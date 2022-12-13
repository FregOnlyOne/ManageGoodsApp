using System.Text;
using System;
using System.Security.Cryptography;

namespace ManageGoodsApp.Model;

public static class Validation
{
    public static string CreateHash(string password)
    {
        byte[] data = Encoding.Default.GetBytes(password);
        SHA1 sha1 = new SHA1CryptoServiceProvider();
        byte[] result = sha1.ComputeHash(data);
        password = Convert.ToBase64String(result);
        return password;
    }
}