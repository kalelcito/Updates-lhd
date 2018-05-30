using System;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.Linq;
using Datos;
using LoadXls;
using System.Collections.Generic;

namespace DataExpressWeb
{
    public partial class subirXLS : System.Web.UI.Page
    {
        Proceso loadxls = new Proceso();
        static ArrayList Array_registros;
        string[] registro;
        string[] registro_error;
        DataTable table = new DataTable("Tabla1");
        DataTable table_error = new DataTable("TablaErrores");
        static int id_Renglon = 0;
        bool uuidPermiso = false;
        static List<KeyValuePair<OracleRecord, string>> records = new List<KeyValuePair<OracleRecord, string>>();
        static string NombreInterfaz = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["permisos"].ToString().Contains("PermiUUID|"))
                {
                    uuidPermiso = true;
                }
            }
            catch (Exception ex) { }

                if (!IsPostBack)
                {
                    table_error.Clear();
                    if (table.Columns.Count == 0)
                    {
                        generar_tabla();
                    }

                    if (records.Count > 0)
                    {
                        generar_tabla_errores(records);
                    }
                }
            }
        
 
        protected void can_Click(object sender, EventArgs e)
        {
            records.Clear();
            Response.Redirect("~/menuReceDHL/interfazOracle.aspx");
        }

        protected void bSubir_Click(object sender, EventArgs e)
        {
            table_error.Clear();
            generar_tabla_errores(records);
            bool bandExtranjero = false;
            if (CheckExtranjero.Checked == true) { bandExtranjero = true; }
            if (examAdi.HasFile)
            {
                lMsj.Visible = false;
                string extencion = System.IO.Path.GetExtension(examAdi.FileName).ToLower();
                if (extencion == ".xls" || extencion == ".xlsx")
                {
                    string rutaXLS = ConfigurationManager.AppSettings.Get("RutaXLS");
                    examAdi.PostedFile.SaveAs(rutaXLS + examAdi.FileName);
                    try
                    {
                        records = loadxls.Iniciar(rutaXLS + examAdi.FileName, bandExtranjero, uuidPermiso);
                        NombreInterfaz = loadxls.GetOutputName();
                    }
                    catch (Exception ex) { }
                    if (records.Count > 0)
                    {
                        lberrorResgistros.Font.Bold = true;
                       //btnEnviar_registros.Visible = true;
                        lberrorResgistros.Visible = true;
                        generar_tabla_errores(records);
                    }
                    lMsj.Text = "El archivo se ha cargado";
                    lMsj.ForeColor = System.Drawing.Color.Green;
                    lMsj.Visible = true;
                }
                else
                {
                    lMsj.Text = "El archivo seleccionado no es compatible con Excel";
                    lMsj.Visible = true;
                }
            }
            else
            {
                lMsj.Text = "Debe seleccionar un archivo";
                lMsj.Visible = true;
            }
        }

        protected void CrearXls_click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            PanelTITULO.Visible = true;
            PanelXsl.Visible = true;
            Array_registros = new ArrayList();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            PanelTITULO.Visible = false;
            PanelXsl.Visible = false;
            gvRegistros.DataSource = null;
            gvRegistros.DataBind();
            id_Renglon = 0;
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            registro = new string[19];
            registro[0] = id_Renglon.ToString();
            id_Renglon++;
            registro[1] = tb1.Text; registro[2] = tb2.Text; registro[3] = tb3.Text; registro[4] = tb4.Text; registro[5] = tb5.Text; registro[6] = tb6.Text;
            registro[7] = tb7.Text; registro[8] = tb8.Text; registro[9] = tb9.Text; registro[10] = tb10.Text; registro[11] = tb11.Text; registro[12] = tb12.Text;
            registro[13] = tb13.Text; registro[14] = tb14.Text; registro[15] = tb15.Text; registro[16] = tb16.Text; registro[17] = tb17.Text; registro[18] = tb18.Text;
            try
            {
                if (table.Rows.Count == 0) { generar_tabla(); }
                Array_registros.Add(registro);
            }
            catch (Exception ex) { }

            if (Array_registros.Count > 0)
            {
                LinkButton lb = new LinkButton();
                foreach (string[] registro in Array_registros)
                {
                    DataRow row = table.NewRow();
                    row["No"] = registro[0];
                    row["Record_Type"] = registro[1];
                    row["INVOICE NUM"] = registro[2];
                    row["SUPPLIER NUM"] = registro[3];
                    row["INVOICE DATE"] = registro[4];
                    row["INVOICE CURR"] = registro[5];
                    row["Currency_Rate"] = registro[6];
                    row["INVOICE AMOUNT"] = registro[7];
                    row["No inv Detail"] = registro[8];
                    row["Num"] = registro[9];
                    row["UUID_CFDI"] = registro[10];
                    row["Supplier Num"] = registro[11];
                    row["MontoTotal"] = registro[12];
                    row["Moneda"] = registro[13];
                    row["TipCamb"] = registro[14];
                    row["No inv detail"] = registro[15];
                    row["TYPE_TAX"] = registro[16];
                    row["CC"] = registro[17];
                    row["Amount"] = registro[18];
                    table.Rows.Add(row);
                    gvRegistros.DataSource = table;
                    gvRegistros.DataBind();
                }
            }
            ClientScript.RegisterStartupScript(GetType(), "LimpiaCajas", "limpia();", true);
            lMsj2.Visible = false;
        }

        #region Metodo Generar con HTML
        //protected void btnGenerarArchivo_Click(object sender, EventArgs e)
        //{
        //-------------------  LLENAR DATA TABLE QUE SE MANDA A EXCEL ----------------------
        //    DataTable table2 = new DataTable("Tabla2");
        //    table2.Columns.Add(new DataColumn("Record_Type", typeof(string)));
        //    table2.Columns.Add(new DataColumn("INVOICE NUM", typeof(string)));
        //    table2.Columns.Add(new DataColumn("SUPPLIER NUM", typeof(string)));
        //    table2.Columns.Add(new DataColumn("INVOICE DATE", typeof(string)));
        //    table2.Columns.Add(new DataColumn("INVOICE CURR", typeof(string)));
        //    table2.Columns.Add(new DataColumn("Currency_Rate", typeof(string)));
        //    table2.Columns.Add(new DataColumn("INVOICE AMOUNT", typeof(string)));
        //    table2.Columns.Add(new DataColumn("No inv Detail", typeof(string)));
        //    table2.Columns.Add(new DataColumn("Num", typeof(string)));
        //    table2.Columns.Add(new DataColumn("UUID_CFDI", typeof(string)));
        //    table2.Columns.Add(new DataColumn("Supplier Num", typeof(string)));
        //    table2.Columns.Add(new DataColumn("MontoTotal", typeof(string)));
        //    table2.Columns.Add(new DataColumn("Moneda", typeof(string)));
        //    table2.Columns.Add(new DataColumn("TipCamb", typeof(string)));
        //    table2.Columns.Add(new DataColumn("No inv detail", typeof(string)));
        //    table2.Columns.Add(new DataColumn("TYPE_TAX", typeof(string)));
        //    table2.Columns.Add(new DataColumn("CC", typeof(string)));
        //    table2.Columns.Add(new DataColumn("Amount", typeof(string)));

        //    foreach (string[] registro in Array_registros)
        //    {
        //        DataRow row = table2.NewRow();

        //        row["Record_Type"] = registro[0];
        //        row["INVOICE NUM"] = registro[1];
        //        row["SUPPLIER NUM"] = registro[2];
        //        row["INVOICE DATE"] = registro[3];
        //        row["INVOICE CURR"] = registro[4];
        //        row["Currency_Rate"] = registro[5];
        //        row["INVOICE AMOUNT"] = registro[6];
        //        row["No inv Detail"] = registro[7];
        //        row["Num"] = registro[8];
        //        row["UUID_CFDI"] = registro[9];
        //        row["Supplier Num"] = registro[10];
        //        row["MontoTotal"] = registro[11];
        //        row["Moneda"] = registro[12];
        //        row["TipCamb"] = registro[13];
        //        row["No inv detail"] = registro[14];
        //        row["TYPE_TAX"] = registro[15];
        //        row["CC"] = registro[16];
        //        row["Amount"] = registro[17];
        //        table2.Rows.Add(row);
        //    }
        //------------------- FIN LLENAR DATA TABLE QUE SE MANDA A EXCEL ----------------------

        //---------------------  ENVIAR DATA TABLE A EXCEL --------------------------------
        //    if (table2.Rows.Count > 0)
        //    {
        //        string rutaXLS= ConfigurationManager.AppSettings.Get("RutaXLS");
        //        string filename = "OracleExcel.xls";
        //        System.IO.StringWriter tw = new System.IO.StringWriter();
        //        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        //        DataGrid dgGrid = new DataGrid();
        //        dgGrid.DataSource = table2;
        //        dgGrid.DataBind();

        //        //Get the HTML for the control.
        //        dgGrid.RenderControl(hw);

        //        string renderedTable = tw.ToString();
        //        System.IO.File.WriteAllText(rutaXLS+filename, renderedTable);

        //        //----------------------Descarga de Navegador------------------------------
        //        //Response.ContentType = "application/vnd.ms-excel";
        //        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
        //        //this.EnableViewState = false;
        //        //Response.Write(tw.ToString());
        //        //Response.End();
        //        //----------------------Descarga de Navegador------------------------------
        //    }
        //    else
        //    {
        //        lMsj2.Text = "No hay datos para generar archivo";
        //        lMsj2.Visible = true;
        //    }
        //------------------------------ FIN ENVIAR DATA TABLE A EXCEL ---------------------------------
        //}
        #endregion

        protected void btnGenerarArchivo_Click(object sender, EventArgs e)
        {
            bool bandExtranjero = false;
            if (CheckExtranjero.Checked == true) { bandExtranjero = true; }

            if (Array_registros.Count > 0)
            {
                DataTable table2 = new DataTable("Tabla2");
                table2.Columns.Add(new DataColumn("Record_Type", typeof(string)));
                table2.Columns.Add(new DataColumn("INVOICE NUM", typeof(string)));
                table2.Columns.Add(new DataColumn("SUPPLIER NUM", typeof(string)));
                table2.Columns.Add(new DataColumn("INVOICE DATE", typeof(string)));
                table2.Columns.Add(new DataColumn("INVOICE CURR", typeof(string)));
                table2.Columns.Add(new DataColumn("Currency_Rate", typeof(string)));
                table2.Columns.Add(new DataColumn("INVOICE AMOUNT", typeof(string)));
                table2.Columns.Add(new DataColumn("No inv Detail", typeof(string)));
                table2.Columns.Add(new DataColumn("Num", typeof(string)));
                table2.Columns.Add(new DataColumn("UUID_CFDI", typeof(string)));
                table2.Columns.Add(new DataColumn("Supplier Num", typeof(string)));
                table2.Columns.Add(new DataColumn("MontoTotal", typeof(string)));
                table2.Columns.Add(new DataColumn("Moneda", typeof(string)));
                table2.Columns.Add(new DataColumn("TipCamb", typeof(string)));
                table2.Columns.Add(new DataColumn("No inv detail", typeof(string)));
                table2.Columns.Add(new DataColumn("TYPE_TAX", typeof(string)));
                table2.Columns.Add(new DataColumn("CC", typeof(string)));
                table2.Columns.Add(new DataColumn("Amount", typeof(string)));

                #region Agregar renglon extra para lectura
                DataRow row = table2.NewRow();
                row["Record_Type"] = "";
                row["INVOICE NUM"] = "";
                row["SUPPLIER NUM"] = "";
                row["INVOICE DATE"] = "";
                row["INVOICE CURR"] = "";
                row["Currency_Rate"] = "";
                row["INVOICE AMOUNT"] = "";
                row["No inv Detail"] = "";
                row["Num"] = "";
                row["UUID_CFDI"] = "";
                row["Supplier Num"] = "";
                row["MontoTotal"] = "";
                row["Moneda"] = "";
                row["TipCamb"] = "";
                row["No inv detail"] = "";
                row["TYPE_TAX"] = "";
                row["CC"] = "";
                row["Amount"] = "";
                table2.Rows.Add(row);
                #endregion


                foreach (string[] registro in Array_registros)
                {
                    DataRow row2 = table2.NewRow();
                    row2["Record_Type"] = registro[1];
                    row2["INVOICE NUM"] = registro[2];
                    row2["SUPPLIER NUM"] = registro[3];
                    row2["INVOICE DATE"] = registro[4];
                    row2["INVOICE CURR"] = registro[5];
                    row2["Currency_Rate"] = registro[6];
                    row2["INVOICE AMOUNT"] = registro[7];
                    row2["No inv Detail"] = registro[8];
                    row2["Num"] = registro[9];
                    row2["UUID_CFDI"] = registro[10];
                    row2["Supplier Num"] = registro[11];
                    row2["MontoTotal"] = registro[12];
                    row2["Moneda"] = registro[13];
                    row2["TipCamb"] = registro[14];
                    row2["No inv detail"] = registro[15];
                    row2["TYPE_TAX"] = registro[16];
                    row2["CC"] = registro[17];
                    row2["Amount"] = registro[18];
                    table2.Rows.Add(row2);
                }

                string rutaXLS = ConfigurationManager.AppSettings.Get("RutaXLS");
                string filename = "OracleExcel.xlsx";

                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Sheet1");
                var tableWithData = ws.Cell(1, 1).InsertTable(table2.AsEnumerable());
                ws.Columns().AdjustToContents();
                ws.Tables.First().ShowAutoFilter = false;
                wb.ShowZeros = true;
                wb.SaveAs(rutaXLS + filename);

                try
                {
                    records = loadxls.Iniciar(rutaXLS + filename, bandExtranjero, uuidPermiso);
                }
                catch (Exception ex) { }
                if (records.Count > 0)
                {
                    lberrorResgistros.Font.Bold = true;
                    //btnEnviar_registros.Visible = true;
                    lberrorResgistros.Visible = true;
                    generar_tabla_errores(records);
                }

                Panel2.Visible = true;
                PanelTITULO.Visible = false;
                PanelXsl.Visible = false;
                Array_registros = new ArrayList();

                lMsj.Text = "El archivo se ha cargado";
                lMsj.ForeColor = System.Drawing.Color.Green;
                lMsj.Visible = true;

                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Su archivo se vera reflejado en el portal en una maximo de 1 minuto", true);
                //Response.Redirect("~/menuReceDHL/InterfazOracle.aspx");
            }
            else
            {
                lMsj2.Text = "Necesita agregar al menos un registro";
                lMsj2.Visible = true;
            }
        }

        protected void btnEliminar_Click(object sender, GridViewCommandEventArgs e)
        {
            ArrayList Array_registros_aux = (ArrayList)Array_registros.Clone();
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "SelectRow")
            {
                foreach (string[] registro in Array_registros)
                {
                    if (registro[0].ToString() == index.ToString())
                    {
                        Array_registros_aux.Remove(registro);
                    }
                }
            }

            Array_registros = Array_registros_aux;
            if (Array_registros.Count > 0)
            {
                foreach (string[] registro in Array_registros)
                {
                    DataRow row = table.NewRow();
                    row["No"] = registro[0];
                    row["Record_Type"] = registro[1];
                    row["INVOICE NUM"] = registro[2];
                    row["SUPPLIER NUM"] = registro[3];
                    row["INVOICE DATE"] = registro[4];
                    row["INVOICE CURR"] = registro[5];
                    row["Currency_Rate"] = registro[6];
                    row["INVOICE AMOUNT"] = registro[7];
                    row["No inv Detail"] = registro[8];
                    row["Num"] = registro[9];
                    row["UUID_CFDI"] = registro[10];
                    row["Supplier Num"] = registro[11];
                    row["MontoTotal"] = registro[12];
                    row["Moneda"] = registro[13];
                    row["TipCamb"] = registro[14];
                    row["No inv detail"] = registro[15];
                    row["TYPE_TAX"] = registro[16];
                    row["CC"] = registro[17];
                    row["Amount"] = registro[18];
                    table.Rows.Add(row);
                    gvRegistros.DataSource = table;
                    gvRegistros.DataBind();
                }
            }
            else
                gvRegistros.DataBind();
        }

        //Desaparecer el renglon de indice de fila
        protected void gvRegistros_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 17)
            {
                e.Row.Cells[19].Visible = false;
            }
            // Agregar linkbutton a gridview desde codigo
            //if (e.Row.Cells.Count != 0)
            //{
            //    LinkButton lb = new LinkButton();
            //    lb.ID = "lbBooks";
            //    lb.Text = "Eliminar";
            //    e.Row.Cells[19].Controls.Add(lb);                
            //}
        }

        protected void gvRegistrosError_DataBound(object sender, GridViewRowEventArgs e)
        {
            //if (Session["permisos"] != null && !Session["permisos"].ToString().Contains("Valdif|"))
            //{
            //    if (e.Row.Cells.Count > 1)
            //    {
            //        e.Row.Cells[0].Visible = false;
            //    }
            //}
        }

        public void generar_tabla()
        {
            table.Columns.Add(new DataColumn("Record_Type", typeof(string)));
            table.Columns.Add(new DataColumn("INVOICE NUM", typeof(string)));
            table.Columns.Add(new DataColumn("SUPPLIER NUM", typeof(string)));
            table.Columns.Add(new DataColumn("INVOICE DATE", typeof(string)));
            table.Columns.Add(new DataColumn("INVOICE CURR", typeof(string)));
            table.Columns.Add(new DataColumn("Currency_Rate", typeof(string)));
            table.Columns.Add(new DataColumn("INVOICE AMOUNT", typeof(string)));
            table.Columns.Add(new DataColumn("No inv Detail", typeof(string)));
            table.Columns.Add(new DataColumn("Num", typeof(string)));
            table.Columns.Add(new DataColumn("UUID_CFDI", typeof(string)));
            table.Columns.Add(new DataColumn("Supplier Num", typeof(string)));
            table.Columns.Add(new DataColumn("MontoTotal", typeof(string)));
            table.Columns.Add(new DataColumn("Moneda", typeof(string)));
            table.Columns.Add(new DataColumn("TipCamb", typeof(string)));
            table.Columns.Add(new DataColumn("No inv detail", typeof(string)));
            table.Columns.Add(new DataColumn("TYPE_TAX", typeof(string)));
            table.Columns.Add(new DataColumn("CC", typeof(string)));
            table.Columns.Add(new DataColumn("Amount", typeof(string)));
            table.Columns.Add(new DataColumn("No", typeof(string)));
            //table.Columns.Add(new DataColumn("Borrar", typeof(string)));
        }

        public void generar_tabla_errores(List<KeyValuePair<OracleRecord, string>> records)
        {
                       
            btnEnviar_registros.Visible = false;
            ArrayList Array_registrosError = new ArrayList();
            records.GroupBy(x => x.Key.UuidCfdi).Select(grp => grp.First());

            foreach (var record in records)
            {
                registro_error = new string[3];
                registro_error[0] = record.Key.RowNumber.ToString();
                registro_error[1] = record.Key.UuidCfdi.ToString();
                registro_error[2] = record.Value.ToString();
                Array_registrosError.Add(registro_error);
            }

            if (table_error.Columns.Count == 0)
            {
                table_error.Columns.Add(new DataColumn("Renglon", typeof(string)));
                table_error.Columns.Add(new DataColumn("UUID", typeof(string)));
                table_error.Columns.Add(new DataColumn("Error", typeof(string)));
            }

            foreach (string[] registro in Array_registrosError)
            {
                DataRow row = table_error.NewRow();
                row["Renglon"] = registro[0];
                row["UUID"] = registro[1];
                row["Error"] = registro[2];
                table_error.Rows.Add(row);
                gvRegistrosError.DataSource = table_error;
                gvRegistrosError.DataBind();
                if ((registro[2].Contains("El InvoiceAmount del registro de Oracle en el xls") && registro[2].Contains("no coincide con el total del xml asociado"))
                    || (registro[2].Contains("El monto del registro de Oracle en el xls ") && registro[2].Contains("no coincide con el monto del xml asociado ")))
                {
                    btnEnviar_registros.Visible = true;
                }
            }

            if (Array_registrosError.Count == 0) { gvRegistrosError.DataBind(); lberrorResgistros.Visible = false; }
        }

        protected void btnEnviar_registros_Click(object sender, EventArgs e)
        {
            BasesDatos BD = new BasesDatos();
            List<OracleRecord> listOracle = new List<OracleRecord>();
            foreach (GridViewRow row in gvRegistrosError.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chck = row.FindControl("chkValidar") as CheckBox;
                    //if para verificar si el check del renglon esta marcado, se modifico debido al requerimiento solicitado
                    //if (chck.Checked == true)
                    //{
                        string renglon = row.Cells[1].Text;
                        string uuidSelected = row.Cells[2].Text;
                        string error = row.Cells[3].Text;

                    var lo = (from uuid in records
                                      where uuid.Key.RowNumber.Equals(renglon)
                                      //Buscar el registro por renglon y uuid
                                      //where uuid.Key.UuidCfdi.Equals(uuidSelected) && uuid.Key.RowNumber.Equals(renglon)
                                  select (uuid.Key)).ToList();
                    //Enviar los registros para escribirse en el archivo de Excel, se modifico debido al requerimiento solicitado 
                    //listOracle.AddRange(lo);
                    foreach (var reg in lo)
                    {
                        if (error.Contains("El InvoiceAmount del registro de Oracle en el xls") && error.Contains("no coincide con el total del xml asociado"))
                        {
                            try
                            {
                                BD.Conectar();
                                BD.CrearComando(@"INSERT INTO Registros_pendientes_Oracle (RECORD_TYPE,INVOICE_NUM,SUPPLIER_NUM,INVOICE_DATE,
 INVOICE_CURR,CURRENCY_RATE,INVOICE_AMOUNT,No_inv_Detail,Num,UUID_CFDI,Supplier_Num2,MontoTotal,
                                    Moneda,TipCamb,No_inv_detail2,Type_Tax,CC,Amount,NombreArchivo,estado) VALUES
(@RECORD_TYPE,@INVOICE_NUM,@SUPPLIER_NUM,@INVOICE_DATE,
 @INVOICE_CURR,@CURRENCY_RATE,@INVOICE_AMOUNT,@No_inv_Detail,@Num,@UUID_CFDI,@Supplier_Num2,@MontoTotal,
                                    @Moneda,@TipCamb,@No_inv_detail2,@Type_Tax,@CC,@Amount,@NombreArchivo,@estado)");
                                BD.AsignarParametroCadena("@RECORD_TYPE", reg.RecordType);
                                BD.AsignarParametroCadena("@INVOICE_NUM", reg.InvoiceNum);
                                BD.AsignarParametroCadena("@SUPPLIER_NUM", reg.SupplierNum);
                                BD.AsignarParametroCadena("@INVOICE_DATE", reg.InvoiceDate);
                                BD.AsignarParametroCadena("@INVOICE_CURR", reg.InvoiceCurr);
                                BD.AsignarParametroCadena("@CURRENCY_RATE", reg.CurrencyRate);
                                BD.AsignarParametroCadena("@INVOICE_AMOUNT", reg.InvoiceAmount);
                                BD.AsignarParametroCadena("@No_inv_Detail", reg.NoInvDetail);
                                BD.AsignarParametroCadena("@Num", reg.Num);
                                BD.AsignarParametroCadena("@UUID_CFDI", reg.UuidCfdi);
                                BD.AsignarParametroCadena("@Supplier_Num2", reg.SupplierNum2);
                                BD.AsignarParametroCadena("@MontoTotal", reg.MontoTotal);
                                BD.AsignarParametroCadena("@Moneda", reg.Moneda);
                                BD.AsignarParametroCadena("@TipCamb", reg.TipCamb);
                                BD.AsignarParametroCadena("@No_inv_detail2", reg.NoInvDetail2);
                                BD.AsignarParametroCadena("@Type_Tax", reg.TypeTax);
                                BD.AsignarParametroCadena("@CC", reg.Cc);
                                BD.AsignarParametroCadena("@Amount", reg.Amount);
                                BD.AsignarParametroCadena("@NombreArchivo", NombreInterfaz);
                                BD.AsignarParametroCadena("@estado", "0");
                                BD.EjecutarConsulta();
                                BD.Desconectar();
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                    //}
                }
            }
            records.Clear();
            Response.Redirect("~/menuReceDHL/InterfazOracle.aspx");
        }
    } 
}