using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Control;
using System.Data.Common;

namespace DataExpressWeb
{
    public partial class enviar : System.Web.UI.Page
    {
        string idfact;
        string pdf;
        string xml;
        string folio;
        string serie;
        string fecha;
        string receptor;
        string emisor;
        string nombreEmisor;
        string mail;
        string filename;
        string rfcname;
        string dirname;

        BasesDatos DB = new BasesDatos();
        string servidor = "";
        Int32 puerto;
        Boolean ssl = false;
        string emailCredencial = "";
        string passCredencial = "";
        string dirtxt, dirbck, dirpdf;
        string emailEnviar = "";
        string RutaDOC = "";
        string descError;
        string fechaError;
        string anoAprobacion = "";
        string noAprobacion = "";
        string correo = "";

        #region benviar
        string resulVal = "";
        string cadenaO = "";
        string Valsello = "";
        string certificado = "";
        string estructura = "";
        string detalleVal = "";
        string existenciaCer = "";
        string vigeciaCer = "";
        string versionComprobante = "";
        string noCertificado = "";
        string sello = "";
        String sHtml;
        string imgEstatus = "";
        string imgSello = "";
        string imgExistCer = "";
        string imgVigCer = "";
        string imgFolSer = "";
        string imgEstruct = "";
        string imgRangoFol = "";
        string imgNoaprobfol = "";
        string auxm = "";
        string tipocomprobant = "";
        string vigeniaCertificado = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            idfact = Request.QueryString.Get("idfa");
            
