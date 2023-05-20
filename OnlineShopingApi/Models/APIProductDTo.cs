namespace OnlineShopingApi.Models
{
    public class APIProductDTo
    {
       public int Id { get; set; }

        public string LocalName { get; set; }
        public string LatinName { get; set; }
        public  byte CategoryId { get; set; }
        public string CategoryName { get; set; }
        public byte SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
    }
}
