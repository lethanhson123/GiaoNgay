namespace Service.Implement
{
	public class StreetWardBusiness : BaseBusiness<StreetWard, IStreetWardRepository>, IStreetWardBusiness
    {
		private readonly IStreetWardRepository _streetWardRepository;
		public StreetWardBusiness(IStreetWardRepository streetWardRepository) : base(streetWardRepository)
		{
            _streetWardRepository = streetWardRepository;
		}		
	}
}
