using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Datos;
using System.Data.Common;


namespace DataExpressWeb.nuevos
{
    /// <summary>
    /// Descripción breve de autoRec
    /// </summary>
    /// 
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class autoRec : System.Web.Services.WebService
    {
        BasesDatos DB;
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] getRfc(string prefixText)
        {
            List<string> a = new List<string>();
            try
            {
                DB = new BasesDatos();
                DB.Conectar();
                DB.CrearComando("SELECT TOP 10 RFCREC FROM RECEPTOR where RFCREC LIKE @rfc");
                DB.AsignarParametroCadena("@rfc", prefixText + "%");
                DbDataReader DR = DB.EjecutarConsulta();
                while (DR.Read())
                {
                    a.Add(DR["RFCREC"].ToString());
                }
                DB.Desconectar();
            }
            catch (Exception e)
            {
            }
            return a.ToArray();
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] getRfcEmi(string prefixText)
        {
            List<string> a = new List<string>();
            try
            {
                DB = new BasesDatos();
                DB.Conectar();
                DB.CrearComando("SELECT TOP 10 RFCEMI FROM EMISOR where RFCEMI LIKE @rfc");
                DB.AsignarParametroCadena("@rfc", prefixText + "%");
                DbDataReader DR = DB.EjecutarConsulta();
                while (DR.Read())
                {
                    a.Add(DR["RFCEMI"].ToString());
                }
                DB.Desconectar();
            }
            catch (Exception e)
            {
            }
            return a.ToArray();
        }
    }
}
