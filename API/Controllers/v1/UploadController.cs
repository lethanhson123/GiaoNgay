using Microsoft.AspNetCore.Hosting;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UploadController : BaseController<Bank, IBankBusiness>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBankBusiness _bankBusiness;
        private readonly IDistrictBusiness _districtBusiness;
        private readonly IWardBusiness _wardBusiness;
        public UploadController(
            IWebHostEnvironment webHostEnvironment
            , IBankBusiness bankBusiness
            , IDistrictBusiness districtBusiness
            , IWardBusiness wardBusiness
            ) : base(bankBusiness)
        {
            _webHostEnvironment = webHostEnvironment;
            _bankBusiness = bankBusiness;
            _districtBusiness = districtBusiness;
            _wardBusiness = wardBusiness;
        }
        [HttpPost]
        [Route("PostBankListByExcelFile")]
        public async Task<List<Bank>> PostBankListByExcelFile()
        {
            List<Bank> list = new List<Bank>();
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
                    fileName = "Bank" + GlobalHelper.InitializationDateTimeCode + fileExtension;
                    string pathSub = GlobalHelper.Upload;
                    var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    try
                    {
                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {
                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                Bank bank = new Bank();                                              
                                                if (workSheet.Cells[i, 1].Value != null)
                                                {
                                                    bank.Code = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    bank.Name = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                int result = await _bankBusiness.AddAsync(bank);
                                                if (result > 0)
                                                {
                                                    list.Add(bank);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string result = e.Message;
                    }
                }
            }
            return list;
        }
        [HttpPost]
        [Route("PostDistrictListByExcelFile")]
        public async Task<List<District>> PostDistrictListByExcelFile()
        {
            List<District> list = new List<District>();
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
                    fileName = "District" + GlobalHelper.InitializationDateTimeCode + fileExtension;
                    string pathSub = GlobalHelper.Upload;
                    var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    try
                    {
                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {
                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                District district = new District();
                                                if (workSheet.Cells[i, 1].Value != null)
                                                {
                                                    district.Display = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                }                                                
                                                int result = await _districtBusiness.AddAsync(district);
                                                if (result > 0)
                                                {
                                                    list.Add(district);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string result = e.Message;
                    }
                }
            }
            return list;
        }
        [HttpPost]
        [Route("PostWardListByExcelFile")]
        public async Task<List<Ward>> PostWardListByExcelFile()
        {
            List<Ward> list = new List<Ward>();
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
                    fileName = "Ward" + GlobalHelper.InitializationDateTimeCode + fileExtension;
                    string pathSub = GlobalHelper.Upload;
                    var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    try
                    {
                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {
                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                Ward ward = new Ward();
                                                if (workSheet.Cells[i, 1].Value != null)
                                                {
                                                    ward.Note = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    ward.Display = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                int result = await _wardBusiness.AddAsync(ward);
                                                if (result > 0)
                                                {
                                                    list.Add(ward);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string result = e.Message;
                    }
                }
            }
            return list;
        }
    }
}
