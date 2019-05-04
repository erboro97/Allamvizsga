var DoctorChartHelper = (function () {
    var settings = {
        patients: null
    };

    function getPatients() {
        var d = $.Deferred();
        $.ajax({
            type: "GET",
            dataType: 'json',
            url: "http://localhost:54231/Survey/getPatients/",
            success: function (data) {
                var mySelect = $('#users');
                $.each(data, function (val, patient) {
                    mySelect.append(
                        $('<option></option>').val(patient.patientId).html(patient.patientName)
                    );
                });
            },
            error: function (data, error) {
                alert('Error in IsValidSurvey');
                d.fail();
            }
        });

        return d.promise();
    }

    function Init() {
        getPatients();
    }

    return {
        Init: Init
    }
 
}());



$(document).ready(function () {
    DoctorChartHelper.Init();
    var myOptions = {
        val1: 'text1',
        val2: 'text2'
    };
    
});