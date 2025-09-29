#region using statements

using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components.Interfaces
{

    #region interface IBlazorComponentParentAsync
    /// <summary>
    /// This interface is used to host IBlazorComponentAsync objects.
    /// </summary>
    public interface IBlazorComponentParentAsync
    {
        
        #region Methods

            #region ReceiveDataAsync(Message message)
            /// <summary>
            /// Send data from a child component to the parent component or page.
            /// </summary>
            Task ReceiveDataAsync(Message message);
            #endregion

            #region RefreshAsync()
            /// <summary>
            /// Call StateHasChanged (or equivalent) to refresh the UI.
            /// </summary>
            Task RefreshAsync();
            #endregion

            #region RegisterAsync(IBlazorComponentAsync component)
            /// <summary>
            /// Called by a child to register with its parent and begin sending events/messages.
            /// </summary>
            Task RegisterAsync(IBlazorComponentAsync component);
            #endregion

        #endregion

    }
    #endregion

}