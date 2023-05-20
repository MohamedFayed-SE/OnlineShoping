using System.Text.Json;

namespace OnlineShopingApi.Models
{
    public class APIResponse
    {
        public APIResponse()
        {

        }
        public APIResponse(object result)
        {
            this.Result = result;
        }
        public int Code { get; set; } = 200;
        public string Status { get; set; } = "Success";

        public object  Result { get; set; }

        public List<string> Errors { get; set; }
        public string ExceptionError { get; set; }


        public override string ToString()
        {
            var result = JsonSerializer.Serialize(this);
            return result;
           
        }

    }
}
