<%@ Page Title="Scans Details" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ScansDetails.aspx.vb" Inherits="ScansDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <asp:Table ID="PageTable" runat="server" Width="900px">
<asp:TableRow><asp:TableCell><h2><%: Page.Title %></h2></asp:TableCell></asp:TableRow>
<asp:TableRow>
<asp:TableCell Width="900px">  
    

    <h3>Scan Orders</h3> 


            <p>
                <asp:GridView  CssClass="GridViewitem" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ID="GridViewScanOrder" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="5" GridLines="Vertical" HorizontalAlign="NotSet" DataKeyNames="ScanBatchID">
                    <AlternatingRowStyle BackColor="#DCDCDC" />

                    <Columns>
                        <asp:BoundField DataField="ScanBatchID" HeaderText="ScanBatchID" SortExpression="ScanBatchID"  />
                        <asp:BoundField DataField="BinKey" HeaderText="BinKey" SortExpression="BinKey" Visible="False" />
                        <asp:BoundField DataField="Line" HeaderText="Line" SortExpression="Line"/>
                        <asp:BoundField DataField="BinSequence" HeaderText="BinSequence" SortExpression="BinSequence" />
                        <asp:BoundField DataField="LocationID" HeaderText="LocationID" SortExpression="LocationID" />
                        <asp:BoundField DataField="LocationName" HeaderText="LocationName" SortExpression="LocationName" />
                        <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
                        <asp:BoundField DataField="ItemDescription" HeaderText="Item Description" SortExpression="ItemDescription" />
                        <asp:BoundField DataField="Bin" HeaderText="Bin" SortExpression="Bin" />
                        <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                        <asp:BoundField DataField="DateScanned" HeaderText="Scanned" SortExpression="DateScanned" />
                        <asp:BoundField DataField="ScannedBy" HeaderText="Scanned By" SortExpression="ScannedBy" />
                        <asp:BoundField DataField="Origin" HeaderText="Origin" SortExpression="Origin"/>
                        <asp:BoundField DataField="Extracted" HeaderText="Extracted" SortExpression="Extracted"/>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                
    </p>
    
</asp:TableCell>
    </asp:TableRow>

     <asp:TableRow>
<asp:TableCell Width="900px">  
    

    <h3>Scan Receive</h3> 


            <p>
                <asp:GridView  CssClass="GridViewitem" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ID="GridViewScanReceive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="5" GridLines="Vertical" HorizontalAlign="NotSet" DataKeyNames="ScanBatchID">
                    <AlternatingRowStyle BackColor="#DCDCDC" />

                    <Columns>
                        <asp:BoundField DataField="ScanBatchID" HeaderText="ScanBatchID" SortExpression="ScanBatchID"  />
                        <asp:BoundField DataField="BinKey" HeaderText="BinKey" SortExpression="BinKey" Visible="False" />
                        <asp:BoundField DataField="Line" HeaderText="Line" SortExpression="Line" Visible="False" />
                        <asp:BoundField DataField="BinSequence" HeaderText="BinSequence" SortExpression="BinSequence" Visible="False"  />
                        <asp:BoundField DataField="LocationID" HeaderText="LocationID" SortExpression="LocationID" Visible="False"  />
                        <asp:BoundField DataField="LocationName" HeaderText="LocationName" SortExpression="LocationName" Visible="False"  />
                        <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
                        <asp:BoundField DataField="ItemDescription" HeaderText="Item Description" SortExpression="ItemDescription" />
                        <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                        <asp:BoundField DataField="DateScanned" HeaderText="Scanned" SortExpression="DateScanned" />
                        <asp:BoundField DataField="ScannedBy" HeaderText="Received By" SortExpression="ScannedBy" />
                        
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                
    </p>
    <p><asp:Button ID="ScansDetailsCancel" runat="server" Text="Return to Scans" CausesValidation="false"/></p>
    
</asp:TableCell>
    </asp:TableRow>
        </asp:Table>

</asp:Content>
