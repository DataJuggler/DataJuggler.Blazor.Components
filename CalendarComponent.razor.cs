﻿

#region using statements

using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Drawing;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class CalendarComponent
    /// <summary>
    /// This class is the code behind for the CalendarComponent
    /// </summary>
    public partial class CalendarComponent : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private List<IBlazorComponent> children;
        private string name;
        private IBlazorComponentParent parent;
        private bool expanded;
        private List<DayObject> dates;
        private string calendarStyle;
        private string caption;
        private double height;
        private string heightStyle;
        private string heightUnit;
        private string buttonStyle;
        private string buttonUrl;
        private double width;
        private string unit;
        private string containerStyle;
        private double buttonLeft;
        private double buttonTop;
        private double calendarLeft;
        private double calendarTop;
        private double textBoxWidth;
        private double column1Width;
        private double column2Width;
        private double buttonWidth;
        private double buttonHeight;
        private double controlWidth;
        private double controlHeight;
        private string className;
        private string position;
        private double left;
        private double top;
        private string display;
        private string columnStyle;
        private string rowStyle;
        private Color dayRowColor;
        private Color dayRowTextColor;
        private string dayRowStyle;
        private string dayButtonStyle;
        private string dayButtonStyle2;
        private string dayButtonStyle3;
        private double dayRowHeight;
        private DateTime selectedDate;
        private ValidationComponent textBox;
        private string prevYearButtonUrl;
        private string nextYearButtonUrl;
        private string prevMonthButtonUrl;
        private string nextMonthButtonUrl;
        private string dateTitle;
        private string navButtonStyle;
        private string bottomRowStyle;
        private DateTime thisMonth;
        private string labelClassName;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CalendarComponent' object.
        /// </summary>
        public CalendarComponent()
        {
            // Create a new collection of 'IBlazorComponent' objects.
            Children = new List<IBlazorComponent>();

            // Get the current date
            DateTime now = DateTime.Now;

            // Create the dates
            Dates = CreateDates(now.Year, now.Month);

            // Default
            Caption = "Date:";

            // Set the Unit
            Unit = "px";
            HeightUnit = "px";
            Height = 146;
            Width = 252;
            ButtonHeight = 24;
            ButtonWidth = 24;
            CalendarLeft = 256;
            Column1Width = 100;
            Column2Width = 240;
            TextBoxWidth = 236;
            ControlWidth = 640;
            ControlHeight = 144;
            Position = "relative";
            DayRowColor = Color.DodgerBlue;
            DayRowTextColor = Color.GhostWhite;

            // Buttons
            NextYearButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/VCRLastSmall.png";
            NextMonthButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/VCRNextSmall.png";
            PrevYearButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/VCRFirstSmall.png";
            PrevMonthButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/VCRPrevSmall.png";
            
            // Setup the Component
            SetupComponent();
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
                    Dates = CreateDates(ThisMonth.Year - 1, ThisMonth.Month);
                }
                else if (buttonNumber == 3)
                {
                    // Create a tempDate one month prior
                    DateTime tempDate = ThisMonth.AddMonths(-1);

                    // Previous Month
                    Dates = CreateDates(tempDate.Year, tempDate.Month);
                }
                else if (buttonNumber == 4)
                {
                    // Next Month

                    // Create a tempDate one month forward
                    DateTime tempDate = ThisMonth.AddMonths(1);

                    // Recreate the Date
                    Dates = CreateDates(tempDate.Year, tempDate.Month);
                }
                else if (buttonNumber == 5)
                {
                    // Next Year
                    Dates = CreateDates(ThisMonth.Year + 1, ThisMonth.Month);
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
            public List<DayObject> CreateDates(int year, int month)
            {
                // initial value
                List<DayObject> dates =  new List<DayObject>();

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

                // return value
                return dates;
            }
            #endregion
            
            #region DateSelected(DayObject date)
            /// <summary>
            /// Date Selected
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
            
            #region FindChildByName(string name)
            /// <summary>
            /// method Find Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // return the child by name
                return ComponentHelper.FindChildByName(Children, name);
            }
            #endregion

            #region GetNextMonthDays()
            /// <summary>
            /// returns the Next Month Days
            /// </summary>
            public int GetNextMonthDays(DayOfWeek dayOfWeek)
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
            public int GetPrevMonthDays(DayOfWeek dayOfWeek)
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
                if (component is ValidationComponent)
                {
                    // Store
                    TextBox = component as ValidationComponent;                    
                }
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
                }
            }
            #endregion
            
            #region SetupComponent()
            /// <summary>
            /// Setup Component
            /// </summary>
            public void SetupComponent()
            {
                if (Expanded)
                {
                    ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/TriangleButtonOpen.png";

                    // Hide
                    Display = "inline-block";
                }
                else
                {
                    ButtonUrl = "_content/DataJuggler.Blazor.Components/Images/Buttons/TriangleButtonClosed.png";

                    // Hide
                    Display = "none";
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
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
            
            #region Children
            /// <summary>
            /// This property gets or sets the value for 'Children'.
            /// </summary>
            public List<IBlazorComponent> Children
            {
                get { return children; }
                set { children = value; }
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
                    height = value;
                        
                    // Set the height headerStyle string
                    HeightStyle = height + HeightUnit;
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
            public string Name
            {
                get { return name; }
                set { name = value; }
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
            /// This read only property returns the value of RowHeight
            /// </summary>
            public double RowHeight
            {
                
                get
                {
                    // initial value
                    double rowHeight = 16;
                    
                    // return value
                    return rowHeight;;
                }
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
            public ValidationComponent TextBox
            {
                get { return textBox; }
                set { textBox = value; }
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
            
        #endregion
        
    }
    #endregion

}
