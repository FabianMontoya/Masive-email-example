using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasiveEmail
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        bool ejecutandoTarea = false;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Title = "Seleccione archivo";
            openFileDialog1.Multiselect = false;
            openFileDialog1.DefaultExt = "xlsx";
            openFileDialog1.Filter = "Archivos Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            groupBoxProgreso.Visible = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileRoute.Text = openFileDialog1.FileName;
            }
        }

        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

        private void DoSomething(IProgress<int> progress)
        {
            for (int i = 0; i < cantidadHacer; i++)
            {
                int timeSleep = 1;
                try
                {
                    DataRow fila = dt.Rows[i];
                    if (fila != null)
                    {
                        string contrato = fila[0].ToString().Trim().ToUpper();
                        string cedula = fila[1].ToString().Trim();
                        string correo = fila[5].ToString().Trim().ToLower().TrimEnd('.');

                        if (!string.IsNullOrWhiteSpace(contrato) && !string.IsNullOrWhiteSpace(cedula) && !string.IsNullOrWhiteSpace(correo))
                        {
                            try
                            {
                                bool isEmail = Regex.IsMatch(correo, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

                                if (isEmail)
                                {
                                    timeSleep = 66;
                                    string departamento = ""; // myTI.ToTitleCase(fila[3].ToString().Trim().ToLower());
                                    string ciudad = myTI.ToTitleCase(fila[3].ToString().Trim().ToLower());
                                    string conjunto = "";// fila[5].ToString().Trim().ToUpper();

                                    /*
                                    string NombrePersona = fila[2].ToString().Trim();
                                    NombrePersona += fila[3].ToString().Trim().Length > 0 ? " " + fila[3].ToString().Trim() : "";
                                    NombrePersona += fila[4].ToString().Trim().Length > 0 ? " " + fila[4].ToString().Trim() : "";
                                    NombrePersona += fila[5].ToString().Trim().Length > 0 ? " " + fila[5].ToString().Trim() : "";

                                    string cliente = NombrePersona;
                                    */
                                    string cliente = myTI.ToTitleCase(fila[2].ToString().Trim().ToLower().Replace("  ", " "));

                                    string direccion = fila[4].ToString().Trim();
                                    //direccion += fila[8].ToString().Trim().Length > 0 ? " " + fila[8].ToString().Trim() : "";

                                    string MensajeCorreo = System.IO.File.ReadAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"plantilla-email.txt"));

                                    MensajeCorreo = MensajeCorreo.Replace("<nombre>", cliente).Replace("<cedula>", cedula).Replace("<contrato>", contrato).Replace("<conjunto>", conjunto).Replace("<ciudad>", ciudad).Replace("<departamento>", departamento).Replace("<direccion>", direccion);

                                    string asunto = "Soporte pago por concepto de Administración - Tercer Trimestre - Contrato No. " + contrato + " - Leasing Fondo Nacional del Ahorro";
                                    //string asunto = "Contrato " + contrato + " - Leasing Fondo Nacional del Ahorro";


                                    EmailClass.SendMail(correo, cliente, asunto, MensajeCorreo);
                                    EscribirArchivoClass.EscribirLogEnviado("[Fila " + i + "]: " + contrato + " - " + cedula + " - " + correo);
                                    /*
                                    StringBuilder query = new StringBuilder();
                                    query.AppendLine("SELECT TOP 1 [RCA_RefActivo_1] FROM [ActivosO].[R_ContratoActivo] ");
                                    query.AppendLine(string.Concat("WHERE [RCA_Nit_ID] = '899999284' AND [RCA_ContratoID] =  '", contrato, "'"));

                                    string activo = ConectorSQL.Consultar_Registro(query.ToString());

                                    if (!string.IsNullOrWhiteSpace(activo))
                                    {
                                        query.Clear();
                                        query.AppendLine("SELECT ISNULL(MAX([COM_SecuenciaAnotacion]),0)  FROM [Personas].[Compromisos] ");
                                        query.AppendLine(string.Concat("WHERE [COM_Nit_ID] = '899999284' AND [COM_TypeDocument_ID] = '1' AND [COM_Documento] = '", cedula ,"' AND [COM_Contrato_ID] = '",contrato,"' AND [COM_Ref_1] =  '", activo, "' AND [COM_Servicio_ID] = '5'"));

                                        string numSecuencia = ConectorSQL.Consultar_Registro(query.ToString());
                                        int secuenciaCompromiso = 1;
                                        if (int.TryParse(numSecuencia, out secuenciaCompromiso))
                                        {
                                            secuenciaCompromiso++;
                                        }
                                        query.Clear();
                                        query.AppendLine("INSERT INTO [Personas].[Compromisos] (");
                                        query.AppendLine("[COM_Nit_ID] ");
                                        query.AppendLine(",[COM_TypeDocument_ID] ");
                                        query.AppendLine(",[COM_Documento] ");
                                        query.AppendLine(",[COM_Contrato_ID] ");
                                        query.AppendLine(",[COM_Ref_1] ");
                                        query.AppendLine(",[COM_Servicio_ID] ");
                                        query.AppendLine(",[COM_Periodo_ID] ");
                                        query.AppendLine(",[COM_Referencia] ");
                                        query.AppendLine(",[COM_SecuenciaAnotacion] ");
                                        query.AppendLine(",[COM_ID_TipoAnotacion] ");
                                        query.AppendLine(",[COM_FechaContacto] ");
                                        query.AppendLine(",[COM_FechaCompromiso] ");
                                        query.AppendLine(",[COM_UsuarioCreadorCompromiso] ");
                                        query.AppendLine(",[COM_Descripcion] ");
                                        query.AppendLine(",[COM_Estado] ");
                                        query.AppendLine(",[COM_UsuarioCreacion] ");
                                        query.AppendLine(",[COM_UsuarioActualizacion] ");
                                        query.AppendLine(") VALUES ( ");
                                        query.AppendLine(string.Concat("'899999284'"));
                                        query.AppendLine(string.Concat(",'1'"));
                                        query.AppendLine(string.Concat(",'", cedula, "'"));
                                        query.AppendLine(string.Concat(",'", contrato, "'"));
                                        query.AppendLine(string.Concat(",'", activo, "'"));
                                        query.AppendLine(string.Concat(",'", 5, "'"));
                                        query.AppendLine(string.Concat(",'0'")); //Periodo
                                        query.AppendLine(string.Concat(",''")); //Referencia factura
                                        query.AppendLine(string.Concat(",'", secuenciaCompromiso, "'"));
                                        query.AppendLine(string.Concat(",'", 8, "'")); //Tipo 8 Cobranza
                                        query.AppendLine(string.Concat(",getdate()"));
                                        query.AppendLine(string.Concat(",CONVERT(DATE, '2020-06-30', 121)"));
                                        query.AppendLine(string.Concat(",'master'"));
                                        query.AppendLine(string.Concat(",'Correo electrónico de notificación mora enviado a ", correo, "'"));
                                        query.AppendLine(string.Concat(",'", 1, "'"));
                                        query.AppendLine(string.Concat(",'master'"));
                                        query.AppendLine(string.Concat(",'master'"));
                                        query.AppendLine(string.Concat(")"));
                                        string result = ConectorSQL.Ejecutar_InsertUpdateDelete(query.ToString());

                                        if (!result.Equals("Exito"))
                                        {
                                            EscribirArchivoClass.EscribirLogFallido("[Fila " + i + "] (5): " + contrato + " - " + activo + " - " + cedula + " | Error al crear el compromiso: " + result + ".");
                                        }
                                    }
                                    else
                                    {
                                        EscribirArchivoClass.EscribirLogFallido("[Fila " + i + "] (4): " + contrato + " - " + cedula + " - " + correo + " | El sistema no encontró el activo relacionado a este contrato.");
                                    }
                                    */
                                }
                                else
                                {
                                    timeSleep = 1;
                                    EscribirArchivoClass.EscribirLogFallido("[Fila " + i + "] (3): " + contrato + " - " + cedula + " - " + correo + " | El sistema determinó que no es una dirección de correo valida.");
                                }
                            }
                            catch (Exception ex)
                            {
                                timeSleep = 1;
                                EscribirArchivoClass.EscribirLogFallido("[Fila " + i + "] (2): " + contrato + " - " + cedula + " - " + correo + " | " + ex.ToString());
                            }
                        }
                        else
                        {
                            timeSleep = 1;
                            EscribirArchivoClass.EscribirLogFallido("[Fila " + i + "] (1): " + contrato + " - " + cedula + " - " + correo + " | Data no valida para enviar e-mail.");
                        }
                    }
                    else
                    {
                        timeSleep = 1;
                        EscribirArchivoClass.EscribirLogFallido("[Fila " + i + "] (0): La fila fue encontrada como null.");
                    }
                }
                catch (Exception ex)
                {
                    timeSleep = 1;
                    EscribirArchivoClass.EscribirLogFallido("[Fila " + i + "]: Ocurrió un fallo al intentar leer la fila: «" + ex.ToString() + "»");
                }
                cantidadHecha++;
                if (progress != null) { progress.Report((100 * cantidadHecha) / cantidadHacer); }
                Thread.Sleep(timeSleep * 1000);
            }
        }

        DataTable dt;
        int cantidadHacer = 0;
        int cantidadHecha = 0;
        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                groupBoxProgreso.Visible = false;
                cantidadHecha = 0;
                progressBar.Value = 0;
                lCantidad.Text = "0/-";
                lPorcentaje.Text = "0%";

                string hoja = txtHoja.Text;
                string archivo = openFileDialog1.FileName;
                //Validamos que haya una ruta de archivo
                if (string.IsNullOrWhiteSpace(archivo))
                {
                    MessageBox.Show("Debes indicar la plantilla con la información de los correos.", "Sin archivo seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
                else if (string.IsNullOrEmpty(hoja))
                {
                    MessageBox.Show("Debes indicar la hoja donde se buscarán las direcciones de correo electrónico.", "Sin nombre de Hoja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //declaramos las variables         
                    OleDbConnection conexion = null;
                    OleDbDataAdapter dataAdapter = null;
                    string consultaHojaExcel = "Select * from [" + hoja + "$]";

                    //esta cadena es para archivos excel 2007 y 2010
                    string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

                    //para archivos de 97-2003 usar la siguiente cadena
                    //string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";

                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                    try
                    {
                        //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                        conexion.Open(); //abrimos la conexion
                        dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataAdapter
                        dt = new DataTable();
                        dataAdapter.Fill(dt);//llenamos el dataset                            
                        conexion.Close();//cerramos la conexion 


                        cantidadHacer = dt.Rows.Count;

                        lCantidad.Text = string.Concat(cantidadHecha, "/", cantidadHacer);
                        lPorcentaje.Text = "0%";
                        groupBoxProgreso.Visible = true;
                        panelPrincipal.Enabled = false;
                        ejecutandoTarea = true;
                        var progress = new Progress<int>(percent =>
                        {
                            progressBar.Value = percent;
                            lCantidad.Text = string.Concat(cantidadHecha, "/", cantidadHacer);
                            lPorcentaje.Text = percent + "%";
                            if (percent > 99)
                            {
                                panelPrincipal.Enabled = true;
                                ejecutandoTarea = false;
                                MessageBox.Show("Se ha terminado la tarea programa.", "Tarea terminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        });
                        await Task.Run(() => DoSomething(progress));
                    }
                    catch (Exception ex)
                    {
                        //en caso de haber una excepcion que nos mande un mensaje de error
                        MessageBox.Show("Error al leer los datos del archivo: " + ex.Message, "Error lectura de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conexion.Close();//cerramos la conexion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar leer el archivo seleccionado: " + ex.Message, "Error leer archivo excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ejecutandoTarea)
            {
                DialogResult result = MessageBox.Show("¿Desea cancelar el proceso de envio de correos y cerrar el programa?", "Envio de correos en progreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
