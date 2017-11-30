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

Partial Public Class ClinicalManagementReport
    Inherits Page
    Protected TableauFullURL As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not Me.Page.User.Identity.IsAuthenticated Then
        'FormsAuthentication.RedirectToLoginPage()
        'End If


        'If Me.Page.User.Identity.IsAuthenticated Then
        Dim GenericLogin As String
        Dim TableauSite As String
        Dim TableauWorkbook As String
        Dim TableauURL As String
        Dim DashBoardWorkbook As String
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
                'Tableau Workbook Name set value in site configuration here
                cmdtableau.Parameters.AddWithValue("@ConfigName", "CMRWorkbook")
                DashBoardWorkbook = Convert.ToString(cmdtableau.ExecuteScalar())
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

        'Set the Name of the Page and the Refresh Text
        DBTitleL.Text = TableauWorkbook

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
        'Set the Dashboard Name below
        TableauFullURL = TableauURL & "/trusted/" & responseFromServer & "/t/" & TableauSite & "/views/" & DashBoardWorkbook & "/ClinicalManagementReport&:toolbar=no&:toolbar=bottom"

        con.Close()
        'End If
    End Sub

End Class


