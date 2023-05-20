using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace OnlineShopingApi.Exceptions
{
    public class NotFoundException:Exception
    {

        public NotFoundException(string message):base(message)
        {

        }

       
        
    }
}
