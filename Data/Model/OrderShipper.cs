namespace Data.Model
{
    public partial class OrderShipper : BaseModel
    {
        public DateTime? DateCreated { get; set; }
        public long? ShipperID { get; set; }
        public OrderShipper()
        {
            DateCreated = GlobalHelper.InitializationDateTime;
        }
    }
}
