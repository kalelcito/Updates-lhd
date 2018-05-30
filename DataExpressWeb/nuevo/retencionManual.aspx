<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="retencionManual.aspx.cs" Inherits="DataExpressWeb.nuevo.retencionManual" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1 {
            height: 283px;
            width: 80%;
        }

        .style6 {
            color: #d40511;
            text-align: left;
            width: 6px;
        }

        .style12 {
            text-align: left;
        }

        .CompletionListCssClass {
            background: #fff;
            border: 1px solid #999;
            color: #000;
            float: left;
            font-size: 16px;
            margin-left: 0;
            margin-top: -3px;
            padding: 0 0;
            position: absolute;
            width: 300px;
            z-index: 1;
        }

        .style17 {
            text-align: left;
            vertical-align: top;
            width: 70%;
        }

        .style18 {
            text-align: left;
            vertical-align: top;
            width: 765px;
        }

        .style31 {
            width: 498px;
        }

        .style32 {
            width: 464px;
        }

        .style33 {
            text-align: left;
            width: 371px;
        }

        .style35 {
            color: #d40511;
            width: 464px;
        }

        .style41 {
            text-align: left;
            vertical-align: top;
            width: 832px;
        }

        .style42 {
            text-align: left;
            width: 832px;
        }

        .style43 {
            color: #d40511;
            height: 15px;
        }

        .style19 {
        }

        .style45 {
            color: #d40511;
            text-align: left;
            vertical-align: top;
            width: 765px;
        }

        .style46 {
            color: #d40511;
            text-align: left;
        }

        .style47 {
            color: #d40511;
            text-align: right;
            width: 1636px;
        }

        .style49 {
            color: #d40511;
            text-align: left;
        }

        .style50 {
            color: #d40511;
            text-align: left;
        }

        .style51 {
            text-align: right;
            width: 303px;
        }

        .style52 {
            color: #d40511;
            text-align: left;
            width: 371px;
        }

        .style53 {
            color: #d40511;
            height: 15px;
            width: 371px;
        }

        .auto-style1 {
            color: #d40511;
            height: 14px;
            text-align: left;
            width: 128px;
        }

        .auto-style4 {
            width: 98%;
        }

        .auto-style7 {
            color: #d40511;
            text-align: left;
            vertical-align: top;
            width: 767px;
        }

        .auto-style8 {
            color: #d40511;
            text-align: left;
            width: 767px;
        }

        .auto-style9 {
            color: #d40511;
            text-align: left;
            width: 764px;
        }

        .auto-style10 {
            color: #d40511;
            text-align: left;
            vertical-align: top;
            width: 764px;
        }

        .auto-style11 {
            color: #d40511;
            height: 38px;
            text-align: left;
            width: 318px;
        }

        .auto-style12 {
            color: #d40511;
            height: 15px;
            width: 318px;
        }

        .auto-style13 {
            width: 536px;
        }

        .auto-style14 {
            color: #d40511;
            height: 38px;
            text-align: left;
            width: 211px;
        }

        .auto-style15 {
            color: #d40511;
            height: 15px;
            width: 211px;
        }

        .auto-style16 {
            margin-right: 0;
        }

        .auto-style20 {
            color: #d40511;
            height: 14px;
            text-align: left;
            width: 140px;
        }

        .auto-style25 {
            color: #d40511;
            height: 14px;
            text-align: left;
        }

        .uppercase {
            text-transform: uppercase;
        }

        .auto-style26 {
            margin-bottom: 0;
        }

        .auto-style27 {
            color: #d40511;
            text-align: left;
            height: 16px;
        }

        .auto-style28 {
            color: #d40511;
            text-align: left;
            width: 140px;
        }

        .auto-style31 {
            color: #d40511;
            text-align: left;
            width: 128px;
        }

        .auto-style32 {
            color: #d40511;
            text-align: left;
            width: 154px;
        }

        .auto-style33 {
            color: #d40511;
            height: 14px;
            text-align: left;
            width: 154px;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 1.5px;
            border-style: solid;
            border-color: #e4b918;
            padding-top: 10px;
            padding-left: 10px;
            padding-right: 10px;
            width: 500px;
            height: 80px;
            overflow: auto;
            -ms-align-content: center;
            -webkit-align-content: center;
            align-content: center;
            text-align: center;
        }
    </style>
    <script>
        function ShowConfirmPopup() {
            var modal = $find("mpeProcesando");
            modal.show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <input id="bProcesando_Trigger" type="button" style="display: none" runat="server" />
    <asp:ModalPopupExtender runat="server"
        ID="mpeProcesando"
        BehaviorID="mpeProcesando"
        PopupControlID="pnlProcesando"
        BackgroundCssClass="modalBackground"
        DropShadow="true"
        TargetControlID="bProcesando_Trigger" />
    <asp:Panel ID="pnlProcesando" runat="server" CssClass="modalPopup">
        <span class="style5" style="color: #d40511">Procesando la retención, espere por favor...</span>
        <br />
        <asp:Image ID="imgProgress" AlternateText="Procesando..." ImageUrl="~/Imagenes-dhl/barritas.gif" runat="server" ImageAlign="Middle" ToolTip="Procesando..." />
    </asp:Panel>
    <asp:UpdatePanel ID="udpBuscarReferencia_Outter" runat="server">
        <ContentTemplate>
            <input id="bAviso_Trigger" type="button" style="display: none" runat="server" />
            <ajaxToolkit:ModalPopupExtender runat="server"
                ID="mpeAviso"
                BehaviorID="mpeAviso"
                PopupControlID="pnlAviso"
                BackgroundCssClass="modalBackground"
                DropShadow="true"
                TargetControlID="bAviso_Trigger"
                CancelControlID="bAviso_Close" />
            <asp:Panel ID="pnlAviso" runat="server" CssClass="modalPopup">
                <asp:Button ID="bAviso_Close" runat="server" Text="Cerrar" Style="float: right;" />
                <center><span class="style5" style="color: #d40511; font-size: x-large;">Aviso</span></center>
                <br />
                <asp:Label ID="lblMsgAviso" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="Label16" runat="server" CssClass="auto-style10" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="False" Text="GENERAR RETENCIÓN"></asp:Label>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:DropDownList ID="ddlEmisor" runat="server" AppendDataBoundItems="True"
                AutoPostBack="True" DataSourceID="SqlDataSourceEmisor" DataTextField="Expr1"
                DataValueField="RFCEMI"
                OnSelectedIndexChanged="ddlEmisor_SelectedIndexChanged"
                Style="font-weight: 700" Visible="False" CssClass="auto-style26">
                <asp:ListItem Value="0">Seleccionar Emisor</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="1" BackColor="#F7F6F3"
                BorderColor="#DE0248" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="0.8em" Width="97%"
                Height="346px"
                FinishCompleteButtonText="Crear Documento" Style="text-align: center" CssClass="auto-style16">
                <FinishCompleteButtonStyle Font-Size="Small" Height="25px" Width="140px" />
                <FinishPreviousButtonStyle Font-Size="Small" Height="25px" Width="90px" />
                <FinishNavigationTemplate>
                    <asp:Button ID="FinishPreviousButton" runat="server" BackColor="White"
                        BorderColor="#000099" BorderStyle="Solid" BorderWidth="1px"
                        CausesValidation="False" CommandName="MovePrevious" Font-Names="Verdana"
                        Font-Size="Small" ForeColor="#284775" Height="25px" Text="Anterior " />
                    <asp:Button ID="FinishButton" runat="server" OnClientClick='ShowConfirmPopup(); return true;' BackColor="White"
                        BorderColor="#000099" BorderStyle="Solid" BorderWidth="1px"
                        CommandName="MoveComplete" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="#284775" Height="25px" Text="Facturar" OnClick="FinishButton_Click" />
                </FinishNavigationTemplate>
                <HeaderStyle BackColor="#7AC043" BorderStyle="Solid" Font-Bold="True"
                    Font-Size="0.9em" ForeColor="White"
                    HorizontalAlign="Left" />
                <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC"
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
                    ForeColor="#284775" />
                <NavigationStyle HorizontalAlign="Center" Font-Size="Small" />
                <StartNextButtonStyle Font-Size="Small" Height="25px" Width="90px" />
                <StepNextButtonStyle Font-Size="Small" Height="25px" Width="90px" />
                <StepPreviousButtonStyle Font-Size="Small" Height="25px" Width="90px" />
                <SideBarButtonStyle ForeColor="White" BorderWidth="0" Font-Names="Verdana"
                    Font-Size="Small" />
                <SideBarStyle BackColor="#d40511" Font-Size="Small" VerticalAlign="Top"
                    Width="150px" Font-Names="Arial" BorderStyle="Inset" BorderWidth="0"
                    HorizontalAlign="Right" />
                <StartNavigationTemplate>
                    <asp:Button ID="StartNextButton" runat="server" BackColor="#FFFBFF"
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                        CommandName="MoveNext" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="#284775" Height="25px" Text="Siguiente" Width="90px" />
                </StartNavigationTemplate>
                <StepStyle
                    BorderWidth="0" ForeColor="#5D7B9D" />
                <WizardSteps>
                    <asp:WizardStep runat="server" Title="Emisor" AllowReturn="True">
                        <table class="style1">
                            <tr>
                                <td class="style6">
                                    <span class="style34">RFC:<br />
                                    </span>
                                    <asp:TextBox ID="tbRfcEmi" runat="server" Width="187px" CssClass="style34"
                                        Style="color: #000000" ForeColor="Black" OnTextChanged="tbRfcEmi_TextChanged" AutoPostBack="true" MaxLength="20">
                                    </asp:TextBox>
                                    <asp:AutoCompleteExtender ID="tbRfcEmi_AutoCompleteExtender" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="CompletionListCssClass"
                                        CompletionSetCount="12" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServicePath="~/nuevo/autoRec.asmx" ServiceMethod="getRfc"
                                        ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="tbRfcEmi"
                                        UseContextKey="True">
                                    </asp:AutoCompleteExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                        ControlToValidate="tbRfcEmi" ErrorMessage="Requiere RFC" ForeColor="Red"
                                        CssClass="style34">
                    *
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td class="style12" rowspan="2" valign="top">
                                    <span class="style46">Razon Social:<br />
                                    </span>
                                    <asp:TextBox ID="tbNomEmi" runat="server" Width="402px" CssClass="style34"
                                        Style="color: #000000" ForeColor="Black" OnTextChanged="tbNomEmi_TextChanged" AutoPostBack="true">
                                    </asp:TextBox>
                                    <asp:AutoCompleteExtender ID="tbNomEmi_AutoCompleteExtender" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="CompletionListCssClass"
                                        CompletionSetCount="12" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServicePath="~/nuevo/autoRazon.asmx" ServiceMethod="getRfc"
                                        ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="tbNomEmi"
                                        UseContextKey="True">
                                    </asp:AutoCompleteExtender>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                        ControlToValidate="tbNomEmi" ErrorMessage="Requiere razon social"
                                        ForeColor="Red" CssClass="style34" Style="color: red">
                    *
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">CURP:<br />
                                    <asp:TextBox ID="tbCURPE" runat="server" Width="187px" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style46" colspan="2">
                                    <span class="style34">Domicilio:</span><br class="style34" />
                                    <asp:TextBox ID="tbDomEmi" runat="server" Width="545px" CssClass="style34"
                                        Style="color: #000000" ForeColor="Black">
                                    </asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                        ControlToValidate="tbDomEmi" ErrorMessage="Requiere domicilio"
                                        ForeColor="Red" CssClass="style34" Style="color: red">
                    *
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style46">Numero Exterior:<br />
                                    <asp:TextBox ID="tbNumExterior" runat="server" CssClass="style34"
                                        ForeColor="Black" Style="color: #000000" Width="200px">
                                    </asp:TextBox>
                                </td>
                                <td class="style46">Numero Interior:<br />
                                    <asp:TextBox ID="tbNumInterior" runat="server" CssClass="style34"
                                        ForeColor="Black" Style="color: #000000" Width="200px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style46" colspan="2">
                                    <span class="style34">Colonia:<br />
                                    </span>
                                    <asp:TextBox ID="tbColEmi" runat="server" Width="543px" CssClass="style34"
                                        Style="color: #000000" ForeColor="Black">
                                    </asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                        ControlToValidate="tbColEmi" ErrorMessage="Requiere colonia"
                                        ForeColor="Red" CssClass="style34" Style="color: red">
                    *
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    <span class="style34">Municipio:<br />
                                    </span>
                                    <asp:TextBox ID="tbMunEmi" runat="server" Width="200px" CssClass="style34"
                                        Style="color: #000000" ForeColor="Black">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                        ControlToValidate="tbMunEmi" ErrorMessage="Requiere municipio"
                                        ForeColor="Red" CssClass="style34">
                    *
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td class="style12">
                                    <span class="style46">C.P.:<br />
                                    </span>
                                    <asp:TextBox ID="tbCpEmi" runat="server" Width="88px" CssClass="style34"
                                        Style="color: #000000" ForeColor="Black">
                                    </asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                        ControlToValidate="tbCpEmi" ErrorMessage="Requiere C.P" ForeColor="Red"
                                        CssClass="style34">
                    *
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    <span class="style34">Estado:<br />
                                    </span>
                                    <asp:TextBox ID="tbEstEmi" runat="server" Width="200px" CssClass="style34"
                                        Style="color: #000000" ForeColor="Black">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                        ControlToValidate="tbEstEmi" ErrorMessage="Requiere estado"
                                        ForeColor="Red" CssClass="style34">
                    *
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td class="style12">
                                    <span class="style46">Pais:<br />
                                    </span>
                                    <asp:TextBox ID="tbPaiEmi" runat="server" Width="224px" CssClass="style34"
                                        Style="color: #000000" ForeColor="Black">
                            </asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                        ControlToValidate="tbPaiEmi" ErrorMessage="Requiere pais" ForeColor="Red"
                                        CssClass="style34">
                    *
                            </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style46" colspan="2">
                                    <span class="style34">
                                        <br class="style46" />
                                    </span>
                                    <asp:TextBox ID="tbTelEmi" runat="server" Width="187px" CssClass="style34"
                                        Style="color: #000000" ForeColor="Black" ReadOnly="True" Visible="False">
                            </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4" colspan="2">
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red"
                                        Height="103px" />
                                </td>
                            </tr>
                        </table>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep2" runat="server" Title="Receptor">
                        <div class="style54">
                        </div>
                        <table>
                            <tr>
                                <td class="auto-style10">
                                    <span class="style44"><span class="style32">RFC:</span></span><br class="style44" />
                                    <asp:TextBox ID="tbRfcRec" runat="server" AutoPostBack="True"
                                        OnTextChanged="tbRfcRec_TextChanged" Width="187px" CssClass="style44 uppercase"
                                        Style="color: #000000" ForeColor="Black" MaxLength="20">
                </asp:TextBox>
                                    <asp:AutoCompleteExtender ID="tbRfcRec_AutoCompleteExtender" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="CompletionListCssClass"
                                        CompletionSetCount="12" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServicePath="~/nuevo/autoRec.asmx" ServiceMethod="getRfcEmi"
                                        ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="tbRfcRec"
                                        UseContextKey="True">
                                    </asp:AutoCompleteExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                        ControlToValidate="tbRfcRec" ErrorMessage="*" ForeColor="Red"
                                        ValidationGroup="Llenar" CssClass="style44">
                </asp:RequiredFieldValidator>
                                    <br class="style44" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                        ControlToValidate="tbRfcRec" ErrorMessage="RFC Invalido" ForeColor="Red" ValidationExpression="^(([A-Z]|[a-z]|&amp;|ñ|Ñ|\s){3,4})([0-9]{6})((([A-Z]|[a-z]|[0-9]){2}))((([A]|[a]|[0-9]){1}))"
                                        CssClass="style44">
                </asp:RegularExpressionValidator>
                                    <br class="style44" />
                                </td>
                                <td class="style18" colspan="2">
                                    <span class="style46"><span class="style44"><span
                                        class="style32">Razon Social:</span></span><br class="style44" />
                                    </span>
                                    <asp:TextBox ID="tbNomRec" runat="server" Width="402px" CssClass="style44"
                                        Style="color: #000000" ForeColor="Black">
                                    </asp:TextBox>
                                    <asp:AutoCompleteExtender ID="tbNomRec_AutoCompleteExtender" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="CompletionListCssClass"
                                        CompletionSetCount="12" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServicePath="~/nuevo/autoRazon.asmx" ServiceMethod="getRfcEmi"
                                        ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="tbNomRec"
                                        UseContextKey="True">
                                    </asp:AutoCompleteExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server"
                                        ControlToValidate="tbNomRec" ErrorMessage="*" ForeColor="Red"
                                        ValidationGroup="Llenar" CssClass="style44">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10">CURP:<br />
                                    <asp:TextBox ID="tbCURPR" runat="server" CssClass="style44 uppercase" Width="186px" MaxLength="20"></asp:TextBox>
                                </td>
                                <td class="auto-style7">Nacionalidad:<br />
                                    <asp:RadioButton ID="rbNacional" runat="server" Text="Nacional" AutoPostBack="True" GroupName="bgNacionalidad" OnCheckedChanged="rbNacional_CheckedChanged" />
                                    <br />
                                    <asp:RadioButton ID="rbExtranjero" runat="server" Text="Extranjero" AutoPostBack="True" GroupName="bgNacionalidad" OnCheckedChanged="rbExtranjero_CheckedChanged" />
                                    <asp:TextBox ID="tbNacionalidad" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td class="style45" id="tdIdFiscal" runat="server">No.Identificacion Fiscal:<br />
                                    <asp:TextBox ID="tbIdFiscal" runat="server" Width="229px" CssClass="uppercase" MaxLength="12"></asp:TextBox>

                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="tbIdFiscal" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9_]*$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style46" colspan="3">
                                    <span class="style44"><span class="style32">Domicilio:</span></span><br class="style44" />
                                    <asp:TextBox ID="tbDomRec" runat="server" Width="545px" CssClass="style44"
                                        Style="color: #000000" ForeColor="Black" ReadOnly="True">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">
                                    <span class="style44"><span class="style32">Num. Exterior:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Num. Interior:</span></span><br />
                                    <asp:TextBox ID="tbNumExtRec" runat="server" CssClass="style44"
                                        ForeColor="Black" Style="color: #000000" Width="119px" ReadOnly="True">
                                    </asp:TextBox>
                                    &nbsp;<asp:TextBox ID="tbNumIntRec" runat="server" CssClass="style44" ForeColor="Black" Style="color: #000000" Width="121px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td class="auto-style8" colspan="1">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="style46" colspan="3">
                                    <span class="style35">Colonia:</span><br class="style46" />
                                    <asp:TextBox ID="tbColRec" runat="server" Width="543px" CssClass="style44"
                                        Style="color: #000000" ForeColor="Black" ReadOnly="True">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10">
                                    <span class="style44"><span class="style32">Municipio:</span></span><br class="style44" />
                                    <asp:TextBox ID="tbMunRec" runat="server" Width="200px" CssClass="style44"
                                        Style="color: #000000" ForeColor="Black" ReadOnly="True">
                                    </asp:TextBox>
                                </td>
                                <td class="style17" colspan="2">
                                    <span class="style46"><span class="style44"><span
                                        class="style32">C.P.:</span></span><br class="style44" />
                                    </span>
                                    <asp:TextBox ID="tbCpRec" runat="server" Width="76px" CssClass="style44"
                                        Style="color: #000000" ForeColor="Black" ReadOnly="True">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10">
                                    <span class="style44"><span class="style32">Estado:</span></span><br class="style44" />
                                    <asp:TextBox ID="tbEstRec" runat="server" Width="200px" CssClass="style44"
                                        Style="color: #000000" ForeColor="Black" ReadOnly="True">
                                    </asp:TextBox>
                                </td>
                                <td class="style18" colspan="2">
                                    <span class="style46"><span class="style44">Pais:</span><br class="style44" />
                                    </span>
                                    <asp:TextBox ID="tbPaiRec" runat="server" Width="224px" CssClass="style44"
                                        Style="color: #000000" ForeColor="Black" ReadOnly="True">
                </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9" colspan="1">
                                    <span class="style32">
                                        <br class="style44" />
                                        <asp:TextBox ID="tbEmail" runat="server" Height="34px" Width="333px"
                                            CssClass="style44" Style="color: #000000" ForeColor="Black"
                                            Visible="False" ReadOnly="True"></asp:TextBox>
                                    </span>
                                </td>
                                <td class="style12" colspan="2">
                                    <br class="style46" />
                                    <asp:TextBox ID="tbLocRec" runat="server" Visible="False" Width="277px"
                                        CssClass="style44" Style="color: #000000" ForeColor="Black" ReadOnly="True">
                </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lMsj" runat="server" ForeColor="Red" Text=""></asp:Label>
                        <br />
                        <br />

                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep3" runat="server" Title="Totales">

                        <span class="style44">&nbsp;</span><span>
                            <table class="auto-style4">

                                <tr>
                                    <td align="right" class="style46 bold" colspan="4">IMPUESTOS RETENIDOS:<br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style32" valign="top">
                                        <span>Tipo de Impuesto:
                                   
                                   

                                            <br />
                                            <asp:DropDownList ID="ddlTipoImpuesto" runat="server" Width="90%">
                                                <asp:ListItem Value="01">ISR</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="02">IVA</asp:ListItem>
                                                <asp:ListItem Value="03">IEPS</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <br />
                                            <asp:Button ID="bAgregarImpuesto" runat="server" OnClick="tbAgregar_Click" Text="Agregar Impuesto" ValidationGroup="impValidation" />
                                        </span>
                                    </td>
                                    <td align="right" class="auto-style31" valign="top">

                                        <span>Base del Impuesto:<br />
                                            <asp:TextBox ID="tbBaseRet" runat="server" CssClass="style44" ForeColor="Black" MaxLength="13" Width="90%"></asp:TextBox>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="tbBaseRet" CssClass="style44" ErrorMessage="Formato no válido" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^(((?=.*[0-9])\d{0,18}(?:\.\d{1,2})?)|())$" ValidationGroup="impValidation"></asp:RegularExpressionValidator>
                                        </span></td>
                                    <td align="right" class="auto-style28" dir="ltr" valign="top">Importe del Impuesto:<asp:TextBox ID="tbmontoRet" runat="server" Width="90%">0.00</asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator105" runat="server" ControlToValidate="tbmontoRet" ErrorMessage="*" ForeColor="Red" ValidationGroup="impValidation"></asp:RequiredFieldValidator>
                                        </span>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^(((?=.*[0-9])\d{1,18}(?:\.\d{1,2})?)|())$" ControlToValidate="tbmontoRet" ValidationGroup="impValidation"></asp:RegularExpressionValidator>
                                    </td>
                                    <td align="right" class="style50" valign="top">Tipo de Pago<span>:<br />
                                        <asp:DropDownList ID="ddlTipoPago" runat="server" CssClass="style44" ForeColor="Black" Width="203px">
                                            <asp:ListItem Selected="True" Value="1">Pago definitivo</asp:ListItem>
                                            <asp:ListItem Value="2">Pago provisional</asp:ListItem>
                                        </asp:DropDownList>
                                    </span></td>
                                </tr>
                                <tr>
                                    <td align="right" class="auto-style27" colspan="4">
                                        <asp:Label ID="lError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                        <asp:Label ID="lErrorPU" runat="server" ForeColor="#FF3300" Text="Label"
                                            Visible="False"></asp:Label>
                                        <asp:Label ID="LMensajeErrorAgregar" runat="server" ForeColor="#CC0000"
                                            Style="color: #0000FF; text-align: center;"></asp:Label>
                                        <br />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right" class="style49" colspan="4">
                                        <asp:GridView ID="gvImpuestosTemp" runat="server" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#d40511" BorderStyle="None" BorderWidth="1px"
                                            CellPadding="4" DataKeyNames="idImpuesto" DataSourceID="SqlDataSource1"
                                            ForeColor="Black" GridLines="Vertical" Style="text-align: left"
                                            Width="100%" OnDataBound="gvImpuestosTemp_DataBound">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="BaseRet" HeaderText="Base" SortExpression="Base"></asp:BoundField>
                                                <asp:BoundField DataField="Impuesto" HeaderText="Tipo de Impuesto" SortExpression="Impuesto" />
                                                <asp:BoundField DataField="MontoRet" HeaderText="Monto Retenido" SortExpression="MontoRet" />
                                                <asp:BoundField DataField="TipoPago" HeaderText="Tipo de Pago" SortExpression="TipoPago"></asp:BoundField>
                                                <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True"></asp:CommandField>
                                            </Columns>
                                            <EmptyDataRowStyle BorderColor="White" />
                                            <EmptyDataTemplate>
                                                <asp:TextBox ID="tbGV" runat="server" Height="0.000000000001px" ReadOnly="true"
                                                    Visible="true" Width="0.0000000001px"></asp:TextBox>
                                                NO CONTIENE DATOS
                                   
                                       

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server"
                                                    BorderColor="White" ControlToValidate="tbGV"
                                                    ErrorMessage="Agrega al menos 1 impuesto" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </EmptyDataTemplate>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#d40511" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#FAC291" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="left" class="style46 bold">
                                        <br />
                                        TOTALES:<br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="auto-style33" valign="top">Monto Total de Operación:<br />
                                        <span>
                                            <asp:TextBox ID="tbmontoTotOperacion" runat="server" CssClass="style44" ForeColor="Black" Height="16px" Width="90%">0.00</asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator106" runat="server" ControlToValidate="tbmontoTotOperacion" ErrorMessage="*" ForeColor="Red" ValidationGroup="impValidation"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="tbmontoTotOperacion" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^(((?=.*[0-9])\d{1,18}(?:\.\d{1,2})?)|())$" ValidationGroup="impValidation"></asp:RegularExpressionValidator>
                                        </span></td>
                                    <td align="right" class="auto-style1" valign="top">Monto Total Gravado:<span><br />
                                        <asp:TextBox ID="tbmontoTotGrav" runat="server" Width="90%">0.00</asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator103" runat="server" ControlToValidate="tbmontoTotGrav" ErrorMessage="*" ForeColor="Red" ValidationGroup="impValidation"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="tbmontoTotGrav" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^(((?=.*[0-9])\d{1,18}(?:\.\d{1,2})?)|())$" ValidationGroup="impValidation"></asp:RegularExpressionValidator>
                                    </span></td>
                                    <td align="right" class="auto-style20" valign="top">Monto Total Exento:<br />
                                        <span>
                                            <asp:TextBox ID="tbmontoTotExent" runat="server" Height="16px" Width="90%">0.00</asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator104" runat="server" ControlToValidate="tbmontoTotExent" ErrorMessage="*" ForeColor="Red" ValidationGroup="impValidation"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="tbmontoTotExent" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^(((?=.*[0-9])\d{1,18}(?:\.\d{1,2})?)|())$" ValidationGroup="impValidation"></asp:RegularExpressionValidator>
                                        </span></td>
                                    <td align="right" class="auto-style25" valign="top">
                                        <span>Monto Total Retenido:<br />
                                            <asp:TextBox ID="tbmontoTotRet" runat="server" CssClass="style44" ForeColor="Black" Width="29%">0.00</asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server" ControlToValidate="tbmontoTotRet" CssClass="style44" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="impValidation"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="tbmontoTotRet" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^(((?=.*[0-9])\d{1,18}(?:\.\d{1,2})?)|())$" ValidationGroup="impValidation"></asp:RegularExpressionValidator>
                                        </span>
                                    </td>
                                </tr>
                            </table>
                        </span>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep4" runat="server" Title="Pagos a Extranjeros">
                        <table class="auto-style13">
                            <tr>
                                <td class="style46" colspan="2">
                                    <asp:CheckBox ID="chkPagos" runat="server" Text="Habilitar Complemento" AutoPostBack="true" OnCheckedChanged="chkPagos_CheckedChanged" />
                                    <br />
                                    <asp:CheckBox ID="chkBeneficiario" runat="server" OnCheckedChanged="chkBeneficiario_CheckedChanged" AutoPostBack="True" Text="BENEFICIARIO" Enabled="false" />
                                    <br />
                                    RFC:<br />
                                    <asp:TextBox ID="tbRFCNB" runat="server" CssClass="style44" ForeColor="Black" ReadOnly="True" MaxLength="20"></asp:TextBox>
                                    <br />
                                    Razón Social:<br />
                                    <asp:TextBox ID="tbRazonNB" runat="server" Width="500px" ReadOnly="True"></asp:TextBox>
                                    <br />
                                    CURP:<br />
                                    <asp:TextBox ID="tbCURPNB" runat="server" CssClass="style44" ForeColor="Black" ReadOnly="True" MaxLength="20"></asp:TextBox>
                                    <br />
                                    Concepto de Pago:<br />
                                    <asp:DropDownList ID="tbConceptoPagoB" runat="server" Width="459px" Enabled="false">
                                        <asp:ListItem Value="1" Text="Artistas, deportistas y espectáculos públicos"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Otras personas físicas" Selected="true"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Persona moral"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Fideicomiso"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="Asociación en participación"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="Organizaciones Internacionales o de gobierno"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="Organizaciones exentas"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="Agentes pagadores"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="Otros"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    Descripción de Concepto:<br />
                                    <asp:TextBox ID="tbDescConceptoB" runat="server" Width="500px" ReadOnly="True"></asp:TextBox>
                                    <br class="style46" />
                                    <span class="style19">
                                        <br />
                                        <asp:CheckBox ID="chkNoBeneficiario" runat="server" AutoPostBack="True" OnCheckedChanged="chkNoBeneficiario_CheckedChanged1" Text="NO BENEFICIARIO" Enabled="false" />
                                        <br />
                                        País de Residencia para Efectos Fiscales:<br />
                                        <asp:DropDownList ID="ddlPaisExt" runat="server" Width="459px" Enabled="false">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator113" runat="server" ControlToValidate="ddlPaisExt" ErrorMessage="*" ForeColor="Red" Enabled="false"></asp:RequiredFieldValidator>
                                        <br />
                                        Concepto de Pago:<asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ControlToValidate="tbConceptoPagoNB" ErrorMessage="*" ForeColor="Red" Enabled="false"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:DropDownList ID="tbConceptoPagoNB" runat="server" Width="459px" Enabled="false">
                                            <asp:ListItem Value="1" Text="Artistas, deportistas y espectáculos públicos"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Otras personas físicas" Selected="true"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Persona moral"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Fideicomiso"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Asociación en participación"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Organizaciones Internacionales o de gobierno"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Organizaciones exentas"></asp:ListItem>
                                            <asp:ListItem Value="8" Text="Agentes pagadores"></asp:ListItem>
                                            <asp:ListItem Value="9" Text="Otros"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        Descripción de Concepto:<br />
                                        <asp:TextBox ID="tbDescConceptoNB" runat="server" Width="500px" ReadOnly="True"></asp:TextBox>
                                    </span></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lMensajeError" runat="server" ForeColor="Red" CssClass="style46"></asp:Label>
                                    <br class="style46" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Image ID="iProgress" runat="server" ImageUrl="~/imagenes/progress.gif"
                                        Visible="False" />
                                    <span class="style19">
                                        <br />
                                        <asp:TextBox ID="tbObservacion" runat="server" CssClass="title" Height="68px"
                                            ReadOnly="True" TextMode="MultiLine" Visible="False" Width="455px"></asp:TextBox>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">
                                    <asp:Label ID="lRFCEMI" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lTXT" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lBCK" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lPDF" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td class="auto-style15">&nbsp;</td>
                            </tr>
                        </table>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep5" runat="server" Title="Dividendos">
                        <table class="auto-style13">
                            <tr>
                                <td class="style46" colspan="2">
                                    <asp:CheckBox ID="chkDividendos" runat="server" Text="Habilitar Complemento" AutoPostBack="true" OnCheckedChanged="chkDividendos_CheckedChanged" />
                                    <br />
                                    <asp:CheckBox ID="chkDividOutil" runat="server" Text="DIVIDENDOS O UTILIDADES" OnCheckedChanged="chkDividOutil_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                    <br />
                                    Tipo de dividendo o utilidad:<br />
                                    <asp:DropDownList ID="ddlTipoDivOUtil" runat="server" Width="459px" Enabled="false">
                                        <asp:ListItem Value="01" Text="Proviene de CUFIN"></asp:ListItem>
                                        <asp:ListItem Value="02" Text="No proviene de CUFIN"></asp:ListItem>
                                        <asp:ListItem Value="03" Text="Reembolso o reducción de capital"></asp:ListItem>
                                        <asp:ListItem Value="04" Text="Liquidación de la persona moral"></asp:ListItem>
                                        <asp:ListItem Value="05" Text="CUFINRE"></asp:ListItem>
                                        <asp:ListItem Value="06" Text="Proviene de CUFIN al 31 
