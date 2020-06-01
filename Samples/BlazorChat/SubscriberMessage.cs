

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorChat.Enumerations;

#endregion

namespace BlazorChat
{

    #region class SubscriberMessage
    /// <summary>
    /// This class is used to send information between components / pages.
    /// </summary>
    public class SubscriberMessage
    {

        #region Private Variables
        private string text;
        private Guid fromId;
        private Guid toId;
        private string fromName;
        private string toName;
        private object data;
        private string valid;
        private DateTime sent;
        private bool isSystemMessage;
        private string invalidReason;
        private BubbleColorEnum bubbleColor;
        private string imageUrl;
        #endregion

        #region Methods

            #region SetImageUrl()
            /// <summary>
            /// This method Set Image Url
            /// </summary>
            public void SetImageUrl()
            {
                // as long as the BubbleColor is set this will work
                if (BubbleColor != BubbleColorEnum.NotSet)
                {  
                    // Set the ImageUrl
                    ImageUrl = "../Images/Bubbles/" + BubbleColor.ToString() + ".png";
                }
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
                    // set the bubbleColor
                    bubbleColor = value;

                    // Set the ImageUrl
                    SetImageUrl();
                }
            }
            #endregion
            
            #region Data
            /// <summary>
            /// This property gets or sets the value for 'Data'.
            /// </summary>
            public object Data
            {
                get { return data; }
                set { data = value; }
            }
            #endregion

            #region FromId
            /// <summary>
            /// This property gets or sets the value for 'FromId'.
            /// </summary>
            public Guid FromId
            {
                get { return fromId; }
                set { fromId = value; }
            }
            #endregion

            #region FromName
            /// <summary>
            /// This property gets or sets the value for 'FromName'.
            /// </summary>
            public string FromName
            {
                get { return fromName; }
                set { fromName = value; }
            }
            #endregion

            #region HasText
            /// <summary>
            /// This property returns true if the 'Text' exists.
            /// </summary>
            public bool HasText
            {
                get
                {
                    // initial value
                    bool hasText = (!String.IsNullOrEmpty(this.Text));
                    
                    // return value
                    return hasText;
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
            
            #region InvalidReason
            /// <summary>
            /// This property gets or sets the value for 'InvalidReason'.
            /// </summary>
            public string InvalidReason
            {
                get { return invalidReason; }
                set { invalidReason = value; }
            }
            #endregion
            
            #region IsSystemMessage
            /// <summary>
            /// This property gets or sets the value for 'IsSystemMessage'.
            /// </summary>
            public bool IsSystemMessage
            {
                get { return isSystemMessage; }
                set { isSystemMessage = value; }
            }
            #endregion
            
            #region Sent
            /// <summary>
            /// This property gets or sets the value for 'Sent'.
            /// </summary>
            public DateTime Sent
            {
                get { return sent; }
                set { sent = value; }
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

            #region ToId
            /// <summary>
            /// This property gets or sets the value for 'ToId'.
            /// </summary>
            public Guid ToId
            {
                get { return toId; }
                set { toId = value; }
            }
            #endregion

            #region ToName
            /// <summary>
            /// This property gets or sets the value for 'ToName'.
            /// </summary>
            public string ToName
            {
                get { return toName; }
                set { toName = value; }
            }
            #endregion

            #region Valid
            /// <summary>
            /// This property gets or sets the value for 'Valid'.
            /// </summary>
            public string Valid
            {
                get { return valid; }
                set { valid = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
