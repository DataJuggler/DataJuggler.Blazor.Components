

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.NET.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Reflection;

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
        private int borderWidth;
        private int buttonNumber;
        private string buttonUrl;
        private string caption;
        private string className;        
        private int columnNumber;
        private DataManager.DataTypeEnum dataType;
        private bool editMode;
        private string editorClassName;
        private string editorText;
        private string fieldName;
        private string fontName;
        private double fontSize;
        private bool fontBold;
        private string format;
        private Guid id;
        private string imageUrl;
        private int height;
        private int index;
        private bool isImage;
        private bool isImageButton;
        private bool lastColumn;
        private string name;
        private IBlazorComponentParent parent;
        private bool primaryKey;
        private bool readOnly;
        private bool setFocusOnFirstRender;
        private string text;
        private string unit;
        private bool visible;
        private int width;
        private int zIndex;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a GridColumn object
        /// </summary>
        public GridColumn()
        {
            // Perform initializations for this object
            Init();
        }
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
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create defaults
                Id = new Guid();
                Unit = "px";

                // Editors need to be in front
                ZIndex = 100;
            }
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
            
            #region BorderWidth
            /// <summary>
            /// This property gets or sets the value for 'BorderWidth'.
            /// </summary>
            [Parameter]
            public int BorderWidth
            {
                get { return borderWidth; }
                set { borderWidth = value; }
            }
            #endregion

            #region BorderWidthStyle
            /// <summary>
            /// This read only property returns the value of BorderWidth + "px";
            /// </summary>
            public string BorderWidthStyle
            {

                get
                {
                    // initial value
                    string borderWidthStyle = BorderWidth + Unit;
                    
                    // return value
                    return borderWidthStyle;
                }
            }
            #endregion
            
            #region ButtonNumber
            /// <summary>
            /// This property gets or sets the value for 'ButtonNumber'.
            /// </summary>
            [Parameter]
            public int ButtonNumber
            {
                get { return buttonNumber; }
                set { buttonNumber = value; }
            }
            #endregion

            #region ButtonUrl
            /// <summary>
            /// This property gets or sets the value for 'ButtonUrl'.
            /// </summary>
            public string ButtonUrl
            {
                get { return buttonUrl; }
                set { buttonUrl = value; }
            }
            #endregion
            
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

            #region EditorClassName
            /// <summary>
            /// This property gets or sets the value for 'EditorClassName'.
            /// </summary>            
            [Parameter]
            public string EditorClassName
            {
                get { return editorClassName; }
                set { editorClassName = value; }
            }
            #endregion
            
            #region EditMode
            /// <summary>
            /// This property gets or sets the value for 'EditMode'.
            /// </summary>
            [Parameter]
            public bool EditMode
            {
                get { return editMode; }
                set { editMode = value; }
            }
            #endregion
            
            #region EditorText
            /// <summary>
            /// This property gets or sets the value for 'EditorText'.
            /// </summary>
            public string EditorText
            {
                get { return editorText; }
                set { editorText = value; }
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
            
            #region FontBold
            /// <summary>
            /// This property gets or sets the value for 'FontBold'.
            /// </summary>
            [Parameter]
            public bool FontBold
            {
                get { return fontBold; }
                set { fontBold = value; }
            }
            #endregion
            
            #region FontName
            /// <summary>
            /// This property gets or sets the value for 'FontName'.
            /// </summary>
            [Parameter]
            public string FontName
            {
                get { return fontName; }
                set { fontName = value; }
            }
            #endregion
            
            #region FontSize
            /// <summary>
            /// This property gets or sets the value for 'FontSize'.
            /// </summary>
            [Parameter]
            public double FontSize
            {
                get { return fontSize; }
                set { fontSize = value; }
            }
            #endregion
            
            #region Format
            /// <summary>
            /// This property gets or sets the value for 'Format'.
            /// </summary>
            [Parameter]
            public string Format
            {
                get { return format; }
                set { format = value; }
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
            
            #region ImageUrl
            /// <summary>
            /// This property gets or sets the value for 'ImageUrl'.
            /// </summary>
            [Parameter]
            public string ImageUrl
            {
                get { return imageUrl; }
                set { imageUrl = value; }
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
            
            #region IsImage
            /// <summary>
            /// This property gets or sets the value for 'IsImage'.
            /// </summary>
            [Parameter]
            public bool IsImage
            {
                get { return isImage; }
                set { isImage = value; }
            }
            #endregion
            
            #region IsImageButton
            /// <summary>
            /// This property gets or sets the value for 'IsImageButton'.
            /// </summary>
            [Parameter]
            public bool IsImageButton
            {
                get { return isImageButton; }
                set { isImageButton = value; }
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
            
            #region PrimaryKey
            /// <summary>
            /// This property gets or sets the value for 'PrimaryKey'.
            /// </summary>
            [Parameter]
            public bool PrimaryKey
            {
                get { return primaryKey; }
                set { primaryKey = value; }
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
            
            #region SetFocusOnFirstRender
            /// <summary>
            /// This property gets or sets the value for 'SetFocusOnFirstRender'.
            /// </summary>
            [Parameter]
            public bool SetFocusOnFirstRender
            {
                get { return setFocusOnFirstRender; }
                set { setFocusOnFirstRender = value; }
            }
            #endregion
            
            #region Text
            /// <summary>
            /// This property gets or sets the value for 'Text'.
            /// </summary>
            [Parameter]
            public string Text
            {
                get { return text; }
                set { text = value; }
            }
            #endregion
            
            #region Unit
            /// <summary>
            /// This property gets or sets the value for 'Unit'.
            /// </summary>
            [Parameter]
            public string Unit
            {
                get { return unit; }
                set { unit = value; }
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
            
            #region ZIndex
            /// <summary>
            /// This property gets or sets the value for 'ZIndex'.
            /// </summary>
            [Parameter]
            public int ZIndex
            {
                get { return zIndex; }
                set { zIndex = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}