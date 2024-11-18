

#region using statements

using System.Collections.Generic;

#endregion

namespace DataJuggler.Blazor.Components.Interfaces
{

    #region interface ILabelFont
    /// <summary>
    /// The purpose of this interface is seto set all comonents with a Label to have the same font name and size
    /// </summary>
    public interface ILabelFont
    {

        #region Properties

            #region LabelFontName
            /// <summary>
            /// This property gets or sets the LabelFontName.
            /// </summary>
            public string LabelFontName { get; set; }
            #endregion

            #region LabelFontSize
            /// <summary>
            /// This property gets or sets the LabelFontSize
            /// </summary>
            public double LabelFontSize { get; set; }
            #endregion

        #endregion

    }
    #endregion

}
