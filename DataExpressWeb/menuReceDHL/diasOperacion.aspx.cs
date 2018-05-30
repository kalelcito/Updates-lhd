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
    public partial class Formulario_web119 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        private DataTable DT = new DataTable();
        string modulo = "";
        string rfcEmisor = "";
        static string idres = "";
        private String separador = "|";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["usuario"] == null || Session["adm"] == null || Session["permisos"]==null)
            {
                Response.Redirect("~/Cerrar.aspx");
            }
            else if (Convert.ToBoolean(Session["adm"]) == false)
            {
                Response.Redirect("~/Documentos.aspx");
            }

            if (Session["permisos"] != null)
            {
                if (!(Session["permisos"].ToString().IndexOf("Dias") < 0))
                {
                    GridView5.Visible = true;
                }
            }
        }

        protected void Button54_Click(object sender, EventArgs e)
        {
            // -----------cancelar panel dias-------------
            Pdias.Width = 10;
            Pdias.Height = 10;
            Pdias.Visible = false;
            idres = "";
            Response.Redirect("~/menuReceDHL/diasOperacion.aspx");
        }

        protected void Button53_Click(object sender, EventArgs e)
        {
            //-------grabar dia-----------------------
            string prov = "";

            foreach (ListItem listItem in ListPr.Items)
            {
                if (listItem.Selected)
                {
                    prov += listItem.Value + "|"; 
                }
            }

            if (prov != "")
            {
                BD.Conectar();
                BD.CrearComando("update diasOperacion set habilitado=@habi, horaIni=@hi, horaFin=@fi, Proveedores=@pr where dia=@dia");
                if (Checkdia.Checked)
                {
                    BD.AsignarParametroCadena("@habi", "Si");
                }
                else { BD.AsignarParametroCadena("@habi", "No"); }
                BD.AsignarParametroCadena("@hi", Dropdia1.SelectedValue);
                BD.AsignarParametroCadena("@fi", Dropdia2.SelectedValue);
                BD.AsignarParametroCadena("@pr", prov);
                BD.AsignarParametroCadena("@dia", idres);
                BD.EjecutarConsulta();
                BD.Desconectar();

                idres = "";
                Pdias.Width = 10;
                Pdias.Height = 10;
                Pdias.Visible = false;
                Response.Redirect("~/menuReceDHL/diasOperacion.aspx");
            }
            else {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN PROVEEDOR";
                Session["estPan"] = true;
            }
        }

        protected void Button37_Click(object sender, EventArgs e)
        {
            //----------Editar dias------------------
            bool si = false;
            foreach (GridViewRow row in GridView5.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                Pdias.Width = 425;
                Pdias.Height = 260;
                string dia1 = "", habi = "", hi = "", hf = "", pr="";
                 foreach (GridViewRow row in GridView5.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres= hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("Select dia, habilitado, horaIni, horaFin, Proveedores from diasOperacion where dia=@dia");
                        BD.AsignarParametroCadena("@dia", idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            dia1 = DR[0].ToString();
                            habi = DR[1].ToString();
                            hi = DR[2].ToString();
                            hf = DR[3].ToString();
                            pr = DR[4].ToString();
                        }

                        BD.Desconectar();
                        Ldia1.Text = dia1;
                        if (habi == "Si")
                        {
                            Checkdia.Checked = true;
                        }
                        if (hi != "" && hf != "")
                        {
                            Dropdia1.SelectedValue = hi;
                            Dropdia2.SelectedValue = hf;
                        }

                        SqlDataSo.DataBind();
                        ListPr.DataBind();

                        foreach (ListItem listItem in ListPr.Items)
                        {
                            if (!(pr.IndexOf(listItem.Value)<0))
                            {
                                listItem.Selected = true;
                            }
                        }

                        Pdias.Visible = true;
                    }
                 }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN DÍA";
                Session["estPan"] = true;
            }
        }
    }
}