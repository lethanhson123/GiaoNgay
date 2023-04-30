namespace Data.Model
{
    public partial class CategoryOrderDetail : BaseModel
    {
        public decimal? Price { get; set; }
        public decimal? Quantity { get; set; }
        public CategoryOrderDetail()
        {
        }
    }
}
