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
    public partial class crear_rol : System.Web.UI.Page
    {
        string filename;
        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BCrear_Click(object sender, EventArgs e)
        {
            








        }

        protected void BCrear_Click1(object sender, EventArgs e)
        {
            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_insertar_rol");
            DB.AsignarParametroProcedimiento("@descripcion", System.Data.DbType.String, tbRol.Text);
            DB.AsignarParametroProcedimiento("@crear_cliente", System.Data.DbType.Byte, Convert.ToByte (cbCrear_cliente.Checked));
            DB.AsignarParametroProcedimiento("@crear_admin_sucursal", System.Data.DbType.Byte, Convert.ToByte(cbCrear_admin.Checked));
            DB.AsignarParametroProcedimiento("@consultar_facturas_propias", System.Data.DbType.Byte, Convert.ToByte(cbConsulta_propias.Checked));
            DB.AsignarParametroProcedimiento("@consultar_todas_facturas", System.Data.DbType.Byte, Convert.ToByte(cbConsulta_todas.Checked));
            DB.AsignarParametroProcedimiento("@reportesSucursales", System.Data.DbType.Byte, Convert.ToByte(cbReportesSucursales.Checked));
            DB.AsignarParametroProcedimiento("@reportesGlobales", System.Data.DbType.Byte, Convert.ToByte(cbReportesGlobales.Checked));
            DB.AsignarParametroProcedimiento("@modificarEmpleado", System.Data.DbType.Byte, Convert.ToByte(cbModificarEmpleado.Checked));
            DB.AsignarParametroProcedimiento("@asignacion_roles", System.Data.DbType.Byte, Convert.ToByte(cbAsignar_rol.Checked));
            DB.AsignarParametroProcedimiento("@envio_facturas_email", System.Data.DbType.Byte, Convert.ToByte(cbEnvio_fac.Checked));
            DB.AsignarParametroProcedimiento("@agregar_documento", System.Data.DbType.Byte, Convert.ToByte(cbAgregar_doc.Checked));
            DB.EjecutarConsulta1();
            DB.Desconectar();
            Response.Redirect("roles.aspx");
        }
    }
}