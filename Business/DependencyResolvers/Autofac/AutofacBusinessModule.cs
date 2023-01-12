
using Autofac;
using Business.Abstract;

using Business.Concrete;
using Business.Concrete.Managers;


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
			builder.RegisterType<JwtHelper>().As<ITokenHelper>();


		}
	}
}
