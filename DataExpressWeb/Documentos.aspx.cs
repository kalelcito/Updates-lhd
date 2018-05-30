using Control;
using DataExpressWeb.wsRetenciones;
using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;


namespace DataExpressWeb
{

    public partial class Documentos : System.Web.UI.Page
    {
        private String consulta;
        private String aux;
        private String separador = "|";
        private DataTable DT = new DataTable();
        private BasesDatos DB = new BasesDatos();
        private EnviarMail EM;
        static string idres = "";

        private Facturas FAC;
        private string idComplemento = "";
        private string arc;
        private string pdf;
        private string bck;
        private string usuario = "";

        String fecha, fechanom, fechacreacion;
        String dir, auxRuta;
        string where = "";
        int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["usuario"] != null || Session["adm"] != null) && Session["proveedorTipe"] != null)
            {
                if (Convert.ToBoolean(Session["adm"]) == false)
                {

                    if (!IsPostBack)
                    {

                        if (Session["proveedorTipe"].ToString() == "FLETES")
                        {
                            ChackSabCom.Visible = true;
                        }
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
            SqlDataSourceCPago.ConnectionString = ConfigurationManager.AppSettings.Get("CADENA_CONEXION");
            lblMsg.Text = "";
            msjError.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            consulta = "";
            DT.Clear();
            if (tbFolioAnterior.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "FA" + tbFolioAnterior.Text + separador; }
                else { consulta = "FA" + tbFolioAnterior.Text + separador; }
            }
            if (tbNombre.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RS" + tbNombre.Text + separador; }
                else { consulta = "RS" + tbNombre.Text + separador; }
            }
            if (tbRFC.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RF" + tbRFC.Text + separador; }
                else { consulta = "RF" + tbRFC.Text + separador; }
            }
            if (tbSerie.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "SE" + tbSerie.Text + separador; }
                else { consulta = "SE" + tbSerie.Text + separador; }
            }
            if (consulta.Length != 0)
            {
                consulta = consulta.Substring(0, consulta.Length - 1);

                try
                {
                    SqlDataSource1.SelectParameters["QUERY"].DefaultValue = consulta;
                    SqlDataSource1.SelectParameters["RFC"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
                    SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["PI"].DefaultValue = " ";
                    SqlDataSource1.DataBind();
                    gvFacturas.DataBind();
                }
                catch (Exception ex)
                {

                }
                lSeleccionDocus.Text = lSeleccionDocus.Text + (String)Session["rfcUser"];
                consulta = "";



            }
            Pbuscar.Visible = false;
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            string emails = "";
            string emailEnviar = "";
            string FOLFAC = "";
            string SERFAC = "";
            string FECHEMI = "";
            string servidor = "";
            int puerto = 25;
            Boolean ssl = false;
            string emailCredencial = "";
            string passCredencial = "";
            string RutaDOC = "";
            string RFCREC = "";
            ArrayList Arraycons = new ArrayList();
            string[] cons;

            DB.Conectar();
            DB.CrearComando("select servidorSMTP,puertoSMTP,sslSMTP,userSMTP,passSMTP,dirdocs,emailEnvio from ParametrosSistema");
            DbDataReader DR1 = DB.EjecutarConsulta();

            while (DR1.Read())
            {
                servidor = DR1[0].ToString();
                puerto = Convert.ToInt32(DR1[1].ToString());
                ssl = Convert.ToBoolean(DR1[2].ToString());
                emailCredencial = DR1[3].ToString();
                passCredencial = DR1[4].ToString();
                RutaDOC = DR1[5].ToString();
                emailEnviar = DR1[6].ToString();
            }
            DB.Desconectar();
            consulta = "";
            DT.Clear();
            if (tbFolioAnterior.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "FA" + tbFolioAnterior.Text + separador; }
                else { consulta = "FA" + tbFolioAnterior.Text + separador; }
            }
            if (tbNombre.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RS" + tbNombre.Text + separador; }
                else { consulta = "RS" + tbNombre.Text + separador; }
            }
            if (tbRFC.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RF" + tbRFC.Text + separador; }
                else { consulta = "RF" + tbRFC.Text + separador; }
            }
            if (tbSerie.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "SE" + tbSerie.Text + separador; }
                else { consulta = "SE" + tbSerie.Text + separador; }
            }
            if (consulta.Length != 0)
            {
                consulta = consulta.Substring(0, consulta.Length - 1);
            }

            if (Convert.ToBoolean(Session["coFactTodas"])) { aux = "1"; } else { aux = "0"; }


            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
            DB.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, consulta);
            DB.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, (String)Session["rfcUser"]);
            DB.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "");
            DB.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, (String)Session["rfcUser"]);
            DB.AsignarParametroProcedimiento("@PI", System.Data.DbType.String, " ");

            DbDataReader DR = DB.EjecutarConsulta();

            while (DR.Read())
            {
                cons = new string[5];
                RFCREC = DR[0].ToString();
                FOLFAC = DR[3].ToString();
                SERFAC = DR[2].ToString();
                FECHEMI = DR[5].ToString();

                cons[0] = RFCREC;
                cons[1] = FOLFAC;
                cons[2] = SERFAC;
                cons[3] = FECHEMI;
                cons[4] = emails;
                Arraycons.Add(cons);
            }
            DB.Desconectar();



            foreach (string[] datFact in Arraycons)
            {
                DB.Conectar();
                DB.CrearComando("select emailsRegla from EmailsReglas  where Receptor=@rfcrec and estadoRegla=1");
                DB.AsignarParametroCadena("@rfcrec", datFact[0]);
                DbDataReader DR3 = DB.EjecutarConsulta();
                if (DR3.Read())
                {
                    emails = DR3[0].ToString();
                }
                DB.Desconectar();
            }
        }

        protected void enviarMail(string id, string cc, string mon)
        {
            string emailEnviar = "";
            string asunto = "";
            string mensaje = "";
            string analista = "";
            string proveedor = "";
            string UUID = "";
            string razon = "";
            string servidor = "";
            int puerto = 0;
            Boolean ssl = false;
            string emailCredencial = "";
            string passCredencial = "";
            string emailNoti = "";

            DB.Conectar();
            DB.CrearComando("select servidorSMTP,puertoSMTP,sslSMTP,userSMTP,passSMTP,emailEnvio,emailNotificacion from ParametrosSistema");
            DbDataReader DR1 = DB.EjecutarConsulta();
            while (DR1.Read())
            {
                servidor = DR1[0].ToString();
                puerto = Convert.ToInt32(DR1[1].ToString());
                ssl = Convert.ToBoolean(DR1[2].ToString());
                emailCredencial = DR1[3].ToString();
                passCredencial = DR1[4].ToString();
                emailEnviar = DR1[5].ToString();
                emailNoti = DR1[6].ToString();
            }
            DB.Desconectar();

            DB.Conectar();
            DB.CrearComando(@"select correoAnalista,tipProv,UUID,razonSocial  from general inner join 
                            CFDI on CFDI.id_Factura = GENERAL.idFactura inner join
                            Proveedores on Proveedores.idProveedor = GENERAL.idProv where idFactura=@idFt");
            DB.AsignarParametroCadena("@idFt", id);
            DbDataReader DR2 = DB.EjecutarConsulta();
            if (DR2.Read())
            {
                analista = DR2[0].ToString();
                proveedor = DR2[1].ToString();
                UUID = DR2[2].ToString();
                razon = DR2[3].ToString();
            }
            DB.Desconectar();
            EM = new EnviarMail();
            EM.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);
            asunto = "Comprobante modificado";
            mensaje = @"Buen dia! <br>
                     El proveedor " + razon + " ha modificado la factura con folio fiscal: <br>";
            mensaje += UUID + " de " + proveedor + ".<br>";
            if (ChackSabCom.Checked)
            {
                mensaje += "El cambio fue realizado en el No. de Sabana y/o Moneda.<br>";
                mensaje += "Datos actuales del comprobante:<br><br>";
                mensaje += "-No. Sabana: " + cc + "<br>";
            }
            else
            {
                mensaje += "El cambio fue realizado en el Centro de Costos y/o Moneda.<br>";
                mensaje += "Datos actuales del comprobante:<br><br>";
                mensaje += "-CC: " + cc + "<br>";
            }

            mensaje += "-Moneda: " + mon + "<br><br>";
            mensaje += "<br>El comprobante a pasado su estatus de rechazado a validado";
            mensaje += "<br><br>Saludos cordiales. ";

            if (analista != "")
            {
                EM.llenarEmail(emailEnviar, analista, "", "", asunto, mensaje);
            }
            else
            {
                EM.llenarEmail(emailEnviar, emailNoti, "", "", asunto, mensaje);
            }
            EM.enviarEmail();
        }

        protected void Button1_Click3(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["idUser"] != null)
            {
                try
                {
                    SqlDataSource1.SelectParameters["QUERY"].DefaultValue = "-";
                    SqlDataSource1.SelectParameters["RFC"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
                    SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["PI"].DefaultValue = " ";
                    SqlDataSource1.DataBind();
                    gvFacturas.DataBind();
                }
                catch (Exception ex)
                {
                    //  error.Text = ex.ToString();
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                try
                {
                    SqlDataSource1.SelectParameters["QUERY"].DefaultValue = "-";
                    SqlDataSource1.SelectParameters["RFC"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
                    SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["PI"].DefaultValue = " ";
                    SqlDataSource1.DataBind();
                    gvFacturas.DataBind();
                }
                catch (Exception ex)
                {
                    //  error.Text = ex.ToString();
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                try
                {
                    SqlDataSource1.SelectParameters["QUERY"].DefaultValue = " ";
                    SqlDataSource1.SelectParameters["RFC"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
                    SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["PI"].DefaultValue = " ";
                    SqlDataSource1.DataBind();
                    gvFacturas.DataBind();
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                try
                {
                    SqlDataSource1.SelectParameters["QUERY"].DefaultValue = " ";
                    SqlDataSource1.SelectParameters["RFC"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
                    SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["PI"].DefaultValue = " ";
                    SqlDataSource1.DataBind();
                    gvFacturas.DataBind();
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSourceLog_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {

            Pbuscar.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string[] acentos = { "á", "é", "í", "ó", "ú" };
            DateTime hoy = DateTime.Now;
            TimeSpan t;
            string[] hi;
            string[] fi;
            int ini = 0, fin = 0;
            string d = "", hri = "", hri2 = "", dba = "";
            //bool bandhor = false;
            string dia = hoy.ToString("dddd");
            //dia = dia.Replace(acentos, "a");
            DB.Conectar();
            DB.CrearComando("select habilitado, horaIni, horaFin,dia from diasOperacion where dia=@dia");
            DB.AsignarParametroCadena("@dia", dia);
            DbDataReader DR = DB.EjecutarConsulta();
            if (DR.Read())
            {
                d = DR[0].ToString();
                hri = DR[1].ToString();
                hri2 = DR[2].ToString();
                dba = DR[3].ToString();
            }
            DB.Desconectar();

            //string hora = hoy.ToString("HH:mm:ss tt");
            if (d == "Si") //if (true)
            {
                hi = hri.Split(':');
                fi = hri2.Split(':');
                ini = Convert.ToInt32(hi[0]);
                fin = Convert.ToInt32(fi[0]);

                if (hoy.TimeOfDay >= new TimeSpan(ini, 0, 0) && hoy.TimeOfDay <= new TimeSpan(fin, 0, 0) && (dia.Contains(dba))) // if (true) 
                {
                    Response.Redirect("~/validarFacturas.aspx");
                }
                else
                {
                    Session["estNot"] = false;
                    Session["msjNoti"] = "SOLO PUEDES CARGAR CFDI LOS DIAS LUNES EN UN HORARIO DE 8:00 AM A 8:00 PM";
                    Session["estPan"] = true;
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "SOLO PUEDES CARGAR CFDI LOS DIAS LUNES EN UN HORARIO DE 8:00 AM A 8:00 PM";
                Session["estPan"] = true;
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Documentos.aspx");
        }

        protected void gvFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            otro.Visible = true;
        }

        protected void But_Click(object sender, EventArgs e)
        {
            //string CodC = "", mon = "";
            if (valEditar())
            {
                if (ChackSabCom.Checked)
                {

                    DB.Conectar();
                    DB.CrearComando(@"update General set Moneda=@mon, noSabana = @nsb ,estatus=@sta ,fechaRechazo=@fech, 
                                           causaRechazo=@causa, fechaUltimCam=@cambio where idFactura=@fac");
                    DB.AsignarParametroCadena("@mon", lMon.SelectedValue);
                    DB.AsignarParametroCadena("@nsb", TcodCo.Text);
                    DB.AsignarParametroCadena("@fech", "");
                    DB.AsignarParametroCadena("@causa", "");
                    DB.AsignarParametroCadena("@sta", "validado");
                    DB.AsignarParametroCadena("@cambio", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                    DB.AsignarParametroCadena("@fac", idres);
                    DB.EjecutarConsulta();
                    DB.Desconectar();

                    int No_intentos = 0;
                    DB.Conectar();
                    DB.CrearComando("SELECT No_intentos FROM GENERAL where idFactura=@fact");
                    DB.AsignarParametroCadena("@fact", idres);
                    DbDataReader DR = DB.EjecutarConsulta();
                    if (DR.Read())
                    {
                        string variable = DR[0].ToString();
                        if (DR[0].ToString() != null && DR[0].ToString() != "")
                        {
                            No_intentos = Convert.ToInt32(DR[0].ToString());
                        }
                        else { No_intentos = 0; }
                    }
                    DB.Desconectar();
                    DB.Conectar();
                    DB.CrearComando("UPDATE GENERAL SET No_intentos=@No_intentos  where idFactura=@fact");
                    DB.AsignarParametroCadena("@fact", idres);
                    DB.AsignarParametroCadena("@No_intentos", No_intentos.ToString());
                    DB.EjecutarConsulta();
                    DB.Desconectar();

                    DB.AsignarParametroCadena("@sta", "validado " + No_intentos);

                    enviarMail(idres, TcodCo.Text, lMon.SelectedValue);
                    otro.Width = 20;
                    otro.Height = 20;
                    otro.Visible = false;
                    idres = "";
                    Response.Redirect("~/Documentos.aspx");
                }
                else
                {
                    if (validarCodGL(TcodCo.Text))
                    {

                        int No_intentos = 0;
                        DB.Conectar();
                        DB.CrearComando("SELECT No_intentos FROM GENERAL where idFactura=@fact");
                        DB.AsignarParametroCadena("@fact", idres);
                        DbDataReader DR = DB.EjecutarConsulta();
                        if (DR.Read())
                        {
                            string variable = DR[0].ToString();
                            if (DR[0].ToString() != null && DR[0].ToString() != "")
                            {
                                No_intentos = Convert.ToInt32(DR[0].ToString());
                            }
                            else { No_intentos = 0; }
                        }
                        DB.Desconectar();
                        DB.Conectar();
                        DB.CrearComando("UPDATE GENERAL SET No_intentos=@No_intentos  where idFactura=@fact");
                        DB.AsignarParametroCadena("@fact", idres);
                        DB.AsignarParametroCadena("@No_intentos", No_intentos.ToString());
                        DB.EjecutarConsulta();
                        DB.Desconectar();


                        DB.Conectar();
                        DB.CrearComando(@"update General set CodCont=@cod, Moneda=@mon, estatus=@sta ,fechaRechazo=@fech, 
                                           causaRechazo=@causa, fechaUltimCam=@cambio where idFactura=@fac");
                        DB.AsignarParametroCadena("@cod", TcodCo.Text);
                        DB.AsignarParametroCadena("@mon", lMon.SelectedValue);
                        DB.AsignarParametroCadena("@sta", "validado " + No_intentos);
                        DB.AsignarParametroCadena("@fech", "");
                        DB.AsignarParametroCadena("@causa", "");
                        DB.AsignarParametroCadena("@cambio", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                        DB.AsignarParametroCadena("@fac", idres);
                        DB.EjecutarConsulta();
                        DB.Desconectar();

                        enviarMail(idres, TcodCo.Text, lMon.SelectedValue);
                        otro.Width = 20;
                        otro.Height = 20;
                        otro.Visible = false;
                        idres = "";
                        Response.Redirect("~/Documentos.aspx");
                    }
                    else
                    {
                        Session["estNot"] = false;
                        Session["msjNoti"] = "Formato del Código Contable incorrecto <br/> ejemplo: 0000.0000.0000.00.000";
                        Session["estPan"] = true;
                    }
                }
            }
            else { Response.Redirect("~/Documentos.aspx"); }

        }

        protected bool valEditar()
        {
            string mn = "", cc = "", sb = "";
            DB.Conectar();
            DB.CrearComando("select CodCont, Moneda, noSabana from General where idFactura=@id");
            DB.AsignarParametroCadena("@id", idres);
            DbDataReader DR = DB.EjecutarConsulta();
            if (DR.Read())
            {
                cc = DR[0].ToString();
                mn = DR[1].ToString();
                sb = DR[2].ToString();
            }
            DB.Desconectar();

            if (ChackSabCom.Checked)
            {
                if (mn != lMon.SelectedValue || sb == TcodCo.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (mn != lMon.SelectedValue || cc != TcodCo.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            otro.Width = 20;
            otro.Height = 20;
            idres = "";
            otro.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string[] acentos = { "á", "é", "í", "ó", "ú" };
            DateTime hoy = DateTime.Now;
            TimeSpan t;
            string[] hi;
            string[] fi;
            int ini = 0, fin = 0;
            string d = "", hri = "", hri2 = "", dba = "", pr = "";
            //bool bandhor = false;
            string dia = hoy.ToString("dddd");
            //dia = dia.Replace(acentos, "a");
            DB.Conectar();
            DB.CrearComando("select habilitado, horaIni, horaFin,dia,Proveedores from diasOperacion where dia=@dia");
            DB.AsignarParametroCadena("@dia", dia);
            DbDataReader DR = DB.EjecutarConsulta();
            if (DR.Read())
            {
                d = DR[0].ToString();
                hri = DR[1].ToString();
                hri2 = DR[2].ToString();
                dba = DR[3].ToString();
                pr = DR[4].ToString();
            }
            DB.Desconectar();

            //string hora = hoy.ToString("HH:mm:ss tt");
            if (d == "Si") //if (true)  
            {
                hi = hri.Split(':');
                fi = hri2.Split(':');
                ini = Convert.ToInt32(hi[0]);
                fin = Convert.ToInt32(fi[0]);

                if (hoy.TimeOfDay >= new TimeSpan(ini, 0, 0) && hoy.TimeOfDay <= new TimeSpan(fin, 0, 0) && (dia.Contains(dba))) //if (true)
                {
                    //Session["proveedorTipe"]
                    if (!(pr.IndexOf(Session["proveedorTipe"].ToString()) < 0)) //if (true)  //  
                    {
                        Response.Redirect("~/validarFacturas.aspx");
                    }
                    else
                    {
                        Session["estNot"] = false;
                        Session["msjNoti"] = "LOS PROVEEDORES DE " + Session["proveedorTipe"].ToString() + " <br/> NO PUEDEN CARGAR CFDI ESTE DÍA ";
                        Session["estPan"] = true;
                    }
                }
                else
                {
                    Session["estNot"] = false;
                    Session["msjNoti"] = "SOLO PUEDES CARGAR CFDI LOS DIAS LUNES EN UN HORARIO DE 8:00 AM A 8:00 PM";
                    Session["estPan"] = true;
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "SOLO PUEDES CARGAR CFDI LOS DIAS LUNES EN UN HORARIO DE 8:00 AM A 8:00 PM";
                Session["estPan"] = true;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            bool si = false;
            if (ChackSabCom.Checked)
            {
                foreach (GridViewRow row in gvFacturas2.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    if (chk_Seleccionar.Checked)
                    { si = true; }
                }
            }
            else
            {
                foreach (GridViewRow row in gvFacturas.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    if (chk_Seleccionar.Checked)
                    { si = true; }
                }
            }
            if (si == true)
            {
                otro.Width = 435;
                otro.Height = 280;
                if (ChackSabCom.Checked)
                {
                    foreach (GridViewRow row in gvFacturas2.Rows)
                    {
                        CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                        HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                        if (chk_Seleccionar.Checked)
                        {
                            idres = hd_Seleccionafol.Value;
                            DB.Conectar();
                            DB.CrearComando("select folio, CodCont, Moneda, noSabana from General where idFactura=@id");
                            DB.AsignarParametroCadena("@id", idres);
                            DbDataReader DR = DB.EjecutarConsulta();
                            if (DR.Read())
                            {
                                TFol.Text = DR[0].ToString();
                                if (DR[2].ToString() != "")
                                {
                                    lMon.SelectedValue = DR[2].ToString();
                                }
                                LIden.Text = "No. Sabana:";
                                TcodCo.Text = DR[3].ToString();

                                otro.Visible = true;
                            }
                            DB.Desconectar();
                        }
                    }
                }
                else
                {
                    foreach (GridViewRow row in gvFacturas.Rows)
                    {
                        CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                        HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                        if (chk_Seleccionar.Checked)
                        {
                            idres = hd_Seleccionafol.Value;

                            DB.Conectar();
                            DB.CrearComando("select folio, CodCont, Moneda, noSabana from General where idFactura=@id");
                            DB.AsignarParametroCadena("@id", idres);
                            DbDataReader DR = DB.EjecutarConsulta();
                            if (DR.Read())
                            {
                                TFol.Text = DR[0].ToString();
                                if (DR[2].ToString() != "")
                                {
                                    lMon.SelectedValue = DR[2].ToString();
                                }
                                TcodCo.Text = DR[1].ToString();
                                LIden.Text = "Código Contable:";
                                otro.Visible = true;
                            }
                            DB.Desconectar();
                        }
                    }
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UNA FACTURA";
                Session["estPan"] = true;
            }
        }

        protected bool validarCodGL(string text)
        {
            if (!(text.IndexOf(".") < 0))
            {
                string[] puntos = text.Split('.');
                if (puntos.Length == 5)
                {
                    if (puntos[0].Length == 4 && puntos[1].Length == 4 && puntos[2].Length == 4 && puntos[3].Length == 2 && puntos[4].Length == 3)
                    {
                        bool aux = true, aux2 = true;
                        string cont = puntos[0] + puntos[1] + puntos[2];
                        string cont2 = puntos[3].ToUpper() + puntos[4].ToUpper();
                        foreach (var c in cont)
                        {
                            if (!(c >= '0' && c <= '9'))
                            {
                                aux = false;
                            }
                        }

                        foreach (var c in cont2)
                        {
                            if (!((c >= '0' && c <= '9') || !(c >= 'a' && c <= 'z') || !(c >= 'A' && c <= 'Z')))
                            {
                                aux2 = false;
                            }
                        }

                        if (aux && aux2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            PanelBusca.Width = 20;
            PanelBusca.Height = 20;
            PanelBusca.Visible = false;
        }

        protected void Button49_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataSource1.SelectParameters["QUERY"].DefaultValue = "-";
                SqlDataSource1.SelectParameters["RFC"].DefaultValue = Session["rfcUser"].ToString();
                SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
                SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["rfcUser"].ToString();
                SqlDataSource1.SelectParameters["PI"].DefaultValue = " ";
                SqlDataSource1.DataBind();
                gvFacturas.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            string consulta = "";
            DT.Clear();
            if (Tuuid.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "UD" + Tuuid.Text + separador; }
                else { consulta = "UD" + Tuuid.Text + separador; }
            }
            if (Tfol2.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "FA" + Tfol2.Text + separador; }
                else { consulta = "FA" + Tfol2.Text + separador; }
            }
            if (Tprov.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RS" + Tprov.Text + separador; }
                else { consulta = "RS" + Tprov.Text + separador; }
            }
            if (Ttip.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "TP" + Ttip.Text + separador; }
                else { consulta = "TP" + Ttip.Text + separador; }
            }
            if (Tser.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "SE" + Tser.Text + separador; }
                else { consulta = "SE" + Tser.Text + separador; }
            }
            if (Tmon.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "MN" + Tmon.Text + separador; }
                else { consulta = "MN" + Tmon.Text + separador; }
            }
            if (Ttot.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "TL" + Ttot.Text + separador; }
                else { consulta = "TL" + Ttot.Text + separador; }
            }
            if (Tcod.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "GL" + Tcod.Text + separador; }
                else { consulta = "GL" + Tcod.Text + separador; }
            }
            if (consulta.Length != 0)
            {
                consulta = consulta.Substring(0, consulta.Length - 1);
                try
                {
                    SqlDataSource1.SelectParameters["QUERY"].DefaultValue = consulta;
                    SqlDataSource1.SelectParameters["RFC"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
                    SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource1.SelectParameters["PI"].DefaultValue = " ";
                    SqlDataSource1.DataBind();
                    gvFacturas.DataBind();
                }
                catch (Exception ex)
                {
                }
            }
            PanelBusca.Width = 20;
            PanelBusca.Height = 20;
            PanelBusca.EnableViewState = false;
            PanelBusca.Visible = false;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (ChackSabCom.Checked)
            {
                LbusId.Text = "No. Sabana:";
            }
            else
            {
                LbusId.Text = "Código GL:";
            }
            PanelBusca.Width = 600;
            PanelBusca.Height = 350;
            PanelBusca.EnableViewState = true;
            PanelBusca.Visible = true;
        }

        protected void butonBus_Click(object sender, EventArgs e)
        {
            string consulta = "";
            DT.Clear();
            if (Tuuid.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "UD" + Tuuid.Text + separador; }
                else { consulta = "UD" + Tuuid.Text + separador; }
            }
            if (Tfol2.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "FA" + Tfol2.Text + separador; }
                else { consulta = "FA" + Tfol2.Text + separador; }
            }
            if (Tprov.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RS" + Tprov.Text + separador; }
                else { consulta = "RS" + Tprov.Text + separador; }
            }
            if (Ttip.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "TP" + Ttip.Text + separador; }
                else { consulta = "TP" + Ttip.Text + separador; }
            }
            if (Tser.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "SE" + Tser.Text + separador; }
                else { consulta = "SE" + Tser.Text + separador; }
            }

            if (Tmon.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "MN" + Tmon.Text + separador; }
                else { consulta = "MN" + Tmon.Text + separador; }
            }

            if (Ttot.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "TL" + Ttot.Text + separador; }
                else { consulta = "TL" + Ttot.Text + separador; }
            }
            if (ChackSabCom.Checked)
            {
                if (Tcod.Text.Length != 0)
                {
                    if (consulta.Length != 0) { consulta = consulta + "NS" + Tcod.Text + separador; }
                    else { consulta = "NS" + Tcod.Text + separador; }
                }
            }
            else
            {
                if (Tcod.Text.Length != 0)
                {
                    if (consulta.Length != 0) { consulta = consulta + "GL" + Tcod.Text + separador; }
                    else { consulta = "GL" + Tcod.Text + separador; }
                }
            }
            if (consulta.Length != 0)
            {
                try
                {
                    if (ChackSabCom.Checked)
                    {
                        SqlDataSource2.SelectParameters["QUERY"].DefaultValue = consulta;
                        SqlDataSource2.SelectParameters["RFC"].DefaultValue = Session["rfcUser"].ToString();
                        SqlDataSource2.SelectParameters["ESTADO"].DefaultValue = " ";
                        SqlDataSource2.SelectParameters["MODULO"].DefaultValue = " ";
                        SqlDataSource2.SelectParameters["PI"].DefaultValue = "OTM|";
                        SqlDataSource2.DataBind();
                        gvFacturas2.DataBind();
                    }
                    else
                    {
                        SqlDataSource1.SelectParameters["QUERY"].DefaultValue = consulta;
                        SqlDataSource1.SelectParameters["RFC"].DefaultValue = Session["rfcUser"].ToString();
                        SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
                        SqlDataSource1.SelectParameters["MODULO"].DefaultValue = " ";
                        SqlDataSource1.SelectParameters["PI"].DefaultValue = "ORACLE|REN|";
                        SqlDataSource1.DataBind();
                        gvFacturas.DataBind();
                    }
                }
                catch (Exception ex)
                {
                }
                consulta = "";
            }
            PanelBusca.Width = 20;
            PanelBusca.Height = 20;
            PanelBusca.Visible = false;
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Documentos.aspx");
        }

        protected void ChackSabCom_CheckedChanged(object sender, EventArgs e)
        {
            if (ChackSabCom.Checked)
            {
                PaneFa.Visible = false;
                try
                {
                    SqlDataSource2.SelectParameters["QUERY"].DefaultValue = "-";
                    SqlDataSource2.SelectParameters["RFC"].DefaultValue = Session["rfcUser"].ToString();
                    SqlDataSource2.SelectParameters["ESTADO"].DefaultValue = " ";
                    SqlDataSource2.SelectParameters["MODULO"].DefaultValue = " ";
                    SqlDataSource2.SelectParameters["PI"].DefaultValue = "OTM|";
                    SqlDataSource2.DataBind();
                    gvFacturas2.DataBind();
                }
                catch (Exception ex)
                {
                    tbSerie.Text = ex.ToString();
                }
                PaneOt.Visible = true;
            }
            else
            {
                PaneFa.Visible = true;
                PaneOt.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            vAddPagos.Hide();
            Session["id"] = (object)null;
        }

        protected string EmisorRFC(string file)
        {
            string str1 = "";
            XmlDocument xmlDocument = new XmlDocument();
            string str2 = "cfdi:";
            bool flag = true;
            try
            {
                xmlDocument.Load(file);
                XmlTextReader xmlTextReader = new XmlTextReader((TextReader)new StringReader(xmlDocument.OuterXml));
                string str3;
                XmlNodeList elementsByTagName;
                if ((uint)xmlDocument.GetElementsByTagName(str2 + "Comprobante").Count > 0U)
                {
                    str3 = "cfdi:";
                    elementsByTagName = xmlDocument.GetElementsByTagName(str3 + "Comprobante");
                    flag = true;
                }
                else
                {
                    str3 = "";
                    elementsByTagName = xmlDocument.GetElementsByTagName("Comprobante");
                    flag = false;
                }
                string str4 = "";
                XPathNavigator navigator = new XPathDocument((XmlReader)xmlTextReader).CreateNavigator();
                navigator.MoveToFollowing(XPathNodeType.Element);
                foreach (string key in (IEnumerable<string>)navigator.GetNamespacesInScope(XmlNamespaceScope.All).Keys)
                    str4 = key;
                foreach (XmlElement xmlElement1 in elementsByTagName)
                {
                    foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(str3 + "Emisor"))
                        str1 = xmlElement2.GetAttribute("rfc");
                }
                return str1;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "logErrorNEW\\ErrorCOM.txt";
                try { System.IO.File.Delete(path); }
                catch { }

                var fileName = (HttpPostedFile)Session["bytesXML"];
                var fileNamePDF = (HttpPostedFile)Session["bytesPDF"];
                DB.Conectar();
                DB.CrearComando("SELECT dirtxt,dirdocs,dirrespaldo from ParametrosSistema");
                DbDataReader dbDataReader1 = DB.EjecutarConsulta();
                dbDataReader1.Read();
                arc = dbDataReader1[0].ToString();
                pdf = dbDataReader1[1].ToString();
                bck = dbDataReader1[2].ToString();
                DB.Desconectar();
                if (fileName.ContentLength < 2097152 && fileNamePDF.ContentLength < 2097152)
                {
                    string nameXML = fileName.FileName.ToString().Replace("&", "_").Replace("#", "").Replace("+", "").Trim();
                    string namePDF = fileNamePDF.FileName.ToString().Replace("&", "_").Replace("#", "").Replace("+", "").Trim();
                    var lower = Path.GetExtension(fileName.FileName.ToString()).ToUpper();
                    var PDFext = Path.GetExtension(fileNamePDF.FileName.ToString()).ToUpper();
                    if (lower.ToUpper().Equals(".XML") && PDFext.ToUpper().Equals(".PDF"))
                    {
                        try
                        {
                            var bytesXML = PostedFileToBytesB(fileName);
                            var bytesPDF = PostedFileToBytesB(fileNamePDF);
                            SaveData(arc + "manual\\" + nameXML.Replace(" ", ""), bytesXML);
                            SaveData(arc + "manual\\" + namePDF.Replace(" ", ""), bytesPDF);

                            if (new FileInfo(pdf + (DateTime.Today.ToString("yyyy/MM/dd").Replace("/", "\\") + "\\") + EmisorRFC(arc + "manual\\" + nameXML.Replace(" ", "")).Replace("&", "_") + "\\" + nameXML.Replace(" ", "")).Exists)
                            {
                                lblMsg.Text = "Ya existe un Complemento de Pago con mismo nombre";
                                msjError.Visible = true;
                            }
                            else
                            {
                                lblMsg.Text += "Procesando.....";
                                FAC = new Facturas(Directory.GetFiles(arc + "manual\\"), bck, pdf, arc + "manual\\", "", Session["id_usuario"].ToString());
                                FAC.readComplementoPaid(arc + "manual\\" + nameXML.Replace(" ", ""), arc + "manual\\" + namePDF.Replace(" ", ""), pdf);
                                lblMsg.Text = FAC.getmsgarrayLog();
                            }
                        }
                        catch (Exception ex)
                        {
                            lblMsg.Text = "No se pudieron validar los archivos ";
                            msjError.Visible = true;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Extension de archivo no reconocida";
                        msjError.Visible = true;
                    }
                }
                else
                {
                    msjError.Text = "El tamaño de cada uno de los archivos excede 2 MB";
                    msjError.Visible = true;
                }
                #region MSJ COMPLETE ERROR READ
                if (File.Exists(path))
                {
                    string str = File.ReadAllText(path);
                    msjError.Visible = true;
                    msjError.Text = str;
                    try { File.Delete(path); }
                    catch { }
                }
                #endregion
            }
            catch (Exception es)
            {
                msjError.Visible = true;
                msjError.Text = "Error al cargar archivos";
            }

        }

        protected void btPagos_Click(object sender, EventArgs e)
        {
            string[] strArray1 = new string[5]
      {
        "á",
        "é",
        "í",
        "ó",
        "ú"
      };
            DateTime now = DateTime.Now;
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string valor = now.ToString("dddd");
            DB.Conectar();
            DB.CrearComando("select habilitado, horaIni, horaFin,dia,Proveedores from diasOperacion where dia=@dia");
            DB.AsignarParametroCadena("@dia", valor);
            DbDataReader dbDataReader = DB.EjecutarConsulta();
            if (dbDataReader.Read())
            {
                str1 = dbDataReader[0].ToString();
                str2 = dbDataReader[1].ToString();
                str3 = dbDataReader[2].ToString();
                str4 = dbDataReader[3].ToString();
                str5 = dbDataReader[4].ToString();
            }
            DB.Desconectar();
            if (str1 == "Si")
            {
                string[] strArray2 = str2.Split(':');
                string[] strArray3 = str3.Split(':');
                int int32_1 = Convert.ToInt32(strArray2[0]);
                int int32_2 = Convert.ToInt32(strArray3[0]);
                if (now.TimeOfDay >= new TimeSpan(int32_1, 0, 0) && now.TimeOfDay <= new TimeSpan(int32_2, 0, 0) && valor.Contains(str4))
                {
                    if (str5.IndexOf(Session["proveedorTipe"].ToString()) >= 0)
                    {
                        vAddPagos.Show();
                    }
                    else
                    {
                        Session["estNot"] = (object)false;
                        Session["msjNoti"] = (object)("LOS PROVEEDORES DE " + Session["proveedorTipe"].ToString() + " <br/> NO PUEDEN CARGAR COMPLEMENTOS DE PAGO CFDI ESTE DÍA ");
                        Session["estPan"] = (object)true;
                    }
                }
                else
                {
                    Session["estNot"] = (object)false;
                    Session["msjNoti"] = (object)"SOLO PUEDES CARGAR COMPLEMENTOS DE PAGO CFDI LOS DIAS LUNES EN UN HORARIO DE 8:00 AM A 8:00 PM";
                    Session["estPan"] = (object)true;
                }
            }
            else
            {
                Session["estNot"] = (object)false;
                Session["msjNoti"] = (object)"SOLO PUEDES CARGAR COMPLEMENTOS DE PAGO CFDI LOS DIAS LUNES EN UN HORARIO DE 8:00 AM A 8:00 PM";
                Session["estPan"] = (object)true;
            }
        }

        protected void btComplementoPago_Click(object sender, EventArgs e)
        {
            this.idComplemento = ((LinkButton)sender).CommandArgument;
            this.SqlDataSourceCPago.SelectParameters["QUERY"].DefaultValue = "-";
            this.SqlDataSourceCPago.SelectParameters["SiO"].DefaultValue = this.idComplemento;
            this.SqlDataSourceCPago.DataBind();
            this.gvComplementoPago.DataBind();
            LoadImportesComplemento(idComplemento);
            this.vPaymentComplement.Show();
        }

        protected void blClosePayment_Click(object sender, EventArgs e)
        {
            this.vPaymentComplement.Hide();
        }

        protected void gvFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            try
            {
                var idPago = "";
                LinkButton control1 = (LinkButton)e.Row.FindControl("btPagos");
                HiddenField control2 = (HiddenField)e.Row.FindControl("checkMP");
                HiddenField control3 = (HiddenField)e.Row.FindControl("checkHdID");
                if (control2.Value.Equals("PPD"))
                {
                    control1.Visible = true;
                    DB.Conectar();
                    DB.CrearComando(@"select idPagoRelacion from RelacionPago where id_factura=idfactura ");
                    DB.AsignarParametroCadena(@"idfactura", control3.Value);
                    var dr = DB.EjecutarConsulta();
                    if (dr.Read())
                    {
                        idPago = dr[0].ToString();
                    }
                    DB.Desconectar();
                    if (!string.IsNullOrEmpty(idPago))
                    {
                        control1.Style["background-color"] = "#9FF781";
                        control1.Style["border-color"] = "green";
                        control1.Style["border"] = "1px solid #133b01";
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void LoadImportesComplemento(string idFac)
        {
            try
            {
                DB.Conectar();
                DB.CrearComando("select MAX(impSaldoAnt), SUM(impPagado), MIN(impSaldoInsoluto) from RelacionPago where id_factura=@idFac");
                DB.AsignarParametroCadena("@idFac", idFac);
                DbDataReader DRV = DB.EjecutarConsulta();
                if (DRV.Read())
                {
                    tbResT.Text = DRV[0].ToString();
                    tbPagT.Text = DRV[1].ToString();
                    tbTotal.Text = DRV[2].ToString();
                }
                DB.Desconectar();
                if (string.IsNullOrEmpty(tbResT.Text))
                {
                    DB.Conectar();
                    DB.CrearComando("select TOTAL from GENERAL where idfactura=@idFac");
                    DB.AsignarParametroCadena("@idFac", idFac);
                    DRV = DB.EjecutarConsulta();
                    if (DRV.Read())
                    {
                        tbResT.Text = DRV[0].ToString();
                        tbPagT.Text = "0.00";
                        tbTotal.Text = DRV[0].ToString();
                    }
                    DB.Desconectar();
                }
            }
            catch (Exception ex)
            {
                tbResT.Text = "0.00";
                tbPagT.Text = "0.00";
                tbTotal.Text = "0.00";
            }
        }

        protected void fuXML_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                Session["bytesXML"] = fuXML.PostedFile;
            }
            catch (Exception es) { }
        }

        protected void fuPDF_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                Session["bytesPDF"] = fuPDF.PostedFile;
            }
            catch (Exception es) { }
        }

        private byte[] PostedFileToBytesB(HttpPostedFile file)
        {
            byte[] result = null;
            try
            {
                var stream = file.InputStream;
                var output = new MemoryStream();
                stream.Position = 0;
                stream.CopyTo(output);
                result = output.ToArray();
            }
            catch { }
            return result;
        }

        protected bool SaveData(string FileName, byte[] Data)
        {
            BinaryWriter Writer = null;
            string Name = FileName;
            try
            {
                Writer = new BinaryWriter(File.OpenWrite(Name));
                Writer.Write(Data);
                Writer.Flush();
                Writer.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        protected void bGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                var RFCREC = Session["rfcUser"].ToString();
                var _count = 0;
                if (Convert.ToDateTime(tbFechaIni.Text).ToString("yyyyMMdd") != "" && Convert.ToDateTime(tbFechaFin.Text).ToString("yyyyMMdd") != "")
                {
                    if (Convert.ToDateTime(tbFechaIni.Text).ToString("yyyyMMdd") != "")
                    {
                        if (Convert.ToDateTime(tbFechaFin.Text).ToString("yyyyMMdd") != "")
                        {
                            fecha = Convert.ToDateTime(tbFechaIni.Text).ToString("yyyyMMdd");

                            fechanom = Convert.ToDateTime(tbFechaFin.Text).ToString("yyyyMMdd");

                            fechacreacion = System.DateTime.Now.ToString("yyyyMMddHHmm");
                            auxRuta = @"reportes\docs\" + fechacreacion;
                            dir = System.AppDomain.CurrentDomain.BaseDirectory + auxRuta;
                            var _virtualDir = auxRuta + RFCREC + ".xlsx";
                            var nameFile = fechacreacion + RFCREC + ".xlsx";
                            where += " CONVERT(VARCHAR(MAX),General.fechaRec,112) >= " + Convert.ToDateTime(tbFechaIni.Text).ToString("yyyyMMdd") + " AND CONVERT(VARCHAR(MAX),General.fechaRec,112) <=" + Convert.ToDateTime(tbFechaFin.Text).ToString("yyyyMMdd") + " AND Proveedores.rfc=" + "'" + RFCREC + "'";
                            try
                            {
                                var periodo = Convert.ToDateTime(tbFechaIni.Text).ToString("yyyyMMdd") + " - " + Convert.ToDateTime(tbFechaFin.Text).ToString("yyyyMMdd");
                                DB.Conectar();
                                DB.CrearComando(@"select count(general.idfactura) from GENERAL inner join CFDI ON cfdi.id_Factura = general.idfactura inner join Proveedores ON Proveedores.idProveedor = GENERAL.idProv WHERE " + where);

                                var dr = DB.EjecutarConsulta();
                                if (dr.Read())
                                {
                                    _count = Convert.ToInt32(dr[0]);
                                }
                                DB.Desconectar();
                                if (_count > 0)
                                {
                                    WebServiceReport.GenerarReporte Generar = new WebServiceReport.GenerarReporte();
                                    try
                                    {
                                        Generar.GeneraReporte("", dir, fecha, fechanom, DropRep.SelectedValue, where, "", id, auxRuta, "prove", RFCREC);


                                        var ruta = dir + RFCREC + ".xlsx"; ;
                                        System.IO.FileInfo toDownload = new System.IO.FileInfo(ruta);



                                        Response.Redirect(_virtualDir/*@"docs\" + fechacreacion + ".xlsx"*/, false);

                                        btnCancel(null, null);

                                    }
                                    catch (Exception ex)
                                    {
                                        lErrorCalendar.Visible = true;
                                        lErrorCalendar.Text = "error con datos del reporte";
                                    }
                                }
                                else
                                {
                                    lErrorCalendar.Visible = true;
                                    lErrorCalendar.Text = "No hay registros para este tipo de reporte";
                                }
                            }
                            catch (Exception ex)
                            {
                                lErrorCalendar.Visible = true;
                                lErrorCalendar.Text = "Error al generar el reporte";
                            }
                        }
                        else
                        {
                            lErrorCalendar.Visible = true;
                            lErrorCalendar.Text = "Selecciona fecha Final";
                        }
                    }
                    else
                    {
                        lErrorCalendar.Visible = true;
                        lErrorCalendar.Text = "Selecciona fecha Inicial";
                    }
                }
                else
                {
                    lErrorCalendar.Visible = true;
                    lErrorCalendar.Text = "Selecciona fecha";
                }
            }
            catch (Exception ea) { Label1.Text = ea.Message; }
        }

        protected void btnCancel(object sender, EventArgs e)
        {
            vReports.Hide();
        }

        protected void lbReports_Click(object sender, EventArgs e)
        {
            vReports.Show();
        }

    }
}
