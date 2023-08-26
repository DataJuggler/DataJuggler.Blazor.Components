

#region using statements

using DataJuggler.Blazor.Components.Util;

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
        private string name;        
        #endregion
        
        #region Constructors
            
            #region Constructor
            /// <summary>
            /// Create a new instance of a 'Item' object.
            /// </summary>
            public Item()
            {
            }
            #endregion
            
            #region Constructor
            /// <summary>
            /// Create a new instance of a 'Item' object.
            /// </summary>
            public Item(int id, string name, string text)
            {
                // store args
                Id = id;
                Name = name;
                Text = text;
            }
            #endregion
            
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
