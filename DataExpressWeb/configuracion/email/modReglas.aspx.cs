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
    public partial class modReglas : System.Web.UI.Page
    {
        string idRegla;
        BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            idRegla = Request.QueryString.Get("regladi");
            if (!Page.IsPostBack)
            {
                
                DB.Conectar();
                DB.CrearComando("select nombreRegla,estadoRegla,emailsRegla,rfc from EmailsReglas where  idEmailRegla=@idRegla");
                DB.AsignarParametroCadena("@idRegla", idRegla);
                DbDataReader DR = DB.EjecutarConsulta();

                while (DR.Read())
                {
                    tbNombre.Text = DR[0].ToString();
                    tbEmail.Text = DR[2].ToString();
                    tbRFC.Text = DR[3].ToString();
                    ddlEstado.SelectedValue = DR[1].ToString();
                }
                DB.Desconectar();
                
            }
        }

        protected void bActualizar_Click(object sender, EventArgs e)
        {
                        string a="";
            DB.Conectar();
            DB.CrearComando("select IDEEMI from Emisor where RFCEMI=@RFC");
            DB.AsignarParametroCadena("@RFC", tbRFC.Text);
            DbDataReader DR = DB.EjecutarConsulta();

            while (DR.Read())
            {
                a = DR[0].ToString();
            }
            DB.Desconectar();

            if (!String.IsNullOrEmpty(a))
            {

                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_modifica_ReglasEmail");
                DB.AsignarParametroProcedimiento("@idRegla", System.Data.DbType.Int32, Convert.ToInt32(idRegla));
                DB.AsignarParametroProcedimiento("@nombreRegla", System.Data.DbType.String, tbNombre.Text);
                DB.AsignarParametroProcedimiento("@estado", System.Data.DbType.Byte, ddlEstado.SelectedValue);
                DB.AsignarParametroProcedimiento("@emailsRegla", System.Data.DbType.String, tbEmail.Text);
                DB.AsignarParametroProcedimiento("@rfcrec", System.Data.DbType.String, tbRFC.Text);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                Response.Redirect("reglas.aspx");
            }
            else {
                lMensaje.Text = "El RFC proporcionado no Existe";

            }
        }
    }
}