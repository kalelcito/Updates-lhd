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
    public partial class crear_sesion : System.Web.UI.Page
    {
        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bCrear_Click(object sender, EventArgs e)
        {
            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_inserta_sesion");
            DB.AsignarParametroProcedimiento("@descripcion", System.Data.DbType.String, tbDescripcion.Text) ;
            DB.AsignarParametroProcedimiento("@conexiones_simultaneas", System.Data.DbType.Int16, ddlConexiones.SelectedValue);
            DB.AsignarParametroProcedimiento("@duracion_sesion", System.Data.DbType.String, ddlDuracion.SelectedValue);
            DB.AsignarParametroProcedimiento("@intentos", System.Data.DbType.Int16, ddlIntentos.SelectedValue);
            DB.EjecutarConsulta1();
            DB.Desconectar();
            Response.Redirect("sesiones.aspx");
        }
    }
}