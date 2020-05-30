

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using Microsoft.AspNetCore.Components;

#endregion

namespace BlazorChat.Components
{

    #region class SpeechBubble
    /// <summary>
    /// This class is used to display SubscriberMessages.
    /// </summary>
    public partial class SpeechBubble : ISpriteSubscriber, IBlazorComponent
    {
        
        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        private double opacity;
        private int xPosition;
        private int yPosition;
        private SubscriberMessage message;
        #endregion
        
        #region Methods

            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // not sure if anything is needed for this
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// method Refresh
            /// </summary>
            public void Refresh()
            {
                // Subtract
                this.Opacity = this.Opacity - .01;

                // if down to zero and the ParentChat and the Message exists
                if ((Opacity == 0) & (HasParentChat) && (HasMessage))
                {
                    ParentChat.RemoveMessage(Message);
                }
            }
            #endregion
            
            #region Register(Sprite sprite)
            /// <summary>
            /// method Register
            /// </summary>
            public void Register(Sprite sprite)
            {
                
            }
        #endregion

        #endregion

        #region Properties
            
            #region HasMessage
            /// <summary>
            /// This property returns true if this object has a 'Message'.
            /// </summary>
            public bool HasMessage
            {
                get
                {
                    // initial value
                    bool hasMessage = (this.Message != null);
                    
                    // return value
                    return hasMessage;
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
            
            #region HasParentChat
            /// <summary>
            /// This property returns true if this object has a 'ParentChat'.
            /// </summary>
            public bool HasParentChat
            {
                get
                {
                    // initial value
                    bool hasParentChat = (this.ParentChat != null);
                    
                    // return value
                    return hasParentChat;
                }
            }
            #endregion
            
            #region Message
            /// <summary>
            /// This property gets or sets the value for 'Message'.
            /// </summary>
            [Parameter]
            public SubscriberMessage Message
            {
                get { return message; }
                set { message = value; }
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
            
            #region Opacity
            /// <summary>
            /// This property gets or sets the value for 'Opacity'.
            /// </summary>
            public double Opacity
            {
                get { return opacity; }
                set { opacity = value; }
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

                    // if the Parent exists
                    if (HasParent)
                    {
                        // Register with the parent
                        parent.Register(this);
                    }
               }
            }
            #endregion

            #region ParentChat
            /// <summary>
            /// This is used to get a reference to the hosting Chat component
            /// by casting the Parent as a Chat object.
            /// </summary>
            public Chat ParentChat
            {
                get
                {
                    // initial value
                    Chat chat = this.Parent as Chat;

                    // return value
                    return chat;
                }
            }
            #endregion
            
            #region XPosition
            /// <summary>
            /// This property gets or sets the value for 'XPosition'.
            /// </summary>
            [Parameter]
            public int XPosition
            {
                get { return xPosition; }
                set { xPosition = value; }
            }
            #endregion
            
            #region YPosition
            /// <summary>
            /// This property gets or sets the value for 'YPosition'.
            /// </summary>
            [Parameter]
            public int YPosition
            {
                get { return yPosition; }
                set { yPosition = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
