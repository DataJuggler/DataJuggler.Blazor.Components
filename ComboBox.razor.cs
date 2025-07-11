﻿

#region using statements

using DataJuggler.Blazor.Components.Delegates;
using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class ComboBox
    /// <summary>
    /// This class is designed to make a DropDownList easier to work with.
    /// </summary>
    public partial class ComboBox : ComponentBase, IBlazorComponent, IBlazorComponentParent, ILabelFont, ITextBoxFont
    {
        
        #region Private Variables
        private Color buttonBorderColor;
        private double buttonBorderWidth;
        private double buttonLeft;
        private string buttonPosition;
        private double buttonTop;
        private string selectedText;        
        private string buttonUrl;
        private CheckedListBox checkedListComponent;
        private bool checkListMode;
        private List<IBlazorComponent> children;
        private string className;
        private string display;
        private string listDisplay;
        private ImageButton button;        
        private bool expanded;        
        private double height;
        private string heightStyle;
        private string heightUnit;
        private string imagePath;
        private bool initialized;
        private List<Item> items;
        private List<Item> storedSelectedItems;
        private string labelBackColor;
        private string labelClassName;        
        private Color labelColor;
        private double labelLeft;
        private double labelMarginRight;
        private double labelMarginRightList;
        private string labelMarginRightListStyle;
        private string labelMarginRightStyle;
        private string labelPosition;
        private string labelText;
        private double labelTop;
        private double labelWidth;
        private double left;
        private string leftStyle;
        private Color listBackgroundColor;
        private double listBorderWidth;
        private string listContainerPosition;
        private double listItemHeight;
        private string listItemClassName;
        private double listItemLeft;        
        private string listItemPosition;
        private Color listItemTextColor;
        private Color listItemBackgroundColor;
        private double listItemTop;
        private double listItemWidth;        
        private string listItemWidthStyle;
        private string name;
        private bool notifyParentOnBlur;
        private IBlazorComponentParent parent;
        private string position;
        private Item selectedItem;
        private string textAlign;        
        private ThemeEnum theme;
        private double top;
        private string topStyle;
        private string unit;        
        private int visibleCount;
        private double width;
        private int zIndex;
        private string listItemHeightStyle;
        private double checkedListheight;
        private double checkedListWidth;
        private double labelFontSize;        
        private string labelFontSizeUnit;
        private string labelFontName;
        private double textBoxWidth;
        private double column1Width;
        private double column2Width;
        private double buttonWidth;
        private double buttonHeight;
        private TextBoxComponent textBox;
        private double textBoxLeft;
        private double textBoxTop;
        private string filterText;
        private int filterIndex;
        private double fontSize;
        private string fontUnit;
        private double checkedListLeft;
        private double checkedListTop;
        private string checkedListClassName;
        private double checkBoxTextX;
        private double checkBoxTextY;        
        private string checkedListPosition;
        private string checkedListUnit;
        private string checkedListHeightUnit;
        private double textBoxHeight;
        private string labelUnit;
        private double checkBoxX;
        private double checkBoxY;
        private string containerStyle;
        private double controlWidth;
        private double controlHeight;
        private string dropdownClassName;
        private double textBoxFontSize;
        private string textBoxFontName;
        private string fontName;
        private bool showButton;
        private int dropDownZIndex;
        private string overflowX;
        private string overflowY;
        private bool loaded;
        
        // Had to bring back BlazorStyled        
        private string listItemContainer;
        private string listItemStyle;
        private string buttonStyle;
        private string checkedListBoxStyle;
        private double checkedListItemLeft;
        private double checkedListItemTop;
        private string listContainerStyle;
        private double listContainerLeft;
        private double listContainerTop;
        private double listItemMarginBottom;
        private double checkBoxHeight;
        private double checkBoxWidth;
        private double listContainerHeight;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a ComboBox object
        /// </summary>
        public ComboBox()
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
                // if the TextSize button was clicked
                if ((buttonNumber == 1) && (HasButton))
                {
                    // Store the selections (checked boxes) before hiding
                    StoreSelections();

                    // Set the value for expanded or not
                    Expanded = !Expanded;
                }
                
                // Update the UI
                Refresh();
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
                if (firstRender)
                {
                    // These values need to be set after Parameters have been set

                    // if not set as a Parameter
                    if (ListItemWidth == 0)
                    {
                        // Set the default Width
                        ListItemWidth = GlobalDefaults.TextBoxWidth;
                    }

                    // if not set as a parameter
                    if (ListContainerLeft == 0)
                    {
                        if (CheckListMode)
                        {
                            // Set default
                            ListContainerLeft = Column1Width;
                        }
                        else
                        {
                            // Set default
                            ListContainerLeft = Column1Width + 20;
                        }
                    }

                    // Set to False
                    Expanded = false;                    
                }

                // call the base
                await base.OnAfterRenderAsync(firstRender);
            }
            #endregion
            
            #region SelectionChanged(ChangeEventArgs selectedItem)
            /// <summary>
            /// event is fired when On Change
            /// </summary>
            public void SelectionChanged(ChangeEventArgs selectedItem)
            {
                // Set the selectedItem
                SelectedText = selectedItem.Value.ToString();
                
                // Set the SelectedItem
                SetSelectedItem(SelectedText, false);
                
                // if the Parent exists
                if (HasParent)
                {
                    // Create a new instance of a 'Message' object.
                    Message message = new Message();
                    
                    // Notify the parent
                    message.Text = SelectedText;
                    
                    // Set who the message is from
                    message.Sender = this;
                    
                    // Send the parent a message the selection changed
                    Parent.ReceiveData(message);
                }
                
                // No longer expanded
                Expanded = false;
                
                // Update everything
                Refresh();
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region DisplaySelections()
            /// <summary>
            /// Display Selections
            /// </summary>
            public void DisplaySelections()
            {
                // If the CheckedListComponent exists and the TextBox exists
                if ((HasCheckedListComponent) && (HasTextBox))
                {
                    // Get the Selected Items
                    List<Item> selectedItems = CheckedListComponent.SelectedItems;

                    // Dislay the selected items
                    DisplaySelections(selectedItems);
                }
                else if ((HasTextBox) && (HasStoredSelectedItems))
                {
                    // Dislay the selected items
                    DisplaySelections(StoredSelectedItems);
                }
            }
            #endregion

            #region DisplaySelections(List<Item> selectedItems)
            /// <summary>
            /// This method displays the SelectedItems
            /// </summary>
            /// <param name="selectedItems"></param>
            public void DisplaySelections(List<Item> selectedItems)
            {
                // Initial value
                string selectedText = "";

                // if the TextBox exists and there are one or more selectedItems
                if (HasTextBox)
                {
                    // If the selectedItems collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(selectedItems))
                    {
                        // Set Loading to true
                        TextBox.Loading = true;

                        // Create a new instance of a 'StringBuilder' object.
                        StringBuilder sb = new StringBuilder();

                        // Iterate the collection of Item objects
                        foreach(Item item in selectedItems)
                        {
                            // if checked
                            if (item.ItemChecked)
                            {
                                // Append the Item and a semicolon separator
                                sb.Append(item.Text);
                                sb.Append(';');
                            }
                        }

                        // Set the selected Text
                        selectedText = sb.ToString();
                    }

                     // Set the SelecctedText
                    TextBox.SetTextValue(selectedText);

                    // Update
                    TextBox.Refresh();

                    // Set Loading to false
                    TextBox.Loading = false;
                }
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // initial value
                IBlazorComponent child = null;
                
                // if the value for HasChildren is true
                if (HasChildren)
                {
                    foreach (IBlazorComponent tempChild in Children)
                    {
                        // if this is the item being sought
                        if (TextHelper.IsEqual(tempChild.Name, name))
                        {
                            // set the return value
                            child = tempChild;
                            
                            // break out of loop
                            break;
                        }
                    }
                }
                
                // return value
                return child;
            }
            #endregion
            
            #region GetCountItemsWithFilter()
            /// <summary>
            /// returns the Count Items With Filter
            /// </summary>
            public int GetCountItemsWithFilter()
            {
                // initial value
                int count = 0;

                if ((HasItems) && (HasFilterText))
                {
                    // Get the items
                    List<Item> items = Items.Where(x => x.Text.StartsWith(FilterText)).ToList();
                    
                    // If the items collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(items))
                    {
                        // Get the count
                        count = items.Count;
                    }
                }
                
                // return value
                return count;
            }
            #endregion

            #region HandleOnBlur()
            /// <summary>
            /// Handle On Blur
            /// </summary>
            public void HandleOnBlur()
            {
                // if the value for Expanded is true
                if ((Expanded) && (HasButton) && (Button.HasClickHandler))
                {
                    // Call the ClickHander
                    Button.ClickHandler(1, "");
                }
            }
            #endregion
            
            #region Hide(bool refresh = true)
            /// <summary>
            /// Hide
            /// </summary>
            public void Hide(bool refresh = true)
            {
                // Set the value
                Display = "none";

                // if the value for refresh is true
                if (refresh)
                {
                    // Update the UI
                    Refresh();
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default to blueGold now
                Theme = ThemeEnum.BlueGold;
    
                // Units First
                Unit = "px";
                LabelUnit = "px";
                HeightUnit = "px";
                CheckedListUnit = "px";
                CheckedListHeightUnit = "px";
                ButtonBorderColor = Color.Black;
                ButtonBorderWidth = 1;
                ButtonHeight = 24;
                ButtonLeft = 8;
                ButtonPosition = "relative";
                ButtonTop = 0;
                ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBoxBlack.png";
                ButtonWidth = 24;
                CheckBoxHeight = 16;
                CheckBoxWidth = 16;
                CheckBoxTextX = 16;
                CheckBoxTextY = 0;
                CheckBoxX = 0;
                CheckBoxY = 2;
                CheckedListClassName = "container border1gray textdonotwrap";
                CheckedListItemLeft = 8;
                CheckedListItemTop = 0;
                CheckedListheight = 72;
                CheckedListLeft = 36;
                CheckedListPosition = "absolute";                
                CheckedListTop = 24;
                CheckedListWidth = 132;                
                Children = new List<IBlazorComponent>();                
                Column1Width = GlobalDefaults.Column1Width;
                Column2Width = GlobalDefaults.Column2Width;
                ControlHeight = 28;
                Display = "inline-block";
                DropdownClassName = "combobox-container border1gray textdonotwrap";
                DropDownZIndex = GlobalDefaults.ListZIndex;
                FontSize = GlobalDefaults.TextBoxFontSize;
                FontUnit = "px";
                Height = 24; 
                Items = new List<Item>();
                LabelBackColor = "transparent";
                LabelColor = Color.LightSkyBlue;
                LabelClassName = GlobalDefaults.LabelClassName;
                LabelFontName = "Calibri"; 
                LabelFontSize = GlobalDefaults.LabelFontSize;
                LabelMarginRight = 0;
                LabelMarginRightList = 0;
                LabelPosition = "relative";
                Left = 0;
                ListBackgroundColor = Color.White;
                ListContainerLeft = 36;
                ListContainerTop = 1;
                ListContainerPosition = "absolute";
                ListDisplay = "none";
                ListItemBackgroundColor = Color.White;                
                ListContainerHeight = 120;
                ListItemHeight = GlobalDefaults.ListItemHeight;            
                ListItemLeft = -12;
                ListItemPosition = "relative";
                ListItemTop = -2;
                ListItemWidth = 80;
                OverflowX = "hidden";
                OverflowY = "auto";
                Position = "relative";
                SelectedText = "";
                ShowButton = true;
                TextAlign = "center";
                TextBoxFontName = GlobalDefaults.TextBoxFontName;
                TextBoxFontSize = GlobalDefaults.TextBoxFontSize;
                TextBoxHeight = 21;
                TextBoxLeft = 0;
                TextBoxWidth = GlobalDefaults.TextBoxWidth;
                Top = 2;
                VisibleCount = 5;
                Width = 224;
                ZIndex = GlobalDefaults.ZIndex;
                
                // Set so the image is set (its gets unExpanded)
                Expanded = true;
            }
            #endregion
            
            #region LoadItems(List<T> items, bool addEmptyRowAtTop = false)
            /// <summary>
            /// This method loads a list of any type
            /// </summary>
            public void LoadItems<T>(List<T> items, bool addEmptyRowAtTop = false)
            {
                // clear the list
                this.Items = new List<Item>();
                
                // if the list exists
                if ((items != null) && (items.Count > 0))
                {
                    // if addEmptyRowAtTop is true
                    if (addEmptyRowAtTop)
                    {
                        // Add the empty item
                        Item item = new Item();
                        item.Text = "";
                        item.Id = 0;
                        
                        // Add this item
                        Items.Add(item);
                    }
                    
                    // iterate the list
                    foreach (object tempItem in items)
                    {
                        Item item = new Item();
                        item.Text = tempItem.ToString();
                        item.Id = Items.Count + 1;
                        Items.Add(item);
                    }
                    
                    // if not checkListMode
                    if (!CheckListMode)
                    {
                        // Select the first item
                        SelectedItem = Items[0];
                    }

                    // Has been Loaded
                    Loaded = true;
                    
                    // Update Async
                    Refresh();
                }
            }
            #endregion
            
            #region LoadItems(Type enumType)
            /// <summary>
            /// This method loads a combobox with the enum values
            /// </summary>
            public void LoadItems(Type enumType)
            {
                // locals
                string[] names = null;
                Array values = null;
                int index = -1;
                string formattedName = "";
                
                // clear the list
                this.Items = new List<Item>();
                
                // verifyh the object is an emum
                if (enumType.IsEnum)
                {
                    // get the names from the enum
                    names = Enum.GetNames(enumType);
                    values = Enum.GetValues(enumType);
                    
                    // if there are one or more names
                    if ((names != null) && (names.Length > 0) && (values != null) && (values.Length == names.Length))
                    {
                        // iterate the names
                        foreach (string name in names)
                        {
                            // increment index
                            index++;
                            
                            // Get the int value of the enum
                            int id = (int) values.GetValue(index);
                                                        
                            // replace out any underscores with spaces
                            formattedName = name.Replace("_", " ");
                            
                            // Create the item
                            Item item = new Item();
                            
                            // Get the value
                            item.Id = id;
                            
                            // Set the name with any underscores out
                            item.Text = formattedName;
                            
                            // add this item
                            this.Items.Add(item);
                        }

                        // Has been Loaded
                        Loaded = true;
                        
                        // Update Async
                        Refresh();
                    }
                }
            }
            #endregion
            
            #region OnTextChanged(string text)
            /// <summary>
            /// On Text Changed
            /// </summary>
            public void OnTextChanged(string text)
            {
                if (TextHelper.Exists(text))
                {
                    // the text was set to blank
                    DisplaySelections();
                }
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // If the 'message' object 
                if (NullHelper.Exists(message))
                {
                    // if it is the CheckedListBox
                    if ((message.Text == "SendItems") && (HasCheckedListComponent))
                    {  
                        // set the items
                        CheckedListComponent.SetItems(Items);
                    }
                    // if a checkbox was checked
                    else if ((message.Text == "ItemSelected") && (CheckListMode))
                    {
                        // Display Selections
                        DisplaySelections();                        
                    }
                    else if (message.Text.Contains("OnBlurFired"))
                    {
                        // Handle the Blur
                        HandleOnBlur();
                    }
                    else if (message.Text.Contains("text"))
                    {
                        // get the key pressed
                        string keyPressed = message.Text.Replace("text: Key", "");

                        // Filter the list of items
                        if (TextHelper.Exists(FilterText))
                        {
                            // if the FilterText matches
                            if (FilterText == keyPressed)
                            {
                                // Check if in range for this filter group
                                FilterIndex++;

                                // Check if in range for this filter group
                                int itemsWithThisFilter = GetCountItemsWithFilter();

                                // if the FilterIndex
                                if (FilterIndex >= itemsWithThisFilter)
                                {
                                    // Reset                                    
                                    FilterIndex = 0;
                                }
                            }
                            else
                            {
                                // Set the FilterText
                                FilterText = keyPressed;

                                // Select the first item
                                FilterIndex = 0;
                            }
                        }
                        else
                        {
                            // Use this as the Filter
                            FilterText = keyPressed;

                            // Select the first item
                            FilterIndex = 0;
                        }

                        // if there are enough items
                        if (ListHelper.HasXOrMoreItems(FilteredItems, FilterIndex + 1))
                        {
                            // Set the Selected Item
                            SelectedItem = FilteredItems[FilterIndex];

                            // if the SelectedItem exists
                            if (HasSelectedItem)
                            {
                                // Set the Selected Text
                                SetSelectedText(SelectedItem.Text);

                                // if the SelectedText exists
                                if ((HasSelectedText) && (HasItems))
                                {
                                    // find the index
                                    int index = ItemHelper.FindItemIndexByText(Items, SelectedText);

                                    // if found
                                    if (index >= 0)
                                    {
                                        // Set the selected index
                                        SelectedItem = Items[index];
                                    }
                                }
                            }
                        }

                        // Update the UI
                        Refresh();
                    }                   
                    else
                    {
                        // Refresh
                        Refresh();
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
            /// method registers the ComboBoxButton
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                // Add this item
                this.Children.Add(component);
                    
                // if this is the Button registering
                if (component is ImageButton)
                {
                    // Store the ComboBoxButton
                    Button = component as ImageButton;
                        
                    // if the value for HasComboBoxButton is true
                    if (HasButton)
                    {
                        // Setup the click handler
                        Button.SetClickHandler(ButtonClicked);
                    }
                }
                else if (component is TextBoxComponent)
                {
                    // Store the TextBox
                    TextBox = component as TextBoxComponent;

                    // if the value for HasStoredSelectedItems is true
                    if (HasStoredSelectedItems)
                    {
                        // Display the Selections
                        DisplaySelections(StoredSelectedItems);
                    }
                }
                else if (component is CheckedListBox)
                {
                    // store
                    CheckedListComponent = component as CheckedListBox;

                    // if the value for HasCheckedListComponent is true
                    if (HasCheckedListComponent)
                    {
                        // Set the Items
                        CheckedListComponent.SetItems(Items);

                        // if the value for HasStoredSelectedItems is true
                        if (HasStoredSelectedItems)
                        {
                            // Now set the SelectedItems
                            SetSelectedItems(StoredSelectedItems);

                            // erase
                            StoredSelectedItems = null;
                        }
                    }
                }
            }
            #endregion
                
            #region SetComboBoxText(string text)
            /// <summary>
            /// Set Combo Box Text
            /// </summary>
            public void SetComboBoxText(string text)
            {
                // if the value for HasTextBox is true
                if (HasTextBox)
                {
                    // Set the text value
                    TextBox.SetTextValue(text);
                }
            }
            #endregion
            
            #region SetSelectedItems(List<Item> selectedItems)
            /// <summary>
            /// Set Selected Items for the ComboBox in CheckedListMode
            /// </summary>
            public void SetSelectedItems(List<Item> selectedItems)
            {
                // if the value for HasCheckedListComponent is true
                if ((HasCheckedListComponent) && (ListHelper.HasOneOrMoreItems(selectedItems)))
                {
                    // iterate the items
                    foreach (Item item in selectedItems)
                    {
                        // if this item is checked
                        if (item.ItemChecked)
                        {
                            // Find the item by Id
                            int index = ItemHelper.FindItemIndexByText(CheckedListComponent.Items, item.Text);

                            // if the index was found
                            if (index >= 0)
                            {
                                // Check this item
                                CheckedListComponent.Items[index].ItemChecked = true;    
                            }
                        }
                    }

                    // Update the selections
                    CheckedListComponent.Refresh();

                    // display the selections
                    DisplaySelections();
                }
                else
                {
                    // Store this for once the ocmponent is registered
                    StoredSelectedItems = selectedItems;
                }
            }
            #endregion
            
            #region SetSelectedText(string buttonText)
            /// <summary>
            /// Set the selected value for the combo box Text
            /// </summary>
            public void SetSelectedText(string buttonText)
            {  
                // Store the buttonText
                SelectedText = buttonText;
            }
            #endregion
                
            #region SetLeft(int left)
            /// <summary>
            /// Set Left
            /// </summary>
            public void SetLeft(int left)
            {
                // store
                Left = left;
            }
            #endregion
                
            #region SetPosition(string position)
            /// <summary>
            /// Set Position
            /// </summary>
            public void SetPosition(string position)
            {
                // store
                Position = position;
            }
            #endregion
                
            #region SetSelectedItem(string text, bool refresh = true)
            /// <summary>
            /// returns the Selected Item
            /// </summary>
            public Item SetSelectedItem(string text, bool refresh = true)
            {
                // initial value
                Item selectedItem = null;
                    
                // If the text string exists
                if ((TextHelper.Exists(text)) && (HasItems))
                {
                    // Iterate the collection of Item objects
                    foreach (Item item in Items)
                    {
                        // if a direct match
                        if (TextHelper.IsEqual(item.Text, text))
                        {
                            // set the selecteted item
                            selectedItem = item;
                                
                            // Set the property
                            SelectedItem = item;
                                
                            // Set the ButtonText
                            SelectedText = selectedItem.Text.Replace("_", " ");
                                
                            // if the value for refresh is true
                            if (refresh)
                            {
                                // Update this object
                                Refresh();
                            }
                                
                            // break out of the loop
                            break;
                        }
                        else if (TextHelper.Exists(item.Text))
                        {
                            // if a match with the underscores replaced as a space
                            if (TextHelper.IsEqual(item.Text.Replace("_", " "), text))
                            {
                                // set the selecteted item
                                selectedItem = item;
                                    
                                // Set the property
                                SelectedItem = item;
                                    
                                // Set the ButtonText
                                SelectedText = selectedItem.Text.Replace("_", " ");
                                    
                                // if the value for refresh is true
                                if (refresh)
                                {
                                    // Update this object
                                    Refresh();
                                }
                                    
                                // break out of the loop
                                break;
                            }
                        }
                    }
                }
                    
                // return value
                return selectedItem;
            }
            #endregion
                
            #region SetupComponent()
            /// <summary>
            /// Set Button Image
            /// </summary>
            public void SetupComponent()
            {
                // if not ShowButton
                if ((!ShowButton) && (Initialized))
                {
                    // Show the list
                    Expanded = true;
                }

                // if Blue Mode
                if (theme == ThemeEnum.Blue)
                {      
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/TriangleButtonOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/TriangleButtonClosed.png";
                    }
                }
                else if ((theme == ThemeEnum.Dark) || (theme == ThemeEnum.Black))
                { 
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlackTriangleOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlackTriangleClosed.png";
                    }
                }
                else if (theme == ThemeEnum.Brown)
                {      
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BrownTriangleOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BrownTriangleClosed.png";
                    }
                }
                else if (theme == ThemeEnum.BlueGold)
                {
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlueGoldArrowOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlueGoldArrowClosed.png";
                    }
                }
                    
                // if the Button exists
                if (HasButton)
                {
                    // Update the Button
                    Button.Refresh();
                }

                // if expanded
                if (Expanded)
                {
                    // Show selections
                    ListDisplay = "inline-block";
                }
                else
                {
                    // Show selections
                    ListDisplay = "none";
                }

                // Display the Selections (if in CheckListMode)
                DisplaySelections();

                // Has fired once
                Initialized = true;
            }
            #endregion

            #region Show(bool refresh = true)
            /// <summary>
            /// Show
            /// </summary>
            public void Show(bool refresh = true)
            {
                // Set the value
                Display = "inline-block";

                // if the value for refresh is true
                if (refresh)
                {
                    // Update the UI
                    Refresh();
                }
            }
            #endregion
                
            #region StoreSelections()
            /// <summary>
            /// Store Selections
            /// </summary>
            public void StoreSelections()
            {
                // If the CheckedListComponent and the Items collections both exist
                if ((HasCheckedListComponent) && (HasItems))
                {
                    // Get the selected items
                    List<Item> selectedItems = CheckedListComponent.SelectedItems;

                    // first unselect everything
                    foreach (Item item in Items)
                    {   
                        // unselect
                        item.ItemChecked = false;
                    }

                    // If the selectedItems collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(selectedItems))
                    {
                        foreach (Item item in selectedItems)
                        {
                            // attempt to find this item
                            Item temp = CheckedListComponent.FindItemById(item.Id);

                            // If the temp object exists
                            if (NullHelper.Exists(temp))
                            {
                                // set to true
                                temp.ItemChecked = true;
                            }
                        }
                    }
                }
            }
            #endregion
            
        #endregion
            
        #region Properties
            
            #region Button
            /// <summary>
            /// This property gets or sets the value for 'Button'.
            /// </summary>
            public ImageButton Button
            {
                get { return button; }
                set { button = value; }
            }
            #endregion

            #region ButtonBorderColor
            /// <summary>
            /// This property gets or sets the value for 'ButtonBorderColor'.
            /// </summary>
            [Parameter]
            public Color ButtonBorderColor
            {
                get { return buttonBorderColor; }
                set { buttonBorderColor = value; }
            }
            #endregion
            
            #region ButtonBorderWidth
            /// <summary>
            /// This property gets or sets the value for 'ButtonBorderWidth'.
            /// </summary>
            [Parameter]
            public double ButtonBorderWidth
            {
                get { return buttonBorderWidth; }
                set { buttonBorderWidth = value; }
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
            
            #region ButtonLeft
            /// <summary>
            /// This property gets or sets the value for 'ButtonLeft'.
            /// </summary>
            [Parameter]
            public double ButtonLeft
            {
                get { return buttonLeft; }                
                set { buttonLeft = value; }
            }
            #endregion
                
            #region ButtonLeftStyle
            /// <summary>
            /// This read only property returns the value of ButtonLeftStyle from the object ButtonLeft.
            /// </summary>
            public string ButtonLeftStyle
            {
                    
                get
                {
                    // initial value
                    string buttonLeftStyle = ButtonLeft + Unit;
                        
                    // return value
                    return buttonLeftStyle;
                }
            }
            #endregion
                
            #region ButtonPosition
            /// <summary>
            /// This property gets or sets the value for 'ButtonPosition'.
            /// </summary>
            [Parameter]
            public string ButtonPosition
            {
                get { return buttonPosition; }
                set { buttonPosition = value; }
            }
            #endregion

            #region ButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'ButtonstyleStyle'.
            /// </summary>
            public string ButtonStyle
            {
                get { return buttonStyle; }
                set { buttonStyle = value; }
            }
            #endregion
                
            #region ButtonTop
            /// <summary>
            /// This property gets or sets the value for 'ButtonTop'.
            /// </summary>
            [Parameter]
            public double ButtonTop
            {
                get { return buttonTop; }
                set { buttonTop = value; }
            }
            #endregion
                
            #region ButtonTopStyle
            /// <summary>
            /// This read only property returns the value of ButtonTopStyle from the object ButtonTop.
            /// </summary>
            public string ButtonTopStyle
            {
                get
                {
                    // initial value
                    string buttonTopStyle = ButtonTop + HeightUnit;
                        
                    // return value
                    return buttonTopStyle;
                }
            }
            #endregion
                
            #region ButtonUrl
            /// <summary>
            /// This property gets or sets the value for 'ButtonUrl'.
            /// </summary>
            [Parameter]
            public string ButtonUrl
            {
                get { return buttonUrl; }
                set { buttonUrl = value; }
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
            
            #region CheckBoxX
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxX'.
            /// </summary>
            [Parameter]
            public double CheckBoxX
            {
                get { return checkBoxX; }
                set { checkBoxX = value; }
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
                set { checkBoxY = value; }
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
            
            #region CheckedListClassName
            /// <summary>
            /// This property gets or sets the value for 'CheckedListClassName'.
            /// </summary>
            [Parameter]
            public string CheckedListClassName
            {
                get { return checkedListClassName; }
                set { checkedListClassName = value; }
            }
            #endregion
            
            #region CheckedListComponent
            /// <summary>
            /// This property gets or sets the value for 'CheckedListComponent'.
            /// </summary>
            public CheckedListBox CheckedListComponent
            {
                get { return checkedListComponent; }
                set { checkedListComponent = value; }
            }
            #endregion
                
            #region CheckedListheight
            /// <summary>
            /// This property gets or sets the value for 'CheckedListheight'.
            /// </summary>
            [Parameter]
            public double CheckedListheight
            {
                get { return checkedListheight; }
                set { checkedListheight = value; }
            }
            #endregion
            
            #region CheckedListheightStyle
            /// <summary>
            /// This read only property returns the value of CheckedListheight plus the HeightUnit for CSS
            /// </summary>
            public string CheckedListheightStyle
            {
                
                get
                {
                    // initial value
                    string checkedListheightStyle = CheckedListheight + HeightUnit;
                    
                    // return value
                    return checkedListheightStyle;
                }
            }
            #endregion
            
            #region CheckedListHeightUnit
            /// <summary>
            /// This property gets or sets the value for 'CheckedListHeightUnit'.
            /// </summary>
            [Parameter]
            public string CheckedListHeightUnit
            {
                get { return checkedListHeightUnit; }
                set { checkedListHeightUnit = value; }
            }
            #endregion
           
            #region CheckedListItemLeft
            /// <summary>
            /// This property gets or sets the value for 'CheckedListItemLeft'.
            /// </summary>
            [Parameter]
            public double CheckedListItemLeft
            {
                get { return checkedListItemLeft; }
                set { checkedListItemLeft = value; }
            }
            #endregion
            
            #region CheckedListItemTop
            /// <summary>
            /// This property gets or sets the value for 'CheckedListItemTop'.
            /// </summary>
            [Parameter]
            public double CheckedListItemTop
            {
                get { return checkedListItemTop; }
                set { checkedListItemTop = value; }
            }
            #endregion
            
            #region CheckedListLeft
            /// <summary>
            /// This property gets or sets the value for 'CheckedListLeft'.
            /// </summary>
            [Parameter]
            public double CheckedListLeft
            {
                get { return checkedListLeft; }
                set { checkedListLeft = value; }
            }
            #endregion
            
            #region CheckedListLeftStyle
            /// <summary>
            /// This read only property returns the value of CheckedListLeftStyle from the object CheckedListLeft.
            /// </summary>
            public string CheckedListLeftStyle
            {
                
                get
                {
                    // initial value
                    string checkedListLeftStyle = CheckedListLeft + Unit;
                    
                    // return value
                    return checkedListLeftStyle;
                }
            }
            #endregion
            
            #region CheckedListPosition
            /// <summary>
            /// This property gets or sets the value for 'CheckedListPosition'.
            /// </summary>
            [Parameter]
            public string CheckedListPosition
            {
                get { return checkedListPosition; }
                set { checkedListPosition = value; }
            }
            #endregion
            
            #region CheckedListTop
            /// <summary>
            /// This property gets or sets the value for 'CheckedListTop'.
            /// </summary>
            [Parameter]
            public double CheckedListTop
            {
                get { return checkedListTop; }
                set { checkedListTop = value; }
            }
            #endregion
            
            #region CheckedListTopStyle
            /// <summary>
            /// This read only property returns the value of CheckedListTopStyle from the object CheckedListTop.
            /// </summary>
            public string CheckedListTopStyle
            {
                
                get
                {
                    // initial value
                    string checkedListTopStyle = CheckedListTop + HeightUnit;
                    
                    // return value
                    return checkedListTopStyle;
                }
            }
            #endregion
            
            #region CheckedListUnit
            /// <summary>
            /// This property gets or sets the value for 'CheckedListUnit'.
            /// </summary>
            [Parameter]
            public string CheckedListUnit
            {
                get { return checkedListUnit; }
                set { checkedListUnit = value; }
            }
            #endregion
            
            #region CheckedListWidth
            /// <summary>
            /// This property gets or sets the value for 'CheckedListWidth'.
            /// </summary>
            [Parameter]
            public double CheckedListWidth
            {
                get { return checkedListWidth; }
                set { checkedListWidth = value; }
            }
            #endregion
            
            #region CheckedListWidthStyle
            /// <summary>
            /// This read only property returns the value of CheckedListWidthStyle from the object CheckedListWidth.
            /// </summary>
            public string CheckedListWidthStyle
            {
                
                get
                {
                    // initial value
                    string checkedListWidthStyle = CheckedListWidth + Unit;
                    
                    // return value
                    return checkedListWidthStyle;
                }
            }
            #endregion
          
            #region CheckListMode
            /// <summary>
            /// This property gets or sets the value for 'CheckListMode'.
            /// </summary>
            [Parameter]
            public bool CheckListMode
            {
                get { return checkListMode; }
                set { checkListMode = value; }
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
            
            #region Column1WidthPlus6Style
            /// <summary>
            /// This read only property returns the value of Column1Width Plus 6 + Unit
            /// </summary>
            public string Column1WidthPlus6Style
            {

                get
                {
                    // initial value
                    string column1WidthPlus4Style = Column1Width + 6 + Unit;

                    // return value
                    return column1WidthPlus4Style;
                }
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
                    string column1WidthStyle = Column1Width + Unit;
                    
                    // return value
                    return column1WidthStyle;
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
                
            #region ContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'ContainerStyle'.
            /// </summary>
            [Parameter]
            public string ContainerStyle
            {
                get { return containerStyle; }
                set { containerStyle = value; }
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
            /// This read only property returns the value of ControlHeightStyle from the object ContainerHeight.
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
            
            #region ControlWidth
            /// <summary>
            /// This property gets or sets the value for 'ControlWidth'.
            /// </summary>
            public double ControlWidth
            {
                get { return controlWidth; }
                set { controlWidth = value; }
            }
            #endregion

            #region ControlWidthStyle
            /// <summary>
            /// This read only property returns the value of ControlWidthStyle from the object ContainerWidth.
            /// </summary>
            public string ControlWidthStyle
            {
                
                get
                {
                    // initial value
                    string controlWidthStyle = ControlWidth + Unit;
                    
                    // return value
                    return controlWidthStyle;
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
          
            #region DropdownClassName
            /// <summary>
            /// This property gets or sets the value for 'DropdownClassName'.
            /// </summary>
            [Parameter]
            public string DropdownClassName
            {
                get { return dropdownClassName; }
                set { dropdownClassName = value; }
            }
            #endregion
            
            #region DropDownZIndex
            /// <summary>
            /// This property gets or sets the value for 'DropDownZIndex'.
            /// </summary>
            public int DropDownZIndex
            {
                get { return dropDownZIndex; }
                set { dropDownZIndex = value; }
            }
            #endregion
            
            #region Expanded
            /// <summary>
            /// This property gets or sets the value for 'Expanded'.
            /// </summary>
            public bool Expanded
            {
                get { return expanded; }
                set
                {
                    // initial value
                    bool originalValue = expanded;

                    // set the new value
                    expanded = value;

                    // if the value has changed
                    if ((originalValue != value) || (!Initialized))
                    {
                        // The button image changes on Expanded and Theme.
                        SetupComponent();
                    }
                }
            }
            #endregion
            
            #region FilteredItems
            /// <summary>
            /// This read only property returns the value of FilteredItems from the object Items.
            /// </summary>
            public List<Item> FilteredItems
            {
                
                get
                {
                    // initial value
                    List<Item> filteredItems = Items;
                    
                    // if Items exists
                    if (HasFilterText)
                    {
                        // set the return value
                        filteredItems = Items.Where(x => x.Text.StartsWith(FilterText)).ToList();
                    }
                    
                    // return value
                    return filteredItems;
                }
            }
            #endregion
            
            #region FilterIndex
            /// <summary>
            /// This property gets or sets the value for 'FilterIndex'.
            /// </summary>
            public int FilterIndex
            {
                get { return filterIndex; }
                set { filterIndex = value; }
            }
            #endregion
            
            #region FilterText
            /// <summary>
            /// This property gets or sets the value for 'FilterText'.
            /// </summary>
            public string FilterText
            {
                get { return filterText; }
                set { filterText = value; }
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
                set 
                {
                    // Set the value
                    fontName = value;

                    // Set Both
                    LabelFontName = value;
                    TextBoxFontName = value;
                }
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
                set 
                {
                    // set the value
                    fontSize = value;

                    // Set Label & TextBox Font Sizes
                    LabelFontSize = value;
                    TextBoxFontSize = value;
                }
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
            
            #region HasButton
            /// <summary>
            /// This property returns true if this object has a 'Button'.
            /// </summary>
            public bool HasButton
            {
                get
                {
                    // initial value
                    bool hasComboBoxButton = (this.Button != null);
                        
                    // return value
                    return hasComboBoxButton;
                }
            }
            #endregion
            
            #region HasCheckedListComponent
            /// <summary>
            /// This property returns true if this object has a 'CheckedListComponent'.
            /// </summary>
            public bool HasCheckedListComponent
            {
                get
                {
                    // initial value
                    bool hasCheckedListComponent = (this.CheckedListComponent != null);
                        
                    // return value
                    return hasCheckedListComponent;
                }
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
                
            #region HasFilterText
            /// <summary>
            /// This property returns true if the 'FilterText' exists.
            /// </summary>
            public bool HasFilterText
            {
                get
                {
                    // initial value
                    bool hasFilterText = (!String.IsNullOrEmpty(this.FilterText));
                    
                    // return value
                    return hasFilterText;
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
                
            #region HasSelectedItem
            /// <summary>
            /// This property returns true if this object has a 'SelectedItem'.
            /// </summary>
            public bool HasSelectedItem
            {
                get
                {
                    // initial value
                    bool hasSelectedItem = (this.SelectedItem != null);
                        
                    // return value
                    return hasSelectedItem;
                }
            }
            #endregion
                
            #region HasSelectedText
            /// <summary>
            /// This property returns true if the 'SelectedText' exists.
            /// </summary>
            public bool HasSelectedText
            {
                get
                {
                    // initial value
                    bool hasSelectedText = (!String.IsNullOrEmpty(this.SelectedText));
                    
                    // return value
                    return hasSelectedText;
                }
            }
            #endregion
            
            #region HasStoredSelectedItems
            /// <summary>
            /// This property returns true if this object has a 'StoredSelectedItems'.
            /// </summary>
            public bool HasStoredSelectedItems
            {
                get
                {
                    // initial value
                    bool hasStoredSelectedItems = (this.StoredSelectedItems != null);
                    
                    // return value
                    return hasStoredSelectedItems;
                }
            }
            #endregion
            
            #region HasTextBox
            /// <summary>
            /// This property returns true if this object has a 'TextBox'.
            /// </summary>
            public bool HasTextBox
            {
                get
                {
                    // initial value
                    bool hasTextBox = (this.TextBox != null);
                    
                    // return value
                    return hasTextBox;
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
                
            #region ImagePath
            /// <summary>
            /// This property gets or sets the value for 'ImagePath'.
            /// </summary>
            public string ImagePath
            {
                get { return imagePath; }
                set { imagePath = value; }
            }
            #endregion
            
            #region Initialized
            /// <summary>
            /// This property gets or sets the value for 'Initialized'.
            /// </summary>
            public bool Initialized
            {
                get { return initialized; }
                set { initialized = value; }
            }
            #endregion
            
            #region Items
            /// <summary>
            /// This property gets or sets the value for 'Items'.
            /// </summary>
            public List<Item> Items
            {
                get
                {
                    // return the list
                    return items;
                }
                set
                {
                    // set the value
                    items = value;
                        
                    // if the value for HasCheckedListComponent is true
                    if (HasCheckedListComponent)
                    {
                        // Set the items
                        CheckedListComponent.SetItems(items);
                    }
                }
            }
            #endregion
                
            #region LabelBackColor
            /// <summary>
            /// This property gets or sets the value for 'LabelBackColor'.
            /// </summary>
            [Parameter]
            public string LabelBackColor
            {
                get { return labelBackColor; }
                set { labelBackColor = value; }
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
                
            #region LabelColorName
            /// <summary>
            /// This read only property returns the value of LabelColorName from the object LabelColor.
            /// </summary>
            public string LabelColorName
            {
                    
                get
                {
                    // initial value
                    string labelColorName = LabelColor.Name;
                        
                    // return value
                    return labelColorName;
                }
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
                    string labelFontSizeStyle = LabelFontSize + LabelFontSizeUnit;

                    // return value
                    return labelFontSizeStyle;
                }
            }
            #endregion
            
            #region LabelFontSizeUnit
            /// <summary>
            /// This property gets or sets the value for 'LabelFontSizeUnit'.
            /// </summary>
            [Parameter]
            public string LabelFontSizeUnit
            {
                get { return labelFontSizeUnit; }
                set { labelFontSizeUnit = value; }
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
                    string labelLeftStyle = LabelLeft + LabelUnit;
                        
                    // return value
                    return labelLeftStyle;
                }
            }
            #endregion
                
            #region LabelMarginRight
            /// <summary>
            /// This property gets or sets the value for 'LabelMarginRight'.
            /// </summary>
            [Parameter]
            public double LabelMarginRight
            {
                get { return labelMarginRight; }
                set
                {
                    labelMarginRight = value;
                        
                    // set the CSS value
                    LabelMarginRightStyle = labelMarginRight + Unit;
                }
            }
            #endregion
                
            #region LabelMarginRightList
            /// <summary>
            /// This property gets or sets the value for 'LabelMarginRightList'.
            /// </summary>
            [Parameter]
            public double LabelMarginRightList
            {
                get { return labelMarginRightList; }
                set
                {
                    labelMarginRightList = value;
                        
                    // Set the value
                    labelMarginRightListStyle = labelMarginRightList + Unit;
                }
            }
            #endregion
                
            #region LabelMarginRightListStyle
            /// <summary>
            /// This property gets or sets the value for 'LabelMarginRightListStyle'.
            /// </summary>
            public string LabelMarginRightListStyle
            {
                get { return labelMarginRightListStyle; }
                set { labelMarginRightListStyle = value; }
            }
            #endregion
                
            #region LabelMarginRightStyle
            /// <summary>
            /// This property gets or sets the value for 'LabelMarginRightStyle'.
            /// </summary>
            public string LabelMarginRightStyle
            {
                get { return labelMarginRightStyle; }
                set { labelMarginRightStyle = value; }
            }
            #endregion
                
            #region LabelPosition
            /// <summary>
            /// This property gets or sets the value for 'LabelPosition'.
            /// </summary>
            [Parameter]
            public string LabelPosition
            {
                get { return labelPosition; }
                set { labelPosition = value; }
            }
            #endregion
            
            #region LabelText
            /// <summary>
            /// This property gets or sets the value for 'LabelText'.
            /// </summary>
            [Parameter]
            public string LabelText
            {
                get { return labelText; }
                set { labelText = value; }
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
                set 
                {
                    labelTop = value;
                }
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
            
            #region LabelUnit
            /// <summary>
            /// This property gets or sets the value for 'LabelUnit            
            /// </summary>
            [Parameter]
            public string LabelUnit
            {
                get {return labelUnit; }
                set { labelUnit = value; }
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
                
            #region LabelWidthStyle
            /// <summary>
            /// This read only property returns the value of LabelWidth + Unit
            /// </summary>
            public string LabelWidthStyle
            {
                    
                get
                {
                    // initial value
                    string labelWidthStyle = labelWidth + unit;
                        
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
           
            #region ListBorderWidth
            /// <summary>
            /// This property gets or sets the value for 'ListBorderWidth'.
            /// </summary>
            [Parameter]
            public double ListBorderWidth
            {
                get { return listBorderWidth; }
                set { listBorderWidth = value; }
            }
            #endregion
            
            #region ListBorderWidthStyle
            /// <summary>
            /// This read only property returns the value of ListBorderWidth + Unit
            /// </summary>
            public string ListBorderWidthStyle
            {

                get
                {
                    // initial value
                    string listBorderWidthStyle = ListBorderWidth + Unit;

                    // return value
                    return listBorderWidthStyle;
                }
            }
            #endregion

            #region ListContainerHeight
            /// <summary>
            /// This property gets or sets the value for 'ListContainerHeight'.
            /// </summary>
            [Parameter]
            public double ListContainerHeight
            {
                get { return listContainerHeight; }
                set { listContainerHeight = value; }
            }
            #endregion
            
            #region ListContainerHeightStyle
            /// <summary>
            /// This read only property returns the value of ListContainerHeight + HeightUnit
            /// </summary>
            public string ListContainerHeightStyle
            {

                get
                {
                    // initial value
                    string listContainerHeightStyle = ListContainerHeight + HeightUnit;
                    
                    // return value
                    return listContainerHeightStyle;
                }
            }
            #endregion

            #region ListContainerLeft
            /// <summary>
            /// This property gets or sets the value for 'ListContainerLeft'.
            /// </summary>
            [Parameter]
            public double ListContainerLeft
            {
                get { return listContainerLeft; }
                set { listContainerLeft = value; }
            }
            #endregion
            
            #region ListContainerLeftStyle
            /// <summary>
            /// This read only property returns the value of ListContainerLeft + Unit
            /// </summary>
            public string ListContainerLeftStyle
            {

                get
                {
                    // initial value
                    string listContainerLeftStyle = ListContainerLeft + Unit;
                    
                    // return value
                    return listContainerLeftStyle;
                }
            }
            #endregion

            #region ListContainerPosition
            /// <summary>
            /// This property gets or sets the value for 'ListContainerPosition'.
            /// </summary>
            [Parameter]
            public string ListContainerPosition
            {
                get { return listContainerPosition; }
                set { listContainerPosition = value; }
            }
            #endregion
            
            #region ListContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'ListContainerStyle'.
            /// </summary>            
            public string ListContainerStyle
            {
                get { return listContainerStyle; }
                set { listContainerStyle = value; }
            }
            #endregion
            
            #region ListContainerTop
            /// <summary>
            /// This property gets or sets the value for 'ListContainerTop'.
            /// </summary>
            [Parameter]
            public double ListContainerTop
            {
                get { return listContainerTop; }
                set { listContainerTop = value; }
            }
            #endregion
            
            #region ListContainerTopStyle
            /// <summary>
            /// This read only property returns the value of ListContainerTopStyle from the object ListContainerTop.
            /// </summary>
            public string ListContainerTopStyle
            {

                get
                {
                    // initial valu
                    string listContainerTopStyle = ListContainerTop + HeightUnit;
                    
                    // return value
                    return listContainerTopStyle;
                }
            }
            #endregion

            #region ListDisplay
            /// <summary>
            /// This property gets or sets the value for 'ListDisplay'.
            /// </summary>
            public string ListDisplay
            {
                get { return listDisplay; }
                set { listDisplay = value; }
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
                set
                {
                    listItemHeight = value;

                    // Set the value
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
            
            #region ListItemContainer
            /// <summary>
            /// This property gets or sets the value for 'ListItemContainer'.
            /// </summary>
            public string ListItemContainer
            {
                get { return listItemContainer; }
                set { listItemContainer = value; }
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
            
            #region Loaded
            /// <summary>
            /// This property gets or sets the value for 'Loaded'.
            /// </summary>
            public bool Loaded
            {
                get { return loaded; }
                set { loaded = value; }
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
            
            #region OnChange
            /// <summary>
            /// This event is used to clients can get a notification when a selection was made
            /// </summary>
            [Parameter]
            public EventCallback<ChangeEventArgs> OnChange { get; set; }
            #endregion
                
            #region OverflowX
            /// <summary>
            /// This property gets or sets the value for 'OverflowX'.
            /// </summary>
            [Parameter]
            public string OverflowX
            {
                get { return overflowX; }
                set { overflowX = value; }
            }
            #endregion
            
            #region OverflowY
            /// <summary>
            /// This property gets or sets the value for 'OverflowY'.
            /// </summary>
            [Parameter]
            public string OverflowY
            {
                get { return overflowY; }
                set { overflowY = value; }
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
                
            #region SelectedItem
            /// <summary>
            /// This property gets or sets the value for 'SelectedItem'.
            /// </summary>
            public Item SelectedItem
            {
                get { return selectedItem; }
                set { selectedItem = value; }
            }
            #endregion
            
            #region SelectedItems
            /// <summary>
            /// This read only property returns the value of SelectedItems from the object CheckedListComponent.
            /// </summary>
            public List<Item> SelectedItems
            {
                
                get
                {
                    // initial value
                    List<Item> selectedItems = null;
                    
                    // if CheckedListComponent exists
                    if (HasCheckedListComponent)
                    {
                        // set the return value
                        selectedItems = CheckedListComponent.SelectedItems;
                    }
                    
                    // return value
                    return selectedItems;
                }
            }
            #endregion

            #region SelectedText
            /// <summary>
            /// This property gets or sets the value for 'SelectedText'.
            /// </summary>
            [Parameter]
            public string SelectedText
            {
                get { return selectedText; }
                set { selectedText = value; }
            }
            #endregion
            
            #region ShowButton
            /// <summary>
            /// This property gets or sets the value for 'ShowButton'.
            /// </summary>
            [Parameter]
            public bool ShowButton
            {
                get { return showButton; }
                set 
                {
                    showButton = value;

                    // if the value for showButton is false
                    if (!showButton)
                    {
                        // Has to be Expanded
                        Expanded = true;
                    }
                }
            }
            #endregion
            
            #region ShowLabel
            /// <summary>
            /// This property gets or sets the value for 'ShowLabel'.
            /// </summary>
            public bool ShowLabel
            {
                get
                {
                    // set the return value
                    bool showLabel = TextHelper.Exists(LabelText);
                        
                    // return value
                    return showLabel;
                }
            }
            #endregion
                
            #region StoredSelectedItems
            /// <summary>
            /// This property gets or sets the value for 'StoredSelectedItems'.
            /// </summary>
            public List<Item> StoredSelectedItems
            {
                get { return storedSelectedItems; }
                set { storedSelectedItems = value; }
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
                
            #region TextBox
            /// <summary>
            /// This property gets or sets the value for 'TextBox'.
            /// </summary>
            public TextBoxComponent TextBox
            {
                get { return textBox; }
                set { textBox = value; }
            }
            #endregion
            
            #region TextBoxEnabled
            /// <summary>
            /// This read only property returns true if not in ChecckListMode
            /// </summary>
            public bool TextBoxEnabled
            {
                
                get
                {
                    // initial value
                    bool textBoxEnabled = !CheckListMode;
                    
                    // return value
                    return textBoxEnabled;
                }
            }
            #endregion
            
            #region TextBoxFontName
            /// <summary>
            /// This property gets or sets the value for 'TextBoxFontName'.
            /// </summary>
            [Parameter]
            public string TextBoxFontName
            {
                get { return textBoxFontName; }
                set { textBoxFontName = value; }
            }
            #endregion
            
            #region TextBoxFontSize
            /// <summary>
            /// This property gets or sets the value for 'TextBoxFontSize'.
            /// </summary>
            [Parameter]
            public double TextBoxFontSize
            {
                get { return textBoxFontSize; }
                set { textBoxFontSize = value; }
            }
            #endregion
            
            #region TextBoxHeight
            /// <summary>
            /// This property gets or sets the value for 'TextBoxHeight'.
            /// </summary>
            [Parameter]
            public double TextBoxHeight
            {
                get { return textBoxHeight; }
                set { textBoxHeight = value; }
            }
            #endregion
            
            #region TextBoxLeft
            /// <summary>
            /// This property gets or sets the value for 'TextBoxLeft'.
            /// </summary>
            [Parameter]
            public double TextBoxLeft
            {
                get { return textBoxLeft; }
                set { textBoxLeft = value; }
            }
            #endregion
            
            #region TextBoxTop
            /// <summary>
            /// This property gets or sets the value for 'TextBoxTop'.
            /// </summary>
            [Parameter]
            public double TextBoxTop
            {
                get { return textBoxTop; }
                set { textBoxTop = value; }
            }
            #endregion
            
            #region TextBoxWidth
            /// <summary>
            /// This property gets or sets the value for 'TextBoxWidth'.
            /// </summary>
            [Parameter]
            public double TextBoxWidth
            {
                get { return textBoxWidth; }
                set { textBoxWidth = value; }
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
                        
                    // Set the ButtonImage, TextColor, etc.
                    SetupComponent();
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
                set { unit = value; }
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
                set 
                {
                    visibleCount = value;

                    if (VisibleCount > 0)
                    {
                        // Guess at row height
                        CheckedListheight = VisibleCount * ListItemHeight;
                    }
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
                
            #region ZIndexPlus10
            /// <summary>
            /// This read only property returns the value of ZIndexPlus Plus 10.
            /// </summary>
            public int ZIndexPlus10
            {
                    
                get
                {
                    // initial value
                    int zIndexPlus = ZIndex + 10;
                        
                    // return value
                    return zIndexPlus;
                }
            }
            #endregion

            #region ZIndexPlus20
            /// <summary>
            /// This read only property returns the value of ZIndexPlus Plus 20.
            /// </summary>
            public int ZIndexPlus20
            {
                    
                get
                {
                    // initial value
                    int zIndexPlus = ZIndex + 20;
                        
                    // return value
                    return zIndexPlus;
                }
            }
            #endregion

            #region ZIndexPlus30
            /// <summary>
            /// This read only property returns the value of ZIndexPlus Plus 30.
            /// </summary>
            public int ZIndexPlus30
            {
                    
                get
                {
                    // initial value
                    int zIndexPlus = ZIndex + 30;
                        
                    // return value
                    return zIndexPlus;
                }
            }
            #endregion
                
        #endregion
            
    }
    #endregion
    
}
