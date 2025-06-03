window.BlazorJSFunctions = {
    ShowPrompt: function (message) {
        return prompt(message, 'Type anything here');
    },

    CopyText: function (text) {
        let returnValue = 0;
        try {
            navigator.clipboard.writeText(text);
            returnValue = 1;
        } catch (err) {
            returnValue = -2;
        }
        return returnValue;
    },
    ShowElement: function (elementId) {
        const element = document.getElementById(elementId);
        if (!element) {
            console.error(`No element found with id ${elementId}`);
            return;
        }
        element.style.display = "block";
        element.style.opacity = 1;
    },
    HideElement: function (elementId) {
        const element = document.getElementById(elementId);
        if (!element) {
            console.error(`No element found with id ${elementId}`);
            return;
        }
        element.style.display = "none";
    },
    ShowThenHide: function (elementId, duration) {
        const element = document.getElementById(elementId);
        if (!element) {
            console.error(`No element found with id ${elementId}`);
            return;
        }
        element.style.display = "block";
        element.style.opacity = 1;
        setTimeout(() => {
            const element2 = document.getElementById(elementId);
            if (!element2) {
                console.error(`No element found with id ${elementId}`);
                return;
            }
            element2.style.display = "none";
        }, duration);
    },
    SetCookie: function (name, value, days) {
        const expires = new Date(Date.now() + days * 86400000).toUTCString();
        document.cookie = `${name}=${value}; expires=${expires}; path=/`;
    },
    GetCookie: function (name) {
        const match = document.cookie.match(new RegExp('(^| )' + name + '=([^;]+)'));
        return match ? match[2] : '';
    },
    DeleteCookie: function (name) {
        document.cookie = `${name}=; Max-Age=0; path=/`;
    }
};