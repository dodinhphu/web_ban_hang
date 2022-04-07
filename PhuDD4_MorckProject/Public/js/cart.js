    
function themvaogiohang(cart_id, product_id) {
    $("#nut_themvaogio").hide(100);
    if (cart_id != null && product_id != null) {
        $.ajax({
            url: "/GioHang/Add_cart",
            type: "POST",
            data: {
                cart_id: cart_id,
                product_id: product_id,
                product_number: $('#txt_soluong').val()
            }
        })
            .then(function (data) {
                if (data.Data.status == "OK") {
                    $('#txt_count_cart').text(data.Data.cout_cart);
                    $('#tb_them_cardtc').text(data.Data.messeger);
                    $('#tongtbt_tc').show(200);
                    setTimeout(function () {
                        $('#tongtbt_tc').hide(200);
                    }, 2000)
                }
                else {
                    $('#tb_them_cardtb').text(data.Data.messeger);
                    $('#tongtbt_tb').show(200);
                    setTimeout(function () {
                        $('#tongtbt_tb').hide(200);
                    }, 2000)
                }
            })
    }
    $("#nut_themvaogio").show(100);
}
function xoa_sp_gh(ma_gh, ma_sp, giale) {
    $.ajax({
        url: "/GioHang/Remove",
        type: "POST",
        data: {
            cart_id: ma_gh,
            product_id: ma_sp
        }
    })
        .then(function (data) {
            if (data.Data.status == "OK") {
                $('#txt_count_cart').text(data.Data.cout_cart);
                $(`#${ma_sp}`).remove();
                let tongcu = parseFloat($('#tongtien_cart').text().replace(/,/g, "").toString().replace(/\./g, ""));
                let giatru = parseFloat(giale)
                let tong = tongcu - giatru;
                $('#tongtien_cart').text(tong.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }))
                let listkt = $(".check_dh_trong");
                if (listkt.length <= 0) {
                    $("#btn_dathang").hide(100);
                    $('#tongtien_cart').hide(100);
                }
            }
        })
}

function dathang_new(customer_id, total_price) {
    $.ajax({
        url: "/DonHang/MuaHang",
        type: "POST",
        data: {
            customer_id: customer_id,
            total_price: total_price,
            customer_name: $('#txt_tenkh').val(),
            customer_address: $('#txt_diachi').val(),
            customer_phone: $('#txt_phone').val()
        }
    })
        .then(function (data) {
            if (data.Data.status == "OK") {
                $('#txt_count_cart').text(data.Data.cout_cart);
                var a = document.getElementById('toanbogh')
                a.outerHTML = `
                                           <div style="margin:auto;" class="giohangtrong">
                                                <h6 style="margin:204px 0;padding:0;font-size:40px;font-family:cursive" class="txt_giohangtrong">
                                                    Giỏ Hà<span style="color: #f6422e">ng Trống !</span>
                                                </h6>
                                                <i class="fa-solid fa-face-frown"></i>
                                                <div style="margin:200px 0; text-align:center;" class="dimua">
                                                    <a href="/">
                                                        <button class="btn btn_muangay_">Đơn Hàng Của Tôi</button>
                                                    </a>
                                                </div>
                                            </div>
                                        `
                $('#noidungtb').text("Đặt Hàng Thành Công !")
                $("body,html").animate({ scrollTop: 0 });
                $('#tongtb').show(200);
            }
            else {
                $('#txt_tbs').text("Đặt Hàng Không Thành Công !")
                $('#tongtbs').show(200);
            }
        })
}





