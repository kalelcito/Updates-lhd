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
    public partial class Formulario_web120 : System.Web.UI.Page
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

        protected void Button38_Click(object sender, EventArgs e)
        {
            //------------------ ver panel crear moneda----------------------
            Pcrearmon.Width = 500;
            Pcrearmon.Height = 240;
            Checkcrear.Checked = true;
            Pcrearmon.Visible = true;
        }

        protected void Button31_Click(object sender, EventArgs e)
        {
            //------------------ cancelar crear moneda----------------------
            Pcrearmon.Width = 20;
            Pcrearmon.Height = 20;
            Pcrearmon.Visible = false;
        }

        protected void Button32_Click(object sender, EventArgs e)
        {
            //-------------cear moneda-------------
            BD.Conectar();
            BD.CrearComando("insert into monedas (codigoISO,nombre, activa) values (@codigoISO,@nombre,@activa)");
            BD.AsignarParametroCadena("@codigoISO",Tcodcrear.Text);
            BD.AsignarParametroCadena("@nombre",Tnomcrear.Text);
            if (Checkcrear.Checked)
            {
                BD.AsignarParametroCadena("@activa", "si");
            }
            else {
                BD.AsignarParametroCadena("@activa", "no");
            }
            BD.EjecutarConsulta();
            BD.Desconectar();

            Pcrearmon.Width = 20;
            Pcrearmon.Height = 20;
            Pcrearmon.Visible = false;
            Response.Redirect("~/menuReceDHL/monedas.aspx");
        }

        protected void Button40_Click(object sender, EventArgs e)
        {
            //------------------ver panel editar--------------
             bool si = false;
            foreach (GridViewRow row in GridView6.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                Peditarmon.Width = 480;
                Peditarmon.Height = 230;
                string dia1 = "", habi = "", hi = "", hf = "";
                foreach (GridViewRow row in GridView6.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("select codigoISO, nombre,activa from monedas where idMon=@id");
                        BD.AsignarParametroCadena("@id",idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Tconeditar.Text = DR[0].ToString();
                            Tnomeditar.Text=DR[1].ToString();
                            if (DR[2].ToString() == "si")
                            {
                                Checkeditar.Checked = true;
                            }
                        }
                        BD.Desconectar();
                        Peditarmon.Visible = true;
                    }
                }
            }
        }

        protected void Button33_Click(object sender, EventArgs e)
        {
            //-------------cancelar editar------------------
            Peditarmon.Width = 20;
            Peditarmon.Height = 20;
            idres = "";
            Pcrearmon.Visible = false;
        }

        protected void Button34_Click(object sender, EventArgs e)
        {
            //------------------editarr moneda---------------------
            BD.Conectar();
            BD.CrearComando("update monedas set codigoISO=@cod, nombre=@nom, activa=@act where idMon=@id");
            BD.AsignarParametroCadena("@cod",Tconeditar.Text);
            BD.AsignarParametroCadena("@nom", Tnomeditar.Text);
            if (Checkeditar.Checked)
            {
                BD.AsignarParametroCadena("@act", "si");
            }
            else {
                BD.AsignarParametroCadena("@act", "no");
            }
            BD.AsignarParametroCadena("@id", idres);
            BD.EjecutarConsulta();
            BD.Desconectar();
            Peditarmon.Width = 20;
            Peditarmon.Height = 20;
            idres = "";
            Peditarmon.Visible = false;
            Response.Redirect("~/menuReceDHL/monedas.aspx");

        }


    }
}