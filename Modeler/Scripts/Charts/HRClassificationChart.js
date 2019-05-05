$(document).ready(function () {
    var settings = {
        userId: $('#UserId').val(),
        answers: null
    };

    var userIdNumber = Number(settings.userId);
    $.get("http://localhost:54231/api/Values/getHRValues/" + userIdNumber, function (data) {
        settings.answers = data;

        var chart = new Highcharts.Chart({
            chart: {
                polar: true,
                renderTo: 'hrContainer',
                type: 'line'

            },
            title: {
                text: 'Pulse values classifiction',
                align: 'left',
                x: 70
            },
            subtitle: {
                text: 'Stationary state of pulse',
                align: 'left',
                x: 70
            },
            xAxis: {
                categories: ['Normal', 'Low', 'High'],
                tickmarkPlacement: 'on',
                lineWidth: 0
            },

            yAxis: {
                gridLineInterpolation: 'polygon',
                lineWidth: 0,
                min: 0
            },

            tooltip: {
                enabled: true,
                headerFormat: '<span style="font-size:11px">{point.key} </span><br>',
                pointFormat: '{point.y} times '
            },
            

            series: [{

                name: 'Pulse classification',
                data: (function () {
                    var category = ['x'];
                    var mySeries = [];
                    myData = [data.hrs];
                    for (var i = 0; i < myData[0].length; i++) {
                        mySeries.push([myData[0][i]]);
                    }


                    return mySeries;
                }())

            }
            ]
        })

    })

});





