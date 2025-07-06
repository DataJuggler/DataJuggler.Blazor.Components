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

    #region delegate void OnSaved(string text);  
    /// <summary>
    /// This delegate is used to handle the Save buttom click event from the SaveCancelControl
    /// </summary>
    /// <param name="componentName">The name of the Component in case there are more than one</param>
    public delegate void OnSaved(string componentName);
    #endregion

    #region delegate void OnSaved(string text);  
    /// <summary>
    /// This delegate is used to handle the Cancel buttom click event from the SaveCancelControl
    /// </summary>
    /// <param name="componentName">The name of the Component in case there are more than one</param>
    public delegate void OnCancelled(string componentName);
    #endregion

}
