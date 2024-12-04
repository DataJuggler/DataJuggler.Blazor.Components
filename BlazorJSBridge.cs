

#region using statements

using Microsoft.JSInterop;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class BlazorJSBridge
    /// <summary>
    /// This class [Enter Class Description]
    /// </summary>
    public class BlazorJSBridge
    {
        
        #region Private Variables
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region CopyToClipboard(IJSRuntime jsRuntime, string textToCopy)
            /// <summary>
            /// method Copy To Clipboard
            /// </summary>
            public async static Task<int> CopyToClipboard(IJSRuntime jsRuntime, string textToCopy)
            {
                // set the value
                int copied = await jsRuntime.InvokeAsync<int>("BlazorJSFunctions.CopyText", textToCopy);
                
                // return value
                return copied;
            }
            #endregion
            
            #region HideElement(IJSRuntime jsRuntime, string elementId)
            /// <summary>
            /// method Hide Element
            /// </summary>
            public static ValueTask HideElement(IJSRuntime jsRuntime, string elementId)
            {
                return jsRuntime.InvokeVoidAsync("BlazorJSFunctions.HideElement", elementId);
            }
            #endregion
            
            #region Prompt(IJSRuntime jsRuntime, string message)
            /// <summary>
            /// method Prompt
            /// </summary>
            public static ValueTask<string> Prompt(IJSRuntime jsRuntime, string message)
            {
                // Implemented in BlazorJSInterop.js
                return jsRuntime.InvokeAsync<string>(
                "BlazorJSFunctions.ShowPrompt",
                message);
            }
            #endregion
            
            #region ShowElement(IJSRuntime jsRuntime, string elementId)
            /// <summary>
            /// method Show Element
            /// </summary>
            public static ValueTask ShowElement(IJSRuntime jsRuntime, string elementId)
            {
                return jsRuntime.InvokeVoidAsync("BlazorJSFunctions.ShowElement", elementId);
            }
            #endregion
            
            #region ShowThenHide(IJSRuntime jsRuntime, string elementId, int duration)
            /// <summary>
            /// method Show Then Hide
            /// </summary>
            public static ValueTask ShowThenHide(IJSRuntime jsRuntime, string elementId, int duration)
            {
                return jsRuntime.InvokeVoidAsync("BlazorJSFunctions.ShowThenHide", elementId, duration);
            }
            #endregion
            
        #endregion
        
        #region Properties
            
        #endregion
        
    }
    #endregion

}
