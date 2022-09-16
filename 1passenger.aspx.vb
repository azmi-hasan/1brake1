Imports System.Data
Imports System.Data.Odbc

Partial Class passenger
    Inherits System.Web.UI.Page
    Dim cmd As New OdbcCommand
    ''Dim con As OdbcConnection
    Dim con1 As OdbcConnection
    Dim cmd1 As New OdbcCommand
    Dim cmd2 As New OdbcCommand

    Dim adp As New OdbcDataAdapter
    Dim rd As OdbcDataReader
    Dim rd1 As OdbcDataReader
    Dim ds As New DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con1 = New OdbcConnection("DRIVER={Microsoft Access Driver (*.mdb)};DBQ=c:\ebd_web_data\locodatabase.mdb;DefaultDir=;UID=;PWD=;")

        PanelPassenger.Visible = False
        If Not IsPostBack Then

            cmd.Connection = con1
            cmd.CommandText = " Select locomotive from loco order by locomotive" 'new 
            con1.Open()
            rd = cmd.ExecuteReader
            DDPassengerLocoType.Items.Add("Select")

            While rd.Read() = True
                DDPassengerLocoType.Items.Add(New ListItem(rd(0)))
            End While
            rd.Close()
            cmd.CommandText = " Select typeofcoach from coach order by typeofcoach" 'new 
            rd = cmd.ExecuteReader
            DDPassengerCoachType.Items.Add("Select")

            While rd.Read() = True
                DDPassengerCoachType.Items.Add(New ListItem(rd(0)))
            End While
            rd.Close()
            con1.Close()

        End If
    End Sub

    Protected Sub BtnPassengerCoachType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPassengerCoachType.Click
        If DDPassengerCoachType.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Coach Type');</script>")
        ElseIf DDPassengerCoaches.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select No. of coaches');</script>")
        Else
            ListBoxTrComposition.Items.Add(DDPassengerCoachType.Text & "-" & DDPassengerCoaches.SelectedItem.Value)
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
                adp = New OdbcDataAdapter("Select Weight,Brakepower,BrakePowerCI from coach where typeofcoach='" + TypeOfCoach + "'", con1)

                ds = New DataSet()
                adp.Fill(ds, "coach")

                If ds.Tables("coach").Rows.Count > 0 Then
                    For Each dr In ds.Tables("coach").Rows
                        WtStk = dr("Weight")
                        BpStk = dr("Brakepower")
                        BpStkCI = dr("BrakePowerCI")
                    Next
                End If
                TWtStk = WtStk * NoOfCoaches
                TBpStk = BpStk * NoOfCoaches
                TBpStkCI = BpStkCI * NoOfCoaches
                TrainWT = TrainWT + TWtStk
                TrainBP = TrainBP + TBpStk
                TrainBPCI = TrainBPCI + TBpStkCI
                TotalNoOfCoaches = TotalNoOfCoaches + NoOfCoaches
            Next
            WtStk = TrainWT / TotalNoOfCoaches
            BpStk = TrainBP / TotalNoOfCoaches
            BpStkCI = TrainBPCI / TotalNoOfCoaches
            text1.Text = WtStk
            text2.Text = BpStk
            text5.Text = BpStkCI
            Text6.Text = TotalNoOfCoaches
            'MsgBox(text1.Text & "," & text2.Text & " , " & text5.Text & " , " & Text6.Text)
        End If
    End Sub

    Protected Sub BtnPassenger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPassenger.Click

        If DDPassengerLocoType.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Type of Locomotive');</script>")
        ElseIf DDPassengerNoOfLoco.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select No. of Locomotive');</script>")
        ElseIf DDPassengerLocoBrakeBlock.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Loco Brake Block');</script>")
        ElseIf DDPassengerStockBrakeBlock.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Type of Stock Brake Block');</script>")
        ElseIf DDPassengerBCPressure.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select BC Pressure of Loco');</script>")
        ElseIf DDPassengerBrakePower.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Percentage Brake Power');</script>")
        ElseIf DDPassengerSpeed.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Speed');</script>")
        ElseIf DDPassengerGrade.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Grade');</script>")

        ElseIf DDPassengerBCPressure.Text = "Other" And Val(txtPassengerBCPressure.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select BC Pressure of Loco');</script>")
        ElseIf DDPassengerBrakePower.Text = "Other" And Val(txtPassengerBrakePower.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Percentage Brake Power');</script>")
        ElseIf DDPassengerSpeed.Text = "Other" And Val(txtPassengerSpeed.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Speed');</script>")
        ElseIf DDPassengerGrade.Text = "Other" And Val(txtPassengerGrade.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Grade');</script>")


        ElseIf text1.Text = "" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Click on Finish button');</script>")

        Else
            PanelTrComposition.Visible = False
            Dim TotalBPloco As Double
            Dim BrakeEffortLoco As Double
            Dim TotalBPStock As Double
            Dim BrakeEffortStock As Double
            Dim RollingResistanceLoco As Double
            Dim RollingResistanceStock As Double
            Dim GradePull As Double
            Dim TotalBrakeEffort As Double
            Dim Retardation As Double
            Dim Distance As Double
            Dim TotalDistance As Double
            Dim FinalDistance As Integer

            Dim Time As Integer
            Dim SpecificShoePrLoco As Integer
            Dim SpecificShoePrStock As Integer

            Dim Locoweight As Double
            Dim LocoBrakePower As Double
            Dim LocoBrakeBlock As Integer
            Dim LocoBrakeBlockArea As Double
            Dim LocoRRL1 As Double
            Dim LocoRRL2 As Double
            Dim LocoRRL3 As Double
            Dim LocoBCPressureForBP As Double
            Dim StockBrakePower As Double
            Dim StockWeight As Double
            Dim StockBrakePowerCI As Double
            Dim StockNumber As Double
            Dim StockRRL1 As Double
            Dim StockRRL2 As Double
            Dim StockRRL3 As Double
            Dim LocoNumber As Double
            Dim LocoBCPressure As Double
            Dim PercentageOperativeCylinder As Double
            Dim Speedkmph As Double
            Dim DownGrade As Double
            adp = New OdbcDataAdapter("Select Weight,Brakepower,numbrkblk,brkblkarea,X1,Y1,Z1,BCpressure from loco where locomotive='" + DDPassengerLocoType.SelectedItem.Text + "'", con1)

            ds = New DataSet()
            adp.Fill(ds, "loco")

            If ds.Tables("loco").Rows.Count > 0 Then
                For Each dr In ds.Tables("loco").Rows
                    Locoweight = dr("Weight")
                    LocoBrakePower = dr("Brakepower")
                    LocoBrakeBlock = dr("numbrkblk")
                    LocoBrakeBlockArea = dr("brkblkarea")
                    LocoRRL1 = dr("X1")
                    LocoRRL2 = dr("Y1")
                    LocoRRL3 = dr("Z1")
                    LocoBCPressureForBP = dr("BCpressure")
                Next
            End If
            LocoNumber = Val(DDPassengerNoOfLoco.Text)

            If DDPassengerBCPressure.Text <> "Other" Then '010709
                LocoBCPressure = DDPassengerBCPressure.SelectedValue
            Else
                LocoBCPressure = Val(txtPassengerBCPressure.Text)
            End If

            If DDPassengerBrakePower.Text <> "Other" Then '010709
                PercentageOperativeCylinder = (DDPassengerBrakePower.SelectedValue) / 100
            Else
                PercentageOperativeCylinder = (Val(txtPassengerBrakePower.Text)) / 100
            End If

            If DDPassengerSpeed.Text <> "Other" Then '010709
                Speedkmph = DDPassengerSpeed.SelectedValue
            Else
                Speedkmph = Val(txtPassengerSpeed.Text)
            End If

            If DDPassengerGrade.Text <> "Other" Then '010709
                DownGrade = DDPassengerGrade.SelectedValue
            Else
                DownGrade = Val(txtPassengerGrade.Text)
            End If


            '' ''LocoBCPressure = Val(DDPassengerBCPressure.Text)
            '' ''PercentageOperativeCylinder = Val(DDPassengerBrakePower.Text / 100)
            '' ''Speedkmph = Val(DDPassengerSpeed.Text)
            '' ''DownGrade = Val(DDPassengerGrade.Text)
            'data of stock
            StockWeight = Val(text1.Text)
            StockBrakePower = Val(text2.Text)
            StockBrakePowerCI = Val(text5.Text)
            StockNumber = Val(Text6.Text)
            StockRRL1 = 1.347
            StockRRL2 = 0.00385
            StockRRL3 = 0.000165
            'calculation of EBD
            Dim EffectiveTrainWeight As Double = 1.05 * (Locoweight * LocoNumber + StockWeight * StockNumber)
            Dim LocoBrakeDevTime As Integer = 13
            Dim StockBrakeDevTime1 As Integer
            Dim StockBrakeDevTime2 As Integer
            If StockNumber <= 19 Then StockBrakeDevTime1 = 5
            If StockNumber > 20 Then StockBrakeDevTime1 = 7
            'If StockNumber <= 10 Then StockBrakeDevTime2 = 6
            'If StockNumber <= 12 Then StockBrakeDevTime2 = 8
            'If StockNumber <= 14 Then StockBrakeDevTime2 = 10
            'If StockNumber <= 16 Then StockBrakeDevTime2 = 12
            'If StockNumber <= 18 Then StockBrakeDevTime2 = 14
            'If StockNumber <= 20 Then StockBrakeDevTime2 = 16
            'If StockNumber <= 22 Then StockBrakeDevTime2 = 19
            'If StockNumber <= 24 Then StockBrakeDevTime2 = 22
            'If StockNumber <= 26 Then StockBrakeDevTime2 = 25

            If StockNumber <= 10 Then StockBrakeDevTime2 = 6
            If StockNumber > 10 And StockNumber <= 12 Then StockBrakeDevTime2 = 8
            If StockNumber > 12 And StockNumber <= 14 Then StockBrakeDevTime2 = 10
            If StockNumber > 14 And StockNumber <= 16 Then StockBrakeDevTime2 = 12
            If StockNumber > 16 And StockNumber <= 18 Then StockBrakeDevTime2 = 14
            If StockNumber > 18 And StockNumber <= 20 Then StockBrakeDevTime2 = 16
            If StockNumber > 20 And StockNumber <= 22 Then StockBrakeDevTime2 = 19
            If StockNumber > 22 And StockNumber <= 24 Then StockBrakeDevTime2 = 22
            If StockNumber > 24 And StockNumber <= 26 Then StockBrakeDevTime2 = 25



            Dim TimeLag1 As Integer = 1
            Dim TimeLag2 As Integer = 2

            Dim StockBrakeDevTime As Double = (StockBrakeDevTime1 + StockBrakeDevTime2) * 0.5
            Dim Velocity As Double = Speedkmph / 3.6
            Dim SKM As Double
            Dim AKS As Double
            Dim AKL As Double
            Dim B1, B2, B3, TL, FL, TS, FS, LocoFriction As Double
            Dim StockFriction As Double
            Dim StockBrakeBlock As Double
            Dim StockBrakeBlockArea As Double
            Do While Velocity > 0
                B1 = 0.16166666
                B2 = 0.0103125
                B3 = 0.0002865
                TL = Time - TimeLag1 + 2
                If TL < 0 Then TL = 0
                FL = TL * 13.5 / (LocoBrakeDevTime - TimeLag1)
                AKL = (B1 * FL - B2 * FL * FL + B3 * FL * FL * FL)
                If AKL > 1 Then AKL = 1
                TS = Time - TimeLag2 + 2
                If TS < 0 Then TS = 0
                FS = TS * 13.5 / (StockBrakeDevTime - TimeLag2)
                AKS = B1 * FS - B2 * FS * FS + B3 * FS * FS * FS
                If AKS > 1 Then AKS = 1
                If DDPassengerLocoBrakeBlock.SelectedItem.Text = "Cast Iron" Then GoTo 150
                If DDPassengerLocoBrakeBlock.SelectedItem.Text = "L Type Composition" Then LocoFriction = 0.17
                If DDPassengerLocoBrakeBlock.SelectedItem.Text = "High Friction" Then LocoFriction = 0.25
                GoTo 160
150:            Speedkmph = Velocity * 3.6
                SKM = Speedkmph
                SpecificShoePrLoco = (LocoBrakePower * 0.85) / (LocoBrakeBlock * LocoBrakeBlockArea)
                If SpecificShoePrLoco < 6 Then SpecificShoePrLoco = 6
                If SpecificShoePrLoco > 12 Then SpecificShoePrLoco = 12
                If SpecificShoePrLoco = 6 Then GoTo 200
                If SpecificShoePrLoco = 7 Then GoTo 210
                If SpecificShoePrLoco = 8 Then GoTo 220
                If SpecificShoePrLoco = 9 Then GoTo 230
                If SpecificShoePrLoco = 10 Then GoTo 240
                If SpecificShoePrLoco = 11 Then GoTo 250
                If SpecificShoePrLoco = 12 Then GoTo 260
200:            If SKM >= 75 Then GoTo 2003
                If SKM >= 35 Then GoTo 2001
                If SKM < 35 Then GoTo 2002
2003:           LocoFriction = 1.04
                GoTo 160
2001:           LocoFriction = (0.3 + 1.70597654345651 * SKM - 0.217999971250967 * SKM * SKM + _
          0.0117817847707845 * SKM * SKM * SKM - 0.0003503704351204 * SKM * SKM * SKM * SKM + _
          0.0000061966868687 * SKM * SKM * SKM * SKM * SKM - 0.0000000652052836 * SKM * SKM * SKM * _
          SKM * SKM * SKM + 0.0000000003781108 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009324 _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                'ravi

                GoTo 160
2002:           LocoFriction = (0.3 - 0.0141178325123153 * SKM + 0.0004007290640394 * SKM * _
          SKM + 0.0000090214559387 * SKM * SKM * SKM - 0.0000009777011494 * SKM * SKM * SKM * SKM + _
          0.0000000155708812 * SKM * SKM * SKM * SKM * SKM + 0.0000000004229885 * SKM * SKM * SKM * SKM * _
          SKM * SKM - 0.0000000000124357 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + 0.0000000000000525 * SKM * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
210:            If SKM >= 75 Then GoTo 2103
                If SKM >= 35 Then GoTo 2101
                If SKM < 35 Then GoTo 2102
2103:           LocoFriction = 0.098
                GoTo 160
2101:           LocoFriction = (0.3 + 1.70510609723624 * SKM - 0.217945068720181 * SKM * SKM _
          + 0.0117798181248387 * SKM * SKM * SKM - 0.0003503266726237 * SKM * SKM * SKM * SKM _
          + 0.0000061960673401 * SKM * SKM * SKM * SKM * SKM - 0.0000000651998342 * SKM * SKM * SKM * _
          SKM * SKM * SKM + 0.0000000003780835 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2102:           LocoFriction = (0.3 - 0.021561330049261 * SKM + 0.0026047495894909 * SKM * SKM - _
          0.0002787030651341 * SKM * SKM * SKM + 0.0000181953065134 * SKM * SKM * SKM * SKM - _
          0.000000642605364 * SKM * SKM * SKM * SKM * SKM + 0.0000000105363985 * SKM * SKM * SKM * _
          SKM * SKM * SKM - 0.000000000031965 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
          0.0000000000006787 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
220:            If SKM >= 75 Then GoTo 2203
                If SKM >= 35 Then GoTo 2201
                If SKM < 35 Then GoTo 2202
2203:           LocoFriction = 0.092
                GoTo 160
2201:           LocoFriction = (0.3 + 1.70423565101564 * SKM - 0.217890166189369 * SKM * SKM + _
          0.0117778514788917 * SKM * SKM * SKM - 0.0003502829101269 * SKM * SKM * SKM * SKM + _
          0.0000061954478114 * SKM * SKM * SKM * SKM * SKM - 0.0000000651943849 * SKM * SKM * SKM * SKM _
          * SKM * SKM + 0.0000000003780563 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * SKM _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2202:           LocoFriction = (0.3 - 0.0261124137931033 * SKM + 0.0032766469622331 * SKM * _
          SKM - 0.0003122137931034 * SKM * SKM * SKM + 0.0000182213793103 * SKM * SKM * SKM _
          * SKM - 0.0000005943908046 * SKM * SKM * SKM * SKM * SKM + 0.0000000092137931 * SKM * _
          SKM * SKM * SKM * SKM * SKM - 0.0000000000257471 * SKM * SKM * SKM * SKM * SKM * SKM _
          * SKM - 0.000000000000578 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
230:            If SKM >= 75 Then GoTo 2303
                If SKM >= 35 Then GoTo 2301
                If SKM < 35 Then GoTo 2302
2303:           LocoFriction = 0.086
                GoTo 160
2301:           LocoFriction = (0.3 + 1.70336520479522 * SKM - 0.217835263658568 * SKM * SKM _
          + 0.0117758848329451 * SKM * SKM * SKM - 0.0003502391476302 * SKM * SKM * SKM * _
          SKM + 0.0000061948282828 * SKM * SKM * SKM * SKM * SKM - 0.0000000651889355 * SKM * SKM * _
          SKM * SKM * SKM * SKM + 0.0000000003780291 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
          0.0000000000009322 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2302:           LocoFriction = (0.3 - 0.0350428078817735 * SKM + 0.0061845295566502 * SKM * _
          SKM - 0.0007227459770115 * SKM * SKM * SKM + 0.0000476529310345 * SKM * SKM * SKM * SKM _
          - 0.0000016844137931 * SKM * SKM * SKM * SKM * SKM + 0.000000027645977 * SKM * SKM * SKM _
          * SKM * SKM * SKM - 0.0000000000832841 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000017997 _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
240:            If SKM >= 75 Then GoTo 2403
                If SKM >= 35 Then GoTo 2401
                If SKM < 35 Then GoTo 2402
2403:           LocoFriction = 0.08
                GoTo 160
2401:           LocoFriction = (0.3 - 5.84726968586961 * SKM + 0.747139572205568 * SKM * SKM _
          - 0.0406393079858413 * SKM * SKM * SKM + 0.0012185038988172 * SKM * SKM * SKM * _
          SKM - 0.0000217490011223 * SKM * SKM * SKM * SKM * SKM + 0.0000002311108348 * SKM * SKM _
          * SKM * SKM * SKM * SKM - 0.0000000013539488 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + _
          0.000000000003374 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2402:           LocoFriction = (0.3 - 0.0395938916256153 * SKM + 0.0068564269293924 * SKM * _
          SKM - 0.0007562567049808 * SKM * SKM * SKM + 0.0000476790038314 * SKM * SKM * SKM * SKM _
          - 0.0000016361992337 * SKM * SKM * SKM * SKM * SKM + 0.0000000263233716 * SKM * SKM * SKM * _
          SKM * SKM * SKM - 0.0000000000770662 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
          0.000000000001699 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
250:            If SKM >= 75 Then GoTo 2503
                If SKM > 35 Then GoTo 2501
                If SKM < 35 Then GoTo 2502
2503:           LocoFriction = 0.076
                GoTo 160
2501:           LocoFriction = (0.3 - 0.199231560661529 * SKM + 0.0203851445776407 * SKM * SKM _
          - 0.0008760435206766 * SKM * SKM * SKM + 0.0000192389946473 * SKM * SKM * SKM * SKM - _
          0.0000002145095398 * SKM * SKM * SKM * SKM * SKM + 0.0000000008762842 * SKM * SKM * SKM * SKM * _
          SKM * SKM + 0.0000000000032303 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000000291 * SKM * SKM _
          * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2502:           LocoFriction = (0.3 - 0.0426580788177338 * SKM + 0.0068244622331691 * SKM * _
          SKM - 0.0006669597701149 * SKM * SKM * SKM + 0.0000374465325671 * SKM * SKM * SKM * SKM _
          - 0.000001156137931 * SKM * SKM * SKM * SKM * SKM + 0.0000000166819923 * SKM * SKM * SKM * _
          SKM * SKM * SKM - 0.0000000000328407 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000011078 * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
260:            If SKM >= 75 Then GoTo 2603
                If SKM >= 35 Then GoTo 2601
                If SKM < 35 Then GoTo 2602
2603:           LocoFriction = 0.07
                GoTo 160
2601:           LocoFriction = (0.3 - 0.200102006881999 * SKM + 0.0204400471084461 * SKM * SKM _
          - 0.0008780101666234 * SKM * SKM * SKM + 0.0000192827571441 * SKM * SKM * SKM * SKM - _
          0.0000002151290685 * SKM * SKM * SKM * SKM * SKM + 0.0000000008817336 * SKM * SKM * SKM * SKM * _
          SKM * SKM + 0.0000000000032031 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.000000000000029 * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2602:           LocoFriction = (0.3 - 0.0472091625615763 * SKM + 0.0074963596059113 * SKM * _
          SKM - 0.0007004704980843 * SKM * SKM * SKM + 0.000037472605364 * SKM * SKM * SKM * SKM _
          - 0.0000011079233716 * SKM * SKM * SKM * SKM * SKM + 0.000000015359387 * SKM * SKM * SKM _
          * SKM * SKM * SKM - 0.0000000000266229 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000010071 _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
160:            TotalBPloco = (LocoBrakePower * LocoNumber * 0.85 * LocoFriction * LocoBCPressure) _
           / LocoBCPressureForBP
                BrakeEffortLoco = TotalBPloco
                If DDPassengerStockBrakeBlock.SelectedItem.Text = "Cast Iron" Then GoTo 170
                If DDPassengerStockBrakeBlock.SelectedItem.Text = "L Type Composition" Then GoTo 175
                If DDPassengerStockBrakeBlock.SelectedItem.Text = "K Type Composition" Then GoTo 180
                GoTo 190
170:            StockBrakePower = StockBrakePowerCI
                Speedkmph = Velocity * 3.6
                SKM = Speedkmph
                StockBrakeBlock = 16
                StockBrakeBlockArea = 270
                SpecificShoePrStock = (StockBrakePower * 0.81) / (StockBrakeBlock * StockBrakeBlockArea)
                If SpecificShoePrStock < 6 Then SpecificShoePrStock = 6
                If SpecificShoePrStock > 12 Then SpecificShoePrStock = 12
                If SpecificShoePrStock = 6 Then GoTo 300
                If SpecificShoePrStock = 7 Then GoTo 310
                If SpecificShoePrStock = 8 Then GoTo 320
                If SpecificShoePrStock = 9 Then GoTo 330
                If SpecificShoePrStock = 10 Then GoTo 340
                If SpecificShoePrStock = 11 Then GoTo 350
                If SpecificShoePrStock = 12 Then GoTo 360
300:            If SKM >= 75 Then GoTo 3003
                If SKM >= 35 Then GoTo 3001
                If SKM < 35 Then GoTo 3002
3003:           StockFriction = 1.04
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3001:           StockFriction = (0.3 + 1.70597654345651 * SKM - 0.217999971250967 * SKM * SKM + _
          0.0117817847707845 * SKM * SKM * SKM - 0.0003503704351204 * SKM * SKM * SKM * SKM + _
          0.0000061966868687 * SKM * SKM * SKM * SKM * SKM - 0.0000000652052836 * SKM * SKM * SKM * SKM _
          * SKM * SKM + 0.0000000003781108 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009324 * SKM _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3002:           StockFriction = (0.3 - 0.0141178325123153 * SKM + 0.0004007290640394 * SKM * SKM _
          + 0.0000090214559387 * SKM * SKM * SKM - 0.0000009777011494 * SKM * SKM * SKM * SKM + _
          0.0000000155708812 * SKM * SKM * SKM * SKM * SKM + 0.0000000004229885 * SKM * SKM * SKM * SKM * _
          SKM * SKM - 0.0000000000124357 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + 0.0000000000000525 * SKM * SKM _
          * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
310:            If SKM >= 75 Then GoTo 3103
                If SKM >= 35 Then GoTo 3101
                If SKM < 35 Then GoTo 3102
3103:           StockFriction = 0.098
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3101:           StockFriction = (0.3 + 1.70510609723624 * SKM - 0.217945068720181 * SKM * SKM + _
          0.0117798181248387 * SKM * SKM * SKM - 0.0003503266726237 * SKM * SKM * SKM * SKM + _
          0.0000061960673401 * SKM * SKM * SKM * SKM * SKM - 0.0000000651998342 * SKM * SKM * SKM * SKM _
          * SKM * SKM + 0.0000000003780835 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * SKM _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3102:           StockFriction = (0.3 - 0.021561330049261 * SKM + 0.0026047495894909 * SKM * SKM - _
          0.0002787030651341 * SKM * SKM * SKM + 0.0000181953065134 * SKM * SKM * SKM * SKM - _
          0.000000642605364 * SKM * SKM * SKM * SKM * SKM + 0.0000000105363985 * SKM * SKM * SKM * SKM _
          * SKM * SKM - 0.000000000031965 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000006787 * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
320:            If SKM >= 75 Then GoTo 3203
                If SKM >= 35 Then GoTo 3201
                If SKM < 35 Then GoTo 3202
3203:           StockFriction = 0.092
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3201:           StockFriction = (0.3 + 1.70423565101564 * SKM - 0.217890166189369 * SKM * SKM + _
          0.0117778514788917 * SKM * SKM * SKM - 0.0003502829101269 * SKM * SKM * SKM * SKM + _
          0.0000061954478114 * SKM * SKM * SKM * SKM * SKM - 0.0000000651943849 * SKM * SKM * SKM * SKM _
          * SKM * SKM + 0.0000000003780563 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * SKM _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3202:           StockFriction = (0.3 - 0.0261124137931033 * SKM + 0.0032766469622331 * SKM * _
          SKM - 0.0003122137931034 * SKM * SKM * SKM + 0.0000182213793103 * SKM * SKM * SKM * SKM _
          - 0.0000005943908046 * SKM * SKM * SKM * SKM * SKM + 0.0000000092137931 * SKM * SKM * SKM * SKM _
          * SKM * SKM - 0.0000000000257471 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.000000000000578 _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
330:            If SKM >= 75 Then GoTo 3303
                If SKM >= 35 Then GoTo 3301
                If SKM < 35 Then GoTo 3302
3303:           StockFriction = 0.086
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3301:           StockFriction = (0.3 + 1.70336520479522 * SKM - 0.217835263658568 * SKM * SKM + _
          0.0117758848329451 * SKM * SKM * SKM - 0.0003502391476302 * SKM * SKM * SKM * SKM + _
          0.0000061948282828 * SKM * SKM * SKM * SKM * SKM - 0.0000000651889355 * SKM * SKM * SKM * SKM _
          * SKM * SKM + 0.0000000003780291 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009322 * SKM _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3302:           StockFriction = (0.3 - 0.0350428078817735 * SKM + 0.0061845295566502 * SKM * _
          SKM - 0.0007227459770115 * SKM * SKM * SKM + 0.0000476529310345 * SKM * SKM * SKM * SKM _
          - 0.0000016844137931 * SKM * SKM * SKM * SKM * SKM + 0.000000027645977 * SKM * SKM * SKM _
          * SKM * SKM * SKM - 0.0000000000832841 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000017997 _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
340:            If SKM >= 75 Then GoTo 3403
                If SKM >= 35 Then GoTo 3401
                If SKM < 35 Then GoTo 3402
3403:           StockFriction = 0.08
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3401:           StockFriction = (0.3 - 5.84726968586961 * SKM + 0.747139572205568 * SKM * SKM - _
          0.0406393079858413 * SKM * SKM * SKM + 0.0012185038988172 * SKM * SKM * SKM * SKM - _
          0.0000217490011223 * SKM * SKM * SKM * SKM * SKM + 0.0000002311108348 * SKM * SKM * SKM * _
          SKM * SKM * SKM - 0.0000000013539488 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + _
          0.000000000003374 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3402:           StockFriction = (0.3 - 0.0395938916256153 * SKM + 0.0068564269293924 * SKM * _
          SKM - 0.0007562567049808 * SKM * SKM * SKM + 0.0000476790038314 * SKM * SKM * SKM * SKM _
          - 0.0000016361992337 * SKM * SKM * SKM * SKM * SKM + 0.0000000263233716 * SKM * SKM * SKM * _
          SKM * SKM * SKM - 0.0000000000770662 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
          0.000000000001699 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
350:            If SKM >= 75 Then GoTo 3503
                If SKM > 35 Then GoTo 3501
                If SKM < 35 Then GoTo 3502
3503:           StockFriction = 0.076
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3501:           StockFriction = (0.3 - 0.199231560661529 * SKM + 0.0203851445776407 * SKM * SKM _
          - 0.0008760435206766 * SKM * SKM * SKM + 0.0000192389946473 * SKM * SKM * SKM * SKM - _
          0.0000002145095398 * SKM * SKM * SKM * SKM * SKM + 0.0000000008762842 * SKM * SKM * SKM * SKM * _
          SKM * SKM + 0.0000000000032303 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000000291 * SKM * SKM _
          * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3502:           StockFriction = (0.3 - 0.0426580788177338 * SKM + 0.0068244622331691 * SKM * _
          SKM - 0.0006669597701149 * SKM * SKM * SKM + 0.0000374465325671 * SKM * SKM * SKM * SKM _
          - 0.000001156137931 * SKM * SKM * SKM * SKM * SKM + 0.0000000166819923 * SKM * SKM * SKM * _
          SKM * SKM * SKM - 0.0000000000328407 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000011078 * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
360:            If SKM >= 75 Then GoTo 3603
                If SKM >= 35 Then GoTo 3601
                If SKM < 35 Then GoTo 3602
3603:           StockFriction = 0.07
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3601:           StockFriction = (0.3 - 0.200102006881999 * SKM + 0.0204400471084461 * SKM * SKM _
          - 0.0008780101666234 * SKM * SKM * SKM + 0.0000192827571441 * SKM * SKM * SKM * SKM - _
          0.0000002151290685 * SKM * SKM * SKM * SKM * SKM + 0.0000000008817336 * SKM * SKM * SKM * SKM * _
          SKM * SKM + 0.0000000000032031 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.000000000000029 * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
3602:           StockFriction = (0.3 - 0.0472091625615763 * SKM + 0.0074963596059113 * SKM * _
          SKM - 0.0007004704980843 * SKM * SKM * SKM + 0.000037472605364 * SKM * SKM * SKM * SKM _
          - 0.0000011079233716 * SKM * SKM * SKM * SKM * SKM + 0.000000015359387 * SKM * SKM * SKM _
          * SKM * SKM * SKM - 0.0000000000266229 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000010071 _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
                GoTo 190
175:            StockBrakePower = StockBrakePowerCI
                StockFriction = 0.17
                GoTo 190
180:            Speedkmph = Velocity * 3.6
                If Speedkmph < 40 Then StockFriction = 0.27
                If Speedkmph > 40 Then StockFriction = 0.23
                GoTo 190
190:            TotalBPStock = StockBrakePower * StockNumber * 0.81 * StockFriction * PercentageOperativeCylinder
                BrakeEffortStock = TotalBPStock
                If Time <= LocoBrakeDevTime Then GoTo 30
                GoTo 40
30:             BrakeEffortLoco = TotalBPloco * AKL
40:             If Time <= StockBrakeDevTime Then GoTo 50
                GoTo 60
50:             BrakeEffortStock = TotalBPStock * AKS
60:             RollingResistanceLoco = ((LocoRRL1 + LocoRRL2 * Speedkmph + LocoRRL3 * Speedkmph * _
            Speedkmph) * Locoweight * LocoNumber) / 1000
                RollingResistanceStock = ((StockRRL1 + StockRRL2 * Speedkmph + StockRRL3 * Speedkmph * _
                Speedkmph) * StockWeight * StockNumber) / 1000
                GradePull = EffectiveTrainWeight / DownGrade * 1.05
                If DownGrade >= 500 Then GradePull = 0
                TotalBrakeEffort = BrakeEffortLoco + BrakeEffortStock + RollingResistanceLoco + RollingResistanceStock + GradePull
                Retardation = TotalBrakeEffort * 9.81 / EffectiveTrainWeight
                Distance = Velocity - 0.5 * Retardation
                TotalDistance = TotalDistance + Distance
                Velocity = Velocity - Retardation
                Time = Time + 1
                'List1.AddItem("SPEED " + Str(v) + " time " + Str(cofs) + " distance " + Str(cofl))
            Loop
            'If dist > 3000 Then MsgBox("EBD is more than 3000 m")
            'If dist < 3000 Then GoTo 70
            'End
70:         'EBD.Text = TotalDistance
            txtTime.Text = Time
            txtTotalDistance.Text = TotalDistance
            FinalDistance = Val(TotalDistance)


            PanelPassenger.Visible = True
            LblPassengerLocoType.Text = DDPassengerLocoType.Text
            LblPassengerNoOfLoco.Text = DDPassengerNoOfLoco.Text
            LblPassengerLocoBrakeBlock.Text = DDPassengerLocoBrakeBlock.SelectedItem.Text
            LblPassengerStockBrakeBlock.Text = DDPassengerStockBrakeBlock.SelectedItem.Text
            LblPassengerNoOfStock.Text = Text6.Text
            For i = ListBoxTrComposition.Items.Count - 1 To 0 Step -1
                LblPassengerNoOfStock.Text = LblPassengerNoOfStock.Text & "," & (ListBoxTrComposition.Items(i).Text)
            Next

            If DDPassengerBCPressure.Text <> "Other" Then '010709
                LblPassengerBCPressure.Text = DDPassengerBCPressure.Text
            Else
                LblPassengerBCPressure.Text = Val(txtPassengerBCPressure.Text)
            End If
            If DDPassengerBrakePower.Text <> "Other" Then '010709
                LblPassengerBrakePower.Text = DDPassengerBrakePower.Text
            Else
                LblPassengerBrakePower.Text = Val(txtPassengerBrakePower.Text)
            End If

            If DDPassengerSpeed.Text <> "Other" Then '010709
                LblPassengerSpeed.Text = DDPassengerSpeed.Text
            Else
                LblPassengerSpeed.Text = Val(txtPassengerSpeed.Text)
            End If

            If DDPassengerGrade.Text <> "Other" Then '010709
                LblPassengerGrade.Text = DDPassengerGrade.Text
            Else
                LblPassengerGrade.Text = Val(txtPassengerGrade.Text)
            End If
            ' '' ''LblPassengerBCPressure.Text = DDPassengerBCPressure.Text
            ' '' ''LblPassengerBrakePower.Text = DDPassengerBrakePower.Text
            ' '' ''LblPassengerSpeed.Text = DDPassengerSpeed.Text
            ' '' ''LblPassengerGrade.Text = DDPassengerGrade.Text


            LblPassengerEBD.Text = FinalDistance
        End If
    End Sub
    Protected Sub BtnPrintPassengerEBD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintPassengerEBD.Click
        Response.Redirect("Passenger_Report.aspx?RptPassengerLocoType=" + LblPassengerLocoType.Text + "&RptPassengerNoOfLoco=" + LblPassengerNoOfLoco.Text + "&RptPassengerLocoBrakeBlock=" + LblPassengerLocoBrakeBlock.Text + "&RptPassengerStockBrakeBlock=" + LblPassengerStockBrakeBlock.Text + "&RptPassengerNoOfStock=" + LblPassengerNoOfStock.Text + "&RptPassengerBCPressure=" + LblPassengerBCPressure.Text + "&RptPassengerBrakePower=" + LblPassengerBrakePower.Text + "&RptPassengerSpeed=" + LblPassengerSpeed.Text + "&RptPassengerGrade=" + LblPassengerGrade.Text + "&RptPassengerEBD=" + LblPassengerEBD.Text)
    End Sub
    Protected Sub DDPassengerLocoType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDPassengerLocoType.SelectedIndexChanged
        If DDPassengerLocoType.SelectedItem.Text = "WDG4" Or DDPassengerLocoType.SelectedItem.Text = "WDP4" Or DDPassengerLocoType.SelectedItem.Text = "WAP5" Or DDPassengerLocoType.SelectedItem.Text = "WDP4B" Then
            DDPassengerLocoBrakeBlock.Items.Clear()
            DDPassengerLocoBrakeBlock.Items.Add("Select")
            DDPassengerLocoBrakeBlock.Items.Add(New ListItem("High Friction", "3"))
        ElseIf DDPassengerLocoType.SelectedItem.Text = "WAG9" Or DDPassengerLocoType.SelectedItem.Text = "WAG9H" Or DDPassengerLocoType.SelectedItem.Text = "WAP7" Then
            DDPassengerLocoBrakeBlock.Items.Clear()
            DDPassengerLocoBrakeBlock.Items.Add("Select")
            DDPassengerLocoBrakeBlock.Items.Add(New ListItem("Cast Iron", "1"))
            DDPassengerLocoBrakeBlock.Items.Remove("Cast Iron")
        Else
            DDPassengerLocoBrakeBlock.Items.Clear()
            DDPassengerLocoBrakeBlock.Items.Add("Select")
            DDPassengerLocoBrakeBlock.Items.Add(New ListItem("Cast Iron", "1"))
            DDPassengerLocoBrakeBlock.Items.Add(New ListItem("L Type Composition", "2"))

        End If
    End Sub


    Protected Sub BtnChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnChart.Click
        Dim TotalBPloco As Double
        Dim BrakeEffortLoco As Double
        Dim TotalBPStock As Double
        Dim BrakeEffortStock As Double
        Dim RollingResistanceLoco As Double
        Dim RollingResistanceStock As Double
        Dim GradePull As Double
        Dim TotalBrakeEffort As Double
        Dim Retardation As Double
        Dim Distance As Double
        Dim TotalDistance As Double

        Dim Time As Integer
        Dim SpecificShoePrLoco As Integer
        Dim SpecificShoePrStock As Integer

        Dim Locoweight As Double
        Dim LocoBrakePower As Double
        Dim LocoBrakeBlock As Integer
        Dim LocoBrakeBlockArea As Double
        Dim LocoRRL1 As Double
        Dim LocoRRL2 As Double
        Dim LocoRRL3 As Double
        Dim LocoBCPressureForBP As Double
        Dim StockBrakePower As Double
        Dim StockWeight As Double
        Dim StockBrakePowerCI As Double
        Dim StockNumber As Double
        Dim StockRRL1 As Double
        Dim StockRRL2 As Double
        Dim StockRRL3 As Double
        Dim LocoNumber As Double
        Dim LocoBCPressure As Double
        Dim PercentageOperativeCylinder As Double
        Dim Speedkmph As Double
        Dim DownGrade As Double
        adp = New OdbcDataAdapter("Select Weight,Brakepower,numbrkblk,brkblkarea,X1,Y1,Z1,BCpressure from loco where locomotive='" + DDPassengerLocoType.SelectedItem.Text + "'", con1)

        ds = New DataSet()
        adp.Fill(ds, "loco")

        If ds.Tables("loco").Rows.Count > 0 Then
            For Each dr In ds.Tables("loco").Rows
                Locoweight = dr("Weight")
                LocoBrakePower = dr("Brakepower")
                LocoBrakeBlock = dr("numbrkblk")
                LocoBrakeBlockArea = dr("brkblkarea")
                LocoRRL1 = dr("X1")
                LocoRRL2 = dr("Y1")
                LocoRRL3 = dr("Z1")
                LocoBCPressureForBP = dr("BCpressure")
            Next
        End If
        LocoNumber = Val(DDPassengerNoOfLoco.Text)

        If DDPassengerBCPressure.Text <> "Other" Then '010709
            LocoBCPressure = DDPassengerBCPressure.SelectedValue
        Else
            LocoBCPressure = Val(txtPassengerBCPressure.Text)
        End If

        If DDPassengerBrakePower.Text <> "Other" Then '010709
            PercentageOperativeCylinder = (DDPassengerBrakePower.SelectedValue) / 100
        Else
            PercentageOperativeCylinder = (Val(txtPassengerBrakePower.Text)) / 100
        End If

        If DDPassengerSpeed.Text <> "Other" Then '010709
            Speedkmph = DDPassengerSpeed.SelectedValue
        Else
            Speedkmph = Val(txtPassengerSpeed.Text)
        End If

        If DDPassengerGrade.Text <> "Other" Then '010709
            DownGrade = DDPassengerGrade.SelectedValue
        Else
            DownGrade = Val(txtPassengerGrade.Text)
        End If

        '' ''LocoBCPressure = Val(DDPassengerBCPressure.Text)
        '' ''PercentageOperativeCylinder = Val(DDPassengerBrakePower.Text / 100)
        '' ''Speedkmph = Val(DDPassengerSpeed.Text)
        '' ''DownGrade = Val(DDPassengerGrade.Text)
        'data of stock
        StockWeight = Val(text1.Text)
        StockBrakePower = Val(text2.Text)
        StockBrakePowerCI = Val(text5.Text)
        StockNumber = Val(Text6.Text)
        StockRRL1 = 1.347
        StockRRL2 = 0.00385
        StockRRL3 = 0.000165
        'calculation of EBD
        Dim EffectiveTrainWeight As Double = 1.05 * (Locoweight * LocoNumber + StockWeight * StockNumber)
        Dim LocoBrakeDevTime As Integer = 13
        Dim StockBrakeDevTime1 As Integer
        Dim StockBrakeDevTime2 As Integer
        If StockNumber <= 19 Then StockBrakeDevTime1 = 5
        If StockNumber > 20 Then StockBrakeDevTime1 = 7
        If StockNumber <= 10 Then StockBrakeDevTime2 = 6
        If StockNumber > 10 And StockNumber <= 12 Then StockBrakeDevTime2 = 8
        If StockNumber > 12 And StockNumber <= 14 Then StockBrakeDevTime2 = 10
        If StockNumber > 14 And StockNumber <= 16 Then StockBrakeDevTime2 = 12
        If StockNumber > 16 And StockNumber <= 18 Then StockBrakeDevTime2 = 14
        If StockNumber > 18 And StockNumber <= 20 Then StockBrakeDevTime2 = 16
        If StockNumber > 20 And StockNumber <= 22 Then StockBrakeDevTime2 = 19
        If StockNumber > 22 And StockNumber <= 24 Then StockBrakeDevTime2 = 22
        If StockNumber > 24 And StockNumber <= 26 Then StockBrakeDevTime2 = 25
        Dim TimeLag1 As Integer = 1
        Dim TimeLag2 As Integer = 2

        Dim StockBrakeDevTime As Double = (StockBrakeDevTime1 + StockBrakeDevTime2) * 0.5
        Dim Velocity As Double = Speedkmph / 3.6
        Dim SKM As Double
        Dim AKS As Double
        Dim AKL As Double
        Dim B1, B2, B3, TL, FL, TS, FS, LocoFriction As Double
        Dim StockFriction As Double
        Dim StockBrakeBlock As Double
        Dim StockBrakeBlockArea As Double
        'dhiraj
        Dim table_name As String = "temp_passenger"
        cmd1.Connection = con1
        cmd2.Connection = con1
        cmd1.CommandText = "SELECT name FROM MSysObjects WHERE (MSysObjects.Name='" + table_name + "') AND (MSysObjects.Type=1)"
        con1.Open()
        rd1 = cmd1.ExecuteReader()
        If rd1.Read = True Then
            cmd2.CommandText = "drop table temp_passenger"
            cmd2.ExecuteNonQuery()

            cmd2.CommandText = " Create TABLE [temp_passenger] (fieldSpeedkmph double,fieldTime long,fieldDistance double)"

            cmd2.ExecuteNonQuery()

        Else
            cmd2.CommandText = " Create TABLE [temp_passenger] (fieldSpeedkmph double,fieldTime long,fieldDistance double)"

            cmd2.ExecuteNonQuery()
        End If
        con1.Close()


        Do While Velocity > 0
            B1 = 0.16166666
            B2 = 0.0103125
            B3 = 0.0002865
            TL = Time - TimeLag1 + 2
            If TL < 0 Then TL = 0
            FL = TL * 13.5 / (LocoBrakeDevTime - TimeLag1)
            AKL = (B1 * FL - B2 * FL * FL + B3 * FL * FL * FL)
            If AKL > 1 Then AKL = 1
            TS = Time - TimeLag2 + 2
            If TS < 0 Then TS = 0
            FS = TS * 13.5 / (StockBrakeDevTime - TimeLag2)
            AKS = B1 * FS - B2 * FS * FS + B3 * FS * FS * FS
            If AKS > 1 Then AKS = 1
            If DDPassengerLocoBrakeBlock.SelectedItem.Text = "Cast Iron" Then GoTo 150
            If DDPassengerLocoBrakeBlock.SelectedItem.Text = "L Type Composition" Then LocoFriction = 0.17
            If DDPassengerLocoBrakeBlock.SelectedItem.Text = "High Friction" Then LocoFriction = 0.25
            GoTo 160
150:        Speedkmph = Velocity * 3.6
            SKM = Speedkmph
            SpecificShoePrLoco = (LocoBrakePower * 0.85) / (LocoBrakeBlock * LocoBrakeBlockArea)
            If SpecificShoePrLoco < 6 Then SpecificShoePrLoco = 6
            If SpecificShoePrLoco > 12 Then SpecificShoePrLoco = 12
            If SpecificShoePrLoco = 6 Then GoTo 200
            If SpecificShoePrLoco = 7 Then GoTo 210
            If SpecificShoePrLoco = 8 Then GoTo 220
            If SpecificShoePrLoco = 9 Then GoTo 230
            If SpecificShoePrLoco = 10 Then GoTo 240
            If SpecificShoePrLoco = 11 Then GoTo 250
            If SpecificShoePrLoco = 12 Then GoTo 260
200:        If SKM >= 75 Then GoTo 2003
            If SKM >= 35 Then GoTo 2001
            If SKM < 35 Then GoTo 2002
2003:       LocoFriction = 1.04
            GoTo 160
2001:       LocoFriction = (0.3 + 1.70597654345651 * SKM - 0.217999971250967 * SKM * SKM + _
      0.0117817847707845 * SKM * SKM * SKM - 0.0003503704351204 * SKM * SKM * SKM * SKM + _
      0.0000061966868687 * SKM * SKM * SKM * SKM * SKM - 0.0000000652052836 * SKM * SKM * SKM * _
      SKM * SKM * SKM + 0.0000000003781108 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009324 _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2002:       LocoFriction = (0.3 - 0.0141178325123153 * SKM + 0.0004007290640394 * SKM * _
      SKM + 0.0000090214559387 * SKM * SKM * SKM - 0.0000009777011494 * SKM * SKM * SKM * SKM + _
      0.0000000155708812 * SKM * SKM * SKM * SKM * SKM + 0.0000000004229885 * SKM * SKM * SKM * SKM * _
      SKM * SKM - 0.0000000000124357 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + 0.0000000000000525 * SKM * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
210:        If SKM >= 75 Then GoTo 2103
            If SKM >= 35 Then GoTo 2101
            If SKM < 35 Then GoTo 2102
2103:       LocoFriction = 0.098
            GoTo 160
2101:       LocoFriction = (0.3 + 1.70510609723624 * SKM - 0.217945068720181 * SKM * SKM _
      + 0.0117798181248387 * SKM * SKM * SKM - 0.0003503266726237 * SKM * SKM * SKM * SKM _
      + 0.0000061960673401 * SKM * SKM * SKM * SKM * SKM - 0.0000000651998342 * SKM * SKM * SKM * _
      SKM * SKM * SKM + 0.0000000003780835 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2102:       LocoFriction = (0.3 - 0.021561330049261 * SKM + 0.0026047495894909 * SKM * SKM - _
      0.0002787030651341 * SKM * SKM * SKM + 0.0000181953065134 * SKM * SKM * SKM * SKM - _
      0.000000642605364 * SKM * SKM * SKM * SKM * SKM + 0.0000000105363985 * SKM * SKM * SKM * _
      SKM * SKM * SKM - 0.000000000031965 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
      0.0000000000006787 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
220:        If SKM >= 75 Then GoTo 2203
            If SKM >= 35 Then GoTo 2201
            If SKM < 35 Then GoTo 2202
2203:       LocoFriction = 0.092
            GoTo 160
2201:       LocoFriction = (0.3 + 1.70423565101564 * SKM - 0.217890166189369 * SKM * SKM + _
      0.0117778514788917 * SKM * SKM * SKM - 0.0003502829101269 * SKM * SKM * SKM * SKM + _
      0.0000061954478114 * SKM * SKM * SKM * SKM * SKM - 0.0000000651943849 * SKM * SKM * SKM * SKM _
      * SKM * SKM + 0.0000000003780563 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * SKM _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2202:       LocoFriction = (0.3 - 0.0261124137931033 * SKM + 0.0032766469622331 * SKM * _
      SKM - 0.0003122137931034 * SKM * SKM * SKM + 0.0000182213793103 * SKM * SKM * SKM _
      * SKM - 0.0000005943908046 * SKM * SKM * SKM * SKM * SKM + 0.0000000092137931 * SKM * _
      SKM * SKM * SKM * SKM * SKM - 0.0000000000257471 * SKM * SKM * SKM * SKM * SKM * SKM _
      * SKM - 0.000000000000578 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
230:        If SKM >= 75 Then GoTo 2303
            If SKM >= 35 Then GoTo 2301
            If SKM < 35 Then GoTo 2302
2303:       LocoFriction = 0.086
            GoTo 160
2301:       LocoFriction = (0.3 + 1.70336520479522 * SKM - 0.217835263658568 * SKM * SKM _
      + 0.0117758848329451 * SKM * SKM * SKM - 0.0003502391476302 * SKM * SKM * SKM * _
      SKM + 0.0000061948282828 * SKM * SKM * SKM * SKM * SKM - 0.0000000651889355 * SKM * SKM * _
      SKM * SKM * SKM * SKM + 0.0000000003780291 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
      0.0000000000009322 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2302:       LocoFriction = (0.3 - 0.0350428078817735 * SKM + 0.0061845295566502 * SKM * _
      SKM - 0.0007227459770115 * SKM * SKM * SKM + 0.0000476529310345 * SKM * SKM * SKM * SKM _
      - 0.0000016844137931 * SKM * SKM * SKM * SKM * SKM + 0.000000027645977 * SKM * SKM * SKM _
      * SKM * SKM * SKM - 0.0000000000832841 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000017997 _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
240:        If SKM >= 75 Then GoTo 2403
            If SKM >= 35 Then GoTo 2401
            If SKM < 35 Then GoTo 2402
2403:       LocoFriction = 0.08
            GoTo 160
2401:       LocoFriction = (0.3 - 5.84726968586961 * SKM + 0.747139572205568 * SKM * SKM _
      - 0.0406393079858413 * SKM * SKM * SKM + 0.0012185038988172 * SKM * SKM * SKM * _
      SKM - 0.0000217490011223 * SKM * SKM * SKM * SKM * SKM + 0.0000002311108348 * SKM * SKM _
      * SKM * SKM * SKM * SKM - 0.0000000013539488 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + _
      0.000000000003374 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2402:       LocoFriction = (0.3 - 0.0395938916256153 * SKM + 0.0068564269293924 * SKM * _
      SKM - 0.0007562567049808 * SKM * SKM * SKM + 0.0000476790038314 * SKM * SKM * SKM * SKM _
      - 0.0000016361992337 * SKM * SKM * SKM * SKM * SKM + 0.0000000263233716 * SKM * SKM * SKM * _
      SKM * SKM * SKM - 0.0000000000770662 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
      0.000000000001699 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
250:        If SKM >= 75 Then GoTo 2503
            If SKM > 35 Then GoTo 2501
            If SKM < 35 Then GoTo 2502
2503:       LocoFriction = 0.076
            GoTo 160
2501:       LocoFriction = (0.3 - 0.199231560661529 * SKM + 0.0203851445776407 * SKM * SKM _
      - 0.0008760435206766 * SKM * SKM * SKM + 0.0000192389946473 * SKM * SKM * SKM * SKM - _
      0.0000002145095398 * SKM * SKM * SKM * SKM * SKM + 0.0000000008762842 * SKM * SKM * SKM * SKM * _
      SKM * SKM + 0.0000000000032303 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000000291 * SKM * SKM _
      * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2502:       LocoFriction = (0.3 - 0.0426580788177338 * SKM + 0.0068244622331691 * SKM * _
      SKM - 0.0006669597701149 * SKM * SKM * SKM + 0.0000374465325671 * SKM * SKM * SKM * SKM _
      - 0.000001156137931 * SKM * SKM * SKM * SKM * SKM + 0.0000000166819923 * SKM * SKM * SKM * _
      SKM * SKM * SKM - 0.0000000000328407 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000011078 * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
260:        If SKM >= 75 Then GoTo 2603
            If SKM >= 35 Then GoTo 2601
            If SKM < 35 Then GoTo 2602
2603:       LocoFriction = 0.07
            GoTo 160
2601:       LocoFriction = (0.3 - 0.200102006881999 * SKM + 0.0204400471084461 * SKM * SKM _
      - 0.0008780101666234 * SKM * SKM * SKM + 0.0000192827571441 * SKM * SKM * SKM * SKM - _
      0.0000002151290685 * SKM * SKM * SKM * SKM * SKM + 0.0000000008817336 * SKM * SKM * SKM * SKM * _
      SKM * SKM + 0.0000000000032031 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.000000000000029 * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2602:       LocoFriction = (0.3 - 0.0472091625615763 * SKM + 0.0074963596059113 * SKM * _
      SKM - 0.0007004704980843 * SKM * SKM * SKM + 0.000037472605364 * SKM * SKM * SKM * SKM _
      - 0.0000011079233716 * SKM * SKM * SKM * SKM * SKM + 0.000000015359387 * SKM * SKM * SKM _
      * SKM * SKM * SKM - 0.0000000000266229 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000010071 _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
160:        TotalBPloco = (LocoBrakePower * LocoNumber * 0.85 * LocoFriction * LocoBCPressure) _
       / LocoBCPressureForBP
            BrakeEffortLoco = TotalBPloco
            If DDPassengerStockBrakeBlock.SelectedItem.Text = "Cast Iron" Then GoTo 170
            If DDPassengerStockBrakeBlock.SelectedItem.Text = "L Type Composition" Then GoTo 175
            If DDPassengerStockBrakeBlock.SelectedItem.Text = "K Type Composition" Then GoTo 180
            GoTo 190
170:        StockBrakePower = StockBrakePowerCI
            Speedkmph = Velocity * 3.6
            SKM = Speedkmph
            StockBrakeBlock = 16
            StockBrakeBlockArea = 270
            SpecificShoePrStock = (StockBrakePower * 0.81) / (StockBrakeBlock * StockBrakeBlockArea)
            If SpecificShoePrStock < 6 Then SpecificShoePrStock = 6
            If SpecificShoePrStock > 12 Then SpecificShoePrStock = 12
            If SpecificShoePrStock = 6 Then GoTo 300
            If SpecificShoePrStock = 7 Then GoTo 310
            If SpecificShoePrStock = 8 Then GoTo 320
            If SpecificShoePrStock = 9 Then GoTo 330
            If SpecificShoePrStock = 10 Then GoTo 340
            If SpecificShoePrStock = 11 Then GoTo 350
            If SpecificShoePrStock = 12 Then GoTo 360
300:        If SKM >= 75 Then GoTo 3003
            If SKM >= 35 Then GoTo 3001
            If SKM < 35 Then GoTo 3002
3003:       StockFriction = 1.04
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3001:       StockFriction = (0.3 + 1.70597654345651 * SKM - 0.217999971250967 * SKM * SKM + _
      0.0117817847707845 * SKM * SKM * SKM - 0.0003503704351204 * SKM * SKM * SKM * SKM + _
      0.0000061966868687 * SKM * SKM * SKM * SKM * SKM - 0.0000000652052836 * SKM * SKM * SKM * SKM _
      * SKM * SKM + 0.0000000003781108 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009324 * SKM _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3002:       StockFriction = (0.3 - 0.0141178325123153 * SKM + 0.0004007290640394 * SKM * SKM _
      + 0.0000090214559387 * SKM * SKM * SKM - 0.0000009777011494 * SKM * SKM * SKM * SKM + _
      0.0000000155708812 * SKM * SKM * SKM * SKM * SKM + 0.0000000004229885 * SKM * SKM * SKM * SKM * _
      SKM * SKM - 0.0000000000124357 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + 0.0000000000000525 * SKM * SKM _
      * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
310:        If SKM >= 75 Then GoTo 3103
            If SKM >= 35 Then GoTo 3101
            If SKM < 35 Then GoTo 3102
3103:       StockFriction = 0.098
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3101:       StockFriction = (0.3 + 1.70510609723624 * SKM - 0.217945068720181 * SKM * SKM + _
      0.0117798181248387 * SKM * SKM * SKM - 0.0003503266726237 * SKM * SKM * SKM * SKM + _
      0.0000061960673401 * SKM * SKM * SKM * SKM * SKM - 0.0000000651998342 * SKM * SKM * SKM * SKM _
      * SKM * SKM + 0.0000000003780835 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * SKM _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3102:       StockFriction = (0.3 - 0.021561330049261 * SKM + 0.0026047495894909 * SKM * SKM - _
      0.0002787030651341 * SKM * SKM * SKM + 0.0000181953065134 * SKM * SKM * SKM * SKM - _
      0.000000642605364 * SKM * SKM * SKM * SKM * SKM + 0.0000000105363985 * SKM * SKM * SKM * SKM _
      * SKM * SKM - 0.000000000031965 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000006787 * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
320:        If SKM >= 75 Then GoTo 3203
            If SKM >= 35 Then GoTo 3201
            If SKM < 35 Then GoTo 3202
3203:       StockFriction = 0.092
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3201:       StockFriction = (0.3 + 1.70423565101564 * SKM - 0.217890166189369 * SKM * SKM + _
      0.0117778514788917 * SKM * SKM * SKM - 0.0003502829101269 * SKM * SKM * SKM * SKM + _
      0.0000061954478114 * SKM * SKM * SKM * SKM * SKM - 0.0000000651943849 * SKM * SKM * SKM * SKM _
      * SKM * SKM + 0.0000000003780563 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * SKM _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3202:       StockFriction = (0.3 - 0.0261124137931033 * SKM + 0.0032766469622331 * SKM * _
      SKM - 0.0003122137931034 * SKM * SKM * SKM + 0.0000182213793103 * SKM * SKM * SKM * SKM _
      - 0.0000005943908046 * SKM * SKM * SKM * SKM * SKM + 0.0000000092137931 * SKM * SKM * SKM * SKM _
      * SKM * SKM - 0.0000000000257471 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.000000000000578 _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
330:        If SKM >= 75 Then GoTo 3303
            If SKM >= 35 Then GoTo 3301
            If SKM < 35 Then GoTo 3302
3303:       StockFriction = 0.086
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3301:       StockFriction = (0.3 + 1.70336520479522 * SKM - 0.217835263658568 * SKM * SKM + _
      0.0117758848329451 * SKM * SKM * SKM - 0.0003502391476302 * SKM * SKM * SKM * SKM + _
      0.0000061948282828 * SKM * SKM * SKM * SKM * SKM - 0.0000000651889355 * SKM * SKM * SKM * SKM _
      * SKM * SKM + 0.0000000003780291 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009322 * SKM _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3302:       StockFriction = (0.3 - 0.0350428078817735 * SKM + 0.0061845295566502 * SKM * _
      SKM - 0.0007227459770115 * SKM * SKM * SKM + 0.0000476529310345 * SKM * SKM * SKM * SKM _
      - 0.0000016844137931 * SKM * SKM * SKM * SKM * SKM + 0.000000027645977 * SKM * SKM * SKM _
      * SKM * SKM * SKM - 0.0000000000832841 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000017997 _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
340:        If SKM >= 75 Then GoTo 3403
            If SKM >= 35 Then GoTo 3401
            If SKM < 35 Then GoTo 3402
3403:       StockFriction = 0.08
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3401:       StockFriction = (0.3 - 5.84726968586961 * SKM + 0.747139572205568 * SKM * SKM - _
      0.0406393079858413 * SKM * SKM * SKM + 0.0012185038988172 * SKM * SKM * SKM * SKM - _
      0.0000217490011223 * SKM * SKM * SKM * SKM * SKM + 0.0000002311108348 * SKM * SKM * SKM * _
      SKM * SKM * SKM - 0.0000000013539488 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + _
      0.000000000003374 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3402:       StockFriction = (0.3 - 0.0395938916256153 * SKM + 0.0068564269293924 * SKM * _
      SKM - 0.0007562567049808 * SKM * SKM * SKM + 0.0000476790038314 * SKM * SKM * SKM * SKM _
      - 0.0000016361992337 * SKM * SKM * SKM * SKM * SKM + 0.0000000263233716 * SKM * SKM * SKM * _
      SKM * SKM * SKM - 0.0000000000770662 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
      0.000000000001699 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
350:        If SKM >= 75 Then GoTo 3503
            If SKM > 35 Then GoTo 3501
            If SKM < 35 Then GoTo 3502
3503:       StockFriction = 0.076
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3501:       StockFriction = (0.3 - 0.199231560661529 * SKM + 0.0203851445776407 * SKM * SKM _
      - 0.0008760435206766 * SKM * SKM * SKM + 0.0000192389946473 * SKM * SKM * SKM * SKM - _
      0.0000002145095398 * SKM * SKM * SKM * SKM * SKM + 0.0000000008762842 * SKM * SKM * SKM * SKM * _
      SKM * SKM + 0.0000000000032303 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000000291 * SKM * SKM _
      * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3502:       StockFriction = (0.3 - 0.0426580788177338 * SKM + 0.0068244622331691 * SKM * _
      SKM - 0.0006669597701149 * SKM * SKM * SKM + 0.0000374465325671 * SKM * SKM * SKM * SKM _
      - 0.000001156137931 * SKM * SKM * SKM * SKM * SKM + 0.0000000166819923 * SKM * SKM * SKM * _
      SKM * SKM * SKM - 0.0000000000328407 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000011078 * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
360:        If SKM >= 75 Then GoTo 3603
            If SKM >= 35 Then GoTo 3601
            If SKM < 35 Then GoTo 3602
3603:       StockFriction = 0.07
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3601:       StockFriction = (0.3 - 0.200102006881999 * SKM + 0.0204400471084461 * SKM * SKM _
      - 0.0008780101666234 * SKM * SKM * SKM + 0.0000192827571441 * SKM * SKM * SKM * SKM - _
      0.0000002151290685 * SKM * SKM * SKM * SKM * SKM + 0.0000000008817336 * SKM * SKM * SKM * SKM * _
      SKM * SKM + 0.0000000000032031 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.000000000000029 * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
3602:       StockFriction = (0.3 - 0.0472091625615763 * SKM + 0.0074963596059113 * SKM * _
      SKM - 0.0007004704980843 * SKM * SKM * SKM + 0.000037472605364 * SKM * SKM * SKM * SKM _
      - 0.0000011079233716 * SKM * SKM * SKM * SKM * SKM + 0.000000015359387 * SKM * SKM * SKM _
      * SKM * SKM * SKM - 0.0000000000266229 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000010071 _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            If SKM < 100 Then StockFriction = StockFriction * 0.95 '090709
            GoTo 190
175:        StockBrakePower = StockBrakePowerCI
            StockFriction = 0.17
            GoTo 190
180:        Speedkmph = Velocity * 3.6
            If Speedkmph < 40 Then StockFriction = 0.27
            If Speedkmph > 40 Then StockFriction = 0.23
            GoTo 190
190:        TotalBPStock = StockBrakePower * StockNumber * 0.81 * StockFriction * PercentageOperativeCylinder
            BrakeEffortStock = TotalBPStock
            If Time <= LocoBrakeDevTime Then GoTo 30
            GoTo 40
30:         BrakeEffortLoco = TotalBPloco * AKL
40:         If Time <= StockBrakeDevTime Then GoTo 50
            GoTo 60
50:         BrakeEffortStock = TotalBPStock * AKS
60:         RollingResistanceLoco = ((LocoRRL1 + LocoRRL2 * Speedkmph + LocoRRL3 * Speedkmph * _
        Speedkmph) * Locoweight * LocoNumber) / 1000
            RollingResistanceStock = ((StockRRL1 + StockRRL2 * Speedkmph + StockRRL3 * Speedkmph * _
            Speedkmph) * StockWeight * StockNumber) / 1000
            GradePull = EffectiveTrainWeight / DownGrade * 1.05
            If DownGrade >= 500 Then GradePull = 0
            TotalBrakeEffort = BrakeEffortLoco + BrakeEffortStock + RollingResistanceLoco + RollingResistanceStock + GradePull
            Retardation = TotalBrakeEffort * 9.81 / EffectiveTrainWeight
            Distance = Velocity - 0.5 * Retardation
            TotalDistance = TotalDistance + Distance
            Velocity = Velocity - Retardation
            Time = Time + 1
            If Speedkmph < 0 Then
                Speedkmph = 0
            End If

            cmd1.Connection = con1
            cmd1.CommandText = "Insert Into temp_passenger (fieldSpeedkmph,fieldTime,fieldDistance) values ('" & Speedkmph & "','" & Time & "','" & TotalDistance & "')"
            con1.Open()
            cmd1.ExecuteNonQuery()
            con1.Close()
        Loop
        'Response.Redirect("PassengerChart.aspx")
        Response.Redirect("PassengerChart.aspx?RptQry_distance=" + txtTotalDistance.Text + "&RptQry_time=" + txtTime.Text)

    End Sub

    Protected Sub DDPassengerCoachType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDPassengerCoachType.SelectedIndexChanged

        'If DDPassengerCoachType.SelectedItem.Text = "AC3TIER-LHBSHELL-ICFBOGIE" Or DDPassengerCoachType.SelectedItem.Text = "LHB -ACHOTBUFFER" Or DDPassengerCoachType.SelectedItem.Text = "LHB-AC2TIEREOG" Or DDPassengerCoachType.SelectedItem.Text = "LHB-AC3TIEREOG" Or DDPassengerCoachType.SelectedItem.Text = "LHB-AC3TIERSG" Or DDPassengerCoachType.SelectedItem.Text = "LHB-ACFIRSTCLASS" Or DDPassengerCoachType.SelectedItem.Text = "LHB-ACCHAIRCAR" Or DDPassengerCoachType.SelectedItem.Text = "LHB-ACFIRSTSLEEPER" Or DDPassengerCoachType.SelectedItem.Text = "LHB-GENCAR" Or DDPassengerCoachType.SelectedItem.Text = "GARIBRATH-ACCHAIRCAR" Or DDPassengerCoachType.SelectedItem.Text = "GARIBRATH-ACSLEEPER-81" Or DDPassengerCoachType.SelectedItem.Text = "GARIBRATH-ACSLEEPER-75" Or DDPassengerCoachType.SelectedItem.Text = "AC3TIER-LHBSHELL-ICFBOGIE" Then

        'If DDPassengerCoachType.SelectedItem.Text = "LHB-AC-2T" Or DDPassengerCoachType.SelectedItem.Text = "LHB-ACFirstclass" Or DDPassengerCoachType.SelectedItem.Text = "LHB-ACChaircar" Or DDPassengerCoachType.SelectedItem.Text = "LHB-ACFirstsleeper" Or DDPassengerCoachType.SelectedItem.Text = "LHB-AC-3TEOG" Or DDPassengerCoachType.SelectedItem.Text = "AC3Tier-LHBShell-ICFBogie" Or DDPassengerCoachType.SelectedItem.Text = "LHB-AC-3TSG" Or DDPassengerCoachType.SelectedItem.Text = "LHB -ACHotBufferCar" Or DDPassengerCoachType.SelectedItem.Text = "LHB-GeneratorCar" Or DDPassengerCoachType.SelectedItem.Text = "SG-AC3T-72Berths" Or DDPassengerCoachType.SelectedItem.Text = "AC-3T-WGACCN2" Or DDPassengerCoachType.SelectedItem.Text = "GARIBRATH-ACChairCar" Or DDPassengerCoachType.SelectedItem.Text = "GARIBRATH-ACSleeper-81" Or DDPassengerCoachType.SelectedItem.Text = "GARIBRATH-ACSleeper-75" Or DDPassengerCoachType.SelectedItem.Text = "AC-3Tier-WACCNH1" Or DDPassengerCoachType.SelectedItem.Text = "SG-Sleeper-81Berths /WGSCN2" Then

If DDPassengerCoachType.SelectedItem.Text = "AC EOG Double Decker Chiar Car" Or DDPassengerCoachType.SelectedItem.Text _
            = "AC3Tier-LHBShell-ICFBogie" Or DDPassengerCoachType.SelectedItem.Text = "AC-3Tier-WACCNH1" Or DDPassengerCoachType.SelectedItem.Text _
            = "AC-3T-WGACCN2" Or DDPassengerCoachType.SelectedItem.Text = "EOG Generator Car or IRY Power car" Or DDPassengerCoachType.SelectedItem.Text _
            = "EOG type IRY AC Chair car with IR-20 bogie" Or DDPassengerCoachType.SelectedItem.Text = "GaribRath-ACChairCar" Or DDPassengerCoachType.SelectedItem.Text _
            = "GaribRath--ACSleeper-75" Or DDPassengerCoachType.SelectedItem.Text = "GaribRath--ACSleeper-81" Or DDPassengerCoachType.SelectedItem.Text _
            = "GaribRath--SG-AC3T-72Berths" Or DDPassengerCoachType.SelectedItem.Text = "GrbRath-SG-Slpeer-81Brts. /WGSCN2" Or DDPassengerCoachType.SelectedItem.Text _
            = "ICC" Or DDPassengerCoachType.SelectedItem.Text = "LHB -ACHotBufferCar/LWCBAC" Or DDPassengerCoachType.SelectedItem.Text = "LHB-AC-2T/ACCW" _
            Or DDPassengerCoachType.SelectedItem.Text = "LHB-AC-3TEOG" Or DDPassengerCoachType.SelectedItem.Text = "LHB-AC-3TSG/ACCN" Or _
            DDPassengerCoachType.SelectedItem.Text = "LHB-ACChaircar" Or DDPassengerCoachType.SelectedItem.Text = "LHB-ACFirstsleeper/FAC" Or _
            DDPassengerCoachType.SelectedItem.Text = "LHB-AC-OSC-Car-EOG" Or DDPassengerCoachType.SelectedItem.Text = "LHB-GeneratorCar" Or _
            DDPassengerCoachType.SelectedItem.Text = "LHB-LGS (LHB second class)" Or DDPassengerCoachType.SelectedItem.Text = "LHB-Non AC Chaircar" Or _
            DDPassengerCoachType.SelectedItem.Text = "LHB-SLR (LuggageCumGuardCompartment)" Or DDPassengerCoachType.SelectedItem.Text = "LS/Non AC second class/LGS" Or _
            DDPassengerCoachType.SelectedItem.Text = "LWACCN" Or DDPassengerCoachType.SelectedItem.Text = "LWACCW" Or DDPassengerCoachType.SelectedItem.Text _
            = "LWCB" Or DDPassengerCoachType.SelectedItem.Text = "LWFAC" Or DDPassengerCoachType.SelectedItem.Text = "LWFACZA/LHB AC First class-EOG Coach" _
            Or DDPassengerCoachType.SelectedItem.Text = "LWLRRM/Power Car" Or DDPassengerCoachType.SelectedItem.Text = "LWSCN/Non AC 3-tier Sleeper/Non AC SL" _
            Or DDPassengerCoachType.SelectedItem.Text = "LWSCZAC/LHB AC chair car-EOG Coach" Or DDPassengerCoachType.SelectedItem.Text = "OSC-All coil ICF bogie" _
            Or DDPassengerCoachType.SelectedItem.Text = "OSC-IR-20 bogie" Or DDPassengerCoachType.SelectedItem.Text = "Power Car for Double Decker Chair Car" Or _
            DDPassengerCoachType.SelectedItem.Text = "SGS" Or DDPassengerCoachType.SelectedItem.Text = "SGSLR" Or DDPassengerCoachType.SelectedItem.Text = "SGSLRD" _
            Or DDPassengerCoachType.SelectedItem.Text = "SGSRD" Or DDPassengerCoachType.SelectedItem.Text = "SGWCB(HybridPantryCar)" Or DDPassengerCoachType.SelectedItem.Text _
            = "SLRD" Or DDPassengerCoachType.SelectedItem.Text = "SWGACCN" Or DDPassengerCoachType.SelectedItem.Text = "SWGACCW" Or DDPassengerCoachType.SelectedItem.Text _
            = "SWGCBN" Or DDPassengerCoachType.SelectedItem.Text = "SWGCWNAC" Or DDPassengerCoachType.SelectedItem.Text = "SWGFAC" Or DDPassengerCoachType.SelectedItem.Text = _
            "SWGFCWAC" Or DDPassengerCoachType.SelectedItem.Text = "SWGSCN" Or DDPassengerCoachType.SelectedItem.Text = "SWGSCZAC" _
            Or DDPassengerCoachType.SelectedItem.Text = "VVN/Milk Tank Van loaded" Or DDPassengerCoachType.SelectedItem.Text = "WICBAC1" _
            Or DDPassengerCoachType.SelectedItem.Text = "WICBAC2" Or DDPassengerCoachType.SelectedItem.Text = "WICCBAC" Or DDPassengerCoachType.SelectedItem.Text = _
            "WICRAC" Or DDPassengerCoachType.SelectedItem.Text = "WICTAC1" Or DDPassengerCoachType.SelectedItem.Text = "WICTAC2" Or DDPassengerCoachType.SelectedItem.Text _
            = "WICTAC3" Or DDPassengerCoachType.SelectedItem.Text = "WICTAC4" Or DDPassengerCoachType.SelectedItem.Text = "WILRRM" _
            Or DDPassengerCoachType.SelectedItem.Text = "WISAC" Then

            DDPassengerStockBrakeBlock.Items.Clear()
            DDPassengerStockBrakeBlock.Items.Add("Select")
            DDPassengerStockBrakeBlock.Items.Add(New ListItem("K Type Composition", "3"))
        Else
            DDPassengerStockBrakeBlock.Items.Clear()
            DDPassengerStockBrakeBlock.Items.Add("Select")
            DDPassengerStockBrakeBlock.Items.Add(New ListItem("Cast Iron", "1"))
            DDPassengerStockBrakeBlock.Items.Add(New ListItem("L Type Composition", "2"))
            DDPassengerStockBrakeBlock.Items.Add(New ListItem("K Type Composition", "3"))

        End If
    End Sub
    Protected Sub DDPassengerBCPressure_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDPassengerBCPressure.SelectedIndexChanged
        If DDPassengerBCPressure.Text = "Other" Then
            txtPassengerBCPressure.Visible = True
        Else
            txtPassengerBCPressure.Visible = False
        End If
    End Sub

    Protected Sub DDPassengerBrakePower_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDPassengerBrakePower.SelectedIndexChanged
        If DDPassengerBrakePower.Text = "Other" Then
            txtPassengerBrakePower.Visible = True
        Else
            txtPassengerBrakePower.Visible = False
        End If
    End Sub

    Protected Sub DDPassengerSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDPassengerSpeed.SelectedIndexChanged
        If DDPassengerSpeed.Text = "Other" Then
            txtPassengerSpeed.Visible = True
        Else
            txtPassengerSpeed.Visible = False
        End If
    End Sub

    Protected Sub DDPassengerGrade_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDPassengerGrade.SelectedIndexChanged
        If DDPassengerGrade.Text = "Other" Then
            txtPassengerGrade.Visible = True
        Else
            txtPassengerGrade.Visible = False
        End If
    End Sub
End Class
