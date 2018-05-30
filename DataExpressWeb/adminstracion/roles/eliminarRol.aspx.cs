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
    public partial class eliminarRol : System.Web.UI.Page
    {

        string idRol;
        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            idRol = Request.QueryString.Get("id");
            if (!String.IsNullOrEmpty(idRol))
            {
                //elimnar

                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_eliminar_rol");
                DB.AsignarParametroProcedimiento("@idRol", System.Data.DbType.String, idRol);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                Response.Redirect("roles.aspx");

            }
        }
    }
}