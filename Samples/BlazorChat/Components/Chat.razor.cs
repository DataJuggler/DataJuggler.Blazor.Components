﻿

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataJuggler.RandomShuffler.Core;
using DataJuggler.UltimateHelper.Core;
using ObjectLibrary.BusinessObjects;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using Microsoft.AspNetCore.Components;
using BlazorChat.Enumerations;
using Microsoft.AspNetCore.Mvc.Filters;

#endregion

namespace BlazorChat.Components
{

    #region class Chat
    /// <summary>
    /// This component is used to demonstrate a Chat sample.
    /// </summary>
    public partial class Chat : IBlazorComponent, IBlazorComponentParent, IDisposable
    {
        
        #region Private Variables
        private User user;
        private string name;
        private string subscriberName;
        private Guid id;
        private bool connected;
        private string messageText;
        private IBlazorComponentParent parent;
        private List<SubscriberMessage> messages;
        private List<IBlazorComponent> children;
        private List<SubscriberCallback> names;
        private RandomShuffler shuffler;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Chat object
        /// </summary>
        public Chat()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events
    
            #region SendPrivateMessageClicked(EventArgs args, Guid toId)
            /// <summary>
            /// This method is used to send a Private message to a user
            /// </summary>
            /// <param name="args"></param>
            /// <param name="toId"></param>
            private void SendPrivateMessageClicked(EventArgs args, Guid toId)
            {
                // Attempt to find the subscriber
                SubscriberCallback subscriber = SubscriberService.FindSubscriber(toId);

                // If the subscriber object exists
                if (NullHelper.Exists(subscriber))
                {
                     // Send a message
                    SendMessage(true, subscriber);
                }
            }
            #endregion
        
        #endregion

        #region Methods

            #region BroadCastMessage()
            /// <summary>
            /// This method Broad Cast Message
            /// </summary>
            public void BroadCastMessage()
            {
                // Send a message
                SendMessage(false);
            }
            #endregion
            
