// Write your Javascript code.
$(function () {
    $("#slider-range-1").slider({
        range: true,
        min: 0,
        max: 500,
        values: [0, 10],
        slide: function (event, ui) {
            $("#number1").val(ui.values[0] + " " + ui.values[1]);
        }
    });
    $("#number1").val($("#slider-range-1").slider("values", 0) +
        " " + $("#slider-range-1").slider("values", 1));

    $("#slider-range-2").slider({
        range: true,
        min: 0,
        max: 500,
        values: [0, 10],
        slide: function (event, ui) {
            $("#number2").val(ui.values[0] + " " + ui.values[1]);
        }
    });
    $("#number2").val($("#slider-range-2").slider("values", 0) +
        " " + $("#slider-range-2").slider("values", 1));


});