de diciembre 2013"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    Importe en Territorio Nacional:<br />
                                    <asp:TextBox ID="tbMontISRAcredRetMexico" runat="server" CssClass="style44" ForeColor="Black" ReadOnly="True" Width="29%">0.00</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbMontISRAcredRetMexico" CssClass="style44" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="impValidation" Enabled="false"></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                   
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbMontISRAcredRetMexico" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^\d{1,18}(\.\d{1,6})?$" Enabled="false"></asp:RegularExpressionValidator>
                                    <br />
                                    Importe en Territorio Extranjero:<br />
                                    <asp:TextBox ID="tbMontISRAcredRetExtranjero" runat="server" CssClass="style44" ForeColor="Black" ReadOnly="True" Width="29%">0.00</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbMontISRAcredRetExtranjero" CssClass="style44" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="impValidation" Enabled="false"></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                   
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbMontISRAcredRetExtranjero" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^\d{1,18}(\.\d{1,6})?$" Enabled="false"></asp:RegularExpressionValidator>
                                    <br />
                                    Monto en Territorio Extranjero:<br />
                                    <asp:TextBox ID="tbMontRetExtDivExt" runat="server" CssClass="style44" ForeColor="Black" ReadOnly="True" Width="29%"></asp:TextBox>&nbsp;&nbsp;
                                   
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tbMontRetExtDivExt" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^(((?=.*[1-9])\d{1,16}(?:\.\d{1,6})?)|())$" Enabled="false"></asp:RegularExpressionValidator>
                                    <br />
                                    Tipo de sociedad:<br />
                                    <asp:DropDownList ID="ddlTipoSocDistrDiv" runat="server" Width="459px" Enabled="false">
                                        <asp:ListItem Value="Sociedad Nacional" Text="Sociedad Nacional"></asp:ListItem>
                                        <asp:ListItem Value="Sociedad Extranjera" Text="Sociedad Extranjera"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    Monto del ISR Acreditable Nacional:<br />
                                    <asp:TextBox ID="tbMontISRAcredNal" runat="server" CssClass="style44" ForeColor="Black" ReadOnly="True" Width="29%"></asp:TextBox>&nbsp;&nbsp;
                                   
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tbMontISRAcredNal" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^(((?=.*[1-9])\d{1,16}(?:\.\d{1,6})?)|())$" Enabled="false"></asp:RegularExpressionValidator>
                                    <br />
                                    Monto del Dividendo Acumulable Nacional:<br />
                                    <asp:TextBox ID="tbMontDivAcumNal" runat="server" CssClass="style44" ForeColor="Black" ReadOnly="True" Width="29%"></asp:TextBox>&nbsp;&nbsp;
                                   
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="tbMontDivAcumNal" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^(((?=.*[1-9])\d{1,16}(?:\.\d{1,6})?)|())$" Enabled="false"></asp:RegularExpressionValidator>
                                    <br />
                                    Monto del Dividendo Acumulable Extranjero:<br />
                                    <asp:TextBox ID="tbMontDivAcumExt" runat="server" CssClass="style44" ForeColor="Black" ReadOnly="True" Width="29%"></asp:TextBox>&nbsp;&nbsp;
                                   
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="tbMontDivAcumExt" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^(((?=.*[1-9])\d{1,16}(?:\.\d{1,6})?)|())$" Enabled="false"></asp:RegularExpressionValidator>
                                    <br class="style46" />
                                    <span class="style19">
                                        <br />
                                        <asp:CheckBox ID="chkRemanente" runat="server" Text="REMANENTE" OnCheckedChanged="chkRemanente_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                        <br />
                                        Participación de Integrantes/Accionistas:<br />
                                        <asp:TextBox ID="tbProporcionRem" runat="server" CssClass="style44" ForeColor="Black" ReadOnly="True" Width="29%">0.00</asp:TextBox>&nbsp;&nbsp;
                                       
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="tbProporcionRem" ErrorMessage="Formato no válido" ForeColor="Red" ValidationExpression="^(((?=.*[1-9])\d{1,16}(?:\.\d{1,6})?)|())$" Enabled="false"></asp:RegularExpressionValidator>
                                    </span></td>
                            </tr>
                        </table>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep6" runat="server" Title="Documento">
                        <table class="auto-style13">
                            <tr>
                                <td class="auto-style11">
                                    <span class="style32"><span class="style47"><span class="style34">Fecha de Expedición:
                               
                                        <asp:Label ID="lFecha" runat="server" Text="01/12/2010"></asp:Label>
                                    </span></span></span>
                                </td>
                                <td class="auto-style14">
                                    <span class="style19">
                                        <asp:Label ID="Label15" runat="server" CssClass="style37" Text="Serie:"></asp:Label>
                                        <asp:TextBox ID="tbSerie" runat="server" CssClass="style19" ReadOnly="True" Width="132px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label2" runat="server" CssClass="style37" Text="Mes Inicial Periodo:"></asp:Label>
                                        <asp:TextBox ID="tbMesIni" runat="server" CssClass="style19" Width="50px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label3" runat="server" CssClass="style37" Text="Mes Final Periodo:"></asp:Label>
                                        <asp:TextBox ID="tbMesFin" runat="server" CssClass="style19" Width="50px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label1" runat="server" CssClass="style37" Text="Año Periodo:"></asp:Label>
                                        <asp:TextBox ID="tbEjerc" runat="server" CssClass="style19" Width="60px"></asp:TextBox>
                                    </span></td>
                            </tr>
                        </table>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep7" runat="server" Title="Resumen">
                        <span class="style44">&nbsp;</span><span>
                            <table class="auto-style4">
                                <tr>
                                    <td align="right" class="style46 bold" colspan="4">RESUMEN DE RETENCIÓN:<br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel1" runat="server" Style="overflow-x: scroll;" Height="346px" ScrollBars="Vertical">
                                <table class="auto-style4">
                                    <tr>
                                        <td class="style46" colspan="4">EMISOR
                                           
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">RFC:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox1" runat="server" Text="<%#tbRfcEmi.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46">Razón Social:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox2" runat="server" Text="<%#tbNomEmi.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46">CURP:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox3" runat="server" Text="<%#tbCURPE.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table class="auto-style4">
                                    <tr>
                                        <td class="style46" colspan="4">RECEPTOR
                                           
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Nacionalidad:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox4" runat="server" Text="<%#tbNacionalidad.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <% if (rbNacional.Checked)
                                        { %>
                                    <tr>
                                        <td class="style46">RFC:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox5" runat="server" Text="<%#tbRfcRec.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46">Razón Social:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox6" runat="server" Text="<%#tbNomRec.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46">CURP:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox7" runat="server" Text="<%#tbCURPR.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <% }
                                        else { %>
                                    <tr>
                                        <td class="style46">No. de Identificación Tributaria:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox8" runat="server" Text="<%#tbIdFiscal.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46">Razón Social:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox9" runat="server" Text="<%#tbNomRec.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <% } %>
                                </table>
                                <br />
                                <table class="auto-style4">
                                    <tr>
                                        <td class="style46" colspan="4">TOTALES
                                           
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Monto Total de Operación:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox10" runat="server" Text="<%#tbmontoTotOperacion.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Monto Total Gravado:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox11" runat="server" Text="<%#tbmontoTotGrav.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Monto Total Exento:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox12" runat="server" Text="<%#tbmontoTotExent.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Monto Total Retenido:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox13" runat="server" Text="<%#tbmontoTotRet.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table class="auto-style4">
                                    <tr>
                                        <td class="style46" colspan="4">PERIODO
                                           
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Mes Inicial:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox14" runat="server" Text="<%#tbMesIni.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Mes Final:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox32" runat="server" Text="<%#tbMesFin.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Año:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox15" runat="server" Text="<%#tbEjerc.Text %>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <% if (chkPagos.Checked || chkDividendos.Checked)
                                    { %>
                                <br />
                                <table class="auto-style4">
                                    <tr>
                                        <td class="style46" colspan="4">COMPLEMENTO
                                           
                                            <hr />
                                        </td>
                                    </tr>
                                    <% if (chkPagos.Checked)
                                        { %>
                                    <tr>
                                        <td class="style46" colspan="1">PAGOS A EXTRANJEROS
                                           
                                            <hr />
                                        </td>
                                        <td class="style46" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Es Benef. del Cobro:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <% if (chkBeneficiario.Checked)
                                                { %>
                                            <asp:TextBox ID="TextBox21" runat="server" Text="SI" Enabled="false" Width="100%"></asp:TextBox>
                                            <% }
                                                else { %>
                                            <asp:TextBox ID="TextBox22" runat="server" Text="NO" Enabled="false" Width="100%"></asp:TextBox>
                                            <%}  %>
                                        </td>
                                    </tr>
                                    <% if (chkBeneficiario.Checked)
                                        { %>
                                    <tr>
                                        <td class="style46" width="30%"><strong>Beneficiario: </strong>
                                        </td>
                                        <td class="style46" colspan="3"></td>
                                    </tr>

                                    <tr>
                                        <td class="style46" width="30%">RFC:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox33" runat="server" Text="<%#tbRFCNB.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Razón Social:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox34" runat="server" Text="<%#tbRazonNB.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <% if (!string.IsNullOrEmpty(tbCURPNB.Text))
                                        { %>
                                    <tr>
                                        <td class="style46" width="30%">CURP:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox35" runat="server" Text="<%#tbCURPNB.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <% } %>
                                    <tr>
                                        <td class="style46" width="30%">Concepto de Pago:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox16" runat="server" Text="<%#tbConceptoPagoB.SelectedItem.Value%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Descripción de Concepto:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox17" runat="server" Text="<%#tbDescConceptoB.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <% } %>
                                    <% if (chkNoBeneficiario.Checked)
                                        { %>
                                    <tr>
                                        <td class="style46" width="30%"><strong>No Beneficiario: </strong>
                                        </td>
                                        <td class="style46" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Concepto de Pago:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox18" runat="server" Text="<%#tbConceptoPagoNB.SelectedItem.Value%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Descripción de Concepto:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox19" runat="server" Text="<%#tbDescConceptoNB.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">País de Residencia:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox20" runat="server" Text="<%#ddlPaisExt.SelectedItem.Value%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <% } %>
                                    <% }
                                        else if (chkDividendos.Checked)
                                        { %>
                                    <tr>
                                        <td class="style46" colspan="1">DIVIDENDOS
                                           
                                            <hr />
                                        </td>
                                        <td class="style46" colspan="3"></td>
                                    </tr>
                                    <% if (chkDividOutil.Checked)
                                        { %>
                                    <tr>
                                        <td class="style46" width="30%">Tipo de Dividendo:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox23" runat="server" Text="<%#ddlTipoDivOUtil.SelectedItem.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Importe Retenido en México:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox24" runat="server" Text="<%#tbMontISRAcredRetMexico.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Importe Retenido en el Extranjero:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox25" runat="server" Text="<%#tbMontISRAcredRetExtranjero.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Importe sobre Dividendos del Extranjero:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox26" runat="server" Text="<%#tbMontRetExtDivExt.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Sociedad Distribuidora:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox27" runat="server" Text="<%#ddlTipoSocDistrDiv.SelectedItem.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">ISR Acreditable Nacional:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox28" runat="server" Text="<%#tbMontISRAcredNal.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Dividendo Acumulable Nacional:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox29" runat="server" Text="<%#tbMontDivAcumNal.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style46" width="30%">Dividendo Acumulable Extranjero:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox30" runat="server" Text="<%#tbMontDivAcumExt.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <% } %>
                                    <% if (chkRemanente.Checked)
                                        { %>
                                    <tr>
                                        <td class="style46" width="30%">Participación de Integrantes/Accionistas:
                                        </td>
                                        <td class="style46" colspan="3">
                                            <asp:TextBox ID="TextBox31" runat="server" Text="<%#tbPaiEmi.Text%>" Enabled="false" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <% } %>
                                    <% } %>
                                </table>
                                <% } %>
                            </asp:Panel>
                        </span>
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:SqlDataSource ID="SqlDataSourceEmisor" runat="server"
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>"
        SelectCommand="SELECT RFCEMI, RFCEMI + ': ' + NOMEMI AS Expr1 FROM EMISOR WHERE (RFCEMI = 'HIM890120VEA') OR (RFCEMI = 'SIH071204N90')"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server"
        ConnectionString="<%$ ConnectionStrings:dataexpressConnectionString %>"
        DeleteCommand="DELETE FROM ImpRetTemp WHERE (idImpuesto = @idImpuesto)"
        SelectCommand="SELECT idImpuesto, CAST(BaseRet as decimal(18,2)) as BaseRet, Impuesto, CAST(MontoRet as decimal(18,2)) as MontoRet, TipoPago FROM ImpRetTemp WHERE (id_Empleado = @id_Empleado)"
        ID="SqlDataSource1">
        <DeleteParameters>
            <asp:SessionParameter Name="idImpuesto"></asp:SessionParameter>
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="id_Empleado"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server"
        ConnectionString="<%$ ConnectionStrings:upsdataConnectionString %>"
        SelectCommand="SELECT DESCRIPCION FROM CatalogoConceptosModulo WHERE(IDEMODULO = @idModulo ) "
        ID="SqlDataSource2">
        <SelectParameters>
            <asp:SessionParameter SessionField="moduloEmple" Name="idModulo"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:Label runat="server" ForeColor="Red" ID="lServi"></asp:Label>
</asp:Content>
