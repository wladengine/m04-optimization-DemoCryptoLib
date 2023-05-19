using System;
using System.Security.Cryptography;

namespace DemoCryptoLib;

public class DemoCryptoLib
{
    public static string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
    {
        const int iterate = 10000;
        var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);

        byte[] hash = pbkdf2.GetBytes(20);

        var hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        string passwordHash = Convert.ToBase64String(hashBytes);

        return passwordHash;
    }

    public static string GeneratePasswordHashUsingSaltOptimized(string passwordText, byte[] salt)
        => GeneratePasswordHashUsingSalt(passwordText, salt);
}