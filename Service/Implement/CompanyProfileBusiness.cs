namespace Service.Implement
{
	public class CompanyProfileBusiness : BaseBusiness<CompanyProfile, ICompanyProfileRepository>, ICompanyProfileBusiness
    {
		private readonly ICompanyProfileRepository _companyProfileRepository;
		public CompanyProfileBusiness(ICompanyProfileRepository companyProfileRepository) : base(companyProfileRepository)
		{
            _companyProfileRepository = companyProfileRepository;
		}		
	}
}
