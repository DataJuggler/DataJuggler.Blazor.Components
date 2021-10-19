

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.Blazor.Components.Enumerations;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class AdjustmentResult
    /// <summary>
    /// This class is used by the Sprite to apply adjustments, and 
    /// if the Adjustment just caused the trigger to end and adjustment.
    /// The purpose is so there is not so much code in one method to 
    /// test if min or maximums were just reached.
    /// </summary>
    public class AdjustmentResult
    {

        #region Private Variables
        private double newValue;
        private bool minimumSet;
        private bool maximumSet;
        private AdjustmentStatusEnum status;
        #endregion

        #region Properties

            #region MaximumSet
            /// <summary>
            /// This property gets or sets the value for 'MaximumSet'.
            /// </summary>
            public bool MaximumSet
            {
                get { return maximumSet; }
                set { maximumSet = value; }
            }
            #endregion
            
            #region MinimumSet
            /// <summary>
            /// This property gets or sets the value for 'MinimumSet'.
            /// </summary>
            public bool MinimumSet
            {
                get { return minimumSet; }
                set { minimumSet = value; }
            }
            #endregion
            
            #region NewValue
            /// <summary>
            /// This property gets or sets the value for 'NewValue'.
            /// </summary>
            public double NewValue
            {
                get { return newValue; }
                set { newValue = value; }
            }
            #endregion
            
            #region Status
            /// <summary>
            /// This property gets or sets the value for 'Status'.
            /// </summary>
            public AdjustmentStatusEnum Status
            {
                get { return status; }
                set { status = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
