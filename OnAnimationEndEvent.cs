#region using statements

using Microsoft.AspNetCore.Components;
using System;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class OnAnimationEndEvent
    /// <summary>
    /// This class registers the animation events that Blazor does not support by default
    /// </summary>
    [EventHandler("onanimationend", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    public static class OnAnimationEndEvent
    {
    }
    #endregion

}