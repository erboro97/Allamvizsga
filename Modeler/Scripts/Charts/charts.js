

$(document).ready(function () {
    var settings = {
        userId: $('#UserId').val(),
        answers: null
    };
  
    var userIdNumber = Number(settings.userId);
    $.get("http://localhost:54231/api/Values/getValues/" + userIdNumber, function (data) {
        settings.answers = data;

        var chart = new Highcharts.Chart({
            chart: {
                renderTo: 'container1',
                type: 'spline',
            },

            xAxis: {
                reversed: false,
                title: {
                    enavled: true,
                    text: 'X'
                },
                labels: {
                    format: '{value} -'
                },
                showLastLabel: true
            },

            yAxis: {
                title: {
                    text: 'Y'
                },

                labels: {
                    format: '{value} '
                },
                lineWidth: 2
            },

            legend: {
                enabled: false
            },
            tooltip: {
                enabled: false,
                headerFormat: '<span style="font-size:11px">{point.key}</span><br>',
                pointFormat: '{series.name}: <b>{point.y:.1f}%</b> '
            },



            series: [{

                name: 'Segment',
                data: (function () {
                    var category = ['x'];
                    var mySeries = [];
                    myData = [data.r0.hr, data.r0.t];
                    for (var i = 0; i < myData[0].length; i++) {
                        mySeries.push([myData[1][i], myData[0][i]]);
                    }
                    

                    return mySeries;
                }())
            }
            ]
        })
        $('#button').click(function () {

            $.each(settings.answers, function (key, value) {
                if (key != "size") {
                    chart.addSeries({
                        name: key,
                        data: (function () {
                            var category = ['x'];
                            var mySeries = [];
                            myData = [value.hr, value.t];
                            for (var j = 0; j < myData[0].length; j++) {
                                mySeries.push([myData[1][j], myData[0][j]]);
                            }


                            return mySeries;
                        }())
                    })
                }
            })
          
        });
    })
   
 });



       

