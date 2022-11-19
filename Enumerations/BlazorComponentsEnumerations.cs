using System;
using System.Collections.Generic;
using System.Text;

namespace DataJuggler.Blazor.Components.Enumerations
{

    #region AdjustmentTypeEnum : int
    /// <summary>
    /// This enum is the choices for the types of Adjustments for now
    /// </summary>
    public enum AdjustmentTypeEnum : int
    {
        NotSet = 0,
        X = 1,
        Y = 2,
        Rotation = 3,
        Opacity = 4
    }
    #endregion

    #region AdjustmentStatusEnum
    /// <summary>
    /// This enumeration represents the states of Adjustment
    /// </summary>
    public enum AdjustmentStatusEnum
    {
        Rejected = -1,
        NotApplied = 0,
        InProgress = 1,
        Applied = 2,
        AppliedAndCompleted = 3
    }
    #endregion

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

    #region TextSizeEnum : int
    /// <summary>
    /// This enum is used to set which size to render the progress bar.
    /// There is also a Scale property which can be used in conjunction.
    /// </summary>
    public enum TextSizeEnum : int
    {
        Extra_Small = 1,
        Small = 2,
        Medium = 3,
        Large = 4,
        Extra_Large = 5
    }
    #endregion
    
    #region ThemeEnum : int
    /// <summary>
    /// This enum is used to set which type of images to show.
    /// </summary>
    public enum ThemeEnum : int
    {
        Black = 0,
        Dark = 1,
        Blue = 2,
        Brown = 3
    }
    #endregion

}
