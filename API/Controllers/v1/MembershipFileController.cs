using Microsoft.AspNetCore.Hosting;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MembershipFileController : BaseController<MembershipFile, IMembershipFileBusiness>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMembershipFileBusiness _MembershipFileBusiness;
        public MembershipFileController(
            IWebHostEnvironment webHostEnvironment
            , IMembershipFileBusiness MembershipFileBusiness
            ) : base(MembershipFileBusiness)
        {
            _webHostEnvironment = webHostEnvironment;
            _MembershipFileBusiness = MembershipFileBusiness;
        }
        [HttpPost]
        [Route("SaveAndUploadFile")]
        public async Task<MembershipFile> SaveAndUploadFile()
        {
            MembershipFile model = JsonConvert.DeserializeObject<MembershipFile>(Request.Form["data"]);
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
                        fileName = model.ParentID + "_" + GlobalHelper.InitializationDateTimeCode + fileExtension;
                        string pathSub = GlobalHelper.Image + @"\" + GlobalHelper.Membership;
                        var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
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
            await _MembershipFileBusiness.SaveAsync(model);
            return model;
        }
    }
}
