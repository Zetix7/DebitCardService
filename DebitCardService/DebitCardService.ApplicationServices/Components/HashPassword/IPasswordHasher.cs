namespace DebitCardService.ApplicationServices.Components.HashPassword;

public interface IPasswordHasher
{
    string CreateHashPassword(string password);
    string CheckHashPassword(string password, string hashedSalt);
}
