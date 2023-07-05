using Microsoft.AspNetCore.Hosting.Server;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderCallFileController : BaseController<OrderCallFile, IOrderCallFileBusiness>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOrderCallFileBusiness _orderCallFileBusiness;
        public OrderCallFileController(IWebHostEnvironment webHostEnvironment
            , IOrderCallFileBusiness olrderCallFileBusiness) : base(olrderCallFileBusiness)
        {
            _webHostEnvironment = webHostEnvironment;
            _orderCallFileBusiness = olrderCallFileBusiness;
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
                            OrderCallFile orderCallFile = new OrderCallFile();
                            orderCallFile.ParentID = parentID;
                            string fileExtension = Path.GetExtension(file.FileName);
                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            fileName = orderCallFile.ParentID + "_" + GlobalHelper.InitializationDateTimeCode + fileExtension;
                            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, GlobalHelper.OrderDelivery);
                            bool isFolderExists = System.IO.Directory.Exists(folderPath);
                            if (!isFolderExists)
                            {
                                System.IO.Directory.CreateDirectory(folderPath);
                            }
                            var physicalPath = Path.Combine(folderPath, fileName);
                            using (var stream = new FileStream(physicalPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                            orderCallFile.Note = fileName;
                            await _orderCallFileBusiness.Save01Async(orderCallFile, _webHostEnvironment.WebRootPath);
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
