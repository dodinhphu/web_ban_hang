

var kichthuoc = document.getElementsByClassName("slide")[0].clientWidth;
var chuyenslide = document.getElementsByClassName("chuyenslide")[0];
var chuyen = 0;
var tong_anh = chuyenslide.getElementsByTagName("img");
var max = tong_anh.length * kichthuoc;
max = max - kichthuoc;
function next() {
    if (chuyen < max) chuyen = chuyen + kichthuoc;
    else chuyen = 0;
    chuyenslide.style.marginLeft = '-' + (chuyen) + 'px';
}
function back() {
    if (chuyen == 0) chuyen = max;
    else chuyen = chuyen - kichthuoc;
    chuyenslide.style.marginLeft = '-' + chuyen + 'px';
}
setInterval(
    function () {
        next();
    }, 2000
)

function timkiem() {
    let txt_tukhoa = $('#txt_ten_sp_timkiem').val();
    window.location = ('/product/search/' + txt_tukhoa.trim());
}
