using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataJuggler.Blazor.Components
{
    /// <summary>
    /// This delegate is used to send messages to any subscribers
    /// </summary>    
    /// <returns></returns>
    public delegate void Callback(SubscriberMessage message);

    /// <summary>
    /// This delegate is used to handle button clicks
    /// </summary>
    /// <param name="buttonNumber"></param>
    /// <param name="buttonText"></param>
    public delegate void ButtonClickedHandler(int buttonNumber, string buttonText);
}
