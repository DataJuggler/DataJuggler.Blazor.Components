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
            

    }
}
