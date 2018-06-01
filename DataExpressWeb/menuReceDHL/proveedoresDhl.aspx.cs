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
    public partial class Formulario_web115 : System.Web.UI.Page
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
                if (!(Session["permisos"].ToString().IndexOf("AdmProveedores") < 0))
                {
                    GridView1.Visible = true;
                }
            }
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            //---------------abrie panel editar----------------------
            bool si = false;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }
           
            if (si == true)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        string pr = "";
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("select rfc,razonSocial,correo,vendorID,vendorSite,tipoProveedor,pass,usuario, formaPago from Proveedores where idProveedor=@idp");
                        BD.AsignarParametroCadena("@idp", idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Trfc.Text = DR[0].ToString();
                            Trs.Text = DR[1].ToString();
                            Tcorr.Text = DR[2].ToString();
                            Tnoti.Text = DR[2].ToString();
                            Tven.Text = DR[3].ToString();
                            Tsite.Text = DR[4].ToString();
                            pr = DR[5].ToString();
                            TexPass.Text = DR[6].ToString();
                            Tusa.Text = DR[7].ToString();
                            this.TbFP.Text = DR[8].ToString();
                        }
                        BD.Desconectar();
                        SqlDatapr.DataBind();
                        Droptip.DataBind();
                        if (pr != "")
                        {
                           Droptip.SelectedValue = pr;
                        }

                        Peditar.Width = 423;
                        Peditar.Height = 380;
                        Peditar.Visible = true;
                    }
                }
            }
            else {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN PROVEEDOR";
                Session["estPan"] = true;
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            //--------------------cancelar editar proveedor-------------------
            Peditar.Width = 20;
            Peditar.Height = 20;
            Peditar.Visible = false;
            idres = "";
            Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            var x = AgregarLista.SelectedValue;

            BD.Conectar();
            BD.CrearComando("select * from tipoProveedor where nombre=@x");
            BD.AsignarParametroCadena("@x", x);
            DbDataReader DR = BD.EjecutarConsulta();
            if (DR.Read())
            {
                var id = DR[0].ToString();
                DR.Close();
                bool ban = false;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    idres = hd_Seleccionafol.Value;
                    BD.CrearComando("select * from TiposProveedor where idProv=@idp and idTipo=@x");
                    BD.AsignarParametroCadena("@idp", idres);
                    BD.AsignarParametroCadena("@x", id);
                    DbDataReader query = BD.EjecutarConsulta();
                    int rowCount = 0;
                    while (query.Read())
                    {
                        rowCount++;
                    }
                    if (rowCount>0)
                    {
                        ban = false;
                    }
                    else
                    {
                        ban = true;
                    }
                    query.Close();
                }
                if (ban == true)
                {
                    BD.CrearComando("insert into TiposProveedor (idProv,idTipo) values (@idp,@x)");
                    BD.AsignarParametroCadena("@idp", idres);
                    BD.AsignarParametroCadena("@x", id);
                    DbDataReader query = BD.EjecutarConsulta();
                }
                else
                {
                    prueba.Text = "Ya existe";
                }
            }
            BD.Desconectar();
            prueba.Visible = true;
        }

        protected void CerrarLista_Click(object sender, EventArgs e)
        {
            lista.Visible = false;
            Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
        }

        protected void AddTipo_Click(object sender, EventArgs e)
        {
            bool si = false;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        string pr = "";
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("select * from TiposProveedor where idProv=@idp");
                        BD.AsignarParametroCadena("@idp", idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            //prueba.Text = DR[2].ToString();
                        }
                        BD.Desconectar();
                        SqlDatapr.DataBind();

                        Peditar.Visible = false;
                        lista.Width = 400;
                        lista.Height = 300;
                        lista.Visible = true;
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

        protected void Button8_Click(object sender, EventArgs e)
        {
            //----------------editar proveedor----------
            string menSeg = seguridad();
            if (menSeg == "")
            {
                BD.Conectar();
                BD.CrearComando("update Proveedores set rfc=@rfc, razonSocial=@rs, correo=@corr, correonoti=@noti, vendorID=@ven, vendorSite=@site,tipoProveedor=@tip, pass=@ps, usuario=@usu, formaPago=@formaP where idProveedor=@idp ");
                BD.AsignarParametroCadena("@rfc", Trfc.Text);
                BD.AsignarParametroCadena("@rs", Trs.Text);
                BD.AsignarParametroCadena("@corr", Tcorr.Text);
                BD.AsignarParametroCadena("@noti", Tnoti.Text);
                BD.AsignarParametroCadena("@ven", Tven.Text);
                BD.AsignarParametroCadena("@site", Tsite.Text);
                BD.AsignarParametroCadena("@tip", Droptip.SelectedValue);
                BD.AsignarParametroCadena("@ps", TexPass.Text);
                BD.AsignarParametroCadena("@usu", Tusa.Text);
                BD.AsignarParametroCadena("@formaP", this.TbFP.Text);
                BD.AsignarParametroCadena("@idp", idres);
                BD.EjecutarConsulta();
                BD.Desconectar();
                Peditar.Width = 20;
                Peditar.Height = 20;
                Peditar.Visible = false;
                idres = "";
                Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
            }
            else {
                Session["estNot"] = false;
                Session["msjNoti"] = menSeg;
                Session["estPan"] = true;
            }
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            //-----------------panel inhabilitar-------------------
            bool si = false;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("select rfc,razonSocial from Proveedores where idProveedor=@idp");
                        BD.AsignarParametroCadena("@idp", idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Trfcin.Text = DR[0].ToString();
                            Trzin.Text = DR[1].ToString();
           
                            Pina.Width = 445;
                            Pina.Height = 245;
                            Pina.Visible = true;
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

        protected void Button13_Click(object sender, EventArgs e)
        {
            //--------------------cancelar inhabilitar proveedor-------------------
            Pina.Width = 20;
            Pina.Height = 20;
            Pina.Visible = false;
            idres = "";
            Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            //-----------------inhablitar proveedor----------------
            BD.Conectar();
            BD.CrearComando("update Proveedores set habilitado=@hab, causaHabilitar=@cau where idProveedor=@idp ");
            BD.AsignarParametroCadena("@hab", "no");
            BD.AsignarParametroCadena("@cau", Tcausain.Text);
            BD.AsignarParametroCadena("@idp", idres);
            BD.EjecutarConsulta();
            BD.Desconectar();
            Pina.Width = 20;
            Pina.Height = 20;
            Pina.Visible = false;
            idres = "";
            Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            //-----------------panel habilitar-------------------
            bool si = false;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("select rfc,razonSocial from Proveedores where idProveedor=@idp");
                        BD.AsignarParametroCadena("@idp", idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Trfchabi.Text = DR[0].ToString();
                            Trzhabi.Text = DR[1].ToString();

                            Phabi.Width = 435;
                            Phabi.Height = 245;
                            Phabi.Visible = true;
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

        protected void Button15_Click(object sender, EventArgs e)
        {
            //--------------------cancelar habilitar proveedor-------------------
            Phabi.Width = 20;
            Phabi.Height = 20;
            Phabi.Visible = false;
            idres = "";
            Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");

        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            //---------------------rehabilitar proveedor-----------------------
            BD.Conectar();
            BD.CrearComando("update Proveedores set habilitado=@hab, causaHabilitar=@cau where idProveedor=@idp ");
            BD.AsignarParametroCadena("@hab", "si");
            BD.AsignarParametroCadena("@cau", Tcauhabi.Text);
            BD.AsignarParametroCadena("@idp", idres);
            BD.EjecutarConsulta();
            BD.Desconectar();
            Phabi.Width = 20;
            Phabi.Height = 20;
            Phabi.Visible = false;
            idres = "";
            Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["adSub"] = "Admin";
            Response.Redirect("~/agregarProveedor.aspx");
        }

        protected void Button252_Click(object sender, EventArgs e)
        {
            string consulta = "";

            if (TrfcBus.Text != "")
            {
                if (consulta.IndexOf("WHERE") < 0)
                {
                    consulta += "WHERE [rfc] like '%" + TrfcBus.Text + "%'";
                }
                else {
                    consulta += " AND [rfc] like '%" + TrfcBus.Text + "%'";
                }
            }

            if (TtipBus.Text != "")
            {
                if (consulta.IndexOf("WHERE") < 0)
                {
                    consulta += "WHERE [tipoProveedor] like '%" + TtipBus.Text + "%'";
                }
                else
                {
                    consulta += " AND [tipoProveedor] like '%" + TtipBus.Text + "%'";
                }
            }

            if (!(consulta.IndexOf("WHERE") < 0))
            {
                SqlDataSource3.SelectCommand = @"SELECT [rfc], [idProveedor], [razonSocial], [contacto], [telefono], [correo],[habilitado], [vendorID],
               [vendorSite], [tipoProveedor], [privacidad], [fechaAceptacion], [causaHabilitar], [calle], [noExt], [noInt],
               [colonia], [localidad], [referencia], [municipio], [estado], [pais], [codPostal], [causaRechazo] FROM [Proveedores] " + consulta + " AND [status]='aprobado' order by [idProveedor] asc";
                //GridView1.DataSource = SqlDataSource3;
                GridView1.DataBind();
            }

            PanFiltProv.Width = 20;
            PanFiltProv.Height = 20;
            PanFiltProv.Visible = false;
        }

        protected void LinkButton253_Click(object sender, EventArgs e)
        {
            PanFiltProv.Width = 415;
            PanFiltProv.Height = 160;
            PanFiltProv.Visible = true;
        }

        protected void Button151_Click(object sender, EventArgs e)
        {
            PanFiltProv.Width = 20;
            PanFiltProv.Height = 20;
            PanFiltProv.Visible = false;
            Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
        }

        protected void LinkButton293_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
        }

        protected string seguridad()
        {
            bool num = false, min = false, may = false, sim = false;
            if (TexPass.Text.Length >= 8)
            {
                foreach (var c in TexPass.Text)
                {
                    if (c >= '0' && c <= '9')
                    {
                        num = true;
                    }
                    if (c >= 'a' && c <= 'z')
                    {
                        min = true;
                    }
                    if (c >= 'A' && c <= 'Z')
                    {
                        may = true;
                    }
                    if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                    {
                        sim = true;
                    }
                }

                if (num && min && may && sim)
                {
                    return "";
                }
                else
                {
                    return "Formato de contraseña incorrecto <br/> (debe de contener mayúsculas, minúsculas, números y caracteres especiales)";
                }
            }
            else
            {
                return "El tamaño de la contraseña no puede ser menor a 8 caracteres";
            }
        }

    }
}