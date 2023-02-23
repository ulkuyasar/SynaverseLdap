using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.MethodAspects.Autofac
{
	public class SecuredOperation : MethodInterception // aspect olmanın kosulu
	{
		private string[] _roles;
		private IHttpContextAccessor _httpContextAccessor;

		public SecuredOperation(string roles)
		{
			_roles = roles.Split(',');
			_httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();  // depency enjection cozumlerıne kavusmak ıcın uygulanan yapı
		}

		protected override void OnBefore(IInvocation invocation)
		{
			var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
			foreach (var role in _roles)
			{
				if (roleClaims.Contains(role))
				{
					return;
				}
			}
			throw new Exception(Messages.AuthorizationDenied);
		}


	}
}
