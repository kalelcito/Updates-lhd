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
    public partial class modificarSucursal : System.Web.UI.Page
    {
        string idSucursal;
        
        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                idSucursal = Request.QueryString.Get("id");
                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_consultaSucursal");
                DB.AsignarParametroProcedimiento("@idSucursal", System.Data.DbType.String, idSucursal);
                DbDataReader DR = DB.EjecutarConsulta();
                DR.Read();
                tbClave.Text = DR[1].ToString();
                tbSucursal.Text = DR[2].ToString();
                tbDireccion.Text = DR[3].ToString();

                DB.Desconectar();

            }         
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {

           idSucursal = Request.QueryString.Get("id");
   
            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_modificarSucursal");
            DB.AsignarParametroProcedimiento("@idSucursal", System.Data.DbType.String, idSucursal);
            DB.AsignarParametroProcedimiento("@clave", System.Data.DbType.String, tbClave.Text);
            DB.AsignarParametroProcedimiento("@sucursal", System.Data.DbType.String, tbSucursal.Text);
            DB.AsignarParametroProcedimiento("@domicilio", System.Data.DbType.String, tbDireccion.Text);
            DB.EjecutarConsulta1();

            DB.Desconectar();
            Response.Redirect("sucursales.aspx");
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("sucursales.aspx");
        }
    }
}