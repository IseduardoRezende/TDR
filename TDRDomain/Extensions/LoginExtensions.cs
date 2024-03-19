using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using TDRData.Models;

namespace TDRDomain.Extensions
{
    public static class LoginExtension
    {       
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            string regex = @"^[^@\s]+\.[^@\s]+[0-9]{0,20}@(fatec)\.(sp)\.(gov)\.(br)$";
            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

        public static bool IsDefaultUser(this string email, Settings settings) 
        {
            if (settings == null || string.IsNullOrEmpty(email)) return false;

            if (email.Equals(settings.AdmEmailMorning, StringComparison.OrdinalIgnoreCase) || 
                email.Equals(settings.AdmEmailEvening, StringComparison.OrdinalIgnoreCase) || 
                email.Equals(settings.AdmEmail, StringComparison.OrdinalIgnoreCase))
                return false;

            return true;
        }

        public static string ConvertToSHA512(this string value, string salt)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(salt))
                throw new Exception("Invalid Value.");

            var data = Encoding.UTF8.GetBytes(string.Concat(value, salt));
            return Convert.ToBase64String(SHA512.HashData(data));
        }

        public static string BuildEmail(this string email)
        {
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
                throw new Exception("Invalid Email.");

            return email.ToLowerInvariant();
        }
    }
}
