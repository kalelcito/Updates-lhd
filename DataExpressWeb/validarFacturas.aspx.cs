using Control;
using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;
using ValSign;

namespace DataExpressWeb
{
    public partial class validarFacturas : System.Web.UI.Page
    {
        Facturas FAC;

        BasesDatos DB = new BasesDatos();
        Validacion val;
        static bool resp;
        string arc, pdf, bck;
        ArrayList docLAdi = new ArrayList();
        ArrayList docLOtm = new ArrayList();
        string correoDhl = "";
        string nomFin = "";
        string usuario = "";
        Boolean validaCC = false;
        String archivo_log = AppDomain.CurrentDomain.BaseDirectory + @"logErrorNEW\ErrorValFAC " + System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").Replace("T", "_").Replace("-", "_").Substring(0, 10) + ".txt";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null || Session["adm"] != null || Session["proveedorTipe"] != null)
            {
                DB.Conectar();
                DB.CrearComando(@"SELECT dirtxt,dirdocs,dirrespaldo from ParametrosSistema");
                DbDataReader DR = DB.EjecutarConsulta();
                DR.Read();
                arc = DR[0].ToString();
                pdf = DR[1].ToString();
                bck = DR[2].ToString();
                DB.Desconectar();
                if (Session["proveedorTipe"].ToString() == "FLETES")
                {
                    CheckSab.Visible = true;
                }

                //Textim.Text = "30";
                if (Session["adSub"].ToString() == "Admin")
                {
                    LabTim.Visible = true;
                    Textim.Visible = true;
                    moneda.Visible = true;
                    this.CheckAnticipo.Visible = false;
                }
                else
                {
                    LabTim.Visible = false;
                    Textim.Visible = false;
                    moneda.Visible = false;
                    this.CheckAnticipo.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/Cerrar.aspx");
            }
            //Panel3.Visible = false;
            //SAT.ConsultaCFDIService client = new SAT.ConsultaCFDIService();

            //client.
            //ConsultaCFDIServiceClient client = new ConsultaCFDIServiceClient();

        }

        public void respVal(bool resp2)
        {

            resp = resp2;
        }

