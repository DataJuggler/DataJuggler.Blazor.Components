

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
    public static class BlazorJSBridge
    {  
        
        #region Methods
            
            #region CopyToClipboard(IJSRuntime jsRuntime, string textToCopy)
            /// <summary>
            /// method Copy To Clipboard
            /// </summary>
            public static async Task<int> CopyToClipboard(IJSRuntime jsRuntime, string textToCopy)
            {
                return await jsRuntime.InvokeAsync<int>("BlazorJSFunctions.CopyText", textToCopy);
            }
            #endregion
            
            #region DeleteCookie(IJSRuntime jsRuntime, string key)
            /// <summary>
            /// method Delete Cookie
            /// </summary>
            public static ValueTask DeleteCookie(IJSRuntime jsRuntime, string key)
            {
                return jsRuntime.InvokeVoidAsync("BlazorJSFunctions.DeleteCookie", key);
            }
            #endregion
            
            #region GetCookie(IJSRuntime jsRuntime, string key)
            /// <summary>
            /// method Get Cookie
            /// </summary>
            public static ValueTask<string> GetCookie(IJSRuntime jsRuntime, string key)
            {
                return jsRuntime.InvokeAsync<string>("BlazorJSFunctions.GetCookie", key);
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
                return jsRuntime.InvokeAsync<string>("BlazorJSFunctions.ShowPrompt", message);
            }
            #endregion
            
            #region SetCookie(IJSRuntime jsRuntime, string key, string value, int expireDays = 30)
            /// <summary>
            /// method Set Cookie
            /// </summary>
            public static ValueTask SetCookie(IJSRuntime jsRuntime, string key, string value, int expireDays = 30)
            {
                return jsRuntime.InvokeVoidAsync("BlazorJSFunctions.SetCookie", key, value, expireDays);
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
        
    }
    #endregion

}
