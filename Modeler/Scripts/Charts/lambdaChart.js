

$(document).ready(function () {
    var settings = {
        userId: $('#UserId').val(),
        answers: null
    };

    var userIdNumber = Number(settings.userId);
    $.get("http://localhost:54231/api/Values/getLambdaValues/" + userIdNumber, function (data) {
        settings.answers = data;

        var chart = new Highcharts.Chart({
            chart: {
                renderTo: 'container',
                type: 'area',
              
            },

            title: {
                text: 'Cardiovascular state ',
                align: 'left',
                x: 70
            },
            
            xAxis: {
              
            },

            yAxis: {
                
            },

            legend: {
                enabled: true
            },
            tooltip: {
                enabled: true,
                headerFormat: '<span style="font-size:11px">{point.key}</span><br>',
                pointFormat: '{series.name}: <b>{point.y:.1f}%</b> '
            },

            area: {
                pointStart: 0,
                marker: {
                    enabled: false,
                    symbol: 'circle',
                    radius: 2,
                    states: {
                        hover: {
                            enabled: true
                        }
                    }
                }
            },

            series: [{

                name: 'Cardiovascular state',
                data: (function () {
                    var category = ['x'];
                    var mySeries = [];
                    myData = [data.lambda];
                    for (var i = 0; i < myData[0].length; i++) {
                        mySeries.push([myData[0][i]]);
                    }


                    return mySeries;
                }()),
               
                zones: [{
                    value: 0.33,
                    color: '#f7a35c'
                }, {
                    value: 0.66,
                    color: '#FFFF00'
                }, {
                    color: '#90ed7d'
                }]
            }
            ]
        })
      
    })

});





