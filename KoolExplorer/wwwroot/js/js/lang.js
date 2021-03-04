var cookieDuration = 86400;
var translate = function (jsdata) {
    
    $("[data-lang]").each(function (index) {
        var value = jsdata[$(this).attr('data-lang')];
        $(this).html(value);
    });

    $("[data-lang-placeholder]").each(function (index) {
        var value = jsdata[$(this).attr('data-lang-placeholder')];
        $(this).attr("placeholder", value);
    });
}

function langTranslate() {
    if (system.readCookie("lang") != null && system.readCookie("lang") != "") {
        $.getJSON('/languages/' + system.readCookie("lang") + '.json', translate);
        $(".lang").css("display","none");
        $("." + system.readCookie("lang")).css("display", "block");
        $(".selectLanguage option[value='" + system.readCookie("lang").trim() + "']").prop('selected', true);
    }
    else {
        system.createCookie("lang", "en", cookieDuration);
        $.getJSON('/languages/en.json', translate);
        $(".lang").css("display", "none");
        $(".en").css("display", "block");
        $(".selectLanguage option[value='" + "en" + "']").prop('selected', true);
    }

}