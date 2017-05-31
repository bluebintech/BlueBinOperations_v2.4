<%@ Page Title="BlueBin Cones Deployed" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ConesDeployed.aspx.vb" Inherits="ConesDeployed" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>



<asp:Table ID="PageTable" runat="server" >
<asp:TableRow><asp:TableCell><h2><%: Title %></h2>
    <p>Welcome to the Cones Deployed Module.  Enter cones deployed and returned to the field for accurate Dashboard readings.</p>

              </asp:TableCell></asp:TableRow>
<asp:TableRow>
        <asp:TableCell>
          <div class="jumbotronmini" id="ConesDeployedUtility" runat="server">
          <asp:Table runat="server" >
        <asp:TableRow>
          <asp:TableCell>
              <asp:Table runat="server">
                  <asp:TableRow>

                 <asp:TableCell><b>Facility:</b>&nbsp;&nbsp;
                <asp:DropDownList ID="FacilityDD"  AppendDataBoundItems="true" runat="server" DataSourceID="FacilityDataSource" DataTextField="FacilityName" DataValueField="FacilityID"  AutoPostBack="True">
                <asp:ListItem Selected="True" Text = "--Select--" Value = "" ></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
            </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
              <asp:TableRow>
          <asp:TableCell><b>Location:</b>
                <asp:DropDownList ID="LocationDD"  AppendDataBoundItems="false" runat="server" DataSourceID="LocationSource" DataTextField="LocationName" DataValueField="LocationID"  AutoPostBack="True">
                <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
              </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
              <asp:TableRow>
          <asp:TableCell><b>Item:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ClinicalDescriptionDD" runat="server"  AppendDataBoundItems="false"  DataTextField="ExtendedDescription" DataValueField="ItemID" DataSourceID="ClinicalDSource" >
                    <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
        <asp:TableCell Width="15"></asp:TableCell>
              </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
              <asp:TableRow>
          <asp:TableCell><b>Expected Date:</b>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Please Enter Date the product is expected to arrive." />&nbsp;
                <asp:TextBox ID="ExpectedDeliveryTB" runat="server" DataFormatString="{0:d}" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
                  </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
              <asp:TableRow>
          <asp:TableCell><b>Sub Product:</b>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Tooltip Text" />&nbsp;
                <asp:DropDownList ID="SubProductDD"  runat="server" DataTextField="SubProduct" DataValueField="SubProduct"  AutoPostBack="False">
                <asp:ListItem Selected = "True" Text = "Yes" Value = "Yes"></asp:ListItem>
                    <asp:ListItem Text = "No" Value = "No"></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
                  </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>

              <asp:TableRow>
              <%--<asp:TableCell><asp:Button ID="DocumentInsert" class="btn btn-primary btn-lg" runat="server" Text="Deploy" OnClientClick="ConeDeployed_Click"></asp:Button></asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>--%>
              
          </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>    
          <asp:TableRow>  
            <asp:TableCell><asp:Label ID="lblMessage" runat="server" Text="" Font-Names = "Arial"></asp:Label> </asp:TableCell>
            </asp:TableRow>
</asp:Table>

          </asp:TableCell>
            <asp:TableCell Width="15"></asp:TableCell>
            <asp:TableCell><b>Details:</b>&nbsp;<asp:TextBox runat="server" TextMode="MultiLine" ID="DetailsTB" Height="120" Width="200" MaxLength="255"></asp:TextBox></asp:TableCell>
            <asp:TableCell Width="15"></asp:TableCell>
            <asp:TableCell><asp:ImageButton ID="ConesDeployed" runat="server" OnClientClick="ConesDeployed_Click" ImageUrl="~/img/conearrow.png"></asp:ImageButton></asp:TableCell>
        </asp:TableRow>


           </asp:Table></div>                     
      </asp:TableCell>

    </asp:TableRow>  

    
