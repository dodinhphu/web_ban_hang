
$("#btn_dangki").click(function () {

    $("#form_dk").validate({
        rules: {
            username: "required",
            password: "required",
            nhaplai: {
                required: true,
                equalTo: "#txt_password"
            },
            ho: "required",
            ten: "required",
            diachi: "required",
            ngaysinh: {
                required: true,
                date: true
            },
            dienthoai: {
                required: true,
                rangelength: [10, 10]
            },
        },
        messages: {
            username: "Vui lòng nhập tên !",
            password: "Vui lòng Mật Khẩu !",
            nhaplai: {
                required: "Vui Lòng Lại Mật Khẩu !",
                equalTo: "Mật Khẩu Không Khớp !"
            },
            ho: "Vui Lòng Lại Họ !",
            ten: "Vui Lòng Lại Tên !",
            diachi: "Vui Lòng Lại Địa Chỉ !",
            ngaysinh: {
                required: "Vui Lòng Lại Ngày Sinh !",
                date: "Sai Định Dạng Ngày Tháng Năm !"
            },
            dienthoai: {
                required: "Vui Lòng Lại Số Điện Thoại !",
                rangelength: "Sai Định Dạng Số Điện Thoại"
            },
        },
        submitHandler: function (form) {
            let username = $("#txt_username").val();
            let password = $("#txt_password").val();
            let last_name = $("#txt_lastname").val();
            let first_name = $("#txt_firstname").val();
            let address = $("#txt_address").val();
            let dayofbirth = $("#txt_dayofbirth").val();
            let number_phone = $("#txt_numberphone").val();
            $.ajax({
                url: "/Register/Create",
                type: "POST",
                data: {
                    username: username,
                    password: password,
                    last_name: last_name,
                    first_name: first_name,
                    address: address,
                    dayofbirth: dayofbirth,
                    number_phone: number_phone,
                }
            })
                .then(function (data) {
                    if (data.Data.status == "OK") {
                        $('#tb_tong').text(data.Data.messeger);
                        $('#tb_tong').css("color","springgreen")
                        $('#tb_tong').show(200);
                        $("#txt_username").val("");
                        $("#txt_password").val("");
                        $("#txt_lastname").val("");
                        $("#txt_firstname").val("");
                        $("#txt_address").val("");
                        $("#txt_dayofbirth").val("");
                        $("#txt_numberphone").val("");
                        $("#txt_password_kt").val("");
                    }
                    else {
                        $('#tb_tong').text(data.Data.messeger);
                        $('#tb_tong').css("color","red")
                        $('#tb_tong').show(200);
                    }
                })
        }
    });
});

$("#btn_capnhat").click(function () {

    $("#form_dk").validate({
        rules: {
            username: "required",
            password: "required",
            nhaplai: {
                required: true,
                equalTo: "#txt_password"
            },
            ho: "required",
            ten: "required",
            diachi: "required",
            ngaysinh: {
                required: true,
                date: true
            },
            dienthoai: {
                required: true,
                rangelength: [10, 10]
            },
        },
        messages: {
            username: "Vui lòng nhập tên !",
            password: "Vui lòng Mật Khẩu !",
            nhaplai: {
                required: "Vui Lòng Lại Mật Khẩu !",
                equalTo: "Mật Khẩu Không Khớp !"
            },
            ho: "Vui Lòng Lại Họ !",
            ten: "Vui Lòng Lại Tên !",
            diachi: "Vui Lòng Lại Địa Chỉ !",
            ngaysinh: {
                required: "Vui Lòng Lại Ngày Sinh !",
                date: "Sai Định Dạng Ngày Tháng Năm !"
            },
            dienthoai: {
                required: "Vui Lòng Lại Số Điện Thoại !",
                rangelength: "Sai Định Dạng Số Điện Thoại"
            },
        },
        submitHandler: function (form) {
            let username = $("#txt_username").val();
            let password = $("#txt_password").val();
            let last_name = $("#txt_lastname").val();
            let first_name = $("#txt_firstname").val();
            let address = $("#txt_address").val();
            let dayofbirth = $("#txt_dayofbirth").val();
            let number_phone = $("#txt_numberphone").val();
            $.ajax({
                url: "/Register/Update",
                type: "POST",
                data: {
                    username: username,
                    password: password,
                    last_name: last_name,
                    first_name: first_name,
                    address: address,
                    dayofbirth: dayofbirth,
                    number_phone: number_phone,
                }
            })
                .then(function (data) {
                    if (data.Data.status == "OK") {
                        $('#tb_tong').text(data.Data.messeger);
                        $('#tb_tong').css("color", "springgreen")
                        $('#tb_tong').show(200);
                        $("#txt_username").val("");
                        $("#txt_password").val("");
                        $("#txt_lastname").val("");
                        $("#txt_firstname").val("");
                        $("#txt_address").val("");
                        $("#txt_dayofbirth").val("");
                        $("#txt_numberphone").val("");
                        $("#txt_password_kt").val("");
                    }
                    else {
                        $('#tb_tong').text(data.Data.messeger);
                        $('#tb_tong').css("color", "red")
                        $('#tb_tong').show(200);
                    }
                })
        }
    });
});
function an() {
    $('#tb_tong').hide(200);
}
