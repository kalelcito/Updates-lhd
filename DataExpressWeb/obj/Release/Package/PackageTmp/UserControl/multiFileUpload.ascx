<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="multiFileUpload.ascx.cs" Inherits="multiFileUpload" %>
<asp:Panel ID="pnlParent" runat="server" Width="500px" BorderColor="Black" BorderWidth="1px"
    BorderStyle="Solid">
    <asp:Panel ID="pnlFiles" runat="server" Width="500px" HorizontalAlign="Left">
        <asp:FileUpload ID="IpFile" runat="server" Width="500px" />
    </asp:Panel>
        <asp:Panel ID="pnlButton" runat="server" Width="500px" HorizontalAlign="Right">
        <input id="btnAdd" onclick="javascript: Add();" style="width: 60px" type="button"
            runat="server" value="Agregar" />       
        <asp:Button ID="btnUpload" OnClientClick="javascript:return DisableTop();" runat="server"
            Text="Subir" Width="60px" OnClick="btnUpload_Click" /> 
        <input id="btnClear" onclick="javascript: Clear();" style="width: 60px" type="button"
            value="Limpiar" runat="server" />
        <br />
        <asp:Label ID="lblCaption" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
            ForeColor="Gray"></asp:Label>&nbsp;
    </asp:Panel>
    <asp:Panel ID="pnlListBox" runat="server" Width="480px" style="font-size:small;" ScrollBars="Horizontal" BorderStyle="Inset" >
    </asp:Panel>
</asp:Panel>
