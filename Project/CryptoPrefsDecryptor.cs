using System;
using System.Text;

namespace PG3D_CryptoPrefsGen2
{
    internal class CryptoPrefsDecryptor
    {
        private static readonly byte[] key = Convert.FromBase64String("SB6epSJtheapBMeVL6SfaSlIBmMBUmPxrDY8aB2JJW0ceIOEXR6hmw==");

        private static readonly AesFacade _aesFacade = new AesFacade(key);

        private static readonly DefaultAead _aead = new DefaultAead(key);

        private static WeakReference _bufferWeakReference;

        private static UTF8Encoding s_defaultEncoding = new UTF8Encoding(false, false);
        internal static string UnWrapKey(string key)
        {
            string key1 = key.Replace("AEAD:", "").Replace(" ","+");
            byte[] keyBytes = CryptoPrefsDecryptor.s_defaultEncoding.GetBytes(key1);
            byte[] buffer = CryptoPrefsDecryptor.GetBuffer(keyBytes.Length + CryptoPrefsDecryptor._aead.MaxOverhead);
            string result2;
            try
            {
                byte[] text = Convert.FromBase64String(key1);
                byte[] inArray = CryptoPrefsDecryptor._aesFacade.Decrypt(text);
                String result = Encoding.UTF8.GetString(inArray);
                result2 = result;
            }
            catch (Exception message)
            {
                string text2 = Convert.ToBase64String(keyBytes);
                result2 = message.StackTrace;
            }
            finally
            {
                Array.Clear(buffer, 0, buffer.Length);
            }
            return result2;
        }
        internal static byte[] GetBuffer(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "Must be non-negative.");
            }
            if (CryptoPrefsDecryptor._bufferWeakReference != null && CryptoPrefsDecryptor._bufferWeakReference.IsAlive)
            {
                byte[] array = (byte[])CryptoPrefsDecryptor._bufferWeakReference.Target;
                if (array.Length >= length)
                {
                    return array;
                }
            }
            byte[] array2 = new byte[length];
            CryptoPrefsDecryptor._bufferWeakReference = new WeakReference(array2, false);
            return array2;
        }
        internal static string GetValueFromKey(string key, string value)
        {
            byte[] bytes = CryptoPrefsDecryptor.s_defaultEncoding.GetBytes(UnWrapKey(key));
            string result;
            try
            {
                string @string = value;
                {
                    byte[] array = Convert.FromBase64String(@string);
                    {
                        byte[] buffer = CryptoPrefsDecryptor.GetBuffer(array.Length - CryptoPrefsDecryptor._aead.MinOverhead);
                        try
                        {
                            ArraySegment<byte> arraySegment = CryptoPrefsDecryptor._aead.Decrypt(new ArraySegment<byte>(array), bytes, buffer);
                            string string2 = CryptoPrefsDecryptor.s_defaultEncoding.GetString(arraySegment.Array, arraySegment.Offset, arraySegment.Count);
                            result = string2;
                        }
                        finally
                        {
                            Array.Clear(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
            catch (Exception message)
            {
                result = message.StackTrace;
            }
            return result;
        }
    }
}