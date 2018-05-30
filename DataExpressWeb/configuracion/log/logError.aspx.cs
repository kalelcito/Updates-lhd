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
namespace DataExpressWeb.configuracion.log
{
    public partial class logError : System.Web.UI.Page
    {

        string consulta;
        string separador;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void bBuscarReg_Click(object sender, EventArgs e)
        {
            separador = "|";
            consulta = "";
            if (tbNoOrden.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "NO" + tbNoOrden.Text + separador; }
                else { consulta = "NO" + tbNoOrden.Text + separador; }
            }

            if (tbArchivo.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "AR" + tbArchivo.Text + separador; }
                else { consulta = "AR" + tbArchivo.Text + separador; }
            }


            if ( tbDetalle.Text.Length   != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "DL" + tbDetalle.Text + separador; }
                else { consulta = "DL" + tbDetalle.Text + separador; }
            }

            if (tbTipo.Text.Length != 0)
            {
                if (consulta.Length != 0) { consulta = consulta + "TP" + tbTipo.Text + separador; }
                else { consulta = "TP" + tbTipo.Text + separador; }
            }


            if (!calFechaAnterior.SelectedDate.ToShortDateString().Equals("01/01/0001") &&
                !calFechaFin.SelectedDate.ToShortDateString().Equals("01/01/0001")
                )
            {
                if (consulta.Length != 0) { consulta = consulta + "DA" + calFechaAnterior.SelectedDate.ToString("dd/MM/yyyy") + separador; }
                else { consulta = "DA" + calFechaAnterior.SelectedDate.ToString("dd/MM/yyyy") + separador; }
            }
            if (!calFechaFin.SelectedDate.ToShortDateString().Equals("01/01/0001") &&
                !calFechaAnterior.SelectedDate.ToShortDateString().Equals("01/01/0001")
                )
            {
                if (consulta.Length != 0) { consulta = consulta + "DF" + calFechaFin.SelectedDate.ToString("dd/MM/yyyy") + separador; }
                else { consulta = "DF" + calFechaFin.SelectedDate.ToString("dd/MM/yyyy") + separador; }
            }

            //cambiar a formato ingles MM/dd/yyyy


            if (consulta.Length != 0)
            {
                consulta = consulta.Substring(0, consulta.Length - 1);
                SqlDataSource1.SelectParameters["QUERY"].DefaultValue = consulta;
                SqlDataSource1.DataBind();
                gvLog.DataBind();
                consulta = "";
            }
        }

        protected void bActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/configuracion/log/logError.aspx");
        }
    }
}