using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.Common;
using System.Collections;
using Datos;

namespace DataExpressWeb
{
    public partial class Formulario_web128 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        static string rutaArc = "";
        static int separ = 0;
        static string arc = "";
        static string NomMod = "";
        static byte[] archivo;
        Boolean RFC_Existe_Catalogo = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || Session["adm"] == null || Session["permisos"] == null)
            {
                Response.Redirect("~/Cerrar.aspx");
            }
            else if (Convert.ToBoolean(Session["adm"]) == false)
            {
                Response.Redirect("~/Documentos.aspx");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomArc = DropDownList1.SelectedValue;
            arc = nomArc;
            if (DropDownList1.SelectedValue != "Seleccionar")
            {
                rutaArc = AppDomain.CurrentDomain.BaseDirectory + @"catalogos\" + nomArc + ".txt";
                if (arc == "Proveedores")
                {
                    Lform.Text = "Formato:<br> RFC|Razón Social|tipo de proveedor|Vendor ID|Vendor Site ID";
                    Lform1.Text = "Formato:<br> RFC|Razón Social|tipo de proveedor|Vendor ID|Vendor Site ID";
                    Label3.Text = "Buscar por RFC:";
                    separ = 4;
                    LabelN.Visible = false;
                    ButCat.Visible = false;
                    ArcCat.Visible = false;
                    Lms5.Visible = false;
                }
                else if (arc == "Catalogo-Analistas")
                {
                    Lform.Text = "Formato:<br> CC|Nombre Site|Nombre cliente|Cliente|Sector|Nombre Completo Financier|User Mark View|Correo|Ext. o Tel.|Finance Partner|Otro";
                    Lform1.Text = "Formato:<br> CC|Nombre Site|Nombre cliente|Cliente|Sector|Nombre Completo Financier|User Mark View|Correo|Ext. o Tel.|Finance Partner|Otro";
                    Label3.Text = "Buscar por Correo:";
                    separ = 10;

                    LabelN.Visible = true;
                    ButCat.Visible = true;
                    ArcCat.Visible = true;
                    Lms5.Visible = false;
                }
                else if (arc == "Catalogo-Analistas2")
                {
                    Lform.Text = "Formato:<br> CC|Nombre Site|Cliente|Nombre cliente|Vendor Site ID|Sector|Financiero|Ext. o Tel.";
                    Lform1.Text = "Formato:<br> CC|Nombre Site|Cliente|Nombre cliente|Vendor Site ID|Sector|Financiero|Ext. o Tel.";
                    Label3.Text = "Buscar por CC:";
                    separ = 6;
                    LabelN.Visible = false;
                    ButCat.Visible = false;
                    ArcCat.Visible = false;
                    Lms5.Visible = false;
                }
                PanCat.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string resp = registros(TextBusc.Text);
            if(resp==""){
                Lms1.Text = "no se encotrarón registros";
            }
        }

        protected void ButtonCC_Click(object sender, EventArgs e)
        {
            ListaReg.Items.Clear();
            string resp = registrosCC(Centro1.Text + "|||" + Centro2.Text);
            if (resp == "")
            {
                Lms1.Text = "no se encotrarón registros";
            }
        }

        protected string registrosCC(string rfc)
        {
            int vl = 0;
            string rs = "";
            if (arc == "Proveedores")
            {
                vl = 5;
            }
            else if (arc == "Catalogo-Analistas")
            {
                vl = 11;

            }
            else if (arc == "Catalogo-Analistas2")
            {
                vl = 7;
            }
            if (vl > 0)
            {
                string[] valores = new string[vl];

                StreamReader sr = new StreamReader(rutaArc);
                var linea = "";
                linea = sr.ReadLine();

                while (!String.IsNullOrEmpty(linea))
                {
                    linea = sr.ReadLine();
                    if (!String.IsNullOrEmpty(linea))
                    {
                        valores = linea.Split('|');

                        if (arc == "Proveedores")
                        {
                            if (valores[0].Trim().Equals(Centro1.Text) && valores[3].Trim().Equals(Centro2.Text))
                            {
                                ListaReg.Items.Add(linea);
                                rs = "si";
                            }
                        }
                        else if (arc == "Catalogo-Analistas")
                        {
                            if (valores[0].Trim().Equals(Centro1.Text) && valores[3].Trim().Equals(Centro2.Text))
                            {
                                ListaReg.Items.Add(linea);
                                rs = "si";
                            }
                        }
                        else if (arc == "Catalogo-Analistas2")
                        {
                            if (valores[0].Trim().Equals(Centro1.Text) && valores[3].Trim().Equals(Centro2.Text))
                            {
                                ListaReg.Items.Add(linea);
                                rs = "si";
                            }
                        }
                    }
                }
                sr.Dispose();
                sr.Close();
            }

            if (rs != "")
            {
                return rs;
            }
            else { return ""; }

        }

        protected string registros(string rfc)
        {
            int vl=0;
            string rs = "";
            if (arc == "Proveedores")
            {
                vl = 5;
            }
            else if (arc == "Catalogo-Analistas")
            {
                vl = 11;
                
            }
            else if (arc == "Catalogo-Analistas2")
            {
                vl = 7;
            }
            if (vl > 0)
            {
                string[] valores = new string[vl];

                StreamReader sr = new StreamReader(rutaArc);
                var linea = "";
                linea = sr.ReadLine();

                while (!String.IsNullOrEmpty(linea))
                {
                    linea = sr.ReadLine();
                    if (!String.IsNullOrEmpty(linea))
                    {
                        valores = linea.Split('|');

                        if (arc == "Proveedores")
                        {
                            if (valores[0].Trim().Equals(rfc))
                            {
                                ListaReg.Items.Add(linea);
                                rs = "si";
                            }
                        }
                        else if (arc == "Catalogo-Analistas")
                        {
                            if (valores[7].Trim().Equals(rfc))
                            {
                                ListaReg.Items.Add(linea);
                                rs = "si";
                            }
                        }
                        else if (arc == "Catalogo-Analistas2")
                        {
                            if (valores[0].Trim().Equals(rfc))
                            {
                                ListaReg.Items.Add(linea);
                                rs = "si";
                            }
                        }
                    }
                }
                sr.Dispose();
                sr.Close();
            }

            if (rs != "")
            {
                return rs;
            }
            else { return ""; }

        }

        protected void ButEdit_Click(object sender, EventArgs e)
        {
            int co = 0;
            foreach (ListItem item in ListaReg.Items)
            {
                if (item.Selected)
                {
                    co++;
                    if (co == 1)
                    {
                        TextMod.Text = item.Value;
                        NomMod = item.Value;
                    }
                }
            }
            if (co > 1)
            {
                Lms2.Text = "Solo puedes selecionar un registro";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string textoDocumento = "";
            try
            {
                if (TextMod.Text != "")
                {
                    if (TextMod.Text.IndexOf("|") > 0)
                    {
                     string[] sp = TextMod.Text.Split('|');
                     if (sp.Count() == separ + 1)
                     {
                         System.IO.StreamReader sr = new System.IO.StreamReader(rutaArc);
                         textoDocumento = sr.ReadToEnd();
                         sr.Close();

                         textoDocumento = textoDocumento.Replace(NomMod, TextMod.Text);

                         System.IO.StreamWriter sw = new System.IO.StreamWriter(rutaArc);
                         sw.WriteLine(textoDocumento);
                         sw.Close();

                         ListaReg.Items.Clear();
                         TextMod.Text = "";
                         Lms3.Text = "Modificación correcta";
                     }
                     else
                     {
                         Lms3.Text = "El registro debe de tener " + separ + "separadores";
                     }
                    }
                    else
                    {
                        Lms3.Text = "El registro debe de llevar separadores";
                    }
                }
                else {
                    Lms3.Text = "El campo no puede ir vacio";
                }
            }
            catch (Exception y)
            {
                Lms3.Text = "Problemas al modificar";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)///////AGREGAR
        {
            try
            {
                
                if (TextAgre.Text != "")
                {
                    if (TextAgre.Text.IndexOf("|") > 0)
                    {
                        string[] sp = TextAgre.Text.Split('|');
                        string RFC = sp[0];
                        ///////////////////////////////////////////////////777
                        //string ruta = ruta.Replace("XdService\\Interfaz\\bin\\Debug\\datos.txt", "Datos\\datos.txt");
                        string respDat = "";
                        string ruta = System.AppDomain.CurrentDomain.BaseDirectory + @"catalogos\Proveedores.txt";
                        string[] valores = new string[5];
                        StreamReader sr = new StreamReader(ruta);
                        var linea = "";
                        linea = sr.ReadLine();
                        while ((linea = sr.ReadLine()) != null)
                        //while (!String.IsNullOrEmpty(linea))
                        {
                            //linea = sr.ReadLine();
                            if (!String.IsNullOrEmpty(linea))
                            {
                                valores = linea.Split('|');
                                if (valores[0].Trim().Equals(sp[0]))
                                {
                                    //   respDat = valores[2] + "|" + valores[3] + "|" + valores[4];
                                    RFC_Existe_Catalogo = true;
                                }
                            }

                        }
                        sr.Dispose();
                        sr.Close();

                        ////////////////////////////////////////////////////////
                        if (!RFC_Existe_Catalogo)
                        {
                            if (sp.Count() == separ + 1)
                            {
                                // esto inserta texto en un archivo existente, si el archivo no existe lo crea
                                StreamWriter writer = File.AppendText(rutaArc);
                                writer.WriteLine(TextAgre.Text.ToUpper());
                                writer.Close();

                                Lms4.Text = "Registro Agregado";
                            }
                            else
                            {
                                Lms4.Text = "El registro debe de tener " + separ + "separadores";
                            }
                        }

                        else /////////////////validad RFC
                        {
                            Lms4.Text = "Existe un registro con este RFC";
                        }
                    }
                    else
                    {
                        Lms4.Text = "El registro debe de llevar separadores";
                    }
                }
                else
                {
                    Lms4.Text = "El campo no puede ir vacio";
                }
            }
            catch(Exception t)
            {
                String archivo = System.AppDomain.CurrentDomain.BaseDirectory + @"ErrorReg.txt";
                //Label2.Text = archivo;
                using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(archivo))
                {
                    escritor.WriteLine(t.ToString());
                }

                Lms4.Text = "Error al agregar registro";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (ArcCat.HasFile)
            {
              
                archivo = ArcCat.FileBytes;
                String ext = System.IO.Path.GetExtension(ArcCat.FileName);
                if (ext == ".TXT" || ext == ".txt")
                {
                    PanelSeg.Width = 405;
                    PanelSeg.Height = 220;
                    PanelSeg.Visible = true;
                    Lms5.Visible = false;
                }
                else
                {
                    Session["estNot"] = false;
                    Session["msjNoti"] = "EL ARCHIVO DEBE SER DE TEXTO (.txt)";
                    Session["estPan"] = true;
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "NO SE HA SELECIONADO UN ARCHIVO";
                Session["estPan"] = true;
            }
        }

        protected void But_Click(object sender, EventArgs e)
        {
            PanelSeg.Width = 20;
            PanelSeg.Height = 20;
            PanelSeg.Visible = false;
        }

        protected void But2_Click(object sender, EventArgs e)
        {
            String rutLic = AppDomain.CurrentDomain.BaseDirectory + @"catalogos\";
            string grupo = "";
            //BD.Conectar();
            //BD.CrearComando("select grupo from usuarios where login=@lg and pass=@ps");
            //BD.AsignarParametroCadena("@lg", TextUser.Text);
            //BD.AsignarParametroCadena("@ps", TextPas.Text);
            //DbDataReader DRL = BD.EjecutarConsulta();
            //if (DRL.Read())
            //{
            //    grupo = DRL[0].ToString();
            //}
            //BD.Desconectar();

            //if (grupo == "Administrador")
            //{
                if (File.Exists(rutLic + "Catalogo-Analistas.txt"))
                {
                    if (archivo != null)
                    {
                        File.Delete(rutLic + "Catalogo-Analistas.txt");
                        System.IO.File.WriteAllBytes(rutLic + "Catalogo-Analistas.txt", archivo);
                    }
                }
                else
                {
                    if (archivo != null)
                    {
                        System.IO.File.WriteAllBytes(rutLic + "Catalogo-Analistas.txt", archivo);
                    }
                }

                //archivo = System.Array.Clear(); 
                archivo = null;
                PanelSeg.Width = 20;
                PanelSeg.Height = 20;
                PanelSeg.Visible = false;
                Lms5.Text = "Catálogo actualizado con éxito.";
                Lms5.Visible = true;
   
            }
            //else
            //{
            //    if (grupo == "")
            //    {
            //        Session["estNot"] = false;
            //        Session["msjNoti"] = "DATOS INCORRECTOS";
            //        Session["estPan"] = true;
            //    }
            //    else
            //    {
            //        Session["estNot"] = false;
            //        Session["msjNoti"] = "LOS DATOS NO CORRESPONDEN A UN ADMINITRADOR";
            //        Session["estPan"] = true;
            //    }
            //}
      //  }
       
    }
}