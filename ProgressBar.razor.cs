

#region using statements

using System;
using Microsoft.AspNetCore.Components;
using System.Timers;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Enumerations;
using System.Text;
using System.Threading.Tasks;

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
        private string backgroundColor;
        private Timer timer;
        private int increment;
        private int interval;
        private bool started;
        private string display;
        private bool visible;
        private bool notificaitonInProgress;
        private double scale;
        private IProgressSubscriber subscriber;
        private bool showBackground;
        private string backgroundPosition;
        private int backgroundLeft;
        private int backgroundTop;
        private string backgroundLeftPixels;
        private string backgroundTopPixels;
        private string progressStyle;
        private int max;
        private double backgroundScale;
        private bool inProgress;
        private int percent;
        private string percentString;
        private int extraPercent;
        private int closeAtExtraPercent;
        private bool clientHandledIncrement;
        private string textColor;
        private string textColorStyle;
        private SizeEnum size;
        private ColorEnum color;
        private ThemeEnum theme;
        private bool overrideThemeColorForText;
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
                        if ((this.Percent <= Max) && (Increment >= 0))
                        {
                            // test only
                            string textColor = TextColor;

                            // Increase the value
                            this.Percent += this.Increment;

                            // if the end has been reached
                            if (Percent >= Max)
                            {  
                                // Cap at Max
                                Percent = Max;

                                // Add 1
                                ExtraPercent += 1;   

                                // if we have reached the end
                                if ((CloseAtExtraPercent > 0) && (ExtraPercent > CloseAtExtraPercent))
                                {
                                    // Stop this object
                                    Stop();

                                    // Hide this control
                                    Visible = false;
                                }
                            }

                            // if there is currently a subscriber
                            if (HasSubscriber)
                            {
                                // build a message to send
                                string message = "Percent: " + Percent.ToString();

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

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Set Defaults
                BackgroundImageUrl = "_content/DataJuggler.Blazor.Components/Images/DarkBackground.png";
                BackgroundHeight = 64;
                BackgroundWidth = 64;
                BackgroundPosition = "relative";
                Interval = 25;    
                Increment = 2;
                BackgroundScale = 1;
                Max = 100;
                ShowBackground = false;
                CloseAtExtraPercent = 12;
                Color = ColorEnum.Blue;
                Size = SizeEnum.Medium;
                Theme = ThemeEnum.Dark;
                Scale = 1.0;
                OverrideThemeColorForText = false;
            }
            #endregion

            #region SetClientHandledIncrement(bool clientHandledIncrementValue)
            /// <summary>
            /// This method Set Client Handled Increment
            /// </summary>
            public void SetClientHandledIncrement(bool clientHandledIncrementValue)
            {
                // Set the value
                ClientHandledIncrement = clientHandledIncrementValue;
            }
            #endregion
            
            #region SetProgressStyle()
            /// <summary>
            /// This method Set Progress HeaderStyle
            /// </summary>
            public void SetProgressStyle()
            {
                // Create a new instance of a 'StringBuilder' object.
                StringBuilder sb = new StringBuilder("c100 p");

                // Append the percent value
                sb.Append(percent);

                // Update version 1.3.3, on 4.12.2020: 
                if (Theme == ThemeEnum.Dark)
                {
                    // Now set ProgressStyle
                    sb.Append(" dark");
                }
                
                // if Large
                if (Size == SizeEnum.Large)
                {
                    // append big
                    sb.Append(" big");
                }
                else if (Size == SizeEnum.Small)
                {
                    // append big
                    sb.Append(" small");
                }
                else
                {
                    // nothing needed for Medium
                }

                // if the TextColor exists
                bool dontSetTextColor = ((HasTextColor) && (OverrideThemeColorForText));
                
                // if Green
                if (Color == ColorEnum.Green)
                {
                    // append green
                    sb.Append(" green");

                    // if the value for dontSetTextColor is false
                    if (!dontSetTextColor)
                    {
                        // Set the TextColor
                        TextColor = "Green";
                    }
                }
                else if (Color == ColorEnum.Orange)
                {
                    // append green
                    sb.Append(" orange");

                    // if the value for dontSetTextColor is false
                    if (!dontSetTextColor)
                    {
                        // Set the TextColor
                        TextColor = "Orange";
                    }
                }
                else
                {
                    // Blue is the default

                     // if the value for dontSetTextColor is false
                    if (!dontSetTextColor)
                    {
                        // Set the TextColor
                        TextColor = "RoyalBlue";
                    }
                }

                // Set the new value for ProgressStyle
                ProgressStyle = sb.ToString();
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
                Percent = startAtValue;
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

            #region BackgroundColor
            /// <summary>
            /// This property gets or sets the value for 'BackgroundColor'.
            /// </summary>
            [Parameter]
            public string BackgroundColor
            {
                get { return backgroundColor; }
                set { backgroundColor = value; }
            }
            #endregion
            
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
            
            #region ClientHandledIncrement
            /// <summary>
            /// This property gets or sets the value for 'ClientHandledIncrement'.
            /// </summary>
            [Parameter]
            public bool ClientHandledIncrement
            {
                get { return clientHandledIncrement; }
                set { clientHandledIncrement = value; }
            }
            #endregion
            
            #region CloseAtExtraPercent
            /// <summary>
            /// This property gets or sets the value for 'CloseAtExtraPercent'.
            /// </summary>
            [Parameter]
            public int CloseAtExtraPercent
            {
                get { return closeAtExtraPercent; }
                set { closeAtExtraPercent = value; }
            }
            #endregion
            
            #region Color
            /// <summary>
            /// This property gets or sets the value for 'Color'.
            /// </summary>
            [Parameter]
            public ColorEnum Color
            {
                get { return color; }
                set { color = value; }
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
            
            #region ExtraPercent
            /// <summary>
            /// This property gets or sets the value for 'ExtraPercent'.
            /// </summary>
            public int ExtraPercent
            {
                get { return extraPercent; }
                set { extraPercent = value; }
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
            
            #region HasTextColor
            /// <summary>
            /// This property returns true if the 'TextColor' exists.
            /// </summary>
            public bool HasTextColor
            {
                get
                {
                    // initial value
                    bool hasTextColor = (!String.IsNullOrEmpty(this.TextColor));
                    
                    // return value
                    return hasTextColor;
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
                set { increment = value; }
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

            #region OverrideThemeColorForText
            /// <summary>
            /// This property gets or sets the value for 'OverrideThemeColorForText'.
            /// </summary>
            [Parameter]
            public bool OverrideThemeColorForText
            {
                get { return overrideThemeColorForText; }
                set { overrideThemeColorForText = value; }
            }
            #endregion
            
            #region Percent
            /// <summary>
            /// This property gets or sets the value for 'Percent'.
            /// </summary>
            public int Percent
            {
                get { return percent; }
                set 
                {
                    // if less than zero
                    if (value < 0)
                    {
                        // set to 0
                        value = 0;
                    }

                    // if greater than 100
                    if (value > 100)
                    {
                        // set to 100
                        value = 100;
                    }

                    // set the value
                    percent = value;

                    // Set the ProgressStyle string
                    SetProgressStyle();

                    // Set the percentString value
                    PercentString = percent.ToString() + "%";
                }
            }
            #endregion
            
            #region PercentString
            /// <summary>
            /// This property gets or sets the value for 'PercentString'.
            /// </summary>
            public string PercentString
            {
                get { return percentString; }
                set { percentString = value; }
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
            
            #region ProgressStyle
            /// <summary>
            /// This property gets or sets the value for 'ProgressStyle'.
            /// </summary>
            public string ProgressStyle
            {
                get { return progressStyle; }
                set { progressStyle = value; }
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
            
            #region Size
            /// <summary>
            /// This property gets or sets the value for 'Size'.
            /// </summary>
            [Parameter]
            public SizeEnum Size
            {
                get { return size; }
                set { size = value; }
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
            
            #region TextColor
            /// <summary>
            /// This property gets or sets the value for 'TextColor'.
            /// </summary>
            [Parameter]
            public string TextColor
            {
                get { return textColor; }
                set { textColor = value; }
            }
            #endregion
            
            #region TextColorStyle
            /// <summary>
            /// This property gets or sets the value for 'TextColorStyle'.
            /// </summary>
            public string TextColorStyle
            {
                get { return textColorStyle; }
                set { textColorStyle = value; }
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

                    // Set the string that makes up the CSS
                    SetProgressStyle();
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
