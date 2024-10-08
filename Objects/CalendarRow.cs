

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components.Objects
{

    #region class CalendarRow
    /// <summary>
    /// This class represents a Row of DayObjects.
    /// You could also think of this as a Week as it
    /// will always contain 7 DayObjects.
    /// </summary>
    public class CalendarRow
    {
        
        #region Private Variables
        private List<DayObject> days;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CalendarRow' object.
        /// </summary>
        public CalendarRow()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a new collection of 'DayObject' objects.
                Days = new List<DayObject>();
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Days
            /// <summary>
            /// This property gets or sets the value for 'Days'.
            /// </summary>
            public List<DayObject> Days
            {
                get { return days; }
                set { days = value; }
            }
            #endregion
            
            #region HasDays
            /// <summary>
            /// This property returns true if this object has a 'Days'.
            /// </summary>
            public bool HasDays
            {
                get
                {
                    // initial value
                    bool hasDays = (this.Days != null);
                    
                    // return value
                    return hasDays;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
