<%@ Page Title="AHRMM Simulation" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AHRMM.aspx.vb" Inherits="AHRMM" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <asp:Table ID="PageTable" runat="server" Width="900px">

<asp:TableRow Height ="30"></asp:TableRow>
    <asp:TableRow>
<asp:TableCell Width="900px">  
    
    <p>
        <asp:Button ID="TraySubmitB" runat="server" class="btn btn-primary btn-lg" Text="Simulate Tray Scan" CausesValidation="False" PostBackUrl="~/AHRMM.aspx" />
        
    </p>
    <p>
        <asp:Button ID="TraySubmitSecondBinB" runat="server" class="btn btn-primary btn-lg" Text="Simulate Second Bin Scan"  CausesValidation="False" PostBackUrl="~/AHRMM.aspx" /> 

    </p>
    <p>
        <asp:Button ID="TrayDeleteB" runat="server" class="btn btn-default btn-lg" Text="Delete Scans"  CausesValidation="False" PostBackUrl="~/AHRMM.aspx" /> 
    </p>
    
</asp:TableCell>
    </asp:TableRow>
        </asp:Table>

</asp:Content>
