News

10.2.2024: Version 8.11.7 was published and the ComboBox when in CheckedListMode now displays
the selections. 

# 200,000 Installs
10.1.2024: DataJuggler.Blazor.Components recently passed 200,000 installs on NuGet. Sadly, out of 200,000 installs 
there are only 7 likes on this project. Please take a second and like this project as I work hundreds of hours 
per year on it.

Please leave a star if you think this project is worth the price.
https://github.com/DataJuggler/DataJuggler.Blazor.Components

# Upcoming News
I will start testing the previews for .NET 9, so I expect to have a working version for .NET 9 by release date
in Mid November or soon thereafter.

# New Website Coming
I plan on building a new site just for this project, so you can find the information you need faster about each component.

# Major Update Version 8.11.0
10.1.2024: This release contains a few major updates, and one breaking change, but it's an easy fix in most cases.

# New Time Component
I created a new Time Component, and you type in the hours or minutes and double click on the AM / PM label to toggle it.
If you set the property TimeType to Hours24, than the AM / PM label does not appear.

# New Delegate OnTextChange(string text)

A new delegate was created in DataJuggler.Blazor.Components.Delegates called OnTextChange, and you can create
a method that receives a string parameter to get a call back when a text box value changes. This is how the TimeComponent
turns red if you type in an invalid time.

    public delegate void OnTextChange(string text);

# InformationBoxComponent - New Property: BodyContent
I learned something new recently thanks to Bing Chat (Copilot). I wanted the user to be able to host their own 
components on an InformationBoxComponent, and you can do so with a property called RenderFragment.
So in the InformationBoxComponent, you can do this:

    <InformationBox Name="TestScheduleInfoBox" Parent="this" Title="Test Schedule"
        Column1Width="200" Column2Width="120" Column1Left="0" Gap="8" ListItemTop="-2"
        Column1ClassName="textalignright" Column2ClassName="textalignleft"
        HeaderFontWeight="bold" HeaderFontSize=20
        ListItemLeft="0" ImageTop="1" Height="164" Width="300" FontSize=16
        Left="-112" Theme="@ThemeEnum.Blue" BorderColor="Color.Gray" HeaderHeight="32"
        HeaderTextVerticalOffset="3" Scale="85">
        <BodyContent>
            <div class="down8 right8">
                <TimeComponent Name="StartTimeComponent" Parent="this"
					Column1Width="40" Caption="Start Time" FontSize="16"
					HoursTextBoxLeft="-2" MinutesTextBoxWidth="20"
					MinutesTextBoxLeft="0"></TimeComponent>
			</div>
		</BodyContent>
    </InformationBox>

# ValidationComponent is Gone
The ValidationComponent confused people I have discovered. Instead of having one component that could be
a CheckBox, a Multiline TextBox or a TextBox, I broke this up into two new components.

CheckBoxComponent
TextBoxComponent

Everything that used be on the ValidationComponent, is now called TextBoxComponent. The only parts that are missing
are the parts related to a CheckBoxMode. This should help with the confusion, since everyone knows what a TextBox is.

The other part that changed is the ComboBox in CheckedListMode now uses the CheckBox for each item instead of the
ValidationComponents.

# CalendarComponent Now Has A Year Selector
By default the year selector is turned off. Set the property AllowYearSelector to true and the year selector appears.

    AllowYearSelector="true"

The Year Selector has decades at the top and the selected decade's year appear below. Select a Year to close the
Year Selector or click the Date Title (Month Year) on the Calendar to toggle it On/ off.

9.24.2024: Breaking Changing! Easy Fix. I renamed the ValidationComponent to TextBoxComponent, 
removed the CheckBoxMode and created a new CheckBoxComponent. Unless you were using the 
CheckedBoxMode of the ValidationComponent, the only thing you should have to do is rename
ValidationComponent to TextBoxComponent. I think it confused a lot of people on what the
ValidationComponent is. Everyone knows what a TextBox is, so simple is better.
 
9.12.2024: Working on a new TimeComponent. 

9.11.2024: I updated DataJuggler.Excelerate. I also fixed a bug with ListItemTop and ListItemLeft,
as they were only applied to Column2. i removed method FindChildByName from IBlazorComponent interface.

9.9.2024: I added two new properties HeaderFontSize and HeaderFontWeight, which defaults to bold.
I also expanded the InformationBox with a RenderFragment property, allowing a user to put custom content
such as text, HTML, Blazor Components or images inside an InformationBox object.
Also a new enum was created to specifiy ItemsOnly, ItemsOnTop (default) or ItemsOnBottom, and the users
custom content will render with the Items (if it works, untested yet)

9.5.2024: I added a Scale property to the Information Box.

9.1.2024: I added Column1Width and Column2 Width and Column1TextAlign and Column2TextAlign properties
to the the Information Box. Testing now

8.27.2024: I added some properties to customize the position of items in the Information Box.

8.13.2024: DataJuggler.UltimateHelper was updated.

5.30.2024: I created a new component called an InformationBox. This component is used for creating dashboards or reports.

<img src=https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/SampleInformationBox.png height=215 width=356>

    <InformationBox Parent="this" Title="Summary" Height="204" Width="340"
        Column1Width="180" Column2Width="152" Column1Left="0" Gap="8"
        Left="256" Theme="@ThemeEnum.Blue" BorderColor="Color.Gray" HeaderHeight="32"
        HeaderTextVerticalOffset="3" Name="Summary">
    </InformationBox>

