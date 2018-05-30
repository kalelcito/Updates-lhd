using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.Common;
using Control;
using Datos;
using ValSign;

namespace DataExpressWeb
{
    /*public partial class Formulario_web12 : System.Web.UI.Page
    {
        Facturas FAC;
       
        BasesDatos DB = new BasesDatos();
        Validacion val;
        string arc, pdf, bck;
        protected void Page_Load(object sender, EventArgs e)
        {

            DB.Conectar();
            DB.CrearComando(@"SELECT dirtxt,dirdocs,dirrespaldo from ParametrosSistema");
            DbDataReader DR = DB.EjecutarConsulta();
            DR.Read();
            arc = DR[0].ToString();
            pdf = DR[1].ToString();
            bck = DR[2].ToString();
            DB.Desconectar();
            //Panel3.Visible = false;
        }

        protected void bSubir_Click(object sender, EventArgs e)
        {
            lMsj.Text = "";
            val = new Validacion();
            string ppxml = fuXML.PostedFile.FileName;
            string pppdf = fuPDF.PostedFile.FileName;

            if (ppxml != "")
            {
                if (pppdf != "")
                {
            
                string rutaXML = Path.GetDirectoryName(fuXML.PostedFile.FileName);
                string rutaPDF = Path.GetDirectoryName(fuPDF.PostedFile.FileName);
            }
            }
            string noCert = "";
            if (fuCertificado.HasFile || chCertificado.Enabled)
            {

                String fnCER = fuCertificado.FileName;
                if (fuXML.HasFile && fuPDF.HasFile)
                {
                    String fnXML = fuXML.FileName;
                    String fnPDF = fnXML.Replace("XML", "PDF").Replace("xml", "PDF");
                    String feXML = System.IO.Path.GetExtension(fuXML.FileName).ToLower();
                    String fePDF = System.IO.Path.GetExtension(fuPDF.FileName).ToLower();
                    if (feXML == ".XML" || feXML == ".xml")
                    {
                        if (fePDF == ".PDF" || fePDF == ".pdf")
                        {
                            try
                            {
                                fuXML.PostedFile.SaveAs(arc+@"manual\" + fnXML);
                                fuPDF.PostedFile.SaveAs(arc +@"manual\" +  fnPDF);
                                tbMsj.Text += "Procesando.....";
                                String[] files = Directory.GetFiles(arc);
                                FAC = new Facturas(files, bck, pdf, arc+@"manual\","");
                                FAC.msj = "";
                                if (fuCertificado.HasFile)
                                {
                                    string rutaCER = Path.GetDirectoryName(fuCertificado.PostedFile.FileName);
                                    fuCertificado.PostedFile.SaveAs(bck + fnCER);
                                    FAC.setCertificado(val.extraerCertificado(bck + fnCER));
                                    noCert=val.extraerNoCertificado(bck + fnCER);
                                    System.IO.File.Delete(bck + fnCER);
                                }
                                FAC.leerIndividual(arc + @"manual\" + fnXML);

                                //Estatus general
                                lbarrayLog.Text = FAC.getmsgarrayLog();
                                
                                if (FAC.getbanValCadena() && FAC.getbanstatusCer() && FAC.getbanexistenciaCer())
                                     {imgStatusok.Visible = true; }
                                else { imgStatusx.Visible = true; }
                               //
                                if (FAC.getbanValCadena()) {
                                    imgSellook.Visible = true;}
                                else { imgSellook.Visible = true; }

                               if (FAC.getbanexistenciaCer())
                                {
                                    imgCerok.Visible = true;
                                }
                                else { imgCerx.Visible = true; }

                             
                                if(FAC.getbanVigCer())
                                {
                                    imbVigCerok.Visible = true;
                                }
                                else { imgVigCerx.Visible = true; }


                               if (FAC.getbanCFDI()) 
                               {
                                   if (FAC.getbanfolser())
                                   { imgFolSerok.Visible = true;
                                   imgAprobok.Visible = true;
                                   }
                                   else {

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
                                }
                                else { tbOtros.Text = ""; }
                                

                                Panel3.Visible = true;
                                tbMsj.Text = "Validación Completa.."+Environment.NewLine;
                                if (FAC.getNoCertificado() != noCert && fuCertificado.HasFile)
                                {
                                    tbMsj.Text = "El certificado no corresponde";
                                }
                                else
                                {
                                    if (!String.IsNullOrEmpty(FAC.getVersion()))
                                    {
                                        tbMsj.Text += "Versión del Comprobante: " + FAC.getVersion()+Environment.NewLine;
                                    }
                                    tbMsj.Text += "Resultado de la Validación. " + Environment.NewLine + Environment.NewLine;
                                    tbMsj.Text += FAC.msj;//.Replace(Environment.NewLine,"<br>");
                                    if (!String.IsNullOrEmpty(FAC.getCO()))
                                    {
                                        tbMsj.Text += Environment.NewLine+"Cadena Original: " + Environment.NewLine + FAC.getCO();
                                    }
                                    if (!String.IsNullOrEmpty(FAC.getNoCertificado()))
                                    {
                                        tbMsj.Text += Environment.NewLine+"Certificado: " + Environment.NewLine + FAC.getNoCertificado();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                tbMsj.Text = "No se pudieron validar los archivos " + ex.Message;
                                if (fuCertificado.HasFile)
                                {
                                    System.IO.File.Delete(bck + fnCER);
                                }
                                System.IO.File.Delete(bck + fnPDF);
                                System.IO.File.Delete(bck + fnXML);
                            }
                        }
                        else
                        {
                            lMsj.Text = "Extension de archivo no reconocida";
                        }
                    }
                    else
                    {
                        lMsj.Text = "Extension de archivo no reconocida";
                    }
                }
                else
                {
                    lMsj.Text = "Necesitas Subir ambos archivos XML y PDF.";
                }
            }
            else
            {
                lMsj.Text = "Es necesario incluir en el Certificado.";
            }
   

        }

    }*/
}