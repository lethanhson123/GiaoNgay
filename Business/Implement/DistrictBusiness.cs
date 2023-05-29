using Business.Interface;
using Newtonsoft.Json;

namespace Business.Implement
{
    public class DistrictBusiness : BaseBusiness<District, IDistrictRepository>, IDistrictBusiness
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictBusiness(IDistrictRepository districtRepository) : base(districtRepository)
        {
            _districtRepository = districtRepository;
        }
        public override void Initialization(District model)
        {
            if (model.ParentID == null)
            {
                model.ParentID = 1;
            }
            if (!string.IsNullOrEmpty(model.Display))
            {
                model.Display = model.Display.Trim();
            }
        }
        public override async Task<int> AddAsync(District model)
        {
            Initialization(model);
            int result = GlobalHelper.InitializationNumber;
            if (!string.IsNullOrEmpty(model.Display))
            {
                District district = await _districtRepository.GetByCondition(item => item.Display == model.Display && item.ParentID == model.ParentID).FirstOrDefaultAsync();
                if (district == null)
                {
                    result = await _districtRepository.AddAsync(model);
                }
            }
            return result;
        }
        public override async Task<List<District>> GetByParentIDToListAsync(long parentID)
        {
            List<District> result = new List<District>();
            District unknown = new District();
            unknown.ID = GlobalHelper.InitializationNumber;
            unknown.SortOrder = GlobalHelper.InitializationNumber;
            unknown.Display = GlobalHelper.Unknown;
            result.Add(unknown);
            result.AddRange(await _districtRepository.GetByParentIDToListAsync(parentID));
            return result;
        }
    }
}
