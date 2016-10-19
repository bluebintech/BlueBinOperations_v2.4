<%@ Page Title="QCN" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="QCN.aspx.vb" Inherits="QCN" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="http://cdn.jsdelivr.net/jquery.simpletip/1.3.1/jquery.simpletip-1.3.1.min.js"></script>




<script type="text/javascript">
    $(function () {
        $('[id*=GridViewQCN] tr').each(function () {
            var toolTip = $(this).attr("DetailsText");
            $(this).find("td").each(function () {
                $(this).simpletip({
                    content: toolTip
                });
            });
            $(this).removeAttr("DetailsText");
        });
    });
</script>

    <style type="text/css">
    .tooltip td
    {
        position: absolute;
        top: 0;
        left: 0;
        z-index: 3;
        display: none;
        background-color: #FB66AA;
        color: White;
        padding: 5px;
        font-size: 10pt;
        font-family: Arial;
        cursor: pointer;
    }

</style>


    <asp:panel runat ="server">    

<asp:Table ID="PageTable" runat="server" Width="1000px" >
<asp:TableRow><asp:TableCell><h2>QCN Status</h2></asp:TableCell></asp:TableRow>
<asp:TableRow>
<asp:TableCell Width="1000px">    
<p>
    <asp:Button ID="NewQCNB" class="btn btn-primary btn-lg" runat="server" Text="New QCN Form" />&nbsp;
    <asp:Button ID="QCNDashboardB" class="btn btn-primary btn-lg" runat="server" Text="QCN Dashboard" />
    </p>


<p>


     <b>Assigned To:</b>&nbsp;<asp:DropDownList ID="AssignedSearchDD" AppendDataBoundItems="true" runat="server" DataSourceID="AssignedSearchDS" DataTextField="AssignedUserName" DataValueField="AssignedUserName">
            <asp:ListItem Selected = "True" Text = "All" Value = ""></asp:ListItem>
        </asp:DropDownList>
           
     <asp:SqlDataSource runat="server" ID="AssignedSearchDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="SELECT DISTINCT v.LastName + ', ' + v.FirstName as AssignedUserName FROM qcn.QCN a inner join [bluebin].[BlueBinUser] v on AssignedUserID = v.BlueBinUserID order by 1"></asp:SqlDataSource>
 <p>
     <b>QCN Status:</b>&nbsp;&nbsp;<asp:DropDownList ID="QCNStatusSearchDD" AppendDataBoundItems="true" runat="server" DataSourceID="QCNStatusSearchDS" DataTextField="Status" DataValueField="Status">
            <asp:ListItem Selected = "True" Text = "All" Value = ""></asp:ListItem>
        </asp:DropDownList>
           
     <asp:SqlDataSource runat="server" ID="QCNStatusSearchDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectQCNStatus '1'"></asp:SqlDataSource>

    </p> 
    <p>
     <b>QCN Facility:</b>&nbsp;<asp:DropDownList ID="QCNFacilityS" AppendDataBoundItems="true" runat="server" DataSourceID="QCNFacilityDS" DataTextField="FacilityName" DataValueField="FacilityName">
            <asp:ListItem Selected = "True" Text = "All" Value = ""></asp:ListItem>
        </asp:DropDownList>
           
     <asp:SqlDataSource runat="server" ID="QCNFacilityDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectQCNFacility"></asp:SqlDataSource>
</p>
    <p>
     <b>QCN Location:</b>&nbsp;<asp:DropDownList ID="QCNLocationS" AppendDataBoundItems="true" runat="server" DataSourceID="QCNLocationDS" DataTextField="LocationName" DataValueField="LocationName">
            <asp:ListItem Selected = "True" Text = "All" Value = ""></asp:ListItem>
        </asp:DropDownList>
           
     <asp:SqlDataSource runat="server" ID="QCNLocationDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectQCNLocation"></asp:SqlDataSource>
