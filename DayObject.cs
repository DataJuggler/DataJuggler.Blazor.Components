

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class DayObject
    /// <summary>
    /// This class is the Date object associated with each button.
    /// </summary>
    public class DayObject
    {
        
        #region Private Variables
        private DateTime date;        
        private bool thisMonth;
        private bool today;
        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// method returns the String
            /// </summary>
            public override string ToString()
            {
                // return Day as a string
                return Day.ToString();
            }
            #endregion
            
        #endregion

        #region Properties

            #region Date
            /// <summary>
            /// This property gets or sets the value for 'Date'.
            /// </summary>
            public DateTime Date
            {
                get { return date; }
                set { date = value; }
            }
            #endregion
            
            #region Day
            /// <summary>
            /// This read only property returns the value of Day from the object Date.
            /// </summary>
            public int Day
            {
                
                get
                {
                    // initial value
                    int day = Date.Day;
                    
                    // return value
                    return day;
                }
            }
            #endregion
            
            #region ThisMonth
            /// <summary>
            /// This property gets or sets the value for 'ThisMonth'.
            /// </summary>
            public bool ThisMonth
            {
                get { return thisMonth; }
                set { thisMonth = value; }
            }
            #endregion
            
            #region Today
            /// <summary>
            /// This property gets or sets the value for 'Today'.
            /// </summary>
            public bool Today
            {
                get { return today; }
                set { today = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