            #region Dispose()
            /// <summary>
            /// This method Dispose
            /// </summary>
            public void Dispose()
            {
                // If the SubscriberService object exists
                if (NullHelper.Exists(SubscriberService))
                {
                    // Unsubscribe from the service
                    SubscriberService.Unsubscribe(Id);
                }
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // initial value
                IBlazorComponent child = null;

                // if the value for HasChildren is true
                if (HasChildren)
                {
                    // Iterate the collection of IBlazorComponent objects
                    foreach (IBlazorComponent tempChild in Children)
                    {
                        // if this is the item being sought
                        if (TextHelper.IsEqual(tempChild.Name, name))
                        {
                            // set the return value
                            child = tempChild;

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return child;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a Guid
                this.Id = Guid.Empty;

                // Create a Shuffler
                Shuffler = new RandomShuffler(1, 6, 1, 10);
            }
            #endregion
            
            #region Listen(SubscriberMessage message)
            /// <summary>
            /// This method Listen
            /// </summary>
            public void Listen(SubscriberMessage message)
            {
                // if the message exists
                if (NullHelper.Exists(message))
                {
                    // if the message is a SystemMessage
                    if (message.IsSystemMessage)
                    {   
                        // Get the Names again
                        this.Names = SubscriberService.GetSubscriberNames();

                        // Update the UI
                        Refresh();
                    }
                    else
                    {  
                        // Get the Messages
                        this.Messages = SubscriberService.GetBroadcastMessages(this.Id);

                        // Update the UI
                        Refresh();                   
                    }
                }
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // If the message object exists
                if (NullHelper.Exists(message))
                {
                    // if the message is Logged In User Is Set
                    if (TextHelper.IsEqual(message.Text, "Logged In User Is Set"))
                    {
                        // Set the User
                        User = ParentIndexPage.LoggedInUser;

                        // if the value for HasUser is true
                        if (HasUser)
                        {
                            // Set the SubscriberName for them
                            SubscriberName = User.Name;
                        }
                    }
                }

                // Update
                Refresh();
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// This method is called by a Sprite when as it refreshes.
            /// </summary>
            public void Refresh()
            {
                // Update the UI
                InvokeAsync(() =>
                {
                    // Refresh
                    StateHasChanged();
                });
            }
            #endregion

            #region Register(IBlazorComponent component)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                
            }
            #endregion
            
            #region RegisterWithServer()
            /// <summary>
            /// This event registers with the chat server
            /// </summary>
            public void RegisterWithServer()
            {
                SubscriberCallback callback = new SubscriberCallback(SubscriberName);
                callback.Callback = Listen;
                callback.Name = SubscriberName;

                // Get a message back
                SubscriberMessage message = SubscriberService.Subscribe(callback);

                // if message.Text exists and equals Subscribed
                if ((NullHelper.Exists(message)) && (message.HasText) && (TextHelper.IsEqual(message.Text, "Subscribed")))
                {   
                    // Set to true
                    Connected = true;

                    // Set the Id the Server assigned
                    this.Id = message.ToId;
                }

                // Convert the Subscribers to Names
                this.Names = SubscriberService.GetSubscriberNames();

                // get the count
                int count = NumericHelper.ParseInteger(message.Data.ToString(), 0, -1);

                // if there are two people online or more
                if (count > 1)
                {
                    // send a message to everyone else this user has joined
                    SubscriberMessage newMessage = new SubscriberMessage();

                    // set the text
                    newMessage.FromId = Id;
                    newMessage.FromName = SubscriberName;
                    newMessage.Text = SubscriberName + " has joined the conversation.";
                    newMessage.ToId = Guid.Empty;
                    newMessage.ToName = "Room";
                    newMessage.IsSystemMessage = true;
                    
                    // Send the message
                    SubscriberService.BroadcastMessage(newMessage);
                }

                // Update
                Refresh();
            }
            #endregion
            
            #region SendMessage(bool isPrivate = false, SubscriberCallback subscriber = null)
            /// <summary>
            /// This method Send Message
            /// </summary>
            public void SendMessage(bool isPrivate = false, SubscriberCallback subscriber = null)
            {  
                // Create a new instance of a 'SubscriberMessage' object.                    
                SubscriberMessage message = null;

                // Create a new instance of a 'SubscriberMessage' object.                    
                message = new SubscriberMessage();
                message.Text = MessageText;
                message.FromId = Id;
                message.FromName = SubscriberName;

                // Set the Time
                message.Sent = DateTime.Now;
        
                // Set the 
                message.BubbleColor = (BubbleColorEnum) Shuffler.PullNextItem();    

                try
                {
                    // If the MessageText string exists
                    if (TextHelper.Exists(MessageText))
                    {
                        // if this is a private message
                        if ((isPrivate) && (NullHelper.Exists(subscriber)) && (subscriber.HasCallback))
                        {
                             // Set the ToName
                            message.ToName = subscriber.Name;
                            message.ToId = subscriber.Id;
                            
                            // This is a private message
                            message.IsPrivate = true;
                            
                            //  Send this message to all clients
                            SubscriberService.SendPrivateMessage(subscriber, message);
                        }
                        else
                        {
                            // Set the ToName
                            message.ToName = "Room";
                            message.ToId = Guid.Empty;
                            
                            //  Send this message to all clients
                            SubscriberService.BroadcastMessage(message);
                        }

                        // Erase the Text
                        MessageText = "";

                        // Deliver the message to this client, without being Broadcast
                        Listen(message);
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("BroadCastMessage", "Chat.razor.cs", error);
                }
            }
            #endregion
            
            #region SendPrivateMessage(Guid toId)
            /// <summary>
            /// This method Send Private Message
            /// </summary>
            public void SendPrivateMessage(Guid toId)
            {
                // if the toId is set
                if (toId != Guid.Empty)
                {
                    // Attempt to find the subscriber
                    SubscriberCallback subscriber = SubscriberService.FindSubscriber(toId);

                    // If the subscriber object exists
                    if (NullHelper.Exists(subscriber))
                    {
                        // Send the private message
                        SendMessage(true, subscriber);
                    }
                }
            }
            #endregion
            
            #region SignOut()
            /// <summary>
            /// This method Sign Out the user
            /// </summary>
            public void SignOut()
            {
                // Sign out
                this.SubscriberName = "";
                this.User = null;

                // Update the UI
                Refresh();
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region Children
            /// <summary>
            /// This property gets or sets the value for 'Children'.
            /// </summary>
            public List<IBlazorComponent> Children
            {
                get { return children; }
                set { children = value; }
            }
            #endregion
            
            #region Connected
            /// <summary>
            /// This property gets or sets the value for 'Connected'.
            /// </summary>
            public bool Connected
            {
                get { return connected; }
                set { connected = value; }
            }
            #endregion
            
            #region HasChildren
            /// <summary>
            /// This property returns true if this object has a 'Children'.
            /// </summary>
            public bool HasChildren
            {
                get
                {
                    // initial value
                    bool hasChildren = (this.Children != null);
                    
                    // return value
                    return hasChildren;
                }
            }
            #endregion
            
            #region HasMessages
            /// <summary>
            /// This property returns true if this object has a 'Messages'.
            /// </summary>
            public bool HasMessages
            {
                get
                {
                    // initial value
                    bool hasMessages = (this.Messages != null);
                    
                    // return value
                    return hasMessages;
                }
            }
            #endregion
            
            #region HasParent
            /// <summary>
            /// This property returns true if this object has a 'Parent'.
            /// </summary>
            public bool HasParent
            {
                get
                {
                    // initial value
                    bool hasParent = (this.Parent != null);
                    
                    // return value
                    return hasParent;
                }
            }
            #endregion
            
            #region HasParentIndexPage
            /// <summary>
            /// This property returns true if this object has a 'ParentIndexPage'.
            /// </summary>
            public bool HasParentIndexPage
            {
                get
                {
                    // initial value
                    bool hasParentIndexPage = (this.ParentIndexPage != null);
                    
                    // return value
                    return hasParentIndexPage;
                }
            }
            #endregion
            
            #region HasShuffler
            /// <summary>
            /// This property returns true if this object has a 'Shuffler'.
            /// </summary>
            public bool HasShuffler
            {
                get
                {
                    // initial value
                    bool hasShuffler = (this.Shuffler != null);
                    
                    // return value
                    return hasShuffler;
                }
            }
            #endregion
            
            #region HasUser
            /// <summary>
            /// This property returns true if this object has an 'User'.
            /// </summary>
            public bool HasUser
            {
                get
                {
                    // initial value
                    bool hasUser = (this.User != null);
                    
                    // return value
                    return hasUser;
                }
            }
            #endregion
            
            #region Id
            /// <summary>
            /// This property gets or sets the value for 'Id'.
            /// </summary>
            public Guid Id
            {
                get { return id; }
                set { id = value; }
            }
            #endregion
            
            #region Messages
            /// <summary>
            /// This property gets or sets the value for 'Messages'.
            /// </summary>
            public List<SubscriberMessage> Messages
            {
                get { return messages; }
                set { messages = value; }
            }
            #endregion
            
            #region MessageText
            /// <summary>
            /// This property gets or sets the value for 'MessageText'.
            /// </summary>
            public string MessageText
            {
                get { return messageText; }
                set { messageText = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Names
            /// <summary>
            /// This property gets or sets the value for 'Names'.
            /// </summary>
            public List<SubscriberCallback> Names
            {
                get { return names; }
                set { names = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get { return parent; }
                set 
                { 
                    // set the value
                    parent = value;

                    // Register with the parent
                    parent.Register(this);
                }
            }
            #endregion

            #region ParentIndexPage
            /// <summary>
            /// This read only property returns the value for 'ParentIndexPage'.
            /// </summary>
            public Pages.Index ParentIndexPage
            {
                get
                {
                    // cast the parent as an Index page
                    return this.Parent as Pages.Index;
                }
            }
            #endregion
            
            #region Shuffler
            /// <summary>
            /// This property gets or sets the value for 'Shuffler'.
            /// </summary>
            public RandomShuffler Shuffler
            {
                get { return shuffler; }
                set { shuffler = value; }
            }
            #endregion
            
            #region SubscriberName
            /// <summary>
            /// This property gets or sets the value for 'SubscriberName'.
            /// </summary>
            public string SubscriberName
            {
                get { return subscriberName; }
                set { subscriberName = value; }
            }
            #endregion
            
            #region User
            /// <summary>
            /// This property gets or sets the value for 'User'.
            /// </summary>
            public User User
            {
                get { return user; }
                set { user = value; }
            }        
            #endregion

        #endregion

    }
    #endregion

}
