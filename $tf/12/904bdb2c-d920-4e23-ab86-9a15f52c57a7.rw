<%@ Page Title="Time Study Home" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TimeStudy.aspx.vb" Inherits="TimeStudy" %>


    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<asp:Table ID="PageTable" runat="server" Width="1000px">
<asp:TableRow><asp:TableCell><h2><%: Title %></h2>
<p>Welcome to the Time Study Module Home Page.  Please Use the buttons below to select the details for Times in each SubModule or open a new Time Study.</p>
    <p>
            <asp:LinkButton ID="StageScanB" runat="server" class="btn btn-default">Stage Scan Times</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="BinFillB" runat="server" class="btn btn-default">Stage Bin Fill Times</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="NodeServiceB" runat="server" class="btn btn-default">Node Service Times</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="StockOutB" runat="server" class="btn btn-default">Stock Out Process</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="GroupConfigB" runat="server" class="btn btn-default">Group Config</asp:LinkButton>&nbsp;
            
            
        </p>
        <%--<p>
            <asp:LinkButton ID="StageScanB2" runat="server" class="btn btn-primary btn-sm">New Stage Scan Form</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="BinFillB2" runat="server" class="btn btn-primary btn-sm">New Stage Bin Fill Form</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="NodeServiceB2" runat="server" class="btn btn-primary btn-sm">New Node Service Form</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="StockOutB2" runat="server" class="btn btn-primary btn-sm">New Stock Out Form</asp:LinkButton>&nbsp;
            
            
        </p>--%>
</asp:TableCell></asp:TableRow>
<asp:TableRow Height="10"></asp:TableRow>
    
