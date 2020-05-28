

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class UserManager
    /// <summary>
    /// This class is used to manage a 'User' object.
    /// </summary>
    public class UserManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UserManager' object.
        /// </summary>
        public UserManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteUser()
            /// <summary>
            /// This method deletes a 'User' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteUser(DeleteUserStoredProcedure deleteUserProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteUserProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllUsers()
            /// <summary>
            /// This method fetches a  'List<User>' object.
            /// This method uses the 'Users_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<User>'</returns>
            /// </summary>
            public List<User> FetchAllUsers(FetchAllUsersStoredProcedure fetchAllUsersProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<User> userCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allUsersDataSet = this.DataHelper.LoadDataSet(fetchAllUsersProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allUsersDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allUsersDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            userCollection = UserReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return userCollection;
            }
            #endregion

            #region FindUser()
            /// <summary>
            /// This method finds a  'User' object.
            /// This method uses the 'User_Find' procedure.
            /// </summary>
            /// <returns>A 'User' object.</returns>
            /// </summary>
            public User FindUser(FindUserStoredProcedure findUserProc, DataConnector databaseConnector)
            {
                // Initial Value
                User user = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet userDataSet = this.DataHelper.LoadDataSet(findUserProc, databaseConnector);

                    // Verify DataSet Exists
                    if(userDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(userDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load User
                            user = UserReader.Load(row);
                        }
                    }
                }

                // return value
                return user;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertUser()
            /// <summary>
            /// This method inserts a 'User' object.
            /// This method uses the 'User_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertUser(InsertUserStoredProcedure insertUserProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertUserProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateUser()
            /// <summary>
            /// This method updates a 'User'.
            /// This method uses the 'User_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateUser(UpdateUserStoredProcedure updateUserProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateUserProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
