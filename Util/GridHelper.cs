

#region using statements

using DataJuggler.Blazor.Components.Objects;
using DataJuggler.Excelerate;
using DataJuggler.UltimateHelper;
using System;
using System.Collections;
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
            
            #region GetPage<T>(List<T> items, int itemsPerPage = 0, int currentPage = -1)
            /// <summary>
            /// method returns the Page <T>
            /// </summary>
            public static PageResponse GetPage<T>(List<T> items, int itemsPerPage = 0, int currentPage = -1)
            {
                // initial value
                PageResponse response = new PageResponse();

                // create the list
                response.Items = new List<object>();

                // defaults
                response.ItemsPerPage = itemsPerPage;
                response.CurrentPage = currentPage;
                response.StartIndex = 0;
                response.TotalCount = 0;
                response.TotalPages = 0;

                // If the list exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(items))
                {
                    // set total count
                    response.TotalCount = items.Count;

                    // if paging is enabled
                    if (itemsPerPage > 0 && currentPage >= 0)
                    {
                        // calculate total pages
                        int totalPages = items.Count / itemsPerPage;

                        // if total pages is in range
                        if ((totalPages * itemsPerPage) < items.Count)
                        {
                            totalPages = totalPages + 1;
                        }

                        response.TotalPages = totalPages;

                        // compute start index
                        int start = itemsPerPage * currentPage;

                        if (start < items.Count)
                        {
                            response.StartIndex = start;

                            int remaining = items.Count - start;
                            int count;

                            if (itemsPerPage < remaining)
                            {
                                count = itemsPerPage;
                            }
                            else
                            {
                                count = remaining;
                            }

                            // add page items
                            for (int i = 0; i < count; i++)
                            {
                                response.Items.Add(items[start + i]);
                            }
                        }
                    }
                    else
                    {
                        // no paging requested, return all items
                        for (int i = 0; i < items.Count; i++)
                        {
                            response.Items.Add(items[i]);
                        }

                        response.TotalPages = 1;
                        response.StartIndex = 0;
                    }
                }

                // return value
                return response;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
