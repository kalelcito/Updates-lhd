using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
namespace DataExpressWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        String user;
        String password;
        String email;
        BasesDatos DB = new BasesDatos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bRegistrarse_Click(object sender, EventArgs e)
        {
            user = tbRfcuser.Text;
            password = tbPass.Text;
            email = tbEmail.Text;

            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_Registro_Cliente");
            DB.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, tbRfcuser.Text);
            DB.AsignarParametroProcedimiento("@PASSWORD", System.Data.DbType.String, tbPass.Text);
            DB.AsignarParametroProcedimiento("@EMAIL", System.Data.DbType.String, tbEmail.Text);
            DB.EjecutarConsulta();

            DB.Desconectar();
        }

    }
}