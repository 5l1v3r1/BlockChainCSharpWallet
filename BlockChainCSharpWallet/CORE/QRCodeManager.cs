using QRCoder;

namespace BlockChainCSharpWallet.CORE
{
    class QRCodeManager
    {
        public static System.Drawing.Bitmap CreateQR(string _inputText, int _widthPixelFactor = 3)
        {
            //Create a QR and return its bitmap
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(_inputText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            return qrCode.GetGraphic(_widthPixelFactor);
        }
    }
}
