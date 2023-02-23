
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;

using Business.Concrete;
using Business.Concrete.Managers;
using Business.ServiceAdapters.LdapServices;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{


			builder.RegisterType<UserManager>().As<IUserService>();
			builder.RegisterType<EfUserDal>().As<IUserDal>();

			builder.RegisterType<UserDetailManager>().As<IUserDetailService>();
			builder.RegisterType<EfUserDetailDal>().As<IUserDetailDal>();

			builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
			builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

			builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
			builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

			builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<LdapAdapter>().As<ILdapService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            // butun aspect eklemelerı burada eklenıyor
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
	}
}
