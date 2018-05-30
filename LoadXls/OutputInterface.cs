using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Datos;
using System.Linq;
using System.Text.RegularExpressions;

namespace LoadXls
{
    public class OutputInterface
    {

        //private readonly ExcelPackage _package;
        //private readonly ExcelWorksheet _ws;
        private int _rowNumber;
        private FileInfo _file;
        private string _idInterface;
        private List<List<string>> _csv;


        private string CerosNull(string a, bool zeros = true, bool comas = false)
        {
            var result = a;
            var format = zeros ? (!comas ? "{0:0.00}" : "{0:#,##0.00}") : (!comas ? "{0:0.##}" : "{0:#,##.##}");
            var cifra = (!string.IsNullOrEmpty(result) ? result : "").Replace(",", "").Trim();
            if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(cifra))
            {
                decimal b = 0;
                if (decimal.TryParse(cifra, out b))
                {
                    result = string.Format(format, b);
                }
            }
            return result;
        }

        public OutputInterface()
        {
            _idInterface = "";
            _file = null;
            _csv = new List<List<string>>();
            //_package = new ExcelPackage();
            //_ws = _package.Workbook.Worksheets.Add("New Records");
            //Obtener los 
            //AddHeaders();
        }

        private void AddHeaders()
        {
            _rowNumber = 1;
            var _csvRow = new List<string>()
            {
                "Record_Type",
                "INVOICE NUM",
                "SUPPLIER NUM",
                "INVOICE DATE",
                "INVOICE CURR",
                "Currency_Rate",
                "INVOICE AMOUNT",
                "No inv Detail",
                "Num",
                "UUID_CFDI",
                "Supplier Num",
                "MontoTotal",
                "Moneda",
                "TipCamb",
                "No inv detail",
                "TYPE_TAX",
                "CC",
                "Amount"
            };
            _csv.Add(_csvRow);
        }

        /// <summary>
        /// Agrega a la interface los registros de Oracle indicados
        /// </summary>
        /// <param name="records">Arreglo de registros de Oracle a agregar</param>
        public void AddRecords(List<OracleRecord> records)
        {
            foreach (var record in records)
            {
                AddRecord(record);
            }
        }

        private string ReplaceMonth(string dotMonth)
        {
            var monthDate = "";
            var lower = dotMonth.ToLower().Replace(".", "");
            if (Regex.IsMatch(lower, @"ene|jan")) { monthDate = Regex.Replace(lower, @"ene|jan", "Enero"); }
            if (Regex.IsMatch(lower, @"feb")) { monthDate = Regex.Replace(lower, @"feb", "Febrero"); }
            if (Regex.IsMatch(lower, @"mar")) { monthDate = Regex.Replace(lower, @"mar", "Marzo"); }
            if (Regex.IsMatch(lower, @"abr|apr")) { monthDate = Regex.Replace(lower, @"abr|apr", "Abril"); }
            if (Regex.IsMatch(lower, @"may")) { monthDate = Regex.Replace(lower, @"may", "Mayo"); }
            if (Regex.IsMatch(lower, @"jun")) { monthDate = Regex.Replace(lower, @"jun", "Junio"); }
            if (Regex.IsMatch(lower, @"jul")) { monthDate = Regex.Replace(lower, @"jul", "Julio"); }
            if (Regex.IsMatch(lower, @"ago|aug")) { monthDate = Regex.Replace(lower, @"ago|aug", "Agosto"); }
            if (Regex.IsMatch(lower, @"sep")) { monthDate = Regex.Replace(lower, @"sep", "Septiembre"); }
            if (Regex.IsMatch(lower, @"oct")) { monthDate = Regex.Replace(lower, @"oct", "Octubre"); }
            if (Regex.IsMatch(lower, @"nov")) { monthDate = Regex.Replace(lower, @"nov", "Noviembre"); }
            if (Regex.IsMatch(lower, @"dic|dec")) { monthDate = Regex.Replace(lower, @"dic|dec", "Diciembre"); }
            return monthDate;
        }

