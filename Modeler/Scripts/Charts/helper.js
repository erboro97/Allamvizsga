var helper = (function () {
    var settings = {
        userId: $('#UserId').val(),
        answers: null
    };

    function DisplayCorrespondingDiv(lambda) {
        if (lambda <= 0.3) {
            $('#explanation1').show();
        }
        else {
            if (lambda <= 0.6) {
                $('#explanation2').show();
            }
            else {
                $('#explanation3').show();
            }
        }
    }

    function GetLambdaValue(userId) {
        var d = $.Deferred();
        $.ajax({
            type: "GET",
            dataType: 'json',
            url: "http://localhost:54231/api/Values/getLastLambdaValue/" + userId,
            success: function (data) {
                DisplayCorrespondingDiv(data);
                d.resolve();
            },
            error: function (data, error) {
                alert('Error in IsValidSurvey');
                d.fail();
            }
        });

        return d.promise();
    }

    function Init(userId) {
        GetLambdaValue(userId);
    }
    return {
        Init: Init
    }
}());

$(document).ready(function () {
    userId = $('#UserId').val();
    helper.Init(userId);
});