            try
            {

                DB.Conectar();
                DB.CrearComando("select servidorSMTP,puertoSMTP,sslSMTP,userSMTP,passSMTP,emailEnvio from ParametrosSistema");
                DbDataReader DRSMTP = DB.EjecutarConsulta();
                if (DRSMTP.Read())
                {
                    servidor = DRSMTP[0].ToString();
                    puerto = Convert.ToInt32(DRSMTP[1].ToString());
                    ssl = Convert.ToBoolean(DRSMTP[2].ToString());
                    emailCredencial = DRSMTP[3].ToString();
                    passCredencial = DRSMTP[4].ToString();
                    emailEnviar = DRSMTP[5].ToString();
                }
                DB.Desconectar();
            }
            catch (Exception ex)
            {
                DB.Desconectar();
                DB.Conectar();
                DB.CrearComando((@"insert into LogErrorFacturas
                                (detalle,fecha,numeroDocumento) 
                                values 
                                (@detalle,@fecha,@numeroDocumento)"));

                DB.AsignarParametroCadena("@detalle", "E-mail no enviado: " + ex.ToString() );
                DB.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                DB.AsignarParametroCadena("@numeroDocumento", folio + serie);
                DB.EjecutarConsulta1();
                DB.Desconectar();
            }
            try
            {
                DB.Conectar();
                DB.CrearComando(@"SELECT facturasInvalidas.fecha, facturasInvalidas.folio, facturasInvalidas.serie, ArchivosInvalidos.PDFARC, ArchivosInvalidos.XMLARC,
EMISOR.RFCEMI,EMISOR.NOMEMI,facturasInvalidas.noAprobacion,facturasInvalidas.anoAprobacion,facturasInvalidas.email
                             FROM
                             ArchivosInvalidos INNER JOIN
                             facturasInvalidas ON ArchivosInvalidos.IDEFAC = facturasInvalidas.idFactura	 INNER JOIN
                             EMISOR ON facturasInvalidas.id_Emisor = EMISOR.IDEEMI
                             WHERE 
                             facturasInvalidas.idFactura=@IDE");
                DB.AsignarParametroCadena("@IDE", idfact);
                DbDataReader DR = DB.EjecutarConsulta();
                if (DR.Read())
                {
                    fecha = DR[0].ToString(); folio = DR[1].ToString(); serie = DR[2].ToString();
                    pdf = DR[3].ToString(); xml = DR[4].ToString(); emisor = DR[5].ToString();
                    nombreEmisor = DR[6].ToString(); noAprobacion = DR[7].ToString(); anoAprobacion = DR[8].ToString(); //correo = DR[9].ToString();
                }
                DB.Desconectar();
                tbFactura.Text = folio + " " + serie;
                //tbEmail.Text = correo;
            }
            catch (Exception ex)
            {
                DB.Desconectar();
                DB.Conectar();
                DB.CrearComando((@"insert into LogErrorFacturas
                                (detalle,fecha,numeroDocumento) 
                                values 
                                (@detalle,@fecha,@numeroDocumento)"));

                DB.AsignarParametroCadena("@detalle", "E-mail no enviado: " + ex.ToString());
                DB.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                DB.AsignarParametroCadena("@numeroDocumento", folio + serie);
                DB.EjecutarConsulta1();
                DB.Desconectar();
            }

        }


        protected void bEnviarEmail_Click(object sender, EventArgs e)
        {
            //if (Archivos(idfact))
            //{
                try
                {
                    resulVal = consultarResulVal(idfact).Replace("\r", "").Replace("\n", "");
                    detalleVal = consultarDetalleVal(idfact);
                  
                    //Resultado de la validacion
                    string[] rv = resulVal.Split('*');
                    estructura = rv[0];
                    Valsello = rv[1];
                    existenciaCer = rv[2];
                    vigeciaCer = rv[3];
                    versionComprobante = rv[4];
                    noCertificado = rv[5];
                    string[] auxCer = noCertificado.Split(':');
                    noCertificado = auxCer[1].ToString();
                    cadenaO = rv[6];
                    string[] auxCO = cadenaO.Split(':');
                    cadenaO = auxCO[1].ToString() + auxCO[2].ToString() + auxCO[3].ToString();
                    sello = rv[7];
                    
                    //estructura = rv[0];
                    //Valsello = rv[1];
 
                    EnviarMail em = new EnviarMail();
                    mail = tbEmail.Text;
                    string mensaje = "";
                    string asunto = "";

                    if (mail.Length > 0)
                    {
                        //Valida que imagen corresponde
                        if (estructura.IndexOf("Válida") != -1)
                        { imgEstruct = @"http://dataexpressintmx.com/ok-small.png"; }
                        else { imgEstruct = @"http://dataexpressintmx.com/x_small.png"; }


                        if (Valsello.IndexOf("Sello válido") != -1)
                        { imgSello = @"http://dataexpressintmx.com/ok-small.png"; }
                        else { imgSello = @"http://dataexpressintmx.com/x_small.png"; }

                        if (existenciaCer.IndexOf("Correcto") != -1)
                        { imgExistCer = @"http://dataexpressintmx.com/ok-small.png"; }
                        else { imgExistCer = @"http://dataexpressintmx.com/x_small.png"; }

                        if (vigeciaCer != "El certificado no esta vigente.")
                        { imgVigCer = @"http://dataexpressintmx.com/ok-small.png"; }
                        else { imgVigCer = @"http://dataexpressintmx.com/x_small.png"; }
                        //Validacion de serie y folio para CFD

                        /*if (!banCFDI)
                        {
                            if (banfolser)
                            { imgFolSer = @"http://dataexpressintmx.com/ok-small.png"; }

                            else
                            {
                                if (banRangofol)
                                {
                                    imgRangoFol = @"http://dataexpressintmx.com/x_small.png";
                                }
                                else
                                { imgRangoFol = @"http://dataexpressintmx.com/ok-small.png"; }

                                if (banNoAprob)
                                {
                                    imgNoaprobfol = @"http://dataexpressintmx.com/x_small.png";
                                }
                                else
                                { imgNoaprobfol = @"http://dataexpressintmx.com/ok-small.png"; }

                            }
                        }*/
                        if (versionComprobante.IndexOf("2.2") != -1) { tipocomprobant = "CFD"; versionComprobante = "2.2"; } else { tipocomprobant = "CFDI"; versionComprobante = "3.2"; }

                        if (detalleVal.IndexOf("RE002") != -1 || detalleVal.IndexOf("RE005") != -1 || detalleVal.IndexOf("RE013") != -1)//Facturas invalidas
                        {
                            asunto = "Información sobre la factura que enviaste con Folio. " + folio + serie + ". ";

                            sHtml =
                          @"<h5><Font Color=" + "#3983B7" + "><center>DETALLE DE VALIDACION DE LA FACTURA DIGITAL BASADO EN EL ANEXO 20 <br>DE LA RESOLUCION MISCELANEA FISCAL PUBLICADA POR EL SAT</center></Font></h1></P>" +

                              " <TABLE BORDER=0>" +
                                    "<TR>" +
                           "<TD>Estatus completo de la factura digital:</TD>" +
                                    "<TD>" + detalleVal +
                                    "<TD><img src=" + "http://dataexpressintmx.com/x_small.png" + "></TD>" +
                                "</TD>" +
                            "</TR>" +
                           " </TABLE>" +

                        "<table border=" + "0" + " width=" + "200px" + ">" +
                                "<tr>" +
                                 "<th></th>" +

                                 "<td> </td>" +
                                 "<th>   Estatus validación  </th>" +
                              "</tr>" +
          "</tr>" +
                                   "<tr>" +
                                  "<th align=" + "right" + ">Razon Social:</th>" +
                                  "<td>" + nombreEmisor + "</td>" +
                               "</tr>" +
                               "</tr>" +
                                   "<tr>" +
                                  "<th align=" + "right" + ">RFC:</th>" +
                                  "<td>" + emisor + "</td>" +
                               "</tr>" +
                                "<tr>" +
                                  "<th align=" + "right" + ">Tipo comprobante:</th>" +
                                  "<td>" + tipocomprobant + "</td>" +
                               "</tr>" +


                             "<tr>" +
                                 "<th width=" + "50%" + " align=" + "right" + ">Versión del comprobante:</th>" +
                                 "<td>" + versionComprobante + "</td>" +
                                "</tr>" +
                               "</tr>" +
                                  "<tr>" +
                                  "<th align=" + "right" + ">Folio y Serie:</th>" +
                                  "<td>" + folio + " " + serie + "</td>" +
                               "</tr>" +
                                 "<tr>" +
                                  "<th align=" + "right" + ">Año   No. aprobación:</th>" +
                                  "<td>" + anoAprobacion + " " + noAprobacion + "</td>" +
                               "</tr>" +
                                "<tr>" +
                                  "<th align=" + "right" + ">Estructura:</th>" +
                                  "<td>" + estructura + "</td>" +
                                    "<th>   <img src=" + imgEstruct + ">  </th>" +

                               "</tr>" +
                                 "<tr>" +
                                  "<th align=" + "right" + ">Certificado:</th>" +
                                  "<td>" + noCertificado + "</td>" +
                                   "<th>   <img src=" + imgExistCer + ">  </th>" +

                               "</tr>" +

                                 "<tr>" +
                                  "<th align=" + "right" + ">Vigencia:</th>" +
                                  "<td>" + vigeciaCer + "</td>" +
                                   "<th>   <img src=" + imgVigCer + ">  </th>" +

                               "</tr>" +
                                                    "</table>" +
                                "<table>" +
                               "<tr>" +
                                  "<th align=" + "left" + ">Sello:" + " <img src=" + imgSello + ">" + "</th>" +

                               "</tr>" +
                               "<tr>" +
                                  "<th>" + "<textarea rows=" + "6" + " cols=" + "50" + " readonly >" + sello + "</textarea>" + "</th>" +
                               "</tr>" +

                                 "</table>" +
                              "<table>" +
                               "<tr>" +
                                  "<th align=" + "left" + " >Cadena Original:</th>" +
                                "</tr>" +
                                    "<tr>" +
                                  "<td width=" + "40%" + "HEIGHT=" + "50%" + "> " + "<textarea rows=" + "6" + " cols=" + "50" + " readonly >" + cadenaO + "</textarea>" + "</td>" +
                               "</tr>" +
                               "</table>";

                            mensaje += sHtml;

                        }
                        //CFD
                        if (detalleVal.IndexOf("RE004") != -1 || detalleVal.IndexOf("RE003") != -1)
                        {
                            asunto = "Información sobre la factura que enviaste con Folio. " + folio + serie + ". ";

                            sHtml =
                          @"<h5><Font Color=" + "#3983B7" + "><center>DETALLE DE VALIDACION DE LA FACTURA DIGITAL BASADO EN EL ANEXO 20 <br>DE LA RESOLUCION MISCELANEA FISCAL PUBLICADA POR EL SAT</center></Font></h1></P>" +

                              " <TABLE BORDER=0>" +
                                    "<TR>" +
                           "<TD>Estatus completo de la factura digital:</TD>" +
                                    "<TD>" + detalleVal +
                                    "<TD><img src=" + "http://dataexpressintmx.com/x_small.png" + "></TD>" +
                                "</TD>" +
                            "</TR>" +
                           " </TABLE>" +

                        "<table border=" + "0" + " width=" + "200px" + ">" +
                                "<tr>" +
                                 "<th></th>" +

                                 "<td> </td>" +
                                 "<th>   Estatus validación  </th>" +
                              "</tr>" +

                   "</tr>" +
                                   "<tr>" +
                                  "<th align=" + "right" + ">Razon Social:</th>" +
                                  "<td>" + nombreEmisor + "</td>" +
                               "</tr>" +
                               "</tr>" +
                                   "<tr>" +
                                  "<th align=" + "right" + ">RFC:</th>" +
                                  "<td>" + emisor + "</td>" +
                               "</tr>" +
                                "<tr>" +
                                  "<th align=" + "right" + ">Tipo comprobante:</th>" +
                                  "<td>" + tipocomprobant + "</td>" +
                               "</tr>" +

                             "<tr>" +
                                 "<th width=" + "50%" + " align=" + "right" + ">Versión del comprobante:</th>" +
                                 "<td>" + versionComprobante + "</td>" +
                                "</tr>" +
                               "<tr>" +
                                  "<th align=" + "right" + ">Folio y Serie:</th>" +
                                  "<td>" + folio + " " + serie + "</td>" +
                                    "<th>   <img src=" + imgRangoFol + ">  </th>" +
                               "</tr>" +
                                 "<tr>" +
                                  "<th align=" + "right" + ">Año   No. aprobación:</th>" +
                                  "<td>" + anoAprobacion + " " + noAprobacion + "</td>" +
                                   "<th>   <img src=" + imgNoaprobfol + ">  </th>" +
                               "</tr>" +
                                "<tr>" +
                                  "<th align=" + "right" + ">Estructura:</th>" +
                                  "<td>" + estructura + "</td>" +
                                    "<th>   <img src=" + imgEstruct + ">  </th>" +


                               "</tr>" +
                                 "<tr>" +
                                  "<th align=" + "right" + ">Certificado:</th>" +
                                  "<td>" + noCertificado + "</td>" +
                                   "<th>   <img src=" + imgExistCer + ">  </th>" +

                               "</tr>" +

                               "<tr>" +
                                  "<th align=" + "right" + ">Vigencia:</th>" +
                              "<td>" + vigeciaCer + "</td>" +
                                   "<th>   <img src=" + imgVigCer + ">  </th>" +

                               "</tr>" +
                               "</table>" +
                                "<table>" +
                               "<tr>" +
                                  "<th align=" + "left" + ">Sello:" + " <img src=" + imgSello + ">" + "</th>" +

                               "</tr>" +
                               "<tr>" +
                                  "<th>" + "<textarea rows=" + "6" + " cols=" + "50" + " readonly >" + sello + "</textarea>" + "</th>" +
                               "</tr>" +

                                 "</table>" +
                              "<table>" +
                               "<tr>" +
                                  "<th align=" + "left" + " >Cadena Original:</th>" +
                                "</tr>" +
                                    "<tr>" +
                                  "<td width=" + "40%" + "HEIGHT=" + "50%" + "> " + "<textarea rows=" + "6" + " cols=" + "50" + " readonly >" + cadenaO + "</textarea>" + "</td>" +
                               "</tr>" +
                               "</table>";

                            mensaje += sHtml;
                        }
                        em.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);
                        em.llenarEmail(emailEnviar, mail, "", "", asunto, mensaje);

                        try
                        {
                            em.enviarEmail();
                            lMensaje.Text = "E-mail enviado";

                            DB.Conectar();
                            DB.CrearComando((@"insert into LogErrorFacturas
                                (detalle,fecha,numeroDocumento) 
                                values 
                                (@detalle,@fecha,@numeroDocumento)"));
                            DB.AsignarParametroCadena("@detalle", "E-mail enviado: " + mail);
                            DB.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                            DB.AsignarParametroCadena("@numeroDocumento", folio + serie);
                            DB.EjecutarConsulta1();
                            DB.Desconectar();

                        }
                        catch (System.Net.Mail.SmtpException ex)
                        {
                           
                            DB.Conectar();
                            DB.CrearComando((@"insert into LogErrorFacturas
                                (detalle,fecha,numeroDocumento) 
                                values 
                                (@detalle,@fecha,@numeroDocumento)"));

                            DB.AsignarParametroCadena("@detalle", "E-mail no enviado: " + ex.ToString() );
                            DB.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                            DB.AsignarParametroCadena("@numeroDocumento", folio + serie);
                            DB.EjecutarConsulta1();
                            string errorConsulta = DB.comando.CommandText;
                            lMensaje.Text = errorConsulta;
                            DB.Desconectar();
                        }


                    }//if mail.length
                }
                catch (Exception ex)
                {
                     
                    DB.Conectar();
                    DB.CrearComando((@"insert into LogErrorFacturas
                                (detalle,fecha,numeroDocumento) 
                                values 
                                (@detalle,@fecha,@numeroDocumento)"));

                    DB.AsignarParametroCadena("@detalle", "E-mail no enviado: " + ex.ToString());
                    DB.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                    DB.AsignarParametroCadena("@numeroDocumento", folio + serie);
                    DB.EjecutarConsulta1();
                    DB.Desconectar();
                }

            //}

        }

        public Boolean Archivos(string IDEFAC)
        {
            try
            {
                DB.Conectar();
                DB.CrearComando("select IDEARC from ArchivosInvalidos where IDEFAC=@IDEFAC");
                DB.AsignarParametroCadena("@IDEFAC", IDEFAC);
                DbDataReader DR = DB.EjecutarConsulta();

                if (DR.Read())
                {
                    DB.Desconectar();
                    return true;
                }
                DB.Desconectar();
                return false;
            }
            catch (Exception ex)
            {
                DB.Conectar();
                DB.CrearComando((@"insert into LogErrorFacturas
                                (detalle,fecha,numeroDocumento) 
                                values 
                                (@detalle,@fecha,@numeroDocumento)"));
                DB.AsignarParametroCadena("@detalle", "error BD: " + ex.ToString());
                DB.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString());
                DB.AsignarParametroCadena("@numeroDocumento", folio + serie);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                return false;
            }
        }

        public String consultarResulVal(string idFactura)
        {
            string resultadoV = "";
            try
            {
                DB.Conectar();
                DB.CrearComando("select resultadoVal from facturasInvalidas where idFactura=@idFactura");
                DB.AsignarParametroCadena("@idFactura", idFactura);

                DbDataReader DR1 = DB.EjecutarConsulta();

                if (DR1.Read())
                {
                    resultadoV = DR1[0].ToString();
                    DB.Desconectar();
                    return resultadoV;
                }
                DB.Desconectar();
                return resultadoV;
            }
            catch (Exception ex)
            {

                DB.Conectar();
                DB.CrearComando((@"insert into LogErrorFacturas
                                (detalle,fecha,numeroDocumento) 
                                values 
                                (@detalle,@fecha,@numeroDocumento)"));
                DB.AsignarParametroCadena("@detalle", "error BD: " + ex.ToString());
                DB.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                DB.AsignarParametroCadena("@numeroDocumento", folio + serie);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                return null;
            }
        }

        public String consultarDetalleVal(string idFactura)
        {
            string detalleV = "";
            try
            {
                DB.Conectar();
                DB.CrearComando("select detalleVal from facturasInvalidas where idFactura=@idFactura");
                DB.AsignarParametroCadena("@idFactura", idFactura);

                DbDataReader DR2 = DB.EjecutarConsulta();
                if (DR2.Read())
                {
                    detalleV = DR2[0].ToString();
                    DB.Desconectar();
                    return detalleV;
                }
                DB.Desconectar();
                return detalleV;

            }
            catch (Exception ex)
            {
                DB.Conectar();
                DB.CrearComando((@"insert into LogErrorFacturas
                                (detalle,fecha,numeroDocumento) 
                                values 
                                (@detalle,@fecha,@numeroDocumento)"));
                DB.AsignarParametroCadena("@detalle", "error BD: " + ex.ToString());
                DB.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                DB.AsignarParametroCadena("@numeroDocumento", folio + serie);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                return null;
            }
        }

    }
}