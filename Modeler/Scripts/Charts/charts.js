﻿
//var container = document.createElement('div');
//document.body.appendChild(container);

//window.chart = new Highcharts.Chart({
//    chart: {
//        renderTo: container,
//        height: 400
//    },
//    xAxis: {
//        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
//    },

//    series: [{
//        data: [29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4]
//    }]
//});

//var container2 = document.createElement('div');
//document.body.appendChild(container2);
//window.chart = new Highcharts.Chart({
//        chart: {
//            type: 'area',
//            renderTo: container2
//        },
//        title: {
//            text: 'US and USSR nuclear stockpiles'
//        },
//        subtitle: {
//            text: 'Sources: <a href="https://thebulletin.org/2006/july/global-nuclear-stockpiles-1945-2006">' +
//                'thebulletin.org</a> &amp; <a href="https://www.armscontrol.org/factsheets/Nuclearweaponswhohaswhat">' +
//                'armscontrol.org</a>'
//        },
//        xAxis: {
//            allowDecimals: false,
//            labels: {
//                formatter: function () {
//                    return this.value; // clean, unformatted number for year
//                }
//            }
//        },
//        yAxis: {
//            title: {
//                text: 'Nuclear weapon states'
//            },
//            labels: {
//                formatter: function () {
//                    return this.value / 1000 + 'k';
//                }
//            }
//        },
//        tooltip: {
//            pointFormat: '{series.name} had stockpiled <b>{point.y:,.0f}</b><br/>warheads in {point.x}'
//        },
//        plotOptions: {
//            area: {
//                pointStart: 1940,
//                marker: {
//                    enabled: false,
//                    symbol: 'circle',
//                    radius: 2,
//                    states: {
//                        hover: {
//                            enabled: true
//                        }
//                    }
//                }
//            }
//        },
//        series: [{
//            name: 'USA',
//            data: [
//                null, null, null, null, null, 6, 11, 32, 110, 235,
//                369, 640, 1005, 1436, 2063, 3057, 4618, 6444, 9822, 15468,
//                20434, 24126, 27387, 29459, 31056, 31982, 32040, 31233, 29224, 27342,
//                26662, 26956, 27912, 28999, 28965, 27826, 25579, 25722, 24826, 24605,
//                24304, 23464, 23708, 24099, 24357, 24237, 24401, 24344, 23586, 22380,
//                21004, 17287, 14747, 13076, 12555, 12144, 11009, 10950, 10871, 10824,
//                10577, 10527, 10475, 10421, 10358, 10295, 10104, 9914, 9620, 9326,
//                5113, 5113, 4954, 4804, 4761, 4717, 4368, 4018
//            ]
//        }, {
//            name: 'USSR/Russia',
//            data: [null, null, null, null, null, null, null, null, null, null,
//                5, 25, 50, 120, 150, 200, 426, 660, 869, 1060,
//                1605, 2471, 3322, 4238, 5221, 6129, 7089, 8339, 9399, 10538,
//                11643, 13092, 14478, 15915, 17385, 19055, 21205, 23044, 25393, 27935,
//                30062, 32049, 33952, 35804, 37431, 39197, 45000, 43000, 41000, 39000,
//                37000, 35000, 33000, 31000, 29000, 27000, 25000, 24000, 23000, 22000,
//                21000, 20000, 19000, 18000, 18000, 17000, 16000, 15537, 14162, 12787,
//                12600, 11400, 5500, 4512, 4502, 4502, 4500, 4500
//            ]
//        }]
//    });

$(document).ready(function () {
    $.get("http://localhost:54231/api/Values/getValues", function (data) {
        var chart = new Highcharts.Chart({
            chart: {
                renderTo: 'container',
                type: 'line'
            },
            colors: ['#1986C4', '#7DBD3B'],

            title: {
                text: 'Neme',
                style: {
                    color: '#C0C0C0'
                },
                fontSize: "18px"
            },

        

           
            credits: false,
            tooltip: {
                enabled: false,
                headerFormat: '<span style="font-size:11px">{point.key}</span><br>',
                pointFormat: '{series.name}: <b>{point.y:.1f}%</b> '
            },



            series: [{
                size: '100%',
                showInLegends: false,
                name: 'Segment',
                data: (function () {
                    var mySeries = [];
                    myData = [];
                    myData.push(data.x);
                    mySeries.push(data.x);
                    return mySeries;
                }())
            }]


        },
      

       
        function (chart) { // on complete

            var xpos = '50%';
            var ypos = '53%';
            var circleradius = 102;

            // Render the circle
            chart.renderer.circle(xpos, ypos, circleradius).attr({
                fill: 'none'
            }).add();

            // Render the text
            var inner_text = '<p>Teszt</p><br>';
            myData[0] = parseFloat(myData[0]);
            var inner_text1 = "<p><b>".concat(myData[0]).concat("%</b></p>");
            chart.renderer.text(inner_text, 130, 165).css({
                width: circleradius * 2,
                color: 'grey',
                fontSize: '25px',
                textAlign: 'center'
            }).attr({
                // why doesn't zIndex get the text in front of the chart?

                zIndex: 999
            }).add();

            chart.renderer.text(inner_text1, 120, 197).css({
                width: circleradius * 2,
                color: 'black',
                formatter: "{point.y:.1f}",
                fontSize: '25px',
                textAlign: 'center'
            }).attr({
                // why doesn't zIndex get the text in front of the chart?

                zIndex: 999
            }).add();
        });


    });
});
