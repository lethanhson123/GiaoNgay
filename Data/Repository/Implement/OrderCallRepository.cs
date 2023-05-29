namespace Data.Repository.Implement
{
    public class OrderCallRepository : BaseRepository<OrderCall>, IOrderCallRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderCallRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
        public async Task<List<OrderCall>> GetByOrderReceiveIDToListAsync(long orderReceiveID)
        {
            List<OrderCall> list = new List<OrderCall>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@OrderReceiveID",orderReceiveID),
            };
            DataTable dt = await SQLHelper.FillDataTableAsync(GlobalHelper.SQLServerConectionString, "sp_OrderCallGetByOrderReceiveID", parameters);
            list = SQLHelper.ToList<OrderCall>(dt);
            return list;
        }
        public async Task<string> UpdateByIDAndActiveAndOrderReceiveIDAsync(long ID, bool active, long orderReceiveID)
        {
            string result = GlobalHelper.InitializationString;
            if (ID > 0)
            {
                SqlParameter[] parameters =
                 {
                    new SqlParameter("@ID",ID),
                    new SqlParameter("@Active",active),
                    new SqlParameter("@OrderReceiveID",orderReceiveID),
                };
                result = await SQLHelper.ExecuteNonQueryAsync(GlobalHelper.SQLServerConectionString, "sp_OrderCallUpdateByIDAndActiveAndOrderReceiveID", parameters);
            }
            return result;
        }
    }
}
