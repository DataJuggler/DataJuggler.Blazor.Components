// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.BlazorJSFunctions =
{
    ShowPrompt: function (message)
    {
        return prompt(message, 'Type anything here');
    },   
    CopyText: function (text)
    {
        // original value
        var returnValue = 0;

        try
        {
            navigator.clipboard.writeText(text);

            // set to 1;
            returnValue = 1;
        }
        catch (err)
        {
            returnValue = -2;
        }  

        // return value
        return returnValue;
    },
    ShowElement: function (elementId)
    {
        const element = document.getElementById(elementId);
        if (!element)
        {
            console.error(`No element found with id ${elementId}`);
            return;
        }

        element.style.display = "block"; // Make the element visible
        element.style.opacity = 1; // Ensure the element is fully opaque
    },    
    HideElement: function (elementId)
    {
        const element = document.getElementById(elementId);
        if (!element)
        {
            console.error(`No element found with id ${elementId}`);
            return;
        }

        element.style.display = "none"; // Hide the element
    },    
    ShowThenHide: function (elementId, duration)
    {
        BlazorJSFunctions.ShowElement(elementId); // Show the element

        setTimeout(() =>
        {
            BlazorjSFunctions.HideElement(elementId); // Hide the element after the duration
        }, duration);
    }
};
