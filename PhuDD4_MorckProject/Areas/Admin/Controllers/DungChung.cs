using PhuDD4_MorckProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuDD4_MorckProject.Areas.Admin.Controllers
{
    public class DungChung
    {
        MockProjectEntities1 DB = new MockProjectEntities1();
        // Thêm
        public void Create<T>(T obj)
        {
            DB.Set(obj.GetType()).Add(obj);
        }
        // Thêm nhiều
        public void Creates(List<don_hang_chitiet> obj)
        {
            DB.don_hang_chitiet.AddRange(obj);
        }
        // Lưu
        public int save()
        {
            int kq = DB.SaveChanges();
            return kq;
        }
        // Tìm danh mục
        public category Find(int id)
        {
            category category = DB.categories.Where(c => c.category_id == id).FirstOrDefault();
            return category;
        }
        // xóa
        public void Delete<T>(T obj)
        {
            DB.Set(obj.GetType()).Remove(obj);
        }
        // tìm trong giỏ hàng
        public List<cart> tim_sp_giohang(int product_id)
        {
            List<cart> listcart = new List<cart>();
            listcart = DB.carts.Where(c => c.product_id == product_id).ToList();
            return listcart;
        }

        // tìm trong giỏ hàng 2
        public cart tim_sp_giohang2(string cart_id, int product_id)
        {
            cart cart = new cart();
            cart  = DB.carts.Where(c => c.product_id == product_id && c.cart_id == cart_id).FirstOrDefault();
            return cart;
        }
        // tìm trong giỏ hàng 3
        public List<cart> tim_sp_giohang3(string cart_id)
        {
            List<cart> cart = new List<cart>();
            cart = DB.carts.Where(c => c.cart_id == cart_id).ToList();
            return cart;
        }
        // Tìm sản phẩm
        public product Find_product(int id)
        {
            product product = DB.products.Where(c => c.product_id == id).FirstOrDefault();
            return product;
        }
        // lấy product them danh mục
        public List<product> product_theo_dm(int id)
        {
            List<product> list_product = (from p in DB.products
                                          where p.category_id == id
                                          select p
                                         ).ToList();
            return list_product;
        }
        // lấy product giảm dần
        public List<product> product_giamdan()
        {
            List<product> list_product = (from p in DB.products
                                          orderby p.product_price descending
                                          select p
                                         ).ToList();
            return list_product;
        }
        // lấy product tăng dần
        public List<product> product_tangdan()
        {
            List<product> list_product = (from p in DB.products
                                          orderby p.product_price
                                          select p
                                         ).ToList();
            return list_product;
        }
        // tìm kiếm product gần đúng
        public List<product> product_timkiem(string tukhoa)
        {
            List<product> list_product = (from p in DB.products
                                          where (p.product_name.Contains(tukhoa))
                                          select p
                                         ).ToList();
            return list_product;
        }

        // tìm số lượng đơn hàng trong giỏ
        public int cout_item_cart(string username)
        {
           int a =  DB.carts.Where(c => c.cart_id == username).Count();
            return a;
        }
        public don_dat_hang tim_don_hang(int order_id, string customer_id)
        {
            int orderid= order_id;
            don_dat_hang donhang = DB.don_dat_hang.Where(d => d.order_id == orderid && d.customer_id == customer_id).FirstOrDefault();
            return donhang;
        }
    }
}