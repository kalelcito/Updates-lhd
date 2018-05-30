using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LoadXls;
using Datos;

namespace DataExpressWeb
{
    public partial class RegistrosXLS : System.Web.UI.Page
    {
        #region Variables
        List<KeyValuePair<OracleRecord, string>> records = new List<KeyValuePair<OracleRecord, string>>();
        #endregion

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
            if (!IsPostBack)
            {
                GridView7.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/subirXLS.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistrosXLS.aspx");
        }

        protected void btnEnviar_registros_Click(object sender, EventArgs e)
        {
            List<OracleRecord> listOracle = new List<OracleRecord>();
            Proceso process = new Proceso();
            foreach (GridViewRow row in GridView7.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chck = row.FindControl("chkValidar") as CheckBox;
                    if (chck.Checked == true)
                    {
                        string id_Registro = row.Cells[19].Text;
                        string RECORD_TYPE = row.Cells[1].Text;
                        string INVOICE_NUM = row.Cells[2].Text;
                        string SUPPLIER_NUM = row.Cells[3].Text;
                        string INVOICE_DATE = row.Cells[4].Text;
                        string INVOICE_CURR = row.Cells[5].Text;
                        string CURRENCY_RATE = row.Cells[6].Text;
                        string INVOICE_AMOUNT = row.Cells[7].Text;
                        string No_inv_Detail = row.Cells[8].Text;
                        string Num = row.Cells[9].Text;
                        string UUID_CFDI = row.Cells[10].Text;
                        string Supplier_Num2 = row.Cells[11].Text;
                        string MontoTotal = row.Cells[12].Text;
                        string Moneda = row.Cells[13].Text;
                        string TipCamb = row.Cells[14].Text;
                        string No_inv_detail2 = row.Cells[15].Text;
                        string Type_Tax = row.Cells[16].Text;
                        string CC = row.Cells[17].Text;
                        string Amount = row.Cells[18].Text;

                        var record = new OracleRecord
                        {
                            RowNumber = "0",
                            RecordType = row.Cells[1].Text.Replace("&nbsp;",""),
                            InvoiceNum = row.Cells[2].Text.Replace("&nbsp;", ""),
                            SupplierNum = row.Cells[3].Text.Replace("&nbsp;", ""),
                            InvoiceDate = row.Cells[4].Text.Replace("&nbsp;", ""),
                            InvoiceCurr = row.Cells[5].Text.Replace("&nbsp;", ""),
                            CurrencyRate = row.Cells[6].Text.Replace("&nbsp;", ""),
                            InvoiceAmount = row.Cells[7].Text.Replace("&nbsp;", ""),
                            NoInvDetail = row.Cells[8].Text.Replace("&nbsp;", ""),
                            Num = row.Cells[9].Text.Replace("&nbsp;", ""),
                            UuidCfdi = row.Cells[10].Text.Replace("&nbsp;", ""),
                            SupplierNum2 = row.Cells[11].Text.Replace("&nbsp;", ""),
                            MontoTotal = row.Cells[12].Text.Replace("&nbsp;", ""),
                            Moneda = row.Cells[13].Text.Replace("&nbsp;", ""),
                            TipCamb = row.Cells[14].Text.Replace("&nbsp;", ""),
                            NoInvDetail2 = row.Cells[15].Text.Replace("&nbsp;", ""),
                            TypeTax = row.Cells[16].Text.Replace("&nbsp;", ""),
                            Cc = row.Cells[17].Text.Replace("&nbsp;", ""),
                            Amount = row.Cells[18].Text.Replace("&nbsp;", "")
                        };
                        if (!string.IsNullOrEmpty(record.RecordType) && !string.IsNullOrEmpty(record.InvoiceNum))
                        {
                            listOracle.Add(record);
                        }
                        BasesDatos BD = new BasesDatos();
                        BD.Conectar();
                        BD.CrearComando(@"UPDATE Registros_pendientes_Oracle set estado=1 where idRegistro=@idRegistro");
                        BD.AsignarParametroCadena("@idRegistro", id_Registro);
                        BD.EjecutarConsulta();
                        BD.Desconectar();
                    }
                }
            }
            process.WriteApproved(listOracle);
            GridView7.DataBind();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/menuReceDHL/InterfazOracle.aspx");
        }
    }
}