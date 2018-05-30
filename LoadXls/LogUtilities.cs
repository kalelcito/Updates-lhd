using System;
using System.Configuration;
using System.IO;

namespace LoadXls
{
    public static class LogUtilities
    {

        private static string _logFile = "";

        /// <summary>
        /// Indica el path del log
        /// </summary>
        /// <param name="fileName">Direccion en el disco duro</param>
        /// <param name="append">Si se desea escribir en el mismo archivo o crear uno nuevo</param>
        public static void SetLogFileName(string fileName, bool append = true)
        {
            _logFile = fileName;
            try
            {
                if (File.Exists(fileName) && append)
                {
                    File.Delete(fileName);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        /// <summary>
        ///     Muestra un mensaje con letras de color en consola
        /// </summary>
        /// <param name="message">Mensaje a mostrar</param>
        /// <param name="level">
        ///     Nivel de mensaje a mostrar
        ///     <para>0(default)=blank | 1=informacion | 2=advertencia | 3=error</para>
        /// </param>
        /// /// <param name="log">Define si se va a gauradr o no el mensaje en en log</param>
        public static void ShowMessage(string message, int level = 0, bool log = true)
        {
            var color = Console.ForegroundColor;
            switch (level)
            {
                case 1:
                    color = ConsoleColor.DarkCyan;
                    break;
                case 2:
                    color = ConsoleColor.DarkYellow;
                    break;
                case 3:
                    color = ConsoleColor.Red;
                    break;
            }
            ShowMessage(message, color);
            if (log)
            {
                SaveLog(message);
            }
        }

        /// <summary>
        /// Muestra un salto de linea en la consola
        /// </summary>
        public static void ShowNewLine()
        {
            ShowMessage("", 0, false);
        }

        private static void ShowMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void SaveLog(string message)
        {
            var directory = ConfigurationManager.AppSettings.Get("writeDirectory") + @"\log Oracle";
            Directory.CreateDirectory(directory);
            string logFile = _logFile;
            if (string.IsNullOrEmpty(logFile))
            {
                var dateString = DateTime.Now.ToString("dd-MM-yyyy");
                logFile = "LoadXlsOTM_" + dateString + ".log";
            }
            logFile = directory + @"\" + logFile;
            using (var w = File.AppendText(logFile))
            {
                try
                {
                    w.Write("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToLongTimeString());
                    w.WriteLine("    :{0}", message);
                    w.WriteLine("-------------------------------");
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}