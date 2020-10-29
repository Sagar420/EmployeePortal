using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
	public class ValidateFileAttribute : RequiredAttribute
	{
		public override bool IsValid(object value)
		{
			var file = value as HttpPostedFileBase;
			// Return if a file doesn't exist or not
			return file != null;
		}
	}
}