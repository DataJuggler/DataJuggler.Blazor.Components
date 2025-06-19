

#region using statements

using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

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
        private Color listItemBackgroundColor;
        private double listItemHeight;
        private double listItemMarginBottom;
        private double listItemLeft;
        private string listItemPosition;
        private Color listItemTextColor;
        private double listItemTop;
        private double listItemWidth;
        private string listItemWidthStyle;
        private string name;
        private IBlazorComponentParent parent;
        private string position;
        private double fontSize;
        private double top;
        private string topStyle;
        private string unit;
        private bool visible;
        private int visibleCount;
        private double width;
        private int zIndex;        
        private string listItemClassName;
        private string fontUnit;
        private string className;
        private double labelWidth;
        private double checkBoxTextXPosition;
        private double checkBoxTextYPosition;
        private double checkBoxHeight;
        private double checkBoxWidth;
        private bool notifyParentOnBlur;        
        
        // reverting back to BlazorStyled
        private string checkedlistboxStyle;
        private string listitemStyle;
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
                        // is this a CheckBoxComponent
                        CheckBoxComponent checkBoxComponent = component as CheckBoxComponent;

                        // cast this item as a CheckBoxComponent
                        CheckBoxComponent itemCheckBoxComponent = item as CheckBoxComponent;

                        // If the checkBoxComponent and itemCheckBoxComponent objects both exist
                        if (NullHelper.Exists(checkBoxComponent, itemCheckBoxComponent))
                        {
                            // if the ExternalId's match
                            if ((checkBoxComponent.ExternalId == itemCheckBoxComponent.ExternalId) && (checkBoxComponent.ExternalId > 0))
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

            #region HandleOnBlur()
            /// <summary>
            /// method Handle Blur
            /// </summary>
            private void HandleOnBlur()
            {
                // if the value for NotifyParentOnBlur is true
                if ((HasParent) && (NotifyParentOnBlur))
                {
                    Message message = new Message();
                    message.Sender = this;
                    message.Text = "OnBlurFired";

                    // Notify the parent
                    parent.ReceiveData(message);
                }
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
                FontUnit = "px";
                FontSize = GlobalDefaults.LabelFontSize;
                
                // Set a default height
                ListItemHeight = 32;
                
                // Move over a little
                CheckBoxXPosition = .2;

                // Defaults
                CheckBoxHeight = 20;
                CheckBoxWidth = 20;
                CheckBoxTextXPosition = 3.2;
                CheckBoxTextYPosition = -3.2;
                Left = 0;
                Top = 0;
                Unit = "px";
                HeightUnit = "px";
                Height = 60;
                Width = GlobalDefaults.TextBoxWidth;
                Position = "relative";
                VisibleCount = 5;
                Items = new List<Item>();
                ListItemPosition = "relative";
                ListItemBackgroundColor = Color.White;
                listItemMarginBottom = 0;
                ListBackgroundColor = Color.White;
                ListItemClassName = "textdonotwrap";
                ZIndex = 40;
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
                try
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
                }
                catch (Exception error)
                {
                    DebugHelper.WriteDebugError("OnAfterRenderAsync", "CheckedListBox", error);
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

                                // if there is a parent
                                if (HasParent)
                                {
                                    // Notify the parent
                                    Parent.ReceiveData(message);
                                }
                            }
                        }
                        else
                        {
                            // Send a message to clear
                            message.Text = "Clear";

                            // Notify the parent
                            Parent.ReceiveData(message);
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
                if (component is CheckBoxComponent)
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
                // if the value for HasComboBoxParent is true
                if (HasComboBoxParent)
                {
                    Message message = new Message();
                    message.Sender = this;
                    message.Text = "SendItems";
                                
                    // send a message to the parent
                    ComboBoxParent.ReceiveData(message);
                }
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
                
            #region CheckBoxHeight
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxHeight'.
            /// </summary>
            [Parameter]
            public double CheckBoxHeight
            {
                get { return checkBoxHeight; }
                set { checkBoxHeight = value; }
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
            
            #region CheckBoxWidth
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxWidth'.
            /// </summary>
            [Parameter]
            public double CheckBoxWidth
            {
                get { return checkBoxWidth; }
                set { checkBoxWidth = value; }
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
                
            #region CheckedlistboxStyle
            /// <summary>
            /// This property gets or sets the value for 'CheckedlistboxStyle'.
            /// </summary>
            public string CheckedlistboxStyle
            {
                get { return checkedlistboxStyle; }
                set { checkedlistboxStyle = value; }
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
                
            #region LabelWidth
            /// <summary>
            /// This property gets or sets the value for 'LabelWidth'.
            /// </summary>
            [Parameter]
            public double LabelWidth
            {
                get { return labelWidth; }
                set { labelWidth = value; }
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

            #region ListItemBackgroundColor
            /// <summary>
            /// This property gets or sets the value for 'ListItemBackgroundColor'.
            /// </summary>
            [Parameter]
            public Color ListItemBackgroundColor
            {
                get { return listItemBackgroundColor; }
                set { listItemBackgroundColor = value; }
            }
            #endregion

            #region ListItemBackgroundColorName
            /// <summary>
            /// This read only property returns the value of listItemBackgroundColor from the object ListBackgroundColor.
            /// </summary>
            public string ListItemBackgroundColorName
            {
                    
                get
                {
                    // initial value
                    string listBackgroundColorName = listItemBackgroundColor.Name;
                        
                    // return value
                    return listBackgroundColorName;
                }
            }
            #endregion
            
            #region ListItemClassName
            /// <summary>
            /// This property gets or sets the value for 'ListItemClassName'.
            /// </summary>
            [Parameter]
            public string ListItemClassName
            {
                get { return listItemClassName; }
                set { listItemClassName = value; }
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

             #region ListItemMarginBottom
            /// <summary>
            /// This property gets or sets the value for 'ListItemMarginBottom'.
            /// </summary>
            [Parameter]
            public double ListItemMarginBottom
            {
                get { return listItemMarginBottom; }
                set { listItemMarginBottom = value; }
            }
            #endregion
            
            #region ListItemMarginBottomStyle
            /// <summary>
            /// This read only property returns the value of ListItemMarginBottomStyle from the object ListItemMarginBottom.
            /// </summary>
            public string ListItemMarginBottomStyle
            {

                get
                {
                    // initial value
                    string listItemMarginBottomStyle = ListItemMarginBottom + HeightUnit;
                    
                    // return value
                    return listItemMarginBottomStyle;
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
            
            #region ListitemStyle
            /// <summary>
            /// This property gets or sets the value for 'ListitemStyle'.
            /// </summary>
            public string ListitemStyle
            {
                get { return listitemStyle; }
                set { listitemStyle = value; }
            }
            #endregion
            
            #region ListItemTextColor
            /// <summary>
            /// This property gets or sets the value for 'ListItemTextColor'.
            /// </summary>
            [Parameter]
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
                
            #region NotifyParentOnBlur
            /// <summary>
            /// This property gets or sets the value for 'NotifyParentOnBlur'.
            /// </summary>
            [Parameter]
            public bool NotifyParentOnBlur
            {
                get { return notifyParentOnBlur; }
                set { notifyParentOnBlur = value; }
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
                            // get the CheckBoxComponent
                            CheckBoxComponent checkBox = component as CheckBoxComponent;
                                
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
                        DisplayStyle = "block";
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
