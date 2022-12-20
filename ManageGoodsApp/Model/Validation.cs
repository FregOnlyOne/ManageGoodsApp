using System.Text;
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

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

    public static bool IsNullString(string str)
    {
        return (string.IsNullOrEmpty(str) || str.Replace(" ", "").Length == 0);
    }

    public static bool IsPhoneNumber(string number)
    {
        return Regex.Match(number, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$").Success;
    }

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}