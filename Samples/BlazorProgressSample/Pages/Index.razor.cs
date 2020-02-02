

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DataJuggler.UltimateHelper.Core;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.RandomShuffler.Core;

#endregion

namespace BlazorProgressSample.Pages
{

    #region class Index : IProgressSubscriber, ISpriteSubscriber
    /// <summary>
    /// This class is the code behind for the Index page.
    /// </summary>
    public partial class Index : IProgressSubscriber, ISpriteSubscriber

    {
        
        #region Private Variables
        private ProgressBar progressBar;
        private int fontSize;
        private string fontSizePixels;
        private string textSize;
        private string animationStyle;
        private bool showTrack;
        private string redCarStyle;
        private string whiteCarStyle;
        private int redCarPosition;
        private int whiteCarPosition;
        private Sprite redCar;
        private Sprite whiteCar;
        private RandomShuffler shuffler;
        private bool redWins;
        private bool whiteWins;
        private bool tie;
        private bool raceOver;
        private bool showBackground;
        private const int FinishLine = 1120;
        private const int FlagPosition = 1000;
        private const int RedCarY = 60;
        private const int WhiteCarY = 220;
        private const int RedFlagY = 8;
        private const int WhiteFlagY = 168;
        private double bubbleScale;
        private double backgroundScale;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of an Index page.
        /// This constructor runs at Startup to perform initializations.
        /// </summary>
        public Index()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Methods
   
            #region CheckForWinner()
            /// <summary>
            /// This method Check For Winner
            /// </summary>
            public bool CheckForWinner()
            {
                // initial value
                bool finished = false;    

                // if Red finished
                if ((RedCarPosition >= FinishLine) || (WhiteCarPosition >= FinishLine))
                {   
                    // finished
                    finished = true;

                    // Set Raceover to show the Race Again button
                    RaceOver = true;

                    // if the RedCarPosition
                    if (RedCarPosition > WhiteCarPosition)
                    {
                        // Red is is 
                        RedWins = true;
                    }
                    else if (WhiteCarPosition > RedCarPosition)
                    {
                        // Red is is 
                        WhiteWins = true;
                    }
                    else
                    {
                        // It is a tie
                        Tie = true;
                    }
                }

                // return value
                return finished;
            }
            #endregion
            
            #region HideRace()
            /// <summary>
            /// This method Hide Race
            /// </summary>
            public void HideRace()
            {
                // Hide the race track
                this.ShowTrack = false;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default values
                this.FontSize = 12;
                BackgroundScale = 1;
                BubbleScale = .6;
            }
            #endregion
            
            #region MakeTextBigger()
            /// <summary>
            /// This method Make Text Bigger
            /// </summary>
            public void MakeTextBigger()
            {
                // Increase the Font Size
                FontSize += 2;

                // if 24 or More
                if (FontSize >= 24)
                {
                    // Set to Max
                    FontSize = 24;
                }

                // Refresh the UI
                StateHasChanged();
            }
            #endregion

            #region MakeTextSmaller()
            /// <summary>
            /// This method Make Text Bigger
            /// </summary>
            public void MakeTextSmaller()
            {
                // Increase the Font Size
                FontSize -= 2;

                // if 8 or less
                if (FontSize <= 8)
                {
                    // Set to min
                    FontSize = 8;
                }

                // Refresh the UI
                StateHasChanged();
            }
            #endregion
            
            #region RaceAgain()
            /// <summary>
            /// This method Race Again
            /// </summary>
            public void RaceAgain()
            {
                // Reset all the values
                RedCarPosition = 0;
                WhiteCarPosition = 0;
                WhiteWins = false;
                RedWins = false;
                RaceOver = false;

                // Update the UI
                StateHasChanged();
            }
            #endregion
            
            #region Refresh(string message)
            /// <summary>
            /// This method is called by the ProgressBar when as it refreshes.
            /// </summary>
            public void Refresh(string message)
            {
                // not needed for this app
                
            }
            #endregion

