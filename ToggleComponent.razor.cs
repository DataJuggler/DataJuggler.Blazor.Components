﻿

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using System;
using System.Drawing;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class ToggleComponent
    /// <summary>
    /// This class is used to display and edit an On / Off state.
    /// </summary>
    public partial class ToggleComponent : IBlazorComponent
    {
        
        #region Private Variables
        private Color backgroundColor;
        private Color backgroundColorOff;
        private Color backgroundColorOn;        
        private double labelFontSize;
        private string labelPosition;
        private double labelLeft;
        private double labelTop;        
        private Color circleColor;
        private double height;
        private string imageUrl;
        private string name;
        private IBlazorComponentParent parent;
        private double width;
        private string unit;
        private string heightUnit;
        private string componentStyle;
        private string buttonStyle;
        private bool on;
        private int zIndex;
        private string ovalLeft;
        private string ovalMiddle;
        private string ovalRight;
        private double circleLeftOn;
        private double circleLeftOff;
        private double circleLeft;
        private double circleTop;
        private double circleHeight;
        private double circleWidth;
        private string column1Style;
        private bool showCaption;
        private double scale;
        
        // Oval and Oval Ends - Button ends now get their own values
        private double ovalEndWidth;
        private double ovalWidth;
        private double ovalRadius;

        // Label
        private double column1Width;
        private string caption;
        private string labelClassName;
        private string labelBackgroundColor;
        private string labelColor;
        private string labelFontSizeUnit;
        private string labelStyle;
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
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {  
                // Defaults - adjust as needed
                Height = 24;
                Width = 80;
                CircleHeight = 16;
                CircleWidth = 16;
                Unit = "px";
                HeightUnit = "px";
                ZIndex = 20;
                On = true;
                Scale = 100;

                // The end of the oval have their own width
                OvalEndWidth = 16;
                OvalWidth = 48;
                OvalRadius = 50;
                
                // Default On or Off positions
                CircleLeftOff = -35;
                CircleLeftOn = -14;
                CircleTop = 2;
                
                // Label
                LabelPosition = "relative";
                Column1Width = 60;
                LabelFontSize = 12;                
                LabelFontSizeUnit = "px";
                LabelLeft = -48;
                LabelTop = 4;

                // Set default colors
                BackgroundColorOn = Color.CornflowerBlue;
                BackgroundColorOff = Color.Gray;
                CircleColor = Color.GhostWhite;

                // Default ImageUrl
                ImageUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/OrangeCircle.png";
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
            public Color BackgroundColor
            {
                get
                {
                    // if On
                    if (On)
                    {
                        // Use the On color
                        backgroundColor = BackgroundColorOn;
                    }
                    else
                    {
                        // Use the Off color
                        backgroundColor = BackgroundColorOff;
                    }

                    // return value
                    return backgroundColor;
                }
            }
            #endregion
           
            #region BackgroundColorOff
            /// <summary>
            /// This property gets or sets the value for 'BackgroundColorOff'.
            /// </summary>
            [Parameter]
            public Color BackgroundColorOff
            {
                get { return backgroundColorOff; }
                set { backgroundColorOff = value; }
            }
            #endregion
            
            #region BackgroundColorOn
            /// <summary>
            /// This property gets or sets the value for 'BackgroundColorOn'.
            /// </summary>
            [Parameter]
            public Color BackgroundColorOn
            {
                get { return backgroundColorOn; }
                set { backgroundColorOn = value; }
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
                get { return circleColor; }
                set { circleColor = value; }
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

            #region LabelFontSize
            /// <summary>
            /// This property gets or sets the value for 'LabelFontSize'.
            /// </summary>
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

                    if (on)
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
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
            public string OvalLeft
            {
                get { return ovalLeft; }
                set { ovalLeft = value; }
            }
            #endregion
            
            #region OvalMiddle
            /// <summary>
            /// This property gets or sets the value for 'OvalMiddle'.
            /// </summary>
            public string OvalMiddle
            {
                get { return ovalMiddle; }
                set { ovalMiddle = value; }
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
            
            #region OvalRight
            /// <summary>
            /// This property gets or sets the value for 'OvalRight'.
            /// </summary>
            public string OvalRight
            {
                get { return ovalRight; }
                set { ovalRight = value; }
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

                    // Set the value for CircleLeftOff
                    CircleLeftOff = -ovalWidth - 22;
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