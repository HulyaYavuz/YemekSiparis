using ETicaretF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretF.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer _model)
        {
            try
            {
                var customer = repo_Customer.Find(x => x.Password == _model.Password && x.Email == _model.Email);
                if (customer != null)
                {
                    Session["LogonCustomer"] = customer;
                    //if (HttpContext.Session["AktifSepet"] != null)
                    //    return RedirectToAction("Buy", "Home");
                    //else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.reError = "Kullanıcı bilgileriniz yanlış";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.reError = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            try
            {
                var mail = repo_Customer.Find(x => x.Email == customer.Email);
                if (mail != null)
                {
                    throw new Exception("Zaten bu e-posta kayıtlıdır.");
                }
                repo_Customer.Insert(customer);
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                ViewBag.ReError = ex.Message;

                return View();
            }

        }
    }
}