<%-- Titles --%>
    <asp:TableRow><asp:TableCell>
        <asp:Label runat="server" id="hiddenStageScan" Visible="False"><h3>Stage Scanning Time Studies</h3></asp:Label>
        <asp:Label runat="server" id="hiddenBinFill" Visible="False"><h3>BinFill Time Studies</h3></asp:Label>
        <asp:Label runat="server" id="hiddenNodeService" Visible="False"><h3>Node Service Time Studies</h3></asp:Label>
        <asp:Label runat="server" id="hiddenStockOut" Visible="False"><h3>Stock Out Time Studies</h3></asp:Label>
        <asp:Label runat="server" id="HiddenGroupConfig" Visible="False"><h3>Time Study Group Configuration</h3></asp:Label>
    </asp:TableCell></asp:TableRow>

    <%-- Entry Forms Studies --%>
    <asp:TableRow>
        <asp:TableCell>
          <div class="jumbotronmini" id="TimeStudyUtility" runat="server">
          <asp:Table runat="server" >
        <asp:TableRow>
          <asp:TableCell>
              <asp:Table runat="server">
                  <asp:TableRow>

                <asp:TableCell><b>Facility:</b>&nbsp;&nbsp;
                <asp:DropDownList ID="FacilityDD"  AppendDataBoundItems="true" runat="server" DataSourceID="FacilityDataSource" DataTextField="FacilityName" DataValueField="FacilityID"  AutoPostBack="True">
                <asp:ListItem Text = "--Select--" Value = ""></asp:ListItem>
                </asp:DropDownList>
                     <asp:SqlDataSource runat="server" ID="FacilityDataSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectFacilities"></asp:SqlDataSource>
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorFacility" ControlToValidate="FacilityDD" runat="server" ForeColor="Red"  ErrorMessage="*" Font-Size="X-Small" ValidationGroup="MainGroup"></asp:RequiredFieldValidator>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
            </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
              
          <asp:TableRow ID="LocationRow" runat="server">
          <asp:TableCell><b>Location:</b>
                <asp:DropDownList ID="LocationDD"  AppendDataBoundItems="false" runat="server" DataSourceID="LocationSource" DataTextField="LocationName" DataValueField="LocationID">
                <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>
                </asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="LocationSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>'
                        SelectCommand="exec sp_SelectLocationCascade 'No'"  FilterExpression="FacilityID = '{0}'" >
                <FilterParameters>
                    <asp:ControlParameter Name="FacilityID" ControlID="FacilityDD" PropertyName="SelectedValue" />
                </FilterParameters>
                    </asp:SqlDataSource>
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorLocation" ControlToValidate="LocationDD" runat="server" ForeColor="Red"  ErrorMessage="*" Font-Size="X-Small" ValidationGroup="MainGroup"></asp:RequiredFieldValidator>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
              </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
        <asp:TableRow>
          <asp:TableCell><b>Service Tech:</b>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="If applicable, set Name of Strider/Service Tech performing the actions." />&nbsp;
                <asp:DropDownList ID="ServiceTechDD"  AppendDataBoundItems="true" runat="server" DataSourceID="ServiceTechSource" DataTextField="FullName" DataValueField="BlueBinResourceID">
                    <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>
                </asp:DropDownList>
              <asp:SqlDataSource ID="ServiceTechSource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" SelectCommand="exec sp_SelectGembaShadow"></asp:SqlDataSource>
          </asp:TableCell>
        <asp:TableCell Width="15"></asp:TableCell>
              </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
        <asp:TableRow>
          <asp:TableCell><b>SKUs:</b>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Please Enter the Number of SKUs as part of TimeStudy for the Node." />&nbsp;
                <asp:TextBox ID="SKUsTB" runat="server" Width="30"></asp:TextBox> 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="SKUsTB" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+" BackColor="Red"></asp:RegularExpressionValidator>   
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorSKUs" ControlToValidate="SKUsTB" runat="server" ForeColor="Red"  ErrorMessage="*" Font-Size="X-Small" ValidationGroup="MainGroup"></asp:RequiredFieldValidator>
                </asp:TableCell>
        <asp:TableCell Width="15"></asp:TableCell>
              </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
        <asp:TableRow ID="StockOutProcessRow" runat="server">
          <asp:TableCell><b>Process Type:&nbsp;</b>
                <asp:DropDownList ID="StockOutProcessDD"  AppendDataBoundItems="true" runat="server" DataSourceID="StockOutProcessSource" DataTextField="ConfigValue" DataValueField="ConfigID">
                <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>
                </asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="StockOutProcessSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectConfigDetail 'TimeStudy','Double Bin StockOut'"></asp:SqlDataSource>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
              </asp:TableRow>
         <asp:TableRow ID="NodeServiceProcessRow" runat="server">
          <asp:TableCell><b>Process:&nbsp;</b>
                <asp:DropDownList ID="NodeServiceProcessDD"  AppendDataBoundItems="true" runat="server" DataSourceID="NodeServiceProcessSource" DataTextField="ConfigValue" DataValueField="ConfigID">
                <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>
                </asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="NodeServiceProcessSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectConfigDetail 'TimeStudy','Node Service'"></asp:SqlDataSource>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
              </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
          <asp:TableRow ID="TravelLocationRow" runat="server">
          <asp:TableCell><b>Travel To:</b>
                <asp:DropDownList ID="TravelLocationDD"  AppendDataBoundItems="true" runat="server" DataSourceID="TravelLocationSource" DataTextField="LocationName" DataValueField="LocationID">
                <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>
                </asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="TravelLocationSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectLocation"></asp:SqlDataSource>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
              </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
              
              
        
        </asp:Table></asp:TableCell>
            <asp:TableCell Width="15"></asp:TableCell>
                <asp:TableCell>
                        <asp:Table runat="server">
                            <asp:TableRow>
                                  <asp:TableCell><b>Start Time:</b>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Please Enter Start Time." />&nbsp;
                                        <asp:TextBox ID="StartTimeTB" runat="server" TextMode="Time"></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorStart" ControlToValidate="StartTimeTB" runat="server" ForeColor="Red"  ErrorMessage="*" Font-Size="X-Small" ValidationGroup="MainGroup"></asp:RequiredFieldValidator>
                                  </asp:TableCell>
                             </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
                             <asp:TableRow>
                                  <asp:TableCell><b>Stop Time:</b>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Please Enter Stop Time." />&nbsp;
                                        <asp:TextBox ID="StopTimeTB" runat="server" TextMode="Time"></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorStop" ControlToValidate="StopTimeTB" runat="server" ForeColor="Red"  ErrorMessage="*" Font-Size="X-Small" ValidationGroup="MainGroup"></asp:RequiredFieldValidator>
                                   </asp:TableCell>
                             </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
                             
                            <asp:TableRow>
                                <asp:TableCell>
                                    <b>Comments:</b>&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" TextMode="MultiLine" ID="CommentsTB" Height="70" Width="200" MaxLength="255"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                </asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ID="NodeServiceSubmitB" runat="server" OnClientClick="NodeServiceSubmitB_Click" ImageUrl="~/img/bbtimestudy.png" ValidationGroup="ValidationGroup"></asp:ImageButton>
                    <asp:ImageButton ID="StageScanSubmitB" runat="server" OnClientClick="StageScanSubmitB_Click" ImageUrl="~/img/bbtimestudy.png"></asp:ImageButton>
                    <asp:ImageButton ID="BinFillSubmitB" runat="server" OnClientClick="BinFillSubmitB_Click" ImageUrl="~/img/bbtimestudy.png"></asp:ImageButton>
                    <asp:ImageButton ID="StockOutSubmitB" runat="server" OnClientClick="StockOutSubmitB_Click" ImageUrl="~/img/bbtimestudy.png"></asp:ImageButton>
                    
                </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                  <asp:Label ID="TimeStudyMessageL" runat="server" Text ="" Font-Size="Smaller" Font-Bold="True" ForeColor="Red"  />                 
            </asp:TableCell>
            </asp:TableRow>

           </asp:Table></div>                     
      </asp:TableCell>

    </asp:TableRow>  