The InformationBox is loaded via code. Here is a sample for how to load an InformationBox

I create a private variable for the InformationBox

    private InformationBox infoBox;

And from this I create a property. It's optional, but I use Visual Studio package Regionizer2022

Regionizer2022
https://github.com/DataJuggler/Regionizer2022

Make sure your code file has a Properties region, and select one or more private variables - Click the 
Create Properties button

A property is created

    #region InfoBox
    /// <summary>
    /// This property gets or sets the value for 'InfoBox'.
    /// </summary>
    public InformationBox InfoBox
    {
        get { return infoBox; }
        set { infoBox = value; }
    }
    #endregion

To create a HasProperty, I select the word InfoBox, in the line public InformationBox InfoBox
and in Regionizer 2022, I click 'Create Has Property'.

This creates a read only property that is a simple method of testing for null

    #region HasInfoBox
    /// <summary>
    /// This property returns true if this object has an 'InfoBox'.
    /// </summary>
    public bool HasInfoBox
    {
        get
        {
            // initial value
            bool hasInfoBox = (this.InfoBox != null);
            
            // return value
            return hasInfoBox;
        }
    }
    #endregion

Then in the Register method of the page or component hosting the InformationBox, make sure the
component implements IBlazorComponentParent. If you have more than one InformationBox on a page
or component, you can refer to them by name to store each component. The example below only has
one InformationBox on the page.

In the register method, store the object

    if (component is InformationBox)
    {
        // Store
        InfoBox = component as InformationBox;
        
        // test only
        List<Item> items = CreateSampleInfoBoxItems();
        
        // if the value for HasInfoBox is true
        if (HasInfoBox)
        {
            // Set the Items
            InfoBox.SetItems(items);
            
            // Update the UI
            InfoBox.Refresh();
        }
    }

And this method CreateSampleInfoBoxItems demonstrates how to load a list of items

Tip: Notice the code for the image for the first item. You can place an image on the left or right of text,
by selecting the ImageAlignment.

    #region CreateSampleInfoBoxItems()
    /// <summary>
    /// returns a list of Sample Info Box Items
    /// </summary>
    public List<Item> CreateSampleInfoBoxItems()
    {
        // initial value
        List<Item> items = new List<Item>();
        
        // Create a new instance of an 'Item' object.
        Item item = new Item();
        item.Caption = "Acceptable Pressure Test?";
        item.Text = "Yes";
        
        // image
        item.IncludeImage = true;
        item.ImageAlignment = ImageAlignmentEnum.ImageOnLeftOfText;
        item.ImageWidth = 16;
        item.ImageHeight = 16;
        item.ImageUrl = "../Images/GreenCircle.png";
        
        // Add this item
        items.Add(item);
        
        // Create a new instance of an 'Item' object.
        item = new Item();
        item.Caption = "PSI Loss to Leak?";
        item.Text = "30.1 psi";
        
        // Add this item
        items.Add(item);
        
        // Create a new instance of an 'Item' object.
        item = new Item();
        item.Caption = "Total Test Time";
        item.Text = "8 Hours 0 Minutes";
        
        // Add this item
        items.Add(item);
        
        // Create a new instance of an 'Item' object.
        item = new Item();
        item.Caption = "Min Test Duration Met?";
        item.Text = "Yes";
        
        // Add this item
        items.Add(item);
        
        // Create a new instance of an 'Item' object.
        item = new Item();
        item.Caption = "Min Test Pressure Met?";
        item.Text = "Yes";
        
        // Add this item
        items.Add(item);
        
        // Create a new instance of an 'Item' object.
        item = new Item();
        item.Caption = "MAOP Verified By Test";
        item.Text = "452 psi";
        
        // Add this item
        items.Add(item);
        
        // Create a new instance of an 'Item' object.
        item = new Item();
        item.Caption = "Desired MAOP";
        item.Text = "400 psi";
        
        // Add this item
        items.Add(item);
        
        // Create a new instance of an 'Item' object.
        item = new Item();
        item.Caption = "Test Within Pressure Bounds?";
        item.Text = "Yes";
        
        // Add this item
        items.Add(item);
        
        // return value
        return items;
    }
    #endregion

5.24.2024
8.8.8: New Properties were added to the ComboBox to control the height of the TextBox for the CalendarComponent

# Update 5.18.2024

New Video:

First Ever Opensource Saturday - Sunday Edition
https://youtu.be/uxa1xR6xpzk

5.8.2024: I spent a week refactoring the Combo Box. I realized my first combobox wasn't a standard combobox.
Now, if you are in regular mode (not checklist mode), you can type T twice for Texas in a States list, for example.
I have a new sample project called 'NTouch', that demonstrates the ComboBox and the Calendar.

NTouch
https://github.com/DataJuggler/NTouch/

# Example using the Combobox in regular mode (not CheckListMode)

    <ComboBox Name="StateComboBox" Theme=ThemeEnum.Blue Unit="px" HeightUnit="px" Height="32" ZIndex="80"
        LabelText="State:" Width="224" Parent="this" ButtonHeight=24 ButtonWidth=24 ControlHeight="32"
        DropdownClassName="container2 border1gray textdonotwrap" TextBoxLeft="0" ButtonTop=-5 ButtonLeft=-26
        ListItemWidth="120" ListZIndex=80 ListItemTop=24
        Column2Width="128" Position="relative" Top="0" LabelClassName="down4 right2" TextBoxWidth="124">
    </ComboBox>

