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
        private readonly IProvinceBusiness _provinceBusiness;
        private readonly IWardBusiness _wardBusiness;
        private readonly IOrderDeliveryBusiness _orderDeliveryBusiness;
        private readonly IOrderDeliveryDetailBusiness _orderDeliveryDetailBusiness;
        public UploadController(
            IWebHostEnvironment webHostEnvironment
            , IBankBusiness bankBusiness
            , IDistrictBusiness districtBusiness
            , IProvinceBusiness provinceBusiness
            , IWardBusiness wardBusiness
            , IOrderDeliveryBusiness orderDeliveryBusiness
            , IOrderDeliveryDetailBusiness orderDeliveryDetailBusiness
            ) : base(bankBusiness)
        {
            _webHostEnvironment = webHostEnvironment;
            _bankBusiness = bankBusiness;
            _provinceBusiness = provinceBusiness;
            _districtBusiness = districtBusiness;
            _wardBusiness = wardBusiness;
            _orderDeliveryBusiness = orderDeliveryBusiness;
            _orderDeliveryDetailBusiness = orderDeliveryDetailBusiness;
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
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Upload);
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
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Upload);
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
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Upload);
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

        [HttpPost]
        [Route("PostOrderDeliveryListByExcelFile")]
        public async Task<List<OrderDelivery>> PostOrderDeliveryListByExcelFile()
        {
            int membershipID = JsonConvert.DeserializeObject<int>(Request.Form["MembershipID"]);
            List<OrderDelivery> list = new List<OrderDelivery>();
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
                    fileName = "OrderDelivery" + GlobalHelper.InitializationDateTimeCode + fileExtension;
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Upload, GlobalHelper.OrderDelivery);
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
                                                OrderDelivery orderDelivery = new OrderDelivery();
                                                orderDelivery.ShopID = membershipID;
                                                if (workSheet.Cells[i, 1].Value != null)
                                                {
                                                    orderDelivery.CustomerFullName = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    orderDelivery.CustomerPhone = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 3].Value != null)
                                                {
                                                    orderDelivery.CustomerAddress = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    Ward ward = new Ward();
                                                    ward.Display = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                    ward = await _wardBusiness.GetByCondition(item => item.Display.Contains(ward.Display)).FirstOrDefaultAsync();
                                                    if (ward != null)
                                                    {
                                                        if (ward.ID > 0)
                                                        {
                                                            orderDelivery.DeliveryWardID = ward.ID;
                                                        }
                                                    }
                                                }
                                                if (workSheet.Cells[i, 5].Value != null)
                                                {
                                                    District district = new District();
                                                    district.Display = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                    district = await _districtBusiness.GetByCondition(item => item.Display.Contains(district.Display)).FirstOrDefaultAsync();
                                                    if (district != null)
                                                    {
                                                        if (district.ID > 0)
                                                        {
                                                            orderDelivery.DeliveryDistrictID = district.ID;
                                                        }
                                                    }
                                                }
                                                if (workSheet.Cells[i, 6].Value != null)
                                                {
                                                    Province province = new Province();
                                                    province.Display = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                    province = await _provinceBusiness.GetByCondition(item => item.Display.Contains(province.Display)).FirstOrDefaultAsync();
                                                    if (province != null)
                                                    {
                                                        if (province.ID > 0)
                                                        {
                                                            orderDelivery.DeliveryProvinceID = province.ID;
                                                        }
                                                    }
                                                }
                                                if (workSheet.Cells[i, 7].Value != null)
                                                {
                                                    orderDelivery.Note = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                    if (!string.IsNullOrEmpty(orderDelivery.Note))
                                                    {
                                                        orderDelivery.IsShopPayment = true;
                                                    }
                                                }

                                                orderDelivery = await _orderDeliveryBusiness.SaveShopAsync(orderDelivery, _webHostEnvironment.WebRootPath);
                                                if (orderDelivery.ID > 0)
                                                {
                                                    OrderDeliveryDetail orderDeliveryDetail = new OrderDeliveryDetail();
                                                    orderDeliveryDetail.ParentID = orderDelivery.ID;
                                                    if (workSheet.Cells[i, 8].Value != null)
                                                    {
                                                        orderDeliveryDetail.Name = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                    }
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 9].Value != null)
                                                        {
                                                            orderDeliveryDetail.Quantity = decimal.Parse(workSheet.Cells[i, 9].Value.ToString().Trim());
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string mes = ex.Message;
                                                    }
                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 10].Value != null)
                                                        {
                                                            orderDeliveryDetail.Total = decimal.Parse(workSheet.Cells[i, 10].Value.ToString().Trim());
                                                            if (orderDeliveryDetail.Quantity > 0)
                                                            {
                                                                orderDeliveryDetail.Price = orderDeliveryDetail.Total / orderDeliveryDetail.Quantity;
                                                            }
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string mes = ex.Message;
                                                    }

                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 11].Value != null)
                                                        {
                                                            orderDeliveryDetail.Weight = decimal.Parse(workSheet.Cells[i, 11].Value.ToString().Trim());
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string mes = ex.Message;
                                                    }

                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 12].Value != null)
                                                        {
                                                            orderDeliveryDetail.Length = decimal.Parse(workSheet.Cells[i, 12].Value.ToString().Trim());
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string mes = ex.Message;
                                                    }

                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 13].Value != null)
                                                        {
                                                            orderDeliveryDetail.Width = decimal.Parse(workSheet.Cells[i, 13].Value.ToString().Trim());
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string mes = ex.Message;
                                                    }

                                                    try
                                                    {
                                                        if (workSheet.Cells[i, 14].Value != null)
                                                        {
                                                            orderDeliveryDetail.Height = decimal.Parse(workSheet.Cells[i, 14].Value.ToString().Trim());
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string mes = ex.Message;
                                                    }
                                                    if (workSheet.Cells[i, 15].Value != null)
                                                    {
                                                        orderDeliveryDetail.Note = workSheet.Cells[i, 15].Value.ToString().Trim();
                                                    }
                                                    await _orderDeliveryDetailBusiness.AddAsync(orderDeliveryDetail);
                                                    list.Add(orderDelivery);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string result = ex.Message;
                    }
                }
            }
            return list;
        }
    }
}
