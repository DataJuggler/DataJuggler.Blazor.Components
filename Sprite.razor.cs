

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Components;
using DataJuggler.Blazor.Components.Interfaces;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class Sprite
    /// <summary>
    /// This class is the code behind for the Sprite component
    /// </summary>
    public partial class Sprite
    {

        #region Private Variables
        private string spriteStyle;
        private Timer timer;
        private int xIncrement;
        private int yIncrement;
        private int xPosition;
        private int yPosition;
        private string xPositionStyle;
        private string yPositionStyle;
        private int interval;
        private bool started;
        private string display;
        private bool visible;
        private int height;
        private string heightPixels;
        private string widthPixels;
        private int width;
        private string name;
        private bool notificaitonInProgress;        
        private string imageUrl;
        private int zIndex;
        private double scale;
        private string position;
        private ISpriteSubscriber subscriber;
        private double opacity;
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
                // if a subscriber 
                if (HasSubscriber)
                {
                    // Notify Subscriber
                    Subscriber.Refresh();
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
                // Defaults
                XPosition = 0;
                YPosition = 0;
                Scale = 1;
                Visible = true;
                Interval = 100;
                
                // In front of a background in theory
                ZIndex = 1;
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
            
            #region Height
            /// <summary>
            /// This property gets or sets the value for 'Height'.
            /// </summary>
            [Parameter]
            public int Height
            {
                get { return height; }
                set 
                { 
                    // set the value
                    height = value;

                    // Set the value of HeightPixels
                    HeightPixels = height.ToString() + "px";
                }
            }
            #endregion
            
            #region HeightPixels
            /// <summary>
            /// This property gets or sets the value for 'HeightPixels'.
            /// </summary>
            public string HeightPixels
            {
                get { return heightPixels; }
                set { heightPixels = value; }
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
            public int Width
            {
                get { return width; }
                set 
                {
                    // set the value
                    width = value;

                    // set the value of WidthPixels
                    WidthPixels = width.ToString() + "px";
                }
            }
            #endregion
            
            #region WidthPixels
            /// <summary>
            /// This property gets or sets the value for 'WidthPixels'.
            /// </summary>
            public string WidthPixels
            {
                get { return widthPixels; }
                set { widthPixels = value; }
            }
            #endregion
            
            #region XIncrement
            /// <summary>
            /// This property gets or sets the value for 'XIncrement'.
            /// </summary>
            public int XIncrement
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
            public int XPosition
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
            public int YIncrement
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
            public int YPosition
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