Notice the attribute Parent=this on Line 2. This is how the ComboBox registers with its parent. To use this feature, you probably 
have to supress the warning BL0007 in the project properties. Microsoft doesn't like code in Setters, but this is how all
IBlazorComponents and IBlazorComponentParents talk to each other. 

New video coming soon.

Here is the css you must put in the client project that uses the ComboBox. Notice line 3 DropDownClassName

    .container2
    {
        position: absolute;
        width: 120px;
        height: 80px;        
    }

Feel free to adjust the height and width as needed. The position absolute is the key to the Drop Down showing, without
moving other content (spent a while on this). Border1Gray is shown below.

# Example using the Combobox in CheckListMode

    <ComboBox Name="TargetFrameworkComboBox" Theme=ThemeEnum.Blue Unit="px" HeightUnit="px" Height="32"
        LabelText="Target:" Width="224" Parent="this" ButtonHeight=24 ButtonWidth=24 
        CheckedListClassName="container border1gray textdonotwrap" TextBoxLeft="1" ButtonTop=-5 ButtonLeft=-4
        Column2Width="128" Position="relative" Top="4" LabelClassName="down4 right2" TextBoxWidth="124" 
        CheckListMode=true CheckedListUnit="vw" CheckedListHeightUnit="vh" CheckedListheight="4" ListItemHeight="2.4"
        CheckedListItemLeft="2" CheckedListItemTop=1 ListItemBackgroundColor=Color.White
        CheckBoxXPosition="-3.2" CheckBoxYPosition=".4" CheckBoxTextXPosition="-3"  CheckBoxTextYPosition="0" 
        CheckedListWidth=8 CheckedListTop="24" CheckedListLeft="48" ListItemWidth=10>
    </ComboBox>

It is important to note the CheckedListClassName on line 3. I have two CSS classes set in an External project, that are the key
to making the Z-Index work. I tried using an internal CSS Class, and haven't had much luck. Will try again later.

    .border1
    {
        border-width: 1px;
        border-style: solid;
        border-color: black;
    }
    .border1gray
    {
        border-width: 1px;
        border-style: solid;
        border-color: gray;
    }
    .container
    {
        display: inline-block;
        height: 16vh;
        min-height: 16vh;
        max-height: 16vh;
        width: 16vw  !important;
        max-width: 16vw  !important;
        min-width: 16vw !important; 
        position: relative;
        left: 0vw;
        overflow: visible !important;
        z-index: 200 !important;
        background-color: white;
    }

5.1.2024: I added a ZIndex property to the Calendar. If you have two calendar components near each other, the first one can't type.
Will work on a solution later, but the ZIndex should allow a fix.

4.30.2024: Version 8.6.22 fixes the textbox and button jumping around when the calendar showed, by adding min-height and max-height
properties to the ContainerStyle BlazorStyled class.

4.29.2024: I added few more tweaks to the CalendarComponent, to make it easier to use. 
I think a good future feature might be if you click on the Year label, a combobox opens with a selection of years.
For things like Birthday, scrolling dozens of years isn't worth it. You can always type it, but a year selector might
be worth exploring.

4.27.2024: Eureka! I have done it. I built a working CalendarComponent, and being it has been tested by all of 1 person in all
of 1 project(s), I am pretty excited. If this doesn't make it worth the price, and make you willing to leave a star on GitHub
or Subscribe to my YouTube channel, nothing will. 

<img src=https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/Calendar.png height=219 width=336>

# Calendar Example

    <CalendarComponent Name="FollowUpDateControl" Unit="px" HeightUnit="px" Height="146" Position="relative"
        ButtonHeight=24 ButtonWidth=24 CalendarTop="-116" CalendarLeft="64" Caption="Follow Up Date:" 
        Parent="this" ButtonTop="-4" Width="224" Column2Width="128" ControlHeight="32" 
        Top="0" LabelClassName="down4 right2" TextBoxWidth="124">
    </CalendarComponent>

I created a new repository for a project called NTouch. You can run NTouch now and see an example.

NTouch
https://github.com/DataJuggler/NTouch

4.24.2024: To celebrate the coming milestone of 200,000 installs coming up this summer, I am working on a Calendar Component.
The Calendar Component is in this release (8.5.0), but it is far from being to use. What I am testing now is the text box shows up,
the button shows up, and if you click the button, the pop up calendar div shows and goes away as you toggle the button.
Soon I will add buttons for the calendar. Baby steps.

4.23.2024: I had some problems running the Blazor Server App projects in .NET 8. The problem was browsers (Chrome) are depreciating 
Page Unload events, and blazor.server.js is the culprit. I switched to a web app and things work.
The one important thing I noticed, linking to a CSS class like this seems to not work in a Blazor Web Project (not Blazor Server App Template)

    <link href="~/_content/DataJuggler.Blazor.Components/css/DataJuggler.Blazor.Components.css" rel="stylesheet" />

Removing the Tilde seems to work.

    <link href="/_content/DataJuggler.Blazor.Components/css/DataJuggler.Blazor.Components.css" rel="stylesheet" />

4.18.2024: The conversion to using BlazorStyled again has completed. Testing in progress, but seems to work.

4.17.2024: I added back BlazorStyled, but I forked the project and created a NuGet package DataJuggler.BlazorStyled.
I didn't make any code changes, all I did was upgrade the component to .NET 8 and the dependencies.

4.8.2024: I modified the grid with a new property 'NotifyParentOnDoubleClick'. You can set
an ExternalId and ExternalIdDescription when you create the rows. 
I also added an EnableClick function for a Grid row. The Click does work. Testing the DoubleClick now.
the parent object will receive a message. Optionally, Set the ExternalId and ExternalId Description.

