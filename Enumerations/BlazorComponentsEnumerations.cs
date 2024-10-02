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

    #region HandleChangeEnum : int
    /// <summary>
    /// This enum is used to handle how the oninput is bound in the TextBoxComponent
    /// </summary>
    public enum HandleChangeEnum : int
    {
        OnKeyDown = 0,
        OnChange = 1
    }
    #endregion

    #region ImageAlignmentEnum : int
    /// <summary>
    /// This enum is used by the Item object, but only in an InfoformationBox
    /// </summary>
    public enum ImageAlignmentEnum : int
    {
        NoImage = 0,
        ImageOnly = 1,
        ImageOnLeftOfText = 2,
        ImageOnRightOfText = 3
    }
    #endregion

    #region ItemContenteAlignmentEnum : int
    /// <summary>
    /// This enum is how the InformationBox displays Items.
    /// </summary>
    public enum ItemContenteAlignmentEnum : int
    {
        ItemsOnly = -1,
        ItemsOnTop = 0,
        ItemsOnBottom = 1
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

    #region TextAlignmentEnum : int
    /// <summary>
    /// The choices for Text Alignment
    /// </summary>
    public enum TextAlignmentEnum : int
    {
        Left = 0,
        Center = 1,
        Right = 2
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
        SmallMedium = 3,
        Medium = 4,
        MediumLarge = 5,
        Large = 6,
        Extra_Large = 7
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
        Brown = 3,
        Red = 4,
        BlueGold = 5
    }
    #endregion

    #region TimeTypeEnum : int
    /// <summary>
    /// The type of time. Hours 12 has AM or PM and Hours 24 or military time, does not.
    /// </summary>
    public enum TimeTypeEnum : int
    {
        Hours12 = 0,
        Hours24 = 1
    }
    #endregion

    #region VerticalAlignmentEnum : int
    /// <summary>
    /// This enum is used to set which type of vertical align. This is a subset
    /// of CSS for the simple types. Top is the Default.
    /// </summary>
    public enum VerticalAlignmentEnum : int
    {
        Top = 0,
        Bottom = 1,
        Middle = 2
    }
    #endregion

    #region YearSelectorAlignmentEnum : int
    /// <summary>
    /// This is used as an easy way for people to position the YearSelector on Left or Right.
    /// May add bottom if ever needed.
    /// </summary>
    public enum YearSelectorAlignmentEnum : int
    {
        OnRight = 0,
        OnLeft = 1,
        Custom = 2
    }
    #endregion

}