<%-- END--%>

<%-- Entry Forms Groups --%>
    <asp:TableRow>
        <asp:TableCell>
          <div class="jumbotronmini" id="GroupConfigUtility" runat="server">
          <asp:Table runat="server" >
        <asp:TableRow>
          <asp:TableCell>
              <asp:Table runat="server">
                  <asp:TableRow>

          <asp:TableCell><b>Facility:</b>&nbsp;&nbsp;
                <asp:DropDownList ID="GroupFacilityDD"  AppendDataBoundItems="true" runat="server" DataSourceID="GroupFacilityDataSource" DataTextField="FacilityName" DataValueField="FacilityID"  AutoPostBack="True">
                <asp:ListItem Text = "--Select--" Value = ""></asp:ListItem>
                </asp:DropDownList>
                     <asp:SqlDataSource runat="server" ID="GroupFacilityDataSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectFacilities"></asp:SqlDataSource>
                <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorGroupFacility" ControlToValidate="GroupFacilityDD" runat="server" ForeColor="Red"  ErrorMessage="*" Font-Size="X-Small" ValidationGroup="GroupConfig"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
            </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
              
          <asp:TableRow>
          <asp:TableCell><b>Location:</b>
                <asp:DropDownList ID="GroupLocationDD"  AppendDataBoundItems="false" runat="server" DataSourceID="GroupLocationSource" DataTextField="LocationName" DataValueField="LocationID">
                <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>
                </asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="GroupLocationSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>'
                        SelectCommand="exec sp_SelectLocationCascade 'No'"  FilterExpression="FacilityID = '{0}'" >
                <FilterParameters>
                    <asp:ControlParameter Name="FacilityID" ControlID="GroupFacilityDD" PropertyName="SelectedValue" />
                </FilterParameters>
                    </asp:SqlDataSource>
                <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorGroupLocation" ControlToValidate="GroupLocationDD" runat="server" ForeColor="Red"  ErrorMessage="*" Font-Size="X-Small" ValidationGroup="GroupConfig"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
         <asp:TableCell Width="15"></asp:TableCell>
              </asp:TableRow>
        </asp:Table></asp:TableCell>
            <asp:TableCell Width="15"></asp:TableCell>
                <asp:TableCell>
                        <asp:Table runat="server">
                             <asp:TableRow ID="GroupConfigRow" runat="server">
                                  <asp:TableCell><b>Group Name:</b>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Please Enter the Group Name for this Location.  If possible, match to an existing" />&nbsp;
                                        <asp:TextBox ID="GroupConfigTB" runat="server" Width="180"></asp:TextBox> 
                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorGroupName" ControlToValidate="GroupConfigTB" runat="server" ForeColor="Red"  ErrorMessage="*" Font-Size="X-Small" ValidationGroup="GroupConfig"></asp:RequiredFieldValidator>--%>
                                        </asp:TableCell>
                                <asp:TableCell Width="15"></asp:TableCell>
                                      </asp:TableRow><asp:TableRow Height ="5"></asp:TableRow>
                            <asp:TableRow ID="DescriptionRow" runat="server">
                                <asp:TableCell>
                                    <b>Description:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" TextMode="MultiLine" ID="DescriptionTB" Height="40" Width="200" MaxLength="255"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                </asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ID="GroupConfigSubmitB" runat="server" OnClientClick="GroupConfigSubmitB_Click" ImageUrl="~/img/bbtimestudy.png"></asp:ImageButton>
                </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                  <asp:Label ID="GroupConfigMessageL" runat="server" Text ="" Font-Size="Smaller" Font-Bold="True" ForeColor="Red"  />                 
            </asp:TableCell>
            </asp:TableRow>

           </asp:Table></div>                     
      </asp:TableCell>

    </asp:TableRow>  
<%-- END--%>

