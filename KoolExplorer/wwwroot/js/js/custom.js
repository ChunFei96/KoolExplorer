

$(function () {
    "use strict";
    $(function () {
        if ($(document).width() < 1024) {
            $("section").removeClass("left-side-border");
            $(".languageBar").addClass("bg-white-transparent");
        }

        /* $(".preloader").fadeOut()*/
}), jQuery(document).on("click", ".mega-dropdown", function (i) {
        i.stopPropagation()
});
    var i = function () {
        var i = window.innerWidth > 0 ? window.innerWidth : this.screen.width,
            e = 70;
        1170 > i ? ($("body").addClass("mini-sidebar"), $(".navbar-brand span").hide(), $(".sidebartoggler i").addClass("ti-menu")) : ($("body").removeClass("mini-sidebar"), $(".navbar-brand span").show(), $(".sidebartoggler i").removeClass("ti-menu"));
        var s = (window.innerHeight > 0 ? window.innerHeight : this.screen.height) - 1;
        s -= e, 1 > s && (s = 1), s > e && $(".page-wrapper").css("min-height", s + "px")
    };
    setTimeout(function () { $(".preloader").hide(); }, 1000);
    if (window.location.href.toUpperCase().indexOf("BUSINESSANDINDIVIDUALS") >= 0 && $(document).width() >= 1024) {
        $(".languageBar").addClass("languageBarBorder");
        $(".languageBar").addClass("bg-white-transparent");
    }
    $(window).ready(i), $(window).on("resize", i), $(".sidebartoggler").on("click", function () {
        $("body").hasClass("mini-sidebar") ? ($("body").trigger("resize"), $(".scroll-sidebar, .slimScrollDiv").css("overflow", "hidden").parent().css("overflow", "visible"), $("body").removeClass("mini-sidebar"), $(".navbar-brand span").show(), $(".sidebartoggler i").addClass("ti-menu")) : ($("body").trigger("resize"), $(".scroll-sidebar, .slimScrollDiv").css("overflow-x", "visible").parent().css("overflow", "visible"), $("body").addClass("mini-sidebar"), $(".navbar-brand span").hide(), $(".sidebartoggler i").removeClass("ti-menu"))
    }), $(".fix-header .topbar").stick_in_parent({}), $(".nav-toggler").click(function () {
        $("body").toggleClass("show-sidebar"), $(".nav-toggler i").toggleClass("mdi mdi-menu"), $(".nav-toggler i").addClass("mdi mdi-close")
    }), $(".search-box a, .search-box .app-search .srh-btn").on("click", function () {
        $(".app-search").toggle(200)
    }), $("html").click(function (e) {
        if (e.target.className.indexOf("right-side-toggle") < 0 && $(".shw-lside").length == 1) { $(".right-sidebar").slideDown(50), $(".right-sidebar").toggleClass("shw-lside") }
    }), $(window).scroll(function () {
        if ($(document).width() >= 1024) {
            if ($('.starter').offset().top - $(window).scrollTop() <= 150) {
                $(".languageBar").addClass("languageBarBorder");
                $(".languageBar").addClass("bg-white-transparent");
            }
            else {
                $(".languageBar").removeClass("languageBarBorder");
                $(".languageBar").removeClass("bg-white-transparent");

            }

            if ($('#OPXA').offset().top - $(window).scrollTop() <= 150) {
                $("#OurRates #video_banner").css("opacity", "0");
            }
            else {
                $("#OurRates #video_banner").css("opacity", "1");
            }

            $("body").find("section").each(function () {
                if (!$(this).hasClass("left-side-border")) {
                    if ($(this).offset().top - $(window).scrollTop() <= 145) {
                        $("section").removeClass("left-side-border");
                        $(this).addClass("left-side-border");
                    }

                }
            });
        }
        else {
            //FOR OPX USER GUIDE DOCK
            if (window.location.href.toUpperCase().indexOf("OPXUSERGUIDE") >= 0) {
                console.log($("#opxfeature_1_step").offset().top - $(".dock_new_client").offset().top);
                if ($("#newclient_1_step").offset().top - $(".languageBar ").offset().top <= 500) {
                    $("#OPXGuideNagivator").show();
                }
                else {
                    $("#OPXGuideNagivator").hide();
                }


                if ($("#newclient_1_step").offset().top - $(".languageBar").offset().top <= 100) {
                    if ($("#newclient_4_step").offset().top - $(".dock_new_client").offset().top <= 400) {
                        $(".dock_new_client").removeClass("hidden-xs hidden-sm");
                        $(".dock_existing_client").addClass("hidden-xs hidden-sm");
                        $(".dock_features").addClass("hidden-xs hidden-sm");
                        $(".dock_money_transfer").addClass("hidden-xs hidden-sm");
                    }
                    if ($("#existingclient_1_step").offset().top - $(".languageBar").offset().top <= 400) {
                        $(".dock_new_client").addClass("hidden-xs hidden-sm");
                        $(".dock_existing_client").removeClass("hidden-xs hidden-sm");
                        $(".dock_features").addClass("hidden-xs hidden-sm");
                        $(".dock_money_transfer").addClass("hidden-xs hidden-sm");
                    }
                    else {
                        $(".dock_new_client").removeClass("hidden-xs hidden-sm");
                        $(".dock_existing_client").addClass("hidden-xs hidden-sm");
                        $(".dock_features").addClass("hidden-xs hidden-sm");
                        $(".dock_money_transfer").addClass("hidden-xs hidden-sm");
                    }

                    if ($("#opxfeature_1_step").offset().top - $(".languageBar").offset().top <= 400) {
                        $(".dock_new_client").addClass("hidden-xs hidden-sm");
                        $(".dock_existing_client").addClass("hidden-xs hidden-sm");
                        $(".dock_features").removeClass("hidden-xs hidden-sm");
                        $(".dock_money_transfer").addClass("hidden-xs hidden-sm");
                    }
                    if ($("#opxmoneytransfer_1_step").offset().top - $(".languageBar").offset().top <= 400) {
                        $(".dock_new_client").addClass("hidden-xs hidden-sm");
                        $(".dock_existing_client").addClass("hidden-xs hidden-sm");
                        $(".dock_features").addClass("hidden-xs hidden-sm");
                        $(".dock_money_transfer").removeClass("hidden-xs hidden-sm");
                    }
                }
                else {
                    $("#OPXNewClient").removeClass("dock");
                }
            }
        }
    }), $(".right-side-toggle").click(function () {
        $(".right-sidebar").slideDown(50), $(".right-sidebar").toggleClass("shw-lside")
    }), $(".floating-labels .form-control").on("focus blur", function (i) {
        $(this).parents(".form-group").toggleClass("focused", "focus" === i.type || this.value.length > 0)
    }).trigger("blur"), $(function () {
        for (var i = window.location, e = $("ul#sidebarnav a").filter(function () {
            return this.href == i
        }).addClass("active").parent().addClass("active"); ;) {
            if (!e.is("li")) break;
            e = e.parent().addClass("in").parent().addClass("active")
        }
    }), $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    }), $(function () {
        $('[data-toggle="popover"]').popover()
    }), $(function () {
        $("#sidebarnav").metisMenu()
    }), $(".message-center").slimScroll({
        position: "right",
        size: "5px",
        color: "#dcdcdc"
    }), $(".aboutscroll").slimScroll({
        position: "right",
        size: "5px",
        height: "80",
        color: "#dcdcdc"
    }), $(".message-scroll").slimScroll({
        position: "right",
        size: "5px",
        height: "570",
        color: "#dcdcdc"
    }), $(".chat-box").slimScroll({
        position: "right",
        size: "5px",
        height: "470",
        color: "#dcdcdc"
    }), $(".slimscrollright").slimScroll({
        height: "100%",
        position: "right",
        size: "5px",
        color: "#dcdcdc"
    }), $("body").trigger("resize"), $(".list-task li label").click(function () {
        $(this).toggleClass("task-done")
    }), $("#to-recover").on("click", function () {
        $("#loginform").slideUp(), $("#recoverform").fadeIn()
    }), $('a[data-action="collapse"]').on("click", function (i) {
        i.preventDefault(), $(this).closest(".card").find('[data-action="collapse"] i').toggleClass("ti-minus ti-plus"), $(this).closest(".card").children(".card-body").collapse("toggle")
    }), $('a[data-action="expand"]').on("click", function (i) {
        i.preventDefault(), $(this).closest(".card").find('[data-action="expand"] i').toggleClass("mdi-arrow-expand mdi-arrow-compress"), $(this).closest(".card").toggleClass("card-fullscreen")
    }), $('a[data-action="close"]').on("click", function () {
        $(this).closest(".card").removeClass().slideUp("fast")
    })
});