&nbsp;<asp:Button ID="SearchButton"  runat="server" Text="Search" /> &nbsp;&nbsp; 
    </p>
    <p><asp:CheckBox ID="CompletedCB" OnCheckedChanged="OnCheckedChanged" AutoPostBack="true" runat="server" Text="Include Completed and Rejected?" />
    </p>



    <p>
    <asp:GridView  CssClass="GridViewitem" ID="GridViewQCN" ButtonType="Button"  OnPageIndexChanging="OnPageIndexChanging" OnRowDataBound="OnRowDataBound" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="QCNDatasource" GridLines="Vertical" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="QCNID" PageSize="30">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="QCNID" DataNavigateUrlFormatString="QCNFormEdit.aspx?QCNID={0}" Text="Edit" ></asp:HyperLinkField>
            <asp:BoundField DataField="QCNID" HeaderText="QCNID" InsertVisible="False" ReadOnly="True" SortExpression="QCNID" Visible="False" />
            <asp:BoundField DataField="FacilityID" HeaderText="FacilityID" Visible="False" SortExpression="FacilityID" />
            <asp:BoundField DataField="FacilityName" HeaderText="Facility" SortExpression="FacilityName"  ItemStyle-Wrap="False"/>
            
            <asp:BoundField DataField="LocationID" HeaderText="LocationID" Visible="False" SortExpression="LocationID" />
            <asp:BoundField DataField="LocationName" HeaderText="Location" SortExpression="LocationName"  ItemStyle-Wrap="False"/>
            
            <asp:BoundField DataField="RequesterUserName" HeaderText="Requester" ReadOnly="True" SortExpression="RequesterUserName" />
            <asp:BoundField DataField="ApprovedBy" HeaderText="Approved By" ReadOnly="True" SortExpression="ApprovedBy" />
            <asp:BoundField DataField="AssignedUserName" HeaderText="Assigned To" ReadOnly="True" SortExpression="AssignedUserName" />
            <asp:BoundField DataField="AssignedLogin" HeaderText="AssignedLogin" ReadOnly="True" SortExpression="AssignedLogin"  Visible="False" />
            <asp:BoundField DataField="AssignedTitleName" HeaderText="Assigned Title" SortExpression="AssignedTitleName"  Visible="False" />
            
            <asp:BoundField DataField="QCNType" HeaderText="QCN Type" SortExpression="QCNType" />
            <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID"  Visible="True"/>
            <asp:BoundField DataField="ItemClinicalDescription" HeaderText="Item" SortExpression="ItemClinicalDescription" />
            <asp:BoundField DataField="Par" HeaderText="Par" SortExpression="Par"  DataFormatString="{0:###}"/>
            <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" Visible="false" />
            <asp:BoundField DataField="ManuNumName" HeaderText="Manuf Name/Num" SortExpression="ManuNumName"  Visible="False"/>
            <asp:BoundField DataField="DetailsText" HeaderText="DetailsText" SortExpression="DetailsText"  Visible="False"/>
            <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details"  Visible="False"/>
            <asp:BoundField DataField="UpdatesText" HeaderText="UpdatesText" SortExpression="UpdatesText"  Visible="False"/>
            <asp:BoundField DataField="Updates" HeaderText="Updates" SortExpression="Updates" />
            <asp:BoundField DataField="DaysOpen" HeaderText="Days Open" SortExpression="DaysOpen" />
            <asp:BoundField DataField="DateEntered" HeaderText="Date Entered" SortExpression="DateEntered" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="LastUpdated" HeaderText="Last Updated" SortExpression="LastUpdated" DataFormatString="{0:d}"/>
            
            <asp:BoundField DataField="DateCompleted" HeaderText="Date Completed" SortExpression="DateCompleted" DataFormatString="{0:d}"  Visible ="False"/>
            <asp:BoundField DataField="Status" HeaderText="QCN Status" SortExpression="Status" />
            <asp:BoundField DataField="Complexity" HeaderText="CX" SortExpression="Complexity" />
            <asp:BoundField runat="server" DataField="InternalReference" HeaderText="Reference" SortExpression="InternalReference" />
             <asp:TemplateField ShowHeader="False">
             <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this entry?');">Delete</asp:LinkButton>             
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#000084" ForeColor="Black" />
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

    <p>
        <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="~/img/ExportExcel.gif" OnClick="ExportToExcel" Height="25px" />
    </p>
    <p>
        &nbsp;</p>
    <p>
  
        <asp:SqlDataSource ID="QCNDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" 
                SelectCommand="exec sp_SelectQCN @FacilityName,@LocationName,@QCNStatusName,@Completed,@AssignedUserName" DeleteCommand="exec sp_DeleteQCN @QCNID">
            <SelectParameters>
                <asp:ControlParameter ControlID="AssignedSearchDD" PropertyName ="Text" DefaultValue="%" Name="AssignedUserName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="QCNStatusSearchDD" PropertyName ="Text" DefaultValue="%" Name="QCNStatusName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="QCNLocationS" PropertyName ="Text" DefaultValue="%" Name="LocationName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="QCNFacilityS" PropertyName ="Text" DefaultValue="%" Name="FacilityName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="CompletedCB" Name="Completed" PropertyName="Checked" /> 
            </SelectParameters>



        </asp:SqlDataSource>
</p>
</asp:TableCell>
    </asp:TableRow>
        </asp:Table> </asp:Panel>   
</asp:Content>


