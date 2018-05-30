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
    public partial class agregarSucursal : System.Web.UI.Page
    {
        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void bGuardar_Click(object sender, EventArgs e)
        {
            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_inserta_sucursal");
            DB.AsignarParametroProcedimiento("@clave", System.Data.DbType.String, tbClave.Text);
            DB.AsignarParametroProcedimiento("@sucursal", System.Data.DbType.String, tbSucursal.Text);
            DB.AsignarParametroProcedimiento("@domicilio", System.Data.DbType.String, tbDireccion.Text);
            DB.EjecutarConsulta1();
            DB.Desconectar();
            Response.Redirect("sucursales.aspx");
        }
    }
}