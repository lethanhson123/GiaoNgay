namespace Data.Model
{
    public partial class MembershipAuthenticationToken : BaseModel
    {
        public string? AuthenticationToken { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public MembershipAuthenticationToken()
        {
        }
    }
}
