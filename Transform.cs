

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.UltimateHelper;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class Transform
    /// <summary>
    /// This class represents on set of actions
    /// that apply to a Sprite for a certain number of frames.
    /// For example, if you want to drive West 90 ticks (timer clicks),
    /// then turn right to go South on the 45th tick, you would have two
    /// transforms. One with a duration of 45 ticks and an XAdjustment
    /// of your choosing. The second one would start on tick 46 and then
    /// XAdjustment is set back to 0 and YAdjustment is set. This makes a
    /// 90 degree turn. For a smoother turn, start a rotation Adjustment
    /// at tick (frame) 30 and the sprite will rotate and move.
    /// </summary>
    public class Transform
    {
        
        #region Private Variables        
        private List<Adjustment> adjustments;
        private List<Transform> nextTransforms;
        private string name;
        private bool completed;        
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of an Adjustment object
        /// </summary>
        public Transform()
        {   
            // Create a new collection of 'Adjustment' objects.
            Adjustments = new List<Adjustment>();
            NextTransforms = new List<Transform>();
        }
        #endregion

        #region Methods

            #region CheckCompleted()
            /// <summary>
            /// This method returns true if all the Adjustments have been Completed
            /// </summary>
            public bool CheckCompleted()
            {
                // initial value
                bool completed = true;

                // If the adjustments collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(Adjustments))
                {
                    // Iterate the collection of Adjustment objects
                    foreach (Adjustment adjustment in Adjustments)
                    {
                        // If the value for the property adjustment.Completed is false
                        if (!adjustment.Completed)
                        {
                            // not completed
                            completed = false;

                            // break out of loop
                            break;
                        }
                    }
                }
                
                // return value
                return completed;
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region Adjustments
            /// <summary>
            /// This property gets or sets the value for 'Adjustments'.
            /// </summary>
            public List<Adjustment> Adjustments
            {
                get { return adjustments; }
                set { adjustments = value; }
            }
            #endregion
            
            #region Completed
            /// <summary>
            /// This property gets or sets the value for 'Completed'.
            /// </summary>
            public bool Completed
            {
                get { return completed; }
                set { completed = value; }
            }
            #endregion
            
            #region HasAdjustments
            /// <summary>
            /// This property returns true if this object has an 'Adjustments'.
            /// </summary>
            public bool HasAdjustments
            {
                get
                {
                    // initial value
                    bool hasAdjustments = (this.Adjustments != null);
                    
                    // return value
                    return hasAdjustments;
                }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region NextTransforms
            /// <summary>
            /// This property gets or sets the value for 'NextTransforms'.
            /// </summary>
            public List<Transform> NextTransforms
            {
                get { return nextTransforms; }
                set { nextTransforms = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
