using PhuDD4_MorckProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuDD4_MorckProject.Areas.Authentication.Controllers
{
    public class DungChung
    {
        MockProjectEntities1 DB = new MockProjectEntities1();
        public int save()
        {
            int kq = DB.SaveChanges();
            return kq;
        }
        public void Create<T>(T obj)
        {
            DB.Set(obj.GetType()).Add(obj);
        }
        public customer tim_customer(string username)
        {
            customer customer = DB.customers.Where(c => c.username == username).FirstOrDefault();
            return customer;
        }

    }
}