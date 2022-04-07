

function dangnhap() {
    let username = $('#txt_tendangnhap').val();
    let password = $('#txt_matkhau').val();
    if (username == '' || username == null) {
        $('#tb_username').text("Bạn Phải Nhập Tên Tài Khoản");
        $('#tb_username').show(200);
        return;
    }
    if (password == '' || password == null) {
        $('#tb_matkhau').text("Bạn Phải Nhập Mật Khẩu");
        $('#tb_matkhau').show(200);
        return;
    }

    $.ajax({
        url: "/login/login",
        type: "POST",
        data: {
            username: username,
            password: password
        }
    })
        .then(function (data) {
            if (data.Data.status == "OK") {
                alert(data.Data.messeger)
                window.location ="/home"
            }
            else {
                $('#tb_tong').text(data.Data.messeger);
                $('#tb_tong').show(200);
                 $('#txt_tendangnhap').val("");
                 $('#txt_matkhau').val("");
            }
        })
}
function an() {
    $('.dk_tb').hide(200);
    $('#tb_tong').hide(200);
}