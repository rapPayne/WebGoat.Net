$(document).ready(function () {
    $('#cartTable .quantityInput').change(function () {
        updateOrder();
    });
});
function updateOrder() {
    var cart = new Array();
    var rows = $('#cartTable').find('tr.itemRow').each(function () {
        var productId = $(this).find('td.productId').html();
        var newQuantity = $(this).find('td input.quantityInput').val();
        $(this).find('td.extendedPrice').html("Calculating...");
        console.log('Found a row ' + productId.toString() + ' ' + newQuantity.toString());
        cart.push({ "productId": productId, "quantity": newQuantity });
    });
    $.ajax({
        type: "POST",
        url: "http://localhost:7777/API/OrderService.svc/HelloWorld",
        data: cart,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            console.log(data);
            console.log(textStatus);
            console.log(jqXHR);
        },
        failure: function (data) {
            console.log("fail");
        }
    });
    console.log(JSON.stringify(cart));
}