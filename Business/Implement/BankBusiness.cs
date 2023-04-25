namespace Business.Implement
{
	public class BankBusiness : BaseBusiness<Bank, IBankRepository>, IBankBusiness
    {
		private readonly IBankRepository _bankRepository;
		public BankBusiness(IBankRepository bankRepository) : base(bankRepository)
		{
            _bankRepository = bankRepository;
		}		
	}
}
