using System.Security.Cryptography;

namespace Domain.Classes
{
    public class HashPassword
    {
        public string Text { get; }
        DateTime ErrorDate = new DateTime(1111, 1, 1, 1, 1, 1);
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="password">пароль</param>
        /// <param name="DateAutification">дата регистрации</param>
        public HashPassword(string password, string DateAutification)
        {
            var date = StringGToDateTime(DateAutification);
            if (date != ErrorDate)
            { Text = HashingPassword(password, date); }
        }
        /// <summary>
        /// Конвертер строки в формат dateTime
        /// </summary>
        /// <param name="datestring">строки вида "dd/MM/yyyy hh:mm:ss"</param>
        /// <returns>преобразованное время</returns>
        public DateTime StringGToDateTime(string datestring)
        {
            try
            {
                char datetimesplit = ' ';
                char datesplit = '.';
                char timesplit = ':';

                var splitDateTime = datestring.Split(datetimesplit);
                var date = splitDateTime[0].Split(datesplit);
                var time = splitDateTime[1].Split(timesplit);
                DateTime datetime = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                return datetime;
            }
            catch (Exception ex)
            {

                DateTime dateTime;
                datestring = datestring.Replace('.', '/');
                var res = DateTime.TryParse(datestring, out dateTime);
                if (res) return dateTime;
                else
                {
                    //FileStreamClass.WriteToFormAction("Не удалось преобразовать string в формат даты и времени. " + ex.Message);
                    return ErrorDate;
                }
            }
        }

        /// <summary>
        /// метод хеширования пароля
        /// </summary>
        /// <param name="password">пароль</param>
        /// <param name="DateAutification">дата регистрации</param>
        /// <returns>зашифрованный пароль</returns>
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
        /// <summary>
        /// метод генирации соли для хеширования
        /// </summary>
        /// <param name="DateAutification"></param>
        /// <returns>соль для хеширования</returns>
        byte[] MakeSalt(DateTime DateAutification)
        {
            return new byte[] { Convert.ToByte(DateAutification.Hour + 1), Convert.ToByte(DateAutification.Month + 1), Convert.ToByte(DateAutification.Day + 1), 4, 5, 6, 7, 8, 9, Convert.ToByte(DateAutification.Second + 1), 11, 12, 13, 14, 15, 22 };
        }
    }
}