4.5.2024: ImageButton does not have a ClassName property.

4.4.2024: I removed the dependency on Blazor Styled. Blazor Styled hasn't been updated since 
.NET Core 3.1, and I found you can create a Style section on any razor page and do the same thing
without Blazor Styled, and with better results it seems of late.

12.30.2023: I updated the CheckBox to send a message to its Parent when it's value changes.
I added SetLabelColor method to the TextBoxComponent.

I created a new project that uses these controls.

Snow Creator
https://github.com/DataJuggler/SnowCreator

Live Demo:
https://snowcreator.datajuggler.com 

12.28.2023: I fixed a bug with the CheckedListBox where the ListItemHeight was wrong.

12.27.2023: I added the !important attribute to the ListItemZIndex CSS and ListItemHeight and CheckedListHeight.

12.26.2023: I updated DataJuggler.NET8 and DataJuggler.Excelerate Nuget packages.

12.18.2023 I fixed a bug with the TextBoxComponent
If is valid is true, I set the label to the invalid label color. This is now fixed.

11.15.2023 I updated the project to .NET 8

For .NET 7, use a 7.x version.

11.10.2023: I added a Label

The Label provides a simple way to display text.

11.8.2023 New Video For 100,000 Installs

Version 7.13.7

How To Use DataJuggler.Blazor.Components Grid
https://youtu.be/_qDo9pNT5a8

Version 7.13.5
Novermber 7, 2023: DataJuggler.Blazor.Components passed 100,000 Downloads
I updated the Grid and created a new sample project to demo the Grid.

The sample project is called BubbleReportWeb
https://github.com/DataJuggler/BubbleReportWeb

Version 7.12.8
November 2, 2023: I added a ClassName parameter to the Grid

August 29, 2023: 

New Video: DataJuggler.Blazor.Components reaches 75,000 Installs
https://youtu.be/WkcwQ9kOfw4
In this short video I show a demo of code generating classes from Blazor Excelerate.

August 26, 2023: In celebration of 75,000 NuGet installs, I added two new features.
First, I created a CheckedListBox component. I also added a new feature to the ComboBox,
and that new features is a CheckedListMode. The combobox now supports check boxes and 
multiple selections.

July 22, 2023: More updates  to NuGet package DataJuggler.Excelerate, and I need this update for my project 
Blazor Excelerate

July 21, 2023: I updated NuGet package DataJuggler.Excelerate, and I need this update for my project 
Blazor Excelerate

July 18, 2023: I fixed the checkbox component. The binding wasn't working when I thought I fixed it last time.

July 9, 2023: I removed floats from the ComboBox component. I was having trouble "stacking" a TextBoxComponent
below a ComboBox, so hopefully this fixes it. I also added a ComboBoxWidth parameter property on the ComboBox.

July 6, 2023: I added an AutoComplete property, which defaults to false.
The reason for this is browsers like to fill in values, and the browser is confusing Email Address and User Name fields.

July 2, 2023: I removed the floats from the TextBoxComponent. This will probably break
some existing users, but I am trying to make the control more consistant to work with.
I also added a MarginBottom property. Use this in conjunction with the HeightUnit, which
defaults to px (pixels) and the MarginBottom is set to 8 by default. 

June 21, 2023: I updated DataJuggler.UltimateHelper.

June 3, 2023 B: I updated the Sprite component to have a SetVisible and optional parameter for Hide
when you call Stop.

June 3, 2023: My first attempt at Disabled for the Validation Component was wrong. I think my fix will work. Testing now.

June 2, 2023: I added an Enabled property and a method SetEnabled to the validation component.
If Enabled is false, disabled will appear in the input objects and be read only.

5.8.2023: Nuget package DataJuggler.Blazor.Components reached 50,000 installs today.

3.8.2023: Nuget package DataJuggler.Blazor.Components reached 40,000 installs today.

# Sample Projects

I created a new project that uses the TextBoxComponent.

# Blazor Gallery

Live Demo

Blazor Gallery<br>
https://blazorgallery.com 

Blazor Gallery Source<br>
https://github.com/DataJuggler/BlazorGallery

