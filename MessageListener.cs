using System;
using System.Collections.Generic;
using System.Text;

namespace DataJuggler.Blazor.Components
{
    /// <summary>
    /// This delegate is used so components can handle showing their own message.
    /// </summary>
    /// <param name="message"></param>
    public delegate void MessageListener(Message message);
}
