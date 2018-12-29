using ETicaretF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace ETicaretF.Controllers
{
    public class HomeController : BaseController
    {
        List<Product> product = new List<Product>();
        List<ProductItem> productItems = new List<ProductItem>();
        List<Category> categories = new List<Category>();
        List<Blog> blog = new List<Blog>();

        // GET: Home
        public ActionResult Index()
        {
            CommenModel cm = new CommenModel();
            cm.Categories = repo_category.List();
            cm.Products = repo_product.List();
            return View(cm);
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult ShowProductItem(int id)
        {
            var items = repo_product.Find(x => x.Id == id);
            var item = repo_Productitem.Find(x => x.Product.Id == id);
            ViewBag.ProductItem = repo_Productitem.List().Where(x => x.Product.Id == items.Id);

            //Birden fazla özelliği varsa video 25dk izle
            //productItems = repo_product.List().Where(x => x.Id == id);
      
           // Dictionary<int, List<ProductItem>> item_List = new Dictionary<int, List<ProductItem>>();

            if (items != null)
            {
                TempData["detailfood"] = items.Id;
                return View("ShowProductItem",items);
            }
            else
            {
                return View();
            }

        }

       

        public ActionResult Blog()
        {
            blog = repo_blog.List().OrderByDescending(x => x.AddedDate).ToList();
            return View(blog);
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(MailModel objModelMail, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {
                string to = "send your mail";
                using (MailMessage mail = new MailMessage(objModelMail.From,to))
                {
                    mail.Subject = objModelMail.Subject;
                    mail.Body = objModelMail.Body;
                    if (fileUploader != null)
                    {
                        string fileName = Path.GetFileName(fileUploader.FileName);
                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                    }
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(to, "your's mail password");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Message = "Sent";
                    return View("Index");
                }
            }
            else
            {
                return View();
            }

        }


    }
}
