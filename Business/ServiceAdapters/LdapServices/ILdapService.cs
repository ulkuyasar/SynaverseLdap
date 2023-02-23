using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceAdapters.LdapServices
{

	
	public interface ILdapService
    {
        bool LdapLogin(string username, string pwd);

	}
}