<%-- Search Boxes --%>
<asp:TableRow Height="10"></asp:TableRow>
    <asp:TableRow><asp:TableCell>
        <asp:Table runat="server" ID="SearchTable">
                <asp:TableRow>
                <asp:TableCell>
                    <p>
                    <b>Facility:</b>&nbsp;
                        <asp:DropDownList ID="FacilityS" AppendDataBoundItems="true" runat="server" DataSourceID="FacilityDS" DataTextField="FacilityName" DataValueField="FacilityName">
                                    <asp:ListItem Selected = "True" Text = "All" Value = ""></asp:ListItem>
                                </asp:DropDownList>
           
                             <asp:SqlDataSource runat="server" ID="FacilityDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectFacilities"></asp:SqlDataSource>
                     </p>   
                    <p>
                    <b>Location:</b>&nbsp;
                        <asp:DropDownList ID="LocationS" AppendDataBoundItems="true" runat="server" DataSourceID="LocationDS" DataTextField="LocationName" DataValueField="LocationName">
                                    <asp:ListItem Selected = "True" Text = "All" Value = ""></asp:ListItem>
                                </asp:DropDownList>
           
                             <asp:SqlDataSource runat="server" ID="LocationDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectLocation"></asp:SqlDataSource>
                        
     
                            </p>
                    <p>     
                    <b>User:</b>&nbsp;
	                        <asp:DropDownList ID="UserSearchDD" AppendDataBoundItems="true" runat="server" DataSourceID="UserSearchDS" DataTextField="Name" DataValueField="Name">
                                    <asp:ListItem Selected = "True" Text = "All" Value = ""></asp:ListItem>
                                </asp:DropDownList>
           
                             <asp:SqlDataSource runat="server" ID="UserSearchDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectUsersShort"></asp:SqlDataSource>
                         </p>
                    <p>
                    <b>Most Recent:</b>&nbsp;&nbsp;
                        <asp:DropDownList ID="MostRecentSearchDD" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Selected = "True" Text = "All" Value = "2"></asp:ListItem>
                                    <asp:ListItem Text = "Yes" Value = "1"></asp:ListItem>
                                    <asp:ListItem Text = "No" Value = "0"></asp:ListItem>
                                </asp:DropDownList>
           
                            </p> 
                    <p>
                        <asp:Button ID="SearchButton"  runat="server" Text="Search" /> 
                    </p> 
                    


                </asp:TableCell>
                </asp:TableRow>
                        </asp:Table>
    </asp:TableCell></asp:TableRow>

<%-- Search Boxes Group Config --%>
<asp:TableRow Height="10"></asp:TableRow>
    <asp:TableRow><asp:TableCell>
        <asp:Table runat="server" ID="SearchTableGroupConfig">
                <asp:TableRow>
                <asp:TableCell>
                    <p>
                    <b>Facility:</b>&nbsp;
                        <asp:DropDownList ID="FacilityGroupS" AppendDataBoundItems="true" runat="server" DataSourceID="FacilityGroupDS" DataTextField="FacilityName" DataValueField="FacilityName">
                                    <asp:ListItem Selected = "True" Text = "All" Value = ""></asp:ListItem>
                                </asp:DropDownList>
           
                             <asp:SqlDataSource runat="server" ID="FacilityGroupDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectFacilities"></asp:SqlDataSource>
                     </p>   
                    <p>
                    <b>Location:</b>&nbsp;
                        <asp:DropDownList ID="LocationGroupS" AppendDataBoundItems="true" runat="server" DataSourceID="LocationGroupDS" DataTextField="LocationName" DataValueField="LocationName">
                                    <asp:ListItem Selected = "True" Text = "All" Value = ""></asp:ListItem>
                                </asp:DropDownList>
           
                             <asp:SqlDataSource runat="server" ID="LocationGroupDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectLocation"></asp:SqlDataSource>
                        
     
                            </p>
                    <p>
                    <b>Group Name:</b>&nbsp;&nbsp;
                        <asp:DropDownList ID="GroupNameS" AppendDataBoundItems="true" runat="server" DataSourceID="GroupNameDS" DataTextField="GroupName" DataValueField="GroupName">
                                    <asp:ListItem Selected = "True" Text = "All" Value = ""></asp:ListItem>
                                </asp:DropDownList>
           
                        <asp:SqlDataSource runat="server" ID="GroupNameDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectTimeStudyGroupNames"></asp:SqlDataSource>
           
                            </p> 
                    <p>
                        <asp:Button ID="SearchButtonGroupConfig"  runat="server" Text="Search" /> 
                    </p> 
                    


                </asp:TableCell>
                </asp:TableRow>
                        </asp:Table>
    </asp:TableCell></asp:TableRow>



