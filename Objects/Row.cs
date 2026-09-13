

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using DataJuggler.UltimateHelper;

#endregion

namespace DataJuggler.Blazor.Components.Objects
{

    #region class Row
    /// <summary>
    /// This class represents the Columns make up the Data for an excel sheet.
    /// </summary>
    public class Row
    {
        
        #region Private Variables
        private List<GridColumn> columns;
        private int number;
        private Guid id;
        private bool isHeaderRow;
        private string className;
        private bool editMode;
        private int externalId;
        private string externalIdDescription;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'Row' object.
        /// </summary>
        public Row()
        {
            // Create a new collection of 'Column' objects.
            Columns = new List<GridColumn>();

            // Create a Guid
            Id = Guid.NewGuid();
        }
        #endregion
        
        #region Methods

            #region FindColumn(string name)
            /// <summary>
            /// returns the Column
            /// </summary>
            public GridColumn FindColumn(string name)
            {
                // initial value
                GridColumn column = null;

                // if the value for HasColumns is true
                if (HasColumns)
                {
                    // Iterate the collection of Column objects
                    foreach (GridColumn tempColumn in Columns)
                    {
                        // if this is the column being sought
                        if (TextHelper.IsEqual(tempColumn.Name, name))
                        {
                            // set the return value
                            column = tempColumn;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return column;
            }
            #endregion

            #region FindColumnById(Guid id)
            /// <summary>
            /// returns the Column By Id
            /// </summary>
            public GridColumn FindColumnById(Guid id)
            {
                // initial value
                GridColumn column = null;

                // if the value for HasColumns is true
                if (HasColumns)
                {
                    // find the column
                    column = Columns.FirstOrDefault(x => x.Id == id);
                }
                
                // return value
                return column;
            }
            #endregion
            
            #region FindColumnByNumber(int number)
            /// <summary>
            /// returns the Column By Number
            /// </summary>
            public GridColumn FindColumnByNumber(int number)
            {
                // initial value
                GridColumn column = null;

                // if the value for HasColumns is true
                if (HasColumns)
                {
                    // find the column
                    column = Columns.FirstOrDefault(x => x.ColumnNumber == number);
                }
                
                // return value
                return column;
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region ClassName
            /// <summary>
            /// This property gets or sets the value for 'ClassName'.
            /// </summary>
            public string ClassName
            {
                get { return className; }
                set { className = value; }
            }
            #endregion
            
            #region Columns
            /// <summary>
            /// This property gets or sets the value for 'Columns'.
            /// </summary>
            public List<GridColumn> Columns
            {
                get { return columns; }
                set { columns = value; }
            }
            #endregion
            
            #region EditMode
            /// <summary>
            /// This property gets or sets the value for 'EditMode'.
            /// </summary>
            public bool EditMode
            {
                get { return editMode; }
                set { editMode = value; }
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
            
            #region HasColumns
            /// <summary>
            /// This property returns true if this object has a 'Columns'.
            /// </summary>
            public bool HasColumns
            {
                get
                {
                    // initial value
                    bool hasColumns = (this.Columns != null);
                    
                    // return value
                    return hasColumns;
                }
            }
            #endregion
            
            #region Id
            /// <summary>
            /// This property gets or sets the value for 'Id'.
            /// </summary>
            public Guid Id
            {
                get { return id; }
                set { id = value; }
            }
            #endregion
            
            #region IsHeaderRow
            /// <summary>
            /// This property gets or sets the value for 'IsHeaderRow'.
            /// </summary>
            public bool IsHeaderRow
            {
                get { return isHeaderRow; }
                set { isHeaderRow = value; }
            }
            #endregion
            
            #region Number
            /// <summary>
            /// This property gets or sets the value for 'Number'.
            /// </summary>
            public int Number
            {
                get { return number; }
                set { number = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}