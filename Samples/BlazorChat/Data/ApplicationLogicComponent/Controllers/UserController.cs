

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class UserController
    /// <summary>
    /// This class controls a(n) 'User' object.
    /// </summary>
    public class UserController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'UserController' object.
        /// </summary>
        public UserController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateUserParameter
            /// <summary>
            /// This method creates the parameter for a 'User' data operation.
            /// </summary>
            /// <param name='user'>The 'User' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateUserParameter(User user)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = user;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(User tempUser)
            /// <summary>
            /// Deletes a 'User' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'User_Delete'.
            /// </summary>
            /// <param name='user'>The 'User' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(User tempUser)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteUser";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempuser exists before attemptintg to delete
                    if(tempUser != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteUserMethod = this.AppController.DataBridge.DataOperations.UserMethods.DeleteUser;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUserParameter(tempUser);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteUserMethod, parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(User tempUser)
            /// <summary>
            /// This method fetches a collection of 'User' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'User_FetchAll'.</summary>
            /// <param name='tempUser'>A temporary User for passing values.</param>
            /// <returns>A collection of 'User' objects.</returns>
            public List<User> FetchAll(User tempUser)
            {
                // Initial value
                List<User> userList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.UserMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateUserParameter(tempUser);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<User> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        userList = (List<User>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return userList;
            }
            #endregion

            #region Find(User tempUser)
            /// <summary>
            /// Finds a 'User' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'User_Find'</param>
            /// </summary>
            /// <param name='tempUser'>A temporary User for passing values.</param>
            /// <returns>A 'User' object if found else a null 'User'.</returns>
            public User Find(User tempUser)
            {
                // Initial values
                User user = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempUser != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.UserMethods.FindUser;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUserParameter(tempUser);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as User != null))
                        {
                            // Get ReturnObject
                            user = (User) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return user;
            }
            #endregion

            #region Insert(User user)
            /// <summary>
            /// Insert a 'User' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'User_Insert'.</param>
            /// </summary>
            /// <param name='user'>The 'User' object to insert.</param>
            /// <returns>The id (int) of the new  'User' object that was inserted.</returns>
            public int Insert(User user)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Userexists
                    if(user != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.UserMethods.InsertUser;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUserParameter(user);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref User user)
            /// <summary>
            /// Saves a 'User' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='user'>The 'User' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref User user)
            {
                // Initial value
                bool saved = false;

                // If the user exists.
                if(user != null)
                {
                    // Is this a new User
                    if(user.IsNew)
                    {
                        // Insert new User
                        int newIdentity = this.Insert(user);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            user.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update User
                        saved = this.Update(user);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(User user)
            /// <summary>
            /// This method Updates a 'User' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'User_Update'.</param>
            /// </summary>
            /// <param name='user'>The 'User' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(User user)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(user != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.UserMethods.UpdateUser;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUserParameter(user);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
