using Datos;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Threading;
using System.Web.UI.WebControls;

namespace DataExpressWeb
{
    public partial class Formulario_web112 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        private DataTable DT = new DataTable();
        string modulo = "";
        string rfcEmisor = "";
        static string idres = "";
        private String separador = "|";
        static StreamWriter wr;
        static StreamWriter wr2;
        String rutLic = AppDomain.CurrentDomain.BaseDirectory + @"archivosInterface\";
        ArrayList allId = new ArrayList();
        double totalImporte;
        double totalImporteF;
        Boolean Validar_totalImporte = true;
        Boolean incorrectoImporte = false;
        ArrayList val_Imp = new ArrayList();
        decimal ajusteFIN = 0;
        String estatus = "";

        String archivo_log = AppDomain.CurrentDomain.BaseDirectory + @"\LOG.txt";

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


        }
        /// <summary>
        /// ///////////////////////////////////////////////etatus
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public void anade_linea_archivo(string archivo, string linea)
        {
            using (StreamWriter w = File.CreateText(archivo))
            {
                w.WriteLine(linea.Replace(Environment.NewLine, ""));
                w.Flush();
                w.Close(); // Close the writer and underlying file.
            }
        }

        public void Escribir_Archivo_Interfaz(string archivo, string lineas)
        {
            try
            {
                //foreach (string linea in lineas)
                //{
                using (StreamWriter w = File.CreateText(archivo))
                {
                    w.WriteLine(lineas);
                    w.Flush();
                    w.Close(); // Close the writer and underlying file.
                }
                //}
            }
            catch (Exception ex)
            {

                BD.Conectar();
                BD.CrearComando(@"insert into LogErrorFacturas
                                (detalle,fecha,archivo,linea,numeroDocumento,tipo,detalleTecnico, resultadoValidacion) 
                                values 
                                (@detalle,@fecha,@archivo,@linea,@numeroDocumento,@tipo,@detalleTecnico,@resultadoValidacion)");
                BD.AsignarParametroCadena("@detalle", "Error al generar Interfaz " + archivo);
                BD.AsignarParametroCadena("@fecha", DateTime.Today.ToString());
                BD.AsignarParametroCadena("@archivo", archivo);
                BD.AsignarParametroCadena("@linea", "");
                BD.AsignarParametroCadena("@numeroDocumento", "");
                BD.AsignarParametroCadena("@tipo", "Interfaz");
                BD.AsignarParametroCadena("@detalleTecnico", ex.ToString());
                BD.AsignarParametroCadena("@resultadoValidacion", "");
                BD.EjecutarConsulta();
                BD.Desconectar();
            }
        }

        protected void Button38_Click(object sender, EventArgs e)
        {
            /*GENERAR ARCHIVO CON WEB SERVICE*/
            try
            {

                BD.Conectar();
                BD.CrearComando(@"select GENERAL.idFactura from GENERAL inner join
                              receptorCFDI on receptorCFDI.idreceptorCFDI= GENERAL.id_Receptor where receptorCFDI.razonSoc=@rz
                                and GENERAL.tipProv =@pr and GENERAL.estadoInterface=@st and (GENERAL.parentInvoice=@pi OR GENERAL.parentInvoice=@pi2) and GENERAL.estatus like @estat");
                BD.AsignarParametroCadena("@rz", DropRZ.SelectedValue);
                BD.AsignarParametroCadena("@pr", DropProv.SelectedValue);
                BD.AsignarParametroCadena("@pi", "ORACLE");
                BD.AsignarParametroCadena("@pi2", "REN");
                //BD.AsignarParametroCadena("@pr", DropProv.SelectedValue);
                BD.AsignarParametroCadena("@st", "0");
                BD.AsignarParametroCadena("@estat", "validado%");
                DbDataReader DR = BD.EjecutarConsulta();
                while (DR.Read())
                {
                    allId.Add(DR[0].ToString());
                    val_Imp.Add(true);
                }
                BD.Desconectar();
            }
            catch (Exception ex)
            {
                anade_linea_archivo(archivo_log, "1.- " + ex.ToString());
                BD.Desconectar();
            }
            ////////////////////////////////////////interfaz en curso
            BD.Conectar();
            BD.CrearComando(@"SELECT idInterfaz, estatus FROM Interfaz where estatus=@sta ORDER BY idInterfaz DESC");
            BD.AsignarParametroCadena("@sta", "Procesando");
            DbDataReader DR1 = BD.EjecutarConsulta();
            if (DR1.Read())
            {
                estatus = DR1[1].ToString();
            }
            if (!estatus.Equals("Procesando", StringComparison.OrdinalIgnoreCase))
            {
                /////////////////////////////////////////////////////
                if (allId.Count > 0)
                {

                    System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate (object sender1,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
                         {
                             return true;
                         }; // éstas líneas son para realizar la transacción con protocolo https
                    WebServiceInterfaz.GenerarInterfaz Generar = new WebServiceInterfaz.GenerarInterfaz();
                    try
                    {
                        //    Generar.GeneraInterfazAsync(DropRZ.SelectedValue, DropProv.SelectedValue, true, "todos");
                        new Thread(() =>
                        {
                            GeneraInterfaz1(DropRZ.SelectedValue, DropProv.SelectedValue, true, "todos");
                        }).Start();

                        Session["estNot"] = true;
                        Session["msjNoti"] = "GENERANDO INTERFAZ, SI NO APARECE EN EL LISTADO FAVOR DE RECARGAR LA PAGINA";
                        Session["estPan"] = true;

                        Panel56.Visible = false;


                    }
                    catch (Exception ex)
                    {
                        Session["estNot"] = false;
                        Session["msjNoti"] = "NO ES POSIBLE CONECTAR CON EL SERVIDOR";
                        Session["estPan"] = true;
                    }
                }
                else
                {
                    Session["estNot"] = false;
                    Session["msjNoti"] = "NO HAY FACTURAS PARA GENERAR INTERFAZ";
                    Session["estPan"] = true;
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "HAY UNA INTERFAZ EN PROCESO";
                Session["estPan"] = true;
            }

            Pinterfaz.Width = 20;
            Pinterfaz.Height = 20;
            Pinterfaz.Visible = false;
        }

        public async void GeneraInterfaz1(string RazonSocial, string TipoProveedor, bool grabar_en_bd = false, string numero_registros = "todos")
        {
            WebServiceInterfaz.GenerarInterfaz Generar = new WebServiceInterfaz.GenerarInterfaz();
            Generar.GeneraInterfazAsync(DropRZ.SelectedValue, DropProv.SelectedValue, true, "todos");
        }

        protected void llenarInter(string tip, string rece, string nom, int numR)
        {
            try
            {
                BD.Conectar();
                BD.CrearComando(@"insert into interfaz (fechaEjecucion,tipo,receptor,nombreArc,numRegistros,rutaArcInterfaz) 
            values (@fechaEjecucion,@tipo,@receptor,@nombreArc,@numRegistros,@rutaArcInterfaz)");
                BD.AsignarParametroCadena("@fechaEjecucion", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                BD.AsignarParametroCadena("@tipo", tip);
                BD.AsignarParametroCadena("@receptor", rece);
                BD.AsignarParametroCadena("@nombreArc", nom);
                BD.AsignarParametroEntero("@numRegistros", numR);
                BD.AsignarParametroCadena("@rutaArcInterfaz", @"archivosInterface\" + nom);
                BD.EjecutarConsulta();
                BD.Desconectar();
            }
            catch (Exception ex)
            {
                anade_linea_archivo(archivo_log, "llenarinter.- " + ex.ToString());
                BD.Desconectar();
            }
        }

        public string VerificaEspacios(string strCadena)
        {
            strCadena = strCadena.Replace("     ", " ").Trim();
            strCadena = strCadena.Replace("    ", " ").Trim();
            strCadena = strCadena.Replace("   ", " ").Trim();
            strCadena = strCadena.Replace("  ", " ").Trim();

            return strCadena;
        }

        protected string imp(int id)
        {

            string code = "";
            switch (id.ToString().Trim().Length)
            {
                case 1:
                    code = "0000000" + id.ToString().Trim();
                    break;
                case 2:
                    code = "000000" + id.ToString().Trim();
                    break;
                case 3:
                    code = "00000" + id.ToString().Trim();
                    break;
                case 4:
                    code = "0000" + id.ToString().Trim();
                    break;
                case 5:
                    code = "000" + id.ToString().Trim();
                    break;
                case 6:
                    code = "00" + id.ToString().Trim();
                    break;
                case 7:
                    code = "0" + id.ToString().Trim();
                    break;
                case 8:
                    code = id.ToString().Trim();
                    break;
            }

            return code;

        }

        protected string acHdr(string tot)
        {
            string[] var = tot.Split('.');
            //12.098
            string aux = var[1].Substring(2, 1);

            if (aux != "0")
            {

                string aux2 = var[1].Substring(0, 2);
                decimal auxTot = Convert.ToDecimal(aux2) + 1;

                tot = var[0] + "." + auxTot.ToString() + "0";

                return tot;
            }
            else
            {
                return tot;
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //--------------------ver panel generar interfaz-------------------
            Pinterfaz.Width = 500;
            Pinterfaz.Height = 170;
            Pinterfaz.Visible = true;
        }

        protected void Button37_Click(object sender, EventArgs e)
        {
            //--------------cancelar panel generar--------------
            Pinterfaz.Width = 20;
            Pinterfaz.Height = 20;
            Pinterfaz.Visible = false;
        }

        protected decimal suma(string id)
        {
            decimal suma = 0, total = 0;
            string tipo = "";
            try
            {
                BD.Conectar();
                BD.CrearComando("select tipoDeComprobante from GENERAL where idFactura=@id");
                BD.AsignarParametroCadena("@id", id);
                DbDataReader C0 = BD.EjecutarConsulta();
                if (C0.Read())
                {
                    tipo = C0[0].ToString();
                }
                BD.Desconectar();

                BD.Conectar();
                BD.CrearComando("select importe from Conceptos where id_Factura=@id");
                BD.AsignarParametroCadena("@id", id);
                DbDataReader C1 = BD.EjecutarConsulta();
                while (C1.Read())
                {
                    //decimal tot = Truncate(Convert.ToDecimal(resTot), 2);
                    suma = suma + Truncate(Convert.ToDecimal(C1[0]), 2);
                }
                BD.Desconectar();

                BD.Conectar();
                BD.CrearComando("select descuento, propinas, total from GENERAL where idFactura=@id");
                BD.AsignarParametroCadena("@id", id);
                DbDataReader C3 = BD.EjecutarConsulta();
                if (C3.Read())
                {
                    total = Truncate(Convert.ToDecimal(C3[2]), 2);
                    if (Convert.ToDouble(C3[0].ToString()) != 0.000)
                    {
                        suma = suma - Truncate(Convert.ToDecimal(C3[0].ToString().Replace("-", "")), 2);
                    }
                    if (Convert.ToDouble(C3[1].ToString()) != 0.000)
                    {
                        suma = suma + Truncate(Convert.ToDecimal(C3[1]), 2);
                    }
                }
                BD.Desconectar();


                BD.Conectar();
                BD.CrearComando("select importe,tipo from Impuestos where id_Factura=@id");
                BD.AsignarParametroCadena("@id", id);
                DbDataReader C2 = BD.EjecutarConsulta();
                while (C2.Read())
                {
                    if (C2[1].ToString() == "T")
                    {
                        suma = suma + Truncate(Convert.ToDecimal(C2[0]), 2);
                    }
                    if (C2[1].ToString() == "R")
                    {
                        if (tipo.ToLower() == "egreso")
                        {
                            suma = suma - Truncate(Convert.ToDecimal("-" + C2[0]), 2);
                        }
                        else
                        {
                            suma = suma - Truncate(Convert.ToDecimal(C2[0]), 2);
                        }
                    }
                }
                BD.Desconectar();

            }
            catch (Exception ex)
            {
                anade_linea_archivo(archivo_log, "suma.- " + ex.ToString());
                BD.Desconectar();
            }

            if (total != suma)
            {
                ajusteFIN = suma;
                decimal auxSum = 0;
                auxSum = suma - total;
                return auxSum;
            }
            else
            {
                return 0;
            }
        }

        private decimal Truncate(decimal value, int length)
        {
            if (value.ToString().Contains("."))
            {
                string[] param = value.ToString().Split('.');

                if (param[1].Length >= length)
                    return Convert.ToDecimal(param[0] + "." + param[1].Substring(0, length));
                else
                    return Convert.ToDecimal(param[0] + "." + param[1].Substring(0, param[1].Length));
            }
            else
            {
                return value;
            }
        }

        protected void HyperLink453_Click(object sender, EventArgs e)
        {
            bool si = false;
            int cont = 0;
            string nombre = "";
            foreach (GridViewRow row in GridView7.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; cont++; }
            }

            if (si == true)
            {
                if (cont == 1)
                {
                  
                    foreach (GridViewRow row in GridView7.Rows)
                    {
                        CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                        HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkInt");
                        if (chk_Seleccionar.Checked)
                        {
                            idres = hd_Seleccionafol.Value;
                            BD.Conectar();
                            BD.CrearComando("select nombreArc from Interfaz where idInterfaz=@id");
                            BD.AsignarParametroCadena("@id", idres);
                            DbDataReader DRI = BD.EjecutarConsulta();
                            if (DRI.Read())
                            {
                                nombre = DRI[0].ToString();
                            }
                            BD.Desconectar();

                            if (!(nombre.IndexOf("HDR") < 0))
                            {
                                PanelSeg.Width = 405;
                                PanelSeg.Height = 220;
                                PanelSeg.Visible = true;
                            }
                            else
                            {
                                idres = "";
                                Session["estNot"] = false;
                                Session["msjNoti"] = "DEBES SELECIONAR UN ARCHIVO DE CABECERA";
                                Session["estPan"] = true;
                            }
                        }
                    }
                }
                else
                {
                    Session["estNot"] = false;
                    Session["msjNoti"] = "HAS SELECIONADO MAS DE UN ARCHIVO";
                    Session["estPan"] = true;
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN ARCHIVO HDR";
                Session["estPan"] = true;
            }
        }

        protected void But2_Click(object sender, EventArgs e)
        {
            string grupo = "";
            bool banIn = false;
            ArrayList UUIDS = new ArrayList();
            ArrayList IDS = new ArrayList();
            string ruta = System.AppDomain.CurrentDomain.BaseDirectory;
            string Archivo = "";
            string rutaCompleta = "";
            string NombreIn = "";
            BD.Conectar();
            BD.CrearComando("select rutaArcInterfaz,nombreArc from Interfaz where idInterfaz=@id");
            BD.AsignarParametroCadena("@id", idres);
            DbDataReader DRR = BD.EjecutarConsulta();
            if (DRR.Read())
            {
                Archivo = DRR[0].ToString();
                NombreIn = DRR[1].ToString();
            }
            BD.Desconectar();

            //result = Path.ChangeExtension(goodFileName, ".old");
            if (File.Exists(ruta + Archivo) || File.Exists(ruta + Archivo.Replace(".rdy", ".txt")))
            {
                if (File.Exists(ruta + Archivo))
                {
                    File.Move(ruta + Archivo, Path.ChangeExtension(ruta + Archivo, ".txt"));
                }
                rutaCompleta = ruta + Archivo.Replace(".rdy", ".txt");
                string[] valores;
                StreamReader sr = new StreamReader(rutaCompleta);
                var linea = "";
                //linea = sr.ReadLine();

                while ((linea = sr.ReadLine()) != null)
                {
                    //linea = sr.ReadLine();
                    if (!String.IsNullOrEmpty(linea))
                    {
                        valores = linea.Split('|');
                        UUIDS.Add(valores[0]);
                    }
                }
                sr.Dispose();
                sr.Close();

                foreach (string UUID in UUIDS)
                {
                    BD.Conectar();
                    BD.CrearComando("select id_Factura from CFDI where UUID=@fol");
                    BD.AsignarParametroCadena("@fol", UUID);
                    DbDataReader DRU = BD.EjecutarConsulta();
                    if (DRU.Read())
                    {
                        IDS.Add(DRU[0].ToString());
                    }
                    BD.Desconectar();
                }

                foreach (string id in IDS)
                {
                    BD.Conectar();
                    BD.CrearComando("update GENERAL set estadoInterface='0' where idFactura=@id");
                    BD.AsignarParametroCadena("@id", id);
                    BD.EjecutarConsulta();
                    BD.Desconectar();
                    if (!banIn)
                    {
                        banIn = true;
                    }
                }
                if (banIn)
                {
                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta);
                    }

                    if (File.Exists(ruta + Archivo.Replace("HDR", "LNE")))
                    {
                        File.Delete(ruta + Archivo.Replace("HDR", "LNE"));
                    }

                    BD.Conectar();
                    BD.CrearComando("delete from Interfaz where nombreArc=@NL or nombreArc=@NH");
                    BD.AsignarParametroCadena("@NL", NombreIn.Replace("HDR", "LNE"));
                    BD.AsignarParametroCadena("@NH", NombreIn);
                    BD.EjecutarConsulta();
                    BD.Desconectar();
                }

                PanelSeg.Width = 20;
                PanelSeg.Height = 20;
                PanelSeg.Visible = false;
                idres = "";
                Response.Redirect("~/menuReceDHL/interfazArc.aspx");
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "EL ARCHIVO NO EXISTE";
                Session["estPan"] = true;
            }

        }

        protected void But_Click(object sender, EventArgs e)
        {
            PanelSeg.Width = 20;
            PanelSeg.Height = 20;
            PanelSeg.Visible = false;
            idres = "";
        }

        public async void GInterfazCom(string RazonSocial = "", string TipoProveedor = "", bool grabar_en_bd = false, string numero_registros = "todos")
        {
            GInterComp.GInterfazComplemento Generar = new GInterComp.GInterfazComplemento();
            Generar.GeneraInterfazComAsync("", "", true, "todos");
        }
        protected void hlInter_Click(object sender, EventArgs e)
        {
            try
            {

                BD.Conectar();
                BD.CrearComando(@"SELECT idComPago FROM GeneralPago WHERE edoInter=@estat");
                BD.AsignarParametroCadena("@estat", "0");
                DbDataReader DR = BD.EjecutarConsulta();
                while (DR.Read())
                {
                    allId.Add(DR[0].ToString());
                    val_Imp.Add(true);
                }
                BD.Desconectar();
            }
            catch (Exception ex)
            {
                anade_linea_archivo(archivo_log, "1.- " + ex.ToString());
                BD.Desconectar();
            }
            ////////////////////////////////////////interfaz en curso
            BD.Conectar();
            BD.CrearComando(@"SELECT idInterfaz, estatus FROM Interfaz where estatus=@sta ORDER BY idInterfaz DESC");
            BD.AsignarParametroCadena("@sta", "Procesando");
            DbDataReader DR1 = BD.EjecutarConsulta();
            if (DR1.Read())
            {
                estatus = DR1[1].ToString();
            }
            BD.Desconectar();
            if (!estatus.Equals("Procesando", StringComparison.OrdinalIgnoreCase))
            {
                /////////////////////////////////////////////////////
                if (allId.Count > 0)
                {

                    System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate (object sender1,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                    GInterComp.GInterfazComplemento Generar = new GInterComp.GInterfazComplemento();
                    try
                    {
                        new Thread(() =>
                        {
                            GInterfazCom("", "", true, "todos");
                        }).Start();

                        Session["estNot"] = true;
                        Session["msjNoti"] = "GENERANDO INTERFAZ DE COMPLEMENTO, SI NO APARECE EN EL LISTADO FAVOR DE RECARGAR LA PAGINA";
                        Session["estPan"] = true;
                        Panel56.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        Session["estNot"] = false;
                        Session["msjNoti"] = "NO ES POSIBLE CONECTAR CON EL SERVIDOR";
                        Session["estPan"] = true;
                    }
                }
                else
                {
                    Session["estNot"] = false;
                    Session["msjNoti"] = "NO HAY COMPLEMENTOS DE PAGO PARA GENERAR INTERFAZ";
                    Session["estPan"] = true;
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "HAY UNA INTERFAZ DE COMPLEMENTO DE PAGO EN PROCESO";
                Session["estPan"] = true;
            }

            Pinterfaz.Width = 20;
            Pinterfaz.Height = 20;
            Pinterfaz.Visible = false;

        }


    }
}
