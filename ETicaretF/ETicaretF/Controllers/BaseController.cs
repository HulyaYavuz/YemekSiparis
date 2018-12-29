using ETicaretF.Models;
using ETicaretF.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretF.Controllers
{
    public class BaseController : Controller
    {
        public Repository<Product> repo_product = new Repository<Product>();
        public Repository<ProductItem> repo_Productitem = new Repository<ProductItem>();
        public Repository<Category> repo_category= new Repository<Category>();
        public Repository<Customer> repo_Customer = new Repository<Customer>();
        public Repository<Blog> repo_blog = new Repository<Blog>();
        public Repository<OrderDetail> repo_orderdetail = new Repository<OrderDetail>();
        public Repository<Order> repo_order = new Repository<Order>();

        public BaseController()
        {

        }

        protected Customer CurentUser()
        {
            return (Customer)Session["LogonCustomer"];
        }
        protected int CurrentUserId()
        {
            return ((Customer)Session["LogonCustomer"]).Id;
        }
        protected bool IsLogon()
        {
            if (Session["LogonCustomer"] == null)
                return false;
            else
                return true;
        }
    }
}