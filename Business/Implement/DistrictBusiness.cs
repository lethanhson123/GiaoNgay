namespace Business.Implement
{
	public class DistrictBusiness : BaseBusiness<District, IDistrictRepository>, IDistrictBusiness
    {
		private readonly IDistrictRepository _districtRepository;
		public DistrictBusiness(IDistrictRepository districtRepository) : base(districtRepository)
		{
            _districtRepository = districtRepository;
		}		
	}
}
