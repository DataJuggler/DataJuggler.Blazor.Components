using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChat.Enumerations
{

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

    #region StartGameOptionEnum : int
    /// <summary>
    /// This enum is used to determine who should go first on a new game.
    /// </summary>
    public enum StartGameOptionEnum : int
    {
        Random_First_Move = 0,
        Player_Goes_First = 1,
        Computer_Goes_First = 2
    }
    #endregion

    #region TurnEnum : int
    /// <summary>
    /// This enum is used to set whose turn it is to move
    /// </summary>
    public enum TurnEnum : int
    {
        GameNotStarted = -1,
        ComputerTurn = 0,
        PlayerTurn = 1
    }
    #endregion

}
