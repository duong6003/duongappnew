var CartController = function () {
    var cachedObj = {
        colors: [],
        sizes: [],
    }
    this.initialize = function () {
        $.when(loadColors(),
            loadSizes())
            .then(function () {
                loadData();
            });

        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.classify', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var selector = '.classify-wrap-' + id;
            $(selector).toggleClass('show-classify');
        });
        $('body').on('click', '.btnDelete', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: '/Cart/RemoveFromCart',
                type: 'post',
                data: {
                    productId: id
                },
                beforeSend: function () {
                    duong.startLoading();
                },
                success: function () {
                    duong.notify(resources['RemoveCartOK'], 'success');
                    loadHeaderCart();
                    duong.stopLoading();
                    loadData();
                }
            });
        });
        $('body').on('change', '.txtQuantity', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var q = $(this).val();
            console.log(q);

            if (q > 0) {
                $.ajax({
                    url: '/Cart/UpdateCart',
                    type: 'post',
                    data: {
                        productId: id,
                        quantity: q
                    },
                    success: function () {
                        duong.notify(resources['UpdateOK'], 'success');
                        loadHeaderCart();
                        loadData();
                    }
                });
            } else {
                duong.notify('Your quantity is invalid', 'error');
            }
        });

        $('body').on('change', '.ddlColorId', function (e) {
            e.preventDefault();
            var id = parseInt($(this).closest('tr').data('id'));
            var colorId = $(this).val();
            var q = $(this).closest('tr').find('.txtQuantity').first().val();
            var sizeId = $(this).closest('tr').find('.ddlSizeId').first().val();

            if (q > 0) {
                $.ajax({
                    url: '/Cart/UpdateCart',
                    type: 'post',
                    data: {
                        productId: id,
                        quantity: q,
                        color: colorId,
                        size: sizeId
                    },
                    success: function () {
                        duong.notify(resources['UpdateOK'], 'success');
                        loadHeaderCart();
                        loadData();
                    }
                });
            } else {
                duong.notify('Your quantity is invalid', 'error');
            }
        });

        $('body').on('change', '.ddlSizeId', function (e) {
            e.preventDefault();
            var id = parseInt($(this).closest('tr').data('id'));
            var sizeId = $(this).val();
            var q = parseInt($(this).closest('tr').find('.txtQuantity').first().val());
            var colorId = parseInt($(this).closest('tr').find('.ddlColorId').first().val());
            if (q > 0) {
                $.ajax({
                    url: '/Cart/UpdateCart',
                    type: 'post',
                    data: {
                        productId: id,
                        quantity: q,
                        color: colorId,
                        size: sizeId
                    },
                    success: function () {
                        duong.notify(resources['UpdateOK'], 'success');
                        loadHeaderCart();
                        loadData();
                    }
                });
            } else {
                duong.notify('Your quantity is invalid', 'error');
            }
        });
        $('#btnClearAll').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                url: '/Cart/ClearCart',
                type: 'post',
                success: function () {
                    duong.notify('Cart cleared successfully', 'success');
                    loadHeaderCart();
                    loadData();
                }
            });
        });
    }
    function loadColors() {
        return $.ajax({
            type: "GET",
            url: "/Cart/GetColors",
            dataType: "json",
            success: function (response) {
                cachedObj.colors = response;
            },
            error: function () {
                duong.notify(resources['Error'], 'error');
            }
        });
    }

    function loadSizes() {
        return $.ajax({
            type: "GET",
            url: "/Cart/GetSizes",
            dataType: "json",
            success: function (response) {
                cachedObj.sizes = response;
            },
            error: function () {
                duong.notify(resources['Error'], 'error');
            }
        });
    }
    function getColorOptions(selectedId) {
        var colors = "";
        $.each(cachedObj.colors, function (i, color) {
            if (selectedId === color.Id)
                colors += '<button class="product-variation product-variation--selected">' + color.Name + '</button>';
            else
                colors += '<button class="product-variation">' + color.Name + '</button>';
        });
        return colors;
    }

    function getSizeOptions(selectedId) {
        var sizes = "";
        $.each(cachedObj.sizes, function (i, size) {
            if (selectedId === size.Id)
                sizes += '<button class="product-variation product-variation--selected">' + size.Name + '</button>';
            else
                sizes += '<button class="product-variation">' + size.Name + '</button>';
        });
        return sizes;
    }
    function loadHeaderCart() {
        $("#headerCart").load("/AjaxContent/HeaderCart");
    }
    function loadData() {
        $.ajax({
            url: '/Cart/GetCart',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                var template = $('#template-cart').html();
                var render = "";
                var totalAmount = 0;
                $.each(response, function (i, item) {
                    render += Mustache.render(template,
                        {
                            ProductId: item.Product.Id,
                            ProductName: item.Product.Name,
                            Image: item.Product.Image,
                            OldPrice: duong.formatNumber(item.OriginalPrice, 0),
                            Price: duong.formatNumber(item.Price, 0),
                            Quantity: item.Quantity,
                            Colors: getColorOptions(item.Color == null ? 0 : item.Color.Id),
                            Sizes: getSizeOptions(item.Size == null ? "" : item.Size.Id),
                            Amount: duong.formatNumber(item.Price * item.Quantity, 0),
                            Url: '/' + item.Product.SeoAlias + "-p." + item.Product.Id + ".html"
                        });
                    totalAmount += item.Price * item.Quantity;
                });
                $('#lblTotalAmount').text(duong.formatNumber(totalAmount, 0));
                if (render !== "")
                    $('#table-cart-content').html(render);
                else
                    $('#table-cart-content').html('<span style="color:red">You have no products in your shopping cart</span>');
            }
        });
        return false;
    }
}