

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using Microsoft.AspNetCore.Components;
using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.Blazor.Components.Delegates;
using System.Drawing;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class SaveCancelComponent
    /// <summary>
    /// This class is used to Save a Data Entry screen or Cancel and notify the parent
    /// </summary>
    public partial class SaveCancelComponent : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private string unit;
        private string heightUnit;
        private double buttonHeight;
        private string buttonImageUrl;
        private ButtonThemeEnum buttonTheme;
        private string cancelButtonImageUrl;
        private string cancelbuttonStyle;
        private string cancelButtonText;
        private Color cancelButtonTextColor;
        private double cancelButtonWidth;
        private string controlStyle;
        private double height;
        private double left;
        private string name;
        private OnCancelled onCancelledCallback;
        private OnSaved onSavedCallback;
        private IBlazorComponentParent parent;
        private string position;
        private SaveCancelResultEnum result;
        private string saveButtonImageUrl;
        private string saveButtonStyle;
        private string saveButtonText;
        private Color saveButtonTextColor;
        private double saveButtonWidth;
        private Color textColor;
        private double top;
        private double width;
        private double borderWidth;
        private Color borderColor;
        private double buttonBorderWidth;
        private Color buttonBorderColor;
        private double buttonBorderRadius;
        private Color backgroundColor;
        private string backgroundImageUrl;
        private double borderRadius;
        private string saveButtonClassName;
        private string cancelButtonClassName;
        private string cancelButtonStyle;
        private bool visible;
        private string display;
        private int zIndex;
        private double fontSize;
        private string fontName;
        private ImageButton cancelButton;
        private ImageButton saveButton;
        private double cancelButtonLeft;
        private double saveButtonleft;
        private double buttonTop;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SaveCancelComponent' object.
        /// </summary>
        public SaveCancelComponent()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region ButtonClicked(int buttonNumber, string buttonName)
            /// <summary>
            /// event is fired when Button Clicked
            /// </summary>
            public void ButtonClicked(int buttonNumber, string buttonName)
            {
                // if the Save button was clicked and the delegate exists
                if ((buttonNumber == 1) && (HasOnSavedCallback))
                {
                    // Notify the parent
                    OnSavedCallback(Name);
                }
                else if ((buttonNumber == 2) && (HasOnCancelledCallback))
                {
                    // Notify the parent
                    OnCancelledCallback(Name);
                }
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Set Default Values
                Unit = "px";
                HeightUnit = "px";
                Position = "relative";
                Height = 64;
                Width = 256;
                CancelButtonWidth = 64;
                SaveButtonWidth = 64;
                ButtonHeight = 32;
                BackgroundColor = Color.Transparent;
                BorderColor = Color.Transparent;
                ButtonBorderColor = Color.Transparent;
                ButtonBorderWidth = 0;
                ButtonTheme = ButtonThemeEnum.BlackButton;
                SaveButtonleft = -8;
                FontSize = 14;
                FontName = "Calibri";
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
                if (component is ImageButton tempImageButton)
                {
                    // store the ImageButton components
                    if (component.Name == "SaveButton")
                    {
                        SaveButton = tempImageButton;
                    }
                    else if (component.Name == "CancelButton")
                    {
                        CancelButton = tempImageButton;
                    }
                }
            }
            #endregion
            
            #region SetButtonTextColor(Color textColor)
            /// <summary>
            /// Set Button Text Color
            /// </summary>
            public void SetButtonTextColor(Color textColor)
            {
                // store
                TextColor = textColor;
            }
            #endregion
            
            #region SetCancelButtonTextColor(Color textColor)
            /// <summary>
            /// Set Cancel Button Text Color
            /// </summary>
            public void SetCancelButtonTextColor(Color textColor)
            {
                // store
                CancelButtonTextColor = textColor;
            }
            #endregion
            
            #region SetSaveButtonTextColor(Color textColor)
            /// <summary>
            /// Set Save Button Text Color
            /// </summary>
            public void SetSaveButtonTextColor(Color textColor)
            {
                // store
                SaveButtonTextColor = textColor;
            }
            #endregion
            
            #region SetupButtons(string imageUrl)
            /// <summary>
            /// This method will set the same image url for both the Cancel button and the Save button.
            /// </summary>
            public void SetupButtons(string imageUrl)
            {
                // Setup the button image url's
                SaveButtonImageUrl = imageUrl;
                CancelButtonImageUrl = imageUrl;
            }
            #endregion
            
            #region SetupButtons(string saveButtonImageUrl, string cancelButtonImageUrl)
            /// <summary>
            /// This method will set the same image url for both the Cancel button and the Save button.
            /// </summary>
            public void SetupButtons(string saveButtonImageUrl, string cancelButtonImageUrl)
            {
                // Setup the button image url's
                SaveButtonImageUrl = saveButtonImageUrl;
                CancelButtonImageUrl = cancelButtonImageUrl;
            }
            #endregion
            
            #region SetupButtons(ButtonThemeEnum theme)
            /// <summary>
            /// This method will set the same image url for both the Cancel button and the Save button.
            /// </summary>
            public void SetupButtons(ButtonThemeEnum theme)
            {
                // Determine the action by the theme
                switch (theme)
                {

                    case ButtonThemeEnum.BlackButton:

                        // Set Button Image URL's
                        CancelButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlackButton.jpg";
                        SaveButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlackButton.jpg";

                        // Change TextColor
                        TextColor = Color.White;

                        // Required
                        break;

                    case ButtonThemeEnum.BlackButtonWide:

                        // Set Button Image URL's
                        CancelButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlackButtonWide.jpg";
                        SaveButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlackButtonWide.jpg";

                        // Change TextColor
                        TextColor = Color.White;

                        // Required
                        break;

                     case ButtonThemeEnum.BlueButton:

                        // Set Button Image URL's
                        CancelButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlueButton.png";
                        SaveButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlueButton.png";

                         // Change TextColor
                        TextColor = Color.White;

                        // Required
                        break;

                    case ButtonThemeEnum.OrangeStone:

                        // Set Button Image URL's
                        CancelButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/OrangeStone.png";
                        SaveButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/OrangeStone.png";

                        // Change TextColor
                        TextColor = Color.Black;

                        // Required
                        break;

                    case ButtonThemeEnum.PurpleStone:

                        // Set Button Image URL's
                        CancelButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/PurpleStone.png";
                        SaveButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/PurpleStone.png";

                        // Change TextColor
                        TextColor = Color.White;

                        // Required
                        break;

                    case ButtonThemeEnum.RedGlass:

                        // Set Button Image URL's
                        CancelButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/RedGlass.png";
                        SaveButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/RedGlass.png";

                        // Change TextColor
                        TextColor = Color.White;

                        // Required
                        break;

                    case ButtonThemeEnum.TanButton:

                        // Set Button Image URL's
                        CancelButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/TanStone.png";
                        SaveButtonImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/TanStone.png";

                        // Change TextColor
                        TextColor = Color.Black;

                        // Required
                        break;
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region BackgroundColor
            /// <summary>
            /// This property gets or sets the value for 'BackgroundColor'.
            /// </summary>
            [Parameter]
            public Color BackgroundColor
            {
                get { return backgroundColor; }
                set { backgroundColor = value; }
            }
            #endregion
            
            #region BackgroundImageUrl
            /// <summary>
            /// This property gets or sets the value for 'BackgroundImageUrl'.
            /// </summary>
            [Parameter]
            public string BackgroundImageUrl
            {
                get { return backgroundImageUrl; }
                set { backgroundImageUrl = value; }
            }
            #endregion
            
            #region BorderColor
            /// <summary>
            /// This property gets or sets the value for 'BorderColor'.
            /// </summary>
            [Parameter]
            public Color BorderColor
            {
                get { return borderColor; }
                set { borderColor = value; }
            }
            #endregion
            
            #region BorderRadius
            /// <summary>
            /// This property gets or sets the value for 'BorderRadius'.
            /// </summary>
            [Parameter]
            public double BorderRadius
            {
                get { return borderRadius; }
                set { borderRadius = value; }
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
            
            #region ButtonBorderColor
            /// <summary>
            /// This property gets or sets the value for 'ButtonBorderColor'.
            /// </summary>
            [Parameter]
            public Color ButtonBorderColor
            {
                get { return buttonBorderColor; }
                set { buttonBorderColor = value; }
            }
            #endregion
            
            #region ButtonBorderRadius
            /// <summary>
            /// This property gets or sets the value for 'ButtonBorderRadius'.
            /// </summary>
            [Parameter]
            public double ButtonBorderRadius
            {
                get { return buttonBorderRadius; }
                set { buttonBorderRadius = value; }
            }
            #endregion
            
            #region ButtonBorderWidth
            /// <summary>
            /// This property gets or sets the value for 'ButtonBorderWidth'.
            /// </summary>
            [Parameter]
            public double ButtonBorderWidth
            {
                get { return buttonBorderWidth; }
                set { buttonBorderWidth = value; }
            }
            #endregion
            
            #region ButtonHeight
            /// <summary>
            /// This property gets or sets the value for 'ButtonHeight'.
            /// </summary>
            [Parameter]
            public double ButtonHeight
            {
                get { return buttonHeight; }
                set { buttonHeight = value; }
            }
            #endregion
            
            #region ButtonImageUrl
            /// <summary>
            /// This property gets or sets the value for 'ButtonImageUrl'.
            /// </summary>
            [Parameter]
            public string ButtonImageUrl
            {
                get { return buttonImageUrl; }
                set
                {
                    // set the value
                    buttonImageUrl = value;

                    // Set both buttons
                    CancelButtonImageUrl = value;
                    SaveButtonImageUrl = value;
                }
            }
            #endregion
            
            #region ButtonTheme
            /// <summary>
            /// This property gets or sets the value for 'ButtonTheme'.
            /// </summary>
            [Parameter]
            public ButtonThemeEnum ButtonTheme
            {
                get { return buttonTheme; }
                set
                {
                    // set the value
                    buttonTheme = value;

                    // Setup the Button Themes
                    SetupButtons(value);
                }
            }
            #endregion
            
            #region ButtonTop
            /// <summary>
            /// This property gets or sets the value for 'ButtonTop'.
            /// </summary>
            [Parameter]
            public double ButtonTop
            {
                get { return buttonTop; }
                set { buttonTop = value; }
            }
            #endregion
            
            #region CancelButton
            /// <summary>
            /// This property gets or sets the value for 'CancelButton'.
            /// </summary>
            public ImageButton CancelButton
            {
                get { return cancelButton; }
                set { cancelButton = value; }
            }
            #endregion
            
            #region CancelButtonClassName
            /// <summary>
            /// This property gets or sets the value for 'CancelButtonClassName'.
            /// </summary>
            [Parameter]
            public string CancelButtonClassName
            {
                get { return cancelButtonClassName; }
                set { cancelButtonClassName = value; }
            }
            #endregion
            
            #region CancelButtonImageUrl
            /// <summary>
            /// This property gets or sets the value for 'CancelButtonImageUrl'.
            /// </summary>
            [Parameter]
            public string CancelButtonImageUrl
            {
                get { return cancelButtonImageUrl; }
                set { cancelButtonImageUrl = value; }
            }
            #endregion
            
            #region CancelButtonLeft
            /// <summary>
            /// This property gets or sets the value for 'CancelButtonLeft'.
            /// </summary>
            [Parameter]
            public double CancelButtonLeft
            {
                get { return cancelButtonLeft; }
                set { cancelButtonLeft = value; }
            }
            #endregion
            
            #region CancelbuttonStyle
            /// <summary>
            /// This property gets or sets the value for 'CancelbuttonStyle'.
            /// </summary>
            public string CancelbuttonStyle
            {
                get { return cancelbuttonStyle; }
                set { cancelbuttonStyle = value; }
            }
            #endregion
            
            #region CancelButtonText
            /// <summary>
            /// This property gets or sets the value for 'CancelButtonText'.
            /// </summary>
            [Parameter]
            public string CancelButtonText
            {
                get { return cancelButtonText; }
                set { cancelButtonText = value; }
            }
            #endregion
            
            #region CancelButtonTextColor
            /// <summary>
            /// This property gets or sets the value for 'CancelButtonTextColor'.
            /// </summary>
            [Parameter]
            public Color CancelButtonTextColor
            {
                get { return cancelButtonTextColor; }
                set { cancelButtonTextColor = value; }
            }
            #endregion
            
            #region CancelButtonWidth
            /// <summary>
            /// This property gets or sets the value for 'CancelButtonWidth'.
            /// </summary>
            [Parameter]
            public double CancelButtonWidth
            {
                get { return cancelButtonWidth; }
                set { cancelButtonWidth = value; }
            }
            #endregion
            
            #region ControlStyle
            /// <summary>
            /// This property gets or sets the value for 'ControlStyle'.
            /// </summary>
            public string ControlStyle
            {
                get { return controlStyle; }
                set { controlStyle = value; }
            }
            #endregion
            
            #region Display
            /// <summary>
            /// This property gets or sets the value for 'Display'.
            /// </summary>
            public string Display
            {
                get { return display; }
                set { display = value; }
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
            
            #region HasCancelButton
            /// <summary>
            /// This property returns true if this object has a 'CancelButton'.
            /// </summary>
            public bool HasCancelButton
            {
                get
                {
                    // initial value
                    bool hasCancelButton = (CancelButton != null);

                    // return value
                    return hasCancelButton;
                }
            }
            #endregion
            
            #region HasOnCancelledCallback
            /// <summary>
            /// This property returns true if this object has an 'OnCancelledCallback'.
            /// </summary>
            public bool HasOnCancelledCallback
            {
                get
                {
                    // initial value
                    bool hasOnCancelledCallback = (OnCancelledCallback != null);

                    // return value
                    return hasOnCancelledCallback;
                }
            }
            #endregion
            
            #region HasOnSavedCallback
            /// <summary>
            /// This property returns true if this object has an 'OnSavedCallback'.
            /// </summary>
            public bool HasOnSavedCallback
            {
                get
                {
                    // initial value
                    bool hasOnSavedCallback = (OnSavedCallback != null);

                    // return value
                    return hasOnSavedCallback;
                }
            }
            #endregion
            
            #region HasSaveButton
            /// <summary>
            /// This property returns true if this object has a 'SaveButton'.
            /// </summary>
            public bool HasSaveButton
            {
                get
                {
                    // initial value
                    bool hasSaveButton = (SaveButton != null);

                    // return value
                    return hasSaveButton;
                }
            }
            #endregion
            
            #region Height
            /// <summary>
            /// This property gets or sets the value for 'Height'.
            /// This is the Height for this entire control.
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
            /// This read only property returns the value of Left + Unit
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
            
            #region OnCancelledCallback
            /// <summary>
            /// This property gets or sets the value for 'OnCancelledCallback'.
            /// </summary>
            [Parameter]
            public OnCancelled OnCancelledCallback
            {
                get { return onCancelledCallback; }
                set { onCancelledCallback = value; }
            }
            #endregion
            
            #region OnSavedCallback
            /// <summary>
            /// This property gets or sets the value for 'OnSavedCallback'.
            /// </summary>
            [Parameter]
            public OnSaved OnSavedCallback
            {
                get { return onSavedCallback; }
                set { onSavedCallback = value; }
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
            
            #region Result
            /// <summary>
            /// This property gets or sets the value for 'Result'.
            /// </summary>
            public SaveCancelResultEnum Result
            {
                get { return result; }
                set { result = value; }
            }
            #endregion
            
            #region SaveButton
            /// <summary>
            /// This property gets or sets the value for 'SaveButton'.
            /// </summary>
            public ImageButton SaveButton
            {
                get { return saveButton; }
                set { saveButton = value; }
            }
            #endregion
            
            #region SaveButtonClassName
            /// <summary>
            /// This property gets or sets the value for 'SaveButtonClassName'.
            /// </summary>
            [Parameter]
            public string SaveButtonClassName
            {
                get { return saveButtonClassName; }
                set { saveButtonClassName = value; }
            }
            #endregion
            
            #region SaveButtonImageUrl
            /// <summary>
            /// This property gets or sets the value for 'SaveButtonImageUrl'.
            /// </summary>
            [Parameter]
            public string SaveButtonImageUrl
            {
                get { return saveButtonImageUrl; }
                set { saveButtonImageUrl = value; }
            }
            #endregion
            
            #region SaveButtonleft
            /// <summary>
            /// This property gets or sets the value for 'SaveButtonleft'.
            /// </summary>
            [Parameter]
            public double SaveButtonleft
            {
                get { return saveButtonleft; }
                set { saveButtonleft = value; }
            }
            #endregion
            
            #region SaveButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'SaveButtonStyle'.
            /// </summary>
            public string SaveButtonStyle
            {
                get { return saveButtonStyle; }
                set { saveButtonStyle = value; }
            }
            #endregion
            
            #region SaveButtonText
            /// <summary>
            /// This property gets or sets the value for 'SaveButtonText'.
            /// </summary>
            [Parameter]
            public string SaveButtonText
            {
                get { return saveButtonText; }
                set { saveButtonText = value; }
            }
            #endregion
            
            #region SaveButtonTextColor
            /// <summary>
            /// This property gets or sets the value for 'SaveButtonTextColor'.
            /// </summary>
            [Parameter]
            public Color SaveButtonTextColor
            {
                get { return saveButtonTextColor; }
                set { saveButtonTextColor = value; }
            }
            #endregion
            
            #region SaveButtonWidth
            /// <summary>
            /// This property gets or sets the value for 'SaveButtonWidth'.
            /// </summary>
            [Parameter]
            public double SaveButtonWidth
            {
                get { return saveButtonWidth; }
                set { saveButtonWidth = value; }
            }
            #endregion
            
            #region TextColor
            /// <summary>
            /// This property gets or sets the value for 'TextColor'.
            /// </summary>
            [Parameter]
            public Color TextColor
            {
                get { return textColor; }
                set
                {
                    // set the value
                    textColor = value;

                    // Set Both
                    CancelButtonTextColor = Color.White;
                    SaveButtonTextColor = Color.White;
                }
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
            /// This read only property returns the value of Top + Unit
            /// </summary>
            public string TopStyle
            {

                get
                {
                    // initial value
                    string topStyle = Top + HeightUnit;
                    
                    // return value
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
            
            #region Visible
            /// <summary>
            /// This property gets or sets the value for 'Visible'.
            /// </summary>
            [Parameter]
            public bool Visible
            {
                get { return visible; }
                set 
                {
                    // set the value
                    visible = value;

                    // if the value for visible is true
                    if (visible)
                    {
                        // Show
                        Display = "block";
                    }
                    else
                    {
                        // Hide
                        Display = "none";
                    }
                }
            }
            #endregion
            
            #region Width
            /// <summary>
            /// This property gets or sets the value for 'Width'.
            /// This is the Width for this component. Use CancelButtonWidth
            /// or SaveButtonWidth to set button widths.
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
