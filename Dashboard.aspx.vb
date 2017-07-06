
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.UserControl
Imports System.IO
Imports System.Net
Imports System.Text


Public Class Dashboard
    Inherits Page


    Protected TableauFullURL As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If


        If Me.Page.User.Identity.IsAuthenticated Then
            Dim GenericLogin As String
            Dim TableauSite As String
            Dim TableauWorkbook As String
            Dim TableauURL As String
            Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
            ' Create a request using a URL that can receive a post.


            Dim constrtableau As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
            Using contableau As New SqlConnection(constrtableau)
                Using cmdtableau As New SqlCommand("sp_SelectConfigValues")
                    cmdtableau.CommandType = CommandType.StoredProcedure
                    cmdtableau.Connection = contableau
                    contableau.Open()

                    'Tableau URL Name
                    cmdtableau.Parameters.AddWithValue("@ConfigName", "TableauURL")
                    TableauURL = Convert.ToString(cmdtableau.ExecuteScalar())
                    cmdtableau.Parameters.Clear()
                    'Tableau Site Name
                    cmdtableau.Parameters.AddWithValue("@ConfigName", "TableauSiteName")
                    TableauSite = Convert.ToString(cmdtableau.ExecuteScalar())
                    cmdtableau.Parameters.Clear()
                    'Tableau Workbook Name
                    cmdtableau.Parameters.AddWithValue("@ConfigName", "TableauWorkbook")
                    TableauWorkbook = Convert.ToString(cmdtableau.ExecuteScalar())
                    cmdtableau.Parameters.Clear()
                    'Generic Login Name
                    cmdtableau.Parameters.AddWithValue("@ConfigName", "TableauDefaultUser")
                    GenericLogin = Convert.ToString(cmdtableau.ExecuteScalar())

                    contableau.Close()
                End Using
            End Using

            Dim TableauLogin As String
            'Set the User Login to be bluebin only if it exists.  If it doesn't, use the generic login from the tables.
            If UserLogin.Contains("@bluebin.com") Then
                TableauLogin = UserLogin
            Else
                TableauLogin = GenericLogin
            End If


            Dim requeststring As String = TableauURL & "/trusted?"
            Dim request As WebRequest = WebRequest.Create(requeststring)
            'http.setRequestHeader("Content-Type","application/x-www-form-urlencoded;charset=UTF-8")' Set the Method property of the request to POST.
            request.Method = "POST"

            'http://intelligence.bluebin.com/trusted?username=gbutler@bluebin.com&target_site=bluebinanalytics
            'http://intelligence.bluebin.com/trusted/azJotmGio91cWOUH9Da6jmod/t/bluebinanalytics/views/Demo/Home

            ' Create POST data and convert it to a byte array.
            Dim postData As String = "username=" & TableauLogin & "&target_site=" & TableauSite
            'Dim postData As String = "username=demo@bluebin.com&target_site=bluebinanalytics"
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            ' Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded"
            ' Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length
            ' Get the request stream.
            Dim dataStream As Stream = request.GetRequestStream()
            ' Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.
            dataStream.Close()
            ' Get the response.
            Dim response As WebResponse = request.GetResponse()
            ' Display the status.
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            ' Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.
            Dim reader As New StreamReader(dataStream)
            ' Read the content.
            Dim responseFromServer As String = reader.ReadToEnd()
            ' Display the content.
            'Console.WriteLine(responseFromServer)
            ' Clean up the streams.
            reader.Close()
            dataStream.Close()
            response.Close()


            Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            con.Open()
            Dim da As New SqlDataAdapter("exec sp_SelectTableauURL", con)
            Dim dt As New DataTable

            da.Fill(dt)

            Dim TableaURLDB As String = dt.Rows(0)("ConfigValue").ToString()

            'TableauFullURL = "http://intelligence.bluebin.com/t" & TableaURLDB & "Home"
            TableauFullURL = TableauURL & "/trusted/" & responseFromServer & "/t/" & TableauSite & "/views/" & TableauWorkbook & "/Home"

            con.Close()

            'URLLabel.Text = requeststring

            Dim MENUDashboardSC As String
            Dim MENUDashboardSrc As String
            Dim MENUDashboardOps As String
            Dim UserMENUDashboardSC As String
            Dim UserMENUDashboardSrc As String
            Dim UserMENUDashboardOps As String
            Dim UserMENUDashboardHB As String
            'Reports List
            Dim SCDailyManagementDB As String
            Dim SCNodeActivity As String
            Dim SCBinActivity As String
            Dim SCBinVelocityReport As String
            Dim SCSlowBinReport As String
            Dim SCBlueBinParMaster As String
            Dim SCItemMaster As String
            Dim SCOpenScans As String
            Dim SCOrderDetails As String
            Dim SCItemLocator As String
            Dim SCParValuation As String

            Dim OPBinSequence As String
            Dim OPNodeScorecard As String
            Dim OPSupplySpend As String
            Dim OPStatCalls As String
            Dim OPStatCallsDetail As String
            Dim OPWarehouseVolume As String
            Dim OPWarehouseHistory As String
            Dim OPWarehouseDetail As String
            Dim OPPickLineVolume As String
            Dim OPOverallLineVolume As String
            Dim OPKanbansAdjusted As String
            Dim OPConesDashboard As String
            Dim OPQCNDashboard As String
            Dim OPQCNDetail As String
            Dim OPGembaDashboard As String
            Dim OPGembaAuditor As String
            Dim OPItemUsage As String
            Dim OPTSAT As String
            Dim OPTSAverages As String
            Dim OPTSDashboard As String
            Dim OPTSPlanner As String

            Dim SrcBuyerPerformance As String
            Dim SrcSpecialPerformance As String
            Dim SrcSupplierPerformance As String
            Dim SrcSourcingCalendar As String
            Dim SrcSupplierSpendManager As String
            Dim SrcCostImpactCalculator As String
            Dim SrcOpenPOReport As String
            Dim SrcCostVarianceDashboard As String
            Dim SrcForecast As String


            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
            Using conroles As New SqlConnection(constr)
                Using cmdadmin As New SqlCommand("sp_ValidateBlueBinRole")
                    cmdadmin.CommandType = CommandType.StoredProcedure
                    cmdadmin.Connection = conroles
                    conroles.Open()
                    'cmd.ExecuteNonQuery()
                    'command.Parameters["@id"].Value = rowUserID

                    'UserMENU-Dashboard-SupplyChain
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Dashboard-SupplyChain")
                    UserMENUDashboardSC = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Dashboard-Sourcing
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Dashboard-Sourcing")
                    UserMENUDashboardSrc = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Dashboard-Ops
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Dashboard-Ops")
                    UserMENUDashboardOps = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()
                    'UserMENU-Dashboard-HuddleBoard
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Dashboard-HuddleBoard")
                    UserMENUDashboardHB = Convert.ToString(cmdadmin.ExecuteScalar())

                    conroles.Close()
                End Using
            End Using

            Using conmenu As New SqlConnection(constr)
                Using cmdmenu As New SqlCommand("sp_ValidateMenus")
                    cmdmenu.CommandType = CommandType.StoredProcedure
                    cmdmenu.Connection = conmenu
                    conmenu.Open()
                    'cmd.ExecuteNonQuery()

                    'MENU-Dashboard-SupplyChain
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Dashboard-SupplyChain")
                    MENUDashboardSC = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    'MENU-Dashboard-Sourcing
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Dashboard-Sourcing")
                    MENUDashboardSrc = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    'MENU-Dashboard-Ops
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "MENU-Dashboard-Ops")
                    MENUDashboardOps = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()

                    'REPORTS-Supply Chain
                   
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-Daily Management DB")
                    SCDailyManagementDB = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-Node Activity")
                    SCNodeActivity = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-Bin Activity")
                    SCBinActivity = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-Bin Velocity Report")
                    SCBinVelocityReport = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-Slow Bin Report")
                    SCSlowBinReport = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-BlueBin Par Master")
                    SCBlueBinParMaster = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-Item Master")
                    SCItemMaster = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-Open Scans")
                    SCOpenScans = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-Order Details")
                    SCOrderDetails = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-Item Locator")
                    SCItemLocator = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "SC-Par Valuation")
                    SCParValuation = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()

                    'REPORTS-Op Performance
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Bin Sequence")
                    OPBinSequence = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Node Scorecard")
                    OPNodeScorecard = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Supply Spend")
                    OPSupplySpend = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Stat Calls")
                    OPStatCalls = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Stat Calls Detail")
                    OPStatCallsDetail = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Warehouse History")
                    OPWarehouseHistory = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Warehouse Volume")
                    OPWarehouseVolume = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Warehouse Detail")
                    OPWarehouseDetail = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Pick Line Volume")
                    OPPickLineVolume = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Overall Line Volume")
                    OPOverallLineVolume = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Kanbans Adjusted")
                    OPKanbansAdjusted = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Cones Dashboard")
                    OPConesDashboard = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-QCN Dashboard")
                    OPQCNDashboard = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-QCN Detail")
                    OPQCNDetail = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Gemba Dashboard")
                    OPGembaDashboard = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Gemba Auditor Details")
                    OPGembaAuditor = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Item Usage")
                    OPItemUsage = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Time Study Activity Times")
                    OPTSAT = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Time Study Averages")
                    OPTSAverages = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()

                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Time Study Planner")
                    OPTSPlanner = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "OP-Time Study Dashboard")
                    OPTSDashboard = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()

                    'REPORTS-Sourcing
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "Src-Buyer Performance")
                    SrcBuyerPerformance = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "Src-Special Performance")
                    SrcSpecialPerformance = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "Src-Supplier Performance")
                    SrcSupplierPerformance = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "Src-Sourcing Calendar")
                    SrcSourcingCalendar = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "Src-Supplier Spend Manager")
                    SrcSupplierSpendManager = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "Src-Cost Impact Calculator")
                    SrcCostImpactCalculator = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "Src-Open PO Report")
                    SrcOpenPOReport = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "Src-Cost Variance Dashboard")
                    SrcCostVarianceDashboard = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "Src-Location Forecast")
                    SrcForecast = Convert.ToString(cmdmenu.ExecuteScalar())
                    cmdmenu.Parameters.Clear()

                    conmenu.Close()
                End Using
            End Using



            'Main Menus


            If MENUDashboardSC = "No" Or UserMENUDashboardSC = "No" Then
                MenuSupplyChainReports.Visible = False
            Else
                MenuSupplyChainReports.Visible = True
            End If

            If MENUDashboardSrc = "No" Or UserMENUDashboardSrc = "No" Then
                MenuSourcingReports.Visible = False
            Else
                MenuSourcingReports.Visible = True
            End If

            If MENUDashboardOps = "No" Or UserMENUDashboardOps = "No" Then
                MenuOpsReports.Visible = False
            Else
                MenuOpsReports.Visible = True
            End If

            'Supply Chain Report Menus
            If SCDailyManagementDB = "Yes" Then
                MenuSCDailyManagementDB.Visible = True
            Else
                MenuSCDailyManagementDB.Visible = False
            End If

            If SCNodeActivity = "Yes" Then
                MenuSCNodeActivity.Visible = True
            Else
                MenuSCNodeActivity.Visible = False
            End If

            If SCBinActivity = "Yes" Then
                MenuSCBinActivity.Visible = True
            Else
                MenuSCBinActivity.Visible = False
            End If

            If SCBinVelocityReport = "Yes" Then
                MenuSCBinVelocityReport.Visible = True
            Else
                MenuSCBinVelocityReport.Visible = False
            End If

            If SCSlowBinReport = "Yes" Then
                MenuSCSlowBinReport.Visible = True
            Else
                MenuSCSlowBinReport.Visible = False
            End If

            If SCBlueBinParMaster = "Yes" Then
                MenuSCBlueBinParMaster.Visible = True
            Else
                MenuSCBlueBinParMaster.Visible = False
            End If

            If SCItemMaster = "Yes" Then
                MenuSCItemMaster.Visible = True
            Else
                MenuSCItemMaster.Visible = False
            End If

            If SCOpenScans = "Yes" Then
                MenuSCOpenScans.Visible = True
            Else
                MenuSCOpenScans.Visible = False
            End If

            If SCOrderDetails = "Yes" Then
                MenuSCOrderDetails.Visible = True
            Else
                MenuSCOrderDetails.Visible = False
            End If

            If SCItemLocator = "Yes" Then
                MenuSCItemLocator.Visible = True
            Else
                MenuSCItemLocator.Visible = False
            End If

            If SCParValuation = "Yes" Then
                MenuSCParValuation.Visible = True
            Else
                MenuSCParValuation.Visible = False
            End If

            'Op Performance Report Menus
            If OPNodeScorecard = "Yes" Then
                MenuOPNodeScorecard.Visible = True
                NodeScorecardLine.Visible = True
            Else
                MenuOPNodeScorecard.Visible = False
                NodeScorecardLine.Visible = False
            End If

            If OPBinSequence = "Yes" Then
                MenuOpBinSequence.Visible = True
            Else
                MenuOpBinSequence.Visible = False
            End If

            If OPSupplySpend = "Yes" Then
                MenuOPSupplySpend.Visible = True
            Else
                MenuOPSupplySpend.Visible = False
            End If

            If OPStatCalls = "Yes" Then
                MenuOPStatCalls.Visible = True
            Else
                MenuOPStatCalls.Visible = False
            End If

            If OPStatCallsDetail = "Yes" Then
                MenuOPStatCallsDetail.Visible = True
            Else
                MenuOPStatCallsDetail.Visible = False
            End If

            If OPWarehouseVolume = "Yes" Then
                MenuOPWarehouseVolume.Visible = True
            Else
                MenuOPWarehouseVolume.Visible = False
            End If

            If OPWarehouseHistory = "Yes" Then
                MenuOPWarehouseHistory.Visible = True
            Else
                MenuOPWarehouseHistory.Visible = False
            End If

            If OPWarehouseDetail = "Yes" Then
                MenuOPWarehouseDetail.Visible = True
            Else
                MenuOPWarehouseDetail.Visible = False
            End If

            If OPPickLineVolume = "Yes" Then
                MenuOPPickLineVolume.Visible = True
            Else
                MenuOPPickLineVolume.Visible = False
            End If

            If OPOverallLineVolume = "Yes" Then
                MenuOPOverallLineVolume.Visible = True
            Else
                MenuOPOverallLineVolume.Visible = False
            End If

            If OPKanbansAdjusted = "Yes" Then
                MenuOPKanbansAdjusted.Visible = True
            Else
                MenuOPKanbansAdjusted.Visible = False
            End If

            If OPConesDashboard = "Yes" Then
                MenuOPConesDashboard.Visible = True
            Else
                MenuOPConesDashboard.Visible = False
            End If

            If OPQCNDashboard = "Yes" Then
                MenuOPQCNDashboard.Visible = True
            Else
                MenuOPQCNDashboard.Visible = False
            End If

            If OPQCNDetail = "Yes" Then
                MenuOPQCNDetail.Visible = True
            Else
                MenuOPQCNDetail.Visible = False
            End If

            If OPGembaDashboard = "Yes" Then
                MenuOPGembaDashboard.Visible = True
            Else
                MenuOPGembaDashboard.Visible = False
            End If

            If OPGembaAuditor = "Yes" Then
                MenuOPGembaAuditor.Visible = True
            Else
                MenuOPGembaAuditor.Visible = False
            End If

            If OPQCNDashboard = "Yes" Or OPQCNDetail = "Yes" Or OPGembaDashboard = "Yes" Then
                QCNGembaLine.Visible = True
            Else
                QCNGembaLine.Visible = False
            End If


            If OPItemUsage = "Yes" Then
                MenuOPItemUsage.Visible = True
            Else
                MenuOPItemUsage.Visible = False
            End If

            If OPTSAT = "Yes" Then
                MenuOPTSAT.Visible = True
            Else
                MenuOPTSAT.Visible = False
            End If

            If OPTSAverages = "Yes" Then
                MenuOPTSAverages.Visible = True
            Else
                MenuOPTSAverages.Visible = False
            End If


            If OPTSPlanner = "Yes" Then
                MenuOPTSPlanner.Visible = True
            Else
                MenuOPTSPlanner.Visible = False
            End If

            If OPTSDashboard = "Yes" Then
                MenuOPTSDashboard.Visible = True
            Else
                MenuOPTSDashboard.Visible = False
            End If

            If OPTSPlanner = "Yes" Or OPTSAT = "Yes" Or OPTSAverages = "Yes" Or OPTSDashboard = "Yes" Then
                TSLine.Visible = True
            Else
                TSLine.Visible = False
            End If


            'Sourcing Report Menus
            If SrcBuyerPerformance = "Yes" Then
                MenuSrcBuyerPerformance.Visible = True
            Else
                MenuSrcBuyerPerformance.Visible = False
            End If

            If SrcSpecialPerformance = "Yes" Then
                MenuSrcSpecialPerformance.Visible = True
            Else
                MenuSrcSpecialPerformance.Visible = False
            End If

            If SrcSupplierPerformance = "Yes" Then
                MenuSrcSupplierPerformance.Visible = True
            Else
                MenuSrcSupplierPerformance.Visible = False
            End If

            If SrcSourcingCalendar = "Yes" Then
                MenuSrcSourcingCalendar.Visible = True
            Else
                MenuSrcSourcingCalendar.Visible = False
            End If

            If SrcSupplierSpendManager = "Yes" Then
                MenuSrcSupplierSpendManager.Visible = True
            Else
                MenuSrcSupplierSpendManager.Visible = False
            End If

            If SrcCostImpactCalculator = "Yes" Then
                MenuSrcCostImpactCalculator.Visible = True
            Else
                MenuSrcCostImpactCalculator.Visible = False
            End If

            If SrcOpenPOReport = "Yes" Then
                MenuSrcOpenPOReport.Visible = True
            Else
                MenuSrcOpenPOReport.Visible = False
            End If

            If SrcCostVarianceDashboard = "Yes" Then
                MenuSrcCostVarianceDashboard.Visible = True
            Else
                MenuSrcCostVarianceDashboard.Visible = False
            End If

            If SrcForecast = "Yes" Then
                MenuSrcForecast.Visible = True
            Else
                MenuSrcForecast.Visible = False
            End If


            'If MENUDashboardHB = "No" Or UserMENUDashboardHB = "No" Then
            'HuddleBoardDD.Visible = False
            'HBDivider.Visible = False
            'Else
            'HuddleBoardDD.Visible = True
            'HBDivider.Visible = True
            'End If

        End If

    End Sub



End Class