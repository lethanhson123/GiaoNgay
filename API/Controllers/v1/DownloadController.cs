
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using OfficeOpenXml.Style;
using System.IO;
using System.Text;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DownloadController : BaseController<OrderDelivery, IOrderDeliveryBusiness>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOrderDeliveryBusiness _orderDeliveryBusiness;
        private readonly IOrderDeliveryDetailBusiness _orderDeliveryDetailBusiness;


        public DownloadController(IWebHostEnvironment webHostEnvironment
            , IOrderDeliveryBusiness orderDeliveryBusiness
            , IOrderDeliveryDetailBusiness orderDeliveryDetailBusiness
            ) : base(orderDeliveryBusiness)
        {
            _webHostEnvironment = webHostEnvironment;
            _orderDeliveryBusiness = orderDeliveryBusiness;
            _orderDeliveryDetailBusiness = orderDeliveryDetailBusiness;
        }

        [HttpPost]
        [Route("GetYear")]
        public virtual List<DateHelper> GetYear()
        {
            var result = GlobalHelper.Year();
            return result;
        }
        [HttpPost]
        [Route("GetMonth")]
        public virtual List<DateHelper> GetMonth()
        {
            var result = GlobalHelper.Month();
            return result;
        }
        [HttpPost]
        [Route("GetDay")]
        public virtual List<DateHelper> GetDay()
        {
            var result = GlobalHelper.Day();
            return result;
        }
        [HttpGet]
        [Route("OrderDeliveryByIDToHTML")]
        public JsonResult OrderDeliveryByIDToHTML(long ID)
        {
            string result = GlobalHelper.InitializationString;
            result = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Download, GlobalHelper.OrderDelivery, "OrderDelivery.html");
            string contentHTML = GlobalHelper.InitializationString;
            using (FileStream fs = new FileStream(result, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                {
                    contentHTML = r.ReadToEnd();
                }
            }
            contentHTML = contentHTML.Replace("[DatePrint]", GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss"));
            OrderDelivery orderDelivery = _orderDeliveryBusiness.GetByID(ID);
            if (orderDelivery != null)
            {
                contentHTML = contentHTML.Replace("[DateCreated]", orderDelivery.DateCreated.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                contentHTML = contentHTML.Replace("[Barcode]", orderDelivery.Barcode);
                contentHTML = contentHTML.Replace("[BarcodeFile]", Path.Combine(GlobalHelper.APISite, GlobalHelper.Barcode, orderDelivery.BarcodeFile));
                contentHTML = contentHTML.Replace("[QRcodeFile]", Path.Combine(GlobalHelper.APISite, GlobalHelper.QRcode, orderDelivery.QRcodeFile));
                contentHTML = contentHTML.Replace("[ShopFullName]", orderDelivery.ShopFullName);
                contentHTML = contentHTML.Replace("[ShopAddress]", orderDelivery.ShopAddress);
                contentHTML = contentHTML.Replace("[CustomerFullName]", orderDelivery.CustomerFullName);
                contentHTML = contentHTML.Replace("[CustomerAddress]", orderDelivery.CustomerAddress);
                contentHTML = contentHTML.Replace("[TotalBeforeTax]", orderDelivery.TotalBeforeTax.Value.ToString("N0"));

                OrderDeliveryDetail oderDeliveryDetail = _orderDeliveryDetailBusiness.GetByParentIDToList(orderDelivery.ID).Where(item => item.CategoryOrderDetailID == null).OrderBy(item => item.CreatedDate).FirstOrDefault();
                if (oderDeliveryDetail != null)
                {
                    if (string.IsNullOrEmpty(oderDeliveryDetail.Note))
                    {
                        oderDeliveryDetail.Note = "Kiểm tra tên sản phẩm và đối chiếu mã đơn hàng";
                    }
                    contentHTML = contentHTML.Replace("[OrderDeliveryDetailName]", oderDeliveryDetail.Name);
                    contentHTML = contentHTML.Replace("[OrderDeliveryDetailQuantity]", oderDeliveryDetail.Quantity.Value.ToString("N0"));
                    contentHTML = contentHTML.Replace("[OrderDeliveryDetailNote]", oderDeliveryDetail.Note);
                }

                string fileName = orderDelivery.Barcode + ".html";
                result = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Download, GlobalHelper.OrderDelivery, fileName);
                using (FileStream fs = new FileStream(result, FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        w.WriteLine(contentHTML);
                    }
                }
                result = Path.Combine(GlobalHelper.APISite, GlobalHelper.Download, GlobalHelper.OrderDelivery, fileName);
            }
            return Json(result);
        }
    }
}
