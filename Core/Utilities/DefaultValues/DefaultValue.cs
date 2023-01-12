using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.DefaultValues
{
	public static class DefaultValue
	{
		public static DateTime Today{
			get { return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(SystemTimeZoneName)); } //FindSystemTimeZoneById("Russian Standard Time")); }
		}
		public static string DefaultCreaterUser = "DefaultCreaterUser";
		
		/// <summary>
		/// 19 mayıs 1919
		/// </summary>
		public static DateTime DefaultTime = new DateTime(1919,5,19);
		public static int WhichPageId = 1;
		public static string SystemTimeZoneName = "Europe/Moscow";

		public static bool IsDevelopmetEnvironment = false;




	}
}
