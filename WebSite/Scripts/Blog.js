$(document).ready(function () {

    $('.blogRespondButton').click(function () {
        var blogEntryId = $(this).attr("data-BlogEntryId");
        window.location.href = '/Blog/Reply/' + blogEntryId.toString();
    });
});