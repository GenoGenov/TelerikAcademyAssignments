function onCheckBrowserButtonClick(event, args) {
    'use strict';
    var myWindow = window,
        navigator = myWindow.navigator.appCodeName,
        isMozilla = navigator === "Mozilla";
    if (isMozilla) {
        alert("The browser is Mozilla.");
    } else {
        alert("The browser is not Mozilla.");
    }
}