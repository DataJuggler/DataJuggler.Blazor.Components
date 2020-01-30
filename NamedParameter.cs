

#region using statements

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class NamedParameter
    /// <summary>
    /// This class is used to send parameter values by name.
    /// This class is used by IBlazorComponent and IBlazorComponentParent objects to 
    /// send data between the parent and child components and / or pages.
    /// </summary>
    public class NamedParameter
    {
        
        #region Private Variables
        private string name;
        private object _value;
        #endregion

        #region Properties

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
            
            #region Value
            /// <summary>
            /// This property gets or sets the value for 'Value'.
            /// </summary>
            public object Value
            {
                get { return _value; }
                set { _value = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
