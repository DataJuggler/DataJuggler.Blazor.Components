
#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace DataAccessComponent.DataManager.Writers
{

    #region class UserWriter
    /// <summary>
    /// This class is used for converting a 'User' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class UserWriter : UserWriterBase
    {

        #region Static Methods

            #region CreateFindUserStoredProcedure(User user)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindUserStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'User_Find'.
            /// </summary>
            /// <param name="user">The 'User' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindUserStoredProcedure CreateFindUserStoredProcedure(User user)
            {
                // Initial Value
                FindUserStoredProcedure findUserStoredProcedure = null;

                // verify user exists
                if(user != null)
                {
                    // Instanciate findUserStoredProcedure
                    findUserStoredProcedure = new FindUserStoredProcedure();

                    // if user.FindByEmailAddress is true
                    if (user.FindByEmailAddress)
                    {
                        // Change the procedure name
                        findUserStoredProcedure.ProcedureName = "User_FindByEmailAddress";
                        
                        // Create the @EmailAddress parameter
                        findUserStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@EmailAddress", user.EmailAddress);
                    }
                    // if user.FindByUserName is true
                    else if (user.FindByUserName)
                    {
                        // Change the procedure name
                        findUserStoredProcedure.ProcedureName = "User_FindByUserName";
                        
                        // Create the @UserName parameter
                        findUserStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@UserName", user.UserName);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findUserStoredProcedure.Parameters = CreatePrimaryKeyParameter(user);
                    }
                }

                // return value
                return findUserStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
