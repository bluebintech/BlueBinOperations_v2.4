<%@ Page Title="Huddle Board - BlueBin DMS App" Language="VB" AutoEventWireup="true" CodeFile="HuddleBoard.aspx.vb" Inherits="HuddleBoard" %>

<!DOCTYPE html>

<html lang="en">


    
    
    <head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title runat="server" id="HBTitle"></title>
<link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>

    <body>
        <footer><a href="#" onClick="RefreshReport()" style="font-size:x-small;">Refresh Report Data - <asp:Label runat="server" ID="HBTitleL"></asp:Label></a></footer>
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
var RefreshReport = function () {
    viz.refreshDataAsync();
}
setInterval(function () { viz.refreshDataAsync() }, 1800000);
</script>
</html>



      
