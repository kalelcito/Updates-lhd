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
    public partial class empleados : System.Web.UI.Page
    {
        /*
         string filename;
         private BasesDatos DB = new BasesDatos();
         protected void Page_Load(object sender, EventArgs e)
         {

             filename = Request.QueryString.Get("id");
             DB.Conectar();
             DB.CrearComandoProcedimiento("PA_consulta_sesion");
             DB.AsignarParametroProcedimiento("@id_Sesion", System.Data.DbType.String, filename);
             DbDataReader DR = DB.EjecutarConsulta();


             GridView1.DataSourceID = null;
             GridView1.DataSource = DR;
             GridView1.DataBind();
           

           DB.Desconectar();
             
         */
    }
}
