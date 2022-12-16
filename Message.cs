

#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using DataJuggler.Blazor.Components.Interfaces;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class Message
    /// <summary>
    /// This class is used to send Data between a IBlazorComponent and an IBlazorComponentParent.
    /// </summary>
    public class Message
    {

        #region Private Variables
        private string text;
        private IBlazorComponent sender;
        private List<NamedParameter> parameters;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Message object.
        /// </summary>
        public Message()
        {
            // Create the Parameters
            this.Parameters = new List<NamedParameter>();
        }
        #endregion

        #region Properties

            #region HasParameters
            /// <summary>
            /// This property returns true if this object has a 'Parameters'.
            /// </summary>
            public bool HasParameters
            {
                get
                {
                    // initial value
                    bool hasParameters = (this.Parameters != null);
                    
                    // return value
                    return hasParameters;
                }
            }
            #endregion
            
            #region HasSender
            /// <summary>
            /// This property returns true if this object has a 'Sender'.
            /// </summary>
            public bool HasSender
            {
                get
                {
                    // initial value
                    bool hasSender = (this.Sender != null);
                    
                    // return value
                    return hasSender;
                }
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
            
            #region Parameters
            /// <summary>
            /// This property gets or sets the value for 'Parameters'.
            /// </summary>
            public List<NamedParameter> Parameters
            {
                get { return parameters; }
                set { parameters = value; }
            }
            #endregion
            
            #region Sender
            /// <summary>
            /// This property gets or sets the value for 'Sender'.
            /// </summary>
            public IBlazorComponent Sender
            {
                get { return sender; }
                set { sender = value; }
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
            
        #endregion

    }
    #endregion

}
