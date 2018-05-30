using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data.Common;
using System.Data;

namespace DataExpressWeb
{
    public partial class Formulario_web125 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        private DataTable DT = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null || Session["adm"] != null || Session["permisos"] != null)
                {
                    if (Convert.ToBoolean(Session["adm"]))
                    {
                        BD.Conectar();
                        BD.CrearComando("select * from usuarios where idUsuario=@id");
                        BD.AsignarParametroCadena("@id", Session["identificador"].ToString());
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Lgrup.Text = DR[2].ToString();
                            Lprov.Text = DR[4].ToString();
                            Tnom.Text = DR[1].ToString();
                            Tlog.Text = DR[3].ToString();
                            Tpass.Text = DR[6].ToString();
                            Lfecha.Text = DR[7].ToString();
                        }
                        BD.Desconectar();
                     }
                    else
                    {
                        Response.Redirect("~/Documentos.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Cerrar.aspx");
                }
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BD.Conectar();
            BD.CrearComando("update usuarios set nombre=@cont, login=@us, pass=@ps, fecMod=@fec where idUsuario=@id");
            BD.AsignarParametroCadena("@cont", Tnom.Text);
            BD.AsignarParametroCadena("@us", Tlog.Text);
            BD.AsignarParametroCadena("@ps", Tpass.Text);
            BD.AsignarParametroCadena("@fec", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            BD.AsignarParametroCadena("@id", Session["identificador"].ToString());
            BD.EjecutarConsulta();
            BD.Desconectar();
            Response.Redirect("~/menuReceDHL/perfilEmple.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/menuReceDHL/inicio.aspx");
        }
    }
}