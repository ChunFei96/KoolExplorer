//GLOBAL FUNCTIONS
var system = {
    createCookie: function (name, value, seconds) {
        if (seconds) {
            var date = new Date();
            date.setTime(date.getTime() + (seconds * 1000));
            var expires = "; expires=" + date.toGMTString();
        }
        else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    },

    readCookie: function (name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    },

    clearCookie: function (name) {
        var date = new Date();
        date.setTime(date.getTime() + 0);
        var expires = "; expires=" + date.toGMTString();
        document.cookie = name + "=" + "" + expires + "; path=/";
    },

    getQueryStringParamterByName: function (name) {
        var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
        return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
    }
}
SetCultureInfo();

function SetCultureInfo() {
    var country = "Singapore";
    var language = "EN";
    var isRedirect = false;
    if (window.location.href.toLowerCase().indexOf("/hk/en") > 0) {
        country = "Hong Kong";
        language = "EN";
        isRedirect = true;
        system.createCookie("country", "HK");
        system.createCookie("language", "EN");
    }
    else if (window.location.href.toLowerCase().indexOf("/hk/cn") > 0) {
        country = "Hong Kong";
        if (system.readCookie("language") == "ZH-HANS")
            language = "简";
        else if (system.readCookie("language") == "ZH-HANT")
            language = "繁";

        isRedirect = true;
        //system.createCookie("country", "HK");
        //system.createCookie("language", "CN");
    }
    else if (window.location.href.toLowerCase().indexOf("/sg/en") > 0) {
        country = "Singapore";
        language = "EN";
        isRedirect = true;
        system.createCookie("country", "SG");
        system.createCookie("language", "EN");
    }
    else if (system.readCookie("country") != null && system.readCookie("language") != null) {
        if (system.readCookie("country").toUpperCase() == "SG")
            country = "Singapore";
        else
            country = "Hong Kong";
        language = system.readCookie("language").toUpperCase();
        if (language == "ZH-HANS")
            language = "简";
        else if (language == "ZH-HANT")
            language = "繁";
    }
    if (country == "Hong Kong") {
        $("#home").addClass("home-hk");
        //$("#onepip-exchange").addClass("onepip-exchange-hk");
    }
    $("#country-language").html(country + " | " + language);
}


function SetLanguage(e) {
    var country = $(e).attr("data-country");
    var language = $(e).attr("data-lang");
    system.createCookie("country", country);
    system.createCookie("language", language);
    console.log(language);
} 