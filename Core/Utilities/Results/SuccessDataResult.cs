using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public class SuccessDataResult<T>:DataResult<T>
	{
		public SuccessDataResult(T data, string kod, string message) : base(data,true, kod, message)
		{ }

		public SuccessDataResult(T data) : base(data, true)
		{ }

		public SuccessDataResult(T data, string message) : base(data, true, "00", message)
		{ }

		public SuccessDataResult(string kod, string message) : base(default, true, kod, message)
		{ }

		public SuccessDataResult( string message) : base(default, true, "00", message)
		{ }

		public SuccessDataResult() : base(default, true, "00","")
		{ }
	}
}
