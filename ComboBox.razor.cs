

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

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class ComboBox
    /// <summary>
    /// This class is designed to make a DropDownList easier to work with.
    /// </summary>
    public partial class ComboBox : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private List<Item> items;
        private Item selectedItem;
        private string name;
        private string labelText;
        private string grid;
        private string labelStyle;
        private double labelSize;
        private string labelSizeStyle;
        private string comboBoxStyle;        
        private TextSizeEnum textSize;
        private string textSizeStyle;
        private bool expanded;
        private IBlazorComponentParent parent;
        private string buttonUrl;
        private string buttonText;
        private string imagePath;
        private string listItemStyle;
        private List<IBlazorComponent> children;
        private const string ComboBoxButtonName = "ComboBoxButton";
        private ImageButton comboBoxButton;
        private string noPadding;
        private bool visible;
        private string displayStyle;
        private double left;
        private double top;
        private string leftStyle;
        private string topStyle;
        private double height;
        private double width;
        private string heightStyle;
        private string widthStyle;
        private string position;
        private string labelColor;
        private int visibleCount;
        private string verticalCenter;
        private int zIndex;
        private double labelMarginRight;
        private string labelMarginRightStyle;
        private double labelMarginRightList;
        private string labelMarginRightListStyle;
        private double listItemWidth;
        private string listItemWidthStyle;
        private double buttonWidth;
        private string className;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a ComboBox object
        /// </summary>
        public ComboBox()
        {
            // Default to 30% for the lable, the rest goes to the ComboBox
            LabelSize = 30;
            ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBox.png";
            ButtonText = "[Button Text]";
            TextSize = TextSizeEnum.Medium;
            Children = new List<IBlazorComponent>();
            Visible = true;
            Left = 0;
            Top = 0;
            Height = 6;
            Width = 100;
            Position = "relative";
            VisibleCount = 5;
            ZIndex = 0;
            LabelMarginRight = 1.6;
            LabelMarginRightList = 1.6;
            ButtonWidth = 200;
            ListItemWidth = 120;            
            
            // Set so the image is set
            Expanded = false;
        }
        #endregion

        #region Events

            #region SelectionChanged(ChangeEventArgs selectedItem)
            /// <summary>
            /// event is fired when On Change
            /// </summary>            
            public void SelectionChanged(ChangeEventArgs selectedItem)
            {  
                // Set the selectedItem
                ButtonText = selectedItem.Value.ToString();

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

            #region ButtonClicked(int buttonNumber, string buttonText)
            /// <summary>
            /// Button Clicked
            /// </summary>
            public void ButtonClicked(int buttonNumber, string buttonText)
            {
                // if the TextSize button was clicked
                if ((buttonNumber == 1) && (HasComboBoxButton))
                {
                    // Set the value for expanded or not
                    Expanded = !Expanded;                    
                }

                // Update the UI
                Refresh();
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

            #region LoadItems<T>(List<T> items, bool addEmptyRowAtTop = false)
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
                    }

                    // Update Async
                    Refresh();
                }
            }
            #endregion

            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // if a message exists
                if (NullHelper.Exists(message))
                { 
                    // Refresh
                    Refresh();
                }
            }
            #endregion

            #region Register(IBlazorComponent component)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                // Add this item
                this.Children.Add(component);

                // if this is the Button registering
                if (TextHelper.IsEqual(component.Name, ComboBoxButtonName))
                {
                    // Store the ComboBoxButton
                    ComboBoxButton = component as ImageButton;

                    // if the value for HasComboBoxButton is true
                    if (HasComboBoxButton)
                    {
                        // Setup the click handler
                        ComboBoxButton.ClickHandler = ButtonClicked;
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
            
        #endregion

        #region Properties

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

                    // Set the button url
                    if (expanded)
                    {
                        // Use Open
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBoxOpen.png";

                    }
                    else
                    {
                        // Use Closed
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/ComboBox.png";
                    }
                }
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
                    HeightStyle = height + "vh";
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
                set { items = value; }
            }
            #endregion

            #region LabelColor
            /// <summary>
            /// This property gets or sets the value for 'LabelColor'.
            /// </summary>
            [Parameter]
            public string LabelColor
            {
                get { return labelColor; }
                set { labelColor = value; }
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
                    LabelMarginRightStyle = labelMarginRight + "%";
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
                    labelMarginRightListStyle = labelMarginRightList + "%";
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
            
            #region LabelSize
            /// <summary>
            /// This property gets or sets the value for 'LabelSize'.
            /// </summary>
            [Parameter]
            public double LabelSize
            {
                get { return labelSize; }
                set 
                { 
                    labelSize = value;

                    // append %
                    labelSizeStyle = labelSize + "%";
                }
            }
            #endregion
            
            #region LabelSizeStyle
            /// <summary>
            /// This property gets or sets the value for 'LabelSizeStyle'.
            /// </summary>
            public string LabelSizeStyle
            {
                get { return labelSizeStyle; }
                set { labelSizeStyle = value; }
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
            
            #region ListItemWidth
            /// <summary>
            /// This property gets or sets the value for 'ListItemWidth'.
            /// </summary>
            public double ListItemWidth
            {
                get { return listItemWidth; }
                set 
                { 
                    listItemWidth = value;

                    // Set the value
                    ListItemWidthStyle = listItemWidth + "%";
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
            
            #region VerticalCenter
            /// <summary>
            /// This property gets or sets the value for 'VerticalCenter'.
            /// </summary>
            public string VerticalCenter
            {
                get { return verticalCenter; }
                set { verticalCenter = value; }
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

                    // if visible is true
                    if (visible)
                    {
                        // Show
                        DisplayStyle = "grid";
                    }
                    else
                    {
                        // hide
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

                    // Set the WidthStyle
                    WidthStyle = width + "%";
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
