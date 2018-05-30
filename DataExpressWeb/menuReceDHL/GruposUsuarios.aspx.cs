using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data;
using System.Data.Common;

namespace DataExpressWeb
{
    public partial class Formulario_web114 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        private DataTable DT = new DataTable();
        static string idres = "";
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

        protected void tree_SelectedNodeChanged2(object sender, EventArgs e)
        {
            foreach (TreeNode nod in Tree2.Nodes)
            {
                if (nod.Selected && nod.Text == "Portal-Consultas")
                {
                    foreach (TreeNode nod2 in nod.ChildNodes)
                    {
                        foreach (TreeNode nod3 in nod2.ChildNodes)
                        {
                            nod3.Checked = true;
                        }
                    }
                    nod.Selected = false;
                }
                else

                    if (nod.Selected && nod.Text == "Administración")
                    {
                        foreach (TreeNode nod2 in nod.ChildNodes)
                        {
                            nod2.Checked = true;
                            foreach (TreeNode nod3 in nod2.ChildNodes)
                            {
                                nod3.Checked = true;
                                foreach (TreeNode nod4 in nod3.ChildNodes)
                                {
                                    nod4.Checked = true;
                                }
                            }
                        }
                        nod.Selected = false;
                    }
                    else
                    {


                        foreach (TreeNode nod2 in nod.ChildNodes)
                        {
                            if (nod2.Selected && (nod2.Text == "Comprobantes Fiscales" || nod2.Text == "Interfaz"))
                            {
                                foreach (TreeNode nod3 in nod2.ChildNodes)
                                {
                                    nod3.Checked = true;
                                }
                                nod2.Selected = false;
                            }
                        }



                        foreach (TreeNode nod2 in nod.ChildNodes)
                        {
                            if (nod2.Selected && (nod2.Text == "Administración de Usuarios" || nod2.Text == "Administración de Proveedores" || nod2.Text == "Administración de Receptores" || nod2.Text == "Administración de Configuración"))
                            {
                                foreach (TreeNode nod3 in nod2.ChildNodes)
                                {
                                    nod3.Checked = true;
                                    foreach (TreeNode nod4 in nod3.ChildNodes)
                                    {
                                        nod4.Checked = true;
                                    }
                                }
                                nod2.Selected = false;
                            }

                        }

                        foreach (TreeNode nod2 in nod.ChildNodes)
                        {
                            foreach (TreeNode nod3 in nod2.ChildNodes)
                            {
                                if (nod3.Selected && (nod3.Text == "Grupos de Usuarios" || nod3.Text == "Solicitudes de Registro" || nod3.Text == "Códigos IVA" || nod3.Text == "Días de Operación"
                                    || nod3.Text == "Monedas" || nod3.Text == "Tipo de Proveedor"))
                                {
                                    foreach (TreeNode nod4 in nod3.ChildNodes)
                                    {
                                        nod4.Checked = true;
                                    }
                                    nod3.Selected = false;
                                }
                            }
                        }


                    }
            }
        }

