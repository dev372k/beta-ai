using System.Security.Cryptography;

namespace SharedKernel.Helpers;

public class SecurityHelper
{


    public static string GenerateHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool ValidateHash(string password, string actualPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, actualPassword);
    }

    public static string GenerateApiKey(int length = 32)
    {
        byte[] apiKeyBytes = new byte[length];
        RandomNumberGenerator.Fill(apiKeyBytes);
        return Convert.ToBase64String(apiKeyBytes)
                      .Replace("+", "-")
                      .Replace("/", "_")
                      .TrimEnd('=');
    }
}
