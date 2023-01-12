using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
	public class UserDetail : IEntityExtendedIdName
	{
		public Int64 UserId { get; set; }
		public Int16 CustomerType { get; set; }
		public string PrefixName { get; set; }
		public string SurName { get; set; }
		public string Tckn { get; set; }
		public string Vkn { get; set; }
		public DateTime? Birthday { get; set; }
		public Int16 Gender { get; set; }

		[NotMapped]
		public string FullName {
			get
			{
				return string.IsNullOrEmpty(PrefixName) ? String.Concat(Name, " ", SurName) : String.Concat(PrefixName, " ", Name, " ", SurName);
			}
		}
	}

}
