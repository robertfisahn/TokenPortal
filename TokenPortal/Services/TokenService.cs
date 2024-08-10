using MongoDB.Driver;
using TokenPortal.Entities;
using TokenPortal.Enums;
using TokenPortal.Interface;

namespace TokenPortal.Services
{
    public class TokenService : ITokenService
    {
        private readonly IMongoCollection<Token> _tokenCollection;
        public TokenService(IMongoDatabase database)
        {
            _tokenCollection = database.GetCollection<Token>("Tokens");
        }

        public List<Token> GetTokens()
        {
            return _tokenCollection.Find(token => true).ToList();
        }

        public Token GetTokenById(string id)
        {
            var token = _tokenCollection.Find(t => t.Id == id).FirstOrDefault() ?? throw new Exception();
            return token;
        }

        public void CreateToken(Token token)
        {
            _tokenCollection.InsertOne(token);
        }

        public void DeleteToken(string id)
        {
            _tokenCollection.DeleteOne(t => t.Id == id);
        }

        public void UpdateToken(Token token)
        {
            var filter = Builders<Token>.Filter.Eq(t => t.Id, token.Id);
            _tokenCollection.ReplaceOne(filter, token);
        }

        //public void UpdateToken(string tokenId, int amount, OperationType operationType)
        //{
        //    var filter = Builders<Token>.Filter.Eq(t => t.Id, tokenId);
        //    int amountToAdjust = operationType == OperationType.Buy ? -amount : amount;
        //    var update = Builders<Token>.Update.Inc(t => t.TotalSupply, amountToAdjust);
        //    _tokenCollection.UpdateOne(filter, update);
        //}
    }
}
