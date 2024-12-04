

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;
using System;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class Label : IBlazorComponent
    /// <summary>
    /// The label provides a way to display Text.
    /// </summary>
    public partial class Label : IBlazorComponent
    {
        
        #region Private Variables
        private string labelColor;
        private string labelClassName;        
        private string imageClassName;
        private string labelBackgroundColor;        
        private string labelStyle;        
        private string caption;
        private string text;
        private string textAlign;
        private string imageUrl;
        private bool showImage;
        private string imageStyle;
        private double imageScale;
        private double fontSize;
        private double height;
        private double width;
        private string name;
        private double left;
        private double top;                
        private double labelWidth;
        private double labelFontSize;        
        private string labelFontSizeUnit;        
        private int zIndex;
        private string position;
        private IBlazorComponentParent parent;
        private string className;        
        private bool showCaption;
        private string unit;
        private string heightUnit;        
        private bool visible;
        private string display;        
        private double labelTop;
        private string fontSizeUnit;
        private string backgroundColor;
        private double imageWidth;
        private string imageBackColor;
        private double marginLeft;        
        private double marginBottom;        
        private string labelControlStyle;
        private string bottomMarginStyle;
        private bool enableClick;
        private double fadeValue;
        private bool enableDoubleClick;
        private bool notifyParentOnDoubleClick;
        private bool notifyParentOnClick;
        private bool enableEnterEditMode;
        private bool editMode;
        private int id;
        private string description;
        private string textBoxClassName;        
        private bool autoComplete;
        private ElementReference innerControl;
        private bool sendAllTextToParent;        
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a TextBoxComponent object
        /// </summary>
        public Label()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events
            
            #region OnClick()
            /// <summary>
            /// On Double Click
            /// </summary>
            public void OnClick()
            {
                // If the name string exists
                if ((HasParent) && (NotifyParentOnClick))
                {
                    // Create a message
                    Message message = new Message();

                    // Notify the Parent
                    message.Text = "A label was was clicked with Name '" + name + "' and Id " + Id + " - " + Description + ".";
                    message.Id = Id;
                    message.Sender = this;

                    // Notify the parent
                    Parent.ReceiveData(message);
                }
                
                // Update the page in EditMode
                Refresh();
            }
            #endregion
            
            #region OnDoubleClick()
            /// <summary>
            /// On Double Click
            /// </summary>
            public void OnDoubleClick()
            {  
                // if NotifyParent is true
                if ((NotifyParentOnDoubleClick) && (HasParent))
                {
                    // Create a message
                    Message message = new Message();

                    // Set the parent
                    message.Text = "A label was was double clicked with Name '" + name + "' and Id " + Id + " - " + Description + ".";
                    message.Sender = this;

                    // Notify the parent
                    Parent.ReceiveData(message);
                }                    
                
                if (EnableEnterEditMode)
                {
                    // EditMode is Now true
                    EditMode = true;
                }

                // Update the page in EditMode
                Refresh();
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
                    // Inform the Parent
                    SendMessageToParent("EnterPressed");     

                    // Exit EditMode
                    EditMode = false;
                }
                else if (e.Code == "Escape")
                {
                    // Inform the Parent Escape was hit
                    SendMessageToParent("EscapePressed");      

                    // Exit EditMode
                    EditMode = false;
                }
                
                // if SendAllTextToParent
                if (SendAllTextToParent)
                {
                    // Send to the parent
                    SendMessageToParent("text: " + e.Code);
                }

                // Exit EditMode (possibly)
                Refresh();
            }
            #endregion
    
            #region FadeVisibilityAsync(bool visible)
            /// <summary>
            /// method returns the Visibility Async
            /// </summary>
            public async Task FadeVisibilityAsync(bool visible)
            {
                // This is an asynchronous delay
                await Task.Delay((int) FadeValue);
                
                // Set the value
                Visible = visible;
                
                Refresh();
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Set Default Values                
                Caption = "";
                BackgroundColor = "transparent";
                Display = "inline-block";                
                LabelColor = "Black";
                ImageScale = 1.6;
                FadeValue = 0;
                FontSize = 12;
                FontSizeUnit="px";
                Height= 24;
                HeightUnit = "px";
                ImageBackColor = "transparent";
                ImageWidth = 10;                
                LabelBackgroundColor = "transparent";
                LabelColor="Black";
                LabelWidth= 30;
                LabelFontSize = 12;
                LabelFontSizeUnit = "px";
                Left = 0;
                MarginLeft = 1.2;
                MarginBottom = 8;
                Position = "relative";                
                Text = "";                
                Top = 0;                
                Unit = "px";
                Visible = true;
                Width= 30;                
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                
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

                    message.Id = Id;
                    
                    // Set the Sender
                    message.Sender = this;

                    // Create a new instance of a 'NamedParameter' object.
                    NamedParameter parameter = new NamedParameter();

                    // Set the name of the object calling
                    parameter.Name = this.Name;

                    // Set the value
                    parameter.Value = Text;

                    // Add this parameter
                    message.Parameters.Add(parameter);

                    // notify the parent
                    Parent.ReceiveData(message);                  
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
                Text = text;
            }
            #endregion
            
            #region SetVisibility(bool visibleValue)
            /// <summary>
            /// Set Visibility
            /// </summary>
            public void SetVisibility(bool visibleValue)
            {
                // Change the value
                Visible = visibleValue;
            }
            #endregion
            
        #endregion

        #region Properties

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
            
            #region Description
            /// <summary>
            /// This property gets or sets the value for 'Description'.
            /// </summary>
            [Parameter]
            public string Description
            {
                get { return description; }
                set { description = value; }
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
            
            #region EnableDoubleClick
            /// <summary>
            /// This property gets or sets the value for 'EnableDoubleClick'.
            /// </summary>
            [Parameter]
            public bool EnableDoubleClick
            {
                get { return enableDoubleClick; }
                set { enableDoubleClick = value; }
            }
            #endregion
            
            #region EnableEnterEditMode
            /// <summary>
            /// This property gets or sets the value for 'EnableEnterEditMode'.
            /// </summary>
            [Parameter]
            public bool EnableEnterEditMode
            {
                get { return enableEnterEditMode; }
                set { enableEnterEditMode = value; }
            }
            #endregion
            
            #region FadeValue
            /// <summary>
            /// This property gets or sets the value for 'FadeValue'.
            /// </summary>
            [Parameter]
            public double FadeValue
            {
                get { return fadeValue; }
                set { fadeValue = value; }
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
                set {fontSize = value; }
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
            
            #region Id
            /// <summary>
            /// This property gets or sets the value for 'Id'.
            /// </summary>
            [Parameter]
            public int Id
            {
                get { return id; }
                set { id = value; }
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
            
            #region LabelControlStyle
            /// <summary>
            /// This property gets or sets the value for 'LabelControlStyle'.
            /// </summary>
            public string LabelControlStyle
            {
                get { return labelControlStyle; }
                set { labelControlStyle = value; }
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
                    string labelFontSizeStyle = LabelFontSize + LabelFontSizeUnit;

                    // return value
                    return labelFontSizeStyle;
                }
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
            
            #region NotifyParentOnClick
            /// <summary>
            /// This property gets or sets the value for 'NotifyParentOnClick'.
            /// </summary>
            [Parameter]
            public bool NotifyParentOnClick
            {
                get { return notifyParentOnClick; }
                set { notifyParentOnClick = value; }
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
            
            #region OpacityStyle
            /// <summary>
            /// This read only property returns the value of OpacityStyle from the object Visible.
            /// </summary>
            public string OpacityStyle
            {
                
                get
                {
                    // initial value
                    string opacityStyle = "1";
                    
                    // if the value for Visible is false
                    if (!Visible)
                    {
                        // set the return value
                        opacityStyle = "0";
                    }
                    
                    // return value
                    return opacityStyle;
                }
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
            
            #region TextAlign
            /// <summary>
            /// This property gets or sets the value for 'TextAlign'.
            /// </summary>
            [Parameter]
            public string TextAlign
            {
                get { return textAlign; }
                set { textAlign = value; }
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
            
            #region TransitionStyle
            /// <summary>
            /// This read only property returns the value of TransitionStyle from the object Visible.
            /// </summary>
            public string TransitionStyle
            {
                
                get
                {
                    // initial value
                    string transitionStyle = "visibility 0s " + FadeValue + "s, opacity " + FadeValue + "s linear;"; 
                    
                    // if the value for Visible is false
                    if (!Visible)
                    {
                        // set the return value
                        transitionStyle = "none";
                    }
                    
                    // return value
                    return transitionStyle;
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
                set {unit = value;}
            }
            #endregion
            
            #region VisibilityStyle
            /// <summary>
            /// This read only property returns the value of VisibilityStyle from the object Visible.
            /// </summary>
            public string VisibilityStyle
            {
                
                get
                {
                    // initial value
                    string visibilityStyle = "visible";
                    
                    // if the value for Visible is false
                    if (!Visible)
                    {
                        // set the return value
                        visibilityStyle = "hidden";
                    }
                    
                    // return value
                    return visibilityStyle;
                }
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
