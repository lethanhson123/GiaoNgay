namespace Data.Model
{
    public partial class OrderDelivery : BaseModel
    {
        public DateTime? DateCreated { get; set; }
        public string? Barcode { get; set; }
        public string? BarcodeFile { get; set; }
        public string? QRcode { get; set; }
        public string? QRcodeFile { get; set; }
        public long? ShopID { get; set; }
        public string? ShopFullName { get; set; }
        public string? ShopPhone { get; set; }
        public string? ShopZalo { get; set; }
        public string? ShopEmail { get; set; }
        public string? ShopFacebook { get; set; }
        public string? ShopFacebookMessenger { get; set; }        
        public string? ShopLicenseBusinessNumber { get; set; }
        public long? ShipperID { get; set; }
        public string? ShipperFullName { get; set; }
        public string? ShipperPhone { get; set; }
        public string? ShipperZalo { get; set; }
        public string? ShipperEmail { get; set; }
        public string? ShipperFacebook { get; set; }
        public string? ShipperFacebookMessenger { get; set; }
        public string? ShipperAddress { get; set; }
        public string? ShipperLicenseMotorbicycleNumber { get; set; }
        public string? ShipperMotorbicycleNumber { get; set; }
        public string? ShipperIDNumber { get; set; }
        public long? CustomerID { get; set; }
        public string? CustomerFullName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerZalo { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerFacebook { get; set; }
        public string? CustomerFacebookMessenger { get; set; }
        public string? CustomerAddress { get; set; }
        public long? StaffID { get; set; }
        public string? StaffFullName { get; set; }
        public string? StaffPhone { get; set; }
        public string? StaffZalo { get; set; }
        public string? StaffEmail { get; set; }
        public string? StaffFacebook { get; set; }
        public string? StaffFacebookMessenger { get; set; }
        public long? CategoryOrderPaymentID { get; set; }
        public long? CategoryOrderStatusID { get; set; }
        public decimal? TotalBeforeTax { get; set; }
        public decimal? TaxVAT { get; set; }
        public decimal? TaxTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DiscountTotal { get; set; }
        public decimal? TotalAfterTax { get; set; }
        public long? BeneficiaryID { get; set; }
        public string? BeneficiaryFullName { get; set; }
        public string? BeneficiaryAccountNumber { get; set; }
        public long? BeneficiaryBankID { get; set; }
        public string? BeneficiaryQRcodeFile { get; set; }
        public string? PickupAddress { get; set; }
        public long? PickupStreetID { get; set; }
        public long? PickupWardID { get; set; }
        public long? PickupDistrictID { get; set; }
        public long? PickupProvinceID { get; set; }
        public string? DeliveryAddress { get; set; }
        public long? DeliveryStreetID { get; set; }
        public long? DeliveryWardID { get; set; }
        public long? DeliveryDistrictID { get; set; }
        public long? DeliveryProvinceID { get; set; }
        public OrderDelivery()
        {
        }
    }
}
