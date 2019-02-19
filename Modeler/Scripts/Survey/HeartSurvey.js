var HeartSurvey = (function () {
  
    var settings = {
        ApiBaseUrl: $("#ApiBaseUrl").val()

    };

    function HeartSurvey() {
        var d = $.Deferred();
        $.ajax({
            type: "GET",
            dataType: 'json',
            url: "http://localhost:58465/api/survey/heartSurvey",
            success: function (data) {

                d.resolve();
            },
            error: function (data, error) {
                alert('Error in IsValidSurvey');
                d.fail();
            }
        });

        return d.promise();
    }

    function Init() {



        $(document).on({
            ajaxStart: function (q1, q2, q3) {
               
            },
            ajaxStop: function () {
                
                $(window).trigger("resize");
            }
        });
        HeartSurvey();


    }

    return {
        Init: Init
    }
}());

$(document).ready(function () {
    HeartSurvey.Init();
});