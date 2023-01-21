using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataJuggler.Blazor.Components
{
    /// <summary>
    /// This class is a work in progress.
    /// </summary>
    public partial class CheckedListBox
    {
        #region Private Variables
        private List<Item> items;
        private Item selectedItem;
        private string name;
        private string labelText;
        private bool visible;
        #endregion

        public CheckedListBox()
        {
            // default to visible
            Visible = true;
        }

        #region Properties

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
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
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
            
            #region Visible
            /// <summary>
            /// This property gets or sets the value for 'Visible'.
            /// </summary>
            public bool Visible
            {
                get { return visible; }
                set { visible = value; }
            }
            #endregion
            
        #endregion
    }
}
