namespace Data.Model
{
    public partial class OrderDeliveryReturn : BaseModel
    {
        public long? OrderDeliveryDetailID { get; set; }
        public long? CategoryOrderDetailID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public OrderDeliveryReturn()
        {
        }
    }
}