<%-- StageScanGridview --%>
        <asp:TableRow>
        <asp:TableCell Width="500px"  >

        <asp:GridView  CssClass="GridViewitem" ID="GridViewStageScan" ButtonType="Button" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="StageScanDS" GridLines="Vertical" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="TimeStudyStageScanID" PageSize="30">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <%--<asp:HyperLinkField DataNavigateUrlFields="TimeStudyStageScanID" DataNavigateUrlFormatString="TimeStudyStageScan.aspx?TimeStudyStageScanID={0}" Text="Edit" ></asp:HyperLinkField>--%>

            
            <asp:BoundField DataField="TimeStudy" HeaderText="Type" SortExpression="TimeStudy"  ItemStyle-Wrap="False"/>
            <asp:BoundField DataField="TimeStudyStageScanID" HeaderText="TimeStudyStageScanID" InsertVisible="False" ReadOnly="True" SortExpression="TimeStudyStageScanID" Visible="False" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="FacilityName" HeaderText="Facility" SortExpression="FacilityName"  ItemStyle-Wrap="False"/>
            <asp:BoundField DataField="LocationID" HeaderText="LocationID" Visible="False" SortExpression="LocationID" />
            <asp:BoundField DataField="LocationName" HeaderText="Location" SortExpression="LocationName"  ItemStyle-Wrap="False"/>
            
            <asp:BoundField DataField="SubmittedBy" HeaderText="Submitted By" ReadOnly="True" SortExpression="SubmittedBy" />
            <asp:BoundField DataField="ServiceTech" HeaderText="Service Tech" ReadOnly="True" SortExpression="ServiceTech" />
            <asp:BoundField DataField="MostRecent" HeaderText="Most Recent" ReadOnly="True" SortExpression="MostRecent" />
            <asp:BoundField DataField="SKUS" HeaderText="# SKUS" ReadOnly="True" SortExpression="SKUS" />
            <asp:BoundField DataField="Seconds" HeaderText="Seconds" ReadOnly="True" SortExpression="Seconds"  Visible="True" />
            <asp:BoundField DataField="Minutes" HeaderText="Minutes" SortExpression="Minutes"  Visible="True" />
            
             <asp:TemplateField ShowHeader="False">
             <ItemTemplate>
            <asp:LinkButton ID="StageScanLB" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this entry?');">Delete</asp:LinkButton>             
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
 

        </asp:TableCell> </asp:TableRow>


        <asp:TableRow><asp:TableCell>
        <asp:ImageButton ID="ExportStageScan" runat="Server" ImageUrl="~/img/ExportExcel.gif" OnClick="ExportToExcelStageScan" Height="25px" CausesValidation="False" />

        </asp:TableCell></asp:TableRow>

<%-- END --%>
       
<%-- BinFillGridview --%>
        <asp:TableRow>
        <asp:TableCell Width="500px"  >

        <asp:GridView  CssClass="GridViewitem" ID="GridViewBinFill" ButtonType="Button" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="BinFillDS" GridLines="Vertical" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="TimeStudyBinFillID" PageSize="30">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
 <%--           <asp:HyperLinkField DataNavigateUrlFields="TimeStudyBinFillID" DataNavigateUrlFormatString="TimeStudyBinFill.aspx?TimeStudyBinFillID={0}" Text="Edit" ></asp:HyperLinkField>--%>

            
            
            <asp:BoundField DataField="TimeStudy" HeaderText="Type" SortExpression="TimeStudy"  ItemStyle-Wrap="False"/>
            <asp:BoundField DataField="TimeStudyBinFillID" HeaderText="TimeStudyBinFillID" InsertVisible="False" ReadOnly="True" SortExpression="TimeStudyBinFillID" Visible="False" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="FacilityName" HeaderText="Facility" SortExpression="FacilityName"  ItemStyle-Wrap="False"/>
            <asp:BoundField DataField="LocationID" HeaderText="LocationID" Visible="False" SortExpression="LocationID" />
            <asp:BoundField DataField="LocationName" HeaderText="Location" SortExpression="LocationName"  ItemStyle-Wrap="False"/>
            
            <asp:BoundField DataField="SubmittedBy" HeaderText="Submitted By" ReadOnly="True" SortExpression="SubmittedBy" />
            <asp:BoundField DataField="ServiceTech" HeaderText="Service Tech" ReadOnly="True" SortExpression="ServiceTech" />
            <asp:BoundField DataField="MostRecent" HeaderText="Most Recent" ReadOnly="True" SortExpression="MostRecent" />
            <asp:BoundField DataField="SKUS" HeaderText="# SKUS" ReadOnly="True" SortExpression="SKUS" />
            <asp:BoundField DataField="Seconds" HeaderText="Seconds" ReadOnly="True" SortExpression="Seconds"  Visible="True" />
            <asp:BoundField DataField="Minutes" HeaderText="Minutes" SortExpression="Minutes"  Visible="True" />
            
             <asp:TemplateField ShowHeader="False">
             <ItemTemplate>
            <asp:LinkButton ID="BinFillLB" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this entry?');">Delete</asp:LinkButton>             
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


        </asp:TableCell> </asp:TableRow>


        <asp:TableRow><asp:TableCell>
        <asp:ImageButton ID="ExportBinFill" runat="Server" ImageUrl="~/img/ExportExcel.gif" OnClick="ExportToExcelBinFill" Height="25px" CausesValidation="False" />

        </asp:TableCell></asp:TableRow>


