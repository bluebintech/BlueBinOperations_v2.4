<%@ Page Title="New QCN Form" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="QCNForm.aspx.vb" Inherits="QCNForm" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <asp:panel runat ="server">
<asp:Table ID="PageTable" runat="server" Width="500px" align = "center">
<asp:TableRow><asp:TableCell><h2>New QCN Form</h2></asp:TableCell></asp:TableRow>
<asp:TableRow>
    <asp:TableCell Width="500px"  BorderColor="#032169" BorderStyle="Solid" BorderWidth="1">


        <asp:Table ID="Table3" runat="server" CellPadding="10" Width="500px" BorderWidth="10" BorderColor="#eeeeee" BackColor="#eeeeee">
            <asp:TableRow Height="10"><asp:TableCell Width="150px"><img src="img/Bluebin_logo-inline.png" width="150" /></asp:TableCell><asp:TableCell HorizontalAlign="Right" Font-Size="X-Small"><asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" />=tooltip</asp:TableCell></asp:TableRow>
            </asp:Table>
        <asp:Table ID="Table1" runat="server" CellPadding="10" Width="500px" BorderWidth="10" BorderColor="#eeeeee" BackColor="#eeeeee">

            
            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="Date" runat="server" Text="Date Logged"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="CurrentTimeTB" runat="server"  ReadOnly="True" BackColor="#eeeeee" DataFormatString="{0:d}" Width="100px"></asp:TextBox>
                 </asp:TableCell>
            </asp:TableRow> <asp:TableRow Height="10"></asp:TableRow>

            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="DateRequested" runat="server" Text="Date Requested" BackColor="#eeeeee"></asp:Label>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorRequested" ControlToValidate="DateRequestedTB" runat="server" ForeColor="Red"  ErrorMessage="Required" Font-Size="X-Small"></asp:RequiredFieldValidator> 
               
                    </asp:TableCell>
                <asp:TableCell >
                    <asp:TextBox ID="DateRequestedTB" runat="server" DataFormatString="{0:d}" TextMode="Date"></asp:TextBox>
                     </asp:TableCell>
            </asp:TableRow><asp:TableRow Height="10"></asp:TableRow>
            <asp:TableRow> 
                <asp:TableCell>
                    <asp:Label ID="Facility" runat="server" Text="Facility"></asp:Label>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorFacility" ControlToValidate="FacilityDD" runat="server" ForeColor="Red"  ErrorMessage=" Required" Font-Size="X-Small"></asp:RequiredFieldValidator>
               
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="FacilityDD"  AppendDataBoundItems="true" runat="server" DataSourceID="FacilityDataSource" DataTextField="FacilityName" DataValueField="FacilityID"  AutoPostBack="True">
                <asp:ListItem Text = "--Select--" Value = ""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                 </asp:TableRow><asp:TableRow Height="10"></asp:TableRow>
            
            <asp:TableRow> 
                <asp:TableCell>
                    <asp:Label ID="Location" runat="server" Text="Location"></asp:Label>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorLocation" ControlToValidate="LocationDD" runat="server" ForeColor="Red"  ErrorMessage=" Required" Font-Size="X-Small"></asp:RequiredFieldValidator>
               
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="LocationDD" AppendDataBoundItems="false"  runat="server" DataSourceID="LocationSource" DataTextField="LocationName" DataValueField="LocationID">
                <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>
                <asp:ListItem Text = "Multiple" Value = "Multiple"></asp:ListItem>
            </asp:DropDownList>
                </asp:TableCell>
                 </asp:TableRow><asp:TableRow Height="10"></asp:TableRow>
            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="ItemID"  runat="server" Text="ERP Item Info"></asp:Label>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Please enter ItemID, Par Level, and Unit of Measure (UOM), validate accuracy and, if multiple, type SEE PAR MASTER in ItemID and list ERP numbers in Details section." />
                </asp:TableCell><asp:TableCell>
                    ID&nbsp;<asp:TextBox ID="ItemIDTB" runat="server"  TextMode="SingleLine" Width="100px"></asp:TextBox>
                    &nbsp;Par&nbsp;<asp:TextBox ID="ParTB" runat="server"  TextMode="SingleLine" Width="40px"></asp:TextBox>
                    &nbsp;UOM&nbsp;<asp:TextBox ID="UOMTB" runat="server"  style="text-transform:uppercase" TextMode="SingleLine" Width="40px" MaxLength="4"></asp:TextBox>
                </asp:TableCell></asp:TableRow><asp:TableRow Height="10"></asp:TableRow>
            
            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="ClinicalDescription"  runat="server" Text="Clinical Description"></asp:Label>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Please validate accuracy and observe a 30-character limit if new/not currently on BlueBin. If multiple items, type SEE PAR MASTER and include any other desired information in the Details section." />
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="ClinicalDescriptionTB" style="text-transform:uppercase" runat="server"  TextMode="SingleLine"  Width="250px"></asp:TextBox>
                </asp:TableCell></asp:TableRow>
            <asp:TableRow Height="10"></asp:TableRow>

            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="Sequence"  runat="server" Text="Sequence"></asp:Label>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="If applicable enter the Sequence# for the new item or new # for an existing item." />
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="SequenceTB" style="text-transform:uppercase" runat="server"  TextMode="SingleLine"  Width="250px"></asp:TextBox>
                </asp:TableCell></asp:TableRow>
            <asp:TableRow Height="10"></asp:TableRow>

            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="ManuNumNameL" runat="server" Text="Manufacturer #/Name" ></asp:Label>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="If applicable enter the Manufacturer Name and #." />
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="ManuNumNameTB" runat="server" Width="250px" TextMode="SingleLine"></asp:TextBox>
                </asp:TableCell></asp:TableRow>
            
            <%--Line to Separate--%> 
            <asp:TableRow Height="15"></asp:TableRow>
            <asp:TableRow Height="2"><asp:TableCell BackColor="Gray"></asp:TableCell><asp:TableCell BackColor="Gray"></asp:TableCell></asp:TableRow>
            <asp:TableRow Height="15"></asp:TableRow>
            
            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="LoggedByLabel" runat="server" Text="Logged By"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="LoggedByTB" runat="server"  ReadOnly="True" BackColor="#eeeeee" Width="200px"></asp:TextBox>
                 </asp:TableCell>
            </asp:TableRow> <asp:TableRow Height="10"></asp:TableRow>
            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="Requester" runat="server" Text="Requested By"></asp:Label>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Please validate accuracy that the full name is typed correctly for reporting purposes." />
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorRequester" ControlToValidate="RequesterTB" runat="server" ForeColor="Red" ErrorMessage=" Required" Font-Size="X-Small"></asp:RequiredFieldValidator>
                </asp:TableCell><asp:TableCell>
                 <asp:TextBox ID="RequesterTB" runat="server" Width="200px"></asp:TextBox>   
                </asp:TableCell></asp:TableRow><asp:TableRow Height="10"></asp:TableRow>
            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="ApprovedBy" runat="server" Text="Approved By"></asp:Label>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Approved By should be the department nurse champion or other designated approver." />
                    </asp:TableCell><asp:TableCell>
                 <asp:TextBox ID="ApprovedByTB" runat="server" Width="200px"></asp:TextBox>   
                </asp:TableCell></asp:TableRow>
            
            <asp:TableRow Height="10"></asp:TableRow>
            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="Assigned" runat="server" Text="Assigned To"></asp:Label>
                          </asp:TableCell><asp:TableCell>
                    <asp:DropDownList ID="AssignedDD"  AppendDataBoundItems="true" runat="server" DataSourceID="AssignedUserSource"  DataTextField="AssignedFullName" DataValueField="AssignedUser" Width="200px">
                    <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>

                    </asp:DropDownList>
                </asp:TableCell></asp:TableRow>
            
            <%--Line to Separate--%> 
            <asp:TableRow Height="15"></asp:TableRow>
            <asp:TableRow Height="2"><asp:TableCell BackColor="Gray"></asp:TableCell><asp:TableCell BackColor="Gray"></asp:TableCell></asp:TableRow>
            <asp:TableRow Height="15"></asp:TableRow>

            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="QCNComplexity" runat="server" Text="QCN Complexity"></asp:Label>
        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorQCNComplexity" ControlToValidate="QCNComplexityDD" runat="server" ForeColor="Red"  ErrorMessage="Required" Font-Size="X-Small"></asp:RequiredFieldValidator>

                </asp:TableCell><asp:TableCell>
                    <asp:DropDownList ID="QCNComplexityDD"  AppendDataBoundItems="true" runat="server" DataSourceID="QCNComplexitySource" DataTextField="QCNComplexity" DataValueField="QCNCID">
                    <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>

                    </asp:DropDownList>
                </asp:TableCell></asp:TableRow>

                    <asp:TableRow Height="10"></asp:TableRow>


            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="QCNType" runat="server" Text="QCN Type"></asp:Label>
        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorQCNType" ControlToValidate="QCNTypeDD" runat="server" ForeColor="Red"  ErrorMessage="Required" Font-Size="X-Small"></asp:RequiredFieldValidator>

                </asp:TableCell><asp:TableCell>
                    <asp:DropDownList ID="QCNTypeDD"  AppendDataBoundItems="true" runat="server" DataSourceID="QCNTypeSource" DataTextField="Name" DataValueField="Name">
                    <asp:ListItem Selected = "True" Text = "--Select--" Value = ""></asp:ListItem>

                    </asp:DropDownList>
                </asp:TableCell></asp:TableRow>

                    <asp:TableRow Height="10"></asp:TableRow>
                        
                       <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="QCNStatus" runat="server" Text="QCN Status"></asp:Label>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" 
                        ToolTip="
