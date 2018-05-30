using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data;
using System.Data.Common;
using Control;
namespace DataExpressWeb
{
    public partial class DocumentosInvalidos : System.Web.UI.Page
    {
        private String consulta;
        private String aux;
        private String separador = "|";
        private DataTable DT = new DataTable();
        private BasesDatos DB = new BasesDatos();
        private EnviarMail EM;
        string modulo = "";
        string rfcEmisor = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                try
                {
                    DB.Conectar();
                    DB.CrearComandoProcedimiento("PA_facturasInv_basico_rec");
                    DB.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
                    DB.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, (String)Session["rfcUser"]);
                    DB.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, (String)Session["rfcUser"]);
                    //DbDataReader DR = DB.EjecutarConsulta();
                    //ArrayList al = DB.EjecutarConsulta();
                    DT.Load(DB.EjecutarConsulta());
                    DB.Desconectar();
                }
                catch (Exception ex)
                {

                }

                gvFacturas.DataSourceID = null;
                gvFacturas.DataSource = DT;
                gvFacturas.DataBind();

            }
        }
        
            
            
        //    if (!String.IsNullOrEmpty((String)Session["rfcCliente"]))
        //    {
        //        ddlSucursal.Visible = false;
        //        lSucursal.Visible = false;
        //        bMail.Visible = false;
        //        ddlDocumentosEnviar.Visible = false;
        //        lSeleccionDocus.Visible = false;
        //        consulta = "";
        //    }
        //    lSeleccionDocus.Text = lSeleccionDocus.Text + (String)Session["rfcCliente"];
            
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            consulta = "";
            DT.Clear();
            if (tbFolioAnterior.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "FA" + tbFolioAnterior.Text + separador; }
                else { consulta = "FA" + tbFolioAnterior.Text + separador; }
            }
            if (tbNombre.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RS" + tbNombre.Text + separador; }
                else { consulta = "RS" + tbNombre.Text + separador; }
            }
            if (tbRFC.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RF" + tbRFC.Text + separador; }
                else { consulta = "RF" + tbRFC.Text + separador; }
            }
            if (tbSerie.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "SE" + tbSerie.Text + separador; }
                else { consulta = "SE" + tbSerie.Text + separador; }
            }
          /*  if (ddlTipoDocumento.SelectedIndex != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "TD" + ddlTipoDocumento.SelectedValue + separador; }
                else { consulta = "TD" + ddlTipoDocumento.SelectedValue + separador; }
            }*/
            if (ddlSucursal.SelectedIndex != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "SU" + ddlSucursal.SelectedValue + separador; }
                else { consulta = "SU" + ddlSucursal.SelectedValue + separador; }
            }

            //if (!calFechaAnterior.SelectedDate.ToShortDateString().Equals("01/01/0001") &&
            //    !calFechaFin.SelectedDate.ToShortDateString().Equals("01/01/0001")
            //    )
            //{
            //    if (consulta.Length != 0) { consulta = consulta + "DA" + calFechaAnterior.SelectedDate.ToString("MM/dd/yyyy")  + separador; }
            //    else { consulta = "DA" + calFechaAnterior.SelectedDate.ToString("MM/dd/yyyy") + separador; }
            //}
            //if (!calFechaFin.SelectedDate.ToShortDateString().Equals("01/01/0001") &&
            //    !calFechaAnterior.SelectedDate.ToShortDateString().Equals("01/01/0001")
            //    )
            //{
            //    if (consulta.Length != 0) { consulta = consulta + "DF" + calFechaFin.SelectedDate.ToString("MM/dd/yyyy") + separador; }
            //    else { consulta = "DF" + calFechaFin.SelectedDate.ToString("MM/dd/yyyy") + separador; }
            //}




            if (!calFechaAnterior.SelectedDate.ToString("yyyyMMdd").Equals("00010101") &&
                !calFechaFin.SelectedDate.ToString("yyyyMMdd").Equals("00010101")
                )
            {
                if (consulta.Length != 0) { consulta = consulta + "DA" + calFechaAnterior.SelectedDate.ToString("yyyyMMdd") + separador; }
                else { consulta = "DA" + calFechaAnterior.SelectedDate.ToString("yyyyMMdd") + separador; }
            }
            if (!calFechaFin.SelectedDate.ToString("yyyyMMdd").Equals("00010101") &&
                !calFechaAnterior.SelectedDate.ToString("yyyyMMdd").Equals("00010101")
                )
            {
                if (consulta.Length != 0) { consulta = consulta + "DF" + calFechaFin.SelectedDate.ToString("yyyyMMdd") + separador; }
                else { consulta = "DF" + calFechaFin.SelectedDate.ToString("yyyyMMdd") + separador; }
            }





            if (consulta.Length != 0)
            {
                //if (((String)Session["coFactTodas"])=="") { miSucursal = "S---"; } else { miSucursal = (String)Session["sucursalUser"]; }
                // miSucursal = "S---";
                consulta = consulta.Substring(0, consulta.Length - 1);

                //tbSerie.Text=
                if (Convert.ToBoolean(Session["coFactTodas"])) { aux = "1"; } else { aux = "0"; }
                //facturasTodas = (String)Session["coFactTodas"];
               
                 try
                {
                    DB.Conectar();
                    string sucu;
                    sucu =Session["sucursalUser"].ToString();
                    DB.CrearComandoProcedimiento("PA_facturasInv_basico_rec");
                    DB.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, consulta);
                    DB.AsignarParametroProcedimiento("@SUCURSAL", System.Data.DbType.String, (String)Session["sucursalUser"]);
                    DB.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, (String)Session["rfcCliente"]);
                    DB.AsignarParametroProcedimiento("@ROL", System.Data.DbType.Byte, Convert.ToByte(aux));
                    DB.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, (String)modulo);
                    //DbDataReader DR = DB.EjecutarConsulta();
                    //ArrayList al = DB.EjecutarConsulta();
                    DT.Load(DB.EjecutarConsulta());
                    DB.Desconectar();
                }
                 catch (Exception ex)
                 {

                 }

                gvFacturas.DataSourceID = null;
                gvFacturas.DataSource = DT;
                gvFacturas.DataBind();
                lSeleccionDocus.Text = lSeleccionDocus.Text + (String)Session["rfcCliente"];
                consulta = "";
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("DocumentosInvalidos.aspx");
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            string emails = "";
            string emailEnviar = "";
            string asunto = "";
            string mensaje = "";
            string FOLFAC = "";
            string SERFAC = "";
            string FECHEMI = "";
            string servidor = "";
            int puerto = 25;
            Boolean ssl = false;
            string emailCredencial = "";
            string passCredencial = "";
            string RutaDOC = "";
            string RFCREC = "";
            ArrayList Arraycons = new ArrayList();
            string[] cons;

            DB.Conectar();
            DB.CrearComando("select servidorSMTP,puertoSMTP,sslSMTP,userSMTP,passSMTP,dirdocs,emailEnvio from ParametrosSistema");
            DbDataReader DR1 = DB.EjecutarConsulta();

            while (DR1.Read())
            {
                servidor = DR1[0].ToString();
                puerto = Convert.ToInt32(DR1[1].ToString());
                ssl = Convert.ToBoolean(DR1[2].ToString());
                emailCredencial = DR1[3].ToString();
                passCredencial = DR1[4].ToString();
                RutaDOC = DR1[5].ToString();
                emailEnviar = DR1[6].ToString();
            }
            DB.Desconectar();
             consulta = "";
            DT.Clear();
            if (tbFolioAnterior.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "FA" + tbFolioAnterior.Text + separador; }
                else { consulta = "FA" + tbFolioAnterior.Text + separador; }
            }
            if (tbNombre.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RS" + tbNombre.Text + separador; }
                else { consulta = "RS" + tbNombre.Text + separador; }
            }
            if (tbRFC.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RF" + tbRFC.Text + separador; }
                else { consulta = "RF" + tbRFC.Text + separador; }
            }
            if (tbSerie.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "SE" + tbSerie.Text + separador; }
                else { consulta = "SE" + tbSerie.Text + separador; }
            }
       /*     if (ddlTipoDocumento.SelectedIndex != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "TD" + ddlTipoDocumento.SelectedValue + separador; }
                else { consulta = "TD" + ddlTipoDocumento.SelectedValue + separador; }
            }*/
            if (ddlSucursal.SelectedIndex != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "SU" + ddlSucursal.SelectedValue + separador; }
                else { consulta = "SU" + ddlSucursal.SelectedValue + separador; }
            }

            if (!calFechaAnterior.SelectedDate.ToString("yyyyMMdd").Equals("00010101") &&
                !calFechaFin.SelectedDate.ToString("yyyyMMdd").Equals("00010101")
                )
            {
                if (consulta.Length != 0) { consulta = consulta + "DA" + calFechaAnterior.SelectedDate.ToString("MM/dd/yyyy") + separador; }
                else { consulta = "DA" + calFechaAnterior.SelectedDate.ToString("MM/dd/yyyy") + separador; }
            }
            if (!calFechaFin.SelectedDate.ToString("yyyyMMdd").Equals("00010101") &&
                !calFechaAnterior.SelectedDate.ToString("yyyyMMdd").Equals("00010101")
                )
            {
                if (consulta.Length != 0) { consulta = consulta + "DF" + calFechaFin.SelectedDate.ToString("MM/dd/yyyy") + separador; }
                else { consulta = "DF" + calFechaFin.SelectedDate.ToString("MM/dd/yyyy") + separador; }
            }
            if (consulta.Length != 0)
            {
                //if (((String)Session["coFactTodas"])=="") { miSucursal = "S---"; } else { miSucursal = (String)Session["sucursalUser"]; }
                // miSucursal = "S---";
                consulta = consulta.Substring(0, consulta.Length - 1);
            }

            if (Convert.ToBoolean(Session["coFactTodas"])) { aux = "1"; } else { aux = "0"; }

            string a = "sucursal" + (String)Session["sucursalUser"]+ " cliente"+(String)Session["rfcCliente"];
            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_facturasInv_basico_rec");
            DB.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, consulta);
            DB.AsignarParametroProcedimiento("@SUCURSAL", System.Data.DbType.String, (String)Session["sucursalUser"]);
            DB.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, (String)Session["rfcCliente"]);
            DB.AsignarParametroProcedimiento("@ROL", System.Data.DbType.Byte, Convert.ToByte(aux));
            DB.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, (String)modulo);
            DbDataReader DR = DB.EjecutarConsulta();

            while (DR.Read())
            {
                cons = new string[5];
                RFCREC = DR[0].ToString();
                FOLFAC = DR[3].ToString();
                SERFAC = DR[2].ToString();
                FECHEMI = DR[5].ToString();
                //emails = DR[11].ToString();

                cons[0] = RFCREC;
                cons[1] = FOLFAC;
                cons[2] = SERFAC;
                cons[3] = FECHEMI;
                cons[4] = emails;
                Arraycons.Add(cons);
            }
            DB.Desconectar();



            foreach (string[] datFact in Arraycons)
            {
                DB.Conectar();
                DB.CrearComando("select emailsRegla from EmailsReglas  where Receptor=@rfcrec and estadoRegla=1");
                DB.AsignarParametroCadena("@rfcrec", datFact[0]);
                DbDataReader DR3 = DB.EjecutarConsulta();
                if (DR3.Read())
                {
                    emails = DR3[0].ToString();
                }
                DB.Desconectar();
                if (emails.Length > 1)
                {
                    EM = new EnviarMail();
                    EM.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);
                    if (ddlDocumentosEnviar.SelectedValue == "2")
                    {
                        EM.adjuntar(RutaDOC + datFact[0] + "_" + datFact[1] + datFact[2] + ".pdf");
                    }
                    else if (ddlDocumentosEnviar.SelectedValue == "1")
                    {
                        EM.adjuntar(RutaDOC + datFact[0] + "_" + datFact[1] + datFact[2] + ".xml");
                    }
                    if (ddlDocumentosEnviar.SelectedValue == "0")
                    {
                        EM.adjuntar(RutaDOC + datFact[0] + "_" + datFact[1] + datFact[2] + ".xml");
                        EM.adjuntar(RutaDOC + datFact[0] + "_" + datFact[1] + datFact[2] + ".pdf");
                    }
                    if (emails.Length != 0)
                    {
                        asunto = "Factura con folio" + datFact[1] + datFact[2] + " de BDI de México";
                        mensaje = @"Buenas! <br>
                            Acabas de Recibir tu factura generada el" + datFact[3] + @"<br>
                            con folio" + datFact[1] + datFact[2] + ".";
                        mensaje += "<br>Saludos cordiales ";
                        mensaje += "<br>BDI Distribuciones de Mexico S. de R.L. de C.V. ";
                        mensaje += "<br><br>Servicio proporcionado por DataExpress";

                        EM.llenarEmail(emailEnviar, (datFact[4].Trim(',') + "," + emails.Trim(',')).Trim(','), "", "", asunto, mensaje);
                        try
                        {
                            EM.enviarEmail();
                            lMensaje.Text = "Email enviado";
                        }
                        catch (System.Net.Mail.SmtpException ex)
                        {
                            //setMsj(ex.Message);
                            DB.Desconectar();

                            DB.Conectar();
                            DB.CrearComando(@"insert into LogErrorFacturas
                                (detalle,fecha,archivo,linea,numeroDocumento,tipo) 
                                values 
                                (@detalle,@fecha,@archivo,@linea,@numeroDocumento,@tipo)");
                            DB.AsignarParametroCadena("@detalle", ex.Message);
                            DB.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                            DB.AsignarParametroCadena("@archivo", "");
                            DB.AsignarParametroCadena("@linea", "");
                            DB.AsignarParametroCadena("@tipo", "E-mail");
                            DB.AsignarParametroCadena("@numeroDocumento", datFact[1] + datFact[2]);
                            DB.EjecutarConsulta1();
                            DB.Desconectar();
                        }
                    }
                }
            }
        }

        protected void Button1_Click3(object sender, EventArgs e)
        {
            //DB.Conectar();
            //DB.CrearComando(@"DELETE FROM GENERAL");
            //DB.EjecutarConsulta1();
            //DB.Desconectar();
            //SqlDataSource1.SelectParameters["QUERY"].DefaultValue = consulta;
            //SqlDataSource1.SelectParameters["SUCURSAL"].DefaultValue = Session["sucursalUser"].ToString();
            //SqlDataSource1.SelectParameters["ROL"].DefaultValue = aux;
            //SqlDataSource1.DataBind();
            //gvFacturas.DataBind(); 




        }
    }
}