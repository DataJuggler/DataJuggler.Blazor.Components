#region using statements

using System.Drawing;
using System.Globalization;

#endregion

namespace DataJuggler.Blazor.Components.Util
{

    #region class ColorHelper
    /// <summary>
    /// This class is used to convert a Color to a value that can be used in CSS.
    /// </summary>
    public class ColorHelper
    {

        #region Methods

            #region GetCssColor(Color color)
            /// <summary>
            /// This method returns a CSS color value for the color passed in. Named colors
            /// return the name, all other colors return rgb() or rgba() if partially transparent.
            /// </summary>
            public static string GetCssColor(Color color)
            {
                // initial value
                string cssColor = "";

                // if the color is not empty
                if (!color.IsEmpty)
                {
                    // if this is a named color
                    if (color.IsNamedColor)
                    {
                        // set the return value
                        cssColor = color.Name;
                    }
                    else if (color.A < 255)
                    {
                        // get the alpha as a value between 0 and 1
                        string alpha = (color.A / 255.0).ToString("0.##", CultureInfo.InvariantCulture);

                        // set the return value
                        cssColor = "rgba(" + color.R + ", " + color.G + ", " + color.B + ", " + alpha + ")";
                    }
                    else
                    {
                        // set the return value
                        cssColor = "rgb(" + color.R + ", " + color.G + ", " + color.B + ")";
                    }
                }

                // return value
                return cssColor;
            }
            #endregion

        #endregion

    }
    #endregion

}
