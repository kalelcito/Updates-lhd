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
    public class ValidacionFolios
    {
        BasesDatos DB = new BasesDatos();
        public string estado { get; set; }
        public string msj { get; set; }
        public string msjT { get; set; }
        string error;

        public Boolean folioyserie(string rfc, string serie, string folio, string anoaprob, string noaprob) 
        {
            string folioInicial, folioFinal, auxaprob;
            int fol, folI, folF ;

            if (String.IsNullOrEmpty(serie))
            {
                DB.Configurar2();
                DB.Conectar();
                DB.CrearComando("select noAprobacion, folioInicial, folioFinal, RFC from Folios where RFC=@RFC and noAprobacion=@noaprob and anoAprobacion=@anoaprob");
                DB.AsignarParametroCadena("@RFC", rfc);
                DB.AsignarParametroCadena("@noaprob", noaprob);
                DB.AsignarParametroCadena("@anoaprob", anoaprob);
                //DbDataReader DR = DB.EjecutarConsulta3(ref error);
            }
            else
            {
                DB.Configurar2();
                DB.Conectar();
                DB.CrearComando("select noAprobacion, folioInicial, folioFinal, RFC from Folios where RFC=@RFC and noAprobacion=@noaprob and anoAprobacion=@anoaprob and serie=@serie");
                DB.AsignarParametroCadena("@RFC", rfc);
                DB.AsignarParametroCadena("@noaprob", noaprob);
                DB.AsignarParametroCadena("@anoaprob", anoaprob);
                DB.AsignarParametroCadena("@serie", serie);
            }
            DbDataReader DR = DB.EjecutarConsulta3(ref error);

            while (DR.Read())
            {
                auxaprob = DR[0].ToString();
                folioInicial = DR[1].ToString();
                folioFinal = DR[2].ToString();
                DB.Desconectar();

                fol = Convert.ToInt32(folio);
                folI = Convert.ToInt32(folioInicial);
                folF = Convert.ToInt32(folioFinal);
                if (fol >= folI && fol <= folF)
                {
                    if (noaprob == auxaprob)
                    {
                        return true;
                    }
                    else
                    {
                        msj = "El número de aprobación es invalido.";
                        estado = "1";
                        return false;
                    }
                }
                else
                {
                    msj = "El número de folio no esta dentro del rango, o no esta autorizado por el SAT.";
                    estado = "3";
                    return false;
                }
            }
            DB.Desconectar();            
            if (!String.IsNullOrEmpty(error))
            {
                msjT += error + Environment.NewLine;
            }
            msj += "Serie y/o año de aprobación no Existen en la BD.";
            estado = "3";
            return false;
        }
    }
}