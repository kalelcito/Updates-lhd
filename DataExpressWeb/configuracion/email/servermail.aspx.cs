using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using Datos;
using System.Data.Common;

namespace DataExpressWeb.configuracion.email
{
    public partial class servermail : System.Web.UI.Page
    {
        private BasesDatos DB = new BasesDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            ///Leer el archivo datos de conexion///
           //Leer los datos de la base de datos////
            if (!Page.IsPostBack)
            {
                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_consultarParametros");
                DB.AsignarParametroProcedimiento("@idparametro", System.Data.DbType.String, 1);
                DbDataReader DR = DB.EjecutarConsulta();

                while (DR.Read())
                {
                    tbServidor.Text = DR[7].ToString();
                    tbPuerto.Text = DR[8].ToString();
                    tbUsuario.Text = DR[10].ToString();
                    tbPassword.Text = DR[11].ToString();
                    tbEmailEnvio.Text = DR[12].ToString();
                    cbSSL.Checked = Convert.ToBoolean(DR[9].ToString());
                }
                DB.Desconectar();
            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            tbServidor.ReadOnly = false;
            tbPuerto.ReadOnly = false;
            tbUsuario.ReadOnly = false;
            tbPassword.ReadOnly = false;
            tbEmailEnvio.ReadOnly = false;
            cbSSL.Enabled = true;
            bModificar.Visible = false;
            bActualizar.Visible = true;
            //Response.Redirect("Modificar.aspx");
        }

        protected void bActualizar_Click(object sender, EventArgs e)
        {

            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_modificarParametrosEmail");
            DB.AsignarParametroProcedimiento("@idparametro", System.Data.DbType.Int16, 0);
            DB.AsignarParametroProcedimiento("@servidor", System.Data.DbType.String, tbServidor.Text);
            DB.AsignarParametroProcedimiento("@puerto", System.Data.DbType.String, tbPuerto.Text);
            DB.AsignarParametroProcedimiento("@usuario", System.Data.DbType.String, tbUsuario.Text);
            DB.AsignarParametroProcedimiento("@password", System.Data.DbType.String, tbPassword.Text);
            DB.AsignarParametroProcedimiento("@emailenvio", System.Data.DbType.String, tbEmailEnvio.Text);
            DB.AsignarParametroProcedimiento("@ssl", System.Data.DbType.Byte,cbSSL.Checked);
            DB.EjecutarConsulta();
            DB.Desconectar();
            tbServidor.ReadOnly = true;
            tbPuerto.ReadOnly = true;
            tbUsuario.ReadOnly = true;
            tbPassword.ReadOnly = true;
            tbEmailEnvio.ReadOnly = true;
            cbSSL.Enabled = false;
            bModificar.Visible = true;
            bActualizar.Visible = false;

        }
    }
}