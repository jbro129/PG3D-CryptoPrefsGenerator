using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace PG3D_CryptoPrefsGen2
{
    // Token: 0x0200089A RID: 2202
    internal class DefaultAead : IAead
    {
        // Token: 0x0600403C RID: 16444 RVA: 0x0014C740 File Offset: 0x0014A940
        public DefaultAead(byte[] masterKey)
        {
            if (masterKey == null)
            {
                throw new ArgumentNullException("masterKey");
            }
            this._aes = Rijndael.Create();
            this._aes.KeySize = 256;
            this._aes.BlockSize = 128;
            this._aes.Mode = CipherMode.CFB;
            this._aes.Padding = PaddingMode.PKCS7;
            int num = Math.Max(32, 8);
            if (masterKey.Length < num)
            {
                throw new ArgumentException("Master key should be at least " + num + " bytes.", "masterKey");
            }
            this._aesKeyBuffer = new byte[32];
            this._aesIVBuffer = new byte[this.AesIVLength];
            this._aesKeyTweak = new byte[32];
            Array.Copy(masterKey, 0, this._aesKeyTweak, 0, this._aesKeyTweak.Length);
            this._pbkdfSalt = new byte[8];
            Array.Copy(masterKey, masterKey.Length - 8, this._pbkdfSalt, 0, this._pbkdfSalt.Length);
        }

        // Token: 0x0600403D RID: 16445 RVA: 0x00027EBA File Offset: 0x000260BA
        static DefaultAead()
        {
            // Note: this type is marked as 'beforefieldinit'.
        }

        // Token: 0x17000B40 RID: 2880
        // (get) Token: 0x0600403E RID: 16446 RVA: 0x00027EC7 File Offset: 0x000260C7
        public int MaxOverhead
        {
            get
            {
                return this.NonceLength + 20 + 16;
            }
        }

        // Token: 0x17000B41 RID: 2881
        // (get) Token: 0x0600403F RID: 16447 RVA: 0x00027ED5 File Offset: 0x000260D5
        public int MinOverhead
        {
            get
            {
                return this.NonceLength + 20;
            }
        }

        // Token: 0x06004040 RID: 16448 RVA: 0x0014C84C File Offset: 0x0014AA4C
        public bool Authenticate(ArraySegment<byte> ciphertext, byte[] salt)
        {
            if (ciphertext.Count < this.NonceLength + 20)
            {
                return false;
            }
            byte[] macKey = this.GenerateMacKey(salt);
            return this.AuthenticateCore(ciphertext, macKey);
        }

        // Token: 0x06004041 RID: 16449 RVA: 0x0014C884 File Offset: 0x0014AA84
        public bool AuthenticateCore(ArraySegment<byte> ciphertext, byte[] macKey)
        {
            ArraySegment<byte> arraySegment = new ArraySegment<byte>(ciphertext.Array, ciphertext.Count - 20, 20);
            byte[] array = null;
            using (HMACSHA1 hmacsha = new HMACSHA1(macKey, true))
            {
                array = hmacsha.ComputeHash(ciphertext.Array, 0, ciphertext.Count - 20);
            }
            return DefaultAead.ConstantTimeEqual(arraySegment.Array, arraySegment.Offset, array, 0, array.Length);
        }

        // Token: 0x06004042 RID: 16450 RVA: 0x0014C90C File Offset: 0x0014AB0C
        public ArraySegment<byte> Decrypt(ArraySegment<byte> taggedCiphertext, byte[] salt, byte[] outputBuffer)
        {
            if (outputBuffer == null)
            {
                throw new ArgumentNullException("outputBuffer");
            }
            if (outputBuffer.Length < taggedCiphertext.Count - this.MinOverhead)
            {
                throw new ArgumentException("Output buffer is too short: " + outputBuffer.Length, "outputBuffer");
            }
            byte[] macKey = this.GenerateMacKey(salt);
            if (!this.AuthenticateCore(taggedCiphertext, macKey))
            {
                return default(ArraySegment<byte>);
            }
            ArraySegment<byte> result;
            try
            {
                ArraySegment<byte> arraySegment = new ArraySegment<byte>(taggedCiphertext.Array, 0, 32);
                ArraySegment<byte> arraySegment2 = new ArraySegment<byte>(taggedCiphertext.Array, arraySegment.Count, this.AesIVLength);
                ArraySegment<byte> arraySegment3 = new ArraySegment<byte>(taggedCiphertext.Array, this.NonceLength, taggedCiphertext.Count - this.NonceLength - 20);
                for (int num = 0; num != this._aesKeyBuffer.Length; num++)
                {
                    this._aesKeyBuffer[num] = Convert.ToByte(this._aesKeyTweak[num] ^ arraySegment.Array[arraySegment.Offset + num]);
                }
                Array.Copy(arraySegment2.Array, arraySegment2.Offset, this._aesIVBuffer, 0, this._aesIVBuffer.Length);
                using (ICryptoTransform cryptoTransform = this._aes.CreateDecryptor(this._aesKeyBuffer, this._aesIVBuffer))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(arraySegment3.Array, arraySegment3.Offset, arraySegment3.Count);
                            cryptoStream.Close();
                            byte[] array = memoryStream.ToArray();
                            ArraySegment<byte> arraySegment4 = new ArraySegment<byte>(outputBuffer, 0, array.Length);
                            Array.Copy(array, 0, arraySegment4.Array, arraySegment4.Offset, arraySegment4.Count);
                            result = arraySegment4;
                        }
                    }
                }
            }
            finally
            {
                Array.Clear(this._aesKeyBuffer, 0, this._aesKeyBuffer.Length);
                Array.Clear(this._aesIVBuffer, 0, this._aesIVBuffer.Length);
            }
            return result;
        }

        // Token: 0x06004043 RID: 16451 RVA: 0x0014CB90 File Offset: 0x0014AD90
        public ArraySegment<byte> Encrypt(ArraySegment<byte> plaintext, byte[] salt, byte[] outputBuffer)
        {
            if (outputBuffer == null)
            {
                throw new ArgumentNullException("outputBuffer");
            }
            if (outputBuffer.Length < plaintext.Count + this.MaxOverhead)
            {
                throw new ArgumentException("Output buffer is too short: " + outputBuffer.Length, "outputBuffer");
            }
            ArraySegment<byte> result;
            try
            {
                this._prng.GetBytes(this._aesKeyBuffer);
                this._prng.GetBytes(this._aesIVBuffer);
                ArraySegment<byte> arraySegment = new ArraySegment<byte>(outputBuffer, 0, 32);
                ArraySegment<byte> arraySegment2 = new ArraySegment<byte>(outputBuffer, arraySegment.Count, this.AesIVLength);
                Array.Copy(this._aesKeyBuffer, 0, arraySegment.Array, arraySegment.Offset, arraySegment.Count);
                Array.Copy(this._aesIVBuffer, 0, arraySegment2.Array, arraySegment2.Offset, arraySegment2.Count);
                for (int num = 0; num != this._aesKeyBuffer.Length; num++)
                {
                    this._aesKeyBuffer[num] = Convert.ToByte(this._aesKeyTweak[num] ^ this._aesKeyBuffer[num]);
                }
                using (ICryptoTransform cryptoTransform = this._aes.CreateEncryptor(this._aesKeyBuffer, this._aesIVBuffer))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plaintext.Array, plaintext.Offset, plaintext.Count);
                            cryptoStream.Close();
                            byte[] array = memoryStream.ToArray();
                            ArraySegment<byte> arraySegment3 = new ArraySegment<byte>(outputBuffer, this.NonceLength, array.Length);
                            Array.Copy(array, 0, arraySegment3.Array, arraySegment3.Offset, arraySegment3.Count);
                            ArraySegment<byte> arraySegment4 = new ArraySegment<byte>(outputBuffer, 0, this.NonceLength + arraySegment3.Count + 20);
                            byte[] key = this.GenerateMacKey(salt);
                            using (HMACSHA1 hmacsha = new HMACSHA1(key, true))
                            {
                                ArraySegment<byte> arraySegment5 = new ArraySegment<byte>(outputBuffer, arraySegment4.Count - 20, 20);
                                byte[] sourceArray = hmacsha.ComputeHash(arraySegment4.Array, 0, this.NonceLength + arraySegment3.Count);
                                Array.Copy(sourceArray, 0, arraySegment5.Array, arraySegment5.Offset, arraySegment5.Count);
                            }
                            result = arraySegment4;
                        }
                    }
                }
            }
            finally
            {
                Array.Clear(this._aesKeyBuffer, 0, this._aesKeyBuffer.Length);
                Array.Clear(this._aesIVBuffer, 0, this._aesIVBuffer.Length);
            }
            return result;
        }

        // Token: 0x06004044 RID: 16452 RVA: 0x0014CEA0 File Offset: 0x0014B0A0
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static public bool ConstantTimeEqual(byte[] left, int leftOffset, byte[] right, int rightOffset, int length)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }
            if (right == null)
            {
                throw new ArgumentNullException("right");
            }
            if (leftOffset < 0)
            {
                throw new ArgumentOutOfRangeException("leftOffset", "leftOffset < 0");
            }
            if (rightOffset < 0)
            {
                throw new ArgumentOutOfRangeException("rightOffset", "rightOffset < 0");
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "length < 0");
            }
            if (leftOffset + length > left.Length)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "leftOffset + length > left.Length: {0} + {1} > {2}", new object[]
                {
                    leftOffset,
                    length,
                    left.Length
                }));
            }
            if (rightOffset + length > right.Length)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "rightOffset + length > right.Length: {0} + {1} > {2}", new object[]
                {
                    rightOffset,
                    length,
                    right.Length
                }));
            }
            int num = 0;
            for (int num2 = 0; num2 != length; num2++)
            {
                num |= (int)(left[leftOffset + num2] ^ right[rightOffset + num2]);
            }
            return num == 0;
        }

        // Token: 0x06004045 RID: 16453 RVA: 0x0014CFC8 File Offset: 0x0014B1C8
        public byte[] GenerateMacKey(byte[] salt)
        {
            byte[] password = salt ?? DefaultAead.s_emptyByteArray;
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, this._pbkdfSalt, 1);
            return rfc2898DeriveBytes.GetBytes(64);
        }

        // Token: 0x17000B42 RID: 2882
        // (get) Token: 0x06004046 RID: 16454 RVA: 0x00027EE0 File Offset: 0x000260E0
        public int AesIVLength
        {
            get
            {
                return 16;
            }
        }

        // Token: 0x17000B43 RID: 2883
        // (get) Token: 0x06004047 RID: 16455 RVA: 0x00027EE4 File Offset: 0x000260E4
        public int NonceLength
        {
            get
            {
                return 32 + this.AesIVLength;
            }
        }

        // Token: 0x040032D1 RID: 13009
        public const int AesBlockLength = 16;

        // Token: 0x040032D2 RID: 13010
        public const int AesKeyLength = 32;

        // Token: 0x040032D3 RID: 13011
        public const int TagLength = 20;

        // Token: 0x040032D4 RID: 13012
        public static readonly byte[] s_emptyByteArray = new byte[0];

        // Token: 0x040032D5 RID: 13013
        public readonly byte[] _aesKeyTweak;

        // Token: 0x040032D6 RID: 13014
        public readonly byte[] _pbkdfSalt;

        // Token: 0x040032D7 RID: 13015
        public readonly byte[] _aesKeyBuffer;

        // Token: 0x040032D8 RID: 13016
        public readonly byte[] _aesIVBuffer;

        // Token: 0x040032D9 RID: 13017
        public readonly SymmetricAlgorithm _aes;

        // Token: 0x040032DA RID: 13018
        public readonly DefaultAead.CustomRandomNumberGenerator _prng = new DefaultAead.CustomRandomNumberGenerator();

        // Token: 0x0200089B RID: 2203
        public sealed class CustomRandomNumberGenerator
        {
            // Token: 0x06004048 RID: 16456 RVA: 0x00027EEF File Offset: 0x000260EF
            public CustomRandomNumberGenerator()
            {
            }

            // Token: 0x06004049 RID: 16457 RVA: 0x00027F02 File Offset: 0x00026102
            public void GetBytes(byte[] data)
            {
                if (data == null)
                {
                    return;
                }
                if (data.Length == 0)
                {
                    return;
                }
                this._prng.GetBytes(data);
            }

            // Token: 0x040032DB RID: 13019
            public readonly RNGCryptoServiceProvider _prng = new RNGCryptoServiceProvider();
        }
    }
}