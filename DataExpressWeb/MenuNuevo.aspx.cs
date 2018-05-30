using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data.Common;
using System.Data;

namespace DataExpressWeb
{
    public partial class Formulario_web19 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        private DataTable DT = new DataTable();
        string modulo = "";
        string rfcEmisor = "";
        static string idres = "";
        private String separador = "|";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BD.Conectar();
                BD.CrearComando(@"SELECT rfc FROM Proveedores");
                DbDataReader DRM = BD.EjecutarConsulta();
                while (DRM.Read())
                {
                    modulo += separador + DRM[0].ToString();
                }
                BD.Desconectar();

                modulo = modulo.Trim('|');
                try
                {
                    BD.Conectar();
                    BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
                    BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
                    BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
                    BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, modulo);
                    BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String,"");
                    DT.Load(BD.EjecutarConsulta());
                    BD.Desconectar();
                }
                catch (Exception ex)
                {
                    // tbSerie.Text = ex.ToString();
                }

                gvFacturas.DataSourceID = null;
                gvFacturas.DataSource = DT;
                gvFacturas.DataBind();
            }
        }


        protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index; 
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView2.ActiveViewIndex = index;
        }

        protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView4.ActiveViewIndex = index;
            MultiView3.ActiveViewIndex = index;
        }
        //protected void gvFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes.Add("onMouseOver", "this.style.background='#eeff00';this.style.cursor='pointer'");

        //        e.Row.Attributes.Add("onMouseOut", "this.style.background='#ffffff'");

        //        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvFacturas, "Select$" + e.Row.RowIndex);

        //    }
           
        //}

        //protected void gvFacturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvFacturas.SelectedIndex = -1;
        //}

        protected void Button3_Click(object sender, EventArgs e)
        {
            BD.Conectar();
            BD.CrearComando(@"SELECT rfc FROM Proveedores");
            DbDataReader DRM = BD.EjecutarConsulta();
            while (DRM.Read())
            {
                modulo += separador + DRM[0].ToString();
            }
            BD.Desconectar();

            modulo = modulo.Trim('|');
            try
            {
                BD.Conectar();
                BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
                BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
                BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
                BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "valido|");
                BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, modulo);
                
                DT.Load(BD.EjecutarConsulta());
                BD.Desconectar();
            }
            catch (Exception ex)
            {
                // tbSerie.Text = ex.ToString();
            }

            gvFacturas.DataSourceID = null;
            gvFacturas.DataSource = DT;
            gvFacturas.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            BD.Conectar();
            BD.CrearComando(@"SELECT rfc FROM Proveedores");
            DbDataReader DRM = BD.EjecutarConsulta();
            while (DRM.Read())
            {
                modulo += separador + DRM[0].ToString();
            }
            BD.Desconectar();

            modulo = modulo.Trim('|');
            try
            {
                BD.Conectar();
                BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
                BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
                BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
                BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "proceso|");
                BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, modulo);
                DT.Load(BD.EjecutarConsulta());
                BD.Desconectar();
            }
            catch (Exception ex)
            {
                // tbSerie.Text = ex.ToString();
            }

            gvFacturas.DataSourceID = null;
            gvFacturas.DataSource = DT;
            gvFacturas.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            BD.Conectar();
            BD.CrearComando(@"SELECT rfc FROM Proveedores");
            DbDataReader DRM = BD.EjecutarConsulta();
            while (DRM.Read())
            {
                modulo += separador + DRM[0].ToString();
            }
            BD.Desconectar();

            modulo = modulo.Trim('|');
            try
            {
                BD.Conectar();
                BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
                BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
                BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
                BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "rechazado|");
                BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, modulo);
                DT.Load(BD.EjecutarConsulta());
                BD.Desconectar();
            }
            catch (Exception ex)
            {
                // tbSerie.Text = ex.ToString();
            }

            gvFacturas.DataSourceID = null;
            gvFacturas.DataSource = DT;
            gvFacturas.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            BD.Conectar();
            BD.CrearComando(@"SELECT rfc FROM Proveedores");
            DbDataReader DRM = BD.EjecutarConsulta();
            while (DRM.Read())
            {
                modulo += separador + DRM[0].ToString();
            }
            BD.Desconectar();

            modulo = modulo.Trim('|');
            try
            {
                BD.Conectar();
                BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
                BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
                BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
                BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "cancelado|");
                BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, modulo);
                DT.Load(BD.EjecutarConsulta());
                BD.Desconectar();
            }
            catch (Exception ex)
            {
                // tbSerie.Text = ex.ToString();
            }

            gvFacturas.DataSourceID = null;
            gvFacturas.DataSource = DT;
            gvFacturas.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BD.Conectar();
            BD.CrearComando(@"SELECT rfc FROM Proveedores");
            DbDataReader DRM = BD.EjecutarConsulta();
            while (DRM.Read())
            {
                modulo += separador + DRM[0].ToString();
            }
            BD.Desconectar();

            modulo = modulo.Trim('|');
            try
            {
                BD.Conectar();
                BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
                BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
                BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
                BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "");
                BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, modulo);
                
                DT.Load(BD.EjecutarConsulta());
                BD.Desconectar();
            }
            catch (Exception ex)
            {
                // tbSerie.Text = ex.ToString();
            }

            gvFacturas.DataSourceID = null;
            gvFacturas.DataSource = DT;
            gvFacturas.DataBind();
        }

       

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
           string  consulta = "";
            DT.Clear();
            if (Tfol.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "FA" + Tfol.Text + separador; }
                else { consulta = "FA" + Tfol.Text + separador; }
            }
            if (Tprov.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "RS" + Tprov.Text + separador; }
                else { consulta = "RS" + Tprov.Text + separador; }
            }
            if (Ttip.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "TP" + Ttip.Text + separador; }
                else { consulta = "TP" + Ttip.Text + separador; }
            }
            if (Tser.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "SE" + Tser.Text + separador; }
                else { consulta = "SE" + Tser.Text + separador; }
            }

            if (Tmon.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "MN" + Tmon.Text + separador; }
                else { consulta = "SE" + Tmon.Text + separador; }
            }

            if (Ttot.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "TL" + Ttot.Text + separador; }
                else { consulta = "SE" + Ttot.Text + separador; }
            }

            if (Tcod.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "GL" + Tcod.Text + separador; }
                else { consulta = "SE" + Tcod.Text + separador; }
            }
            //---------------------------Busqueda por fecha
            //if (!calFechaAnterior.SelectedDate.ToString("yyyyMMdd").Equals("00010101") &&
            //    !calFechaFin.SelectedDate.ToString("yyyyMMdd").Equals("00010101")
            //    )
            //{
            //    if (consulta.Length != 0) { consulta = consulta + "DA" + calFechaAnterior.SelectedDate.ToString("yyyyMMdd") + separador; }
            //    else { consulta = "DA" + calFechaAnterior.SelectedDate.ToString("yyyyMMdd") + separador; }
            //}
            //if (!calFechaFin.SelectedDate.ToString("yyyyMMdd").Equals("00010101") &&
            //    !calFechaAnterior.SelectedDate.ToString("yyyyMMdd").Equals("00010101")
            //    )
            //{
            //    if (consulta.Length != 0) { consulta = consulta + "DF" + calFechaFin.SelectedDate.ToString("yyyyMMdd") + separador; }
            //    else { consulta = "DF" + calFechaFin.SelectedDate.ToString("yyyyMMdd") + separador; }
            //}



            if (consulta.Length != 0)
            {
                //if (((String)Session["coFactTodas"])=="") { miSucursal = "S---"; } else { miSucursal = (String)Session["sucursalUser"]; }
                // miSucursal = "S---";
                consulta = consulta.Substring(0, consulta.Length - 1);

                //tbSerie.Text=
                //facturasTodas = (String)Session["coFactTodas"];
                try
                {

                    BD.Conectar();
                    BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
                    BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, consulta);
                    BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
                    BD.AsignarParametroProcedimiento("@ESTADO", System.Data.DbType.String, "");
                    BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, modulo);
                    DT.Load(BD.EjecutarConsulta());
                    BD.Desconectar();
                }
                catch (Exception ex)
                {

                }

                gvFacturas.DataSourceID = null;
                gvFacturas.DataSource = DT;
                gvFacturas.DataBind();
                consulta = "";

            }
            PanelBusca.Width = 20;
            PanelBusca.Height = 20;
            PanelBusca.EnableViewState = false;
            PanelBusca.Visible = false;
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            PanelBusca.Width = 425;
            PanelBusca.Height = 297;
            PanelBusca.EnableViewState = true;
            PanelBusca.Visible = true;
        }

        protected void gvFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvFacturas.SelectedRow;
            idres = Convert.ToString(gvFacturas.DataKeys[row.RowIndex].Value);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            //------------cancelar
          if (idres != "")
            {
            Pcancelar.Width = 425;
            Pcancelar.Height = 197;
            string[] datos = llenar().Split('|');

            Lcancel1.Text = datos[0];
            Lcancel2.Text = datos[1];
            Lcancel3.Text = datos[2];
            Pcancelar.Visible = true;
            }
          else
          {
              Session["estNot"] = false;
              Session["msjNoti"] = "DEBES SELECIONAR UNA FACTURA";
              Session["estPan"] = true;
          }
        }


        protected bool update(string band) {
            try
            {
                BD.Conectar();
                BD.CrearComando("UPDATE GENERAL SET estatus=@val,fechaUltimCam=@fecUl,fechaRechazo=@fecrec,causaRechazo=@cau where idFactura=@fact");
                BD.AsignarParametroCadena("@val", band);
                BD.AsignarParametroCadena("@fact", idres);
                BD.AsignarParametroFecha("@fecUl", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                BD.AsignarParametroCadena("@fecrec", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                if (band == "rechazado") 
                {
                    BD.AsignarParametroCadena("@cau", Tbrechazar.Text);
                }
                else
                {
                    BD.AsignarParametroCadena("@cau", tbcausa.Text);
                }
                BD.EjecutarConsulta();
                BD.Desconectar();
                return true;
            }catch(Exception h ){
                return false;
            }
        }

        protected string llenar()
        {
            string dat = "";
            BD.Conectar();
            BD.CrearComando("select NOMEMI as proveedor,serie,folio from GENERAL inner join EMISOR on EMISOR.IDEEMI = GENERAL.id_Emisor where GENERAL.idFactura=@id");
            BD.AsignarParametroCadena("@id",idres);
            DbDataReader DR = BD.EjecutarConsulta();
            if (DR.Read()) {
                dat += DR[0].ToString()+"|";
                dat += DR[1].ToString();
                dat += "|"+ DR[2].ToString();
            }
            BD.Desconectar();

            return dat;
           
        }

        protected void bgrab_Click(object sender, EventArgs e)
        {
           
                if (update("cancelado"))
                {
                    idres = "";
                    //Response.Redirect("~/MenuNuevo.aspx");
                    Session["estNot"] = true;
                    Session["msjNoti"] = "FACTURA CANCELADA";
                    Session["estPan"] = true;
                    Pcancelar.Width = 10;
                    Pcancelar.Height = 10;
                    Pcancelar.Visible = false;
                }
                else
                {
                    
                    Session["estNot"] = false;
                    Session["msjNoti"] = "PROBLEMAS AL CANCELAR";
                    Session["estPan"] = true;
                }
            
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            //-----------rechazar
            if (idres != "")
            {
                Prechazar.Width = 425;
                Prechazar.Height = 197;
                string[] datos = llenar().Split('|');

                Lrechazar1.Text = datos[0];
                Lrechazar2.Text = datos[1];
                Lrechazar3.Text = datos[2];
                Prechazar.Visible = true;
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UNA FACTURA";
                Session["estPan"] = true;
            }

        }

        protected void Button46_Click(object sender, EventArgs e)
        {
            //click rechazar
            if (update("rechazado"))
            {
                idres = "";
                //Response.Redirect("~/MenuNuevo.aspx");
                Session["estNot"] = true;
                Session["msjNoti"] = "FACTURA RECHAZADA";
                Session["estPan"] = true;
                Prechazar.Width = 10;
                Prechazar.Height = 10;
                Prechazar.Visible = false;
            }
            else
            {

                Session["estNot"] = false;
                Session["msjNoti"] = "PROBLEMAS AL CANCELAR";
                Session["estPan"] = true;
            }
        }

        protected void Button50_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MenuNuevo.aspx");
        }

        protected void Button51_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MenuNuevo.aspx");
        }

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView5.SelectedRow;
            idres = Convert.ToString(GridView5.DataKeys[row.RowIndex].Value);
        }

        protected void Button37_Click(object sender, EventArgs e)
        {
            //----------Editar dias------------------
            if (idres != "")
            {
                Pdias.Width = 425;
                Pdias.Height = 197;
                string dia1 = "", habi = "", hi = "", hf = "";

                BD.Conectar();
                BD.CrearComando("Select dia, habilitado, horaIni, horaFin from diasOperacion where dia=@dia");
                BD.AsignarParametroCadena("@dia",idres);
                DbDataReader DR = BD.EjecutarConsulta();
                if (DR.Read()) {
                    dia1 = DR[0].ToString();
                    habi = DR[1].ToString();
                    hi = DR[2].ToString();
                    hf = DR[3].ToString();
                }

                BD.Desconectar();
                Ldia1.Text = dia1;
                if (habi == "Si") {
                    Checkdia.Checked = true;
                }
                if(hi!="" && hf !=""){
                    Dropdia1.SelectedValue = hi;
                    Dropdia2.SelectedValue = hf;
                }

                Pdias.Visible = true;
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN DÍA";
                Session["estPan"] = true;
            }
        }

        protected void Button54_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MenuNuevo.aspx");
        }

        protected void Button53_Click(object sender, EventArgs e)
        {
            //-------grabar dia-----------------------
            BD.Conectar();
            BD.CrearComando("update diasOperacion set habilitado=@habi, horaIni=@hi, horaFin=@fi where dia=@dia");
            if (Checkdia.Checked)
            {
                BD.AsignarParametroCadena("@habi", "Si");
            }
            else { BD.AsignarParametroCadena("@habi", "No");}
            BD.AsignarParametroCadena("@hi",Dropdia1.SelectedValue);
            BD.AsignarParametroCadena("@fi", Dropdia2.SelectedValue);
            BD.AsignarParametroCadena("@dia", idres);
            BD.EjecutarConsulta();
            BD.Desconectar();

            idres = "";
            Session["estNot"] = true;
            Session["msjNoti"] = "DIA DE OPERACIÓN EDITADO";
            Session["estPan"] = true;
            Pdias.Width = 10;
            Pdias.Height = 10;
            Pdias.Visible = false;
        }


    }
}