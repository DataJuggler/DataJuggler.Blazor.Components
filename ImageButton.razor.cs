

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Drawing;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class ImageButton
    /// <summary>
    /// This class is used to show an image with a text caption under it
    /// </summary>
    public partial class ImageButton : IBlazorComponent
    {

        #region Private Variables
        private Color borderColor;
        private double borderWidth;
        private string imageUrl;
        private string text;
        private int buttonNumber;
        private double left;
        private double top;
        private string leftStyle;
        private string topStyle;
        private string name;
        private double height;
        private double width;
        private string heightStyle;
        private string textAlign;
        private IBlazorComponentParent parent;
        private ButtonClickedHandler clickHandler;        
        private int zIndex;        
        private bool visible;        
        private string position;
        private string unit;
        private double labelWidth;
        private Color textColor;
        private string heightUnit;
        private string className;
        private string title;
        private double fontSize;
        private string fontName;
        private double textOffsetX;
        private double textOffsetY;        

        // Reverting back to BlazorStyled
        private string buttonContainerStyle;
        private string buttonStyle;
        private string buttonTextStyle;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of an ImageButton object
        /// </summary>
        public ImageButton()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Methods
            
            #region ButtonClicked()
            /// <summary>
            /// This method Button Clicked
            /// </summary>
            public void ButtonClicked()
            {
                // if the value for HasClickHandler is true
                if (HasClickHandler)
                {
                    // Notify the handler
                    ClickHandler(ButtonNumber, Text);
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Units have to be first
                Unit = "px";                
                HeightUnit = "px";

                // defaults
                BorderWidth = 0;
                BorderColor = Color.Black;
                FontSize = GlobalDefaults.LabelFontSize;
                FontName = GlobalDefaults.LabelFontName;
                Height = 64;
                Left = 0;
                Position = "relative";
                TextAlign = "center";                
                TextColor = Color.Black;
                Top = 0;
                Visible = true;
                Width = 64;
                ZIndex = 5;
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // not used in this component
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

            #region SetClickHandler(ButtonClickedHandler clickHandler)
            /// <summary>
            /// Set Click Handler
            /// </summary>
            public void SetClickHandler(ButtonClickedHandler clickHandler)
            {
                // Store the clickHandler
                ClickHandler = clickHandler;
            }
            #endregion
            
            #region SetText(string text)
            /// <summary>
            /// Set Text
            /// </summary>
            public void SetText(string text)
            {
                // Store the new value
                Text = text;

                // Update
                Refresh();
            }
            #endregion

            #region SetTextColor(Color color)
            /// <summary>
            /// method returns the Text Color
            /// </summary>
            public void SetTextColor(Color color)
            {
                // Set the value
                TextColor = color;

                // Update
                Refresh();
            }
            #endregion
            
            #region SetVisible(bool visible)
            /// <summary>
            /// Set Visible
            /// </summary>
            public void SetVisible(bool visible)
            {
                // store
                Visible = visible;

                // Update the UI
                Refresh();
            }
            #endregion
            
        #endregion

        #region Properties
            
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
            
            #region BorderStyle
            /// <summary>
            /// This read only property returns the value of BorderWidthStyle + solid + Border Color
            /// Example: 1px solid black
            /// </summary>
            public string BorderStyle
            {

                get
                {
                    // initial value
                    string borderStyle = "none";
                    
                    // if the width is set
                    if (BorderWidth > 0)
                    {
                        // Set the return value
                        borderStyle = BorderWidthStyle + " solid " + BorderColor.Name;
                    }

                    // return value
                    return borderStyle;
                }
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

            #region ButtonContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'ButtoncontainerStyle'.
            /// </summary>
            public string ButtonContainerStyle
            {
                get { return buttonContainerStyle; }
                set { buttonContainerStyle = value; }
            }
            #endregion
            
            #region ButtonNumber
            /// <summary>
            /// This property gets or sets the value for 'ButtonNumber'.
            /// </summary>
            [Parameter]
            public int ButtonNumber
            {
                get { return buttonNumber; }
                set { buttonNumber = value; }
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
            
            #region ButtonTextStyle
            /// <summary>
            /// This property gets or sets the value for 'ButtonTextStyle'.
            /// </summary>
            public string ButtonTextStyle
            {
                get { return buttonTextStyle; }
                set { buttonTextStyle = value; }
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
            
            #region ClickHandler
            /// <summary>
            /// This property gets or sets the value for 'ClickHandler'.
            /// </summary>            
            [Parameter]
            public ButtonClickedHandler ClickHandler
            {
                get { return clickHandler; }
                set { clickHandler = value; }
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
            /// This read only property returns the value of FontSize + Unit
            /// </summary>
            public string FontSizeStyle
            {

                get
                {
                    // initial value
                    string fontSizeStyle = FontSize + Unit;
                    
                    // return value
                    return fontSizeStyle;
                }
            }
            #endregion

            #region HasClickHandler
            /// <summary>
            /// This property returns true if this object has a 'ClickHandler'.
            /// </summary>
            public bool HasClickHandler
            {
                get
                {
                    // initial value
                    bool hasClickHandler = (this.ClickHandler != null);
                    
                    // return value
                    return hasClickHandler;
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
            /// This read only property returns the value of Height + Unit
            /// </summary>
            public string HeightStyle
            {
                
                get
                {
                    // initial value
                    string heightStyle = Height + HeightUnit;

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
            
            #region ImageUrl
            /// <summary>
            /// This property gets or sets the value for 'ImageUrl'.
            /// </summary>
            [Parameter]
            public string ImageUrl
            {
                get 
                {
                    return imageUrl;
                }
                set 
                { 
                    imageUrl = value;
                }
            }
            #endregion

            #region LabelWidth
            /// <summary>
            /// This property gets or sets the value for 'LabelWidth'.
            /// </summary>
            public double LabelWidth
            {
                get { return labelWidth; }
                set { labelWidth = value; }
            }
            #endregion
            
            #region LabelWidthStyle
            /// <summary>
            /// This read only property returns the value of LabelWidthStyle from the object LabelWidth.
            /// </summary>
            public string LabelWidthStyle
            {
                
                get
                {
                    // initial value
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
            
            #region OutlineStyle
            /// <summary>
            /// This read only property returns the value of the Border if BorderWidth is set, else None:
            /// </summary>
            public string OutlineStyle
            {

                get
                {
                    // initial value
                    string outlineStyle = "none";

                    // if BorderWidth is set
                    if (BorderWidth > 0)
                    {
                        // set the return value
                        outlineStyle = BorderWidth + Unit + " solid " + BorderColor.Name;
                    }

                    // return value
                    return outlineStyle;
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

                    // if the parent exists
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
            
            #region TextColor
            /// <summary>
            /// This property gets or sets the value for 'TextColor'.
            /// </summary>
            [Parameter]
            public Color TextColor
            {
                get { return textColor; }
                set { textColor = value; }
            }
            #endregion

            #region TextColorName
            /// <summary>
            /// This read only property returns the name from the 'TextColor'.
            /// </summary>            
            public string TextColorName
            {
                get 
                {
                    return textColor.Name;
                }
            }
            #endregion
            
            #region TextOffsetX
            /// <summary>
            /// This property gets or sets the value for 'TextOffsetX'.
            /// </summary>
            [Parameter]
            public double TextOffsetX
            {
                get { return textOffsetX; }
                set { textOffsetX = value; }
            }
            #endregion
            
            #region TextOffsetXStyle
            /// <summary>
            /// This read only property returns the value of TextOffsetX + Unit
            /// </summary>
            public string TextOffsetXStyle
            {

                get
                {
                    // initial value
                    string textOffsetXStyle = TextOffsetX + Unit;
                    
                    // return value
                    return textOffsetXStyle;
                }
            }
            #endregion

            #region TextOffsetY
            /// <summary>
            /// This property gets or sets the value for 'TextOffsetY'.
            /// </summary>
            [Parameter]
            public double TextOffsetY
            {
                get { return textOffsetY; }
                set { textOffsetY = value; }
            }
            #endregion
            
            #region TextOffsetYStyle
            /// <summary>
            /// This read only property returns the value of TextOffsetY + HeightUnit
            /// </summary>
            public string TextOffsetYStyle
            {

                get
                {
                    // initial value
                    string textOffsetYStyle = TextOffsetY + HeightUnit;
                    
                    // return value
                    return textOffsetYStyle;
                }
            }
            #endregion

            #region Title
            /// <summary>
            /// This property gets or sets the value for 'Title'.
            /// </summary>
            [Parameter]
            public string Title
            {
                get { return title; }
                set { title = value; }
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
            
            #region VisibleStyle
            /// <summary>
            /// This property gets or sets the value for 'VisibleStyle'.
            /// </summary>
            public string VisibleStyle
            {
                get 
                {
                    // initial value
                    string visibleStyle = "visible";

                    // if the value for Visible is false
                    if (!Visible)
                    {
                        // hide
                        visibleStyle = "hidden";
                    }

                    // return value
                    return visibleStyle;
                }
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
                }
            }
            #endregion
            
            #region WidthStyle
            /// <summary>
            /// This property gets or sets the value for 'WidthStyle'.
            /// </summary>
            public string WidthStyle
            {
                get
                {
                    // initial value
                    string widthStyle = width + unit;

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
