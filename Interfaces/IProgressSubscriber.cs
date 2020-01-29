
namespace DataJuggler.Blazor.Components.Interfaces
{

    #region interface IProgressSubscriber
    /// <summary>
    /// This interface is used by the ProgressManager to notifiy callers that a refresh is needed.
    /// </summary>
    public interface IProgressSubscriber
    {

        #region Methods
            
            #region Refresh(string message)
            /// <summary>
            /// This method will call StateHasChanged to refresh the UI
            /// </summary>
            void Refresh(string message);
            #endregion

            #region Register(ProgressBar progressBar)
            /// <summary>
            /// This method is called by the ProgressBar to a subscriber so it can register with the subscriber, and 
            /// receiver events after that.
            /// </summary>
            void Register(ProgressBar progressBar);
        #endregion

        #endregion

        #region Properties

            #region ProgressBar
            /// <summary>
            /// This is used so the ProgressBar is stored and available to the Subscriber after Registering
            /// </summary>
            ProgressBar ProgressBar { get; set; }
            #endregion

        #endregion

    }
    #endregion

}