<%-- END --%>                
            
<%-- NodeServiceGridview --%>
        <asp:TableRow>
        <asp:TableCell Width="500px"  >

        <asp:GridView  CssClass="GridViewitem" ID="GridViewNodeService" ButtonType="Button" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="NodeServiceDS" GridLines="Vertical" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="TimeStudyNodeServiceID" PageSize="30">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
<%--            <asp:HyperLinkField DataNavigateUrlFields="TimeStudyNodeServiceID" DataNavigateUrlFormatString="TimeStudyNodeService.aspx?TimeStudyNodeServiceID={0}" Text="Edit" ></asp:HyperLinkField>

            --%>
            
            <asp:BoundField DataField="TimeStudy" HeaderText="Type" SortExpression="TimeStudy"  ItemStyle-Wrap="False"/>
            <asp:BoundField DataField="TimeStudyNodeServiceID" HeaderText="TimeStudyNodeServiceID" InsertVisible="False" ReadOnly="True" SortExpression="TimeStudyNodeServiceID" Visible="False" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="FacilityName" HeaderText="Facility" SortExpression="FacilityName"  ItemStyle-Wrap="False"/>
            <asp:BoundField DataField="LocationID" HeaderText="LocationID" Visible="False" SortExpression="LocationID" />
            <asp:BoundField DataField="LocationName" HeaderText="Location" SortExpression="LocationName"  ItemStyle-Wrap="False"/>
            
            <asp:BoundField DataField="SubmittedBy" HeaderText="Submitted By" ReadOnly="True" SortExpression="SubmittedBy" />
            <asp:BoundField DataField="ServiceTech" HeaderText="Service Tech" ReadOnly="True" SortExpression="ServiceTech" />
            <asp:BoundField DataField="MostRecent" HeaderText="Most Recent" ReadOnly="True" SortExpression="MostRecent" />
            <asp:BoundField DataField="ProcessName" HeaderText="Process" ReadOnly="True" SortExpression="ProcessName" />
            <asp:BoundField DataField="SKUS" HeaderText="# SKUS" ReadOnly="True" SortExpression="SKUS" />
            <asp:BoundField DataField="TravelLocationID" HeaderText="TravelLocationID" Visible="False" SortExpression="LocationID" />
            <asp:BoundField DataField="TravelLocationName" HeaderText="Travel To" SortExpression="TravelLocationName"  ItemStyle-Wrap="False"/>
            <asp:BoundField DataField="Seconds" HeaderText="Seconds" ReadOnly="True" SortExpression="Seconds"  Visible="True" />
            <asp:BoundField DataField="Minutes" HeaderText="Minutes" SortExpression="Minutes"  Visible="True" />
            
             <asp:TemplateField ShowHeader="False">
             <ItemTemplate>
            <asp:LinkButton ID="NodeServiceLB" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this entry?');">Delete</asp:LinkButton>             
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

        </asp:TableCell> </asp:TableRow>
 

        <asp:TableRow><asp:TableCell>
        <asp:ImageButton ID="ExportNodeService" runat="Server" ImageUrl="~/img/ExportExcel.gif" OnClick="ExportToExcelNodeService" Height="25px" CausesValidation="False" />

        </asp:TableCell></asp:TableRow>

<%-- END --%>
<%-- StockOutGridview --%>
        <asp:TableRow>
        <asp:TableCell Width="500px"  >

        <asp:GridView  CssClass="GridViewitem" ID="GridViewStockOut" ButtonType="Button" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="StockOutDS" GridLines="Vertical" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="TimeStudyStockOutID" PageSize="30">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
