
using Data.Model;

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
        [Route("XoayAnhSangTraiAsync")]
        public async Task<OrderDeliveryFile> XoayAnhSangTraiAsync()
        {
            OrderDeliveryFile result = JsonConvert.DeserializeObject<OrderDeliveryFile>(Request.Form["data"]);
            string filePathIn = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, GlobalHelper.OrderDelivery, result.Note);
            string fileExtension = Path.GetExtension(result.Note);
            result.Note = result.ParentID + "_" + GlobalHelper.InitializationDateTimeCode + fileExtension;
            string filePathOut = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, GlobalHelper.OrderDelivery, result.Note);
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(filePathIn))
            {
                image.RotateFlip(Aspose.Imaging.RotateFlipType.Rotate90FlipXY);
                image.Save(filePathOut);
                await _orderDeliveryFileBusiness.UpdateAsync(result);
            }
            return result;
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
