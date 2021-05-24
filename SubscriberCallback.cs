

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class SubscriberCallback
    /// <summary>
    /// This class is used to register a subscriber with the ChatService
    /// </summary>
    public class SubscriberCallback
    {
        
        #region Private Variables
        private string name;
        private Guid id;
        private Callback callback;
        private List<Guid> blockedList;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a SubscriberCallback instance
        /// </summary>
        public SubscriberCallback(string name)
        {
            // store the Name
            Name = name;

            // Create the Id
            Id = Guid.NewGuid();

            // create a BlockedList
            BlockedList = new List<Guid>();
        }
        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// This method is used to return the Name of the Subscriber when ToString is called.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // return the Name when ToString is called
                return this.Name;
            }
            #endregion

        #endregion

        #region Properties

            #region BlockedList
            /// <summary>
            /// This property gets or sets the value for 'BlockedList'.
            /// </summary>
            public List<Guid> BlockedList
            {
                get { return blockedList; }
                set { blockedList = value; }
            }
            #endregion
            
            #region Callback
            /// <summary>
            /// This property gets or sets the value for 'Callback'.
            /// </summary>
            public Callback Callback
            {
                get { return callback; }
                set { callback = value; }
            }
            #endregion
            
            #region HasBlockedList
            /// <summary>
            /// This property returns true if this object has a 'BlockedList'.
            /// </summary>
            public bool HasBlockedList
            {
                get
                {
                    // initial value
                    bool hasBlockedList = (this.BlockedList != null);
                    
                    // return value
                    return hasBlockedList;
                }
            }
            #endregion
            
            #region HasCallback
            /// <summary>
            /// This property returns true if this object has a 'Callback'.
            /// </summary>
            public bool HasCallback
            {
                get
                {
                    // initial value
                    bool hasCallback = (this.Callback != null);
                    
                    // return value
                    return hasCallback;
                }
            }
            #endregion
            
            #region HasName
            /// <summary>
            /// This property returns true if the 'Name' exists.
            /// </summary>
            public bool HasName
            {
                get
                {
                    // initial value
                    bool hasName = (!String.IsNullOrEmpty(this.Name));
                    
                    // return value
                    return hasName;
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
            
        #endregion

    }
    #endregion

}
