namespace Data.Model
{
    public partial class OrderShipperDetail : BaseModel
    {        
        public long? OrderDeliveryID { get; set; }
        public string Barcode { get; set; }
        public OrderShipperDetail()
        {
        }
    }
}
