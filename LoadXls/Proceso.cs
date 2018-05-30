using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using System.Threading;

namespace LoadXls
{
    public class Proceso
    {
        private Validations _validations;
        private string _logFileName = null;
        private bool _isExtranjero = false;
        private bool _isPermisoUuid = false;
        private string _outputFile = "";

        /// <summary>
        /// 
        /// </summary>
        public Proceso()
        {
            _isExtranjero = false;
            _isPermisoUuid = false;
            _logFileName = null;
            _outputFile = null;
        }

        private bool archivoEnUso(string path)
        {
            FileStream stream = null;
            try
            {
                stream = new FileInfo(path).Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                stream?.Close();
            }
            return false;
        }

        /// <summary>
        /// Crea una nueva interfaz con los registros fallidos pero aprobados
        /// </summary>
        /// <param name="newRecords">Lista de nuevos registros a agregar</param>
        /// <returns></returns>
        public bool WriteApproved(List<OracleRecord> newRecords)
        {
            var estado = false;
            try
            {
                LogUtilities.ShowMessage("Procesando " + newRecords.Count + " archivos aprobados", 1);
                var reporte = new OutputInterface();
                reporte.AddRecords(newRecords);
                var outputFile = DateTime.Now.ToString("dd-MM-yyyyThh-mm-ss") + "_output.csv";
                reporte.Save(outputFile);
                estado = true;
            }
            catch (Exception ex)
            {
                LogUtilities.ShowMessage(ex.ToString(), 1, false);
            }
            return estado;
        }

        public string GetOutputName()
        {
            return _outputFile;
        }

        /// <summary>
        /// Inicia el proceso del xls
        /// </summary>
        /// <param name="fileName">Ruta del archivo xls temporal</param>
        /// <param name="isExtranjero">Determina si el xls es extranjero o local</param>
        /// <param name="isPermisoUuid">Determina si se debe saltar la validacion del uuid del portal</param>
        /// <returns>Lista de los reistros fallidos</returns>
        public List<KeyValuePair<OracleRecord, string>> Iniciar(string fileName, bool isExtranjero = false, bool isPermisoUuid = false)
        {
            _isExtranjero = isExtranjero;
            _isPermisoUuid = isPermisoUuid;
            var fi = new FileInfo(fileName);
            _validations = new Validations();
            LogUtilities.ShowMessage("Procesando archivo " + fi.Name, 1);
            //while (archivoEnUso(fi.FullName))
            //{
            //    LogUtilities.ShowMessage("[FAIL] El archivo está en uso, se procesará nuevamente...", 2);
            //    Thread.Sleep(100);
            //}
            if (LeerXls(fi.FullName))
            {
                LogUtilities.ShowMessage("[FINISH]", 1);
                try
                {
                    fi.Delete();
                }
                catch { LogUtilities.ShowMessage("[FAIL] El archivo no se pudo eliminar, se procesará nuevamente...", 2); }
            }
            else
            {
                try
                {
                    if (File.Exists(fi.FullName + ".err")) { File.Delete(fi.FullName + ".err"); }
                    File.Move(fi.FullName, fi.FullName + ".err");
                    LogUtilities.ShowMessage("[FAIL] Uno o más registros en el archivo tuvieron errores, se cambiará la extension a \".err\" para futuras referencias...", 2, false);
                }
                catch (Exception) { LogUtilities.ShowMessage("[FAIL] No se pudo cambiar la extensión al archivo, se procesará nuevamente...", 2, false); }
            }
            var output = _validations.GetInterfaceSalida();
            _outputFile = Path.GetFileNameWithoutExtension(fi.FullName).Replace(" ", "_") + "_" + DateTime.Now.ToString("dd-MM-yyyyThh-mm-ss") + "_output.csv";
            output.Save(_outputFile, _logFileName);
            LogUtilities.ShowNewLine();
            return _validations.GetFailedRecords();
        }

        private bool LeerXls(string filePath)
        {
            bool control;
            var records = new List<OracleRecord>();
            try
            {
                records = Transform(filePath);
            }
            catch (Exception ex)
            {
                LogUtilities.ShowMessage("[EX] " + ex.Message, 3);
                LogUtilities.ShowNewLine();
            }
            _logFileName = "LoadXlsOTM_" + Path.GetFileNameWithoutExtension(filePath).Replace(" ", "_") + "_" + DateTime.Now.ToString("dd-MM-yyyyThh-mm-ss") + ".log";
            LogUtilities.SetLogFileName(_logFileName, false);
            control = _validations.Validate(records, _isExtranjero, _isPermisoUuid);
            LogUtilities.SetLogFileName(null);
            return control;
        }

        private List<OracleRecord> Transform(string pathDelFicheroExcel)
        {
            var list = new List<OracleRecord>();
            using (var package = new ExcelPackage(new FileInfo(pathDelFicheroExcel)))
            {
                var workSheet = package.Workbook.Worksheets.First();
                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;
                for (var row = (start.Row + 2); row <= end.Row; row++)
                {
                    try
                    {
                        var record = new OracleRecord
                        {
                            RowNumber = row.ToString(),
                            RecordType = workSheet.Cells[row, 1].Text,
                            InvoiceNum = workSheet.Cells[row, 2].Text,
                            SupplierNum = workSheet.Cells[row, 3].Text,
                            InvoiceDate = workSheet.Cells[row, 4].Text,
                            InvoiceCurr = workSheet.Cells[row, 5].Text,
                            CurrencyRate = workSheet.Cells[row, 6].Text,
                            InvoiceAmount = workSheet.Cells[row, 7].Text.Replace(",", ""),
                            NoInvDetail = workSheet.Cells[row, 8].Text,
                            Num = workSheet.Cells[row, 9].Text,
                            UuidCfdi = workSheet.Cells[row, 10].Text,
                            SupplierNum2 = workSheet.Cells[row, 11].Text,
                            MontoTotal = workSheet.Cells[row, 12].Text.Replace(",", ""),
                            Moneda = workSheet.Cells[row, 13].Text,
                            TipCamb = workSheet.Cells[row, 14].Text,
                            NoInvDetail2 = workSheet.Cells[row, 15].Text,
                            TypeTax = workSheet.Cells[row, 16].Text,
                            Cc = workSheet.Cells[row, 17].Text,
                            Amount = workSheet.Cells[row, 18].Text.Replace(",", "")
                        };
                        //if (!string.IsNullOrEmpty(record.RecordType) && !string.IsNullOrEmpty(record.InvoiceNum))
                        //{
                        list.Add(record);
                        //}
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
            return list;
        }
    }
}