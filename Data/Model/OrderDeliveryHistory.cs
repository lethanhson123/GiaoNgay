namespace Data.Model
{
    public partial class OrderDeliveryHistory : BaseModel
    {
        public DateTime? DateCreated { get; set; }
        public long? ShipperID { get; set; }
        public string? ShipperFullName { get; set; }
        public OrderDeliveryHistory()
        {
            DateCreated = GlobalHelper.InitializationDateTime;
        }
    }
}
