using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using Datos;
using System.Data.Common;

namespace ups
{
    public partial class Mostrar : System.Web.UI.Page
    {
        private BasesDatos DB = new BasesDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DB.Conectar();
                DB.CrearComandoProcedimiento("PA_consultarParametros");
                DB.AsignarParametroProcedimiento("@idparametro", System.Data.DbType.String, 3);
                DbDataReader DR = DB.EjecutarConsulta();

                while (DR.Read())
                {
                    tbDirdocs.Text = DR[1].ToString();
                    tbDirtxt.Text = DR[2].ToString();
                    tbDirrespaldo.Text = DR[3].ToString();
                    tbDircerti.Text = DR[4].ToString();
                    tbDirllaves.Text = DR[5].ToString();
                    tbemalNotificacion.Text  = DR[13].ToString();
                }
                DB.Desconectar();
            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            tbDirtxt.ReadOnly = false;
            tbDirdocs.ReadOnly = false;
            tbDirtxt.ReadOnly = false;
            tbDirrespaldo.ReadOnly = false;
            tbDircerti.ReadOnly = false;
            tbDirllaves.ReadOnly = false;
            bModificar.Visible = false;
            tbemalNotificacion.Visible  = true;
            bActualizar.Visible = true;
        }

        protected void bActualizar_Click(object sender, EventArgs e)
        {

            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_modificarParametros");
            DB.AsignarParametroProcedimiento("@idparametro", System.Data.DbType.Int16, 0);
            DB.AsignarParametroProcedimiento("@dirdocs", System.Data.DbType.String, tbDirdocs.Text);
            DB.AsignarParametroProcedimiento("@dirtxt", System.Data.DbType.String, tbDirtxt.Text);
            DB.AsignarParametroProcedimiento("@dirrespaldo", System.Data.DbType.String, tbDirrespaldo.Text);
            DB.AsignarParametroProcedimiento("@dircertificados", System.Data.DbType.String, tbDircerti.Text);
            DB.AsignarParametroProcedimiento("@dirllaves", System.Data.DbType.String, tbDirllaves.Text);
            DB.AsignarParametroProcedimiento("@emailNotificacion", System.Data.DbType.String, tbemalNotificacion.Text);
            //DbDataReader DR = DB.EjecutarConsulta1();
            DB.EjecutarConsulta();
            DB.Desconectar();
            tbDirtxt.ReadOnly = true;
            tbDirdocs.ReadOnly = true;
            tbDirtxt.ReadOnly = true;
            tbDirrespaldo.ReadOnly = true;
            tbDircerti.ReadOnly = true;
            tbDirllaves.ReadOnly = true;
            bActualizar.Visible = false;
            bModificar.Visible = true;
            tbemalNotificacion.Visible = true;

        }

        protected void tbDirtxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}