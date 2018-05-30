using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using System.Text.RegularExpressions;

namespace LoadXls
{
    public class Validations
    {
        private List<OracleRecord> _records;
        private readonly Dictionary<string, List<string>> _dbRecords;
        private readonly BasesDatos _db;
        private readonly OutputInterface _reporte;
        private List<KeyValuePair<OracleRecord, string>> _failRecords;
        private bool _isExtranjero;
        private bool _isPermisoUuid;

        /// <summary>
        ///     Inicia las validaciones
        /// </summary>
        public Validations()
        {
            _db = new BasesDatos();
            _failRecords = new List<KeyValuePair<OracleRecord, string>>();
            _dbRecords = new Dictionary<string, List<string>>();
            _reporte = new OutputInterface();
            GetDataFromDataBase();
        }

        /// <summary>
        /// Obtiene la interfaz de salida para su procesamiento
        /// </summary>
        /// <returns>Interface generada</returns>
        public OutputInterface GetInterfaceSalida()
        {
            return _reporte;
        }

        /// <summary>
        /// Obtiene la lista de records que fallaron y la razón por la cual fallaron
        /// </summary>
        /// <returns>Lista de par de claves cotentiendo el record y el mensaje</returns>
        public List<KeyValuePair<OracleRecord, string>> GetFailedRecords()
        {
            return _failRecords;
        }

