

#region using statements

using System;
using Microsoft.AspNetCore.Components;
using System.Timers;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.RandomShuffler.Core;

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
        private int backgroundHeight;
        private int backgroundWidth;
        private string backgroundHeightPixels;
        private string backgroundWidthPixels;
        private string backgroundImageUrl;
        private int currentValue;
        private Timer timer;
        private int increment;
        private int interval;
        private bool started;
        private string display;
        private bool visible;
        private bool notificaitonInProgress;
        private double scale;
        private string bubbleStyle;
        private string bubbleImageUrl;
        private IProgressSubscriber subscriber;
        private bool showBackground;
        private string backgroundPosition;
        private int backgroundLeft;
        private int backgroundTop;
        private string backgroundLeftPixels;
        private string backgroundTopPixels;
        private string bubblePosition;
        private int bubbleLeft;
        private int bubbleTop;
        private int max;
        private string bubbleLeftPixels;
        private string bubbleTopPixels;
        private double backgroundScale;
        private double bubbleScale;
        private int bubbleOffSet;
        private bool inProgress;
        private DataJuggler.RandomShuffler.Core.RandomShuffler shuffler;
        private ThemeEnum theme;
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
                // if we are not currently executing
                if (!InProgress)
                {
                    try
                    {
                        // Set InProgress to true so this operates one at a time (for debugging mostly)
                        InProgress = true;

                        // Set the CurrentValue
                        if ((this.CurrentValue <= Max) && (Increment > 0))
                        {
                            // Increase the value
                            this.CurrentValue += this.Increment;

                            // if the end has been reached
                            if ((CurrentValue) >= Max)
                            {  
                                // Start over
                                CurrentValue = 0;
                            }

                            // Get the image number (1 - 6)
                            int imageNumber = GetImageNumber();

                            // verify the image number is in range 
                            if ((imageNumber >= 1) && (imageNumber <= 6))
                            {
                                // if using Spheres
                                if (Theme == ThemeEnum.Spheres)
                                {
                                    // set the first image
                                    BubbleImageUrl = "_content/DataJuggler.Blazor.Components/Images/Sphere" + imageNumber + ".png";
                                }
                                else
                                {
                                    // set the first image
                                    BubbleImageUrl = "_content/DataJuggler.Blazor.Components/Images/Image" + imageNumber + ".png";
                                }
                            }
                            else
                            {  
                                // if Spheres
                                if (Theme == ThemeEnum.Spheres)
                                {
                                    // show the first image
                                    BubbleImageUrl = "_content/DataJuggler.Blazor.Components/Images/Sphere1.png";
                                }
                                else
                                {
                                    // show the first image
                                    BubbleImageUrl = "_content/DataJuggler.Blazor.Components/Images/Image1.png";
                                }
                            }

                            // if there is currently a subscriber
                            if (HasSubscriber)
                            {
                                // build a message to send
                                string message = "CurrentValue: " + CurrentValue.ToString();

                                // send a message to the subscriber
                                subscriber.Refresh(message);
                            }

                            //// Notify the UI thread to update
                            InvokeAsync(() =>
                            {
                                StateHasChanged();
                            });
                        }
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        string err = error.ToString();
                    }
                    finally
                    {
                        // Turn off
                        InProgress = false;
                    }
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region GetImageNumber()
            /// <summary>
            /// This method returns the Image Number
            /// </summary>
            public int GetImageNumber()
            {
                // initial value
                int imageNumber = 1;

                // if the value for HasShuffler is true
                if (HasShuffler)
                {
                    // if there are not any more items
                    if (Shuffler.RandomIntStorage.Count == 0)
                    {
                        // Recreate the Shuffler
                        Shuffler = new DataJuggler.RandomShuffler.Core.RandomShuffler(1, 6, 1, 10);
                    }

                    // pull the next shuffler
                    imageNumber = Shuffler.PullNextItem();
                }

                // return value
                return imageNumber;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Set Defaults
                BackgroundImageUrl = "_content/DataJuggler.Blazor.Components/Images/DarkBackground.png";
                BackgroundHeight = 64;
                BackgroundWidth = 320;
                BubbleImageUrl = "_content/DataJuggler.Blazor.Components/Images/Image6.png";
                BubblePosition = "relative";
                BackgroundPosition = "relative";
                CurrentValue =  (Increment - BubbleOffSet) * 6;
                BubbleTop = 4;
                Interval = 500;    
                Increment = 16;
                BubbleOffSet = 8;
                BackgroundScale = 1;
                BubbleScale = .6;
                Shuffler = new DataJuggler.RandomShuffler.Core.RandomShuffler(1, 6, 1, 10);
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

            #region BackgroundHeight
            /// <summary>
            /// This property gets or sets the value for 'BackgroundHeight'.
            /// </summary>
            [Parameter]
            public int BackgroundHeight
            {
                get { return backgroundHeight; }
                set 
                { 
                    // set the value
                    backgroundHeight = value;

                    // set the height in pixels
                    backgroundHeightPixels = backgroundHeight.ToString() + "px";
                }
            }
            #endregion
            
            #region BackgroundHeightPixels
            /// <summary>
            /// This property gets or sets the value for 'BackgroundHeightPixels'.
            /// </summary>
            public string BackgroundHeightPixels
            {
                get { return backgroundHeightPixels; }
                set { backgroundHeightPixels = value; }
            }
            #endregion
            
            #region BackgroundImageUrl
            /// <summary>
            /// This property gets or sets the value for 'BackgroundImageUrl'.
            /// </summary>
            [Parameter]
            public string BackgroundImageUrl
            {
                get { return backgroundImageUrl; }
                set { backgroundImageUrl = value; }
            }
            #endregion
            
            #region BackgroundLeft
            /// <summary>
            /// This property gets or sets the value for 'BackgroundLeft'.
            /// </summary>
            public int BackgroundLeft
            {
                get { return backgroundLeft; }
                set 
                { 
                    // set the value
                    backgroundLeft = value;

                    // Set the value for BackgroundLeftPixels
                    BackgroundLeftPixels = backgroundLeft.ToString() + "px";
                }
            }
            #endregion
            
            #region BackgroundLeftPixels
            /// <summary>
            /// This property gets or sets the value for 'BackgroundLeftPixels'.
            /// </summary>
            public string BackgroundLeftPixels
            {
                get { return backgroundLeftPixels; }
                set { backgroundLeftPixels = value; }
            }
            #endregion
            
            #region BackgroundPosition
            /// <summary>
            /// This property gets or sets the value for 'BackgroundPosition'.
            /// </summary>
            public string BackgroundPosition
            {
                get { return backgroundPosition; }
                set { backgroundPosition = value; }
            }
            #endregion
            
            #region BackgroundScale
            /// <summary>
            /// This property gets or sets the value for 'BackgroundScale'.
            /// </summary>
            [Parameter]
            public double BackgroundScale
            {
                get { return backgroundScale; }
                set { backgroundScale = value; }
            }
            #endregion
            
            #region BackgroundTop
            /// <summary>
            /// This property gets or sets the value for 'BackgroundTop'.
            /// </summary>
            public int BackgroundTop
            {
                get { return backgroundTop; }
                set 
                { 
                    // set the value
                    backgroundTop = value;

                    // set the value for BackgroundTopPixels
                    BackgroundTopPixels = backgroundTop.ToString() + "px";
                }
            }
            #endregion
            
            #region BackgroundTopPixels
            /// <summary>
            /// This property gets or sets the value for 'BackgroundTopPixels'.
            /// </summary>
            public string BackgroundTopPixels
            {
                get { return backgroundTopPixels; }
                set { backgroundTopPixels = value; }
            }
            #endregion
            
            #region BackgroundWidth
            /// <summary>
            /// This property gets or sets the value for 'BackgroundWidth'.
            /// </summary>
            [Parameter]
            public int BackgroundWidth
            {
                get { return backgroundWidth; }
                set 
                { 
                    // set the value
                    backgroundWidth = value;

                    // Set the value in Pixels
                    BackgroundWidthPixels = backgroundWidth.ToString() + "px";
                }
            }
            #endregion
            
            #region BackgroundWidthPixels
            /// <summary>
            /// This property gets or sets the value for 'BackgroundWidthPixels'.
            /// </summary>
            public string BackgroundWidthPixels
            {
                get { return backgroundWidthPixels; }
                set { backgroundWidthPixels = value; }
            }
            #endregion
            
            #region BubbleImageUrl
            /// <summary>
            /// This property gets or sets the value for 'BubbleImageUrl'.
            /// </summary>
            public string BubbleImageUrl
            {
                get { return bubbleImageUrl; }
                set { bubbleImageUrl = value; }
            }
            #endregion
            
            #region BubbleLeft
            /// <summary>
            /// This property gets or sets the value for 'BubbleLeft'.
            /// </summary>
            public int BubbleLeft
            {
                get { return bubbleLeft; }
                set 
                { 
                    // set the value
                    bubbleLeft = value;

                    // Set the value for BubbleLeftPixels
                    BubbleLeftPixels = bubbleLeft.ToString() + "px";
                }
            }
            #endregion
            
            #region BubbleLeftPixels
            /// <summary>
            /// This property gets or sets the value for 'BubbleLeftPixels'.
            /// </summary>
            public string BubbleLeftPixels
            {
                get { return bubbleLeftPixels; }
                set { bubbleLeftPixels = value; }
            }
            #endregion
            
            #region BubbleOffSet
            /// <summary>
            /// This property gets or sets the value for 'BubbleOffSet'.
            /// </summary>
            [Parameter]
            public int BubbleOffSet
            {
                get { return bubbleOffSet; }
                set { bubbleOffSet = value; }
            }
            #endregion
            
            #region BubblePosition
            /// <summary>
            /// This property gets or sets the value for 'BubblePosition'.
            /// </summary>
            public string BubblePosition
            {
                get { return bubblePosition; }
                set { bubblePosition = value; }
            }
            #endregion
            
            #region BubbleScale
            /// <summary>
            /// This property gets or sets the value for 'BubbleScale'.
            /// </summary>
            [Parameter]
            public double BubbleScale
            {
                get { return bubbleScale; }
                set { bubbleScale = value; }
            }
            #endregion
            
            #region BubbleStyle
            /// <summary>
            /// This property gets or sets the value for 'BubbleStyle'.
            /// </summary>
            public string BubbleStyle
            {
                get { return bubbleStyle; }
                set { bubbleStyle = value; }
            }
            #endregion
            
            #region BubbleTop
            /// <summary>
            /// This property gets or sets the value for 'BubbleTop'.
            /// </summary>
            [Parameter]
            public int BubbleTop
            {
                get { return bubbleTop; }
                set 
                { 
                    // set the value
                    bubbleTop = value;

                    // Set the value for BubbleTopPixels
                    BubbleTopPixels = bubbleTop.ToString() + "px";
                }
            }
            #endregion
            
            #region BubbleTopPixels
            /// <summary>
            /// This property gets or sets the value for 'BubbleTopPixels'.
            /// </summary>
            public string BubbleTopPixels
            {
                get { return bubbleTopPixels; }
                set { bubbleTopPixels = value; }
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

                    // Kind of redundant these two properties
                    BubbleLeft = currentValue + BubbleOffSet;
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
            
            #region HasShuffler
            /// <summary>
            /// This property returns true if this object has a 'Shuffler'.
            /// </summary>
            public bool HasShuffler
            {
                get
                {
                    // initial value
                    bool hasShuffler = (this.Shuffler != null);
                    
                    // return value
                    return hasShuffler;
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
            
            #region Increment
            /// <summary>
            /// This property gets or sets the value for 'Increment'.
            /// </summary>
            [Parameter]
            public int Increment
            {
                get { return increment; }
                set 
                { 
                    increment = value;

                    // set the value for Max
                    Max = increment * 6;
                }
            }
            #endregion
            
            #region InProgress
            /// <summary>
            /// This property gets or sets the value for 'InProgress'.
            /// </summary>
            public bool InProgress
            {
                get { return inProgress; }
                set { inProgress = value; }
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
            
            #region Scale
            /// <summary>
            /// This property gets or sets the value for 'Scale', which sets the value for BackgroundScale and BubbleScale.
            /// </summary>
            [Parameter]
            public double Scale
            {
                get { return scale; }
                set 
                { 
                    // set the value
                    scale = value;

                    // Set Both At Once By Setting This Property
                    BubbleScale = scale;
                    BackgroundScale = scale;
                }
            }
            #endregion
            
            #region ShowBackground
            /// <summary>
            /// This property gets or sets the value for 'ShowBackground'.
            /// </summary>
            [Parameter]
            public bool ShowBackground
            {
                get { return showBackground; }
                set { showBackground = value; }
            }
            #endregion
            
            #region Shuffler
            /// <summary>
            /// This property gets or sets the value for 'Shuffler'.
            /// </summary>
            public DataJuggler.RandomShuffler.Core.RandomShuffler Shuffler
            {
                get { return shuffler; }
                set { shuffler = value; }
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
            
            #region Theme
            /// <summary>
            /// This property gets or sets the value for 'Theme'.
            /// </summary>
            [Parameter]
            public ThemeEnum Theme
            {
                get { return theme; }
                set 
                { 
                    theme = value;

                    // if theme is Spheres
                    if (theme == ThemeEnum.Spheres)
                    {
                        // Set the value for BubbleImageUrl to use Image1
                        BubbleImageUrl = "_content/DataJuggler.Blazor.Components/Images/Sphere1.png";
                    }
                    else
                    {
                        // Set the value for BubbleImageUrl to use Image1
                        BubbleImageUrl = "_content/DataJuggler.Blazor.Components/Images/Image1.png";
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
            
        #endregion
        
    }
    #endregion

}
