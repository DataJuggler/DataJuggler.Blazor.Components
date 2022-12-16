

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

            #region ReceiveData(Message message)
            /// <summary>
            /// This method is used to send Data from a child component to the parent component or page.
            /// </summary>
            /// <param name="data"></param>
            void ReceiveData(Message message);
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
