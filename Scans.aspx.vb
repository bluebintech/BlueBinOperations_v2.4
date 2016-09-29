Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class Scans
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack() Then
            'Comment

            'Dim SqlDataSourceScan As New SqlDataSource()
            'SqlDataSourceScan.ID = "Site_ConnectionString"
            'Me.Page.Controls.Add(SqlDataSourceScan)
            'SqlDataSourceScan.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
            'SqlDataSourceScan.SelectCommand =
            '"exec sp_SelectScanBatch"
            'GridViewScan.DataSource = SqlDataSourceScan
            BatchViewL.Visible = True
            OpenLineViewL.Visible = False
            GridViewScan.Visible = True
            GridViewScanLinesOpen.Visible = False
            GridViewScan.DataBind()

            Dim ScanReceiveOptions As String
            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString

            Using conmenu As New SqlConnection(constr)
                Using cmdadmin As New SqlCommand("sp_ValidateMenus")

                    cmdadmin.CommandType = CommandType.StoredProcedure
                    cmdadmin.Connection = conmenu
                    conmenu.Open()

                    'ScanReceiveOptions
                    cmdadmin.Parameters.AddWithValue("@ConfigName", "MENU-Scanning-Receive")
                    ScanReceiveOptions = Convert.ToString(cmdadmin.ExecuteScalar())

                    conmenu.Close()
                End Using
            End Using

            If ScanReceiveOptions = "Yes" Then
                NewScanBatchReceive.Visible = True
                OpenLineViewB.Visible = True
                BatchViewB.Visible = True
                GridViewScan.Columns(11).Visible = True
            Else
                GridViewScanLinesOpen.Visible = False
                NewScanBatchReceive.Visible = False
                OpenLineViewB.Visible = False
                BatchViewB.Visible = False
                GridViewScan.Columns(11).Visible = False

            End If

        End If
    End Sub
    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cellExtracted As TableCell = e.Row.Cells(11)
            Dim cellMatched As TableCell = e.Row.Cells(12)
            If cellMatched.Text = "Yes" Then
                cellMatched.BackColor = Color.Green
            End If
            If cellMatched.Text = "Partial" Then
                cellMatched.BackColor = Color.LightYellow
            End If
            If cellExtracted.Text = "Yes" Then
                cellExtracted.BackColor = Color.Green
            End If
            If cellExtracted.Text = "Partial" Then
                cellExtracted.BackColor = Color.LightYellow
            End If


        End If
    End Sub

    Protected Sub OpenLineViewB_Click(sender As Object, e As EventArgs) Handles OpenLineViewB.Click
        GridViewScanLinesOpen.Visible = True
        GridViewScan.Visible = False
        BatchViewL.Visible = False
        OpenLineViewL.Visible = True
        GridViewScanLinesOpen.DataBind()
    End Sub

    Protected Sub BatchViewB_Click(sender As Object, e As EventArgs) Handles BatchViewB.Click
        GridViewScanLinesOpen.Visible = False
        GridViewScan.Visible = True
        BatchViewL.Visible = True
        OpenLineViewL.Visible = False

    End Sub

    Protected Sub NewScanBatch_Click(sender As Object, e As EventArgs) Handles NewScanBatch.Click
        Response.Redirect("~/ScanOrder")
        GridViewScan.DataBind()
    End Sub

    Protected Sub NewScanBatchReceive_Click(sender As Object, e As EventArgs) Handles NewScanBatchReceive.Click
        Response.Redirect("~/ScanReceive")
        GridViewScan.DataBind()
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridViewScan.PageIndex = e.NewPageIndex
        GridViewScan.DataBind()
    End Sub



End Class