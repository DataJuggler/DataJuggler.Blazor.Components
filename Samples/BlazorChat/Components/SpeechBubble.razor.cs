

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DataJuggler.RandomShuffler;
using DataJuggler.RandomShuffler.Core;
using BlazorChat.Enumerations;
using DataJuggler.UltimateHelper.Core;
using DataJuggler.UltimateHelper.Core.Objects;

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
        private string htmlText;
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
            
            #region ContainsLink()
            /// <summary>
            /// This method returns the Link Start
            /// </summary>
            public bool ContainsLink(string text)
            {
                // initial value
                bool containsLink = false;
                
                // not an href already
                if ((TextHelper.Exists(text)) && (!text.Contains("<a href")))
                {
                    // set the return value
                    containsLink = ((text.Contains("http") || (text.Contains("https"))));
                }

                // return value
                return containsLink;
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
            
            #region ReplaceLinksWithHref(ApplicationLogicComponent)
            /// <summary>
            /// This method returns the Links With Href
            /// </summary>
            public string ReplaceLinksWithHref(string text)
            {
                // initial value
                string formattedText = text;

                // delimiters
                char[] delimiters = { ' ', '\n', };

                // If the text string exists
                if (ContainsLink(text))
                {
                    // if the NewLine is not found
                    if (!text.Contains(Environment.NewLine))
                    {
                        // The parsing on lines isn't working, this is a good hack till
                        // I rewrite the parser to be more robust someday
                        text = text.Replace("\n", Environment.NewLine);
                    }

                    // just in case, fix for the hack
                    text = text.Replace("\r\r", "\r");

                    // Get the text lines
                    List<TextLine> lines = WordParser.GetTextLines(text);

                    // If the lines collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(lines))
                    {
                        // iterate the textLines
                        foreach(TextLine line in lines)
                        {
                            // Get the words - parse only on space
                            List<Word> words = WordParser.GetWords(line.Text, delimiters);
                    
                            // If the words collection exists and has one or more items
                            if (ListHelper.HasOneOrMoreItems(words))
                            {
                                // iterate each word
                                foreach (Word word in words)
                                {
                                    // if this is a link
                                    if (StartsWithLink(word.Text))
                                    {
                                        // set the word as a href
                                        string temp = "<a href=" + word.Text + " target=_blank>" + word.Text + "</a>";

                                        // Replace out the word with the link
                                        formattedText = formattedText.Replace(word.Text, temp);
                                    }
                                }
                            }
                        }
                    }
                }
                
                // return value
                return formattedText;
            }
            #endregion
            
            #region StartsWithLink(string text)
            /// <summary>
            /// This method returns the With Link
            /// </summary>
            public bool StartsWithLink(string text)
            {
                // initial value
                bool startsWithLink = false;

                 // not an href already
                if (TextHelper.Exists(text))
                {
                    // set the return value
                    startsWithLink = ((text.StartsWith("http") || (text.StartsWith("https"))));
                }
                
                // return value
                return startsWithLink;
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

            #region FullFrom
            /// <summary>
            /// This read only property appends the word [Private] if the message is private
            /// </summary>
            private string FullFrom
            {
                get
                {
                    // initial value
                    string fullFrom = From;

                    // if the Message exists and is private
                    if ((HasMessage) && (Message.IsPrivate))
                    {
                        // Set the text as private
                        fullFrom = From + " [Private]";
                    }

                    // return value
                    return fullFrom;
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
            
            #region HtmlText
            /// <summary>
            /// This property gets or sets the value for 'HtmlText'.
            /// </summary>
            public string HtmlText
            {
                get { return htmlText; }
                set { htmlText = value; }
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
                set 
                { 
                    // set the value
                    text = value;

                    // set the value for htemlText
                    htmlText = ReplaceLinksWithHref(text);
                }
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
