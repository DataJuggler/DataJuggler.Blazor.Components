

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;

#endregion

namespace BlazorProgressSample.Pages
{

    #region class Index
    /// <summary>
    /// This class is the code behind for the Index page.
    /// </summary>
    public partial class Index : IProgressSubscriber
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
            
            #region Refresh(string message)
            /// <summary>
            /// This method is called by the ProgressBar when as it refreshes.
            /// </summary>
            public void Refresh(string message)
            {
                // not needed for this app
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

            #region StartRace()
            /// <summary>
            /// This method Start Race
            /// </summary>
            public void StartRace()
            {
                // Start the race
                ShowTrack = true;
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
            
        #endregion
        
    }
    #endregion

}
