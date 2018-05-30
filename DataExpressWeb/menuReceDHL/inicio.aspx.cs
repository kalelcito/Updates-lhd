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
    public partial class Formulario_web113 : System.Web.UI.Page
    {
        protected void Page1_Load(object sender, EventArgs e)
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
        //BasesDatos BD = new BasesDatos();
        //private DataTable DT = new DataTable();
        //string modulo = "";
        //string rfcEmisor = "";
        //static string idres = "";
        //private String separador = "|";
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        //protected void Button13_Click(object sender, EventArgs e)
        //{
        //    //--------------------visible panel editar usuario--------------------
        //    bool si = false;
        //    foreach (GridViewRow row in GridView3.Rows)
        //    {
        //        CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
        //        if (chk_Seleccionar.Checked)
        //        { si = true; }
        //    }

        //    if (si == true)
        //    {
                
        //        foreach (GridViewRow row in GridView3.Rows)
        //        {
        //            CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
        //            HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
        //            if (chk_Seleccionar.Checked)
        //            {
        //                idres = hd_Seleccionafol.Value;

        //                BD.Conectar();
        //                BD.CrearComando("select nombre,login,pass,grupo from usuarios where idUsuario=@idus");
        //                BD.AsignarParametroCadena("@idus",idres);
        //                DbDataReader RD = BD.EjecutarConsulta();
        //                if (RD.Read())
        //                {

        //                    PeditarUs.Width = 450;
        //                    PeditarUs.Height = 250;
        //                    Textnom.Text = RD[0].ToString();
        //                    Textus.Text = RD[1].ToString();
        //                    Textpass.Attributes.Add("Value", RD[2].ToString());
        //                    Textgr.Text = RD[3].ToString();
        //                    PeditarUs.Visible = true;

        //                }
        //                BD.Desconectar();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Session["estNot"] = false;
        //        Session["msjNoti"] = "DEBES SELECIONAR UN USUARIO";
        //        Session["estPan"] = true;
        //    }
        //}

        //protected void Button11_Click(object sender, EventArgs e)
        //{
        //    //----------cancelar editar usuario--------------
        //    PeditarUs.Width = 20;
        //    PeditarUs.Height = 20;
        //    PeditarUs.Visible = false;
        //    Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //------------editar usuario--------------
        //    if (TextBox27.Text != "")
        //    {
        //        BD.Conectar();
        //        BD.CrearComando("update usuarios set nombre=@nom, login=@log, pass=@ps, grupo=@gru where idUsuario=@idus");
        //        BD.AsignarParametroCadena("@nom",Textnom.Text);
        //        BD.AsignarParametroCadena("@log", Textus.Text);
        //        BD.AsignarParametroCadena("@ps", TextBox27.Text);
        //        BD.AsignarParametroCadena("@gru",Textgr.Text);
        //        BD.AsignarParametroCadena("@idus", idres);
        //        BD.EjecutarConsulta();
        //        BD.Desconectar();

        //        PeditarUs.Width = 20;
        //        PeditarUs.Height = 20;
        //        PeditarUs.Visible = false;
        //        Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");

        //    }else{
        //        Session["estNot"] = false;
        //        Session["msjNoti"] = "INGRESA NNUEVA CONTRASEÑA";
        //        Session["estPan"] = true;
        //    }
        //}

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    //------------cancelar crear usuario-------------
        //    PcrearUs.Width = 20;
        //    PcrearUs.Height = 20;
        //    PcrearUs.Visible = false;
        //    Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
        //}

        //protected void Button12_Click(object sender, EventArgs e)
        //{
        //    //----------visible panel registro------------
        //    PcrearUs.Width = 430;
        //    PcrearUs.Height = 270;
        //    ChecAct.Checked = true;
        //    PcrearUs.Visible = true;
        //}

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    //--------------------crear usuario-------------
        //    if (Tps.Text == Tconfps.Text && Tps.Text != "" && Tconfps.Text != "")
        //    {
        //        BD.Conectar();
        //        BD.CrearComando("insert into usuarios (nombre,grupo,login,proveedor,activo,pass) values (@nom,@gr,@log,@prov,@act,@ps)");
        //        BD.AsignarParametroCadena("@nom", Tnom.Text);
        //        BD.AsignarParametroCadena("@gr", Tgrup.Text);
        //        BD.AsignarParametroCadena("@log", Tus.Text);
        //        BD.AsignarParametroCadena("@prov", "");
        //        if (ChecAct.Checked)
        //        {
        //            BD.AsignarParametroCadena("@act", "si");
        //        }
        //        else
        //        {
        //            BD.AsignarParametroCadena("@act", "no");
        //        }
        //        BD.AsignarParametroCadena("@ps", Tps.Text);
        //        BD.EjecutarConsulta();
        //        BD.Desconectar();

        //        PcrearUs.Width = 20;
        //        PcrearUs.Height = 20;
        //        PcrearUs.Visible = false;
        //        Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
        //    }
        //    else
        //    {
        //        Session["estNot"] = false;
        //        Session["msjNoti"] = "CONTRASEÑA NO COINCIDE";
        //        Session["estPan"] = true;
        //    }
        //}

        //protected void Button14_Click(object sender, EventArgs e)
        //{
        //    //-----------desactivar usuario---------------
        //    bool si = false;
        //    foreach (GridViewRow row in GridView3.Rows)
        //    {
        //        CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
        //        if (chk_Seleccionar.Checked)
        //        { si = true; }
        //    }

        //    if (si == true)
        //    {

        //        foreach (GridViewRow row in GridView3.Rows)
        //        {
        //            CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
        //            HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
        //            if (chk_Seleccionar.Checked)
        //            {
        //                idres = hd_Seleccionafol.Value;

        //                BD.Conectar();
        //                BD.CrearComando("update usuarios set activo=@act where idUsuario=@us");
        //                BD.AsignarParametroCadena("@act","no");
        //                BD.AsignarParametroCadena("@us", idres);
        //                BD.EjecutarConsulta();
        //                BD.Desconectar();

        //                idres="";
        //                Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
                       
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Session["estNot"] = false;
        //        Session["msjNoti"] = "DEBES SELECIONAR UN USUARIO";
        //        Session["estPan"] = true;
        //    }
        //}

    }
}