

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using Microsoft.AspNetCore.Components;
using DataJuggler.RandomShuffler;
using DataJuggler.RandomShuffler.Core;
using BlazorChat.Enumerations;

#endregion

namespace BlazorChat.Components
{

    #region class SpeechBubble
    /// <summary>
    /// This class is used to display SubscriberMessages.
    /// </summary>
    public partial class SpeechBubble : ISpriteSubscriber, IBlazorComponent, IDisposable
    {
        
        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        private double opacity;
        private int xPosition;
        private int yPosition;
        private Sprite sprite;
        private BubbleColorEnum bubbleColor;
        private SubscriberMessage message;
        private string imageUrl;
        private string textStyle;
        private string text;
        private string textLeftStyle;
        private string textTopStyle;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of the SpeechBubble.
        /// </summary>
        public SpeechBubble()
        {
            // Start and 1 and it goes backwards
            this.Opacity = 1;    
            TextLeftStyle = "0%";
            TextTopStyle = "0vh";
        }
        #endregion
        
        #region Methods

            #region Dispose()
            /// <summary>
            /// This method Dispose
            /// </summary>
            public void Dispose()
            {
                // Get rid of the Sprite
                this.Sprite.Timer = null;
            }
            #endregion
            
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
                this.Opacity -= .01;

                // if down to zero and the ParentChat and the Message exists
                if ((Opacity == 0) & (HasParentChat) && (HasMessage))
                {
                    // remove the message
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
                // This is where the Sprite is started   
                this.Sprite = sprite;

                // Create a new instance of a 'RandomShuffler' object.
                RandomShuffler shuffler = new RandomShuffler(5, 60, 10, 10);
                
                // Set the X Position
                this.XPosition = shuffler.PullNextItem();

                // recreate the shuffler for Y
                shuffler = new RandomShuffler(18, 48, 10, 10);

                // Set the Y Position
                this.YPosition = shuffler.PullNextItem();

                // Now set the color

                // recreate the shuffler for Y
                shuffler = new RandomShuffler(1, 6, 10, 10);

                // set the BubbleColor
                BubbleColor = (BubbleColorEnum) shuffler.PullNextItem();

                // local
                int margin = 2;

                // Set up the Text Left & Top
                this.TextLeftStyle = (XPosition + margin) + "%";
                this.TextTopStyle = (YPosition + margin) + "vh";

                // Start the Sprite - starts the Timer
                Sprite.Start();
            }
            #endregion

        #endregion

        #region Properties
            
            #region BubbleColor
            /// <summary>
            /// This property gets or sets the value for 'BubbleColor'.
            /// </summary>
            public BubbleColorEnum BubbleColor
            {
                get { return bubbleColor; }
                set 
                {
                    // set the value
                    bubbleColor = value;

                    // set the bubbleUrl
                    string bubbleUrl = value.ToString() + ".png";

                    // Set the ImageUrl, which sets the value on the Sprite
                    ImageUrl = "../Images/Bubbles/SpeechBubble" + bubbleUrl;
                }
            }
            #endregion
            
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
            
            #region HasSprite
            /// <summary>
            /// This property returns true if this object has a 'Sprite'.
            /// </summary>
            public bool HasSprite
            {
                get
                {
                    // initial value
                    bool hasSprite = (this.Sprite != null);
                    
                    // return value
                    return hasSprite;
                }
            }
            #endregion
            
            #region ImageUrl
            /// <summary>
            /// This property gets or sets the value for 'ImageUrl'.
            /// </summary>
            public string ImageUrl
            {
                get { return imageUrl; }
                set { imageUrl = value; }
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
                set 
                { 
                    message = value;

                    // If the message object exists
                    if (message != null)
                    {
                        // Set the text
                        Text = message.Text;
                    }
                    else
                    {
                        // Erase
                        Text = "";
                    }
                }
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
            
            #region Sprite
            /// <summary>
            /// This property gets or sets the value for 'Sprite'.
            /// </summary>
            public Sprite Sprite
            {
                get { return sprite; }
                set { sprite = value; }
            }
            #endregion
            
            #region Text
            /// <summary>
            /// This property gets or sets the value for 'Text'.
            /// </summary>
            public string Text
            {
                get { return text; }
                set { text = value; }
            }
            #endregion
            
            #region TextLeftStyle
            /// <summary>
            /// This property gets or sets the value for 'TextLeftStyle'.
            /// </summary>
            public string TextLeftStyle
            {
                get { return textLeftStyle; }
                set { textLeftStyle = value; }
            }
            #endregion
            
            #region TextStyle
            /// <summary>
            /// This property gets or sets the value for 'TextStyle'.
            /// </summary>
            public string TextStyle
            {
                get { return textStyle; }
                set { textStyle = value; }
            }
            #endregion
            
            #region TextTopStyle
            /// <summary>
            /// This property gets or sets the value for 'TextTopStyle'.
            /// </summary>
            public string TextTopStyle
            {
                get { return textTopStyle; }
                set { textTopStyle = value; }
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
