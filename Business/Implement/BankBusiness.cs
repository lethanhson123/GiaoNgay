
namespace Business.Implement
{
    public class BankBusiness : BaseBusiness<Bank, IBankRepository>, IBankBusiness
    {
        private readonly IBankRepository _bankRepository;
        public BankBusiness(IBankRepository bankRepository) : base(bankRepository)
        {
            _bankRepository = bankRepository;
        }
        public override void Initialization(Bank model)
        {
            model.Display = model.Code + "-" + model.Name;
        }
        public override async Task<int> AddAsync(Bank model)
        {
            Initialization(model);
            int result = GlobalHelper.InitializationNumber;
            if (!string.IsNullOrEmpty(model.Code))
            {
                Bank bank = await _bankRepository.GetByCondition(item => item.Code == model.Code).FirstOrDefaultAsync();
                if (bank == null)
                {
                    result = await _bankRepository.AddAsync(model);
                }
            }
            return result;
        }
    }
}
