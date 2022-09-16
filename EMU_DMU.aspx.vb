Imports System.Data
Imports System.Data.Odbc
Partial Class EMU_DMU
    Inherits System.Web.UI.Page
    Dim cmd As New OdbcCommand
    'Dim con As OdbcConnection
    Dim adp As New OdbcDataAdapter
    Dim rd As OdbcDataReader
    Dim cmd1 As New OdbcCommand
    Dim cmd2 As New OdbcCommand

    Dim con1 As OdbcConnection
    Dim rd1 As OdbcDataReader

    Dim ds As New DataSet
dim i as integer
dim dr as datarow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con1 = New OdbcConnection("DRIVER={Microsoft Access Driver (*.mdb)};DBQ=c:\ebd_web_data\locodatabase.mdb;DefaultDir=;UID=;PWD=;")

        PanelEMU.Visible = False
        If Not IsPostBack Then
            cmd.Connection = con1
            cmd.CommandText = " Select typeofcoach from dmu order by typeofcoach"
            con1.Open()
            rd = cmd.ExecuteReader
            DDEMUCoachType.Items.Add("Select")

            While rd.Read() = True
                DDEMUCoachType.Items.Add(New ListItem(rd(0)))
            End While
            rd.Close()
            con1.Close()

        End If
    End Sub
    Protected Sub BtnEMUCoachType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEMUCoachType.Click
        If DDEMUCoachType.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Coach Type');</script>")
        ElseIf DDEMUCoaches.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select No. of coaches');</script>")
        Else
            ListBoxTrComposition.Items.Add(DDEMUCoachType.Text & "-" & DDEMUCoaches.SelectedItem.Value)
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("menu.aspx")
    End Sub
    Protected Sub BtnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        If ListBoxTrComposition.SelectedIndex > -1 Then
            For i = ListBoxTrComposition.Items.Count - 1 To 0 Step -1
                If ListBoxTrComposition.Items(i).Selected Then
                    ListBoxTrComposition.Items.Remove(ListBoxTrComposition.Items(i).Text)
                End If
            Next
        End If
    End Sub
    Protected Sub btnTrComposition_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTrComposition.Click
        If ListBoxTrComposition.Items.Count = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('First you select Coach Type & No. of Coaches');</script>")
            Exit Sub
        Else
            Dim NoOfCoaches As String
            Dim TypeOfCoach As String
            Dim LenghOfString As Integer
            Dim TotalNoOfCoaches As Integer
            Dim WtStk As Double
            Dim BpStk As Double
            Dim BpStkCI As Double
            Dim TWtStk As Double
            Dim TBpStk As Double
            Dim TBpStkCI As Double
            Dim TrainWT As Double
            Dim TrainBP As Double
            Dim TrainBPCI As Double
            For i = ListBoxTrComposition.Items.Count - 1 To 0 Step -1
                LenghOfString = Len(ListBoxTrComposition.Items(i).Text)
                NoOfCoaches = Val(Right(ListBoxTrComposition.Items(i).Text, 2))
                TypeOfCoach = Left(ListBoxTrComposition.Items(i).Text, LenghOfString - 3)
                adp = New OdbcDataAdapter("Select Weight,Brakepower from dmu where typeofcoach='" + TypeOfCoach + "'", con1)

                ds = New DataSet()
                adp.Fill(ds, "dmu")

                If ds.Tables("dmu").Rows.Count > 0 Then
                    For Each dr In ds.Tables("dmu").Rows
                        WtStk = dr("Weight")
                        BpStk = dr("Brakepower")
                    Next
                End If
                TWtStk = WtStk * NoOfCoaches
                TBpStk = BpStk * NoOfCoaches
                TrainWT = TrainWT + TWtStk
                TrainBP = TrainBP + TBpStk
                TotalNoOfCoaches = TotalNoOfCoaches + NoOfCoaches
            Next
            WtStk = TrainWT / TotalNoOfCoaches
            BpStk = TrainBP / TotalNoOfCoaches
            BpStkCI = TrainBPCI / TotalNoOfCoaches
            text3.Text = WtStk
            Text4.Text = BpStk
            Text6.Text = TotalNoOfCoaches
            'MsgBox(text1.Text & "," & text2.Text & " , " & text5.Text & " , " & Text6.Text)
        End If
    End Sub

    Protected Sub BtnEMU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEMU.Click

        If DDEMUSpeed.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Speed');</script>")
        ElseIf DDEMUGrade.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Grade');</script>")
        ElseIf DDEMUSpeed.Text = "Other" And Val(txtEMUSpeed.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Speed');</script>")
        ElseIf DDEMUGrade.Text = "Other" And Val(txtEMUGrade.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Grade');</script>")


        ElseIf text3.Text = "" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Click on Finish button');</script>")

        Else


            PanelTrComposition.Visible = False
            Dim TotalBPStock As Double
            Dim BrakeEffortStock As Double
            Dim RollingResistanceStock As Double
            Dim GradePull As Double
            Dim TotalBrakeEffort As Double
            Dim Retardation As Double
            Dim Distance As Double
            Dim TotalDistance As Double
            Dim FinalDistance As Double

            Dim Time As Integer
            Dim StockBrakePower As Double
            Dim StockWeight As Double
            Dim StockNumber As Double
            Dim StockRRL1 As Double
            Dim StockRRL2 As Double
            Dim StockRRL3 As Double
            Dim Speedkmph As Double
            Dim DownGrade As Double

            'data of stock
            StockWeight = text3.Text / Val(Text6.Text)
            StockBrakePower = Text4.Text / Val(Text6.Text)
            StockNumber = Val(Text6.Text)
            If DDEMUSpeed.Text <> "Other" Then '010709
                Speedkmph = DDEMUSpeed.SelectedValue
            Else
                Speedkmph = Val(txtEMUSpeed.Text)
            End If

            If DDEMUGrade.Text <> "Other" Then '010709
                DownGrade = DDEMUGrade.SelectedValue
            Else
                DownGrade = Val(txtEMUGrade.Text)
            End If


            '' ''Speedkmph = Val(DDEMUSpeed.Text)
            '' ''DownGrade = Val(DDEMUGrade.Text)

            'calculation of EBD
            Dim EffectiveTrainWeight As Double = 1.05 * (StockWeight * StockNumber)
            StockRRL1 = 1.347
            StockRRL2 = 0.00385
            StockRRL3 = 0.000165
            Dim StockBrakeDevTime1 As Integer = 4
            Dim StockBrakeDevTime2 As Integer = 7
            Dim TimeLag1 As Double = 0.5
            Dim TimeLag2 As Double = 0.5
            Dim StockBrakeDevTime As Double = (StockBrakeDevTime1 + StockBrakeDevTime2) * 0.5
            Dim Velocity As Double = Speedkmph / 3.6
            Dim AKS As Double
            Dim B1, B2, B3, TS, FS As Double
            Dim StockFriction As Double

            Do While Velocity > 0
                B1 = 0.16166666
                B2 = 0.0103125
                B3 = 0.0002865
                TS = Time - TimeLag2 + 2
                If TS < 0 Then TS = 0
                FS = TS * 13.5 / (StockBrakeDevTime - TimeLag2)
                AKS = B1 * FS - B2 * FS * FS + B3 * FS * FS * FS
                If AKS > 1 Then AKS = 1
                Speedkmph = Velocity * 3.6
                If Speedkmph <= 40 Then StockFriction = 0.27
                If Speedkmph > 40 Then StockFriction = 0.23 
		
		If (DDEMUCoachType.SelectedItem.Text) = "BCMPOWERCAR" Then StockFriction = 0.17
		If (DDEMUCoachType.SelectedItem.Text) = "BCMWORKINGUNIT" Then StockFriction = 0.17
       	If (DDEMUCoachType.SelectedItem.Text) = "8-WheelerTWBEML" Then StockFriction = 0.17
            If (DDEMUCoachType.SelectedItem.Text) = "UTVL-EMPTY" Then StockFriction = 0.17
		If (DDEMUCoachType.SelectedItem.Text) = "UTVL-LOADED" Then StockFriction = 0.17
		If (DDEMUCoachType.SelectedItem.Text) = "UTVLBRNLOADED" Then StockFriction = 0.17
		If (DDEMUCoachType.SelectedItem.Text) = "BRNLOADED" Then StockFriction = 0.17

		TotalBPStock = StockBrakePower * StockNumber * 0.88 * 0.9 * StockFriction
                BrakeEffortStock = TotalBPStock
                If Time <= StockBrakeDevTime Then GoTo 50
                GoTo 60
50:             BrakeEffortStock = TotalBPStock * AKS
60:             RollingResistanceStock = ((StockRRL1 + StockRRL2 * Speedkmph + StockRRL3 * Speedkmph _
            * Speedkmph) * StockWeight * StockNumber) / 1000
                GradePull = EffectiveTrainWeight / (DownGrade * 1.05)
                If DownGrade >= 500 Then GradePull = 0
                TotalBrakeEffort = BrakeEffortStock + RollingResistanceStock + GradePull
                Retardation = TotalBrakeEffort * 9.81 / EffectiveTrainWeight
                Distance = Velocity - 0.5 * Retardation
                TotalDistance = TotalDistance + Distance
                Velocity = Velocity - Retardation
                Time = Time + 1
            Loop

70:         'EBD.Text = TotalDistance
            txtTime.Text = Time
            txtTotalDistance.Text = TotalDistance
            FinalDistance = Val(TotalDistance)
            PanelEMU.Visible = True
            LblEMUNoOfStock.Text = Text6.Text
            For i = ListBoxTrComposition.Items.Count - 1 To 0 Step -1
                LblEMUNoOfStock.Text = LblEMUNoOfStock.Text & "," & (ListBoxTrComposition.Items(i).Text)
            Next

            If DDEMUSpeed.Text <> "Other" Then '010709
                LblEMUSpeed.Text = DDEMUSpeed.Text
            Else
                LblEMUSpeed.Text = Val(txtEMUSpeed.Text)
            End If

            If DDEMUGrade.Text <> "Other" Then '010709
                LblEMUGrade.Text = DDEMUGrade.Text
            Else
                LblEMUGrade.Text = Val(txtEMUGrade.Text)
            End If


            ' ''LblEMUSpeed.Text = DDEMUSpeed.Text
            ' ''LblEMUGrade.Text = DDEMUGrade.Text
            LblEMUEBD.Text = Math.Round(FinalDistance, 0)


        End If
    End Sub

    Protected Sub BtnPrintEMUEBD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintEMUEBD.Click
        Response.Redirect("EMU_DMU_Report.aspx?RptEMUNoOfStock=" + LblEMUNoOfStock.Text + "&RptEMUSpeed=" + LblEMUSpeed.Text + "&RptEMUGrade=" + LblEMUGrade.Text + "&RptEMUEBD=" + LblEMUEBD.Text)
    End Sub

    Protected Sub BtnChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnChart.Click
        Dim TotalBPStock As Double
        Dim BrakeEffortStock As Double
        Dim RollingResistanceStock As Double
        Dim GradePull As Double
        Dim TotalBrakeEffort As Double
        Dim Retardation As Double
        Dim Distance As Double
        Dim TotalDistance As Double

        Dim Time As Integer
        Dim StockBrakePower As Double
        Dim StockWeight As Double
        Dim StockNumber As Double
        Dim StockRRL1 As Double
        Dim StockRRL2 As Double
        Dim StockRRL3 As Double
        Dim Speedkmph As Double
        Dim DownGrade As Double

        'data of stock
        StockWeight = text3.Text / Val(Text6.Text)
        StockBrakePower = Text4.Text / Val(Text6.Text)
        StockNumber = Val(Text6.Text)

        If DDEMUSpeed.Text <> "Other" Then '010709
            Speedkmph = DDEMUSpeed.SelectedValue
        Else
            Speedkmph = Val(txtEMUSpeed.Text)
        End If

        If DDEMUGrade.Text <> "Other" Then '010709
            DownGrade = DDEMUGrade.SelectedValue
        Else
            DownGrade = Val(txtEMUGrade.Text)
        End If


        '' ''Speedkmph = Val(DDEMUSpeed.Text)
        '' ''DownGrade = Val(DDEMUGrade.Text)

        'calculation of EBD
        Dim EffectiveTrainWeight As Double = 1.05 * (StockWeight * StockNumber)
        StockRRL1 = 1.347
        StockRRL2 = 0.00385
        StockRRL3 = 0.000165
        Dim StockBrakeDevTime1 As Integer = 4
        Dim StockBrakeDevTime2 As Integer = 7
        Dim TimeLag1 As Double = 0.5
        Dim TimeLag2 As Double = 0.5
        Dim StockBrakeDevTime As Double = (StockBrakeDevTime1 + StockBrakeDevTime2) * 0.5
        Dim Velocity As Double = Speedkmph / 3.6
        Dim AKS As Double
        Dim B1, B2, B3, TS, FS As Double
        Dim StockFriction As Double
        Dim table_name As String = "temp_EMUDMU"
        cmd1.Connection = con1
        cmd2.Connection = con1
        cmd1.CommandText = "SELECT name FROM MSysObjects WHERE (MSysObjects.Name='" + table_name + "') AND (MSysObjects.Type=1)"
        con1.Open()
        rd1 = cmd1.ExecuteReader()
        If rd1.Read = True Then
            cmd2.CommandText = "drop table temp_EMUDMU"
            cmd2.ExecuteNonQuery()

            cmd2.CommandText = " Create TABLE [temp_EMUDMU] (fieldSpeedkmph double,fieldTime long,fieldDistance double)"

            cmd2.ExecuteNonQuery()

        Else
            cmd2.CommandText = " Create TABLE [temp_EMUDMU] (fieldSpeedkmph double,fieldTime long,fieldDistance double)"

            cmd2.ExecuteNonQuery()
        End If
        con1.Close()


        Do While Velocity > 0
            B1 = 0.16166666
            B2 = 0.0103125
            B3 = 0.0002865
            TS = Time - TimeLag2 + 2
            If TS < 0 Then TS = 0
            FS = TS * 13.5 / (StockBrakeDevTime - TimeLag2)
            AKS = B1 * FS - B2 * FS * FS + B3 * FS * FS * FS
            If AKS > 1 Then AKS = 1
            Speedkmph = Velocity * 3.6
            If Speedkmph <= 40 Then StockFriction = 0.27
            If Speedkmph > 40 Then StockFriction = 0.23 
            
		If (DDEMUCoachType.SelectedItem.Text) = "BCMPOWERCAR" Then StockFriction = 0.17
		If (DDEMUCoachType.SelectedItem.Text) = "BCMWORKINGUNIT" Then StockFriction = 0.17
		If (DDEMUCoachType.SelectedItem.Text) = "8-WheelerTWBEML" Then StockFriction = 0.17
		If (DDEMUCoachType.SelectedItem.Text) = "UTVL-EMPTY" Then StockFriction = 0.17
		If (DDEMUCoachType.SelectedItem.Text) = "UTVL-LOADED" Then StockFriction = 0.17
		If (DDEMUCoachType.SelectedItem.Text) = "UTVLBRNLOADED" Then StockFriction = 0.17
		If (DDEMUCoachType.SelectedItem.Text) = "BRNLOADED" Then StockFriction = 0.17
		
		TotalBPStock = StockBrakePower * StockNumber * 0.88 * 0.9 * StockFriction
            BrakeEffortStock = TotalBPStock
            If Time <= StockBrakeDevTime Then GoTo 50
            GoTo 60
50:         BrakeEffortStock = TotalBPStock * AKS
60:         RollingResistanceStock = ((StockRRL1 + StockRRL2 * Speedkmph + StockRRL3 * Speedkmph _
        * Speedkmph) * StockWeight * StockNumber) / 1000
            GradePull = EffectiveTrainWeight / (DownGrade * 1.05)
            If DownGrade >= 500 Then GradePull = 0
            TotalBrakeEffort = BrakeEffortStock + RollingResistanceStock + GradePull
            Retardation = TotalBrakeEffort * 9.81 / EffectiveTrainWeight
            Distance = Velocity - 0.5 * Retardation
            TotalDistance = TotalDistance + Distance
            Velocity = Velocity - Retardation
            Time = Time + 1
            If Speedkmph < 0 Then
                Speedkmph = 0
            End If

            cmd1.Connection = con1
            cmd1.CommandText = "Insert Into temp_EMUDMU (fieldSpeedkmph,fieldTime,fieldDistance) values ('" & Speedkmph & "','" & Time & "','" & TotalDistance & "')" 'dhs
            con1.Open()
            cmd1.ExecuteNonQuery()
            con1.Close()
        Loop

         Response.Redirect("EMU_DMUChart.aspx?RptQry_distance=" + txtTotalDistance.Text + "&RptQry_time=" + txtTime.Text)

    End Sub
    Protected Sub DDEMUSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDEMUSpeed.SelectedIndexChanged
        If DDEMUSpeed.Text = "Other" Then
            txtEMUSpeed.Visible = True
        Else
            txtEMUSpeed.Visible = False
        End If
    End Sub
    Protected Sub DDEMUGrade_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDEMUGrade.SelectedIndexChanged
        If DDEMUGrade.Text = "Other" Then
            txtEMUGrade.Visible = True
        Else
            txtEMUGrade.Visible = False
        End If
    End Sub
End Class