<asp:TableRow Height="15"></asp:TableRow>
  <asp:TableRow><asp:TableCell>
        <asp:Table runat="server" ID="SearchTable">
                <asp:TableRow><asp:TableCell><asp:Label runat="server" id="LocationL">Location:&nbsp;</asp:Label></asp:TableCell><asp:TableCell><asp:TextBox ID="LocationSB" runat="server" Width="200px"></asp:TextBox></asp:TableCell></asp:TableRow>
            <asp:TableRow Height="5px"></asp:TableRow>
                <asp:TableRow><asp:TableCell><asp:Label runat="server" id="ItemL">Item:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Label></asp:TableCell><asp:TableCell><asp:TextBox ID="ItemSB" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:Button ID="SearchButton"  runat="server" Text="Search" /> &nbsp;&nbsp;</asp:TableCell></asp:TableRow>
             
                
            <asp:TableRow Height="15px"></asp:TableRow>
            </asp:Table>
    </asp:TableCell></asp:TableRow>
    
      

<asp:TableRow>
<asp:TableCell Width="500px"  >
    <asp:GridView ID="GridViewCones" CssClass="GridViewitem" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" DataSourceID="ConesDataSource" AutoGenerateColumns="False" DataKeyNames="ConesDeployedID" AllowSorting="True" AllowPaging="True" ShowFooter="True" PageSize="30">
        <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>

        <Columns>
            
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton runat="server" Text="Update" CommandName="Update" CausesValidation="True" ID="Button1"></asp:LinkButton><br />
                    <asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="False" ID="Button2"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CausesValidation="False" ID="Button1"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ConesDeployedID" HeaderText="ConesDeployedID" Visible="False" SortExpression="ConesDeployedID" />
            <asp:TemplateField HeaderText="Deployed" InsertVisible="False" SortExpression="Deployed">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Deployed", "{0:d}") %>' ID="LabelDeployed"  DataFormatString="{0:d}"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Deployed", "{0:d}") %>' ID="LabelDeployed"  DataFormatString="{0:d}"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delivery" InsertVisible="False" SortExpression="ExpectedDelivery" >
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TBDelivery"  Text='<%# Bind("ExpectedDelivery", "{0:d}") %>'  DataFormatString="{0:d}" Width="85" ></asp:TextBox>
                        <asp:RangeValidator ID ="rvDate" runat ="server" ControlToValidate="TBDelivery" ErrorMessage="Invalid Date" Width="85" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2100" Display="Dynamic" Font-Italic="True"></asp:RangeValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("ExpectedDelivery", "{0:d}") %>'  DataFormatString="{0:d}" ID="Label2" ></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FacilityID" HeaderText="FacilityID" Visible="False" SortExpression="FacilityID" />
            <asp:TemplateField HeaderText="Facility" InsertVisible="False" SortExpression="FacilityName">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("FacilityName") %>' ID="LFacilityName"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("FacilityName") %>' ID="LFacilityName"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LocationID" HeaderText="LocationID" SortExpression="LocationID" Visible="False" />
            <asp:TemplateField HeaderText="Location" InsertVisible="False" SortExpression="LocationName">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("LocationName") %>' ID="LFLocationName" Width="100"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("LocationName") %>' ID="LLocationName"  Width="100"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item" InsertVisible="False" SortExpression="ItemID">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("ItemID") %>' ID="LItemID"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("ItemID") %>' ID="LItemID"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="Item Description" InsertVisible="False" SortExpression="ItemDescription">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("ItemDescription") %>' ID="LItemDescription"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("ItemDescription") %>' ID="LItemDescription"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="Sub" InsertVisible="False" SortExpression="SubProduct">
                <EditItemTemplate>
                    <asp:DropDownList runat="server"  AutoPostBack="False" ID="SubProductDD" SelectedValue=<%#Bind("SubProduct")%>>
                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                        <asp:ListItem Value="No">No</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("SubProduct") %>' ID="LSubProduct"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="Sequence" InsertVisible="False" SortExpression="BinSequence">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("BinSequence") %>' ID="LBinSequence" ItemStyle-Wrap="False"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("BinSequence") %>' ID="LBinSequence" ItemStyle-Wrap="False"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Stockout" InsertVisible="False" SortExpression="DashboardStockout">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("DashboardStockout") %>' ID="LDashboardStockout" ItemStyle-Wrap="False"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("DashboardStockout") %>' ID="LDashboardStockout" ItemStyle-Wrap="False"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Details" SortExpression="DetailsText">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("DetailsText") %>' ID="EditDetailsText" ItemStyle-Wrap="True" Height="120" Width="200" TextMode="MultiLine"></asp:TextBox>
                 </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Details") %>' ID="IDetailsText" ToolTip='<%# Bind("DetailsText") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


             <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="ReturnConeB" class ="btn btn-primary btn-sm" runat="server" Text="Return Cone" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to mark this cone as returned?');"></asp:Button>
                </ItemTemplate>
                 <EditItemTemplate>
                    <asp:Button ID="ReturnConeB" class ="btn btn-primary btn-sm" runat="server" Text="Return Cone" CausesValidation="False" Visible="False"></asp:Button>
                </EditItemTemplate>
            </asp:TemplateField>
            

        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black"></FooterStyle>
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White"></HeaderStyle>
        <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>
        <RowStyle BackColor="#EEEEEE" ForeColor="Black"></RowStyle>
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
        <SortedAscendingHeaderStyle BackColor="#0000A9"></SortedAscendingHeaderStyle>
        <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
        <SortedDescendingHeaderStyle BackColor="#000065"></SortedDescendingHeaderStyle>
    </asp:GridView>
 

