using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.Drawing;
using System.IO;
using Data_Access_Layer;

namespace Service_Layer
{
    public static class QR_Maker
    {
        private static string texto = "mE5gvfa48O5QFsqK3KWphdjqDvO5F1fI";

        public static string CrearPagoQR(decimal monto)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(Encriptacion.DesencriptarPass(texto), QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(50);
                qrCodeImage.Save(ReferenciasBD.QR, System.Drawing.Imaging.ImageFormat.Png);
                return ReferenciasBD.QR;
            }catch (Exception ex) { throw ex; }
        }
    }
}
