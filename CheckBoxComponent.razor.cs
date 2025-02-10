

#region using statements

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.Blazor.Components.Interfaces;
using Microsoft.AspNetCore.Components;

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
        private double borderWidth;
        private string name;
        private IBlazorComponentParent parent;
        private double checkBoxXPosition;
        private string checkBoxXStyle;
        private double checkBoxYPosition;
        private string checkBoxYStyle;
        private string className;        
        private bool checkBoxValue;
        private string checkBoxStyle;
        private double checkBoxTextXPosition;
        private double checkBoxTextYPosition;
        private string textStyle;
        private bool enabled;
        private string text;
        private string position;
        private double zIndex;
        private string backColor;
        private string inputType;
        private int tabIndex;
        private string unit;
        private string heightUnit;
        private int externalId;
        private double column1Width;
        private double column2Width;
        private double width;
        private double height;
        private string backgroundColor;
        private Color borderColor;
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
                // default
                Position = "relative";
                InputType = "checkbox";
                Unit = "px";
                HeightUnit = "px";
                CheckBoxTextXPosition = -1;
                CheckBoxTextYPosition = -1;
                CheckBoxXPosition = -4;
                CheckBoxYPosition = 1;
                Column1Width = GlobalDefaults.Column1Width;
                Column2Width = GlobalDefaults.Column2Width;
                Width = 80;
                Height = 24;
                BackgroundColor = "White";
                BorderColor = Color.Gray;
                BorderWidth = 1;
                Enabled = true;
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
            
            #region CheckBoxTextXPosition
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxTextXPosition'.
            /// </summary>
            [Parameter]
            public double CheckBoxTextXPosition
            {
                get { return checkBoxTextXPosition; }
                set { checkBoxTextXPosition = value; }
            }
            #endregion
            
            #region CheckBoxTextXPositionStyle
            /// <summary>
            /// This read only property returns the value of CheckBoxTextXPositionStyle from the object CheckBoxTextXPosition.
            /// </summary>
            public string CheckBoxTextXPositionStyle
            {
                
                get
                {
                    // initial value
                    string checkBoxTextXPositionStyle = CheckBoxTextXPosition + Unit;
                    
                    // return value
                    return checkBoxTextXPositionStyle;
                }
            }
            #endregion
            
            #region CheckBoxTextYPosition
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxTextYPosition'.
            /// </summary>
            [Parameter]
            public double CheckBoxTextYPosition
            {
                get { return checkBoxTextYPosition; }
                set { checkBoxTextYPosition = value; }
            }
            #endregion
            
            #region CheckBoxTextYPositionStyle
            /// <summary>
            /// This read only property returns the value of CheckBoxTextYPositionStyle from the object CheckBoxTextYPosition.
            /// </summary>
            public string CheckBoxTextYPositionStyle
            {
                
                get
                {
                    // initial value
                    string checkBoxTextYPositionStyle = CheckBoxTextYPosition + HeightUnit;
                    
                    // return value
                    return checkBoxTextYPositionStyle;
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
                    checkBoxXStyle = checkBoxXPosition + Unit;
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
                    checkBoxYStyle = checkBoxYPosition + HeightUnit;
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
            public double ZIndex
            {
                get { return zIndex; }
                set { zIndex = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
