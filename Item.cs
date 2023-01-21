

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class Item
    /// <summary>
    /// This class is used by the ComboBox to set the values
    /// </summary>
    public class Item
    {
        
        #region Private Variables
        private int id;
        private string text;
        private bool itemChecked;
        #endregion

        #region Properties

            #region Id
            /// <summary>
            /// This property gets or sets the value for 'Id'.
            /// </summary>
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            #endregion
            
            #region ItemChecked
            /// <summary>
            /// This property gets or sets the value for 'ItemChecked'.
            /// </summary>
            public bool ItemChecked
            {
                get { return itemChecked; }
                set { itemChecked = value; }
            }
            #endregion
            
            #region Text
            /// <summary>
            /// This property gets or sets the value for 'Text'.
            /// </summary>
            public string Text
            {
                get { return text; }
                set { text = value; }
            }
            #endregion
            
        #endregion

        
    }
    #endregion

}
