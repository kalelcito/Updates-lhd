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
    public partial class Autorizar2 : System.Web.UI.Page
    {
        private String consulta;
        private String aux;
        private String separador = "|";
        private DataTable DT = new DataTable();
        private BasesDatos DB = new BasesDatos();
        private Log lg = new Log();
        private EnviarMail EM;
        String[] seleccionados;
        int cantidad;
        static int conf;
        string modulo = "";
        string rfcEmisor = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUser"] != null)
            {
                if (!IsPostBack)
                {
                  
                    DB.Conectar();
                    DB.CrearComando(@"SELECT RFC
                                      FROM ModuloEmpleado INNER JOIN 
                                           Modulos ON Modulos.IDEMODULO = ModuloEmpleado.id_Modulo
                                      WHERE ModuloEmpleado.id_Empleado= @id_Empleado");
                    DB.AsignarParametroCadena("@id_Empleado", Session["idUser"].ToString());
                    DbDataReader DRM = DB.EjecutarConsulta();
                    while (DRM.Read())
                    {
                        modulo = modulo + separador + DRM[0].ToString();
                    }
                    DB.Desconectar();
                    modulo = modulo.Trim('|');

                    tbRFC0.Text = modulo;
                    try
                    {
                        if (Convert.ToBoolean(Session["coFactTodas"])) { aux = "1"; } else { aux = "0"; }
                        DB.Conectar();
                        DB.CrearComandoProcedimiento("PA_facturas_basico_rec");
                        DB.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
                        DB.AsignarParametroProcedimiento("@SUCURSAL", System.Data.DbType.String, (String)Session["sucursalUser"]);
                        DB.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, (String)Session["rfcCliente"]);
                        DB.AsignarParametroProcedimiento("@ROL", System.Data.DbType.Byte, Convert.ToByte(aux));
                        DB.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, (String)tbRFC0.Text);
                        if (Session["tipoUser"].Equals("Ambos"))
                        {
                            DB.AsignarParametroProcedimiento("@TIPOUSER", System.Data.DbType.String, "");
                        }
                        else { DB.AsignarParametroProcedimiento("@TIPOUSER", System.Data.DbType.String, (String)Session["tipoUser"]); }
                        DB.AsignarParametroProcedimiento("@PERMV", System.Data.DbType.Int16, 2);
                        DT.Load(DB.EjecutarConsulta());
                        DB.Desconectar();

                    }
                    catch (Exception ex)
                    {
                        error.Text = ex.ToString();
                    }

                    gvFacturas.DataSourceID = null;
                    gvFacturas.DataSource = DT;
                    gvFacturas.DataBind();

                    cantidad = gvFacturas.Rows.Count;
                    if (cantidad == 0)
                    {
                        NA.Visible = false;
                        AT.Visible = false;
                    }


                }
            }
        }

        protected void val1_Click(object sender, EventArgs e)
        {
            bool si = false;
            foreach (GridViewRow row in gvFacturas.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }
            if (si == true)
            {
                conf = 1;
                gvFacturas.Enabled = false;
                REGRESAR.Enabled = false;
                AT.Enabled = false;
                NA.Enabled = false;
                adv.Visible = true;
                adv.Text = "ESTA SEGURO QUE DESEA AUTORIZAR LAS FACTURAS";
                S.Visible = true;
                N.Visible = true;
            }
            else { error.Text = "NO SELECIONO NINGUNA FACTURA"; }
        }
        protected void NA_Click(object sender, EventArgs e)
        {
             bool si = false;
            foreach (GridViewRow row in gvFacturas.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }
            if (si == true)
            {
                conf = 2;
                gvFacturas.Enabled = false;
                REGRESAR.Enabled = false;
                AT.Enabled = false;
                NA.Enabled = false;
                adv.Visible = true;
                adv.Text = "ESTA SEGURO QUE DESEA DENEGAR LAS FACTURAS";
                S.Visible = true;
                N.Visible = true;
            }
            else { error.Text = "NO SELECIONO NINGUNA FACTURA"; }
        }
        protected void REGRESAR_Click(object sender, EventArgs e)
        {
            Response.Redirect("menuVal.aspx");
        }

        protected void S_Click(object sender, EventArgs e)
        {
            if (conf == 1)
            {
                
                cantidad = gvFacturas.Rows.Count;
                seleccionados = new String[cantidad];
                //String mensaje = "", val_rb = "";
                Boolean bCHK = false;//, bRB = false, bSelect = false;
                string fol;
                //int a = 0;
                Response.Clear();

                foreach (GridViewRow row in gvFacturas.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {

                        fol = hd_Seleccionafol.Value;
                        DB.Conectar();
                        DB.CrearComando(@"update General set edoFact=@edo where folio=@fol");
                        DB.AsignarParametroEntero("@edo", 3);
                        DB.AsignarParametroCadena("@fol", fol);
                        DB.EjecutarConsulta();
                        DB.Desconectar();

                        String ses = Session["nombreEmpleado"].ToString();
                        log(fol, ses);
                        
                    }
                }
                Response.Redirect("Autorizar2.aspx");
            }

            else {
                
                cantidad = gvFacturas.Rows.Count;
                seleccionados = new String[cantidad];
                //String mensaje = "", val_rb = "";
                Boolean bCHK = false;//, bRB = false, bSelect = false;
                string fol;
                //int a = 0;
                Response.Clear();

                foreach (GridViewRow row in gvFacturas.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {

                        fol = hd_Seleccionafol.Value;
                        DB.Conectar();
                        DB.CrearComando(@"update General set edoFact=@edo where folio=@fol");
                        DB.AsignarParametroEntero("@edo", 4);
                        DB.AsignarParametroCadena("@fol", fol);
                        DB.EjecutarConsulta();

                        String ses = Session["nombreEmpleado"].ToString();
                        log(fol, ses);
                        DB.Desconectar();
                        
                    }
                }
                Response.Redirect("Autorizar2.aspx");
            }
        }

        protected void log(string fol, string ses) {
            String mensaje;
            if (conf == 1)
            {
                mensaje = "EL USUARIO " + ses + "AUTORIZO LA FACTURA POR PAGAR CON FOLIO: " + fol;
                lg.guardar_Log(mensaje);
            }
            else 
            { 
                mensaje = "EL USUARIO " + ses + " RECHAZO FACTURA POR PAGAR CON FOLIO: " + fol;
                lg.guardar_Log(mensaje);
            }
        }
        protected void N_Click(object sender, EventArgs e)
        {
            Response.Redirect("Autorizar2.aspx");
        }

        
    }
}