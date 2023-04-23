namespace Data.Model
{
    public partial class Company : BaseModel
    {
        public string? LicenseBusinessNumber { get; set; }
        public string? FullName { get; set; }
        public string? AccountNumber { get; set; }
        public string? BankID { get; set; }
        public string? QRcodeFile { get; set; }        
        public Company()
        {
        }
    }
}
