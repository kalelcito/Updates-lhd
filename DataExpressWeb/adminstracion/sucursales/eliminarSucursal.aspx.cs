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
    public partial class eliminarSucursal : System.Web.UI.Page
    {

        string idSucursal;
        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            idSucursal = Request.QueryString.Get("id");
            if (!String.IsNullOrEmpty(idSucursal))
            {
                //elimnar

                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_eliminar_sucursal");
                DB.AsignarParametroProcedimiento("@idSucursal", System.Data.DbType.String, idSucursal);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                Response.Redirect("sucursales.aspx");

            }

        }
    }
}