            #region Refresh()
            /// <summary>
            /// This method is called by a Sprite when as it refreshes.
            /// </summary>
            public void Refresh()
            {
                if (HasShuffler)
                {
                    // pull the next red value
                    int nextRedValue = Shuffler.PullNextItem();

                    // pull the next White value
                    int nextWhiteValue = Shuffler.PullNextItem();

                    // Set the RedCarPosition
                    RedCarPosition += nextRedValue;

                    // Set the WhiteCarPosition
                    WhiteCarPosition += nextWhiteValue;

                    // Check For A Winner
                    bool finished = CheckForWinner();

                    // if finished
                    if (finished)
                    {
                        // Stop the Timer
                        RedCar.Stop();
                    }

                    // Update the UI
                    InvokeAsync(() =>
                    {
                        StateHasChanged();
                    });
                }
            }
            #endregion

            #region Register(ProgressBar progressBar)
            /// <summary>
            /// This method Registers the ProgressBar with this app.
            /// </summary>
            public void Register(ProgressBar progressBar)
            {
                // store the ProgressBar
                this.ProgressBar = progressBar;                
            }
            #endregion

            #region Register(Sprite sprite)
            /// <summary>
            /// This method Registers the ProgressBar with this app.
            /// </summary>
            public void Register(Sprite sprite)
            {
                // If the sprite object exists
                if (NullHelper.Exists(sprite))
                {
                    // if this is the RedCar
                    if (sprite.Name == "RedCar")
                    {
                        // Set the RedCar
                        RedCar = sprite;
                    }
                    else 
                    {
                        // Set the WhiteCar
                        WhiteCar = sprite;
                    }
                }
            }
            #endregion
            
            #region ShowProgressSimulation()
            /// <summary>
            /// This method Show Progress Simulation
            /// </summary>
            public void ShowProgressSimulation()
            {
                // if HasProgressBar
                if (HasProgressBar)
                {
                    // Create the Timer
                    ProgressBar.Start();
                }
            }
            #endregion

            #region ShowRace()
            /// <summary>
            /// This method Show Race
            /// </summary>
            public void ShowRace()
            {
                // Start the race
                ShowTrack = true;
            }
            #endregion
            
            #region StartRace()
            /// <summary>
            /// This method Start Race
            /// </summary>
            public void StartRace()
            {
                // if both cars exist
                if (NullHelper.Exists(RedCar, WhiteCar))
                {
                    // Create a new instance of a 'RandomShuffler' object.
                    Shuffler = new RandomShuffler(2, 12, 100, 3);

                    // Start the timer on the RedCar
                    RedCar.Start();
                }
            }
            #endregion
            
            #region StopProgressSimulation()
            /// <summary>
            /// This method Stops The Progress Simulation
            /// </summary>
            public void StopProgressSimulation()
            {
                // if HasProgressBar
                if (HasProgressBar)
                {
                    // Create the Timer
                    ProgressBar.Stop();
                }
            }
            #endregion
            
        #endregion
            
        #region Properties
            
            #region AnimationStyle
            /// <summary>
            /// This property gets or sets the value for 'AnimationStyle'.
            /// </summary>
            public string AnimationStyle
            {
                get { return animationStyle; }
                set { animationStyle = value; }
            }
            #endregion
            
            #region BackgroundScale
            /// <summary>
            /// This property gets or sets the value for 'BackgroundScale'.
            /// </summary>
            public double BackgroundScale
            {
                get { return backgroundScale; }
                set { backgroundScale = value; }
            }
            #endregion
            
            #region BubbleScale
            /// <summary>
            /// This property gets or sets the value for 'BubbleScale'.
            /// </summary>
            public double BubbleScale
            {
                get { return bubbleScale; }
                set { bubbleScale = value; }
            }
            #endregion
            
            #region FontSize
            /// <summary>
            /// This property gets or sets the value for 'FontSize'.
            /// </summary>
            public int FontSize
            {
                get { return fontSize; }
                set 
                {
                    // set the return value
                    fontSize = value;

                    // set the value
                    FontSizePixels = fontSize.ToString() + "px";
                }
            }
            #endregion

            #region FontSizePixels
            /// <summary>
            /// This property gets or sets the value for 'FontSizePixels'.
            /// </summary>
            public string FontSizePixels
            {
                get { return fontSizePixels; }
                set { fontSizePixels = value; }
            }
            #endregion
            
