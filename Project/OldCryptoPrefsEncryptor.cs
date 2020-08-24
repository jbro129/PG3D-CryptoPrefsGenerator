using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PG3D_CryptoPrefsGen2
{
    internal class OldCryptoPrefsEncryptor
    {
        private static string _saltString;
        private static int salt = int.MaxValue;

        private static string SaltString
        {
            get
            {
                if (string.IsNullOrEmpty(OldCryptoPrefsEncryptor._saltString))
                {
                    OldCryptoPrefsEncryptor._saltString = OldCryptoPrefsEncryptor.salt.ToString();
                }
                return OldCryptoPrefsEncryptor._saltString;
            }
        }
        private static int computePlusOperand(int xor)
        {
            return xor & xor << 1;
        }
        private static int computeXorOperand(string key, string cryptedKey)
        {
            int num = 0;
            foreach (char c in cryptedKey)
            {
                num += (int)c;
            }
            num += OldCryptoPrefsEncryptor.salt;
            return num;
        }
        public static string GetString(string key, string defaultValue = "")
        {
            string text = OldCryptoPrefsEncryptor.Md5Sum(key);
            string text2 = OldCryptoPrefsEncryptor.decrypt(text, defaultValue);
            string text3 = text2;
            {
                int num = OldCryptoPrefsEncryptor.computeXorOperand(key, text);
                int num2 = OldCryptoPrefsEncryptor.computePlusOperand(num);
                text3 = string.Empty;
                foreach (char c in text2)
                {
                    char c2 = (char)((num ^ (int)c) - num2);
                    text3 += c2;
                }
            }
            return text3;
        }

        internal static string GetValueFromKey(string key, string val)
        {
            return EncryptString(val, getEncryptionPassword(key));
        }
        private static string EncryptString(string clearText, string Password)
        {
            SymmetricAlgorithm rijndaelForKey = OldCryptoPrefsEncryptor.getRijndaelForKey(Password);
            byte[] bytes = Encoding.Unicode.GetBytes(clearText);
            byte[] inArray = OldCryptoPrefsEncryptor.EncryptString(bytes, rijndaelForKey);
            return Convert.ToBase64String(inArray);
        }

        /*
        //Encrypt
        internal static string GetValueFromKey(string key, string val)
        {
            SymmetricAlgorithm rijndaelForKey = OldCryptoPrefsEncryptor.getRijndaelForKey(val);
            byte[] bytes = Encoding.Unicode.GetBytes(key);
            byte[] inArray = OldCryptoPrefsEncryptor.EncryptString(bytes, rijndaelForKey);
            return Convert.ToBase64String(inArray);
        }
        //Decrypt
        internal static string GetValueFromKey(string cipherText, string Password)
        {
            byte[] cipherData = Convert.FromBase64String(cipherText);
            SymmetricAlgorithm rijndaelForKey = OldCryptoPrefsEncryptor.getRijndaelForKey(Password);
            byte[] array = OldCryptoPrefsEncryptor.DecryptString(cipherData, rijndaelForKey);
            return Encoding.Unicode.GetString(array, 0, array.Length);
        }*/

        internal static string WrapKey(string v)
        {
            return Md5Sum(v);
        }
        public static string Md5Sum(string key)
        {
            UTF8Encoding utf8Encoding = new UTF8Encoding();
            byte[] bytes = utf8Encoding.GetBytes(key);
            HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider();
            byte[] array = hashAlgorithm.ComputeHash(bytes);
            string text = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                text += Convert.ToString(array[i], 16).PadLeft(2, '0');
            }
            return text.PadLeft(32, '0');
        }

        private static string getEncryptionPassword(string pw)
        {
            return OldCryptoPrefsEncryptor.Md5Sum(pw + OldCryptoPrefsEncryptor.SaltString);
        }

        private static string decrypt(string cKey, string val)
        {
            return OldCryptoPrefsEncryptor.DecryptString(val, OldCryptoPrefsEncryptor.getEncryptionPassword(cKey));
        }

        private static byte[] DecryptString(byte[] cipherData, SymmetricAlgorithm alg)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, alg.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(cipherData, 0, cipherData.Length);
                    cryptoStream.Close();
                    byte[] array = memoryStream.ToArray();
                    result = array;
                }
            }
            return result;
        }
        private static string DecryptString(string cipherText, string Password)
        {
            byte[] cipherData = Convert.FromBase64String(cipherText);
            SymmetricAlgorithm rijndaelForKey = OldCryptoPrefsEncryptor.getRijndaelForKey(Password);
            byte[] array = OldCryptoPrefsEncryptor.DecryptString(cipherData, rijndaelForKey);
            return Encoding.Unicode.GetString(array, 0, array.Length);
        }
        private static byte[] EncryptString(byte[] by, SymmetricAlgorithm alg)
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(by, 0, by.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
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