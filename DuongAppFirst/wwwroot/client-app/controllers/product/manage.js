var ProductManageController = function () {
    this.initialize = function () {
        registerEvents();
    }
    function registerEvents() {
        $('#btnAddToCart').on('click', function (e) {
            e.preventDefault();
            var id = parseInt($(this).data('id'));
            var quantity = parseInt($('#txtQuantity').val());
            if (quantity < 0) quantity = 0;
            var colorId = parseInt($('#ddlColorId').val());
            var sizeId = parseInt($('#ddlSizeId').val());
            $.ajax({
                url: '/Cart/AddToCart',
                type: 'post',
                dataType: 'json',
                data: {
                    productId: id,
                    quantity: quantity,
                    color: colorId,
                    size: sizeId
                },
                success: function () {
                    duong.notify('Product was added successful', 'success');
                    loadHeaderCart();
                }
            });
        });
        $('.btnAddToWishList').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                type: 'post',
                url: '/WishList/AddToWishList',
                dataType: 'json',
                data: {
                    productId: id
                },
                success: function (res) {
                    if (res.Success) {
                        duong.notify(res.Message, 'success');
                    }
                    else {
                        duong.notify(res.Message, 'warning');
                    }
                },
                error: function () {
                    duong.notify('An error occurred', 'error');
                }
            });
        });
    }
    function loadHeaderCart() {
        $("#headerCart").load("/AjaxContent/HeaderCart");
    }
}