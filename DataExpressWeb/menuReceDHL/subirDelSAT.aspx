<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="subirDelSAT.aspx.cs" Inherits="DataExpressWeb.menuReceDHL.subirDelSAT" Culture="Auto" UICulture="Auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Src="~/UserControl/filesUpload.ascx" TagName="filesUpload" TagPrefix="control" %>
<%@ Register Src="~/UserControl/MultiFileUpload.ascx" TagName="multiFileUpload" TagPrefix="control2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/StylesEx.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .form-control-det {
            display: block;
            width: 350px;
            height: 200px;
            padding: 6px 12px;
            font-size: 12px;
            line-height: 1.428571429;
            align-content: center;
            color: #555555;
            vertical-align: middle;
            background-color: #F2EFEF;
            border: 1px solid #d40511;
            border-radius: 4px;
            font-family: Arial;
            outline: 0;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(102, 175, 233, 0.6);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(102, 175, 233, 0.6);
            -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
            transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
        }
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            overflow:auto;
        }
        .modalPopup
        {
             display: block;
  width: auto;
  height: auto;
  padding: 6px 12px;
  font-size: 14px;
  line-height: 1.428571429;
  color: #000;
  vertical-align: middle;
  border:solid;
  background-color:white;
  border: 1px solid #66afe9;
  border-radius: 4px;
  outline: 0;
  -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(102, 175, 233, 0.6);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgba(102, 175, 233, 0.6);
  -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
          transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
        }
        .panelBodyWrapper {
            border: 1px ridge #666666;
        }

        .panelHeader {
            background-color: #d40511;
            border: 1px groove black;
            font-family: Arial;
            font-weight: bold;
            font-size: 14px;
            color: #fff;
            height: 20px;
            width: auto;
        }

        .panelWrapper {
            background-color: #e8e8e4;
            border-style: solid;
            border-color: #d40511;
            border-width: 1px;
        }

        #bus {
            position: absolute;
            left: 780px;
            top: 152px;
            z-index: 1;
            height: 67px;
            width: 112px;
        }

        #bus2 {
            position: absolute;
            left: 750px;
            top: 162px;
            z-index: 1;
            height: 71px;
            width: 141px;
        }

        #bus3 {
            position: absolute;
            left: 1022px;
            top: 175px;
            z-index: 1;
            height: 63px;
            width: 103px;
        }

        #bus4 {
            position: absolute;
            left: 770px;
            top: 149px;
            z-index: 1;
            height: 84px;
            width: 122px;
        }

        #bus5 {
            position: absolute;
            left: 770px;
            top: 149px;
            z-index: 1;
            height: 84px;
            width: 122px;
        }

        #bus6 {
            position: absolute;
            left: 770px;
            top: 149px;
            z-index: 1;
            height: 84px;
            width: 122px;
        }

        #bus7 {
            position: absolute;
            left: 770px;
            top: 149px;
            z-index: 1;
            height: 84px;
            width: 122px;
        }

        #bus12 {
            position: absolute;
            left: 770px;
            top: 149px;
            z-index: 1;
            height: 84px;
            width: 122px;
        }

        #navigation {
            text-decoration: none;
        }

        .sideMenuComprobantesFiscales:hover {
            text-decoration: underline;
            color: #C90101;
        }

        ul#navigation {
            padding: 0 0 1em 1.75em;
            list-style-image: url(../imagenes/arrow.png);
            list-style-position: inside;
        }

        .titulo {
            padding: 0 0 1em 1.75em;
            list-style-position: inside;
            font: normal bold 12px Arial;
        }



        h1 {
            background-color: #C90101;
            color: #fff;
            font: normal bold 20px arial;
        }

        .contenedor {
            overflow: auto;
            direction: rtl;
        }

        .tablaFac {
            direction: ltr;
        }

        .botonForm {
            background-color: #d40511;
            border-bottom-style: ridge;
            font-weight: normal;
            font-size: 11px;
            color: #ffffff;
            width: 87px;
            border-left-color: #e4b918;
            border-right-color: #e4b918;
            border-top-color: #e4b918;
            border-bottom-color: #e4b918;
        }

            .botonForm:hover {
                color: #ffcc00;
            }

        .watermarked {
            height: 20px;
            width: 150px;
            padding: 2px 0 0 2px;
            border: 1px solid #BEBEBE;
            color: gray;
            text-align: center;
        }

        .ajax__calendar_header {
            background-color: #8A0808;
            color: snow;
            text-transform: uppercase;
        }

        .ajax__calendar_body {
            background-color: #F2F5A9;
            text-align: center;
        }

        .ajax__calendar_prev {
            background-color: white;
        }

        .ajax__calendar_next {
            background-color: white;
        }
    </style>

    <script type="text/javascript">
        function Success() {
            document.getElementById("lblMessage").innerHTML = "Archivos Subidos";
            //alert("subido Correctamente");
        }

        function Error() {
            document.getElementById("lblMessage").innerHTML = "Upload failed.";
            //alert("subido Correctamente");
        }
        function Completo(sender, args) {
            //alert("Felicidades el archivo se subio muy bien");
            var filename = args.get_fileName();
            var contentType = args.get_contentType();
            var text = "Tamaño de " + filename + " es " + args.get_length + " bytes";
            if (contentType.length > 0) {
                text += " y el tipo de contenido es '" + contentType + "'.";
            }

            alert(text);
        }

        function Error(sender, args) {
            //alert("Lo sentimos ha ocurrido un error");
            alert(args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>");

        }

        function InicioCarga(sender, args) {
            //alert("inicio carga");
            alert("Inicio de carga");
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <h1 style="width: 520px; text-align:center" >Comprobantes Fiscales Digitales</h1>--%>

			<table style="width: 75%; height: 102px">
			        <tr>
					   <td>
                            <span style="position: absolute;left: 22%;top: 20%; z-index: 1;">   		
				<center style="height: 150px;">
				<asp:Panel ID="tipoProcesar" CssClass="panelWrapper" runat="server" BorderStyle="Groove" Height="470px" Visible="true" 
											Width="720px" HorizontalAlign="Center">
					<asp:Panel ID="Panel45" CssClass="panelHeader" runat="server" BackColor="#d40511" BorderColor="Black" 
						Font-Bold="True" ForeColor="White" BorderStyle="Groove" HorizontalAlign="Center" Font-Size="Medium">
						CFDI descargados del portal del SAT</asp:Panel>
											<asp:Panel ID="Panel46" runat="server" BorderColor="#666666" BorderStyle="Solid" 
												Height="340px" Width="710px" BorderWidth="1px" ScrollBars="Vertical">
												<table style="width: 680px; height: 290px;">    
                                                            <%--<caption>--%>
<%--                                                                <br />
                                                                <tr>
                                                                    <td style="font-variant:small-caps; font-size:medium;" colspan="3">Elegir opcion para subir CFDI: </td>
                                                                    <td></td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td align="left" colspan="4">
                                                                        &nbsp;&nbsp;<asp:RadioButton ID="cfdiSAT_ser" runat="server" AutoPostBack="true" Checked="True" GroupName="tipoRecep" OnCheckedChanged="cfdiSAT_ser_CheckedChanged" Text="CFDI descargados del portal" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:100px;">
                                                                    </td>
                                                                    <td align="left">Receptor:</td>
                                                                    <td colspan="2" align="left">
                                                                        <asp:DropDownList ID="rfc" runat="server" Font-Size="Smaller" Width="330px">
                                                                            <asp:ListItem Value="DML7905239C3">DHL METROPOLITAN LOGISTICS SC MEXICO SA DE CV</asp:ListItem>
                                                                            <asp:ListItem Value="ESC920529NP4">DHL SUPPLY CHAIN AUTOMOTIVE MEXICO SA DE CV</asp:ListItem>
                                                                            <asp:ListItem Value="HIN920529D22">HYPERION INMOBILIARIA SA DE CV</asp:ListItem>
                                                                            <asp:ListItem Value="ESE970808GW2">DHL CORPORATE SERVICES SC MEXICO SA DE CV</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td> </td>
                                                                    <td align="left">RFC del Emisor:</td>
                                                                    <td colspan="2" align="left">
                                                                        <asp:TextBox ID="tbRFC" MaxLength="13" Width="150px" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td align="left">Nombre del Emisor:</td>
                                                                    <td colspan="2" align="left">
                                                                        <asp:TextBox ID="tbNom" runat="server" Width="330px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td align="left" valign="top">
                                                                       Intervalo de Fechas:
                                                                    </td>
                                                                    <td valign="baseline" align="left">
                                                                            <asp:TextBox ID="tbFechaIni"  runat="server" Width="120px" Height="20px" Font-Size="Small" Visible="True"></asp:TextBox>
                                                                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="tbFechaIni" Animated="true" Format="yyyy/MM/dd" TodaysDateFormat="d/MMMM/yyyy">
                                                                            </ajaxtoolkit:CalendarExtender>
                                                                            <ajaxtoolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="tbFechaIni" WatermarkText="Fecha Inicial" WatermarkCssClass="watermarked"  >
                                                                            </ajaxtoolkit:TextBoxWatermarkExtender>
                                                                            <br />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                                                            runat="server" ControlToValidate="tbFechaIni" 
                                                                            ErrorMessage="Formato yyyy/mm/dd" ForeColor="OrangeRed" Font-Size="XX-Small" 
                                                                            ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"></asp:RegularExpressionValidator>
                                                                      </td> 
                                                                    <td valign="baseline"  align="left">
                                                                            <asp:TextBox ID="tbFechaFin" runat="server" Width="120px" Height="20px" Font-Size="Small" Visible="True"></asp:TextBox>
                                                                          <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbFechaFin" Animated="true" Format="yyyy/MM/dd" TodaysDateFormat="d/MMMM/yyyy">
                                                                            </ajaxtoolkit:CalendarExtender>
                                                                            <ajaxtoolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="tbFechaFin" WatermarkText="Fecha Final" WatermarkCssClass="watermarked" >
                                                                            </ajaxtoolkit:TextBoxWatermarkExtender>
                                                                            <br />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                                            runat="server" ControlToValidate="tbFechaFin"
                                                                            ErrorMessage="Formato yyyy/mm/dd" ForeColor="OrangeRed" Font-Size="XX-Small" 
                                                                            ValidationExpression="(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"></asp:RegularExpressionValidator>
                                                         
                                                                      </td>                                                   
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" colspan="4">
                                                                        <br />
                                                                        &nbsp;&nbsp;<asp:RadioButton ID="cfdiSAT_cli" runat="server" AutoPostBack="true" GroupName="tipoRecep" OnCheckedChanged="cfdiSAT_cli_CheckedChanged" Text="CFDI del cliente" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="4">
                                                                        <control2:multiFileUpload ID="MultipleFileUpload1" runat="server" OnClick="MultipleFileUpload1_Click" Rows="20" UpperLimit="19" Visible="false" />
                                                                     <asp:Label ID="countArch" runat="server" Text="0" Visible="false"></asp:Label>
                                                                        <%--<control:filesUpload ID="MultipleFileUpload1" OnClick="MultipleFileUpload1_Click" runat="server" UpperLimit="15" Rows="20" Visible="false"  />--%>
                                                                        <%--                                    <ajaxtoolkit:AjaxFileUpload ID="AjaxFuArchivos" runat="server" OnUploadComplete="AjaxFileUpload1_UploadComplete" AllowedFileTypes="xml"
                                                                OnClientUploadComplete="Success"  OnClientUploadError="Error"
                                                                Width="400px" MaximumNumberOfFiles="200"  
                                                                EnableViewState="False" UploadingBackColor="#66CCFF" CompleteBackColor="Lime" UploaderStyle="Modern" 
                                                                ErrorBackColor="Red" ForeColor="Black"/>                                                            
                                                            <br />
                                                            <asp:Label ID="lblMessage" runat="server"/> --%>
                                                                        <%--                                                                    <ajaxtoolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" 
                                                                        AllowedFileTypes="jpg,jpeg,gif,png" onclientuploadcomplete="Completo" 
                                                                        onclientuploaderror="Error" OnClientUploadStarted="InicioCarga" 
                                                                        onuploadcomplete="AjaxFileUpload1_UploadComplete" MaximumNumberOfFiles="5" 
                                                                         EnableViewState="False" UploadingBackColor="#66CCFF" CompleteBackColor="Lime" UploaderStyle="Modern" 
                                                                          ErrorBackColor="Red" ThrobberID="Throbber" />

                                                                        <asp:Label ID="Throbber" runat="server" Style="display: none">
                                                                      <img src="~/Imagenes-dhl/barritas.gif" alt="loading" />
                                                                        </asp:Label>--%></td>
                                                                </tr>                                            
                                                            <%--</caption>--%>
												</table>
											</asp:Panel>
                                            <br />
                                            <asp:Label ID="mensaje" runat="server" ForeColor="DarkRed" Text=""></asp:Label>
											<br />
											<asp:Button ID="Button49" runat="server" BackColor="#d40511" 
												BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
												Text="Aceptar" Width="87px" ForeColor="White" onclick="Button49_Click" />
											&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button ID="Button12" runat="server" BackColor="#d40511" 
												BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
												Text="Cancelar" Width="87px" onclick="Button12_Click" ForeColor="White" />
										
										</asp:Panel>						
			    </center>
							</span>
                           <span style="position: absolute;left:5%;top: 20%; z-index: 1; width:90%;">
                           <asp:Panel ID="facturas" runat="server" Visible="false" HorizontalAlign="Center">
                                   <asp:Panel ID="Panel1" CssClass="panelHeader" runat="server" BackColor="#d40511" BorderColor="Black" 
						Font-Bold="True" ForeColor="White" BorderStyle="Groove" HorizontalAlign="Center">CFDI A PROCESAR</asp:Panel>

                                           <asp:Panel ID="panelGrid" runat="server" Height="400px" ScrollBars="Both" >
                                            <asp:GridView ID="gvFacturasP" class="tablaFac" runat="server" 
                                    DataSourceID="SqlDataSource1" AutoGenerateColumns="False"  
                                    CellPadding="1" DataKeyNames="idFac" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
         ForeColor="#333333" GridLines="None"  style="margin-top: 0px;" BorderColor="#CC0000" 
        BorderStyle="Solid" Font-Size="10px" Font-Bold="True" CellSpacing="1" AllowPaging="True" HorizontalAlign="Center" AllowSorting="True" OnSelectedIndexChanged="gvFacturasP_SelectedIndexChanged" > <%--OnPageIndexChanging="gvFacturas_PageIndexChanging1"--%>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>                                
    <Columns >
         <asp:TemplateField SortExpression="Editar" ItemStyle-HorizontalAlign="Center">
             <ItemTemplate>
                <asp:ImageButton runat="server" ID="imgSeleccion" CommandName="Select"
                     ImageUrl="../imagenes/modify.png" height="22" width="22"></asp:ImageButton>
             </ItemTemplate>
         </asp:TemplateField>
         <%--<asp:CommandField ShowEditButton="false"/>--%>
         <asp:TemplateField HeaderText="PROCESAR" ItemStyle-Width="50px" SortExpression="procesar">
                        <EditItemTemplate>
                        <asp:DropDownList ID="procesar" runat="server" DataTextField="procesar" DataValueField="procesar" 
                            SelectedValue='<%# Bind("procesar") %>'>
                            <asp:ListItem Value="NO" Text="NO"></asp:ListItem>
                            <asp:ListItem Value="SI" Text="SI"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label25" runat="server" Text='<%# Bind("procesar") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle Width="50px" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="INTERFAZ" ItemStyle-Width="50px" SortExpression="interfaz">
                        <EditItemTemplate>
                        <asp:DropDownList ID="interfaz" runat="server" DataTextField="interfaz" DataValueField="interfaz" 
                            SelectedValue='<%# Bind("interfaz") %>'>
                            <asp:ListItem Value="NO" Text="NO"></asp:ListItem>
                            <asp:ListItem Value="SI" Text="SI"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label35" runat="server" Text='<%# Bind("interfaz") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle Width="50px" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="FILTRAR" ItemStyle-Width="50px" SortExpression="filtros">
                        <EditItemTemplate>
                        <asp:DropDownList ID="filtros" runat="server" DataTextField="filtros" DataValueField="intfiltroserfaz" 
                            SelectedValue='<%# Bind("filtros") %>'>
                            <asp:ListItem Value="NO" Text="NO"></asp:ListItem>
                            <asp:ListItem Value="SI" Text="SI"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label451" runat="server" Text='<%# Bind("filtros") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TIPO DE PROVEEDOR" SortExpression="nombre" >
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            DataSourceID="SqlDataSource2" DataTextField="nombre" DataValueField="nombre" 
                            SelectedValue='<%# Bind("nombre") %>'>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label55" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                    </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="CENTRO DE COSTOS" SortExpression="centroC">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Width="130px" Text='<%# Bind("centroC") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label461" runat="server" Width="130px" Text='<%# Bind("centroC") %>'></asp:Label>
            </ItemTemplate>            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FECHA" SortExpression="fecha" ItemStyle-Width="130px">
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("fecha") %>' Width="130px"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="130px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OTM" ItemStyle-Width="50px" SortExpression="otm">
                        <EditItemTemplate>
                        <asp:DropDownList ID="otm" runat="server" DataTextField="otm" DataValueField="otm" 
                            SelectedValue='<%# Bind("otm") %>'>
                            <asp:ListItem Value="NO" Text="NO"></asp:ListItem>
                            <asp:ListItem Value="SI" Text="SI"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label45" runat="server" Text='<%# Bind("otm") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="NO. SABANA" SortExpression="noSabana">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox100" runat="server" Width="130px" Text='<%# Bind("noSabana") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label462" runat="server" Width="130px" Text='<%# Bind("noSabana") %>'></asp:Label>
            </ItemTemplate>            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SITE ORIGEN" SortExpression="siteOrigen">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox101" runat="server" Width="100px" Text='<%# Bind("siteOrigen") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label46" runat="server" Width="100px" Text='<%# Bind("siteOrigen") %>'></asp:Label>
            </ItemTemplate>            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MONEDA" ItemStyle-Width="50px" SortExpression="moneda">
                        <EditItemTemplate>
                        <asp:DropDownList ID="moneda" runat="server" DataTextField="moneda" DataValueField="moneda" 
                            SelectedValue='<%# Bind("moneda") %>'>
                            <asp:ListItem Value="MXN" Text="MXN"></asp:ListItem>
                            <asp:ListItem Value="USD" Text="USD"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label75" runat="server" Text='<%# Bind("moneda") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RFC" SortExpression="rfc">
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Width="100px" Text='<%# Bind("rfc") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RAZON SOCIAL" SortExpression="razon" ItemStyle-Width="300px">
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Bind("razon") %>' Width="250px"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="250px"/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FOLIO FISCAL" SortExpression="uuid">
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("uuid") %>' Width="230px"></asp:Label>
            </ItemTemplate>           
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TOTAL" SortExpression="total">
            <ItemTemplate>
                <asp:Label ID="total" runat="server" Text='<%# Bind("total") %>' Width="90px"></asp:Label>
            </ItemTemplate>           
        </asp:TemplateField>
         <asp:TemplateField HeaderText="ESTADO" SortExpression="estado">
            <ItemTemplate>
                <asp:Label ID="Label9" runat="server" Width="200px" Text='<%# Bind("estado") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
        <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            No existen registros.
        </EmptyDataTemplate>
    <FooterStyle BackColor="#d40511" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#C31A1A" Font-Bold="True" ForeColor="White" 
            Font-Size="10px" Wrap="False" BorderColor="White" />
    <PagerStyle BackColor="#d40511" ForeColor="White" 
            HorizontalAlign="Left" Wrap="False" />
        <RowStyle BackColor="#f2f2ed" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#E9E7E2"/>
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT nombre from tipoProveedor">    
    </asp:SqlDataSource>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>" 
        SelectCommand="SELECT * from TempRecepcion"        
        
        UpdateCommand="UPDATE TempRecepcion SET centroC=@centroC,nombre=@nombre, interfaz=@interfaz, procesar=@procesar, filtros=@filtros, otm=@otm, noSabana=@noSabana, siteOrigen=@siteOrigen where idFac=@idFac">
        <UpdateParameters>
            <asp:Parameter Name="centroC" />
            <asp:Parameter Name="nombre" />
            <asp:Parameter Name="interfaz" />
            <asp:Parameter Name="procesar" />
            <asp:Parameter Name="filtros" />
            <asp:Parameter Name="otm" />
            <asp:Parameter Name="noSabana" />
            <asp:Parameter Name="siteOrigen" />
        </UpdateParameters>
    </asp:SqlDataSource>
                                               </asp:Panel>

                               <br />
											<asp:Button ID="bProcesar" runat="server" BackColor="#d40511" 
												BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
												Text="Procesar" Width="87px" ForeColor="White" onclick="bProcesar_Click" />
											&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button ID="bCancelar" runat="server" BackColor="#d40511" 
												BorderColor="#E4B918" BorderStyle="Ridge" Font-Bold="True" Height="23px" 
												Text="Cancelar" Width="87px" onclick="bCancelar_Click" ForeColor="White" />

                               <br />
                               <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Justify">
                                   <asp:Label ID="bandera" runat="server" Text="" Visible="false" ></asp:Label>
                                           <asp:Label ID="ldirDes" runat="server" Text="" Visible="false" ></asp:Label>                                           
                                            <asp:LinkButton ID="lbEliminarP" runat="server" OnClick="lbEliminarP_Click" OnClientClick="if (!confirm('¿Esta seguro que quiere eliminar los archivos?')) return false" Visible="false">Eliminar archivos </asp:LinkButton>
                                             <br />
                                           <asp:LinkButton ID="lbEliminarT" runat="server" OnClick="lbEliminarT_Click" OnClientClick="if (!confirm('¿Esta seguro que quiere eliminar los archivos?')) return false" Visible="false">Eliminar todos los archivos </asp:LinkButton>

                               </asp:Panel>                                           
                               </asp:Panel>
                           </span>			
                       </td>
					</tr>							  							  
				</table>
    <asp:Label runat="server" ID="alone" Enabled="false"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="popNotificacion" PopupControlID="pnlMensaje" runat="server" BackgroundCssClass="modalBackground" TargetControlID="alone"></ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="pnlMensaje" CssClass="modalPopup" runat="server" align="center" style = "display:none">
            <asp:Label runat="server" ID="lblTitulo" style="font-family:Arial;font-size:16px" Font-Bold="true"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" Font-Bold="True" Font-Size="12" ReadOnly="True" CssClass="form-control-det"  style="text-align: center"></asp:TextBox>
            <br />
            <asp:Button ID="ButConOk" runat="server" Text="OK" Width="115px" style="font-weight: 700" 
                    BackColor="#d40511" BorderColor="#E4B918" 
                    BorderStyle="Ridge" Font-Bold="True" ForeColor="White" OnClick="ButConOk_Click"/>
        </asp:Panel>

    <ajaxToolkit:ModalPopupExtender ID="popEditar" PopupControlID="pnlEditar" runat="server" BackgroundCssClass="modalBackground" TargetControlID="alone"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlEditar" CssClass="modalPopup" runat="server" align="center" style = "display:none">
        <table>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblPrmFecha" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="lblRFC" runat="server" Text="RFC:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblPrmRFC" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="lblRaz" runat="server" Text="Razón Social:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblPrmRaz" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="lblUUID" runat="server" Text="UUID:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblPrmUUID" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="lblTotal" runat="server" Text="Total:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblPrmTotal" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTipProv" runat="server" Text="Tipo:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dplTipoProv" runat="server" 
                            DataSourceID="SqlDataSource2" DataTextField="nombre" DataValueField="nombre" Width="172px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblOtm" runat="server" Text="OTM:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dplOtm" runat="server" DataTextField="otm" DataValueField="otm" Width="172px" OnSelectedIndexChanged="dplOtm_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="NO" Text="NO"></asp:ListItem>
                            <asp:ListItem Value="SI" Text="SI"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCC" runat="server" Text="CC:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCC" runat="server" OnTextChanged="txtCC_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSabana" runat="server" Text="Sabana:" Font-Bold="true" AutoPostBack="true"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSabana" runat="server" OnTextChanged="txtSabana_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSite" runat="server" Text="Site:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSite" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMoneda" runat="server" Text="Moneda:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dplMoneda" runat="server" DataTextField="moneda" DataValueField="moneda" Width="172px">
                            <asp:ListItem Value="MXN" Text="MXN"></asp:ListItem>
                            <asp:ListItem Value="USD" Text="USD"></asp:ListItem>
                        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProcesar" runat="server" Text="Procesar:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                  <asp:DropDownList ID="dplProcesar" runat="server" DataTextField="procesar" DataValueField="procesar" Width="172px">
                            <asp:ListItem Value="NO" Text="NO"></asp:ListItem>
                            <asp:ListItem Value="SI" Text="SI"></asp:ListItem>
                   </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblInterfaz" runat="server" Text="Interfaz:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                  <asp:DropDownList ID="dplInterfaz" runat="server" DataTextField="interfaz" DataValueField="interfaz" Width="172px">
                            <asp:ListItem Value="NO" Text="NO"></asp:ListItem>
                            <asp:ListItem Value="SI" Text="SI"></asp:ListItem>
                   </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFiltros" runat="server" Text="Filtros:" Font-Bold="true"></asp:Label>
                <br />
                    <br />
                </td>
                <td>
                  <asp:DropDownList ID="dplFiltros" runat="server" DataTextField="filtros" DataValueField="intfiltroserfaz" Width="172px">
                            <asp:ListItem Value="NO" Text="NO"></asp:ListItem>
                            <asp:ListItem Value="SI" Text="SI"></asp:ListItem>
                   </asp:DropDownList>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblError" runat="server" Text="" Font-Bold="true" ForeColor="#d40511" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="115px" style="font-weight: 700" 
                    BackColor="#d40511" BorderColor="#E4B918" 
                    BorderStyle="Ridge" Font-Bold="True" ForeColor="White" OnClick="btnCancelar_Click"/>
                </td>
                <td align="center">
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" Width="115px" style="font-weight: 700" 
                    BackColor="#d40511" BorderColor="#E4B918" 
                    BorderStyle="Ridge" Font-Bold="True" ForeColor="White" OnClick="btnActualizar_Click"/>
                </td>
            </tr>
         </table>
        </asp:Panel>
</asp:Content>
