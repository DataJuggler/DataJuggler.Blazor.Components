#region using statements

using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components.Interfaces
{
    /// <summary>
    /// Async-capable interface for communication between a Blazor component
    /// and a parent component or page.
    /// </summary>
    public interface IBlazorComponentAsync
    {
        #region Methods

            /// <summary>
            /// Send data from a child component to the parent component or page.
            /// </summary>
            Task ReceiveDataAsync(Message message);

        #endregion

        #region Properties

            /// <summary>
            /// Gets or sets the Name.
            /// </summary>
            string Name { get; set; }

            /// <summary>
            /// Gets or sets the Parent component or page for this object.
            /// </summary>
            IBlazorComponentParent Parent { get; set; }

        #endregion
    }
}