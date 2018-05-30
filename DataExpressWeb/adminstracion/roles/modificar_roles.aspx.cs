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
    public partial class modificar_roles : System.Web.UI.Page
    {
        string idRol;
        
        private BasesDatos DB = new BasesDatos();
        //private Boolean bcrearCliente;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                idRol = Request.QueryString.Get("id");
                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_consulta_rol");
                DB.AsignarParametroProcedimiento("@idRol", System.Data.DbType.String, idRol);
                DbDataReader DR = DB.EjecutarConsulta();
                DR.Read();
               
                
                tbRol.Text = DR[1].ToString();
     
                cbCrear_cliente.Checked = Convert.ToBoolean ( DR[2].ToString());
                cbCrear_admin.Checked = Convert.ToBoolean ( DR[3].ToString());
                cbConsulta_propias.Checked = Convert.ToBoolean ( DR[4].ToString());
                cbConsulta_todas.Checked = Convert.ToBoolean ( DR[5].ToString());
                cbReportesSucursales.Checked = Convert.ToBoolean ( DR[6].ToString());
                cbReportesGlobales.Checked = Convert.ToBoolean ( DR[7].ToString());
                cbModificarEmpleado.Checked = Convert.ToBoolean ( DR[8].ToString());
                cbAsignar_rol.Checked = Convert.ToBoolean ( DR[9].ToString());
                cbEnvio_fac.Checked = Convert.ToBoolean ( DR[10].ToString());
                cbAgregar_doc.Checked = Convert.ToBoolean(DR[11].ToString());

                DB.Desconectar();

            }     


            
        }

       protected void bModificar_Click(object sender, EventArgs e)
        {
            idRol = Request.QueryString.Get("id");

            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_modificar_rol");
            DB.AsignarParametroProcedimiento("@idRol", System.Data.DbType.String, idRol);
            DB.AsignarParametroProcedimiento("@descripcion", System.Data.DbType.String, tbRol.Text);
            DB.AsignarParametroProcedimiento("@crear_cliente", System.Data.DbType.Byte, Convert.ToByte(cbCrear_cliente.Checked));
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

       protected void bCancelar_Click(object sender, EventArgs e)
       {
           Response.Redirect("roles.aspx");
       }

        
    }
}