using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Datos;

namespace regRutas
{
    public partial class Inicio : Form
    {

        private string rutaAr;
        BasesDatos DB = new BasesDatos();
        private int x = 0,y=0, i, f;

        public Inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialogoRuta = new FolderBrowserDialog();
            if (dialogoRuta.ShowDialog() == DialogResult.OK)
            {
                rut.Text = dialogoRuta.SelectedPath+@"\";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            String auxRut, rutAct = "";
            int tamAux;
            string NomComp;
            string[] separador2 = new string[] { @"\","/" };
            string[] nomRut;
   if (!(rut.Text == "" && pri.Text == "" && ult.Text == ""))
       {
           rutaAr = rut.Text;
            i = Convert.ToInt32(pri.Text);
            f = Convert.ToInt32(ult.Text);
         if (rut.Text.Contains("docus"))
         {
                if (i <= f)
                    {
                            for (int fo = i; fo <= f; fo++)
                            {
                                DB.Conectar();
                                DB.CrearComando(@"SELECT XMLARC FROM Archivos WHERE IDEFAC=@fol");
                                DB.AsignarParametroEntero("@fol", fo);
                                IDataReader DR = DB.EjecutarConsulta();
                                if (DR.Read())
                                {
                                    rutAct = DR[0].ToString();
                                }
                                DB.Desconectar();
                                nomRut = rutAct.Split(separador2, StringSplitOptions.None);
                                tamAux = nomRut.Count();
                                NomComp = nomRut[tamAux - 1];

                                //auxRut = rutAct;
                                //rutAct = rutAct.Replace("/",@"\");
                               // MessageBox.Show(NomComp + "-" + rutaAr + "-" + rutAct + "-" + fo);
                                buscar(NomComp, rutaAr,rutAct,fo);
   
                            }

                            tot.Text = "ARCHIVOS REVIZADOS: " + y;
                            mod.Text = "ARCHIVOS MODIFICADOS: " + x;
                            tot.Visible = true;
                            mod.Visible = true;
                    }
                    else
                    {

                        error.Text = "EL INTERVALO ES INCORRECTO";
                        error.Visible = true;
                    }
                }
                else
                {
                    error.Text = "SELECCIONE LA CARPETA docus";
                    error.Visible = true;
                    
                }
            }
else
{
    error.Text = "LLENAR TODOS LOS CAMPOS";
    error.Visible = true;
}

        }


        private void buscar(String nom2, String rut2, String rutaBDD, int fol)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(rut2);
            string rutaArchivo,splRut;
            string[]  rutSplit;
            string[] separador2 = new string[] { @"docus\" };

            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            IEnumerable<System.IO.FileInfo> fileQuery =
                from file in fileList
                where file.Name == nom2
                select file;

           //MessageBox.Show(nom2+"-"+rut2+"-"+rutaBDD+"-"+fol);

            foreach (System.IO.FileInfo fi in fileQuery)
            {
                rutaArchivo=fi.FullName;
                rutSplit = rutaArchivo.Split(separador2, StringSplitOptions.None);
                splRut=rutSplit[1];

         //    MessageBox.Show(rutaBDD+"  "+ @"docus\" + splRut);

                if (!(rutaBDD == @"docus\" + splRut))
                {
                    DB.Conectar();
                    DB.CrearComando(@"UPDATE Archivos SET XMLARC=@XML,PDFARC=@PDF WHERE IDEFAC=@FAC");
                    DB.AsignarParametroCadena("@XML", @"docus\" + splRut);
                    splRut = splRut.Replace(".xml", ".pdf");
                    DB.AsignarParametroCadena("@PDF", @"docus\" + splRut);
                    DB.AsignarParametroEntero("@FAC", fol);
                    DB.EjecutarConsulta();
                    DB.Desconectar();
                    x++;
                    y++;
                }
                else {
                    y++;
                }
            } //MessageBox.Show("NO ENTRO AL FOREACH");

        }

        private void pri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                error.Text = "EL CAMPO SOLO ACEPTA NUMEROS";
                error.Visible = true;
            }
        }
        private void ult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                error.Text = "EL CAMPO SOLO ACEPTA NUMEROS";
                error.Visible = true;
            }

        }
    }
}