        protected void tree_SelectedNodeChanged(object sender, EventArgs e)
        {
            foreach(TreeNode nod in tree.Nodes)
            {
                if (nod.Selected && nod.Text == "Portal-Consultas")
                {
                  foreach(TreeNode nod2 in nod.ChildNodes)
                  {
                      foreach (TreeNode nod3 in nod2.ChildNodes)
                      {
                          nod3.Checked = true;
                      } 
                  }
                 nod.Selected = false;
                }else

                    if (nod.Selected && nod.Text == "Administración")
                    {
                        foreach (TreeNode nod2 in nod.ChildNodes)
                        {
                            nod2.Checked = true;
                            foreach (TreeNode nod3 in nod2.ChildNodes)
                            {
                                nod3.Checked = true;
                                foreach (TreeNode nod4 in nod3.ChildNodes)
                                {
                                    nod4.Checked = true;
                                }
                            }
                        }
                        nod.Selected = false;
                    }
                    else
                    {


                        foreach (TreeNode nod2 in nod.ChildNodes)
                        {
                            if (nod2.Selected && (nod2.Text == "Comprobantes Fiscales" || nod2.Text == "Interfaz"))
                            {
                                foreach (TreeNode nod3 in nod2.ChildNodes)
                                {
                                    nod3.Checked = true;
                                }
                                nod2.Selected = false;
                            }
                        }


                        
                            foreach (TreeNode nod2 in nod.ChildNodes)
                            {
                                if (nod2.Selected && (nod2.Text == "Administración de Usuarios" || nod2.Text == "Administración de Proveedores" || nod2.Text == "Administración de Receptores" || nod2.Text == "Administración de Configuración"))
                                {
                                    foreach (TreeNode nod3 in nod2.ChildNodes)
                                    {
                                        nod3.Checked = true;
                                        foreach (TreeNode nod4 in nod3.ChildNodes)
                                        {
                                            nod4.Checked = true;
                                        }
                                    }
                                    nod2.Selected = false;
                                }

                            }

                            foreach (TreeNode nod2 in nod.ChildNodes)
                            {
                                foreach (TreeNode nod3 in nod2.ChildNodes)
                                {
                                    if (nod3.Selected && (nod3.Text == "Grupos de Usuarios" || nod3.Text == "Solicitudes de Registro" || nod3.Text == "Códigos IVA" || nod3.Text == "Días de Operación"
                                        || nod3.Text == "Monedas" || nod3.Text == "Tipo de Proveedor"))
                                    {
                                        foreach (TreeNode nod4 in nod3.ChildNodes)
                                        {
                                            nod4.Checked = true;
                                        }
                                        nod3.Selected = false;
                                    }
                                } 
                            }

                      
                    }
            }
        }
        string permisos = "";
        protected void Button16_Click(object sender, EventArgs e)
        {
            //----------------crear grupo----------------
            string nivelR = "";
            foreach (TreeNode nod in tree.Nodes)
            {
                foreach (TreeNode nod2 in nod.ChildNodes)
                {
                    if (nod2.Checked && nod2.Value != "")
                    {
                        permisos += nod2.Value + "|";
                    }
                    foreach (TreeNode nod3 in nod2.ChildNodes)
                    {
                        if (nod3.Checked && nod3.Value != "")
                        {
                            permisos += nod3.Value + "|";
                        }
                        foreach (TreeNode nod4 in nod3.ChildNodes)
                        {
                            if (nod4.Checked && nod4.Value != "")
                            {
                                permisos += nod4.Value + "|";
                            }
                        }
                    }
                }
            }
            if (permisos != "")
            {
                permisos = permiGen(permisos);
                if (nomPer.Text != "" && desPer.Text != "" && nivelRol.Text !="")
                {
                    /////////////////////////////////////valida si nivel existe//////////
                    BD.Conectar();
                    BD.CrearComando("select nivelRol from grupos where nivelRol=@nivelRol");
                    BD.AsignarParametroCadena("@nivelRol", nivelRol.Text);
                    var dr = BD.EjecutarConsulta();
                    if (dr.HasRows && dr.Read())
                    {
                        nivelR = dr["nivelRol"].ToString();
                        BD.Desconectar();
                    }
                    BD.Desconectar();
                    if (nivelR == nivelRol.Text)
                        {
                            Session["estNot"] = false;
                            Session["msjNoti"] = "YA EXISTE UN GRUPO EN ESTE NIVEL";
                            Session["estPan"] = true;
                            MenuVis.Width = 478;
                            MenuVis.Height = 390;
                            tree.ExpandAll();
                            MenuVis.Visible = true;
                        }
                        else
                        {
                        /////////////////////////////////////////////////////////////////////
                        BD.Conectar();
                            BD.CrearComando("insert into grupos (grupo,activo,descripcion,permiso,nivelRol) values (@grupo,@activo,@descripcion,@permiso,@nivelR)");
                            BD.AsignarParametroCadena("@grupo", nomPer.Text);
                            if (ChecAct.Checked)
                            {
                                BD.AsignarParametroCadena("@activo", "si");
                            }
                            else
                            {
                                BD.AsignarParametroCadena("@activo", "no");
                            }
                            BD.AsignarParametroCadena("@descripcion", desPer.Text);
                            BD.AsignarParametroCadena("@nivelR", nivelRol.Text);
                            BD.AsignarParametroCadena("@permiso", permisos);
                            BD.EjecutarConsulta();
                            BD.Desconectar();

                            PCrearGru.Width = 20;
                            PCrearGru.Height = 20;
                            PCrearGru.Visible = false;
                            Response.Redirect("~/menuReceDHL/GruposUsuarios.aspx");
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
                    Session["msjNoti"] = "DEBES SELECIONAR ALGUN PERMISO";
                    Session["estPan"] = true;
        //        }
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //--------------ver panel crear grupo------------------------
            PCrearGru.Width = 478;
            PCrearGru.Height = 390;
            tree.ExpandAll();
            PCrearGru.Visible = true;
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            //------------cancelar crear grupo---------------
            PCrearGru.Width = 20;
            PCrearGru.Height = 20;
            PCrearGru.Visible = false;
            nomPer.Text = "";
            desPer.Text = "";
            permisos = "";
            nivelRol.Text = "";
        }

        protected void Button30_Click(object sender, EventArgs e)
        {
            //------------cancelar crear grupo en mismo nivel---------------
       //     MenuVis.Width = 20;
       //     PCrearGru.Height = 20;
            MenuVis.Visible = false;
            PCrearGru.Visible = true;
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            //-----------------ver panel editar------------------
            bool si = false;
            foreach (GridViewRow row in GridView6.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }
            if (si == true)
            {
                Tree2.ExpandAll();
                Peditar.Width = 478;
                Peditar.Height = 390;
                string dia1 = "", habi = "", hi = "", hf = "";
                foreach (GridViewRow row in GridView6.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("select * from grupos where idGrupo=@id");
                        BD.AsignarParametroCadena("@id",idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if(DR.Read()){
                            TeditNom.Text= DR[1].ToString();
                            TeditDes.Text = DR[3].ToString();
                            if (DR[2].ToString() == "si")
                            {
                                Checedit.Checked = true;
                            }
                            else {
                                Checedit.Checked = false;
                            }

                            foreach (TreeNode nod in Tree2.Nodes)
                            {
                                foreach (TreeNode nod2 in nod.ChildNodes)
                                {
                                    if (!(DR[4].ToString().IndexOf(nod2.Value)<0))
                                    {
                                        nod2.Checked = true;
                                    }
                                    //if (!(DR[4].ToString().IndexOf("CompFis") < 0) || !(DR[4].ToString().IndexOf("Interfaz") < 0) || !(DR[4].ToString().IndexOf("AdmUsuarios") < 0) 
                                    //    || !(DR[4].ToString().IndexOf("AdmProveedores") < 0) || !(DR[4].ToString().IndexOf("AdmReceptores") < 0)  
                                    //    || !(DR[4].ToString().IndexOf("AdmConfiguracion") < 0))
                                    //{
                                    //    nod2.Selected = true;
                                    //}

                                    foreach (TreeNode nod3 in nod2.ChildNodes)
                                    {
                                        if (!(DR[4].ToString().IndexOf(nod3.Value) < 0))
                                        {
                                            nod3.Checked = true;
                                        }
                                        //if (!(DR[4].ToString().IndexOf("GrupUs") < 0) || !(DR[4].ToString().IndexOf("SolicReg") < 0 ) 
                                        //    || !(DR[4].ToString().IndexOf("CodigosIVA") < 0 ) || !(DR[4].ToString().IndexOf("Dias") < 0 ) 
                                        //    || !(DR[4].ToString().IndexOf("Monedas") < 0 ) || !(DR[4].ToString().IndexOf("TipoProv") < 0 ))
                                        //{
                                        //    nod3.Selected = true;
                                        //}
                                        foreach (TreeNode nod4 in nod3.ChildNodes)
                                        {
                                            if (!(DR[4].ToString().IndexOf(nod4.Value) < 0))
                                            {
                                                nod4.Checked = true;
                                            }
                                        }
                                    }
                                }

                            }

                        }
                        BD.Desconectar();
                        Peditar.Visible = true;
                    }
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN GRUPO";
                Session["estPan"] = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //-------------cancelar editar------------
            Peditar.Width = 20;
            Peditar.Height = 20;
            idres = "";
            Peditar.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //----------------editar grupo---------------------------
            string permisos = "";

            foreach (TreeNode nod in Tree2.Nodes)
            {
                foreach (TreeNode nod2 in nod.ChildNodes)
                {
                    if (nod2.Checked && nod2.Value != "")
                    {
                        permisos += nod2.Value + "|";
                    }
                    foreach (TreeNode nod3 in nod2.ChildNodes)
                    {
                        if (nod3.Checked && nod3.Value != "")
                        {
                            permisos += nod3.Value + "|";
                        }
                        foreach (TreeNode nod4 in nod3.ChildNodes)
                        {
                            if (nod4.Checked && nod4.Value != "")
                            {
                                permisos += nod4.Value + "|";
                            }
                        }
                    }
                }
            }
            if (permisos != "")
            {

                permisos = permiGen(permisos);
                BD.Conectar();
                BD.CrearComando("update grupos set grupo=@grupo,activo=@activo,descripcion=@descripcion,permiso=@permiso where idGrupo=@id");
                BD.AsignarParametroCadena("@grupo", TeditNom.Text);
                if (Checedit.Checked)
                {
                    BD.AsignarParametroCadena("@activo", "si");
                }
                else
                {
                    BD.AsignarParametroCadena("@activo", "no");
                }
                BD.AsignarParametroCadena("@descripcion", TeditDes.Text);
                BD.AsignarParametroCadena("@permiso", permisos);
                BD.AsignarParametroCadena("@id", idres);
                BD.EjecutarConsulta();
                BD.Desconectar();

                Peditar.Width = 20;
                Peditar.Height = 20;
                Peditar.Visible = false;
                idres = "";

                

                Response.Redirect("~/menuReceDHL/GruposUsuarios.aspx");

                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN GRUPO";
                Session["estPan"] = true;
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR PERMISOS";
                Session["estPan"] = true;
            }
        }

        protected string permiGen(string perm)
        {
            if (!(perm.IndexOf("SubCFDI") < 0) || !(perm.IndexOf("EditarCom") < 0) || !(perm.IndexOf("DocAdic") < 0) || !(perm.IndexOf("PorConsultas") < 0)
                || !(perm.IndexOf("CanCFDI") < 0) || !(perm.IndexOf("RecCFDI") < 0) || !(perm.IndexOf("Proc") < 0))
            {
                perm += "CompFis|";
            }
            if (!(perm.IndexOf("GenInt") < 0))
            {
                perm += "Interfaz|";
            }
            if (!(perm.IndexOf("NuevoUs") < 0) || !(perm.IndexOf("EditarUs") < 0) || !(perm.IndexOf("RegistrarUs") < 0))
            {
                perm += "AdmUsuarios|";
            }
            if (!(perm.IndexOf("NuevoGru") < 0) || !(perm.IndexOf("EditarGru") < 0) || !(perm.IndexOf("DesactivarGru") < 0))
            {
                if (!(perm.IndexOf("AdmUsuarios") < 0))
                {
                    perm += "GrupUs|";
                }
                else
                {
                    perm += "GrupUs|AdmUsuarios|";
                }
            }
            if (!(perm.IndexOf("CrearPro") < 0) || !(perm.IndexOf("EditarPro") < 0) || !(perm.IndexOf("InhabilitarPro") < 0) || !(perm.IndexOf("RehabilitarPro") < 0))
            {
                perm += "AdmProveedores|";
            }
            if (!(perm.IndexOf("RecSolicitud") < 0) || !(perm.IndexOf("AprSolicitud") < 0))
            {
                if (!(perm.IndexOf("AdmProveedores") < 0))
                {
                    perm += "SolicReg|";
                }
                else
                {
                    perm += "AdmProveedores|SolicReg|";
                }
            }
            if (!(perm.IndexOf("NuevoRec") < 0) || !(perm.IndexOf("EditarRec") < 0))
            {
                perm += "AdmReceptores|";
            }
            if (!(perm.IndexOf("NuevoIVA") < 0) || !(perm.IndexOf("EditarIVA") < 0))
            {
                if (!(perm.IndexOf("AdmReceptores") < 0))
                {
                    perm += "CodigosIVA|";
                }
                else
                {
                    perm += "AdmReceptores|CodigosIVA|";
                }
            }
            if (!(perm.IndexOf("EditarDia") < 0))
            {
                if (!(perm.IndexOf("AdmConfiguracion") < 0))
                {
                    perm += "Dias|";
                }
                else
                {
                    perm += "AdmConfiguracion|Dias|";
                }
            }
            if (!(perm.IndexOf("NuevaMon") < 0) || !(perm.IndexOf("EditarMon") < 0))
            {
                if (!(perm.IndexOf("AdmConfiguracion") < 0))
                {
                    perm += "Monedas|";
                }
                else
                {
                    perm += "AdmConfiguracion|Monedas|";
                }
            }
            if (!(perm.IndexOf("NuevoProv") < 0) || !(perm.IndexOf("EditarProv") < 0))
            {
                if (!(perm.IndexOf("AdmConfiguracion") < 0))
                {
                    perm += "TipoProv|";
                }
                else
                {
                    perm += "AdmConfiguracion|TipoProv|";
                }
            }
            //if (!(perm.IndexOf("CompFis") < 0) || !(perm.IndexOf("Interfaz") < 0))
            if (!(perm.IndexOf("Interfaz") < 0))
            {   
                perm += "PorConsultas|";
            }
            if (!(perm.IndexOf("AdmUsuarios") < 0) || !(perm.IndexOf("AdmProveedores") < 0) || !(perm.IndexOf("AdmReceptores") < 0) || !(perm.IndexOf("AdmConfiguracion") < 0)
                || !(perm.IndexOf("AdmMensajes") < 0) || !(perm.IndexOf("Reportes") < 0) || !(perm.IndexOf("AdmCat") < 0))
            {
                perm += "Administracion|";
            }

            return perm;
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            //-----------desactivar grupo-----------------
            bool si = false;
            foreach (GridViewRow row in GridView6.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }
            if (si == true)
            {
                foreach (GridViewRow row in GridView6.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("update grupos set activo=@activo where idGrupo=@id");
                        BD.AsignarParametroCadena("@activo", "no");
                        BD.AsignarParametroCadena("@id", idres);
                        BD.EjecutarConsulta();
                        BD.Desconectar();

                        idres = "";
                        Response.Redirect("~/menuReceDHL/GruposUsuarios.aspx");
                    }
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN GRUPO";
                Session["estPan"] = true;
            }
        }

        string nivelR;
        string nivelR1;

        protected void Mostrar_onClick(object sender, EventArgs e)
        {
            BD.Conectar();
            BD.CrearComando("select nivelRol from grupos where nivelRol>=@nivelRol order by nivelRol asc");
            BD.AsignarParametroCadena("@nivelRol", nivelRol.Text);
            var dr1 = BD.EjecutarConsulta();
            if (dr1.Read())
            {
                nivelR = dr1["nivelRol"].ToString();
                if (Convert.ToInt64(nivelR) >= Convert.ToInt64(nivelRol.Text))
                {
                    BD.Desconectar();
                    BasesDatos BD3 = new BasesDatos();
                    BD3.Conectar();
                    BD3.CrearComando("select MAX(nivelRol)  from grupos");
                    var dr2 = BD3.EjecutarConsulta();
                    if (dr2.Read())
                    {
                        nivelR1 = dr2[0].ToString();
                    }
                    BD3.Desconectar();
                    int btr = Convert.ToInt32(nivelR1);
                    var sum2 = Convert.ToInt32(nivelR1) + 1;
                    var sum = Convert.ToInt32(nivelR1);
                    int initializeer= Convert.ToInt32(nivelR);
                   
                    for (int i = initializeer; i <= btr; i++)
                    {
                        BasesDatos BD1 = new BasesDatos();
                        BD1.Conectar();
                        BD1.CrearComando("update grupos set nivelRol = @nivel where nivelRol = @act ");
                        BD1.AsignarParametroCadena("@act", Convert.ToString(sum));
                        BD1.AsignarParametroCadena("@nivel", Convert.ToString(sum2));
                        BD1.EjecutarConsulta();
                        BD1.Desconectar();
                        sum -= 1;
                        sum2 -= 1;
                    }
                }
            }
            BD.Desconectar();
            ////////////////////////insert info//////////////////////////////////
            foreach (TreeNode nod in tree.Nodes)
            {
                foreach (TreeNode nod2 in nod.ChildNodes)
                {
                    if (nod2.Checked && nod2.Value != "")
                    {
                        permisos += nod2.Value + "|";
                    }
                    foreach (TreeNode nod3 in nod2.ChildNodes)
                    {
                        if (nod3.Checked && nod3.Value != "")
                        {
                            permisos += nod3.Value + "|";
                        }
                        foreach (TreeNode nod4 in nod3.ChildNodes)
                        {
                            if (nod4.Checked && nod4.Value != "")
                            {
                                permisos += nod4.Value + "|";
                            }
                        }
                    }
                }
            }
       //     int level = Convert.ToInt32(nivelRol.Text) - 1;
            if (permisos != "")
            {
                permisos = permiGen(permisos);
                BD.Conectar();
                BD.CrearComando("insert into grupos (grupo,activo,descripcion,permiso,nivelRol) values (@grupo,@activo,@descripcion,@permiso,@nivelRR)");
                BD.AsignarParametroCadena("@grupo", nomPer.Text);
                if (ChecAct.Checked)
                {
                    BD.AsignarParametroCadena("@activo", "si");
                }
                else
                {
                    BD.AsignarParametroCadena("@activo", "no");
                }
                BD.AsignarParametroCadena("@descripcion", desPer.Text);
                BD.AsignarParametroCadena("@permiso", permisos);
                BD.AsignarParametroCadena("@nivelRR", nivelRol.Text);
                BD.EjecutarConsulta();
                BD.Desconectar();
            }
            MenuVis.Visible = false;
            PCrearGru.Visible = false;
            nomPer.Text = "";
            desPer.Text = "";
            permisos = "";
            nivelRol.Text = "";
            Response.Redirect("~/menuReceDHL/GruposUsuarios.aspx");

            Session["estNot"] = false;
            Session["msjNoti"] = "GRUPO GENERADO CORRECTAMENTE";
            Session["estPan"] = true;
        }

    }
}