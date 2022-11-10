           
#region using statements

using System;
using DataJuggler.Blazor.Components.Interfaces;
using System.Collections.Generic;
using DataJuggler.Excelerate;
using Microsoft.AspNetCore.Components;
using DataJuggler.UltimateHelper;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class Grid
    /// <summary>
    /// This class represents a Grid to display and edit column values.
    /// </summary>
    public partial class Grid : IBlazorComponent
    {
        
        #region Private Variables
        private List<Column> columns;
        private List<Row> rows;
        private bool showHeader;
        private string headerText;
        private string name;
        private IBlazorComponentParent parent;        
        private string headerClassName;
        private bool showColumnHeaders;
        private bool editMode;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Grid object.
        /// </summary>
        public Grid()
        {
            
        }
        #endregion

        #region Methods

            #region OnDoubleClick(Row row)
            /// <summary>
            /// On Double Click
            /// </summary>
            public void OnDoubleClick(Row row)
            {
                // if the row exists
                if (NullHelper.Exists(row))
                {
                    // Set the row into EditMode so the edit control is displayed.
                    // to do: Figure out the Edit Control.
                    row.EditMode = true;

                    // turn on EditMode
                    EditMode = true;
                }

                // Update the page in EditMode
                Refresh();
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // If the message object exists
                if ((NullHelper.Exists(message)) && (message.HasParameters))
                {
                    // iterate the parameters
                    foreach (NamedParameter parameter in message.Parameters)
                    {
                        // if this is the Rows collection
                        if (parameter.Name == "Rows")
                        {
                            // cast the value as a List of Row objects.
                            Rows = parameter.Value as List<Row>;
                        }

                        // if this is the Columns collection
                        if (parameter.Name == "Columns")
                        {
                            // cast the value as a List of Row objects.
                            Columns = parameter.Value as List<Column>;
                        }
                    }
                    
                    // Display the Data
                    Refresh();
                }
            }
            #endregion

            #region Refresh()
            /// <summary>
            /// method Refresh
            /// </summary>
            public void Refresh()
            {
                // Update the UI
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
            #endregion

        #endregion

        #region Properties

            #region Columns
            /// <summary>
            /// This property gets or sets the value for 'Columns'.
            /// </summary>
            public List<Column> Columns
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
          
            #region HasHeaderText
            /// <summary>
            /// This property returns true if the 'HeaderText' exists.
            /// </summary>
            public bool HasHeaderText
            {
                get
                {
                    // initial value
                    bool hasHeaderText = (!String.IsNullOrEmpty(this.HeaderText));
                    
                    // return value
                    return hasHeaderText;
                }
            }
            #endregion
            
            #region HasParent
            /// <summary>
            /// This property returns true if this object has a 'Parent'.
            /// </summary>
            public bool HasParent
            {
                get
                {
                    // initial value
                    bool hasParent = (this.Parent != null);
                    
                    // return value
                    return hasParent;
                }
            }
            #endregion

            #region HasRows
            /// <summary>
            /// This property returns true if this object has a 'Rows'.
            /// </summary>
            public bool HasRows
            {
                get
                {
                    // initial value
                    bool hasRows = (this.Rows != null);
                    
                    // return value
                    return hasRows;
                }
            }
            #endregion
            
            #region HeaderClassName
            /// <summary>
            /// This property gets or sets the value for 'HeaderClassName'.
            /// </summary>
            [Parameter]
            public string HeaderClassName
            {
                get { return headerClassName; }
                set { headerClassName = value; }
            }
            #endregion
            
            #region HeaderText
            /// <summary>
            /// This property gets or sets the value for 'HeaderText'.
            /// </summary>
            [Parameter]
            public string HeaderText
            {
                get { return headerText; }
                set { headerText = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            [Parameter]
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// You should set the Name property before this method.
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get { return parent; }
                set 
                {
                    // set the value
                    parent = value;

                    // if the value for HasParent is true
                    if (HasParent)
                    {
                        // Register with the parent
                        Parent.Register(this);
                    }
                }
            }
            #endregion
            
            #region Rows
            /// <summary>
            /// This property gets or sets the value for 'Rows'.
            /// </summary>
            public List<Row> Rows
            {
                get { return rows; }
                set { rows = value; }
            }
            #endregion
            
            #region ShowColumnHeaders
            /// <summary>
            /// This property gets or sets the value for 'ShowColumnHeaders'.
            /// </summary>
            public bool ShowColumnHeaders
            {
                get { return showColumnHeaders; }
                set { showColumnHeaders = value; }
            }
            #endregion
            
            #region ShowHeader
            /// <summary>
            /// This property gets or sets the value for 'ShowHeader'.
            /// </summary>
            [Parameter]
            public bool ShowHeader
            {
                get { return showHeader; }
                set { showHeader = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