        /// <summary>
        /// Agrega a la interface el registro de Oracle indicado
        /// </summary>
        /// <param name="record">Registro de Oracle a agregar</param>
        public void AddRecord(OracleRecord record)
        {
            try
            {
                record.Moneda = record.InvoiceCurr;
                if (record.InvoiceCurr.Equals("MXN", StringComparison.OrdinalIgnoreCase))
                {
                    record.CurrencyRate = "1";
                    record.TipCamb = "1";
                }
                if (record.Cc.Equals("40.9941.0000.1185.00.000"))
                {
                    record.TypeTax = "Y";
                }
                string invoiceDate = "";
                if (record.InvoiceDate != "")
                {
                    invoiceDate = ReplaceMonth(record.InvoiceDate);
                    try
                    {
                        invoiceDate = Convert.ToDateTime(invoiceDate).ToString("MM/dd/yyyy");
                    }
                    catch (Exception ex)
                    {
                    }
                }
                var _csvRow = new List<string>() {
                    record.RecordType,
                    record.InvoiceNum,
                    record.SupplierNum,
                    //string.IsNullOrEmpty(record.InvoiceDate)?Convert.ToDateTime(record.InvoiceDate).ToString("MM/dd/yyyy"):record.InvoiceDate,
                    invoiceDate,
                    record.InvoiceCurr,
                    record.CurrencyRate,
                    CerosNull(record.InvoiceAmount, true, false),
                    record.RecordType.Equals("2") ? "Y" : record.NoInvDetail,
                    //record.NoInvDetail,
                    record.Num,
                    !record.NoInvDetail2.Equals("Y") ? record.UuidCfdi : "",
                    !record.RecordType.Equals("1") ? record.SupplierNum2 : "",
                    !record.RecordType.Equals("1") ? CerosNull(record.MontoTotal, true, false) : "",
                    !record.RecordType.Equals("1") && !record.RecordType.Equals("3") && !record.RecordType.Equals("2") ? record.Moneda : "",
                    !record.RecordType.Equals("1") && !record.RecordType.Equals("3") && !record.RecordType.Equals("2") ? record.TipCamb : "",
                    !record.RecordType.Equals("1") ? (record.NoInvDetail2.Equals("Y") ? "Y" : "") : "",
                    !record.RecordType.Equals("1") && !record.RecordType.Equals("3") ? record.TypeTax : "",
                    !record.RecordType.Equals("1") && !record.RecordType.Equals("3") ? record.Cc : "",
                    !record.RecordType.Equals("1") && !record.RecordType.Equals("3") ? CerosNull(record.Amount, true, false) : ""
                };
                _csv.Add(_csvRow);
                _rowNumber++;
            }
            catch (Exception)
            {
                _rowNumber--;
            }
        }

        //private void Close()
        //{
        //    try
        //    {
        //        using (var range = _ws.Cells[1, 1, 1, 18])
        //        {
        //            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            range.Style.ShrinkToFit = false;
        //        }
        //        using (var range = _ws.Cells[1, 1, 1, 9])
        //        {
        //            range.Style.Font.Bold = true;
        //            range.Style.Fill.BackgroundColor.SetColor(Color.Gray);
        //            range.Style.Font.Color.SetColor(Color.Black);
        //        }
        //        using (var range = _ws.Cells[1, 9, 1, 18])
        //        {
        //            range.Style.Fill.BackgroundColor.SetColor(Color.Green);
        //            range.Style.Font.Color.SetColor(Color.Black);
        //        }
        //        for (var i = 1; i <= 18; i++)
        //        {
        //            _ws.Column(i).AutoFit();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        // ignored;
        //    }
        //}

        public string ListToCsv()
        {
            string csv = "";
            foreach (var record in _csv)
            {
                csv += string.Join(";", record) + ";"
                    //+ (record[0].Equals("4") ? ";" : "") + (record[0].Equals("1") ? ";;;;" : "")
                    + Environment.NewLine;
            }
            return csv;
        }

        /// <summary>
        /// Guarda la interfaz en disco y en la base de datos
        /// </summary>
        /// <param name="fileName">Nombre del archivo (sin ruta)</param>
        /// <param name="logFileName">Nombre del archivo log (con ruta)</param>
        /// <param name="storeDb">Guardar registro en la base de datos</param>
        /// <returns></returns>
        public bool Save(string fileName, string logFileName = null, bool storeDb = true)
        {
            var saved = true;
            var db = new BasesDatos();
            try
            {
                //Close();
                var directory = ConfigurationManager.AppSettings.Get("writeDirectory");
                Directory.CreateDirectory(directory);
                var file = new FileInfo(directory + @"\" + fileName);
                _file = file;
                var csv = ListToCsv();
                File.WriteAllText(file.FullName, csv);
                //_package.SaveAs(file);
                saved = file.Exists;
                if (storeDb)
                {
                    db.Conectar();
                    db.CrearComando(@"INSERT INTO interfazOracle(fechaEjecucion,tipo,nombreArc,numRegistros,rutaArcInterfaz,rutaArcLog) OUTPUT inserted.idInterfaz VALUES (@fechaEjecucion,@tipo,@nombreArc,@numRegistros,@rutaArcInterfaz,@rutaArcLog)");
                    db.AsignarParametroCadena("@fechaEjecucion", DateTime.Now.ToString("s"));
                    db.AsignarParametroCadena("@tipo", "Oracle");
                    db.AsignarParametroCadena("@nombreArc", file.Name);
                    db.AsignarParametroCadena("@numRegistros", ((_rowNumber.ToString()))); //> 0 ? _rowNumber - 1 : _rowNumber).ToString()));
                    db.AsignarParametroCadena("@rutaArcInterfaz", @"InterfacesOracle\" + file.Name);
                    db.AsignarParametroCadena("@rutaArcLog", !string.IsNullOrEmpty(logFileName) ? (@"InterfacesOracle\log Oracle\" + logFileName) : "");
                    var dr = db.EjecutarConsulta();
                    if (dr.Read())
                    {
                        _idInterface = dr[0].ToString();
                    }
                    else
                    {
                        throw new Exception("No se pudo guardar en la BD");
                    }
                    db.Desconectar();
                }
                saved = true;
            }
            catch (Exception)
            {
                if (db != null) { db.Desconectar(); }
                saved = false;
            }
            return saved;
        }
    }
}
