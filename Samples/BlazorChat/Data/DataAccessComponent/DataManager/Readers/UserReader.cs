

#region using statements

using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class UserReader
    /// <summary>
    /// This class loads a single 'User' object or a list of type <User>.
    /// </summary>
    public class UserReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'User' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'User' DataObject.</returns>
            public static User Load(DataRow dataRow)
            {
                // Initial Value
                User user = new User();

                // Create field Integers
                int activefield = 0;
                int createdDatefield = 1;
                int emailAddressfield = 2;
                int emailVerifiedfield = 3;
                int idfield = 4;
                int isAdminfield = 5;
                int lastLoginDatefield = 6;
                int namefield = 7;
                int passwordHashfield = 8;
                int premiumfield = 9;
                int premiumExpiresfield = 10;
                int totalLoginsfield = 11;
                int userNamefield = 12;

                try
                {
                    // Load Each field
                    user.Active = DataHelper.ParseBoolean(dataRow.ItemArray[activefield], false);
                    user.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    user.EmailAddress = DataHelper.ParseString(dataRow.ItemArray[emailAddressfield]);
                    user.EmailVerified = DataHelper.ParseBoolean(dataRow.ItemArray[emailVerifiedfield], false);
                    user.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    user.IsAdmin = DataHelper.ParseBoolean(dataRow.ItemArray[isAdminfield], false);
                    user.LastLoginDate = DataHelper.ParseDate(dataRow.ItemArray[lastLoginDatefield]);
                    user.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    user.PasswordHash = DataHelper.ParseString(dataRow.ItemArray[passwordHashfield]);
                    user.Premium = DataHelper.ParseBoolean(dataRow.ItemArray[premiumfield], false);
                    user.PremiumExpires = DataHelper.ParseDate(dataRow.ItemArray[premiumExpiresfield]);
                    user.TotalLogins = DataHelper.ParseInteger(dataRow.ItemArray[totalLoginsfield], 0);
                    user.UserName = DataHelper.ParseString(dataRow.ItemArray[userNamefield]);
                }
                catch
                {
                }

                // return value
                return user;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'User' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A User Collection.</returns>
            public static List<User> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<User> users = new List<User>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'User' from rows
                        User user = Load(row);

                        // Add this object to collection
                        users.Add(user);
                    }
                }
                catch
                {
                }

                // return value
                return users;
            }
            #endregion

        #endregion

    }
    #endregion

}