            #region HasProgressBar
            /// <summary>
            /// This property returns true if this object has a 'ProgressBar'.
            /// </summary>
            public bool HasProgressBar
            {
                get
                {
                    // initial value
                    bool hasProgressBar = (this.ProgressBar != null);
                    
                    // return value
                    return hasProgressBar;
                }
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
            
            #region ProgressBar
            /// <summary>
            /// This property gets or sets the value for 'ProgressBar'.
            /// </summary>
            public ProgressBar ProgressBar
            {
                get { return progressBar; }
                set { progressBar = value; }
            }
            #endregion
            
            #region RaceOver
            /// <summary>
            /// This property gets or sets the value for 'RaceOver'.
            /// </summary>
            public bool RaceOver
            {
                get { return raceOver; }
                set { raceOver = value; }
            }
            #endregion
            
            #region RedCar
            /// <summary>
            /// This property gets or sets the value for 'RedCar'.
            /// </summary>
            public Sprite RedCar
            {
                get { return redCar; }
                set { redCar = value; }
            }
            #endregion
            
            #region RedCarPosition
            /// <summary>
            /// This property gets or sets the value for 'RedCarPosition'.
            /// </summary>
            public int RedCarPosition
            {
                get { return redCarPosition; }
                set { redCarPosition = value; }
            }
            #endregion
            
            #region RedCarStyle
            /// <summary>
            /// This property gets or sets the value for 'RedCarStyle'.
            /// </summary>
            public string RedCarStyle
            {
                get { return redCarStyle; }
                set { redCarStyle = value; }
            }
            #endregion
            
            #region RedWins
            /// <summary>
            /// This property gets or sets the value for 'RedWins'.
            /// </summary>
            public bool RedWins
            {
                get { return redWins; }
                set { redWins = value; }
            }
            #endregion
            
            #region ShowBackground
            /// <summary>
            /// This property gets or sets the value for 'ShowBackground'.
            /// </summary>
            public bool ShowBackground
            {
                get { return showBackground; }
                set { showBackground = value; }
            }
            #endregion
            
            #region ShowTrack
            /// <summary>
            /// This property gets or sets the value for 'ShowTrack'.
            /// </summary>
            public bool ShowTrack
            {
                get { return showTrack; }
                set { showTrack = value; }
            }
            #endregion
            
            #region Shuffler
            /// <summary>
            /// This property gets or sets the value for 'Shuffler'.
            /// </summary>
            public RandomShuffler Shuffler
            {
                get { return shuffler; }
                set { shuffler = value; }
            }
            #endregion
            
            #region TextSize
            /// <summary>
            /// This property gets or sets the value for 'TextSize'.
            /// </summary>
            public string TextSize
            {
                get { return textSize; }
                set { textSize = value; }
            }
            #endregion
            
            #region Tie
            /// <summary>
            /// This property gets or sets the value for 'Tie'.
            /// </summary>
            public bool Tie
            {
                get { return tie; }
                set { tie = value; }
            }
            #endregion
            
            #region WhiteCar
            /// <summary>
            /// This property gets or sets the value for 'WhiteCar'.
            /// </summary>
            public Sprite WhiteCar
            {
                get { return whiteCar; }
                set { whiteCar = value; }
            }
            #endregion
            
            #region WhiteCarPosition
            /// <summary>
            /// This property gets or sets the value for 'WhiteCarPosition'.
            /// </summary>
            public int WhiteCarPosition
            {
                get { return whiteCarPosition; }
                set { whiteCarPosition = value; }
            }
            #endregion
            
            #region WhiteCarStyle
            /// <summary>
            /// This property gets or sets the value for 'WhiteCarStyle'.
            /// </summary>
            public string WhiteCarStyle
            {
                get { return whiteCarStyle; }
                set { whiteCarStyle = value; }
            }
            #endregion
            
            #region WhiteWins
            /// <summary>
            /// This property gets or sets the value for 'WhiteWins'.
            /// </summary>
            public bool WhiteWins
            {
                get { return whiteWins; }
                set { whiteWins = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
