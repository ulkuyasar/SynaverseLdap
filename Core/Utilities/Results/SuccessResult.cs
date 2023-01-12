using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public class SuccessResult: Result
	{

		public SuccessResult(string kod, string message)  : base(true, kod,message)
		{ }

		public SuccessResult( string message) : base(true, "00", message)
		{ }

		public SuccessResult() : base(true)
		{ }
	}
}
