

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using System;
using System.Drawing;
using System.Net.NetworkInformation;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class ToggleComponent
    /// <summary>
    /// This class is used to display and edit an On / Off state.
    /// </summary>
    public partial class ToggleComponent : IBlazorComponent, ILabelFont
    {
        
        #region Private Variables
        private int borderWidth;
        private Color borderColor;
        private string display;
        private Color backgroundColor;                
        private double labelFontSize;
        private string labelPosition;
        private double labelLeft;
        private double labelTop;        
        private Color circleColor;
        private Color circleColorOn;
        private Color circleColorOff;
        private double height;
        private string imageUrl;
        private string name;
        private bool notifyParentOnChange;
        private IBlazorComponentParent parent;
        private double width;
        private string unit;
        private string heightUnit;
        private string componentStyle;
        private string buttonStyle;
        private bool on;
        private bool previousOn;
        private int zIndex;
        
        // Circle
        private double circleLeftOn;
        private double circleLeftOff;
        private double circleLeft;
        private double circleTop;
        private double circleHeight;
        private double circleWidth;
        private string column1Style;
        private bool showCaption;
        private double scale;
        private string containerStyle;
        private string position;
        private double top;
        private double left;
        
        // Oval and Oval Ends
        private double ovalEndWidth;
        private double ovalWidth;
        private double ovalRadius;
        private string ovalPosition;
        private double ovalLeft;
        private double ovalTop;
        private string ovalStyle;
        private Color ovalBackgroundColor;
        private Color ovalBackgroundColorOff;
        private Color ovalBackgroundColorOn;
        private string ovalLeftButtonStyle;
        private string ovalMiddleButtonStyle;
        private string ovalRightButtonStyle;

        // Label
        private double column1Width;
        private string caption;
        private string labelClassName;
        private string labelBackgroundColor;
        private string labelColor;
        private string labelFontSizeUnit;
        private string labelFontName;
        private string labelStyle;
        private bool visible;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ToggleComponent' object.
        /// </summary>
        public ToggleComponent()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {  
                // Defaults - adjust as needed
                BackgroundColor = Color.Transparent;
                BorderColor = Color.Transparent;
                BorderWidth = 0;
                Visible = true;
                Display = "inline-block";
                position = "relative";
                Height = 24;
                Width = 160;
                CircleHeight = 12;
                CircleWidth = 12;                
                ZIndex = 20;
                On = true;
                Unit = "px";
                HeightUnit = "px";

                // The end of the oval have their own width
                OvalEndWidth = 16;
                OvalWidth = 16;
                OvalRadius = 50;
                OvalPosition = "relative";
                OvalLeft = 35;
                OvalTop = 32;
                OvalBackgroundColorOn = Color.CornflowerBlue;
                OvalBackgroundColorOff = Color.Gray;
                
                // Default On or Off positions
                CircleColorOn = Color.Empty;
                CircleColorOff = Color.Empty;
                CircleColor = Color.GhostWhite;
                CircleLeftOff = -35;
                CircleLeftOn = -14;
                CircleTop = 2;
                
                // Label
                LabelPosition = "relative";
                Column1Width = GlobalDefaults.Column1Width;
                LabelFontSize = GlobalDefaults.LabelFontSize;
                LabelFontName = GlobalDefaults.LabelFontName;
                LabelFontSizeUnit = "px";
                LabelLeft = 0;
                LabelTop = 10;
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                
            }
            #endregion
            
            #region SetOnValue(bool onValue)
            /// <summary>
            /// Set On Value
            /// </summary>
            public void SetOnValue(bool onValue)
            {
                // Set the Value of On
                On = onValue;
            }
            #endregion
            
            #region Toggle()
            /// <summary>
            /// Toggle
            /// </summary>
            public void Toggle()
            {
                // Turn on if off or off if on
                On = !On;
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
            
            #region ButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'ButtonStyle'.
            /// </summary>
            public string ButtonStyle
            {
                get { return buttonStyle; }
                set { buttonStyle = value; }
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
                    // Set the value
                    caption = value;

                    // Show the Caption, if the Caption is set.
                    ShowCaption = TextHelper.Exists(caption);
                }
            }
            #endregion
            
            #region CircleColor
            /// <summary>
            /// This property gets or sets the value for 'CircleColor'.
            /// </summary>
            [Parameter]
            public Color CircleColor
            {
                get 
                {
                    // initial value
                    Color tempCircleColor = circleColor;

                    // if this component is currently On
                    if (On)
                    {
                        // if Set
                        if (CircleColorOn != Color.Empty)
                        {
                        
                            // Use the On Color
                            tempCircleColor = CircleColorOn;
                        }                        
                    }
                    else
                    {
                        // if Off Color is set
                        if (CircleColorOff != Color.Empty)
                        {
                            // Use the Off Color
                            tempCircleColor = CircleColorOff;
                        }
                    }

                    // return tempCircleColor
                    return tempCircleColor;
                }
                set { circleColor = value; }
            }
            #endregion
            
            #region CircleColorOff
            /// <summary>
            /// This property gets or sets the value for 'CircleColorOff'.
            /// </summary>
            [Parameter]
            public Color CircleColorOff
            {
                get { return circleColorOff; }
                set { circleColorOff = value; }
            }
            #endregion
            
            #region CircleColorOn
            /// <summary>
            /// This property gets or sets the value for 'CircleColorOn'.
            /// </summary>
            [Parameter]
            public Color CircleColorOn
            {
                get { return circleColorOn; }
                set { circleColorOn = value; }
            }
            #endregion
            
            #region CircleHeight
            /// <summary>
            /// This property gets or sets the value for 'CircleHeight'.
            /// </summary>
            [Parameter]
            public double CircleHeight
            {
                get { return circleHeight; }
                set { circleHeight = value; }
            }
            #endregion
            
            #region CircleHeightStyle
            /// <summary>
            /// This read only property returns the value of CircleHeightStyle from the object CircleHeight.
            /// </summary>
            public string CircleHeightStyle
            {
                
                get
                {
                    // initial value
                    string circleHeightStyle = CircleHeight + HeightUnit;
                    
                    // return value
                    return circleHeightStyle;
                }
            }
            #endregion
            
            #region CircleLeft
            /// <summary>
            /// This read only property returns the left based upon if this component is On or Off.
            /// </summary>
            public double CircleLeft
            {
                get
                {
                    // if On
                    if (On)
                    {
                        // Use the On value
                        circleLeft = circleLeftOn;
                    }
                    else
                    {
                        // Use the Off value
                        circleLeft = circleLeftOff;
                    }

                    // return the value
                    return circleLeft;
                }
            }
            #endregion
            
            #region CircleLeftOff
            /// <summary>
            /// This property gets or sets the value for 'CircleLeftOff'.
            /// </summary>
            [Parameter]
            public double CircleLeftOff
            {
                get { return circleLeftOff; }
                set { circleLeftOff = value; }
            }
            #endregion
            
            #region CircleLeftOn
            /// <summary>
            /// This property gets or sets the value for 'CircleLeftOn'.
            /// </summary>
            [Parameter]
            public double CircleLeftOn
            {
                get { return circleLeftOn; }
                set { circleLeftOn = value; }
            }
            #endregion
            
            #region CircleLeftStyle
            /// <summary>
            /// This read only property returns the value of CircleLeft plus Unit.
            /// </summary>
            public string CircleLeftStyle
            {
                
                get
                {
                    // initial value
                    string circleLeftStyle = CircleLeft + Unit;
                    
                    // return value
                    return circleLeftStyle;
                }
            }
            #endregion
            
            #region CircleTop
            /// <summary>
            /// This property gets or sets the value for 'CircleTop'.
            /// </summary>
            [Parameter]
            public double CircleTop
            {
                get { return circleTop; }
                set { circleTop = value; }
            }
            #endregion
            
            #region CircleWidth
            /// <summary>
            /// This property gets or sets the value for 'CircleWidth'.
            /// </summary>
            [Parameter]
            public double CircleWidth
            {
                get { return circleWidth; }
                set { circleWidth = value; }
            }
            #endregion
            
            #region CircleWidthStyle
            /// <summary>
            /// This read only property returns the value of CircleWidth plus Unit
            /// </summary>
            public string CircleWidthStyle
            {
                
                get
                {
                    // initial value
                    string circleWidthStyle = CircleWidth + Unit;
                    
                    // return value
                    return circleWidthStyle;
                }
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
            
            #region ComponentStyle
            /// <summary>
            /// This property gets or sets the value for 'ComponentStyle'.
            /// </summary>
            public string ComponentStyle
            {
                get { return componentStyle; }
                set { componentStyle = value; }
            }
            #endregion
            
            #region ContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'ContainerStyle'.
            /// </summary>
            public string ContainerStyle
            {
                get { return containerStyle; }
                set { containerStyle = value; }
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
                set { height = value; }
            }
            #endregion
            
            #region HeightStyle
            /// <summary>
            /// This read only property returns the value of HeightStyle from the object Height.
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
            
            #region LabelPosition
            /// <summary>
            /// This property gets or sets the value for 'LabelPosition'.
            /// </summary>
            [Parameter]
            public string LabelPosition
            {
                get { return labelPosition; }
                set { labelPosition = value; }
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
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            [Parameter]
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region NotifyParentOnChange
            /// <summary>
            /// This property gets or sets the value for 'NotifyParentOnChange'.
            /// </summary>
            [Parameter]
            public bool NotifyParentOnChange
            {
                get { return notifyParentOnChange; }
                set { notifyParentOnChange = value; }
            }
            #endregion
            
            #region On
            /// <summary>
            /// This property gets or sets the value for 'On'.
            /// </summary>
            [Parameter]
            public bool On
            {
                get { return on; }
                set 
                {
                    on = value;

                    // If the value for the property HasParent is true and NotifyParentOnChange is true
                    // and the value of On changed
                    if ((HasParent && NotifyParentOnChange) && (previousOn != on))
                    {
                        // Create a new instance of a 'Message' object.
                        Message message = new Message();

                        // Set the Message Properties
                        message.Sender = this;
                        message.Text = "On value was changed to " + on;
                        message.CheckedValue = on;

                        // Send the parent a message
                        Parent.ReceiveData(message);
                    }

                    // Set the value for PreviousOn
                    PreviousOn = on;
                }
            }
            #endregion
            
            #region OvalBackgroundColor
            /// <summary>
            /// This property gets or sets the value for 'BackgroundColor'.
            /// </summary>            
            public Color OvalBackgroundColor
            {
                get
                {
                    // if On
                    if (On)
                    {
                        // Use the On color
                        ovalBackgroundColor = ovalBackgroundColorOn;
                    }
                    else
                    {
                        // Use the Off color
                        ovalBackgroundColor = ovalBackgroundColorOff;
                    }

                    // return value
                    return ovalBackgroundColor;
                }
            }
            #endregion
            
            #region OvalBackgroundColorOff
            /// <summary>
            /// This property gets or sets the value for 'OvalbackgroundColorOff'.
            /// </summary>
            [Parameter]
            public Color OvalBackgroundColorOff
            {
                get { return ovalBackgroundColorOff; }
                set { ovalBackgroundColorOff = value; }
            }
            #endregion
            
            #region OvalBackgroundColorOn
            /// <summary>
            /// This property gets or sets the value for 'OvalBackgroundColorOn'.
            /// </summary>
            [Parameter]
            public Color OvalBackgroundColorOn
            {
                get { return ovalBackgroundColorOn; }
                set { ovalBackgroundColorOn = value; }
            }
            #endregion
            
            #region OvalEndWidth
            /// <summary>
            /// This property gets or sets the value for 'OvalEndWidth'.
            /// </summary>
            [Parameter]
            public double OvalEndWidth
            {
                get { return ovalEndWidth; }
                set { ovalEndWidth = value; }
            }
            #endregion
            
            #region OvalEndWidthStyle
            /// <summary>
            /// This read only property returns the value of OvalEndWidth + Unit
            /// </summary>
            public string OvalEndWidthStyle
            {
                
                get
                {
                    // initial value
                    string ovalEndWidthStyle = OvalEndWidth + Unit;
                    
                    // return value
                    return ovalEndWidthStyle;
                }
            }
            #endregion
            
            #region OvalLeft
            /// <summary>
            /// This property gets or sets the value for 'OvalLeft'.
            /// </summary>
            [Parameter]
            public double OvalLeft
            {
                get { return ovalLeft; }
                set { ovalLeft = value; }
            }
            #endregion
            
            #region OvalLeftButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'OvalLeftButtonStyle'.
            /// </summary>
            public string OvalLeftButtonStyle
            {
                get { return ovalLeftButtonStyle; }
                set { ovalLeftButtonStyle = value; }
            }
            #endregion
            
            #region OvalLeftStyle
            /// <summary>
            /// This read only property returns the value of OvalLeftStyle from the object OvalLeft.
            /// </summary>
            public string OvalLeftStyle
            {
                
                get
                {
                    // initial value
                    string ovalLeftStyle = OvalLeft + Unit;
                    
                    // return value
                    return ovalLeftStyle;
                }
            }
            #endregion
            
            #region OvalMiddleButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'OvalMiddleButtonStyle'.
            /// </summary>
            public string OvalMiddleButtonStyle
            {
                get { return ovalMiddleButtonStyle; }
                set { ovalMiddleButtonStyle = value; }
            }
            #endregion

            #region OvalPosition
            /// <summary>
            /// This property gets or sets the value for 'OvalPosition'.
            /// </summary>
            [Parameter]
            public string OvalPosition
            {
                get { return ovalPosition; }
                set { ovalPosition = value; }
            }
            #endregion
            
            #region OvalRadius
            /// <summary>
            /// This property gets or sets the value for 'OvalRadius'.
            /// This value must be between 0 and 100.
            /// </summary>
            [Parameter]
            public double OvalRadius
            {
                get { return ovalRadius; }
                set { ovalRadius = value; }
            }
            #endregion
            
            #region OvalRadiusStyle
            /// <summary>
            /// This read only property returns the value of OvalRadius + "%"
            /// </summary>
            public string OvalRadiusStyle
            {
                
                get
                {
                    // initial value
                    string ovalRadiusStyle = OvalRadius + "%";
                    
                    // return value
                    return ovalRadiusStyle;
                }
            }
            #endregion
            
            #region OvalRightButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'OvalRightButtonStyle'.
            /// </summary>
            public string OvalRightButtonStyle
            {
                get { return ovalRightButtonStyle; }
                set { ovalRightButtonStyle = value; }
            }
            #endregion
            
            #region OvalStyle
            /// <summary>
            /// This property gets or sets the value for 'OvalStyle'.
            /// </summary>
            public string OvalStyle
            {
                get { return ovalStyle; }
                set { ovalStyle = value; }
            }
            #endregion
            
            #region OvalTop
            /// <summary>
            /// This property gets or sets the value for 'OvalTop'.
            /// </summary>
            [Parameter]
            public double OvalTop
            {
                get { return ovalTop; }
                set { ovalTop = value; }
            }
            #endregion
            
            #region OvalTopStyle
            /// <summary>
            /// This read only property returns the value of OvalTop + HeightUnit
            /// </summary>
            public string OvalTopStyle
            {
                
                get
                {
                    // initial value
                    string ovalTopStyle = OvalTop + HeightUnit;
                    
                    // return value
                    return ovalTopStyle;
                }
            }
            #endregion
            
            #region OvalWidth
            /// <summary>
            /// This property gets or sets the value for 'OvalWidth'.
            /// </summary>
            [Parameter]
            public double OvalWidth
            {
                get { return ovalWidth; }
                set 
                {
                    // set the value
                    ovalWidth = value;

                    // if > 24
                    if (ovalWidth > 24)
                    {
                        CircleLeftOff = -ovalWidth - 22;
                    }
                    else
                    {
                        int adjustment = 24 - (int) ovalWidth;
                        CircleLeftOff = -ovalWidth - 22 - adjustment;
                    }
                }
            }
            #endregion
            
            #region OvalWidthStyle
            /// <summary>
            /// This read only property returns the value of OvalWidthStyle from the object OvalWidth.
            /// </summary>
            public string OvalWidthStyle
            {
                
                get
                {
                    // initial value
                    string ovalWidthStyle = OvalWidth + Unit;
                    
                    // return value
                    return ovalWidthStyle;
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
                        // Register this component with the parent
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
            
            #region PreviousOn
            /// <summary>
            /// This property gets or sets the value for 'PreviousOn'.
            /// </summary>
            public bool PreviousOn
            {
                get { return previousOn; }
                set { previousOn = value; }
            }
            #endregion
            
            #region Scale
            /// <summary>
            /// This property gets or sets the value for 'Scale'.
            /// </summary>
            [Parameter]
            public double Scale
            {
                get { return scale; }
                set { scale = value; }
            }
            #endregion

            #region ScaleValue
            /// <summary>
            /// This read only property returns the value of Scale times .01
            /// </summary>
            public double ScaleValue
            {
                
                get
                {
                    // initial value
                    double scaleValue = Scale * .01;

                    // Round to 2 digits just in case
                    scaleValue = Math.Round(scaleValue, 2);
                    
                    // return value
                    return scaleValue;
                }
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
            /// This read only property returns the value of Top + HeightUnit
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
                set { width = value; }
            }
            #endregion
            
            #region WidthStyle
            /// <summary>
            /// This read only property returns the value of WidthStyle from the object Width.
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

            #region ZIndexMinus1
            /// <summary>
            /// This read only property returns the value of ZIndex Minus 1
            /// </summary>
            public int ZIndexMinus1
            {
                
                get
                {
                    // initial value
                    int zIndexMinus1 = ZIndex - 1;
                    
                    // return value
                    return zIndexMinus1;
                }
            }
            #endregion
            
            #region ZIndexPlus1
            /// <summary>
            /// This read only property returns the value of ZIndex Plus 1
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

            #region ZIndexPlus2
            /// <summary>
            /// This read only property returns the value of ZIndex Plus 2
            /// </summary>
            public int ZIndexPlus2
            {
                
                get
                {
                    // initial value
                    int zIndexPlus1 = ZIndex + 2;
                    
                    // return value
                    return zIndexPlus1;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}