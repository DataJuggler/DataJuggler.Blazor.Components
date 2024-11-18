

#region using statements

using System.Collections.Generic;

#endregion

namespace DataJuggler.Blazor.Components.Interfaces
{

    #region interface ITextBoxFont
    /// <summary>
    /// The purpose of this interface is to set all the TextBoxes to the same Font Size and Font Name (Family)
    /// </summary>
    public interface ITextBoxFont
    {

        #region Properties

            #region TextBoxFontName
            /// <summary>
            /// This property gets or sets the TextBoxFontName.
            /// </summary>
            public string TextBoxFontName { get; set; }
            #endregion

            #region TextBoxFontSize
            /// <summary>
            /// This property gets or sets the TextBoxFontSize
            /// </summary>
            public double TextBoxFontSize { get; set; }
            #endregion

        #endregion

    }
    #endregion

}
