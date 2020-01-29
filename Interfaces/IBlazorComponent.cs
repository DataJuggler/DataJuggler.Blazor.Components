

#region using statements

using System.Collections.Generic;

#endregion

namespace DataJuggler.Blazor.Components.Interfaces
{

    #region interface IBlazorComponent
    /// <summary>
    /// This interface allows communication between a blazor componetn and a parent component or page.
    /// </summary>
    public interface IBlazorComponent
    {

        #region Methods

            #region ReceiveData(List<object> data, string message = "")
            /// <summary>
            /// This method is used to send data from a child component to the parent.
            /// </summary>
            /// <param name="data"></param>
            void ReceiveData(List<object> data, string message = "");
            #endregion

        #endregion

        #region Properties

            #region Name
            /// <summary>
            /// This property gets or sets the Name.
            /// </summary>
            public string Name { get; set; }
            #endregion

            #region Parent
            /// <summary>
            /// This property gets or sets the Parent componet or page for this object.
            /// </summary>
            public IBlazorComponentParent Parent { get; set; }
            #endregion

        #endregion

    }
    #endregion

}
