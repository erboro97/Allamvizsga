var DoctorChartHelper = (function () {
    var settings = {
        patients: null,
        patientId: 2
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
        $('#goToCharts').click(function () {
            settings.patientId = $("#users").children("option").filter(":selected").val();
            window.location.href = "http://localhost:54231/Chart/RedirectUserType?userId=" + settings.patientId;

        });
       
            
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