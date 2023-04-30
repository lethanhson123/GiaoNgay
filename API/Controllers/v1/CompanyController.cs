using Microsoft.AspNetCore.Hosting;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CompanyController : BaseController<Company, ICompanyBusiness>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICompanyBusiness _companyBusiness;
        public CompanyController(
            IWebHostEnvironment webHostEnvironment
            , ICompanyBusiness companyBusiness
            ) : base(companyBusiness)
        {
            _webHostEnvironment = webHostEnvironment;
            _companyBusiness = companyBusiness;
        }
        [HttpPost]
        [Route("SaveAndUploadFile")]
        public async Task<Company> SaveAndUploadFile()
        {
            Company model = JsonConvert.DeserializeObject<Company>(Request.Form["data"]);
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
                        string pathSub = GlobalHelper.Image;
                        var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        model.QRcodeFile = fileName;
                    }

                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }

            await _companyBusiness.SaveAsync(model);
            return model;
        }
    }
}
