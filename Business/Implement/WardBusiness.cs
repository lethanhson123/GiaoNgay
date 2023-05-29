namespace Business.Implement
{
    public class WardBusiness : BaseBusiness<Ward, IWardRepository>, IWardBusiness
    {
        private readonly IWardRepository _wardRepository;
        private readonly IDistrictBusiness _districtBusiness;
        private readonly IProvinceBusiness _provinceBusiness;
        public WardBusiness(IWardRepository wardRepository
            , IDistrictBusiness districtBusiness
            , IProvinceBusiness provinceBusiness
            ) : base(wardRepository)
        {
            _wardRepository = wardRepository;
            _districtBusiness = districtBusiness;
            _provinceBusiness = provinceBusiness;
        }
        public override void Initialization(Ward model)
        {
            if (!string.IsNullOrEmpty(model.Display))
            {
                model.Display = model.Display.Trim();
            }
        }
        public override async Task<int> AddAsync(Ward model)
        {
            int result = GlobalHelper.InitializationNumber;
            if (!string.IsNullOrEmpty(model.Display))
            {
                District district = await _districtBusiness.GetByCondition(item => item.Display == model.Note).FirstOrDefaultAsync();
                if (district != null)
                {
                    model.ParentID = district.ID;
                    Province province = await _provinceBusiness.GetByIDAsync(district.ParentID.Value);
                    if (province != null)
                    {
                        model.Description = province.Display;
                    }
                    Initialization(model);
                    result = await _wardRepository.AddAsync(model);
                }
            }
            return result;
        }
        public virtual async Task<List<Ward>> GetBySearchStringToListAsync(string searchString)
        {
            List<Ward> list = new List<Ward>();
            if (!string.IsNullOrEmpty(searchString))
            {
                list = await _wardRepository.GetByCondition(item => item.Display.Contains(searchString)).ToListAsync();
            }
            return list;
        }
        public virtual async Task<List<Ward>> GetByParentIDAndSearchStringToListAsync(long parentID, string searchString)
        {
            List<Ward> list = new List<Ward>();
            if (!string.IsNullOrEmpty(searchString))
            {
                list = await GetBySearchStringToListAsync(searchString);
            }
            else
            {
                list = await GetByParentIDToListAsync(parentID);
            }
            return list;
        }
        public override async Task<List<Ward>> GetByParentIDToListAsync(long parentID)
        {
            List<Ward> result = new List<Ward>();
            Ward unknown = new Ward();
            unknown.ID = GlobalHelper.InitializationNumber;
            unknown.SortOrder = GlobalHelper.InitializationNumber;
            unknown.Display = GlobalHelper.Unknown;
            result.Add(unknown);
            result.AddRange(await _wardRepository.GetByParentIDToListAsync(parentID));
            return result;
        }
    }
}