<%--            <asp:HyperLinkField DataNavigateUrlFields="TimeStudyStockOutID" DataNavigateUrlFormatString="TimeStudyStockOut.aspx?TimeStudyStockOutID={0}" Text="Edit" ></asp:HyperLinkField>

            --%>
            
            <asp:BoundField DataField="TimeStudy" HeaderText="Type" SortExpression="TimeStudy"  ItemStyle-Wrap="False"/>
            <asp:BoundField DataField="TimeStudyStockOutID" HeaderText="TimeStudyStockOutID" InsertVisible="False" ReadOnly="True" SortExpression="TimeStudyStockOutID" Visible="False" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="FacilityName" HeaderText="Facility" SortExpression="FacilityName"  ItemStyle-Wrap="False"/>
            <asp:BoundField DataField="LocationID" HeaderText="LocationID" Visible="False" SortExpression="LocationID"  />
            <asp:BoundField DataField="LocationName" HeaderText="Location" SortExpression="LocationName"  ItemStyle-Wrap="False"  Visible="False"/>
            
            <asp:BoundField DataField="SubmittedBy" HeaderText="Submitted By" ReadOnly="True" SortExpression="SubmittedBy" />
            <asp:BoundField DataField="ServiceTech" HeaderText="Service Tech" ReadOnly="True" SortExpression="ServiceTech" />
            <asp:BoundField DataField="MostRecent" HeaderText="Most Recent" ReadOnly="True" SortExpression="MostRecent" />
            <asp:BoundField DataField="ProcessName" HeaderText="Process" ReadOnly="True" SortExpression="ProcessName" />
            <asp:BoundField DataField="SKUS" HeaderText="# SKUS" ReadOnly="True" SortExpression="SKUS" />
            <asp:BoundField DataField="Seconds" HeaderText="Seconds" ReadOnly="True" SortExpression="Seconds"  Visible="True" />
            <asp:BoundField DataField="Minutes" HeaderText="Minutes" SortExpression="Minutes"  Visible="True" />
            
             <asp:TemplateField ShowHeader="False">
             <ItemTemplate>
            <asp:LinkButton ID="StockOutLB" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this entry?');">Delete</asp:LinkButton>             
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
 

        </asp:TableCell> </asp:TableRow>


        <asp:TableRow><asp:TableCell>
        <asp:ImageButton ID="ExportStockOut" runat="Server" ImageUrl="~/img/ExportExcel.gif" OnClick="ExportToExcelStockOut" Height="25px" CausesValidation="False" />

        </asp:TableCell></asp:TableRow>

<%-- END --%>

    <%-- GroupConfigGridview --%>
        <asp:TableRow>
        <asp:TableCell Width="500px"  >

        <asp:GridView  CssClass="GridViewitem" ID="GridViewGroupConfig" ButtonType="Button" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="GroupConfigDS" GridLines="Vertical" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="TimeStudyGroupID" PageSize="30">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:Button runat="server" Text="Update" CommandName="Update" CausesValidation="True" ID="GroupConfigUpdate"></asp:Button>&nbsp;<asp:Button runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="False" ID="GroupConfigCancel"></asp:Button>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CausesValidation="False" ID="GroupConfigEdit"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="TimeStudyGroupID" SortExpression="TimeStudyGroupID" ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("TimeStudyGroupID") %>' ID="TimeStudyGroupIDLI" Visible="False"></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FacilityName" SortExpression="FacilityName">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("FacilityName") %>' ID="FacilityNameLI"></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LocationID" SortExpression="LocationID">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("LocationID") %>' ID="LocationIDLI"></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LocationName" SortExpression="LocationName">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("LocationName") %>' ID="LocationNameLI"></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="GroupName" SortExpression="GroupName">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Bind("GroupName") %>' ID="GroupNameEdit" Columns="5"></asp:TextBox><asp:RequiredFieldValidator ValidationGroup="Edit" ID="RequiredFieldValidatorGroupNameEdit" runat="server" ControlToValidate="GroupNameEdit" Display="Dynamic" ForeColor="Red" Font-Size="X-Small">REQUIRED</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("GroupName") %>' ID="GroupNameLI"></asp:Label>
                    </ItemTemplate>
             </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Bind("Description") %>' ID="DescriptionEdit" Columns="5"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Description") %>' ID="DescriptionLI"></asp:Label>
                    </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Created" SortExpression="DateCreated">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("DateCreated") %>' ID="DateCreatedLI"  DataFormatString="{0:d}"></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField ShowHeader="False">
             <ItemTemplate>
            <asp:LinkButton ID="GroupConfigLBD" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this entry?');">Delete</asp:LinkButton>             
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
 

        </asp:TableCell> </asp:TableRow>



