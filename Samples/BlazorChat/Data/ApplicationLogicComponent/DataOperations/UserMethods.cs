

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class UserMethods
    /// <summary>
    /// This class contains methods for modifying a 'User' object.
    /// </summary>
    public class UserMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'UserMethods' object.
        /// </summary>
        public UserMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteUser(User)
            /// <summary>
            /// This method deletes a 'User' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'User' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteUser(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteUserStoredProcedure deleteUserProc = null;

                    // verify the first parameters is a(n) 'User'.
                    if (parameters[0].ObjectValue as User != null)
                    {
                        // Create User
                        User user = (User) parameters[0].ObjectValue;

                        // verify user exists
                        if(user != null)
                        {
                            // Now create deleteUserProc from UserWriter
                            // The DataWriter converts the 'User'
                            // to the SqlParameter[] array needed to delete a 'User'.
                            deleteUserProc = UserWriter.CreateDeleteUserStoredProcedure(user);
                        }
                    }

                    // Verify deleteUserProc exists
                    if(deleteUserProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.UserManager.DeleteUser(deleteUserProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'User' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'User' to delete.
            /// <returns>A PolymorphicObject object with all  'Users' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<User> userListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllUsersStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get UserParameter
                    // Declare Parameter
                    User paramUser = null;

                    // verify the first parameters is a(n) 'User'.
                    if (parameters[0].ObjectValue as User != null)
                    {
                        // Get UserParameter
                        paramUser = (User) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllUsersProc from UserWriter
                    fetchAllProc = UserWriter.CreateFetchAllUsersStoredProcedure(paramUser);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    userListCollection = this.DataManager.UserManager.FetchAllUsers(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(userListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = userListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindUser(User)
            /// <summary>
            /// This method finds a 'User' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'User' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindUser(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                User user = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindUserStoredProcedure findUserProc = null;

                    // verify the first parameters is a 'User'.
                    if (parameters[0].ObjectValue as User != null)
                    {
                        // Get UserParameter
                        User paramUser = (User) parameters[0].ObjectValue;

                        // verify paramUser exists
                        if(paramUser != null)
                        {
                            // Now create findUserProc from UserWriter
                            // The DataWriter converts the 'User'
                            // to the SqlParameter[] array needed to find a 'User'.
                            findUserProc = UserWriter.CreateFindUserStoredProcedure(paramUser);
                        }

                        // Verify findUserProc exists
                        if(findUserProc != null)
                        {
                            // Execute Find Stored Procedure
                            user = this.DataManager.UserManager.FindUser(findUserProc, dataConnector);

                            // if dataObject exists
                            if(user != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = user;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertUser (User)
            /// <summary>
            /// This method inserts a 'User' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'User' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertUser(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                User user = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertUserStoredProcedure insertUserProc = null;

                    // verify the first parameters is a(n) 'User'.
                    if (parameters[0].ObjectValue as User != null)
                    {
                        // Create User Parameter
                        user = (User) parameters[0].ObjectValue;

                        // verify user exists
                        if(user != null)
                        {
                            // Now create insertUserProc from UserWriter
                            // The DataWriter converts the 'User'
                            // to the SqlParameter[] array needed to insert a 'User'.
                            insertUserProc = UserWriter.CreateInsertUserStoredProcedure(user);
                        }

                        // Verify insertUserProc exists
                        if(insertUserProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.UserManager.InsertUser(insertUserProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateUser (User)
            /// <summary>
            /// This method updates a 'User' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'User' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateUser(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                User user = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateUserStoredProcedure updateUserProc = null;

                    // verify the first parameters is a(n) 'User'.
                    if (parameters[0].ObjectValue as User != null)
                    {
                        // Create User Parameter
                        user = (User) parameters[0].ObjectValue;

                        // verify user exists
                        if(user != null)
                        {
                            // Now create updateUserProc from UserWriter
                            // The DataWriter converts the 'User'
                            // to the SqlParameter[] array needed to update a 'User'.
                            updateUserProc = UserWriter.CreateUpdateUserStoredProcedure(user);
                        }

                        // Verify updateUserProc exists
                        if(updateUserProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.UserManager.UpdateUser(updateUserProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