</asp:TableCell> </asp:TableRow>

            
        


        <asp:TableRow Height="15px"></asp:TableRow>
        <asp:TableRow><asp:TableCell> 
            <asp:ImageButton ID="ExportCones" runat="Server" ImageUrl="~/img/ExportExcel.gif" OnClick="ExportToExcelCones" Height="25px" CausesValidation="False" />
                                                                 </asp:TableCell> </asp:TableRow>  
    </asp:Table>
  

<p>
       
         <p>
        <asp:SqlDataSource runat="server" ID="ConesDataSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' 
            DeleteCommand="exec sp_EditConesDeployed @ConesDeployedID" 
            SelectCommand="exec sp_SelectConesDeployed @Location,@Item" 
            UpdateCommand="exec sp_EditConesDetail @ConesDeployedID,@DetailsText,@ExpectedDelivery,@SubProduct">
        <DeleteParameters>
            <asp:Parameter Name="ConesDeployedID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="ConesDeployedID" Type="Int32"></asp:Parameter>
             <asp:Parameter Name="DetailsText" Type="String"></asp:Parameter>
            <asp:Parameter Name="ExpectedDelivery" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="SubProduct" Type="String"></asp:Parameter>
        </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="LocationSB" Name="Location" PropertyName="Text" DefaultValue="%"  />
                <asp:ControlParameter ControlID="ItemSB" Name="Item" PropertyName="Text" DefaultValue="%"  />
            </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="FacilityDataSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectFacilities"></asp:SqlDataSource>
             


        <asp:SqlDataSource ID="LocationSource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" 
            SelectCommand="exec sp_SelectLocationCascade 'No'" FilterExpression="FacilityID = '{0}'" >
                <FilterParameters>
                    <asp:ControlParameter Name="FacilityID" ControlID="FacilityDD" PropertyName="SelectedValue" />
                </FilterParameters>       
        </asp:SqlDataSource>      
        <asp:SqlDataSource ID="ClinicalDSource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" 
            SelectCommand="exec sp_SelectConesLocation"  FilterExpression="LocationID = '{0}'" >
        <FilterParameters>
        <asp:ControlParameter Name="LocationID" ControlID="LocationDD" PropertyName="SelectedValue" />
        </FilterParameters>
        </asp:SqlDataSource>
         </p>

   
     
</asp:Content>