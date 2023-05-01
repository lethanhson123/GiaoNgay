namespace Business.Implement
{
    public class CompanyBusiness : BaseBusiness<Company, ICompanyRepository>, ICompanyBusiness
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyBusiness(ICompanyRepository companyRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public override async Task<Company> GetByIDAsync(long ID)
        {
            var result = await _companyRepository.GetByIDAsync(ID);
            try
            {
                result.QRcodeFile = GlobalHelper.APISite + GlobalHelper.Image + "/" + GlobalHelper.Company + "/" + result.QRcodeFile;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
    }
}
