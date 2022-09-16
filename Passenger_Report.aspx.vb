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
        'rpt.DataDefinition.FormulaFields("strReportDate").Text = "'" & Format(ReportDate, "dd/MM/yyyy") & "'"
        'Response.Redirect("Passenger_Report.aspx?RptPassengerLocoType=" + LblPassengerLocoType.Text + "&RptPassengerNoOfLoco=" + LblPassengerNoOfLoco.Text + "&RptPassengerLocoBrakeBlock=" + LblPassengerLocoBrakeBlock.Text + "&RptPassengerStockBrakeBlock=" + LblPassengerStockBrakeBlock.Text + "&RptPassengerNoOfStock=" + LblPassengerNoOfStock.Text + "&RptPassengerBCPressure=" + LblPassengerBCPressure.Text + "&RptPassengerSpeed=" + LblPassengerSpeed.Text + "&RptPassengerGrade=" + LblPassengerGrade.Text + "&RptPassengerEBD=" + LblPassengerEBD.Text)

        'LblPassengerLocoType.Text = DDPassengerLocoType.Text
        'LblPassengerNoOfLoco.Text = DDPassengerNoOfLoco.Text
        'LblPassengerLocoBrakeBlock.Text = DDPassengerLocoBrakeBlock.SelectedItem.Text
        'LblPassengerStockBrakeBlock.Text = DDPassengerStockBrakeBlock.SelectedItem.Text
        'LblPassengerNoOfStock.Text = Text6.Text
        'For i = ListBoxTrComposition.Items.Count - 1 To 0 Step -1
        '    LblPassengerNoOfStock.Text = LblPassengerNoOfStock.Text & "," & (ListBoxTrComposition.Items(i).Text)
        'Next

        'LblPassengerBCPressure.Text = DDPassengerBCPressure.Text
        'LblPassengerBrakePower.Text = DDPassengerBrakePower.Text
        'LblPassengerSpeed.Text = DDPassengerSpeed.Text
        'LblPassengerGrade.Text = DDPassengerGrade.Text
        'LblPassengerEBD.Text = FinalDistance
        'Response.Redirect("Passenger_Report.aspx?RptPassengerLocoType=" + LblPassengerLocoType.Text + "&RptPassengerNoOfLoco=" + LblPassengerNoOfLoco.Text + "&RptPassengerLocoBrakeBlock=" + LblPassengerLocoBrakeBlock.Text + "&RptPassengerStockBrakeBlock=" + LblPassengerStockBrakeBlock.Text + "&RptPassengerNoOfStock=" + LblPassengerNoOfStock.Text + "&RptPassengerBCPressure=" + LblPassengerBCPressure.Text + "&RptPassengerSpeed=" + LblPassengerSpeed.Text + "&RptPassengerGrade=" + LblPassengerGrade.Text + "&RptPassengerEBD=" + LblPassengerEBD.Text)

        rep.Load(Server.MapPath("Passenger.rpt"))
        rep.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rep
        rep.DataDefinition.FormulaFields("TypeOfLocomotive").Text = " ' " & Request.QueryString("RptPassengerLocoType") & "'"
        rep.DataDefinition.FormulaFields("NoOfLocomotive").Text = " ' " & Request.QueryString("RptPassengerNoOfloco") & "'"
        rep.DataDefinition.FormulaFields("TypeOfLocomotiveBrakeBlock").Text = " ' " & Request.QueryString("RptPassengerLocoBrakeBlock") & "'"
        'rep.DataDefinition.FormulaFields("TypeOfStock").Text = " ' " & Request.QueryString("RptGoodsTypeOfStock") & "'"
        rep.DataDefinition.FormulaFields("NoOfStock").Text = " ' " & Request.QueryString("RptPassengerNoOfStock") & "'"
        rep.DataDefinition.FormulaFields("StockBrakeBlock").Text = " ' " & Request.QueryString("RptPassengerStockBrakeBlock") & "'"
        rep.DataDefinition.FormulaFields("BCPressure").Text = " ' " & Request.QueryString("RptPassengerBCPressure") & "'"
        rep.DataDefinition.FormulaFields("BrakePower").Text = " ' " & Request.QueryString("RptPassengerBrakePower") & "'"
        'rep.DataDefinition.FormulaFields("LoadingCC").Text = " ' " & Request.QueryString("RptGoodsCC") & "'"
        rep.DataDefinition.FormulaFields("Speed").Text = " ' " & Request.QueryString("RptPassengerSpeed") & "'"
        rep.DataDefinition.FormulaFields("Grade").Text = " ' " & Request.QueryString("RptPassengerGrade") & "'"
        rep.DataDefinition.FormulaFields("EBD").Text = " ' " & Request.QueryString("RptPassengerEBD") & "'"

        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.DisplayToolbar = True
        CrystalReportViewer1.HasPageNavigationButtons = True
        CrystalReportViewer1.HasPrintButton = True
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("passenger.aspx")
    End Sub

End Class
