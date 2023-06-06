namespace Data.Model
{
    public partial class CategoryOrderDetail : BaseModel
    {
        public decimal? Price { get; set; }
        public decimal? Quantity { get; set; }
        public long? ProvinceID { get; set; }
        public long? DistrictID { get; set; }
        public long? WardID { get; set; }
        public CategoryOrderDetail()
        {
            Price = GlobalHelper.InitializationNumber;
            Quantity = GlobalHelper.InitializationNumber;
        }
    }
}
