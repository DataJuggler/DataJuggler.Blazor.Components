

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public partial class SpeechBubble
    {
        
        #region Private Variables
        private string name;
        private int xPosition;
        private int yPosition;
        private SubscriberMessage message;
        private string textStyle;
        private string text;        
        private string bubbleStyle;
        private string imageUrl;
        private string from;
        private string messageHeader;
        private string textAlign;
        private string leftStyle;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of the SpeechBubble.
        /// </summary>
        public SpeechBubble()
        {
            // Start and 1 and it goes backwards                        
            XPosition = 0;
            YPosition = 0;
        }
        #endregion
        
        #region Methods
            
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
            
            #region From
            /// <summary>
            /// This property gets or sets the value for 'From'.
            /// </summary>
            public string From
            {
                get { return from; }
                set { from = value; }
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
            
            #region LeftStyle
            /// <summary>
            /// This property gets or sets the value for 'LeftStyle'.
            /// </summary>
            public string LeftStyle
            {
                get { return leftStyle; }
                set { leftStyle = value; }
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
                        From = message.FromName;

                         // Use 4 percent
                        LeftStyle = "4%";
                        TextAlign = "left";

                        // Set the ImageUrl
                        ImageUrl = message.ImageUrl;
                    }
                    else
                    {
                        // Erase
                        Text = "";
                    }
                }
            }
            #endregion
            
            #region MessageHeader
            /// <summary>
            /// This property gets or sets the value for 'MessageHeader'.
            /// </summary>
            public string MessageHeader
            {
                get { return messageHeader; }
                set { messageHeader = value; }
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
            
            #region TextAlign
            /// <summary>
            /// This property gets or sets the value for 'TextAlign'.
            /// </summary>
            public string TextAlign
            {
                get { return textAlign; }
                set { textAlign = value; }
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
