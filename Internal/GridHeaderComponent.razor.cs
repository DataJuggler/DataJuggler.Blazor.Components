

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Excelerate;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Drawing;

#endregion

namespace DataJuggler.Blazor.Components.Internal
{

    #region class GridHeaderComponent
    /// <summary>
    /// This class is the header for the grid. Since the grid puts the header in two
    /// different places depending on the value for StickyHeader, this saved duplicating
    /// markup in two places.
    /// </summary>
    public partial class GridHeaderComponent : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private List<TextBoxComponent> filterTextBoxes;
        private string name;
        private IBlazorComponentParent parent;
        private string columnHeaderTextStyle;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'GridHeaderComponent' object.
        /// </summary>
        public GridHeaderComponent()
        {
            // Create a new collection of 'TextBoxComponent' objects.
            FilterTextBoxes = new List<TextBoxComponent>();
        }
        #endregion
        
        #region Methods
            
            #region ReceiveData(Message message)
            /// <summary>
            /// This method is used to receive messages from other components or pages
            /// </summary>
            public void ReceiveData(Message message)
            {
                
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// This method is used to update the UI after changes
            /// </summary>
            public void Refresh()
            {
                InvokeAsync(() =>
                {
                    // Refresh
                    StateHasChanged();
                });
            }
            #endregion
            
            #region Register(IBlazorComponent component)
            /// <summary>
            /// This method is used to store child controls that are on this component or page
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                // if the value for HasFilterTextBoxes is true
                if (HasFilterTextBoxes)
                {
                    // if this component is a TextBoxComponent
                    if (component is TextBoxComponent tempTextBoxComponent)
                    {
                        // Add this component
                        FilterTextBoxes.Add(tempTextBoxComponent);                    
                    }
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region ColumnHeaderClassName
            /// <summary>
            /// This read only property returns the value of ColumnHeaderClassName from the object ParentGrid.
            /// </summary>
            public string ColumnHeaderClassName
            {

                get
                {
                    // initial value
                    string columnHeaderClassName = "";

                    // if ParentGrid exists
                    if (HasParentGrid)
                    {
                        // set the return value
                        columnHeaderClassName = ParentGrid.ColumnHeaderClassName;
                    }

                    // return value
                    return columnHeaderClassName;
                }
            }
            #endregion
            
            #region ColumnHeaderStyle
            /// <summary>
            /// This read only property returns the value of ColumnHeaderStyle from the object ParentGrid.
            /// </summary>
            public string ColumnHeaderStyle
            {

                get
                {
                    // initial value
                    string columnHeaderStyle = "";

                    // if ParentGrid exists
                    if (HasParentGrid)
                    {
                        // set the return value
                        columnHeaderStyle = ParentGrid.ColumnHeaderStyle;
                    }

                    // return value
                    return columnHeaderStyle;
                }
            }
            #endregion
            
            #region ColumnHeaderTextOffsetYStyle
            /// <summary>
            /// This read only property returns the value of ColumnHeaderTextOffsetYStyle from the object ParentGrid
            /// </summary>
            public string ColumnHeaderTextOffsetYStyle
            {

                get
                {
                    // initial value
                    string columnHeaderTextOffsetYStyle = "";

                    // if the value for HasParentGrid is true
                    if (HasParentGrid)
                    {
                        // set the return value
                        columnHeaderTextOffsetYStyle = ParentGrid.ColumnHeaderTextOffsetYStyle;
                    }

                    // return value
                    return columnHeaderTextOffsetYStyle;
                }
            }
            #endregion

            #region ColumnHeaderTextStyle
            /// <summary>
            /// This property gets or sets the value for 'ColumnHeaderTextStyle'.
            /// </summary>
            public string ColumnHeaderTextStyle
            {
                get { return columnHeaderTextStyle; }
                set { columnHeaderTextStyle = value; }
            }
            #endregion
            
            #region Columns
            /// <summary>
            /// This read only property returns the value of Columns from the object ParentGrid.
            /// </summary>
            public List<Column> Columns
            {

                get
                {
                    // initial value
                    List<Column> columns = null;

                    // if ParentGrid exists
                    if (ParentGrid != null)
                    {
                        // set the return value
                        columns = ParentGrid.Columns;
                    }

                    // return value
                    return columns;
                }
            }
            #endregion            
            
            #region FilterTextBoxes
            /// <summary>
            /// This property gets or sets the value for 'FilterTextBoxes'.
            /// </summary>
            public List<TextBoxComponent> FilterTextBoxes
            {
                get { return filterTextBoxes; }
                set { filterTextBoxes = value; }
            }
            #endregion
            
            #region GridColumns
            /// <summary>
            /// This read only property returns the value of GridColumns from the object ParentGrid.
            /// </summary>
            public RenderFragment<Grid> GridColumns
            {

                get
                {
                    // initial value
                    RenderFragment<Grid> gridColumns = null;

                    // if ParentGrid exists
                    if (HasParentGrid)
                    {
                        // set the return value
                        gridColumns = ParentGrid.GridColumns;
                    }

                    // return value
                    return gridColumns;
                }
                set
                {
                    // if the value for HasParentGrid is true
                    if (HasParentGrid)
                    {
                        // Set the GridColumns on the Parent
                        ParentGrid.GridColumns(this.ParentGrid);
                    }
                }
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
                    bool hasColumns = (Columns != null);

                    // return value
                    return hasColumns;
                }
            }
            #endregion
            
            #region HasFilterTextBoxes
            /// <summary>
            /// This property returns true if this object has a 'FilterTextBoxes'.
            /// </summary>
            public bool HasFilterTextBoxes
            {
                get
                {
                    // initial value
                    bool hasFilterTextBoxes = (FilterTextBoxes != null);

                    // return value
                    return hasFilterTextBoxes;
                }
            }
            #endregion
            
            #region HasGridColumns
            /// <summary>
            /// This property returns true if this object has a 'GridColumns'.
            /// </summary>
            public bool HasGridColumns
            {
                get
                {
                    // initial value
                    bool hasGridColumns = (GridColumns != null);

                    // return value
                    return hasGridColumns;
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
                    bool hasParent = (Parent != null);

                    // return value
                    return hasParent;
                }
            }
            #endregion
            
            #region HasParentGrid
            /// <summary>
            /// This property returns true if this object has a 'ParentGrid'.
            /// </summary>
            public bool HasParentGrid
            {
                get
                {
                    // initial value
                    bool hasParentGrid = (ParentGrid != null);

                    // return value
                    return hasParentGrid;
                }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for Name
            /// </summary>
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for Parent
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get
                {
                    return parent;
                }
                set
                {
                    parent = value;

                    // If the parent exists
                    if (parent != null)
                    {
                        // register with the parent
                        parent.Register(this);
                    }
                }
            }
            #endregion
            
            #region ParentGrid
            /// <summary>
            /// This read only property returns the value of Parent if it is a Grid
            /// </summary>
            public Grid ParentGrid
            {

                get
                {
                    // initial value
                    Grid parentGrid = null;

                    // if Parent exists
                    if (HasParent)
                    {
                        if (Parent is Grid tempGrid)
                        {
                            // set the return value
                            parentGrid = tempGrid;
                        }
                    }

                    // return value
                    return parentGrid;
                }
            }
            #endregion
            
            #region ShowFilterRow
            /// <summary>
            /// This read only property returns the value of ShowFilterRow from the object ParentGrid.
            /// </summary>
            public bool ShowFilterRow
            {

                get
                {
                    // initial value
                    bool showFilterRow = false;

                    // if ParentGrid exists
                    if (HasParentGrid)
                    {
                        // set the return value
                        showFilterRow = ParentGrid.ShowFilterRow;
                    }

                    // return value
                    return showFilterRow;
                }
            }
            #endregion
            
            #region ShowHeader
            /// <summary>
            /// This read only property returns the value of ShowHeader from the object ParentGrid.
            /// </summary>
            public bool ShowHeader
            {

                get
                {
                    // initial value
                    bool showHeader = false;

                    // if ParentGrid exists
                    if (ParentGrid != null)
                    {
                        // set the return value
                        showHeader = ParentGrid.ShowHeader;
                    }

                    // return value
                    return showHeader;
                }
            }
            #endregion
            
            #region StickyStyle
            /// <summary>
            /// This read only property returns the value of StickyStyle from the object ParentGrid.
            /// </summary>
            public string StickyStyle
            {

                get
                {
                    // initial value
                    string stickyStyle = "";

                    // if ParentGrid exists
                    if (HasParentGrid)
                    {
                        // set the return value
                        stickyStyle = ParentGrid.StickyStyle;
                    }

                    // return value
                    return stickyStyle;
                }
            }
            #endregion
            
            #region WidthStyle
            /// <summary>
            /// This read only property returns the value of WidthStyle from the object ParentGrid.
            /// </summary>
            public string WidthStyle
            {

                get
                {
                    // initial value
                    string widthStyle = "";

                    // if ParentGrid exists
                    if (HasParentGrid)
                    {
                        // set the return value
                        widthStyle = ParentGrid.WidthStyle;
                    }

                    // return value
                    return widthStyle;
                }
            }
            #endregion

        #endregion
        
    }
    #endregion

}
