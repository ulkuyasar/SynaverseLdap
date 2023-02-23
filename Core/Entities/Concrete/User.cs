using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Concrete
{
	public class User : IEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		
		public byte[] PasswordSalt { get; set; }
		
		public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
		public string FireBaseToken { get; set; }
		public string Pwd { get; set; }
		public bool RecordStatus { get; set; }

        public bool IsComeFromLdap { get; set; }

        public long? Id { get { return id; } set { id = value; } }
		private long? id;

		[NotMapped]
		public string DisplayName
		{
			get { return FirstName.Trim() + " " + LastName.Trim(); }
		}
	}
}
