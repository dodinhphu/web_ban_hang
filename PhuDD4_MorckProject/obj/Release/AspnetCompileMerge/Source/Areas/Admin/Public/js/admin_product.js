

function add_product() {
    let product_name = $("#product_name").val();
    let category_id = $("#category_id").val();
    let product_price = $('#product_price').val();
    let product_ngaytao = $('#product_ngaytao').val();
    let product_short_description = $('#product_short_description').val();
    let product_description = $('#product_description').val();
    let product_number = $('#product_number').val();
    let product_xuatxu = $('#product_xuatxu').val();
    let product_thuonghieu = $('#product_thuonghieu').val();

    if (product_name.trim() == '' || product_name == undefined) {
        $('#tb_product_name').text("Bạn Không Được Bỏ Trống Tên Sản Phẩm");
        $('#tb_product_name').show(200);
        $("#product_name").focus();
        return;
    }
    if (category_id.trim() == 'FALSE' || category_id == undefined) {
        $('#tb_category_danhmuc').text("Bạn Phải Chọn Loại Sản Phẩm");
        $('#tb_category_danhmuc').show(200);
        $("#category_id").focus();
        return;
    }
    if (product_price.trim() == '' || product_price == undefined) {
        $('#tb_product_gia').text("Bạn Phải Đặt Giá Cho Sản Phẩm");
        $('#tb_product_gia').show(200);
        $("#product_price").focus();
        return;
    }
    if (product_number.trim() == '' || product_number == undefined) {
        $('#tb_product_soluong').text("Hãy Nhập Số Lượng Của Sản Phẩm");
        $('#tb_product_soluong').show(200);
        $("#product_number").focus();
        return;
    }
    if (product_xuatxu.trim() == '' || product_xuatxu == undefined) {
        $('#tb_product_xuatxu').text("Hãy Nhập Xuất Xứ Của Sản Phẩm");
        $('#tb_product_xuatxu').show(200);
        $("#product_xuatxu").focus();
        return;
    }
    if (product_thuonghieu.trim() == '' || product_thuonghieu == undefined) {
        $('#tb_product_thuonghieu').text("Hãy Nhập Thướng Hiệu Của Sản Phẩm");
        $('#tb_product_thuonghieu').show(200);
        $("#product_thuonghieu").focus();
        return;
    }
    if (product_ngaytao.trim() == '' || product_ngaytao == undefined) {
        $('#tb_product_date').text("Chọn Ngày Tạo Sản Phẩm");
        $('#tb_product_date').show(200);
        $("#product_ngaytao").focus();
        return;
    }
    if (product_short_description.trim() == '' || product_short_description == undefined) {
        $('#tb_product_motangan').text("Hãy Viết Mô Tả Ngắn Cho Sản Phẩm Này");
        $('#tb_product_motangan').show(200);
        $("#product_short_description").focus();
        return;
    }
    if (product_description.trim() == '' || product_description == undefined) {
        $('#tb_product_mota').text("Hãy Viết Mô Tả Cho Sản Phẩm Này");
        $('#tb_product_mota').show(200);
        $("#product_description").focus();
        return;
    }
   

    
    let product_img = $('#product_img').get(0);
    let file_img = product_img.files;
    if (file_img[0]) {
        let formdata = new FormData();
        //  Thêm dữ liệu cho form
        formdata.append("anh", file_img[0]);
        formdata.append("product_name", product_name);
        formdata.append("category_id", category_id);
        formdata.append("product_price", product_price);
        formdata.append("product_ngaytao", product_ngaytao);
        formdata.append("product_short_description", product_short_description);
        formdata.append("product_description", product_description);
        formdata.append("product_number", product_number);
        formdata.append("product_xuatxu", product_xuatxu);
        formdata.append("product_thuonghieu", product_thuonghieu);
        $.ajax({
            url: "/Admin/product/CreateProduct",
            type: "POST",
            data: formdata,
            contentType: false,
            processData: false,
        })
            .then(function (data) {
                if (data.Data.status = "OK") {
                    $("#tb_tc").text(data.Data.messeger);
                    $("#tb_tc").show(200);
                    //----------------
                    $("#product_name").val("");
                    $("#category_id").val("");
                    $('#product_price').val("");
                    $('#product_ngaytao').val("");
                    $('#product_short_description').val("");
                    $('#product_description').val("");
                    $('#product_number').val("");
                    $('#product_xuatxu').val("");
                    $('#product_thuonghieu').val("");
                    let anh_clone = $('#product_img').clone(true);
                    $('#product_img').replaceWith(anh_clone);
                    $('#product_img').val('');
                    setTimeout(function () {
                        $("#tb_tc").hide(100);
                    }, 4000)
                }
                else {
                    $("#tb_tb").text(data.Data.messeger);
                    $("#tb_tb").show(200);
                    setTimeout(function () {
                        $("#tb_tb").hide(100);
                    }, 4000)
                }
            })
            .catch(function (err) {
                $("#tb_tb").text(err);
                $("#tb_tb").show(200);
                setTimeout(function () {
                    $("#tb_tb").hide(100);
                }, 4000)
            })
    }
    else {
        $('#tb_img').text("Bạn Phải Chọn Ảnh Sản Phẩm");
        $('#tb_img').show(200);
        return;
    }
  
}
//-------------------
function update_product(id) {
    let product_name = $("#product_name").val();
    let category_id = $("#category_id").val();
    let product_price = $('#product_price').val();
    let product_ngaytao = $('#product_ngaytao').val();
    let product_short_description = $('#product_short_description').val();
    let product_description = $('#product_description').val();
    let product_number = $('#product_number').val();
    let product_xuatxu = $('#product_xuatxu').val();
    let product_thuonghieu = $('#product_thuonghieu').val();

    if (product_name.trim() == '' || product_name == undefined) {
        $('#tb_product_name').text("Bạn Không Được Bỏ Trống Tên Sản Phẩm");
        $('#tb_product_name').show(200);
        $("#product_name").focus();
        return;
    }
    if (category_id.trim() == 'FALSE' || category_id == undefined) {
        $('#tb_category_id').text("Bạn Phải Chọn Loại Sản Phẩm");
        $('#tb_category_id').show(200);
        $("#category_id").focus();
        return;
    }
    if (product_price.trim() == '' || product_price == undefined) {
        $('#tb_product_id').text("Bạn Phải Đặt Giá Cho Sản Phẩm");
        $('#tb_product_id').show(200);
        $("#product_price").focus();
        return;
    }
    if (product_number.trim() == '' || product_number == undefined) {
        $('#tb_product_soluong').text("Hãy Nhập Số Lượng Của Sản Phẩm");
        $('#tb_product_soluong').show(200);
        $("#product_number").focus();
        return;
    }
    if (product_xuatxu.trim() == '' || product_xuatxu == undefined) {
        $('#tb_product_xuatxu').text("Hãy Nhập Xuất Xứ Của Sản Phẩm");
        $('#tb_product_xuatxu').show(200);
        $("#product_xuatxu").focus();
        return;
    }
    if (product_thuonghieu.trim() == '' || product_thuonghieu == undefined) {
        $('#tb_product_thuonghieu').text("Hãy Nhập Thướng Hiệu Của Sản Phẩm");
        $('#tb_product_thuonghieu').show(200);
        $("#product_thuonghieu").focus();
        return;
    }
    if (product_ngaytao.trim() == '' || product_ngaytao == undefined) {
        $('#tb_product_date').text("Chọn Ngày Tạo Sản Phẩm");
        $('#tb_product_date').show(200);
        $("#product_ngaytao").focus();
        return;
    }
    if (product_short_description.trim() == '' || product_short_description == undefined) {
        $('#tb_product_motangan').text("Hãy Viết Mô Tả Ngắn Cho Sản Phẩm Này");
        $('#tb_product_motangan').show(200);
        $("#product_short_description").focus();
        return;
    }
    if (product_description.trim() == '' || product_description == undefined) {
        $('#tb_product_mota').text("Hãy Viết Mô Tả Cho Sản Phẩm Này");
        $('#tb_product_mota').show(200);
        $("#product_description").focus();
        return;
    }



    let product_img = $('#product_img').get(0);
    let file_img = product_img.files;
    if (file_img[0]) {
        let formdata = new FormData();
        //  Thêm dữ liệu cho form
        formdata.append("product_id", id);
        formdata.append("anh", file_img[0]);
        formdata.append("product_name", product_name);
        formdata.append("category_id", category_id);
        formdata.append("product_price", product_price);
        formdata.append("product_ngaytao", product_ngaytao);
        formdata.append("product_short_description", product_short_description);
        formdata.append("product_description", product_description);
        formdata.append("product_number", product_number);
        formdata.append("product_xuatxu", product_xuatxu);
        formdata.append("product_thuonghieu", product_thuonghieu);
        $.ajax({
            url: "/Admin/product/UpdateProduct",
            type: "POST",
            data: formdata,
            contentType: false,
            processData: false,
        })
            .then(function (data) {
                if (data.Data.status = "OK") {
                    $("#tb_tc").text(data.Data.messeger);
                    $("#tb_tc").show(200);
                    //----------------
                    setTimeout(function () {
                        $("#tb_tc").hide(100);
                    }, 4000)
                }
                else {
                    $("#tb_tb").text(data.Data.messeger);
                    $("#tb_tb").show(200);
                    setTimeout(function () {
                        $("#tb_tb").hide(100);
                    }, 4000)
                }
            })
            .catch(function (err) {
                $("#tb_tb").text(err);
                $("#tb_tb").show(200);
                setTimeout(function () {
                    $("#tb_tb").hide(100);
                }, 4000)
            })
    }
    else {
        $('#tb_img').text("Bạn Phải Chọn Ảnh Sản Phẩm");
        $('#tb_img').show(200);
        return;
    }

}

function xoa_product(id, name) {
    let kt = confirm("Bạn Có Chắc Chắn Muốn Xóa Sản Phẩm " + name + " Không ?");
    if (kt == true) {
        $.ajax({
            url: "/Admin/Product/DeleteProduct",
            type: "POST",
            data: {
                product_id: id,
            }
        })
            .then(function (data) {
                if (data.Data.status == "OK") {
                    $(`#${id}`).hide(100);
                }
                else {
                    alert(data.Data.messeger)
                }
            })
    }
}


function trove() {
    window.location ="/Admin/product/listproduct"
}
function an(a) {
    $('.category_tb').hide(100);
}