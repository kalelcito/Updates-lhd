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
    public partial class modificar_sesion : System.Web.UI.Page
    {
        string idSesion;

        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                idSesion = Request.QueryString.Get("id");
                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_consulta_sesion");
                DB.AsignarParametroProcedimiento("@idSesion", System.Data.DbType.String, idSesion);
                DbDataReader DR = DB.EjecutarConsulta();
                DR.Read();
                tbDescripcion.Text = DR[1].ToString();
                ddlConexiones.SelectedValue = DR[2].ToString();
                ddlDuracion.SelectedValue = DR[3].ToString();
                ddlIntentos.SelectedValue = DR[4].ToString();
               

                DB.Desconectar();

            }     
        }

        protected void bModificarsesion_Click(object sender, EventArgs e)
        {
            idSesion = Request.QueryString.Get("id");

            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_modificar_sesion");
            DB.AsignarParametroProcedimiento("@idSesion", System.Data.DbType.String, idSesion);
            DB.AsignarParametroProcedimiento("@descripcion", System.Data.DbType.String, tbDescripcion.Text);
            DB.AsignarParametroProcedimiento("@conexiones_simultaneas", System.Data.DbType.Int16, ddlConexiones.SelectedValue);
            DB.AsignarParametroProcedimiento("@duracion_sesion", System.Data.DbType.String, ddlDuracion.SelectedValue);
            DB.AsignarParametroProcedimiento("@intentos", System.Data.DbType.Int16, ddlIntentos.SelectedValue);
            
            
            DB.EjecutarConsulta1();

            DB.Desconectar();
            Response.Redirect("sesiones.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
           

        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("sesiones.aspx");
        }
    }
}