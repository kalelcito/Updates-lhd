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
    public partial class Formulario_web117 : System.Web.UI.Page
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

            if (Session["permisos"] != null)
            {
                if (!(Session["permisos"].ToString().IndexOf("AdmReceptores") < 0))
                {
                    GridView4.Visible = true;
                }
            }
        }

        protected void Button31_Click(object sender, EventArgs e)
        {
            //----------------ver panel crear receptor-------------
            Pagreceptor.Width = 500;
            Pagreceptor.Height = 320;
            Checag.Checked = true;
            Pagreceptor.Visible = true;
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            //------------cancelar agregar receptor----------------------
            Pagreceptor.Width = 20;
            Pagreceptor.Height = 20;
            Pagreceptor.Visible = false;
        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            //-------------agregar receptor--------------------
            BD.Conectar();
            BD.CrearComando(@"insert into receptorCFDI (rfc,razonSoc,OrdID,OracleID,codigoGLRet,codigoGLISRret,tipProvFlet, codigoGLIVAret, habilitado)
                values (@rfc,@razonSoc,@OrdID,@OracleID,@codigoGLRet,@codigoGLISRret,@tipProvFlet,@codigoGLIVAret,@habilitado)");
            BD.AsignarParametroCadena("@rfc",Trfcag.Text);
            BD.AsignarParametroCadena("@razonSoc", Trzag.Text);
            BD.AsignarParametroEntero("@OrdID", Convert.ToInt32(Torag.Text));
            BD.AsignarParametroEntero("@OracleID", Convert.ToInt32(Toracag.Text));
            BD.AsignarParametroCadena("@codigoGLRet",Tglag.Text);
            BD.AsignarParametroCadena("@codigoGLISRret",Tglretag.Text);
            BD.AsignarParametroCadena("@tipProvFlet", Droptipag.SelectedValue);
            BD.AsignarParametroCadena("@codigoGLIVAret",Tglretenag.Text);
            if(Checag.Checked){
                BD.AsignarParametroCadena("@habilitado", "si");
            }else{
                BD.AsignarParametroCadena("@habilitado", "no");
            }

            Pagreceptor.Width = 20;
            Pagreceptor.Height = 20;
            Pagreceptor.Visible = false;
            Response.Redirect("~/menuReceDHL/receptoresCfdi.aspx");

        }

        protected void Toacleedit_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button32_Click(object sender, EventArgs e)
        {
         //-------------------VER PANEL EDITAR ------------------------
            bool si = false;
            foreach (GridViewRow row in GridView4.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                foreach (GridViewRow row in GridView4.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("SELECT rfc,razonSoc,OrdID,OracleID,codigoGLret,codigoGLISRret,tipProvFlet,codigoGLIVAret FROM receptorCFDI where idreceptorCFDI=@idp");
                        BD.AsignarParametroCadena("@idp", idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Trfcedit.Text = DR[0].ToString();
                            Trzedit.Text = DR[1].ToString();
                            Torgedit.Text = DR[2].ToString();
                            Toacleedit.Text = DR[3].ToString();
                            Tcodgledit.Text = DR[4].ToString();
                            Tglisredit.Text = DR[5].ToString();
                            Tglretenidoedit.Text = DR[7].ToString();

                            Peditar.Width = 490;
                            Peditar.Height =300;
                            Peditar.Visible = true;
                        }
                        BD.Desconectar();
                    }
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN PROVEEDOR";
                Session["estPan"] = true;
            }
        }

        protected void Button24_Click(object sender, EventArgs e)
        {
            //----------editar receptor CFDI------------------
        
                BD.Conectar();
                BD.CrearComando(@"update receptorCFDI set rfc=@rfc,razonSoc=@razonSoc,OrdID=@OrdID,OracleID=@OracleID,codigoGLret=@codigoGLret,codigoGLISRret=@codigoGLISRret,
                              tipProvFlet=@tipProvFlet,codigoGLIVAret=@codigoGLIVAret where idreceptorCFDI=@idp");
                BD.AsignarParametroCadena("@rfc", Trfcedit.Text);
                BD.AsignarParametroCadena("@razonSoc", Trzedit.Text);
                BD.AsignarParametroEntero("@OrdID", Convert.ToInt32(Torgedit.Text));
                BD.AsignarParametroEntero("@OracleID", Convert.ToInt32(Toacleedit.Text));
                BD.AsignarParametroCadena("@codigoGLret", Tcodgledit.Text);
                BD.AsignarParametroCadena("@codigoGLISRret", Tglisredit.Text);
                BD.AsignarParametroCadena("@tipProvFlet", Droptipedit.SelectedValue);
                BD.AsignarParametroCadena("@codigoGLIVAret", Tglretenidoedit.Text);
                BD.AsignarParametroCadena("@idp", idres);
                BD.EjecutarConsulta();
                BD.Desconectar();
            
      

            Peditar.Width = 20;
            Peditar.Height = 20;
            idres = "";
            Peditar.Visible = false;
        }

        protected void Button23_Click(object sender, EventArgs e)
        {
            //-------------cancelar editar receptor cfdi-------------
            Peditar.Width = 20;
            Peditar.Height = 20;
            idres = "";
            Peditar.Visible = false;
        }
    }
}