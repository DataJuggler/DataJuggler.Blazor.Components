

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

    #region class UserWriterBase
    /// <summary>
    /// This class is used for converting a 'User' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class UserWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(User user)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='user'>The 'User' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(User user)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (user != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", user.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteUserStoredProcedure(User user)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteUser'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'User_Delete'.
            /// </summary>
            /// <param name="user">The 'User' to Delete.</param>
            /// <returns>An instance of a 'DeleteUserStoredProcedure' object.</returns>
            public static DeleteUserStoredProcedure CreateDeleteUserStoredProcedure(User user)
            {
                // Initial Value
                DeleteUserStoredProcedure deleteUserStoredProcedure = new DeleteUserStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteUserStoredProcedure.Parameters = CreatePrimaryKeyParameter(user);

                // return value
                return deleteUserStoredProcedure;
            }
            #endregion

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
            public static FindUserStoredProcedure CreateFindUserStoredProcedure(User user)
            {
                // Initial Value
                FindUserStoredProcedure findUserStoredProcedure = null;

                // verify user exists
                if(user != null)
                {
                    // Instanciate findUserStoredProcedure
                    findUserStoredProcedure = new FindUserStoredProcedure();

                    // Now create parameters for this procedure
                    findUserStoredProcedure.Parameters = CreatePrimaryKeyParameter(user);
                }

                // return value
                return findUserStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(User user)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new user.
            /// </summary>
            /// <param name="user">The 'User' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(User user)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[12];
                SqlParameter param = null;

                // verify userexists
                if(user != null)
                {
                    // Create [Active] parameter
                    param = new SqlParameter("@Active", user.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If user.CreatedDate does not exist.
                    if ((user.CreatedDate == null) || (user.CreatedDate.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = user.CreatedDate;
                    }

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [EmailAddress] parameter
                    param = new SqlParameter("@EmailAddress", user.EmailAddress);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [EmailVerified] parameter
                    param = new SqlParameter("@EmailVerified", user.EmailVerified);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [IsAdmin] parameter
                    param = new SqlParameter("@IsAdmin", user.IsAdmin);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [LastLoginDate] Parameter
                    param = new SqlParameter("@LastLoginDate", SqlDbType.DateTime);

                    // If user.LastLoginDate does not exist.
                    if ((user.LastLoginDate == null) || (user.LastLoginDate.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = user.LastLoginDate;
                    }

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", user.Name);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [PasswordHash] parameter
                    param = new SqlParameter("@PasswordHash", user.PasswordHash);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [Premium] parameter
                    param = new SqlParameter("@Premium", user.Premium);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create [PremiumExpires] Parameter
                    param = new SqlParameter("@PremiumExpires", SqlDbType.DateTime);

                    // If user.PremiumExpires does not exist.
                    if ((user.PremiumExpires == null) || (user.PremiumExpires.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = user.PremiumExpires;
                    }

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [TotalLogins] parameter
                    param = new SqlParameter("@TotalLogins", user.TotalLogins);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create [UserName] parameter
                    param = new SqlParameter("@UserName", user.UserName);

                    // set parameters[11]
                    parameters[11] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertUserStoredProcedure(User user)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertUserStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'User_Insert'.
            /// </summary>
            /// <param name="user"The 'User' object to insert</param>
            /// <returns>An instance of a 'InsertUserStoredProcedure' object.</returns>
            public static InsertUserStoredProcedure CreateInsertUserStoredProcedure(User user)
            {
                // Initial Value
                InsertUserStoredProcedure insertUserStoredProcedure = null;

                // verify user exists
                if(user != null)
                {
                    // Instanciate insertUserStoredProcedure
                    insertUserStoredProcedure = new InsertUserStoredProcedure();

                    // Now create parameters for this procedure
                    insertUserStoredProcedure.Parameters = CreateInsertParameters(user);
                }

                // return value
                return insertUserStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(User user)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing user.
            /// </summary>
            /// <param name="user">The 'User' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(User user)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[13];
                SqlParameter param = null;

                // verify userexists
                if(user != null)
                {
                    // Create parameter for [Active]
                    param = new SqlParameter("@Active", user.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [CreatedDate]
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If user.CreatedDate does not exist.
                    if ((user.CreatedDate == null) || (user.CreatedDate.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = user.CreatedDate;
                    }


                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [EmailAddress]
                    param = new SqlParameter("@EmailAddress", user.EmailAddress);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [EmailVerified]
                    param = new SqlParameter("@EmailVerified", user.EmailVerified);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [IsAdmin]
                    param = new SqlParameter("@IsAdmin", user.IsAdmin);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [LastLoginDate]
                    // Create [LastLoginDate] Parameter
                    param = new SqlParameter("@LastLoginDate", SqlDbType.DateTime);

                    // If user.LastLoginDate does not exist.
                    if ((user.LastLoginDate == null) || (user.LastLoginDate.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = user.LastLoginDate;
                    }


                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", user.Name);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [PasswordHash]
                    param = new SqlParameter("@PasswordHash", user.PasswordHash);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [Premium]
                    param = new SqlParameter("@Premium", user.Premium);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [PremiumExpires]
                    // Create [PremiumExpires] Parameter
                    param = new SqlParameter("@PremiumExpires", SqlDbType.DateTime);

                    // If user.PremiumExpires does not exist.
                    if ((user.PremiumExpires == null) || (user.PremiumExpires.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = user.PremiumExpires;
                    }


                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [TotalLogins]
                    param = new SqlParameter("@TotalLogins", user.TotalLogins);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [UserName]
                    param = new SqlParameter("@UserName", user.UserName);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", user.Id);
                    parameters[12] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateUserStoredProcedure(User user)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateUserStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'User_Update'.
            /// </summary>
            /// <param name="user"The 'User' object to update</param>
            /// <returns>An instance of a 'UpdateUserStoredProcedure</returns>
            public static UpdateUserStoredProcedure CreateUpdateUserStoredProcedure(User user)
            {
                // Initial Value
                UpdateUserStoredProcedure updateUserStoredProcedure = null;

                // verify user exists
                if(user != null)
                {
                    // Instanciate updateUserStoredProcedure
                    updateUserStoredProcedure = new UpdateUserStoredProcedure();

                    // Now create parameters for this procedure
                    updateUserStoredProcedure.Parameters = CreateUpdateParameters(user);
                }

                // return value
                return updateUserStoredProcedure;
            }
            #endregion

            #region CreateFetchAllUsersStoredProcedure(User user)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllUsersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'User_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllUsersStoredProcedure' object.</returns>
            public static FetchAllUsersStoredProcedure CreateFetchAllUsersStoredProcedure(User user)
            {
                // Initial value
                FetchAllUsersStoredProcedure fetchAllUsersStoredProcedure = new FetchAllUsersStoredProcedure();

                // return value
                return fetchAllUsersStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
