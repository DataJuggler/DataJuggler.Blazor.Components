#region using statements

using DataJuggler.UltimateHelper;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class BlazorJSBridge
    /// <summary>
    /// This class is used to call the JavaScript functions in BlazorJSInterop.js.
    /// Each call is wrapped in a try / catch so a disconnected circuit or missing function does not crash the component.
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
                // initial value
                int result = 0;

                try
                {
                    // Copy the text to the clipboard
                    result = await jsRuntime.InvokeAsync<int>("BlazorJSFunctions.CopyText", textToCopy);
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("CopyToClipboard", "BlazorJSBridge", error);
                }

                // return value
                return result;
            }
            #endregion
            
            #region DeleteCookie(IJSRuntime jsRuntime, string key)
            /// <summary>
            /// method Delete Cookie
            /// </summary>
            public static async ValueTask DeleteCookie(IJSRuntime jsRuntime, string key)
            {
                try
                {
                    // Delete the cookie
                    await jsRuntime.InvokeVoidAsync("BlazorJSFunctions.DeleteCookie", key);
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("DeleteCookie", "BlazorJSBridge", error);
                }
            }
            #endregion
            
            #region GetCookie(IJSRuntime jsRuntime, string key)
            /// <summary>
            /// method Get Cookie
            /// </summary>
            public static async ValueTask<string> GetCookie(IJSRuntime jsRuntime, string key)
            {
                // initial value
                string result = "";

                try
                {
                    // Get the cookie
                    result = await jsRuntime.InvokeAsync<string>("BlazorJSFunctions.GetCookie", key);
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("GetCookie", "BlazorJSBridge", error);
                }

                // return value
                return result;
            }
            #endregion
            
            #region HideElement(IJSRuntime jsRuntime, string elementId)
            /// <summary>
            /// method Hide Element
            /// </summary>
            public static async ValueTask HideElement(IJSRuntime jsRuntime, string elementId)
            {
                try
                {
                    // Hide the element
                    await jsRuntime.InvokeVoidAsync("BlazorJSFunctions.HideElement", elementId);
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("HideElement", "BlazorJSBridge", error);
                }
            }
            #endregion
            
            #region Prompt(IJSRuntime jsRuntime, string message)
            /// <summary>
            /// method Prompt
            /// </summary>
            public static async ValueTask<string> Prompt(IJSRuntime jsRuntime, string message)
            {
                // initial value
                string result = "";

                try
                {
                    // Show the prompt
                    result = await jsRuntime.InvokeAsync<string>("BlazorJSFunctions.ShowPrompt", message);
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("Prompt", "BlazorJSBridge", error);
                }

                // return value
                return result;
            }
            #endregion
            
            #region SetCookie(IJSRuntime jsRuntime, string key, string value, int expireDays = 30)
            /// <summary>
            /// method Set Cookie
            /// </summary>
            public static async ValueTask SetCookie(IJSRuntime jsRuntime, string key, string value, int expireDays = 30)
            {
                try
                {
                    // Set the cookie
                    await jsRuntime.InvokeVoidAsync("BlazorJSFunctions.SetCookie", key, value, expireDays);
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("SetCookie", "BlazorJSBridge", error);
                }
            }
            #endregion
            
            #region ShowElement(IJSRuntime jsRuntime, string elementId)
            /// <summary>
            /// method Show Element
            /// </summary>
            public static async ValueTask ShowElement(IJSRuntime jsRuntime, string elementId)
            {
                try
                {
                    // Show the element
                    await jsRuntime.InvokeVoidAsync("BlazorJSFunctions.ShowElement", elementId);
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("ShowElement", "BlazorJSBridge", error);
                }
            }
            #endregion
            
            #region ShowThenHide(IJSRuntime jsRuntime, string elementId, int duration)
            /// <summary>
            /// method Show Then Hide
            /// </summary>
            public static async ValueTask ShowThenHide(IJSRuntime jsRuntime, string elementId, int duration)
            {
                try
                {
                    // Show the element, then hide it
                    await jsRuntime.InvokeVoidAsync("BlazorJSFunctions.ShowThenHide", elementId, duration);
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("ShowThenHide", "BlazorJSBridge", error);
                }
            }
            #endregion
            
            #region DownloadFile(IJSRuntime jsRuntime, string url)
            /// <summary>
            /// method Download File
            /// </summary>
            public static async ValueTask DownloadFile(IJSRuntime jsRuntime, string url)
            {
                try
                {
                    // Download the file
                    await jsRuntime.InvokeVoidAsync("BlazorJSFunctions.DownloadFile", url);
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("DownloadFile", "BlazorJSBridge", error);
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
