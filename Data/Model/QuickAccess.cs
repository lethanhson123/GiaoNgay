namespace Data.Model
{
    public partial class QuickAccess : BaseModel
    {       
        public QuickAccess()
        {
            SortOrder = GlobalHelper.InitializationNumber;
        }
    }
}
