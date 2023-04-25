namespace Service.Implement
{
	public class StreetBusiness : BaseBusiness<Street, IStreetRepository>, IStreetBusiness
    {
		private readonly IStreetRepository _streetRepository;
		public StreetBusiness(IStreetRepository streetRepository) : base(streetRepository)
		{
            _streetRepository = streetRepository;
		}		
	}
}
