namespace Data.Model
{
    public partial class StreetWard : BaseModel
    {
        public long? WardID { get; set; }
        public int? NumberBegin { get; set; }
        public int? NumberEnd { get; set; }       
        public StreetWard()
        {
        }
    }
}
