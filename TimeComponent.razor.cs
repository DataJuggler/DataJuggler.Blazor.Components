

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Enumerations;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Components;
using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using System.Drawing;
using Microsoft.AspNetCore.Components.Web;
using DataJuggler.Blazor.Components.Delegates;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class TimeComponent
    /// <summary>
    /// This class is used to diisplay and select user input of a time.
    /// </summary>
    public partial class TimeComponent : IBlazorComponent, IBlazorComponentParent, ILabelFont
    {
        
        #region Private Variables
        private List<IBlazorComponent> children;        
        private string name;
        private IBlazorComponentParent parent;
        private TimeTypeEnum timeType;
        private double left;
        private double top;
        private double height;
        private double width;        
        private double column1Width;   
        private TextAlignmentEnum captionTextAlign;
        private string unit;
        private string heightUnit;
        private string timeComponentStyle;
        private string display;
        private string position;
        private string caption;
        private double fontSize;
        private string fontName;
        private string fontUnit;
        private string pattern;
        private Color backgroundColor;
        private double labelLeft;
        private double labelTop;        
        private TextBoxComponent hoursTextBox;
        private TextBoxComponent minutesTextBox;
        private double hoursTextBoxWidth;
        private double hoursTextBoxLeft;
        private double minutesTextBoxWidth;
        private double minutesTextBoxLeft;
        private double buttonWidth;
        private double buttonHeight;
        private string minutesTextBoxStyle;
        private string hoursTextBoxStyle;
        private string colonTextBoxStyle;
        private Label labelComponent;
        private Label aMPMComponent; 
        private DateTime currentTime;
        private Color labelColor;
        private string labelFontName;
        private double labelFontSize;
        private double aMPMLabelLeft;
        private double labelZIndex;
        private string labelClassName;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'TimeComponent' object.
        /// </summary>
        public TimeComponent()
        {
            // Perform initializations for this object
            Init(); 
        }
        #endregion
        
        #region Methods
            
            #region DisplayCurrentTime()
            /// <summary>
            /// Display Current Time
            /// </summary>
            public void DisplayCurrentTime()
            {
                // locals
                string hourText = CurrentTime.Hour.ToString();
                string minutesText = currentTime.Minute.ToString();
                string ampm = "AM";

                int hour = NumericHelper.ParseInteger(hourText, -1, -2);
                int minute = NumericHelper.ParseInteger(minutesText, -1, -2);

                // if 12 - 23
                if (hour > 11)
                {
                    // reduce hourss by 12
                    hour -= 12;
                    
                    // After noon
                    ampm = "PM";
                }

                if (hour == 0)
                {
                    // Reset
                    hour = 12;
                }

                // if the value for HasHoursTextBox is true
                if (HasHoursTextBox)
                {
                    // Set the Hours
                    HoursTextBox.SetTextValue(hour.ToString());
                }

                // if the value for HasAMPMComponent is true
                if (HasAMPMComponent)
                {
                    // Display
                    AMPMComponent.SetTextValue(ampm);
                }

                // if the value for HasMinutesTextBox is true
                if (HasMinutesTextBox)
                {
                    // Set the Hours
                    MinutesTextBox.SetTextValue(minute.ToString());
                }

                // Update the UI
                Refresh();
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                 // Default
                TimeType = TimeTypeEnum.Hours12;

                // Default Units                
                FontUnit = "px";                
                HeightUnit = "px";
                Unit = "px";

                // Default to inline-block
                Display = "inline-block";

                // Default Position
                Position = "relative";

                // Default Caption
                Caption = "Time:";

                // Default to right
                Column1Width = GlobalDefaults.Column1Width;
                CaptionTextAlign = TextAlignmentEnum.Right;

                // Default                
                FontSize = GlobalDefaults.TextBoxFontSize;
                FontName = GlobalDefaults.TextBoxFontName;
                LabelFontSize = GlobalDefaults.LabelFontSize;
                LabelFontName = GlobalDefaults.LabelFontName;

                // Default Pattern for a Time
                // Pattern = "(0?[1-9]|1[0-2]):[0-5][0-9] (AM|PM)";

                // Defaults (this might get adjusted)
                HoursTextBoxLeft = 2;
                HoursTextBoxWidth = 24; // Will Set MinutesTextBoxLeft
                MinutesTextBoxWidth = HoursTextBoxWidth;

                // Defaults                
                Left = -1;                
                LabelLeft = 0;
                LabelTop = 3;
                LabelColor = Color.Black;
                LabelClassName = GlobalDefaults.LabelClassName;
                HoursTextBoxLeft = -14; 
                MinutesTextBoxLeft = -16;
                ButtonHeight = 16;
                ButtonWidth = 16;

                // Start at Negative 20
                AMPMLabelLeft = -20;

                // Default to two 12 hour times
                TimeType = TimeTypeEnum.Hours12;
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                if ((NullHelper.Exists(message)) && (message.HasSender))
                {
                    // if this message was sent by the AMPMComponent
                    if (message.Sender.Name == "LabelAMPMComponent")
                    {
                        // if the AMPMComponent exists
                        if (HasAMPMComponent)
                        {
                            // Get the current text
                            string currentText = AMPMComponent.Text;

                            // if AM
                            if (currentText == "AM")
                            {
                                // Toggle
                                AMPMComponent.SetTextValue("PM");
                            }
                            else
                            {
                                // Toggle
                                AMPMComponent.SetTextValue("AM");
                            }
                        }
                    }
                    else if ((message.Sender.Name == "HoursTextBox") && (HasHoursTextBox))
                    {  
                        // Parse the Hour
                        int hour = NumericHelper.ParseInteger(HoursTextBox.Text, -1, -2);

                        if (NumericHelper.IsInRange(hour, 1, 12))
                        {
                            // Valid
                            HoursTextBox.SetBackgroundColor(Color.White);
                        }
                        else
                        {
                            // Not Valid
                            HoursTextBox.SetBackgroundColor(Color.Tomato);
                        }
                    }
                    else if ((message.Sender.Name == "MinutesTextBox") && (HasMinutesTextBox))
                    {
                        // Parse the Minute
                        int minutes = NumericHelper.ParseInteger(MinutesTextBox.Text, -1, -2);

                        if (NumericHelper.IsInRange(minutes, 0, 59))
                        {
                            // Valid
                            MinutesTextBox.SetBackgroundColor(Color.White);
                        }
                        else
                        {
                            // Not Valid
                            MinutesTextBox.SetBackgroundColor(Color.Tomato);
                        }
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
                
            #region Register(IBlazorComponent component)
            /// <summary>
            /// method Register
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                if (component is TextBoxComponent)
                {
                    // if this is the MinutesTextBox
                    if (component.Name == "MinutesTextBox")
                    {
                        // store
                        MinutesTextBox = component as TextBoxComponent;

                        if (HasMinutesTextBox)
                        {  
                            MinutesTextBox.SetTextValue("00");
                        }
                    }

                     // if this is the MinutesTextBox
                    if (component.Name == "HoursTextBox")
                    {
                        // store
                        HoursTextBox = component as TextBoxComponent;

                        if (HasHoursTextBox)
                        {
                            // Test only
                            HoursTextBox.SetTextValue("8");
                        }
                    }
                }
                else if (component is Label)
                {
                    // if this the first label
                    if (component.Name == "LabelComponent")
                    {
                        // Store
                        LabelComponent = component as Label;
                    }
                
                    // if this the first label
                    if (component.Name == "LabelAMPMComponent")
                    {
                        // Store
                        AMPMComponent = component as Label;
                    }}
            }
            #endregion
                
            #region SetCurrentTime(DateTime newTime)
            /// <summary>
            /// Set Current Time
            /// </summary>
            public void SetCurrentTime(DateTime newTime)
            {
                // Set the CurrentTime
                currentTime = newTime;

                // Display the CurrentTime
                DisplayCurrentTime();
            }
            #endregion
            
            #region ValidateHours(string text)
            /// <summary>
            /// Validate Hours
            /// </summary>
            public void ValidateHours(string text)
            {
                // if the value for HasHoursTextBox is true
                if (HasHoursTextBox)
                {
                    // parse the hour
                    int hour = NumericHelper.ParseInteger(text, -1, -2);

                    // if military time
                    if (TimeType == TimeTypeEnum.Hours24)
                    {
                        // if 0 - 23
                        if (NumericHelper.IsInRange(hour, 0, 23))
                        {
                            // Set to White
                            HoursTextBox.SetTextBoxBackColor(Color.White);
                        }
                        else
                        {
                            // Set to White
                            HoursTextBox.SetTextBoxBackColor(Color.Tomato);
                        }
                    }
                    else
                    {
                        // if 0 - 23
                        if (NumericHelper.IsInRange(hour, 1, 12))
                        {
                            // Set to White
                            HoursTextBox.SetTextBoxBackColor(Color.White);
                        }
                        else
                        {
                            // Set to White
                            HoursTextBox.SetTextBoxBackColor(Color.Tomato);
                        }
                    }

                    // Update the HoursTextBox
                    HoursTextBox.Refresh();
                }
            }
            #endregion

            #region ValidateMinutes(string text)
            /// <summary>
            /// Validate Minutes
            /// </summary>
            public void ValidateMinutes(string text)
            {
                // if the value for HasMinutesTextBox is true
                if (HasMinutesTextBox)
                {
                    // parse the minutes
                    int minutes = NumericHelper.ParseInteger(text, -1, -2);

                    // if 0 - 59
                    if (NumericHelper.IsInRange(minutes, 0, 59))
                    {
                        // Set to White
                        MinutesTextBox.SetTextBoxBackColor(Color.White);
                    }
                    else
                    {
                        // Set to White
                        MinutesTextBox.SetTextBoxBackColor(Color.Tomato);
                    }

                    // if 0 - 9
                    if (minutes < 10)
                    {
                        // if the user only typed 1 digit
                        if (text.Length < 2)
                        {
                            // Create a two digit 0
                            string newText = "0" + minutes.ToString();

                            // Set Loading to true
                            MinutesTextBox.Loading = true;

                            // Set the newText
                            MinutesTextBox.SetTextValue(newText);

                            // Turn off Loading so this event doesn't get called again
                            MinutesTextBox.Loading = false;
                        }
                    }

                    // Update the HoursTextBox
                    MinutesTextBox.Refresh();
                }
            }
            #endregion
            
        #endregion
            
        #region Properties
                
            #region AMPMComponent
            /// <summary>
            /// This property gets or sets the value for 'AMPMComponent'.
            /// </summary>
            public Label AMPMComponent
            {
                get { return aMPMComponent; }
                set { aMPMComponent = value; }
            }
            #endregion
            
            #region AMPMLabelLeft
            /// <summary>
            /// This property gets or sets the value for 'AMPMLabelLeft'.
            /// </summary>
            [Parameter]
            public double AMPMLabelLeft
            {
                get { return aMPMLabelLeft; }
                set { aMPMLabelLeft = value; }
            }
            #endregion
           
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
            
            #region ButtonWidth
            /// <summary>
            /// This property gets or sets the value for 'ButtonWidth'.
            /// </summary>
            [Parameter]
            public double ButtonWidth
            {
                get { return buttonWidth; }
                set { buttonWidth = value; }
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
            
            #region CaptionTextAlign
            /// <summary>
            /// This property gets or sets the value for 'CaptionTextAlign'.
            /// </summary>
            public TextAlignmentEnum CaptionTextAlign
            {
                get { return captionTextAlign; }
                set { captionTextAlign = value; }
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
                
            #region ColonTextBoxStyle
            /// <summary>
            /// This property gets or sets the value for 'ColonTextBoxStyle'.
            /// </summary>
            public string ColonTextBoxStyle
            {
                get { return colonTextBoxStyle; }
                set { colonTextBoxStyle = value; }
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
            
            #region CurrentTime
            /// <summary>
            /// This property gets or sets the value for 'CurrentTime'.
            /// </summary>
            public DateTime CurrentTime
            {
                get { return currentTime; }
            }
            #endregion
                
            #region Display
            /// <summary>
            /// This property gets or sets the value for 'Display'.
            /// </summary>
            [Parameter]
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
            
            #region FontSizeStyle
            /// <summary>
            /// This read only property returns the value of FontSizeStyle from the object FontSize.
            /// </summary>
            public string FontSizeStyle
            {
                
                get
                {
                    // initial value
                    string fontSizeStyle = FontSize + FontUnit;
                    
                    // return value
                    return fontSizeStyle;
                }
            }
            #endregion
            
            #region FontUnit
            /// <summary>
            /// This property gets or sets the value for 'FontUnit'.
            /// </summary>
            [Parameter]
            public string FontUnit
            {
                get { return fontUnit; }
                set { fontUnit = value; }
            }
            #endregion
            
            #region HasAMPMComponent
            /// <summary>
            /// This property returns true if this object has an 'AMPMComponent'.
            /// </summary>
            public bool HasAMPMComponent
            {
                get
                {
                    // initial value
                    bool hasAMPMComponent = (this.AMPMComponent != null);
                    
                    // return value
                    return hasAMPMComponent;
                }
            }
            #endregion
            
            #region HasChildren
            /// <summary>
            /// This property returns true if this object has a 'Children'.
            /// </summary>
            public bool HasChildren
            {
                get
                {
                    // initial value
                    bool hasChildren = (this.Children != null);
                        
                    // return value
                    return hasChildren;
                }
            }
            #endregion
            
            #region HasHoursTextBox
            /// <summary>
            /// This property returns true if this object has a 'HoursTextBox'.
            /// </summary>
            public bool HasHoursTextBox
            {
                get
                {
                    // initial value
                    bool hasHoursTextBox = (this.HoursTextBox != null);
                    
                    // return value
                    return hasHoursTextBox;
                }
            }
            #endregion
            
            #region HasMinutesTextBox
            /// <summary>
            /// This property returns true if this object has a 'MinutesTextBox'.
            /// </summary>
            public bool HasMinutesTextBox
            {
                get
                {
                    // initial value
                    bool hasMinutesTextBox = (this.MinutesTextBox != null);
                    
                    // return value
                    return hasMinutesTextBox;
                }
            }
            #endregion
            
            #region HasName
            /// <summary>
            /// This property returns true if the 'Name' exists.
            /// </summary>
            public bool HasName
            {
                get
                {
                    // initial value
                    bool hasName = (!String.IsNullOrEmpty(this.Name));
                        
                    // return value
                    return hasName;
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
            
            #region HoursTextBox
            /// <summary>
            /// This property gets or sets the value for 'HoursTextBox'.
            /// </summary>
            public TextBoxComponent HoursTextBox
            {
                get { return hoursTextBox; }
                set { hoursTextBox = value; }
            }
            #endregion
            
            #region HoursTextBoxLeft
            /// <summary>
            /// This property gets or sets the value for 'HoursTextBoxLeft'.
            /// </summary>
            [Parameter]
            public double HoursTextBoxLeft
            {
                get { return hoursTextBoxLeft; }
                set { hoursTextBoxLeft = value; }
            }
            #endregion
            
            #region HoursTextBoxStyle
            /// <summary>
            /// This property gets or sets the value for 'HoursTextBoxStyle'.
            /// </summary>
            public string HoursTextBoxStyle
            {
                get { return hoursTextBoxStyle; }
                set { hoursTextBoxStyle = value; }
            }
            #endregion
            
            #region HoursTextBoxWidth
            /// <summary>
            /// This property gets or sets the value for 'HoursTextBoxWidth'.
            /// </summary>
            [Parameter]
            public double HoursTextBoxWidth
            {
                get { return hoursTextBoxWidth; }
                set 
                {
                    hoursTextBoxWidth = value;

                    // The left of the minutes textbox should be the same plus the colon (I think)
                    MinutesTextBoxLeft = value + 8;
                }
            }
            #endregion
            
            #region HoursTextBoxWidthPlus4
            /// <summary>
            /// This read only property returns the value of HoursTextBoxWidthPlus4 from the object HoursTextBoxWidth.
            /// </summary>
            public double HoursTextBoxWidthPlus4
            {
                
                get
                {
                    // initial value
                    double hoursTextBoxWidthPlus4 = HoursTextBoxWidth + 4;
                    
                    // return value
                    return hoursTextBoxWidthPlus4;
                }
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
            
            #region LabelComponent
            /// <summary>
            /// This property gets or sets the value for 'LabelComponent'.
            /// </summary>
            public Label LabelComponent
            {
                get { return labelComponent; }
                set { labelComponent = value; }
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
            
            #region LabelZIndex
            /// <summary>
            /// This property gets or sets the value for 'LabelZIndex'.
            /// </summary>
            [Parameter]
            public double LabelZIndex
            {
                get { return labelZIndex; }
                set { labelZIndex = value; }
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
            /// This read only property returns the value of LeftStyle from the object Left.
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
                
            #region MinutesTextBox
            /// <summary>
            /// This property gets or sets the value for 'MinutesTextBox'.
            /// </summary>
            public TextBoxComponent MinutesTextBox
            {
                get { return minutesTextBox; }
                set { minutesTextBox = value; }
            }
            #endregion
            
            #region MinutesTextBoxLeft
            /// <summary>
            /// This property gets or sets the value for 'MinutesTextBoxLeft'.
            /// </summary>
            [Parameter]
            public double MinutesTextBoxLeft
            {
                get { return minutesTextBoxLeft; }
                set { minutesTextBoxLeft = value; }
            }
            #endregion
            
            #region MinutesTextBoxStyle
            /// <summary>
            /// This property gets or sets the value for 'MinutesTextBoxStyle'.
            /// </summary>
            public string MinutesTextBoxStyle
            {
                get { return minutesTextBoxStyle; }
                set { minutesTextBoxStyle = value; }
            }
            #endregion
            
            #region MinutesTextBoxWidth
            /// <summary>
            /// This property gets or sets the value for 'MinutesTextBoxWidth'.
            /// </summary>
            [Parameter]
            public double MinutesTextBoxWidth
            {
                get { return minutesTextBoxWidth; }
                set { minutesTextBoxWidth = value; }
            }
            #endregion
            
            #region MinutesTextBoxWidthPlus4
            /// <summary>
            /// This read only property returns the value of MinutesTextBoxWidth Plus4
            /// </summary>
            public double MinutesTextBoxWidthPlus4
            {
                
                get
                {
                    // initial value
                    double minutesTextBoxWidthPlus4 = MinutesTextBoxWidth + 4;
                    
                    // return value
                    return minutesTextBoxWidthPlus4;
                }
            }
            #endregion
            
            #region MinutesTextBoxLeftPlus3
            /// <summary>
            /// This read only property returns the value of MinutesTextBoxLeft + 3
            /// </summary>
            public double MinutesTextBoxLeftPlus3
            {
                get
                {
                    // initial value
                    double minutesTextBoxLeftMinus3 = MinutesTextBoxLeft + 3;
                    
                    // return value
                    return minutesTextBoxLeftMinus3;
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

                    // if the parent exists
                    if (HasParent)
                    {
                        // register with the parent
                        Parent.Register(this);
                    }
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
            
            #region ShowAMPMLabel
            /// <summary>
            /// This read only property returns the true if TimeType = 12
            /// </summary>
            public bool ShowAMPMLabel
            {
                
                get
                {
                    // initial value
                    bool showAMPMLabel = (TimeType == TimeTypeEnum.Hours12);
                    
                    // return value
                    return showAMPMLabel;
                }
            }
            #endregion
            
            #region TimeComponentStyle
            /// <summary>
            /// This property gets or sets the value for 'TimeComponentStyle'.
            /// </summary>
            public string TimeComponentStyle
            {
                get { return timeComponentStyle; }
                set { timeComponentStyle = value; }
            }
            #endregion
            
            #region TimeType
            /// <summary>
            /// This property gets or sets the value for 'TimeType'.
            /// </summary>
            [Parameter]
            public TimeTypeEnum TimeType
            {
                get { return timeType; }
                set { timeType = value; }
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
            /// This read only property returns the value of TopStyle from the object Top.
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
