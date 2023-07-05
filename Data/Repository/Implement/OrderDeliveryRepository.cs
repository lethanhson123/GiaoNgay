

using Data.Model;

namespace Data.Repository.Implement
{
    public class OrderDeliveryRepository : BaseRepository<OrderDelivery>, IOrderDeliveryRepository
    {
        private readonly GiaoNgayContext _context;
        public OrderDeliveryRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<OrderDelivery>> GetByOrderShipperIDToListAsync(long orderShipperID)
        {
            List<OrderDelivery> list = new List<OrderDelivery>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@OrderShipperID",orderShipperID),
            };
            DataTable dt = await SQLHelper.FillDataTableAsync(GlobalHelper.SQLServerConectionString, "sp_OrderDeliveryGetByOrderShipperID", parameters);
            list = SQLHelper.ToList<OrderDelivery>(dt);
            return list;
        }
        public async Task<string> UpdateByIDAndActiveAndOrderShipperIDAsync(long ID, bool active, long orderShipperID)
        {
            string result = GlobalHelper.InitializationString;
            if (ID > 0)
            {
                SqlParameter[] parameters =
                 {
                    new SqlParameter("@ID",ID),
                    new SqlParameter("@Active",active),
                    new SqlParameter("@OrderShipperID",orderShipperID),
                };
                result = await SQLHelper.ExecuteNonQueryAsync(GlobalHelper.SQLServerConectionString, "sp_OrderDeliveryUpdateByIDAndActiveAndOrderShipperID", parameters);
            }
            return result;
        }
        public async Task<List<OrderDelivery>> GetByOrderReceiveIDToListAsync(long orderReceiveID)
        {
            List<OrderDelivery> list = new List<OrderDelivery>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@OrderReceiveID",orderReceiveID),
            };
            DataTable dt = await SQLHelper.FillDataTableAsync(GlobalHelper.SQLServerConectionString, "sp_OrderDeliveryGetByOrderReceiveID", parameters);
            list = SQLHelper.ToList<OrderDelivery>(dt);
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
                result = await SQLHelper.ExecuteNonQueryAsync(GlobalHelper.SQLServerConectionString, "sp_OrderDeliveryUpdateByIDAndActiveAndOrderReceiveID", parameters);
            }
            return result;
        }
        public async Task<string> UpdateByParentIDAndReceiveIDAndReceiveFullNameAsync(long parentID, long receiveID, string receiveFullName)
        {
            string result = GlobalHelper.InitializationString;
            if (parentID > 0)
            {
                SqlParameter[] parameters =
                 {
                    new SqlParameter("@ParentID",parentID),
                    new SqlParameter("@ReceiveID",receiveID),
                    new SqlParameter("@ReceiveFullName",receiveFullName),
                };
                result = await SQLHelper.ExecuteNonQueryAsync(GlobalHelper.SQLServerConectionString, "sp_OrderDeliveryUpdateByParentIDAndReceiveIDAndReceiveFullName", parameters);
            }
            return result;
        }
    }
}
