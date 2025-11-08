

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Drawing;
using DataJuggler.Blazor.Components.Enumerations;
using System.Numerics;
using System.Drawing.Text;
using DataJuggler.UltimateHelper;
using System;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class InformationBox
    /// <summary>
    /// This class is used to display information in a rectangle
    /// </summary>
    public partial class InformationBox : IBlazorComponent
    {
        
        #region Private Variables
        private Color backgroundColor;
        private string column1ClassName;
        private string column2ClassName;
        private string display;
        private double height;
        private double headerHeight;
        private string headerHeightStyle;
        private string heightUnit;
        private string infoBoxHeaderStyle;
        private string infoBoxStyle;
        private double left;
        private string name;
        private IBlazorComponentParent parent;
        private string position;
        private string title;
        private double headerFontSize;
        private string headerFontWeight;
        private double top;
        private string unit;
        private double width;
        private string leftStyle;
        private string topStyle;
        private string widthStyle;
        private string HeightStyle;
        private string itemContainerStyle;
        private string listItemStyle;
        private List<Item> items;
        private string column1Style;
        private double column1Width;
        private double column2Width;
        private double column1Left;        
        private string listItemHeightStyle;
        private string imageStyle;
        private string headerImageUrl;
        private ThemeEnum theme;
        private Color titleTextColor;
        private Color borderColor;
        private double borderRadius;
        private double fontSize;
        private string fontName;
        private string fontUnit;
        private double headerTextVerticalOffset;
        private string headerTextPosition;
        private string headerTextStyle;
        private string headerFontName;        
        private double imageWidth;
        private double imageHeight;
        private TextAlignmentEnum column1TextAlign;
        private TextAlignmentEnum column2TextAlign;
        private int gap;
        private string listItemPosition;
        private double listItemTop;
        private double listItemLeft;
        private string listItemUnit;
        private double listItemHeight;
        private string listItemHeightUnit;
        private string column2Style;
        private double imageTop;
        private double imageLeft;        
        private string overflow;
        private double scale;
        private int zIndex;
        private VerticalAlignmentEnum verticalAlignment;
        private RenderFragment bodyContent;
        private ItemContenteAlignmentEnum itemContenteAlignment;
        private bool visible;
        private string visibility;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InformationBox' object.
        /// </summary>
        public InformationBox()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Methods
            
            #region GetTextAlignValue(TextAlignmentEnum textAlign)
            /// <summary>
            /// returns the Text Align Value
            /// </summary>
            public static string GetTextAlignValue(TextAlignmentEnum textAlign)
            {
                // initial value
                string textAlignValue = "textalignleft";

                if (textAlign == TextAlignmentEnum.Center)
                {
                    // center
                    textAlignValue = "textaligncenter";
                }
                else if (textAlign == TextAlignmentEnum.Right)
                {
                    // center
                    textAlignValue = "textalignright";
                }
                
                // return value
                return textAlignValue;
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Unit must come first
                ListItemUnit = "px";
                ListItemHeightUnit = "px";
                FontUnit = "px";
                Unit = "px";

                // Defaults
                BackgroundColor = Color.White;
                BorderColor = Color.Gray;
                BorderRadius = 10;
                Column1TextAlign = TextAlignmentEnum.Right;
                Column2TextAlign = TextAlignmentEnum.Left;                
                Column1Width = GlobalDefaults.Column1Width;
                Column2Width = GlobalDefaults.Column2Width;
                Column1TextAlign = TextAlignmentEnum.Right;
                Column2TextAlign = TextAlignmentEnum.Left;                
                Column1Left = 8;
                Display = "inline-block";
                FontName = "Calibri";
                FontSize = 12;
                Gap = 8;
                HeaderFontSize = 16;
                HeaderFontWeight = "bold";
                HeaderFontName = "Calibri";
                HeaderHeight = 20;
                HeaderTextPosition = "relative";
                Height = 160;
                HeightUnit = "px";
                ItemContenteAlignment = ItemContenteAlignmentEnum.ItemsOnTop;                
                ListItemLeft = 0;
                ListItemTop = 0;
                ListItemPosition = "relative";                
                ListItemHeight = 26;
                Overflow = "visible";
                Position = "relative";
                Scale = 100;
                TitleTextColor = Color.White;
                VerticalAlignment = VerticalAlignmentEnum.Top;
                Visible = true;
                Width = 240;
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
                InvokeAsync(() =>
                {
                    // Refresh
                    StateHasChanged();
                });
            }
            #endregion
            
            #region SetHeaderImage(ThemeEnum theme)
            /// <summary>
            /// Set Header Image
            /// </summary>
            public void SetHeaderImage(ThemeEnum theme)
            {
                switch(theme)
                {
                    case ThemeEnum.Blue:

                        // Set the HeaderImage
                        HeaderImageUrl = "_content/DataJuggler.Blazor.Components/Images/Headers/HeaderBlue.png";

                        // required
                        break;

                    case ThemeEnum.Black:

                        // Set the HeaderImage
                        HeaderImageUrl = "_content/DataJuggler.Blazor.Components/Images/Headers/HeaderBlack.png";

                        // required
                        break;

                    case ThemeEnum.Dark:

                        // Set the HeaderImage
                        HeaderImageUrl = "_content/DataJuggler.Blazor.Components/Images/Headers/HeaderDark.png";

                        // required
                        break;

                    case ThemeEnum.Red:

                        // Set the HeaderImage
                        HeaderImageUrl = "_content/DataJuggler.Blazor.Components/Images/Headers/HeaderRed.png";

                        // required
                        break;
                }
            }
            #endregion
            
            #region SetItems(List<Item> items)
            /// <summary>
            /// Set Items
            /// </summary>
            public void SetItems(List<Item> items)
            {
                // Store
                Items = items;
            }
            #endregion

            #region SetVisible(bool visible)
            /// <summary>
            /// returns the Visible
            /// </summary>
            public void SetVisible(bool visible)
            {
                // Set to Visible
                this.Visible = visible;

                // Update
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
            
            #region BodyContent
            /// <summary>
            /// This property gets or sets the value for 'BodyContent'.
            /// </summary>
            [Parameter]
            public RenderFragment BodyContent
            {
                get { return bodyContent; }
                set { bodyContent = value; }
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
            
            #region BorderRadiusStyle
            /// <summary>
            /// This read only property returns the value of BorderRadiusStyle from the object BorderRadius.
            /// </summary>
            public string BorderRadiusStyle
            {
                
                get
                {
                    // initial value
                    string borderRadiusStyle = BorderRadius + Unit;
                    
                    // return value
                    return borderRadiusStyle;
                }
            }
            #endregion            
            
            #region Column1ClassName
            /// <summary>
            /// This property gets or sets the value for 'Column1ClassName'.
            /// </summary>
            [Parameter]
            public string Column1ClassName
            {
                get { return column1ClassName; }
                set { column1ClassName = value; }
            }
            #endregion
            
            #region Column1Left
            /// <summary>
            /// This property gets or sets the value for 'Column1Left'.
            /// </summary>
            [Parameter]
            public double Column1Left
            {
                get { return column1Left; }
                set { column1Left = value; }
            }
            #endregion
            
            #region Column1LeftStyle
            /// <summary>
            /// This read only property returns the value of Column1LeftStyle from the object Column1Left.
            /// </summary>
            public string Column1LeftStyle
            {
                
                get
                {
                    // initial value
                    string column1LeftStyle = Column1Left + Unit;
                    
                    // return value
                    return column1LeftStyle;
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
            
            #region Column1TextAlign
            /// <summary>
            /// This property gets or sets the value for 'Column1Textalign'.
            /// </summary>
            [Parameter]
            public TextAlignmentEnum Column1TextAlign
            {
                get { return column1TextAlign; }
                set { column1TextAlign = value; }
            }
            #endregion
            
            #region Column1TextAlignStyle
            /// <summary>
            /// This read only property returns the value of Column1TextAlignStyle
            /// </summary>
            public string Column1TextAlignStyle
            {
                
                get
                {
                    // initial value
                    string column1TextAlignStyle = GetTextAlignValue(column1TextAlign);
                    
                    // return value
                    return column1TextAlignStyle;
                }
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
            /// This read only property returns the value of Column1WidthStyle from the object Column1Width.
            /// </summary>
            public string Column1WidthStyle
            {
                
                get
                {
                    // initial value
                    string column1WidthStyle =  Column1Width + Unit;
                    
                    // return value
                    return column1WidthStyle;
                }
            }
            #endregion
            
            #region Column2ClassName
            /// <summary>
            /// This property gets or sets the value for 'Column2ClassName'.
            /// </summary>
            [Parameter]
            public string Column2ClassName
            {
                get { return column2ClassName; }
                set { column2ClassName = value; }
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
            
            #region Column2TextAlign
            /// <summary>
            /// This property gets or sets the value for 'Column2TexAlign'.
            /// </summary>
            [Parameter]
            public TextAlignmentEnum Column2TextAlign
            {
                get { return column2TextAlign; }
                set { column2TextAlign = value; }
            }
            #endregion

            #region Column2TextAlignStyle
            /// <summary>
            /// This read only property returns the string value of the text align value, left, center or right
            /// </summary>
            public string Column2TextAlignStyle
            {
                
                get
                {
                    // initial value
                    string column2TextAlignStyle = GetTextAlignValue(column2TextAlign);
                    
                    // return value
                    return column2TextAlignStyle;
                }
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
            /// This read only property returns the value of Column2WidthStyle from the object Column2Width.
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
                    string fontSizeStyle = FontSize + HeightUnit;
                    
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
            
            #region Gap
            /// <summary>
            /// This property gets or sets the value for 'Gap'.
            /// </summary>
            [Parameter]
            public int Gap
            {
                get { return gap; }
                set { gap = value; }
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
            
            #region HeaderFontName
            /// <summary>
            /// This property gets or sets the value for 'HeaderFontName'.
            /// </summary>
            [Parameter]
            public string HeaderFontName
            {
                get { return headerFontName; }
                set { headerFontName = value; }
            }
            #endregion
            
            #region HeaderFontSize
            /// <summary>
            /// This property gets or sets the value for 'HeaderFontSize'.
            /// </summary>
            [Parameter]
            public double HeaderFontSize
            {
                get { return headerFontSize; }
                set { headerFontSize = value; }
            }
            #endregion
            
            #region HeaderFontSizeStyle
            /// <summary>
            /// This read only property returns the value of HeaderFontSizeStyle from the object HeaderFontSize.
            /// </summary>
            public string HeaderFontSizeStyle
            {
                
                get
                {
                    // initial value
                    string headerFontSizeStyle = HeaderFontSize + HeightUnit;
                    
                    // return value
                    return headerFontSizeStyle;
                }
            }
            #endregion
            
            #region HeaderFontWeight
            /// <summary>
            /// This property gets or sets the value for 'HeaderFontWeight'.
            /// </summary>
            [Parameter]
            public string HeaderFontWeight
            {
                get { return headerFontWeight; }
                set { headerFontWeight = value; }
            }
            #endregion
            
            #region HeaderHeight
            /// <summary>
            /// This property gets or sets the value for 'HeaderHeight'.
            /// </summary>
            [Parameter]
            public double HeaderHeight
            {
                get { return headerHeight; }
                set
                {
                    // set the value
                    headerHeight = value;

                    // Set the HeaderStyle
                    HeaderHeightStyle = headerHeight + HeightUnit;
                }
            }
            #endregion
            
            #region HeaderHeightStyle
            /// <summary>
            /// This property gets or sets the value for 'HeaderHeightStyle'.
            /// </summary>
            public string HeaderHeightStyle
            {
                get { return headerHeightStyle; }
                set { headerHeightStyle = value; }
            }
            #endregion
            
            #region HeaderImageUrl
            /// <summary>
            /// This property gets or sets the value for 'HeaderImageUrl'.
            /// </summary>
            public string HeaderImageUrl
            {
                get { return headerImageUrl; }
                set { headerImageUrl = value; }
            }
            #endregion
            
            #region HeaderTextPosition
            /// <summary>
            /// This property gets or sets the value for 'HeaderTextPosition'.
            /// </summary>
            [Parameter]

            public string HeaderTextPosition
            {
                get { return headerTextPosition; }
                set { headerTextPosition = value; }
            }
            #endregion
            
            #region HeaderTextStyle
            /// <summary>
            /// This property gets or sets the value for 'HeaderTextStyle'.
            /// </summary>
            public string HeaderTextStyle
            {
                get { return headerTextStyle; }
                set { headerTextStyle = value; }
            }
            #endregion
            
            #region HeaderTextVerticalOffset
            /// <summary>
            /// This property gets or sets the value for 'HeaderTextVerticalOffset'.
            /// </summary>
            [Parameter]
            public double HeaderTextVerticalOffset
            {
                get { return headerTextVerticalOffset; }
                set { headerTextVerticalOffset = value; }
            }
            #endregion
            
            #region HeaderTextVerticalOffsetStyle
            /// <summary>
            /// This read only property returns the value of HeaderTextVerticalOffsetStyle from the object HeaderTextVerticalOffset.
            /// </summary>
            public string HeaderTextVerticalOffsetStyle
            {
                
                get
                {
                    // initial value
                    string headerTextVerticalOffsetStyle =  HeaderTextVerticalOffset + HeightUnit;
                    
                    // return value
                    return headerTextVerticalOffsetStyle;
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
                set
                {
                    height = value;
                        
                    // Set the height headerStyle string
                    HeightStyle = height + HeightUnit;
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
            
            #region ImageHeight
            /// <summary>
            /// This property gets or sets the value for 'ImageHeight'.
            /// </summary>
            [Parameter]
            public double ImageHeight
            {
                get { return imageHeight; }
                set { imageHeight = value; }
            }
            #endregion
            
            #region ImageLeft
            /// <summary>
            /// This property gets or sets the value for 'ImageLeft'.
            /// </summary>
            [Parameter]
            public double ImageLeft
            {
                get { return imageLeft; }
                set { imageLeft = value; }
            }
            #endregion
            
            #region ImageLeftStyle
            /// <summary>
            /// This read only property returns the value of ImageLeftStyle from the object ImageLeft.
            /// </summary>
            public string ImageLeftStyle
            {
                
                get
                {
                    // initial value
                    string imageLeftStyle = ImageLeft + ListItemUnit;
                    
                    // return value
                    return imageLeftStyle;
                }
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
            
            #region ImageTop
            /// <summary>
            /// This property gets or sets the value for 'ImageTop'.
            /// </summary>
            [Parameter]
            public double ImageTop
            {
                get { return imageTop; }
                set { imageTop = value; }
            }
            #endregion
            
            #region ImageTopStyle
            /// <summary>
            /// This read only property returns the value of ImageTopStyle from the object ImageTop.
            /// </summary>
            public string ImageTopStyle
            {
                
                get
                {
                    // initial value
                    string imageTopStyle = ImageTop + ListItemUnit;
                    
                    // return value
                    return imageTopStyle;
                }
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
            
            #region InfoBoxHeaderStyle
            /// <summary>
            /// This property gets or sets the value for 'InfoBoxHeaderStyle'.
            /// </summary>
            public string InfoBoxHeaderStyle
            {
                get { return infoBoxHeaderStyle; }
                set { infoBoxHeaderStyle = value; }
            }
            #endregion
            
            #region InfoBoxStyle
            /// <summary>
            /// This property gets or sets the value for 'InfoBoxStyle'.
            /// </summary>
            public string InfoBoxStyle
            {
                get { return infoBoxStyle; }
                set { infoBoxStyle = value; }
            }
            #endregion
            
            #region ItemContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'ItemContainerStyle'.
            /// </summary>
            public string ItemContainerStyle
            {
                get { return itemContainerStyle; }
                set { itemContainerStyle = value; }
            }
            #endregion
            
            #region ItemContenteAlignment
            /// <summary>
            /// This property gets or sets the value for 'ItemContenteAlignment'.
            /// </summary>
            [Parameter]
            public ItemContenteAlignmentEnum ItemContenteAlignment
            {
                get { return itemContenteAlignment; }
                set { itemContenteAlignment = value; }
            }
            #endregion
            
            #region Items
            /// <summary>
            /// This property gets or sets the value for 'Items'.
            /// </summary>
            public List<Item> Items
            {
                get { return items; }
                set { items = value; }
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
                set
                {
                    left = value;
                        
                    // set the value for leftStyle
                    leftStyle = left + Unit;
                }
            }
            #endregion
            
            #region LeftStyle
            /// <summary>
            /// This property gets or sets the value for 'LeftStyle'.
            /// </summary>
            public string LeftStyle
            {
                get { return leftStyle; }
                set { leftStyle = value; }
            }
            #endregion
            
            #region ListItemHeight
            /// <summary>
            /// This property gets or sets the value for 'ListItemHeight'.
            /// </summary>
            [Parameter]
            public double ListItemHeight
            {
                get { return listItemHeight; }
                set 
                {
                    listItemHeight = value;

                    // Set the ListItemHeightStyle
                    ListItemHeightStyle = listItemHeight + HeightUnit;
                }
            }
            #endregion
            
            #region ListItemHeightStyle
            /// <summary>
            /// This property gets or sets the value for 'ListItemHeightStyle'.
            /// </summary>
            public string ListItemHeightStyle
            {
                get { return listItemHeightStyle; }
                set { listItemHeightStyle = value; }
            }
            #endregion
            
            #region ListItemHeightUnit
            /// <summary>
            /// This property gets or sets the value for 'ListItemHeightUnit'.
            /// </summary>
            [Parameter]
            public string ListItemHeightUnit
            {
                get { return listItemHeightUnit; }
                set { listItemHeightUnit = value; }
            }
            #endregion
            
            #region ListItemLeft
            /// <summary>
            /// This property gets or sets the value for 'ListItemLeft'.
            /// </summary>
            [Parameter]
            public double ListItemLeft
            {
                get { return listItemLeft; }
                set { listItemLeft = value; }
            }
            #endregion
            
            #region ListItemLeftStyle
            /// <summary>
            /// This read only property returns the value of ListItemLeftStyle from the object ListItemLeft.
            /// </summary>
            public string ListItemLeftStyle
            {
                
                get
                {
                    // initial value
                    string listItemLeftStyle = ListItemLeft + ListItemUnit;
                    
                    // return value
                    return listItemLeftStyle;
                }
            }
            #endregion
            
            #region ListItemPosition
            /// <summary>
            /// This property gets or sets the value for 'ListItemPosition'.
            /// </summary>
            [Parameter]
            public string ListItemPosition
            {
                get { return listItemPosition; }
                set { listItemPosition = value; }
            }
            #endregion
            
            #region ListItemStyle
            /// <summary>
            /// This property gets or sets the value for 'ListItemStyle'.
            /// </summary>
            public string ListItemStyle
            {
                get { return listItemStyle; }
                set { listItemStyle = value; }
            }
            #endregion
            
            #region ListItemTop
            /// <summary>
            /// This property gets or sets the value for 'ListItemTop'.
            /// </summary>
            [Parameter]
            public double ListItemTop
            {
                get { return listItemTop; }
                set { listItemTop = value; }
            }
            #endregion
            
            #region ListItemTopStyle
            /// <summary>
            /// This read only property returns the value of ListItemTopStyle from the object ListItemTop.
            /// </summary>
            public string ListItemTopStyle
            {
                
                get
                {
                    // initial value
                    string listItemTopStyle = ListItemTop + ListItemHeightUnit;
                    
                    // return value
                    return listItemTopStyle;
                }
            }
            #endregion
            
            #region ListItemUnit
            /// <summary>
            /// This property gets or sets the value for 'ListItemUnit'.
            /// </summary>
            [Parameter]
            public string ListItemUnit
            {
                get { return listItemUnit; }
                set { listItemUnit = value; }
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
            
            #region Overflow
            /// <summary>
            /// This property gets or sets the value for 'Overflow'.
            /// </summary>
            [Parameter]
            public string Overflow
            {
                get { return overflow; }
                set { overflow = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// You should set the Name property before this method.
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
            
            #region Theme
            /// <summary>
            /// This property gets or sets the value for 'Theme'.
            /// </summary>
            [Parameter]
            public ThemeEnum Theme
            {
                get { return theme; }
                set 
                {
                    theme = value;

                    // Set the HeaderImage
                    SetHeaderImage(theme);
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
            
            #region TitleTextColor
            /// <summary>
            /// This property gets or sets the value for 'TitleTextColor'.
            /// </summary>
            [Parameter]
            public Color TitleTextColor
            {
                get { return titleTextColor; }
                set { titleTextColor = value; }
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
                set
                {
                    // set the value for top
                    top = value;
                        
                    // set the value for topStyle
                    TopStyle = top + HeightUnit;
                }
            }
            #endregion
            
            #region TopStyle
            /// <summary>
            /// This property gets or sets the value for 'TopStyle'.
            /// </summary>
            public string TopStyle
            {
                get { return topStyle; }
                set { topStyle = value; }
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
            
            #region VerticalAlignment
            /// <summary>
            /// This property gets or sets the value for 'VerticalAlignment'.
            /// </summary>
            [Parameter]
            public VerticalAlignmentEnum VerticalAlignment
            {
                get { return verticalAlignment; }
                set { verticalAlignment = value; }
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
                        Visibility = "visible";
                    }
                    else
                    {
                        Visibility = "hidden";
                    }
                }
            }
            #endregion
            
            #region Visibility
            /// <summary>
            /// This property gets or sets the value for 'Visibility'.
            /// </summary>
            public string Visibility
            {
                get { return visibility; }
                set { visibility = value; }
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
                    // set the value
                    width = value;

                    // Set the value for WidthStyle
                    WidthStyle = Width + Unit;

                }
            }
            #endregion
            
            #region WidthStyle
            /// <summary>
            /// This property gets or sets the value for 'WidthStyle'.
            /// </summary>
            public string WidthStyle
            {
                get { return widthStyle; }
                set { widthStyle = value; }
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
