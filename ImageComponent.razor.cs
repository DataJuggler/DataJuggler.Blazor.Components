

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using System.Drawing;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class ImageComponent
    /// <summary>
    /// This class is used to render an Image.
    /// </summary>
    public partial class ImageComponent : IBlazorComponent
    {
        
        #region Private Variables
        private Color borderColor;
        private double borderWidth;
        private string fontName;
        private double fontSize;
        private string heightUnit;
        private string imageContainerStyle;
        private string imageTextStyle;
        private double left;
        private string name;
        private IBlazorComponentParent parent;
        private string position;
        private string textAlign;
        private double textOffsetX;
        private double textOffsetY;
        private double top;
        private string unit;
        private double height;
        private Color textColor;
        private double width;
        private int zIndex;
        private bool visible;
        private string className;
        private string imageStyle;
        private string imageUrl;
        private string text;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ImageComponent' object.
        /// </summary>
        public ImageComponent()
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
                Unit = "px";                
                HeightUnit = "px";
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
            /// This method is used to receive messages from other components or pages
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
                InvokeAsync(() =>
                {
                    // Refresh
                    StateHasChanged();
                });
            }
            #endregion

            #region SetVisible(bool visible)
            /// <summary>
            /// Set Visible
            /// </summary>
            public void SetVisible(bool visible)
            {
                // set the value
                this.Visible = visible;

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
            
            #region ImageContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'ImageContainerStyle'.
            /// </summary>
            public string ImageContainerStyle
            {
                get { return imageContainerStyle; }
                set { imageContainerStyle = value; }
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
            
            #region ImageTextStyle
            /// <summary>
            /// This property gets or sets the value for 'ImageTextStyle'.
            /// </summary>
            public string ImageTextStyle
            {
                get { return imageTextStyle; }
                set { imageTextStyle = value; }
            }
            #endregion
            
            #region ImageUrl
            /// <summary>
            /// This property gets or sets the value for 'ImageUrl'.
            /// </summary>
            [Parameter]
            public string ImageUrl
            {
                get { return imageUrl; }
                set { imageUrl = value; }
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

            #region Visibility
            /// <summary>
            /// This property gets or sets the value for 'Visibility'.
            /// </summary>
            public string Visibility
            {
                get 
                {
                    // initial value
                    string visibility = "visible";

                    // if the value for Visible is false
                    if (!Visible)
                    {
                        // hide
                        visibility = "hidden";
                    }

                    // return value
                    return visibility;
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
                set { width = value; }
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
