﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data.Common;
using System.Data;
using System.Drawing;
using Control;
using System.Configuration;
using AjaxControlToolkit;
using System.IO;
using System.Web.ApplicationServices;
using System.Xml;
using System.Xml.XPath;
using DataExpressWeb.wsRetenciones;

namespace DataExpressWeb
{
    public partial class Formulario_web127 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        private DataTable DT = new DataTable();
        EnviarMail em;
        string modulo = "";
        string rfcEmisor = "";
        static string idres = "", auxFol = "";
        private String separador = "|";
        String LOG_AditionaFILES = AppDomain.CurrentDomain.BaseDirectory + @"log\Error " + System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").Replace("T", "_").Replace("-", "_").Substring(0, 10) + ".txt";

        private string arc;
        private string pdf;
        private string bck;
        private Facturas FAC;
        private BasesDatos DB = new BasesDatos();
        private string usuario = "";
        private string idComplemento;

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
            this.SqlDataSourceCPago.ConnectionString = ConfigurationManager.AppSettings.Get("CADENA_CONEXION");
        }

        protected bool update(string band)
        {
            try
            {

                BD.Conectar();
                BD.CrearComando("UPDATE GENERAL SET estatus=@val,fechaUltimCam=@fecUl,fechaRechazo=@fecrec,causaRechazo=@cau where idFactura=@fact");
                BD.AsignarParametroCadena("@val", band);
                BD.AsignarParametroCadena("@fact", auxFol);
                BD.AsignarParametroFecha("@fecUl", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                BD.AsignarParametroCadena("@fecrec", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                if (band == "rechazado")
                {
                    BD.AsignarParametroCadena("@cau", Tbrechazar.Text);
                }
                else
                {
                    BD.AsignarParametroCadena("@cau", tbcausa.Text);
                }
                BD.EjecutarConsulta();
                BD.Desconectar();
                return true;
            }
            catch (Exception h)
            {
                return false;
            }
        }

        protected void bgrab_Click(object sender, EventArgs e)
        {

            if (update("cancelado"))
            {
                idres = "";
                //Response.Redirect("~/MenuNuevo.aspx");
                Session["estNot"] = true;
                Session["msjNoti"] = "FACTURA CANCELADA";
                Session["estPan"] = true;
                Pcancelar.Width = 10;
                Pcancelar.Height = 10;
                Pcancelar.Visible = false;
                tbcausa.Text = "";
                auxFol = "";
            }
            else
            {

                Session["estNot"] = false;
                Session["msjNoti"] = "PROBLEMAS AL CANCELAR";
                Session["estPan"] = true;
            }

        }

        protected string llenar()
        {
            string fol = "";
            string dat = "";
            foreach (GridViewRow row in gvFacturas.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                if (chk_Seleccionar.Checked)
                {

                    fol = hd_Seleccionafol.Value;
                    auxFol = hd_Seleccionafol.Value;
                    BD.Conectar();
                    BD.CrearComando("select NOMEMI as proveedor,serie,folio from GENERAL inner join EMISOR on EMISOR.IDEEMI = GENERAL.id_Emisor where GENERAL.idFactura=@id");
                    BD.AsignarParametroCadena("@id", fol);
                    DbDataReader DR = BD.EjecutarConsulta();
                    if (DR.Read())
                    {
                        dat += DR[0].ToString() + "|";
                        dat += DR[1].ToString();
                        dat += "|" + DR[2].ToString();
                    }
                    BD.Desconectar();
                }
            }
            return dat;


        }

        protected void Button46_Click(object sender, EventArgs e)
        {
            //click rechazar
            if (update("rechazado"))
            {
                idres = "";
                //Response.Redirect("~/MenuNuevo.aspx");
                Session["estNot"] = true;
                Session["msjNoti"] = "FACTURA RECHAZADA";
                Session["estPan"] = true;
                Prechazar.Width = 10;
                Prechazar.Height = 10;
                Prechazar.Visible = false;
                Tbrechazar.Text = "";
                auxFol = "";
                Response.Redirect("~/menuReceDHL/ComprobantesOTM.aspx");
            }
            else
            {

                Session["estNot"] = false;
                Session["msjNoti"] = "PROBLEMAS AL CANCELAR";
                Session["estPan"] = true;
            }
        }

        protected void Button50_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/menuReceDHL/ComprobantesOTM.aspx");
        }

        protected void Button51_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/menuReceDHL/ComprobantesOTM.aspx");
        }

        protected void gvFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvFacturas.SelectedRow;
            idres = Convert.ToString(gvFacturas.DataKeys[row.RowIndex].Value);
        }


        protected void Button3_Click(object sender, EventArgs e)
        {

            SqlDataSource1.SelectParameters["QUERY"].DefaultValue = "-";
            SqlDataSource1.SelectParameters["RFC"].DefaultValue = " ";
            SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = "validado|";
            SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["empresas"].ToString();
            SqlDataSource1.SelectParameters["PI"].DefaultValue = "OTM|";
            SqlDataSource1.DataBind();
            gvFacturas.DataBind();
            //modulo = modulo.Trim('|');
            //try
            //{
            //    BD.Conectar();
            //    BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
            //    BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
            //    BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
            //    BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "valido|");
            //    BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, Session["empresas"]);

            //    DT.Load(BD.EjecutarConsulta());
            //    BD.Desconectar();
            //}
            //catch (Exception ex)
            //{
            //    // tbSerie.Text = ex.ToString();
            //}

            //gvFacturas.DataSourceID = null;
            //gvFacturas.DataSource = DT;
            //gvFacturas.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectParameters["QUERY"].DefaultValue = "-";
            SqlDataSource1.SelectParameters["RFC"].DefaultValue = " ";
            SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = "en proceso de pago|";
            SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["empresas"].ToString();
            SqlDataSource1.SelectParameters["PI"].DefaultValue = "OTM|";
            SqlDataSource1.DataBind();
            gvFacturas.DataBind();

            //modulo = modulo.Trim('|');
            //try
            //{
            //    BD.Conectar();
            //    BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
            //    BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
            //    BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
            //    BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "proceso|");
            //    BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, Session["empresas"]);
            //    DT.Load(BD.EjecutarConsulta());
            //    BD.Desconectar();
            //}
            //catch (Exception ex)
            //{
            //    // tbSerie.Text = ex.ToString();
            //}

            //gvFacturas.DataSourceID = null;
            //gvFacturas.DataSource = DT;
            //gvFacturas.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            SqlDataSource1.SelectParameters["QUERY"].DefaultValue = "-";
            SqlDataSource1.SelectParameters["RFC"].DefaultValue = " ";
            SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = "rechazado|";
            SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["empresas"].ToString();
            SqlDataSource1.SelectParameters["PI"].DefaultValue = "OTM|";
            SqlDataSource1.DataBind();
            gvFacturas.DataBind();
            //modulo = modulo.Trim('|');
            //try
            //{
            //    BD.Conectar();
            //    BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
            //    BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
            //    BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
            //    BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "rechazado|");
            //    BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, Session["empresas"]);
            //    DT.Load(BD.EjecutarConsulta());
            //    BD.Desconectar();
            //}
            //catch (Exception ex)
            //{
            //    // tbSerie.Text = ex.ToString();
            //}

            //gvFacturas.DataSourceID = null;
            //gvFacturas.DataSource = DT;
            //gvFacturas.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            SqlDataSource1.SelectParameters["QUERY"].DefaultValue = "-";
            SqlDataSource1.SelectParameters["RFC"].DefaultValue = " ";
            SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = "cancelado|";
            SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["empresas"].ToString();
            SqlDataSource1.SelectParameters["PI"].DefaultValue = "OTM|";
            SqlDataSource1.DataBind();
            gvFacturas.DataBind();
            //modulo = modulo.Trim('|');
            //try
            //{
            //    BD.Conectar();
            //    BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
            //    BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
            //    BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
            //    BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "cancelado|");
            //    BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, Session["empresas"]);
            //    DT.Load(BD.EjecutarConsulta());
            //    BD.Desconectar();
            //}
            //catch (Exception ex)
            //{
            //    // tbSerie.Text = ex.ToString();
            //}

            //gvFacturas.DataSourceID = null;
            //gvFacturas.DataSource = DT;
            //gvFacturas.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectParameters["QUERY"].DefaultValue = "-";
            SqlDataSource1.SelectParameters["RFC"].DefaultValue = " ";
            SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
            SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["empresas"].ToString();
            SqlDataSource1.SelectParameters["PI"].DefaultValue = "OTM|";
            SqlDataSource1.DataBind();
            gvFacturas.DataBind();

            //modulo = modulo.Trim('|');
            //try
            //{
            //    BD.Conectar();
            //    BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
            //    BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
            //    BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
            //    BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "");
            //    BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, Session["empresas"]);

            //    DT.Load(BD.EjecutarConsulta());
            //    BD.Desconectar();
            //}
            //catch (Exception ex)
            //{
            //    // tbSerie.Text = ex.ToString();
            //}

            //gvFacturas.DataSourceID = null;
            //gvFacturas.DataSource = DT;
            //gvFacturas.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            string consulta = "";
            DT.Clear();
            if (Tfol.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "UD" + Tfol.Text + separador; }
                else { consulta = "UD" + Tfol.Text + separador; }
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
            //---------------------------Busqueda por fecha
            //if (!calFechaAnterior.SelectedDate.ToString("yyyyMMdd").Equals("00010101") &&
            //    !calFechaFin.SelectedDate.ToString("yyyyMMdd").Equals("00010101")
            //    )
            //{
            //    if (consulta.Length != 0) { consulta = consulta + "DA" + calFechaAnterior.SelectedDate.ToString("yyyyMMdd") + separador; }
            //    else { consulta = "DA" + calFechaAnterior.SelectedDate.ToString("yyyyMMdd") + separador; }
            //}
            //if (!calFechaFin.SelectedDate.ToString("yyyyMMdd").Equals("00010101") &&
            //    !calFechaAnterior.SelectedDate.ToString("yyyyMMdd").Equals("00010101")
            //    )
            //{
            //    if (consulta.Length != 0) { consulta = consulta + "DF" + calFechaFin.SelectedDate.ToString("yyyyMMdd") + separador; }
            //    else { consulta = "DF" + calFechaFin.SelectedDate.ToString("yyyyMMdd") + separador; }
            //}



            if (consulta.Length != 0)
            {
                //if (((String)Session["coFactTodas"])=="") { miSucursal = "S---"; } else { miSucursal = (String)Session["sucursalUser"]; }
                // miSucursal = "S---";
                consulta = consulta.Substring(0, consulta.Length - 1);

                //tbSerie.Text=
                //facturasTodas = (String)Session["coFactTodas"];
                //try
                //{

                //    BD.Conectar();
                //    BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
                //    BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, consulta);
                //    BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
                //    BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "");
                //    BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, Session["empresas"]);
                //    DT.Load(BD.EjecutarConsulta());
                //    BD.Desconectar();
                //}
                //catch (Exception ex)
                //{

                //}
                SqlDataSource1.SelectParameters["QUERY"].DefaultValue = consulta;
                SqlDataSource1.SelectParameters["RFC"].DefaultValue = " ";
                SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
                SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["empresas"].ToString();
                SqlDataSource1.SelectParameters["PI"].DefaultValue = "OTM|";
                SqlDataSource1.DataBind();
                gvFacturas.DataBind();

                //gvFacturas.DataSourceID = null;
                //gvFacturas.DataSource = DT;
                //gvFacturas.DataBind();
                consulta = "";

            }
            PanelBusca.Width = 20;
            PanelBusca.Height = 20;
            PanelBusca.EnableViewState = false;
            PanelBusca.Visible = false;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            //------------cancelar
            bool si = false;
            foreach (GridViewRow row in gvFacturas.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                Pcancelar.Width = 435;
                Pcancelar.Height = 240;
                string[] datos = llenar().Split('|');

                Lcancel1.Text = datos[0];
                Lcancel2.Text = datos[1];
                Lcancel3.Text = datos[2];
                Pcancelar.Visible = true;
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UNA FACTURA";
                Session["estPan"] = true;
            }

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            PanelBusca.Width = 425;
            PanelBusca.Height = 320;
            PanelBusca.EnableViewState = true;
            PanelBusca.Visible = true;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            //-----------ver   rechazar
            bool si = false;
            foreach (GridViewRow row in gvFacturas.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                Prechazar.Width = 430;
                Prechazar.Height = 235;
                string[] datos = llenar().Split('|');

                Lrechazar1.Text = datos[0];
                Lrechazar2.Text = datos[1];
                Lrechazar3.Text = datos[2];
                Prechazar.Visible = true;
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UNA FACTURA";
                Session["estPan"] = true;
            }

        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            PanelBusca.Width = 20;
            PanelBusca.Height = 20;
            PanelBusca.EnableViewState = false;
            PanelBusca.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool si = false;
            foreach (GridViewRow row in gvFacturas.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                Peditar.Width = 430;
                Peditar.Height = 270;
                foreach (GridViewRow row in gvFacturas.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        auxFol = hd_Seleccionafol.Value;

                        BD.Conectar();
                        BD.CrearComando("select serie, folio, CodCont,correoContac, Moneda from General where idFactura=@id");
                        BD.AsignarParametroCadena("@id", auxFol);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Labelser.Text = DR[0].ToString();
                            Labelfol.Text = DR[1].ToString();
                            Textgl.Text = DR[2].ToString();
                            Textcorreo.Text = DR[3].ToString();
                            if (DR[4].ToString() != "")
                            {
                                DropListMon.SelectedValue = DR[4].ToString();
                            }
                            Peditar.Visible = true;
                        }
                        BD.Desconectar();
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

        protected void Button14_Click(object sender, EventArgs e)
        {
            BD.Conectar();
            BD.CrearComando("update General set CodCont=@cod, correoContac=@corr, Moneda=@mon where idFactura=@fac");
            BD.AsignarParametroCadena("@cod", Textgl.Text);
            BD.AsignarParametroCadena("@corr", Textcorreo.Text);
            BD.AsignarParametroCadena("@mon", DropListMon.SelectedValue);
            BD.AsignarParametroCadena("@fac", auxFol);
            BD.EjecutarConsulta();
            BD.Desconectar();
            Peditar.Width = 20;
            Peditar.Height = 20;
            Peditar.EnableViewState = false;
            Peditar.Visible = false;
            auxFol = "";
            Response.Redirect("~/menuReceDHL/ComprobantesOTM.aspx");

        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Peditar.Width = 20;
            Peditar.Height = 20;
            Peditar.EnableViewState = false;
            Peditar.Visible = false;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            //-------------ver panel adicionales---------------
            bool si = false;
            foreach (GridViewRow row in gvFacturas.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                PdocAdi.Width = 480;
                PdocAdi.Height = 355;
                string dia1 = "", habi = "", hi = "", hf = "";
                foreach (GridViewRow row in gvFacturas.Rows)
                {
                    try
                    {
                        CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                        HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                        if (chk_Seleccionar.Checked)
                        {
                            idres = hd_Seleccionafol.Value;
                            BD.Conectar();
                            BD.CrearComando(@"select serie, folio,receptorCFDI.razonSoc, Emisor.NOMEMI from General INNER JOIN
                           Emisor ON General.id_Emisor = Emisor.IDEEMI INNER JOIN 
		                   receptorCFDI ON General.id_Receptor = receptorCFDI.idreceptorCFDI  where idFactura=@id");
                            BD.AsignarParametroCadena("@id", idres);
                            DbDataReader DR8 = BD.EjecutarConsulta();
                            if (DR8.Read())
                            {
                                Tdocadiemi.Text = DR8[3].ToString();
                                Tdocadirec.Text = DR8[2].ToString();
                                Tdocadiser.Text = DR8[0].ToString();
                                Tdocadifol.Text = DR8[1].ToString();
                            }
                            BD.Desconectar();


                            BD.Conectar();
                            BD.CrearComando("select ADIARC,NOMARC,NOMBRE from documentosAdicionales where IDEFAC=@id");
                            BD.AsignarParametroCadena("@id", idres);
                            DT.Load(BD.EjecutarConsulta());
                            BD.Desconectar();

                            GridView6.DataSourceID = null;
                            GridView6.DataSource = DT;
                            GridView6.DataBind();


                            PdocAdi.Visible = true;
                        }
                    }

                    catch (Exception ex)
                    {
                        Session["estNot"] = false;
                        Session["msjNoti"] = "HAY UN ERROR AL CONSULTAR EL ARCHIVO ADICIONAL";
                        Session["estPan"] = true;
                        anade_linea_archivo(LOG_AditionaFILES, "Error " + ex.ToString());
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

        protected void Button15_Click(object sender, EventArgs e)
        {
            PdocAdi.Width = 20;
            PdocAdi.Height = 20;
            idres = "";
            PdocAdi.Visible = false;
        }

        protected void HyperLink12_Click(object sender, EventArgs e)
        {
            //---------ver panel subir facturas-------------
            Psubirfact.Height = 175;
            Psubirfact.Width = 425;
            Psubirfact.Visible = true;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //---------cancelar subir--------------
            Psubirfact.Height = 20;
            Psubirfact.Width = 20;
            Psubirfact.Visible = false;
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            //----------------subir factura----------
            Session["proveedorTipe"] = DropCargar.SelectedValue;
            Session["adSub"] = "Admin";
            Session["identificador"] = "Creado por el Administrador";
            Response.Redirect("~/validarFacturas.aspx");
        }

        protected void Button49_Click(object sender, EventArgs e)
        {
            string consulta = "";
            DT.Clear();
            if (Tfol.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "UD" + Tfol.Text + separador; }
                else { consulta = "UD" + Tfol.Text + separador; }
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
                if (consulta.Length != 0) { consulta = consulta + "NS" + Tcod.Text + separador; }
                else { consulta = "NS" + Tcod.Text + separador; }
            }
            if (!tbFechaIni.Text.Equals("") && !tbFechaFin.Text.Equals(""))
            {
                String fechaIni = tbFechaIni.Text.Replace("/", "");
                if (consulta.Length != 0) { consulta = consulta + "DA" + fechaIni + separador; }
                else { consulta = "DA" + fechaIni + separador; }
            }
            if (!tbFechaFin.Text.Equals("") && !tbFechaIni.Text.Equals(""))
            {
                String fechaFin = tbFechaFin.Text.Replace("/", "");
                if (consulta.Length != 0) { consulta = consulta + "DF" + fechaFin + separador; }
                else { consulta = "DF" + fechaFin + separador; }
            }

            if (consulta.Length != 0)
            {
                consulta = consulta.Substring(0, consulta.Length - 1);

                SqlDataSource1.SelectParameters["QUERY"].DefaultValue = consulta;
                SqlDataSource1.SelectParameters["RFC"].DefaultValue = " ";
                SqlDataSource1.SelectParameters["ESTADO"].DefaultValue = " ";
                SqlDataSource1.SelectParameters["MODULO"].DefaultValue = Session["empresas"].ToString();
                SqlDataSource1.SelectParameters["PI"].DefaultValue = "OTM|";
                SqlDataSource1.DataBind();
                gvFacturas.DataBind();
                consulta = "";

            }
            PanelBusca.Width = 20;
            PanelBusca.Height = 20;
            PanelBusca.EnableViewState = false;
            PanelBusca.Visible = false;
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            bool si = false;
            foreach (GridViewRow row in gvFacturas.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                foreach (GridViewRow row in gvFacturas.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("UPDATE GENERAL SET estatus=@val,fechaUltimCam=@fecUl where idFactura=@fact");
                        BD.AsignarParametroCadena("@val", "en proceso de pago");
                        BD.AsignarParametroFecha("@fecUl", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                        BD.AsignarParametroCadena("@fact", idres);
                        BD.EjecutarConsulta();
                        BD.Desconectar();

                        enviarM(idres, "", "pago");

                        idres = "";
                        Response.Redirect("~/menuReceDHL/ComprobantesFiscales.aspx");
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

        protected void enviarM(string id, string cau, string mot)
        {
            string folio = "", serie = "", correo = "";
            BD.Conectar();
            BD.CrearComando(@"select GENERAL.folio, GENERAL.serie, Proveedores.correo from GENERAL inner join Proveedores 
                             on GENERAL.idProv=Proveedores.idProveedor where GENERAL.idFactura=@id");
            BD.AsignarParametroCadena("@id", id);
            DbDataReader DR = BD.EjecutarConsulta();
            if (DR.Read())
            {
                folio = DR[0].ToString();
                serie = DR[1].ToString();
                correo = DR[2].ToString();
            }
            BD.Desconectar();

            if (correo != "")
            {
                string servidor = "", emailCredencial = "", passCredencial = "", emailEnviar = "", emailNoti = "", rutaDOC = "";
                bool ssl = false;
                int puerto = 0;
                BD.Conectar();
                BD.CrearComando("select servidorSMTP,puertoSMTP,sslSMTP,userSMTP,passSMTP,dirdocs,emailEnvio,emailNotificacion from ParametrosSistema");
                DbDataReader DR1 = BD.EjecutarConsulta();

                if (DR1.Read())
                {
                    servidor = DR1[0].ToString();
                    puerto = Convert.ToInt32(DR1[1].ToString());
                    ssl = Convert.ToBoolean(DR1[2].ToString());
                    emailCredencial = DR1[3].ToString();
                    passCredencial = DR1[4].ToString();
                    rutaDOC = DR1[5].ToString();
                    emailEnviar = DR1[6].ToString();
                    emailNoti = DR1[7].ToString();
                }
                BD.Desconectar();


                string mensaje = "";
                string asunto = "";
                DateTime fech = DateTime.Today;
                if (correo.Length > 5)
                {
                    em = new EnviarMail();
                    em.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);
                    if (mot != "pago")
                    {
                        asunto = "Comprobante " + mot;
                        mensaje = @"Buen dia! <br>
                               El comprobante con folio: " + folio + "y serie:" + serie + " ha sido " + mot + ".";
                        mensaje += "<br>la causa es la siguiente:";
                        mensaje += cau;
                        mensaje += "<br><br><br>Saludos cordiales. ";
                    }
                    else
                    {
                        asunto = "Comprobante a proceso de pago";
                        mensaje = @"Buen dia! <br>
                               El comprobante con folio: " + folio + "y serie:" + serie;
                        mensaje += "<br>ha cambiado su estado a proceso de pago";
                        mensaje += "<br><br><br>Saludos cordiales. ";

                    }

                    em.llenarEmail(emailEnviar, correo, "", "", asunto, mensaje);
                    em.enviarEmail();
                }

            }
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
                var fileName = (HttpPostedFile)Session["grupo"];         //.PostedFile.FileName;  
                var fileNamePDF = (HttpPostedFile)Session["nivelRol"];       //.PostedFile.FileName;
                this.DB.Conectar();
                this.DB.CrearComando("SELECT dirtxt,dirdocs,dirrespaldo from ParametrosSistema");
                DbDataReader dbDataReader1 = this.DB.EjecutarConsulta();
                dbDataReader1.Read();
                arc = dbDataReader1[0].ToString();
                pdf = dbDataReader1[1].ToString();
                bck = dbDataReader1[2].ToString();
                this.DB.Desconectar();
                if (fileName.ContentLength < 2097152 && fileNamePDF.ContentLength < 2097152)
                {
                    string nameXML = fileName.FileName.ToString().Replace("&", "_").Replace("#", "").Replace("+", "").Trim();
                    string namePDF = fileNamePDF.FileName.ToString().Replace("&", "_").Replace("#", "").Replace("+", "").Trim();
                    string lower = Path.GetExtension(fileName.FileName.ToString()).ToLower();
                    var PDFext = Path.GetExtension(fileNamePDF.FileName.ToString()).ToLower();
                    if (Path.GetExtension(fileName.FileName.ToString()).ToUpper().Equals(".XML") || Path.GetExtension(fileNamePDF.FileName.ToString()).ToUpper().Equals(".PDF"))
                    {
                        try
                        {
                            File.WriteAllBytes(arc + "manual\\" + nameXML.Replace(" ", ""), PostedFileToBytesB(fileName));
                            File.WriteAllBytes(arc + "manual\\" + namePDF.Replace(" ", ""), PostedFileToBytesB(fileNamePDF));
                            if (new FileInfo(pdf + (DateTime.Today.ToString("yyyy/MM/dd").Replace("/", "\\") + "\\") + this.EmisorRFC(this.arc + "manual\\" + nameXML.Replace(" ", "")).Replace("&", "_") + "\\" + nameXML.Replace(" ", "")).Exists)
                            {
                                this.lblMsg.Text = "Ya existe un archivo similar";
                                msjError.Visible = true;
                            }
                            else
                            {
                                this.lblMsg.Text += "Procesando.....";
                                this.FAC = new Facturas(Directory.GetFiles(this.arc + "manual\\"), this.bck, this.pdf, this.arc + "manual\\", "", this.Session["id_usuario"].ToString());
                                this.FAC.readComplementoPaid(arc + "manual\\" + nameXML.Replace(" ", ""), arc + "manual\\" + namePDF.Replace(" ", ""), pdf);
                                this.lblMsg.Text = this.FAC.getmsgarrayLog();
                            }
                        }
                        catch (Exception ex)
                        {
                            this.lblMsg.Text = "No se pudieron validar los archivos " + ex.ToString();
                            msjError.Visible = true;
                            // (Master as SiteMaster).MostrarAlerta(this, "No se pudieron validar los archivos<br/><br/>" + ex, 4, null);
                        }
                    }
                    else
                    {
                        this.lblMsg.Text = "Extension de archivo no reconocida";
                        msjError.Visible = true;
                        //   (Master as SiteMaster).MostrarAlerta(this, "Extension de archivo no reconocida<br/><br/>", 4, null);
                    }
                }
                else
                {
                    msjError.Text = "El tamaño de cada uno de los archivos excede 2 MB";
                    msjError.Visible = true;
                    //      (Master as SiteMaster).MostrarAlerta(this, "El tamaño de cada uno de los archivos excede 2 MB<br/><br/>", 4, null);
                }

                #region MSJ COMPLETE ERROR READ
                string path = AppDomain.CurrentDomain.BaseDirectory + "logErrorNEW\\ErrorCOM.txt";
                if (File.Exists(path))
                {
                    string str = File.ReadAllText(path);
                    msjError.Visible = true;
                    msjError.Text = str;
                    //(Master as SiteMaster).MostrarAlerta(this, str, 4, null);
                    try { File.Delete(path); }
                    catch { }
                }
                #endregion
            }
            catch (Exception es)
            {
                msjError.Visible = true;
                msjError.Text = "Error al cargar archivos";
                // TextBox2.Text = "Error al cargar archivos";
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
            this.DB.Conectar();
            this.DB.CrearComando("select habilitado, horaIni, horaFin,dia,Proveedores from diasOperacion where dia=@dia");
            this.DB.AsignarParametroCadena("@dia", valor);
            DbDataReader dbDataReader = this.DB.EjecutarConsulta();
            if (dbDataReader.Read())
            {
                str1 = dbDataReader[0].ToString();
                str2 = dbDataReader[1].ToString();
                str3 = dbDataReader[2].ToString();
                str4 = dbDataReader[3].ToString();
                str5 = dbDataReader[4].ToString();
            }
            this.DB.Desconectar();
            if (str1 == "Si")
            {
                string[] strArray2 = str2.Split(':');
                string[] strArray3 = str3.Split(':');
                int int32_1 = Convert.ToInt32(strArray2[0]);
                int int32_2 = Convert.ToInt32(strArray3[0]);
                if (now.TimeOfDay >= new TimeSpan(int32_1, 0, 0) && now.TimeOfDay <= new TimeSpan(int32_2, 0, 0) && valor.Contains(str4))
                {
                    //if (str5.IndexOf(this.Session["proveedorTipe"].ToString()) >= 0)
                    //{
                    this.vAddPagos.Show();
                    //}
                    //else
                    //{
                    //    this.Session["estNot"] = (object)false;
                    //    this.Session["msjNoti"] = (object)("LOS PROVEEDORES DE " + this.Session["proveedorTipe"].ToString() + " <br/> NO PUEDEN CARGAR COMPLEMENTOS DE PAGO CFDI ESTE DÍA ");
                    //    this.Session["estPan"] = (object)true;
                    //}
                }
                else
                {
                    this.Session["estNot"] = (object)false;
                    this.Session["msjNoti"] = (object)"SOLO PUEDES CARGAR COMPLEMENTOS DE PAGO CFDI LOS DIAS LUNES EN UN HORARIO DE 8:00 AM A 8:00 PM";
                    this.Session["estPan"] = (object)true;
                }
            }
            else
            {
                this.Session["estNot"] = (object)false;
                this.Session["msjNoti"] = (object)"SOLO PUEDES CARGAR COMPLEMENTOS DE PAGO CFDI LOS DIAS LUNES EN UN HORARIO DE 8:00 AM A 8:00 PM";
                this.Session["estPan"] = (object)true;
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
                lblMsg.Text = "";
                msjError.Text = "";
                Session["grupo"] = fuXML.PostedFile;
            }
            catch (Exception es) { }
        }

        protected void fuPDF_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                Session["nivelRol"] = fuPDF.PostedFile;
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

        public static void anade_linea_archivo(string archivo, string linea)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"log"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"log");
            }
            using (StreamWriter w = File.AppendText(archivo))
            {
                w.WriteLine(linea.Replace(Environment.NewLine, ""));
                w.Flush();
                w.Close();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.vAddPagos.Hide();
            this.Session["id"] = (object)null;
        }

        protected void lbRetencion_Click(object sender, EventArgs e)
        {
            int procesadas = 0;
            int totales = 0;
            string mensajes = "";
            int checks = rowsChecked();
            if (checks < 1)
            {
                mensajes += "Debes seleccionar al menos un comprobante de ingresos" + Environment.NewLine;
            }
            else
            {
                foreach (GridViewRow row in gvFacturas.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    Label lbl_Retenciones = (Label)row.FindControl("Label12");
                    Label lbl_UUID = (Label)row.FindControl("Label5");
                    Label lblRet = (Label)row.FindControl("lblRet");
                    if (chk_Seleccionar.Checked)
                    {
                        totales++;
                        if (!string.IsNullOrEmpty(hd_Seleccionafol.Value))
                        {
                            if (string.IsNullOrEmpty(lblRet.Text) || lblRet.Text.Equals("0"))
                            {
                                float retValue;
                                if (!string.IsNullOrEmpty(lbl_Retenciones.Text) && float.TryParse(lbl_Retenciones.Text, out retValue) && retValue > 0)
                                {
                                    var ObjMyService = new wsRetenciones.Retenciones();
                                    var correo = Session["correo"] != null ? Session["correo"].ToString() : "";
                                    var result = ObjMyService.retencionFactura(hd_Seleccionafol.Value, correo);
                                    if (result != null)
                                    {
                                        procesadas++;
                                    }
                                }
                                else
                                {
                                    mensajes += "El comprobante \"" + lbl_UUID.Text + "\" no tiene retenciones." + Environment.NewLine;
                                }
                            }
                            else
                            {
                                mensajes += "El comprobante \"" + lbl_UUID.Text + "\" ya tiene retención vinculada." + Environment.NewLine;
                            }
                        }
                        else
                        {
                            mensajes += "El comprobante \"" + lbl_UUID.Text + "\" no tiene folio." + Environment.NewLine;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(mensajes))
            {
                pnlAviso.Style["height"] = "280px";
                Session["msjNoti"] = mensajes;
                var titulo = "<center><strong>Se procesaron " + procesadas + " de " + totales + " comprobantes seleccionados</strong></center>";
                var msg = ("<ul style='padding-left:10px;'><li>" + mensajes.Replace(Environment.NewLine, "</li><li>") + "</li></ul>").Replace("<li></li>", "");
                lblMsgAviso.Text = (titulo + "<br>" + msg);
                SqlDataSource1.DataBind();
                gvFacturas.DataBind();
                UpdatePanel1.Update();
                mpeAviso.Show();
            }
            else
            {
                pnlAviso.Style["height"] = "100px";
                var titulo = "<center><strong>Se procesaron " + procesadas + " de " + totales + " comprobantes seleccionados</strong></center>";
                lblMsgAviso.Text = (titulo);
                SqlDataSource1.DataBind();
                gvFacturas.DataBind();
                UpdatePanel1.Update();
                mpeAviso.Show();
            }
        }

        private int rowsChecked()
        {
            int counter = 0;
            foreach (GridViewRow row in gvFacturas.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                {
                    counter++;
                }
            }
            return counter;
        }


    }
}