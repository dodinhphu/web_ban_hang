function doi_status(order_id, customer_id) {
    $.ajax({
        url: "/Admin/Cart/updateStatus",
        type: "POST",
        data: {
            order_id: order_id,
            customer_id: customer_id
        }
    })
        .then(function (data) {
            if (data.Data.status == "OK") {
                
                if (data.Data.status_new == true) {
                    alert("Bạn Đã Xử Lí Đơn Hàng ", order_id);
                    let a = order_id + customer_id;
                    $(`#${a}`).removeClass();
                    $(`#${a}`).addClass('btn btn-danger');
                    $(`#${a}`).text('Hủy Đơn')
                }
                else {
                    alert("Bạn Đã Hủy Đơn Hàng ", order_id);
                    let a = order_id + customer_id;
                    $(`#${a}`).removeClass();
                    $(`#${a}`).addClass('btn btn-primary');
                    $(`#${a}`).text('Xử Lí')
                }
            }
        })
}