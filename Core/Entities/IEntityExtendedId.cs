
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Core.Entities
{
	public class IEntityExtendedId : IEntity, IEquatable<IEntityExtendedId>
	{

		public  DateTime CreatedDate { get; set; }
		public  DateTime? UpdatedDate { get; set; }
		public string CreatedUser { get; set; }
		public string UpdatedUser { get; set; }
		public Int32 WhichPageId { get; set; }
		public bool RecordStatus { get; set; }

	    public long? Id { get { return id; } set { id = value; } }
		private long? id;

		public long GetIdValue()
        {
			return Id.Value;
        }

		public bool Equals(IEntityExtendedId other)
		{
			if (other != null)
			{
				if (other.Id.Equals(this.Id))
				{
					return true;
				}
			}
			return false;
		}

		public void SetDefaultValuesForIEntityExtendedId()
		{
			CreatedDate = Core.Utilities.DefaultValues.DefaultValue.Today;
			UpdatedDate = Core.Utilities.DefaultValues.DefaultValue.Today;
			CreatedUser = Core.Utilities.DefaultValues.DefaultValue.DefaultCreaterUser;
			UpdatedUser = null;
			WhichPageId = Core.Utilities.DefaultValues.DefaultValue.WhichPageId;
		    RecordStatus = false;
	    }

		[NotMapped]
		public string ShowCreatedTime
        {
            get
            {
				return CreatedDate.ToString("g", CultureInfo.CreateSpecificCulture("tr-TR"));
			}
        }
	}
}
