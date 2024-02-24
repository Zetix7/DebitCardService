using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

namespace DebitCardService.ApplicationServices.Components.HashPassword;

public class PasswordHasher : IPasswordHasher
{
    public string CreateHashPassword(string password)
    {
        var salt = new byte[128 / 8];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);

        var saltString = Convert.ToBase64String(salt);
        var base64Code = Encoding.UTF8.GetBytes(saltString);
        var saltHashed = Convert.ToBase64String(base64Code);

        string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return hashedPassword + '|' + saltHashed;
    }

    public string CheckHashPassword(string password, string hashed)
    {
        var data = hashed.Split('|');
        var base64Encode = Convert.FromBase64String(data[1]);
        var saltString = Encoding.UTF8.GetString(base64Encode);
        var salt = Convert.FromBase64String(saltString);

        string hashedPassword = Convert.ToBase64String(KeyDerivation
            .Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA1, 10000, 32));

        return hashedPassword + '|' + data[1];
    }
}
