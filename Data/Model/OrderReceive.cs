namespace Data.Model
{
    public partial class OrderReceive : BaseModel
    {
        public DateTime? DateCreated { get; set; }
        public long? ReceiveID { get; set; }
        public OrderReceive()
        {
        }
    }
}
