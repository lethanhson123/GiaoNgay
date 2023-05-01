namespace Business.Implement
{
	public class MembershipFileBusiness : BaseBusiness<MembershipFile, IMembershipFileRepository>, IMembershipFileBusiness
    {
		private readonly IMembershipFileRepository _MembershipFileRepository;
		public MembershipFileBusiness(IMembershipFileRepository MembershipFileRepository) : base(MembershipFileRepository)
		{
            _MembershipFileRepository = MembershipFileRepository;
		}
        public override async Task<MembershipFile> GetByIDAsync(long ID)
        {
            var result = await _MembershipFileRepository.GetByIDAsync(ID);
            try
            {
                result.Note = GlobalHelper.APISite + GlobalHelper.Image + "/" + GlobalHelper.Membership + "/" + result.Note;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
    }
}
