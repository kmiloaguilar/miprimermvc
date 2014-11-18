namespace Domain.Services
{
    public interface IPasswordEncryptor
    {
        string Encrypt(string clearTextPassword);
    }
}