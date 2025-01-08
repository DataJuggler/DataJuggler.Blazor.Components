           
#region using statements

using System;
using DataJuggler.Blazor.Components.Interfaces;
using System.Collections.Generic;
using DataJuggler.Excelerate;
using Microsoft.AspNetCore.Components;
using DataJuggler.UltimateHelper;
using DataJuggler.Blazor.Components.Util;
using Microsoft.AspNetCore.Components.Web;
using DataJuggler.Cryptography;
using System.Threading.Tasks;
using System.Drawing;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class Grid
    /// <summary>
    /// This class represents a Grid to display and edit column values.
    /// </summary>
    public partial class Grid : ComponentBase, IBlazorComponent, IBlazorComponentParent
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
        private Row editRow;
        private Guid editRowId;
        private string className;
        private TextBoxComponent setFocusEditor;
        private List<IBlazorComponent> children;
        private int externalId;
        private string externalIdDescription;
        private List<ImageButton> buttons;
        private ButtonClickedHandler buttonClickHandler;
        private Color gridBackColor;
        private double height;
        private string heightUnit;
        private double fontSize;        
        private string fontSizeUnit;
        private double width;        
        private double left;
        private double top;                        
        private string position;
        private string unit;
        private bool notifyParentOnDoubleClick;        
        private bool enableClick;
        private string gridStyle;
        private string overflowX;
        private string overflowY;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Grid object.
        /// </summary>
        public Grid()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region Enter(KeyboardEventArgs e)
            /// <summary>
            /// event is fired when Enter
            /// </summary>
            public void Enter(KeyboardEventArgs e)
            {
                if (e.Code == "Enter" || e.Code == "NumpadEnter")
                {
                    // Exit
                    EditMode = false;

                    // if the value for HasEditRow is true
                    if (HasEditRow)
                    {
                        // Set to false
                        EditRow.EditMode = false;

                        // Reload the screen to exit read only mode
                        Refresh();
                    }
                }
            }
            #endregion

            #region OnAfterRenderAsync(bool firstRender)
            /// <summary>
            /// This method is used to verify a user
            /// </summary>
            /// <param name="firstRender"></param>
            /// <returns></returns>
            protected async override Task OnAfterRenderAsync(bool firstRender)
            {
                try
                {
                    // if the value for HasSetFocusEditor is true
                    if (HasSetFocusEditor)
                    {
                        // Set Focus
                        SetFocusEditor.SetFocus();
                    }
                }
                catch (Exception error)
                {
                    // Attempt to trap
                    DebugHelper.WriteDebugError("OnAfterRenderAsync", "Grid.razor.cs", error);
                }

                // call the base
                await base.OnAfterRenderAsync(firstRender);
            }
            #endregion

            #region OnClick(Row row, int columnNumber)
            /// <summary>
            /// On Double Click
            /// </summary>
            public void OnClick(Row row, int columnNumber)
            {
                // if the row exists
                if (NullHelper.Exists(row))
                {
                    // if NotifyParent is true
                    if (HasParent)
                    {
                        // Create a message
                        Message message = new Message();

                        // Set the parent
                        message.Text = "A row was clicked with Id " + row.ExternalId + " " + row.ExternalIdDescription;
                        message.Id = row.ExternalId;
                        message.Sender = this;

                        // Notify the parent
                        Parent.ReceiveData(message);
                    }
                }

                // Update the page in EditMode
                Refresh();
            }
            #endregion
            
            #region OnDoubleClick(Row row, int columnNumber)
            /// <summary>
            /// On Double Click
            /// </summary>
            public void OnDoubleClick(Row row, int columnNumber)
            {
                // if the row exists
                if (NullHelper.Exists(row))
                {
                    // if NotifyParent is true
                    if ((NotifyParentOnDoubleClick) && (HasParent))
                    {
                        // Create a message
                        Message message = new Message();

                        // Set the parent
                        message.Text = "A row was double clicked with Id " + row.ExternalId + " " + row.ExternalIdDescription;
                        message.Id = row.ExternalId;
                        message.Sender = this;

                        // Notify the parent
                        Parent.ReceiveData(message);
                    }
                    else
                    {
                        // Find the column
                        Column column = row.FindColumnByNumber(columnNumber);

                        // If the column object exists
                        if (NullHelper.Exists(column))
                        {
                            // Set the column to focus
                            column.SetFocusOnFirstRender = true;

                            // Set the column to EditMode
                            column.EditMode = true;
                        }

                        // Set the row into EditMode so the edit control is displayed.
                        // to do: Figure out the Edit Control.
                        row.EditMode = true;

                        // turn on EditMode
                        EditMode = true;
                    }
                }

                // Update the page in EditMode
                Refresh();
            }
            #endregion

        #endregion

        #region Methods
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // attempt to find the IBlazorComponent by name.
                IBlazorComponent component = ComponentHelper.FindChildByName(Children, name);

                // return value
                return component;
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create
                Position = "relative";
                Children = new List<IBlazorComponent>();
                Buttons = new List<ImageButton>();
                Columns = new List<Column>();
                HeightUnit = "px";
                Height = 240;
                FontSize = 12;
                FontSizeUnit="px";
                Unit = "px";
                Width = 400;
                OverflowX = "hidden";
                OverflowY = "auto";
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // If the message object exists
                if (NullHelper.Exists(message))
                {
                    if ((message.Text == "EnterPressed") && (HasParent))
                    {
                        // Set the Sender
                        message.Sender = this;

                        // raise this up to the parent to Save
                        Parent.ReceiveData(message);
                    }
                    else if ((message.Text == "EscapePressed") && (HasParent))
                    {
                        // Set the Sender
                        SetFocusEditor = null;

                        // Exit edit mode
                        EditMode = false;

                        // if the EditRow exists
                        if (HasEditRow)
                        {
                            // Exit EditMode
                            EditRow.EditMode = false;

                            // Erase
                            EditRow = null;
                        }

                        // raise this up to the parent to Save
                        Parent.ReceiveData(message);

                        // Escape = exit editor mode
                        Refresh();
                    }
                    else if (message.HasParameters)
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

            #region Register(IBlazorComponent component)
            /// <summary>
            /// This method is used to keep track of the current editors.
            /// When Save is called, these editors have to be removed.
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                // If the component object exists
                if (NullHelper.Exists(component, Children))
                {
                    // Add this oobject
                    Children.Add(component);

                    if (component is TextBoxComponent)
                    {
                        // Test if this is a TextBoxComponent
                        TextBoxComponent TextBoxComponent = component as TextBoxComponent;

                        // if this is the control to set focus to
                        if ((NullHelper.Exists(TextBoxComponent)) && (TextBoxComponent.SetFocusOnFirstRender))
                        {
                            // Set the SetFocusEditor
                            SetFocusEditor = TextBoxComponent;
                        }
                    }
                    else if (component is ImageButton)
                    {
                        // cast the IBlazorComponent as an ImageButton
                        ImageButton button = component as ImageButton;

                        

                        // Add this button
                        Buttons.Add(button);
                    }
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region Buttons
            /// <summary>
            /// This property gets or sets the value for 'Buttons'.
            /// </summary>
            public List<ImageButton> Buttons
            {
                get { return buttons; }
                set { buttons = value; }
            }
            #endregion
            
            #region Children
            /// <summary>
            /// This property gets or sets the value for 'Children'.
            /// </summary>
            public List<IBlazorComponent> Children
            {
                get { return children; }
                set { children = value; }
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
            
            #region ButtonClickHandler
            /// <summary>
            /// This property gets or sets the value for 'ClickHandler'.
            /// </summary>
            public ButtonClickedHandler ButtonClickHandler
            {
                get { return buttonClickHandler; }
                set { buttonClickHandler = value; }
            }
            #endregion
            
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
            
            #region EditRow
            /// <summary>
            /// This property gets or sets the value for 'EditRow'.
            /// </summary>
            public Row EditRow
            {
                get { return editRow; }
                set { editRow = value; }
            }
            #endregion
            
            #region EditRowId
            /// <summary>
            /// This property gets or sets the value for 'EditRowId'.
            /// </summary>
            public Guid EditRowId
            {
                get { return editRowId; }
                set { editRowId = value; }
            }
            #endregion
            
            #region EnableClick
            /// <summary>
            /// This property gets or sets the value for 'EnableClick'.
            /// </summary>
            [Parameter]
            public bool EnableClick
            {
                get { return enableClick; }
                set { enableClick = value; }
            }
            #endregion
            
            #region ExternalId
            /// <summary>
            /// This property gets or sets the value for 'ExternalId'.
            /// </summary>
            [Parameter]
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
            [Parameter]
            public string ExternalIdDescription
            {
                get { return externalIdDescription; }
                set { externalIdDescription = value; }
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
            
            #region FontSizeStyle
            /// <summary>
            /// This property gets or sets the value for 'FontSizeStyle'.
            /// </summary>
            public string FontSizeStyle
            {
                get
                {
                    // set the return value
                    string fontSizeStyle = FontSize + FontSizeUnit;

                    // return value
                    return fontSizeStyle;
                }
            }
            #endregion
            
            #region FontSizeUnit
            /// <summary>
            /// This property gets or sets the value for 'FontSizeUnit'.
            /// </summary>
            [Parameter]
            public string FontSizeUnit
            {
                get { return fontSizeUnit; }
                set { fontSizeUnit = value; }
            }
            #endregion
            
            #region GridBackColor
            /// <summary>
            /// This property gets or sets the value for 'GridBackColor'.
            /// </summary>
            [Parameter]
            public Color GridBackColor
            {
                get { return gridBackColor; }
                set { gridBackColor = value; }
            }
            #endregion
            
            #region GridStyle
            /// <summary>
            /// This property gets or sets the value for 'GridStyle'.
            /// </summary>
            public string GridStyle
            {
                get { return gridStyle; }
                set { gridStyle = value; }
            }
            #endregion
            
            #region HasButtons
            /// <summary>
            /// This property returns true if this object has a 'Buttons'.
            /// </summary>
            public bool HasButtons
            {
                get
                {
                    // initial value
                    bool hasButtons = (this.Buttons != null);
                    
                    // return value
                    return hasButtons;
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
                    bool hasColumns = (this.Columns != null);
                    
                    // return value
                    return hasColumns;
                }
            }
            #endregion
          
            #region HasEditRow
            /// <summary>
            /// This property returns true if this object has an 'EditRow'.
            /// </summary>
            public bool HasEditRow
            {
                get
                {
                    // initial value
                    bool hasEditRow = (this.EditRow != null);
                    
                    // return value
                    return hasEditRow;
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
            
            #region HasSetFocusEditor
            /// <summary>
            /// This property returns true if this object has a 'SetFocusEditor'.
            /// </summary>
            public bool HasSetFocusEditor
            {
                get
                {
                    // initial value
                    bool hasSetFocusEditor = (this.SetFocusEditor != null);
                    
                    // return value
                    return hasSetFocusEditor;
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
            
            #region Height
            /// <summary>
            /// This property gets or sets the value for 'Height'.
            /// </summary>
            [Parameter]
            public double Height
            {
                get { return height; }
                set { height = value; }
            }
            #endregion

            #region HeightStyle
            /// <summary>
            /// This read only property returns the value of Height + Unit
            /// </summary>
            public string HeightStyle
            {
                
                get
                {
                    // initial value
                    string heightStyle = Height + HeightUnit;

                    // If the HeightUnit string exists
                    if (TextHelper.Exists(HeightUnit))
                    {
                        // Use the HeightUnit
                        heightStyle = Height + HeightUnit;
                    }
                    
                    // return value
                    return heightStyle;
                }
            }
            #endregion

            #region HeightUnit
            /// <summary>
            /// This property gets or sets the value for 'HeightUnit'.
            /// </summary>
            [Parameter]
            public string HeightUnit
            {
                get { return heightUnit; }
                set { heightUnit = value; }
            }
            #endregion
            
            #region Left
            /// <summary>
            /// This property gets or sets the value for 'Left'.
            /// </summary>
            [Parameter]
            public double Left
            {
                get { return left; }
                set { left = value; }
            }
            #endregion
            
            #region LeftStyle
            /// <summary>
            /// This property returns the value for 'LeftStyle'.
            /// </summary>
            public string LeftStyle
            {
                get
                {
                    // initial value
                    string leftStyle = Left + Unit;

                    // return value
                    return leftStyle;
                }
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
            
            #region NotifyParentOnDoubleClick
            /// <summary>
            /// This property gets or sets the value for 'NotifyParentOnDoubleClick'.
            /// </summary>
            [Parameter]
            public bool NotifyParentOnDoubleClick
            {
                get { return notifyParentOnDoubleClick; }
                set { notifyParentOnDoubleClick = value; }
            }
            #endregion
            
            #region OverflowX
            /// <summary>
            /// This property gets or sets the value for 'OverflowX'.
            /// </summary>
            [Parameter]
            public string OverflowX
            {
                get { return overflowX; }
                set { overflowX = value; }
            }
            #endregion
            
            #region OverflowY
            /// <summary>
            /// This property gets or sets the value for 'OverflowY'.
            /// </summary>
            [Parameter]
            public string OverflowY
            {
                get { return overflowY; }
                set { overflowY = value; }
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
            
            #region Position
            /// <summary>
            /// This property gets or sets the value for 'Position'.
            /// </summary>
            [Parameter]
            public string Position
            {
                get { return position; }
                set { position = value; }
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
            
            #region SetFocusEditor
            /// <summary>
            /// This property gets or sets the value for 'SetFocusEditor'.
            /// </summary>
            public TextBoxComponent SetFocusEditor
            {
                get { return setFocusEditor; }
                set { setFocusEditor = value; }
            }
            #endregion
            
            #region ShowColumnHeaders
            /// <summary>
            /// This property gets or sets the value for 'ShowColumnHeaders'.
            /// </summary>
            [Parameter]
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

            #region Top
            /// <summary>
            /// This property gets or sets the value for 'Top'.
            /// </summary>
            [Parameter]
            public double Top
            {
                get { return top; }
                set { top = value; }
            }
            #endregion
            
            #region TopStyle
            /// <summary>
            /// This property returns the value for 'TopStyle'.
            /// </summary>
            public string TopStyle
            {
                get
                {
                    // initial value
                    string topStyle = Top + HeightUnit;

                    // Set the value
                    return topStyle;
                }
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
            
            #region Width
            /// <summary>
            /// This property gets or sets the value for 'Width'.
            /// </summary>
            [Parameter]
            public double Width
            {
                get { return width; }
                set { width = value; }
            }
            #endregion

            #region WidthStyle
            /// <summary>
            /// This read only property returns the value of WidthStyle
            /// </summary>
            public string WidthStyle
            {  
                get
                {
                    // initial value
                    string widthStyle = Width + Unit;
                    
                    // return value
                    return widthStyle;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
