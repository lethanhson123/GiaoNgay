using QRCoder;
using System.Drawing;

namespace Helper
{
    public class QRCodeHelper
    {
        public static QRCodeModel CreateQRCode(string barcode, string path)
        {
            QRCodeModel model = new QRCodeModel();
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(barcode, QRCodeGenerator.ECCLevel.H))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                string fileName = barcode + ".png";
                path = Path.Combine(path, fileName);
                qrCodeImage.Save(path, ImageFormat.Png);
                model.Code = barcode;
                model.FileName = fileName;
            }
            return model;
        }
        public static QRCodeModel CreateQRCodeCCCD(string path, string QRCode)
        {
            QRCodeModel model = new QRCodeModel();
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRCode, QRCodeGenerator.ECCLevel.H))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                string fileName = GlobalHelper.InitializationDateTimeCode0001 + ".png";
                path = Path.Combine(path, fileName);
                qrCodeImage.Save(path, ImageFormat.Png);
                model.Code = QRCode;
                model.FileName = fileName;
            }
            return model;
        }
    }
}
