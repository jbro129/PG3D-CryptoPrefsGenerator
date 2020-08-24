using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PG3D_CryptoPrefsGen2
{
    internal class OldCryptoPrefsDecryptor
    {
        internal static string GetValueFromKey(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal static string UnWrapKey(string key)
        {
            UTF8Encoding utf8Encoding = new UTF8Encoding();
            byte[] bytes = utf8Encoding.GetBytes(key);
            HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider();
            byte[] array = hashAlgorithm.ComputeHash(bytes);
            string text = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                text += Convert.ToString(array[i], -16).PadRight(2, '0');
            }
            return text.PadRight(32, '0');
        }
        private static byte[] DecryptString(byte[] by, SymmetricAlgorithm alg)
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(by, 0, by.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }
        private static string DecryptString(string key, string val)
        {
            byte[] ࡍ = Convert.FromBase64String(key);
            SymmetricAlgorithm rijndaelForKey = OldCryptoPrefsDecryptor.getRijndaelForKey(val);
            byte[] array = OldCryptoPrefsDecryptor.DecryptString(ࡍ, rijndaelForKey);
            return Encoding.Unicode.GetString(array, 0, array.Length);
        }
        private static SymmetricAlgorithm getRijndaelForKey(string pass)
        {
            SymmetricAlgorithm symmetricAlgorithm;
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(pass, new byte[]
            {
                73,
                97,
                110,
                32,
                77,
                100,
                118,
                101,
                101,
                100,
                101,
                118,
                118
            });
            symmetricAlgorithm = Rijndael.Create();
            symmetricAlgorithm.Key = rfc2898DeriveBytes.GetBytes(32);
            symmetricAlgorithm.IV = rfc2898DeriveBytes.GetBytes(16);

            return symmetricAlgorithm;
        }
    }
}