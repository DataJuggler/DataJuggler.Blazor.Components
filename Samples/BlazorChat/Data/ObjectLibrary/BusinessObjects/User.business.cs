
#region using statements

using System;
using DataJuggler.Net.Core.Delegates;
using DataJuggler.Net.Core.Enumerations;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class User
    [Serializable]
    public partial class User
    {

        #region Private Variables
        private bool findByEmailAddress;
        private bool findByUserName;
        #endregion

        #region Constructor
        public User()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public User Clone()
            {
                // Create New Object
                User newUser = (User) this.MemberwiseClone();

                // Return Cloned Object
                return newUser;
            }
            #endregion

        #endregion

        #region Properties

            #region FindByEmailAddress
            /// <summary>
            /// This property gets or sets the value for 'FindByEmailAddress'.
            /// </summary>
            public bool FindByEmailAddress
            {
                get { return findByEmailAddress; }
                set { findByEmailAddress = value; }
            }
            #endregion

            #region FindByUserName
            /// <summary>
            /// This property gets or sets the value for 'FindByUserName'.
            /// </summary>
            public bool FindByUserName
            {
                get { return findByUserName; }
                set { findByUserName = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
