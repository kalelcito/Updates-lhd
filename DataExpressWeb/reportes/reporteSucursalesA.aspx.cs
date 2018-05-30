using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Control;
using System.Data.Common;

namespace DataExpressWeb
{
    public partial class reporteSucursalesA : System.Web.UI.Page
    {
        String fecha, fechanom, fechafin, fechacreacion;
        String dir, auxRuta;
        string where = "";

        int id = 0;
        String Empresa;
        String Tipo;

        private BasesDatos DB = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || Session["adm"] == null || Session["permisos"] == null)
            {
                Response.Redirect("~/Cerrar.aspx");
                ddlPtoEmi.Items.Clear();
            }
            else if (Convert.ToBoolean(Session["adm"]) == false)
            {
                Response.Redirect("~/Documentos.aspx");
                ddlPtoEmi.Items.Clear();
            }
        }

        public Boolean validarDatos(string fechaI, string fechaF)
        {
            DB.Conectar();
            DB.CrearComando("SELECT GENERAL.folio, GENERAL.folio, GENERAL.fechaRec FROM GENERAL WHERE General.fechaRec>=@fechaInicial AND General.fechaRec<=@fechaFinal");
            DB.AsignarParametroCadena("@fechaInicial", fechaI);
            DB.AsignarParametroCadena("@fechaFinal", fechaF);
            DbDataReader DR = DB.EjecutarConsulta();

            while (DR.Read())
            {
                DB.Desconectar();
                return true;
            }
            DB.Desconectar();

            return false;
        }
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                String Fecha;
                if (tbFechaIni.Text != "" && tbFechaFin.Text != "")
                {
                    if (tbFechaIni.Text != "")
                    {
                        if (tbFechaFin.Text != "")
                        {
                            fecha = tbFechaIni.Text;

                            fechanom = tbFechaFin.Text;

                            fechacreacion = System.DateTime.Now.ToString("yyyyMMddHHmm");

                            auxRuta = @"reportes\docs\" + fechacreacion;
                            dir = System.AppDomain.CurrentDomain.BaseDirectory + auxRuta;
                            where += " CONVERT(VARCHAR(MAX),General.fechaRec,112) >= " + "'" + Convert.ToDateTime(fecha).ToString("yyyyMMdd") + "'" + " AND CONVERT(VARCHAR(MAX),General.fechaRec,112) <=" + "'" + Convert.ToDateTime(fechanom).ToString("yyyyMMdd") + "'" + " AND ";
                            if (DropRep.SelectedValue == "GENERAL")
                            {
                                Label3.Visible = true;
                                ddlPtoEmi.Visible = true;
                                if (ddlPtoEmi.SelectedValue != "0")
                                {
                                    where += " receptorCFDI.razonSoc='" + ddlPtoEmi.SelectedValue + "' AND ";
                                }
                            }
                            else
                            {
                                Label3.Visible = false;
                                ddlPtoEmi.Visible = false;
                            }
                            DB.Conectar();
                            DB.CrearComandoProcedimiento("DHL_spRegistroReportes");
                            DB.AsignarParametroProcedimiento("@prmTipo", System.Data.DbType.String, DropRep.SelectedItem.ToString());
                            DB.AsignarParametroProcedimiento("@prmEmpresa", System.Data.DbType.String, ddlPtoEmi.SelectedItem.ToString());
                            DB.AsignarParametroProcedimiento("@prmPeriodo", System.Data.DbType.String, tbFechaIni.Text + " - " + tbFechaFin.Text);
                            DbDataReader DR2 = DB.EjecutarConsulta();
                            if (DR2.Read())
                            {
                                id = Convert.ToInt32(DR2[0]);
                                Tipo = DR2[1].ToString();
                                Empresa = DR2[2].ToString();
                            }
                            DB.Desconectar();

                            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate (object sender1,
                             System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                             System.Security.Cryptography.X509Certificates.X509Chain chain,
                             System.Net.Security.SslPolicyErrors sslPolicyErrors)
                            {
                                return true;
                            }; // éstas líneas son para realizar la transacción con protocolo https
                            WebServiceReport.GenerarReporte Generar = new WebServiceReport.GenerarReporte();
                            try
                            {
                                new System.Threading.Thread(() =>
                                {
                                    Generar.GeneraReporteAsync("", dir, fecha, fechanom, DropRep.SelectedValue, where, ddlPtoEmi.SelectedValue, id, auxRuta, "admin", "");
                                }).Start();

                                Session["estNot"] = true;
                                Session["msjNoti"] = "GENERANDO REPORTE";
                                Session["estPan"] = true;

                            }
                            catch (Exception ex)
                            {
                                Session["estNot"] = false;
                                Session["msjNoti"] = "NO ES POSIBLE CONECTAR CON EL SERVIDOR";
                                Session["estPan"] = true;
                            }

                            //RepSucursal reporteSuc = new RepSucursal(sucursal, dir, fecha, fechanom, DropRep.SelectedValue, where, ddlPtoEmi.SelectedValue);  
                            //if (reporteSuc.getError() != null)
                            //{
                            //    Response.Redirect(@"docs\" + fechacreacion + ".xlsx", false);
                            //}
                            //else
                            //{
                            //    Label1.Text = reporteSuc.getError();
                            //}

                            gdvReportes.DataBind();

                        }
                        else { lErrorCalendar.Text = "Selecciona fecha Final"; }
                    }
                    else { lErrorCalendar.Text = "Selecciona fecha Inicial"; }
                }
                else { lErrorCalendar.Text = "Selecciona fecha"; }
            }
            catch (Exception ea) { Label1.Text = ea.Message; }
        }
    }
}