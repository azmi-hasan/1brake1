Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class goods_Report
    Inherits System.Web.UI.Page
    Dim con1 As OdbcConnection
    Dim cmd1 As New OdbcCommand
    Dim adp As New OdbcDataAdapter
    Dim rep As New ReportDocument
    Dim ds As DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con1 = New OdbcConnection("DRIVER={Microsoft Access Driver (*.mdb)};DBQ=c:\ebd_web_data\locodatabase.mdb;DefaultDir=;UID=;PWD=;")

        Dim DistanceCheck As Double
        Dim timrcheck1 As Integer = Val(Request.QueryString("RptQry_time"))
        adp = New OdbcDataAdapter("Select fieldSpeedkmph,fieldTime,fieldDistance from temp_LightEngine where fieldtime=" & timrcheck1 & "", con1)

        ds = New DataSet()
        adp.Fill(ds, "tempCheck")

        If ds.Tables("tempCheck").Rows.Count > 0 Then
            For Each dr In ds.Tables("tempCheck").Rows
                DistanceCheck = dr("fieldDistance")
            Next
        End If

        If DistanceCheck = Val(Request.QueryString("RptQry_distance")) Then

            Dim STRSELECT As String = "select fieldSpeedkmph, fieldTime,fieldDistance FROM temp_LightEngine"
            adp = New OdbcDataAdapter
            adp.SelectCommand = New OdbcCommand(STRSELECT, con1)
            ds = New DataSet()
            adp.Fill(ds, "temp_LightEngine")


            rep.Load(Server.MapPath("LightEngineChartNew.rpt"))
            rep.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rep

            CrystalReportViewer1.DataBind()
            CrystalReportViewer1.DisplayToolbar = True
            CrystalReportViewer1.HasPageNavigationButtons = True
            CrystalReportViewer1.HasPrintButton = True
        Else
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Try after some times');</script>")
            Exit Sub
        End If



    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        'cmd1.Connection = con1
        'cmd1.CommandText = "drop table temp_goods" 'dhs
        'con1.Open()
        'cmd1.ExecuteNonQuery()
        'con1.Close()

        Response.Redirect("Light_Engine.aspx")
    End Sub

End Class
