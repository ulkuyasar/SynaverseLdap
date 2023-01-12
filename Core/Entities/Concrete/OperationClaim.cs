using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
	public class OperationClaim : IEntity
	{
		//public int Id { get; set; }
		public long? Id { get { return id; } set { id = value; } }
		private long? id;
		public string Name { get; set; }

		public bool RecordStatus { get; set; }

	}
}
