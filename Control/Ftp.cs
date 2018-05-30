using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
namespace Control
{
    public class Ftp
    {
        public void UploadFTP(string FilePath, string RemotePath, string Login, string Password)
        {


            using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                string url = Path.Combine(RemotePath, Path.GetFileName(FilePath));
                // Creo el objeto ftp 
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(url);
                // Fijo las credenciales, usuario y contraseña 
                ftp.Credentials = new NetworkCredential(Login, Password);
                // Se define el modo pasivo en Off
                ftp.UsePassive = false;
                // Le digo que no mantenga la conexión activa al terminar. 
                ftp.KeepAlive = false;
                // Indicamos que la operación es subir un archivo... 
                ftp.Method = WebRequestMethods.Ftp.UploadFile;
                // … en modo binario … (podria ser como ASCII) 
                ftp.UseBinary = true;
                // Indicamos la longitud total de lo que vamos a enviar. 
                ftp.ContentLength = fs.Length;

                // Desactivo cualquier posible proxy http. 
                // Ojo pues de saltar este paso podría usar 
                // un proxy configurado en iexplorer 
                ftp.Proxy = null;
                // Pongo el stream al inicio 
                fs.Position = 0;
                // Configuro el buffer a 2 KBytes 
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;

                // obtener el stream del socket sobre el que se va a escribir. 
                using (Stream strm = ftp.GetRequestStream())
                {
                    // Leer del buffer 2kb cada vez 
                    contentLen = fs.Read(buff, 0, buffLength);
                    // mientras haya datos en el buffer …. 
                    while (contentLen != 0)
                    {
                        // escribir en el stream de conexión 
                        //el contenido del stream del fichero 
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }
                }
            }
        }//fin upload
    }
}
