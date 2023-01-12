using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public class ErrorResult : Result
	{

		public ErrorResult(string kod, string message)  : base(false, kod,message)
		{ }

		public ErrorResult(string message) : base(false, "-1", message)
		{ }

		public ErrorResult() : base(false)
		{ }
	}
}
