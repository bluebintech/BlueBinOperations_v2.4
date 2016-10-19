Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing


Partial Class AHRMM
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub TraySubmitB_Click(sender As Object, e As EventArgs) Handles TraySubmitB.Click

        Dim con2 As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        Using (con2)
            Dim cmd1 As New SqlCommand
            Dim cmd2 As New SqlCommand
            Dim cmd3 As New SqlCommand

            cmd1.Connection = con2
            cmd2.Connection = con2
            cmd3.Connection = con2

            cmd1.CommandText = "exec sp_AHRMMInsert 6,'BB001','0008673','A','1'"
            cmd2.CommandText = "exec sp_AHRMMInsert 6,'BB001','0008675','A','2'"
            cmd3.CommandText = "exec sp_AHRMMInsert 6,'BB001','0008776','A','12'"

            con2.Open()
            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            cmd3.ExecuteNonQuery()

            con2.Close()
        End Using

    End Sub

    Protected Sub TraySubmitSecondBinB_Click(sender As Object, e As EventArgs) Handles TraySubmitSecondBinB.Click


        Dim con2 As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        Using (con2)
            Dim cmd1 As New SqlCommand

            cmd1.Connection = con2

            cmd1.CommandText = "exec sp_AHRMMInsert 6,'BB001','0008673','B','1'"

            con2.Open()
            cmd1.ExecuteNonQuery()

            con2.Close()
        End Using




    End Sub

    Protected Sub TrayDeleteB_Click(sender As Object, e As EventArgs) Handles TrayDeleteB.Click

        Dim con2 As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Site_ConnectionString").ConnectionString)
        Using (con2)
            Dim cmd1 As New SqlCommand

            cmd1.Connection = con2

            cmd1.CommandText = "sp_AHRMMDelete"

            con2.Open()
            cmd1.ExecuteNonQuery()

            con2.Close()
        End Using
    End Sub




End Class