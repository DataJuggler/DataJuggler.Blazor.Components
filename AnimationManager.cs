

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class AnimationManager
    /// <summary>
    /// This class is used as a CascadingParameter for Sprites.
    /// </summary>
    public class AnimationManager
    {
        
        #region Private Variables
        private Timer timer;
        private int increment;
        private int interval;
        private bool started;
        private string display;
        private bool visible;
        #endregion

        #region Properties
        
            #region Display
            /// <summary>
            /// This property gets or sets the value for 'Display'.
            /// </summary>
            public string Display
            {
                get { return display; }
                set { display = value; }
            }
            #endregion
            
            #region Increment
            /// <summary>
            /// This property gets or sets the value for 'Increment'.
            /// </summary>
            public int Increment
            {
                get { return increment; }
                set { increment = value; }
            }
            #endregion
            
            #region Interval
            /// <summary>
            /// This property gets or sets the value for 'Interval'.
            /// </summary>
            public int Interval
            {
                get { return interval; }
                set { interval = value; }
            }
            #endregion
            
            #region Started
            /// <summary>
            /// This property gets or sets the value for 'Started'.
            /// </summary>
            public bool Started
            {
                get { return started; }
                set { started = value; }
            }
            #endregion
            
            #region Timer
            /// <summary>
            /// This property gets or sets the value for 'Timer'.
            /// </summary>
            public Timer Timer
            {
                get { return timer; }
                set { timer = value; }
            }
            #endregion
            
            #region Visible
            /// <summary>
            /// This property gets or sets the value for 'Visible'.
            /// This visible can be used for setting an entire scene visible or not.
            /// Subscribing Sprites' Visible properties are not affected.
            /// </summary>
            public bool Visible
            {
                get { return visible; }
                set { visible = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
