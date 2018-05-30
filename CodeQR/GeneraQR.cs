using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using System.Data.OleDb;
using System.Data.Common;
using Datos;

namespace CodeQR
{
    public class GeneraQR
    {
        public string strMsj;
        private string strCadena;
        private Image imgCodigo;
        BasesDatos DB = new BasesDatos();        
        string CadenaCodigo;
        Image imarecu;
        byte[] img;
        byte[] img2;


        public GeneraQR(String strinCad)
        {
            strCadena = strinCad;
            strMsj = "";
        }

        public void createCodigoQR()
        {
            //Convierte una Cadena a codigo QR
            int pixel = 4;
            System.Globalization.NumberFormatInfo nfi_g0 = new System.Globalization.NumberFormatInfo();
            nfi_g0.CurrencyGroupSeparator = ".";
            if (Convert.ToDouble(pixel, nfi_g0) == 0) pixel = 4;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = pixel;
            qrCodeEncoder.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.H;
            qrCodeEncoder.QRCodeVersion = 0;
            imgCodigo = qrCodeEncoder.Encode(strCadena, System.Text.Encoding.UTF8);
            //getImgCodigo();
            img = imageToBytes(imgCodigo);
            //imgCodigo.Save(@"Q:\docus\imagen.jpeg");

        }

        public Image RecuCodigo(string IDEFAC)
        {

            string ruta = @"C:\";
            img2 = new byte[img.Length];

            DB.Conectar();
            DB.CrearComando("select CadenaQR, CodigoQR from general where idFactura=@IDEFAC");
            DB.AsignarParametroCadena("@IDEFAC", IDEFAC);
            DbDataReader DR = DB.EjecutarConsulta();

            while (DR.Read())
            {
                CadenaCodigo = DR[0].ToString();
                img2 = (byte[])DR[1];

            }
            DB.Desconectar();
            imarecu = bytes2Image(img2);
            return imarecu;
            //ruta += CadenaCodigo + ".png";
            //imarecu.Save(ruta, System.Drawing.Imaging.ImageFormat.Png); ;
        }

        public byte[] getImgCodigo()
        {
            return imageToBytes(imgCodigo);
        }

        public Image getBytCodigo() 
        {
            return imgCodigo;
        }
        
        public static byte[] imageToBytes(Image img)
        {
            //Convierte una tipo imagen a bytes
            string strTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(strTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;
            int intImgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[intImgLength];
            fs.Read(bytes, 0, intImgLength);
            fs.Close();
            return bytes;
        }

        public static Image bytes2Image(byte[] bytes)
        {
            //Convierte un tipo bytes a imagen
            if (bytes == null) return null;
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                //strMsj = ex.Message;
            }
            return bm;
        }
    }
}
