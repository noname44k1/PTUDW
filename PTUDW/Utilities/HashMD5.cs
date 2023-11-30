using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PTUDW.Utilities
{
    public static class HashMD5
    {
        public static string GetHash(string plainText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            // Compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(plainText));
            // Get hash result after compute it
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        //public static string MD5Hash(string input)
        //{


        //    using (var md5 = MD5.Create())
        //    {
        //        var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
        //        return Encoding.ASCII.GetString(result);
        //    }
        //}

        //private static string ComputeHash(string input)
        //{
        //    using (var md5 = MD5.Create())
        //    {
        //        var data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        //        var sb = new StringBuilder();
        //        foreach (var c in data)
        //        {
        //            sb.Append(c.ToString("x2"));
        //        }
        //        return sb.ToString();
        //    }
        //}
    }
}
