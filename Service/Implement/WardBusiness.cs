namespace Service.Implement
{
	public class WardBusiness : BaseBusiness<Ward, IWardRepository>, IWardBusiness
    {
		private readonly IWardRepository _wardRepository;
		public WardBusiness(IWardRepository wardRepository) : base(wardRepository)
		{
            _wardRepository = wardRepository;
		}		
	}
}
