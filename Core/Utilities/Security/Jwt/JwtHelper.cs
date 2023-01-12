
using Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Extensions;
using System.Linq;
using Core.Utilities.DefaultValues;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
	public class JwtHelper : ITokenHelper
	{
		public JwtHelper(IConfiguration configuration)
		{
			Configuration = configuration;
			_tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
		}
		public IConfiguration Configuration { get; }
		private TokenOptions _tokenOptions;
		DateTime _accessTokenExpration;
		public async Task<AccessToken> CreateTokenAsync(User user, List<OperationClaim> operationClaims)
		{
			_accessTokenExpration = DefaultValue.Today.AddMinutes(_tokenOptions.AccessTokenExpiration);
			var securityKey = Encription.SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
			var signingCreatentials = Encription.SigningCredentialsHelper.CreateSigningCredentials(securityKey);
			var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCreatentials, operationClaims);
			var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			var token = jwtSecurityTokenHandler.WriteToken(jwt);

			return new AccessToken { Token = token, Expiration = _accessTokenExpration };
		}

		public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
														SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
		{
			var jwt = new JwtSecurityToken
			(
				issuer: tokenOptions.Issuer,
				audience: tokenOptions.Audience,
				expires: _accessTokenExpration,
				notBefore: DefaultValue.Today,
				claims: SetClaims(user, operationClaims),
				signingCredentials: signingCredentials
			);
			return jwt;
		}

		private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
		{
			var claims = new List<Claim>();
			claims.AddNameIdentifier(user.Id.ToString());
			claims.AddEmail(user.Email);
			claims.AddName($"{user.FirstName} {user.LastName}");
			claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
			return claims;

		}


	}
}
