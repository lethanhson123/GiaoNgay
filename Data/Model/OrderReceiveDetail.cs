namespace Data.Model
{
    public partial class OrderReceiveDetail : BaseModel
    {        
        public long? OrderDeliveryID { get; set; }
        public string Barcode { get; set; }
        public OrderReceiveDetail()
        {
        }
    }
}