<%-- END --%>
    </asp:Table>
    
    
     <p>
        <asp:SqlDataSource runat="server" ID="NodeServiceDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' 
            DeleteCommand="exec sp_DeleteTimeStudyNodeService @TimeStudyNodeServiceID"  
            SelectCommand="exec sp_SelectTimeStudyNodeService @FacilityName,@LocationName,@UserName,@MostRecent" 
            UpdateCommand="exec sp_EditTimeStudyNodeService @TimeStudyNodeServiceID">
        <DeleteParameters>
            <asp:Parameter Name="TimeStudyNodeServiceID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="TimeStudyNodeServiceID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="UserSearchDD" PropertyName ="Text" DefaultValue="%" Name="UserName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="MostRecentSearchDD" PropertyName ="Text" DefaultValue="%" Name="MostRecent" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="LocationS" PropertyName ="Text" DefaultValue="%" Name="LocationName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="FacilityS" PropertyName ="Text" DefaultValue="%" Name="FacilityName" Type="String"></asp:ControlParameter>
            </SelectParameters>

        </asp:SqlDataSource>

    </p>

    <p>
        <asp:SqlDataSource runat="server" ID="BinFillDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' 
            DeleteCommand="exec sp_DeleteTimeStudyBinFill @TimeStudyBinFillID"  
            SelectCommand="exec sp_SelectTimeStudyBinFill @FacilityName,@LocationName,@UserName,@MostRecent" 
            UpdateCommand="exec sp_EditTimeStudyBinFill @TimeStudyBinFillID">
        <DeleteParameters>
            <asp:Parameter Name="TimeStudyBinFillID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="TimeStudyBinFillID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="UserSearchDD" PropertyName ="Text" DefaultValue="%" Name="UserName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="MostRecentSearchDD" PropertyName ="Text" DefaultValue="%" Name="MostRecent" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="LocationS" PropertyName ="Text" DefaultValue="%" Name="LocationName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="FacilityS" PropertyName ="Text" DefaultValue="%" Name="FacilityName" Type="String"></asp:ControlParameter>
            </SelectParameters>

        </asp:SqlDataSource>

    </p>
    <p>
        <asp:SqlDataSource runat="server" ID="StageScanDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' 
            DeleteCommand="exec sp_DeleteTimeStudyStageScan @TimeStudyStageScanID"  
            SelectCommand="exec sp_SelectTimeStudyStageScan @FacilityName,@LocationName,@UserName,@MostRecent" 
            UpdateCommand="exec sp_EditTimeStudyStageScan @TimeStudyStageScanID">
        <DeleteParameters>
            <asp:Parameter Name="TimeStudyStageScanID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="TimeStudyStageScanID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="UserSearchDD" PropertyName ="Text" DefaultValue="%" Name="UserName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="MostRecentSearchDD" PropertyName ="Text" DefaultValue="%" Name="MostRecent" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="LocationS" PropertyName ="Text" DefaultValue="%" Name="LocationName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="FacilityS" PropertyName ="Text" DefaultValue="%" Name="FacilityName" Type="String"></asp:ControlParameter>
            </SelectParameters>

        </asp:SqlDataSource>

    </p>
            <p>
        <asp:SqlDataSource runat="server" ID="StockOutDS" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' 
            DeleteCommand="exec sp_DeleteTimeStudyStockOut @TimeStudyStockOutID"  
            SelectCommand="exec sp_SelectTimeStudyStockOut @FacilityName,@LocationName,@UserName,@MostRecent" 
            UpdateCommand="exec sp_EditTimeStudyStockOut @TimeStudyStockOutID">
        <DeleteParameters>
            <asp:Parameter Name="TimeStudyStockOutID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="TimeStudyStockOutID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="UserSearchDD" PropertyName ="Text" DefaultValue="%" Name="UserName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="MostRecentSearchDD" PropertyName ="Text" DefaultValue="%" Name="MostRecent" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="LocationS" PropertyName ="Text" DefaultValue="%" Name="LocationName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="FacilityS" PropertyName ="Text" DefaultValue="%" Name="FacilityName" Type="String"></asp:ControlParameter>
            </SelectParameters>

        </asp:SqlDataSource>

    </p>
    <p>
        <asp:SqlDataSource ID="GroupConfigDS" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>"
            SelectCommand="exec sp_SelectTimeStudyGroup @FacilityName,@LocationName,@GroupName"
            UpdateCommand="exec sp_EditTimeStudyGroup  @TimeStudyGroupID,@GroupName,@Description"
            DeleteCommand="exec sp_DeleteTimeStudyGroup @TimeStudyGroupID">
            <UpdateParameters>
                <asp:Parameter Name="TimeStudyGroupID"></asp:Parameter>
                <asp:Parameter Name="GroupName"></asp:Parameter>
                <asp:Parameter Name="Description"></asp:Parameter>
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="LocationGroupS" PropertyName ="Text" DefaultValue="%" Name="LocationName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="FacilityGroupS" PropertyName ="Text" DefaultValue="%" Name="FacilityName" Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="GroupNameS" PropertyName ="Text" DefaultValue="%" Name="GroupName" Type="String"></asp:ControlParameter>
            </SelectParameters>
            <DeleteParameters>
            <asp:Parameter Name="TimeStudyGroupID" Type="Int32"></asp:Parameter>
            </DeleteParameters>
        </asp:SqlDataSource>
        </p>
</asp:Content>