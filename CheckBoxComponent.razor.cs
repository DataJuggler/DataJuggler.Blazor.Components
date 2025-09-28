

#region using statements

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using NPOI.SS.Formula.Functions;
using NPOI.XWPF.UserModel;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class CheckBoxComponent
    /// <summary>
    /// This class serves a CheckBox and is used in CheckListBox and the ComboBox in CheckedList mode.
    /// </summary>
    public partial class CheckBoxComponent : IBlazorComponent
    {
        
        #region Private Variables        
        private Color backgroundColor;
        private Color borderColor;
        private double borderWidth;
        private string caption;
        private string checkBoxControlStyle;
        private string checkBoxStyle;
        private bool checkBoxValue;
        private double checkBoxTextX;
        private double checkBoxTextY;
        private double checkBoxX;
        private string checkBoxXStyle;
        private double checkBoxY;
        private string checkBoxYStyle;
        private string className;
        private double column1Width;
        private string column1Style;
        private double column2Width;
        private string column2Style;
        private double controlHeight;
        private string display;
        private bool enabled;
        private int externalId;
        private double height;
        private string heightUnit;
        private string inputType;
        private double left;
        private double marginBottom;
        private double marginLeft;
        private string name;
        private IBlazorComponentParent parent;
        private string position;
        private bool showCaption;
        private int tabIndex;
        private string text;
        private string textStyle;
        private double top;
        private string unit;
        private bool visible;
        private double width;
        private int zIndex;
        
         // Label
        private double labelWidth;
        private double labelFontSize;
        private string labelFontName;        
        private string labelClassName;
        private Color labelBackgroundColor;
        private Color labelColor;
        private double labelTop;
        private double labelLeft;
        private string labelStyle;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a CheckBoxComponent
        /// </summary>
        public CheckBoxComponent()
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
                // Units have to be first
                HeightUnit = "px";
                Unit = "px";

                // Default Values
                BackgroundColor = @Color.White;
                BorderColor = Color.Gray;
                BorderWidth = 1;
                Caption = "";
                CheckBoxTextX = 2;
                CheckBoxTextY = 0;
                CheckBoxX = 6;
                CheckBoxY = 7;
                ClassName = "";
                Column1Width = GlobalDefaults.Column1Width;
                Column2Width = GlobalDefaults.Column2Width;
                ControlHeight = 22;
                Display = "inline-block";
                Enabled = true;                
                Height = 16;
                InputType = "checkbox";                
                LabelBackgroundColor = Color.White;
                LabelClassName = GlobalDefaults.LabelClassName;
                LabelColor = Color.Black;
                LabelFontName = GlobalDefaults.LabelFontName;
                LabelFontSize = GlobalDefaults.LabelFontSize;
                LabelWidth = 30;
                Left = 0;
                MarginBottom = 8;
                MarginLeft = 1.2;
                Position = "relative";                
                Text = "";
                Top = 0;
                Width = 16;             
                Visible = true;                
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

            #region SetCheckBoxValue(bool isChecked)
            /// <summary>
            /// This method Sets the CheckBoxValue
            /// </summary>
            public void SetCheckBoxValue(bool isChecked)
            {  
                // Set the value
                CheckBoxValue = isChecked;

                // Update the UI
                Refresh();
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
            public double BorderWidth
            {
                get { return borderWidth; }
                set { borderWidth = value; }
            }
            #endregion
            
            #region BorderWidthStyle
            /// <summary>
            /// This read only property returns the value of BorderWidthStyle from the object BorderWidth.
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

            #region CheckBoxControlStyle
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxControlStyle'.
            /// </summary>
            public string CheckBoxControlStyle
            {
                get { return checkBoxControlStyle; }
                set { checkBoxControlStyle = value; }
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
            
            #region CheckBoxTextX
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxTextX'.
            /// </summary>
            [Parameter]
            public double CheckBoxTextX
            {
                get { return checkBoxTextX; }
                set { checkBoxTextX = value; }
            }
            #endregion
            
            #region CheckBoxTextXStyle
            /// <summary>
            /// This read only property returns the value of CheckBoxTextXStyle from the object CheckBoxTextX.
            /// </summary>
            public string CheckBoxTextXStyle
            {
                
                get
                {
                    // initial value
                    string checkBoxTextXStyle = CheckBoxTextX + Unit;
                    
                    // return value
                    return checkBoxTextXStyle;
                }
            }
            #endregion
            
            #region CheckBoxTextY
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxTextY'.
            /// </summary>
            [Parameter]
            public double CheckBoxTextY
            {
                get { return checkBoxTextY; }
                set { checkBoxTextY = value; }
            }
            #endregion
            
            #region CheckBoxTextYStyle
            /// <summary>
            /// This read only property returns the value of CheckBoxTextYStyle from the object CheckBoxTextY.
            /// </summary>
            public string CheckBoxTextYStyle
            {
                
                get
                {
                    // initial value
                    string checkBoxTextYStyle = CheckBoxTextY + HeightUnit;
                    
                    // return value
                    return checkBoxTextYStyle;
                }
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
                set 
                {
                    // set the value
                    checkBoxValue = value;

                    // if there is a Parent
                    if (HasParent)
                    {
                        // Create a new instance of a 'Message' object.
                        Message message = new Message();
                        message.Sender = this;
                        message.Text = "ItemSelected";
                        message.Id = ExternalId;
                        message.CheckedValue = checkBoxValue;

                        // Send the parent a message the value has changed.
                        Parent.ReceiveData(message);
                    }
                }
            }
            #endregion
            
            #region CheckBoxX
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxX'.
            /// </summary>
            [Parameter]
            public double CheckBoxX
            {
                get { return checkBoxX; }
                set 
                { 
                    // set the value
                    checkBoxX = value;

                    // set the headerStyle value
                    checkBoxXStyle = checkBoxX + Unit;
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
            
            #region CheckBoxY
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxY'.
            /// </summary>
            [Parameter]
            public double CheckBoxY
            {
                get { return checkBoxY; }
                set 
                {
                    // set the value
                    checkBoxY = value;

                    // Set the checkBoxYStyle
                    checkBoxYStyle = checkBoxY + HeightUnit;
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
            
            #region ControlHeight
            /// <summary>
            /// This property gets or sets the value for 'ControlHeight'.
            /// </summary>
            [Parameter]
            public double ControlHeight
            {
                get { return controlHeight; }
                set { controlHeight = value; }
            }
            #endregion
            
            #region ControlHeightStyle
            /// <summary>
            /// This read only property returns the value of ControlHeightJ + HeightUnit
            /// </summary>
            public string ControlHeightStyle
            {

                get
                {
                    // initial value
                    string controlHeightStyle = ControlHeight + HeightUnit;
                    
                    // return value
                    return controlHeightStyle;
                }
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

            #region LabelBackgroundColor
            /// <summary>
            /// This property gets or sets the value for 'LabelBackgroundColor'.
            /// </summary>
            [Parameter]
            public Color LabelBackgroundColor
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
                    // Set parent
                    parent = value;

                    // if the value for HasParent is true
                    if (HasParent)
                    {
                        // register with the parent
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
            
            #region TextStyle
            /// <summary>
            /// This property gets or sets the value for 'TextStyle'.
            /// </summary>
            public string TextStyle
            {
                get { return textStyle; }
                set { textStyle = value; }
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
            
            #region ZIndexPlus10
            /// <summary>
            /// This read only property returns the value of ZIndex Plus 10
            /// </summary>
            public int ZIndexPlus10
            {

                get
                {
                    // initial value
                    int zIndexPlus10 = ZIndex + 10;
                    
                    // return value
                    return zIndexPlus10;
                }
            }
            #endregion

        #endregion
        
    }
    #endregion

}
