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
        BasesDatos BD = new BasesDatos();
        private DataTable DT = new DataTable();
        string modulo = "";
        string rfcEmisor = "";
        static string idres = "";
        static string empres = "";
        private String separador = "|";
        string ObtSesion = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || Session["adm"] == null || Session["permisos"] == null || Session["grupo"] == null)
            {
                Response.Redirect("~/Cerrar.aspx");
            }
            else if (Convert.ToBoolean(Session["adm"]) == false)
            {
                Response.Redirect("~/Documentos.aspx");
            }

            if (Session["permisos"] != null)
            {
                if (!(Session["permisos"].ToString().IndexOf("AdmUsuarios") < 0) &&
                    (!(Session["permisos"].ToString().IndexOf("NuevoUs") < 0) ||
                    !(Session["permisos"].ToString().IndexOf("EditarUs") < 0) ||
                    !(Session["permisos"].ToString().IndexOf("DesactivarUs") < 0)))
                {
                    string error = "";
                    try
                    {
                        GridView35.Visible = true;
                        ObtSesion = Session["nivelRol"].ToString();////obtner sesion
                        ObtsesionID.Text = ObtSesion;
                        ObtsesionIDe.Text = ObtSesion;
                    }
                    catch (Exception t) {
                        error = t.ToString();
                    }
                }
            }
        
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            //--------------------visible panel editar usuario--------------------
            bool si = false;
            var rol = "";
            foreach (GridViewRow row in GridView35.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {

                foreach (GridViewRow row in GridView35.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        /////////////////////////////////////////77revisa si usuario es mayor
                        try
                        {
                            BD.Conectar();
                            BD.CrearComando("select grupo, nivel from usuarios where idUsuario=@idus");
                            BD.AsignarParametroCadena("@idus", idres);
                            DbDataReader RD1 = BD.EjecutarConsulta();
                            if (RD1.Read())
                            {
                                rol = RD1[1].ToString();
                            }
                            BD.Desconectar();
                            if (Convert.ToUInt32(ObtSesion) <= Convert.ToUInt32(rol))
                            {
                                /////////////////////////////////////////////////7
                                BD.Conectar();
                                BD.CrearComando("select nombre,login,pass, grupo,empresas from usuarios where idUsuario=@idus");
                                BD.AsignarParametroCadena("@idus", idres);
                                DbDataReader RD = BD.EjecutarConsulta();
                                if (RD.Read())
                                {
                                    //string pr = RD[3].ToString();
                                    PeditarUs.Width = 450;
                                    PeditarUs.Height = 380;
                                    Textnom.Text = RD[0].ToString();
                                    Textus.Text = RD[1].ToString();
                                    Textpass.Attributes.Add("Value", RD[2].ToString());
                                    Textgr.SelectedValue = RD[3].ToString();
                                    empres = RD[4].ToString();


                                    PeditarUs.Visible = true;

                                }
                                BD.Desconectar();
                            }
                            else {
                                Session["estNot"] = false;
                                Session["msjNoti"] = "NO PUEDES EDITAR ESTE USUARIO ES DE MAYOR NIVEL";
                                Session["estPan"] = true;
                                chk_Seleccionar.Checked = false;
                            }
                        }
                        catch (Exception t)
                        {                        }
                        
                    }
                    }
                
                }
            else
            {
                    Session["estNot"] = false;
                    Session["msjNoti"] = "DEBES SELECIONAR UN USUARIO";
                    Session["estPan"] = true;
                }
            
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            //----------cancelar editar usuario--------------
            PeditarUs.Width = 20;
            PeditarUs.Height = 20;
            PeditarUs.Visible = false;
            Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
        }

        protected void Button20_Click(object sender, EventArgs e)  
        {
            //----------cerrar editar usuario--------------
            PeditarUs.Width = 20;
            PeditarUs.Height = 20;
            PeditarUs.Visible = false;
            Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
        }

        protected string seguridad2()
        {
            bool num = false, min = false, may = false, sim = false;
            if (TextBox27.Text.Length >= 8)
            {
                foreach (var c in TextBox27.Text)
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            //------------editar usuario--------------
            if (TextBox27.Text != "")
            {
                string menSeg = seguridad2();
                if (menSeg == "")
                {
                    String empr = "";

                    foreach (ListItem item in ListEditar.Items)
                    {
                        if (item.Selected)
                        {
                            empr += "|" + item.Value;
                        }
                    }
                    if (empr != "")
                    {
                        //if ((Textgr.SelectedValue == "Administrador" && Session["grupo"].ToString() == "Administrador")
                        //    || (Textgr.SelectedValue != "Administrador" && Session["grupo"].ToString() != "Administrador")
                        //    || (Textgr.SelectedValue != "Administrador" && Session["grupo"].ToString() == "Administrador")
                        //    || (Textgr.SelectedValue.Contains("Administrador") && Session["grupo"].ToString().Contains("Administrador"))
                        //    || (Textgr.SelectedValue.Contains("Super Usuario A") && Session["grupo"].ToString().Contains("Super Usuario A")))
                        //{
                        if ((Session["permisos"].ToString().Contains("AdmUsuarios") ||
                           (Session["permisos"].ToString().Contains("EditarUS")) ||
                           (Session["permisos"].ToString().Contains("DesactivarUs"))))
                        {
                            var nRol = "";
                            BD.Conectar();
                            BD.CrearComando(@"SELECT nivelRol FROM grupos WHERE nivelRol = @nR;");
                            BD.AsignarParametroCadena("@nR", Session["nivelRol"].ToString());
                            var dr = BD.EjecutarConsulta();
                            if (dr.HasRows && dr.Read())
                            {
                                nRol = dr["nivelRol"].ToString();
                            }
                            BD.Desconectar();
                            if (Convert.ToInt32(Session["nivelRol"].ToString()) <= Convert.ToInt32(nRol))
                            {

                                BD.Conectar();
                                BD.CrearComando("update usuarios set nombre=@nom, login=@log, pass=@ps, grupo=@gru, empresas=@emp where idUsuario=@idus");
                                BD.AsignarParametroCadena("@nom", Textnom.Text);
                                BD.AsignarParametroCadena("@log", Textus.Text);
                                BD.AsignarParametroCadena("@ps", TextBox27.Text);
                                BD.AsignarParametroCadena("@gru", Textgr.SelectedValue);
                                BD.AsignarParametroCadena("@emp", empr);
                                BD.AsignarParametroCadena("@idus", idres);
                               
                                BD.EjecutarConsulta();
                                BD.Desconectar();

                                //            PeditarUs.Width = 20;
                                //            PeditarUs.Height = 20;
                                //            PeditarUs.Visible = true;
                                Session["estNot"] = true;
                                
                                Session["msjNoti"] = "USUARIO MODIFICADO CORRECTAMENTE";
                                Session["estPan"] = true;
                                //          Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
                            }
                            else {
                                Session["estNot"] = false;
                                Session["msjNoti"] = "NO PUEDE MODIFICAR UN USUARIO QUE TIENE UN NIVEL MAYOR AL DE USTED";
                                Session["estPan"] = true;
                            }
                        }
                        else
                        {
                            Session["estNot"] = false;
                            Session["msjNoti"] = "SOLO UN ADMINISTRADOR PUEDE ASIGNAR PERMISOS DE ADMINISTRADOR";
                            Session["estPan"] = true;
                        }
                    }
                    else
                    {
                        Session["estNot"] = false;
                        Session["msjNoti"] = "DEBES SELECIONAR AL MENOS UNA EMPRESA";
                        Session["estPan"] = true;
                    }
                }
                else{
                Session["estNot"] = false;
                Session["msjNoti"] = menSeg;
                Session["estPan"] = true;
            }

            }else{
                Session["estNot"] = false;
                Session["msjNoti"] = "INGRESA NUEVA CONTRASEÑA";
                Session["estPan"] = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //------------cancelar crear usuario-------------
            PcrearUs.Width = 20;
            PcrearUs.Height = 20;
            PcrearUs.Visible = false;
            Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
        }

        


        protected void Button12_Click(object sender, EventArgs e)
        {
            //----------visible panel registro------------
            PcrearUs.Width = 430;
            PcrearUs.Height = 410;
            ChecAct.Checked = true;
            PcrearUs.Visible = true;
        }

        protected string seguridad()
        {
            bool num = false, min = false, may= false, sim = false;
            if (Tps.Text.Length >= 8 && Tconfps.Text.Length >= 8)
            {
                foreach (var c in Tconfps.Text)
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



        protected void Button4_Click(object sender, EventArgs e)
        {
            //--------------------crear usuario-------------
            if (Tps.Text == Tconfps.Text)
            {
                if (Tps.Text != "" && Tconfps.Text != "")
                {
                    string menSeg = seguridad();
                    if (menSeg == "")
                    {
                        String empr = "";

                        foreach (ListItem item in ListCrear.Items)
                        {
                            if (item.Selected)
                            {
                                empr += "|" + item.Value;
                            }
                        }
 
                        if (empr != "")
                        {

                            if ((Session["permisos"].ToString().Contains("NuevoUS|") ||
                                    (Session["permisos"].ToString().Contains("AdmUsuarios"))||
                                    (Session["permisos"].ToString().Contains("DesactivarUs"))))
                            {
                               
                                    ////////////////////////validar si uasuario no existe/////////77
                                    var nombre = "";
                                var login = "";
                                BD.Conectar();
                                BD.CrearComando(@"SELECT nombre, login FROM usuarios WHERE login = @log;");
                                BD.AsignarParametroCadena("@log", Tus.Text);
                                var dr = BD.EjecutarConsulta();
                                if (dr.HasRows && dr.Read())
                                {
                                    nombre = dr["nombre"].ToString();
                                    login = dr["login"].ToString();
                                    BD.Desconectar();
                                }
                                BD.Desconectar();
                                if (login == Tus.Text)
                                {
                                    Session["estNot"] = false;
                                    Session["msjNoti"] = "EL USURAIO YA EXISTE, POR FAVOR REVISE SU INFORMACIÓN";
                                    Session["estPan"] = true;
                                }
                                else {
                                    ////////////////////////////////jala nivel
                                    var nivR = "";
                                    BD.Conectar();
                                    BD.CrearComando(@"SELECT grupo, nivelRol FROM grupos WHERE grupo = @grupo;");
                                    BD.AsignarParametroCadena("@grupo", Tgrup.SelectedValue);
                                    var dr9 = BD.EjecutarConsulta();
                                    if (dr9.HasRows && dr9.Read())
                                    {
                                        nivR = dr9["nivelRol"].ToString();
                                        BD.Desconectar();
                                    }
                                    BD.Desconectar();
                                    ////////////////////////////
                                    BD.Conectar();
                                    BD.CrearComando("insert into usuarios (nombre,grupo,login,proveedor,activo,pass,empresas,fecMod,nivel) values (@nom,@gr,@log,@prov,@act,@ps,@emp,@fc,@niv)");
                                    BD.AsignarParametroCadena("@nom", Tnom.Text);
                                    BD.AsignarParametroCadena("@gr", Tgrup.SelectedValue);
                                    BD.AsignarParametroCadena("@log", Tus.Text);
                                    BD.AsignarParametroCadena("@prov", "");
                                    if (ChecAct.Checked)
                                    {
                                        BD.AsignarParametroCadena("@act", "si");
                                    }
                                    else
                                    {
                                        BD.AsignarParametroCadena("@act", "no");
                                    }
                                    BD.AsignarParametroCadena("@ps", Tps.Text);
                                    BD.AsignarParametroCadena("@emp", empr);
                                    BD.AsignarParametroCadena("@fc", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                                    BD.AsignarParametroCadena("@niv", nivR);
                                    BD.EjecutarConsulta();
                                    BD.Desconectar();

                                    PcrearUs.Width = 20;
                                    PcrearUs.Height = 20;
                                    PcrearUs.Visible = false;
                                    Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
                                }/////////////validar
                            }
                            else
                            {
                                Session["estNot"] = false;
                                Session["msjNoti"] = "SOLO UN ADMINISTRADOR PUEDE CREAR USUARIOS ADMINISTRADORES";
                                Session["estPan"] = true;
                            }
                        }
                        else
                        {
                            Session["estNot"] = false;
                            Session["msjNoti"] = "DEBES SELECIONAR AL MENOS UNA EMPRESA";
                            Session["estPan"] = true;
                        }
                    }
                    else
                    {
                        Session["estNot"] = false;
                        Session["msjNoti"] = menSeg;
                        Session["estPan"] = true;
                    }
                }
                else
                {
                    Session["estNot"] = false;
                    Session["msjNoti"] = "EXISTEN CAMPOS VACIOS";
                    Session["estPan"] = true;
                }
               
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "CONTRASEÑA NO COINCIDE";
                Session["estPan"] = true;
            }
        }

        protected void Button14_Click(object sender, EventArgs e)
        {

            //-----------desactivar usuario---------------
            bool si = false;
            foreach (GridViewRow row in GridView35.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {

                foreach (GridViewRow row in GridView35.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    ///////////////////////////////////////////revisa permisos
                    if ((Session["permisos"].ToString().Contains("NuevoUS|") ||
                                    (Session["permisos"].ToString().Contains("AdmUsuarios")) ||
                                    (Session["permisos"].ToString().Contains("DesactivarUs"))))
                    {
                        
                            /////////////////////////

                            if (chk_Seleccionar.Checked)
                            {
                                idres = hd_Seleccionafol.Value;
                            //////////////////////////////
                            var nRol = "";
                            BD.Conectar();
                            BD.CrearComando(@"SELECT idUsuario, nivel FROM usuarios WHERE IdUsuario = @nR;");
                            BD.AsignarParametroCadena("@nR",idres );
                            var dr = BD.EjecutarConsulta();
                            if (dr.HasRows && dr.Read())
                            {
                                nRol = dr["nivel"].ToString();
                            }
                            BD.Desconectar();
                            if (Convert.ToInt32(Session["nivelRol"].ToString()) <= Convert.ToInt32(nRol))
                            {
                                ////////////////////////////////activar/desactivar
                                var acti = "";
                                BD.Conectar();
                                BD.CrearComando(@"SELECT idUsuario, activo FROM usuarios WHERE IdUsuario = @nR;");
                                BD.AsignarParametroCadena("@nR", idres);
                                var dr1 = BD.EjecutarConsulta();
                                if (dr1.HasRows && dr1.Read())
                                {
                                    acti = dr1["activo"].ToString();
                                }
                                BD.Desconectar();
                                if (acti == "si")
                                {
                                    /////////////////////////////
                                    BD.Conectar();
                                    BD.CrearComando("update usuarios set activo=@act where idUsuario=@us");
                                    BD.AsignarParametroCadena("@act", "no");
                                    BD.AsignarParametroCadena("@us", idres);
                                    BD.EjecutarConsulta();
                                    BD.Desconectar();

                                    
                                    Session["estNot"] = true;
                                    Session["msjNoti"] = "USUARIO DESACTIVADO CORRECTAMENTE";
                                    Session["estPan"] = true;
                               //     chk_Seleccionar.Checked = false;
                                    idres = "";
                                     Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
                                }
                                else {
                                    BD.Conectar();
                                    BD.CrearComando("update usuarios set activo=@act where idUsuario=@us");
                                    BD.AsignarParametroCadena("@act", "si");
                                    BD.AsignarParametroCadena("@us", idres);
                                    BD.EjecutarConsulta();
                                    BD.Desconectar();

                                    
                                    Session["estNot"] = true;
                                    Session["msjNoti"] = "USUARIO ACTIVADO CORRECTAMENTE";
                                    Session["estPan"] = true;
                               //     chk_Seleccionar.Checked = false;
                                    idres = "";
                                    Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
                                }

                            }
                        }
                        else
                        {
                            Session["estNot"] = false;
                            Session["msjNoti"] = "NO PUEDES DESACTIVAR A UN USUARIO CON MAYOR NIVEL QUE TÚ";
                            Session["estPan"] = true;
                            //chk_Seleccionar.Checked = false;
                        }
                        }
                        else
                        {
                            Session["estNot"] = false;
                            Session["msjNoti"] = "NO TINES PERMISOS SUFICIENTES PARA DESACTIVAR ESTE USUARIO";
                            Session["estPan"] = true;
                        }
                    chk_Seleccionar.Checked = false;
                }
                
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN USUARIO";
                Session["estPan"] = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in ListEditar.Items)
            {

                if (!(empres.IndexOf(item.Value) < 0))
                {
                    item.Selected = true;
                }

            }
        }

        protected void Button121_Click(object sender, EventArgs e)
        {
            PanFiltUs.Width = 20;
            PanFiltUs.Height = 20;
            PanFiltUs.Visible = false;
            Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
        }

        protected void Button232_Click(object sender, EventArgs e)
        {
            string consulta = "";
            if (TnomBus.Text != "")
            {
                if (consulta.IndexOf("WHERE") < 0)
                {
                    consulta += "WHERE [nombre] like '%" + TnomBus.Text + "%'";
                }
                else
                {
                    consulta += " AND [nombre] like '%" + TnomBus.Text + "%'";
                }
            }

            if (TUspBus.Text != "")
            {
                if (consulta.IndexOf("WHERE") < 0)
                {
                    consulta += "WHERE [login] like '%" + TUspBus.Text + "%'";
                }
                else
                {
                    consulta += " AND [login] like '%" + TUspBus.Text + "%'";
                }
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     

            if (TeGrBus.Text != "")
            {
                if (consulta.IndexOf("WHERE") < 0)
                {
                    consulta += "WHERE [grupo] like '%" + TeGrBus.Text + "%'";
                }
                else
                {
                    consulta += " AND [grupo] like '%" + TeGrBus.Text + "%'";
                }
            }

            if (!(consulta.IndexOf("WHERE") < 0))
            {
                SqlDataSource4.SelectCommand = "SELECT [idUsuario], [nombre], [grupo], [login], [proveedor],[activo],[empresas] FROM [usuarios] "+consulta+" order by [idUsuario] desc";
                GridView35.DataBind();
            }

            PanFiltUs.Width = 20;
            PanFiltUs.Height = 20;
            PanFiltUs.Visible = false;
        }

        protected void LinkButton213_Click(object sender, EventArgs e)
        {
            PanFiltUs.Width = 335;
            PanFiltUs.Height = 200;
            PanFiltUs.Visible = true;
        }

        protected void LinkButton233_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
        }

    }
}