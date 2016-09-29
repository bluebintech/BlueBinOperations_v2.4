Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Configuration
Imports System.Net.Mail
Imports System.Web.UI.WebControls

Partial Class ConesDeployed
    Inherits Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        'If FacilityDD.SelectedIndex > -1 And LocationDD.SelectedIndex > -1 And ClinicalDescriptionDD.SelectedIndex > -1 Then
        'ConesDeployed.Visible = True
        'Else ConesDeployed.Visible = False
        'End If


        If Me.Page.User.Identity.IsAuthenticated Then
            Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
            Dim UserConesEdit As String

            Dim constr As String = ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString

            Using conedit As New SqlConnection(constr)
                Using cmdadmin As New SqlCommand("sp_ValidateBlueBinRole")
                    cmdadmin.CommandType = CommandType.StoredProcedure
                    cmdadmin.Connection = conedit
                    conedit.Open()
                    cmdadmin.Parameters.AddWithValue("@UserLogin", UserLogin)
                    cmdadmin.Parameters.AddWithValue("@OpName", "MENU-Cones-EDIT")
                    UserConesEdit = Convert.ToString(cmdadmin.ExecuteScalar())

                    conedit.Close()
                End Using
            End Using

            If UserConesEdit = "Yes" Then
                GridViewCones.Columns(0).Visible = True
                ConesDeployedUtility.Visible = True
            Else
                GridViewCones.Columns(0).Visible = False
                ConesDeployedUtility.Visible = False
            End If


        End If
    End Sub

    Protected Sub ConesDeployed_Click(sender As Object, e As EventArgs) Handles ConesDeployed.Click
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        Dim cmd As New SqlCommand

        cmd.Connection = con
        con.Open()

        Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
        Dim Location As String
        Dim Item As String
        Dim Facility As String
        Dim ExpectedDelivery As String
        Dim SubProduct As String
        Dim Details As String

        Facility = FacilityDD.SelectedItem.Value
        Location = LocationDD.SelectedItem.Value
        Item = ClinicalDescriptionDD.SelectedItem.Value
        ExpectedDelivery = ExpectedDeliveryTB.Text
        Details = DetailsTB.Text
        SubProduct = SubProductDD.SelectedItem.Value

        cmd.CommandType = System.Data.CommandType.Text

        cmd.CommandText = "
                exec sp_InsertConesDeployed
                '" & Facility & "',
                '" & Location & "',
                '" & Item & "',
                '" & ExpectedDelivery & "',
                '" & SubProduct & "',
                '" & Details & "'
"
        cmd.ExecuteNonQuery()

        con.Close()

        Response.Redirect("~/ConesDeployed")
    End Sub



    Protected Sub ExportToExcelCones(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=ConesExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridViewCones.AllowPaging = False
            GridViewCones.DataBind()
            GridViewCones.HeaderRow.BackColor = Color.White
            GridViewCones.HeaderRow.Cells(0).Visible = False
            GridViewCones.FooterRow.Visible = False



            For Each cell As TableCell In GridViewCones.HeaderRow.Cells
                cell.BackColor = GridViewCones.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridViewCones.Rows
                row.BackColor = Color.White
                row.Cells(0).Visible = False
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridViewCones.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridViewCones.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"


                Next
            Next

            GridViewCones.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase))

            Response.[End]()
        End Using
    End Sub


    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cellUpdates As TableCell = e.Row.Cells(14)
            cellUpdates.ToolTip = TryCast(e.Row.DataItem, DataRowView)("DetailsText").ToString()
        End If

    End Sub


    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridViewCones.PageIndex = e.NewPageIndex
        GridViewCones.DataBind()
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub

End Class