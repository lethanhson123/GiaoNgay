
namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class QuickAccessController : BaseController<QuickAccess, IQuickAccessBusiness>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IQuickAccessBusiness _quickAccessBusiness;
        public QuickAccessController(
            IWebHostEnvironment webHostEnvironment
            , IQuickAccessBusiness quickAccessBusiness
            ) : base(quickAccessBusiness)
        {
            _webHostEnvironment = webHostEnvironment;
            _quickAccessBusiness = quickAccessBusiness;
        }
        [HttpPost]
        [Route("SaveAndUploadFile")]
        public async Task<QuickAccess> SaveAndUploadFile()
        {
            QuickAccess model = JsonConvert.DeserializeObject<QuickAccess>(Request.Form["data"]);
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        fileName = GlobalHelper.InitializationDateTimeCode + fileExtension;
                        string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, GlobalHelper.QuickAccess);
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
                        model.Note = fileName;
                    }

                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }

            await _quickAccessBusiness.SaveAsync(model);
            return model;
        }
    }
}
