

using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
	//JWT de kullandın
	public static class ClaimExtensions
	{
		
		public static void AddEmail(this ICollection<Claim> claims,string email)
		{
			claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
		}

		public static void AddName(this ICollection<Claim> claims, string name)
		{
			claims.Add(new Claim(ClaimTypes.Name, name));
		}

		public static void AddNameIdentifier(this ICollection<Claim> claims, string NameIdentifier)
		{
			claims.Add(new Claim(ClaimTypes.NameIdentifier, NameIdentifier));
		}

        //public static void AddLdapUser(this ICollection<Claim> claims, string NameIdentifier)
        //{
        //    //yasar LDAP userı mı olup olmadıgını cozmek ıstermısın ?
        //    //namespace System.Security.Claims
        //    //{
        //   // claims.Add(new Claim(ClaimTypes.LDAPUser mi gibi bisi, NameIdentifier));
        //}

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
		{
			roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));			
		}
	}
}
