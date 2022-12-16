

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
    /// send Data between the parent and child components and / or pages.
    /// </summary>
    public class NamedParameter
    {
        
        #region Private Variables
        private string name;
        private object _value;
        private string gridName;
        private Guid rowId;
        private Guid columnId;
        private int externalId;
        private string externalIdDescription;
        #endregion

        #region Properties

            #region ColumnId
            /// <summary>
            /// This property gets or sets the value for 'ColumnId'.
            /// </summary>
            public Guid ColumnId
            {
                get { return columnId; }
                set { columnId = value; }
            }
            #endregion
            
            #region ExternalId
            /// <summary>
            /// This property gets or sets the value for 'ExternalId'.
            /// </summary>            
            public int ExternalId
            {
                get { return externalId; }
                set { externalId = value; }
            }
            #endregion
            
            #region ExternalIdDescription
            /// <summary>
            /// This property gets or sets the value for 'ExternalIdDescription'.
            /// </summary>
            public string ExternalIdDescription
            {
                get { return externalIdDescription; }
                set { externalIdDescription = value; }
            }
            #endregion
            
            #region GridName
            /// <summary>
            /// This property gets or sets the value for 'GridName'.
            /// </summary>            
            public string GridName
            {
                get { return gridName; }
                set { gridName = value; }
            }
            #endregion
            
            #region HasGridName
            /// <summary>
            /// This property returns true if the 'GridName' exists.
            /// </summary>
            public bool HasGridName
            {
                get
                {
                    // initial value
                    bool hasGridName = (!String.IsNullOrEmpty(this.GridName));
                    
                    // return value
                    return hasGridName;
                }
            }
            #endregion
            
            #region HasName
            /// <summary>
            /// This property returns true if the 'Name' exists.
            /// </summary>
            public bool HasName
            {
                get
                {
                    // initial value
                    bool hasName = (!String.IsNullOrEmpty(this.Name));
                    
                    // return value
                    return hasName;
                }
            }
            #endregion
            
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
            
            #region RowId
            /// <summary>
            /// This property gets or sets the value for 'RowId'.
            /// </summary>
            public Guid RowId
            {
                get { return rowId; }
                set { rowId = value; }
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
