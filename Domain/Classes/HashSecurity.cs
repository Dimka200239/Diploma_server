using System.Security.Cryptography;

namespace Domain.Classes
{
    public class HashSecurity
    {
        public string Text { get; }
        public HashSecurity(string password, DateTime DateAutification)
        {
            Text = HashingPassword(password, DateAutification);
        }

        string HashingPassword(string password, DateTime DateAutification)
        {

            byte[] salt = MakeSalt(DateAutification);
            // new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        byte[] MakeSalt(DateTime DateAutification)
        {
            return new byte[] { Convert.ToByte(DateAutification.Hour + 1), Convert.ToByte(DateAutification.Month + 1), Convert.ToByte(DateAutification.Day + 1), 4, 5, 6, 7, 8, 9, Convert.ToByte(DateAutification.Second + 1), 11, 12, 13, 14, 15, 22 };
        }
    }
}
