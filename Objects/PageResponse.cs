

#region using statements

using System;
using System.Collections;
using System.Collections.Generic;
using DataJuggler.UltimateHelper;

#endregion

namespace DataJuggler.Blazor.Components.Objects
{

    #region class PageResponse
    /// <summary>
    /// This class [Enter Class Description]
    /// </summary>
    public class PageResponse
    {
        
        #region Private Variables
        private int currentPage;
        private List<object> items;
        private int itemsPerPage;
        private int startIndex;
        private int totalCount;
        private int totalPages;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region CanMoveNext()
            /// <summary>
            /// method Can Move Next
            /// </summary>
            public bool CanMoveNext()
            {
                return ((CurrentPage + 1) < TotalPages);
            }
            #endregion
            
            #region CanMovePrevious()
            /// <summary>
            /// method Can Move Previous
            /// </summary>
            public bool CanMovePrevious()
            {
                return (CurrentPage > 0);
            }
            #endregion
            
            #region GetItems<T>()
            /// <summary>
            /// method returns a list of Items <T>
            /// </summary>
            public List<T> GetItems<T>()
            {
                return Items.ConvertAll(item => (T)item);
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region CurrentPage
            /// <summary>
            /// This property gets or sets the value for 'CurrentPage'.
            /// </summary>
            public int CurrentPage
            {
                get { return currentPage; }
                set { currentPage = value; }
            }
            #endregion
            
            #region Items
            /// <summary>
            /// This property gets or sets the value for 'Items'.
            /// </summary>
            public List<object> Items
            {
                get { return items; }
                set { items = value; }
            }
            #endregion
            
            #region ItemsPerPage
            /// <summary>
            /// This property gets or sets the value for 'ItemsPerPage'.
            /// </summary>
            public int ItemsPerPage
            {
                get { return itemsPerPage; }
                set { itemsPerPage = value; }
            }
            #endregion
            
            #region StartIndex
            /// <summary>
            /// This property gets or sets the value for 'StartIndex'.
            /// </summary>
            public int StartIndex
            {
                get { return startIndex; }
                set { startIndex = value; }
            }
            #endregion
            
            #region TotalCount
            /// <summary>
            /// This property gets or sets the value for 'TotalCount'.
            /// </summary>
            public int TotalCount
            {
                get { return totalCount; }
                set { totalCount = value; }
            }
            #endregion
            
            #region TotalPages
            /// <summary>
            /// This property gets or sets the value for 'TotalPages'.
            /// </summary>
            public int TotalPages
            {
                get { return totalPages; }
                set { totalPages = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
