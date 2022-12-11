

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using DataJuggler.Blazor.Components.Enumerations;
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
        private string buttonStyle;        
        private string buttonContainerStyle;
        private string imageUrl;
        private string buttonText;
        private int buttonNumber;
        private double left;
        private double top;
        private string leftStyle;
        private string topStyle;
        private string name;
        private double height;
        private double width;
        private string heightStyle;
        private string buttonTextAlign;
        private IBlazorComponentParent parent;
        private ButtonClickedHandler clickHandler;
        private List<IBlazorComponent> children;
        private string buttonTextAlignStyle;
        private int zIndex;
        private TextSizeEnum textSize;
        private string textSizeStyle;
        private bool visible;
        private string visibleStyle;
        private string position;
        private string unit;
        private double labelWidth;
        private Color textColor;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of an ImageButton object
        /// </summary>
        public ImageButton()
        {
            // default
            Unit = "px";            
            Width = 200;
            Height = 200;
            Left = 0;
            Top = 0;
            ZIndex = 5;
            Visible = true;            
            ButtonTextAlign = "center";
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
                    ClickHandler(ButtonNumber, ButtonText);
                }
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

                // Update
                Refresh();
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region ButtonContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'ButtonContainerStyle'.
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
            
            #region ButtonText
            /// <summary>
            /// This property gets or sets the value for 'ButtonText'.
            /// </summary>
            [Parameter]
            public string ButtonText
            {
                get { return buttonText; }
                set { buttonText = value; }
            }
            #endregion
            
            #region ButtonTextAlign
            /// <summary>
            /// This property gets or sets the value for 'ButtonTextAlign'.
            /// </summary>
            [Parameter]
            public string ButtonTextAlign
            {
                get { return buttonTextAlign; }
                set { buttonTextAlign = value; }
            }
            #endregion
            
            #region ButtonTextAlignStyle
            /// <summary>
            /// This property gets or sets the value for 'ButtonTextAlignStyle'.
            /// </summary>
            public string ButtonTextAlignStyle
            {
                get { return buttonTextAlignStyle; }
                set { buttonTextAlignStyle = value; }
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
            
            #region ClickHandler
            /// <summary>
            /// This property gets or sets the value for 'ClickHandler'.
            /// </summary>
            public ButtonClickedHandler ClickHandler
            {
                get { return clickHandler; }
                set { clickHandler = value; }
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
                set 
                {
                    height = value;

                    heightStyle = height + "vh";
                }
            }
            #endregion
            
            #region HeightStyle
            /// <summary>
            /// This property gets or sets the value for 'HeightStyle'.
            /// </summary>
            public string HeightStyle
            {
                get { return heightStyle; }
                set { heightStyle = value; }
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
                set 
                { 
                    left = value;

                    // set the value for leftStyle
                    leftStyle = left + "%";
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
            
            #region TextSize
            /// <summary>
            /// This property gets or sets the value for 'TextSize'.
            /// </summary>
            [Parameter]
            public TextSizeEnum TextSize
            {
                get { return textSize; }
                set 
                { 
                    // set the value
                    textSize = value;

                    switch (value)
                    {
                        case TextSizeEnum.Extra_Small:

                            // Set the value
                            TextSizeStyle = .6 + "em";

                            // required
                            break;

                        case TextSizeEnum.Small:

                            // Set the value
                            TextSizeStyle = .8 + "em";

                            // required
                            break;

                        case TextSizeEnum.Medium:

                            // Set the value
                            TextSizeStyle = 1 + "em";

                            // required
                            break;

                        case TextSizeEnum.Large:

                            // Set the value
                            TextSizeStyle = 1.2 + "em";

                            // required
                            break;

                        case TextSizeEnum.Extra_Large:

                            // Set the value
                            TextSizeStyle = 1.4 + "em";

                            // required
                            break;
                    }
                }
            }
            #endregion
            
            #region TextSizeStyle
            /// <summary>
            /// This property gets or sets the value for 'TextSizeStyle'.
            /// </summary>
            public string TextSizeStyle
            {
                get { return textSizeStyle; }
                set { textSizeStyle = value; }
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
                    TopStyle = top + "vh";
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

                    // if true
                    if (visible)
                    {
                        // Default to inline block
                        VisibleStyle = "inline-block";
                    }
                    else
                    {
                        // Hide
                        VisibleStyle = "none";
                    }
                }
            }
            #endregion
            
            #region VisibleStyle
            /// <summary>
            /// This property gets or sets the value for 'VisibleStyle'.
            /// </summary>
            public string VisibleStyle
            {
                get { return visibleStyle; }
                set { visibleStyle = value; }
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
