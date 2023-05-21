namespace Business.Implement
{
    public class MembershipBusiness : BaseBusiness<Membership, IMembershipRepository>, IMembershipBusiness
    {
        private readonly IMembershipRepository _membershipRepository;
        public MembershipBusiness(IMembershipRepository membershipRepository) : base(membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }
        public override void Initialization(Membership model)
        {
            if (model.RowVersion == null)
            {
                model.ProvinceID = 0;
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
    }
}
