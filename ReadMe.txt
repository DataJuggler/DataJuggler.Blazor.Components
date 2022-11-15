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


