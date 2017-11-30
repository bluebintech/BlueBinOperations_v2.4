
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration


Partial Class QCNFormEdit
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim QCNID As String = Request.QueryString("QCNID")
        If Not Page.IsPostBack() Then
            'Comment
            'Comment
            Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
            con.Open()
            Dim da As New SqlDataAdapter("exec sp_SelectQCNFormEdit " + QCNID, con)
            Dim dt As New DataTable

            da.Fill(dt)

            'Dim KanbansFilled As Object = dt.Rows(0)("KanbansFilled")
            QCNIDTB.Text = QCNID.ToString()
            DateRequestedTB.Text = dt.Rows(0)("DateRequested").ToString()
            DateEnteredTB.Text = dt.Rows(0)("DateEntered").ToString()
            DateCompletedTB.Text = dt.Rows(0)("DateCompleted").ToString()
            LocationDD.SelectedValue = dt.Rows(0)("LocationID").ToString()
            FacilityDD.SelectedValue = dt.Rows(0)("FacilityID").ToString()
            RequesterTB.Text = dt.Rows(0)("RequesterUser").ToString()
            ApprovedByTB.Text = dt.Rows(0)("ApprovedBy").ToString()
            AssignedDD.SelectedValue = dt.Rows(0)("AssignedUser").ToString()
            QCNComplexityDD.SelectedValue = dt.Rows(0)("QCNComplexity").ToString()
            QCNTypeDD.SelectedValue = dt.Rows(0)("QCNType").ToString()
            ItemIDTB.Text = dt.Rows(0)("ItemID").ToString()
            ClinicalDescriptionTB.Text = dt.Rows(0)("ClinicalDescription").ToString()
            SequenceTB.Text = dt.Rows(0)("Sequence").ToString()
            QCNStatusDD.SelectedValue = dt.Rows(0)("QCNStatus").ToString()
            DetailsTB.Text = dt.Rows(0)("Details").ToString()
            UpdatesTB.Text = dt.Rows(0)("Updates").ToString()
            LastUpdatedTB.Text = dt.Rows(0)("LastUpdated").ToString()
            InternalReferenceTB.Text = dt.Rows(0)("InternalReference").ToString()
            ManuNumNameTB.Text = dt.Rows(0)("ManuNumName").ToString()
            LoggedByTB.Text = dt.Rows(0)("LoggedByUser").ToString()
            ParTB.Text = dt.Rows(0)("Par").ToString()
            UOMTB.Text = dt.Rows(0)("UOM").ToString()
            con.Close()
        End If
    End Sub


    Protected Sub QCNSubmit_Click(sender As Object, e As EventArgs) Handles QCNSubmit.Click
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        Dim cmd As New SqlCommand


        cmd.Connection = con
        con.Open()

        Dim UserLogin As String = Page.User.Identity.Name.ToString().ToLower()
        Dim QCNID As String
        Dim Location As String
        Dim Facility As String
        Dim Requester As String
        Dim ApprovedBy As String
        Dim Assigned As String
        Dim QCNComplexity As String
        Dim QCNType As String
        Dim ItemID As String
        Dim ClinicalDescription As String
        Dim Sequence As String
        Dim QCNStatus As String
        Dim Details As String
        Dim Updates As String
        Dim DateCompleted As String
        Dim LastUpdated As String
        Dim InternalReference As String
        Dim ManuNumName As String
        Dim Par As String
        Dim UOM As String


        QCNID = QCNIDTB.Text
        Location = LocationDD.SelectedItem.Value
        Facility = FacilityDD.SelectedItem.Value
        Requester = RequesterTB.Text
        ApprovedBy = ApprovedByTB.Text
        Assigned = AssignedDD.SelectedItem.Value
        QCNComplexity = QCNComplexityDD.SelectedItem.Value
        QCNType = QCNTypeDD.SelectedItem.Value
        ItemID = ItemIDTB.Text
        ClinicalDescription = ClinicalDescriptionTB.Text.ToUpper()
        Sequence = SequenceTB.Text.ToUpper()
        QCNStatus = QCNStatusDD.SelectedItem.Value
        Details = DetailsTB.Text
        Updates = UpdatesTB.Text
        DateCompleted = DateCompletedTB.Text
        LastUpdated = LastUpdatedTB.Text
        InternalReference = InternalReferenceTB.Text
        ManuNumName = ManuNumNameTB.Text
        Par = ParTB.Text
        UOM = UOMTB.Text.ToUpper()


        Details = Details.Replace("'", "''")
        Updates = Updates.Replace("'", "''")
        ClinicalDescription = ClinicalDescription.Replace("'", "''")
        InternalReference = InternalReference.Replace("'", "''")

        'If String.IsNullOrEmpty(AssignedDD.SelectedItem.Value.ToString()) Then
        'Assigned = ", "
        'End If

        cmd.CommandType = System.Data.CommandType.Text

        cmd.CommandText = "exec sp_EditQCN
                            '" & QCNID & "',
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
                            '" & InternalReference & "',
                            '" & ManuNumName & "',
                            '" & Par & "',
                            '" & UOM & "'

exec sp_InsertMasterLog '" & UserLogin & "','QCN','Edit QCN Form','" & QCNID & "'
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