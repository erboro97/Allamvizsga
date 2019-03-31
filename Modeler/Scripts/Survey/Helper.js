$('#surveyBtn').click(function () {
        document.location = '@Url.Action("HeartSurvey","Survey")';
});



$(document).ready(function () {
    $('.InputType').click(function () {
        if ($(this).attr("value") == "survey") {
            $(".surveyBox").show('slow');
            $(".textBox").hide('slow');
        }
        if ($(this).attr("value") == "textbox") {
            $(".textBox").show('slow');
            $(".surveyBox").hide('slow');
        }
    });
});
