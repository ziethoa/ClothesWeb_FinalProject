$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quatity = 1;
        var TQuantity = $('#quantity_value').text();
        if (TQuantity != '') {
            quatity = parseInt(TQuantity);

        }
       // alert(id + " " + quatity);
        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',
            data: { id: id, quantity: quatity },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.count);
                    alert(rs.msg);
                }
            }
        });
    });

    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn có chắc muốn xoá sản phẩm này khỏi giỏ hàng không ???');
        if (conf == true) {
            $.ajax({
                url: '/shoppingcart/Delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }
        
    });

    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn có chắc muốn xoá toàn bộ sản phẩm trong giỏ hàng không ???');
        if (conf == true) {
            DeleteAll();
        }

    });

    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data("id");
        var quantity = $('#Quantity_' + id).val();
        Update(id, quantity);
    });
});

function ShowCount() {
    $.ajax({
        url: '/shoppingcart/ShowCount',
        type: 'GET',
        success: function (rs) {
            if (rs.Success) {
                $('#checkout_items').html(rs.count);
            }
        }
    });
}

function Update(id, quantity) {
    $.ajax({
        url: '/shoppingcart/Update',
        type: 'POST',
        data: { id:id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function DeleteAll() {
    $.ajax({
        url: '/shoppingcart/DeleteAll',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function LoadCart() {
    $.ajax({
        url: '/shoppingcart/Partial_Item_Cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}