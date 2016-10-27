Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Configuration
Imports System.Net.Mail
Imports System.Web.UI.WebControls


Partial Public Class QCN
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            GetData()
        End If
        GridViewQCN.DataBind()


        If Me.Page.User.Identity.IsAuthenticated Then
            Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
            Dim QCNReferenceC As String
            Dim QCNBulkCompleteC As String
            Dim OPQCNDashboardB As String

            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString

            Using conmenu As New SqlConnection(constr)
                Using cmdadmin As New SqlCommand("sp_ValidateMenus")

                    cmdadmin.CommandType = CommandType.StoredProcedure
                    cmdadmin.Connection = conmenu
                    conmenu.Open()

                    'QCN Dashboard Button
                    cmdadmin.Parameters.AddWithValue("@ConfigName", "OP-QCN Dashboard")
                    OPQCNDashboardB = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()

                    'QCN Bulk Complete
                    cmdadmin.Parameters.AddWithValue("@ConfigName", "QCN-Bulk CompleteC")
                    QCNBulkCompleteC = Convert.ToString(cmdadmin.ExecuteScalar())
                    cmdadmin.Parameters.Clear()

                    'QCN-ReferenceC
                    cmdadmin.Parameters.AddWithValue("@ConfigName", "QCN-ReferenceC")
                    QCNReferenceC = Convert.ToString(cmdadmin.ExecuteScalar())
                    conmenu.Close()
                End Using
            End Using

            If QCNBulkCompleteC = "Yes" Then
                GridViewQCN.Columns(1).Visible = True
                btnComplete.Visible = True
            Else
                GridViewQCN.Columns(1).Visible = False
                btnComplete.Visible = False

            End If

            If QCNReferenceC = "Yes" Then
                GridViewQCN.Columns(28).Visible = True
            Else
                GridViewQCN.Columns(28).Visible = False

            End If

            If OPQCNDashboardB = "Yes" Then
                QCNDashboardB.Visible = True
            Else
                QCNDashboardB.Visible = False
            End If

        End If

    End Sub
    Private Sub SetData()
        Dim currentCount As Integer = 0
        Dim chkAll As CheckBox = DirectCast(GridViewQCN.HeaderRow _
                        .Cells(0).FindControl("chkAll"), CheckBox)
        chkAll.Checked = True
        Dim arr As ArrayList = DirectCast(ViewState("SelectedRecords") _
                                        , ArrayList)
        For i As Integer = 0 To GridViewQCN.Rows.Count - 1
            Dim chk As CheckBox = DirectCast(GridViewQCN.Rows(i).Cells(0) _
                                         .FindControl("chk"), CheckBox)
            If chk IsNot Nothing Then
                chk.Checked = arr.Contains(GridViewQCN.DataKeys(i).Value)
                If Not chk.Checked Then
                    chkAll.Checked = False
                Else
                    currentCount += 1
                End If
            End If
        Next
        hfCount.Value = (arr.Count - currentCount).ToString()
    End Sub

    Protected Sub NewQCNB_Click(sender As Object, e As EventArgs) Handles NewQCNB.Click
        Response.Redirect("~/QCNForm")
        GridViewQCN.DataBind()
    End Sub

    Protected Sub QCNDashboardB_Click(sender As Object, e As EventArgs) Handles QCNDashboardB.Click
        'Response.Redirect("~/QCNReportViewer")
        Dim url As String = "QCNReportViewer.aspx"
        Response.Write("<script type='text/javascript'>window.open('" + url + "');</script>")
    End Sub

    Private Sub QCNDataSource_Selecting(sender As Object,
            e As SqlDataSourceSelectingEventArgs) Handles QCNDataSource.Selecting

        e.Command.CommandTimeout = 1000
    End Sub




    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cellLocation As TableCell = e.Row.Cells(6)
            Dim cellUpdates As TableCell = e.Row.Cells(21)
            'Dim cellDetails As TableCell = e.Row.Cells(12)
            cellLocation.ToolTip = "QCNID:" & TryCast(e.Row.DataItem, DataRowView)("QCNID").ToString()
            cellUpdates.ToolTip = TryCast(e.Row.DataItem, DataRowView)("UpdatesText").ToString()
            'cellDetails.ToolTip = TryCast(e.Row.DataItem, DataRowView)("DetailsText").ToString()
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cell As TableCell = e.Row.Cells(22)
            '        Dim cell2 As TableCell = e.Row.Cells(24)
            Dim quantity As Integer = Integer.Parse(cell.Text)
            '        Dim Status As String = cell2.Text
            If quantity > 30 Then
                cell.BackColor = Color.Red
            End If
            If quantity > 15 AndAlso quantity < 30 Then
                cell.BackColor = Color.Yellow
            End If
            '        If Status = "Hot" Or Status = "Critical" Then
            '            cell2.BackColor = Color.Red
            '        End If

        End If
    End Sub


    Protected Sub OnPaging(sender As Object, e As GridViewPageEventArgs)
        GridViewQCN.PageIndex = e.NewPageIndex
        GridViewQCN.DataBind()
        SetData()
    End Sub

    Protected Sub ExportToExcel(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=QCNExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridViewQCN.AllowPaging = False
            GridViewQCN.DataBind()
            GridViewQCN.HeaderRow.BackColor = Color.White
            GridViewQCN.HeaderRow.Cells(0).Visible = False

            For Each cell As TableCell In GridViewQCN.HeaderRow.Cells
                cell.BackColor = GridViewQCN.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewQCN.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewQCN.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewQCN.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewQCN.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub

    Protected Sub OnCheckedChanged(sender As Object, e As EventArgs)
        GridViewQCN.Columns(18).Visible = TryCast(sender, CheckBox).Checked

    End Sub

    Private Sub GetData()
        Dim arr As ArrayList
        If ViewState("SelectedRecords") IsNot Nothing Then
            arr = DirectCast(ViewState("SelectedRecords"), ArrayList)
        Else
            arr = New ArrayList()
        End If
        Dim chkAll As CheckBox = DirectCast(GridViewQCN.HeaderRow _
                    .Cells(0).FindControl("chkAll"), CheckBox)
        For i As Integer = 0 To GridViewQCN.Rows.Count - 1
            If chkAll.Checked Then
                If Not arr.Contains(GridViewQCN.DataKeys(i).Value) Then
                    arr.Add(GridViewQCN.DataKeys(i).Value)
                End If
            Else
                Dim chk As CheckBox = DirectCast(GridViewQCN.Rows(i).Cells(0) _
                                            .FindControl("chk"), CheckBox)
                If chk.Checked Then
                    If Not arr.Contains(GridViewQCN.DataKeys(i).Value) Then
                        arr.Add(GridViewQCN.DataKeys(i).Value)
                    End If
                Else
                    If arr.Contains(GridViewQCN.DataKeys(i).Value) Then
                        arr.Remove(GridViewQCN.DataKeys(i).Value)
                    End If
                End If
            End If
        Next
        ViewState("SelectedRecords") = arr
    End Sub

    Private Sub CompleteRecord(ByVal QCNID As String)
        Dim UserLoginText As String = Page.User.Identity.Name.ToString().ToLower()
        Dim CurrentDate As String = DateTime.Now.ToString("MM/dd/yyyy")
        Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        Dim query As String = "update qcn.QCN set QCNStatusID = (select QCNStatusID from qcn.QCNStatus where Status = 'Completed'), LastUpdated = getdate(), DateCompleted = getdate(),Updates = Updates + ' | Bulk Completed by " & UserLoginText & " on " & CurrentDate & "' where QCNID = @QCNID"
        Dim con As New SqlConnection(constr)
        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@QCNID", QCNID)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub ShowMessage(ByVal count As Integer)
        Dim sb As New StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("alert('")
        sb.Append(count.ToString())
        sb.Append(" records completed.');")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.GetType(),
                        "script", sb.ToString())
    End Sub

    Protected Sub btnComplete_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim count As Integer = 0
        SetData()
        GridViewQCN.AllowPaging = False
        GridViewQCN.DataBind()
        Dim arr As ArrayList = DirectCast(ViewState("SelectedRecords") _
                                        , ArrayList)
        count = arr.Count
        For i As Integer = 0 To GridViewQCN.Rows.Count - 1
            If arr.Contains(GridViewQCN.DataKeys(i).Value) Then
                CompleteRecord(GridViewQCN.DataKeys(i).Value.ToString())
                arr.Remove(GridViewQCN.DataKeys(i).Value)
            End If
        Next
        ViewState("SelectedRecords") = arr
        hfCount.Value = "0"
        GridViewQCN.AllowPaging = True
        GridViewQCN.DataBind()
        ShowMessage(count)
    End Sub
End Class


