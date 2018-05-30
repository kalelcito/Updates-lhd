using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data.Common;

namespace DataExpressWeb
{
    public partial class addProveedores : System.Web.UI.Page
    {
        BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bGuardar_Click(object sender, EventArgs e)
        {
            DB.Conectar();
            DB.CrearComando(@"insert into Proveedores
                                (rfc,razonSocial) 
                                values 
                                (@rfc,@razonSocial)");
            DB.AsignarParametroCadena("@rfc", tbRFC.Text);
            DB.AsignarParametroCadena("@razonSocial", tbNombre.Text);
            DB.EjecutarConsulta1();
            DB.Desconectar();

            Response.Redirect("Proveedores.aspx");
                       
        
        }
    }
}