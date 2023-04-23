namespace Data.Model
{
    public partial class OrderDeliveryStatus : BaseModel
    {
        public DateTime? DateStatus { get; set; }
        public long? MembershipID { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Facebook { get; set; }
        public string? FacebookMessenger { get; set; }
        public string? Zalo { get; set; }
        public long? CategoryOrderStatusID { get; set; }
        public OrderDeliveryStatus()
        {
        }
    }
}
