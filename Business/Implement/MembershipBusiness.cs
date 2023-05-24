using Business.Interface;
using Microsoft.EntityFrameworkCore;

namespace Business.Implement
{
    public class MembershipBusiness : BaseBusiness<Membership, IMembershipRepository>, IMembershipBusiness
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMembershipAuthenticationTokenBusiness _membershipAuthenticationTokenBusiness;
        public MembershipBusiness(IMembershipRepository membershipRepository
            , IMembershipAuthenticationTokenBusiness membershipAuthenticationTokenBusiness) : base(membershipRepository)
        {
            _membershipRepository = membershipRepository;
            _membershipAuthenticationTokenBusiness = membershipAuthenticationTokenBusiness;
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
            if (string.IsNullOrEmpty(model.Password))
            {
                model.Password = "0";
            }
            if (string.IsNullOrEmpty(model.Code))
            {
                model.Code = GlobalHelper.InitializationGUICode;
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
    }
}
