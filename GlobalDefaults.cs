

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class GlobalConstants
    /// <summary>
    /// This class is used to values are not 
    /// </summary>
    public class GlobalDefaults
    {
    
        #region Properties

            #region Column1Width
            /// <summary>
            /// The default column width for the 1st column, usually labels
            /// </summary>
            public const int Column1Width = 100;
            #endregion

            #region Column2Width
            /// <summary>
            /// The default column width for the 2nd column, usually a TextBox
            /// </summary>
            public const int Column2Width = 124;
            #endregion

            #region Column3Width
            /// <summary>
            /// The default column width for the 3rd column, probably an image
            /// </summary>
            public const int Column3Width = 24;
            #endregion

            #region LabelClassName
            /// <summary>
            /// A default LabelClassName
            /// </summary>
            public const string LabelClassName = "down4 right2";
            #endregion
            
            #region LabelFontName
            /// <summary>
            /// This property returns the Default Font Name for Labels
            /// </summary>
            public const string LabelFontName = "Calibri";
            #endregion
            
            #region LabelFontSize
            /// <summary>
            /// This property returns the Default Font Size for Labels
            /// </summary>
            public const double LabelFontSize = 14;
            #endregion

            #region ListItemHeight
            /// <summary>
            /// This is the default Height for items in a list
            /// </summary>
            public const int ListItemHeight = 18;
            #endregion

            #region ListItemZIndex
            /// <summary>
            /// This is the default ListZIndex
            /// </summary>
            public const int ListItemZIndex = 100;
            #endregion

            #region ListZIndex
            /// <summary>
            /// This is the default ListZIndex
            /// </summary>
            public const int ListZIndex = 80;
            #endregion

            #region TextBoxFontName
            /// <summary>
            /// This property returns the Default Font Name for TextBoxs
            /// </summary>
            public const string TextBoxFontName = "Calibri";
            #endregion
            
            #region TextBoxFontSize
            /// <summary>
            /// This property returns the Default Font Size for TextBoxs
            /// </summary>
            public const double TextBoxFontSize = 14;
            #endregion

            #region TextBoxWidth
            /// <summary>
            /// The default Width for TextBoxes
            /// </summary>
            public const double TextBoxWidth = 120;
            #endregion
            
        #endregion
        
    }
    #endregion

}
