using MongoDB.Driver;
using TokenPortal.Entities;

namespace TokenPortal.Data
{
    public class TokenSeeder
    {
        private readonly IMongoCollection<Token> _tokenCollection;

        public TokenSeeder(IMongoDatabase database)
        {
            _tokenCollection = database.GetCollection<Token>("Tokens");
        }

        public void Seed()
        {
            if (!_tokenCollection.Find(_ => true).Any())
            {
                var tokens = new List<Token>
                {
                    new Token
                    {
                        Name = "Bitcoin",
                        Price = "30000.00",
                        TotalSupply = 21000000
                    },
                    new Token
                    {
                        Name = "Ethereum",
                        Price = "2000.00",
                        TotalSupply = 120000000 
                    },
                    new Token
                    {
                        Name = "Binance Coin",
                        Price = "400.00",
                        TotalSupply = 160000000
                    },
                    new Token
                    {
                        Name = "Cardano",
                        Price = "0.50", 
                        TotalSupply = 450000000
                    }
                };

                _tokenCollection.InsertMany(tokens);
            }
        }
    }
}