var WishListController = function () {
    this.initialize = function () {
        registerEvents();
        loadData();
    }
    function registerEvents() {
        $('body').on('click', '.btnAddToCart', function (e) {
            e.preventDefault();
            var id = parseInt($(this).data('id'));
            console.log(id);
            $.ajax({
                url: '/Cart/AddToCart',
                type: 'post',
                dataType: 'json',
                data: {
                    productId: id,
                    quantity: 1,
                },
                success: function () {
                    duong.notify('Product was added successful', 'success');
                    $.ajax({
                        url: '/WishList/RemoveFromWishList',
                        type: 'post',
                        data: {
                            productId: id
                        },
                        beforeSend: function () {
                            duong.startLoading();
                        },
                        success: function () {
                            duong.stopLoading();
                            loadData();
                        },
                        error: function () {
                            duong.notify('An error occurred', 'error')
                        }
                    });
                    loadHeaderCart();
                }
            });
        });
        $('body').on('click', '.btnDelete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $.ajax({
                url: '/WishList/RemoveFromWishList',
                type: 'post',
                data: {
                    productId: that
                },
                beforeSend: function () {
                    duong.startLoading();
                },
                success: function () {
                    duong.notify('Successfully deleted', 'success');
                    duong.stopLoading();
                    loadData();
                },
                error: function () {
                    duong.notify('An error occurred', 'error')
                }
            });
        });
    }
    function loadData() {
        $.ajax({
            url: '/WishList/GetWishListDetails',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                var template = $('#template-wish').html();
                var render = "";
                $.each(response, function (i, item) {
                    render += Mustache.render(template,
                        {
                            ProductId: item.Product.Id,
                            Image: item.Product.Image,
                            ProductName: item.Product.Name,
                            Status: duong.getStatus(item.Product.Status),
                            Price: duong.formatNumber(item.Price, 0),
                            Url: '/' + item.Product.SeoAlias + "-p." + item.Product.Id + ".html"
                        });
                });
                if (render !== "")
                    $('#table-wishlist-content').html(render);
                else
                    $('table-wishlist-content').html('You have no product in wishlist');
            }
        });
        return false;
    }
    function loadHeaderCart() {
        $("#headerCart").load("/AjaxContent/HeaderCart");
    }
}