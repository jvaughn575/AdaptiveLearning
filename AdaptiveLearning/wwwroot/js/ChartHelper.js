var Charts = (function () {
    
    var ctx = document.getElementById("myChart").getContext('2d');
    var SingleResultBarChart = function(data){
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: [...Array(data.length).keys()],
                datasets: [{
                    label: 'Placeholder Label',
                    data: data
                }]
            }
        });
    };

    var StackedResultLineChart = function (datas) {
        var labels_arr = [...Array(datas[0].data.length).keys()];
        console.log("LABELS", labels_arr);
        new Chart(ctx, {
            type: 'line',
            data: { labels: labels_arr, datasets: datas },
            options: {
                scales: {
                    yAxes: [{
                        //stacked: true
                    }]
                }
            }
        });
    };

    var StackedResultBarChart = function (datas) {
        var labels_arr = [...Array(datas[0].data.length).keys()];
        console.log("LABELS", labels_arr);
        new Chart(ctx, {
            type: 'bar',
            data: { labels: labels_arr, datasets: datas},
            options: {
                animation: {
                    duration: 10,
                },
                tooltips: {
                    mode: 'label',
                    callbacks: {
                        label: function (tooltipItem, data) {
                            //return data.datasets[tooltipItem.datasetIndex].label + ": " + numberWithCommas(tooltipItem.yLabel);
                        }
                    }
                },
                scales: {
                    xAxes: [{
                        //stacked: true,
                        gridLines: { display: false },
                    }],
                    yAxes: [{
                        //stacked: true,
                        ticks: {
                            //callback: function (value) { return numberWithCommas(value); },
                        },
                    }],
                }, // scales
                legend: { display: true }
            } // options
        }
        );
    };

    return {
        SingleResultBarChart: SingleResultBarChart,
        StackedResultBarChart: StackedResultBarChart,
        StackedResultLineChart: StackedResultLineChart,
    };
})();