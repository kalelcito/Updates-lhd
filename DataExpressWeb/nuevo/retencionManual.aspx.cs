using Control;
using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace DataExpressWeb.nuevo
{
    public partial class retencionManual : System.Web.UI.Page
    {
        private void Log(string logMessage)
        {
            var _dbLog = new BasesDatos();
            _dbLog.Conectar();
            try
            {
                _dbLog.CrearComando(@"INSERT INTO PruebasLog VALUES (@pagina, @fechaHora, @mensaje)");
                _dbLog.AsignarParametroCadena("@pagina", Path.GetFileName(Request.Path));
                _dbLog.AsignarParametroCadena("@fechaHora", DateTime.Now.ToString("s"));
                _dbLog.AsignarParametroCadena("@mensaje", logMessage.Replace("'", "''"));
                _dbLog.EjecutarConsulta1();
            }
            catch { }
            finally
            {
                _dbLog.Desconectar();
            }
        }
        #region Variables

        private static string bck; // = System.AppDomain.CurrentDomain.BaseDirectory + @"bcktxt\"; //DRdir[2].ToString();
        private readonly BasesDatos DB = new BasesDatos();
        private DataTable DT = new DataTable();
        //private Lectura myXml1;
        private static bool nacional;
        private static string pdf; // = System.AppDomain.CurrentDomain.BaseDirectory + @"docus\";//DRdir[1].ToString();
        private static string txt; // = System.AppDomain.CurrentDomain.BaseDirectory + @"txt\";// DRdir[0].ToString();
        private static Button btnFinish;

        #region ListaPaises

        private List<ListItem> listaPaises = new List<ListItem>()
            {
                new ListItem("SELECCIONE PAIS", ""),
                new ListItem("AFGANISTAN (EMIRATO ISLAMICO DE)", "AF"),
                new ListItem("ALBANIA (REPUBLICA DE)", "AL"),
                new ListItem("ALEMANIA (REPUBLICA FEDERAL DE)", "DE"),
                new ListItem("ANDORRA (PRINCIPADO DE)", "AD"),
                new ListItem("ANGOLA (REPUBLICA DE)", "AO"),
                new ListItem("ANGUILA", "AI"),
                new ListItem("ANTARTIDA", "AQ"),
                new ListItem("ANTIGUA Y BARBUDA (COMUNIDAD BRITANICA DE NACIONES)", "AG"),
                new ListItem("ANTILLAS NEERLANDESAS (TERRITORIO HOLANDES DE ULTRAMAR)", "AN"),
                new ListItem("ARABIA SAUDITA (REINO DE)", "SA"),
                new ListItem("ARGELIA (REPUBLICA DEMOCRATICA Y POPULAR DE)", "DZ"),
                new ListItem("ARGENTINA (REPUBLICA)", "AR"),
                new ListItem("ARMENIA (REPUBLICA DE)", "AM"),
                new ListItem("ARUBA (TERRITORIO HOLANDES DE ULTRAMAR)", "AW"),
                new ListItem("AUSTRALIA (COMUNIDAD DE)", "AU"),
                new ListItem("AUSTRIA (REPUBLICA DE)", "AT"),
                new ListItem("AZERBAIJAN (REPUBLICA AZERBAIJANI)", "AZ"),
                new ListItem("BAHAMAS (COMUNIDAD DE LAS)", "BS"),
                new ListItem("BAHREIN (ESTADO DE)", "BH"),
                new ListItem("BANGLADESH (REPUBLICA POPULAR DE)", "BD"),
                new ListItem("BARBADOS (COMUNIDAD BRITANICA DE NACIONES)", "BB"),
                new ListItem("BELGICA (REINO DE)", "BE"),
                new ListItem("BELICE", "BZ"),
                new ListItem("BENIN (REPUBLICA DE)", "BJ"),
                new ListItem("BERMUDAS", "BM"),
                new ListItem("BIELORRUSIA (REPUBLICA DE)", "BY"),
                new ListItem("BOLIVIA (REPUBLICA DE)", "BO"),
                new ListItem("BOSNIA Y HERZEGOVINA", "BA"),
                new ListItem("BOTSWANA (REPUBLICA DE)", "BW"),
                new ListItem("BRASIL (REPUBLICA FEDERATIVA DE)", "BR"),
                new ListItem("BRUNEI (ESTADO DE) (RESIDENCIA DE PAZ)", "BN"),
                new ListItem("BULGARIA (REPUBLICA DE)", "BG"),
                new ListItem("BURKINA FASO", "BF"),
                new ListItem("BURUNDI (REPUBLICA DE)", "BI"),
                new ListItem("BUTAN (REINO DE)", "BT"),
                new ListItem("CABO VERDE (REPUBLICA DE)", "CV"),
                new ListItem("CHAD (REPUBLICA DEL)", "TD"),
                new ListItem("CAIMAN (ISLAS)", "KY"),
                new ListItem("CAMBOYA (REINO DE)", "KH"),
                new ListItem("CAMERUN (REPUBLICA DEL)", "CM"),
                new ListItem("CANADA", "CA"),
                new ListItem("CHILE (REPUBLICA DE)", "CL"),
                new ListItem("CHINA (REPUBLICA POPULAR)", "CN"),
                new ListItem("CHIPRE (REPUBLICA DE)", "CY"),
                new ListItem("CIUDAD DEL VATICANO (ESTADO DE LA)", "VA"),
                new ListItem("COCOS (KEELING, ISLAS AUSTRALIANAS)", "CC"),
                new ListItem("COLOMBIA (REPUBLICA DE)", "CO"),
                new ListItem("COMORAS (ISLAS)", "KM"),
                new ListItem("CONGO (REPUBLICA DEL)", "CG"),
                new ListItem("COOK (ISLAS)", "CK"),
                new ListItem("COREA (REPUBLICA POPULAR DEMOCRATICA DE) (COREA DEL NORTE)", "KP"),
                new ListItem("COREA (REPUBLICA DE) (COREA DEL SUR)", "KR"),
                new ListItem("COSTA DE MARFIL (REPUBLICA DE LA)", "CI"),
                new ListItem("COSTA RICA (REPUBLICA DE)", "CR"),
                new ListItem("CROACIA (REPUBLICA DE)", "HR"),
                new ListItem("CUBA (REPUBLICA DE)", "CU"),
                new ListItem("DINAMARCA (REINO DE)", "DK"),
                new ListItem("DJIBOUTI (REPUBLICA DE)", "DJ"),
                new ListItem("DOMINICA (COMUNIDAD DE)", "DM"),
                new ListItem("ECUADOR (REPUBLICA DEL)", "EC"),
                new ListItem("EGIPTO (REPUBLICA ARABE DE)", "EG"),
                new ListItem("EL SALVADOR (REPUBLICA DE)", "SV"),
                new ListItem("EMIRATOS ARABES UNIDOS", "AE"),
                new ListItem("ERITREA (ESTADO DE)", "ER"),
                new ListItem("ESLOVENIA(REPUBLICA DE)", "SI"),
                new ListItem("ESPAÑA (REINO DE)", "ES"),
                new ListItem("ESTADO FEDERADO DE MICRONESIA", "FM"),
                new ListItem("ESTADOS UNIDOS DE AMERICA", "US"),
                new ListItem("ESTONIA (REPUBLICA DE)", "EE"),
                new ListItem("ETIOPIA (REPUBLICA DEMOCRATICA FEDERAL)", "ET"),
                new ListItem("FIDJI (REPUBLICA DE)", "FJ"),
                new ListItem("FILIPINAS (REPUBLICA DE LAS)", "PH"),
                new ListItem("FINLANDIA (REPUBLICA DE)", "FI"),
                new ListItem("FRANCIA (REPUBLICA FRANCESA)", "FR"),
                new ListItem("GABONESA (REPUBLICA)", "GA"),
                new ListItem("GAMBIA (REPUBLICA DE LA)", "GM"),
                new ListItem("GEORGIA (REPUBLICA DE)", "GE"),
                new ListItem("GHANA (REPUBLICA DE)", "GH"),
                new ListItem("GIBRALTAR (R.U.)", "GI"),
                new ListItem("GRANADA", "GD"),
                new ListItem("GRECIA (REPUBLICA HELENICA)", "GR"),
                new ListItem("GROENLANDIA (DINAMARCA)", "GL"),
                new ListItem("GUADALUPE (DEPARTAMENTO DE)", "GP"),
                new ListItem("GUAM (E.U.A.)", "GU"),
                new ListItem("GUATEMALA (REPUBLICA DE)", "GT"),
                new ListItem("GUERNSEY", "GG"),
                new ListItem("GUINEA-BISSAU (REPUBLICA DE)", "GW"),
                new ListItem("GUINEA ECUATORIAL (REPUBLICA DE)", "GQ"),
                new ListItem("GUINEA (REPUBLICA DE)", "GN"),
                new ListItem("GUYANA FRANCESA", "GF"),
                new ListItem("GUYANA (REPUBLICA COOPERATIVA DE)", "GY"),
                new ListItem("HAITI (REPUBLICA DE)", "HT"),
                new ListItem("HONDURAS (REPUBLICA DE)", "HN"),
                new ListItem("HONG KONG (REGION ADMINISTRATIVA ESPECIAL DE LA REPUBLICA)", "HK"),
                new ListItem("HUNGRIA (REPUBLICA DE)", "HU"),
                new ListItem("INDIA (REPUBLICA DE)", "IN"),
                new ListItem("INDONESIA (REPUBLICA DE)", "ID"),
                new ListItem("IRAK (REPUBLICA DE)", "IQ"),
                new ListItem("IRAN (REPUBLICA ISLAMICA DEL)", "IR"),
                new ListItem("IRLANDA (REPUBLICA DE)", "IE"),
                new ListItem("ISLANDIA (REPUBLICA DE)", "IS"),
                new ListItem("ISLA BOUVET", "BV"),
                new ListItem("ISLA DE MAN", "IM"),
                new ListItem("ISLAS ALAND", "AX"),
                new ListItem("ISLAS FEROE", "FO"),
                new ListItem("ISLAS GEORGIA Y SANDWICH DEL SUR", "GS"),
                new ListItem("ISLAS HEARD Y MCDONALD", "HM"),
                new ListItem("ISLAS MALVINAS (R.U.)", "FK"),
                new ListItem("ISLAS MARIANAS SEPTENTRIONALES", "MP"),
                new ListItem("ISLAS MARSHALL", "MH"),
                new ListItem("ISLAS MENORES DE ULTRAMAR DE ESTADOS UNIDOS DE AMERICA", "UM"),
                new ListItem("ISLAS SALOMON (COMUNIDAD BRITANICA DE NACIONES)", "SB"),
                new ListItem("ISLAS SVALBARD Y JAN MAYEN (NORUEGA)", "SJ"),
                new ListItem("ISLAS TOKELAU", "TK"),
                new ListItem("ISLAS WALLIS Y FUTUNA", "WF"),
                new ListItem("ISRAEL (ESTADO DE)", "IL"),
                new ListItem("ITALIA (REPUBLICA ITALIANA)", "IT"),
                new ListItem("JAMAICA", "JM"),
                new ListItem("JAPON", "JP"),
                new ListItem("JERSEY", "JE"),
                new ListItem("JORDANIA (REINO HACHEMITA DE)", "JO"),
                new ListItem("KAZAKHSTAN (REPUBLICA DE) ", "KZ"),
                new ListItem("KENYA (REPUBLICA DE)", "KE"),
                new ListItem("KIRIBATI (REPUBLICA DE)", "KI"),
                new ListItem("KUWAIT (ESTADO DE)", "KW"),
                new ListItem("KYRGYZSTAN (REPUBLICA KIRGYZIA)", "KG"),
                new ListItem("LESOTHO (REINO DE)", "LS"),
                new ListItem("LETONIA (REPUBLICA DE)", "LV"),
                new ListItem("LIBANO (REPUBLICA DE)", "LB"),
                new ListItem("LIBERIA (REPUBLICA DE)", "LR"),
                new ListItem("LIBIA (JAMAHIRIYA LIBIA ARABE POPULAR SOCIALISTA)", "LY"),
                new ListItem("LIECHTENSTEIN (PRINCIPADO DE)", "LI"),
                new ListItem("LITUANIA (REPUBLICA DE)", "LT"),
                new ListItem("LUXEMBURGO (GRAN DUCADO DE)", "LU"),
                new ListItem("MACAO", "MO"),
                new ListItem("MACEDONIA (ANTIGUA REPUBLICA YUGOSLAVA DE)", "MK"),
                new ListItem("MADAGASCAR (REPUBLICA DE)", "MG"),
                new ListItem("MALASIA", "MY"),
                new ListItem("MALAWI (REPUBLICA DE)", "MW"),
                new ListItem("MALDIVAS (REPUBLICA DE)", "MV"),
                new ListItem("MALI (REPUBLICA DE)", "ML"),
                new ListItem("MALTA (REPUBLICA DE)", "MT"),
                new ListItem("MARRUECOS (REINO DE)", "MA"),
                new ListItem("MARTINICA (DEPARTAMENTO DE) (FRANCIA)", "MQ"),
                new ListItem("MAURICIO (REPUBLICA DE)", "MU"),
                new ListItem("MAURITANIA (REPUBLICA ISLAMICA DE)", "MR"),
                new ListItem("MAYOTTE", "YT"),
                new ListItem("MEXICO (ESTADOS UNIDOS MEXICANOS)", "MX"),
                new ListItem("MOLDAVIA (REPUBLICA DE)", "MD"),
                new ListItem("MONACO (PRINCIPADO DE)", "MC"),
                new ListItem("MONGOLIA", "MN"),
                new ListItem("MONSERRAT (ISLA)", "MS"),
                new ListItem("MONTENEGRO", "ME"),
                new ListItem("MOZAMBIQUE (REPUBLICA DE)", "MZ"),
                new ListItem("MYANMAR (UNION DE)", "MM"),
                new ListItem("NAMIBIA (REPUBLICA DE)", "NA"),
                new ListItem("NAURU", "NR"),
                new ListItem("NAVIDAD (CHRISTMAS) (ISLAS)", "CX"),
                new ListItem("NEPAL (REINO DE)", "NP"),
                new ListItem("NICARAGUA (REPUBLICA DE)", "NI"),
                new ListItem("NIGER (REPUBLICA DE)", "NE"),
                new ListItem("NIGERIA (REPUBLICA FEDERAL DE)", "NG"),
                new ListItem("NIVE (ISLA)", "NU"),
                new ListItem("NORFOLK (ISLA)", "NF"),
                new ListItem("NORUEGA (REINO DE)", "NO"),
                new ListItem("NUEVA CALEDONIA (TERRITORIO FRANCES DE ULTRAMAR)", "NC"),
                new ListItem("NUEVA ZELANDIA", "NZ"),
                new ListItem("OMAN (SULTANATO DE)", "OM"),
                new ListItem("PACIFICO, ISLAS DEL (ADMON. E.U.A.)", "PIK"),
                new ListItem("PAISES BAJOS (REINO DE LOS) (HOLANDA)", "NL"),
                new ListItem("PAKISTAN (REPUBLICA ISLAMICA DE)", "PK"),
                new ListItem("PALAU (REPUBLICA DE)", "PW"),
                new ListItem("PALESTINA", "PS"),
                new ListItem("PANAMA (REPUBLICA DE)", "PA"),
                new ListItem("PAPUA NUEVA GUINEA (ESTADO INDEPENDIENTE DE)", "PG"),
                new ListItem("PARAGUAY (REPUBLICA DEL)", "PY"),
                new ListItem("PERU (REPUBLICA DEL)", "PE"),
                new ListItem("PITCAIRNS (ISLAS DEPENDENCIA BRITANICA)", "PN"),
                new ListItem("POLINESIA FRANCESA", "PF"),
                new ListItem("POLONIA (REPUBLICA DE)", "PL"),
                new ListItem("PORTUGAL (REPUBLICA PORTUGUESA)", "PT"),
                new ListItem("PUERTO RICO (ESTADO LIBRE ASOCIADO DE LA COMUNIDAD DE)", "PR"),
                new ListItem("QATAR (ESTADO DE)", "QA"),
                new ListItem("REINO UNIDO DE LA GRAN BRETAÑA E IRLANDA DEL NORTE", "GB"),
                new ListItem("REPUBLICA CHECA", "CZ"),
                new ListItem("REPUBLICA CENTROAFRICANA", "CF"),
                new ListItem("REPUBLICA DEMOCRATICA POPULAR LAOS", "LA"),
                new ListItem("REPUBLICA DE SERBIA", "RS"),
                new ListItem("REPUBLICA DOMINICANA", "DO"),
                new ListItem("REPUBLICA ESLOVACA", "SK"),
                new ListItem("REPUBLICA POPULAR DEL CONGO", "CD"),
                new ListItem("REPUBLICA RUANDESA", "RW"),
                new ListItem("REUNION (DEPARTAMENTO DE LA) (FRANCIA)", "RE"),
                new ListItem("RUMANIA", "RO"),
                new ListItem("RUSIA (FEDERACION RUSA)", "RU"),
                new ListItem("SAHARA OCCIDENTAL (REPUBLICA ARABE SAHARAVI DEMOCRATICA)", "EH"),
                new ListItem("SAMOA (ESTADO INDEPENDIENTE DE)", "WS"),
                new ListItem("SAMOA AMERICANA", "AS"),
                new ListItem("SAN BARTOLOME", "BL"),
                new ListItem("SAN CRISTOBAL Y NIEVES (FEDERACION DE) (SAN KITTS - NEVIS)", "KN"),
                new ListItem("SAN MARINO (SERENISIMA REPUBLICA DE)", "SM"),
                new ListItem("SAN MARTIN", "MF"),
                new ListItem("SAN PEDRO Y MIQUELON", "PM"),
                new ListItem("SAN VICENTE Y LAS GRANADINAS", "VC"),
                new ListItem("SANTA ELENA", "SH"),
                new ListItem("SANTA LUCIA", "LC"),
                new ListItem("SANTO TOME Y PRINCIPE (REPUBLICA DEMOCRATICA DE)", "ST"),
                new ListItem("SENEGAL (REPUBLICA DEL)", "SN"),
                new ListItem("SEYCHELLES (REPUBLICA DE LAS)", "SC"),
                new ListItem("SIERRA LEONA (REPUBLICA DE)", "SL"),
                new ListItem("SINGAPUR (REPUBLICA DE)", "SG"),
                new ListItem("SIRIA (REPUBLICA ARABE)", "SY"),
                new ListItem("SOMALIA", "SO"),
                new ListItem("SRI LANKA (REPUBLICA DEMOCRATICA SOCIALISTA DE)", "LK"),
                new ListItem("SUDAFRICA (REPUBLICA DE)", "ZA"),
                new ListItem("SUDAN (REPUBLICA DEL)", "SD"),
                new ListItem("SUECIA (REINO DE)", "SE"),
                new ListItem("SUIZA (CONFEDERACION)", "CH"),
                new ListItem("SURINAME (REPUBLICA DE)", "SR"),
                new ListItem("SWAZILANDIA (REINO DE)", "SZ"),
                new ListItem("TADJIKISTAN (REPUBLICA DE)", "TJ"),
                new ListItem("TAILANDIA (REINO DE)", "TH"),
                new ListItem("TAIWAN (REPUBLICA DE CHINA)", "TW"),
                new ListItem("TANZANIA (REPUBLICA UNIDA DE)", "TZ"),
                new ListItem("TERRITORIOS BRITANICOS DEL OCEANO INDICO", "IO"),
                new ListItem("TERRITORIOS FRANCESES, AUSTRALES Y ANTARTICOS", "TF"),
                new ListItem("TIMOR ORIENTAL", "TL"),
                new ListItem("TOGO (REPUBLICA TOGOLESA)", "TG"),
                new ListItem("TONGA (REINO DE)", "TO"),
                new ListItem("TRINIDAD Y TOBAGO (REPUBLICA DE)", "TT"),
                new ListItem("TUNEZ (REPUBLICA DE)", "TN"),
                new ListItem("TURCAS Y CAICOS(ISLAS)", "TC"),
                new ListItem("TURKMENISTAN (REPUBLICA DE)", "TM"),
                new ListItem("TURQUIA (REPUBLICA DE)", "TR"),
                new ListItem("TUVALU (COMUNIDAD BRITANICA DE NACIONES)", "TV"),
                new ListItem("UCRANIA", "UA"),
                new ListItem("UGANDA (REPUBLICA DE)", "UG"),
                new ListItem("URUGUAY (REPUBLICA ORIENTAL DEL)", "UY"),
                new ListItem("UZBEJISTAN (REPUBLICA DE)", "UZ"),
                new ListItem("VANUATU", "VU"),
                new ListItem("VENEZUELA (REPUBLICA DE)", "VE"),
                new ListItem("VIETNAM (REPUBLICA SOCIALISTA DE)", "VN"),
                new ListItem("VIRGENES. ISLAS (BRITANICAS)", "VG"),
                new ListItem("VIRGENES. ISLAS (NORTEAMERICANAS)", "VI"),
                new ListItem("YEMEN (REPUBLICA DE)", "YE"),
                new ListItem("ZAMBIA (REPUBLICA DE)", "ZM")
            };

        #endregion ListaPaises

        #endregion Variables

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || Session["adm"] == null || Session["permisos"] == null)
            {
                Response.Redirect("~/Cerrar.aspx");
            }
            else
            {
                lFecha.Text = DateTime.Now.ToString("s");
                tbEjerc.Text = string.IsNullOrEmpty(tbEjerc.Text) ? DateTime.Now.ToString("yyyy") : tbEjerc.Text;
                tbMesIni.Text = string.IsNullOrEmpty(tbMesIni.Text) ? DateTime.Now.ToString("MM") : tbMesIni.Text;
                tbMesFin.Text = string.IsNullOrEmpty(tbMesFin.Text) ? DateTime.Now.ToString("MM") : tbMesFin.Text;
                if (!Page.IsPostBack)
                {
                    nacional = true;
                    DB.Conectar();
                    DB.CrearComando(@"select dirtxt,dirdocs,dirrespaldo from ParametrosSistema");
                    var DR = DB.EjecutarConsulta();
                    if (DR.Read())
                    {
                        txt = DR[0].ToString();
                        pdf = DR[1].ToString();
                        bck = DR[2].ToString();
                    }
                    DB.Desconectar();
                    DB.Conectar();
                    DB.CrearComando(@"DELETE FROM IMPRETTEMP where id_Empleado=@IDUSUARIO");
                    DB.AsignarParametroCadena("@IDUSUARIO", Session["identificador"].ToString());
                    DB.EjecutarConsulta();
                    DB.Desconectar();
                    ddlPaisExt.DataTextField = "Text";
                    ddlPaisExt.DataValueField = "Value";
                    ddlPaisExt.DataSource = listaPaises;
                    ddlPaisExt.DataBind();
                    ddlPaisExt.SelectedIndex = -1;
                    ddlPaisExt.Items.FindByValue("").Selected = true;
                    Wizard1.ActiveStepIndex = 0;
                }
                else
                {
                    Page.DataBind();
                }
            }
        }

        private void Nacionalidad()
        {
            DB.Conectar();
            DB.CrearComando(@"SELECT
                                CASE
									WHEN LOWER(PAIEMI) LIKE 'méx%'
	                                    THEN 'Nacional'
                                    WHEN LOWER(PAIEMI) LIKE 'mex%'
	                                    THEN 'Nacional'
									WHEN LOWER(PAIEMI) = 'mx'
	                                    THEN 'Nacional'
                                    ELSE
	                                    'Extranjero'
                                END AS 'Nacionalidad'
                            FROM
                                EMISOR
                            WHERE
                                RFCEMI = @RFC");
            DB.AsignarParametroCadena("@RFC", tbRfcRec.Text);
            var DR1 = DB.EjecutarConsulta();
            if (DR1.HasRows)
            {
                DR1.Read();
                rbNacional.Enabled = false;
                rbExtranjero.Enabled = false;
                nacional = DR1["Nacionalidad"].ToString().Equals("Nacional", StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                rbNacional.Enabled = true;
                rbExtranjero.Enabled = true;
            }
            HabilitaNacionalidad(nacional);
            DB.Desconectar();
        }

        private void HabilitaNacionalidad(bool esNacional)
        {
            try
            {
                rbNacional.Checked = esNacional;
                rbExtranjero.Checked = !esNacional;
                tdIdFiscal.Visible = !esNacional;
                tbIdFiscal.Text = !esNacional ? tbIdFiscal.Text : "XEXX010101000";
                RegularExpressionValidator3.Enabled = esNacional;
                tbRfcRec.Text = (esNacional ? tbRfcRec.Text : "");
                tbRfcRec.ReadOnly = !esNacional;
                tbDomRec.Text = esNacional ? tbDomRec.Text : "";
                tbNumExtRec.Text = esNacional ? tbNumExtRec.Text : "";
                tbNumIntRec.Text = esNacional ? tbNumIntRec.Text : "";
                tbColRec.Text = esNacional ? tbColRec.Text : "";
                tbMunRec.Text = esNacional ? tbMunRec.Text : "";
                tbCpRec.Text = esNacional ? tbCpRec.Text : "";
                tbEstRec.Text = esNacional ? tbEstRec.Text : "";
                tbPaiRec.Text = esNacional ? tbPaiRec.Text : "";
                tbEmail.Text = esNacional ? tbEmail.Text : "";
                tbNacionalidad.Text = esNacional ? "Nacional" : "Extranjero";

                //chkBeneficiario.Enabled = !esNacional;
                //chkNoBeneficiario.Enabled = !esNacional;




            }
            catch
            {
                // ignored 
            }
        }

        protected void FinishButton_Click(object sender, EventArgs e)
        {
            //protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
            //       var ambiente = ConfigurationManager.AppSettings.Get("ambiente");
            var dFecha = Convert.ToDateTime(lFecha.Text);
            var mesI = tbMesIni.Text;
            var mesF = tbMesFin.Text;
            var anio = tbEjerc.Text;
            var sFecha = dFecha.ToString("yyyy-MM-ddTHH:mm:sszzz");
            var TXT = "";
            var desc = "";
            if (chkPagos.Checked)
            {
                desc = "18|Pagos realizados a favor de residentes en el extranjero.|";
            }
            else if (chkDividendos.Checked)
            {
                desc = "14|Dividendos o utilidades distribuidas.|";
            }
            else
            {
                desc = "04|Servicios prestados por comisionistas|";
            }
            TXT = "Retenciones|||" + sFecha + "|" + desc;
            TXT += Environment.NewLine + "Emisor||" + tbRfcEmi.Text + "|" + tbNomEmi.Text + "|" + tbCURPE.Text + "|";
            var recep = (!nacional)
                ? "|||EXT|" + tbIdFiscal.Text + "|" + tbNomRec.Text
                : tbRfcRec.Text + "|" + tbNomRec.Text + "|" + tbCURPR.Text + "|||";
            TXT += Environment.NewLine + "Receptor||" + (nacional ? "Nacional" : "Extranjero") + "|" + recep + "|";
            TXT += Environment.NewLine + "Periodo||" + mesI + "|" + mesF + "|" + anio + "|";
            TXT += Environment.NewLine + "Totales||" + tbmontoTotOperacion.Text + "|" + tbmontoTotGrav.Text + "|" + tbmontoTotExent.Text + "|" + tbmontoTotRet.Text + "|";
            foreach (var impuesto in GetImpuestos())
            {
                TXT += Environment.NewLine + impuesto;
            }
            if (chkPagos.Checked)
            {
                TXT += Environment.NewLine + "Complemento|Pagosaextranjeros||" + ((chkBeneficiario.Checked) ? "SI" : "NO") + "|";
                if (chkNoBeneficiario.Checked)
                {
                    TXT += Environment.NewLine + "Complemento|Pagosaextranjeros|NoBeneficiario||" + ddlPaisExt.SelectedValue + "|" + tbConceptoPagoNB.SelectedItem.Value + "|" + tbDescConceptoNB.Text + "|";
                }
                if (chkBeneficiario.Checked)
                {
                    TXT += Environment.NewLine + "Complemento|Pagosaextranjeros|Beneficiario||" + tbRFCNB.Text + "|" + tbCURPNB.Text + "|" + tbRazonNB.Text + "|" + tbConceptoPagoB.SelectedItem.Value + "|" + tbDescConceptoB.Text + "|";
                }
            }
            else if (chkDividendos.Checked)
            {
                TXT += Environment.NewLine + "Complemento|Dividendos||";
                if (chkDividOutil.Checked)
                {
                    TXT += Environment.NewLine + "Complemento|Dividendos|DividOUtil||" + ddlTipoDivOUtil.SelectedValue + "|" + tbMontISRAcredRetMexico.Text + "|" + tbMontISRAcredRetExtranjero.Text + "|" + tbMontRetExtDivExt.Text + "|" + ddlTipoSocDistrDiv.SelectedValue + "|" + tbMontISRAcredNal.Text + "|" + tbMontDivAcumNal.Text + "|" + tbMontDivAcumExt.Text + "|";
                }
                if (chkRemanente.Checked)
                {
                    TXT += Environment.NewLine + "Complemento|Dividendos|Remanente||" + tbProporcionRem.Text + "|";
                }
            }
            var ObjMyService = new wsRetenciones.Retenciones();
            ObjMyService.Timeout = Timeout.Infinite;
            var correo = Session["correo"] != null ? Session["correo"].ToString() : "";
            var result = ObjMyService.procesarRetencionTXT(TXT, correo);
            mpeProcesando.Hide();
            if (result != null)
            {
                Response.Redirect("~/menuReceDHL/ComprobantesFiscales.aspx", true);
            }
            else
            {
                pnlAviso.Style["height"] = "200px";
                var titulo = "<center><strong>No se pudo procesar la retención</strong></center>";
                var msg = ("<center>" + ObjMyService.obtenerMensajeError() + "</center>");
                lblMsgAviso.Text = (titulo + "<br>" + msg);
                SqlDataSource1.DataBind();
                mpeAviso.Show();
            }
        }

        private IEnumerable<string> GetImpuestos()
        {
            var impuestos = new List<string>();
            DB.Conectar();
            DB.CrearComando(@"SELECT BaseRet, impuesto, montoRet, tipopago FROM ImpRetTemp WHERE id_Empleado=@idUser");
            DB.AsignarParametroCadena("@idUser", Session["identificador"].ToString());
            var DR = DB.EjecutarConsulta();
            while (DR.Read())
            {
                impuestos.Add("ImpRetenidos||" + DR["BaseRet"] + "|" + DR["impuesto"] + "|" + DR["montoRet"] + "|" +
                        DR["tipopago"] + "|");
            }
            DB.Desconectar();
            return impuestos;
        }

        private void llenarlista(string tipo, string rfc = null, string nom = null)
        {
            var sql = "";
            var hayRegistros = false;
            if (tipo == "emi")
            {
                if (!string.IsNullOrEmpty(rfc) && !string.IsNullOrEmpty(nom))
                {
                    sql = @"SELECT * FROM RECEPTOR WHERE RFCREC=@rfc AND NOMREC=@razon";
                }
                else
                {
                    sql = !string.IsNullOrEmpty(rfc) ? "SELECT * FROM RECEPTOR WHERE RFCREC=@rfc" : (!string.IsNullOrEmpty(nom) ? "SELECT * FROM RECEPTOR WHERE NOMREC=@razon" : "");
                }
            }
            else if (tipo == "rec")
            {
                if (!string.IsNullOrEmpty(rfc) && !string.IsNullOrEmpty(nom))
                {
                    sql = @"SELECT * FROM EMISOR WHERE RFCEMI=@rfc AND NOMEMI=@razon";
                }
                else
                {
                    sql = !string.IsNullOrEmpty(rfc) ? "SELECT * FROM EMISOR WHERE RFCEMI=@rfc" : (!string.IsNullOrEmpty(nom) ? "SELECT * FROM EMISOR WHERE NOMEMI=@razon" : "");
                }
            }
            if (string.IsNullOrEmpty(sql) || (string.IsNullOrEmpty(rfc) && string.IsNullOrEmpty(nom)))
            {
                return;
            }
            DB.Conectar();
            DB.CrearComando(sql);
            if (!string.IsNullOrEmpty(nom))
            {
                DB.AsignarParametroCadena("@razon", nom);
            }
            if (!string.IsNullOrEmpty(rfc))
            {
                DB.AsignarParametroCadena("@rfc", rfc);
            }
            var drSum = DB.EjecutarConsulta();
            hayRegistros = drSum.HasRows;
            if (hayRegistros)
            {
                drSum.Read();
                switch (tipo)
                {
                    case "emi":
                        tbRfcEmi.Text = drSum["RFCREC"].ToString();
                        tbNomEmi.Text = drSum["NOMREC"].ToString();
                        tbDomEmi.Text = drSum["CALLEREC"].ToString();
                        tbNumExterior.Text = drSum["NUMEXTREC"].ToString();
                        tbNumInterior.Text = drSum["NUMINTREC"].ToString();
                        tbColEmi.Text = drSum["COLREC"].ToString();
                        tbMunEmi.Text = drSum["MUNREC"].ToString();
                        tbEstEmi.Text = drSum["EDOREC"].ToString();
                        tbPaiEmi.Text = drSum["PAIREC"].ToString();
                        tbCpEmi.Text = drSum["CODREC"].ToString();
                        tbSerie.Text = "";
                        tbCURPE.Text = "";//drSum["CURPR"].ToString();
                        break;
                    case "rec":
                        tbRfcRec.Text = drSum["RFCEMI"].ToString();
                        tbNomRec.Text = drSum["NOMEMI"].ToString();
                        tbDomRec.Text = drSum["CALLEEMI"].ToString();
                        tbNumExtRec.Text = drSum["NUMEXTEMI"].ToString();
                        tbNumIntRec.Text = drSum["NUMINTEMI"].ToString();
                        tbColRec.Text = drSum["COLEMI"].ToString();
                        tbMunRec.Text = drSum["MUNEMI"].ToString();
                        tbEstRec.Text = drSum["EDOEMI"].ToString();
                        tbPaiRec.Text = drSum["PAIEMI"].ToString();
                        tbCpRec.Text = drSum["CODEMI"].ToString();
                        tbCURPR.Text = "";
                        tbIdFiscal.Text = "";
                        break;
                }
            }
            else
            {
                switch (tipo)
                {
                    case "emi":
                        tbNomEmi.Text = "";
                        tbDomEmi.Text = "";
                        tbNumExterior.Text = "";
                        tbNumInterior.Text = "";
                        tbColEmi.Text = "";
                        tbMunEmi.Text = "";
                        tbEstEmi.Text = "";
                        tbPaiEmi.Text = "";
                        tbCpEmi.Text = "";
                        tbSerie.Text = "";
                        break;
                    case "rec":
                        tbNomRec.Text = "";
                        tbDomRec.Text = "";
                        tbNumExtRec.Text = "";
                        tbNumIntRec.Text = "";
                        tbColRec.Text = "";
                        tbMunRec.Text = "";
                        tbEstRec.Text = "";
                        tbPaiRec.Text = "";
                        tbCpRec.Text = "";
                        tbIdFiscal.Text = "";
                        break;
                }
            }
            switch (tipo)
            {
                case "emi":
                    tbNomEmi.ReadOnly = hayRegistros;
                    tbDomEmi.ReadOnly = hayRegistros;
                    tbNumExterior.ReadOnly = hayRegistros;
                    tbNumInterior.ReadOnly = hayRegistros;
                    tbColEmi.ReadOnly = hayRegistros;
                    tbMunEmi.ReadOnly = hayRegistros;
                    tbEstEmi.ReadOnly = hayRegistros;
                    tbPaiEmi.ReadOnly = hayRegistros;
                    tbCpEmi.ReadOnly = hayRegistros;
                    tbSerie.ReadOnly = hayRegistros;
                    break;
                case "rec":
                    tbNomRec.ReadOnly = hayRegistros;
                    tbDomRec.ReadOnly = hayRegistros;
                    tbNumExtRec.ReadOnly = hayRegistros;
                    tbNumIntRec.ReadOnly = hayRegistros;
                    tbColRec.ReadOnly = hayRegistros;
                    tbMunRec.ReadOnly = hayRegistros;
                    tbEstRec.ReadOnly = hayRegistros;
                    tbPaiRec.ReadOnly = hayRegistros;
                    tbCpRec.ReadOnly = hayRegistros;
                    //tbIdFiscal.ReadOnly = hayRegistros;
                    break;
            }
            DB.Desconectar();
            if (tipo.Equals("rec"))
            {
                Nacionalidad();
            }
        }

        protected void bLlenarRec_Click(object sender, EventArgs e)
        {
            llenarlista("rec", tbRfcRec.Text, tbNomRec.Text);
            Session["tbRfcRectemp"] = tbRfcRec.Text;
            Session["tbNomRectemp"] = tbNomRec.Text;
            Session["tbDomRectemp"] = tbDomRec.Text;
            Session["tbColRectemp"] = tbColRec.Text;
            Session["tbMunRectemp"] = tbMunRec.Text;
            Session["tbCpRectemp"] = tbCpRec.Text;
            Session["tbEstRectemp"] = tbEstRec.Text;
            Session["tbPaiRectemp"] = tbPaiRec.Text;
            Session["tbLocRectemp"] = tbLocRec.Text;
            Session["tbIdFiscaltemp"] = tbIdFiscal.Text;
        }

        protected void bActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/nuevo/retencionManual.aspx");
        }

        private void agregarImpuesto()
        {
            LMensajeErrorAgregar.Text = "";
            try
            {
                var baseRet = tbBaseRet.Text;
                var montoRet = Math.Round((!string.IsNullOrEmpty(tbmontoRet.Text) ? Convert.ToDecimal(tbmontoRet.Text) : 0), 2);
                if (montoRet >= 0)
                {
                    DB.Conectar();
                    DB.CrearComando(
                        @"INSERT INTO ImpRetTemp
                            (" + (!string.IsNullOrEmpty(baseRet.ToString()) ? "BaseRet," : "") + @"Impuesto, MontoRet, TipoPago, id_Empleado)
                        VALUES
                            (" + (!string.IsNullOrEmpty(baseRet.ToString()) ? "@baseRet," : "") + @"@impuesto,@montoRet,@tipoPago,@id_Empleado)");
                    if (!string.IsNullOrEmpty(baseRet.ToString()))
                    {
                        DB.AsignarParametroCadena("@baseRet", baseRet.ToString());
                    }
                    DB.AsignarParametroCadena("@impuesto", ddlTipoImpuesto.SelectedValue);
                    DB.AsignarParametroCadena("@montoRet", montoRet.ToString());
                    DB.AsignarParametroCadena("@tipoPago", ddlTipoPago.SelectedItem.Text);
                    DB.AsignarParametroCadena("@id_Empleado", Session["identificador"].ToString());
                    DB.EjecutarConsulta1();
                    DB.Desconectar();

                    SqlDataSource1.SelectParameters["id_Empleado"].DefaultValue = Session["identificador"].ToString();
                    SqlDataSource1.DataBind();
                    gvImpuestosTemp.DataBind();

                    var a = 0;
                    while (a < 10000)
                    {
                        a++;
                    }
                    tbmontoRet.Text = @"0.00";
                }
                else
                {
                    throw new Exception("El Importe del Impuesto no puede quedar en 0");
                }
            }
            catch (Exception ea)
            {
                LMensajeErrorAgregar.Text = @"Error: " + ea.Message;
            }
        }

        protected void tbAgregar_Click(object sender, EventArgs e)
        {
            agregarImpuesto();
        }

        protected void tbRfcRec_TextChanged(object sender, EventArgs e)
        {
            llenarlista("rec", tbRfcRec.Text);
        }

        private bool BuscarRfc(string rfc)
        {
            DB.Conectar();
            //DB.CrearComando("SELECT idreceptorCFDI FROM receptorCFDI WHERE rfc=@rfc");
            DB.CrearComando("SELECT IDEREC FROM RECEPTOR WHERE RFCREC=@rfc");
            DB.AsignarParametroCadena("@rfc", rfc);
            var DR = DB.EjecutarConsulta();

            while (DR.Read())
            {
                DB.Desconectar();
                return true;
            }
            DB.Desconectar();
            return false;
        }

        protected void ddlEmisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmisor.SelectedValue != "0")
            {
                llenarlista("emi", ddlEmisor.SelectedValue);
            }
        }

        protected void gvImpuestosTemp_DataBound(object sender, EventArgs e)
        {
            //LMensajeErrorAgregar.Text = "";
            //var montoTotGrav = Convert.ToDecimal(cerosNull(tbmontoTotGrav.Text));
            //DB.Conectar();
            //DB.CrearComando(
            //    @"SELECT ISNULL(SUM(MontoRet), 0) AS SUM FROM ImpRetTemp WHERE (id_Empleado = @id_Empleado)");
            //DB.AsignarParametroCadena("@id_Empleado", Session["identificador"].ToString());
            //DbDataReader DR = DB.EjecutarConsulta();
            //DR.Read();
            //var totImpRetenidos = Convert.ToDecimal(cerosNull(DR["SUM"].ToString()));
            //DB.Desconectar();
            //tbmontoTotRet.Text = Math.Round(totImpRetenidos, 2).ToString(CultureInfo.InvariantCulture);
            //tbmontoTotOperacion.Text = Math.Round((montoTotGrav + totImpRetenidos), 2).ToString(CultureInfo.InvariantCulture);
        }

        protected void tbmontoTotGrav_TextChanged(object sender, EventArgs e)
        {
            //var montoTotGrav = Convert.ToDecimal(tbmontoTotGrav.Text);
            //var totImpRetenidos = Convert.ToDecimal(tbmontoTotRet.Text);
            //tbmontoTotOperacion.Text = Math.Round((montoTotGrav + totImpRetenidos), 2).ToString(CultureInfo.InvariantCulture);
        }

        private string DateAsStringName(string date)
        {
            return Convert.ToDateTime(date).ToString("yyyy-MM-dd_hh-mm-ss-tt");
        }

        private String cerosNull(string a)
        {
            if (a == "")
                return "0.00";

            if (a == null)
                return "0.00";

            if (a == "0")
                return "0.00";

            if (a == "0.00")
                return "0.00";
            else
                return a;
        }

        protected void chkNoBeneficiario_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void tbRfcEmi_TextChanged(object sender, EventArgs e)
        {
            llenarlista("emi", tbRfcEmi.Text);
        }

        protected void rbNacional_CheckedChanged(object sender, EventArgs e)
        {
            nacional = true;
            HabilitaNacionalidad(nacional);
        }

        protected void rbExtranjero_CheckedChanged(object sender, EventArgs e)
        {
            nacional = false;
            HabilitaNacionalidad(nacional);
        }

        protected void tbNomEmi_TextChanged(object sender, EventArgs e)
        {
            llenarlista("emi", null, tbNomEmi.Text);
        }

        protected void chkDividOutil_CheckedChanged(object sender, EventArgs e)
        {
            ddlTipoDivOUtil.Enabled = chkDividOutil.Checked;
            tbMontISRAcredRetMexico.ReadOnly = !chkDividOutil.Checked;
            tbMontISRAcredRetExtranjero.ReadOnly = !chkDividOutil.Checked;
            tbMontRetExtDivExt.ReadOnly = !chkDividOutil.Checked;
            ddlTipoSocDistrDiv.Enabled = chkDividOutil.Checked;
            tbMontISRAcredNal.ReadOnly = !chkDividOutil.Checked;
            tbMontDivAcumNal.ReadOnly = !chkDividOutil.Checked;
            tbMontDivAcumExt.ReadOnly = !chkDividOutil.Checked;
            tbMontISRAcredRetMexico.Text = "0.00";
            tbMontISRAcredRetExtranjero.Text = "0.00";
            tbMontRetExtDivExt.Text = "";
            tbMontISRAcredNal.Text = "";
            tbMontDivAcumNal.Text = "";
            tbMontDivAcumExt.Text = "";
            RequiredFieldValidator3.Enabled = chkDividOutil.Checked;
            RegularExpressionValidator1.Enabled = chkDividOutil.Checked;
            RequiredFieldValidator4.Enabled = chkDividOutil.Checked;
            RegularExpressionValidator2.Enabled = chkDividOutil.Checked;
            RegularExpressionValidator4.Enabled = chkDividOutil.Checked;
            RegularExpressionValidator5.Enabled = chkDividOutil.Checked;
            RegularExpressionValidator6.Enabled = chkDividOutil.Checked;
            RegularExpressionValidator7.Enabled = chkDividOutil.Checked;
        }

        protected void chkRemanente_CheckedChanged(object sender, EventArgs e)
        {
            tbProporcionRem.ReadOnly = !chkRemanente.Checked;
            tbProporcionRem.Text = "";
            RegularExpressionValidator15.Enabled = chkRemanente.Checked;
        }

        protected void chkBeneficiario_CheckedChanged(object sender, EventArgs e)
        {
            tbConceptoPagoB.Enabled = chkBeneficiario.Checked;
            tbRFCNB.ReadOnly = !chkBeneficiario.Checked;
            tbRazonNB.ReadOnly = !chkBeneficiario.Checked;
            tbCURPNB.ReadOnly = !chkBeneficiario.Checked;
            tbDescConceptoB.ReadOnly = !chkBeneficiario.Checked;
            tbRFCNB.Text = "";
            tbRazonNB.Text = "";
            tbCURPNB.Text = "";
            tbDescConceptoB.Text = "";
        }

        protected void chkNoBeneficiario_CheckedChanged1(object sender, EventArgs e)
        {
            ddlPaisExt.Enabled = chkNoBeneficiario.Checked;//Enabled;
            RequiredFieldValidator113.Enabled = ddlPaisExt.Enabled;
            tbConceptoPagoNB.Enabled = chkNoBeneficiario.Checked;
            RequiredFieldValidator111.Enabled = chkNoBeneficiario.Checked;
            tbDescConceptoNB.ReadOnly = !chkNoBeneficiario.Checked;
            tbDescConceptoNB.Text = "";
        }

        protected void chkPagos_CheckedChanged(object sender, EventArgs e)
        {
            chkBeneficiario.Checked = false;
            chkNoBeneficiario.Checked = false;
            chkBeneficiario.Enabled = chkPagos.Checked;
            chkNoBeneficiario.Enabled = chkPagos.Checked;
            chkNoBeneficiario_CheckedChanged1(null, null);
            chkBeneficiario_CheckedChanged(null, null);
        }

        protected void chkDividendos_CheckedChanged(object sender, EventArgs e)
        {
            chkPagos.Checked = false;
            chkPagos.Enabled = !chkDividendos.Checked;
            chkPagos_CheckedChanged(null, null);
            chkDividOutil.Checked = false;
            chkRemanente.Checked = false;
            chkDividOutil.Enabled = chkDividendos.Checked;
            chkRemanente.Enabled = chkDividendos.Checked;
            chkDividOutil_CheckedChanged(null, null);
            chkRemanente_CheckedChanged(null, null);
        }
    }
}