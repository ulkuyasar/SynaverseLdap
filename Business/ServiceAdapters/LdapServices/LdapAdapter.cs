
//using System.DirectoryServices.Protocols;
//using System.DirectoryServices.AccountManagement;
//using System.DirectoryServices;

using System;
using System.DirectoryServices;



namespace Business.ServiceAdapters.LdapServices
{

    public class LdapAdapter : ILdapService
    {
        private static string server = "LDAP://10.34.0.180:389"; // LDAP://ldap.example.com // "ldap.example.com";
        private static int port = 389;
        private static string dn = "cn=Users,dc=example,dc=com";
        //private static string userName = "ulku.yilmaz2";
        //private static string password = "Yz123456@";

        /// <summary>
        /// LdapLogin ldap uzerınden gidiliyor
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool LdapLogin(string username, string pwd){
            using (DirectoryEntry entry = new DirectoryEntry(server, username, pwd)){
                try{
                    // Kullanıcının kimliğini doğrula
                    Object obj = entry.NativeObject;
                    Console.WriteLine("Doğrulama başarılı.");
                    return true;
                }
                catch (DirectoryServicesCOMException){
                    Console.WriteLine("Doğrulama başarısız.");
                    return false;
                }
            }

        }
    }
}