# Video
Blazor Gallery Deserves A Star<br>
[![Blazor Gallery Deserves A Star Video](https://img.youtube.com/vi/HAMgeaCuvHY/0.jpg)](https://www.youtube.com/watch?v=HAMgeaCuvHY)

# Blazor Excelerate

Live Demo

Blazor Excelerate
https://excelerate.datajuggler.com 
Code Generate C# Classes From Excel Header Rows

Blazor Excelerate Source
https://github.com/DataJuggler/Blazor.Excelerate

Getting Started:

# Important

This project has a dependency on DataJuggler.BlazorStyled (a port of BlazorStyled by chanan. Both will work, but 
the forked version has been upgraded for .NET8.)

Add the following to program.cs:

using DataJuggler.BlazorStyled;

builder.Services.AddBlazorStyled();
    
# New Video - 50,000 NuGet Installs

BuildCopy https://github.com/DataJuggler/BuildCopy

BuildCopy will copy the files from a Visual Studio solution to an output folder. In this case, the output folder is ProjectTemplates\Working\Templates. BuildCopy also allows you to set ignore folders, so I do not copy the .vs, .git, .bin, .obj, .templateconfig and a few others.

Here is a video showing you how to setup this project, build the data tier for Blazor Gallery, and build your own DataTier.Net projects.

How To Create A NuGet Package For A Blazor Site
https://youtu.be/K5WbNKUPDGs

Want To Help Contribute to this project?
Volunteer to take the instructions from the video and write them out as step by step. Bonus with images and screen shots.

If you think this project is worth the price, please leave a star and / or subscribe to my YouTube channel: https://youtube.com/DataJuggler

Thanks

One of my favorite parts of this project is the DataJuggler.Blazor.Componets.css file.

After adding nuget package DataJuggler.Blazor.Componets Nuget package, add the folloing line to
your _layout.cshtml file in your Blazor project:

    <link href="~/_content/DataJuggler.Blazor.Components/css/DataJuggler.Blazor.Components.css" rel="stylesheet" />

View the full CSS here:
https://github.com/DataJuggler/DataJuggler.Blazor.Components/blob/master/wwwroot/css/DataJuggler.Blazor.Components.css

The CSS file has values to make it easy to position and style components.

CSS classes can be combined using spaces like:

    <div class="width16 backgroundcolorskyblue marginleft8 down12"></div>

background(color name) 
Example: backgroundlemonchiffon<br>
Set the background color to a .NET named color.

Set Colors:
https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.colors?view=windowsdesktop-7.0

color(color name)
Example: colormidnightblue.
Set the forecolor to a .NET named color.

displayblock, displayinline, displaylineblock, displaynone.

down(0 - 1000)
Example: down16
Move the element 16 pixels down. (CSS is top: 16px).

height(0 - 1000)
Example: height18
Set the height, minheight and maxheight to 18 pixels.

left(0 - 1000)
Example: left40
Move the element 40 pixels to the left (Css is right: 40px).

marginbottom(0 - 600)
Example: marginbottom200
Give the element a bottom margin of 200 pixels.

marginleft(0 - 600)
Example: marginleft24
Give the element a left margin of 24 pixels.

marginright(0 - 600)
Example: marginright64
Give the element a right margin of 64 pixels.

margintop(0 - 600)
Example: margintop90
Give the element a top margin of 90 pixels.

right(0 - 1000)
Example: right128
Move the element 128 pixels to the right (Css is left: 128px).

up(0 - 1000)
Example: up12
Move the element up 12 pixels. (Css is bottom: 12px)

width(0 - 1000)
Example: width640
Set the width, min-width and max-width in pixels. In this example 640.

## TextBoxComponent

### Example

    <TextBoxComponent Name="ResultsControl" Caption="Results:" Parent="this" Unit="px" Column1Width="64" Column2Width="480" TextBoxWidth="480" 
        LabelClassName="down8" Left="0" MarginLeft="4" Multiline=true HeightUnit="vh" Height="20" Top=0 LabelFontSizeUnit="em" 
        LabelFontSize=".8"></TextBoxComponent>

This componet can serve as a CheckBox, a TextBox or a TextArea.

Register the componet by setting the parent=this, and your parent needs to implement
IBlazorComponentParent interface.

Add the following line in your parent component.

using DataJuggler.Blazer.Components.Interfaces;

Tip: Use partial classes for your components. To do this, in your project add a CS class with the same name
as your component. Name your class such as this:

Example: 
Grid.razor
Grid.razor.cs (partial class)

public partial class Grid : ComponentBase, IBlazorComponent, IBlazorComponentParent

As you can see above, the Grid implements IBlazorComponet and IBlazorComponentParent.

Visual Studio makes it easy to implement interfaces. Right click the interface name, and select
Quick Actions and Refactoring > Implement Interface.

This will stub out the properties and methods needed to implement the interface.

To see an example of registering components, see the project Blazor Excelerate linked
at the top of this document. Look for a method called Register. Once registered then your
components can talk to each other using the ReceiveData method and by passing Message objects.

# Update 11.7.2023: I just published a new project to Demo Grids
https://github.com/DataJuggler/BubbleReportWeb

This is a sample mark up for a grid. The parent of the grid must implement DataJuggler.Blazor.IComponentParent

    <Grid Name="TopStreaksStockGrid" ClassName="grid" Unit="px" Width="310" HeightUnit="px" Height=278
        ShowHeader="true" HeaderText = "Top Streak Stocks" HeaderClassName = "width320 textaligncenter"
        ShowColumnHeaders=true Parent="this" Left="40" Top=-24 FontSize="12"></Grid>

Notice the property Parent="this" on the bottom line. This is how the grid is registered with the parent.

View the code for the BubbleReportWeb above, and view the code for Index.razor.cs. The Register method has multiple grid properties.

    private Grid topStreakGrid;

    /// <summary>
    /// This property gets or sets the value for 'TopStreakGrid'.
    /// </summary>
    public Grid TopStreakGrid
    {
        get { return topStreakGrid; }
        set { topStreakGrid = value; }
    }

One important thing to note, is the grid works best when you register DataJuggler.Blazor.Components.css in your project like this:
    
    <link href="/_content/DataJuggler.Blazor.Components/css/DataJuggler.Blazor.Components.css" rel="stylesheet" />

Removing the tilde seems necessary for Blazor Web Apps (latest .NET8 Template). I will do more testing when I get a chance and confirm this works in both.

The above CSS class is included with NuGet package DataJuggler.Blazor.Components

The grid can be loaded via code in the OnAfterRenderAsync event:

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        // if the TopStreakGrid exists
        if (HasTopStreakGrid)
        {
            // create the rows
            List<Row> rows = CreateRowsForTopStreakStocks();
            
            // Set the Row
            TopStreakGrid.Rows = rows;
            
            // Refresh the Grid
            TopStreakGrid.Refresh();
        }
    }

# Loading Grid Rows and Columns

In this example, I added two using statements to avoid the conflict between DataJuggler.Excelerate.Row and DataJuggler.Excelerate.Column
OfficeOpenXml.Row and OfficeOpenXml.Column. DataJuggler.Blazor.Excelerate is installed when you add DataJuggler.Blazor.Components
to a project via NuGet.

Note: The Gateway class listed below is created when you create a project via DataTier.Net. You can use EntityFramework or another ORM
if you prefer. I like DataTier.Net because it uses all stored procedures.

DataTier.Net (Optional)
https://github.com/DataJuggler/DataTier.Net

    using Row = DataJuggler.Excelerate.Row;
    using Column = DataJuggler.Excelerate.Column;

    /// <summary>
    /// returns a list of Rows For Top Streak Stocks
    /// </summary>
    public List<Row> CreateRowsForTopStreakStocks()
    {
        // initial value
        List<Row> rows = new List<Row>();
        
        // Load the Gateway
        Gateway gateway = new Gateway(Connection.Name);
        
        // Load the topStocks
        List<TopStreakStocks> topStocks = gateway.LoadTopStreakStocks();
        
        // If the topStocks collection exists and has one or more items
        if (ListHelper.HasOneOrMoreItems(topStocks))
        {
            // Create Column and set properties
            Column column = new Column();
            column.Caption = "Symbol";
            column.ColumnName = "Symbol";
            column.Index = 0;
            column.ColumnNumber = 1;
            column.ColumnText = "Symbol";
            column.Width = 48;
            column.Height = 16;
            column.ClassName = "displayinlineblock width48 colorwhite textalignleft down4 right16 fontsize12";
            
            // Add this column
            TopStreakGrid.Columns.Add(column);
            
            // Create Column and set properties
            Column column2 = new Column();
            column2.Caption = "Name";
            column2.ColumnName = "Name";
            column2.Index = 1;
            column2.ColumnNumber = 2;
            column2.ColumnText = column2.Caption;
            column2.Width = 140;
            column2.Height = 16;
            column2.ClassName = "displayinlineblock width140 colorwhite textalignleft down4 right16 fontsize12";
            
            // Add Column 2 to the header row
            TopStreakGrid.Columns.Add(column2);
            
            // Create Column and set properties
            Column column3 = new Column();
            column3.Caption = "Last";
            column3.ColumnName = "LastClose";
            column3.Index = 2;
            column3.ColumnNumber = 3;
            column3.ColumnText = column3.Caption;
            column3.Width = 48;
            column3.Height = 16;
            column3.ClassName = "displayinlineblock width48 colorwhite textalignleft down4 right30 fontsize12";
            
            // Add this column
            TopStreakGrid.Columns.Add(column3);
            
            // Create Column and set properties
            Column column4 = new Column();
            column4.Caption = "Streak";
            column4.ColumnName = "Streak";
            column4.Index = 3;
            column4.ColumnNumber = 4;
            column4.ColumnText = column4.Caption;
            column4.Width = 48;
            column4.Height = 16;
            column4.ClassName = "displayinlineblock width48 colorwhite textalignleft down4 right16 fontsize12";
            
            // Add this column
            TopStreakGrid.Columns.Add(column4);
            
            foreach (TopStreakStocks topStock in topStocks)
            {
                // Create a row
                DataJuggler.Excelerate.Row row = new DataJuggler.Excelerate.Row();
                row.ClassName = "textdonotwrap width448 height16 marginbottom0 down8";
                
                // Create Column and set properties
                column = new Column();
                column.Caption = "Symbol";
                column.ColumnName = "Symbol";
                column.Index = 0;
                column.ColumnNumber = 1;
                column.ColumnText = topStock.Symbol;
                column.Unit = "px";
                column.Width = 48;
                column.Height = 16;
                column.ClassName = "displayinlineblock width48 colorwhite textalignleft right16 fontsize12";
                
                // Add this column
                row.Columns.Add(column);
                
                // Create Column and set properties
                column2 = new Column();
                column2.Caption = "Name";
                column2.ColumnName = "Name";
                column2.Index = 1;
                column2.ColumnNumber = 2;
                column2.ColumnText = topStock.ShortName.ToString();
                column2.Width = 140;
                column2.Height = 16;
                column2.ClassName = "displayinlineblock width140 colorwhite textalignleft right16 fontsize12";
                
                // Add this column
                row.Columns.Add(column2);
                
                // Create Column and set properties
                column3 = new Column();
                column3.Caption = "Last Close";
                column3.ColumnName = "LastPrice";
                column3.Index = 2;
                column3.ColumnNumber = 3;
                column3.ColumnText = topStock.LastClose.ToString("C");
                column3.Width = 48;
                column3.Height = 16;
                column3.ClassName = "displayinlineblock width48 colorwhite textalignright right8 fontsize12";
                
                // Add this column
                row.Columns.Add(column3);
                
                // Create Column and set properties
                column4 = new Column();
                column4.Caption = "Streak";
                column4.ColumnName = "Streak";
                column4.Index = 3;
                column4.ColumnNumber = 4;
                column4.ColumnValue = topStock.Streak;
                column4.ColumnText = topStock.Streak.ToString();
                column4.Width = 48;
                column4.Height = 16;
                column4.ClassName = "displayinlineblock width48 colorwhite textaligncenter right16 fontsize12";
                
                // Add this column
                row.Columns.Add(column4);
                
                // Add this row
                rows.Add(row);
            }
        }
        
        // return value
        return rows;
    }

If you have any questions, please feel free to ask on Git Hub:
https://github.com/DataJuggler/DataJuggler.Blazor.Components/Issues

# DataJuggler.Blazor.Components
This class consists of an ImageButton, ProgressBar, Sprite, TextBoxComponent, ComboBox,
CheckedListBox and a Grid.

# CheckedListBox

Update 8.26.2023: If you need to hide the CheckedListBox, before hiding you need to store
the selections. Look at the code for the ComboBox.ButtonClickedEvent to see an example where
it calls StoreSelections. This checks the Items in memory if the checkboxes have been checked.
I have tried doing this dynamically as the items are checked, and had numeroius problems.


Update 11.8.2022: This project has been updated to .NET 7.

DataJuggler.Excelerate has been added to add Rows and Columns for the Grid.

I also added a new CSS file:

# DataJuggler.Blazor.Components.css

https://github.com/DataJuggler/DataJuggler.Blazor.Components/blob/master/wwwroot/css/DataJuggler.Blazor.Components.css

DataJuggler.Blazor.Components.css has classes that I find useful in styling blazor components.

To use this file, after adding Nuget package DataJuggler.Blazor.Components, add the following link to your _layout.cshtml file:

    <link href="~/_content/DataJuggler.Blazor.Components/css/DataJuggler.Blazor.Components.css" rel="stylesheet" />
    
This will make all the classes in the file available to your project.

# Examples:

# Background Color
Background color is in the format backgroundcolor + the known color name.

    .backgroundcolorskyblue
    {
        background-color: skyblue;
    }

# Foreground Color
Background color is in the format color + the known color name.

    .colorforestgreen
    {
        color: forestgreen;
    }

# Height
Height is in the format height + the height value in pixels

Height values range from 0 - 1,000.

    .height75
    {
        height: 75px;
        min-height: 75px;
        max-height: 75px;
    }

# Width
Width is in the format width + the width value in pixels

Width values range from 0 - 1,000.

    .width596
    {
        width: 596px;
        min-width: 596px;
        max-width: 596px;
    }

# Margin
Margin is in the format margin + direction (top, left, bottom, right) + the margin value in pixels:

Margin ranges from 0 - 600

    .marginleft200
    {
        margin-left: 200px;
    }

    .marginright12
    {
        margin-right: 12px;
    }

A few extras:

    .textalignleft
    {
        text-align: left;
    }
    .textalignright
    {
        text-align: right;
    }
    .textaligncenter
    {
        text-align: center;
    }
    .textdonotwrap
    {
        white-space: nowrap !important;
    }

I find these classes useful for Blazor components, because you can combine them and it saves creating inline styles.

    # Excample of multiple classes applied to an element.
    column2.ClassName = "width120 textalignleft marginleft4 colorwhite";


Update 10.22.2021:

I just released a full working sample here:
https://github.com/DataJuggler/Blazor.Excelerate

And a live example is here:
https://excelerate.datajuggler.com

Blazor Excelerate is used to code generate C# classes from an Excel header row.

--

The TextBoxComponent is a multi-use component that allows you to build data entry
screens quickly. 

Below is a quick sample to get you started using it.

Install Package DataJuggler.Blazor.Components

# Directly on a .razor page or component:
@using DataJuggler.Blazor.Components
@using DataJuggler.Blazor.Components.Interfaces;

# Partial Class (code behind)
using Microsoft.AspNetCore.Components;<br>
using DataJuggler.Blazor.Components;<br>
using DataJuggler.Blazor.Components.Interfaces;<br>

# Component in a razor app
<ProgressBar Subscriber=this Increment="5" Interval="50"
    Continuous="false" HideWhenFinished="true"></ProgressBar>
    
The hosting page or component must implement the IProgressSubscriber interface.

# Implementing IProgressSubscriber Interface
This interface contains two simple methods and one property.

public partial class Index : IProgressSubscriber
{
   ...
}

# IProgressSubscriber Interface Methods

# Refresh

    /// <summary>
    /// This method is called by the ProgressBar when as it refreshes.
    /// </summary>
    public void Refresh(string message)
    {
        // Update the UI
        InvokeAsync(() =>
        {
            StateHasChanged();
        });
    }

# Register

    /// <summary>
    /// This method Registers the ProgressBar with this app.
    /// </summary>
    public void Register(ProgressBar progressBar)
    {
        // store the ProgressBar
        this.ProgressBar = progressBar;
    }

# Blazor Styled Has Been Removed

# Use Cases

For now, the progress bar is meant to show the user something is happening during a long running process.

The sample project demonstrates using a Timer and on every refresh the progress bar increases the fill width by the increment value
in pixels, up to the Max value. To use the timer, call the Start method on the Progress bar.
In theory, and I will update this once I know it works, you should also be able to manually increase the FillWidth value, which in turn sets the FillWidthPixels string value

Example: FillWidth = 100
         FillWidthPixels = 100px
         
The FillWidthPixels is used by the CSS for the inner graph.

# Progress Bar Events

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
       ...
    }
    