        /// <summary>
        /// Valida el registro dependiendo del número de escenario (revisar documentación)
        /// </summary>
        /// <param name="records">Lista de registros de Oracle consecutivos del mismo RecordType</param>
        /// <param name="isExtranjero">Define si el xls es extranjero</param>
        /// <param name="isPermisoUuid">Define si se salta la validación contra la base de datos</param>
        /// <returns>El resultado de la validación de los registros</returns>
        public bool Validate(List<OracleRecord> records, bool isExtranjero = false, bool isPermisoUuid = false)
        {
            _isExtranjero = isExtranjero;
            _isPermisoUuid = isPermisoUuid;
            var control = true;
            _records = FillBlanks(records);
            var adjacentRecords = _records.GroupAdjacent(record => record.RecordType).ToList();
            foreach (var recordGroup in adjacentRecords)
            {
                var recordType = recordGroup.Key;
                foreach (var record in recordGroup)
                {
                    try
                    {
                        var regex = new Regex(@"[A-F0-9]{8}-[A-F0-9]{4}-[A-F0-9]{4}-[A-F0-9]{4}-[A-F0-9]{12}");
                        if (!string.IsNullOrEmpty(record.UuidCfdi.ToUpper()) && regex.IsMatch(record.UuidCfdi.ToUpper()))
                        {
                            if (_isExtranjero)
                            {
                                throw new Exception("El registro es extranjero, no se puede comparar el UUID");
                            }
                            //else if (!_dbRecords.ContainsKey(record.UuidCfdi))
                            //{
                            //    if (!_isPermisoUuid)
                            //    {
                            //        throw new Exception("El UUID no existe en el portal");
                            //    }
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        var pair = new KeyValuePair<OracleRecord, string>(record, ex.Message);
                        _failRecords.Add(pair);
                        LogUtilities.ShowMessage(ex.Message, 3);
                    }
                }
                List<List<OracleRecord>> groupedList;
                if (recordType.Equals("1"))
                {
                    groupedList = recordGroup.GroupBy(u => u.UuidCfdi).Select(grp => grp.ToList()).ToList();
                }
                else
                {
                    groupedList = recordGroup.GroupBy(u => u.InvoiceNum).Select(grp => grp.ToList()).ToList();
                }
                switch (recordType)
                {
                    case "1": control &= Scenario1(groupedList); break;
                    case "2": control &= Scenarios23(groupedList, 2); break;
                    case "3": control &= Scenarios23(groupedList, 3); break;
                    case "4": control &= Scenarios23(groupedList, 4); break;
                }
            }
            return control;
        }

        private List<List<OracleRecord>> FillBlanksScenario3(List<List<OracleRecord>> records)
        {
            var filled = new List<List<OracleRecord>>();
            filled.AddRange(records);
            for (int i = 0; i < filled.Count; i++)
            {
                try
                {
                    var recordGroup = filled[i];
                    if (i > 0)
                    {
                        var prevRecordGroup = filled[i - 1];
                        for (int j = 0; j < recordGroup.Count; j++)
                        {
                            var record = recordGroup[j];
                            var isEmpty = IsEmpty(record);
                            var prevRecord = prevRecordGroup[j];
                            if (!string.IsNullOrEmpty(prevRecord.RecordType) && !isEmpty)
                            {
                                if (prevRecord.RecordType.Equals("4"))
                                {

                                    if (string.IsNullOrEmpty(record.Num))
                                    {
                                        record.Num = prevRecord.Num;
                                    }
                                    if (string.IsNullOrEmpty(record.UuidCfdi))
                                    {
                                        record.UuidCfdi = prevRecord.UuidCfdi;
                                    }
                                    if (string.IsNullOrEmpty(record.SupplierNum2))
                                    {
                                        record.SupplierNum2 = prevRecord.SupplierNum2;
                                    }
                                    if (string.IsNullOrEmpty(record.MontoTotal))
                                    {
                                        record.MontoTotal = prevRecord.MontoTotal;
                                    }
                                    if (string.IsNullOrEmpty(record.Moneda))
                                    {
                                        record.Moneda = prevRecord.Moneda;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception es)
                {
                    var esdfgsd = "";
                }
            }
            return filled;
        }

        private static bool IsEmpty(OracleRecord record)
        {
            var isEmpty = true;
            isEmpty &= string.IsNullOrEmpty(record.Amount.Trim());
            isEmpty &= string.IsNullOrEmpty(record.Cc.Trim());
            isEmpty &= string.IsNullOrEmpty(record.CurrencyRate.Trim());
            isEmpty &= string.IsNullOrEmpty(record.InvoiceAmount.Trim());
            isEmpty &= string.IsNullOrEmpty(record.InvoiceCurr.Trim());
            isEmpty &= string.IsNullOrEmpty(record.InvoiceDate.Trim());
            isEmpty &= string.IsNullOrEmpty(record.InvoiceNum.Trim());
            isEmpty &= string.IsNullOrEmpty(record.Moneda.Trim());
            isEmpty &= string.IsNullOrEmpty(record.MontoTotal.Trim());
            isEmpty &= string.IsNullOrEmpty(record.NoInvDetail.Trim());
            isEmpty &= string.IsNullOrEmpty(record.NoInvDetail2.Trim());
            isEmpty &= string.IsNullOrEmpty(record.Num.Trim());
            isEmpty &= string.IsNullOrEmpty(record.RecordType.Trim());
            isEmpty &= string.IsNullOrEmpty(record.SupplierNum.Trim());
            isEmpty &= string.IsNullOrEmpty(record.SupplierNum2.Trim());
            isEmpty &= string.IsNullOrEmpty(record.TipCamb.Trim());
            isEmpty &= string.IsNullOrEmpty(record.TypeTax.Trim());
            isEmpty &= string.IsNullOrEmpty(record.UuidCfdi.Trim());
            return isEmpty;
        }

        private List<OracleRecord> FillBlanks(List<OracleRecord> records)
        {
            var filled = new List<OracleRecord>();
            filled.AddRange(records);
            for (int i = 0; i < filled.Count; i++)
            {
                var record = filled[i];
                var isEmpty = IsEmpty(record);
                if (i > 0 && !isEmpty)
                {
                    var prevRecord = filled[i - 1];
                    if (!string.IsNullOrEmpty(prevRecord.RecordType))
                    {
                        if (prevRecord.RecordType.Equals("1") || prevRecord.RecordType.Equals("3"))
                        {
                            if (string.IsNullOrEmpty(record.UuidCfdi) && !record.NoInvDetail2.Equals("Y"))
                            {
                                record.UuidCfdi = prevRecord.UuidCfdi;
                            }
                        }
                        if (prevRecord.RecordType.Equals("2"))
                        {
                            if (string.IsNullOrEmpty(record.NoInvDetail2))
                            {
                                record.NoInvDetail2 = prevRecord.NoInvDetail2;
                            }
                        }
                        if (string.IsNullOrEmpty(record.RecordType))
                        {
                            record.RecordType = prevRecord.RecordType;
                        }
                        if (string.IsNullOrEmpty(record.InvoiceNum))
                        {
                            record.InvoiceNum = prevRecord.InvoiceNum;
                        }
                        if (string.IsNullOrEmpty(record.SupplierNum))
                        {
                            record.SupplierNum = prevRecord.SupplierNum;
                        }
                        if (string.IsNullOrEmpty(record.InvoiceDate))
                        {
                            record.InvoiceDate = prevRecord.InvoiceDate;
                        }
                        if (string.IsNullOrEmpty(record.InvoiceCurr))
                        {
                            record.InvoiceCurr = prevRecord.InvoiceCurr;
                        }
                        if (string.IsNullOrEmpty(record.InvoiceAmount))
                        {
                            record.InvoiceAmount = prevRecord.InvoiceAmount;
                        }
                        if (string.IsNullOrEmpty(record.NoInvDetail))
                        {
                            record.NoInvDetail = prevRecord.NoInvDetail;
                        }
                    }

                }
            }
            return filled;
        }

        private void GetDataFromDataBase()
        {
            _db.Conectar();
            _db.CrearComando(@"SELECT DISTINCT [idFactura]
                ,[UUID]
                ,[total]
				,[RFCEMI]
FROM [GENERAL] INNER JOIN
	 [EMISOR] ON IDEEMI = id_Emisor INNER JOIN
	 [CFDI] ON id_Factura = idFactura");
            var dr = _db.EjecutarConsulta();
            while (dr.Read())
            {
                var uuid = dr["UUID"].ToString().ToUpper();
                var total = dr["total"].ToString();
                var rfc = dr["RFCEMI"].ToString();
                if (!_dbRecords.ContainsKey(uuid))
                {
                    _dbRecords.Add(uuid, new List<string>() { rfc, total });
                }
            }
            _db.Desconectar();
        }

        private bool Scenario1(List<List<OracleRecord>> recordsGroup)
        {
            var valid = true;
            foreach (var group in recordsGroup)
            {
                var sumGroup = group.Sum(x =>
                {
                    decimal monto;
                    decimal.TryParse(x.InvoiceAmount, out monto);
                    return monto;
                });
                foreach (var record in group)
                {
                    try
                    {
                        if (!_dbRecords.ContainsKey(record.UuidCfdi.ToUpper()))
                        {
                            if ((_isPermisoUuid && !string.IsNullOrEmpty(record.UuidCfdi)) || _isExtranjero || (_isPermisoUuid && !string.IsNullOrEmpty(record.UuidCfdi)))
                            {
                                _reporte.AddRecord(record);
                                LogUtilities.ShowMessage("[OK=RowNumber:" + record.RowNumber + ",UUID:" + record.UuidCfdi + "]", 1);
                                continue;
                            }
                            throw new Exception("El UUID no existe en el portal");
                        }
                        decimal dMontoXml;
                        var montoXml = _dbRecords[record.UuidCfdi.ToUpper()].ElementAt(1);
                        var rfcXml = _dbRecords[record.UuidCfdi.ToUpper()].ElementAt(0);
                        decimal.TryParse(montoXml, out dMontoXml);
                        if (sumGroup != dMontoXml && Math.Abs(sumGroup - dMontoXml) > Convert.ToDecimal(0.99))
                        {
                            throw new Exception("La sumatoria de los registros de Oracle en el xls (" + sumGroup + ") no coincide con el total del xml asociado (" + montoXml + ")");
                        }
                        if (!record.SupplierNum.Equals(rfcXml))
                        {
                            throw new Exception("El RFC en el registro de Oracle en el xls (" + record.SupplierNum + ") no coincide con el RFC del xml asociado (" + rfcXml + ")");
                        }
                        _reporte.AddRecord(record);
                        LogUtilities.ShowMessage("[OK=RowNumber:" + record.RowNumber + ",UUID:" + record.UuidCfdi + "]", 1);
                    }
                    catch (Exception ex)
                    {
                        var pair = new KeyValuePair<OracleRecord, string>(record, ex.Message);
                        _failRecords.Add(pair);
                        valid = false;
                        LogUtilities.ShowMessage("[FAIL=RowNumber:" + record.RowNumber + ",UUID:" + record.UuidCfdi + "]: " + ex.Message, 3);
                    }
                    finally
                    {
                        LogUtilities.ShowNewLine();
                    }
                }
            }
            return valid;
        }

        private bool Scenarios23(List<List<OracleRecord>> recordsGroup, int scenario)
        {
            var valid = true;
            decimal invoiceAmountGroup;
            decimal amountGroupCc = 0;
            var recordsCc = new List<OracleRecord>();
            var regex = new Regex(@"[A-F0-9]{8}-[A-F0-9]{4}-[A-F0-9]{4}-[A-F0-9]{4}-[A-F0-9]{12}");
            foreach (var recordGroup in recordsGroup)
            {
                var adjacentRecords = recordGroup.GroupAdjacent(record => record.Cc).Select(grp => grp.ToList()).ToList();
                if (scenario == 3 || scenario == 4)
                {
                    adjacentRecords = FillBlanksScenario3(adjacentRecords);
                }
                for (var i = 0; i < adjacentRecords.Count; i++)
                {
                    var group = adjacentRecords[i];
                    var invoiceNum = group.First().InvoiceNum;
                    var uuids = string.Join(",", group.Select(x => x.UuidCfdi));
                    try
                    {
                        #region Valida que el UUID exista en el portal si es que no tiene permisos, que el MontoTotal corresponda con el del portal, que el RFC corresponda con el del portal y que el UUID tenga una estructura válida

                        foreach (var record in group)
                        {
                            if (_isExtranjero)
                            {
                                continue;
                            }
                            else if (record.NoInvDetail2.Equals("Y"))
                            {
                                continue;
                            }
                            else if (scenario == 2 && !regex.IsMatch(record.UuidCfdi.ToUpper()))
                            {
                                continue;
                            }
                            else if (!_dbRecords.ContainsKey(record.UuidCfdi.ToUpper()))
                            {
                                if (_isPermisoUuid && !string.IsNullOrEmpty(record.UuidCfdi))
                                {
                                    continue;
                                }
                                throw new Exception(record.UuidCfdi + "||" + "El UUID no existe en el portal");
                            }
                            decimal dMontoRecord;
                            decimal dMontoXml;
                            //var montoRecord = Regex.Replace(record.MontoTotal, @"[^(\d|,|\.)]", "");
                            var montoRecord = record.MontoTotal;
                            var montoXml = _dbRecords[record.UuidCfdi.ToUpper()].ElementAt(1);
                            var rfcXml = _dbRecords[record.UuidCfdi.ToUpper()].ElementAt(0);
                            decimal.TryParse(montoRecord, out dMontoRecord);
                            decimal.TryParse(montoXml, out dMontoXml);
                            if (dMontoRecord != dMontoXml && Math.Abs(dMontoRecord - dMontoXml) > Convert.ToDecimal(0.99))
                            {
                                throw new Exception(record.UuidCfdi + "||" + "El monto del registro de Oracle en el xls (" + montoRecord + ") no coincide con el monto del xml asociado (" + montoXml + ")");
                            }
                            if (scenario != 3 && scenario != 4 && !record.SupplierNum.Equals(rfcXml))
                            {
                                throw new Exception(record.UuidCfdi + "||" + "El RFC en el registro de Oracle en el xls (" + record.SupplierNum + ") no coincide con el RFC del xml asociado (" + rfcXml + ")");
                            }
                        }

                        #endregion

                        if (scenario == 3 || scenario == 4)
                        {
                            #region Valida que los InvoiceAmount de los registros del InvoiceNum sean iguales

                            decimal.TryParse(group.First().InvoiceAmount, out invoiceAmountGroup);
                            var valor = group.Sum(x => decimal.Parse(x.InvoiceAmount));
                            //  var equals = group.All(x => decimal.Parse(x.InvoiceAmount) == invoiceAmountGroup);

                            var equals = group.Sum(x => decimal.Parse(x.InvoiceAmount)) == invoiceAmountGroup;

                            if (!equals)
                            {
                                throw new Exception("El InvoiceAmount de los registros del InvoiceNum \"" + invoiceNum + "\" no son iguales");
                            }

                            #endregion

                            #region Valida que la sumatoria de los MontoTotal sea igual al InvoiceAmount

                            var sumGroup = group.Sum(x =>
                            {
                                decimal monto;
                                decimal.TryParse(x.MontoTotal, out monto);
                                return monto;
                            });
                            //      if (sumGroup != invoiceAmountGroup && Math.Abs(sumGroup - invoiceAmountGroup) > Convert.ToDecimal(0.9))
                            if (sumGroup != invoiceAmountGroup && (sumGroup - invoiceAmountGroup) > Convert.ToDecimal(0.9))
                            {
                                throw new Exception("La sumatoria del MontoTotal de los registros del InvoiceNum \"" + invoiceNum + "\" (" + sumGroup + ") no coincide  con el InvoiceAmount (" + invoiceAmountGroup + ")");
                            }

                            #endregion

                            #region Valida que la sumatoria de los Amount sea igual al Invoice

                            if (scenario == 4)
                            {
                                amountGroupCc += sumGroup = group.Sum(x =>
                                {
                                    decimal monto;
                                    decimal.TryParse(x.Amount, out monto);
                                    return monto;
                                });
                                recordsCc.AddRange(group.ToList());
                                var cont = i + 1;
                                if ((i + 1) == adjacentRecords.Count)
                                {
                                    if (amountGroupCc != invoiceAmountGroup && Math.Abs(amountGroupCc - invoiceAmountGroup) > Convert.ToDecimal(0.9))
                                    {
                                        throw new Exception("La sumatoria del Amount de los registros del InvoiceNum \"" + invoiceNum + "\" (" + sumGroup + ") no coincide  con el InvoiceAmount (" + invoiceAmountGroup + ")");
                                    }
                                }
                            }

                            #endregion
                        }

                        if (scenario == 4)
                        {
                            #region Agrega todos los Records agrupados por el CC
                            if ((i + 1) == adjacentRecords.Count)
                            {
                                _reporte.AddRecords(recordsCc);
                                LogUtilities.ShowMessage("[OK=RowNumbers:" + recordsCc.First().RowNumber + "-" + recordsCc.Last().RowNumber + ", UUIDs:" + uuids + "]", 1);
                            }
                            #endregion
                        }
                        else
                        {
                            #region Agrega todos los Records del grupo
                            _reporte.AddRecords(group.ToList());
                            LogUtilities.ShowMessage("[OK=RowNumbers:" + group.First().RowNumber + "-" + group.Last().RowNumber + ", UUIDs:" + uuids + "]", 1);
                            #endregion
                        }
                    }
                    catch (Exception ex)
                    {
                        foreach (var record in group)
                        {
                            var mensaje = ex.Message;
                            try
                            {
                                var split = ex.Message.Split(new char[] { '|', '|' }, StringSplitOptions.RemoveEmptyEntries);
                                var uuid = split.FirstOrDefault();
                                var msg = split.LastOrDefault();
                                if (record.UuidCfdi.Equals(uuid))
                                {
                                    mensaje = msg;
                                }
                                else
                                {
                                    mensaje = "Error heredado del UUID " + uuid;
                                }
                            }
                            catch { }
                            var pair = new KeyValuePair<OracleRecord, string>(record, mensaje);
                            _failRecords.Add(pair);
                        }
                        valid = false;
                        LogUtilities.ShowMessage("[FAIL=RowNumbers:" + group.First().RowNumber + "-" + group.Last().RowNumber + ", UUIDs:" + uuids + "]: " + ex.Message, 3);
                    }
                    finally
                    {
                        LogUtilities.ShowNewLine();
                    }
                }
            }
            return valid;
        }
    }
}