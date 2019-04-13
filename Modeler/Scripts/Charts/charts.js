

$(document).ready(function () {
    var settings = {
        userId : $('#UserId').val()
    };
    var userIdNumber = Number(settings.userId);
    $.get("http://localhost:54231/api/Values/getValues", function (data) {
        var chart = new Highcharts.Chart({
            chart: {
                renderTo: 'container',
                type: 'spline',
                inverted: true
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
                    myData = [data.t0, data.x0];
                    for (var i = 0; i < myData[0].length; i++) {
                        mySeries.push([myData[1][i], myData[0][i]]);
                    }
                    

                    return mySeries;
                }())
            },
                {
                    name: 'Segment1',
                    data: (function () {
                        var category = ['x'];
                        var mySeries = [];
                        myData = [data.t1, data.x1];
                        for (var i = 0; i < myData[0].length; i++) {
                            mySeries.push([myData[1][i], myData[0][i]]);
                        }


                        return mySeries;
                    }())
                }
            ]
        })
   })
 });
      

       

