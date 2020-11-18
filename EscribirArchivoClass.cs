using System;
using System.Diagnostics;
using System.IO;

namespace MasiveEmail
{
    internal class EscribirArchivoClass
    {
        public static void EscribirLogEnviado(string Mensaje)
        {
            try
            {
                string folder = "C:\\Envio-Contratos-Correo";
                //Verificamos si ya existe la carpeta de logs para servicios
                if (!Directory.Exists(folder))
                { Directory.CreateDirectory(folder); }
                
                if (!Directory.Exists(folder))
                { Directory.CreateDirectory(folder); }
                
                //Verificamos si ya existe el archivo con los log creados al día de hoy
                folder += "\\EnviadoCorrecto.txt";
                if (!File.Exists(folder)) { File.CreateText(folder).Dispose(); }
                Mensaje = "[" + DateTime.Now.ToString("HH:mm:ss.fff") + "]: " + Mensaje + "\r\n";
                using (StreamWriter w = File.AppendText(folder))
                {
                    w.WriteLine(Mensaje);
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry("Error al escribir el archivo de texto de logs: " + ex, EventLogEntryType.Warning, 101, 1);
                }
            }

        }
        public static void EscribirLogFallido(string Mensaje)
        {
            try
            {
                string folder = "C:\\Envio-Contratos-Correo";
                //Verificamos si ya existe la carpeta de logs para servicios
                if (!Directory.Exists(folder))
                { Directory.CreateDirectory(folder); }
                
                if (!Directory.Exists(folder))
                { Directory.CreateDirectory(folder); }

                //Verificamos si ya existe el archivo con los log creados al día de hoy
                folder += "\\EnviadoFallido.txt";
                if (!File.Exists(folder)) { File.CreateText(folder).Dispose(); }
                Mensaje = "[" + DateTime.Now.ToString("HH:mm:ss.fff") + "]: " + Mensaje + "\r\n";
                using (StreamWriter w = File.AppendText(folder))
                {
                    w.WriteLine(Mensaje);
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry("Error al escribir el archivo de texto de logs: " + ex, EventLogEntryType.Warning, 101, 1);
                }
            }

        }
    }
}
