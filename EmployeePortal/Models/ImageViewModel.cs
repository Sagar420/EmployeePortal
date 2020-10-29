using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
	public class ImageViewModel
	{
		[DataType(DataType.Upload)]
		[Display(Name = "Upload File")]
		public string file { get; set; }

		public string filename { get; set; }
	}
}