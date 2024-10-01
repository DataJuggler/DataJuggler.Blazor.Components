using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataJuggler.Blazor.Components.Delegates
{

    #region delegate void OnTextChange(string text);  
    /// <summary>
    /// This delegate is used to the TextBox can handle OnChange event being notified to subscribers 
    /// </summary>
    /// <param name="text"></param>
    public delegate void OnTextChange(string text);    
    #endregion

}
