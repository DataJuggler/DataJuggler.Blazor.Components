

#region using statements

using DataJuggler.Blazor.Components.Objects;
using DataJuggler.Excelerate;
using DataJuggler.NET.Data.Interfaces;
using DataJuggler.UltimateHelper;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using Column = DataJuggler.Excelerate.Column;
using Row = DataJuggler.Excelerate.Row;

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

            #region ConvertGridColumnsToColumns(List<GridColumn> sourceColumns)
            /// <summary>
            /// Converts the Grid Columns To Columns
            /// </summary>
            public static List<Column> ConvertGridColumnsToColumns(List<GridColumn> sourceColumns)
            {
                // initial value
                List<Column> columns = new List<Column>();

                // locals
                Column column = null;
                int index = -1;

                // if the Columns exist
                if (ListHelper.HasOneOrMoreItems(sourceColumns))
                {
                    // Create the Columns object
                    columns = new List<Column>();

                    // Iterate the collection of GridColumn objects
                    foreach (GridColumn gridColumn in sourceColumns)
                    {
                        // Increment the value for index
                        index++;

                        // Create a new instance of a 'column' object.
                        column = new Column();

                        // map properties
                        column.BorderWidth = gridColumn.BorderWidth;
                        column.ColumnName = gridColumn.Name;
                        column.ColumnNumber = gridColumn.ColumnNumber;
                        column.Caption = gridColumn.Caption;
                        column.ClassName = gridColumn.ClassName;
                        column.DataType = gridColumn.DataType;
                        column.FieldName = gridColumn.FieldName;
                        column.Format = gridColumn.Format;
                        column.Height = gridColumn.Height;
                        column.PrimaryKey = gridColumn.PrimaryKey;
                        column.Width = gridColumn.Width;

                        // Set these values
                        column.Index = index;
                        column.ColumnNumber = index + 1;

                        // Column.Visible doesn’t exist — use Hidden instead
                        column.Hidden = !gridColumn.Visible;

                        // Add this column to the collection
                        columns.Add(column);
                    }
                }

                // return value
                return columns;
            }
            #endregion

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
            
            #region GetPage<IGridValueProvider>(List<IGridValueProvider> items, , List<Column> columns, int itemsPerPage = 0, int currentPage = -1)
            /// <summary>
            /// method returns a PageResponse
            /// </summary>
            public static PageResponse GetPage<IGridValueProvider>(List<IGridValueProvider> items, List<Column> columns, int itemsPerPage = 0, int currentPage = -1)
            {
                // initial value
                PageResponse response = new PageResponse();

                // set the columns, so the PageResponse object can create Rows
                response.Columns = columns;

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

            #region GetPage<IGridValueProvider>(List<IGridValueProvider> items, , List<GridColumn> gridColumns, int itemsPerPage = 0, int currentPage = -1)
            /// <summary>
            /// method returns a PageResponse
            /// </summary>
            public static PageResponse GetPage<IGridValueProvider>(List<IGridValueProvider> items, List<GridColumn> gridColumns, int itemsPerPage = 0, int currentPage = -1)
            {
                // initial value
                PageResponse response = new PageResponse();
            
                // convert the columns
                List<Column> columns = ConvertGridColumnsToColumns(gridColumns);

                // set the columns, so the PageResponse object can create Rows
                response.Columns = columns;

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