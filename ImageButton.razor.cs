

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using DataJuggler.Blazor.Components.Enumerations;

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
        private string widthStyle;
        private string buttonTextAlign;
        private IBlazorComponentParent parent;
        private ButtonClickedHandler clickHandler;
        private List<IBlazorComponent> children;
        private string buttonTextAlignStyle;
        private int zIndex;
        private TextSizeEnum textSize;
        private string textSizeStyle;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of an ImageButton object
        /// </summary>
        public ImageButton()
        {
            // default
            Width = 100;
            Height = 100;
            Left = 0;
            Top = 0;
            ZIndex = 5;
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
                            TextSizeStyle = 1.2 + "vh";

                            // required
                            break;

                        case TextSizeEnum.Small:

                            // Set the value
                            TextSizeStyle = 1.5 + "vh";

                            // required
                            break;

                        case TextSizeEnum.Medium:

                            // Set the value
                            TextSizeStyle = 1.8 + "vh";

                            // required
                            break;

                        case TextSizeEnum.Large:

                            // Set the value
                            TextSizeStyle = 2.1 + "vh";

                            // required
                            break;

                        case TextSizeEnum.Extra_Large:

                            // Set the value
                            TextSizeStyle = 2.4 + "vh";

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

                    // set the string 
                    widthStyle = width + "%";
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
