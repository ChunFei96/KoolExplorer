


$(".validation-wizard").steps({
    headerTag: "h6"
    , bodyTag: "section"
    , transitionEffect: "fade"
    , titleTemplate: '<span class="step">#index#</span> #title#'
    , labels: {
        next: "Next",
        previous: "Back",
        finish: "Submit"
    },
    onInit: function (event, current) {
        
    }
    ,
onStepChanging: function (event, currentIndex, newIndex) {

    }
    , onStepChanged: function (event, currentIndex, previousIndex) {

    }

    , onFinishing: function (event, currentIndex) {

    }

    , onFinished: function (event, currentIndex) {

    }

}),

    $(".validation-wizard").validate({
        ignore: "input[type=hidden]"
        , errorClass: "text-danger"
        , successClass: "text-success"
        , highlight: function (element, errorClass) {
            $(element).removeClass(errorClass)
        }
        , unhighlight: function (element, errorClass) {
            $(element).removeClass(errorClass)
        }
        , errorPlacement: function (error, element) {
            error.insertAfter(element)
        }
        , rules: {
            email: {
                email: !0
            }
        }
    })

