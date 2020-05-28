
#region using statements

using DataJuggler.Net.Core.Enumerations;
using DataJuggler.UltimateHelper.Core;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;

#endregion

namespace DataGateway.Services
{

    #region class UserDataWatcher
    /// <summary>
    /// This class is used to hold a delegate so when changes occur in a 
    /// User item, the delegate is notified so the values are saved.
    /// </summary>
    public class UserDataWatcher
    {

        #region Methods

            #region ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            /// <summary>
            /// This method Item Changed
            /// </summary>
            public async void ItemChanged(object itemChanged, ChangeTypeEnum listChangeType)
            {
                // cast the item as a ToDo object
                User user = itemChanged as User;

                // If the user object exists
                if (NullHelper.Exists(user))
                {
                    // perform the saved
                    bool saved = await UserService.SaveUser(ref user);
                }
            }
            #endregion

            #region Watch(List<User> user)
            /// <summary>
            /// This method watches the current list by setting a delegate for each item.
            /// </summary>
            /// <param name="users">The list of User objects to set a delegate on.</param>
            public void Watch(List<User> users)
            {
                // If the users collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(users))
                {
                    // Iterate the collection of User objects
                    foreach (User user in users)
                    {
                        // Setup the Callback for each item
                       user.Callback = ItemChanged;
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
