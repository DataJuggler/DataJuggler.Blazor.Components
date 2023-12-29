

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Components;
using DataJuggler.UltimateHelper;
using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.Blazor.Components.Interfaces;
using System.Drawing;
using OfficeOpenXml.FormulaParsing.ExpressionGraph.FunctionCompilers;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class ComboBox
    /// <summary>
    /// This class is designed to make a DropDownList easier to work with.
    /// </summary>
    public partial class ComboBox : ComponentBase, IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private double buttonLeft;
        private string buttonPosition;
        private string buttonStyle;
        private string buttonText;
        private Color buttonTextColor;
        private double buttonTop;
        private string buttonUrl;
        private CheckedListBox checkedListComponent;
        private bool checkListMode;
        private List<IBlazorComponent> children;
        private string className;
        private Color comboBoxBackColor;
        private ImageButton comboBoxButton;
        private double comboBoxLeft;
        private string comboBoxStyle;
        private double comboBoxWidth;
        private string displayStyle;
        private bool expanded;
        private double expandedButtonLeft;
        private string grid;
        private double height;
        private string heightStyle;
        private string heightUnit;
        private string imagePath;
        private List<Item> items;
        private string labelBackColor;
        private string labelClassName;
        private Color labelColor;
        private double labelLeft;
        private double labelMarginRight;
        private double labelMarginRightList;
        private string labelMarginRightListStyle;
        private string labelMarginRightStyle;
        private string labelPosition;
        private string labelStyle;
        private string labelText;
        private double labelTop;
        private string labelUnit;
        private double labelWidth;
        private double left;
        private string leftStyle;
        private Color listBackgroundColor;
        private double listItemHeight;
        private string listItemClassName;
        private double listItemLeft;
        private string listItemPosition;
        private string listItemStyle;
        private Color listItemTextColor;
        private Color listItemBackgroundColor;
        private double listItemTop;
        private double listItemWidth;        
        private string listItemWidthStyle;
        private string name;
        private string noPadding;
        private IBlazorComponentParent parent;
        private string position;
        private bool rendered;
        private Item selectedItem;
        private string textAlign;
        private TextSizeEnum textSize;
        private string textSizeStyle;
        private ThemeEnum theme;
        private double top;
        private string topStyle;
        private string unit;
        private bool visible;
        private int visibleCount;
        private double width;
        private int zIndex;
        private string listItemHeightStyle;
        private double checkedListheight;
        private double comboBoxHeight;
        private string comboBoxHeightStyle;
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
                if ((buttonNumber == 1) && (HasComboBoxButton))
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
            
            #region SelectionChanged(ChangeEventArgs selectedItem)
            /// <summary>
            /// event is fired when On Change
            /// </summary>
            public void SelectionChanged(ChangeEventArgs selectedItem)
            {
                // Set the selectedItem
                ButtonText = selectedItem.Value.ToString();
                
                // Set the SelectedItem
                SetSelectedItem(ButtonText, false);
                
                // if the Parent exists
                if (HasParent)
                {
                    // Create a new instance of a 'Message' object.
                    Message message = new Message();
                    
                    // Notify the parent
                    message.Text = ButtonText;
                    
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
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default to 30% for the lable, the rest goes to the ComboBox
                Theme = ThemeEnum.Black;
                ButtonPosition = "relative";
                ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBoxBlack.png";
                ButtonText = "[Button Text]";
                TextSize = TextSizeEnum.Medium;
                Children = new List<IBlazorComponent>();
                Visible = true;
                Left = 0;
                Top = 0;
                Height = 60;
                Unit = "px";
                HeightUnit = "px";
                Width = 120;
                ComboBoxWidth = 120;
                Position = "relative";
                VisibleCount = 5;
                ZIndex = 0;
                LabelMarginRight = 0;
                LabelMarginRightList = 0;
                ListItemWidth = 120;
                TextAlign = "center";
                Items = new List<Item>();
                LabelBackColor = "transparent";
                ComboBoxBackColor = Color.Transparent;
                LabelUnit = "px";
                ListItemPosition = "relative";
                ListItemHeight = 16;
                LabelPosition = "relative";
                ListItemBackgroundColor = Color.White;
                ListItemClassName="height16";
                
                // Set so the image is set
                Expanded = false;
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
                    
                    SelectedItem = Items[0];
                    
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
                string itemValue = "";
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
                            
                            // set the itemValue
                            itemValue = values.GetValue(index).ToString();
                            
                            // replace out any underscores with spaces
                            formattedName = name.Replace("_", " ");
                            
                            // Create the item
                            Item item = new Item();
                            
                            // Get the value
                            item.Id = NumericHelper.ParseInteger(itemValue, 0, 0);
                            
                            // Set the name with any underscores out
                            item.Text = formattedName;
                            
                            // add this item
                            this.Items.Add(item);
                        }
                        
                        // Update Async
                        Refresh();
                    }
                }
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // If the 'message' object and the 'checkedListComponent' objects both exist.
                if (NullHelper.Exists(message, checkedListComponent))
                {
                    // if it is the CheckedListBox
                    if (message.Text == "SendItems")
                    {
                        // set the items
                        CheckedListComponent.SetItems(Items);
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
                    ComboBoxButton = component as ImageButton;
                        
                    // if the value for HasComboBoxButton is true
                    if (HasComboBoxButton)
                    {
                        // Setup the click handler
                        ComboBoxButton.SetClickHandler(ButtonClicked);
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
                    }
                }
            }
            #endregion
                
            #region SetButtonText(string buttonText)
            /// <summary>
            /// Set Button Text
            /// </summary>
            public void SetButtonText(string buttonText)
            {
                // Store the buttonText
                ButtonText = buttonText;
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
                            ButtonText = selectedItem.Text.Replace("_", " ");
                                
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
                                ButtonText = selectedItem.Text.Replace("_", " ");
                                    
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
                
            #region SetTextSize(TextSizeEnum textSize)
            /// <summary>
            /// Sets the text size
            /// </summary>
            public void SetTextSize(TextSizeEnum textSize)
            {
                // set the value
                TextSize = textSize;
            }
            #endregion
                
            #region SetTextSize(string selectedTextSizeText)
            /// <summary>
            /// Set Text Size
            /// </summary>
            public void SetTextSize(string selectedTextSizeText)
            {
                // Default value
                TextSizeEnum textSize = TextSizeEnum.Medium;
                    
                    // If the selectedTextSizeText string exists
                    if (TextHelper.Exists(selectedTextSizeText))
                    {
                        switch (selectedTextSizeText)
                        {
                            case "Extra Small":
                            
                            // Set the value
                            textSize = TextSizeEnum.Extra_Small;
                            
                            // required
                            break;
                            
                            case "Small":
                            
                            // Set the value
                            textSize = TextSizeEnum.Small;
                            
                            // required
                            break;
                            
                            case "Large":
                            
                            // Set the value
                            textSize = TextSizeEnum.Large;
                            
                            // required
                            break;
                            
                            case "Extra Large":
                            
                            // Set the value
                            textSize = TextSizeEnum.Extra_Large;
                            
                            // required
                            break;
                        }
                    }
                    
                    // set the value
                    TextSize = textSize;
                }
                #endregion
                
            #region SetTextSizeStyle(string textSizeStyle)
            /// <summary>
            /// Set Text Size Style. Examples: 12px, 2vh, .75em
            /// </summary>
            public void SetTextSizeStyle(string textSizeStyle)
            {
                // Store the value
                TextSizeStyle = textSizeStyle;
            }
            #endregion
                
            #region SetupComponent()
            /// <summary>
            /// Set Button Image
            /// </summary>
            public void SetupComponent()
            {
                // if Blue Mode
                if (theme == ThemeEnum.Blue)
                {
                    // only set the TextColor on the first pass
                    if (!Rendered)
                    {
                        // Dark Blue
                        ButtonTextColor = Color.Navy;
                        ListBackgroundColor = Color.AliceBlue;
                    }
                        
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBoxOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBox.png";
                    }
                }
                else if (theme == ThemeEnum.Dark)
                {
                    // only set the TextColor on the first pass
                    if (!Rendered)
                    {
                        // Dark Blue
                        ButtonTextColor = Color.White;
                        ListBackgroundColor = Color.Brown;
                    }
                        
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBoxOpenDark.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBoxDark.png";
                    }
                }
                else if (theme == ThemeEnum.Brown)
                {
                    // only set the TextColor on the first pass
                    if (!Rendered)
                    {
                        // Dark Blue
                        ButtonTextColor = Color.White;
                        ListBackgroundColor = Color.Brown;
                    }
                        
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBoxBrownOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBoxBrown.png";
                    }
                }
                else
                {
                    // only set the TextColor on the first pass
                    if (!Rendered)
                    {
                        // black
                        ButtonTextColor = Color.White;
                        ListBackgroundColor = Color.DarkGray;
                    }
                        
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBoxBlackOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBoxBlack.png";
                    }
                }
                    
                // if the Button exists
                if (HasComboBoxButton)
                {
                    // Update the Button
                    ComboBoxButton.Refresh();
                }
                    
                // Set Rendered to true
                Rendered = true;
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
                
            #region ButtonLeft
            /// <summary>
            /// This property gets or sets the value for 'ButtonLeft'.
            /// </summary>
            [Parameter]
            public double ButtonLeft
            {
                get
                {
                    double left = buttonLeft;
                        
                    // if expanded and the value is different for ExpandedButtonLeft
                    if ((expanded) && (buttonLeft != expandedButtonLeft))
                    {
                        // use ExpandedButtonLeft
                        left = ExpandedButtonLeft;
                    }
                        
                    return buttonLeft;
                }
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
                
            #region ButtonTextColor
            /// <summary>
            /// This property gets or sets the value for 'ButtonTextColor'.
            /// </summary>
            [Parameter]
            public Color ButtonTextColor
            {
                get { return buttonTextColor; }
                set { buttonTextColor = value; }
            }
            #endregion
                
            #region ButtonTextColorName
            /// <summary>
            /// This read only property returns the value of Name of the ButtonTextColor
            /// </summary>
            public string ButtonTextColorName
            {
                    
                get
                {
                    // initial value
                    string buttonTextColorName = ButtonTextColor.Name;
                        
                    // return value
                    return buttonTextColorName;
                }
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
                
            #region ComboBoxBackColor
            /// <summary>
            /// This property gets or sets the value for 'ComboBoxBackColor'.
            /// This is used for helping position the ComboBox.
            /// </summary>
            [Parameter]
            public Color ComboBoxBackColor
            {
                get { return comboBoxBackColor; }
                set { comboBoxBackColor = value; }
            }
            #endregion
                
            #region ComboBoxButton
            /// <summary>
            /// This property gets or sets the value for 'ComboBoxButton'.
            /// </summary>
            public ImageButton ComboBoxButton
            {
                get { return comboBoxButton; }
                set { comboBoxButton = value; }
            }
            #endregion
                
            #region ComboBoxHeight
            /// <summary>
            /// This property gets or sets the value for 'ComboBoxHeight'.
            /// </summary>
            [Parameter]
            public double ComboBoxHeight
            {
                get { return comboBoxHeight; }
                set 
                {
                    comboBoxHeight = value;

                    // Set the value for ComboBoxHeightStyle
                    comboBoxHeightStyle = ComboBoxHeight + HeightUnit;
                }
            }
            #endregion
            
            #region ComboBoxHeightStyle
            /// <summary>
            /// This property gets or sets the value for 'ComboBoxHeightStyle'.
            /// </summary>
            public string ComboBoxHeightStyle
            {
                get { return comboBoxHeightStyle; }
                set { comboBoxHeightStyle = value; }
            }
            #endregion
            
            #region ComboBoxLeft
            /// <summary>
            /// This property gets or sets the value for 'ComboBoxLeft'.
            /// </summary>
            [Parameter]
            public double ComboBoxLeft
            {
                get { return comboBoxLeft; }
                set { comboBoxLeft = value; }
            }
            #endregion
                
            #region ComboBoxLeftStyle
            /// <summary>
            /// This read only property returns the value of ComboBoxLeftStyle from the object ComboBoxLeft.
            /// </summary>
            public string ComboBoxLeftStyle
            {
                    
                get
                {
                    // initial value
                    string comboBoxLeftStyle = ComboBoxLeft + unit;
                        
                    // return value
                    return comboBoxLeftStyle;
                }
            }
            #endregion
                
            #region ComboBoxStyle
            /// <summary>
            /// This property gets or sets the value for 'ComboBoxStyle'.
            /// </summary>
            public string ComboBoxStyle
            {
                get { return comboBoxStyle; }
                set { comboBoxStyle = value; }
            }
            #endregion
                
            #region ComboBoxWidth
            /// <summary>
            /// This property gets or sets the value for 'ComboBoxWidth'.
            /// </summary>
            [Parameter]
            public double ComboBoxWidth
            {
                get { return comboBoxWidth; }
                set { comboBoxWidth = value; }
            }
            #endregion
                
            #region ComboBoxWidthStyle
            /// <summary>
            /// This read only property returns the value of ComboBoxWidthStyle from the object ComboBoxWidth.
            /// </summary>
            public string ComboBoxWidthStyle
            {
                    
                get
                {
                    // initial value
                    string comboBoxWidthStyle = ComboBoxWidth + Unit;
                        
                    // return value
                    return comboBoxWidthStyle;
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
                
            #region Expanded
            /// <summary>
            /// This property gets or sets the value for 'Expanded'.
            /// </summary>
            public bool Expanded
            {
                get { return expanded; }
                set
                {
                    expanded = value;
                        
                    // The button image changes on Expanded and Theme.
                    SetupComponent();
                }
            }
            #endregion
                
            #region ExpandedButtonLeft
            /// <summary>
            /// This property gets or sets the value for 'ExpandedButtonLeft'.
            /// This property is the left of the button when the control is expanded.
            /// The reason for this is one of my projects the button shifts right about 4 pixels.
            /// Kind of hack, but if it works I will leave it till I can solve the why it shifts.
            /// </summary>
            [Parameter]
            public double ExpandedButtonLeft
            {
                get { return expandedButtonLeft; }
                set { expandedButtonLeft = value; }
            }
            #endregion
                
            #region Grid
            /// <summary>
            /// This property gets or sets the value for 'Grid'.
            /// </summary>
            public string Grid
            {
                get { return grid; }
                set { grid = value; }
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
                
            #region HasComboBoxButton
            /// <summary>
            /// This property returns true if this object has a 'ComboBoxButton'.
            /// </summary>
            public bool HasComboBoxButton
            {
                get
                {
                    // initial value
                    bool hasComboBoxButton = (this.ComboBoxButton != null);
                        
                    // return value
                    return hasComboBoxButton;
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
                
            #region Items
            /// <summary>
            /// This property gets or sets the value for 'Items'.
            /// </summary>
            public List<Item> Items
            {
                get { return items; }
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
                
            #region LabelStyle
            /// <summary>
            /// This property gets or sets the value for 'LabelStyle'.
            /// </summary>
            public string LabelStyle
            {
                get { return labelStyle; }
                set { labelStyle = value; }
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
                set { labelTop = value; }
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
            /// This property gets or sets the value for 'LabelUnit'.
            /// This property is used with LabelLeft and LabelTop
            /// </summary>
            [Parameter]
            public string LabelUnit
            {
                get { return labelUnit; }
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
                
            #region NoPadding
            /// <summary>
            /// This property gets or sets the value for 'NoPadding'.
            /// </summary>
            public string NoPadding
            {
                get { return noPadding; }
                set { noPadding = value; }
            }
            #endregion
                
            #region OnChange
            /// <summary>
            /// This event is used to clients can get a notification when a selection was made
            /// </summary>
            [Parameter]
            public EventCallback<ChangeEventArgs> OnChange { get; set; }
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
                
            #region Rendered
            /// <summary>
            /// This property gets or sets the value for 'Rendered'.
            /// </summary>
            public bool Rendered
            {
                get { return rendered; }
                set { rendered = value; }
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
            [Parameter]
            public string TextSizeStyle
            {
                get { return textSizeStyle; }
                set { textSizeStyle = value; }
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
                        
                    // if the ListItemWidth is less than the width
                    if (ListItemWidth < width)
                    {
                        // Set the ListItemWidth to the width of the button
                        ListItemWidth = width;
                    }
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
                
            #region ZIndexMinus
            /// <summary>
            /// This read only property returns the value of Minus 10.
            /// </summary>
            public int ZIndexMinus
            {
                    
                get
                {
                    // initial value
                    int zIndexMinus =ZIndex - 10;
                        
                    // return value
                    return zIndexMinus;
                }
            }
            #endregion
                
            #region ZIndexMinusStyle
            /// <summary>
            /// This read only property returns the value of ZIndexMinus Minus 10.
            /// </summary>
            public string ZIndexMinusStyle
            {
                    
                get
                {
                    // initial value
                    string zIndexMinus = ZIndexMinus.ToString();
                        
                    // return value
                    return zIndexMinus;
                }
            }
            #endregion
                
            #region ZIndexPlus
            /// <summary>
            /// This read only property returns the value of ZIndexPlus Plus 10.
            /// </summary>
            public int ZIndexPlus
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
                
            #region ZIndexPlusStyle
            /// <summary>
            /// This read only property returns the value of ZIndexPlus Plus 10.
            /// </summary>
            public string ZIndexPlusStyle
            {
                    
                get
                {
                    // initial value
                    string zIndexPlus = ZIndexPlus.ToString();
                        
                    // return value
                    return zIndexPlus;
                }
            }
            #endregion
                
        #endregion
            
    }
    #endregion
    
}
