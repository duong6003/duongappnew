var CheckOutController = function () {
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
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
                    duong.stopLoading();
                    loadHeaderCart();
                    loadData();
                }
            });
        });
    }
    function loadHeaderCart() {
        $("#headerCart").load("/AjaxContent/HeaderCart");
    }
}