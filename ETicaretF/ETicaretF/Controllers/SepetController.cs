using ETicaretF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretF.Controllers
{
    public class SepetController : BaseController
    {
        // GET: Sepet
        [HttpGet]
        public void AddBasket(int id, bool remove = false)
        {
            List<Cart> basket = null;
            if (Session["Basket"] == null)
            {
                basket = new List<Cart>();
            }
            else
            {
                basket = (List<Cart>)Session["Basket"];
                if (basket.Any(x => x.Product.Id == id))
                {

                    var pro = basket.FirstOrDefault(x => x.Product.Id == id);
                    if (remove && pro.Count > 0)
                    {
                        pro.Count -= 1;
                    }
                    else
                    {
                        pro.Count += 1;
                    }

                }
                else
                {
                    var pro = repo_product.Find(x => x.Id == id);
                    if (pro != null)
                    {
                        basket.Add(new Cart()
                        {
                            Count = 1,
                            Product = pro
                        });
                    }
                }
            }

           
          
            Session["Basket"] = basket;

        }

        public void DeleteToBasketProduct(int id)
        {
            List<Models.Cart> basket = (List<Models.Cart>)Session["Basket"];
            if (basket != null)
            {
                if (id > 0)
                {
                    basket.RemoveAll(x => x.Product.Id == id);
                }
                else if (id == 0)
                {
                    basket.Clear();
                }
                Session["Basket"] = basket;
            }
            
        }

        public PartialViewResult MiniSepet()
        {
            if (HttpContext.Session["Basket"] != null)
                return PartialView(HttpContext.Session["Basket"]);
            else
                return PartialView();
        }

        public ActionResult Basket()
        {
            List<Models.Cart> model = (List<Cart>)Session["Basket"];
            if (model == null)
            {
                model = new List<Models.Cart>();
            }
            ViewBag.TotalPrice = model.Select(x => x.Product.Price * x.Count).Sum();

            return View(model);
        }

        [HttpPost]
        public ActionResult Buy(string adres)
        {

            if (IsLogon())
            {
                try
                {
                    var basket = (List<Models.Cart>)Session["Basket"];

                    var order = new Order()
                    {
                        OrderTime = DateTime.Now,
                        CustomerID = CurrentUserId(),
                        Status = "SV"
                    };
                    repo_order.Insert(order);
                    foreach (Models.Cart item in basket)
                    {

                        var oDetail = new OrderDetail()
                        {
                            Price = item.Product.Price * item.Product.Count,
                            ProductID = item.Product.Id,
                            Quantity = item.Count,
                            OrderID = order.Id
                    };
                        
                        repo_orderdetail.Insert(oDetail);
                    }
                   

                }
                catch (Exception ex)
                {
                    ViewBag.MyError = ex.Message;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }
        [HttpGet]
        public ActionResult Buy()
        {
            if (IsLogon())
            {
                var currentId = CurrentUserId();
                var customers = repo_Customer.List().Where(x => x.Id == currentId);
              
                return View("Buy", customers);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        [HttpPost]
        public ActionResult Pay(Customer _model,int? id)
        {
            var currentId = CurrentUserId();
            var customers = repo_Customer.Find(x => x.Id == currentId);
            if(customers != null)
            {
                customers.Name = _model.Name;
                customers.Phone = _model.Phone;
                customers.Email = _model.Email;
                customers.BillAdress = _model.BillAdress;
                customers.DeliveryAdress = _model.DeliveryAdress;
                repo_Customer.Update(customers);
            }
            else
            {

            }
            repo_Customer.Save();
            return RedirectToAction("Pay");
        }

        [HttpGet]
        public ActionResult Pay()
        {
            return View();
        }

        public PartialViewResult HesapOzet()
        {
            if (HttpContext.Session["Basket"] != null)
                return PartialView(HttpContext.Session["Basket"]);
            else
                return PartialView();
        }
    }
}