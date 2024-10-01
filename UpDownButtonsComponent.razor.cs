

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.Blazor.Components.Interfaces;
using Microsoft.AspNetCore.Components;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class UpDownButtonsComponent
    /// <summary>
    /// This class is used to place to buttons, one for up and one for down stacked on top of each other.
    /// </summary>
    public partial class UpDownButtonsComponent : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private string buttonContainerStyle;
        private string buttonStyle;
        private List<IBlazorComponent> children;
        private string heightUnit;
        private string name;
        private IBlazorComponentParent parent;
        private string unit;
        private ImageButton upButton;
        private ImageButton downButton;
        private double buttonHeight;
        private double buttonWidth;
        private double gap;
        private double marginBottom;
        private string position;
        private double left;
        private double top;
        private double zIndex;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpDownButtonsComponent' object.
        /// </summary>
        public UpDownButtonsComponent()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region ButtonClicked(int buttonNumber, string buttonText)
            /// <summary>
            /// Button Clicked
            /// </summary>
            public void ButtonClicked(int buttonNumber, string buttonText)
            {
                // if the value for HasParent is true
                if (HasParent)
                {
                    // Create a new instance of a 'Message' object.
                    Message message = new Message();

                    // Set the sender
                    message.Sender = this;

                    // if UpButton
                    if (buttonNumber == 1)
                    {
                        // Set the text
                        message.Text = "Up Button was clicked";
                        
                    }
                    else if (buttonNumber == 2)
                    {
                        // Set the text
                        message.Text = "Down Button was clicked";
                    }

                    // Set the Id as the ButtonNumber
                    message.Id = buttonNumber;

                    // Send the message to the parent
                    Parent.ReceiveData(message);
                }
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default Units
                Unit = "px";
                HeightUnit = "px";

                // Default Size
                ButtonWidth = 16;
                ButtonHeight = 16;
                Position = "relative";
                Left = 0;
                Top = 0;
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
                // If this is an image button (only one on this component, so it will be)
                if (component is ImageButton)
                {
                    // if UpButton
                    if (component.Name == "UpButton")
                    {
                        // Store
                        UpButton = component as ImageButton;
                    }

                    // If DownButton
                    if (component.Name == "DownButton")
                    {
                        // Store
                        DownButton = component as ImageButton;
                    }
                }                
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
            
            #region ButtonHeightStyle
            /// <summary>
            /// This read only property returns the value of ButtonHeiight Plus Height Unit - Example 32px;
            /// </summary>
            public string ButtonHeightStyle
            {
                
                get
                {
                    // initial value
                    string buttonHeightStyle = ButtonHeight + HeightUnit;
                    
                    // return value
                    return buttonHeightStyle;
                }
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
            
            #region ButtonWidthStyle
            /// <summary>
            /// This read only property returns the value of ButtonWidth + Unit. Example 32px
            /// </summary>
            public string ButtonWidthStyle
            {
                
                get
                {
                    // initial value
                    string buttonWidthStyle = ButtonWidth + Unit;
                    
                    // return value
                    return buttonWidthStyle;
                }
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
                
            #region DownButton
            /// <summary>
            /// This property gets or sets the value for 'DownButton'.
            /// </summary>
            public ImageButton DownButton
            {
                get { return downButton; }
                set { downButton = value; }
            }
            #endregion
            
            #region Gap
            /// <summary>
            /// This property gets or sets the value for 'Gap'.
            /// </summary>
            [Parameter]
            public double Gap
            {
                get { return gap; }
                set { gap = value; }
            }
            #endregion
            
            #region GapStyle
            /// <summary>
            /// This read only property returns the value of GapStyle from the object Gap.
            /// </summary>
            public string GapStyle
            {
                
                get
                {
                    // initial value
                    string gapStyle = Gap + HeightUnit;
                    
                    // return value
                    return gapStyle;
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
                    // Set the value
                    parent = value;

                    // if the value for HasParent is true
                    if (HasParent)
                    {
                        // Register witht he parent
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
                
            #region UpButton
            /// <summary>
            /// This property gets or sets the value for 'UpButton'.
            /// </summary>
            public ImageButton UpButton
            {
                get { return upButton; }
                set { upButton = value; }
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
