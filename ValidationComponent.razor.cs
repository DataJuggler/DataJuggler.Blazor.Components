

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components.Web;
using System.Drawing;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class ValidationComponent : IBlazorComponent
    /// <summary>
    /// The validation component is just a way to display a valid or not valid to make the UI
    /// appear different.
    /// </summary>
    public partial class ValidationComponent : IBlazorComponent
    {
        
        #region Private Variables
        private string labelColor;
        private string labelClassName;
        private string labelBackgroundColor;
        private string textBoxBackColor;
        private string labelStyle;
        private string textBoxStyle;
        private bool isValid;
        private string caption;
        private string text;        
        private bool isRequired;
        private bool isIntegerRequired;
        private bool isDoubleRequired;
        private bool passwordMode;
        private string inputType;
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
        private bool showImage;
        private string imageStyle;
        private bool isUnique;
        private bool checkBoxMode;
        private bool checkBoxValue;
        private string checkBoxStyle;
        private double imageScale;
        private double checkBoxXPosition;
        private string checkBoxXStyle;
        private double checkBoxYPosition;
        private string checkBoxYStyle;
        private string validationControlStyle;
        private double fontSize;
        private string fontSizeStyle;        
        private double height;        
        private double width;        
        private string name;
        private double left;
        private double top;
        private string leftStyle;
        private string topStyle;        
        private double labelWidth;
        private double labelFontSize;
        private string labelFontSizeStyle;
        private string labelFontSizeUnit;
        private string labelWidthStyle;
        private int zIndex;
        private string position;
        private IBlazorComponentParent parent;
        private string className;
        private bool setFocusOnFirstRender;
        private bool showCaption;
        private string unit;
        private string heightUnit;
        private int externalId;
        private string externalIdDescription;
        // This are only used when inside a Grid
        private Guid rowId;
        private Guid columnId;
        private ElementReference innerControl;
        private bool visible;
        private string display;
        private bool sendAllTextToParent;
        private bool autoComplete;
        private double labelTop;
        private string fontSizeUnit;
        private string backgroundColor;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a ValidationComponent object
        /// </summary>
        public ValidationComponent()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events            
            
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
                    SendMessageToParent("text: " + e.Code);
                }
            }
            #endregion

            #region Init()
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Set Default Values
                LabelColor = "LemonChiffon";
                TextBoxBackColor = "White";
                InputType = "text";
                Text = "";
                IsUnique = true;
                ImageScale = 1.6;
                TakenImageUrl = "_content/DataJuggler.Blazor.Components/Images/Failure.png";
                UniqueImageUrl = "_content/DataJuggler.Blazor.Components/Images/Success.png";
                CheckBoxXPosition = -6;
                CheckBoxYPosition = 1.28;
                FontSize = 12;
                Unit = "px";
                FontSizeUnit="px";
                Width = 40;
                Height = 16;                
                Position = "relative";
                Top = .2;
                Left = -6;
                LabelWidth = 20;
                LabelFontSize = 12;
                LabelFontSizeUnit = "px";
                Display = "inline-block";
                Visible = true;
                LabelBackgroundColor = "transparent";
                BackgroundColor = "transparent";

                // Just being explicit
                SetFocusOnFirstRender = false;
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

            #region SendMessageToParent(string messageText)
            /// <summary>
            /// Sends a Message To the Parent
            /// </summary>
            public void SendMessageToParent(string messageText)
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
            
            #region SetCheckBoxValue(bool isChecked)
            /// <summary>
            /// This method Sets the CheckBoxValue
            /// </summary>
            public void SetCheckBoxValue(bool isChecked)
            {
                // if CheckBoxMode
                if (this.CheckBoxMode)
                {
                    // Set the value
                    this.CheckBoxValue = isChecked;
                }
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
                    DebugHelper.WriteDebugError("SetFocus", "ValidationComponent.cs", error);
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
                else if (CheckBoxMode)
                {
                    // Set the InputType
                    inputType = "checkbox";
                }
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
                // initial value
                bool isValid = false;

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
                        this.ValidationMessage = "This " + this.Caption + " is already taken. Please login if this is you.";
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

            #region AutoComplete
            /// <summary>
            /// This property gets or sets the value for 'AutoComplete'.
            /// </summary>
            [Parameter]
            public bool AutoComplete
            {
                get { return autoComplete; }
                set { autoComplete = value; }
            }
            #endregion
            
            #region AutoCompleteEnabled
            /// <summary>
            /// This read only property returns the value of AutoCompleteEnabled from the object AutoComplete.
            /// </summary>
            public string AutoCompleteEnabled
            {
                
                get
                {
                    // initial value
                    string autoCompleteEnabled = "on";

                    // if not AutoComplete
                    if (!AutoComplete)
                    {
                        // set the value
                        autoCompleteEnabled = "off";
                    }
                    
                    // return value
                    return autoCompleteEnabled;
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
                }
            }
            #endregion
            
            #region CheckBoxMode
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxMode'.
            /// </summary>
            [Parameter]
            public bool CheckBoxMode
            {
                get { return checkBoxMode; }
                set 
                {
                    // set the value
                    checkBoxMode = value;

                    // Set to CheckBox
                    SetInputType();
                }
            }
            #endregion
            
            #region CheckBoxStyle
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxStyle'.
            /// </summary>
            public string CheckBoxStyle
            {
                get { return checkBoxStyle; }
                set { checkBoxStyle = value; }
            }
            #endregion
            
            #region CheckBoxValue
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxValue'.
            /// </summary>
            [Parameter]
            public bool CheckBoxValue
            {
                get { return checkBoxValue; }
                set { checkBoxValue = value; }
            }
            #endregion
            
            #region CheckBoxXPosition
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxXPosition'.
            /// </summary>
            [Parameter]
            public double CheckBoxXPosition
            {
                get { return checkBoxXPosition; }
                set 
                { 
                    // set the value
                    checkBoxXPosition = value;

                    // set the headerStyle value
                    checkBoxXStyle = checkBoxXPosition.ToString() + "%";
                }
            }
            #endregion
            
            #region CheckBoxXStyle
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxXStyle'.
            /// </summary>
            public string CheckBoxXStyle
            {
                get { return checkBoxXStyle; }
                set { checkBoxXStyle = value; }
            }
            #endregion
            
            #region CheckBoxYPosition
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxYPosition'.
            /// </summary>
            [Parameter]
            public double CheckBoxYPosition
            {
                get { return checkBoxYPosition; }
                set 
                {
                    // set the value
                    checkBoxYPosition = value;

                    // Set the checkBoxYStyle
                    checkBoxYStyle = checkBoxYPosition.ToString() + "vh";
                }
            }
            #endregion
            
            #region CheckBoxYStyle
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxYStyle'.
            /// </summary>
            public string CheckBoxYStyle
            {
                get { return checkBoxYStyle; }
                set { checkBoxYStyle = value; }
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
                set 
                {
                    // set the value
                    fontSize = value;

                    // Set to vh or the unit set
                    fontSizeStyle = fontSize.ToString() + FontSizeUnit;
                }
            }
            #endregion
           
            #region FontSizeStyle
            /// <summary>
            /// This property gets or sets the value for 'FontSizeStyle'.
            /// </summary>
            public string FontSizeStyle
            {
                get { return fontSizeStyle; }
                set { fontSizeStyle = value; }
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
                        LabelColor = "LemonChiffon";
                        TextBoxBackColor = "White";
                    }
                    else
                    {
                        // Set for valid
                        LabelColor = "Tomato";
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
            public string LabelColor
            {
                get { return labelColor; }
                set { labelColor = value; }
            }
            #endregion
            
            #region LabelFontSize
            /// <summary>
            /// This property gets or sets the value for 'LabelFontSize'.
            /// </summary>
            public double LabelFontSize
            {
                get { return labelFontSize; }
                set 
                { 
                    // Set the value
                    labelFontSize = value;

                    // Set hte LabelFontSizeStyle
                    LabelFontSizeStyle = labelFontSize + LabelFontSizeUnit;
                }
            }
            #endregion
            
            #region LabelFontSizeStyle
            /// <summary>
            /// This property gets or sets the value for 'LabelFontSizeStyle'.
            /// </summary>
            public string LabelFontSizeStyle
            {
                get { return labelFontSizeStyle; }
                set { labelFontSizeStyle = value; }
            }
            #endregion
            
            #region LabelFontSizeUnit
            /// <summary>
            /// This property gets or sets the value for 'LabelFontSizeUnit'.
            /// </summary>
            [Parameter]
            public string LabelFontSizeUnit
            {
                get { return labelFontSizeUnit; }
                set { labelFontSizeUnit = value; }
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

                    // Add % or the default unit
                    LabelWidthStyle = labelWidth + LabelFontSizeUnit;
                }
            }
            #endregion
            
            #region LabelWidthStyle
            /// <summary>
            /// This property gets or sets the value for 'LabelWidthStyle'.
            /// </summary>
            public string LabelWidthStyle
            {
                get { return labelWidthStyle; }
                set { labelWidthStyle = value; }
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
                set 
                { 
                    left = value;

                    // set the value for leftStyle
                    leftStyle = left + Unit;
                }
            }
            #endregion
            
            #region LeftStyle
            /// <summary>
            /// This property gets or sets the value for 'LeftStyle'.
            /// </summary>
            public string LeftStyle
            {
                get { return leftStyle; }
                set { leftStyle = value; }
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
                set { text = value; }
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
            
            #region Top
            /// <summary>
            /// This property gets or sets the value for 'Top'.
            /// </summary>
            [Parameter]
            public double Top
            {
                get { return top; }
                set 
                { 
                    // set the value for top
                    top = value;

                    // set the value for topStyle
                    TopStyle = top + HeightUnit;
                }
            }
            #endregion

            #region TopStyle
            /// <summary>
            /// This property gets or sets the value for 'TopStyle'.
            /// </summary>
            public string TopStyle
            {
                get { return topStyle; }
                set { topStyle = value; }
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
                set 
                {
                    // set the unit
                    unit = value;

                    // if the unit is percent, % doesn't work for height.
                    if (unit == "%")
                    {
                        // Set to vh
                        HeightUnit = "vh";
                    }
                }
            }
            #endregion
            
            #region ValidationControlStyle
            /// <summary>
            /// This property gets or sets the value for 'ValidationControlStyle'.
            /// </summary>
            public string ValidationControlStyle
            {
                get { return validationControlStyle; }
                set { validationControlStyle = value; }
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
            
        #endregion

    }
    #endregion

}
