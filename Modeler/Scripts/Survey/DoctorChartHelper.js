$(document).ready(function () {
    var myOptions = {
        val1: 'text1',
        val2: 'text2'
    };
    var mySelect = $('#users');
    $.each(myOptions, function (val, text) {
        mySelect.append(
            $('<option></option>').val(val).html(text)
        );
    });
});