This is the Tick event the Timer calls on every cycle. This method increments the FillWidth by the Increment value.
If the value for Max is encountered, either the app will close if HideWhenFinished is true or reset if continuous is true.

# ProgressBar Methods

# Init

This method is called by the Constructor of the ProgressBar and sets the DefaultValues.

# Start

Call this method to Start the timer. This is used where the graph increments on a regular basis based upon the interval set.

public void Start(int startAtValue = 0)

# Stop

This method stops the timer and all future events (already in progress events may finish before stopping)

# ProgressBar Properties

# CurrentValue

    [Parameter]
    public int CurrentValue { get; set; }
    
The CurrentValue also sets the FillWidth. This property might be removed as FillWidth controls FillWidthPixels, and is what the display goes by.

# Display

    public string Display { get; set; }
    

The display is managed by the ProgressBar.Visible property, but you can change it if needed (I think).

Visible = true - Display = inline-block
Visible = false - Display = none

From Progressbar.razor:
display: @Display;

# FillWidth

    public int FillWidth { get; set; }

The FillWidth is the number of pixels displayed up to the Max value.

Setting the FillWidth sets the FillWidthPixels CSS Property.

FillWidth = 90;
FillWidthPixels = 90px

# FillWidthPixels

    public int FillWidthPixeels { get; set; }

