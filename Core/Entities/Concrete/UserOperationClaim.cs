using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
	public class UserOperationClaim : IEntity
	{
		public Int64 UserId { get; set; }
		public Int64 OperationClaimId { get; set; }
		public long? Id { get { return id; } set { id = value; } }
		private long? id;

		public bool RecordStatus { get; set; }
	}
}
