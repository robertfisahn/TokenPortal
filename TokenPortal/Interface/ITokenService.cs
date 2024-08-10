using TokenPortal.Entities;
using TokenPortal.Enums;

namespace TokenPortal.Interface
{
    public interface ITokenService
    {
        List<Token> GetTokens();
        void CreateToken(Token token);
        void DeleteToken(string id);
        void UpdateToken(Token token);
    }
}
