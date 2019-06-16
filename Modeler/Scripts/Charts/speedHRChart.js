﻿/*
The purpose of this demo is to demonstrate how multiple charts on the same page
can be linked through DOM and Highcharts events and API methods. It takes a
standard Highcharts config with a small variation for each data set, and a
mouse/touch event handler to bind the charts together.
*/


/**
 * In order to synchronize tooltips and crosshairs, override the
 * built-in events with handlers defined on the parent element.
 */
$(document).ready(function () {
    var settings = {
        userId: $('#UserId').val(),
        answers: null
    };
['mousemove', 'touchmove', 'touchstart'].forEach(function (eventType) {
    document.getElementById('container').addEventListener(
        eventType,
        function (e) {
            var chart,
                point,
                i,
                event;

            for (i = 0; i < Highcharts.charts.length; i = i + 1) {
                chart = Highcharts.charts[i];
                // Find coordinates within the chart
                event = chart.pointer.normalize(e);
                // Get the hovered point
                point = chart.series[0].searchPoint(event, true);

                if (point) {
                    point.highlight(e);
                }
            }
        }
    );
});

/**
 * Override the reset function, we don't need to hide the tooltips and
 * crosshairs.
 */
Highcharts.Pointer.prototype.reset = function () {
    return undefined;
};

/**
 * Highlight a point by showing tooltip, setting hover state and draw crosshair
 */
Highcharts.Point.prototype.highlight = function (event) {
    event = this.series.chart.pointer.normalize(event);
    this.onMouseOver(); // Show the hover marker
    this.series.chart.tooltip.refresh(this); // Show the tooltip
    this.series.chart.xAxis[0].drawCrosshair(event, this); // Show the crosshair
};

/**
 * Synchronize zooming through the setExtremes event handler.
 */
function syncExtremes(e) {
    var thisChart = this.chart;

    if (e.trigger !== 'syncExtremes') { // Prevent feedback loop
        Highcharts.each(Highcharts.charts, function (chart) {
            if (chart !== thisChart) {
                if (chart.xAxis[0].setExtremes) { // It is null while updating
                    chart.xAxis[0].setExtremes(
                        e.min,
                        e.max,
                        undefined,
                        false,
                        { trigger: 'syncExtremes' }
                    );
                }
            }
        });
    }
}

// Get the data. The contents of the data file can be viewed at
    Highcharts.ajax({
        url: 'http://localhost:54231/api/Values/speedHRValues/' + settings.userId,
    dataType: 'text',
    success: function (activity) {

        activity = JSON.parse(activity);
        activity.datasets = JSON.parse(JSON.stringify(activity.datasets));
        for (var i = 0; i < 2;i++){

            // Add X values
            activity.datasets[i].data = Highcharts.map(activity.datasets[i].data, function (val, j) {
                return [activity.xData[j], val];
            });

            var chartDiv = document.createElement('div');
            chartDiv.className = 'chart';
            document.getElementById('container').appendChild(chartDiv);

            Highcharts.chart(chartDiv, {
                chart: {
                    marginLeft: 40, // Keep all charts left aligned
                    spacingTop: 20,
                    spacingBottom: 20
                },
                title: {
                    text: activity.datasets[i].name,
                    align: 'left',
                    margin: 0,
                    x: 30
                },
                credits: {
                    enabled: false
                },
                legend: {
                    enabled: false
                },
                xAxis: {
                    crosshair: true,
                    events: {
                        setExtremes: syncExtremes
                    },
                    labels: {
                        format: '{value} s'
                    }
                },
                yAxis: {
                    title: {
                        text: null
                    }
                },
                tooltip: {
                    positioner: function () {
                        return {
                            // right aligned
                            x: this.chart.chartWidth - this.label.width,
                            y: 10 // align to title
                        };
                    },
                    borderWidth: 0,
                    backgroundColor: 'none',
                    pointFormat: '{point.y}',
                    headerFormat: '',
                    shadow: false,
                    style: {
                        fontSize: '18px'
                    },
                    valueDecimals: activity.datasets[i].valueDecimals
                },
                series: [{
                    data: activity.datasets[i].data,
                    name: activity.datasets[i].name,
                    type: activity.datasets[i].type,
                    color: Highcharts.getOptions().colors[i],
                    fillOpacity: 0.3,
                    tooltip: {
                        valueSuffix: ' ' + activity.datasets[i].unit
                    }
                }]
            });
        };
    }
});

//$.get("http://localhost:54231/api/Values/getHRValues/" + userIdNumber, function (data) {
//    settings.answers = data;

//    var chart = new Highcharts.Chart({
//        chart: {
//            marginLeft: 40, // Keep all charts left aligned
//            spacingTop: 20,
//            spacingBottom: 20

//        },
//        title: {
//            text: 'Pulse values classifiction',
//            align: 'left',
//            x: 70
//        },
//        subtitle: {
//            text: 'Stationary state of pulse',
//            align: 'left',
//            x: 70
//        },
//        credits: {
//            enabled: false
//        },
//        legend: {
//            enabled: false
//        },
//        xAxis: {
//                    crosshair: true,
//                    events: {
//                       setExtremes: syncExtremes
//                    },
//                   labels: {
//                        format: '{value}'
//                    }
//             },
//        yAxis: {
//            title: {
//                text: null
//            }
//        },

//          tooltip: {
//                    positioner: function () {
//                        return {
//                            // right aligned
//                            x: this.chart.chartWidth - this.label.width,
//                            y: 10 // align to title
//                        };
//                    },
//                    borderWidth: 0,
//                    backgroundColor: 'none',
//                    pointFormat: '{point.y}',
//                    headerFormat: '',
//                    shadow: false,
//                    style: {
//                        fontSize: '18px'
//                    },
//                    valueDecimals: dataset.valueDecimals
//                },

//        series: [{

//            name: 'Pulse classification',
//            data: (function () {
//                var category = ['x'];
//                var mySeries = [];
//                myData = [data.hrs];
//                for (var i = 0; i < myData[0].length; i++) {
//                    mySeries.push([myData[0][i]]);
//                }


//                return mySeries;
//            }())

//        }
//        ]
//    })

    //})
});