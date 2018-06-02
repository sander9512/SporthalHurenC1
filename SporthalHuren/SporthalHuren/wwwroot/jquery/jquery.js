var dateToday = new Date();
$(function () {
    $(".date-picker").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "-0:+1", // You can set the year range as per as your need
        dateFormat: 'dd-M-yy',
        minDate: dateToday
    });
});

$(function () {
    $('.timepicker-starttime').timepicker({
        timeFormat: 'HH:mm',
        interval: 30,
        minTime: '08',
        maxTime: '21:00',
        defaultTime: '08',
        startTime: '08:00',
        dynamic: false,
        dropdown: true,
        scrollbar: true

    })



    $('.timepicker-endtime').timepicker({
    timeFormat: 'HH:mm',
    interval: 30,
    minTime: '08',
    maxTime: '22:00',
    defaultTime: '08',
    startTime: '08:00',
    showDuration: true,
    dynamic: false,
    dropdown: true,
    scrollbar: true
    })



$('.timepicker-starttime').on('changeTime', function () {
    $('timepicker.endtime').timepicker('option', 'startTime', $(this).val());
})

$('.timepicker-starttime').on('changeTime', function () {
    $('timepicker.endtime').timepicker('option', 'minTime', $(this).val());
})

});

