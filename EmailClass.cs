using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MasiveEmail
{
    internal class EmailClass
    {
        /// <summary>
        /// Función genérica para el envio de e-mail desde el API
        /// </summary>
        /// <param name="mailDestino"></param>
        /// <param name="nombreDestinatario"></param>
        /// <param name="asuntoMensaje"></param>
        /// <param name="cuerpoMensaje"></param>
        public static void SendMail(string mailDestino, string nombreDestinatario, string asuntoMensaje, string cuerpoMensaje)
        {
            try
            {
                //CorreoClass emailSettings = CorreoSQLClass.ConsultarInfoCorreoo(1);
                if (true)
                {
                    //Datos desde donde se van a enviar los correos
                    string mailFrom = "webmail@grupotci.com.co";
                    string nameFrom = "Notificaciones TCI Software SAS";
                    string passwordFrom = "Grupotci2020*";
                    string hostSMTP = "mail.grupotci.com.co";
                    //Message data
                    MailAddress fromAddress = new MailAddress(mailFrom, nameFrom, System.Text.Encoding.UTF8);
                    MailAddress toAddress = new MailAddress(mailDestino, nombreDestinatario, System.Text.Encoding.UTF8);
                    MailAddress CCO = new MailAddress("info@grupotci.com.co", "Información TCI Software SAS"); //Copia oculta

                    // Specify the message content.
                    using (MailMessage message = new MailMessage(fromAddress, toAddress))
                    {
                        message.Subject = asuntoMensaje;
                        message.SubjectEncoding = System.Text.Encoding.UTF8;
                        message.IsBodyHtml = true;
                        message.Body = cuerpoMensaje;
                        message.BodyEncoding = System.Text.Encoding.UTF8;
                        message.Priority = MailPriority.Normal;
                        message.Bcc.Add(CCO);
                        message.From = new MailAddress("cgarzon@grupotci.com.co", "Claudia Garzón - Fondo Nacional del Ahorro - TCI Software SAS"); //Correo que el usuario verá y al que responderá

                        //SMTP Cliente
                        SmtpClient smtp = new SmtpClient
                        {
                            Host = hostSMTP,
                            Port = 587, //Este puerto intentar no cambiar, funciona para todos los tipos de email
                            EnableSsl = true,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(mailFrom, passwordFrom),
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            Timeout = 5 * 60 * 1000 //2 minutos
                        };
                        //Send the E-Mail
                        smtp.Send(message);
                    }
                }
                else
                {
                    throw new InvalidOperationException("Ocurrió un error al intentar obtener los datos de configuración del correo 1. Favor validar.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
