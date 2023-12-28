

#region using statements

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.Cryptography;
using DataJuggler.NET8.Delegates;
using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using Microsoft.AspNetCore.Components;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class CheckedListBox
    /// <summary>
    /// This class is a work in progress.
    /// </summary>
    public partial class CheckedListBox : IBlazorComponentParent, IBlazorComponent
    {
        
        #region Private Variables
        private double checkBoxXPosition;
        private double checkBoxYPosition;
        private string checkedListBoxStyle;
        private List<IBlazorComponent> children;
        private string displayStyle;
        private double height;
        private string heightStyle;
        private string heightUnit;
        private List<Item> items;
        private string labelText;
        private double left;
        private string leftStyle;
        private Color listBackgroundColor;
        private double listItemHeight;
        private double listItemLeft;
        private string listItemPosition;
        private string listItemStyle;
        private Color listItemTextColor;
        private double listItemTop;
        private double listItemWidth;
        private string listItemWidthStyle;
        private string name;
        private IBlazorComponentParent parent;
        private string position;
        private TextSizeEnum textSize;
        private string textSizeStyle;
        private double top;
        private string topStyle;
        private string unit;
        private bool visible;
        private int visibleCount;
        private double width;
        private int zIndex;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CheckedListBox' object.
        /// </summary>
        public CheckedListBox()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Methods
            
            #region CheckIfComponentIsRegistered(IBlazorComponent component)
            /// <summary>
            /// returns the If Component Is Registered
            /// </summary>
            public bool CheckIfComponentIsRegistered(IBlazorComponent component)
            {
                // initial value (default to false)
                bool isComponentRegistered = false;

                // if the value for HasChildren is true
                if (HasChildren)
                {
                    // Iterate the collection of IBlazorComponent objects
                    foreach (IBlazorComponent item in Children)
                    {
                        // is this a validationComponent
                        ValidationComponent validationComponent = component as ValidationComponent;

                        // cast this item as a 
                        ValidationComponent itemValidationComponent = item as ValidationComponent;

                        // If the validationComponent object exists
                        if (NullHelper.Exists(validationComponent, itemValidationComponent))
                        {
                            // if the ExternalId's match
                            if ((validationComponent.ExternalId == itemValidationComponent.ExternalId) && (validationComponent.ExternalId > 0))
                            {
                                // set the return value
                                isComponentRegistered = true;

                                // break out of the loop
                                break;
                            }
                        }
                    }
                }
                
                // return value
                return isComponentRegistered;
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // not sure if this is used, but interface requires it
                return ComponentHelper.FindChildByName(Children, name);
            }
            #endregion
            
            #region FindItemById(int id)
            /// <summary>
            /// returns the Item By Id
            /// </summary>
            public Item FindItemById(int id)
            {
                // initial value
                Item item = null;
                
                // if the value for HasItems is true
                if (HasItems)
                {
                    // Iterate the collection of Item objects
                    foreach (Item temp in Items)
                    {
                        // if this is the item being sought
                        if (temp.Id == id)
                        {
                            // set the return value
                            item = temp;

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return item;
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // default to visible
                Visible = true;
                
                // Create a new collection of 'IBlazorComponent' objects.
                Children = new List<IBlazorComponent>();
                
                // Set the Unit and HeightUnit defaults
                Unit = "px";
                HeightUnit = "px";

                // Set a default height
                ListItemHeight = 32;
                
                // Move the checkbox down a little
                CheckBoxYPosition = .2;
                
                // Set the default width
                Width = 120;
                
                // Default to 30% for the lable, the rest goes to the ComboBox                
                TextSize = TextSizeEnum.Medium;
                Left = 0;
                Top = 0;
                Unit = "px";
                HeightUnit = "px";
                Height = 60;
                Width = 120;
                Position = "relative";
                VisibleCount = 5;
                Items = new List<Item>();
                ListItemPosition = "relative";
            }
            #endregion

            #region OnAfterRenderAsync(bool firstRender)
            /// <summary>
            /// This method is used to verify a user
            /// </summary>
            /// <param name="firstRender"></param>
            /// <returns></returns>
            protected async override Task OnAfterRenderAsync(bool firstRender)
            {
                // if the Items do not exist for some reason
                if (!ListHelper.HasOneOrMoreItems(Items))
                {
                    // Request Items be sent
                    RequestItems();

                    // if now there are more than one
                    if (ListHelper.HasOneOrMoreItems(Items))
                    {
                        // Update the 
                        Refresh();
                    }
                }

                // call the base
                await base.OnAfterRenderAsync(firstRender);
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // If the message object exists
                if (NullHelper.Exists(message))
                {
                    // if a checkbox was checked
                    if (message.Text == "ItemSelected")
                    {
                        // if the value for HasItems is true
                        if (ListHelper.HasOneOrMoreItems(Items))
                        {
                            // find this item
                            Item item = FindItemById(message.Id);

                            // if the item was found
                            if (NullHelper.Exists(item))
                            {
                                // store
                                item.ItemChecked = message.CheckedValue;
                            }
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
            /// method returns the
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                if (component is ValidationComponent)
                {   
                    // check if this component is already registered
                    bool isComponentRegistered = CheckIfComponentIsRegistered(component);

                    // if the value for isComponentRegistered is false
                    if (!isComponentRegistered)
                    {
                        // Add to the list
                        Children.Add(component);
                    }
                }                
            }
            #endregion
                
            #region RequestItems()
            /// <summary>
            /// Request Items
            /// </summary>
            public void RequestItems()
            {
                Message message = new Message();
                message.Sender = this;
                message.Text = "SendItems";
                                
                // send a message to the parent
                ComboBoxParent.ReceiveData(message);
            }
            #endregion
            
            #region SetItems(List<Item> items, bool refresh = true)
            /// <summary>
            /// Set Items
            /// </summary>
            public void SetItems(List<Item> items, bool refresh = true)
            {
                // store
                Items = items;

                // Set the value for the property 'Visible' to true
                Visible = true;
                 
                // if the value for refresh is true
                if (refresh)
                {
                    // update the UI
                    Refresh();
                }
            }
            #endregion
                
            #region SetVisible(bool visible)
            /// <summary>
            /// Set Visible
            /// </summary>
            public void SetVisible(bool visible)
            {
                // set the value
                Visible = visible;
            }
            #endregion
            
        #endregion
            
        #region Properties
                
            #region CheckBoxXPosition
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxXPosition'.
            /// </summary>
            [Parameter]
            public double CheckBoxXPosition
            {
                get { return checkBoxXPosition; }
                set { checkBoxXPosition = value; }
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
                set { checkBoxYPosition = value; }
            }
            #endregion
                
            #region CheckedListBoxStyle
            /// <summary>
            /// This property gets or sets the value for 'CheckedListBoxStyle'.
            /// </summary>
            public string CheckedListBoxStyle
            {
                get { return checkedListBoxStyle; }
                set { checkedListBoxStyle = value; }
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
                
            #region ComboBox
            /// <summary>
            /// This read only property returns the value of ComboBox from the object Parent.
            /// </summary>
            public ComboBox ComboBox
            {
                    
                get
                {
                    // initial value
                    ComboBox comboBox = null;
                        
                    // if Parent exists
                    if (Parent != null)
                    {
                        // set the return value
                        comboBox = Parent as ComboBox;
                    }
                        
                    // return value
                    return comboBox;
                }
            }
            #endregion
                
            #region ComboBoxParent
            /// <summary>
            /// This read only property returns the value of ComboBoxParent from the object Parent.
            /// </summary>
            public IBlazorComponent ComboBoxParent
            {
                    
                get
                {
                    // initial value
                    IBlazorComponent comboBoxParent = null;
                        
                    // if Parent exists
                    if (Parent != null)
                    {
                        // set the return value
                        comboBoxParent = Parent as IBlazorComponent;
                    }
                        
                    // return value
                    return comboBoxParent;
                }
            }
            #endregion
                
            #region DisplayStyle
            /// <summary>
            /// This property gets or sets the value for 'DisplayStyle'.
            /// </summary>
            public string DisplayStyle
            {
                get { return displayStyle; }
                set { displayStyle = value; }
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
                
            #region HasComboBoxParent
            /// <summary>
            /// This property returns true if this object has a 'ComboBoxParent'.
            /// </summary>
            public bool HasComboBoxParent
            {
                get
                {
                    // initial value
                    bool hasComboBoxParent = (this.ComboBoxParent != null);
                        
                    // return value
                    return hasComboBoxParent;
                }
            }
            #endregion
                
            #region HasItems
            /// <summary>
            /// This property returns true if this object has an 'Items'.
            /// </summary>
            public bool HasItems
            {
                get
                {
                    // initial value
                    bool hasItems = (this.Items != null);
                        
                    // return value
                    return hasItems;
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
                        
                    // Set the height headerStyle string
                    HeightStyle = height + HeightUnit;
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
                
            #region Items
            /// <summary>
            /// This property gets or sets the value for 'Items'.
            /// </summary>
            [Parameter]
            public List<Item> Items
            {
                get { return items; }
                set { items = value; }
            }
            #endregion
                
            #region LabelText
            /// <summary>
            /// This property gets or sets the value for 'LabelText'.
            /// </summary>
            public string LabelText
            {
                get { return labelText; }
                set { labelText = value; }
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
                
            #region ListBackgroundColor
            /// <summary>
            /// This property gets or sets the value for 'ListBackgroundColor'.
            /// </summary>
            [Parameter]
            public Color ListBackgroundColor
            {
                get { return listBackgroundColor; }
                set { listBackgroundColor = value; }
            }
            #endregion

            #region ListBackgroundColorName
            /// <summary>
            /// This read only property returns the value of ListBackgroundColorName from the object ListBackgroundColor.
            /// </summary>
            public string ListBackgroundColorName
            {
                    
                get
                {
                    // initial value
                    string listBackgroundColorName = ListBackgroundColor.Name;
                        
                    // return value
                    return listBackgroundColorName;
                }
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
                set { listItemHeight = value; }
            }
            #endregion
            
            #region ListItemHeightStyle
            /// <summary>
            /// This read only property returns the value of ListItemHeightStyle from the object ListItemHeight.
            /// </summary>
            public string ListItemHeightStyle
            {
                
                get
                {
                    // initial value
                    string listItemHeightStyle = ListItemHeight + HeightUnit;
                    
                    // return value
                    return listItemHeightStyle;
                }
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
                    string listItemLeftStyle = ListItemLeft + unit;
                        
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

            #region ListItemTextColor
            /// <summary>
            /// This property gets or sets the value for 'ListItemTextColor'.
            /// </summary>
            public Color ListItemTextColor
            {
                get { return listItemTextColor; }
                set { listItemTextColor = value; }
            }
            #endregion

            #region ListItemTextColorName
            /// <summary>
            /// This read only property returns the value of ListItemTextColorName from the object ListItemTextColor.
            /// </summary>
            public string ListItemTextColorName
            {
                    
                get
                {
                    // initial value
                    string listItemTextColorName = ListItemTextColor.Name;
                        
                    // return value
                    return listItemTextColorName;
                }
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
                    string listItemTopStyle = ListItemTop + HeightUnit;
                        
                    // return value
                    return listItemTopStyle;
                }
            }
            #endregion
            
            #region ListItemWidth
            /// <summary>
            /// This property gets or sets the value for 'ListItemWidth'.
            /// </summary>
            [Parameter]
            public double ListItemWidth
            {
                get { return listItemWidth; }
                set
                {
                    listItemWidth = value;
                        
                    // Set the value
                    ListItemWidthStyle = listItemWidth + Unit;
                }
            }
            #endregion
                
            #region ListItemWidthStyle
            /// <summary>
            /// This property gets or sets the value for 'ListItemWidthStyle'.
            /// </summary>
            public string ListItemWidthStyle
            {
                get { return listItemWidthStyle; }
                set { listItemWidthStyle = value; }
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
                        
                    // If the parent object exists
                    if (HasParent)
                    {
                        // register with the parent
                        parent.Register(this);
                            
                        // if the value for HasComboBoxParent is true
                        if (HasComboBoxParent)
                        {
                            // Notify the parent we might be empty
                            RequestItems();
                                
                            // if the value for HasItems is true
                            if (HasItems)
                            {
                                // Refresh
                                Refresh();
                            }
                        }
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
                
            #region SelectedItems
            /// <summary>
            /// This property gets or sets the value for 'SelectedItems'.
            /// </summary>
            public List<Item> SelectedItems
            {
                get
                {
                    // Create a new collection of 'Item' objects.
                    List<Item> selectedItems = new List<Item>();
                        
                    // if the value for HasChildren is true
                    if (HasChildren)
                    {
                        // Iterate the collection of IBlazorComponent objects
                        foreach (IBlazorComponent component in Children)
                        {
                            // get the ValidationComponent
                            ValidationComponent checkBox = component as ValidationComponent;
                                
                            // If the checkBox object exists
                            if (NullHelper.Exists(checkBox))
                            {
                                // if checked
                                if (checkBox.CheckBoxValue)
                                {
                                    // Set the values
                                    Item item = new Item();
                                    item.Id = checkBox.ExternalId;
                                    item.Name = checkBox.Name;
                                    item.Text = checkBox.Text;
                                    item.ItemChecked = true;
                                        
                                    // Add this item
                                    selectedItems.Add(item);
                                }
                            }
                        }
                    }
                        
                    // return value
                    return selectedItems;
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
                            
                        case TextSizeEnum.SmallMedium:
                            
                        // Set the value
                        TextSizeStyle = .9 + "em";
                            
                        // required
                        break;
                            
                        case TextSizeEnum.Medium:
                            
                        // Set the value
                        TextSizeStyle = 1 + "em";
                            
                        // required
                        break;
                            
                        case TextSizeEnum.MediumLarge:
                            
                        // Set the value
                        TextSizeStyle = 1.1 + "em";
                            
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
                set {unit = value;}
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
                        
                    // if visible
                    if (visible)
                    {
                        DisplayStyle = "inline-block";
                    }
                    else
                    {
                        DisplayStyle = "none";
                    }
                }
            }
            #endregion
                
            #region VisibleCount
            /// <summary>
            /// This property gets or sets the value for 'VisibleCount'.
            /// </summary>
            [Parameter]
            public int VisibleCount
            {
                get { return visibleCount; }
                set { visibleCount = value; }
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
                    // set the value
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
