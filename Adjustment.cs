

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

    #region class Adjustment
    /// <summary>
    /// This class is used to make adjustments to Sprites.
    /// Transform classes can hold many adjustments.
    /// A Sprite can have many Transforms.
    /// </summary>
    public class Adjustment
    {
        
        #region Private Variables
        private AdjustmentTypeEnum adjustmentType;
        private double min;
        private double max;
        private double adjustmentAmount;
        private bool endOnMin;
        private bool endOnMax;
        private int startTick;
        private int endTick;
        private bool completed;
        private Transform parent;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'Adjustment' object.
        /// </summary>
        public Adjustment(Transform parent)
        {
            // store
            Parent = parent;
        }
        #endregion
        
        #region Properties
            
            #region AdjustmentAmount
            /// <summary>
            /// This property gets or sets the value for 'AdjustmentAmount'.
            /// </summary>
            public double AdjustmentAmount
            {
                get { return adjustmentAmount; }
                set { adjustmentAmount = value; }
            }
            #endregion
            
            #region AdjustmentType
            /// <summary>
            /// This property gets or sets the value for 'AdjustmentType'.
            /// </summary>
            public AdjustmentTypeEnum AdjustmentType
            {
                get { return adjustmentType; }
                set { adjustmentType = value; }
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
            
            #region EndOnMax
            /// <summary>
            /// This property gets or sets the value for 'EndOnMax'.
            /// </summary>
            public bool EndOnMax
            {
                get { return endOnMax; }
                set { endOnMax = value; }
            }
            #endregion
            
            #region EndOnMin
            /// <summary>
            /// This property gets or sets the value for 'EndOnMin'.
            /// </summary>
            public bool EndOnMin
            {
                get { return endOnMin; }
                set { endOnMin = value; }
            }
            #endregion
            
            #region EndTick
            /// <summary>
            /// This property gets or sets the value for 'EndTick'.
            /// </summary>
            public int EndTick
            {
                get { return endTick; }
                set { endTick = value; }
            }
            #endregion
            
            #region HasParent
            /// <summary>
            /// This property returns true if this object has a 'Parent'.
            /// </summary>
            public bool HasParent
            {
                get
                {
                    // initial value
                    bool hasParent = (this.Parent != null);
                    
                    // return value
                    return hasParent;
                }
            }
            #endregion
            
            #region IsIncrement
            /// <summary>
            /// This read only property returns true if the AdjustmentAmount is a positive number
            /// </summary>
            public bool IsIncrement
            {
                get
                {
                    // initial value
                    bool isIncrement = (AdjustmentAmount > 0);
                    
                    // return value
                    return isIncrement;
                }
            }
            #endregion
            
            #region Max
            /// <summary>
            /// This property gets or sets the value for 'Max'.
            /// </summary>
            public double Max
            {
                get { return max; }
                set { max = value; }
            }
            #endregion
            
            #region Min
            /// <summary>
            /// This property gets or sets the value for 'Min'.
            /// </summary>
            public double Min
            {
                get { return min; }
                set { min = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// </summary>
            public Transform Parent
            {
                get { return parent; }
                set { parent = value; }
            }
            #endregion
            
            #region StartTick
            /// <summary>
            /// This property gets or sets the value for 'StartTick'.
            /// </summary>
            public int StartTick
            {
                get { return startTick; }
                set { startTick = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
