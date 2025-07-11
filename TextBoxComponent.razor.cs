﻿

#region using statements

using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Drawing;
using System.Threading.Tasks;
using DataJuggler.Blazor.Components.Delegates;
using NPOI.SS.UserModel;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class TextBoxComponent : IBlazorComponent
    /// <summary>
    /// The validation component is just a way to display a valid or not valid to make the UI
    /// appear different.
    /// </summary>
    public partial class TextBoxComponent : IBlazorComponent, ILabelFont, ITextBoxFont 
    {
        
        #region Private Variables
        private string bottomMarginStyle;        
        private double borderWidth;
        private string borderColor;
        private string caption;
        private double fontSize;
        private string fontName;        
        private double height;        
        private string imageClassName;
        private bool isValid;
        private string text;
        private string inputType;
        private bool isRequired;
        private bool isIntegerRequired;
        private bool isDoubleRequired;
        private bool isUnique;        
        private bool loading;
        private int minimumLength;
        private int maximumLength;
        private int minimumInteger;
        private int maximumInteger;
        private int minimumDouble;
        private int maximumDouble;
        private bool multiline;
        private string validationMessage;
        private string invalidReason;
        private bool isUniqueCallbackRequired;
        private string uniqueImageUrl;
        private string takenImageUrl;
        private string imageUrl;
        private bool passwordMode;
        private bool showImage;        
        private double imageScale;
        private double width;        
        private string name;
        private double left;
        private double top;
        private bool formatAsPhoneNumber;
        private string position;
        private IBlazorComponentParent parent;
        private string className;
        private bool setFocusOnFirstRender;
        private bool showCaption;        
        private int externalId;
        private string externalIdDescription;        
        private ElementReference innerControl;
        private bool visible;
        private string display;
        private bool sendAllTextToParent;        
        private string fontSizeUnit;
        private string backgroundColor;
        private double imageWidth;
        private string imageBackColor;
        private int rows;
        private double column1Width;
        private double column2Width;
        private double column3Width;
        private bool enabled;        
        private double marginBottom;
        private double marginLeft;
        private bool autoComplete;
        private string invalidLabelColor;
        private string pattern;
        private int tabIndex;
        private string column1Style;
        private string column2Style;
        private string column3Style;
        private string imageStyle;
        private OnTextChange onTextChangedCallback;
        private HandleChangeEnum handleChangeOption;
        private int zIndex;
        private string unit;
        private string heightUnit;
        private bool notifyParentOnBlur;

        // Label
        private double labelWidth;
        private double labelFontSize;
        private string labelFontName;        
        private string labelClassName;
        private string labelBackgroundColor;
        private Color labelColor;
        private double labelTop;
        private double labelLeft;
        private string labelStyle;
        private string labelTextAlign;
        
        // TextBox
        private double textBoxLeft;
        private double textBoxTop;
        private string textBoxBackColor;
        private string textBoxTextColor;
        private string textBoxClassName;
        private double textBoxWidth;
        private string textBoxControlStyle;
        private string textBoxStyle;
        private double textBoxFontSize;
        private string textBoxFontName;
        private bool allowWrapping;
        private string textWrapping;

        // This are only used when inside a Grid
        private Guid rowId;
        private Guid columnId;        
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a TextBoxComponent object
        /// </summary>
        public TextBoxComponent()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events            
            
            #region HandleChange(ChangeEventArgs e)
            /// <summary>
            /// event is fired when Handle Change
            /// </summary>
            private void HandleChange(ChangeEventArgs e)
            {
                // get the current text
                string text = e.Value.ToString();

                // if the value for HasOnTextChangedCallback is true
                if (HasOnTextChangedCallback)
                {
                    // Notify Subscriber
                    OnTextChangedCallback(text);
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
                    if (SetFocusOnFirstRender && firstRender)
                    {
                        // Set Focus
                        SetFocus();
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
            
        #endregion

        #region Methods
    
            #region Enter(KeyboardEventArgs e)
            /// <summary>
            /// event is fired when Enter
            /// </summary>
            public void Enter(KeyboardEventArgs e)
            {
                if (e.Code == "Enter" || e.Code == "NumpadEnter")
                {
                    // if the value for FormatAsPhoneNumber is true
                    if (FormatAsPhoneNumber)
                    {
                        // Handle Blue which sets the text to (xxx) xxx - xxxx
                        HandleBlur();
                    }

                    // if the Parent exists
                    if (HasParent)
                    { 
                        // Inform the Parent
                        SendMessageToParent("EnterPressed");      
                    }                            
                }
                else if (e.Code == "Escape")
                {
                    // Inform the Parent Escape was hit
                    SendMessageToParent("EscapePressed");      
                }
                
                // if SendAllTextToParent
                if (SendAllTextToParent)
                {
                    // Send to the parent
                    SendMessageToParent("text: " + e.Code, e.Code);
                }
            }
            #endregion

            #region HandleBlur()
            /// <summary>
            /// method Handle Blur
            /// </summary>
            private void HandleBlur()
            {
                // if the value for FormatAsPhoneNumber is true
                if (FormatAsPhoneNumber)
                {
                    // Update the Text
                    Text = TextHelper.FormatPhoneNumber(Text);
                }

                // if the value for NotifyParentOnBlur is true
                if ((HasParent) && (NotifyParentOnBlur))
                {
                    Message message = new Message();
                    message.Sender = this;
                    message.Text = "OnBlurFired";

                    // Notify the parent
                    parent.ReceiveData(message);
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default Values
                AllowWrapping = false;
                AutoComplete = false;
                BackgroundColor = "transparent";
                BorderColor = "gray";
                BorderWidth = 1;
                Caption = "";
                Column1Width = GlobalDefaults.Column1Width;
                Column2Width = GlobalDefaults.Column2Width;
                Column3Width = GlobalDefaults.Column3Width;
                Display = "inline-block";
                Enabled = true;
                FontName = GlobalDefaults.TextBoxFontName;
                FontSize = GlobalDefaults.TextBoxFontSize;
                FontSizeUnit = "px";
                HandleChangeOption = HandleChangeEnum.OnKeyDown;
                Height = 22;
                HeightUnit = "px";
                ImageBackColor = "transparent";
                ImageScale = 1.6;
                ImageWidth = 10;
                InputType = "text";
                InvalidLabelColor = "Tomato";
                IsUnique = true;
                LabelBackgroundColor = "transparent";
                LabelClassName = GlobalDefaults.LabelClassName;
                LabelColor = Color.Black;
                LabelFontName = GlobalDefaults.LabelFontName;
                LabelFontSize = GlobalDefaults.LabelFontSize;
                LabelTextAlign = "right";
                LabelWidth = 30;
                Left = 0;
                MarginBottom = 8;
                MarginLeft = 1.2;
                Position = "relative";
                Rows = 3;
                TakenImageUrl = "_content/BlazorComponentsTutorial/Images/Failure.png";
                Text = "";                
                TextBoxBackColor = "white";
                TextBoxFontName = GlobalDefaults.TextBoxFontName;
                TextBoxFontSize = GlobalDefaults.TextBoxFontSize;
                TextBoxLeft = 8;
                TextBoxTextColor = "black";
                TextBoxWidth = GlobalDefaults.TextBoxWidth;
                Top = 0;
                UniqueImageUrl = "_content/BlazorComponentsTutorial/Images/Success.png";
                Unit = "px";
                Visible = true;
                Width = 220;
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // if a message exists
                if (NullHelper.Exists(message))
                {
                    // if Taken
                    if ((TextHelper.IsEqual(message.Text, "Taken")) && (HasTakenImageUrl))
                    {
                        // Set the ImageUrl
                        ImageUrl = TakenImageUrl;

                        // Set to true
                        ShowImage = true;

                        // not valid because it is not unique
                        IsUnique = false;

                        // Not valid here
                        IsValid = false;
                    }
                    // if Available
                    else if ((TextHelper.IsEqual(message.Text, "Available")) && (HasUniqueImageUrl))
                    {
                        // Set the ImageUrl
                        ImageUrl = UniqueImageUrl;

                        // this is unique
                        isUnique = true;

                        // Set to true
                        ShowImage = true;

                        // Is valid here
                        IsValid = true;
                    }

                    // if the value for ShowImage is true
                    if (ShowImage)
                    {
                        // if there are parameters
                        if (ListHelper.HasOneOrMoreItems(message.Parameters))
                        {
                            // if a ValidationMessage was passed in with it
                            if (message.Parameters[0].Name == "Validation Message")
                            {
                                if (NullHelper.Exists(message.Parameters[0].Value))
                                {
                                    // Use the Validation Message passed in
                                    ValidationMessage = message.Parameters[0].Value.ToString();
                                }
                            }
                        }

                        // Refresh
                        Refresh();
                    }
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

            #region SendMessageToParent(string messageText, string keyCode = "")
            /// <summary>
            /// Sends a Message To the Parent
            /// </summary>
            public void SendMessageToParent(string messageText, string keyCode = "")
            {
                // if the value for HasParent is true
                if (HasParent)
                {
                    // Create a message
                    Message message = new Message();

                    // Set the message text
                    message.Text = messageText;

                    // Set the Sender
                    message.Sender = this;

                    // Send the KeyCode
                    message.KeyCode = keyCode;

                    // Create a new instance of a 'NamedParameter' object.
                    NamedParameter parameter = new NamedParameter();

                    // Set the name of the object calling
                    parameter.Name = this.Name;

                    // if the value for HasParentGrid is true
                    if (HasParentGrid)
                    {
                        // Send in the Ids to help find what was just saved
                        parameter.ColumnId = ColumnId;
                        parameter.RowId = RowId;
                        parameter.GridName = ParentGrid.Name;
                    }

                    // 12.11.2022: Added these to provide more info to clients.
                    parameter.ExternalId = ExternalId;
                    parameter.ExternalIdDescription = ExternalIdDescription;

                    // Set the value
                    parameter.Value = Text;

                    // Add this parameter
                    message.Parameters.Add(parameter);

                    // notify the parent
                    Parent.ReceiveData(message);                  
                }
            }
            #endregion
            
            #region SetBackgroundColor(Color color)
            /// <summary>
            /// Set Background Color
            /// </summary>
            public void SetBackgroundColor(Color color)
            {
                // Set the BackgroundColor
                BackgroundColor = color.Name;
            }
            #endregion
            
            #region SetClassName(string className, bool refresh)
            /// <summary>
            /// Set Class Name
            /// </summary>
            public void SetClassName(string newClassName, bool refresh)
            {
                // Set the ClassName
                ClassName = newClassName;

                // if the value for refresh is true
                if (refresh)
                {
                    // Set to Refresh
                    Refresh();
                }
            }
            #endregion
            
            #region SetEnabled(bool enable)
            /// <summary>
            /// Set Enabled
            /// </summary>
            public void SetEnabled(bool enable)
            {
                // store
                Enabled = enable;
            }
            #endregion
            
            #region SetFocus()
            /// <summary>
            /// method Set Focus
            /// </summary>
            public async void SetFocus()
            {
                try
                {
                    // Set focus to the control
                    await InnerControl.FocusAsync();
                }
                catch (Exception error)
                {
                    // for debugging only for now
                    DebugHelper.WriteDebugError("SetFocus", "TextBoxComponent.cs", error);
                }
            }
            #endregion
            
            #region SetInputType()
            /// <summary>
            /// This method Set Input Type
            /// </summary>
            public void SetInputType()
            {
                // default
                inputType = "text";

                // if the value for PasswordMode is true
                if (PasswordMode)
                {
                    // Set the InputType
                    inputType = "password";
                }                
            }
            #endregion
            
            #region SetInvalidLabelColor(string invalidColor)
            /// <summary>
            /// Set Invalid Label Color
            /// </summary>
            public void SetInvalidLabelColor(string invalidColor)
            {
                // Set the color to be set for invalid
                InvalidLabelColor = invalidColor;
            }
            #endregion
            
            #region SetLabelClassName(string labelClass)
            /// <summary>
            /// Set Label Class Name
            /// </summary>
            public void SetLabelClassName(string labelClass)
            {
                // Store
                LabelClassName = labelClass;
            }
            #endregion
            
            #region SetLabelColor()
            /// <summary>
            /// Set Label Color
            /// </summary>
            public void SetLabelColor(Color color)
            {
                // Store
                LabelColor = color;
            }
            #endregion
            
            #region SetTextBoxBackColor(Color color)
            /// <summary>
            /// Set Text Box Back Color
            /// </summary>
            public void SetTextBoxBackColor(Color color)
            {
                // Set the Color
                TextBoxBackColor = color.Name;
            }
            #endregion
            
            #region SetTextBoxTextColor(string color)
            /// <summary>
            /// Set Text Box Text Color
            /// </summary>
            public void SetTextBoxTextColor(string color)
            {
                // Store
                TextBoxTextColor = color;
            }
            #endregion
            
            #region SetTextValue(string text)
            /// <summary>
            /// This method Sets the Text Value
            /// </summary>
            public void SetTextValue(string text)
            {
                // Set the value
                this.Text = text;
            }
            #endregion
            
            #region Validate()
            /// <summary>
            /// This method Validate
            /// </summary>
            public bool Validate()
            {
                // initial value (Defaulting to true)
                bool isValid = true;

                // if an integer value is required
                if (IsIntegerRequired)
                {
                    // to do: Do this some day
                }
                else if (IsDoubleRequired)
                {
                    // to do: Do this some day
                }
                // if this is required
                else if (isRequired)
                {
                    // set isValid to true if there is any text
                    isValid = TextHelper.Exists(Text);

                    // if a Minimum or MaximumLength is set
                    if ((isValid) && (MinimumLength > 0) || (MaximumLength > 0))
                    {
                        // if a MinimumLength is required
                        if ((MinimumLength > 0) && (Text.Length < MinimumLength))
                        {
                            // not valid
                            isValid = false;
                        }

                        // if a MaximumLength is required
                        if ((MaximumLength > 0) && (Text.Length > MaximumLength))
                        {
                            // not valid
                            isValid = false;
                        }
                    }

                    // if a UniqueCallback is required
                    if ((isValid) && (IsUniqueCallbackRequired) && (HasParent))
                    {
                        // Create a new instance of a 'Message' object.
                        Message message = new Message();

                        // Set the Text
                        message.Text = "Check Unique";

                        // Create a new instance of a 'NamedParameter' object.
                        NamedParameter instructionParameter = new NamedParameter();

                        // Set the name & Value
                        instructionParameter.Name = Caption;
                        instructionParameter.Value = Text;

                        // Add this parameter
                        message.Parameters.Add(instructionParameter);

                        // Send the parent a message
                        Parent.ReceiveData(message);
                    }

                    // if not unique, not valid
                    if (!IsUnique)
                    {
                        // not valid if alse
                        isValid = false;

                        // Set the validiation message
                        this.ValidationMessage = "This " + this.Caption.Replace(":", "") + " is already taken. Please login if this is you.";
                    }

                    // Set the value
                    this.IsValid = isValid;
                }

                // if the value for IsValid is false
                if (!isValid)
                {
                    // Set the reason
                    InvalidReason = ValidationMessage;
                }

                // return value
                return isValid;
            }
            #endregion
            
        #endregion

        #region Properties
   
            #region AllowWrapping
            /// <summary>
            /// This property gets or sets the value for 'AllowWrapping'.
            /// </summary>
            [Parameter]
            public bool AllowWrapping
            {
                get { return allowWrapping; }
                set 
                {
                    // Set allowWrapping
                    allowWrapping = value;

                    // if allowWrapping is true
                    if (allowWrapping)
                    {
                        // do not wrap
                        TextWrapping = "";

                        // Use left
                        LabelTextAlign = "left";
                    }
                    else
                    {
                        // do not wrap
                        TextWrapping = "textdonotwrap";

                        // Use right
                        LabelTextAlign = "right";
                    }
                }
            }
            #endregion
            
            #region AutoComplete
            /// <summary>
            /// This property gets or sets the value for 'Autocomplete'.
            /// </summary>
            [Parameter]
            public bool AutoComplete
            {
                get { return autoComplete; }
                set { autoComplete = value; }
            }
            #endregion
            
            #region AutoCompleteStyle
            /// <summary>
            /// This read only property returns the value of AutoCompleteStyle from the object AutoComplete.
            /// </summary>
            public string AutoCompleteStyle
            {
                
                get
                {
                    // initial value
                    string autoCompleteStyle = "off";
                    
                    if (AutoComplete)
                    {
                        // Set to On if AutoComplete is truned on.
                        autoCompleteStyle = "on";
                    }
                    
                    // return value
                    return autoCompleteStyle;
                }
            }
            #endregion
            
            #region BackgroundColor
            /// <summary>
            /// This property gets or sets the value for 'BackgroundColor'.
            /// </summary>
            [Parameter]
            public string BackgroundColor
            {
                get { return backgroundColor; }
                set { backgroundColor = value; }
            }
            #endregion
            
            #region BorderColor
            /// <summary>
            /// This property gets or sets the value for 'BorderColor'.
            /// </summary>
            [Parameter]
            public string BorderColor
            {
                get { return borderColor; }
                set { borderColor = value; }
            }
            #endregion
            
            #region BorderWidth
            /// <summary>
            /// This property gets or sets the value for 'BorderWidth'.
            /// </summary>
            [Parameter]
            public double BorderWidth
            {
                get { return borderWidth; }
                set { borderWidth = value; }
            }
            #endregion
            
            #region BorderWidthStyle
            /// <summary>
            /// This read only property returns the value of BorderWidth + Unit;
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
            
            #region BottomMarginStyle
            /// <summary>
            /// This property gets or sets the value for 'BottomMarginStyle'.
            /// </summary>
            public string BottomMarginStyle
            {
                get { return bottomMarginStyle; }
                set { bottomMarginStyle = value; }
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
                set 
                {
                    // set the value
                    caption = value;

                    // Show the Caption, if the Caption is set.
                    ShowCaption = TextHelper.Exists(caption);

                    // if the value for ShowCaption is false
                    if (!ShowCaption)
                    {
                        // Reset to 0 if the Label is not visible
                        TextBoxLeft = 0;
                    }
                }
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
            
            #region Column1Style
            /// <summary>
            /// This property gets or sets the value for 'Column1Style'.
            /// </summary>
            public string Column1Style
            {
                get { return column1Style; }
                set { column1Style = value; }
            }
            #endregion
            
            #region Column1Width
            /// <summary>
            /// This property gets or sets the value for 'Column1Width'.
            /// </summary>
            [Parameter]
            public double Column1Width
            {
                get { return column1Width; }
                set { column1Width = value; }
            }
            #endregion
            
            #region Column1WidthStyle
            /// <summary>
            /// This read only property returns the value of Column1Width + Unit
            /// </summary>
            public string Column1WidthStyle
            {
                
                get
                {
                    // initial value
                    string column1WidthStyle = Column1Width + Unit;
                    
                    // return value
                    return column1WidthStyle;
                }
            }
            #endregion
            
            #region Column2Style
            /// <summary>
            /// This property gets or sets the value for 'Column2Style'.
            /// </summary>
            public string Column2Style
            {
                get { return column2Style; }
                set { column2Style = value; }
            }
            #endregion
            
            #region Column2Width
            /// <summary>
            /// This property gets or sets the value for 'Column2Width'.
            /// </summary>
            [Parameter]
            public double Column2Width
            {
                get { return column2Width; }
                set { column2Width = value; }
            }
            #endregion

            #region Column2WidthStyle
            /// <summary>
            /// This read only property returns the value of Column2Width + Unit
            /// </summary>
            public string Column2WidthStyle
            {
                
                get
                {
                    // initial value
                    string column2WidthStyle = Column2Width + Unit;
                    
                    // return value
                    return column2WidthStyle;
                }
            }
            #endregion
            
            #region Column3Style
            /// <summary>
            /// This property gets or sets the value for 'Column3Style'.
            /// </summary>
            public string Column3Style
            {
                get { return column3Style; }
                set { column3Style = value; }
            }
            #endregion
            
            #region Column3Width
            /// <summary>
            /// This property gets or sets the value for 'Column3Width'.
            /// </summary>
            [Parameter]
            public double Column3Width
            {
                get { return column3Width; }
                set { column3Width = value; }
            }
            #endregion

            #region Column3WidthStyle
            /// <summary>
            /// This read only property returns the value of Column3Width + Unit
            /// </summary>
            public string Column3WidthStyle
            {
                
                get
                {
                    // initial value
                    string column3WidthStyle = Column3Width + Unit;
                    
                    // return value
                    return column3WidthStyle;
                }
            }
            #endregion
            
            #region ColumnId
            /// <summary>
            /// This property gets or sets the value for 'ColumnId'.
            /// </summary>
            [Parameter]
            public Guid ColumnId
            {
                get { return columnId; }
                set { columnId = value; }
            }
            #endregion
            
            #region Display
            /// <summary>
            /// This property gets or sets the value for 'Display'.
            /// This property will be used, unless Visible = false, then DisplayNone will be used.
            /// </summary>
            [Parameter]
            public string Display
            {
                get { return display; }
                set { display = value; }
            }
            #endregion
            
            #region DisplayStyle
            /// <summary>
            /// This read only property returns the value of Display, unless Visible = false.
            /// </summary>
            public string DisplayStyle
            {
                
                get
                {
                    // initial value
                    string displayStyle = "";
                    
                    // if the value for Visible is true
                    if (Visible)
                    {
                        // set the return value
                        displayStyle = Display;
                    }
                    else
                    {
                        // Invisible
                        displayStyle = "none";
                    }
                    
                    // return value
                    return displayStyle;
                }
            }
            #endregion
            
            #region Enabled
            /// <summary>
            /// This property gets or sets the value for 'Enabled'.
            /// </summary>
            [Parameter]
            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
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
            
            #region FontName
            /// <summary>
            /// This property gets or sets the value for 'FontName'.
            /// </summary>
            [Parameter]
            public string FontName
            {
                get { return fontName; }
                set 
                {
                    // Set the FontName
                    fontName = value;

                    // Set Both
                    LabelFontName = value;
                    TextBoxFontName = value;
                }
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
                set 
                {
                    // Set the fontSize
                    fontSize = value;

                    // Set Both
                    LabelFontSize = value;
                    TextBoxFontSize = value;
                }
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
            
            #region FormatAsPhoneNumber
            /// <summary>
            /// This property gets or sets the value for 'FormatAsPhoneNumber'.
            /// </summary>
            [Parameter]
            public bool FormatAsPhoneNumber
            {
                get { return formatAsPhoneNumber; }
                set { formatAsPhoneNumber = value; }
            }
            #endregion
            
            #region HandleChangeOption
            /// <summary>
            /// This property gets or sets the value for 'HandleChangeOption'.
            /// </summary>
            [Parameter]
            public HandleChangeEnum HandleChangeOption
            {
                get { return handleChangeOption; }
                set { handleChangeOption = value; }
            }
            #endregion
            
            #region HasOnTextChangedCallback
            /// <summary>
            /// This property returns true if this object has an 'OnTextChangedCallback'.
            /// </summary>
            public bool HasOnTextChangedCallback
            {
                get
                {
                    // initial value
                    bool hasOnTextChangedCallback = (this.OnTextChangedCallback != null);
                    
                    // return value
                    return hasOnTextChangedCallback;
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
            
            #region HasParentGrid
            /// <summary>
            /// This property returns true if this object has a 'ParentGrid'.
            /// </summary>
            public bool HasParentGrid
            {
                get
                {
                    // initial value
                    bool hasParentGrid = (this.ParentGrid != null);
                    
                    // return value
                    return hasParentGrid;
                }
            }
            #endregion
            
            #region HasTakenImageUrl
            /// <summary>
            /// This property returns true if the 'TakenImageUrl' exists.
            /// </summary>
            public bool HasTakenImageUrl
            {
                get
                {
                    // initial value
                    bool hasTakenImageUrl = (!String.IsNullOrEmpty(this.TakenImageUrl));
                    
                    // return value
                    return hasTakenImageUrl;
                }
            }
            #endregion
            
            #region HasText
            /// <summary>
            /// This property returns true if the 'Text' exists.
            /// </summary>
            public bool HasText
            {
                get
                {
                    // initial value
                    bool hasText = (!String.IsNullOrEmpty(Text));

                    // return value
                    return hasText;
                }
            }
            #endregion
            
            #region HasUniqueImageUrl
            /// <summary>
            /// This property returns true if the 'UniqueImageUrl' exists.
            /// </summary>
            public bool HasUniqueImageUrl
            {
                get
                {
                    // initial value
                    bool hasUniqueImageUrl = (!String.IsNullOrEmpty(this.UniqueImageUrl));
                    
                    // return value
                    return hasUniqueImageUrl;
                }
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
                set {height = value;}
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
                    string heightStyle = Height + unit;                    
                    
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
            
            #region ImageBackColor
            /// <summary>
            /// This property gets or sets the value for 'ImageBackColor'.
            /// </summary>
            [Parameter]
            public string ImageBackColor
            {
                get { return imageBackColor; }
                set { imageBackColor = value; }
            }
            #endregion
            
            #region ImageClassName
            /// <summary>
            /// This property gets or sets the value for 'ImageClassName'.
            /// </summary>
            [Parameter]
            public string ImageClassName
            {
                get { return imageClassName; }
                set { imageClassName = value; }
            }
            #endregion
            
            #region ImageScale
            /// <summary>
            /// This property gets or sets the value for 'ImageScale'.
            /// </summary>
            [Parameter]
            public double ImageScale
            {
                get { return imageScale; }
                set { imageScale = value; }
            }
            #endregion
            
            #region ImageStyle
            /// <summary>
            /// This property gets or sets the value for 'ImageStyle'.
            /// </summary>
            public string ImageStyle
            {
                get { return imageStyle; }
                set { imageStyle = value; }
            }
            #endregion
            
            #region ImageUrl
            /// <summary>
            /// This property gets or sets the value for 'ImageUrl'.
            /// </summary>
            public string ImageUrl
            {
                get { return imageUrl; }
                set { imageUrl = value; }
            }
            #endregion
            
            #region ImageWidth
            /// <summary>
            /// This property gets or sets the value for 'ImageWidth'.
            /// </summary>
            [Parameter]
            public double ImageWidth
            {
                get { return imageWidth; }
                set { imageWidth = value; }
            }
            #endregion
            
            #region ImageWidthStyle
            /// <summary>
            /// This read only property returns the value of ImageWidthStyle from the object ImageWidth.
            /// </summary>
            public string ImageWidthStyle
            {
                
                get
                {
                    // initial value
                    string imageWidthStyle = ImageWidth + "%";
                    
                    // return value
                    return imageWidthStyle;
                }
            }
            #endregion
            
            #region InnerControl
            /// <summary>
            /// This property gets or sets the value for 'InnerControl'.
            /// </summary>
            public ElementReference InnerControl
            {
                get { return innerControl; }
                set { innerControl = value; }
            }
            #endregion
            
            #region InputType
            /// <summary>
            /// This property gets or sets the value for 'InputType'.
            /// </summary>
            public string InputType
            {
                get { return inputType; }
                set { inputType = value; }
            }
            #endregion
            
            #region InvalidLabelColor
            /// <summary>
            /// This property gets or sets the value for 'InvalidLabelColor'.
            /// </summary>
            [Parameter]
            public string InvalidLabelColor
            {
                get { return invalidLabelColor; }
                set { invalidLabelColor = value; }
            }
            #endregion
            
            #region InvalidReason
            /// <summary>
            /// This property gets or sets the value for 'InvalidReason'.
            /// </summary>
            public string InvalidReason
            {
                get { return invalidReason; }
                set { invalidReason = value; }
            }
            #endregion
            
            #region IsDoubleRequired
            /// <summary>
            /// This property gets or sets the value for 'IsDoubleRequired'.
            /// </summary>
            [Parameter]
            public bool IsDoubleRequired
            {
                get { return isDoubleRequired; }
                set { isDoubleRequired = value; }
            }
            #endregion
            
            #region IsIntegerRequired
            /// <summary>
            /// This property gets or sets the value for 'IsIntegerRequired'.
            /// </summary>
            [Parameter]
            public bool IsIntegerRequired
            {
                get { return isIntegerRequired; }
                set { isIntegerRequired = value; }
            }
            #endregion
            
            #region IsRequired
            /// <summary>
            /// This property gets or sets the value for 'IsRequired'.
            /// </summary>
            [Parameter]
            public bool IsRequired
            {
                get { return isRequired; }
                set { isRequired = value; }
            }
            #endregion
            
            #region IsUnique
            /// <summary>
            /// This property gets or sets the value for 'IsUnique'.
            /// </summary>
            public bool IsUnique
            {
                get { return isUnique; }
                set { isUnique = value; }
            }
            #endregion
            
            #region IsUniqueCallbackRequired
            /// <summary>
            /// This property gets or sets the value for 'IsUniqueCallbackRequired'.
            /// </summary>
            [Parameter]
            public bool IsUniqueCallbackRequired
            {
                get { return isUniqueCallbackRequired; }
                set { isUniqueCallbackRequired = value; }
            }
            #endregion
            
            #region IsValid
            /// <summary>
            /// This property gets or sets the value for 'IsValid'.
            /// </summary>            
            public bool IsValid
            {
                get { return isValid; }
                set 
                {
                    // set the value
                    isValid = value;

                    // if valid
                    if (isValid)
                    {
                        // Set for valid
                        LabelColor = Color.Black;
                        TextBoxBackColor = "White";
                    }
                    else
                    {
                        // Set for valid
                        LabelColor = Color.Tomato;
                        TextBoxBackColor = "Tomato";
                    }
                }
            }
            #endregion
            
            #region LabelBackgroundColor
            /// <summary>
            /// This property gets or sets the value for 'LabelBackgroundColor'.
            /// </summary>
            [Parameter]
            public string LabelBackgroundColor
            {
                get { return labelBackgroundColor; }
                set { labelBackgroundColor = value; }
            }
            #endregion
            
            #region LabelClassName
            /// <summary>
            /// This property gets or sets the value for 'LabelClassName'.
            /// </summary>
            [Parameter]
            public string LabelClassName
            {
                get { return labelClassName; }
                set { labelClassName = value; }
            }
            #endregion
            
            #region LabelColor
            /// <summary>
            /// This property gets or sets the value for 'LabelColor'.
            /// </summary>
            [Parameter]
            public Color LabelColor
            {
                get { return labelColor; }
                set { labelColor = value; }
            }
            #endregion
            
            #region LabelFontName
            /// <summary>
            /// This property gets or sets the value for 'LabelFontName'.
            /// </summary>
            [Parameter]
            public string LabelFontName
            {
                get { return labelFontName; }
                set { labelFontName = value; }
            }
            #endregion
            
            #region LabelFontSize
            /// <summary>
            /// This property gets or sets the value for 'LabelFontSize'.
            /// </summary>
            [Parameter]
            public double LabelFontSize
            {
                get { return labelFontSize; }
                set { labelFontSize = value; }
            }
            #endregion
            
            #region LabelFontSizeStyle
            /// <summary>
            /// This property gets or sets the value for 'LabelFontSizeStyle'.
            /// </summary>
            public string LabelFontSizeStyle
            {
                get 
                {
                    // set the return value
                    string labelFontSizeStyle = LabelFontSize + Unit;

                    // return value
                    return labelFontSizeStyle;
                }
            }
            #endregion
            
            #region LabelLeft
            /// <summary>
            /// This property gets or sets the value for 'LabelLeft'.
            /// </summary>
            [Parameter]
            public double LabelLeft
            {
                get { return labelLeft; }
                set { labelLeft = value; }
            }
            #endregion
            
            #region LabelLeftStyle
            /// <summary>
            /// This read only property returns the value of LabelLeftStyle from the object LabelLeft.
            /// </summary>
            public string LabelLeftStyle
            {
                
                get
                {
                    // initial value
                    string labelLeftStyle = LabelLeft + unit;
                    
                    // return value
                    return labelLeftStyle;
                }
            }
            #endregion
            
            #region LabelStyle
            /// <summary>
            /// This property gets or sets the value for 'LabelStyle'.
            /// </summary>
            public string LabelStyle
            {
                get { return labelStyle; }
                set { labelStyle = value; }
            }
            #endregion

            #region LabelTextAlign
            /// <summary>
            /// This property gets or sets the value for 'LabelTextAlign'.
            /// </summary>
            [Parameter]
            public string LabelTextAlign
            {
                get { return labelTextAlign; }
                set { labelTextAlign = value; }
            }
            #endregion
            
            #region LabelTop
            /// <summary>
            /// This property gets or sets the value for 'LabelTop'.
            /// </summary>
            [Parameter]
            public double LabelTop
            {
                get { return labelTop; }
                set { labelTop = value; }
            }
            #endregion
            
            #region LabelTopStyle
            /// <summary>
            /// This read only property returns the value of LabelTopStyle from the object LabelTop.
            /// </summary>
            public string LabelTopStyle
            {
                
                get
                {
                    // initial value
                    string labelTopStyle = LabelTop + HeightUnit;
                    
                    // return value
                    return labelTopStyle;
                }
            }
            #endregion
            
            #region LabelWidth
            /// <summary>
            /// This property gets or sets the value for 'LabelWidth'.
            /// </summary>
            [Parameter]
            public double LabelWidth
            {
                get { return labelWidth; }
                set 
                {
                    // set the value
                    labelWidth = value;

                    // if a Caption is set
                    if (ShowCaption)
                    {
                        // if the Column is not as big
                        if (Column1Width < labelWidth)
                        {
                            // Set
                            Column1Width = labelWidth;
                        }
                    }
                }
            }
            #endregion
            
            #region LabelWidthStyle
            /// <summary>
            /// This property gets or sets the value for 'LabelWidthStyle'.
            /// </summary>
            public string LabelWidthStyle
            {
                get
                {
                    string labelWidthStyle = LabelWidth + Unit;

                    // return value
                    return labelWidthStyle;
                }
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
            
            #region Loading
            /// <summary>
            /// This property gets or sets the value for 'Loading'.
            /// </summary>
            public bool Loading
            {
                get { return loading; }
                set { loading = value; }
            }
            #endregion
            
            #region MarginBottom
            /// <summary>
            /// This property gets or sets the value for 'MarginBottom'.
            /// </summary>
            [Parameter]
            public double MarginBottom
            {
                get { return marginBottom; }
                set { marginBottom = value; }
            }
            #endregion
            
            #region MarginBottomStyle
            /// <summary>
            /// This read only property returns the value of MarginBottomStyle from the object MarginBottom.
            /// </summary>
            public string MarginBottomStyle
            {
                
                get
                {
                    // initial value
                    string marginBottomStyle = MarginBottom + HeightUnit;
                    
                    // return value
                    return marginBottomStyle;
                }
            }
            #endregion
            
            #region MarginLeft
            /// <summary>
            /// This property gets or sets the value for 'MarginLeft'.
            /// </summary>
            [Parameter]
            public double MarginLeft
            {
                get { return marginLeft; }
                set { marginLeft = value; }
            }
            #endregion
            
            #region MarginLeftStyle
            /// <summary>
            /// This read only property returns the value of MarginLeftStyle from the object MarginLeft.
            /// </summary>
            public string MarginLeftStyle
            {
                
                get
                {
                    // initial value
                    string marginLeftStyle = MarginLeft + Unit;

                    // return value
                    return marginLeftStyle;
                }
            }
            #endregion
            
            #region MaximumDouble
            /// <summary>
            /// This property gets or sets the value for 'MaximumDouble'.
            /// </summary>
            [Parameter]
            public int MaximumDouble
            {
                get { return maximumDouble; }
                set { maximumDouble = value; }
            }
            #endregion
            
            #region MaximumInteger
            /// <summary>
            /// This property gets or sets the value for 'MaximumInteger'.
            /// </summary>
            [Parameter]
            public int MaximumInteger
            {
                get { return maximumInteger; }
                set { maximumInteger = value; }
            }
            #endregion
            
            #region MaximumLength
            /// <summary>
            /// This property gets or sets the value for 'MaximumLength'.
            /// </summary>
            [Parameter]
            public int MaximumLength
            {
                get { return maximumLength; }
                set { maximumLength = value; }
            }
            #endregion
            
            #region MinimumDouble
            /// <summary>
            /// This property gets or sets the value for 'MinimumDouble'.
            /// </summary>
            [Parameter]
            public int MinimumDouble
            {
                get { return minimumDouble; }
                set { minimumDouble = value; }
            }
            #endregion
            
            #region MinimumInteger
            /// <summary>
            /// This property gets or sets the value for 'MinimumInteger'.
            /// </summary>
            [Parameter]
            public int MinimumInteger
            {
                get { return minimumInteger; }
                set { minimumInteger = value; }
            }
            #endregion
            
            #region MinimumLength
            /// <summary>
            /// This property gets or sets the value for 'MinimumLength'.
            /// </summary>
            [Parameter]
            public int MinimumLength
            {
                get { return minimumLength; }
                set { minimumLength = value; }
            }
            #endregion
            
            #region Multiline
            /// <summary>
            /// This property gets or sets the value for 'Multiline'.
            /// Use the Height and Width properties to set the size.
            /// </summary>
            [Parameter]
            public bool Multiline
            {
                get { return multiline; }
                set 
                { 
                    multiline = value;
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
            
            #region NotifyParentOnBlur
            /// <summary>
            /// This property gets or sets the value for 'NotifyParentOnBlur'.
            /// </summary>
            [Parameter]
            public bool NotifyParentOnBlur
            {
                get { return notifyParentOnBlur; }
                set { notifyParentOnBlur = value; }
            }
            #endregion
            
            #region OnTextChangedCallback
            /// <summary>
            /// This property gets or sets the value for 'OnTextChangedCallback'.
            /// </summary>
            [Parameter]
            public OnTextChange OnTextChangedCallback
            {
                get { return onTextChangedCallback; }
                set { onTextChangedCallback = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
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
            
            #region ParentGrid
            /// <summary>
            /// This read only property returns the value of ParentGrid from the object Parent.
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
                        // set the return value
                        parentGrid = Parent as Grid;
                    }
                    
                    // return value
                    return parentGrid;
                }
            }
            #endregion
            
            #region PasswordMode
            /// <summary>
            /// This property gets or sets the value for 'PasswordMode'.
            /// </summary>
            [Parameter]
            public bool PasswordMode
            {
                get { return passwordMode; }
                set 
                { 
                    // set the value
                    passwordMode = value;

                    // Set the InputType
                    SetInputType();
                }
            }
            #endregion
            
            #region Pattern
            /// <summary>
            /// This property gets or sets the value for 'Pattern'.
            /// </summary>
            [Parameter]
            public string Pattern
            {
                get { return pattern; }
                set { pattern = value; }
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
            
            #region RowId
            /// <summary>
            /// This property gets or sets the value for 'RowId'.
            /// </summary>
            [Parameter]
            public Guid RowId
            {
                get { return rowId; }
                set { rowId = value; }
            }
            #endregion
            
            #region Rows
            /// <summary>
            /// This property gets or sets the value for 'Rows'.
            /// </summary>
            [Parameter]
            public int Rows
            {
                get { return rows; }
                set { rows = value; }
            }
            #endregion
            
            #region SendAllTextToParent
            /// <summary>
            /// This property gets or sets the value for 'SendAllTextToParent'.
            /// </summary>
            [Parameter]
            public bool SendAllTextToParent
            {
                get { return sendAllTextToParent; }
                set { sendAllTextToParent = value; }
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
            
            #region ShowCaption
            /// <summary>
            /// This property gets or sets the value for 'ShowCaption'.
            /// </summary>
            [Parameter]
            public bool ShowCaption
            {
                get { return showCaption; }
                set { showCaption = value; }
            }
            #endregion
            
            #region ShowImage
            /// <summary>
            /// This property gets or sets the value for 'ShowImage'.
            /// </summary>
            public bool ShowImage
            {
                get { return showImage; }
                set { showImage = value; }
            }
            #endregion
            
            #region TabIndex
            /// <summary>
            /// This property gets or sets the value for 'TabIndex'.
            /// </summary>
            [Parameter]
            public int TabIndex
            {
                get { return tabIndex; }
                set { tabIndex = value; }
            }
            #endregion
            
            #region TakenImageUrl
            /// <summary>
            /// This property gets or sets the value for 'TakenImageUrl'.
            /// </summary>            
            [Parameter]
            public string TakenImageUrl
            {
                get { return takenImageUrl; }
                set { takenImageUrl = value; }
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
                set 
                {
                    text = value;

                    if (!Loading)
                    {
                        // if the call back exists
                        if (HasOnTextChangedCallback)
                        {
                            // Notify the Subscriber
                            OnTextChangedCallback(text);
                        }
                    }
                }
            }
            #endregion
            
            #region TextBoxBackColor
            /// <summary>
            /// This property gets or sets the value for 'TextBoxBackColor'.
            /// </summary>
            [Parameter]
            public string TextBoxBackColor
            {
                get { return textBoxBackColor; }
                set { textBoxBackColor = value; }
            }
            #endregion
            
            #region TextBoxClassName
            /// <summary>
            /// This property gets or sets the value for 'TextBoxClassName'.
            /// </summary>
            [Parameter]
            public string TextBoxClassName
            {
                get { return textBoxClassName; }
                set { textBoxClassName = value; }
            }
            #endregion

            #region TextBoxControlStyle
            /// <summary>
            /// This property gets or sets the value for 'ValidationControlStyle'.
            /// </summary>
            public string TextBoxControlStyle
            {
                get { return textBoxControlStyle; }
                set { textBoxControlStyle = value; }
            }
            #endregion
            
            #region TextBoxFontName
            /// <summary>
            /// This property gets or sets the value for 'TextBoxFontName'.
            /// </summary>
            [Parameter]
            public string TextBoxFontName
            {
                get { return textBoxFontName; }
                set { textBoxFontName = value; }
            }
            #endregion
            
            #region TextBoxFontSize
            /// <summary>
            /// This property gets or sets the value for 'TextBoxFontSize'.
            /// </summary>
            [Parameter]
            public double TextBoxFontSize
            {
                get { return textBoxFontSize; }
                set { textBoxFontSize = value; }
            }
            #endregion
            
            #region TextBoxFontSizeStyle
            /// <summary>
            /// This read only property returns the value of TextBoxFontSizeStyle from the object TextBoxFontSize.
            /// </summary>
            public string TextBoxFontSizeStyle
            {
                
                get
                {
                    // initial value
                    string textBoxFontSizeStyle = TextBoxFontSize + Unit;
                    
                    // return value
                    return textBoxFontSizeStyle;
                }
            }
            #endregion
            
            #region TextBoxLeft
            /// <summary>
            /// This property gets or sets the value for 'TextBoxLeft'.
            /// </summary>
            [Parameter]
            public double TextBoxLeft
            {
                get { return textBoxLeft; }
                set { textBoxLeft = value; }
            }
            #endregion
            
            #region TextBoxLeftStyle
            /// <summary>
            /// This read only property returns the value of TextBoxLeft + Unit
            /// </summary>
            public string TextBoxLeftStyle
            {

                get
                {
                    // initial value
                    string textBoxLeftStyle = TextBoxLeft + Unit;
                    
                    // return value
                    return textBoxLeftStyle;
                }
            }
            #endregion

            #region TextBoxStyle
            /// <summary>
            /// This property gets or sets the value for 'TextBoxStyle'.
            /// </summary>
            public string TextBoxStyle
            {
                get { return textBoxStyle; }
                set { textBoxStyle = value; }
            }
            #endregion

            #region TextBoxTextColor
            /// <summary>
            /// This property gets or sets the value for 'TextBoxTextColor'.
            /// </summary>
            [Parameter]
            public string TextBoxTextColor
            {
                get { return textBoxTextColor; }
                set { textBoxTextColor = value; }
            }
            #endregion
            
            #region TextBoxTop
            /// <summary>
            /// This property gets or sets the value for 'TextBoxTop'.
            /// </summary>
            [Parameter]
            public double TextBoxTop
            {
                get { return textBoxTop; }
                set { textBoxTop = value; }
            }
            #endregion
            
            #region TextBoxTopStyle
            /// <summary>
            /// This read only property returns the value of TextBoxTop + HeightUnit
            /// </summary>
            public string TextBoxTopStyle
            {

                get
                {
                    // initial value
                    string textBoxTopStyle = TextBoxTop + HeightUnit;
                    
                    // return value
                    return textBoxTopStyle;
                }
            }
            #endregion

            #region TextBoxWidth
            /// <summary>
            /// This property gets or sets the value for 'TextBoxWidth'.
            /// </summary>
            [Parameter]
            public double TextBoxWidth
            {
                get { return textBoxWidth; }
                set { textBoxWidth = value; }
            }
            #endregion
            
            #region TextBoxWidthStyle
            /// <summary>
            /// This read only property returns the value of TextBoxWidthStyle; from the object TextBoxWidthStyle.
            /// </summary>
            public string TextBoxWidthStyle
            {  
                get
                {
                    // initial value
                    string textBoxWidthStyle = TextBoxWidth + Unit;
                    
                    // return value
                    return textBoxWidthStyle;
                }
            }
            #endregion
            
            #region TextWrapping
            /// <summary>
            /// This property gets or sets the value for 'TextWrapping'.
            /// </summary>
            public string TextWrapping
            {
                get { return textWrapping; }
                set { textWrapping = value; }
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
            
            #region UniqueImageUrl
            /// <summary>
            /// This property gets or sets the value for 'UniqueImageUrl'.
            /// </summary>
            [Parameter]
            public string UniqueImageUrl
            {
                get { return uniqueImageUrl; }
                set { uniqueImageUrl = value; }
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
                set {unit = value;}
            }
            #endregion
            
            #region ValidationMessage
            /// <summary>
            /// This property gets or sets the value for 'ValidationMessage'.
            /// </summary>
            [Parameter]
            public string ValidationMessage
            {
                get { return validationMessage; }
                set { validationMessage = value; }
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
            public double Width
            {
                get { return width; }
                set { width = value;}
            }
            #endregion
            
            #region WidthStyle
            /// <summary>
            /// This read only property returns the value of Width + Unit
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
            
            #region ZIndexPlus1
            /// <summary>
            /// This read only property returns the value of ZIndex Plus1
            /// </summary>
            public int ZIndexPlus1
            {
                
                get
                {
                    // initial value
                    int zIndexPlus1 = ZIndex + 1;
                    
                    // return value
                    return zIndexPlus1;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
