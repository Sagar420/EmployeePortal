using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		EmployeePortalEntities db = new EmployeePortalEntities();
		public ActionResult Index()
		{
			int id = Convert.ToInt32(Session["id"]);
			var imagesModel = new ImageGallery();


			//var result= db.ImageDetaiils.Where(s => s.uplodedby==id).ToList();
			//var imageFiles = Server.MapPath("~/UploadedFiles/" + db.ImageDetaiils.Where(s => s.id == id).Select(s => s.imagename)
			var imageFiles = Directory.GetFiles(Server.MapPath("~/UploadedFiles/"));

			foreach (var item in imageFiles)
			{
				imagesModel.ImageList.Add(Path.GetFileName(item));
			}

			//foreach (var item in result)
			//{
			//	imagesModel.ImageList.Add(Server.MapPath("~/UploadedFiles/"+item.imagename));
			//}
			return View(imagesModel);
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