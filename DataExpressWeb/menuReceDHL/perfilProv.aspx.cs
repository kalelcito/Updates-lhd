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
    public partial class Formulario_web124 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        private DataTable DT = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null || Session["adm"] != null)
            {
                if (Convert.ToBoolean(Session["adm"]) == false)
                {
                    if (!IsPostBack)
                    {

                        BD.Conectar();
                        BD.CrearComando("select * from Proveedores where idProveedor=@id");
                        BD.AsignarParametroCadena("@id", Session["identificador"].ToString());
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Lgrup.Text = DR[1].ToString();
                            Lraz.Text = DR[2].ToString();
                            Lprov.Text = DR[12].ToString();
                            Tnom.Text = DR[3].ToString();
                            Ttel.Text = DR[4].ToString();
                            Tcorr.Text = DR[5].ToString();
                            Tlog.Text = DR[6].ToString();
                            Tpass.Text = DR[7].ToString();
                            Tloc.Text = DR[16].ToString() + " " + DR[17].ToString() + " " + DR[18].ToString() + " " + DR[19].ToString() + " " + DR[20].ToString() + " "
                                + DR[21].ToString() + " " + DR[22].ToString() + " " + DR[23].ToString() + " " + DR[24].ToString() + " " + DR[25].ToString() + " " + DR[26].ToString();
                            Lfecha.Text = DR[30].ToString();
                        }
                        BD.Desconectar();
                    }
                }
                else
                {
                    Response.Redirect("~/menuReceDHL/inicio.aspx");
                }

            }
            else
            {
                Response.Redirect("~/Cerrar.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Documentos.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BD.Conectar();
            BD.CrearComando("update Proveedores set contacto=@cont, telefono=@tel, correo=@cor, usuario=@us, pass=@ps, fecMod=@fec where idProveedor=@id");
            BD.AsignarParametroCadena("@cont",Tnom.Text);
            BD.AsignarParametroCadena("@tel", Ttel.Text);
            BD.AsignarParametroCadena("@cor", Tcorr.Text);
            BD.AsignarParametroCadena("@us", Tlog.Text);
            BD.AsignarParametroCadena("@ps", Tpass.Text);
            BD.AsignarParametroCadena("@fec", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            BD.AsignarParametroCadena("@id", Session["identificador"].ToString());
            BD.EjecutarConsulta();
            BD.Desconectar();
            Response.Redirect("~/menuReceDHL/perfilProv.aspx");
        }
    }
}