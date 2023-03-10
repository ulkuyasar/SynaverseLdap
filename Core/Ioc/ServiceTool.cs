using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Ioc
{
	public static class ServiceTool
	{
		public static IServiceProvider ServiceProvider { get; set; }

		public static IServiceCollection Create(IServiceCollection service)
		{
			ServiceProvider = service.BuildServiceProvider();
			return service;
		}

	}
}
