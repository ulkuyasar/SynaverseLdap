using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public class ErrorDataResult<T>:DataResult<T>
	{
		public ErrorDataResult(T data, string kod, string message) : base(data,false, kod, message)
		{ }

		public ErrorDataResult(T data) : base(data, false)
		{ }

		public ErrorDataResult(string kod, string message) : base(default, false, kod, message)
		{ }

		public ErrorDataResult( string message) : base(default, false, "-1", message)
		{ }

		public ErrorDataResult() : base(default, false, "-1","")
		{ }
	}
}
