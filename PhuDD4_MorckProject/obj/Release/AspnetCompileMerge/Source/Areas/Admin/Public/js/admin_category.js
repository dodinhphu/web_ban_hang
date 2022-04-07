function add_category() {
    let category_name = $('#category_name').val();
    let category_date = $('#category_date').val();
    if (category_name.trim() == '') {
        let name_tb = $('#name_tb');
        name_tb.text('Bạn Cần Nhập Tên Danh Mục');
        name_tb.show(200);
        return;
    }
    else if (category_date.trim() == '') {
        let date_tb = $('#date_tb');
        date_tb.text('Bạn Cần Nhập Ngày Tạo');
        date_tb.show(200);
        return;
    }
    else {
        $.ajax({
            url: "/Admin/Category/CreateCategory",
            type: "POST",
            data: {
                category_name: category_name,
                CREATE_date: category_date
            }
        })
            .then(function (data) {
                if (data.Data.status == "OK") {
                    $('#category_name').val('');
                    $('#tbdung').text(data.Data.messeger)
                    $('#tbdung').show(200);
                    setTimeout(function () {
                        $('#tbdung').hide(200);
                    }, 4000)
                }
                else {
                    let today = new Date();
                    $('#category_date').val(today.getDate() + '/' + today.getMonth() + 1 + '/' + today.getFullYear()  );
                    $('#tbsai').text(data.Data.messeger)
                    $('#tbsai').show(200);
                    setTimeout(function () {
                        $('#tbsai').hide(200);
                    }, 4000)
                }
            })
    }
}
function an() {
   $('#name_tb').hide(200);
    $('#date_tb').hide(200);
}

// sửa thư muc
function update_category(category_id) {
    let category_name = $('#category_name').val();
    let category_date = $('#category_date').val();
    if (category_name.trim() == '') {
        let name_tb = $('#name_tb');
        name_tb.text('Bạn Cần Nhập Tên Danh Mục');
        name_tb.show(200);
        return;
    }
    else if (category_date.trim() == '') {
        let date_tb = $('#date_tb');
        date_tb.text('Bạn Cần Nhập Ngày Tạo');
        date_tb.show(200);
        return;
    }
    else {
        $.ajax({
            url: "/Admin/Category/UpdateCategory",
            type: "POST",
            data: {
                category_id: category_id,
                category_name_new: category_name,
                CREATE_date_new: category_date
            }
        })
            .then(function (data) {
                if (data.Data.status == "OK") {
                    $('#category_name').val('');
                    $('#tbdung').text(data.Data.messeger)
                    $('#tbdung').show(200);
                    setTimeout(function () {
                        $('#tbdung').hide(200);
                    }, 3000)
                }
                else {
           
                    $('#tbsai').text(data.Data.messeger)
                    $('#tbsai').show(200);
                    setTimeout(function () {
                        $('#tbsai').hide(200);
                    }, 3000)
                }
            })
    }
}


// xóa danh mục
function xoa_category(id, name) {
    let kt = confirm("Bạn Có Chắc Chắn Muốn Xóa Danh Mục " + name + " Không ?");
    if (kt == true) {
        $.ajax({
            url: "/Admin/Category/DeleteCategory",
            type: "POST",
            data: {
                category_id: id,
            }
        })
            .then(function (data) {
                console.log(data)
                if (data.Data.status == "OK") {
                    $(`#${id}`).hide(100);
                }
                else {
                    alert(data.Data.messeger)
                }
            })
        }
}