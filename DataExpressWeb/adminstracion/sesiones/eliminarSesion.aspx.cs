using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data.Common;
namespace Administracion
{
    public partial class eliminarSesion : System.Web.UI.Page
    {
        string idSesion;
        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            idSesion = Request.QueryString.Get("id");
            if (!String.IsNullOrEmpty(idSesion))
            {
                //elimnar

                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_eliminar_sesion");
                DB.AsignarParametroProcedimiento("@idSesion", System.Data.DbType.String, idSesion);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                Response.Redirect("sesiones.aspx");

            }
        }
    }
}