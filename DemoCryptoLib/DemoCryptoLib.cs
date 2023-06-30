using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DemoCryptoLib;

public class DemoCryptoLib
{
    private const int Iterate = 10000;

    public static string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
    {
        var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, Iterate);

        byte[] hash = pbkdf2.GetBytes(20);

        var hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        string passwordHash = Convert.ToBase64String(hashBytes);

        return passwordHash;
    }

    public static string GeneratePasswordHashUsingSaltOptimized(string passwordText, ReadOnlySpan<byte> salt)
    {
        Span<byte> pbkdf2Bytes = stackalloc byte[20];
        Rfc2898DeriveBytes.Pbkdf2(passwordText.AsSpan(), salt, pbkdf2Bytes, Iterate, HashAlgorithmName.SHA1);

        Span<byte> hashBytes = stackalloc byte[36];
        salt.CopyTo(hashBytes);
        pbkdf2Bytes.CopyTo(hashBytes[16..]);

        string passwordHash = Convert.ToBase64String(hashBytes);

        return passwordHash;
    }
}