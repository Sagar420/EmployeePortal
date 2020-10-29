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
	public class ImageUploadController : Controller
	{
		EmployeePortalEntities db = new EmployeePortalEntities();

		// GET: ImageUpload
		public ActionResult Upload()
		{
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult UploadImage(HttpPostedFileBase file)
		{
			var supportedTypes = new[] { ".png", ".jpeg", ".jpg" };
			string uploadFolder = Request.PhysicalApplicationPath + "UploadedFiles\\";
			int uplodedby = Convert.ToInt32(Session["id"]);

			if (ModelState.IsValid)
			{
				try
				{
					if (file != null)
					{
						string strpath = System.IO.Path.GetExtension(file.FileName);
						if (supportedTypes.Contains(strpath))
						{
							string path = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(file.FileName));
							file.SaveAs(uploadFolder + "Test_" + DateTime.Now.ToString("yyyyMMddHHmmss") + uplodedby + strpath);

							var imageUpload = new ImageDetaiil
							{
								uplodedby = Convert.ToInt32(Session["id"]),
								imagepath = path,
								imagename = "Test_" + DateTime.Now.ToString("yyyyMMddHHmmss")+uplodedby + strpath
							};

							db.ImageDetaiils.Add(imageUpload);
							db.SaveChanges();

							ViewBag.FileStatus = "File uploaded successfully.";
						}
						else
						{
							ViewBag.FileStatus = "Select .png/ .jpeg / .jpg files for upload";
						}
					}
					else
					{
						ViewBag.FileStatus = "Please choose file!";
					}

				}
				catch (Exception)
				{
					ViewBag.FileStatus = "Error while file uploading."; ;
				}
			}
			return View("Upload");
		}

		public byte[] ConvertToBytes(HttpPostedFileBase image)
		{
			byte[] imageBytes = null;
			BinaryReader reader = new BinaryReader(image.InputStream);
			imageBytes = reader.ReadBytes((int)image.ContentLength);
			return imageBytes;
		}
	}
}