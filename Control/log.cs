using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Control
{
    public class Log
    {
        public string rutaLog;
        public string rutaLogws;
        public string rutaTickets;
        public string rutaArchivos;
        public string rutaEnviados;
        public string rutaMicros;
        public Log()
        {
            /*  rutaLog = @"D:\MICROS\DataExpress\log\";
              rutaTickets = @"D:\MICROS\DataExpress\tickets\";
              rutaArchivos = @"D:\MICROS\DataExpress\cola\";
              rutaEnviados = @"D:\MICROS\DataExpress\webservice\procesados\";
              rutaLogws = @"D:\MICROS\DataExpress\webservice\log\";
              */
            rutaLog = AppDomain.CurrentDomain.BaseDirectory + @"log\";
            rutaTickets = AppDomain.CurrentDomain.BaseDirectory + @"tickets\";
            rutaArchivos = AppDomain.CurrentDomain.BaseDirectory + @"cola\";
            rutaEnviados = AppDomain.CurrentDomain.BaseDirectory + @"webservice\procesados\";
            rutaLogws = AppDomain.CurrentDomain.BaseDirectory + @"webservice\log\";
            rutaMicros = AppDomain.CurrentDomain.BaseDirectory + @"micros\";
        }

        public void guardar_Log(string datos)//, string nombre_arch
        {
            string nombre_hoy;
            nombre_hoy = "Log_RECEPCION" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            string ruta = rutaLog + nombre_hoy;
            if (File.Exists(ruta))
            {
                using (StreamWriter w = File.AppendText(ruta))
                {
                    contenidoLog(datos, w);
                    w.Close(); // Close the writer and underlying file.
                }
            }
            else
            {
                FileStream fs1 = new FileStream(ruta, FileMode.CreateNew);
                BinaryWriter c1 = new BinaryWriter(fs1);

                c1.Close();
                fs1.Close();
                using (StreamWriter w = File.AppendText(ruta))
                {
                    contenidoLog(datos, w);
                    w.Close(); // Close the writer and underlying file.
                }
            }
        }

        public void escribe_Trama(string datos, string nombre_arch, string tipo)
        {
            string ruta;
            //-------------------------------------------------------------------------------------------------------------------------
            //Aqui se crea un nuevo archivo para cada trama 
            if (tipo.Equals("micros"))
            {
                ruta = rutaMicros + nombre_arch + ".txt";
            }
            else
            {
                ruta = rutaArchivos + nombre_arch + ".txt";

            }
            if (!File.Exists(ruta))
            {
                FileStream fs1 = new FileStream(ruta, FileMode.CreateNew);
                BinaryWriter c1 = new BinaryWriter(fs1);

                c1.Close();
                fs1.Close();
                using (StreamWriter w = File.AppendText(ruta))
                {
                    Registro(datos, w);
                    // Close the writer and underlying file.
                    w.Close();
                }
            }
            else
            {
                Escribe_Arch_ws("Ya esta en cola esta trama");
            }
        }

        public void Leertramas(string datos)
        {
            string nombre_hoy;
            nombre_hoy = "Log_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            //nombre_hoy = "log.txt";
            string ruta = rutaTickets + nombre_hoy;
            if (File.Exists(ruta))
            {
                using (StreamWriter w = File.AppendText(ruta))
                {
                    contenidoLog(datos, w);
                    w.Close(); // Close the writer and underlying file.
                }
            }
            else
            {
                FileStream fs1 = new FileStream(ruta, FileMode.CreateNew);
                BinaryWriter c1 = new BinaryWriter(fs1);
                c1.Close();
                fs1.Close();
                using (StreamWriter w = File.AppendText(ruta))
                {
                    contenidoLog(datos, w);
                    w.Close(); // Close the writer and underlying file.
                }
            }
        }

        public void Escribe_Arch_ws(string datos)
        {
            string nombre_hoy;
            nombre_hoy = "Log_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            //nombre_hoy = "log.txt";
            string ruta = rutaLogws + nombre_hoy;
            if (File.Exists(ruta))
            {
                using (StreamWriter w = File.AppendText(ruta))
                {
                    contenidoLog(datos, w);
                    w.Close(); // Close the writer and underlying file.
                }
            }
            else
            {
                FileStream fs1 = new FileStream(ruta, FileMode.CreateNew);
                BinaryWriter c1 = new BinaryWriter(fs1);
                c1.Close();
                fs1.Close();
                using (StreamWriter w = File.AppendText(ruta))
                {
                    contenidoLog(datos, w);
                    w.Close(); // Close the writer and underlying file.
                }
            }
        }
        public void contenidoLog(String logMessage, TextWriter w)//Archivo Log
        {
            w.WriteLine("{0}", DateTime.Now.ToString("dd-MM-yyyy  HH:mm:ss") + "  " + logMessage);
            w.WriteLine(" ");
            //w.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            w.Flush();  // Update the underlying file.
        }
        private static void Registro(String logMessage, TextWriter w)//Archivo Registro
        {
            w.WriteLine(logMessage);
            w.Flush();
        }
    }
}
