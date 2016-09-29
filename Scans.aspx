<%@ Page Title="Scanning Module" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Scans.aspx.vb" Inherits="Scans" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <asp:Table ID="PageTable" runat="server" Width="900px">
<asp:TableRow><asp:TableCell><h2><%: Page.Title %>
    <asp:Label runat="server" ID ="BatchViewL"> - Order Batches</asp:Label>
    <asp:Label runat="server" ID ="OpenLineViewL"> - Open Scans</asp:Label>
                             </h2></asp:TableCell></asp:TableRow>
<asp:TableRow>
<asp:TableCell Width="900px">  
    
    <p>
        <asp:Button ID="NewScanBatch" runat="server" class="btn btn-primary btn-lg" Text="New Scan Orders" /> &nbsp; 
        <asp:Button ID="NewScanBatchReceive" runat="server" class="btn btn-primary btn-lg" Text="New Scan Receive" /> 
    </p>
    <p>
    <asp:LinkButton ID="BatchViewB" runat="server" class="btn btn-default">View by Batches</asp:LinkButton>&nbsp;
    <asp:LinkButton ID="OpenLineViewB" runat="server" class="btn btn-default">View by Open Items</asp:LinkButton>&nbsp;
        </p>
    <p>
        <%--Search Box--%>
            &nbsp;<asp:DropDownList ID="DatesSearch" AppendDataBoundItems="true" runat="server" DataSourceID="ScanDatesDS" DataTextField="ScanDate" DataValueField="ScanDate"  DataFormatString="{0:d}">
            <asp:ListItem Selected = "True" Text = "Today" Value = "Today" ></asp:ListItem>
            <asp:ListItem Text = "All Dates" Value = "" ></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource  runat="server" ID="ScanDatesDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectScanDates"></asp:SqlDataSource>
            
            &nbsp;<asp:DropDownList ID="FacilitySearch" AppendDataBoundItems="true" runat="server" DataSourceID="ScanFacilityDS" DataTextField="FacilityLongName" DataValueField="FacilityID">
            <asp:ListItem Selected = "True" Text = "All Facilities" Value = "" ></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource  runat="server" ID="ScanFacilityDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectScanFacilities"></asp:SqlDataSource>
            
            &nbsp;<asp:DropDownList ID="LocationSearch" AppendDataBoundItems="true" runat="server" DataSourceID="ScanLocationDS" DataTextField="LocationLongName" DataValueField="LocationID">
            <asp:ListItem Selected = "True" Text = "All Locations" Value = "" ></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource  runat="server" ID="ScanLocationDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectScanLocations"></asp:SqlDataSource>
       
            &nbsp;<asp:Button ID="SearchButton"  runat="server" Text="Search" /> &nbsp;&nbsp; 
        
    <p>
        <asp:GridView  CssClass="GridViewitem" ID="GridViewScan" OnRowDataBound="OnRowDataBound" DataSourceID="DataSourceScan" OnPageIndexChanging="OnPageIndexChanging" DataKeyNames="ScanBatchID"  runat="server" AllowSorting="False" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="True" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CellSpacing="3" PageSize="20" AllowCustomPaging="False">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="ScanBatchID" DataNavigateUrlFormatString="ScansDetails.aspx?ScanBatchID={0}" Text="Details"></asp:HyperLinkField>
                        <asp:BoundField DataField="ScanBatchID" HeaderText="ScanBatchID" SortExpression="ScanBatchID"  />
                        <asp:BoundField DataField="FacilityID" HeaderText="Facility ID" SortExpression="FacilityID"  Visible="False" />
                        <asp:BoundField DataField="FacilityName" HeaderText="Facility Name" SortExpression="FacilityName" />
                        <asp:BoundField DataField="LocationID" HeaderText="Location ID" SortExpression="LocationID" />
                        <asp:BoundField DataField="LocationName" HeaderText="Location Name" SortExpression="LocationName" />
                        <asp:BoundField DataField="BinsScanned" HeaderText="Bins Scanned" SortExpression="BinsScanned" />
                        <asp:BoundField DataField="DateScanned" HeaderText="Date Scanned" SortExpression="DateScanned" DataFormatString="{0:g}"  ItemStyle-Width="150" />
                        <asp:BoundField DataField="ScanDate" HeaderText="ScanDate" SortExpression="ScanDate" DataFormatString="{0:d}"  Visible="False" />
                        <asp:BoundField DataField="ScannedBy" HeaderText="Scanned By" SortExpression="ScannedBy" />
                        <asp:BoundField DataField="Origin" HeaderText="Origin" SortExpression="Origin" />
                        <asp:BoundField DataField="Extracted" HeaderText="Extracted" SortExpression="Extracted" Visible="False" />
                        <asp:BoundField DataField="Matched" HeaderText="Received In Full" SortExpression="Matched"/>
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
        <asp:SqlDataSource ID="DataSourceScan" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" 
                SelectCommand="exec sp_SelectScanBatch @ScanDate,@Facility,@Location">
            <SelectParameters>
                <asp:ControlParameter ControlID="DatesSearch" PropertyName="Text" DefaultValue="%" Name="ScanDate"></asp:ControlParameter>
                <asp:ControlParameter ControlID="FacilitySearch" PropertyName="Text" DefaultValue="%" Name="Facility"></asp:ControlParameter>
                <asp:ControlParameter ControlID="LocationSearch" PropertyName="Text" DefaultValue="%" Name="Location"></asp:ControlParameter>
            </SelectParameters>

        </asp:SqlDataSource>

        
    </p>
    <p>
        <p>
                <asp:GridView  CssClass="GridViewitem" ID="GridViewScanLinesOpen" DataSourceID="DataSourceScanOpen" OnPageIndexChanging="OnPageIndexChanging" DataKeyNames="ScanBatchID"  runat="server" AllowSorting="False" AutoGenerateColumns="False" BackColor="#99CCFF" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="True" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CellSpacing="3" PageSize="20" AllowCustomPaging="False">
            <AlternatingRowStyle BackColor="#DCDCDC" />

                    <Columns>
                        <asp:BoundField DataField="ScanBatchID" HeaderText="ScanBatchID" SortExpression="ScanBatchID"  />
                        <asp:BoundField DataField="BinKey" HeaderText="BinKey" SortExpression="BinKey" Visible="False" />
                        <asp:BoundField DataField="DateScanned" HeaderText="Scanned" SortExpression="DateScanned" />
                        <asp:BoundField DataField="DaysOpen" HeaderText="Days Open" SortExpression="DaysOpen"/>
                        <asp:BoundField DataField="BinSequence" HeaderText="BinSequence" SortExpression="BinSequence"  Visible="False" />
                        <asp:BoundField DataField="Line" HeaderText="Line" SortExpression="Line"/>
                        <asp:BoundField DataField="LocationID" HeaderText="LocationID" SortExpression="LocationID" />
                        <asp:BoundField DataField="LocationName" HeaderText="LocationName" SortExpression="LocationName" />
                        <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
                        <asp:BoundField DataField="ItemDescription" HeaderText="Item Description" SortExpression="ItemDescription" />
                        <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                        
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
            <asp:SqlDataSource ID="DataSourceScanOpen" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" 
                SelectCommand="exec sp_SelectScanLinesOpen @ScanDate,@Facility,@Location">
            <SelectParameters>
                <asp:ControlParameter ControlID="DatesSearch" PropertyName="Text" DefaultValue="%" Name="ScanDate"></asp:ControlParameter>
                <asp:ControlParameter ControlID="FacilitySearch" PropertyName="Text" DefaultValue="%" Name="Facility"></asp:ControlParameter>
                <asp:ControlParameter ControlID="LocationSearch" PropertyName="Text" DefaultValue="%" Name="Location"></asp:ControlParameter>
            </SelectParameters>

        </asp:SqlDataSource>
    </p>
            <p>

                &nbsp;</p>
            
    
    
</asp:TableCell>
    </asp:TableRow>
        </asp:Table>

</asp:Content>
