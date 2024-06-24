$(document).ready(function () {
    $('body').on('Click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var TQuantity = $('#quantity_value').text();
        if (TQuantity != '') {
            quantity = parseInt(TQuantity);
            
        }
        alert(id + " " + quantity);
    });
});