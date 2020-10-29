using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeePortal.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeePortal.Controllers
{
	public class AccountController : Controller
	{
		EmployeePortalEntities db = new EmployeePortalEntities();
		// GET: Account
		public ActionResult Login()
		{
			return View();
		}

		public ActionResult LoginAction(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				string password = AESAlgorithm.EncryptText(model.Password, "Sagar123");

				var userdetails = db.userdetails.Where(m => m.Email == model.Username && m.Password == password).FirstOrDefault();
				if (userdetails == null)
				{
					ModelState.AddModelError("Password", "Username and Password is incorrect!");
					return View("Login");
				}
			}
			else
			{
				return View("Login");
			}

			var empDetails = (from emp in db.userdetails
							  where emp.Email == model.Username
							  select new
							  {
								  emp.Id,
								  emp.Email,
								  emp.Name,
								  emp.Profilepic
							  }).FirstOrDefault();

			Session["id"] = empDetails.Id;
			Session["UserName"] = empDetails.Email;
			Session["Name"] = empDetails.Name;
			Session["ImageData"] = empDetails.Profilepic;

			FormsAuthentication.SetAuthCookie(empDetails.Email, false);


			return RedirectToAction("Index", "Home");
		}
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			Session.Clear();
			Session.Abandon();
			return RedirectToAction("Login");
		}
	}
}