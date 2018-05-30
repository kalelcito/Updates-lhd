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
    public partial class ResultadoVal : System.Web.UI.Page
    {
        string idfact;
        string pdf;
        string xml;
        string folio;
        string serie;
        string fecha;
        string receptor;
        string mail;
        string filename;
        string rfcname;
        string dirname;

        BasesDatos DB = new BasesDatos();
        string servidor = "";
        Int32 puerto ;
        Boolean ssl = false;
        string emailCredencial = "";
        string passCredencial = "";
        string dirtxt, dirbck, dirpdf;
        string emailEnviar = "";
        string RutaDOC = "";

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
            try
            {
                idfact = Request.QueryString.Get("idfa");
                DB.Conectar();
                DB.CrearComando(@"SELECT resultadoVal
                              FROM General
                              WHERE 
                             idFactura=@IDE");
                DB.AsignarParametroCadena("@IDE", idfact);
                DbDataReader DR = DB.EjecutarConsulta();
                if (DR.Read())
                {
                    tbFactura.Text = DR[0].ToString();

                }
                DB.Desconectar();
                // tbFactura.Text = folio + " " + serie;
            }catch(Exception y){}       
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}