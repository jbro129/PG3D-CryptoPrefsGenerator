using System;
using System.Text;

namespace PG3D_CryptoPrefsGen2
{
    internal class CryptoPrefsCreater
    {

        private static readonly byte[] key = Convert.FromBase64String("SB6epSJtheapBMeVL6SfaSlIBmMBUmPxrDY8aB2JJW0ceIOEXR6hmw==");

        private static readonly AesFacade _aesFacade = new AesFacade(key);

        private static readonly DefaultAead _aead = new DefaultAead(key);

        private static WeakReference _bufferWeakReference;

        private static UTF8Encoding s_defaultEncoding = new UTF8Encoding(false, false);

        internal static string WrapKey(byte[] keyBytes)
        {
            byte[] buffer = CryptoPrefsCreater.GetBuffer(keyBytes.Length + CryptoPrefsCreater._aead.MaxOverhead);
            string result2;
            try
            {
                byte[] inArray = CryptoPrefsCreater._aesFacade.Encrypt(keyBytes);
                string text = "AEAD:" + Convert.ToBase64String(inArray);
                result2 = text;
            }
            catch (Exception)
            {
                string text2 = Convert.ToBase64String(keyBytes);
                result2 = text2;
            }
            finally
            {
                Array.Clear(buffer, 0, buffer.Length);
            }
            return result2;
        }
        internal static string WrapKey(string key)
        {
            byte[] bytes = CryptoPrefsCreater.s_defaultEncoding.GetBytes(key);
            return CryptoPrefsCreater.WrapKey(bytes);
        }
        internal static byte[] GetBuffer(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "Must be non-negative.");
            }
            if (CryptoPrefsCreater._bufferWeakReference != null && CryptoPrefsCreater._bufferWeakReference.IsAlive)
            {
                byte[] array = (byte[])CryptoPrefsCreater._bufferWeakReference.Target;
                if (array.Length >= length)
                {
                    return array;
                }
            }
            byte[] array2 = new byte[length];
            CryptoPrefsCreater._bufferWeakReference = new WeakReference(array2, false);
            return array2;
        }
        internal static string GetValueFromKey(string key, string value)
        {
            string result = "";
            if (key == null)
            {
                return "";
            }
            byte[] bytes = CryptoPrefsCreater.s_defaultEncoding.GetBytes(key);
            try
            {
                byte[] bytes2 = CryptoPrefsCreater.s_defaultEncoding.GetBytes(value);
                byte[] buffer = CryptoPrefsCreater.GetBuffer(bytes2.Length + CryptoPrefsCreater._aead.MaxOverhead);
                try
                {
                    ArraySegment<byte> arraySegment = CryptoPrefsCreater._aead.Encrypt(new ArraySegment<byte>(bytes2), bytes, buffer);
                    string text2 = Convert.ToBase64String(arraySegment.Array, arraySegment.Offset, arraySegment.Count);
                    result = text2;
                    return result;
                }
                finally
                {
                    Array.Clear(buffer, 0, buffer.Length);
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
    }
}