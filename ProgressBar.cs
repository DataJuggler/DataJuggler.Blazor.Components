

#region using statements

using Microsoft.AspNetCore.Components;
using System.Timers;
using DataJuggler.Blazor.Components.Interfaces;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class ProgressBar
    /// <summary>
    /// This is the code behind for the ProgressBar.
    /// </summary>
    public partial class ProgressBar
    {
        
        #region Private Variables    
        private string progressBackground;
        private string percentFillStyle;
        private int fillWidth;
        private string fillWidthPixels;
        private int max;
        private int currentValue;
        private int percentFill;
        private Timer timer;
        private int increment;
        private int interval;
        private bool started;
        private string display;
        private bool visible;
        private bool notificaitonInProgress;
        private bool continuous;
        private bool hideWhenFinished;
        private IProgressSubscriber subscriber;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a ProgressBar object
        /// </summary>
        public ProgressBar()
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
                // Set the CurrentValue
                if (this.CurrentValue < Max)
                {
                    // Increase the value
                    this.CurrentValue += this.Increment;

                    // if there is currently a subscriber
                    if (HasSubscriber)
                    {
                        // build a message to send
                        string message = "CurrentValue: " + CurrentValue.ToString();

                        // send a message to the subscriber
                        subscriber.Refresh(message);
                    }

                    // if the end has been reached
                    if (CurrentValue >= Max)
                    {
                        // Start over
                        if (Continuous)
                        {
                            // Start over
                            CurrentValue = 0;
                        }
                        else
                        {
                            // Stop the timer and hide
                            Timer.Stop();

                            // if the value for HideWhenFinished is true
                            if (HideWhenFinished)
                            {
                                // set the value of Visible to false
                                Visible = false;
                            }
                        }
                    }

                    //// Notify the UI thread to update
                    InvokeAsync(() =>
                    {
                        StateHasChanged();
                    });
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Set Defaults
                Interval = 100;    
                Increment = 1;
                Max = 552;
                HideWhenFinished = true;
            }
            #endregion

            #region Start(int startAtValue = 0)
            /// <summary>
            /// This method Starts the timer progressing
            /// </summary>
            public void Start(int startAtValue = 0)
            {
                // The progress has started
                Started = true;
                CurrentValue = startAtValue;
                Visible = true;
                Timer = new Timer();
                Timer.Interval = this.Interval;
                Timer.Elapsed += Timer_Elapsed;
                Timer.Start();
                FillWidth = 0;
            }
            #endregion

            #region Stop(bool hide = true)
            /// <summary>
            /// This method Starts the timer progressing
            /// </summary>
            public void Stop(bool hide = true)
            {
                // The progress has started
                Started = false;
                Visible = !hide;

                // if the Timer exists
                if (Timer != null)
                {
                    // Stop the timer
                    Timer.Stop();
                }                
            }
            #endregion
            
        #endregion

        #region Properties

            #region Continuous
            /// <summary>
            /// This property gets or sets the value for 'Continuous'.
            /// If this value is true, upon reaching the value of Max,
            /// the CurrentValue will start over.
            /// </summary>
            [Parameter]
            public bool Continuous
            {
                get { return continuous; }
                set { continuous = value; }
            }
            #endregion
            
            #region CurrentValue
            /// <summary>
            /// This property gets or sets the value for 'CurrentValue'.
            /// </summary>
            [Parameter]
            public int CurrentValue
            {
                get { return currentValue; }
                set
                {
                    // set the value
                    currentValue = value;

                    // Kind of redundant these two properties, I may change it use only 1
                    FillWidth = currentValue;
                }
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
            
            #region FillWidth
            /// <summary>
            /// This property gets or sets the value for 'FillWidth'.
            /// </summary>
            public int FillWidth
            {
                get { return fillWidth; }
                set 
                {
                    // set the value
                    fillWidth = value;

                    // set the fillWidthPixels
                    fillWidthPixels = fillWidth.ToString() + "px";
                }
            }
            #endregion
            
            #region FillWidthPixels
            /// <summary>
            /// This property gets or sets the value for 'FillWidthPixels'.
            /// </summary>
            public string FillWidthPixels
            {
                get { return fillWidthPixels; }
                set { fillWidthPixels = value; }
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
            
            #region HideWhenFinished
            /// <summary>
            /// This property gets or sets the value for 'HideWhenFinished'.
            /// </summary>
            [Parameter]
            public bool HideWhenFinished
            {
                get { return hideWhenFinished; }
                set { hideWhenFinished = value; }
            }
            #endregion
            
            #region Increment
            /// <summary>
            /// This property gets or sets the value for 'Increment'.
            /// </summary>
            [Parameter]
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
            [Parameter]
            public int Interval
            {
                get { return interval; }
                set { interval = value; }
            }
            #endregion
            
            #region Max
            /// <summary>
            /// This property gets or sets the value for 'Max'.
            /// </summary>
            public int Max
            {
                get { return max; }
                set { max = value; }
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
            
            #region PercentFill
            /// <summary>
            /// This property gets or sets the value for 'PercentFill'.
            /// </summary>
            public int PercentFill
            {
                get { return percentFill; }
                set { percentFill = value; }
            }
            #endregion
            
            #region PercentFillStyle
            /// <summary>
            /// This property gets or sets the value for 'PercentFillStyle'.
            /// </summary>
            public string PercentFillStyle
            {
                get { return percentFillStyle; }
                set { percentFillStyle = value; }
            }
            #endregion
            
            #region ProgressBackground
            /// <summary>
            /// This property gets or sets the value for 'ProgressBackground'.
            /// </summary>
            public string ProgressBackground
            {
                get { return progressBackground; }
                set { progressBackground = value; }
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
            
            #region Subscriber
            /// <summary>
            /// This property gets or sets the value for 'Subscriber'.
            /// </summary>
            [Parameter]
            public IProgressSubscriber Subscriber
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

            #region Visible
            /// <summary>
            /// This property gets or sets the value for 'Visible'.
            /// </summary>
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
            
        #endregion
        
    }
    #endregion

}
