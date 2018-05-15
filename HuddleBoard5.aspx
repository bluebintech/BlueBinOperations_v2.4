<%@ Page Title="Huddle Board5 - BlueBin DMS App" Language="VB" AutoEventWireup="true" CodeFile="HuddleBoard5.aspx.vb" Inherits="HuddleBoard5" %>

<!DOCTYPE html>

<html lang="en">


    
    
    <head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title runat="server" id="HBTitle"></title>
        <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <script type="text/javascript" src="https://online.tableau.com/javascripts/api/tableau-2.min.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
<%--<link rel="stylesheet" href="https://bootswatch.com/cerulean/bootstrap.min.css">--%>
    <link rel="stylesheet" href="~/Content/ceruleanbootstrap.min.css">
<link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>

    <body>
        <footer><a href="#" onClick="RefreshReport()" style="font-size:x-small;">Refresh Report Data - <asp:Label runat="server" ID="HBTitleL"></asp:Label></a>&nbsp;&nbsp;&nbsp;<a runat="server" href="~/" target ="_blank"  style="font-size:x-small;">Launch DMS App - <asp:Label runat="server" ID="DBTitleL"></asp:Label></a></footer>
        <div class="navbar navbar-default navbar-static-top">
      <div class="container">
        <div class="navbar-header">
          <a href="" runat="server" class="navbar-brand" >&nbsp;<asp:Image runat="server" style="display:inline;" ID="Image1" Height="20px" ImageUrl="~/img/BlueBin_icon.png" Width="20px" />&nbsp;BlueBin Analytics</a>
          <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
        </div>
        <div class="navbar-collapse collapse" id="navbar-main">
          <ul class="nav navbar-nav">
		   <li> 
              
          </ul>

          <ul class="nav navbar-nav navbar-right">

					<li class="dropdown">
                        <a href="#" data-toggle="dropdown" class="dropdown-toggle">Export <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><a href="#" onClick="exportPDF()">PDF</a></li>
							<li><a href="#" onClick="exportIMG()">Image</a></li> 
							
                            
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
    
    </body>
    <script type="text/javascript" src="https://online.tableau.com/javascripts/api/tableau-2.min.js"></script>
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
setInterval(function () { viz.refreshDataAsync() }, 1800000);
</script>
</html>



      
