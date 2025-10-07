

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.NET9;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DataJuggler.Excelerate;

#endregion

namespace DataJuggler.Blazor.Components.Objects
{

    #region class GridColumn
    /// <summary>
    /// This class is used by the Grid to define columns
    /// </summary>
    public class GridColumn : ComponentBase, IBlazorComponent
    {
        
        #region Private Variables
        private string caption;
        private string className;
        private int columnNumber;
        private DataManager.DataTypeEnum dataType;
        private string fieldName;
        private int height;
        private int index;
        private string name;
        private IBlazorComponentParent parent;
        private bool readOnly;
        private int width;
        private bool lastColumn;
        private bool visible;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods

            #region BuildRenderTree(RenderTreeBuilder builder)
            /// <summary>
            /// method returns the Render Tree
            /// </summary>
            protected override void BuildRenderTree(RenderTreeBuilder builder)
            {
                // Intentionally empty
            }
            #endregion
            
            #region ExportAsColumn()
            /// <summary>
            /// returns the As Column
            /// </summary>
            #region ExportAsColumn()
            /// <summary>
            /// Exports this GridColumn as a Column object for Excelerate.
            /// </summary>
            public Column ExportAsColumn()
            {
                // initial value
                Column column = new Column();

                // set each property
                column.Caption = this.Caption;
                column.ClassName = this.ClassName;
                column.ColumnNumber = this.ColumnNumber;
                column.DataType = this.DataType;
                column.Height = this.Height;
                column.Index = this.Index;
                column.Width = this.Width;

                // The Column class uses Hidden instead of Visible (reverse mapping)
                column.Hidden = !this.Visible;

                // GridColumn uses FieldName; Column uses ColumnName
                column.ColumnName = this.FieldName;

                // return value
                return column;
            }
            #endregion

            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// This method is used to receive messages from other components or pages
            /// </summary>
            public void ReceiveData(Message message)
            {

            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Caption
            /// <summary>
            /// This property gets or sets the value for 'Caption'.
            /// </summary>
            [Parameter]
            public string Caption
            {
                get { return caption; }
                set { caption = value; }
            }
            #endregion
            
            #region ClassName
            /// <summary>
            /// This property gets or sets the value for 'ClassName'.
            /// </summary>
            [Parameter]
            public string ClassName
            {
                get { return className; }
                set { className = value; }
            }
            #endregion
            
            #region ColumnNumber
            /// <summary>
            /// This property gets or sets the value for 'ColumnNumber'.
            /// </summary>
            [Parameter]
            public int ColumnNumber
            {
                get { return columnNumber; }
                set { columnNumber = value; }
            }
            #endregion
            
            #region DataType
            /// <summary>
            /// This property gets or sets the value for 'DataType'.
            /// </summary>
            [Parameter]
            public DataManager.DataTypeEnum DataType
            {
                get { return dataType; }
                set { dataType = value; }
            }
            #endregion
            
            #region FieldName
            /// <summary>
            /// This property gets or sets the value for 'FieldName'.
            /// </summary>
            [Parameter]
            public string FieldName
            {
                get { return fieldName; }
                set { fieldName = value; }
            }
            #endregion
            
            #region Height
            /// <summary>
            /// This property gets or sets the value for 'Height'.
            /// </summary>
            [Parameter]
            public int Height
            {
                get { return height; }
                set { height = value; }
            }
            #endregion
            
            #region Index
            /// <summary>
            /// This property gets or sets the value for 'Index'.
            /// </summary>
            [Parameter]
            public int Index
            {
                get { return index; }
                set { index = value; }
            }
            #endregion
            
            #region LastColumn
            /// <summary>
            /// This property gets or sets the value for 'LastColumn'.
            /// </summary>
            [Parameter]
            public bool LastColumn
            {
                get { return lastColumn; }
                set { lastColumn = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for Name
            /// </summary>
            [Parameter]
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
            
            #region ReadOnly
            /// <summary>
            /// This property gets or sets the value for 'ReadOnly'.
            /// </summary>
            [Parameter]
            public bool ReadOnly
            {
                get { return readOnly; }
                set { readOnly = value; }
            }
            #endregion
            
            #region Visible
            /// <summary>
            /// This property gets or sets the value for 'Visible'.
            /// </summary>
            [Parameter]
            public bool Visible
            {
                get { return visible; }
                set { visible = value; }
            }
            #endregion
            
            #region Width
            /// <summary>
            /// This property gets or sets the value for 'Width'.
            /// </summary>
            [Parameter]
            public int Width
            {
                get { return width; }
                set { width = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
