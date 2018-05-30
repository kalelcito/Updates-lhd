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
    public partial class Formulario_web118 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        private DataTable DT = new DataTable();
        string modulo = "";
        string rfcEmisor = "";
        static string idres = "";
        private String separador = "|";

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["permisos"] != null)
            //{
            //    revisarPer();
            //}

            if (Session["usuario"] == null || Session["adm"] == null || Session["permisos"] == null)
            {
                Response.Redirect("~/Cerrar.aspx");
            }
            else if (Convert.ToBoolean(Session["adm"]) == false)
            {
                Response.Redirect("~/Documentos.aspx");
            }
        }

        protected void Button33_Click(object sender, EventArgs e)
        {
            //------------ver panel crear IVA-------------------
            PcrearIVA.Width = 500;
            PcrearIVA.Height = 240;
            PcrearIVA.Visible = true;
        }

        protected void Button25_Click(object sender, EventArgs e)
        {
            //------------cancelar crear IVA-------------
            PcrearIVA.Width = 20;
            PcrearIVA.Height = 20;
            PcrearIVA.Visible = false;
        }

        protected void Button26_Click(object sender, EventArgs e)
        {
            //-----------------crear iva-------------------
            string res = rfcRecep();
            string idR = "";
           bool banIv= false;
           BD.Conectar();
           BD.CrearComando("select idreceptorCFDI from receptorCFDI where rfc=@rfc and razonSoc=@rz");
            BD.AsignarParametroCadena("@rfc",res);
            BD.AsignarParametroCadena("@rz", DroprecepCre.SelectedValue);
           DbDataReader DR = BD.EjecutarConsulta();
           if (DR.Read()) {
               banIv = true;
               idR= DR[0].ToString();
           }
           BD.Desconectar();

           if (banIv)
           {
               BD.Conectar();
               BD.CrearComando("insert into codigosIVA (rfc,RazonSoc,impuesto,tasa,codigo,codigoGL, idRec) values (@rfc,@RazonSoc,@impuesto,@tasa,@codigo,@codigoGL,@idRec)");
               BD.AsignarParametroCadena("@rfc", res);
               BD.AsignarParametroCadena("@RazonSoc", DroprecepCre.SelectedValue);
               BD.AsignarParametroCadena("@impuesto", TcreIva.Text);
               BD.AsignarParametroEntero("@tasa", Convert.ToInt32(TtasaCre.Text));
               BD.AsignarParametroCadena("@codigo", TcodCre.Text);
               BD.AsignarParametroCadena("@codigoGL", TglCre.Text);
               BD.AsignarParametroCadena("@idRec",idR);
               BD.EjecutarConsulta();
               BD.Desconectar();
               PcrearIVA.Width = 20;
               PcrearIVA.Height = 20;
               PcrearIVA.Visible = false;
               Response.Redirect("~/menuReceDHL/codigosIVA.aspx");
           }
           else
           {
               Session["estNot"] = false;
               Session["msjNoti"] = "EL RECEPTOR NO EXISTE";
               Session["estPan"] = true;
           }
           
        }

         protected string rfcRecep(){

             string rf="";
             BD.Conectar();
             BD.CrearComando("select rfc from receptorCFDI where razonSoc=@rz");
             BD.AsignarParametroCadena("@rz",DroprecepCre.SelectedValue);
             DbDataReader DR = BD.EjecutarConsulta();
             if (DR.Read())
             {
                 rf = DR[0].ToString();
             }
             BD.Desconectar();
              return rf;
          }

         protected void Button35_Click(object sender, EventArgs e)
         {
             // ------------ver panel editar IVA---------------------------
             bool si = false;
            foreach (GridViewRow row in GridView2.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                PeditIva.Width = 475;
                PeditIva.Height = 230;
                string dia1 = "", habi = "", hi = "", hf = "",ti="";
                foreach (GridViewRow row in GridView2.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("select rfc, RazonSoc, impuesto,tasa, codigo,codigoGl from codigosIVA where idIva=@id");
                        BD.AsignarParametroCadena("@id", idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            hi = DR[1].ToString();
                            TeditIv.Text = DR[2].ToString();
                            Ttasaedi.Text = DR[3].ToString();
                            Tcodedi.Text = DR[4].ToString();
                            Tgledi.Text = DR[5].ToString();
                        }
                        BD.Desconectar();
                        SqlDataSouedit.DataBind();
                        Dropedi.DataBind();

                        //if (ti == "RET") {
                        //    Ttasaedi.Enabled = false;
                        //}
                        //editip.SelectedValue = ti;
                        if (hi != "")
                        {
                            Dropedi.SelectedValue = hi;
                        }
                        PeditIva.Visible = true;
                    }
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN CÓDIGO";
                Session["estPan"] = true;
            }
         }

         protected void Button28_Click(object sender, EventArgs e)
         {
             //-----------------------editar Iva--------------------
             BD.Conectar();
             BD.CrearComando("update codigosIVA set RazonSoc=@rz,tasa=@tz, codigo=@cod,codigoGl=@gl where idIva=@id");
             BD.AsignarParametroCadena("@rz", Dropedi.SelectedValue);
             BD.AsignarParametroEntero("@tz", Convert.ToInt32(Ttasaedi.Text));
             BD.AsignarParametroCadena("@cod", Tcodedi.Text);
             BD.AsignarParametroCadena("@gl", Tgledi.Text);
             BD.AsignarParametroCadena("@id", idres);
             BD.EjecutarConsulta();
             BD.Desconectar();

             idres = "";
             PeditIva.Width = 20;
             PeditIva.Height = 20;
             PeditIva.Visible = false;
             Response.Redirect("~/menuReceDHL/codigosIVA.aspx");
         }

         protected void Button27_Click(object sender, EventArgs e)
         {
             //---------------cancelar editar iva-----------------------
             PeditIva.Width = 20;
             PeditIva.Height = 20;
             PeditIva.Visible = false;
         }

         //protected void DrTipIva_SelectedIndexChanged(object sender, EventArgs e)
         //{
         //    if (DrTipIva.SelectedValue == "RET")
         //    {
         //        TtasaCre.Text = "0";
         //        TtasaCre.Enabled = false;
         //    }
         //    else {
         //        TtasaCre.Text = "";
         //        TtasaCre.Enabled = true;
         //    }
         //}

         //protected void editip_SelectedIndexChanged(object sender, EventArgs e)
         //{
         //    if (editip.SelectedValue == "RET")
         //    {
         //        Ttasaedi.Enabled = false;
         //    }
         //    else {
         //        Ttasaedi.Enabled = true;
         //    }

         //}

         //protected void revisarPer()
         //{
         //    if (!(Session["permisos"].ToString().IndexOf("AdmUsuarios") < 0))
         //    {
         //        HyperLink5.Visible = true;
         //    }
         //    if (!(Session["permisos"].ToString().IndexOf("AdmProveedores") < 0))
         //    {
         //        HyperLink1.Visible = true;
         //    }
         //    if (!(Session["permisos"].ToString().IndexOf("AdmReceptores") < 0))
         //    {
         //        HyperLink13.Visible = true;
         //    }
         //    if (!(Session["permisos"].ToString().IndexOf("AdmConfiguracion") < 0))
         //    {
         //        HyperLink4.Visible = true;
         //    }
         //    if (!(Session["permisos"].ToString().IndexOf("AdmMensajes") < 0))
         //    {
         //        HyperLink6.Visible = true;
         //    }
         //    if (!(Session["permisos"].ToString().IndexOf("Reportes") < 0))
         //    {
         //        HyperLink2.Visible = true;
         //    }
         //    if (!(Session["permisos"].ToString().IndexOf("NuevoIVA") < 0))
         //    {
         //        LinkButton2.Visible = true;
         //    }
         //    if (!(Session["permisos"].ToString().IndexOf("EditarIVA") < 0))
         //    {
         //        LinkButton3.Visible = true;
         //    }

         //}
    }
}