﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Models
{
	public class RegistrationViewModel
	{
		[Required]
		[StringLength(15, MinimumLength = 3)]
		//[StringLength(15, ErrorMessage = "Name length can't be more than 15.")]
		public string Name { get; set; }
		[Required]
		[RegularExpression(@"^(\d{10})$", ErrorMessage = "Mobile no not valid")]
		public string Mobile { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
		[Required]
		[NotMapped] // Does not effect with your database
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
	}
}
