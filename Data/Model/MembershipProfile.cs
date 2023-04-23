namespace Data.Model
{
    public partial class MembershipProfile : BaseModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Zalo { get; set; }
        public string? Phone { get; set; }
        public string? Facebook { get; set; }
        public string? FacebookMessenger { get; set; }
        public string? IDNumber { get; set; }
        public string? AddressLegal { get; set; }
        public string? Address { get; set; }
        public string? LicenseMotorbicycleNumber { get; set; }
        public string? FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? LicenseBusinessNumber { get; set; }
        public MembershipProfile()
        {
        }
    }
}
