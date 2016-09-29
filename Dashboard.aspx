<%@ Page Title="BlueBin Analytics Dashboard" Language="VB" AutoEventWireup="true" CodeFile="Dashboard.aspx.vb" Inherits="Dashboard" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>BlueBin Analytics</title>
<script type="text/javascript" src="https://online.tableau.com/javascripts/api/tableau-2.min.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
<link rel="stylesheet" href="https://bootswatch.com/cerulean/bootstrap.min.css">
<link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>

<body>

<div class="navbar navbar-default navbar-static-top">
      <div class="container">
        <div class="navbar-header">
          <a href="~/" runat="server" class="navbar-brand" onClick="switchView('Home')">&nbsp;<asp:Image runat="server" style="display:inline;" ID="Image1" Height="20px" ImageUrl="~/img/BlueBin_icon.png" Width="20px" />&nbsp;BlueBin Analytics</a>
          <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
        </div>
        <div class="navbar-collapse collapse" id="navbar-main">
          <ul class="nav navbar-nav">
		    <li><a runat="server" href="~/">Home</a></li>
            <li class="dropdown">
              <a class="dropdown-toggle" runat="server" data-toggle="dropdown" href="#" id="MenuSupplyChainReports">Supply Chain <span class="caret"></span></a>
              <ul class="dropdown-menu" aria-labelledby="SupplyChainReports">
							<%-- <li><asp:Label runat="server" ID="URLLabel"></asp:Label></li>--%>
                            <li><a href="#" runat="server" id="MenuSCDailyManagementDB" onClick="switchView('Daily Management Dashboard')">Daily Management Dashboard</a></li>
                            <li class="divider"></li>
                            <li><a href="#" runat="server" id="MenuSCNodeActivity" onClick="switchView('Node Activity')">Node Activity</a></li>
							<li><a href="#" runat="server" id="MenuSCBinActivity" onClick="switchView('BlueBin Activity Report')">Bin Activity</a></li>
                            <li><a href="#" runat="server" id="MenuSCBinVelocityReport" onClick="switchView('Bin Velocity Report')">Bin Velocity Report</a></li>
                            <li><a href="#" runat="server" id="MenuSCSlowBinReport" onClick="switchView('Slow Bin Report')">Slow Bin Report</a></li>
                            <li class="divider"></li>
                            <li><a href="#" runat="server" id="MenuSCBlueBinParMaster" onClick="switchView('BlueBin Par Master')">BlueBin Par Master</a></li>
                            <li><a href="#" runat="server" id="MenuSCItemMaster" onClick="switchView('Item Master Report')">Item Master</a></li> 
                            <li class="divider"></li>
                            <li><a href="#" runat="server" id="MenuSCOpenScans" onClick="switchView('Open Scans')">Open Scans</a></li>
							<li><a href="#" runat="server" id="MenuSCOrderDetails" onClick="switchView('Order Details')">Order Details</a></li>
                            <li class="divider"></li>
                            <li><a href="#" runat="server" id="MenuSCItemLocator" onClick="switchView('Item Locator')">Item Locator</a></li>
                            <li><a href="#" runat="server" id="MenuSCParValuation" onClick="switchView('Par Valuation Report')">Par Valuation</a></li>   
              </ul>
            </li>
            <li class="dropdown">
              <a class="dropdown-toggle" runat="server" data-toggle="dropdown" href="#" id="MenuOpsReports">Operational Performance <span class="caret"></span></a>
              <ul class="dropdown-menu" aria-labelledby="OpsReports">
                            <li><a href="#" runat="server" id="MenuOPSupplySpend" onClick="switchView('Supply Spend')">Supply Spend</a></li>
                            <li><a href="#" runat="server" id="MenuOPStatCalls" onClick="switchView('Stat Calls')">Stat Calls</a></li>
                            <li><a href="#" runat="server" id="MenuOPWarehouseVolume" onClick="switchView('Warehouse Value')">Warehouse Volume</a></li>
                            <li><a href="#" runat="server" id="MenuOPWarehouseHistory" onClick="switchView('Warehouse History')">Warehouse History</a></li>
                            <li><a href="#" runat="server" id="MenuOPWarehouseDetail" onClick="switchView('Warehouse Size')">Warehouse Detail</a></li>
                            <li><a href="#" runat="server" id="MenuOPPickLineVolume" onClick="switchView('Pick Line Volume')">Pick Line Volume</a></li>
                            <li><a href="#" runat="server" id="MenuOPOverallLineVolume" onClick="switchView('Overall Line Volume')">Overall Line Volume</a></li>
                            <li><a href="#" runat="server" id="MenuOPKanbansAdjusted" onClick="switchView('Kanbans Adjusted')">Kanbans Adjusted</a></li>
                            <li><a href="#" runat="server" id="MenuOPConesDashboard" onClick="switchView('Cones Deployed Dashboard')">Cones Dashboard</a></li>
                            <li><a href="#" runat="server" id="MenuOPItemUsage" onClick="switchView('Item Usage and Cost')">Item Usage</a></li>
                            <li class="divider"></li>
                            <li><a href="#" runat="server" id="MenuOPQCNDashboard" onClick="switchView('QCN Dashboard')">QCN Dashboard</a></li>
                            <li><a href="#" runat="server" id="MenuOPQCNDetail" onClick="switchView('QCN Detail')">QCN Detail</a></li>
                            <li><a href="#" runat="server" id="MenuOPGembaDashboard" onClick="switchView('Gemba Dashboard')">Gemba Dashboard</a></li>
              </ul>
            </li>
            <li class="dropdown">
              <a class="dropdown-toggle" runat="server" data-toggle="dropdown" href="#" id="MenuSourcingReports">Strategic Sourcing <span class="caret"></span></a>
              <ul class="dropdown-menu" aria-labelledby="SourcingReports">
                			<li><a href="#" runat="server" id="MenuSrcBuyerPerformance" onClick="switchView('Buyer Performance Dashboard')">Buyer Performance</a></li>
                            <li><a href="#" runat="server" id="MenuSrcSpecialPerformance" onClick="switchView('Specials Dashboard')">Special Performance</a></li>
                            <li><a href="#" runat="server" id="MenuSrcSupplierPerformance" onClick="switchView('Supplier Performance Dashboard')">Supplier Performance</a></li>
                            <li><a href="#" runat="server" id="MenuSrcSourcingCalendar" onClick="switchView('Sourcing Calendar')">Sourcing Calendar (Contracts Dashboard)</a></li>
                            <li><a href="#" runat="server" id="MenuSrcSupplierSpendManager" onClick="switchView('Supplier Spend Manager')">Supplier Spend Manager</a></li>
                            <li><a href="#" runat="server" id="MenuSrcCostImpactCalculator" onClick="switchView('Item Cost Impact Dashboard')">Cost Impact Calculator</a></li>
                            <li class="divider"></li>
                            <li><a href="#" runat="server" id="MenuSrcOpenPOReport" onClick="switchView('Open PO Report')">Open PO Report</a></li>
                            <li class="divider"></li>
                            <li><a href="#" runat="server" id="MenuSrcCostVarianceDashboard" onClick="switchView('Cost Variance Dashboard')">Cost Variance Dashboard</a></li>
                            
                            
              </ul>
            </li>
              
          </ul>

          <ul class="nav navbar-nav navbar-right">

					<li class="dropdown">
                        <a href="#" data-toggle="dropdown" class="dropdown-toggle">Export <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><a href="#" onClick="exportXL()">Excel</a></li>
                            <li><a href="#" onClick="exportData()">Data</a></li>
							<li><a href="#" onClick="exportPDF()">PDF</a></li>
							<li><a href="#" onClick="exportIMG()">Image</a></li>
							 <li class="divider"></li>
							<li><a href="#" onClick="downloadWorkbook()">Download Workbook</a></li> 
							
                            
                        </ul>
                    </li>
              <li class="dropdown">
                        <a href="#" data-toggle="dropdown" class="dropdown-toggle">Updates<b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><a href="#" onClick="revertAll()">Reset All Filters</a></li>
                            <li><a href="#" onClick="PauseUpdate()">Pause Filter Refresh</a></li>
                            <li><a href="#" onClick="ResumeUpdate()">Resume Filter Refresh</a></li>
                            <li><a href="#" onClick="RefreshReport()">Refresh All Report Data</a></li>			
                            
                        </ul>
                    </li>
          </ul>

        </div>
      </div>
    </div>
