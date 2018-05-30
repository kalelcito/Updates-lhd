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
    public partial class agregar_usuario : System.Web.UI.Page
    {
        private int idEmpleado = 0;
        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string siexiste = "";
            if (ddlTipoUsuario.SelectedValue == "1")
            {
                lbModulorfc.Visible = true;
             
                DB.Conectar();
                DB.CrearComando("select RFCREC from  Receptor WHERE RFCREC = @RFC ");
                DB.AsignarParametroCadena("@RFC", tbRFC.Text);
                DbDataReader DR = DB.EjecutarConsulta();
                DR.Read();
                siexiste = DR[0].ToString();
                DB.Desconectar();
                if (!String.IsNullOrEmpty(siexiste))
                {
                    DB.Conectar();
                    DB.CrearComandoProcedimiento("PA_insertar_empleados");
                    DB.AsignarParametroProcedimiento("@nombreEmpleado", System.Data.DbType.String, tbNombre.Text);
                    DB.AsignarParametroProcedimiento("@userEmpleado", System.Data.DbType.String, tbUsername.Text);
                    DB.AsignarParametroProcedimiento("@claveEmpleado", System.Data.DbType.String, tbContraseña.Text);
                    DB.AsignarParametroProcedimiento("@status", System.Data.DbType.String, ddlStatus.SelectedValue);
                    DB.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, tbRFC.Text);
                    DB.AsignarParametroProcedimiento("@id_Rol", System.Data.DbType.Int16, ddlRol.SelectedValue);
                    DB.AsignarParametroProcedimiento("@id_Sesion", System.Data.DbType.Int16, 1);
                    DB.AsignarParametroProcedimiento("@id_Sucursal", System.Data.DbType.Int16, ddlSucursal.SelectedValue);
                    DB.AsignarParametroProcedimiento("@tipo",System.Data.DbType.String,permisoList.SelectedItem.ToString());
                    DB.AsignarParametroProcedimiento("@permVal",System.Data.DbType.Int16,dllVal.SelectedValue);
                    DB.EjecutarConsulta1();
                    DB.Desconectar();

                  

                    DB.Conectar();
                    DB.CrearComando("select idEmpleado FROM  EMPLEADOS WHERE userEmpleado=@userEmpleado");
                    DB.AsignarParametroCadena("@userEmpleado", tbUsername.Text);
                    DbDataReader DR1 = DB.EjecutarConsulta();
                    if (DR1.Read())
                    {
                        idEmpleado = Convert.ToInt32(DR1[0]);
                    }
                    DB.Desconectar();

                    foreach (ListItem item in lbModulorfc.Items)
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

                    siexiste = "";
                    Response.Redirect("empleados.aspx");

                }
                else
                {
                    lMsj.Text = "Este RFC no se encuentra en la Base de Datos";
                }
            }
            if (ddlTipoUsuario.SelectedValue == "2")
            {
                DB.Conectar();
                DB.CrearComando("select RFCEMI from  EMISOR WHERE RFCEMI = @RFC ");
                DB.AsignarParametroCadena("@RFC", tbRFC.Text);
                DbDataReader DR = DB.EjecutarConsulta();
                DR.Read();
                siexiste = DR[0].ToString();
                DB.Desconectar();
                if (!String.IsNullOrEmpty(siexiste))
                {
                    DB.Conectar();
                    DB.CrearComandoProcedimiento("PA_insertar_clientes");
                    DB.AsignarParametroProcedimiento("@nombreCliente", System.Data.DbType.String, tbNombre.Text);
                    DB.AsignarParametroProcedimiento("@userCliente", System.Data.DbType.String, tbUsername.Text);
                    DB.AsignarParametroProcedimiento("@claveCliente", System.Data.DbType.String, tbContraseña.Text);
                    DB.AsignarParametroProcedimiento("@status", System.Data.DbType.String, ddlStatus.SelectedValue);
                    DB.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, tbRFC.Text);
                    DB.AsignarParametroProcedimiento("@id_Rol", System.Data.DbType.Int16, 1);
                    DB.AsignarParametroProcedimiento("@id_Sesion", System.Data.DbType.Int16, 1);
                    //DB.AsignarParametroProcedimiento("@email", System.Data.DbType.Int16, ddlSucursal.SelectedValue);
                    DB.EjecutarConsulta1();
                    DB.Desconectar();
                    siexiste = "";
                    Response.Redirect("clientes.aspx");
                }
                else
                {
                    lMsj.Text = "Este RFC no se encuentra en la Base de Datos";
                }
            }
            if (ddlTipoUsuario.SelectedValue == "0")
            {
                lMsj.Text = "Selecciona un Tipo de Usuario";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maxemp = "", maxcli = "";
            int aux = 0;
            if (ddlTipoUsuario.SelectedValue == "1")
            {
                tbRFC.Visible = false;
                tbUsername.ReadOnly = true;
                DB.Conectar();
                DB.CrearComando("select RFCREC from  REceptor");
                //                DB.AsignarParametroCadena("@RFC", rfc);
                DbDataReader DR = DB.EjecutarConsulta();
                DR.Read();
                tbRFC.Text = DR[0].ToString();
                DB.Desconectar();
               DB.Conectar();
                DB.CrearComando("select SUBSTRING(userEmpleado,LEN(userEmpleado)-3,4) from  EMPLEADOS WHERE idEmpleado= (SELECT MAX(idEmpleado) FROM EMPLEADOS)");
                            //    DB.AsignarParametroCadena("@RFC", rfc);
                DbDataReader DR1 = DB.EjecutarConsulta();
                DR1.Read();
                aux = Convert.ToInt32(DR1[0].ToString()) + 1;
                DB.Desconectar();
                if (aux.ToString().Length == 1) { maxemp = "000" + aux.ToString(); } if (aux.ToString().Length == 2) { maxemp = "00" + aux.ToString(); }
                if (aux.ToString().Length == 3) { maxemp = "0" + aux.ToString(); } if (aux.ToString().Length == 4) { maxemp = aux.ToString(); }
                
                ddlRol.Visible = true;
                lRol.Visible = true;
                ddlSucursal.Visible = true;
                lSucursal.Visible = true;
                tbUsername.Text = "EMPLE" + DateTime.Now.ToString("yy") + maxemp;
                tbEmail.Visible = false;
                lEmail.Visible = false;
            }
            if (ddlTipoUsuario.SelectedValue == "2")
            {
                tbUsername.ReadOnly = true;
                DB.Conectar();
                DB.CrearComando("select SUBSTRING(userCliente,LEN(userCliente)-3,4) from  Clientes WHERE idCliente= (SELECT MAX(idCliente) FROM Clientes)");
                            //    DB.AsignarParametroCadena("@RFC", rfc);
                DbDataReader DRc = DB.EjecutarConsulta();
                DRc.Read();
                aux = Convert.ToInt32(DRc[0]) + 1;
                DB.Desconectar();
                if (aux.ToString().Length == 1) { maxcli = "000" + aux.ToString(); } if (aux.ToString().Length == 2) { maxcli = "00" + aux.ToString(); }
                if (aux.ToString().Length == 3) { maxcli = "0" + aux.ToString(); } if (aux.ToString().Length == 4) { maxcli = aux.ToString(); }
                
                tbRFC.Text = "";
                ddlRol.Visible = false;
                lRol.Visible = false;
                ddlSucursal.Visible = false;
                lSucursal.Visible = false;
                tbUsername.Text = "PROV" + DateTime.Now.ToString("yy") + maxcli;
                tbEmail.Visible = false;
                lEmail.Visible = false;
            }
        }

        protected void SqlDataSourceModulo_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}