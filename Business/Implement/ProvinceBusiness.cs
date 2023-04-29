namespace Business.Implement
{
	public class ProvinceBusiness : BaseBusiness<Province, IProvinceRepository>, IProvinceBusiness
    {
		private readonly IProvinceRepository _provinceRepository;
		public ProvinceBusiness(IProvinceRepository provinceRepository) : base(provinceRepository)
		{
            _provinceRepository = provinceRepository;
		}		
	}
}
