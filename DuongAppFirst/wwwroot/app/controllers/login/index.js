var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {
        $("#frmLogin").validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                userName: {
                    required: true
                },
                password: {
                    required: true,
                    minlength: 6
                }
            }
        });
        $('#btnLogin').on('click', function (e) {
            if ($("#frmLogin").valid()) {
                e.preventDefault();
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                login(user, password);
            }
        });
        $('body').on('keypress', function (e) {
            if (e.which === 13) {
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                login(user, password);
            }
        });
    }

    var login = function (user, pass) {
        $.ajax({
            type: "POST",
            data: {
                Email: user,
                Password: pass
            },
            dataType: 'json',
            url: '/admin/login/authen',
            success: function (res) {
                if (res.Success) {
                    window.location.href = "/Admin/Home/Index";
                }
                else {
                    duong.notify('Đăng nhập không đúng', 'error');
                }
            }
        })
    }
}