using System.Web.Mvc;

namespace PhuDD4_MorckProject.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // router category
            context.MapRoute(
               "Admin_list_category",
               "Admin/category/list",
               new { controller = "Category", action = "ListCategory", id = UrlParameter.Optional }
           );

            context.MapRoute(
              "Admin_create_category",
              "Admin/category/create",
              new { controller = "Category", action = "CreateCategory", id = UrlParameter.Optional }
          );
            context.MapRoute(
             "Admin_update_category",
             "Admin/category/update/{id}",
             new { controller = "Category", action = "UpdateCategory", id = UrlParameter.Optional }
         );

            // router product
            context.MapRoute(
             "Admin_list_product",
             "Admin/product/list",
             new { controller = "product", action = "listProduct", id = UrlParameter.Optional }
         );
            context.MapRoute(
             "Admin_create_product",
             "Admin/product/create",
             new { controller = "product", action = "createProduct", id = UrlParameter.Optional }
         );
            context.MapRoute(
             "Admin_update_product",
             "Admin/product/update/{id}",
             new { controller = "product", action = "UpdateProduct", id = UrlParameter.Optional }
         );

            // cart
            context.MapRoute(
            "detail_donhang",
            "Admin/order/details/{id}",
            new { controller = "Cart", action = "detailsCart", id = UrlParameter.Optional }
        );
            // default
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}