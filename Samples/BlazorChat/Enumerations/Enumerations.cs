using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChat.Enumerations
{

    #region BubbleColorEnum : int
    /// <summary>
    /// This theme is used to determine which image url to show.
    /// </summary>
    public enum BubbleColorEnum : int
    {
        NotSet = 0,
        Blue = 1,
        Green = 2,
        Orange = 3,
        Purple = 4,
        Red = 5,
        Yellow = 6
    }
    #endregion

    #region ScreenTypeEnum : int
    /// <summary>
    /// This enum is used to determine which part of the screen is visible at any time
    /// </summary>
    public enum ScreenTypeEnum : int
    {
        Main = 0,
        Join = 1,
        Login = 2
    }
    #endregion

}