        protected String EmisorRFC(String file)
        {
            XmlTextReader xtrReader = null;
            //Emisor
            String rfcEmisor = "";
            XmlDocument xDoc = new XmlDocument();
            string cfdi = "cfdi:";
            Boolean banCFDI = true;

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

                    XmlNodeList emisor = nodo.GetElementsByTagName(cfdi + "Emisor");
                    foreach (XmlElement nodohi in emisor)
                    {
                        rfcEmisor = nodohi.GetAttribute("rfc");
                    }

                }
                return rfcEmisor;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        protected void bSubir_Click(object sender, EventArgs e)
        {
            try
            {
                string PI = "";

                lMsj.Text = "";
                val = new Validacion();
                string ppxml = fuXML.PostedFile.FileName;
                string pppdf = fuPDF.PostedFile.FileName;

                imgFolSerx.Visible = false;
                //imbVigCerok.Visible = false;
                imgStatusok.Visible = false; imgStatusx.Visible = false;
                //

                imgSellook.Visible = false;

                imgSellook.Visible = false;
                imgSellox.Visible = false;
                imgCOx.Visible = false;


                imgCerok.Visible = false;

                imgCerx.Visible = false;

                imgFolSerok.Visible = false;
                imgAprobok.Visible = false;

                imgAprobx.Visible = false;


                imgFolSerx.Visible = false;

                int fPDF = 0;
                int fXML = 0;
                int fCompra = 0;
                if (fuPDF.PostedFile != null) { fPDF = fuPDF.PostedFile.ContentLength; }
                if (fuXML.PostedFile != null) { fXML = fuXML.PostedFile.ContentLength; }
                if (fuCompra.PostedFile != null) { fCompra = fuCompra.PostedFile.ContentLength; }

                if (fuPDF.PostedFile == null) { fPDF = 0; }
                if (fuXML.PostedFile == null) { fXML = 0; }
                if (fuCompra.PostedFile == null) { fCompra = 0; }

                if (fPDF < 5097152 && fXML < 5097152 && fCompra < 5097152)
                {
                    if (ppxml != "")
                    {
                        if (pppdf != "")
                        {
                            string rutaXML = Path.GetDirectoryName(fuXML.PostedFile.FileName);
                            string rutaPDF = Path.GetDirectoryName(fuPDF.PostedFile.FileName);
                        }
                    }
                    string noCert = "";
                    //FAC.emails = tbcorreo.Text;         
                    if (fuCertificado.HasFile || chCertificado.Enabled)
                    {

                        String fnCER = fuCertificado.FileName;
                        if ((fuXML.HasFile && fuPDF.HasFile && fuCompra.HasFile) || (fuXML.HasFile && fuPDF.HasFile && CheckSab.Checked))
                        {
                            String fnCompra = "";
                            String fnXML = fuXML.FileName.Replace("&", "_").Replace("#", "").Replace("+", "").Trim();
                            String fnPDF = fnXML.Replace(".XML", ".pdf").Replace(".xml", ".pdf").Replace("&", "_").Replace("#", "").Replace("+", "").Trim();
                            String feXML = System.IO.Path.GetExtension(fuXML.FileName).ToLower();
                            String fePDF = System.IO.Path.GetExtension(fuPDF.FileName).ToLower();
                            string feCom = System.IO.Path.GetExtension(fuCompra.FileName).ToLower();
                            if (!CheckSab.Checked)
                            {
                                fnCompra = fuCompra.FileName.Replace("&", "_").Replace("#", "").Replace("+", "").Trim();
                            }
                            else
                            {
                                fnCompra = "";
                            }



                            if (feXML == ".XML" || feXML == ".xml")
                            {
                                if (fePDF == ".PDF" || fePDF == ".pdf")
                                {
                                    if ((!CheckSab.Checked && (feCom == ".PDF" || feCom == ".pdf")) || (CheckSab.Checked))
                                    {
                                        if (CodCont.Text != "" || CheckSab.Checked)
                                        {
                                            string codicoCon = CodCont.Text + "." + CodCont0.Text + "." + CodCont1.Text + "." + CodCont2.Text + "." + CodCont3.Text;
                                            if ((validarCodGL(codicoCon)) || (CheckSab.Checked && TextSab.Text != "" && siteSab.Text != ""))
                                            {
                                                if (!CheckSab.Checked || (CheckSab.Checked && validarSab(TextSab.Text + "-" + TextSab1.Text)))
                                                {
                                                    if (!CheckSab.Checked || (CheckSab.Checked && docAdi.Items.Count > 0))
                                                    {
                                                        //if (!Lmoneda.SelectedValue.Equals("Selecciona Moneda"))
                                                        //{
                                                        if ((CheckSab.Checked) || (!CheckSab.Checked && Lfin.Text.IndexOf("*") < 0))
                                                        {
                                                            try
                                                            {
                                                                int auxI = docAdi.Items.Count;
                                                                int auxO = Lotm.Items.Count;

                                                                fuXML.PostedFile.SaveAs(arc + @"manual\" + fnXML.Replace(" ", ""));
                                                                fuPDF.PostedFile.SaveAs(arc + @"manual\" + fnPDF.Replace(" ", ""));
                                                                if (fuCompra.HasFile)
                                                                {
                                                                    fuCompra.PostedFile.SaveAs(arc + @"manual\" + fnCompra.Replace(" ", ""));
                                                                }

                                                                String emi = EmisorRFC(arc + @"manual\" + fnXML.Replace(" ", ""));
                                                                String fecha = DateTime.Today.ToString("yyyy/MM/dd");
                                                                fecha = fecha.Replace("/", @"\") + @"\";
                                                                FileInfo fileInfoX = new FileInfo(pdf + fecha + emi.Replace("&", "_") + @"\" + fnXML.Replace(" ", ""));
                                                                FileInfo fileInfoP = new FileInfo(pdf + fecha + emi.Replace("&", "_") + @"\" + fnPDF.Replace(" ", ""));
                                                                FileInfo fileInfoO = new FileInfo(pdf + fecha + emi.Replace("&", "_") + @"\" + fnCompra.Replace(" ", ""));
                                                                if (fileInfoX.Exists)
                                                                {
                                                                    lMsj.Text = "Existe un XML con el mismo nombre, por favor modificarlo.";
                                                                    lbarrayLog.Text = "";
                                                                    //docAdi.Items.Clear();
                                                                    goto ContinuarFinal;
                                                                }
                                                                if (fileInfoP.Exists)
                                                                {
                                                                    lMsj.Text = "Existe un PDF con el mismo nombre, por favor modificarlo.";
                                                                    //docAdi.Items.Clear();
                                                                    lbarrayLog.Text = "";
                                                                    goto ContinuarFinal;
                                                                }
                                                                if (fileInfoO.Exists)
                                                                {
                                                                    lMsj.Text = "Existe una Orden de Compra con el mismo nombre, por favor modificarlo.";
                                                                    //docAdi.Items.Clear();
                                                                    lbarrayLog.Text = "";
                                                                    goto ContinuarFinal;
                                                                }

                                                                tbMsj.Text += "Procesando.....";

                                                                String[] files = Directory.GetFiles(arc + @"manual\");
                                                                string auxId = Session["id_usuario"].ToString();

                                                                FAC = new Facturas(files, bck, pdf, arc + @"manual\", tbcorreo.Text, auxId);



                                                                if (auxI != 0)
                                                                {
                                                                    for (int x = 0; x < auxI; x++)
                                                                    {
                                                                        string va = docAdi.Items[x].Text + "|" + docAdi.Items[x].Value;

                                                                        FAC.getLAdi(va);
                                                                        //docLAdi.Add(va);

                                                                    }
                                                                }


                                                                //  FAC.getArrayLAdi(docLAdi);

                                                                if (auxO != 0)
                                                                {
                                                                    for (int x = 0; x < auxO; x++)
                                                                    {
                                                                        string va = Lotm.Items[x].Text + "|" + Lotm.Items[x].Value;
                                                                        docLOtm.Add(va);
                                                                    }
                                                                }


                                                                if (CheckSab.Checked)
                                                                {
                                                                    FAC.getSabana(TextSab.Text + "-" + TextSab1.Text);
                                                                    FAC.getSiteOr(siteSab.Text);
                                                                }
                                                                else
                                                                {
                                                                    FAC.getSabana("");
                                                                    FAC.getSiteOr("");
                                                                }


                                                                if (!CheckSab.Checked)
                                                                    if (Lfin.Text.IndexOf("*") < 0)
                                                                    {
                                                                        string nomFin = Lfin.Text.Replace("<br>", "");
                                                                        string[] valF = nomFin.Split(':');
                                                                        //Financiero DHL:<br>MIRIAM COLIN VALENCIA, <br>EDUARDO FIERRO GUTIERREZ
                                                                        //if (correoDhl.IndexOf("@") > 0)
                                                                        if (Lfin0.Text.IndexOf("@") > 0)
                                                                        {
                                                                            //FAC.getFinancieros(correoDhl, valF[1]);
                                                                            FAC.getFinancieros(Lfin0.Text, valF[1]);
                                                                            //correoDhl = "";
                                                                        }
                                                                        else
                                                                        {
                                                                            FAC.getFinancieros("", valF[1]);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        FAC.getFinancieros("", "");
                                                                    }
                                                                else
                                                                {
                                                                    if (Lsb.Text.IndexOf("*") < 0)
                                                                    {
                                                                        string nomFin = Lsb.Text.Replace("<br>", "");
                                                                        string[] valF = nomFin.Split(':');
                                                                        //Financiero DHL:<br>MIRIAM COLIN VALENCIA, <br>EDUARDO FIERRO GUTIERREZ
                                                                        //if (correoDhl.IndexOf("@") > 0)
                                                                        if (Lfin0.Text.IndexOf("@") > 0)
                                                                        {
                                                                            //FAC.getFinancieros(correoDhl, valF[1]);
                                                                            FAC.getFinancieros(Lfin0.Text, valF[1]);
                                                                            //correoDhl = "";
                                                                        }
                                                                        else
                                                                        {
                                                                            FAC.getFinancieros("", valF[1]);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        FAC.getFinancieros("", "");
                                                                    }
                                                                }

                                                                FAC.msj = "";
                                                                FAC.getSesionAdm(Convert.ToBoolean(Session["adm"]));
                                                                FAC.emails = tbcorreo.Text;
                                                                FAC.getMon(Lmoneda.SelectedValue);
                                                                FAC.getCadCont(codicoCon);
                                                                FAC.getNomOrden(fnCompra);


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

                                                                FAC.getUsuarioFac(usuario);

                                                                if (prop.Text != "")
                                                                {
                                                                    FAC.getPropi(Convert.ToDouble(prop.Text));
                                                                }
                                                                else
                                                                {
                                                                    FAC.getPropi(Convert.ToDouble(0.0));
                                                                }
                                                                FAC.getTipoProveedor(Session["proveedorTipe"].ToString());
                                                                if (CheckBox2.Checked)
                                                                {
                                                                    FAC.getPropi(Convert.ToInt32(prop.Text));
                                                                }
                                                                if (Session["proveedorTipe"].ToString() == "FLETES" && CheckSab.Checked)
                                                                {
                                                                    PI = "OTM";
                                                                    FAC.getParentInv(PI);
                                                                }
                                                                else if (Session["proveedorTipe"].ToString() == "RENTAS")
                                                                {
                                                                    PI = "REN";
                                                                    FAC.getParentInv(PI);
                                                                }
                                                                else
                                                                {
                                                                    PI = "ORACLE";
                                                                    FAC.getParentInv(PI);
                                                                }


                                                                FAC.getTimFac(Textim.Text);

                                                                //FAC.TIPOORDEN = "Proveedor";
                                                                if (fuCertificado.HasFile)
                                                                {
                                                                    string rutaCER = Path.GetDirectoryName(fuCertificado.PostedFile.FileName);
                                                                    fuCertificado.PostedFile.SaveAs(bck + fnCER);
                                                                    FAC.setCertificado(val.extraerCertificado(bck + fnCER));
                                                                    noCert = val.extraerNoCertificado(bck + fnCER);
                                                                    System.IO.File.Delete(bck + fnCER);
                                                                }
                                                                FAC.getRefBancaria(this.tbRefB.Text);
                                                                FAC.leerIndividual(arc + @"manual\" + fnXML.Replace(" ", ""));

                                                                //Estatus general
                                                                lbarrayLog.Text = FAC.getmsgarrayLog();

                                                                //if (FAC.getbanValCadena() && FAC.getbanstatusCer() && FAC.getbanexistenciaCer())
                                                                if (FAC.getbanValCadena())
                                                                { imgStatusok.Visible = true; }
                                                                else { imgStatusx.Visible = true; }
                                                                //
                                                                if (FAC.getbanValCadena())
                                                                {
                                                                    imgSellook.Visible = true;
                                                                    imgCOok.Visible = true;
                                                                }
                                                                else
                                                                {
                                                                    imgSellox.Visible = true;
                                                                    imgCOx.Visible = true;
                                                                }

                                                                if (FAC.getbanexistenciaCer())
                                                                {
                                                                    imgCerok.Visible = true;
                                                                }
                                                                else { imgCerx.Visible = true; }

                                                                //Ya no se revisa individualmente los certificados
                                                                //if (FAC.getbanVigCer())
                                                                //{
                                                                //    imbVigCerok.Visible = true;
                                                                //}
                                                                //else { imgVigCerx.Visible = true; }


                                                                if (FAC.getbanCFDI())
                                                                {
                                                                    if (FAC.getbanfolser())
                                                                    {
                                                                        imgFolSerok.Visible = true;
                                                                        imgAprobok.Visible = true;
                                                                    }
                                                                    else
                                                                    {

                                                                        if (FAC.getestadovalf() == "3")
                                                                        {
                                                                            imgAprobx.Visible = true;

                                                                        }
                                                                        if (FAC.getestadovalf() == "1")
                                                                        {
                                                                            imgFolSerx.Visible = true;

                                                                        }
                                                                    }

                                                                }

                                                                docAdi.Items.Clear();
                                                                Padi.Visible = false;

                                                                String cadDet = "";


                                                                lbVersion.Text = FAC.getVersion();
                                                                lbRFC.Text = FAC.getRFCEMISOR();
                                                                lbFolioSerie.Text = FAC.getFolio() + FAC.getSerie();
                                                                lbAprobacion.Text = FAC.getNoAprobacion() + FAC.getAnoAprobacion();
                                                                lbEstructura.Text = FAC.getmsgEstructura();
                                                                lbCertificado.Text = FAC.getNoCertificado();
                                                                tbCO.Text = FAC.getCO();
                                                                tbSello.Text = FAC.getSello();



                                                                if (FAC.getmsgarrayLog().IndexOf("RE008") != -1)
                                                                {
                                                                    tbOtros.Text = "La factura, ya fue procesada.Fecha de recepción:" + Environment.NewLine + FAC.getFechaRec();

                                                                    if (!FAC.getbanValRetencion())
                                                                    {
                                                                        lbarrayLog.Text = "La factura contiene retenciones ISR";
                                                                        // tbOtros.Text = "La factura contiene retenciones ISR";
                                                                    }
                                                                }
                                                                else { tbOtros.Text = ""; }


                                                                //Panel3.Visible = true;
                                                                tbMsj.Text = "Validación Completa.." + Environment.NewLine;
                                                                if (FAC.getNoCertificado() != noCert && fuCertificado.HasFile)
                                                                {
                                                                    tbMsj.Text = "El certificado no corresponde";
                                                                }
                                                                else
                                                                {
                                                                    if (!String.IsNullOrEmpty(FAC.getVersion()))
                                                                    {
                                                                        tbMsj.Text += "Versión del Comprobante: " + FAC.getVersion() + Environment.NewLine;
                                                                    }
                                                                    tbMsj.Text += "Resultado de la Validación. " + Environment.NewLine + Environment.NewLine;
                                                                    tbMsj.Text += FAC.msj;//.Replace(Environment.NewLine,"<br>");
                                                                    if (!String.IsNullOrEmpty(FAC.getCO()))
                                                                    {
                                                                        tbMsj.Text += Environment.NewLine + "Cadena Original: " + Environment.NewLine + FAC.getCO();
                                                                    }
                                                                    if (!String.IsNullOrEmpty(FAC.getNoCertificado()))
                                                                    {
                                                                        tbMsj.Text += Environment.NewLine + "Certificado: " + Environment.NewLine + FAC.getNoCertificado();
                                                                    }
                                                                }

                                                                int i = 0;
                                                                if (!string.IsNullOrEmpty(FAC.IDEFAC))
                                                                {
                                                                    var ObjMyService = new wsRetenciones.Retenciones();
                                                                    var correo = Session["correo"] != null ? Session["correo"].ToString() : "";
                                                                    var result = ObjMyService.retencionFactura(FAC.IDEFAC, correo);
                                                                }
                                                                ContinuarFinal:
                                                                int aux = 0;
                                                                // Response.Redirect("~/Documentos.aspx");
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                tbMsj.Text = "No se pudieron validar los archivos " + ex.Message;
                                                                if (fuCertificado.HasFile)
                                                                {
                                                                    System.IO.File.Delete(bck + fnCER);
                                                                }
                                                                System.IO.File.Delete(bck + fnPDF.Replace(" ", ""));
                                                                System.IO.File.Delete(bck + fnXML.Replace(" ", ""));
                                                            }
                                                            //}
                                                            //else 
                                                            //{
                                                            //    lMsj.Text = "Seleccione el tipo de Moneda";
                                                            //}
                                                        }
                                                        else
                                                        {
                                                            if (CheckSab.Checked)
                                                            {
                                                                lMsj.Text = "El comprobante no puede ser validado <br> el Site de origen no existe";
                                                                docAdi.Items.Clear();
                                                                Padi.Visible = false;
                                                            }
                                                            else
                                                            {
                                                                lMsj.Text = "El comprobante no puede ser validado <br> el Centro de Costos no existe";
                                                                docAdi.Items.Clear();
                                                                Padi.Visible = false;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        lMsj.Text = "Debes seleccionar como mínimo un documento adicional <br/> (este documento debe ser la sabana)";
                                                        docAdi.Items.Clear();
                                                        Padi.Visible = false;
                                                    }
                                                }
                                                else
                                                {
                                                    lMsj.Text = "Formato de Sabana inválido  <br/> ejemplo:00000000-0000 (solo caracteres numéricos)";
                                                    docAdi.Items.Clear();
                                                    Padi.Visible = false;
                                                }
                                            }
                                            else
                                            {
                                                if (CheckSab.Checked)
                                                {
                                                    lMsj.Text = "El número de Sabana y Site Origen no debe ir vacios";
                                                    docAdi.Items.Clear();
                                                    Padi.Visible = false;
                                                }
                                                else
                                                {
                                                    lMsj.Text = "Formato del Código Contable incorrecto <br/> ejemplo: 0000.0000.0000.00.000";
                                                    docAdi.Items.Clear();
                                                    Padi.Visible = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            lMsj.Text = "Debe incluir el Código Contable";
                                            docAdi.Items.Clear();
                                            Padi.Visible = false;
                                        }

                                    }
                                    else
                                    {
                                        lMsj.Text = "Extension de archivo no reconocida, la orden de compra debe ser de extensión .pdf";
                                        docAdi.Items.Clear();
                                        Padi.Visible = false;
                                    }
                                }
                                else
                                {
                                    lMsj.Text = "Extension de archivo no reconocida";
                                    docAdi.Items.Clear();
                                    Padi.Visible = false;
                                }
                            }
                            else
                            {
                                lMsj.Text = "Extension de archivo no reconocida";
                                docAdi.Items.Clear();
                                Padi.Visible = false;
                            }
                        }
                        else
                        {
                            if (CheckSab.Checked)
                            {
                                lMsj.Text = "Necesitas Subir todos los archivos: XML y PDF";
                                docAdi.Items.Clear();
                                Padi.Visible = false;
                            }
                            else
                            {
                                lMsj.Text = "Necesitas Subir todos los archivos: XML, PDF y orden de compra";
                                docAdi.Items.Clear();
                                Padi.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        lMsj.Text = "Es necesario incluir en el Certificado.";

                    }
                }
                else
                {
                    lMsj.Text = "El tamaño de los archivos es mayor a 2MB";
                }
            }
            catch (Exception ex)
            {
                lMsj.Text = "Verificar el tamaño de los archivos";

                anade_linea_archivo(archivo_log, "ValidarFacturas1" + ex.ToString());

            }
            ///COMPLETE ERROR READ
            string path = AppDomain.CurrentDomain.BaseDirectory + "logErrorNEW\\ErrorREADXML.txt";
            if (File.Exists(path))
            {
                string str = File.ReadAllText(path);
                lbarrayLog.Visible = true;
                lbarrayLog.Text = str;
                try
                {
                    File.Delete(path);
                }
                catch
                {
                }
            }
            ////
        }

        protected void tbCO_TextChanged(object sender, EventArgs e)
        {

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

        protected void caN_Click(object sender, EventArgs e)
        {
            if (Session["adSub"] != null || Session["usuario"] != null)
            {
                if (Session["adSub"].ToString() == "Admin")
                {
                    Session["proveedorTipe"] = null;
                    Session["adSub"] = null;
                    Response.Redirect("~/menuReceDHL/ComprobantesFiscales.aspx");
                }
                else
                {
                    Response.Redirect("~/Documentos.aspx", false);
                }
            }
            else
            {
                Response.Redirect("~/Cerrar.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (examAdi.PostedFile.FileName != "")
            {
                if (nomAdi.Text != "")
                {
                    Padi.Visible = true;
                    string rutaADI = Path.GetDirectoryName(examAdi.FileName);
                    string ext = Path.GetExtension(examAdi.FileName);
                    string nom = (examAdi.FileName.Replace(ext, "").Replace(rutaADI + "\\", "").Replace("&", "_").Replace("#", "").Replace("+", "").Trim()) + "1" + ext;
                    examAdi.PostedFile.SaveAs(arc + @"manual\" + nom);
                    docAdi.Items.Add(new ListItem(nomAdi.Text.Replace("+", ""), nom));
                    nomAdi.Text = "";
                    if (!File.Exists(arc + @"manual\" + nom))
                    {
                        docAdi.Items.RemoveAt(docAdi.Items.Count - 1);
                        lMsj.Text = "El documento no se cargo satisfactoriamente, intentelo de nuevo";
                    }
                }
                else
                {
                    lMsj.Text = "Debes ingresar un nombre";
                }
            }
            else
            {
                lMsj.Text = "Debes seleccionar un Documento";
            }
        }

        protected void ButOtm_Click(object sender, EventArgs e)
        {

        }

        public void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked)
            {
                prop.Visible = true;
            }
            else { prop.Visible = false; }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Labadi.Visible = true;
            Labadi.Text = docAdi.SelectedValue;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            docAdi.Items.Remove(docAdi.SelectedItem);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Labeotm.Visible = true;
            Labeotm.Text = Lotm.SelectedValue;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Lotm.Items.Remove(docAdi.SelectedItem);
        }

        protected void CodCont2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CheckSab_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSab.Checked)
            {
                NumSab.Visible = true;
                TextSab.Visible = true;
                Lsite.Visible = true;
                siteSab.Visible = true;
                Lsb0.Text = "Es obligatorio subir la sabana <br>como documento adicional";
                Lsb0.Visible = true;

                TextSab1.Visible = true;
                guion.Visible = true;
                fuCompra.Visible = false;
                LabelOC.Visible = false;
                LabCC.Visible = false;
                CodCont.Visible = false;
                CodCont0.Visible = false;
                CodCont1.Visible = false;
                CodCont2.Visible = false;
                CodCont3.Visible = false;
                Lfin.Visible = false;

                Lfin.Text = "";
                Lfin0.Text = "";
                CodCont.Text = "";
                CodCont0.Text = "";
                CodCont1.Text = "";
                CodCont2.Text = "";
                CodCont3.Text = "";

            }
            else
            {
                NumSab.Visible = false;
                TextSab.Visible = false;
                Lsite.Visible = false;
                siteSab.Visible = false;
                Lsb.Visible = false;

                Lsb0.Visible = false;
                TextSab1.Visible = false;
                guion.Visible = false;
                fuCompra.Visible = true;
                LabelOC.Visible = true;
                LabCC.Visible = true;
                CodCont.Visible = true;
                CodCont0.Visible = true;
                CodCont1.Visible = true;
                CodCont2.Visible = true;
                CodCont3.Visible = true;
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
                //linea = sr.ReadLine();
                if (!String.IsNullOrEmpty(linea))
                {
                    valores = linea.Split('|');
                    if (valores[0].Trim().Equals(CC) && valores[3].Trim().Equals(cli))
                    {
                        banF = true;
                        correoDhl = valores[7].Trim();
                        Lfin0.Text = valores[7].Trim();

                        respDat = valores[5].Trim();
                        //}
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
                    if (valores[0].Trim().Equals(CC) && valores[2].Trim().Equals(cli))
                    {
                        respDat = valores[5];
                        //}
                    }
                }

            }
            sr.Dispose();
            sr.Close();
            return respDat;

        }

        protected void CodCont0_TextChanged(object sender, EventArgs e)
        {
            string re = "";
            re = DatosFinOrac(CodCont.Text, CodCont0.Text);
            if (re != "")
            {
                Lfin.Text = "Financiero DHL:<br>" + re;
                validaCC = true;
            }
            else
            {
                Lfin.Text = "*El centro de Costo no existe, <br> no podrá subir su facura.";
                validaCC = false;
            }
            Lfin.Visible = true;
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
                        correoDhl = valores[7];
                        Lfin0.Text = valores[7];

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
                        respDat = valores[5];
                        // }
                    }
                }

            }
            sr.Dispose();
            sr.Close();
            return respDat;

        }

        protected void siteSab_TextChanged(object sender, EventArgs e)
        {
            string re = "";
            re = DatosFinOTM(siteSab.Text);
            if (re != "")
            {
                Lsb.Text = "Financiero DHL:<br>" + re;
            }
            else
            {
                //Lsb.Text = "*El Site de Origen no existe, <br> no podrá subir su facura.";
                Lsb.Text = "*El Site de Origen puede no ser válido";
            }
            Lsb.Visible = true;
        }

        protected void CodCont_TextChanged(object sender, EventArgs e)
        {
            if (CodCont.Text != "" && CodCont0.Text != "")
            {
                string re = "";
                re = DatosFinOrac(CodCont.Text, CodCont0.Text);
                if (re != "")
                {
                    Lfin.Text = "Financiero DHL:<br>" + re;
                }
                else
                {
                    Lfin.Text = "*El centro de Costo no existe, <br> no podrá subir su facura.";
                }
                Lfin.Visible = true;
            }
        }

        protected void CheckAnti_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.CheckAnticipo.Checked)
            //{
            //    this.tbRefB.Visible = true;
            //    this.LbRefB.Visible = true;
            //}
            //else
            //{
            this.tbRefB.Visible = false;
            this.LbRefB.Visible = false;
            //}
        }

        public static void anade_linea_archivo(string archivo, string linea)///////////////////log
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"logErrorNEW"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"logErrorNEW");
            }
            using (StreamWriter w = File.AppendText(archivo))
            {
                w.WriteLine(linea.Replace(Environment.NewLine, ""));
                w.Flush();
                w.Close();
            }
        }

    }
}
