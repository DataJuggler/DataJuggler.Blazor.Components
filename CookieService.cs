

#region using statements

using Microsoft.JSInterop;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class CookieService
    /// <summary>
    /// This class is used to set Cookies via JS.
    /// </summary>
    public class CookieService
    {
        
        #region Private Variables
        private readonly IJSRuntime jsRuntime;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CookieService' object.
        /// </summary>
        public CookieService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region DeleteCookieAsync(string key)
            /// <summary>
            /// method Delete Cookie Async
            /// </summary>
            public async Task DeleteCookieAsync(string key)
            {
                await BlazorJSBridge.DeleteCookie(jsRuntime, key);
            }
            #endregion
            
            #region GetCookieAsync(string key)
            /// <summary>
            /// method Get Cookie Async
            /// </summary>
            public async Task<string> GetCookieAsync(string key)
            {
                return await BlazorJSBridge.GetCookie(jsRuntime, key);
            }
            #endregion
            
            #region SetCookieAsync(string key, string value, int expireDays = 30)
            /// <summary>
            /// method Set Cookie Async
            /// </summary>
            public async Task SetCookieAsync(string key, string value, int expireDays = 30)
            {
                await BlazorJSBridge.SetCookie(jsRuntime, key, value, expireDays);
            }
            #endregion
            
        #endregion
        
        #region Properties
            
        #endregion
        
    }
    #endregion

}
