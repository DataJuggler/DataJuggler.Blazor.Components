

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataJuggler.UltimateHelper;
using System.Timers;
using Microsoft.AspNetCore.Components;
using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.Blazor.Components.Interfaces;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class Sprite
    /// <summary>
    /// This class is the code behind for the Sprite component
    /// </summary>
    public partial class Sprite : IBlazorComponent
    {

        #region Private Variables
        private string spriteStyle;
        private Timer timer;
        private double xIncrement;
        private double yIncrement;
        private double xPosition;
        private double yPosition;
        private string xPositionStyle;
        private string yPositionStyle;
        private double rotation;
        private double rotationIncrement;
        private string rotationStyle;
        private int interval;
        private bool started;
        private string display;
        private bool visible;
        private double height;
        private double width;
        private string widthStyle;
        private string heightStyle;
        private string name;
        private bool notificaitonInProgress;        
        private string imageUrl;
        private int zIndex;
        private double scale;
        private string position;        
        private ISpriteSubscriber subscriber;
        private double opacity;
        private bool applyTransforms;
        private int currentTick;
        private bool completed;
        private bool stopOnCompleted;
        private bool busy;
        private List<Transform> transforms;
        private IBlazorComponentParent parent;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Sprite object 
        /// </summary>
        public Sprite()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region Timer_Elapsed(object sender, ElapsedEventArgs e)
            /// <summary>
            /// event is fired when Timer _ Elapsed
            /// </summary>
            private void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                // avoid duplicate processing in case it is too fast, but mostly for
                // debugging so it single process at a time
                if (!Busy)
                {
                    // Set Busy to true
                    Busy = true;

                    try
                    {
                        // Increment the value for CurrentTick
                        CurrentTick++;

                        // locals
                        AdjustmentResult result = null;
                        List<Transform> nextTransforms = new List<Transform>();

                        // if the Transforms exists
                        if ((ApplyTransforms) && (HasTransforms))
                        {       
                            // Iterate the collection of Transform objects
                            foreach (Transform transform in Transforms)
                            {
                                // if this transform has not completed
                                if (!transform.Completed)
                                {
                                    // if there are one or more Adjustments
                                    if (ListHelper.HasOneOrMoreItems(transform.Adjustments))
                                    {
                                        // iterate the Adjustments
                                        foreach (Adjustment adjustment in transform.Adjustments)
                                        {
                                            // Apply this adjustment
                                            result = ApplyAdjustment(adjustment);

                                            if (result.Status == AdjustmentStatusEnum.AppliedAndCompleted)
                                            {
                                                // Set the value
                                                adjustment.Completed = true;

                                                // Check all the other adjustments
                                                transform.Completed = transform.CheckCompleted();
                                            }
                                        }
                                    }

                                    // if the transform has finished and the NextTransforms collection exists and has one or more items
                                    if ((transform.Completed) && (ListHelper.HasOneOrMoreItems(transform.NextTransforms)))
                                    {
                                        // iterate the collection of Transform objects
                                        foreach (Transform nextTransform in transform.NextTransforms)
                                        {
                                            // Add this item
                                           nextTransforms.Add(nextTransform);
                                        }
                                    }
                                }
                            }

                            // if any new Transforms just got created
                            if (ListHelper.HasOneOrMoreItems(nextTransforms))
                            {
                                // iterate the collection of Transform objects
                                foreach (Transform nextTransform in nextTransforms)
                                {
                                    // Add this nextTransform
                                    this.Transforms.Add(nextTransform);
                                } 
                            }

                            // Check if all the Transforms have completed
                            this.Completed = CheckCompleted();

                            // if this Sprite has completed all the transforms and StopOnCompleted is true
                            if (Completed && StopOnCompleted)
                            {
                                // Stop the timer
                                Stop();
                            }
                        }

                        // if a subscriber 
                        if (HasSubscriber)
                        {
                            // Notify Subscriber
                            Subscriber.Refresh();
                        }
                    }
                    catch (Exception error)
                    {
                        // for debugging only for now
                        DebugHelper.WriteDebugError("Timer_Elapsed", "Sprite.razor.cs", error);
                    }
                    finally
                    {
                        // no longer busy
                        Busy = false;
                    }
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region ApplyAdjustment(Adjustment adjustment)
            /// <summary>
            /// Apply Adjustment
            /// </summary>
            public AdjustmentResult ApplyAdjustment(Adjustment adjustment)
            {
                // local
                AdjustmentResult result = null;

                // If the adjustment object exists
                if (NullHelper.Exists(adjustment))
                {
                    // determine the action by the AdjustmentType                    
                    switch (adjustment.AdjustmentType)
                    {
                        case AdjustmentTypeEnum.X:
                            
                            // Attempt to apply the Adjustment
                            result = ApplyXAdjustment(adjustment);

                            // required
                            break;

                        case AdjustmentTypeEnum.Y:

                            // Attempt to apply the Adjustment
                            result = ApplyYAdjustment(adjustment);
                            
                            // required
                            break;

                        case AdjustmentTypeEnum.Opacity:

                           // Attempt to apply the Adjustment
                            result = ApplyOpacityAdjustment(adjustment);
                            
                            // required
                            break;

                        case AdjustmentTypeEnum.Rotation:

                            // Attempt to apply the Adjustment
                            result = ApplyRotationAdjustment(adjustment);
                            
                            // required
                            break;
                    }

                    // if the Adjustment just reached its max
                    if (adjustment.IsIncrement && adjustment.EndOnMax && result.MaximumSet)
                    {
                        // This adjustment just completed                        
                        adjustment.Completed = true;
                    }
                    else if (!adjustment.IsIncrement && adjustment.EndOnMin && result.MinimumSet)
                    {
                        // This adjustment just completed
                        adjustment.Completed = true;
                    }

                    if (adjustment.Completed)
                    {
                        // this result has been completed
                        result.Status = AdjustmentStatusEnum.AppliedAndCompleted;
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region ApplyOpacityAdjustment(Adjustment adjustment)
            /// <summary>
            /// returns the Opacity Adjustment
            /// </summary>
            public AdjustmentResult ApplyOpacityAdjustment(Adjustment adjustment)
            {
                // initial value
                AdjustmentResult result = new AdjustmentResult();

                // local
                double temp = 0;

                // Safeguards
                if ((NullHelper.Exists(result)) && (adjustment.AdjustmentType == AdjustmentTypeEnum.Opacity))
                {
                    // if the adjustmentAmount is a positive number
                    if (adjustment.IsIncrement)
                    {
                        // increment

                        // Get a temp value of what the result will be if applied
                        temp = Opacity + adjustment.AdjustmentAmount;

                        // if the newValue will be below Max
                        if (temp < adjustment.Max)
                        {
                            // Set the value
                            Opacity = temp;
                        }
                        else
                        {
                            // The Maximum has been reached
                            result.MaximumSet = true;

                            // Set the value
                            Opacity = adjustment.Max;
                        }
                    }
                    else
                    {
                        // decrement

                        // Get a temp value of what the result will be if applied
                        temp = Opacity - adjustment.AdjustmentAmount;

                        // if the newValue will be below Max
                        if (temp > adjustment.Min)
                        {
                            // Set the value
                            Opacity = temp;
                        }
                        else
                        {
                            // The Minimum has been reached
                            result.MinimumSet = true;

                            // Set the value
                            Opacity = adjustment.Min;
                        }
                    }

                    // Set the new value
                    result.NewValue = Opacity;
                }
                
                // return value
                return result;
            }
            #endregion

            #region ApplyRotationAdjustment(Adjustment adjustment)
            /// <summary>
            /// returns the Rotation Adjustment
            /// </summary>
            public AdjustmentResult ApplyRotationAdjustment(Adjustment adjustment)
            {
                // initial value
                AdjustmentResult result = new AdjustmentResult();

                // local
                double temp = 0;

                // Safeguards
                if ((NullHelper.Exists(result)) && (adjustment.AdjustmentType == AdjustmentTypeEnum.Rotation))
                {
                    // if the adjustmentAmount is a positive number
                    if (adjustment.IsIncrement)
                    {
                        // increment

                        // Get a temp value of what the result will be if applied
                        temp = Rotation + adjustment.AdjustmentAmount;

                        // if the newValue will be below Max
                        if (temp < adjustment.Max)
                        {
                            // Set the value
                            Rotation = temp;
                        }
                        else
                        {
                            // The Maximum has been reached
                            result.MaximumSet = true;

                            // Set the value
                            Rotation = adjustment.Max;
                        }
                    }
                    else
                    {
                        // decrement

                        // Get a temp value of what the result will be if applied
                        temp = Rotation - adjustment.AdjustmentAmount;

                        // if the newValue will be below Max
                        if (temp > adjustment.Min)
                        {
                            // Set the value
                            Rotation = temp;
                        }
                        else
                        {
                            // The Minimum has been reached
                            result.MinimumSet = true;

                            // Set the value
                            Rotation = adjustment.Min;
                        }
                    }

                    // Set the new value
                    result.NewValue = Rotation;
                }
                
                // return value
                return result;
            }
            #endregion
            
            #region ApplyXAdjustment(Adjustment adjustment)
            /// <summary>
            /// returns the X Adjustment
            /// </summary>
            public AdjustmentResult ApplyXAdjustment(Adjustment adjustment)
            {
                // initial value
                AdjustmentResult result = new AdjustmentResult();

                // local
                double temp = 0;

                // Safeguards
                if ((NullHelper.Exists(result)) && (adjustment.AdjustmentType == AdjustmentTypeEnum.X))
                {
                    // if the adjustmentAmount is a positive number
                    if (adjustment.IsIncrement)
                    {
                        // increment

                        // Get a temp value of what the result will be if applied
                        temp = XPosition + adjustment.AdjustmentAmount;

                        // if the newValue will be below Max
                        if (temp < adjustment.Max)
                        {
                            // Set the value
                            XPosition = temp;
                        }
                        else
                        {
                            // The Maximum has been reached
                            result.MaximumSet = true;

                            // Set the value
                            XPosition = adjustment.Max;
                        }
                    }
                    else
                    {
                        // decrement

                        // Get a temp value of what the result will be if applied
                        temp = XPosition - adjustment.AdjustmentAmount;

                        // if the newValue will be below Max
                        if (temp > adjustment.Min)
                        {
                            // Set the value
                            XPosition = temp;
                        }
                        else
                        {
                            // The Minimum has been reached
                            result.MinimumSet = true;

                            // Set the value
                            XPosition = adjustment.Min;
                        }

                        // Was applied
                        result.Status = AdjustmentStatusEnum.Applied;
                    }

                    // Set the new value
                    result.NewValue = XPosition;
                }
                
                // return value
                return result;
            }
            #endregion

            #region ApplyYAdjustment(Adjustment adjustment)
            /// <summary>
            /// returns the Y Adjustment
            /// </summary>
            public AdjustmentResult ApplyYAdjustment(Adjustment adjustment)
            {
                // initial value
                AdjustmentResult result = new AdjustmentResult();

                // local
                double temp = 0;

                // Safeguards
                if ((NullHelper.Exists(result)) && (adjustment.AdjustmentType == AdjustmentTypeEnum.Y))
                {
                    // if the adjustmentAmount is a positive number
                    if (adjustment.IsIncrement)
                    {
                        // increment

                        // Get a temp value of what the result will be if applied
                        temp = YPosition + adjustment.AdjustmentAmount;

                        // if the newValue will be below Max
                        if (temp < adjustment.Max)
                        {
                            // Set the value
                            YPosition = temp;
                        }
                        else
                        {
                            // The Maximum has been reached
                            result.MaximumSet = true;

                            // Set the value
                            YPosition = adjustment.Max;
                        }
                    }
                    else
                    {
                        // decrement

                        // Get a temp value of what the result will be if applied
                        temp = YPosition - adjustment.AdjustmentAmount;

                        // if the newValue will be below Max
                        if (temp > adjustment.Min)
                        {
                            // Set the value
                            YPosition = temp;
                        }
                        else
                        {
                            // The Minimum has been reached
                            result.MinimumSet = true;

                            // Set the value
                            YPosition = adjustment.Min;
                        }
                    }

                    // Set the new value
                    result.NewValue = YPosition;
                }
                
                // return value
                return result;
            }
            #endregion
            
            #region CheckCompleted()
            /// <summary>
            /// This method checks if all the Transforms have completed.
            /// If yes, then the Timer is turned off if EndOnComplete is true.
            /// </summary>
            public bool CheckCompleted()
            {
                // initial value
                bool completed = false;
                
                // return value
                return completed;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Defaults
                XPosition = 0;
                YPosition = 0;
                Scale = 1;
                Visible = true;
                Interval = 100;
                Display = "block";
                Opacity = 1;
                
                // In front of a background in theory
                ZIndex = 1;
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                throw new NotImplementedException();
            }
            #endregion

            #region SetRotationIncrement(double rotationIncrement)
            /// <summary>
            /// Set Y Increment
            /// </summary>
            public void SetRotationIncrement(double rotationIncrement)
            {
                // store
                RotationIncrement = rotationIncrement;
            }
            #endregion
            
            #region SetXIncrement(double xIncrement)
            /// <summary>
            /// Set X Increment
            /// </summary>
            public void SetXIncrement(double xIncrement)
            {
                // store
                XIncrement = xIncrement;
            }
            #endregion

            #region SetYIncrement(double yIncrement)
            /// <summary>
            /// Set Y Increment
            /// </summary>
            public void SetYIncrement(double yIncrement)
            {
                // store
                YIncrement = yIncrement;
            }
            #endregion
            
            #region Start()
            /// <summary>
            /// method Start
            /// </summary>
            public void Start()
            {
                this.Timer = new Timer();
                this.Timer.Interval = this.interval;
                this.Timer.Elapsed += Timer_Elapsed;
                this.Timer.Start();
            }
            #endregion

            #region Stop
            /// <summary>
            /// method Stops the Timer
            /// </summary>
            public void Stop()
            {
                // if the value for HasTimer is true
                if (HasTimer)
                {
                   // Stop the Timer
                   Timer.Stop();
                }
            }
            #endregion

        #endregion

        #region Properties

            #region ApplyTransforms
            /// <summary>
            /// This property gets or sets the value for 'ApplyTransforms'.
            /// If true, the X, Y and Rotation increments are applied on a tick.
            /// </summary>
            public bool ApplyTransforms
            {
                get { return applyTransforms; }
                set { applyTransforms = value; }
            }
            #endregion
            
            #region Busy
            /// <summary>
            /// This property gets or sets the value for 'Busy'.
            /// </summary>
            public bool Busy
            {
                get { return busy; }
                set { busy = value; }
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
            
            #region CurrentTick
            /// <summary>
            /// This property gets or sets the value for 'CurrentTick'.
            /// </summary>
            public int CurrentTick
            {
                get { return currentTick; }
                set { currentTick = value; }
            }
            #endregion
            
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
            
            #region HasSubscriber
            /// <summary>
            /// This property returns true if this object has a 'Subscriber'.
            /// </summary>
            public bool HasSubscriber
            {
                get
                {
                    // initial value
                    bool hasSubscriber = (this.Subscriber != null);
                    
                    // return value
                    return hasSubscriber;
                }
            }
            #endregion
            
            #region HasTimer
            /// <summary>
            /// This property returns true if this object has a 'Timer'.
            /// </summary>
            public bool HasTimer
            {
                get
                {
                    // initial value
                    bool hasTimer = (this.Timer != null);
                    
                    // return value
                    return hasTimer;
                }
            }
            #endregion
            
            #region HasTransforms
            /// <summary>
            /// This property returns true if this object has a 'Transforms'.
            /// </summary>
            public bool HasTransforms
            {
                get
                {
                    // initial value
                    bool hasTransforms = (this.Transforms != null);
                    
                    // return value
                    return hasTransforms;
                }
            }
            #endregion
            
            #region Height
            /// <summary>
            /// This property gets or sets the value for 'Height'.
            /// </summary>
            [Parameter]
            public double Height
            {
                get { return height; }
                set 
                { 
                    // set the value
                    height = value;

                    // Set the value of HeightStyle
                    HeightStyle = height.ToString() + "vh";
                }
            }
            #endregion
            
            #region HeightStyle
            /// <summary>
            /// This property gets or sets the value for 'HeightStyle'.
            /// </summary>
            public string HeightStyle
            {
                get { return heightStyle; }
                set { heightStyle = value; }
            }
            #endregion
            
            #region ImageUrl
            /// <summary>
            /// This property gets or sets the value for 'ImageUrl'.
            /// </summary>
            [Parameter]
            public string ImageUrl
            {
                get { return imageUrl; }
                set { imageUrl = value; }
            }
            #endregion
            
            #region Interval
            /// <summary>
            /// This property gets or sets the value for 'Interval'.
            /// </summary>
            [Parameter]
            public int Interval
            {
                get { return interval; }
                set { interval = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            [Parameter]
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region NotificaitonInProgress
            /// <summary>
            /// This property gets or sets the value for 'NotificaitonInProgress'.
            /// </summary>
            public bool NotificaitonInProgress
            {
                get { return notificaitonInProgress; }
                set { notificaitonInProgress = value; }
            }
            #endregion
            
            #region Opacity
            /// <summary>
            /// This property gets or sets the value for 'Opacity'.
            /// The values are 1 fully visible to 0 transparent.
            /// </summary>
            [Parameter]
            public double Opacity
            {
                get { return opacity; }
                set 
                { 
                    // if greater than 1
                    if (value > 1)
                    {
                        // set to 1
                        value = 1;
                    }
                    else if (value < 0)
                    {
                        // set to 0
                        value = 0;
                    }

                    opacity = value;
                }
            }
            #endregion

            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get { return parent; }
                set 
                {
                    // set the value
                    parent = value;

                    // if the value for HasParent is true
                    if (HasParent)
                    {
                        // Register with the parent
                        Parent.Register(this);
                    }
                }
            }
            #endregion
            
            #region Position
            /// <summary>
            /// This property gets or sets the value for 'Position'.
            /// </summary>
            [Parameter]
            public string Position
            {
                get { return position; }
                set { position = value; }
            }
            #endregion
            
            #region Rotation
            /// <summary>
            /// This property gets or sets the value for 'Rotation'.
            /// </summary>
            public double Rotation
            {
                get { return rotation; }
                set 
                {
                    // make sure the range doesn't exceed range of a circle
                    value = NumericHelper.EnsureInRange(value, 0, 360);

                    // set the value
                    rotation = value;

                    // set the headerStyle
                    RotationStyle = rotationStyle + "deg";
                }
            }
            #endregion
            
            #region RotationIncrement
            /// <summary>
            /// This property gets or sets the value for 'RotationIncrement'.
            /// </summary>
            [Parameter]
            public double RotationIncrement
            {
                get { return rotationIncrement; }
                set { rotationIncrement = value; }
            }
            #endregion
            
            #region RotationStyle
            /// <summary>
            /// This property gets or sets the value for 'RotationStyle'.
            /// </summary>
            public string RotationStyle
            {
                get { return rotationStyle; }
                set { rotationStyle = value; }
            }
            #endregion
            
            #region Scale
            /// <summary>
            /// This property gets or sets the value for 'Scale'.
            /// </summary>
            [Parameter]
            public double Scale
            {
                get { return scale; }
                set { scale = value; }
            }
            #endregion
            
            #region SpriteStyle
            /// <summary>
            /// This property gets or sets the value for 'SpriteStyle'.
            /// </summary>
            public string SpriteStyle
            {
                get { return spriteStyle; }
                set { spriteStyle = value; }
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
            
            #region StopOnCompleted
            /// <summary>
            /// This property gets or sets the value for 'StopOnCompleted'.
            /// </summary>
            public bool StopOnCompleted
            {
                get { return stopOnCompleted; }
                set { stopOnCompleted = value; }
            }
            #endregion
            
            #region Subscriber
            /// <summary>
            /// This property gets or sets the value for 'Subscriber'.
            /// </summary>
            [Parameter]
            public ISpriteSubscriber Subscriber
            {
                get { return subscriber; }
                set 
                {   
                    // set the value
                    subscriber = value;

                    // if the value for HasSubscriber is true
                    if (HasSubscriber)
                    {
                        // Register with the Subscriber so they can talk to each other
                        Subscriber.Register(this);
                    }
                }
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
            
            #region Transforms
            /// <summary>
            /// This property gets or sets the value for 'Transforms'.
            /// </summary>
            public List<Transform> Transforms
            {
                get { return transforms; }
                set { transforms = value; }
            }
            #endregion
            
            #region Visible
            /// <summary>
            /// This property gets or sets the value for 'Visible'.
            /// </summary>
            [Parameter]
            public bool Visible
            {
                get { return visible; }
                set 
                {
                    // set the value
                    visible = value;

                    // if visible
                    if (visible)
                    {
                        // set the value to inline-block
                        display = "inline-block";
                    }
                    else
                    {
                        // set the value to none
                        display = "none";
                    }
                }
            }
            #endregion
         
            #region Width
            /// <summary>
            /// This property gets or sets the value for 'Width'.
            /// </summary>
            [Parameter]
            public double Width
            {
                get { return width; }
                set 
                {
                    // set the value
                    width = value;

                    // set the value of WidthStyle
                    WidthStyle = width.ToString() + "%";
                }
            }
            #endregion
            
            #region WidthStyle
            /// <summary>
            /// This property gets or sets the value for 'WidthStyle'.
            /// </summary>
            public string WidthStyle
            {
                get { return widthStyle; }
                set { widthStyle = value; }
            }
            #endregion
            
            #region XIncrement
            /// <summary>
            /// This property gets or sets the value for 'XIncrement'.
            /// </summary>
            [Parameter]
            public double XIncrement
            {
                get { return xIncrement; }
                set { xIncrement = value; }
            }
            #endregion
            
            #region XPosition
            /// <summary>
            /// This property gets or sets the value for 'XPosition'.
            /// </summary>
            [Parameter]
            public double XPosition
            {
                get { return xPosition; }
                set 
                {
                    // set the value
                    xPosition = value;

                    // set the string value
                    XPositionStyle = XPosition.ToString() + "%";
                }
            }
            #endregion
            
            #region XPositionStyle
            /// <summary>
            /// This property gets or sets the value for 'XPositionStyle'.
            /// </summary>
            public string XPositionStyle
            {
                get { return xPositionStyle; }
                set { xPositionStyle = value; }
            }
            #endregion
            
            #region YIncrement
            /// <summary>
            /// This property gets or sets the value for 'YIncrement'.
            /// </summary>
            [Parameter]
            public double YIncrement
            {
                get { return yIncrement; }
                set { yIncrement = value; }
            }
            #endregion
            
            #region YPosition
            /// <summary>
            /// This property gets or sets the value for 'YPosition'.
            /// </summary>
            [Parameter]
            public double YPosition
            {
                get { return yPosition; }
                set 
                {
                    // set the value
                    yPosition = value;

                    // set the string value for position
                    YPositionStyle = YPosition.ToString() + "vh";
                }
            }
            #endregion
            
            #region YPositionStyle
            /// <summary>
            /// This property gets or sets the value for 'YPositionStyle'.
            /// </summary>
            public string YPositionStyle
            {
                get { return yPositionStyle; }
                set { yPositionStyle = value; }
            }
            #endregion
            
            #region ZIndex
            /// <summary>
            /// This property gets or sets the value for 'ZIndex'.
            /// </summary>
            [Parameter]
            public int ZIndex
            {
                get { return zIndex; }
                set { zIndex = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
