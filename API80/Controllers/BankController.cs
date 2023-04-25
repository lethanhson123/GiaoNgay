
namespace API80.Controllers
{
    public class BankController : BaseController<Bank, IBankBusiness>
    {
        private readonly IBankBusiness _bankBusiness;
        public BankController(IBankBusiness bankBusiness) : base(bankBusiness)
        {
            _bankBusiness = bankBusiness;
        }
    }
}
