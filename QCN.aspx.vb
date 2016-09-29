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

        GridViewQCN.DataBind()


        If Me.Page.User.Identity.IsAuthenticated Then
            Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
            Dim QCNReferenceC As String
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

                    'QCN-ReferenceC
                    cmdadmin.Parameters.AddWithValue("@ConfigName", "QCN-ReferenceC")
                    QCNReferenceC = Convert.ToString(cmdadmin.ExecuteScalar())
                    conmenu.Close()
                End Using
            End Using

            If QCNReferenceC = "Yes" Then
                GridViewQCN.Columns(27).Visible = True
            Else
                GridViewQCN.Columns(27).Visible = False

            End If

            If OPQCNDashboardB = "Yes" Then
                QCNDashboardB.Visible = True
            Else
                QCNDashboardB.Visible = False
            End If

        End If

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
            Dim cellLocation As TableCell = e.Row.Cells(5)
            Dim cellUpdates As TableCell = e.Row.Cells(20)
            'Dim cellDetails As TableCell = e.Row.Cells(12)
            cellLocation.ToolTip = "QCNID:" & TryCast(e.Row.DataItem, DataRowView)("QCNID").ToString()
            cellUpdates.ToolTip = TryCast(e.Row.DataItem, DataRowView)("UpdatesText").ToString()
            'cellDetails.ToolTip = TryCast(e.Row.DataItem, DataRowView)("DetailsText").ToString()
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cell As TableCell = e.Row.Cells(21)
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


    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridViewQCN.PageIndex = e.NewPageIndex
        GridViewQCN.DataBind()
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
        GridViewQCN.Columns(17).Visible = TryCast(sender, CheckBox).Checked

    End Sub

End Class


