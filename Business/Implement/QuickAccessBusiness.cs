namespace Business.Implement
{
	public class QuickAccessBusiness : BaseBusiness<QuickAccess, IQuickAccessRepository>, IQuickAccessBusiness
    {
		private readonly IQuickAccessRepository _QuickAccessRepository;
		public QuickAccessBusiness(IQuickAccessRepository QuickAccessRepository) : base(QuickAccessRepository)
		{
            _QuickAccessRepository = QuickAccessRepository;
		}		
	}
}
