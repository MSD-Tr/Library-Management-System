$(document).ready(function () {
    $(":input[date-picker]").datepicker({
        dateFormat: "yy/mm/dd",
    });
    $(":input[datetime-picker]").datetimepicker({
        dateFormat: "yy/mm/dd",
        timeFormat: "HH:mm:ss",
    });
    $(":input[time-picker]").timepicker({
        timeFormat: "HH:mm:ss"
    });
})