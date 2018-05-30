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
    public partial class Formulario_web121 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        private DataTable DT = new DataTable();
        string modulo = "";
        string rfcEmisor = "";
        static string idres = "";
        private String separador = "|";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || Session["adm"] == null || Session["permisos"] == null)
            {
                Response.Redirect("~/Cerrar.aspx");
            }
            else if (Convert.ToBoolean(Session["adm"]) == false)
            {
                Response.Redirect("~/Documentos.aspx");
            }
        }

        protected void Button42_Click(object sender, EventArgs e)
        {
            //-----------------------ver panel crear tip proveedor-----------------------
            Pcrearprov.Width = 500;
            Pcrearprov.Height = 240;
            Pcrearprov.Visible = true;
        }

        protected void Button35_Click(object sender, EventArgs e)
        {
            //-----------------cancelar crear tipo proveedor-------------------------
            Pcrearprov.Width = 20;
            Pcrearprov.Height = 20;
            Pcrearprov.Visible = false;
        }

        protected void Button36_Click(object sender, EventArgs e)
        {
            //-------------- crear tipo prveedor--------------------
            BD.Conectar();
            BD.CrearComando("insert into tipoProveedor (nombre,permPropServ,activo) values (@nombre,@permPropServ,@activo)");
            BD.AsignarParametroCadena("@nombre",Tnomcrear.Text);
            if (Checcrear1.Checked)
            {
                BD.AsignarParametroCadena("@permPropServ", "si");
            }
            else {
                BD.AsignarParametroCadena("@permPropServ", "no");
            }
            if (Checcrear2.Checked)
            {
                BD.AsignarParametroCadena("@activo", "si");
            }
            else
            {
                BD.AsignarParametroCadena("@activo", "no");
            }
            BD.EjecutarConsulta();
            BD.Desconectar();

            Pcrearprov.Width = 20;
            Pcrearprov.Height = 20;
            Pcrearprov.Visible = false;
            Response.Redirect("~/menuReceDHL/tiposProveedor.aspx");

        }

        protected void Button43_Click(object sender, EventArgs e)
        {
            //------------ver panel editar tipo proveedor--------------------
             bool si = false;
            foreach (GridViewRow row in GridView7.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                PeditTipoPr.Width = 475;
                PeditTipoPr.Height = 230;
                string dia1 = "", habi = "", hi = "", hf = "";
                foreach (GridViewRow row in GridView7.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("select nombre,permPropServ,activo from tipoProveedor where idTipProv=@id");
                        BD.AsignarParametroCadena("@id", idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Teditarnom.Text = DR[0].ToString();
                            if (DR[1].ToString() == "si") {
                                Checeditar1.Checked = true;
                            }
                            if (DR[2].ToString() == "si")
                            {
                                Checeditar2.Checked = true;
                            }
                        }
                        BD.Desconectar();
                        PeditTipoPr.Visible = true;
                    }
                }
            }
        }

        protected void Button38_Click(object sender, EventArgs e)
        {
            //------------------editar tipo proveedor----------------------------
            BD.Conectar();
            BD.CrearComando("update tipoProveedor set nombre=@nom,permPropServ=@perm,activo=@act where idTipProv=@id");
            BD.AsignarParametroCadena("@nom",Teditarnom.Text);
            if (Checeditar1.Checked)
            {
                BD.AsignarParametroCadena("@perm", "si");
            }
            else
            {
                BD.AsignarParametroCadena("@perm", "no"); 
            }
            if (Checeditar2.Checked)
            {
                BD.AsignarParametroCadena("@act", "si");
            }
            else {
                BD.AsignarParametroCadena("@act", "no");
            }
            BD.AsignarParametroCadena("@id", idres);
            BD.EjecutarConsulta();
            BD.Desconectar();
            PeditTipoPr.Width = 20;
            PeditTipoPr.Height = 20;
            PeditTipoPr.Visible = false;
            idres = "";
            Response.Redirect("~/menuReceDHL/tiposProveedor.aspx");
        }

        protected void Button37_Click(object sender, EventArgs e)
        {
            PeditTipoPr.Width = 20;
            PeditTipoPr.Height = 20;
            PeditTipoPr.Visible = false;
        }
    }
}