As described above, a property that is the CSS value for how many pixels to display.
Set this property by setting the FilWidth integer value else you are in uncharted waters.

# HasSubscriber

    public bool HasSubscriber { get; }

This read only property returns true if the ProgressBar has a Subscriber.

# Increment

    [Parameter]
    public bool Increment { get; set; }
    
This value sets how many pixels left the next bubble will be.

This value is set by the Increment times the number of times Refresh was called.

# Interval

    [Parameter]
    public int Interval { get; set; }
    
This is the value in milliseconds for how often the Timer event will fire. The default value is 100 if not set.

# Max

    [Parameter]
    public int Max { get; set; }
    
This is the maximum value the ProgressBar inner fill can go to.
The Default Value is 552.

# NotificationInProgress

    public bool NotificationInProgress { get; set; }
    
This property is used internally by the ProgressBar to make sure only one thread of notifications is sent to the Client at a time.
This is also useful for debugging as it keeps the message chain down to single threads.

# Position

    public string Position { get; set; }
    
This property is set on the CSS Class for position. Fixed, Absolute and Relative are the 3 I know, there may be more.

# ProgressBackground

    public string ProgressBackground { get; set; }
    
This is the string property bound to the CSS styles for the ProgressBar div.
In future versions I imagine themes or other styles, or even an option to display the innter graph without the background.

