using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data.Common;
using System.Threading;

namespace DataExpressWeb
{
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void caN_Click(object sender, EventArgs e)
        {
            Session["otra"] = null;
            Response.Redirect("~/cuenta/Login.aspx");
        }

        protected void ace_Click(object sender, EventArgs e)
        {
            string oldps,nuevap,confp;
            bool sta = false;
            oldps = vieja.Text;
            nuevap = nueva.Text;
            confp = confir.Text;
            bool num = false, may = false, min = false, sim = false;
            BD.Conectar();
            BD.CrearComando("SELECT * FROM Proveedores where pass=@ps");
            BD.AsignarParametroCadena("@ps", oldps);
            DbDataReader DR = BD.EjecutarConsulta();
            if (DR.Read())
            {
                sta = true;
            }
            BD.Desconectar();

            if (sta == true)
            {
                if (nuevap.Length >= 8 && confp.Length >= 8)
                {
                  if (nuevap == confp)
                  {
                      foreach (var c in confp)
                      {
                          if (c >= '0' && c <= '9')
                          {
                              num = true;
                          }
                          if (c >= 'a' && c <= 'z')
                          {
                              min = true;
                          }
                          if (c >= 'A' && c <= 'Z')
                          {
                              may = true;
                          }
                          if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                          {
                              sim = true;
                          }
                      }

                      if (num && min && may && sim)
                      {
                          BD.Conectar();
                          BD.CrearComando("UPDATE Proveedores SET pass=@nps WHERE pass=@ps");
                          BD.AsignarParametroCadena("@nps", confp);
                          BD.AsignarParametroCadena("@ps", oldps);
                          BD.EjecutarConsulta();
                          BD.Desconectar();


                          Session["confirmacion"] = 2;
                          Session["mensajeCon"] = "CONTRASEÑA RENOVADA CON ÉXITO";
                          Session["redi"] = 2;
                          Session["adSub"] = "";
                          Response.Redirect("~/notificacion.aspx");
                      }
                      else
                      {
                          msj.Text = "Formato de contraseña incorrecto <br/> (debe de contener mayúsculas, minúsculas, números y caracteres especiales)";
                      }


                  }
                  else
                  {
                      Session["estNot"] = false;
                      Session["msjNoti"] = "LA NUEVA CONTRASEÑA NO COINCIDE";
                      Session["estPan"] = true;
                  }
                }
              else
                {
                      msj.Text = "El tamaño de la contraseña <br/> no puede ser menor a 8 caracteres";
               }
                    //Response.Redirect("~/cuenta/Login.aspx");
                
            }
            else {
                Session["estNot"] = false;
                Session["msjNoti"] = "TU ANTIGUA CONTRASEÑA NO ES CORRECTA";
                Session["estPan"] = true;
            }
        }
    }
}