

#region using statements

using DataJuggler.Excelerate;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components.Util
{

    #region class GridHelper
    /// <summary>
    /// This class is used to save duplication of code involving finding and saving rows and columns.
    /// </summary>
    public class GridHelper
    {

        #region Methods

            #region FindRow(List<Row> rows, Guid rowId)
            /// <summary>
            /// method returns the Row
            /// </summary>
            public static Row FindRow(List<Row> rows, Guid rowId)
            {
                // initial value
                Row row = null;

                // If the row collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(rows))
                {
                    // Iterate the collection of Row objects
                    foreach (Row tempRow in rows)
                    {
                        // if the RowId matches
                        if (tempRow.Id == rowId)
                        {
                            // set the return value
                            row = tempRow;

                            // break out of loop
                            break;
                        }
                    }
                }
                
                // return value
                return row;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
