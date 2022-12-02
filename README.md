To see a live example, visit

Blazor Excelerate
https://excelerate.datajuggler.com

The code for the above site is available here:
https://github.com/DataJuggler/Blazor.Excelerate

The following components are in this project:

Getting Started:

One of my favorite things of this project is the DataJuggler.Blazor.Componets.css file.

After adding nuget package DataJuggler.Blazor.Componets Nuget package, add the folloing line to
your _layout.cshtml file in your Blazor project:

    <link href="~/_content/DataJuggler.Blazor.Components/css/DataJuggler.Blazor.Components.css" rel="stylesheet" />

View the full CSS here:
https://github.com/DataJuggler/DataJuggler.Blazor.Components/blob/master/wwwroot/css/DataJuggler.Blazor.Components.css

The CSS file has values to make it easy to position and style components.

CSS classes can be combined using spaces like:

<div class="width16 backgroundcolorskyblue marginleft8 down12"></div>

background(color name) 
Example: backgroundlemonchiffon
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

ValidationComponent

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

I will update this document and create new sample projects when I get time.

If you have any questions, please feel free to ask on Git Hub:
https://github.com/DataJuggler/DataJuggler.Blazor.Components/Issues




# DataJuggler.Blazor.Components
This class consists of an ImageButton, ProgressBar, Sprite, ValidationComponent and now a ComboBox.
I am working on a Grid.

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

And a live exmaple is here:
https://excelerate.datajuggler.com

Blazor Excelerate is used to code generate C# classes from an Excel header row.

--

The ValidationComponent is a multi-use component that allows you to build data entry
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
        // your UI can response to this message if needed. 
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

# BlazorStyled Setup
Blazor Styled is a great component and the code and documentation are available here:

https://github.com/chanan/BlazorStyled

Read the Server Side Install here for more information:

https://blazorstyled.io/server-side-install

Here are my paraphrase of the instructions for quick setup:
1. Add Nuget Package BlazorStyled to your project. It should be installed with DataJuggler.Blazor.Components, but it still may need to be installed. 
2. Open Startup.cs and in the ConfigureServices method, add this line:

    services.AddBlazorStyled();

3. Open Imports.razor and add the following:
@using DataJuggler.Blazor.Components
@using BlazorStyled

4. Open (underscore)Host.cshtml and add this line at the bottom of the Head section:
@(await Html.RenderComponentAsync<BlazorStyled.ServerSideStyled>(RenderMode.ServerPrerendered))

The documentation of BlazorStyled may still be out of date as Visual Studio changed RenderComponentAsync method since the BlazorStyled docs were written. I have been told this will be fixed.

That should be all thats required to get BlazorStyled configured. I will update this page if I can find a way to automate this part.

# Use Cases

For now, the progress bar is meant to show the user something is happening during a long running process.

The sample project demonstrates using a Timer and on every refresh the progress bar increases the fill width by the increment value
in pixels, up to the Max value. To use the timer, call the Start method on the Progress bar.
In theory, and I will update this once I know it works, you should also be able to manually increase the FillWidth value, which in turn sets the FillWidthPixels string value used by BlazorStyled.

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
    
This property is set on the BlazorStyled CSS Class for position. Fixed, Absolute and Relative are the 3 I know, there may be more.

# ProgressBackground

    public string ProgressBackground { get; set; }
    
This is the string property bound to the BlazorStyled styles for the ProgressBar div.
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

# SpriteStyle

    public string SpriteStyle { get; set; }
    
This property is used as the CSS class for BlazorStyle.

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

Most of the other properties should be the same as the ProgressBar.


# ProgressBar
It took me 3 attempts to get a progress bar I actually like, and I owe to Percentage Circle CSS:

    CSS Percentage Circle
    Author: Andre Firchow
    
    http://circle.firchow.net/
    

    