<div id="viz" style="width:100%; margin:0 auto;">
</div>

<script>
var placeholderDiv = document.getElementById("viz");
var url = "<%=Me.TableauFullURL.ToString()%>";
var options = {
   hideTabs: true,
   hideToolbar: true,
   width: "100%",   
   height: "980px"
};
var viz = new tableauSoftware.Viz(placeholderDiv, url, options);

var switchView = function(sheetName) {
	
	workBook = viz.getWorkbook();
	workBook.activateSheetAsync(sheetName);
	
}

var revertAll = function(){
	viz.revertAllAsync();
}

var exportPDF = function(){
	viz.showExportPDFDialog();
}

var exportXL = function(){
	viz.showExportCrossTabDialog();
}

var exportIMG = function(){
	viz.showExportImageDialog();
}

var exportData = function(){
	viz.showExportDataDialog();
}

var downloadWorkbook = function(){
	viz.showDownloadWorkbookDialog();
}

var shareViz = function(){
	viz.showShareDialog();
}
var PauseUpdate = function () {
    viz.pauseAutomaticUpdatesAsync();
}
var ResumeUpdate = function () {
    viz.resumeAutomaticUpdatesAsync();
}
var ToggleUpdate = function () {
    viz.toggleAutomaticUpdatesAsync();
}
var RefreshReport = function () {
    viz.refreshDataAsync();
}



</script>
</body>
</html>
