
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.UI.WebControls


Partial Class QCNForm
    Inherits Page
    Public Overridable Property AlternateText As String
    Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CurrentTimeTB.Text = DateTime.Now.ToString("MM/dd/yyyy")
        LoggedByTB.Text = UserLogin
    End Sub

    Protected Sub QCNSubmit_Click(sender As Object, e As EventArgs) Handles QCNSubmit.Click
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        Dim cmd As New SqlCommand


        cmd.Connection = con
        con.Open()

        Dim DateRequested As String

        Dim Location As String
        Dim Facility As String
        Dim ItemID As String
        Dim ClinicalDescription As String
        Dim Sequence As String
        Dim ApprovedBy As String
        Dim Requester As String
        Dim Assigned As String
        Dim QCNComplexity As String
        Dim QCNType As String
        Dim QCNStatus As String
        Dim Details As String
        Dim Updates As String
        Dim InternalReference As String
        Dim ManuNumName As String
        Dim Par As String
        Dim UOM As String


        DateRequested = DateRequestedTB.Text
        Location = LocationDD.SelectedItem.Value
        Facility = FacilityDD.SelectedItem.Value
        QCNType = QCNTypeDD.SelectedItem.Value
        ItemID = ItemIDTB.Text
        ClinicalDescription = ClinicalDescriptionTB.Text.ToUpper()
        Sequence = SequenceTB.Text.ToUpper()
        Requester = RequesterTB.Text
        ApprovedBy = ApprovedByTB.Text
        Assigned = AssignedDD.SelectedItem.Value
        QCNComplexity = QCNComplexityDD.SelectedItem.Value
        QCNType = QCNTypeDD.SelectedItem.Value
        QCNStatus = QCNStatusDD.SelectedItem.Value
        Details = DetailsTB.Text
        Updates = UpdatesTB.Text
        InternalReference = InternalReferenceTB.Text
        ManuNumName = ManuNumNameTB.Text
        Par = ParTB.Text
        UOM = UOMTB.Text.ToUpper()


        Details = Details.Replace("'", "''")
        Updates = Updates.Replace("'", "''")
        ClinicalDescription = ClinicalDescription.Replace("'", "''")
        InternalReference = InternalReference.Replace("'", "''")

        If String.IsNullOrEmpty(AssignedDD.SelectedItem.Value.ToString()) Then
            Assigned = ""
        End If


        cmd.CommandType = System.Data.CommandType.Text

        cmd.CommandText = "
                exec sp_InsertQCN
                '" & DateRequested & "',
                '" & Facility & "',
                '" & Location & "',
                '" & ItemID & "',
                '" & ClinicalDescription & "',
                '" & Sequence & "',
                '" & Requester & "',
                '" & ApprovedBy & "',
                '" & Assigned & "',
                '" & QCNComplexity & "',
                '" & QCNType & "',
                '" & Details & "',
                '" & Updates & "',
                '" & QCNStatus & "',
                '" & UserLogin & "',
                '" & InternalReference & "',
                '" & ManuNumName & "',
                '" & Par & "',
                '" & UOM & "'

"



        cmd.ExecuteNonQuery()

        con.Close()
        'MsgBox("New QCN Saved for " & Location)

        Response.Redirect("~/QCN")
    End Sub
    Protected Sub QCNCancel_Click(sender As Object, e As EventArgs) Handles QCNCancel.Click
        Response.Redirect("~/QCN")
    End Sub
End Class