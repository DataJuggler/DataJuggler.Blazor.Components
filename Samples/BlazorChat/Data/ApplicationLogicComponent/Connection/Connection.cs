

namespace ApplicationLogicComponent.Connection
{

    #region class Connection
    /// <summary>
    /// This class is used to hold the constant for the System Environment Variable
    /// </summary>
    public static class Connection
    {

        #region Private Variables & Constants
        /// <summary>
        /// Create a connection string and then create a system enivornment variable.
        /// Set the value of the System Environement Variable to the connectionstring.
        /// A useful tool you might enjoy is a program called ConnectionStringBuilder,
        /// which is Tool that comes with DataTier.Net, my open source project and preferred
        /// c# data tier creator. DataTier.Net created the data tier including classes and stored procedures.
        /// https://github.com/DataJuggler/DataTier.Net 
        /// Look in the Tools folder for Connection String Builder. I use it often.
        /// </summary>
        public const string Name = "BlazorChat";
        #endregion

        #region Properties

        #endregion
        
    }
    #endregion

}
