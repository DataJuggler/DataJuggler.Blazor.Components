

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private string invalidReason;
        #endregion

        #region Properties

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
