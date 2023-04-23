using Helper;

namespace Data.Model
{
	public partial class GiaoNgayContext : DbContext
	{
		public GiaoNgayContext()
		{
		}
		public GiaoNgayContext(DbContextOptions<GiaoNgayContext> options)
			: base(options)
		{
		}
		
		public virtual DbSet<Data.Model.Bank> Bank { get; set; }
        public virtual DbSet<Data.Model.CategoryMembership> CategoryMembership { get; set; }
        public virtual DbSet<Data.Model.CategoryOrderDetail> CategoryOrderDetail { get; set; }
        public virtual DbSet<Data.Model.CategoryOrderPayment> CategoryOrderPayment { get; set; }
        public virtual DbSet<Data.Model.CategoryOrderStatus> CategoryOrderStatus { get; set; }
        public virtual DbSet<Data.Model.Company> Company { get; set; }
        public virtual DbSet<Data.Model.CompanyProfile> CompanyProfile { get; set; }
        public virtual DbSet<Data.Model.District> District { get; set; }
        public virtual DbSet<Data.Model.Membership> Membership { get; set; }
        public virtual DbSet<Data.Model.MembershipProfile> MembershipProfile { get; set; }
        public virtual DbSet<Data.Model.OrderDelivery> OrderDelivery { get; set; }
        public virtual DbSet<Data.Model.OrderDeliveryDetail> OrderDeliveryDetail { get; set; }
        public virtual DbSet<Data.Model.OrderDeliveryPaymentHistory> OrderDeliveryPaymentHistory { get; set; }
        public virtual DbSet<Data.Model.OrderDeliveryStatus> OrderDeliveryStatus { get; set; }
        public virtual DbSet<Data.Model.Province> Province { get; set; }
        public virtual DbSet<Data.Model.Street> Street { get; set; }
        public virtual DbSet<Data.Model.StreetWard> StreetWard { get; set; }
        public virtual DbSet<Data.Model.Ward> Ward { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(GlobalHelper.SQLServerConectionString);
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			OnModelCreatingPartial(modelBuilder);
		}
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
