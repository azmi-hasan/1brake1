Imports System.Data
Imports System.Data.Odbc

Partial Class home
    Inherits System.Web.UI.Page
    Dim con As OdbcConnection
    Dim myadapter As OdbcDataAdapter
    Dim mydataset As DataSet
    Dim cmd As New OdbcCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click

        con = New OdbcConnection("DRIVER={Microsoft Access Driver (*.mdb)};DBQ=c:\ebd_web_data\locodatabase.mdb;DefaultDir=;UID=;PWD=;")

        myadapter = New OdbcDataAdapter("Select * from test", con)
        mydataset = New DataSet
        myadapter.Fill(mydataset, "test")
        If mydataset.Tables("test").Rows.Count <= 0 Then
            Label2.Visible = True
            Label2.Text = "No Record found !!!"

        Else

            Label2.Visible = True
            Label2.Text = "Hello : " & txtUser.Text

        End If
        '' ''Label2.Visible = True
        '' ''Label2.Text = "Hello Friend!!!"
    End Sub
End Class
