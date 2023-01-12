using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public class Result : IResult
	{
		public Result(bool success ,string kod, string message  ):this(success)
		{
			Kod = kod;
			Message = message;
		}

		public Result(bool success)
		{
			Success = success;
		}
		public bool Success { get; }

		public string Message { get; }

		public string Kod { get; }
	}
}
