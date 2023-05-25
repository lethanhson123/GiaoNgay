namespace Data.Model
{
    public partial class OrderCall : BaseModel
    {
        public long? ShopID { get; set; }
        public long? ShipperID { get; set; }
        public DateTime? DateCreated { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public string? ShopFullName { get; set; }
        public string? ShopAddress { get; set; }
        public string? ShipperFullName { get; set; }
        public string? ShipperAddress { get; set; }
        public OrderCall()
        {
            DateCreated = GlobalHelper.InitializationDateTime;
            Quantity = 1;
        }
    }
}
