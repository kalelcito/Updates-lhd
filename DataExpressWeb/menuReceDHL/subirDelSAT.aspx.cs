using Datos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

namespace DataExpressWeb.menuReceDHL
{
    public partial class subirDelSAT : System.Web.UI.Page
    {/////////////////////
        ws.RecepcionSAT ws = new ws.RecepcionSAT();
        //RecepcionSAT.RecepcionSATSoapClient ws = new RecepcionSAT.RecepcionSATSoapClient();
        //webService.InnerChannel.OperationTimeout = new TimeSpan(1, 30, 1);
        BasesDatos DB = new BasesDatos();
        System.Collections.ArrayList archivos = new System.Collections.ArrayList();
        string usuario = "";
        String filename = "";
        string[] files;
        String idres = "";
        String dirDes = "";

        int id;
        System.Collections.ArrayList mensajes = new System.Collections.ArrayList();
        Boolean archDescargados = false;
        String archivo_log = AppDomain.CurrentDomain.BaseDirectory + @"\LOG_subirSAT.txt";
        ///
        //////////////////
        string arc = "", doc = "", bck = "";
        Boolean validaCC = false;
        string Lfin = "", correoDhl = "", Lfin0 = "", Lsb = "";
        /// //////////
        /// 
        Boolean filRFC = false, filNom = false, filFechas = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || Session["adm"] == null)
            {
                Response.Redirect("~/Cerrar.aspx");
            }
        }

        protected void Button49_Click(object sender, EventArgs e)
        {
            if (cfdiSAT_ser.Checked)
            {

                if (obtenerCFDI())
                {
                    if (files.Length > 0)
                    {
                        mensaje.Text = files.Length + " facturas a procesar";
                        tipoProcesar.Visible = false;
                        facturas.Visible = true;
                    }
                    else
                    {
                        mensaje.Text = "No hay facturas descargadas";
                    }
                }
                else
                {
                    mensaje.Text = "No hay facturas descargadas";
                }

            }
            else
            {
                if (Convert.ToInt32(countArch.Text) > 0)
                {
                    mensaje.Text = archivos.Count + " facturas a procesar";
                    tipoProcesar.Visible = false;
                    facturas.Visible = true;
                }
                else
                {
                    mensaje.Text = "No hay facturas cargadas";
                }
            }
        }
        protected void borrarTempRecepcion()
        {
            try
            {
                DB.Conectar();
                DB.CrearComando("Delete from tempRecepcion");
                DB.EjecutarConsulta();
                DB.Desconectar();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void obtenerCFDI2()
        {
            borrarTempRecepcion();
            foreach (string f in archivos)
            {
                obtenerDatos(f);
            }
        }
        protected Boolean obtenerCFDI()
        {
            dirDes = obtenerDirDocs() + "Descargas\\" + rfc.SelectedValue + "\\Recibidos";
            ldirDes.Text = dirDes;
            DirectoryInfo directorio = new DirectoryInfo(dirDes);
            if (directorio.Exists)
            {
                if (tbNom.Text != "")
                {
                    filNom = true;
                }
                if (tbRFC.Text != "")
                {
                    filRFC = true;
                }
                if (tbFechaIni.Text != "" && tbFechaFin.Text != "")
                {
                    filFechas = true;
                }
                files = System.IO.Directory.GetFiles(dirDes, "*.xml", SearchOption.AllDirectories);
                borrarTempRecepcion();
                foreach (string s in files)
                {
                    System.IO.FileInfo fi = null;
                    try
                    {
                        fi = new System.IO.FileInfo(s);
                        obtenerDatos(fi.FullName);
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                return true;
            }
            return false;
        }

        public void anade_linea_archivo(string archivo, string linea)
        {
            using (StreamWriter w = File.AppendText(archivo))
            {
                w.WriteLine(linea.Replace(Environment.NewLine, ""));
                w.Flush();
                w.Close(); // Close the writer and underlying file.
            }
        }
        protected void obtenerDatos(string file)
        {
            XmlTextReader xtrReader = null;
            //comprobanteserie = "";
            String fecha2 = ""; String total = "";
            //Emisor
            String rfcEmisor = "", nombreEmisor = "";
            String UUID = "";
            Boolean banCFDI = true;
            XmlDocument xDoc = new XmlDocument();
            string cfdi = "cfdi:";
            var version = "";

            try
            {
                xDoc.Load(file);

                //Lectura de nodo  --> nodohi --> nodohi2 --> nodohi3
                XmlNodeList existe = null;
                XmlNodeList comprobante = null;
                xtrReader = new XmlTextReader(new StringReader(xDoc.OuterXml));
                existe = xDoc.GetElementsByTagName(cfdi + "Comprobante");
                if (existe.Count != 0)
                {
                    cfdi = "cfdi:";
                    comprobante = xDoc.GetElementsByTagName(cfdi + "Comprobante");
                    banCFDI = true;
                }
                else
                {
                    cfdi = "";
                    comprobante = xDoc.GetElementsByTagName("Comprobante");
                    banCFDI = false;
                }

                string az = "";
                XPathDocument x = new XPathDocument(xtrReader);
                XPathNavigator foo = x.CreateNavigator();
                foo.MoveToFollowing(XPathNodeType.Element);
                IDictionary<string, string> whatever = foo.GetNamespacesInScope(XmlNamespaceScope.All);
                foreach (String a in whatever.Keys)
                {
                    az = a;

                }

                foreach (XmlElement nodo in comprobante)
                {
                    version = nodo.GetAttribute("Version");
                    if (string.IsNullOrEmpty(version)) { version = nodo.GetAttribute("version"); }
                }
                #region Version 3.2 AND 3.3
                if (version.Equals("3.2"))
                {
                    foreach (XmlElement nodo in comprobante)
                    {
                        //Nodo Comprobante
                        fecha2 = nodo.GetAttribute("fecha");
                        total = nodo.GetAttribute("total");

                        XmlNodeList emisor = nodo.GetElementsByTagName(cfdi + "Emisor");
                        foreach (XmlElement nodohi in emisor)
                        {
                            rfcEmisor = nodohi.GetAttribute("rfc");
                            nombreEmisor = nodohi.GetAttribute("nombre");
                        }
                        XmlNodeList Complementos = nodo.GetElementsByTagName(cfdi + "Complemento");
                        existe = xDoc.GetElementsByTagName(cfdi + "Complemento");
                        if (existe.Count != 0)
                        {
                            existe = null;
                            foreach (XmlElement nodohi in Complementos)
                            {
                                XmlNodeList TimbreFiscalDigital = nodohi.GetElementsByTagName("tfd:TimbreFiscalDigital");
                                existe = xDoc.GetElementsByTagName("tfd:TimbreFiscalDigital");
                                if (existe.Count != 0)
                                {
                                    existe = null;
                                    foreach (XmlElement nodohi2 in TimbreFiscalDigital)
                                    {
                                        UUID = nodohi2.GetAttribute("UUID");

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (XmlElement nodo in comprobante)
                    {
                        fecha2 = nodo.GetAttribute("Fecha");
                        total = nodo.GetAttribute("Total");

                        XmlNodeList emisor = nodo.GetElementsByTagName(cfdi + "Emisor");
                        foreach (XmlElement nodohi in emisor)
                        {
                            rfcEmisor = nodohi.GetAttribute("Rfc");
                            nombreEmisor = nodohi.GetAttribute("Nombre");
                        }
                        XmlNodeList Complementos = nodo.GetElementsByTagName(cfdi + "Complemento");
                        existe = xDoc.GetElementsByTagName(cfdi + "Complemento");
                        if (existe.Count != 0)
                        {
                            existe = null;
                            foreach (XmlElement nodohi in Complementos)
                            {
                                XmlNodeList TimbreFiscalDigital = nodohi.GetElementsByTagName("tfd:TimbreFiscalDigital");
                                existe = xDoc.GetElementsByTagName("tfd:TimbreFiscalDigital");
                                if (existe.Count != 0)
                                {
                                    existe = null;
                                    foreach (XmlElement nodohi2 in TimbreFiscalDigital)
                                    {
                                        UUID = nodohi2.GetAttribute("UUID");

                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                if (filRFC == false || valRFC(rfcEmisor) == true)
                {
                    if (filNom == false || valNom(nombreEmisor) == true)
                    {
                        if (filFechas == false || valFechas(fecha2) == true)
                        {
                            DB.Conectar();
                            DB.CrearComando("insert into TempRecepcion (fecha,rfc,razon,uuid,archivo,centroC,interfaz,procesar,estado,nombre,filtros,total,otm,noSabana,siteOrigen,moneda) values(@fecha,@rfc,@razon,@uuid,@archivo,@centroC,@interfaz,@procesar,@estado,@nombre,@filtros,@total,@otm,@noSabana,@siteOrigen,@moneda)");
                            DB.AsignarParametroCadena("@fecha", fecha2);
                            DB.AsignarParametroCadena("@rfc", rfcEmisor);
                            DB.AsignarParametroCadena("@razon", nombreEmisor);
                            DB.AsignarParametroCadena("@uuid", UUID);
                            DB.AsignarParametroCadena("@archivo", file);
                            DB.AsignarParametroCadena("@centroC", "");
                            DB.AsignarParametroCadena("@interfaz", "SI");
                            DB.AsignarParametroCadena("@procesar", "NO");
                            DB.AsignarParametroCadena("@filtros", "SI");
                            DB.AsignarParametroCadena("@estado", "");
                            DB.AsignarParametroCadena("@nombre", "FLETES");//tipo de proveedor
                            DB.AsignarParametroCadena("@total", total);
                            DB.AsignarParametroCadena("@otm", "NO");
                            DB.AsignarParametroCadena("@noSabana", "");
                            DB.AsignarParametroCadena("@siteOrigen", "");
                            DB.AsignarParametroCadena("@moneda", "MXN");
                            DB.EjecutarConsulta();
                            DB.Desconectar();
                        }
                    }
                }

            }
            catch (Exception e)
            {
                anade_linea_archivo(archivo_log, "obtenerDatos " + e.ToString());
            }
        }
        private bool valFechas(String fecha)
        {
            DateTime fechaI = Convert.ToDateTime(tbFechaIni.Text).AddHours(0).AddMinutes(0).AddSeconds(0).AddMilliseconds(0);
            DateTime fechaF = Convert.ToDateTime(tbFechaFin.Text).AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(59);
            DateTime fechaD = Convert.ToDateTime(fecha);

            if ((fechaD.CompareTo(fechaI) > 0 || fechaD.CompareTo(fechaI) == 0) && (fechaD.CompareTo(fechaF) == 0 || fechaD.CompareTo(fechaF) < 0))
            {
                return true;
            }
            return false;
        }
        private bool valNom(String nom)
        {
            if (tbNom.Text.ToUpper().Equals(nom.ToUpper()))
            {
                return true;
            }
            return false;
        }

        private bool valRFC(String rfc)
        {
            if (tbRFC.Text.ToUpper().Equals(rfc.ToUpper()))
            {
                return true;
            }
            return false;
        }
        protected string obtenerDirDocs()
        {
            string dirDOCS = "";
            DB.Conectar();
            DB.CrearComando("select dirdocs from ParametrosSistema");
            DbDataReader DR1 = DB.EjecutarConsulta();

            while (DR1.Read())
            {
                dirDOCS = DR1[0].ToString();
            }
            DB.Desconectar();
            return dirDOCS;
        }
        protected void obtenerDirectorios()
        {
            DB.Conectar();
            DB.CrearComando(@"SELECT dirtxt,dirdocs,dirrespaldo from ParametrosSistema");
            DbDataReader DR = DB.EjecutarConsulta();
            DR.Read();
            arc = DR[0].ToString();
            doc = DR[1].ToString();
            bck = DR[2].ToString();
            DB.Desconectar();
        }
        protected void Button12_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/menuReceDHL/ComprobantesFiscales.aspx");
        }
        protected void MultipleFileUpload1_Click(object sender, FileCollectionEventArgs e)
        {
            try
            {
                String dirDoc = obtenerDirDocs() + @"Procesando\";
                ldirDes.Text = dirDoc;
                DirectoryInfo directorioOrigen = new DirectoryInfo(dirDoc);
                bool ban = false;

                if (!directorioOrigen.Exists)
                {
                    directorioOrigen.Create();
                }

                HttpFileCollection oHttpFileCollection = e.PostedFiles;
                HttpPostedFile oHttpPostedFile = null;
                if (e.HasFiles)
                {
                    for (int n = 0; n < e.Count; n++)
                    {
                        oHttpPostedFile = oHttpFileCollection[n];
                        if (oHttpPostedFile.ContentLength <= 0)
                        {
                            continue;
                        }
                        else
                        {
                            String nom = System.IO.Path.GetFileName(oHttpPostedFile.FileName);
                            String[] datos = nom.Split('.');
                            if (datos[1].Equals("xml") || datos[1].Equals("XML"))
                            {
                                ban = true;
                                oHttpPostedFile.SaveAs(dirDoc + System.IO.Path.GetFileName(oHttpPostedFile.FileName));
                                archivos.Add(dirDoc + System.IO.Path.GetFileName(oHttpPostedFile.FileName));
                                anade_linea_archivo(archivo_log, "MultipleFileUpload1_Click: " + System.IO.Path.GetFileName(oHttpPostedFile.FileName));
                            }
                        }
                    }
                    countArch.Text = archivos.Count.ToString();
                    if (archivos.Count > 0)
                    {
                        obtenerCFDI2();
                        tipoProcesar.Visible = false;
                        facturas.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alert('Los archivos fueron cargados, ahora pueder continuar.');</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alert('Solo se pueden subir archivos XML.');</script>");
                    }

                }
            }
            catch (Exception ex)
            {
                anade_linea_archivo(archivo_log, "MultipleFileUpload1_Click: " + ex.ToString());
            }
        }
        //protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        //{
        //    String dirDoc = obtenerDirDocs();
        //    //AjaxFileUpload1.SaveAs(dirDoc + @"ProcesandoSAT\" + e.FileName);

        //    //AjaxFUArchivos
        //    string nombre = e.FileName;
        //    int tamaño = e.FileSize;
        //    string Id = e.FileId;
        //    string tipo = e.ContentType;
        //    archivos.Add(dirDoc + @"ProcesandoSAT\" + e.FileName);
        //}

        protected void cfdiSAT_ser_CheckedChanged(object sender, EventArgs e)
        {
            MultipleFileUpload1.Visible = false;
            rfc.Enabled = true;
            tbRFC.Enabled = true;
            tbNom.Enabled = true;
            tbFechaIni.Enabled = true;
            tbFechaFin.Enabled = true;
        }

        protected void cfdiSAT_cli_CheckedChanged(object sender, EventArgs e)
        {
            MultipleFileUpload1.Visible = true;
            rfc.Enabled = false;
            tbRFC.Enabled = false;
            tbNom.Enabled = false;
            tbFechaIni.Enabled = false;
            tbFechaFin.Enabled = false;
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/menuReceDHL/ComprobantesFiscales.aspx");
        }

        protected void bProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                String file = "", CC = "", interfaz = "", tipProv = "", filtros = "", idFac, fecha = "", otm = "", noSabana = "", siteOrigen = "", moneda = "";

                bool AuxCC = false, AuxSab = false;

                DB.Conectar();
                DB.CrearComandoProcedimiento("DHL_spGetUsarioCFDI");
                DB.AsignarParametroProcedimiento("@prmIdUsuario", System.Data.DbType.Int32, Convert.ToInt32(Session["id_usuario"]));
                DB.AsignarParametroProcedimiento("@prmNmUsuario", System.Data.DbType.String, Convert.ToString(Session["usuario"]));
                DbDataReader DR2 = DB.EjecutarConsulta();
                if (DR2.Read())
                {
                    usuario = DR2[0].ToString();
                }
                DB.Desconectar();
                ws.getUsuarioFac(usuario);

                obtenerDirectorios();
                DB.Conectar();
                DB.CrearComando("Select idFac,archivo,centroC,interfaz,nombre,filtros,fecha,otm,noSabana,siteOrigen,moneda from tempRecepcion where procesar=@procesar");
                DB.AsignarParametroCadena("@procesar", "SI");
                DbDataReader DR = DB.EjecutarConsulta();
                while (DR.Read())
                {
                    idFac = DR[0].ToString();
                    file = DR[1].ToString();
                    CC = DR[2].ToString();
                    interfaz = DR[3].ToString();
                    tipProv = DR[4].ToString();
                    filtros = DR[5].ToString();
                    fecha = DR[6].ToString();
                    otm = DR[7].ToString();
                    noSabana = DR[8].ToString();
                    siteOrigen = DR[9].ToString();
                    moneda = DR[10].ToString();


                    if (otm == "NO")
                    {
                        if (CC != "")
                        {
                            if (validarCodGL(CC))
                            {
                                exiteCC(CC);
                                if (validaCC)
                                {
                                    procesarCFDI(idFac, file, CC, interfaz, tipProv, filtros, fecha, noSabana, siteOrigen, otm, moneda);
                                }
                                else
                                {
                                    mensajes.Add(idFac + "-No exite Centro de Costos");
                                }
                            }
                            else
                            {
                                mensajes.Add(idFac + "-Formato de Centro de Costos erroneo");
                            }
                        }
                        else
                        {
                            AuxCC = true;
                            mensajes.Add(idFac + "-El Centro de costos es obligatorio");
                        }
                    }
                    else if (otm == "SI")
                    {
                        if (noSabana != "" && siteOrigen != "")
                        {
                            if (validarSab(noSabana))
                            {
                                procesarCFDI(idFac, file, CC, interfaz, tipProv, filtros, fecha, noSabana, siteOrigen, otm, moneda);
                            }
                            else
                            {
                                mensajes.Add(idFac + "-Formato de sabana erroneo");
                            }
                        }
                        else
                        {
                            AuxSab = true;
                            mensajes.Add(idFac + "-El No. de sabana y site de origen son obligatorios");
                        }
                    }
                }
                DB.Desconectar();
                actualizarEstadoFacturas();
                gvFacturasP.DataBind();
                lbEliminarT.Visible = true;
                lbEliminarP.Visible = true;

                if (AuxCC && AuxSab)
                {
                    txtMensaje.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d40511");
                    txtMensaje.BackColor = System.Drawing.ColorTranslator.FromHtml("#E4B918");
                    lblTitulo.Text = "ADVERTENCIA !!!";
                    lblTitulo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d40511");
                    txtMensaje.Text = "Existen registros que no se procesarón por falta de Centro de costos y No. de sabana en caso de OTM. Favor de revisar el estatus de los registros para completar la información necesaria";
                    popNotificacion.Show();
                }
                else
                if (AuxCC && !AuxSab)
                {
                    txtMensaje.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d40511");
                    txtMensaje.BackColor = System.Drawing.ColorTranslator.FromHtml("#E4B918");
                    lblTitulo.Text = "ADVERTENCIA !!!";
                    lblTitulo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d40511");
                    txtMensaje.Text = "Existen registros que no se procesarón por falta de Centro de costos. Favor de revisar el estatus de los registros para completar la información necesaria";
                    popNotificacion.Show();
                }
                else
                if (!AuxCC && AuxSab)
                {
                    txtMensaje.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d40511");
                    txtMensaje.BackColor = System.Drawing.ColorTranslator.FromHtml("#E4B918");
                    lblTitulo.Text = "ADVERTENCIA !!!";
                    lblTitulo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d40511");
                    txtMensaje.Text = "Existen registros que no se procesarón por falta No. de sabana y site de origen en caso de OTM. Favor de revisar el estatus de los registros para completar la información necesaria";
                    popNotificacion.Show();
                }
            }
            catch (Exception ex)
            {
                anade_linea_archivo(archivo_log, "Procesar: " + ex.ToString());
                DB.Desconectar();
            }


        }

        protected void ButConOk_Click(object sender, EventArgs e)
        {
            popNotificacion.Hide();
        }

        protected void actualizarEstadoFacturas()
        {
            foreach (String mensaje in mensajes)
            {
                String[] datos = mensaje.Split('-');
                DB.Conectar();
                DB.CrearComando("update tempRecepcion set estado=@estado where idFac=@idFac");
                DB.AsignarParametroCadena("@estado", datos[1]);
                DB.AsignarParametroCadena("@idFac", datos[0]);
                DB.EjecutarConsulta();
                DB.Desconectar();
            }
        }
        protected void procesarCFDI(String idFac, String file, String CC, String interfaz, String tipProv, String filtros, String fecha, String noSabana, string siteOrigen, String otm, string moneda)
        {
            try
            {
                String mail = "";
                String xml = Path.GetFileName(file);
                String ruta = System.IO.Path.Combine(arc + @"manual\", xml);
                DirectoryInfo directorioOrigen = new DirectoryInfo(arc + @"manual\");

                if (!directorioOrigen.Exists)
                {
                    directorioOrigen.Create();
                }
                if (System.IO.File.Exists(ruta))//revisa si el archivo existe en al carpeta de respaldo 
                {
                    System.IO.File.Delete(ruta);
                    File.Copy(file, ruta);
                    //System.IO.File.Delete(rutaAR + nombre + ".XML");
                }
                else
                {
                    File.Copy(file, ruta);
                    //System.IO.File.Delete(rutaAR + nombre + ".XML");
                }
                String[] archs = Directory.GetFiles(arc + @"manual\");
                RecepcionSAT.ArrayOfString files = new RecepcionSAT.ArrayOfString();
                foreach (String arch in archs)
                {
                    files.Add(arch);
                }
                ws.Factura(archs, bck, doc, arc + @"manual\", mail);
                String corr = "", noms = "";
                if (Lfin.IndexOf("*") < 0 && Lfin.Length > 0)
                {
                    string nomFin = Lfin.Replace("<br>", "");
                    string[] valF = nomFin.Split(':');
                    if (Lfin0.IndexOf("@") > 0)
                    {
                        corr = Lfin0;
                        noms = valF[1];
                        ws.getFinancieros(Lfin0, valF[1]);
                    }
                    else
                    {

                        noms = valF[1];
                        ws.getFinancieros("", valF[1]);
                    }
                }
                else
                {
                    ws.getFinancieros("", "");
                }
                //webService.msj = "";
                //webService.emails = email;
                String parentI = "";
                if (otm == "SI" && noSabana != "")
                {
                    parentI = "OTM";
                }
                else
                {
                    if (tipProv == "RENTAS")
                    {
                        parentI = "REN";
                    }
                    else
                    {
                        parentI = "ORACLE";
                    }
                }
                //DateTime hoy = DateTime.Now;
                //string an = hoy.ToString("yyyy");
                //fecha = fecha.Replace("/", "-");
                //string[] fh = fecha.Split('-');
                //if (Convert.ToInt32(fh[0]) == Convert.ToInt32(an))
                //{
                //    //fecha2 = "2014-10-02T11:11:11";
                //    TimeSpan ts = hoy - Convert.ToDateTime(fecha);
                //    int dias = ts.Days + 2;
                //webService.getTimFac(dias.ToString()); //dias recepcion 30
                Boolean sAdm, valInt;
                if (filtros.Equals("SI"))
                {
                    sAdm = (false);
                }
                else
                {
                    sAdm = (true);
                }
                if (interfaz.Equals("SI"))
                {
                    valInt = (true);
                }
                else
                {
                    valInt = (false);
                }

                String sms = ws.leerIndividualX(arc + @"manual\" + xml, bck, moneda, CC, tipProv, parentI, sAdm, valInt, corr, noms, archs, doc, arc + @"manual\", mail, noSabana, siteOrigen, Session["id_usuario"].ToString());
                mensajes.Add(idFac + "-" + sms);
                //}
                //else
                //{
                //    mensajes.Add(idFac + "-La fecha de emisión del comprobante no corresponde al año en curso");
                //}
            }
            catch (Exception ex)
            {
                anade_linea_archivo(archivo_log, "ProcesarCFDI: " + ex.ToString());
            }
        }

        protected void siteSab(String siteO)
        {
            string re = "";
            re = DatosFinOTM(siteO);
            if (re != "")
            {
                Lsb = "Financiero DHL:<br>" + re;
            }
            else
            {
                //Lsb.Text = "*El Site de Origen no existe, <br> no podrá subir su facura.";
                Lsb = "*El Site de Origen puede no ser válido";
            }
        }
        protected string DatosFinOTM(string site)
        {
            //string ruta = ruta.Replace("XdService\\Interfaz\\bin\\Debug\\datos.txt", "Datos\\datos.txt");
            string respDat = "";
            bool banF = false;
            string ruta = System.AppDomain.CurrentDomain.BaseDirectory + @"catalogos\Catalogo-Analistas.txt";
            string[] valores = new string[11];
            StreamReader sr = new StreamReader(ruta);
            var linea = "";
            correoDhl = "";
            linea = sr.ReadLine();

            while ((linea = sr.ReadLine()) != null)
            {
                // linea = sr.ReadLine();
                if (!String.IsNullOrEmpty(linea))
                {
                    valores = linea.Split('|');
                    if (valores[3].Trim().Equals(site))
                    {
                        //banF = true;
                        //if (correoDhl != "")
                        //{
                        //    correoDhl = correoDhl + "," + valores[7];
                        //}
                        //else
                        //{
                        correoDhl = valores[7];
                        Lfin0 = valores[7];
                        //}

                        //if (respDat != "")
                        //{
                        //    respDat = valores[5] + ", <br>" + respDat;
                        //}
                        //else
                        //{
                        respDat = valores[5];
                        //}
                    }
                }

            }
            sr.Dispose();
            sr.Close();

            if (!banF)
            {
                respDat = DatosFinOTM2(site);
            }

            return respDat;

        }

        protected string DatosFinOTM2(string site)
        {
            //string ruta = ruta.Replace("XdService\\Interfaz\\bin\\Debug\\datos.txt", "Datos\\datos.txt");
            string respDat = "";
            string ruta = System.AppDomain.CurrentDomain.BaseDirectory + @"catalogos\Catalogo-Analistas2.txt";
            string[] valores = new string[7];
            StreamReader sr = new StreamReader(ruta);
            var linea = "";
            linea = sr.ReadLine();

            while ((linea = sr.ReadLine()) != null)
            {
                //linea = sr.ReadLine();
                if (!String.IsNullOrEmpty(linea))
                {
                    valores = linea.Split('|');
                    if (valores[2].Trim().Equals(site))
                    {
                        //if (respDat != "")
                        //{
                        //    respDat = valores[5] + ", <br>" + respDat;
                        //}
                        //else
                        //{
                        respDat = valores[5];
                        // }
                    }
                }

            }
            sr.Dispose();
            sr.Close();
            return respDat;

        }

        protected void gvFacturasP_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvFacturasP.SelectedRow;
            Session["id"] = Convert.ToInt32(gvFacturasP.DataKeys[row.RowIndex].Value);

            DB.Conectar();
            DB.CrearComandoProcedimiento("DHL_spGetFacturaSAT");
            DB.AsignarParametroProcedimiento("@prmIdFactura", System.Data.DbType.Int32, Convert.ToInt32(Session["id"]));
            DbDataReader DR2 = DB.EjecutarConsulta();
            if (DR2.Read())
            {
                lblPrmFecha.Text = DR2[0].ToString();
                lblPrmRFC.Text = DR2[1].ToString();
                lblPrmRaz.Text = DR2[2].ToString();
                lblPrmUUID.Text = DR2[3].ToString();
                txtCC.Text = DR2[4].ToString();
                dplInterfaz.SelectedValue = DR2[5].ToString();
                dplProcesar.SelectedValue = DR2[6].ToString();
                dplTipoProv.SelectedValue = DR2[7].ToString();
                dplFiltros.SelectedValue = DR2[8].ToString();
                lblPrmTotal.Text = DR2[9].ToString();
                dplOtm.SelectedValue = DR2[10].ToString();
                txtSabana.Text = DR2[11].ToString();
                txtSite.Text = DR2[12].ToString();
                dplMoneda.SelectedValue = DR2[13].ToString();
            }
            DB.Desconectar();

            if (dplOtm.SelectedValue == "SI")
            {
                txtCC.Text = string.Empty;
                txtCC.Enabled = false;
                txtSite.Enabled = true;
                txtSabana.Enabled = true;
                lblError.Visible = false;
            }
            else
            {
                txtSabana.Text = string.Empty;
                txtSite.Text = string.Empty;
                txtSite.Enabled = false;
                txtSabana.Enabled = false;
                txtCC.Enabled = true;
                lblError.Visible = false;
            }

            popEditar.Show();
        }

        protected void dplOtm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dplOtm.SelectedValue == "SI")
            {
                txtCC.Text = string.Empty;
                txtCC.Enabled = false;
                txtSite.Enabled = true;
                txtSabana.Enabled = true;
                lblError.Visible = false;
                popEditar.Show();
            }
            else
            {
                txtSabana.Text = string.Empty;
                txtSite.Text = string.Empty;
                txtSite.Enabled = false;
                txtSabana.Enabled = false;
                txtCC.Enabled = true;
                lblError.Visible = false;
                popEditar.Show();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            popEditar.Hide();
            Session["id"] = null;
        }

        protected void txtCC_TextChanged(object sender, EventArgs e)
        {
            if (!validarCodGL(txtCC.Text))
            {
                lblError.Text = "Formato de Centro de Costos erroneo";
                lblError.Visible = true;
                popEditar.Show();
            }
            else
            {
                lblError.Visible = false;
                popEditar.Show();
            }
        }

        protected void txtSabana_TextChanged(object sender, EventArgs e)
        {
            if (!validarSab(txtSabana.Text))
            {
                lblError.Text = "Formato de sabana erroneo";
                lblError.Visible = true;
                popEditar.Show();
            }
            else
            {
                lblError.Visible = false;
                popEditar.Show();
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                DB.Conectar();
                DB.CrearComandoProcedimiento("DHL_spUpFacturaSAT");
                DB.AsignarParametroProcedimiento("@prmId", System.Data.DbType.Int32, Convert.ToInt32(Session["id"]));
                DB.AsignarParametroProcedimiento("@prmTipoProv", System.Data.DbType.String, dplTipoProv.SelectedValue);
                DB.AsignarParametroProcedimiento("@prmOtm", System.Data.DbType.String, dplOtm.SelectedValue);
                DB.AsignarParametroProcedimiento("@prmCC", System.Data.DbType.String, txtCC.Text);
                DB.AsignarParametroProcedimiento("@prmSabana", System.Data.DbType.String, txtSabana.Text);
                DB.AsignarParametroProcedimiento("@prmSite", System.Data.DbType.String, txtSite.Text);
                DB.AsignarParametroProcedimiento("@prmMoneda", System.Data.DbType.String, dplMoneda.SelectedValue);
                DB.AsignarParametroProcedimiento("@prmProcesar", System.Data.DbType.String, dplProcesar.SelectedValue);
                DB.AsignarParametroProcedimiento("@prmInterfaz", System.Data.DbType.String, dplInterfaz.SelectedValue);
                DB.AsignarParametroProcedimiento("@prmFiltros", System.Data.DbType.String, dplFiltros.SelectedValue);
                DB.EjecutarConsulta();
                DB.Desconectar();

                gvFacturasP.DataBind();
                Session["id"] = null;
                popEditar.Hide();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
                lblError.Visible = true;
                popEditar.Show();
            }
        }

        protected bool validarSab(string sab)
        {
            string[] saba = sab.Split('-');
            if (saba[0].Length == 8 && saba[1].Length == 4)
            {
                string nuevos = sab.Replace("-", "");
                bool aux = true;

                foreach (var c in nuevos)
                {
                    if (!(c >= '0' && c <= '9'))
                    {
                        aux = false;
                    }
                }
                if (aux)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //return true;
            }
            else
            {
                return false;
            }


        }

        protected void exiteCC(String CC)
        {
            string[] puntos = CC.Split('.');
            string re = "";
            re = DatosFinOrac(puntos[0], puntos[1]);
            if (re != "")
            {
                Lfin = "Financiero DHL:<br>" + re;
                validaCC = true;
            }
            else
            {
                Lfin = "*El centro de Costo no existe, <br> no podrá subir su facura.";
                validaCC = false;
            }
        }
        protected string DatosFinOrac(string CC, string cli)
        {
            //string ruta = ruta.Replace("XdService\\Interfaz\\bin\\Debug\\datos.txt", "Datos\\datos.txt");
            string respDat = "";
            bool banF = false;
            string ruta = System.AppDomain.CurrentDomain.BaseDirectory + @"catalogos\Catalogo-Analistas.txt";
            string[] valores = new string[11];
            StreamReader sr = new StreamReader(ruta);
            var linea = "";
            linea = sr.ReadLine();
            correoDhl = "";

            while ((linea = sr.ReadLine()) != null)
            {
                if (!String.IsNullOrEmpty(linea))
                {
                    valores = linea.Split('|');
                    if (valores[0].Trim().Equals(CC) && valores[3].Trim().Equals(cli))
                    {
                        banF = true;
                        correoDhl = valores[7].Trim();
                        Lfin0 = valores[7].Trim();

                        respDat = valores[5].Trim();
                    }
                }

            }
            sr.Dispose();
            sr.Close();

            if (!banF)
            {
                respDat = DatosFinOracSeg(CC, cli);
            }

            return respDat;

        }
        protected string DatosFinOracSeg(string CC, string cli)
        {
            string respDat = "";
            string ruta = System.AppDomain.CurrentDomain.BaseDirectory + @"catalogos\Catalogo-Analistas2.txt";
            string[] valores = new string[7];
            StreamReader sr = new StreamReader(ruta);
            var linea = "";
            linea = sr.ReadLine();

            while ((linea = sr.ReadLine()) != null)
            {
                if (!String.IsNullOrEmpty(linea))
                {
                    valores = linea.Split('|');
                    if (valores[0].Trim().Equals(CC) && valores[2].Trim().Equals(cli))
                    {
                        respDat = valores[5];
                    }
                }

            }
            sr.Dispose();
            sr.Close();
            return respDat;

        }
        protected bool validarCodGL(string text)
        {
            if (!(text.IndexOf(".") < 0))
            {
                string[] puntos = text.Split('.');
                if (puntos.Length == 5)
                {
                    if (puntos[0].Length == 4 && puntos[1].Length == 4 && puntos[2].Length == 4 && puntos[3].Length == 2 && puntos[4].Length == 3)
                    {
                        bool aux = true, aux2 = true;
                        string cont = puntos[0] + puntos[1] + puntos[2];
                        string cont2 = puntos[3].ToUpper() + puntos[4].ToUpper();
                        foreach (var c in cont)
                        {
                            if (!(c >= '0' && c <= '9'))
                            {
                                aux = false;
                            }
                        }

                        foreach (var c in cont2)
                        {
                            if (!((c >= '0' && c <= '9') || !(c >= 'a' && c <= 'z') || !(c >= 'A' && c <= 'Z')))
                            {
                                aux2 = false;
                            }
                        }


                        if (aux && aux2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        protected void lbEliminarT_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(ldirDes.Text);

            foreach (FileInfo file in downloadedMessageInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
            {
                dir.Delete(true);
            }
            Session["mensajeCon"] = "Los Archivos fueron eliminados.";
            Session["confirmacion"] = 2;
            Response.Redirect("~/notificacionElim.aspx");
            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alert('Los archivos fueron eliminados');location.href = '/menuReceDHL/ComprobantesFiscales.aspx'; </script>");
        }
        protected void lbEliminarP_Click(object sender, EventArgs e)
        {
            try
            {
                DB.Conectar();
                DB.CrearComando("Select archivo from TempRecepcion");
                DbDataReader DR = DB.EjecutarConsulta();
                while (DR.Read())
                {
                    File.Delete(DR[0].ToString());
                }
                DB.Desconectar();
                Session["mensajeCon"] = "Los Archivos fueron eliminados.";
                Session["confirmacion"] = 2;
                Response.Redirect("~/notificacionElim.aspx");

            }
            catch (Exception ex)
            {
                DB.Desconectar();
                anade_linea_archivo(archivo_log, "EliminarP: " + ex.ToString());
            }

            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alert('Los archivos fueron eliminados');location.href = '/menuReceDHL/ComprobantesFiscales.aspx'; </script>");
        }


    }
}
