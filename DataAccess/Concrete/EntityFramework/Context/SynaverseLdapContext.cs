using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;

namespace DataAccess.Concrete.EntityFramework.Context
{
	public class SynaverseLdapContext : DbContext
	{
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			JToken jAppSettings = null;
			if (Core.Utilities.DefaultValues.DefaultValue.IsDevelopmetEnvironment)
			    jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.Development.json")));
			else
			     jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));


			var connectionString = jAppSettings["ConnectionStrings"].SelectToken("SynaverseLdapContext").ToString();
			//var connectionString = "Server=.;Database=Northwind;User Id=sa;Password = 10141014;"; //Configuration.GetConnectionString("TombalaContext");
			optionsBuilder.UseSqlServer(connectionString);


		}

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);
		//	modelBuilder.Properties<string>().Configure(x => x.HasColumnType("VARCHAR"));
		//}



		#region Ortak
		public DbSet<OperationClaim> OperationClaims { get; set; }
		public DbSet<UserOperationClaim> UserOperationClaims { get; set; }		 
		public DbSet<User> Users { get; set; }		
		public DbSet<UserDetail> UserDetails { get; set; }
		#endregion Ortak



	}
}