New/NotStarted - Logged, not yet evaluated for next steps.
InProgress/Approved - No additional support needed, QCN will be completed within 10 working days.
Rejected - QCN has been rejected and closed, provide details in Updates section. This will remove the request off the Huddle Board.
Completed - QCN is done and closed. This will remove the request off the Huddle Board.
NeedsMoreInfo - Requester/clinical/other clarification required to proceed.
AwaitingApproval - New items only, e.g. Value Analysis, Product Standards, or other new product committee process.
InFileMaintenance - New ERP # or other item activation steps." />
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorQCNStatus" ControlToValidate="QCNStatusDD" runat="server" ForeColor="Red"  ErrorMessage="Required" Font-Size="X-Small"></asp:RequiredFieldValidator>

                </asp:TableCell><asp:TableCell>
                    <asp:DropDownList ID="QCNStatusDD" AppendDataBoundItems="true" runat="server" DataSourceID="QCNStatusSource" DataTextField="Status" DataValueField="Status">
                   <asp:ListItem Selected = "True" Text = "--Select--" Value = "New/NotStarted"></asp:ListItem> </asp:DropDownList>
                    
                </asp:TableCell></asp:TableRow><asp:TableRow Height="10">

                                               </asp:TableRow>
                <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="InternalReferenceL" runat="server" Text="Reference" ></asp:Label>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="This is for entering matching internal ticket numbers as applicable." />
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="InternalReferenceTB" runat="server" Width="150px" TextMode="SingleLine"></asp:TextBox>
                </asp:TableCell></asp:TableRow>
            
            <%--Line to Separate--%> 
            <asp:TableRow Height="15"></asp:TableRow>
            <asp:TableRow Height="2"><asp:TableCell BackColor="Gray"></asp:TableCell><asp:TableCell BackColor="Gray"></asp:TableCell></asp:TableRow>
            <asp:TableRow Height="15"></asp:TableRow>
            
            
            <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="Details" runat="server" Text="" >Product and <br />Placement Details</asp:Label>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Product information and/or instructions for node placement." />
                    
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="DetailsTB" runat="server" Height="150px" Width="575px" TextMode="MultiLine"></asp:TextBox>
                </asp:TableCell></asp:TableRow><asp:TableRow Height="10"></asp:TableRow>
                       <asp:TableRow>    
                <asp:TableCell>
                    <asp:Label ID="Updates" runat="server" Text="Updates"></asp:Label>&nbsp;<asp:Image runat="server" ImageUrl="img/info.png" Height="12" Width="12" ImageAlign="Middle" ToolTip="Enter date then comment to explain status changes and other required action items/support needed." />
        
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="UpdatesTB" runat="server" Height="150px" Width="575px" TextMode="MultiLine"></asp:TextBox>
                </asp:TableCell></asp:TableRow><asp:TableRow Height="10"></asp:TableRow>
            <asp:TableRow Height="10"></asp:TableRow>
        </asp:Table>
 
 </asp:TableCell> 

    </asp:TableRow> 
    
    <asp:TableRow Height="10">
        <asp:TableCell><div class="loading">
            Loading. Please wait.<br />
                <br />
                <img src="loader.gif" alt="" /></div></asp:TableCell>

    </asp:TableRow>
 <asp:TableRow><asp:TableCell><asp:Button ID="QCNSubmit" runat="server" Text="Submit" class="btn btn-primary btn-lg" />&nbsp;<asp:Button ID="QCNCancel" runat="server" Text="Cancel" CausesValidation="false" class="btn btn-primary btn-lg"/><br /></asp:TableCell></asp:TableRow>       
      
        </asp:Table>

    
    <br />&nbsp;&nbsp; <br /><br /><br /><br /><br />
        <asp:SqlDataSource ID="LocationSource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" SelectCommand="exec sp_SelectLocationCascade 'Yes'"  FilterExpression="FacilityID = '{0}'" >
                <FilterParameters>
                    <asp:ControlParameter Name="FacilityID" ControlID="FacilityDD" PropertyName="SelectedValue" />
                </FilterParameters></asp:SqlDataSource>      
        <asp:SqlDataSource ID="QCNTypeSource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" SelectCommand="exec sp_SelectQCNType '1'"></asp:SqlDataSource>
        <asp:SqlDataSource ID="QCNComplexitySource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" SelectCommand="exec sp_SelectQCNComplexity '1'"></asp:SqlDataSource>
        <asp:SqlDataSource ID="AssignedUserSource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" SelectCommand="SELECT BlueBinUserID as AssignedUser,LastName + ', ' + FirstName as AssignedFullName FROM [bluebin].[BlueBinUser] WHERE AssignToQCN = 1"></asp:SqlDataSource>
        <asp:SqlDataSource ID="QCNStatusSource" runat="server" ConnectionString="<%$ ConnectionStrings:Site_ConnectionString %>" SelectCommand="exec sp_SelectQCNStatus '1'"></asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="FacilityDataSource" ConnectionString='<%$ ConnectionStrings:Site_ConnectionString %>' SelectCommand="exec sp_SelectFacilities"></asp:SqlDataSource>
        
    
    
  
</asp:panel>
</asp:Content>