<img src="https://github.com/DataJuggler/DataJuggler.Blazor.Components/blob/master/wwwroot/Images/RedProgressBase.png">

# Scale

I added a double value for Scale that allows to control how big the ProgressBar displays. The default is .5.

# Started

    public bool Started { get; set; }

This property is managed internally the by the ProgressBar when Start and Stop are called.

# Subscriber

    [Parameter]
    public IProgressSubscriber Subscriber

This property registers the parent with the ProgressBar, which enables the ProgressBar to register with the host.

    <ProgressBar Subscriber=this></ProgressBar>

# Timer

    public Timer Timer { get; set; }

The System.Timer Timer that is started when the Start method is called.

# Visible

    [Parameter]
    public bool Visible { get; set; }
    
This property sets the @Display value to either inline-block if true (visible), or none if false (invisible).

# Sprite Component

I created a new Sprite component that allows you to set properties for images.

# Sprite Methods

    # Init
    
    The Init method sets the Default values for the control
    
    # Start
    
    The Start method starts the Timer and sets the Elapsed event.
    
    # Stop
    
    Stops the timer and future messages.
    
I have another project planned for Animation called DataJuggler.Blazor.Animation. In that class I have speced out an AnimationManager in my mind, but for now I only create a Timer on one Sprite, and I use the Refresh messages to move Sprites around.

Eventually I would like this to be more automated where you give it a Start X,Y and an End X,Y position and a path could be firued out, but baby steps.

# Sprite Properties

Many of the properties are identical to the ProgressBar, only the differences are listed here.

# Height

    [Parameter]
    public int Height { get; set; }

The height in pixels.

# HeightPixels

    public string HeightPixels { get; set; }
    
This value is set by the setter for Height. The string px is appended to the end.

Example: Height: 80
HeightPixels: 80px.

# ImageUrl

    [Parameter]
    public string ImageUrl
    
 This value is set as the background image for the Div.

# Name
 
    [Parameter]
    public string Name
    
The name helps distinquish Sprites from other Sprites.

# Width

    [Parameter]
    public int Width { get; set; }
    
This property sets the WidthPixels property, which in turns sets the Width of the component.

# WidthPixels

    public string WidthPixels { get; set; }
    
This value is set when you set the Width property.

Example: <br>
Width: 900
WidthPixels: 900px;

## ComboBox Example

    <ComboBox Name="ComboBoxControl" Parent="this" Unit="px" Width="160" HeightUnit="vh" Height="3.6" LabelText="Select:" LabelWidth=54 ZIndex=20
        Left="10" Theme="ThemeEnum.Brown" LabelLeft="-16" LabelColor="Color.Black" ButtonTextColor="Color.LemonChiffon" ButtonLeft=36 ButtonTop=-2.8
        TextSize="TextSizeEnum.SmallMedium" ListItemLeft="56" ListItemTop="0"></ComboBox>




# ProgressBar
It took me 3 attempts to get a progress bar I actually like, and I owe to Percentage Circle CSS:

    CSS Percentage Circle
    Author: Andre Firchow
    
    http://circle.firchow.net/
    

    








