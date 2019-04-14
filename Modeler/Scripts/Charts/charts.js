

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
                    myData = [data.r0.t, data.r0.v];
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
                        myData = [data.r1.t, data.r1.v];
                        for (var i = 0; i < myData[0].length; i++) {
                            mySeries.push([myData[1][i], myData[0][i]]);
                        }


                        return mySeries;
                    }())
                }
            ]
        })
        $('#button').click(function () {

            //for (var i = 2; i < settings.answers.size; i++) {
            //    chart.addSeries({
            //        name: 'Segment' + i,
            //        data: (function (i) {
            //            var category = ['x'];
            //            var mySeries = [];
            //            myData = [eval("settings.answers.t" + i), eval("settings.answers.x"+i)];
            //            for (var j = 0; j < myData[0].length; j++) {
            //                mySeries.push([myData[1][j], myData[0][j]]);
            //            }


            //            return mySeries;
            //        }())
            //    })
             
            //}

            $.each(settings.answers, function (key, value) {
                if (key != "size") {
                    chart.addSeries({
                        name: key,
                        data: (function () {
                            var category = ['x'];
                            var mySeries = [];
                            myData = [value.t, value.v];
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



       

