

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components;
using DataJuggler.UltimateHelper;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class ValidationComponent
    /// <summary>
    /// The validation component is just a way to display a valid or not valid to make the UI
    /// appear different.
    /// </summary>
    public partial class ValidationComponent : IBlazorComponent
    {
        
        #region Private Variables
        private string labelColor;
        private string textBoxBackColor;
        private string labelStyle;
        private string textBoxStyle;
        private bool isValid;
        private string caption;
        private string text;
        private string name;
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
        private string fontSizeUnit;
        private double width;
        private string widthPercent;
        private double textBoxWidth;
        private string textBoxWidthPercent;
        private IBlazorComponentParent parent;        
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

        #region Methods

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
                FontSizeUnit = "vh";
                FontSize = 2.4;
                Width = 80;
                TextBoxWidth = 30;
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

                    // set the style value
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
                    fontSize = value;

                    fontSizeStyle = fontSize.ToString() + fontSizeUnit;
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

                    if (this.Name == "UserNameComponent")
                    {
                        // breakpoint only
                        isValid = value;
                    }

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
            /// </summary>
            [Parameter]
            public bool Multiline
            {
                get { return multiline; }
                set { multiline = value; }
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

            #region TextBoxWidth
            /// <summary>
            /// This property gets or sets the value for 'TextBoxWidth'.
            /// </summary>
            [Parameter]
            public double TextBoxWidth
            {
                get { return textBoxWidth; }
                set 
                {
                    // set the value
                    textBoxWidth = value;

                    // set the value
                    TextBoxWidthPercent = textBoxWidth + "%";
                }
            }
            #endregion
            
            #region TextBoxWidthPercent
            /// <summary>
            /// This property gets or sets the value for 'TextBoxWidthPercent'.
            /// </summary>
            public string TextBoxWidthPercent
            {
                get { return textBoxWidthPercent; }
                set { textBoxWidthPercent = value; }
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
            
            #region Width
            /// <summary>
            /// This property gets or sets the value for 'Width'.
            /// </summary>
            [Parameter]
            public double Width
            {
                get { return width; }
                set 
                { 
                    width = value;

                    // set the value for widthPercent
                    widthPercent = width + "%";
                }
            }
            #endregion
            
            #region WidthPercent
            /// <summary>
            /// This property gets or sets the value for 'WidthPercent'.
            /// </summary>
            public string WidthPercent
            {
                get { return widthPercent; }
                set { widthPercent = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
