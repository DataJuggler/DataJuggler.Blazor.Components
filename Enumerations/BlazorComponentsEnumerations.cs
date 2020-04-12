using System;
using System.Collections.Generic;
using System.Text;

namespace DataJuggler.Blazor.Components.Enumerations
{

    #region ColorEnum : int
    /// <summary>
    /// This enum is used to set which type of images to show.
    /// </summary>
    public enum ColorEnum : int
    {
       Blue = 0,
       Green = 1,
       Orange = 2
    }
    #endregion

    #region SizeEnum : int
    /// <summary>
    /// This enum is used to set which size to render the progress bar.
    /// There is also a Scale property which can be used in conjunction.
    /// </summary>
    public enum SizeEnum : int
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
    #endregion
    
    #region ThemeEnum : int
    /// <summary>
    /// This enum is used to set which type of images to show.
    /// </summary>
    public enum ThemeEnum : int
    {
        Light = 0,
        Dark = 1
    }
    #endregion

}
