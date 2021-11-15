namespace Compulsory.Security.Authenticator
{
    public interface IAuthenticator
    {
        bool Login(string username, string password, out string token);
    }
}