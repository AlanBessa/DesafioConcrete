using System.Security.Cryptography;
using System.Text;

namespace DCS.Domain.SharedKernel.Helpers
{
    public class StringHelper
    {
        public static string Criptografar(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return "";

            valor += "|54be1d80-b6d0-45c0-b8d7-13b3c798729f";
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(valor));
            StringBuilder sbString = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
    }
}
