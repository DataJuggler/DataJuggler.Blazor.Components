using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataJuggler.Blazor.Components.Util
{
    public class ItemHelper
    {  

        #region FindItemIndexByText(List<Item> items, string text)
        /// <summary>
        /// returns the Item Index By Text.
        /// </summary>
        public static int FindItemIndexByText(List<Item> items, string text)
        {
            // initial value
            int index = -1;

            // local
            int temp = -1;

            // if CheckedListMode is true and the CheckedListComponent exists
            if (ListHelper.HasOneOrMoreItems(items))
            {  
                // Iterate the collection of Item objects
                foreach (Item item in items)
                {
                    // Increment the value for temp
                    temp++;

                    // if this is the item being sought
                    if (TextHelper.IsEqual(item.Text, text))
                    {
                        // set the return value
                        index = temp;

                        // break out of the loop
                        break;
                    }
                }                  
            }
                
            // return value
            return index;
        }
        #endregion    

        #region LoadItems(List<T> items, bool addEmptyRowAtTop = false)
        /// <summary>
        /// This method loads a list of any type
        /// </summary>
        public List<Item> LoadItems<T>(List<T> rawList, bool addEmptyRowAtTop = false)
        {      
            // initial value
            List<Item> items = new List<Item>();

            // if the list exists
            if ((rawList != null) && (rawList.Count > 0))
            {
                // if addEmptyRowAtTop is true
                if (addEmptyRowAtTop)
                {
                    // Add the empty item
                    Item item = new Item();
                    item.Text = "";
                    item.Id = 0;
                        
                    // Add this item
                    items.Add(item);
                }
                    
                // iterate the list
                foreach (object tempItem in items)
                {
                    Item item = new Item();
                    item.Text = tempItem.ToString();
                    item.Id = items.Count + 1;
                    items.Add(item);
                }
            }

            // return value
            return items;
        }
        #endregion
            
        #region LoadItems(Type enumType)
        /// <summary>
        /// This method loads a combobox with the enum values
        /// </summary>
        public static List<Item> LoadItems(Type enumType)
        {
            // initial value
            List<Item> items = new List<Item>();;

            // locals
            string[] names = null;
            Array values = null;
            int index = -1;
            string formattedName = "";
                
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
                        items.Add(item);
                    }
                }
            }

            // return value
            return items;
        }
        #endregion

    }
}
