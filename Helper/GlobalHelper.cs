namespace Helper
{
    public class GlobalHelper
    {
        #region Initialization
        public static bool InitializationBool
        {
            get
            {
                return true;
            }
        }
        public static string InitializationString
        {
            get
            {
                return "";
            }
        }
        public static DateTime InitializationDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }
        public static string InitializationGUICode
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
        public static string InitializationDateTimeCode
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + DateTime.Now.Ticks.ToString();
            }
        }
        public static string InitializationDateTimeCode0001
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }
        public static int InitializationNumber
        {
            get
            {
                return 0;
            }
        }
        #endregion
        #region AppSettings 
        public static string QRcode
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("QRcode").Value;
            }
        }
        public static string Barcode
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Barcode").Value;
            }
        }
        public static string EAN13CountryCode
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("EAN13CountryCode").Value;
            }
        }
        public static string EAN13ManufacturerCode
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("EAN13ManufacturerCode").Value;
            }
        }
        public static int YearBegin
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("YearBegin").Value);
            }
        }
        public static int YearEnd
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("YearEnd").Value);
            }
        }
        public static string Download
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Download").Value;
            }
        }
        public static string Upload
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Upload").Value;
            }
        }
        public static string Company
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Company").Value;
            }
        }
        public static string Membership
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Membership").Value;
            }
        }
        public static string OrderDelivery
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("OrderDelivery").Value;
            }
        }
        public static string Image
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Image").Value;
            }
        }
        public static string DomainName
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainName").Value;
            }
        }
        public static string APISite
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("APISite").Value;
            }
        }
        public static string SQLServerConectionString
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("SQLServerConectionString").Value;
            }
        }
        #endregion

        public static List<DateHelper> Year()
        {
            List<DateHelper> result = new List<DateHelper>();
            for (int i = GlobalHelper.YearBegin; i < GlobalHelper.YearEnd; i++)
            {
                DateHelper item = new DateHelper();
                item.Value = i;
                result.Add(item);
            }
            return result;
        }
        public static List<DateHelper> Month()
        {
            List<DateHelper> result = new List<DateHelper>();
            for (int i = 1; i < 12; i++)
            {
                DateHelper item = new DateHelper();
                item.Value = i;
                result.Add(item);
            }
            return result;
        }
        public static List<DateHelper> Day()
        {
            List<DateHelper> result = new List<DateHelper>();
            for (int i = 1; i < 32; i++)
            {
                DateHelper item = new DateHelper();
                item.Value = i;
                result.Add(item);
            }
            return result;
        }
    }

    public class DateHelper
    {
        public int Value { get; set; }
    }
}
