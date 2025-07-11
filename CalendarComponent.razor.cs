﻿

#region using statements

using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Objects;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class CalendarComponent
    /// <summary>
    /// This class is the code behind for the CalendarComponent
    /// </summary>
    public partial class CalendarComponent : IBlazorComponent, IBlazorComponentParent, ILabelFont, ITextBoxFont
    {
        
        #region Private Variables
        private Color buttonBorderColor;
        private double buttonBorderWidth;
        private bool allowYearSelector;        
        private string name;
        private IBlazorComponentParent parent;
        private bool expanded;
        private List<DayObject> dates;
        private string bottomRowClassName;
        private string calendarStyle;
        private string caption;
        private double height;
        private string heightStyle;
        private string heightUnit;
        private string buttonStyle;
        private string buttonUrl;
        private double cellWidth;
        private double fontSize;
        private string fontName;
        private double width;
        private string unit;
        private string containerStyle;
        private double buttonLeft;
        private double buttonTop;
        private double calendarLeft;
        private double calendarTop;
        private double textBoxHeight;
        private double textBoxWidth;
        private double column1Width;
        private double column2Width;
        private double dayRowLeft;
        private double dayRowHeight;
        private double dayRowWidth;
        private double dayRowTop;
        private double buttonWidth;
        private double buttonHeight;
        private double controlWidth;
        private double controlHeight;
        private string className;
        private Color labelColor;
        private double left;
        private double top;
        private string display;
        private string calendarDisplay;
        private string columnStyle;
        private string rowStyle;        
        private Color dayRowColor;
        private Color dayRowTextColor;
        private string dayRowStyle;
        private string dayButtonStyle;
        private string dayButtonStyle2;
        private string dayButtonStyle3;        
        private DateTime selectedDate;
        private double labelFontSize;
        private string labelFontName;
        private TextBoxComponent textBox;
        private string prevYearButtonUrl;
        private string nextYearButtonUrl;
        private string prevMonthButtonUrl;
        private string nextMonthButtonUrl;
        private string dateTitle;
        private string navButtonStyle;
        private string bottomRowStyle;
        private DateTime thisMonth;
        private string labelClassName;
        private string position;        
        private double textBoxLeft;
        private double rowHeight;
        private string yearSelectorButtonStyle;
        private bool yearSelectorVisible;
        private double yearButtonWidth;
        private ThemeEnum theme;
        private string yearSelectorStyle;
        private string yearSelectorDecadesStyle;
        private string yearSelectorYearsStyle;
        private string yearSelectorDisplay;
        private Decade selectedDecade;
        private string decadeButtonStyle;
        private string yearButtonStyle;
        private string dividerStyle;
        private string yearSelectorContainerStyle;
        private Color selectedColor;
        private string yearButtonSelectedStyle;
        private Color yearButtonTextColor;
        private Color yearButtonTextColorSelected;
        private string navButtonCellStyle;
        private ImageButton button;
        private double dateTitleLeft;
        private double dateTitleTop;
        private string dateTitlePosition;
        private double yearSelectorLeft;
        private double yearSelectorTop;
        private double textBoxFontSize;
        private string textBoxFontName;
        private YearSelectorAlignmentEnum yearSelectorAlignment;
        private string calendarPosition;
        private List<CalendarRow> weeks;
        private double scale;       
        private string dayRowColumnStyle;
        private int zIndex;
        private double bottomRowLeft;
        private double bottomRowBottom;
        private double bottomRowFontSize;
        private string bottomRowFontName;
        private string bottomRowPosition;
        private string bottomRowFontWeight;
        private double labelLeft;
        private double rowLeft;        
        private double dayButtonWidth;
        private string dayButtonContainerStyle;
        private double dayButtonContainerLeft;
        private double dayButtonContainerTop;
        private string cellWidth2Style;
        private double textBoxTop;
        private string dayRowTextStyle;
        private double dayRowTextLeft;
        private double dayRowTextTop;
        
        // Nav buttons
        private double previousYearButtonLeft;        
        private double previousMonthButtonLeft;        
        private double nextYearButtonLeft;        
        private double nextMonthButtonLeft;        
        private double bottomNavButtonTop;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CalendarComponent' object.
        /// </summary>
        public CalendarComponent()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Methods
            
            #region ButtonClicked(int buttonNumber, string buttonName)
            /// <summary>
            /// Button Clicked
            /// </summary>
            public void ButtonClicked(int buttonNumber, string buttonName)
            {
                if (buttonNumber == 1)
                {
                    // Toggle the open or close, which shows the calendar or not
                    Expanded = !Expanded;
                }
                else if (buttonNumber == 2)
                {
                    // Previous Year
                    CreateDates(ThisMonth.Year - 1, ThisMonth.Month);
                }
                else if (buttonNumber == 3)
                {
                    // Create a tempDate one month prior
                    DateTime tempDate = ThisMonth.AddMonths(-1);

                    // Previous Month
                    CreateDates(tempDate.Year, tempDate.Month);
                }
                else if (buttonNumber == 4)
                {
                    // Next Month

                    // Create a tempDate one month forward
                    DateTime tempDate = ThisMonth.AddMonths(1);

                    // Recreate the Date
                    CreateDates(tempDate.Year, tempDate.Month);
                }
                else if (buttonNumber == 5)
                {
                    // Next Year
                    CreateDates(ThisMonth.Year + 1, ThisMonth.Month);
                }

                // Update the UI
                Refresh();
            }
            #endregion
            
            #region Close()
            /// <summary>
            /// Close
            /// </summary>
            public void Close()
            {
                // If currently open
                if (Expanded)
                {
                    // Set to closed
                    Expanded = false;

                    // Update the UI
                    Refresh();
                }
            }
            #endregion
            
            #region CreateDates(int year, int month)
            /// <summary>
            /// returns a list of Dates
            /// </summary>
            public void CreateDates(int year, int month)
            {
                // initial value
                Dates = new List<DayObject>();

                // locals
                DateTime now = DateTime.Now;
                ThisMonth = new DateTime(year, month, 1);
                DateTime firstOfMonth = new DateTime(year, month, 1);                
                DayOfWeek dayOfWeek = firstOfMonth.DayOfWeek;            
                int prevMonthDays = GetPrevMonthDays(dayOfWeek);                
                int daysInMonth = System.DateTime.DaysInMonth(year, month);
                DateTime lastDayOfMonth = new DateTime(year, month, daysInMonth);
                dayOfWeek = lastDayOfMonth.DayOfWeek;
                int nextMonthDays = GetNextMonthDays(dayOfWeek);

                // Get the name
                DateTitle = DateHelper.GetMonthName(firstOfMonth) + " " + year.ToString();

                // Now create the dates
                for (int x = 0; x < prevMonthDays; x++)
                {
                    // get the number of days this is from the firstOfMonth and make negative
                    int previousDays = (prevMonthDays - x) * -1;

                    // Get the datetime for this day
                    DateTime tempDate = firstOfMonth.AddDays(previousDays);

                    // Create a new instance of a 'DayObject' object.
                    DayObject dayObject = new DayObject();

                    // Set the properties
                    dayObject.Date = tempDate;

                    // This will show in Gray
                    dayObject.ThisMonth = false;

                    // Add this day
                    dates.Add(dayObject);
                }

                // Now add the days from this month
                for (int x = 0; x < daysInMonth; x++)
                {
                    // Get the datetime for this day
                    DateTime tempDate = firstOfMonth.AddDays(x);

                    // Create a new instance of a 'DayObject' object.
                    DayObject dayObject = new DayObject();

                    // Set the properties
                    dayObject.Date = tempDate;

                    if ((tempDate.Year == now.Year) && (tempDate.Month == now.Month) && (tempDate.Day == now.Day))
                    {
                        // only way it can be true
                        dayObject.Today = true;
                    }

                    // This will show in Gray
                    dayObject.ThisMonth = true;

                    // Add this day
                    dates.Add(dayObject);
                }

                // Now Add the dates that show after this month
                for (int x = 0; x < nextMonthDays; x++)
                {
                    // get the number of days this is from the firstOfMonth and make negative

                    // Get the datetime for this day
                    DateTime tempDate = lastDayOfMonth.AddDays(x + 1);

                    // Create a new instance of a 'DayObject' object.
                    DayObject dayObject = new DayObject();

                    // Set the properties
                    dayObject.Date = tempDate;

                    // This will show in Gray
                    dayObject.ThisMonth = false;

                    // Add this day
                    dates.Add(dayObject);
                }

                // Set the CurrentWeeks
                Weeks = GetWeeks();
            }
            #endregion
            
            #region DateSelected(DayObject date)
            /// <summary>
            /// A date was selected. This method sets the selected date and closes the Calendar.
            /// </summary>
            public void DateSelected(DayObject date)
            {
                // Store
                SelectedDate = date.Date;

                // if exists
                if (HasTextBox)
                {
                    // Display the value
                    TextBox.SetTextValue(date.Date.ToShortDateString());
                }

                // Hide
                Expanded = false;

                // Update the UI
                Refresh();
            }
            #endregion
            
            #region GetNextMonthDays()
            /// <summary>
            /// returns the Next Month Days
            /// </summary>
            public static int GetNextMonthDays(DayOfWeek dayOfWeek)
            {
                // initial value
                int prevMonthDays = 0;

                switch (dayOfWeek)
                {
                    case DayOfWeek.Sunday:

                        // Set the 
                        prevMonthDays = 6;

                        // required
                        break;

                    case DayOfWeek.Monday:

                        // Set the 
                        prevMonthDays = 5;

                        // required
                        break;

                    case DayOfWeek.Tuesday:

                        // Set the 
                        prevMonthDays = 4;

                        // required
                        break;

                    case DayOfWeek.Wednesday:

                        // Set the 
                        prevMonthDays = 3;

                        // required
                        break;

                    case DayOfWeek.Thursday:

                        // Set the 
                        prevMonthDays = 2;

                        // required
                        break;

                    case DayOfWeek.Friday:

                        // Set the 
                        prevMonthDays = 1;

                        // required
                        break;

                    case DayOfWeek.Saturday:

                        // Set the 
                        prevMonthDays = 0;

                        // required
                        break;
                }
                
                // return value
                return prevMonthDays;
            }
            #endregion
            
            #region GetPrevMonthDays()
            /// <summary>
            /// returns the Prev Month Days
            /// </summary>
            public static int GetPrevMonthDays(DayOfWeek dayOfWeek)
            {
                // initial value
                int prevMonthDays = 0;

                switch (dayOfWeek)
                {
                    case DayOfWeek.Sunday:

                        // Set the 
                        prevMonthDays = 0;

                        // required
                        break;

                    case DayOfWeek.Monday:

                        // Set the 
                        prevMonthDays = 1;

                        // required
                        break;

                    case DayOfWeek.Tuesday:

                        // Set the 
                        prevMonthDays = 2;

                        // required
                        break;

                    case DayOfWeek.Wednesday:

                        // Set the 
                        prevMonthDays = 3;

                        // required
                        break;

                    case DayOfWeek.Thursday:

                        // Set the 
                        prevMonthDays = 4;

                        // required
                        break;

                    case DayOfWeek.Friday:

                        // Set the 
                        prevMonthDays = 5;

                        // required
                        break;

                    case DayOfWeek.Saturday:

                        // Set the 
                        prevMonthDays = 6;

                        // required
                        break;
                }
                
                // return value
                return prevMonthDays;
            }
            #endregion
            
            #region GetWeeks()
            /// <summary>
            /// returns a list of Weeks
            /// </summary>
            public List<CalendarRow> GetWeeks()
            {
                // initial value
                List<CalendarRow> weeks = new List<CalendarRow>();

                // Create a CalendarRow
                CalendarRow currentWeek = new CalendarRow();

                // If the Dates collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(Dates))
                {
                    for (int i = 0; i < Dates.Count; i++)
                    {
                        if (i % 7 == 0 && i != 0)
                        {
                            // Add this week
                            weeks.Add(currentWeek);

                            // Set the new currentWeek
                            currentWeek = new CalendarRow();
                        }

                        // Add this DayObject to the currentWeek
                        currentWeek.Days.Add(Dates[i]);
                    }

                    // Add the last week if it has any days
                    if (currentWeek.Days.Count > 0)
                    {
                        // Add this week
                        weeks.Add(currentWeek);
                    }
                }
                
                // return value
                return weeks;
            }
            #endregion
            
            #region Hide(bool refresh = true)
            /// <summary>
            /// Hide
            /// </summary>
            public void Hide(bool refresh = true)
            {
                // Set the value
                Display = "none";

                // if the value for refresh is true
                if (refresh)
                {
                    // Update the UI
                    Refresh();
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Get the current date
                DateTime now = DateTime.Now;

                // Create the dates
                CreateDates(now.Year, now.Month);

                // Default
                Caption = "Date:";

                // Set Defaults
                AllowYearSelector = false;
                ButtonBorderColor = Color.Black;
                ButtonBorderWidth = 1;
                BottomNavButtonTop = 2;
                BottomRowBottom = 3;
                BottomRowClassName = "right12 up4 width220";                
                BottomRowFontName = "Calibri";
                BottomRowFontSize = 11;
                BottomRowFontWeight = "bold";
                BottomRowLeft = -8;
                BottomRowPosition = "absolute";
                ButtonHeight = 22;
                ButtonLeft = 5;
                ButtonTop = 0;
                ButtonWidth = 24;
                CalendarLeft = 300;
                CalendarPosition = "relative";
                CalendarTop = -156;
                Caption = "Date:";                
                DayButtonWidth = 32;
                Column1Width = GlobalDefaults.Column1Width;
                Column2Width = GlobalDefaults.Column2Width;
                ControlHeight = 32;
                ControlWidth = 640;
                DateTitleLeft = 0;
                DateTitlePosition = "relative";
                DateTitleTop = 0;
                DayRowColor = Color.DodgerBlue;
                DayRowLeft = 0;                
                DayButtonContainerLeft = 2;
                DayRowTextColor = Color.White;
                FontSize = GlobalDefaults.LabelFontSize;
                Height = 146;
                HeightUnit = "px";
                LabelClassName = "down4 right6";
                LabelColor = Color.Black;
                LabelFontName = GlobalDefaults.LabelFontName;
                LabelFontSize = GlobalDefaults.LabelFontSize;
                LabelLeft = -4;
                Position = "relative";
                RowLeft = -3;
                RowHeight = 12.8;
                Scale = 100;
                SelectedColor = Color.Firebrick;
                TextBoxFontName = GlobalDefaults.TextBoxFontName;
                TextBoxFontSize = GlobalDefaults.TextBoxFontSize;
                TextBoxHeight = 21;
                TextBoxLeft = -3;
                TextBoxTop = 2;
                TextBoxWidth = GlobalDefaults.TextBoxWidth;
                Theme = ThemeEnum.BlueGold;
                Top = 4;
                Left = 0;
                Unit = "px";
                Width = 228;
                YearButtonTextColor = Color.Black;
                YearButtonTextColorSelected = Color.White;
                YearButtonWidth = 24;
                YearSelectorAlignment = YearSelectorAlignmentEnum.OnBottom;
                ZIndex = 400;
                
                // Buttons
                NextYearButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/VCRLastSmall.png";
                NextMonthButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/VCRNextSmall.png";
                PrevYearButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/VCRFirstSmall.png";
                PrevMonthButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/VCRPrevSmall.png";

                // Adjust posions
                PreviousYearButtonLeft = 12;
                PreviousMonthButtonLeft = 12;
                NextYearButtonLeft = 12;
                NextMonthButtonLeft = 12;
            
                // Setup the Component
                SetupComponent();
            }
            #endregion

            #region OnAfterRenderAsync(bool firstRender)
            /// <summary>
            /// This method is used to verify a user
            /// </summary>
            /// <param name="firstRender"></param>
            /// <returns></returns>
            protected async override Task OnAfterRenderAsync(bool firstRender)
            {
                if (firstRender)
                {
                    // Setup this component
                    SetupComponent();
                }

                // call the base
                await base.OnAfterRenderAsync(firstRender);
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // local
                DateTime invalidDate = new DateTime(1900, 1, 1);

                if ((NullHelper.Exists(message)) && (HasTextBox))
                {
                    if (message.Text == "EnterPressed")
                    {
                        SelectedDate = DateHelper.ParseDate(TextBox.Text, invalidDate, invalidDate);

                        // if a valid date
                        if (SelectedDate.Year > 1900)
                        {
                            // Set the Date
                            TextBox.SetTextValue(SelectedDate.ToShortDateString());

                            // Close the Calendar if open
                            Close();
                        }
                    }
                    else if (message.Text == "EscapePressed")
                    {
                        // Close the Calendar if open
                        Close();
                    }
                }
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// method Refresh
            /// </summary>
            public void Refresh()
            {
                InvokeAsync(() =>
                {
                    // Refresh
                    StateHasChanged();
                });
            }
            #endregion
            
            #region Register(IBlazorComponent component)
            /// <summary>
            /// method Register
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                if (component is TextBoxComponent)
                {
                    // Store
                    TextBox = component as TextBoxComponent;                    
                }
                else if (component is ImageButton)
                {
                    // Store
                    Button = component as ImageButton;
                }
            }
            #endregion
            
            #region SelectDecade(Decade decade)
            /// <summary>
            /// Select Decade
            /// </summary>
            public void SelectDecade(Decade decade)
            {
                // Store
                SelectedDecade = decade;

                // if the value for HasSelectdDecade is true
                if (HasSelectedDecade)
                {
                    // if the years have not been loaded yet
                    if (!SelectedDecade.HasYears)
                    {
                        // Load the Years
                        SelectedDecade.Years = Decade.CreateYears(SelectedDecade);
                    }
                }
            }
            #endregion
            
            #region SelectYear(int year)
            /// <summary>
            /// Select Year
            /// </summary>
            public void SelectYear(int year)
            {
                // Get the selected Month
                int month = SelectedDate.Month;
                int day = SelectedDate.Day;
                int lastDayOfMonth = DateTime.DaysInMonth(year, month);

                // can't be a day that doesn't exist
                if (day > lastDayOfMonth)
                {
                    // reset
                    day = lastDayOfMonth;
                }

                // Recreate the Selected Date
                SelectedDate = new DateTime(year, month, day);

                // Create the Dates
                CreateDates(SelectedDate.Year, SelectedDate.Month);

                // Redraw the Component
                SetupComponent();

                // Stop showing the Year Selector
                ToggleYearSelector();
            }
            #endregion
            
            #region SetSelectedDate(DateTime date)
            /// <summary>
            /// Set Selected Date
            /// </summary>
            public void SetSelectedDate(DateTime date)
            {
                // Set the SelectedDate
                SelectedDate = date;

                // if the value for HasTextBox is true
                if (HasTextBox)
                {
                    // Dislay
                    TextBox.SetTextValue(SelectedDate.ToShortDateString());

                    // Create the Dates
                    CreateDates(date.Year, date.Month);
                }
            }

        #endregion

            #region SetupComponent()
            /// <summary>
            /// Setup Component
            /// </summary>
            public void SetupComponent()
            {
                // if Blue Mode
                if (theme == ThemeEnum.Blue)
                {      
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/TriangleButtonOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/TriangleButtonClosed.png";
                    }
                }
                else if ((theme == ThemeEnum.Dark) || (theme == ThemeEnum.Black))
                { 
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlackTriangleOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlackTriangleClosed.png";
                    }
                }
                else if (theme == ThemeEnum.Brown)
                {      
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BrownTriangleOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BrownTriangleClosed.png";
                    }
                }
                else if (theme == ThemeEnum.BlueGold)
                {
                    if (Expanded)
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlueGoldArrowOpen.png";
                    }
                    else
                    {
                        ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/BlueGoldArrowClosed.png";
                    }
                }
                
                // If Expanded
                if (Expanded)
                {
                    // Show Calendar
                    CalendarDisplay = "inline-block";

                    // if the value for YearSelectorVisible is true
                    if (YearSelectorVisible)
                    {
                        // Set to show
                        YearSelectorDisplay = "inline-block";

                        // if on YearSelector appears on left
                        if (YearSelectorAlignment == YearSelectorAlignmentEnum.OnLeft)
                        {
                            // Left Side
                            YearSelectorLeft = -184;
                        }
                        else if (YearSelectorAlignment == YearSelectorAlignmentEnum.OnRight)
                        {
                            // Right Side
                            YearSelectorLeft = 226;
                        }
                        else
                        {
                            // On bottom
                            YearSelectorLeft = 21;
                        }
                        
                        // Defaults to 40
                        YearSelectorTop = 40;
                    }
                    else
                    {
                        // Set to hide
                        YearSelectorDisplay = "none";
                    }
                }
                else
                {
                    // Hide
                    CalendarDisplay = "none";

                    // Set to hide
                    YearSelectorDisplay = "none";
                }

                // if the Button exists
                if (HasButton)
                {
                    // Update the Button
                    Button.Refresh();
                }
            }
            #endregion

            #region Show(bool refresh = true)
            /// <summary>
            /// Show
            /// </summary>
            public void Show(bool refresh = true)
            {
                // Set the value
                Display = "inline-block";

                // if the value for refresh is true
                if (refresh)
                {
                    // Update the UI
                    Refresh();
                }
            }
            #endregion

            #region ToggleYearSelector()
            /// <summary>
            /// Toggle the Year Selector
            /// </summary>
            public void ToggleYearSelector()
            {
                // Toggle
                YearSelectorVisible = !YearSelectorVisible;

                // Update
                Refresh();
            }
            #endregion
           
        #endregion
        
        #region Properties
            
            #region AllowYearSelector
            /// <summary>
            /// This property gets or sets the value for 'AllowYearSelector'.
            /// If true, the month and year becomes a button, and a user
            /// can select a decade and or year.
            /// </summary>
            [Parameter]
            public bool AllowYearSelector
            {
                get { return allowYearSelector; }
                set { allowYearSelector = value; }
            }
            #endregion
            
            #region BottomNavButtonTop
            /// <summary>
            /// This property gets or sets the value for 'BottomNavButtonTop'.
            /// </summary>
            [Parameter]
            public double BottomNavButtonTop
            {
                get { return bottomNavButtonTop; }
                set { bottomNavButtonTop = value; }
            }
            #endregion
            
            #region BottomRowBottom
            /// <summary>
            /// This property gets or sets the value for 'BottomRowBottom'.
            /// </summary>
            [Parameter]
            public double BottomRowBottom
            {
                get { return bottomRowBottom; }
                set { bottomRowBottom = value; }
            }
            #endregion
            
            #region BottomRowBottomStyle
            /// <summary>
            /// This read only property returns the value of BottomRowBottom + HeightUnit
            /// </summary>
            public string BottomRowBottomStyle
            {
                
                get
                {
                    // initial value
                    string bottomRowBottomStyle = BottomRowBottom + HeightUnit;
                    
                    // return value
                    return bottomRowBottomStyle;
                }
            }
            #endregion
            
            #region BottomRowClassName
            /// <summary>
            /// This property gets or sets the value for 'BottomRowClassName'.
            /// </summary>
            [Parameter]
            public string BottomRowClassName
            {
                get { return bottomRowClassName; }
                set { bottomRowClassName = value; }
            }
            #endregion
            
            #region BottomRowFontName
            /// <summary>
            /// This property gets or sets the value for 'BottomRowFontName'.
            /// </summary>
            [Parameter]
            public string BottomRowFontName
            {
                get { return bottomRowFontName; }
                set { bottomRowFontName = value; }
            }
            #endregion
            
            #region BottomRowFontSize
            /// <summary>
            /// This property gets or sets the value for 'BottomRowFontSize'.
            /// </summary>
            [Parameter]
            public double BottomRowFontSize
            {
                get { return bottomRowFontSize; }
                set { bottomRowFontSize = value; }
            }
            #endregion
            
            #region BottomRowFontSizeStyleStyle
            /// <summary>
            /// This read only property returns the value of BottomRowFontSize + HeightUnit;
            /// </summary>
            public string BottomRowFontSizeStyle
            {
                
                get
                {
                    // initial value
                    string bottomRowFontSizeStyle = BottomRowFontSize + HeightUnit;
                    
                    // return value
                    return bottomRowFontSizeStyle;
                }
            }
            #endregion
            
            #region BottomRowFontWeight
            /// <summary>
            /// This property gets or sets the value for 'BottomRowFontWeight'.
            /// </summary>
            [Parameter]
            public string BottomRowFontWeight
            {
                get { return bottomRowFontWeight; }
                set { bottomRowFontWeight = value; }
            }
            #endregion
            
            #region BottomRowLeft
            /// <summary>
            /// This property gets or sets the value for 'BottomRowLeft'.
            /// </summary>
            [Parameter]
            public double BottomRowLeft
            {
                get { return bottomRowLeft; }
                set { bottomRowLeft = value; }
            }
            #endregion
            
            #region BottomRowLeftStyle
            /// <summary>
            /// This read only property returns the value of BottomRowLeftStyle + Unit;
            /// </summary>
            public string BottomRowLeftStyle
            {
                
                get
                {
                    // initial value
                    string bottomRowLeftStyle = BottomRowLeft + Unit;
                    
                    // return value
                    return bottomRowLeftStyle;
                }
            }
            #endregion
            
            #region BottomRowPosition
            /// <summary>
            /// This property gets or sets the value for 'BottomRowPosition'.
            /// </summary>
            [Parameter]
            public string BottomRowPosition
            {
                get { return bottomRowPosition; }
                set { bottomRowPosition = value; }
            }
            #endregion
            
            #region BottomRowStyle
            /// <summary>
            /// This property gets or sets the value for 'BottomRowStyle'.
            /// </summary>
            public string BottomRowStyle
            {
                get { return bottomRowStyle; }
                set { bottomRowStyle = value; }
            }
            #endregion
            
            #region Button
            /// <summary>
            /// This property gets or sets the value for 'Button'.
            /// </summary>
            public ImageButton Button
            {
                get { return button; }
                set { button = value; }
            }
            #endregion
            
            #region ButtonBorderColor
            /// <summary>
            /// This property gets or sets the value for 'ButtonBorderColor'.
            /// </summary>
            [Parameter]
            public Color ButtonBorderColor
            {
                get { return buttonBorderColor; }
                set { buttonBorderColor = value; }
            }
            #endregion
            
            #region ButtonBorderWidth
            /// <summary>
            /// This property gets or sets the value for 'ButtonBorderWidth'.
            /// </summary>
            [Parameter]
            public double ButtonBorderWidth
            {
                get { return buttonBorderWidth; }
                set { buttonBorderWidth = value; }
            }
            #endregion
            
            #region ButtonHeight
            /// <summary>
            /// This property gets or sets the value for 'ButtonHeight'.
            /// </summary>
            [Parameter]
            public double ButtonHeight
            {
                get { return buttonHeight; }
                set { buttonHeight = value; }
            }
            #endregion
            
            #region ButtonLeft
            /// <summary>
            /// This property gets or sets the value for 'ButtonLeft'.
            /// </summary>
            [Parameter]
            public double ButtonLeft
            {
                get { return buttonLeft; }
                set { buttonLeft = value; }
            }
            #endregion
            
            #region ButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'ButtonStyle'.
            /// </summary>
            public string ButtonStyle
            {
                get { return buttonStyle; }
                set { buttonStyle = value; }
            }
            #endregion
            
            #region ButtonTop
            /// <summary>
            /// This property gets or sets the value for 'ButtonTop'.
            /// </summary>
            [Parameter]
            public double ButtonTop
            {
                get { return buttonTop; }
                set { buttonTop = value; }
            }
            #endregion
            
            #region ButtonUrl
            /// <summary>
            /// This property gets or sets the value for 'ButtonUrl'.
            /// </summary>
            [Parameter]
            public string ButtonUrl
            {
                get { return buttonUrl; }
                set { buttonUrl = value; }
            }
            #endregion
            
            #region ButtonWidth
            /// <summary>
            /// This property gets or sets the value for 'ButtonWidth'.
            /// </summary>
            [Parameter]
            public double ButtonWidth
            {
                get { return buttonWidth; }
                set { buttonWidth = value; }
            }
            #endregion
            
            #region CalendarDisplay
            /// <summary>
            /// This property gets or sets the value for 'CalendarDisplay'.
            /// </summary>
            [Parameter]
            public string CalendarDisplay
            {
                get { return calendarDisplay; }
                set { calendarDisplay = value; }
            }
            #endregion
            
            #region CalendarLeft
            /// <summary>
            /// This property gets or sets the value for 'CalendarLeft'.
            /// </summary>
            [Parameter]
            public double CalendarLeft
            {
                get { return calendarLeft; }
                set { calendarLeft = value; }
            }
            #endregion
            
            #region CalendarLeftStyle
            /// <summary>
            /// This read only property returns the value of CalendarLeft + Unit
            /// </summary>
            public string CalendarLeftStyle
            {
                
                get
                {
                    // initial value
                    string calendarLeftStyle = CalendarLeft + Unit;
                    
                    // return value
                    return calendarLeftStyle;
                }
            }
            #endregion
            
            #region CalendarPosition
            /// <summary>
            /// This property gets or sets the value for 'CalendarPosition'.
            /// </summary>
            [Parameter]
            public string CalendarPosition
            {
                get { return calendarPosition; }
                set { calendarPosition = value; }
            }
            #endregion
            
            #region CalendarStyle
            /// <summary>
            /// This property gets or sets the value for 'CalendarStyle'.
            /// </summary>
            public string CalendarStyle
            {
                get { return calendarStyle; }
                set { calendarStyle = value; }
            }
            #endregion
            
            #region CalendarTop
            /// <summary>
            /// This property gets or sets the value for 'CalendarTop'.
            /// </summary>
            [Parameter]
            public double CalendarTop
            {
                get { return calendarTop; }
                set { calendarTop = value; }
            }
            #endregion
            
            #region CalendarTopStyle
            /// <summary>
            /// This read only property returns the value of CalendarTop + Unit
            /// </summary>
            public string CalendarTopStyle
            {
                
                get
                {
                    // initial value
                    string calendarTopStyle =  CalendarTop + HeightUnit;
                    
                    // return value
                    return calendarTopStyle;
                }
            }
            #endregion
            
            #region Caption
            /// <summary>
            /// This property gets or sets the value for 'Caption'.
            /// </summary>
            [Parameter]
            public string Caption
            {
                get { return caption; }
                set { caption = value; }
            }
            #endregion
            
            #region CellWidth
            /// <summary>
            /// This property gets or sets the value for 'CellWidth'.
            /// </summary>
            [Parameter]
            public double CellWidth
            {
                get { return cellWidth; }
                set { cellWidth = value; }
            }
            #endregion
            
            #region CellWidth2Style
            /// <summary>
            /// This property gets or sets the value for 'CellWidth2Style'.
            /// </summary>
            public string CellWidth2Style
            {
                get { return cellWidth2Style; }
                set { cellWidth2Style = value; }
            }
            #endregion
            
            #region ClassName
            /// <summary>
            /// This property gets or sets the value for 'ClassName'.
            /// </summary>
            [Parameter]
            public string ClassName
            {
                get { return className; }
                set { className = value; }
            }
            #endregion
            
            #region Column1Width
            /// <summary>
            /// This property gets or sets the value for 'Column1Width'.
            /// </summary>
            [Parameter]
            public double Column1Width
            {
                get { return column1Width; }
                set { column1Width = value; }
            }
            #endregion
            
            #region Column2Width
            /// <summary>
            /// This property gets or sets the value for 'Column2Width'.
            /// </summary>
            [Parameter]
            public double Column2Width
            {
                get { return column2Width; }
                set { column2Width = value; }
            }
            #endregion
            
            #region ColumnStyle
            /// <summary>
            /// This property gets or sets the value for 'ColumnStyle'.
            /// </summary>
            public string ColumnStyle
            {
                get { return columnStyle; }
                set { columnStyle = value; }
            }
            #endregion
           
            #region ColumnWidth2
            /// <summary>
            /// This read only property returns the value of ColumnWidth2 from the object Width.
            /// </summary>
            public double ColumnWidth2
            {  
                get
                {
                    // initial value
                    double columnWidth = Width / 7 - 4.2;
                    
                    // return value
                    return columnWidth;
                }
            }
            #endregion

            #region ColumnWidth2Style
            /// <summary>
            /// This read only property returns the value of ColumnWidthStyle from the object ColumnWidth.
            /// </summary>
            public string ColumnWidth2Style
            {
                
                get
                {
                    // initial value (testing hard code value, because calculated value wasin't working
                    string columnWidthStyle = ColumnWidth2 + Unit;
                    
                    // return value
                    return columnWidthStyle;
                }
            }
            #endregion
            
            #region ContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'ContainerStyle'.
            /// </summary>
            public string ContainerStyle
            {
                get { return containerStyle; }
                set { containerStyle = value; }
            }
            #endregion
            
            #region ControlHeight
            /// <summary>
            /// This property gets or sets the value for 'ControlHeight'.
            /// </summary>
            [Parameter]
            public double ControlHeight
            {
                get {  return controlHeight; }
                set { controlHeight = value; }
            }
            #endregion
            
            #region ControlHeightStyle
            /// <summary>
            /// This read only property returns the value of ControlHeightStyle from the object ContainerHeight.
            /// </summary>
            public string ControlHeightStyle
            {
                
                get
                {
                    // initial value
                    string controlHeightStyle = ControlHeight + HeightUnit;
                    
                    // return value
                    return controlHeightStyle;
                }
            }
            #endregion
            
            #region ControlWidth
            /// <summary>
            /// This property gets or sets the value for 'ControlWidth'.
            /// </summary>
            [Parameter]
            public double ControlWidth
            {
                get { return controlWidth; }
                set { controlWidth = value; }
            }
            #endregion
            
            #region ControlWidthStyle
            /// <summary>
            /// This read only property returns the value of ControlWidthStyle from the object ContainerWidth.
            /// </summary>
            public string ControlWidthStyle
            {
                
                get
                {
                    // initial value
                    string controlWidthStyle = ControlWidth + Unit;
                    
                    // return value
                    return controlWidthStyle;
                }
            }
            #endregion
            
            #region Dates
            /// <summary>
            /// This property gets or sets the value for 'Dates'.
            /// </summary>
            public List<DayObject> Dates
            {
                get { return dates; }
                set { dates = value; }
            }
            #endregion
            
            #region DateTitle
            /// <summary>
            /// This property gets or sets the value for 'DateTitle'.
            /// </summary>
            public string DateTitle
            {
                get { return dateTitle; }
                set { dateTitle = value; }
            }
            #endregion
            
            #region DateTitleLeft
            /// <summary>
            /// This property gets or sets the value for 'DateTitleLeft'.
            /// </summary>
            [Parameter]
            public double DateTitleLeft
            {
                get { return dateTitleLeft; }
                set { dateTitleLeft = value; }
            }
            #endregion
            
            #region DateTitleLeftStyle
            /// <summary>
            /// This read only property returns the value of DateTitleLeft + Unit
            /// </summary>
            public string DateTitleLeftStyle
            {

                get
                {
                    // initial value
                    string dateTitleLeftStyle = DateTitleLeft + Unit;

                    // return value
                    return dateTitleLeftStyle;
                }
            }
            #endregion

            #region DateTitlePosition
            /// <summary>
            /// This property gets or sets the value for 'DateTitlePosition'.
            /// </summary>
            [Parameter]
            public string DateTitlePosition
            {
                get { return dateTitlePosition; }
                set { dateTitlePosition = value; }
            }
            #endregion
            
            #region DateTitleTop
            /// <summary>
            /// This property gets or sets the value for 'DateTitleTop'.
            /// </summary>
            [Parameter]
            public double DateTitleTop
            {
                get { return dateTitleTop; }
                set { dateTitleTop = value; }
            }
            #endregion
            
            #region DateTitleTopStyle
            /// <summary>
            /// This read only property returns the value of DateTitleTop + HeightUnit
            /// </summary>
            public string DateTitleTopStyle
            {

                get
                {
                    // initial value
                    string dateTitleTopStyle = DateTitleTop + HeightUnit;

                    // return value
                    return dateTitleTopStyle;
                }
            }
            #endregion

            #region DayButtonContainerLeft
            /// <summary>
            /// This property gets or sets the value for 'DayButtonContainerLeft'.
            /// </summary>
            [Parameter]
            public double DayButtonContainerLeft
            {
                get { return dayButtonContainerLeft; }
                set { dayButtonContainerLeft = value; }
            }
            #endregion
            
            #region DayButtonContainerLeftStyle
            /// <summary>
            /// This read only property returns the value of DayButtonContainerLeft + Unit
            /// </summary>
            public string DayButtonContainerLeftStyle
            {

                get
                {
                    // initial value
                    string dayButtonContainerLeftStyle = DayButtonContainerLeft + Unit;
                    
                    // return value
                    return dayButtonContainerLeftStyle;
                }
            }
            #endregion

            #region DayButtonContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'DayButtonContainerStyle'.
            /// </summary>
            public string DayButtonContainerStyle
            {
                get { return dayButtonContainerStyle; }
                set { dayButtonContainerStyle = value; }
            }
            #endregion
            
            #region DayButtonContainerTop
            /// <summary>
            /// This property gets or sets the value for 'DayButtonContainerTop'.
            /// </summary>
            [Parameter]
            public double DayButtonContainerTop
            {
                get { return dayButtonContainerTop; }
                set { dayButtonContainerTop = value; }
            }
            #endregion
            
            #region DayButtonContainerTopStyle
            /// <summary>
            /// This read only property returns the value of DayButtonContainerTop + HeightUnit
            /// </summary>
            public string DayButtonContainerTopStyle
            {

                get
                {
                    // initial value
                    string dayButtonContainerTopStyle = DayButtonContainerTop + HeightUnit;
                    
                    // return value
                    return dayButtonContainerTopStyle;
                }
            }
            #endregion

            #region DayButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'DayButtonStyle'.
            /// </summary>
            public string DayButtonStyle
            {
                get { return dayButtonStyle; }
                set { dayButtonStyle = value; }
            }
            #endregion
            
            #region DayButtonStyle2
            /// <summary>
            /// This property gets or sets the value for 'DayButtonStyle2'.
            /// </summary>
            public string DayButtonStyle2
            {
                get { return dayButtonStyle2; }
                set { dayButtonStyle2 = value; }
            }
            #endregion
            
            #region DayButtonStyle3
            /// <summary>
            /// This property gets or sets the value for 'DayButtonStyle3'.
            /// </summary>
            public string DayButtonStyle3
            {
                get { return dayButtonStyle3; }
                set { dayButtonStyle3 = value; }
            }
            #endregion
            
            #region DayButtonWidth
            /// <summary>
            /// This property gets or sets the value for 'DayButtonWidth'.
            /// </summary>
            [Parameter]
            public double DayButtonWidth
            {
                get { return dayButtonWidth; }
                set { dayButtonWidth = value; }
            }
            #endregion
            
            #region DayButtonWidthStyle
            /// <summary>
            /// This read only property returns the value of DayButtonWidth + Unit
            /// </summary>
            public string DayButtonWidthStyle
            {

                get
                {
                    // initial value
                    string dayButtonWidthStyle = DayButtonWidth + Unit;
                    
                    // return value
                    return dayButtonWidthStyle;
                }
            }
            #endregion

            #region DayRowColor
            /// <summary>
            /// This property gets or sets the value for 'DayRowColor'.
            /// </summary>
            [Parameter]
            public Color DayRowColor
            {
                get { return dayRowColor; }
                set { dayRowColor = value; }
            }
            #endregion
            
            #region DayRowColorName
            /// <summary>
            /// This read only property returns the value of DayRowColorName from the object DayRowColor.
            /// </summary>
            public string DayRowColorName
            {
                
                get
                {
                    // initial value
                    string dayRowColorName = DayRowColor.Name;
                    
                    // return value
                    return dayRowColorName;
                }
            }
            #endregion
            
            #region DayRowHeight
            /// <summary>
            /// This property gets or sets the value for 'DayRowHeight'.
            /// </summary>
            public double DayRowHeight
            {
                get
                {
                    // Set to 20
                    dayRowHeight = 20;

                    return dayRowHeight;
                }
            }
            #endregion
            
            #region DayRowHeightStyle
            /// <summary>
            /// This read only property returns the value of DayRowHeightStyle from the object DayRowHeight.
            /// </summary>
            public string DayRowHeightStyle
            {
                
                get
                {
                    // initial value
                    string dayRowHeightStyle = DayRowHeight + HeightUnit;
                    
                    // return value
                    return dayRowHeightStyle;
                }
            }
            #endregion
            
            #region DayRowLeft
            /// <summary>
            /// This property gets or sets the value for 'DayRowLeft'.
            /// This is the property for the Day of the Week Header, Left.
            /// </summary>
            [Parameter]
            public double DayRowLeft
            {
                get { return dayRowLeft; }
                set { dayRowLeft = value; }
            }
            #endregion
            
            #region DayRowLeftStyle
            /// <summary>
            /// This read only property returns the value of DayRowLeftStyle from the object DayRowLeft.
            /// </summary>
            public string DayRowLeftStyle
            {

                get
                {
                    // initial value
                    string dayRowLeftStyle = DayRowLeft + Unit;
                    
                    // return value
                    return dayRowLeftStyle;
                }
            }
            #endregion

            #region DayRowStyle
            /// <summary>
            /// This property gets or sets the value for 'DayRowStyle'.
            /// </summary>
            public string DayRowStyle
            {
                get { return dayRowStyle; }
                set { dayRowStyle = value; }
            }
            #endregion

            #region DayRowTextColor
            /// <summary>
            /// This property gets or sets the value for 'DayRowTextColor'.
            /// </summary>
            [Parameter]
            public Color DayRowTextColor
            {
                get { return dayRowTextColor; }
                set { dayRowTextColor = value; }
            }
            #endregion
            
            #region DayRowTextColorName
            /// <summary>
            /// This read only property returns the value of DayRowTextColorName from the object DayRowTextColor.
            /// </summary>
            public string DayRowTextColorName
            {
                
                get
                {
                    // initial value
                    string dayRowTextColorName = DayRowTextColor.Name;
                    
                    // return value
                    return dayRowTextColorName;
                }
            }
            #endregion

            #region DayRowTextLeft
            /// <summary>
            /// This property gets or sets the value for 'DayRowTextLeft'.
            /// </summary>
            
            [Parameter]
            public double DayRowTextLeft
            {
                get { return dayRowTextLeft; }
                set { dayRowTextLeft = value; }
            }
            #endregion
            
            #region DayRowTextLeftStyle
            /// <summary>
            /// This read only property returns the value of DayRowTextLeft + Unit
            /// </summary>
            public string DayRowTextLeftStyle
            {

                get
                {
                    // initial value
                    string dayRowTextLeftStyle = DayRowTextLeft + Unit;                    
                    // return value
                    return dayRowTextLeftStyle;
                }
            }
            #endregion

            #region DayRowTextStyle
            /// <summary>
            /// This property gets or sets the value for 'DayRowTextStyle'.
            /// </summary>
            public string DayRowTextStyle
            {
                get { return dayRowTextStyle; }
                set { dayRowTextStyle = value; }
            }
            #endregion

            #region DayRowTextTop
            /// <summary>
            /// This property gets or sets the value for 'DayRowTextTop'.
            /// </summary>
            [Parameter]
            public double DayRowTextTop
            {
                get { return dayRowTextTop; }
                set { dayRowTextTop = value; }
            }
            #endregion
            
            #region DayRowTextTopStyle
            /// <summary>
            /// This read only property returns the value of DayRowTextTop + HeightUnit
            /// </summary>
            public string DayRowTextTopStyle
            {

                get
                {
                    // initial value
                    string dayRowTextTopStyle = DayRowTextTop + HeightUnit;
                    
                    // return value
                    return dayRowTextTopStyle;
                }
            }
            #endregion

            #region DayRowTop
            /// <summary>
            /// This property gets or sets the value for 'DayRowTop'.
            /// </summary>
            [Parameter]
            public double DayRowTop
            {
                get { return dayRowTop; }
                set { dayRowTop = value; }
            }
            #endregion
            
            #region DayRowTopStyle
            /// <summary>
            /// This read only property returns the value of DayRowTop + HeightUnit
            /// </summary>
            public string DayRowTopStyle
            {

                get
                {
                    // initial value
                    string dayRowTopStyle = DayRowTop + HeightUnit;
                    
                    // return value
                    return dayRowTopStyle;
                }
            }
            #endregion

            #region DayRowWidth
            /// <summary>
            /// This property gets or sets the value for 'DayRowWidth'.
            /// </summary>
            [Parameter]
            public double DayRowWidth
            {
                get { return dayRowWidth; }
                set { dayRowWidth = value; }
            }
            #endregion
            
            #region DayRowWidthStyle
            /// <summary>
            /// This read only property returns the value of DayRowWidth + Unit
            /// </summary>
            public string DayRowWidthStyle
            {

                get
                {
                    // initial value
                    string dayRowWidthStyle = DayRowWidth + Unit;
                    
                    // return value
                    return dayRowWidthStyle;
                }
            }
            #endregion

            #region DecadeButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'DecadeButtonStyle'.
            /// </summary>
            public string DecadeButtonStyle
            {
                get { return decadeButtonStyle; }
                set { decadeButtonStyle = value; }
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
            
            #region DividerStyle
            /// <summary>
            /// This property gets or sets the value for 'DividerStyle'.
            /// </summary>
            public string DividerStyle
            {
                get { return dividerStyle; }
                set { dividerStyle = value; }
            }
            #endregion
            
            #region Expanded
            /// <summary>
            /// This property gets or sets the value for 'Expanded'.
            /// </summary>
            public bool Expanded
            {
                get { return expanded; }
                set
                {
                    // Set the value
                    expanded = value;
                        
                    // The button image changes on Expanded and Theme.
                    SetupComponent();
                }
            }
            #endregion
            
            #region FontName
            /// <summary>
            /// This property gets or sets the value for 'FontName'.
            /// </summary>
            [Parameter]
            public string FontName
            {
                get { return fontName; }
                set 
                {
                    // Set the value
                    fontName = value;

                    // Set Both
                    LabelFontName = value;
                    TextBoxFontName = value;
                }
            }
            #endregion
            
            #region FontSize
            /// <summary>
            /// This property gets or sets the value for 'FontSize'.
            /// </summary>
            [Parameter]
            public double FontSize
            {
                get { return fontSize; }
                set 
                {
                    // set the value
                    fontSize = value;

                    // Set Label & TextBox Font Sizes
                    LabelFontSize = value;
                    TextBoxFontSize = value;
                }
            }
            #endregion

            #region HasButton
            /// <summary>
            /// This property returns true if this object has a 'Button'.
            /// </summary>
            public bool HasButton
            {
                get
                {
                    // initial value
                    bool hasButton = (this.Button != null);
                    
                    // return value
                    return hasButton;
                }
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

            #region HasSelectdDecade
            /// <summary>
            /// This property returns true if this object has a 'SelectdDecade'.
            /// </summary>
            public bool HasSelectedDecade
            {
                get
                {
                    // initial value
                    bool hasSelectedDecade = (this.SelectedDecade != null);
                    
                    // return value
                    return hasSelectedDecade;
                }
            }
            #endregion
            
            #region HasTextBox
            /// <summary>
            /// This property returns true if this object has a 'TextBox'.
            /// </summary>
            public bool HasTextBox
            {
                get
                {
                    // initial value
                    bool hasTextBox = (this.TextBox != null);
                    
                    // return value
                    return hasTextBox;
                }
            }
            #endregion
            
            #region HasWeeks
            /// <summary>
            /// This property returns true if this object has a 'Weeks'.
            /// </summary>
            public bool HasWeeks
            {
                get
                {
                    // initial value
                    bool hasWeeks = (this.Weeks != null);
                    
                    // return value
                    return hasWeeks;
                }
            }
            #endregion
            
            #region DayRowColumnStyle
            /// <summary>
            /// This property gets or sets the value for 'DayRowColumnStyle'.
            /// </summary>
            public string DayRowColumnStyle
            {
                get { return dayRowColumnStyle; }
                set { dayRowColumnStyle = value; }
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
                set { height = value; }
            }
            #endregion
                
            #region HeightStyle
            /// <summary>
            /// This property gets or sets the value for 'HeightStyle'.
            /// </summary>
            public string HeightStyle
            {
                get
                {
                    if (TextHelper.Exists(heightUnit))
                    {
                        // initial value
                        heightStyle = height + HeightUnit;
                    }
                    else
                    {
                        // Default to pixel
                        heightStyle = height + "px";
                    }

                    // Set the return value
                    return heightStyle;
                }
            }
            #endregion
                
            #region HeightUnit
            /// <summary>
            /// This property gets or sets the value for 'HeightUnit'.
            /// </summary>
            [Parameter]
            public string HeightUnit
            {
                get { return heightUnit; }
                set { heightUnit = value; }
            }
            #endregion
            
            #region LabelClassName
            /// <summary>
            /// This property gets or sets the value for 'LabelClassName'.
            /// </summary>
            [Parameter]
            public string LabelClassName
            {
                get { return labelClassName; }
                set { labelClassName = value; }
            }
            #endregion
            
            #region LabelColor
            /// <summary>
            /// This property gets or sets the value for 'LabelColor'.
            /// </summary>
            [Parameter]
            public Color LabelColor
            {
                get { return labelColor; }
                set { labelColor = value; }
            }
            #endregion
            
            #region LabelFontName
            /// <summary>
            /// This property gets or sets the value for 'LabelFontName'.
            /// </summary>
            [Parameter]
            public string LabelFontName
            {
                get { return labelFontName; }
                set { labelFontName = value; }
            }
            #endregion
            
            #region LabelFontSize
            /// <summary>
            /// This property gets or sets the value for 'LabelFontSize'.
            /// </summary>
            [Parameter]
            public double LabelFontSize
            {
                get { return labelFontSize; }
                set { labelFontSize = value; }
            }
            #endregion
            
            #region LabelLeft
            /// <summary>
            /// This property gets or sets the value for 'LabelLeft'.
            /// </summary>
            [Parameter]
            public double LabelLeft
            {
                get { return labelLeft; }
                set { labelLeft = value; }
            }
            #endregion
            
            #region Left
            /// <summary>
            /// This property gets or sets the value for 'Left'.
            /// </summary>
            [Parameter]
            public double Left
            {
                get { return left; }
                set { left = value; }
            }
            #endregion
            
            #region LeftStyle
            /// <summary>
            /// This read only property returns the value of LeftStyle from the object Left.
            /// </summary>
            public string LeftStyle
            {
                
                get
                {
                    // initial value
                    string leftStyle = Left + Unit;
                    
                    // return value
                    return leftStyle;
                }
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
            
            #region NavButtonCellStyle
            /// <summary>
            /// This property gets or sets the value for 'NavButtonCellStyle'.
            /// </summary>
            public string NavButtonCellStyle
            {
                get { return navButtonCellStyle; }
                set { navButtonCellStyle = value; }
            }
            #endregion
            
            #region NavButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'NavButtonStyle'.
            /// </summary>
            public string NavButtonStyle
            {
                get { return navButtonStyle; }
                set { navButtonStyle = value; }
            }
            #endregion
            
            #region NextMonthButtonLeft
            /// <summary>
            /// This property gets or sets the value for 'NextMonthButtonLeft'.
            /// </summary>
            [Parameter]
            public double NextMonthButtonLeft
            {
                get { return nextMonthButtonLeft; }
                set { nextMonthButtonLeft = value; }
            }
            #endregion
            
            #region NextMonthButtonUrl
            /// <summary>
            /// This property gets or sets the value for 'NextMonthButtonUrl'.
            /// </summary>
            public string NextMonthButtonUrl
            {
                get { return nextMonthButtonUrl; }
                set { nextMonthButtonUrl = value; }
            }
            #endregion
            
            #region NextYearButtonLeft
            /// <summary>
            /// This property gets or sets the value for 'NextYearButtonLeft'.
            /// </summary>
            [Parameter]
            public double NextYearButtonLeft
            {
                get { return nextYearButtonLeft; }
                set { nextYearButtonLeft = value; }
            }
            #endregion
            
            #region NextYearButtonUrl
            /// <summary>
            /// This property gets or sets the value for 'NextYearButtonUrl'.
            /// </summary>
            public string NextYearButtonUrl
            {
                get { return nextYearButtonUrl; }
                set { nextYearButtonUrl = value; }
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
            
            #region PreviousMonthButtonLeft
            /// <summary>
            /// This property gets or sets the value for 'PreviousMonthButtonLeft'.
            /// </summary>
            [Parameter]
            public double PreviousMonthButtonLeft
            {
                get { return previousMonthButtonLeft; }
                set { previousMonthButtonLeft = value; }
            }
            #endregion
            
            #region PreviousYearButtonLeft
            /// <summary>
            /// This property gets or sets the value for 'PreviousYearButtonLeft'.
            /// </summary>
            [Parameter]
            public double PreviousYearButtonLeft
            {
                get { return previousYearButtonLeft; }
                set { previousYearButtonLeft = value; }
            }
            #endregion
            
            #region PrevMonthButtonUrl
            /// <summary>
            /// This property gets or sets the value for 'PrevMonthButtonUrl'.
            /// </summary>
            public string PrevMonthButtonUrl
            {
                get { return prevMonthButtonUrl; }
                set { prevMonthButtonUrl = value; }
            }
            #endregion
            
            #region PrevYearButtonUrl
            /// <summary>
            /// This property gets or sets the value for 'PrevYearButtonUrl'.
            /// </summary>
            public string PrevYearButtonUrl
            {
                get { return prevYearButtonUrl; }
                set { prevYearButtonUrl = value; }
            }
            #endregion
            
            #region RowHeight
            /// <summary>
            /// This property gets or sets the value for 'RowHeight'.
            /// </summary>
            [Parameter]
            public double RowHeight
            {
                get { return rowHeight; }
                set { rowHeight = value; }
            }
            #endregion
            
            #region RowHeightStyle
            /// <summary>
            /// This read only property returns the value of RowHeightStyle from the object RowHeight.
            /// </summary>
            public string RowHeightStyle
            {
                
                get
                {
                    // initial value
                    string rowHeightStyle = RowHeight + HeightUnit;
                    
                    // return value
                    return rowHeightStyle;
                }
            }
            #endregion

            #region RowLeft
            /// <summary>
            /// This property gets or sets the value for 'RowLeft'.
            /// </summary>
            [Parameter]
            public double RowLeft
            {
                get { return rowLeft; }
                set { rowLeft = value; }
            }
            #endregion
            
            #region RowLeftStyle
            /// <summary>
            /// This read only property returns the value of RowLeftStyle from the object RowLeft.
            /// This is the property for the date buttons.
            /// </summary>
            public string RowLeftStyle
            {

                get
                {
                    // initial value
                    string rowLeftStyle = RowLeft + Unit;
                    
                    // return value
                    return rowLeftStyle;
                }
            }
            #endregion

            #region RowStyle
            /// <summary>
            /// This property gets or sets the value for 'RowStyle'.
            /// </summary>
            public string RowStyle
            {
                get { return rowStyle; }
                set { rowStyle = value; }
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

            #region ScaleValue
            /// <summary>
            /// This read only property returns the value of Scale times .01
            /// </summary>
            public double ScaleValue
            {
                
                get
                {
                    // initial value
                    double scaleValue = Scale * .01;

                    // Round to 2 digits just in case
                    scaleValue = Math.Round(scaleValue, 2);
                    
                    // return value
                    return scaleValue;
                }
            }
            #endregion
            
            #region SelectedColor
            /// <summary>
            /// This property gets or sets the value for 'SelectedColor'.
            /// </summary>
            [Parameter]
            public Color SelectedColor
            {
                get { return selectedColor; }
                set { selectedColor = value; }
            }
            #endregion
            
            #region SelectedColorName
            /// <summary>
            /// This read only property returns the value of SelectedColorName from the object SelectedColor.
            /// </summary>
            public string SelectedColorName
            {
                
                get
                {
                    // initial value
                    string selectedColorName = SelectedColor.Name;
                    
                    // return value
                    return selectedColorName;
                }
            }
            #endregion
            
            #region SelectedDecade
            /// <summary>
            /// This property gets or sets the value for 'SelectedDecade'.
            /// </summary>
            public Decade SelectedDecade
            {
                get { return selectedDecade; }
                set { selectedDecade = value; }
            }
            #endregion
            
            #region SelectedDate
            /// <summary>
            /// This property gets or sets the value for 'SelectedDate'.
            /// </summary>
            public DateTime SelectedDate
            {
                get { return selectedDate; }
                set { selectedDate = value; }
            }
            #endregion
            
            #region TextBox
            /// <summary>
            /// This property gets or sets the value for 'TextBox'.
            /// </summary>
            public TextBoxComponent TextBox
            {
                get { return textBox; }
                set { textBox = value; }
            }
            #endregion
            
            #region TextBoxFontName
            /// <summary>
            /// This property gets or sets the value for 'TextBoxFontName'.
            /// </summary>
            [Parameter]
            public string TextBoxFontName
            {
                get { return textBoxFontName; }
                set { textBoxFontName = value; }
            }
            #endregion
            
            #region TextBoxFontSize
            /// <summary>
            /// This property gets or sets the value for 'TextBoxFontSize'.
            /// </summary>
            [Parameter]
            public double TextBoxFontSize
            {
                get { return textBoxFontSize; }
                set { textBoxFontSize = value; }
            }
            #endregion
            
            #region TextBoxHeight
            /// <summary>
            /// This property gets or sets the value for 'TextBoxHeight'.
            /// </summary>
            [Parameter]
            public double TextBoxHeight
            {
                get { return textBoxHeight; }
                set { textBoxHeight = value; }
            }
            #endregion
            
            #region TextBoxLeft
            /// <summary>
            /// This property gets or sets the value for 'TextBoxLeft'.
            /// </summary>
            [Parameter]
            public double TextBoxLeft
            {
                get { return textBoxLeft; }
                set { textBoxLeft = value; }
            }
            #endregion
            
            #region TextBoxTop
            /// <summary>
            /// This property gets or sets the value for 'TextBoxTop'.
            /// </summary>
            [Parameter]
            public double TextBoxTop
            {
                get { return textBoxTop; }
                set { textBoxTop = value; }
            }
            #endregion
            
            #region TextBoxWidth
            /// <summary>
            /// This property gets or sets the value for 'TextBoxWidth'.
            /// </summary>
            [Parameter]
            public double TextBoxWidth
            {
                get { return textBoxWidth; }
                set { textBoxWidth = value; }
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
                set { theme = value; }
            }
            #endregion

            #region Decade ThisDecade()
            /// <summary>
            /// returns . This Decade
            /// </summary>
            public static Decade ThisDecade
            {
                get
                {
                    // initial value
                    Decade decade = Decade.CreateDecades().LastOrDefault();

                    // return value
                    return decade;
                }
            }
            #endregion
            
            #region ThisMonth
            /// <summary>
            /// This property gets or sets the value for 'ThisMonth'.
            /// </summary>
            public DateTime ThisMonth
            {
                get { return thisMonth; }
                set { thisMonth = value; }
            }
            #endregion
            
            #region Top
            /// <summary>
            /// This property gets or sets the value for 'Top'.
            /// </summary>
            [Parameter]
            public double Top
            {
                get { return top; }
                set { top = value; }
            }
            #endregion
            
            #region TopStyle
            /// <summary>
            /// This read only property returns the value of TopStyle from the object Top.
            /// </summary>
            public string TopStyle
            {
                
                get
                {
                    // initial value
                    string topStyle = Top + HeightUnit;
                    
                    // return value
                    return topStyle;
                }
            }
            #endregion
            
            #region Unit
            /// <summary>
            /// This property gets or sets the value for 'Unit'.
            /// </summary>
            [Parameter]
            public string Unit
            {
                get { return unit; }
                set { unit = value; }
            }
            #endregion
            
            #region Weeks
            /// <summary>
            /// This property gets or sets the value for 'Weeks'.
            /// </summary>
            public List<CalendarRow> Weeks
            {
                get { return weeks; }
                set { weeks = value; }
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
                set { width = value; }
            }
            #endregion

            #region WidthStyle
            /// <summary>
            /// This property gets or sets the value for 'WidthStyle'.
            /// </summary>
            public string WidthStyle
            {
                get
                {
                    // set the value
                    string widthStyle = width + unit;
                        
                    // return value
                    return widthStyle;
                }
            }
            #endregion
            
            #region YearButtonSelectedStyle
            /// <summary>
            /// This property gets or sets the value for 'YearButtonSelectedStyle'.
            /// </summary>
            public string YearButtonSelectedStyle
            {
                get { return yearButtonSelectedStyle; }
                set { yearButtonSelectedStyle = value; }
            }
            #endregion
            
            #region YearButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'YearButtonStyle'.
            /// </summary>
            public string YearButtonStyle
            {
                get { return yearButtonStyle; }
                set { yearButtonStyle = value; }
            }
            #endregion
            
            #region YearButtonTextColor
            /// <summary>
            /// This property gets or sets the value for 'YearButtonTextColor'.
            /// </summary>
            [Parameter]
            public Color YearButtonTextColor
            {
                get { return yearButtonTextColor; }
                set { yearButtonTextColor = value; }
            }
            #endregion
            
            #region YearButtonTextColorName
            /// <summary>
            /// This read only property returns the value of Name from the object YearButtonTextColor.
            /// </summary>
            public string YearButtonTextColorName
            {
                
                get
                {
                    // initial value
                    string yearButtonTextColorName = YearButtonTextColor.Name;
                    
                    // return value
                    return yearButtonTextColorName;
                }
            }
            #endregion
            
            #region YearButtonTextColorSelected
            /// <summary>
            /// This property gets or sets the value for 'YearButtonTextColorSelected'.
            /// </summary>
            [Parameter]
            public Color YearButtonTextColorSelected
            {
                get { return yearButtonTextColorSelected; }
                set { yearButtonTextColorSelected = value; }
            }
            #endregion
            
            #region YearButtonTextColorSelectedName
            /// <summary>
            /// This read only property returns the value of Name from the object YearButtonTextColorSelected.
            /// </summary>
            public string YearButtonTextColorSelectedName
            {
                
                get
                {
                    // initial value
                    string yearButtonTextColorSelectedName = YearButtonTextColorSelected.Name;
                    
                    // return value
                    return yearButtonTextColorSelectedName;
                }
            }
            #endregion
            
            #region YearButtonWidth
            /// <summary>
            /// This property gets or sets the value for 'YearButtonWidth'.
            /// </summary>
            public double YearButtonWidth
            {
                get { return yearButtonWidth; }
                set { yearButtonWidth = value; }
            }
            #endregion
            
            #region YearButtonWidthStyle
            /// <summary>
            /// This read only property returns the value of YearButtonWidthStyle from the object YearButtonWidth.
            /// </summary>
            public string YearButtonWidthStyle
            {
                
                get
                {
                    // initial value
                    string yearButtonWidthStyle = YearButtonWidth + Unit;
                    
                    // return value
                    return yearButtonWidthStyle;
                }
            }
            #endregion
            
            #region YearSelectorAlignment
            /// <summary>
            /// This property gets or sets the value for 'YearSelectorAlignment'.
            /// </summary>
            [Parameter]
            public YearSelectorAlignmentEnum YearSelectorAlignment
            {
                get { return yearSelectorAlignment; }
                set { yearSelectorAlignment = value; }
            }
            #endregion
            
            #region YearSelectorButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'YearSelectorButtonStyle'.
            /// </summary>
            public string YearSelectorButtonStyle
            {
                get { return yearSelectorButtonStyle; }
                set { yearSelectorButtonStyle = value; }
            }
            #endregion
            
            #region YearSelectorContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'YearSelectorContainerStyle'.
            /// </summary>
            public string YearSelectorContainerStyle
            {
                get { return yearSelectorContainerStyle; }
                set { yearSelectorContainerStyle = value; }
            }
            #endregion
            
            #region YearSelectorDecadesStyle
            /// <summary>
            /// This property gets or sets the value for 'YearSelectorDecadesStyle'.
            /// </summary>
            public string YearSelectorDecadesStyle
            {
                get { return yearSelectorDecadesStyle; }
                set { yearSelectorDecadesStyle = value; }
            }
            #endregion
            
            #region YearSelectorDisplay
            /// <summary>
            /// This property gets or sets the value for 'YearSelectorDisplay'.
            /// </summary>
            public string YearSelectorDisplay
            {
                get { return yearSelectorDisplay; }
                set { yearSelectorDisplay = value; }
            }
            #endregion
            
            #region YearSelectorLeft
            /// <summary>
            /// This property gets or sets the value for 'YearSelectorLeft'.
            /// </summary>
            [Parameter]
            public double YearSelectorLeft
            {
                get { return yearSelectorLeft; }
                set { yearSelectorLeft = value; }
            }
            #endregion
            
            #region YearSelectorLeftStyle
            /// <summary>
            /// This read only property returns the value of YearSelectorLeftStyle from the object YearSelectorLeft.
            /// </summary>
            public string YearSelectorLeftStyle
            {
                
                get
                {
                    // initial value
                    string yearSelectorLeftStyle = YearSelectorLeft + Unit;
                    
                    // return value
                    return yearSelectorLeftStyle;
                }
            }
            #endregion
            
            #region YearSelectorStyle
            /// <summary>
            /// This property gets or sets the value for 'YearSelectorStyle'.
            /// </summary>
            public string YearSelectorStyle
            {
                get { return yearSelectorStyle; }
                set { yearSelectorStyle = value; }
            }
            #endregion
            
            #region YearSelectorTop
            /// <summary>
            /// This property gets or sets the value for 'YearSelectorTop'.
            /// </summary>
            [Parameter]
            public double YearSelectorTop
            {
                get { return yearSelectorTop; }
                set { yearSelectorTop = value; }
            }
            #endregion
            
            #region YearSelectorTopStyle
            /// <summary>
            /// This read only property returns the value of YearSelectorTopStyle from the object YearSelectorTop.
            /// </summary>
            public string YearSelectorTopStyle
            {
                
                get
                {
                    // initial value
                    string yearSelectorTopStyle = YearSelectorTop + HeightUnit;
                    
                    // return value
                    return yearSelectorTopStyle;
                }
            }
            #endregion
            
            #region YearSelectorVisible
            /// <summary>
            /// This property gets or sets the value for 'YearSelectorVisible'.
            /// </summary>
            public bool YearSelectorVisible
            {
                get { return yearSelectorVisible; }
                set
                {
                    // set the value
                    yearSelectorVisible = value;
                    
                    // Show or hide the YearSelector
                    SetupComponent();
                }
            }
            #endregion
            
            #region YearSelectorYearsStyle
            /// <summary>
            /// This property gets or sets the value for 'YearSelectorYearsStyle'.
            /// </summary>
            public string YearSelectorYearsStyle
            {
                get { return yearSelectorYearsStyle; }
                set { yearSelectorYearsStyle = value; }
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
            
            #region ZIndexPlus1
            /// <summary>
            /// This read only property returns the value of ZIndex Plus1 from the property ZIndex.
            /// </summary>
            public int ZIndexPlus1
            {
                
                get
                {
                    // initial value
                    int zIndexPlus1 = ZIndex + 1;
                    
                    // return value
                    return zIndexPlus1;
                }
            }
            #endregion

            #region ZIndexPlus20
            /// <summary>
            /// This read only property returns the value of ZIndexPlus Plus 20.
            /// </summary>
            public int ZIndexPlus20
            {
                    
                get
                {
                    // initial value
                    int zIndexPlus = ZIndex + 20;
                        
                    // return value
                    return zIndexPlus;
                }
            }
            #endregion

            #region ZIndexPlus30
            /// <summary>
            /// This read only property returns the value of ZIndexPlus Plus 30.
            /// </summary>
            public int ZIndexPlus30
            {
                    
                get
                {
                    // initial value
                    int zIndexPlus = ZIndex + 30;
                        
                    // return value
                    return zIndexPlus;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
