

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;

#endregion

namespace DataJuggler.Blazor.Components.Util
{

    #region class ComponentHelper
    /// <summary>
    /// This class is used to help with the interface method FindChildByName.
    /// </summary>
    public class ComponentHelper
    {
        
        #region Private Variables
        #endregion
        
        #region Methods
            
            #region FindChildByName(List<IBlazorComponent> children, string name)
            /// <summary>
            /// method Find Child By Name
            /// </summary>
            public static IBlazorComponent FindChildByName(List<IBlazorComponent> children, string name)
            {
                // initial value
                IBlazorComponent component = null;
                
                // If the component object exists
                if ((ListHelper.HasOneOrMoreItems(children)) && (TextHelper.Exists(name)))
                {
                    // Iterate the collection of IBlazorComponent objects
                    foreach (IBlazorComponent temp in children)
                    {
                        // if this is the item beign sought                        
                        if (TextHelper.IsEqual(temp.Name, name))
                        {
                            // set the return value
                            component = temp;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return component;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
