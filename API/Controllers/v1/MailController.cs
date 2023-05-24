



namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MailController : BaseController<OrderDelivery, IOrderDeliveryBusiness>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOrderDeliveryBusiness _orderDeliveryBusiness;
        private readonly IOrderDeliveryDetailBusiness _orderDeliveryDetailBusiness;
        private readonly IMembershipBusiness _membershipBusiness;
        public MailController(IWebHostEnvironment webHostEnvironment
            , IOrderDeliveryBusiness orderDeliveryBusiness
            , IOrderDeliveryDetailBusiness orderDeliveryDetailBusiness
            , IMembershipBusiness membershipBusiness) : base(orderDeliveryBusiness)
        {
            _webHostEnvironment = webHostEnvironment;
            _orderDeliveryBusiness = orderDeliveryBusiness;
            _orderDeliveryDetailBusiness = orderDeliveryDetailBusiness;
            _membershipBusiness = membershipBusiness;
        }
        [HttpGet]
        [Route("TestSendMail")]
        public async Task<string> TestSendMail(long orderDeliveryID)
        {
            string result = GlobalHelper.InitializationString;
            result = GlobalHelper.APISite + "api/v1/Mail/SendMailWhenOrderDeliveryCreate?orderDeliveryID=" + orderDeliveryID;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(result);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
        [HttpGet]
        [Route("SendMailWhenOrderDeliveryCreate")]
        public async Task<string> SendMailWhenOrderDeliveryCreate(long orderDeliveryID)
        {
            string result = GlobalHelper.InitializationString;
            OrderDelivery orderDelivery = await _orderDeliveryBusiness.GetByIDAsync(orderDeliveryID);
            if (orderDelivery != null)
            {
                Helper.Model.Mail mail = new Helper.Model.Mail();
                mail.MailFrom = GlobalHelper.MasterEmailUser;
                mail.UserName = GlobalHelper.MasterEmailUser;
                mail.Password = GlobalHelper.MasterEmailPassword;
                mail.SMTPPort = GlobalHelper.SMTPPort;
                mail.SMTPServer = GlobalHelper.SMTPServer;
                mail.IsMailBodyHtml = GlobalHelper.IsMailBodyHtml;
                mail.IsMailUsingSSL = GlobalHelper.IsMailUsingSSL;
                mail.Display = GlobalHelper.MasterEmailDisplay;
                mail.MailTo = GlobalHelper.MasterEmailUser;
                mail.Subject = "Đơn hàng " + orderDelivery.Barcode + " tạo thành công vào lúc " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                if (!string.IsNullOrEmpty(mail.MailTo))
                {
                    mail.Content = OrderDeliveryGetContent(orderDelivery, "https://crm.giaongay.com.vn/");
                    MailHelper.SendMail(mail);
                }

                Membership shop = await _membershipBusiness.GetByIDAsync(orderDelivery.ShopID.Value);
                if (shop != null)
                {
                    mail.MailTo = shop.Email;
                    if (!string.IsNullOrEmpty(mail.MailTo))
                    {
                        mail.Content = OrderDeliveryGetContent(orderDelivery, "https://shop.giaongay.com.vn/");
                        MailHelper.SendMail(mail);
                    }
                }
            }
            return result;
        }
        [HttpGet]
        [Route("SendMailWhenOrderDeliveryComplete")]
        public async Task<string> SendMailWhenOrderDeliveryComplete(long orderDeliveryID)
        {
            string result = GlobalHelper.InitializationString;
            OrderDelivery orderDelivery = await _orderDeliveryBusiness.GetByIDAsync(orderDeliveryID);
            if (orderDelivery != null)
            {
                Helper.Model.Mail mail = new Helper.Model.Mail();
                mail.MailFrom = GlobalHelper.MasterEmailUser;
                mail.UserName = GlobalHelper.MasterEmailUser;
                mail.Password = GlobalHelper.MasterEmailPassword;
                mail.SMTPPort = GlobalHelper.SMTPPort;
                mail.SMTPServer = GlobalHelper.SMTPServer;
                mail.IsMailBodyHtml = GlobalHelper.IsMailBodyHtml;
                mail.IsMailUsingSSL = GlobalHelper.IsMailUsingSSL;
                mail.Display = GlobalHelper.MasterEmailDisplay;
                mail.MailTo = GlobalHelper.MasterEmailUser;
                mail.Subject = "Đơn hàng " + orderDelivery.Barcode + " đã hoàn thành vào lúc " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                if (!string.IsNullOrEmpty(mail.MailTo))
                {
                    mail.Content = OrderDeliveryGetContent(orderDelivery, "https://crm.giaongay.com.vn/");
                    MailHelper.SendMail(mail);
                }

                Membership shop = await _membershipBusiness.GetByIDAsync(orderDelivery.ShopID.Value);
                if (shop != null)
                {
                    mail.MailTo = shop.Email;
                    if (!string.IsNullOrEmpty(mail.MailTo))
                    {
                        mail.Content = OrderDeliveryGetContent(orderDelivery, "https://shop.giaongay.com.vn/");
                        MailHelper.SendMail(mail);
                    }
                }
            }
            return result;
        }
        [HttpGet]
        [Route("SendMailWhenMembershipChange")]
        public async Task<string> SendMailWhenMembershipChange(long membershipID)
        {
            string result = GlobalHelper.InitializationString;
            Membership membership = await _membershipBusiness.GetByIDAsync(membershipID);
            if (membership != null)
            {
                Helper.Model.Mail mail = new Helper.Model.Mail();
                mail.MailFrom = GlobalHelper.MasterEmailUser;
                mail.UserName = GlobalHelper.MasterEmailUser;
                mail.Password = GlobalHelper.MasterEmailPassword;
                mail.SMTPPort = GlobalHelper.SMTPPort;
                mail.SMTPServer = GlobalHelper.SMTPServer;
                mail.IsMailBodyHtml = GlobalHelper.IsMailBodyHtml;
                mail.IsMailUsingSSL = GlobalHelper.IsMailUsingSSL;
                mail.Display = GlobalHelper.MasterEmailDisplay;
                mail.MailTo = GlobalHelper.MasterEmailUser;
                mail.Subject = "Thông tin tài khoản đã thay đổi lúc " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                if (!string.IsNullOrEmpty(mail.MailTo))
                {
                    mail.Content = MembershipGetContent(membership);
                    MailHelper.SendMail(mail);
                }

                mail.MailTo = membership.Email;
                if (!string.IsNullOrEmpty(mail.MailTo))
                {
                    mail.Content = MembershipGetContent(membership);
                    MailHelper.SendMail(mail);
                }
            }
            return result;
        }
        private string OrderDeliveryGetContent(OrderDelivery orderDelivery, string url)
        {
            string result = GlobalHelper.InitializationString;
            result = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Download, GlobalHelper.Mail, "OrderDelivery.html");
            string contentHTML = GlobalHelper.InitializationString;
            using (FileStream fs = new FileStream(result, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                {
                    contentHTML = r.ReadToEnd();
                }
            }
            url = "<a href='" + url + "#/OrderDeliveryInfo/" + orderDelivery.ID + "'><b>" + orderDelivery.Barcode + "</b></a>";
            contentHTML = contentHTML.Replace("[DateCreated]", orderDelivery.DateCreated.Value.ToString("dd/MM/yyyy HH:mm"));
            contentHTML = contentHTML.Replace("[Barcode]", url);
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
            else
            {
                contentHTML = contentHTML.Replace("[OrderDeliveryDetailName]", GlobalHelper.InitializationString);
                contentHTML = contentHTML.Replace("[OrderDeliveryDetailQuantity]", GlobalHelper.InitializationString);
                contentHTML = contentHTML.Replace("[OrderDeliveryDetailNote]", GlobalHelper.InitializationString);
            }
            result = contentHTML;
            return result;
        }
        private string MembershipGetContent(Membership membership)
        {
            string result = GlobalHelper.InitializationString;
            result = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Download, GlobalHelper.Mail, "Membership.html");
            string contentHTML = GlobalHelper.InitializationString;
            using (FileStream fs = new FileStream(result, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                {
                    contentHTML = r.ReadToEnd();
                }
            }
            contentHTML = contentHTML.Replace("[UserName]", membership.UserName);
            contentHTML = contentHTML.Replace("[FullName]", membership.FullName);
            contentHTML = contentHTML.Replace("[Phone]", membership.Phone);
            contentHTML = contentHTML.Replace("[Email]", membership.Email);
            result = contentHTML;
            return result;
        }
    }
}
