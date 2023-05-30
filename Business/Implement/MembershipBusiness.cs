using Business.Interface;
using Microsoft.EntityFrameworkCore;

namespace Business.Implement
{
    public class MembershipBusiness : BaseBusiness<Membership, IMembershipRepository>, IMembershipBusiness
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMembershipAuthenticationTokenBusiness _membershipAuthenticationTokenBusiness;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IWardRepository _wardRepository;
        public MembershipBusiness(IMembershipRepository membershipRepository
            , IMembershipAuthenticationTokenBusiness membershipAuthenticationTokenBusiness
            , IProvinceRepository provinceRepository
            , IDistrictRepository districtRepository
            , IWardRepository wardRepository) : base(membershipRepository)
        {
            _membershipRepository = membershipRepository;
            _membershipAuthenticationTokenBusiness = membershipAuthenticationTokenBusiness;
            _provinceRepository = provinceRepository;
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
        }
        public override void Initialization(Membership model)
        {
            if (model.RowVersion == null)
            {
                model.RowVersion = 0;
            }
            if (model.ProvinceID == null)
            {
                model.ProvinceID = 1;
            }
            if (string.IsNullOrEmpty(model.UserName))
            {
                model.UserName = model.Phone;
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                model.Password = "0";
            }
            if (string.IsNullOrEmpty(model.Code))
            {
                model.Code = GlobalHelper.InitializationGUICode;
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                model.Description = model.Address + " " + model.AddressLegal;
                if (model.WardID != null)
                {
                    Ward ward = _wardRepository.GetByID(model.WardID.Value);
                    if (ward != null)
                    {
                        model.Description = model.Description + ", " + ward.Display + ", " + ward.Note + ", " + ward.Description;
                    }
                }
            }
            model.Display = model.FullName + "-" + model.Phone;
            EncryptPassword(model);
        }
        private static void EncryptPassword(Membership model)
        {
            model.Password = SecurityHelper.Encrypt(model.Code, model.Password);
        }
        public static void DecryptPassword(Membership model)
        {
            model.Password = SecurityHelper.Decrypt(model.Code, model.Password);
        }
        public override async Task<Membership> SaveAsync(Membership model)
        {
            bool isSave = true;
            Initialization(model);
            if (string.IsNullOrEmpty(model.UserName))
            {
                model.RowVersion = 11;
                isSave = false;
            }
            if (isSave == true)
            {
                Membership modelExist = await _membershipRepository.GetByCondition(item => item.UserName == model.UserName).FirstOrDefaultAsync();
                if (modelExist != null)
                {
                    if (modelExist.ID != model.ID)
                    {
                        model.RowVersion = 110;
                        isSave = false;
                    }
                }
                if (isSave == true)
                {
                    if (model.ID > 0)
                    {
                        model.RowVersion = await _membershipRepository.UpdateAsync(model);
                    }
                    else
                    {
                        model.RowVersion = await _membershipRepository.AddAsync(model);
                    }
                    if (model.RowVersion > 0)
                    {
                        //string url = GlobalHelper.APISite + "api/v1/Mail/SendMailWhenMembershipChange?membershipID=" + model.ID;
                        //HttpClient client = new HttpClient();
                        //HttpResponseMessage response = await client.GetAsync(url);
                    }
                }
            }
            return model;
        }
        public Membership Authentication(Membership membership)
        {
            Membership result = new Membership();
            result = _membershipRepository.GetByCondition(model => model.UserName == membership.UserName && model.Active == true).FirstOrDefault();
            bool check = false;
            if (result != null)
            {
                if (string.IsNullOrEmpty(result.Code))
                {
                    result.Password = membership.Password;
                    Update(result);
                }
                string passwordDecrypt = SecurityHelper.Decrypt(result.Code, result.Password);
                if (passwordDecrypt.Equals(membership.Password))
                {
                    check = true;
                }
            }
            if (check == true)
            {
                MembershipAuthenticationToken membershipAuthenticationToken = new MembershipAuthenticationToken();
                membershipAuthenticationToken.ParentID = result.ID;
                membershipAuthenticationToken.AuthenticationToken = GlobalHelper.InitializationGUICode;
                membershipAuthenticationToken.DateBegin = GlobalHelper.InitializationDateTime;
                membershipAuthenticationToken.DateEnd = membershipAuthenticationToken.DateBegin.Value.AddMonths(1);
                membershipAuthenticationToken.CreatedDate = GlobalHelper.InitializationDateTime;
                membershipAuthenticationToken.LastUpdatedDate = GlobalHelper.InitializationDateTime;
                membershipAuthenticationToken.Active = true;
                int resultSave = _membershipAuthenticationTokenBusiness.Add(membershipAuthenticationToken);
                if (resultSave > 0)
                {
                    result.Note = membershipAuthenticationToken.AuthenticationToken;
                    result.Description = result.Description + "?AuthenticationToken=" + membershipAuthenticationToken.AuthenticationToken;
                }
            }
            else
            {
                result = new Membership();
            }
            return result;
        }
        public async Task<List<Membership>> GetByTotalDebtGreaterThanZeroToListAsync()
        {
            List<Membership> result = await _membershipRepository.GetByTotalDebtGreaterThanZeroToListAsync();
            return result;
        }
    }
   
}
