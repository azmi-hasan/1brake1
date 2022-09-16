Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class goods_Report
    Inherits System.Web.UI.Page
    Dim con1 As OdbcConnection
    Dim cmd As New OdbcCommand
    Dim adp As New OdbcDataAdapter
    Dim rep As New ReportDocument
    Dim ds As DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con1 = New OdbcConnection("DRIVER={Microsoft Access Driver (*.mdb)};DBQ=c:\ebd_web_data\locodatabase.mdb;DefaultDir=;UID=;PWD=;")

        Dim STRSELECT As String = "select locomotive, weight FROM loco"
        adp = New OdbcDataAdapter
        adp.SelectCommand = New OdbcCommand(STRSELECT, con1)
        ds = New DataSet()
        adp.Fill(ds, "loco")

        'Response.Redirect("EMU_DMU_Report.aspx?RptEMUNoOfStock=" + LblEMUNoOfStock.Text + "&RptEMUSpeed=" + LblEMUSpeed.Text + "&RptEMUGrade=" + LblEMUGrade.Text + "&RptEMUEBD=" + LblEMUEBD.Text)

        rep.Load(Server.MapPath("EMU_DMU.rpt"))
        rep.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rep
        rep.DataDefinition.FormulaFields("NoOfStock").Text = " ' " & Request.QueryString("RptEMUNoOfStock") & "'"
        rep.DataDefinition.FormulaFields("Speed").Text = " ' " & Request.QueryString("RptEMUSpeed") & "'"
        rep.DataDefinition.FormulaFields("Grade").Text = " ' " & Request.QueryString("RptEMUGrade") & "'"
        rep.DataDefinition.FormulaFields("EBD").Text = " ' " & Request.QueryString("RptEMUEBD") & "'"

        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.DisplayToolbar = True
        CrystalReportViewer1.HasPageNavigationButtons = True
        CrystalReportViewer1.HasPrintButton = True



    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("emu_dmu.aspx")
    End Sub

End Class
