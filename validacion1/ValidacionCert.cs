using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace ValSign
{
    public class ValidacionCert
    {
        public string estado { get; set; }
        public string msj { get; set; }
        public string msjT { get; set; }
        BasesDatos DB = new BasesDatos();
        string error;

        //public Boolean existenciaCertificado(string rfc, string nocert) 
        //{
        //    DB.Configurar2();
        //    DB.Conectar();
        //    DB.CrearComando("select no_serie,edo_certificado,fec_final_cert RFC from Certificado where RFC=@RFC and no_serie=@nocert and ");
        //    DB.AsignarParametroCadena("@RFC", rfc);
        //    DB.AsignarParametroCadena("@nocert", nocert);
        //    DbDataReader DR = DB.EjecutarConsulta3(ref error);

        //    while (DR.Read())
        //    {
        //        DB.Desconectar();
        //        return true;
        //    }
        //    DB.Desconectar();
            
        //    if (!String.IsNullOrEmpty(error))
        //    {
        //        msjT += error + Environment.NewLine;
        //    }
        //    msj += "RFC y Número de certificado no encontrados.";
        //    return false;
            
        //}

        public Boolean existenciaCertificado(string rfc, string nocert)
        {
            try
            {
                DB.Configurar2();
                DB.Conectar();
                DB.CrearComando(@"select no_serie,edo_certificado,fec_final_cert,RFC 
                             from 
                             Certificado where RFC=@RFC and no_serie=@nocert AND edo_certificado ='A'");
                DB.AsignarParametroCadena("@RFC", rfc);
                DB.AsignarParametroCadena("@nocert", nocert);
                DbDataReader DR2 = DB.EjecutarConsulta3(ref error);

                if (DR2.Read())
                {
                    DB.Desconectar();
                    return true;
                }
                else
                {
                    msj += "El Certificado es incorrecto (es invalido, esta cancelado o esta revocado).";
                    DB.Desconectar();
                    return false;
                }
                // DB.Desconectar();

                //if (!String.IsNullOrEmpty(error))
                //{
                //    msjT += error + Environment.NewLine;
                //}

            }catch(Exception y){
            return false;
            }
        }


        //public Boolean estatusCertificado(string rfc, string nocert)
        //{
        //    string status, fecha, fecha2;
        //    DateTime auxfecha, auxfecha2;

        //    DB.Configurar2();
        //    DB.Conectar();
        //    DB.CrearComando("select edo_certificado, fec_final_cert from Certificado where RFC=@RFC and no_serie=@nocert");
        //    DB.AsignarParametroCadena("@RFC", rfc);
        //    DB.AsignarParametroCadena("@nocert", nocert);
        //    DbDataReader DR = DB.EjecutarConsulta3(ref error);

        //    while (DR.Read())
        //    {
        //        status = DR[0].ToString();
        //        fecha = DR[1].ToString();
        //        DB.Desconectar();

        //        if (status == "A")
         
        //            fecha2 = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        //            auxfecha = Convert.ToDateTime(fecha);
        //            auxfecha2 = Convert.ToDateTime(fecha2);

        //            if (auxfecha < auxfecha2)
        //            {
        //                msj = "El certificado no esta vigente.";
        //                return false;
        //            }
        //            else
        //            {
        //                return true;
        //            }
        //        }
        //        else if (status == "R")
        //        {
        //            msj = "El certificado esta revocado.";
        //            return false;
        //        }
        //        else if (status == "C")
        //        {
        //            msj = "El certificado esta cancelado.";
        //            return false;
        //        }
        //        else
        //        {
        //            return false;
        //        }*/
        //    }
        //    DB.Desconectar();

        //    if (!String.IsNullOrEmpty(error))
        //    {
        //        msjT += error + Environment.NewLine;
        //    }
        //    msj += "RFC y Número de certificado no encontrados.";
        //    return false;
        //}
    
    }
}
