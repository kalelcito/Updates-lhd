using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Control;
using System.Data.Common;

namespace DataRecepcionWeb
{
    public partial class enviar : System.Web.UI.Page
    {
        string idfact;
   

        BasesDatos DB = new BasesDatos();
   

        public Boolean Archivos(string IDEFAC)
        {
            DB.Conectar();
            DB.CrearComando("select IDEARC from Archivos where IDEFAC=@IDEFAC");
            DB.AsignarParametroCadena("@IDEFAC", IDEFAC);
            
            DbDataReader DR = DB.EjecutarConsulta();

            while (DR.Read())
            {
                DB.Desconectar();
                return true;
            }
            DB.Desconectar();
            return false;
        }



     protected void Page_Load(object sender, EventArgs e)
        {
            idfact = Request.QueryString.Get("idfa");
            DB.Conectar();
            DB.CrearComando(@"SELECT resultadoValidacion
                              FROM LogErrorFacturas
                              WHERE 
                             idErrorFactura=@IDE");
            DB.AsignarParametroCadena("@IDE", idfact);
            DbDataReader DR = DB.EjecutarConsulta();
            if (DR.Read())
            {
                tbFactura.Text = DR[0].ToString();
             
            }
            DB.Desconectar();
           // tbFactura.Text = folio + " " + serie;
                    
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}