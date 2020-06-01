
namespace BlazorChat.Enumerations
{

    #region BubbleColorEnum : int
    /// <summary>
    /// This enum is used to determine which url to show
    /// </summary>
    public enum BubbleColorEnum : int
    {
        NotSet = 0,
        BlueGreen = 1,        
        BlueRed = 2,
        GreenBlue = 3,
        GreenRed = 4,
        RedBlue = 5,
        RedGreen = 6,
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
