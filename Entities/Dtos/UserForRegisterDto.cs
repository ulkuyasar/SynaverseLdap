using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
	public class UserForRegisterDto : IDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
        public bool IsComeFromLdap { get; set; }

        //public DateTime Birthday { get; set; }
        //public Int16 Gender { get; set; }
    }
}
