Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Configuration

Partial Class ScansDetails
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim ScanBatchID As String = Request.QueryString("ScanBatchID")

        Dim SqlDataSourceScanOrder As New SqlDataSource()
            SqlDataSourceScanOrder.ID = "SqlDataSourceScanOrder"
            Me.Page.Controls.Add(SqlDataSourceScanOrder)
            SqlDataSourceScanOrder.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        SqlDataSourceScanOrder.SelectCommand = "exec sp_SelectScanLines " & ScanBatchID
        GridViewScanOrder.DataSource = SqlDataSourceScanOrder

        Dim SqlDataSourceScanReceive As New SqlDataSource()
        SqlDataSourceScanReceive.ID = "SqlDataSourceScanReceive"
        Me.Page.Controls.Add(SqlDataSourceScanReceive)
        SqlDataSourceScanReceive.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString
        SqlDataSourceScanReceive.SelectCommand = "exec sp_SelectScanLinesReceive " & ScanBatchID
        GridViewScanReceive.DataSource = SqlDataSourceScanReceive

        GridViewScanReceive.DataBind()
        GridViewScanOrder.DataBind()
    End Sub

    Protected Sub ScansDetailsCancel_Click(sender As Object, e As EventArgs) Handles ScansDetailsCancel.Click
        Response.Redirect("~/Scans")
    End Sub

End Class