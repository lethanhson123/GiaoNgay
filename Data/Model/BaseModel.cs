
namespace Data.Model
{
	public class BaseModel
	{
		public long ID { get; set; }
		public long? ParentID { get; set; }
		public DateTime? CreatedDate { get; set; }
		public long? CreatedMembershipID { get; set; }
		public DateTime? LastUpdatedDate { get; set; }
		public long? LastUpdatedMembershipID { get; set; }
		public int? RowVersion { get; set; }
		public string? Name { get; set; }
		public string? Code { get; set; }
		public string? Display { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public int? SortOrder { get; set; }
        public BaseModel()
		{            
        }
	}
}
