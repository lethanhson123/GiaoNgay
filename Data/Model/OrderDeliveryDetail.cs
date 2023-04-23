namespace Data.Model
{
    public partial class OrderDeliveryDetail : BaseModel
    {
        public long? CategoryOrderDetailID { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public OrderDeliveryDetail()
        {
        }
    }
}
