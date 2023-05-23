namespace Data.Model
{
    public partial class OrderDeliveryPaymentHistory : BaseModel
    {
        public long? PayerID { get; set; }
        public string? PayerFullName { get; set; }
        public string? PayerAccountNumber { get; set; }
        public long? PayerBankID { get; set; }
        public string? MandateNumber { get; set; }
        public string? MandateFile { get; set; }
        public decimal? PaymentAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public long? BeneficiaryID { get; set; }
        public string? BeneficiaryFullName { get; set; }
        public string? BeneficiaryAccountNumber { get; set; }
        public long? BeneficiaryBankID { get; set; }
        public int? Coefficient { get; set; }
        public OrderDeliveryPaymentHistory()
        {
            PaymentAmount = GlobalHelper.InitializationNumber;
            PaymentDate = GlobalHelper.InitializationDateTime;
        }
    }
}
