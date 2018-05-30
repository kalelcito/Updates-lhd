using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.IO;

namespace validacionCFD
{
    public class Procesar
    {
        StreamReader objReaderFolios, objReaderCert;
        BasesDatos DB;
        public string msj {get; set;}        
        string error;
        public Procesar()
        {
            DB = new BasesDatos();
            msj = "";
        }
        //fOLIOS
        public void cargarFolios()
        {           
            DB.Conectar();
            DB.CrearComando(@"delete from Folios");
            DB.EjecutarConsulta2(ref error);
            DB.Desconectar();

            DB.Conectar();
            DB.CrearComando(@"DBCC CHECKIDENT (Folios, RESEED, 0)");
            DB.EjecutarConsulta2(ref error);
            DB.Desconectar();

            objReaderFolios = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "FoliosCFD.txt");
            string strLinea = "";
            
            try
            {
                while (strLinea != null)
                {
                    strLinea = objReaderFolios.ReadLine();
                    String[] val = strLinea.Split('|');
                    DB.Conectar();
                    DB.CrearComando(@"insert into Folios (RFC,noAprobacion,anoAprobacion,serie,folioInicial,folioFinal) values (@RFC,@noAprobacion,@anoAprobacion,@serie,@folioInicial,@folioFinal)");
                    DB.AsignarParametroCadena("@RFC", val[0]);
                    DB.AsignarParametroCadena("@noAprobacion", val[1]);
                    DB.AsignarParametroCadena("@anoAprobacion", val[2]);
                    DB.AsignarParametroCadena("@serie", val[3]);
                    DB.AsignarParametroCadena("@folioInicial", val[4]);
                    DB.AsignarParametroCadena("@folioFinal", val[5]);
                    DB.EjecutarConsulta2(ref error);
                    msj = error;
                    DB.Desconectar();
                }
                objReaderFolios.Close();
                objReaderFolios.Dispose();
                
            }
            catch (Exception e)
            {
                msj = e.Message;
            }
        }
        
        
        //cERTIFICADO
        public void cargarCertificados()
        {
            objReaderCert = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "CSD.txt");
            string strLinea2 = "";
            string fecha_inicial;
            string fecha_final;
            DateTime fecha;

            DB.Conectar();
            DB.CrearComando(@"delete from Certificado");
            DB.EjecutarConsulta2(ref error);
            DB.Desconectar();

            DB.Conectar();
            DB.CrearComando(@"DBCC CHECKIDENT (Certificado, RESEED, 0)");
            DB.EjecutarConsulta2(ref error);
            DB.Desconectar();
            try
            {
                while (strLinea2 != null)
                {
                    strLinea2 = objReaderCert.ReadLine();
                    String[] val = strLinea2.Split('|');
                    
                    fecha = Convert.ToDateTime(val[1]);
                    fecha_inicial = fecha.ToString("dd-MM-yyyy HH:mm:ss");

                    fecha = Convert.ToDateTime(val[2]);
                    fecha_final = fecha.ToString("dd-MM-yyyy HH:mm:ss");

                    DB.Conectar();
                    DB.CrearComando(@"insert into Certificado (no_serie,fec_inicial_cert,fec_final_cert,RFC,edo_certificado) values (@no_serie,@fec_inicial_cert,@fec_final_cert,@RFC,@edo_certificado)");
                    DB.AsignarParametroCadena("@no_serie", val[0]);                    
                    DB.AsignarParametroCadena("@fec_inicial_cert", fecha_inicial);
                    DB.AsignarParametroCadena("@fec_final_cert", fecha_final);
                    DB.AsignarParametroCadena("@RFC", val[3]);
                    DB.AsignarParametroCadena("@edo_certificado", val[4]);
                    DB.EjecutarConsulta2(ref error);
                    msj = error;
                    DB.Desconectar();
                }
                objReaderCert.Close();
                objReaderCert.Dispose();
            }
            catch (Exception e)
            {
                msj = e.Message;
            }
        }
    }
}
