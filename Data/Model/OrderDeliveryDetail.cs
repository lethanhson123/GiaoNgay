namespace Data.Model
{
    public partial class OrderDeliveryDetail : BaseModel
    {
        public long? CategoryOrderDetailID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public OrderDeliveryDetail()
        {
            Quantity = 1;
            Price = 0;
        }
    }
}
