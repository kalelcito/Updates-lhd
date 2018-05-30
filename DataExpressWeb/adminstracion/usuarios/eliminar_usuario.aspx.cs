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
    public partial class eliminar_usuario : System.Web.UI.Page
    {
        string idEmpleado,idCliente;
        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            idEmpleado = Request.QueryString.Get("idmrdxbdi");
            idCliente = Request.QueryString.Get("idmbdi");

            if (!String.IsNullOrEmpty(idEmpleado))
              {
            //elimnar

                  DB.Conectar();
                  DB.CrearComandoProcedimiento("PA_eliminar_empleado");
                  DB.AsignarParametroProcedimiento("@idEmpleado", System.Data.DbType.String, idEmpleado);
                  DB.EjecutarConsulta1();
                  DB.Desconectar();
                  Response.Redirect("empleados.aspx");

              }
            if (!String.IsNullOrEmpty(idCliente))
            {
                //elimnar

                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_eliminar_cliente");
                DB.AsignarParametroProcedimiento("@idCliente", System.Data.DbType.String, idCliente);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                Response.Redirect("clientes.aspx");

            }
        }
    }
}