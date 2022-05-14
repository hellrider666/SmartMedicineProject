$(document).ready(function () {
    debugger;
    $('#OpenRecordsView').click(function (e) {
        $('#PartialViews').load('@Url.Action("PacientsInfo", "Recording")')
    });
});