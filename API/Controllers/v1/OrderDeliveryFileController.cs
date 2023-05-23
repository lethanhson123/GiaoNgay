
namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderDeliveryFileController : BaseController<OrderDeliveryFile, IOrderDeliveryFileBusiness>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOrderDeliveryFileBusiness _orderDeliveryFileBusiness;
        public OrderDeliveryFileController(IWebHostEnvironment webHostEnvironment
            , IOrderDeliveryFileBusiness orderDeliveryFileBusiness) : base(orderDeliveryFileBusiness)
        {
            _webHostEnvironment = webHostEnvironment;
            _orderDeliveryFileBusiness = orderDeliveryFileBusiness;
        }
        [HttpPost]
        [Route("SaveAndUploadFiles")]
        public async Task<int> SaveAndUploadFiles()
        {
            long parentID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            int result = GlobalHelper.InitializationNumber;
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Form.Files.Count; i++)
                    {
                        var file = Request.Form.Files[i];
                        if (file == null || file.Length == 0)
                        {
                        }
                        if (file != null)
                        {
                            OrderDeliveryFile orderDeliveryFile = new OrderDeliveryFile();
                            orderDeliveryFile.ParentID = parentID;
                            string fileExtension = Path.GetExtension(file.FileName);
                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            fileName = orderDeliveryFile.ParentID + "_" + GlobalHelper.InitializationDateTimeCode + fileExtension;
                            var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, GlobalHelper.OrderDelivery, fileName);
                            using (var stream = new FileStream(physicalPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                            orderDeliveryFile.Note = fileName;
                            await _orderDeliveryFileBusiness.AddAsync(orderDeliveryFile);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }

            return result;
        }
    }
}
