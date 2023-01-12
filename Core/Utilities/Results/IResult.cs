﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public interface IResult
	{
		bool Success { get; }
		string Kod { get; }
		string Message { get; }

	}
}
