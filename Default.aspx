    <%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" >
        <asp:Image id="LogoImage" runat="server"></asp:Image>
        <h1>BlueBin DMS Application</h1>
         <p class="lead">Hello <asp:Label ID="UserNameLabel" runat="server" Font-Bold="True"></asp:Label>, and welcome to the BlueBin Daily Management System (DMS) Application for <asp:Label ID="FacilityNameLabel" runat="server"></asp:Label>!&nbsp; Please click below to learn more about the setup of this application and for other documentation.</p>
        <p><a href="~/LearnAbout"  runat="server" class="btn btn-primary btn-lg">Learn About&raquo;</a> <a href="~/Contact"  runat="server" class="btn btn-primary btn-lg">Contact &raquo;</a></p>
    </div>
    <%--&nbsp;(<asp:LoginName ID="LoginN3ame2" runat="server"  />)--%>
    <%--<asp:Label ID="FacilityNameLabel" runat="server"></asp:Label>--%>
    <div class="row">
        <div class="col-md-4" id ="dashboarddiv" runat="server">
            
            <h2>BlueBin Dashboard</h2>
            <p>
                View your Daily Management Dashboard Reports by launching various BlueBin Intelligence Modules. Dozens of market-leading reports are available to help you track the health of your Supply Chain.
            </p>
            <p>
                <a runat="server" class="btn btn-primary btn-sm" href="~/Dashboard">Click Here &raquo;
                    <%--<asp:Image runat="server" ImageUrl="~/img/ClickHereBin.png" Height="50" />--%>

                </a>
            </p>
        </div>

        <div class="col-md-4" id="qcndiv" runat="server">
            <h2>QCN</h2>
            <p>
                "The Voice of the Customer". You can easily create, assign, track, and store QCNs (Questions, Concerns, and Needs) in this easy to use module.  A detailed QCN Dashboard is available from the Module.</p>
            <p>
                <a class="btn btn-primary btn-sm" runat="server" href="~/QCN">Click Here &raquo;</a>
            </p>
        </div>
       <div class="col-md-4" id ="gembadiv" runat="server">
            <h2>Gemba Auditing</h2>
            <p>
                You can easily perform Gemba Audits on Nodes and Staging Area and store them for future reference in this easy to use module. A detailed Gemba Dashboard is available from the Module.</p>
            <p>
                <a class="btn btn-primary btn-sm" runat="server" href="~/Gemba">Click Here &raquo;</a>
            </p>
        </div>
         </div>
    <div class="row">        
         <div class="col-md-4" id="huddleboarddiv" runat="server">
            <h2>DMS Huddle Board</h2>
            <p>
                Launch your DMS Huddle Board to ensure operational team alignment.
            </p>
            <p>
                <a class="btn btn-primary btn-sm" runat="server" href="~/HuddleBoard" target ="_blank">Click Here &raquo;</a>
            </p>
        </div>
        
        <div class="col-md-4" id="conesdiv" runat="server">
            <h2>Cones Module</h2>
            <p>
                You can record stock out item cone placement for tracking in the BlueBin Dashboard and DMS Huddle Board.
            </p>
            <p>
                <a class="btn btn-primary btn-sm" runat="server" href="~/ConesDeployed">Click Here &raquo;</a>
            </p>
       
    </div>     
        
        
 
      <div class="col-md-4" runat="server">
            <h2>Operational Procedures</h2>
            <p>
                Review Standard Operating Procedures and Documentation for your BlueBin System.
            </p>
            <p>
                <a class="btn btn-primary btn-sm" runat="server" href="~/OperationalProcedures">Click Here &raquo;</a>
            </p>
       
    </div>  
        
     
    </div>
    <div class="row">
        <div class="col-md-4" id="scanningdiv" runat="server">
            <h2>Scanning</h2>
            <p>
                You can easily scan Bins into the Database for faster feedback and tracking in the BlueBin Dashboard.
            </p>
            <p>
                <a class="btn btn-primary btn-sm" runat="server" href="~/Scans">Click Here &raquo;</a>
            </p>
       
    </div>  

        <div class="col-md-4" id="hardwarediv" runat="server">
            <h2>Hardware Orders</h2>
            <p>
                You can easily place, and track, orders for more hardware that will be routed to the BlueBin Operations team.
            </p>
            <p>
                <a class="btn btn-primary btn-sm" runat="server" href="~/HardwareOrder">Click Here &raquo;</a>
            </p>
        </div>

       <div class="col-md-4" id="timestudydiv" runat="server">
            <h2>Time Studies</h2>
            <p>
                You can easily Enter in Time Studies for various Services for Productivity tracking in the BlueBin Dashboard.
            </p>
            <p>
                <a class="btn btn-primary btn-sm" runat="server" href="~/TimeStudy">Click Here &raquo;</a>
            </p>
        </div>
        </div>
</asp:Content>
