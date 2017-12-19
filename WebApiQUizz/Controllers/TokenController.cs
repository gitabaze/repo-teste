using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WebApiQUizz.Models;

namespace WebApiQUizz.Controllers
{
    public class TokenController : ApiController
    {

        public Token Get(int id)
        {
            return GetList().FirstOrDefault(t=>t.ID==id);
        }

        public IEnumerable<Token> Get()
        {
            return GetList();
        }

        List<Token> GetList()
        {
            return new List<Token>
            {
                new Token { ID=1, CompanyID=1, key="KEKY2450", CreateOn="10" , ExpireOn="17", IssueOn="1"},
                new Token { ID=2, CompanyID=1, key="KEKYUU6", CreateOn="10" , ExpireOn="22", IssueOn="10"},
                 new Token { ID=3, CompanyID=3, key="ER34RAAP", CreateOn="10" , ExpireOn="22", IssueOn="10"}

            };
        }
        [AllowAnonymous]
        void  Get(string id)
        {
       //    var cle =JwtAuthForWebAPI. JwtManager.GenerateToken(id);


        }
        [AllowAnonymous]
        //public string Get(string username, string password)
        //{
        //    if (CheckUser(username, password))
        //    {
        //        return JwtManager.GenerateToken(username);
        //    }

        //    throw new HttpResponseException(HttpStatusCode.Unauthorized);
        //}

        public bool CheckUser(string username, string password)
        {
            // should check in the database
            return true;
        }

        //return JwtManager.GenerateToken(username);
    }

    public static class KeyGenerator
    {
        //public static string GetUniqueKey(int maxSize = 15)
        //{
        //    char[] chars = new char[62];
        //    chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        //    byte[] data = new byte[1];
        //    using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
        //    {
        //        crypto.GetNonZeroBytes(data);
        //        Data = new byte[maxSize];
        //        crypto.GetNonZeroBytes(data);
        //    }
        //    StringBuilder result = new StringBuilder(maxSize);
        //    foreach (byte b in data)
        //    {
        //        result.Append(chars[b % (chars.Length)]);
        //    }
        //    return result.ToString();
        //}
    }

}
