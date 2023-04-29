namespace Business.Interface
{
	public interface IWardBusiness : IBaseBusiness<Ward>
	{
        Task<List<Ward>> GetByParentIDToListAsync(long parentID);
        Task<List<Ward>> GetBySearchStringToListAsync(string searchString);
        Task<List<Ward>> GetByParentIDAndSearchStringToListAsync(long parentID, string searchString);
    }
}
