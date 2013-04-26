$(document).ready(function () {
    $("#clickjack").fadeTo('fast', 0.0);
    $("#showClickjack").removeAttr('checked');

    $("#showClickjack").click(function () {
        $('#showClickjack').is(':checked') ? $("#clickjack").fadeTo('slow', 0.5) : $("#clickjack").fadeTo('slow', 0.0);
    });
});