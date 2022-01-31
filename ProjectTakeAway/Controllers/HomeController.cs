using ProjectTakeAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjectTakeAway.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (Session["CustomerID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        //Get: Register
        public ActionResult Register()
        {
            return View();
        }
        //Post: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer _customer)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Customer.FirstOrDefault(s => s.Email == _customer.Email);
                if (check == null)
                {
                    _customer.Password = GetMD5(_customer.Password);
                    _context.Configuration.ValidateOnSaveEnabled = false;
                    _context.Customer.Add(_customer);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }
        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = _context.Customer.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["CustomerID"] = data.FirstOrDefault().CustomerID;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}