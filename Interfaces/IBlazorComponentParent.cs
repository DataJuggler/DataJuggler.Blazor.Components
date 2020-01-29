﻿

#region using statements

using System.Collections.Generic;

#endregion

namespace DataJuggler.Blazor.Components.Interfaces
{

    #region interface IBlazorComponentParent
    /// <summary>
    /// This interface is used to host IBlazorComponent objects
    /// </summary>
    public interface IBlazorComponentParent
    {
        
        #region Methods

            #region ReceiveData(List<object> data, string message = "")
            /// <summary>
            /// This method is used to send data from a child component to the parent.
            /// </summary>
            /// <param name="data"></param>
            void ReceiveData(List<object> data, string message = "");
            #endregion

            #region Refresh()
            /// <summary>
            /// This method will call StateHasChanged to refresh the UI
            /// </summary>
            void Refresh();
            #endregion

            #region Register(IBlazorComponent component)
            /// <summary>
            /// This method is called by the Sprite to a subscriber so it can register with the subscriber, and 
            /// receiver events after that.
            /// </summary>
            void Register(IBlazorComponent component);

        #endregion

        #endregion

        #region Properties

            #region Children
            /// <summary>
            /// This property gets or sets the value for Children.
            /// </summary>
            public List<IBlazorComponent> Children { get; set; }
            #endregion

        #endregion

    }
    #endregion

}
