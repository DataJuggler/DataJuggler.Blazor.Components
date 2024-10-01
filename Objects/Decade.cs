

#region using statements

using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components.Objects
{

    #region class Decade
    /// <summary>
    /// This class represents a period of 10 years, used by the Calendar component
    /// </summary>
    public class Decade
    {
        
        #region Private Variables
        private int startYear;
        private List<int> years;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region CreateDecades()
            /// <summary>
            /// returns a list of Decades
            /// </summary>
            public static List<Decade> CreateDecades()
            {
                // initial value
                List<Decade> decades = new List<Decade>();

                // get the current year
                int year = DateTime.Now.Year;
                int yearsIntoThisDecade = year % 10;
                int thisDecadeStartYear = DateTime.Now.Year - yearsIntoThisDecade;
                int startDecadeYear = thisDecadeStartYear - 90;

                // iterate the decades by year
                for (int x = startDecadeYear; x <= thisDecadeStartYear; x += 10)
                {
                    Decade decade = new Decade();
                    decade.StartYear = x;
                    
                    // Add the decade
                    decades.Add(decade);
                }
                
                // return value
                return decades;
            }
            #endregion
            
            #region CreateYears(Decade decade)
            /// <summary>
            /// returns a list of Years
            /// </summary>
            public static List<int> CreateYears(Decade decade)
            {
                // initial value
                List<int> years = new List<int>();

                int thisYear = DateTime.Now.Year;

                // If the decade object exists
                if (NullHelper.Exists(decade))
                {
                    // Iterate up to the number of years
                    for (int x = 0; x < 10; x++)
                    {
                        // if the year would be in the future
                        if (x > thisYear)
                        {
                            // exit
                            break;
                        }

                        // Add each year in this decade
                        years.Add(decade.StartYear + x);
                    }
                }
                
                // return value
                return years;
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region HasYears
            /// <summary>
            /// This property returns true if this object has a 'Years'.
            /// </summary>
            public bool HasYears
            {
                get
                {
                    // initial value
                    bool hasYears = (this.Years != null);
                    
                    // return value
                    return hasYears;
                }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This read only property returns the value of Name from the object StartYear.
            /// </summary>
            public string Name
            {
                
                get
                {
                    // initial value
                    string name = StartYear + "'s";
                    
                    // return value
                    return name;
                }
            }
            #endregion
            
            #region StartYear
            /// <summary>
            /// This property gets or sets the value for 'StartYear'.
            /// </summary>
            public int StartYear
            {
                get { return startYear; }
                set { startYear = value; }
            }
            #endregion
            
            #region Years
            /// <summary>
            /// This property gets or sets the value for 'Years'.
            /// </summary>
            public List<int> Years
            {
                get { return years; }
                set { years = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
