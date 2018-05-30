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
    public partial class modificar_usuario : System.Web.UI.Page
    {
        string idEmpleado, idCliente;
        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            idEmpleado = Request.QueryString.Get("idmrdxbdi");
            idCliente = Request.QueryString.Get("idmbdi");
            if (!Page.IsPostBack)
            {
               // idEmpleado = Request.QueryString.Get("idmrdxbdi");
                //idCliente = Request.QueryString.Get("idmbdi");
                if (!String.IsNullOrEmpty(idEmpleado))
                {
                    DB.Conectar();
                    DB.CrearComandoProcedimiento("PA_consulta_empleadosUpdate");
                    DB.AsignarParametroProcedimiento("@idEmpleado", System.Data.DbType.String, idEmpleado);
                    DbDataReader DR = DB.EjecutarConsulta();
                    if (DR.Read())
                    {
                        tbNombre.Text = DR[1].ToString();
                        tbUsername.Text = DR[2].ToString();
                        tbContraseña.Text = DR[3].ToString();
                        ddlStatus.SelectedValue = DR[7].ToString();
                        ddlRol.SelectedValue = DR[4].ToString();
                        ddlSesion.SelectedValue = DR[9].ToString();
                        ddlSucursal.SelectedValue = DR[10].ToString();
                        permisoList.SelectedValue = DR[11].ToString();
                        dllVal.SelectedValue = DR[12].ToString();
                    }

                    DB.Desconectar();
                }

                SqlDataSourceModulo2.DataBind();
                lbModulo.DataBind();
              
                DB.Conectar();
                DB.CrearComando("SELECT id_Modulo FROM ModuloEmpleado WHERE id_Empleado = @id_Empleado");
                DB.AsignarParametroCadena("@id_Empleado", idEmpleado);
                DbDataReader DRM = DB.EjecutarConsulta();
                while (DRM.Read())
                {
                    foreach (ListItem item in lbModulo.Items)
                    {
                        
                            if ((item.Value == DRM[0].ToString()))
                            {
                                item.Selected = true;
                              
                            }
                        
                    }
                }
                DB.Desconectar();


                if (!String.IsNullOrEmpty(idCliente))
                {
                    ddlRol.Visible = false;
                   // ddlSucursal.Visible = false;
                    DB.Conectar();
                    DB.CrearComandoProcedimiento("PA_consulta_clientesUpdate");
                    DB.AsignarParametroProcedimiento("@idCliente", System.Data.DbType.String, idCliente);
                    DbDataReader DR = DB.EjecutarConsulta();
                    DR.Read();
                    tbNombre.Text = DR[1].ToString();
                    tbUsername.Text = DR[2].ToString();
                    tbContraseña.Text = DR[3].ToString();
                    ddlStatus.SelectedValue = DR[7].ToString();
                    ddlRol.SelectedValue = DR[4].ToString();
                    ddlSesion.SelectedValue = DR[9].ToString();
                    ddlSucursal.SelectedValue = DR[10].ToString();
                    DB.Desconectar();
                }
            }
        }

        protected void bModificar_Click1(object sender, EventArgs e)
        {
            idEmpleado = Request.QueryString.Get("idmrdxbdi");
            idCliente = Request.QueryString.Get("idmbdi");

            if (!String.IsNullOrEmpty(idEmpleado))
            {
                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_modificar_empleado");
                DB.AsignarParametroProcedimiento("@idEmpleado", System.Data.DbType.String, idEmpleado);
                DB.AsignarParametroProcedimiento("@nombreEmpleado", System.Data.DbType.String, tbNombre.Text);
                DB.AsignarParametroProcedimiento("@userEmpleado", System.Data.DbType.String, tbUsername.Text);
                DB.AsignarParametroProcedimiento("@claveEmpleado", System.Data.DbType.String, tbContraseña.Text);
                DB.AsignarParametroProcedimiento("@id_Rol", System.Data.DbType.Int16, ddlRol.SelectedValue);
                DB.AsignarParametroProcedimiento("@status", System.Data.DbType.String, ddlStatus.SelectedValue);
                DB.AsignarParametroProcedimiento("@id_Sesion", System.Data.DbType.Int16, 1);
                DB.AsignarParametroProcedimiento("@id_Sucursal", System.Data.DbType.Int16, ddlSucursal.SelectedValue);
                DB.AsignarParametroProcedimiento("@tipo", System.Data.DbType.String , permisoList.SelectedItem.ToString());
                DB.AsignarParametroProcedimiento("@permVal", System.Data.DbType.Int16, dllVal.SelectedValue);
                DB.EjecutarConsulta1();
                DB.Desconectar();

                //Se eliminan para volver a agregarlos
                DB.Conectar();
                DB.CrearComando(@"DELETE FROM ModuloEmpleado WHERE id_Empleado=@id_Empleado");
                DB.AsignarParametroCadena("@id_Empleado", idEmpleado);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                //Se agregan nuevamente los seleccionados.
                foreach (ListItem item in lbModulo.Items)
                {
                   
                        if ((item.Selected))
                        {
                            DB.Conectar();
                            DB.CrearComando(@"INSERT INTO ModuloEmpleado
                                (id_Empleado,id_Modulo)
                              VALUES 
                                (@id_Empleado,@id_Modulo)");
                            DB.AsignarParametroCadena("@id_Empleado", idEmpleado.ToString());
                            DB.AsignarParametroCadena("@id_Modulo", item.Value);
                            DB.EjecutarConsulta1();
                            DB.Desconectar();
                        }
                    
                }

                Response.Redirect("empleados.aspx");
            }
            if (!String.IsNullOrEmpty(idCliente))
            {
                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_modificar_cliente");
                DB.AsignarParametroProcedimiento("@idCliente", System.Data.DbType.String, idCliente);
                DB.AsignarParametroProcedimiento("@nombreCliente", System.Data.DbType.String, tbNombre.Text);
                DB.AsignarParametroProcedimiento("@userCliente", System.Data.DbType.String, tbUsername.Text);
                DB.AsignarParametroProcedimiento("@claveCliente", System.Data.DbType.String, tbContraseña.Text);
               DB.AsignarParametroProcedimiento("@id_Rol", System.Data.DbType.Int32, 1);
                DB.AsignarParametroProcedimiento("@status", System.Data.DbType.String, ddlStatus.SelectedValue);
                DB.AsignarParametroProcedimiento("@id_Sesion", System.Data.DbType.Int16, 1);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                Response.Redirect("clientes.aspx");
            }
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(idEmpleado))
            {
                Response.Redirect("empleados.aspx");
            }
            if (!String.IsNullOrEmpty(idCliente))
            {
                Response.Redirect("clientes.aspx");
            }
        }
    }
}