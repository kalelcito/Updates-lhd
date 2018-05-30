using System;

namespace SAT
{
    public static class Utilidades
    {
        public static string CerosNull(string a)
        {
            decimal b;
            var cifra = a.Replace(",", "").Trim();
            return string.Format("{0:0.00}", Convert.ToDecimal(string.IsNullOrEmpty(cifra) || !decimal.TryParse(cifra, out b) || b < 0 ? "0.00" : cifra));
        }

        public static string FormatoFecha(string fecha, bool utc = false)
        {
            var result = fecha;
            try
            {
                DateTime f;
                if (!string.IsNullOrEmpty(fecha) && DateTime.TryParse(fecha, out f))
                {
                    result = f.ToString("yyyy-MM-ddTHH:mm:ss" + (utc ? "zzz" : ""));
                }
            }
            catch { }
            return result;
        }

        public static string ReplaceAccents(string text)
        {
            var result = text;
            result = result.Replace("á", "\u00E1");
            result = result.Replace("é", "\u00E9");
            result = result.Replace("í", "\u00ED");
            result = result.Replace("ó", "\u00F3");
            result = result.Replace("ú", "\u00FA");
            result = result.Replace("Á", "\u00C1");
            result = result.Replace("É", "\u00C9");
            result = result.Replace("Í", "\u00CD");
            result = result.Replace("Ó", "\u00D3");
            result = result.Replace("Ú", "\u00DA");
            result = result.Replace("ü", "\u00FC");
            result = result.Replace("Ü", "\u00DC");
            result = result.Replace("ñ", "\u00F1");
            result = result.Replace("Ñ", "\u00D1");
            return result;
        }
    }
}
