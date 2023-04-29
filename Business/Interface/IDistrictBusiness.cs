namespace Business.Interface
{
	public interface IDistrictBusiness : IBaseBusiness<District>
	{
        Task<List<District>> GetByParentIDToListAsync(long parentID);
    }
}
