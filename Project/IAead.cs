using System;

namespace PG3D_CryptoPrefsGen2
{
    internal interface IAead
    {
        // Token: 0x17000B44 RID: 2884
        // (get) Token: 0x0600405A RID: 16474
        int MaxOverhead { get; }

        // Token: 0x17000B45 RID: 2885
        // (get) Token: 0x0600405B RID: 16475
        int MinOverhead { get; }

        // Token: 0x0600405C RID: 16476
        bool Authenticate(ArraySegment<byte> taggedCiphertext, byte[] salt);

        // Token: 0x0600405D RID: 16477
        ArraySegment<byte> Decrypt(ArraySegment<byte> taggedCiphertext, byte[] salt, byte[] outputBuffer);

        // Token: 0x0600405E RID: 16478
        ArraySegment<byte> Encrypt(ArraySegment<byte> plaintext, byte[] salt, byte[] outputBuffer);
    }
}