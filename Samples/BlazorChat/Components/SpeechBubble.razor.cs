

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
    public partial class SpeechBubble : IBlazorComponent
    {
        
        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        private double opacity;
        private int xPosition;
        private int yPosition;
        private BubbleColorEnum bubbleColor;
        private SubscriberMessage message;
        private string imageUrl;
        private string textStyle;
        private string text;        
        private string bubbleStyle;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of the SpeechBubble.
        /// </summary>
        public SpeechBubble()
        {
            // Start and 1 and it goes backwards
            this.Opacity = 1;                
            XPosition = 0;
            YPosition = 0;
        }
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

                    // Set the ImageUrl
                    ImageUrl = "../Images/Bubbles/SpeechBubble" + bubbleUrl;
                }
            }
            #endregion
            
            #region BubbleStyle
            /// <summary>
            /// This property gets or sets the value for 'BubbleStyle'.
            /// </summary>
            public string BubbleStyle
            {
                get { return bubbleStyle; }
                set { bubbleStyle = value; }
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

                        // create a Shuffler
                        RandomShuffler shuffler = new RandomShuffler(1, 6, 10, 10);

                        // get the bubbleColor
                        BubbleColorEnum bubbleColor = (BubbleColorEnum) shuffler.PullNextItem();

                        // Set the ImageUrl
                        this.ImageUrl = "../Images/Bubbles" + bubbleColor.ToString() + ".png";
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
