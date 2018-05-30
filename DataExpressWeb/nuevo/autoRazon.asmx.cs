using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
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
    public class autoRazon : System.Web.Services.WebService
    {

        BasesDatos DB;
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] getRfc(string prefixText)
        {
            int count = 0;
            string[] a = new String[1];
            DB = new BasesDatos();
            string sql1 = "SELECT TOP 10 NOMREC FROM RECEPTOR where NOMREC LIKE @RAZON";
            int Contador = 0;
            try
            {
                DB.Conectar();
                DB.CrearComando("SELECT TOP 10 COUNT(NOMREC) FROM RECEPTOR where NOMREC LIKE @RAZON");
                DB.AsignarParametroCadena("@RAZON", prefixText + "%");
                DbDataReader DRTot = DB.EjecutarConsulta();
                DRTot.Read();
                count = Convert.ToInt32(DRTot[0].ToString());
                DB.Desconectar();

                DB.Conectar();
                DB.CrearComando(sql1);
                DB.AsignarParametroCadena("@RAZON", prefixText + "%");
                DbDataReader DRSum = DB.EjecutarConsulta();
                string[] items = new string[10];
                while (DRSum.Read())
                {
                    items[Contador] = DRSum[0].ToString();
                    Contador++;
                }
                DB.Desconectar();
                if (count == 0) { a[0] = ""; return a; }
                else { return items; }
            }
            catch (Exception e) { a[0] = e.ToString(); return a; }
        }

        public string[] getRfcEmi(string prefixText)
        {
            int count = 0;
            string[] a = new String[1];
            DB = new BasesDatos();
            string sql1 = "SELECT TOP 10 NOMEMI FROM EMISOR where NOMEMI LIKE @RAZON";
            int Contador = 0;
            try
            {
                DB.Conectar();
                DB.CrearComando("SELECT TOP 10 COUNT(NOMEMI) FROM EMISOR where NOMEMI LIKE @RAZON");
                DB.AsignarParametroCadena("@RAZON", prefixText + "%");
                DbDataReader DRTot = DB.EjecutarConsulta();
                DRTot.Read();
                count = Convert.ToInt32(DRTot[0].ToString());
                DB.Desconectar();

                DB.Conectar();
                DB.CrearComando(sql1);
                DB.AsignarParametroCadena("@RAZON", prefixText + "%");
                DbDataReader DRSum = DB.EjecutarConsulta();
                string[] items = new string[10];
                while (DRSum.Read())
                {
                    items[Contador] = DRSum[0].ToString();
                    Contador++;
                }
                DB.Desconectar();
                if (count == 0) { a[0] = ""; return a; }
                else { return items; }
            }
            catch (Exception e) { a[0] = e.ToString(); return a; }
        }

    }
}
