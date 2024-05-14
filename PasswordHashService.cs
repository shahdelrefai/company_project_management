using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordHashService
{
    public string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    public bool VerifyPassword(string enteredHashedPassword, string storedHash)
    {
        return string.Equals(enteredHashedPassword, storedHash, StringComparison.OrdinalIgnoreCase);
    }
}