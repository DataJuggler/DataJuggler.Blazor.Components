

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.UltimateHelper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

#endregion

namespace BlazorChat.Services
{

    #region class SubscriberService
    /// <summary>
    /// This class is used to subscribe to services, so other windows get a notification a new message 
    /// came in.
    /// </summary>
    public class SubscriberService
    {
        
        #region Private Variables
        private int count;
        private Guid serverId;
        private List<SubscriberMessage> messages;
        private List<SubscriberCallback> subscribers;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SubscriberService' object.
        /// </summary>
        public SubscriberService()
        {
            // Create a new Guid
            this.ServerId = Guid.NewGuid();
            Subscribers = new List<SubscriberCallback>();
            Messages = new List<SubscriberMessage>();
        }
        #endregion
        
        #region Methods
            
            #region BroadcastMessage(SubscriberMessage message)
            /// <summary>
            /// This method Broadcasts a Message to everyone that ins't blocked.
            /// Note To Self: Add Blocked Feature
            /// </summary>
            public void BroadcastMessage(SubscriberMessage message)
            {
                // if the value for HasSubscribers is true
                if ((HasSubscribers) && (NullHelper.Exists(message)))
                {
                    // if this is a System Message
                    if (!message.IsSystemMessage)
                    {
                        // if there are already messages
                        if (ListHelper.HasOneOrMoreItems(messages))
                        {
                            // Insert at the top
                            Messages.Insert(0, message);
                        }
                        else
                        {
                            // Add this message
                            Messages.Add(message);
                        }
                    }

                    // Iterate the collection of SubscriberCallback objects
                    foreach (SubscriberCallback subscriber in Subscribers)
                    {
                        // Send to everyone but this user
                        if ((subscriber.HasCallback) && (subscriber.Id != message.FromId))
                        {
                            // to do: Add if not blocked

                            // send the message
                            subscriber.Callback(message);
                        }
                    }                    
                }
            }
            #endregion
            
            #region GetMessages()
            /// <summary>
            /// This method returns a list of Messages
            /// </summary>
            public List<SubscriberMessage> GetBroadcastMessages()
            {
                // initial value
                List<SubscriberMessage> messages = this.Messages.Take(10).ToList();
                
                // return value
                return messages;
            }
            #endregion
            
            #region GetSubscriberNames()
            /// <summary>
            /// This method returns a list of Subscriber Names ()
            /// </summary>
            public List<string> GetSubscriberNames()
            {
                // initial value
                List<string> subscriberNames = null;

                // if the value for HasSubscribers is true
                if (HasSubscribers)
                {
                    // create the return value
                    subscriberNames = new List<string>();

                    // Get the SubscriberNamesl in alphabetical order
                    List<SubscriberCallback> sortedNames = Subscribers.OrderBy(x => x.Name).ToList();

                    // Iterate the collection of SubscriberService objects
                    foreach (SubscriberCallback subscriber in sortedNames)
                    {
                        // Add this name
                        subscriberNames.Add(subscriber.Name);
                    }
                }
                
                // return value
                return subscriberNames;
            }
            #endregion
            
            #region Subscribe(string subscriberName)
            /// <summary>
            /// method returns a message with their id
            /// </summary>
            public SubscriberMessage Subscribe(SubscriberCallback subscriber)
            {
                // initial value
                SubscriberMessage message = null;

                // If the subscriber object exists
                if ((NullHelper.Exists(subscriber)) && (HasSubscribers))
                {
                    // Add this item
                    Subscribers.Add(subscriber);    

                    // return a test message for now
                    message = new SubscriberMessage();
                
                    // set the message return properties
                    message.FromName = "Subscriber Service";
                    message.FromId = ServerId;
                    message.ToName = subscriber.Name;
                    message.ToId = subscriber.Id;
                    message.Data = Subscribers.Count.ToString();
                    message.Text = "Subscribed";
                }
                
                // return value
                return message;
            }
            #endregion

            #region Unsubscribe(Guid id)
            /// <summary>
            /// This method Unsubscribe
            /// </summary>
            public void Unsubscribe(Guid id)
            {
                // if the value for HasSubscribers is true
                if ((HasSubscribers) && (Subscribers.Count > 0))
                {
                    // attempt to find this callback
                    SubscriberCallback callback = Subscribers.FirstOrDefault(x => x.Id == id);

                    // If the callback object exists
                    if (NullHelper.Exists(callback))
                    {
                        // Remove this item
                        Subscribers.Remove(callback);

                         // create a new message
                        SubscriberMessage message = new SubscriberMessage();

                        // set the message return properties
                        message.FromId = ServerId;
                        message.FromName = "Subscriber Service";
                        message.Text = callback.Name + " has left the conversation.";
                        message.ToId = Guid.Empty;
                        message.ToName = "Room";
                        message.IsSystemMessage = true;

                        // Broadcast the message to everyone
                        BroadcastMessage(message);
                    }
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Count
            /// <summary>
            /// This property gets or sets the value for 'Count'.
            /// </summary>
            public int Count
            {
                get { return count; }
                set { count = value; }
            }
            #endregion
            
            #region HasSubscribers
            /// <summary>
            /// This property returns true if this object has a 'Subscribers'.
            /// </summary>
            public bool HasSubscribers
            {
                get
                {
                    // initial value
                    bool hasSubscribers = (this.Subscribers != null);
                    
                    // return value
                    return hasSubscribers;
                }
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
            
            #region ServerId
            /// <summary>
            /// This property gets or sets the value for 'ServerId'.
            /// </summary>
            public Guid ServerId
            {
                get { return serverId; }
                set { serverId = value; }
            }
            #endregion
            
            #region Subscribers
            /// <summary>
            /// This property gets or sets the value for 'Subscribers'.
            /// </summary>
            public List<SubscriberCallback> Subscribers
            {
                get { return subscribers; }
                set { subscribers = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
