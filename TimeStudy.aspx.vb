Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Configuration
Imports System.Net.Mail
Imports System.Web.UI.WebControls

Partial Class TimeStudy
    Inherits Page
    Dim CreatorUserLogin As String = Page.User.Identity.Name.ToString()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Me.Page.User.Identity.IsAuthenticated Then
            Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
            Dim UserGroupConfig As String
            Dim MenuGroupConfig As String

            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString

            Using conroles As New SqlConnection(constr)
                Using cmdadmin As New SqlCommand("sp_ValidateBlueBinRole")
                    cmdadmin.CommandType = CommandType.StoredProcedure
                    cmdadmin.Connection = conroles
                    conroles.Open()
                    'cmd.ExecuteNonQuery()
                    'command.Parameters["@id"].Value = rowUserID
                    'UserDocumentUplaod Utility
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "TimeStudy-GroupConfig")
                    UserGroupConfig = Convert.ToString(cmdadmin.ExecuteScalar())

                    conroles.Close()
                End Using


            End Using

            Using conmenu As New SqlConnection(constr)
                Using cmdmenu As New SqlCommand("sp_ValidateMenus")
                    cmdmenu.CommandType = CommandType.StoredProcedure
                    cmdmenu.Connection = conmenu
                    conmenu.Open()

                    'cmd.ExecuteNonQuery()
                    'MENU-TimeStudy-GroupConfig
                    cmdmenu.Parameters.AddWithValue("@ConfigName", "TimeStudy-GroupConfig")
                    MenuGroupConfig = Convert.ToString(cmdmenu.ExecuteScalar())

                    conmenu.Close()
                End Using
            End Using

            If UserGroupConfig = "No" Or MenuGroupConfig = "No" Then
                GroupConfigB.Visible = False
            Else
                GroupConfigB.Visible = True
            End If


        End If

        If Not Page.IsPostBack() Then
            SearchTable.Visible = True
            SearchTableGroupConfig.Visible = False
            TimeStudyMessageL.Text = ""
            SKUsTB.Text = ""
            StartTimeTB.Text = ""
            StopTimeTB.Text = ""
            CommentsTB.Text = ""
            FacilityDD.SelectedValue = ""
            LocationDD.SelectedValue = ""
            NodeServiceProcessDD.SelectedValue = ""
            StockOutProcessDD.SelectedValue = ""
            TravelLocationDD.SelectedValue = ""
            ServiceTechDD.SelectedValue = ""
            GroupConfigUtility.Visible = False
            TimeStudyUtility.Visible = True

            GridViewNodeService.DataBind()
            GridViewNodeService.Visible = True
            hiddenNodeService.Visible = True
            ExportNodeService.Visible = True
            GridViewBinFill.Visible = False
            hiddenBinFill.Visible = False
            ExportBinFill.Visible = False
            GridViewStockOut.Visible = False
            hiddenStockOut.Visible = False
            ExportStockOut.Visible = False
            GridViewStageScan.Visible = False
            hiddenStageScan.Visible = False
            ExportStageScan.Visible = False
            NodeServiceSubmitB.Visible = True
            BinFillSubmitB.Visible = False
            StageScanSubmitB.Visible = False
            StockOutSubmitB.Visible = False
            NodeServiceProcessRow.Visible = True
            StockOutProcessRow.Visible = False
            TravelLocationRow.Visible = True
            LocationRow.Visible = True

            GridViewGroupConfig.Visible = False
            HiddenGroupConfig.Visible = False
            GroupConfigSubmitB.Visible = False
            GroupConfigRow.Visible = False
            DescriptionRow.Visible = False

        End If
    End Sub

    Protected Sub StageScanB_Click(sender As Object, e As EventArgs) Handles StageScanB.Click
        SearchTable.Visible = True
        SearchTableGroupConfig.Visible = False
        TimeStudyMessageL.Text = ""
        SKUsTB.Text = ""
        StartTimeTB.Text = ""
        StopTimeTB.Text = ""
        CommentsTB.Text = ""
        FacilityDD.SelectedValue = ""
        LocationDD.SelectedValue = ""
        NodeServiceProcessDD.SelectedValue = ""
        StockOutProcessDD.SelectedValue = ""
        TravelLocationDD.SelectedValue = ""
        ServiceTechDD.SelectedValue = ""
        GroupConfigUtility.Visible = False
        TimeStudyUtility.Visible = True

        GridViewNodeService.Visible = False
        hiddenNodeService.Visible = False
        ExportNodeService.Visible = False
        GridViewBinFill.Visible = False
        hiddenBinFill.Visible = False
        ExportBinFill.Visible = False
        GridViewStockOut.Visible = False
        hiddenStockOut.Visible = False
        ExportStockOut.Visible = False
        GridViewStageScan.DataBind()
        GridViewStageScan.Visible = True
        hiddenStageScan.Visible = True
        ExportStageScan.Visible = True
        NodeServiceSubmitB.Visible = False
        BinFillSubmitB.Visible = False
        StageScanSubmitB.Visible = True
        StockOutSubmitB.Visible = False
        NodeServiceProcessRow.Visible = False
        StockOutProcessRow.Visible = False
        TravelLocationRow.Visible = False
        LocationRow.Visible = True
        GridViewGroupConfig.Visible = False
        HiddenGroupConfig.Visible = False
        GroupConfigSubmitB.Visible = False
        GroupConfigRow.Visible = False
        DescriptionRow.Visible = False
    End Sub
    'Protected Sub StageScanB2_Click(sender As Object, e As EventArgs) Handles StageScanB2.Click
    '    Response.Redirect("~/TimeStudyStageScan")
    'End Sub

    Protected Sub StockOutB_Click(sender As Object, e As EventArgs) Handles StockOutB.Click
        SearchTable.Visible = True
        SearchTableGroupConfig.Visible = False
        TimeStudyMessageL.Text = ""
        SKUsTB.Text = ""
        StartTimeTB.Text = ""
        StopTimeTB.Text = ""
        CommentsTB.Text = ""
        FacilityDD.SelectedValue = ""
        LocationDD.SelectedValue = ""
        NodeServiceProcessDD.SelectedValue = ""
        StockOutProcessDD.SelectedValue = ""
        TravelLocationDD.SelectedValue = ""
        ServiceTechDD.SelectedValue = ""
        GroupConfigUtility.Visible = False
        TimeStudyUtility.Visible = True

        GridViewNodeService.Visible = False
        hiddenNodeService.Visible = False
        ExportNodeService.Visible = False
        GridViewBinFill.Visible = False
        hiddenBinFill.Visible = False
        ExportBinFill.Visible = False
        GridViewStockOut.DataBind()
        GridViewStockOut.Visible = True
        hiddenStockOut.Visible = True
        ExportStockOut.Visible = True
        GridViewStageScan.Visible = False
        hiddenStageScan.Visible = False
        ExportStageScan.Visible = False
        NodeServiceSubmitB.Visible = False
        BinFillSubmitB.Visible = False
        StageScanSubmitB.Visible = False
        StockOutSubmitB.Visible = True
        NodeServiceProcessRow.Visible = False
        StockOutProcessRow.Visible = True
        TravelLocationRow.Visible = False
        LocationRow.Visible = False
        GridViewGroupConfig.Visible = False
        HiddenGroupConfig.Visible = False
        GroupConfigSubmitB.Visible = False
        GroupConfigRow.Visible = False
        DescriptionRow.Visible = False
    End Sub
    'Protected Sub StockOutB2_Click(sender As Object, e As EventArgs) Handles StockOutB2.Click
    '    Response.Redirect("~/TimeStudyStockOut")
    'End Sub

    Protected Sub BinFillB_Click(sender As Object, e As EventArgs) Handles BinFillB.Click
        SearchTable.Visible = True
        SearchTableGroupConfig.Visible = False
        TimeStudyMessageL.Text = ""
        SKUsTB.Text = ""
        StartTimeTB.Text = ""
        StopTimeTB.Text = ""
        CommentsTB.Text = ""
        FacilityDD.SelectedValue = ""
        LocationDD.SelectedValue = ""
        NodeServiceProcessDD.SelectedValue = ""
        StockOutProcessDD.SelectedValue = ""
        TravelLocationDD.SelectedValue = ""
        ServiceTechDD.SelectedValue = ""
        GroupConfigUtility.Visible = False
        TimeStudyUtility.Visible = True

        GridViewNodeService.Visible = False
        hiddenNodeService.Visible = False
        ExportNodeService.Visible = False
        GridViewBinFill.DataBind()
        GridViewBinFill.Visible = True
        hiddenBinFill.Visible = True
        ExportBinFill.Visible = True
        GridViewStockOut.Visible = False
        hiddenStockOut.Visible = False
        ExportStockOut.Visible = False
        GridViewStageScan.Visible = False
        hiddenStageScan.Visible = False
        ExportStageScan.Visible = False
        NodeServiceSubmitB.Visible = False
        BinFillSubmitB.Visible = True
        StageScanSubmitB.Visible = False
        StockOutSubmitB.Visible = False
        NodeServiceProcessRow.Visible = False
        StockOutProcessRow.Visible = False
        TravelLocationRow.Visible = False
        LocationRow.Visible = True
        GridViewGroupConfig.Visible = False
        HiddenGroupConfig.Visible = False
        GroupConfigSubmitB.Visible = False
        GroupConfigRow.Visible = False
        DescriptionRow.Visible = False
    End Sub
    'Protected Sub BinFillB2_Click(sender As Object, e As EventArgs) Handles BinFillB2.Click
    '    Response.Redirect("~/TimeStudyBinFill")
    'End Sub

    Protected Sub NodeServiceB_Click(sender As Object, e As EventArgs) Handles NodeServiceB.Click
        SearchTable.Visible = True
        SearchTableGroupConfig.Visible = False
        TimeStudyMessageL.Text = ""
        SKUsTB.Text = ""
        StartTimeTB.Text = ""
        StopTimeTB.Text = ""
        CommentsTB.Text = ""
        FacilityDD.SelectedValue = ""
        LocationDD.SelectedValue = ""
        NodeServiceProcessDD.SelectedValue = ""
        StockOutProcessDD.SelectedValue = ""
        TravelLocationDD.SelectedValue = ""
        ServiceTechDD.SelectedValue = ""
        GroupConfigUtility.Visible = False
        TimeStudyUtility.Visible = True

        GridViewNodeService.DataBind()
        GridViewNodeService.Visible = True
        hiddenNodeService.Visible = True
        ExportNodeService.Visible = True
        GridViewBinFill.Visible = False
        hiddenBinFill.Visible = False
        ExportBinFill.Visible = False
        GridViewStockOut.Visible = False
        hiddenStockOut.Visible = False
        ExportStockOut.Visible = False
        GridViewStageScan.Visible = False
        hiddenStageScan.Visible = False
        ExportStageScan.Visible = False
        NodeServiceSubmitB.Visible = True
        BinFillSubmitB.Visible = False
        StageScanSubmitB.Visible = False
        StockOutSubmitB.Visible = False
        NodeServiceProcessRow.Visible = True
        StockOutProcessRow.Visible = False
        TravelLocationRow.Visible = True
        LocationRow.Visible = True
        GridViewGroupConfig.Visible = False
        HiddenGroupConfig.Visible = False
        GroupConfigSubmitB.Visible = False
        GroupConfigRow.Visible = False
        DescriptionRow.Visible = False
    End Sub

    Protected Sub GroupConfigB_Click(sender As Object, e As EventArgs) Handles GroupConfigB.Click
        SearchTable.Visible = False
        SearchTableGroupConfig.Visible = True
        TimeStudyMessageL.Text = ""
        SKUsTB.Text = ""
        StartTimeTB.Text = ""
        StopTimeTB.Text = ""
        CommentsTB.Text = ""
        FacilityDD.SelectedValue = ""
        LocationDD.SelectedValue = ""
        NodeServiceProcessDD.SelectedValue = ""
        StockOutProcessDD.SelectedValue = ""
        TravelLocationDD.SelectedValue = ""
        ServiceTechDD.SelectedValue = ""
        GroupConfigUtility.Visible = True
        TimeStudyUtility.Visible = False

        GridViewNodeService.Visible = False
        hiddenNodeService.Visible = False
        ExportNodeService.Visible = False
        GridViewBinFill.Visible = False
        hiddenBinFill.Visible = False
        ExportBinFill.Visible = False
        GridViewStockOut.Visible = False
        hiddenStockOut.Visible = False
        ExportStockOut.Visible = False
        GridViewStageScan.Visible = False
        hiddenStageScan.Visible = False
        ExportStageScan.Visible = False
        NodeServiceSubmitB.Visible = False
        BinFillSubmitB.Visible = False
        StageScanSubmitB.Visible = False
        StockOutSubmitB.Visible = False
        NodeServiceProcessRow.Visible = False
        StockOutProcessRow.Visible = False
        TravelLocationRow.Visible = False
        LocationRow.Visible = True
        GridViewGroupConfig.DataBind()
        GridViewGroupConfig.Visible = True
        HiddenGroupConfig.Visible = True
        GroupConfigSubmitB.Visible = True
        GroupConfigRow.Visible = True
        DescriptionRow.Visible = True
    End Sub

    Protected Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click

        If TimeStudyMessageL.Text <> "" Then
            TimeStudyMessageL.Text = ""
        End If

    End Sub

    Protected Sub SearchButtonGroupConfig_Click(sender As Object, e As EventArgs) Handles SearchButtonGroupConfig.Click

        If GroupConfigMessageL.Text <> "" Then
            GroupConfigMessageL.Text = ""
        End If

    End Sub


    'Protected Sub NodeServiceB2_Click(sender As Object, e As EventArgs) Handles NodeServiceB2.Click
    '    Response.Redirect("~/TimeStudyNodeService")
    'End Sub
    Protected Sub NodeServiceSubmitB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NodeServiceSubmitB.Click
        'Make sure a file has been successfully uploaded
        Dim StartTime As DateTime = DateTime.Parse(StartTimeTB.Text)
        Dim StopTime As DateTime = DateTime.Parse(StopTimeTB.Text)

        If StopTime < StartTime Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Stop Time must be greater than Start Time."
            Exit Sub
        End If

        If NodeServiceProcessDD.SelectedItem.ToString() = "Travel time to next node" And TravelLocationDD.SelectedValue.ToString() = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "You must select a Travel To Node.  Blank entries are invalid"
            Exit Sub
        End If
        If NodeServiceProcessDD.SelectedValue.ToString() = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no Process Type Selected."
            Exit Sub
        End If
        If FacilityDD.SelectedValue.ToString() = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no Facility Selected."
            Exit Sub
        End If
        If LocationDD.SelectedValue.ToString() = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no Location Selected."
            Exit Sub
        End If
        If SKUsTB.Text = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no SKU entries."
            Exit Sub
        End If

        'TimeStudyMessageL.Text = "exec sp_InsertTimeStudyBinFill" + FacilityDD.SelectedValue.ToString() + "," + LocationDD.SelectedValue.ToString() + "," + TravelLocationDD.SelectedValue.ToString() + "," + NodeServiceProcessDD.SelectedValue.ToString() + "," + StartTimeTB.Text + "," + StopTimeTB.Text + "," + SKUsTB.Text + "," + CommentsTB.Text + "," + CreatorUserLogin
        'Connect to the database and insert a new record into Products
        Using myConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            Const SQL As String = "exec sp_InsertTimeStudyNodeService @FacilityID,@LocationID,@TravelLocationID,@TimeStudyProcessID,@StartTime,@StopTime,@SKUS,@Comments,@BlueBinUser,@BlueBinResourceID"
            Dim myCommand As New SqlCommand(SQL, myConnection)
            Dim TravelLocation As String = TravelLocationDD.SelectedValue.ToString()
            Dim NodeServiceProcess As String = NodeServiceProcessDD.SelectedItem.ToString()
            If TravelLocation <> "" And NodeServiceProcess <> "Travel time to next node" Then
                TravelLocation = ""
            End If

            myCommand.Parameters.AddWithValue("@FacilityID", FacilityDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@LocationID", LocationDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@TravelLocationID", TravelLocation)
            myCommand.Parameters.AddWithValue("@TimeStudyProcessID", NodeServiceProcessDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@StartTime", StartTimeTB.Text)
            myCommand.Parameters.AddWithValue("@StopTime", StopTimeTB.Text)
            myCommand.Parameters.AddWithValue("@SKUS", SKUsTB.Text)
            myCommand.Parameters.AddWithValue("@Comments", CommentsTB.Text)
            myCommand.Parameters.AddWithValue("@BlueBinUser", CreatorUserLogin)
            myCommand.Parameters.AddWithValue("@BlueBinResourceID", ServiceTechDD.SelectedValue.ToString())


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Green
            TimeStudyMessageL.Text = "Time Study Entry Successful Successfully"

        End Using
        NodeServiceProcessDD.SelectedValue = ""
        TravelLocationDD.SelectedValue = ""
        CommentsTB.Text = ""
        GridViewNodeService.DataBind()

    End Sub

    Protected Sub StageScanSubmitB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StageScanSubmitB.Click
        'Make sure a file has been successfully uploaded
        Dim StartTime As DateTime = DateTime.Parse(StartTimeTB.Text)
        Dim StopTime As DateTime = DateTime.Parse(StopTimeTB.Text)

        If StopTime < StartTime Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Stop Time must be greater than Start Time."
            Exit Sub
        End If

        If FacilityDD.SelectedValue.ToString() = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no Facility Selected."
            Exit Sub
        End If
        If LocationDD.SelectedValue.ToString() = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no Location Selected."
            Exit Sub
        End If
        If SKUsTB.Text = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no SKU entries."
            Exit Sub
        End If

        'TimeStudyMessageL.Text = "exec sp_InsertTimeStudyBinFill" + FacilityDD.SelectedValue.ToString() + "," + LocationDD.SelectedValue.ToString() + "," + TravelLocationDD.SelectedValue.ToString() + "," + StageScanProcessDD.SelectedValue.ToString() + "," + StartTimeTB.Text + "," + StopTimeTB.Text + "," + SKUsTB.Text + "," + CommentsTB.Text + "," + CreatorUserLogin
        'Connect to the database and insert a new record into Products
        Using myConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            Const SQL As String = "exec sp_InsertTimeStudyStageScan @FacilityID,@LocationID,@StartTime,@StopTime,@SKUS,@Comments,@BlueBinUser,@BlueBinResourceID"
            Dim myCommand As New SqlCommand(SQL, myConnection)
            myCommand.Parameters.AddWithValue("@FacilityID", FacilityDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@LocationID", LocationDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@StartTime", StartTimeTB.Text)
            myCommand.Parameters.AddWithValue("@StopTime", StopTimeTB.Text)
            myCommand.Parameters.AddWithValue("@SKUS", SKUsTB.Text)
            myCommand.Parameters.AddWithValue("@Comments", CommentsTB.Text)
            myCommand.Parameters.AddWithValue("@BlueBinUser", CreatorUserLogin)
            myCommand.Parameters.AddWithValue("@BlueBinResourceID", ServiceTechDD.SelectedValue.ToString())


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Green
            TimeStudyMessageL.Text = "Time Study Entry Successful Successfully"

        End Using

        CommentsTB.Text = ""
        GridViewStageScan.DataBind()

    End Sub

    Protected Sub BinFillSubmitB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BinFillSubmitB.Click
        'Make sure a file has been successfully uploaded
        Dim StartTime As DateTime = DateTime.Parse(StartTimeTB.Text)
        Dim StopTime As DateTime = DateTime.Parse(StopTimeTB.Text)

        If StopTime < StartTime Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Stop Time must be greater than Start Time."
            Exit Sub
        End If
        If FacilityDD.SelectedValue.ToString() = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no Facility Selected."
            Exit Sub
        End If
        If LocationDD.SelectedValue.ToString() = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no Location Selected."
            Exit Sub
        End If
        If SKUsTB.Text = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no SKU entries."
            Exit Sub
        End If

        'TimeStudyMessageL.Text = "exec sp_InsertTimeStudyBinFill" + FacilityDD.SelectedValue.ToString() + "," + LocationDD.SelectedValue.ToString() + "," + TravelLocationDD.SelectedValue.ToString() + "," + BinFillProcessDD.SelectedValue.ToString() + "," + StartTimeTB.Text + "," + StopTimeTB.Text + "," + SKUsTB.Text + "," + CommentsTB.Text + "," + CreatorUserLogin
        'Connect to the database and insert a new record into Products
        Using myConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            Const SQL As String = "exec sp_InsertTimeStudyBinFill @FacilityID,@LocationID,@StartTime,@StopTime,@SKUS,@Comments,@BlueBinUser,@BlueBinResourceID"
            Dim myCommand As New SqlCommand(SQL, myConnection)
            myCommand.Parameters.AddWithValue("@FacilityID", FacilityDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@LocationID", LocationDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@StartTime", StartTimeTB.Text)
            myCommand.Parameters.AddWithValue("@StopTime", StopTimeTB.Text)
            myCommand.Parameters.AddWithValue("@SKUS", SKUsTB.Text)
            myCommand.Parameters.AddWithValue("@Comments", CommentsTB.Text)
            myCommand.Parameters.AddWithValue("@BlueBinUser", CreatorUserLogin)
            myCommand.Parameters.AddWithValue("@BlueBinResourceID", ServiceTechDD.SelectedValue.ToString())


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Green
            TimeStudyMessageL.Text = "Time Study Entry Successful Successfully"

        End Using

        CommentsTB.Text = ""
        GridViewBinFill.DataBind()

    End Sub
    Protected Sub StockOutSubmitB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StockOutSubmitB.Click
        'Make sure a file has been successfully uploaded
        Dim StartTime As DateTime = DateTime.Parse(StartTimeTB.Text)
        Dim StopTime As DateTime = DateTime.Parse(StopTimeTB.Text)

        If StopTime < StartTime Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Stop Time must be greater than Start Time."
            Exit Sub
        End If

        If StockOutProcessDD.SelectedValue.ToString() = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no Process Type Selected."
            Exit Sub
        End If
        If FacilityDD.SelectedValue.ToString() = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no Facility Selected."
            Exit Sub
        End If

        If SKUsTB.Text = "" Then
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Red
            TimeStudyMessageL.Text = "Time Study Entry Invalid, no SKU entries."
            Exit Sub
        End If

        'TimeStudyMessageL.Text = "exec sp_InsertTimeStudyStockOut" + FacilityDD.SelectedValue.ToString() + "," + LocationDD.SelectedValue.ToString() + "," + TravelLocationDD.SelectedValue.ToString() + "," + StockOutProcessDD.SelectedValue.ToString() + "," + StartTimeTB.Text + "," + StopTimeTB.Text + "," + SKUsTB.Text + "," + CommentsTB.Text + "," + CreatorUserLogin
        'Connect to the database and insert a new record into Products
        Using myConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            Const SQL As String = "exec sp_InsertTimeStudyStockOut @FacilityID,@LocationID,@TimeStudyProcessID,@StartTime,@StopTime,@SKUS,@Comments,@BlueBinUser,@BlueBinResourceID"
            Dim myCommand As New SqlCommand(SQL, myConnection)
            myCommand.Parameters.AddWithValue("@FacilityID", FacilityDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@LocationID", LocationDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@TimeStudyProcessID", StockOutProcessDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@StartTime", StartTimeTB.Text)
            myCommand.Parameters.AddWithValue("@StopTime", StopTimeTB.Text)
            myCommand.Parameters.AddWithValue("@SKUS", SKUsTB.Text)
            myCommand.Parameters.AddWithValue("@Comments", CommentsTB.Text)
            myCommand.Parameters.AddWithValue("@BlueBinUser", CreatorUserLogin)
            myCommand.Parameters.AddWithValue("@BlueBinResourceID", ServiceTechDD.SelectedValue.ToString())


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()
            TimeStudyMessageL.ForeColor = System.Drawing.Color.Green
            TimeStudyMessageL.Text = "Time Study Entry Successful Successfully"

        End Using
        StockOutProcessDD.SelectedValue = ""
        CommentsTB.Text = ""
        GridViewStockOut.DataBind()

    End Sub

    Protected Sub GroupConfigSubmitB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupConfigSubmitB.Click
        'Make sure a file has been successfully uploaded

        If GroupConfigTB.Text = "" Or GroupFacilityDD.SelectedValue = "" Or GroupLocationDD.SelectedValue = "" Then
            GroupConfigMessageL.ForeColor = System.Drawing.Color.Red
            GroupConfigMessageL.Text = "Group Entry Invalid, Missing Required Fields."
            Exit Sub
        End If

        'TimeStudyMessageL.Text = "exec sp_InsertTimeStudyStockOut" + FacilityDD.SelectedValue.ToString() + "," + LocationDD.SelectedValue.ToString() + "," + TravelLocationDD.SelectedValue.ToString() + "," + StockOutProcessDD.SelectedValue.ToString() + "," + StartTimeTB.Text + "," + StopTimeTB.Text + "," + SKUsTB.Text + "," + CommentsTB.Text + "," + CreatorUserLogin
        'Connect to the database and insert a new record into Products
        Using myConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            Const SQL As String = "exec sp_InsertTimeStudyGroup @FacilityID,@LocationID,@GroupName,@Description,@BlueBinUser"
            Dim myCommand As New SqlCommand(SQL, myConnection)
            myCommand.Parameters.AddWithValue("@FacilityID", GroupFacilityDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@LocationID", GroupLocationDD.SelectedValue.ToString())
            myCommand.Parameters.AddWithValue("@GroupName", GroupConfigTB.Text)
            myCommand.Parameters.AddWithValue("@Description", DescriptionTB.Text)
            myCommand.Parameters.AddWithValue("@BlueBinUser", CreatorUserLogin)



            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()
            GroupConfigMessageL.ForeColor = System.Drawing.Color.Green
            GroupConfigMessageL.Text = "Time Study Entry Successful Successfully"

        End Using

        GridViewGroupConfig.DataBind()

    End Sub

    Protected Sub ExportToExcelNodeService(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=UsersExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridViewNodeService.AllowPaging = False
            GridViewNodeService.DataBind()
            GridViewNodeService.HeaderRow.BackColor = Color.White
            GridViewNodeService.HeaderRow.Cells(0).Visible = False
            GridViewNodeService.FooterRow.Visible = False

            For Each cell As TableCell In GridViewNodeService.HeaderRow.Cells
                cell.BackColor = GridViewNodeService.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewNodeService.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewNodeService.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewNodeService.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewNodeService.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub


    Protected Sub ExportToExcelBinFill(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename= UsersExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridViewBinFill.AllowPaging = False
            GridViewBinFill.DataBind()
            GridViewBinFill.HeaderRow.BackColor = Color.White
            GridViewBinFill.HeaderRow.Cells(0).Visible = False
            GridViewBinFill.FooterRow.Visible = False

            For Each cell As TableCell In GridViewBinFill.HeaderRow.Cells
                cell.BackColor = GridViewBinFill.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewBinFill.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewBinFill.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewBinFill.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewBinFill.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub
    Protected Sub ExportToExcelStockOut(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=UsersExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridViewStockOut.AllowPaging = False
            GridViewStockOut.DataBind()
            GridViewStockOut.HeaderRow.BackColor = Color.White
            GridViewStockOut.HeaderRow.Cells(0).Visible = False
            GridViewStockOut.FooterRow.Visible = False

            For Each cell As TableCell In GridViewStockOut.HeaderRow.Cells
                cell.BackColor = GridViewStockOut.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewStockOut.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewStockOut.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewStockOut.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewStockOut.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub

    Protected Sub ExportToExcelStageScan(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=UsersExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridViewStageScan.AllowPaging = False
            GridViewStageScan.DataBind()
            GridViewStageScan.HeaderRow.BackColor = Color.White
            GridViewStageScan.HeaderRow.Cells(0).Visible = False
            GridViewStageScan.FooterRow.Visible = False

            For Each cell As TableCell In GridViewStageScan.HeaderRow.Cells
                cell.BackColor = GridViewStageScan.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewStageScan.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewStageScan.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewStageScan.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewStageScan.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub

    Protected Sub GridViewNodeService_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
    End Sub
    Protected Sub GridViewBinFill_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
    End Sub
    'Protected Sub GridViewStageScan_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
    'End Sub
    'Protected Sub GridViewStockOut_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
    'End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub

End Class