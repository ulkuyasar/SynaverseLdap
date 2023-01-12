using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
	public interface IEntity
	{
		Int64? Id { get; set; }

		public bool RecordStatus { get; set; }
	}



	public interface IEmptyEntity
	{
	}


	public interface IEntity<out TKey> : IEmptyEntity where TKey : IEquatable<TKey>
	{
		public TKey Id { get; }
		DateTime CreatedAt { get; set; }
	}
}
