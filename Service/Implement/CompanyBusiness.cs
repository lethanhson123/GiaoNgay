namespace Business.Implement
{
	public class CompanyBusiness : BaseBusiness<Company, ICompanyRepository>, ICompanyBusiness
    {
		private readonly ICompanyRepository _companyRepository;
		public CompanyBusiness(ICompanyRepository companyRepository) : base(companyRepository)
		{
            _companyRepository = companyRepository;
		}		
	}
}
