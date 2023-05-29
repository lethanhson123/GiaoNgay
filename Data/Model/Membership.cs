namespace Data.Model
{
    public partial class Membership : BaseModel
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
        public string? MotorbicycleNumber { get; set; }
        public string? FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? LicenseBusinessNumber { get; set; }
        public long? ProvinceID { get; set; }
        public long? DistrictID { get; set; }
        public long? WardID { get; set; }
        public string? AccountNumber { get; set; }
        public long? BankID { get; set; }
        public decimal? TotalDebt { get; set; }
        public Membership()
        {
        }
    }
}

