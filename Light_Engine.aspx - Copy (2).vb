
Imports System.Data
Imports System.Data.Odbc
Partial Class Light_Engine
    Inherits System.Web.UI.Page
    Dim cmd As New OdbcCommand
    Dim con1 As OdbcConnection
    Dim adp As New OdbcDataAdapter
    Dim rd As OdbcDataReader
    Dim cmd1 As New OdbcCommand
    Dim cmd2 As New OdbcCommand

    Dim rd1 As OdbcDataReader
    Dim ds As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con1 = New OdbcConnection("DRIVER={Microsoft Access Driver (*.mdb)};DBQ=c:\ebd_web_data\locodatabase.mdb;DefaultDir=;UID=;PWD=;")

        PanelLightEngine.Visible = False
        If Not IsPostBack Then

            cmd.Connection = con1
            cmd.CommandText = " Select locomotive from loco order by locomotive" 'new 

            con1.Open()
            rd = cmd.ExecuteReader
            DDLightEngineLocoType.Items.Add("Select")

            While rd.Read() = True
                DDLightEngineLocoType.Items.Add(New ListItem(rd(0)))
            End While
            rd.Close()
            con1.Close()

        End If
    End Sub

    Protected Sub BtnLightEngine_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLightEngine.Click
        If DDLightEngineLocoType.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Type of Locomotive');</script>")
        ElseIf DDLightEngineNoOfLoco.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select No. of Locomotive');</script>")
        ElseIf DDLightEngineLocoBrakeBlock.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Loco Brake block');</script>")
        ElseIf DDLightEngineBCPressure.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select BC Pressure');</script>")
        ElseIf DDLightEngineSpeed.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Speed');</script>")
        ElseIf DDLightEngineGrade.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Grade');</script>")

        ElseIf DDLightEngineBCPressure.Text = "Other" And Val(txtLightEngineBCPressure.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select BC Pressure of Loco');</script>")
        ElseIf DDLightEngineSpeed.Text = "Other" And Val(txtLightEngineSpeed.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Speed');</script>")
        ElseIf DDLightEngineGrade.Text = "Other" And Val(txtLightEngineGrade.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Grade');</script>")

        Else


            Dim Time As Integer
            Dim SpecificShoePrLoco As Integer
            Dim FinalDistance As Integer
            Dim Locoweight As Double
            Dim LocoBrakePower As Double
            Dim LocoBrakeBlock As Integer
            Dim LocoBrakeBlockArea As Double
            Dim LocoRRL1 As Double
            Dim LocoRRL2 As Double
            Dim LocoRRL3 As Double
            Dim LocoBCPressureForBP As Double
            Dim LocoNumber As Double
            Dim LocoBCPressure As Double
            Dim Speedkmph As Double
            Dim DownGrade As Double
            Dim SKM As Double
            Dim AKL As Double
            Dim B1, B2, B3, TL, FL, LocoFriction As Double
            Dim TotalBPloco As Double
            Dim BrakeEffortLoco As Double
            Dim RollingResistanceLoco As Double
            Dim GradePull As Double
            Dim TotalBrakeEffort As Double
            Dim Retardation As Double
            Dim Distance As Double
            Dim TotalDistance As Double


            adp = New OdbcDataAdapter("Select Weight,Brakepower,numbrkblk,brkblkarea,X1,Y1,Z1,BCpressure from loco where locomotive='" + DDLightEngineLocoType.Text + "'", con1)
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
            LocoNumber = Val(DDLightEngineNoOfLoco.Text)

            If DDLightEngineBCPressure.Text <> "Other" Then '010709
                LocoBCPressure = DDLightEngineBCPressure.SelectedValue
            Else
                LocoBCPressure = Val(txtLightEngineBCPressure.Text)
            End If

            If DDLightEngineSpeed.Text <> "Other" Then '010709
                Speedkmph = DDLightEngineSpeed.SelectedValue
            Else
                Speedkmph = Val(txtLightEngineSpeed.Text)
            End If

            If DDLightEngineGrade.Text <> "Other" Then '010709
                DownGrade = DDLightEngineGrade.SelectedValue
            Else
                DownGrade = Val(txtLightEngineGrade.Text)
            End If

            ' ''LocoBCPressure = Val(DDLightEngineBCPressure.Text)
            ' ''Speedkmph = Val(DDLightEngineSpeed.Text)
            ' ''DownGrade = Val(DDLightEngineGrade.Text)


            Dim EffectiveTrainWeight As Double = 1.05 * (Locoweight * LocoNumber)
            Dim LocoBrakeDevTime As Double = 5
            Dim TimeLag1 As Integer = 1
            Dim Velocity As Double = Speedkmph / 3.6



            Do While Velocity > 0
                B1 = 0.16166666
                B2 = 0.0103125
                B3 = 0.0002865
                TL = Time - TimeLag1 + 2
                If TL < 0 Then TL = 0
                FL = TL * 13.5 / (LocoBrakeDevTime - TimeLag1)
                AKL = (B1 * FL - B2 * FL * FL + B3 * FL * FL * FL)
                If AKL > 1 Then AKL = 1
                If DDLightEngineLocoBrakeBlock.SelectedItem.Text = "Cast Iron" Then GoTo 150
                If DDLightEngineLocoBrakeBlock.SelectedItem.Text = "L Type Composition" Then LocoFriction = 0.17
                If DDLightEngineLocoBrakeBlock.SelectedItem.Text = "High Friction" Then LocoFriction = 0.25
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
                If Time <= LocoBrakeDevTime Then GoTo 30
                GoTo 40
30:             BrakeEffortLoco = TotalBPloco * AKL
40:             RollingResistanceLoco = ((LocoRRL1 + LocoRRL2 * Speedkmph + LocoRRL3 * Speedkmph * _
            Speedkmph) * Locoweight * LocoNumber) / 1000
                GradePull = EffectiveTrainWeight / DownGrade * 1.05
                If DownGrade >= 500 Then GradePull = 0
                TotalBrakeEffort = BrakeEffortLoco + RollingResistanceLoco + GradePull
                Retardation = TotalBrakeEffort * 9.81 / EffectiveTrainWeight
                Distance = Velocity - 0.5 * Retardation
                TotalDistance = TotalDistance + Distance
                Velocity = Velocity - Retardation
                Time = Time + 1

                Speedkmph = Velocity * 3.6
                'List1.AddItem("SPEED " + Str(Speedkmph) + " time " + Str(Time) + " distance " + Str(TotalDistance))
            Loop
            'End
            '70:     EBD.Text = TotalDistance
            txtTime.Text = Time
            txtTotalDistance.Text = TotalDistance

            FinalDistance = Val(TotalDistance)



            PanelLightEngine.Visible = True
            LblLightEngineLocoType.Text = DDLightEngineLocoType.Text
            LblLightEngineNoOfLoco.Text = DDLightEngineNoOfLoco.Text
            LblLightEngineLocoBrakeBlock.Text = DDLightEngineLocoBrakeBlock.SelectedItem.Text
            If DDLightEngineBCPressure.Text <> "Other" Then '010709
                LblLightEngineBCPressure.Text = DDLightEngineBCPressure.Text
            Else
                LblLightEngineBCPressure.Text = Val(txtLightEngineBCPressure.Text)
            End If

            If DDLightEngineSpeed.Text <> "Other" Then '010709
                LblLightEngineSpeed.Text = DDLightEngineSpeed.Text
            Else
                LblLightEngineSpeed.Text = Val(txtLightEngineSpeed.Text)
            End If

            If DDLightEngineGrade.Text <> "Other" Then '010709
                LblLightEngineGrade.Text = DDLightEngineGrade.Text
            Else
                LblLightEngineGrade.Text = Val(txtLightEngineGrade.Text)
            End If

            '' ''LblLightEngineBCPressure.Text = DDLightEngineBCPressure.Text
            '' ''LblLightEngineSpeed.Text = DDLightEngineSpeed.Text
            '' ''LblLightEngineGrade.Text = DDLightEngineGrade.Text
            LblLightEngineEBD.Text = FinalDistance
        End If 'check
    End Sub
    Protected Sub BtnPrintLightEngineEBD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintLightEngineEBD.Click
        Response.Redirect("LightEngine_Report.aspx?RptLightEngineLocoType=" + LblLightEngineLocoType.Text + "&RptLightEngineNoOfLoco=" + LblLightEngineNoOfLoco.Text + "&RptLightEngineLocoBrakeBlock=" + LblLightEngineLocoBrakeBlock.Text + "&RptLightEngineBCPressure=" + LblLightEngineBCPressure.Text + "&RptLightEngineSpeed=" + LblLightEngineSpeed.Text + "&RptLightEngineGrade=" + LblLightEngineGrade.Text + "&RptLightEngineEBD=" + LblLightEngineEBD.Text)
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("menu.aspx")
    End Sub

    Protected Sub BtnChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnChart.Click
        Dim Time As Integer
        Dim SpecificShoePrLoco As Integer
         Dim Locoweight As Double
        Dim LocoBrakePower As Double
        Dim LocoBrakeBlock As Integer
        Dim LocoBrakeBlockArea As Double
        Dim LocoRRL1 As Double
        Dim LocoRRL2 As Double
        Dim LocoRRL3 As Double
        Dim LocoBCPressureForBP As Double
        Dim LocoNumber As Double
        Dim LocoBCPressure As Double
        Dim Speedkmph As Double
        Dim DownGrade As Double
        Dim SKM As Double
        Dim AKL As Double
        Dim B1, B2, B3, TL, FL, LocoFriction As Double
        Dim TotalBPloco As Double
        Dim BrakeEffortLoco As Double
        Dim RollingResistanceLoco As Double
        Dim GradePull As Double
        Dim TotalBrakeEffort As Double
        Dim Retardation As Double
        Dim Distance As Double
        Dim TotalDistance As Double


        adp = New OdbcDataAdapter("Select Weight,Brakepower,numbrkblk,brkblkarea,X1,Y1,Z1,BCpressure from loco where locomotive='" + DDLightEngineLocoType.Text + "'", con1)
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
        LocoNumber = Val(DDLightEngineNoOfLoco.Text)

        If DDLightEngineBCPressure.Text <> "Other" Then '010709
            LocoBCPressure = DDLightEngineBCPressure.SelectedValue
        Else
            LocoBCPressure = Val(txtLightEngineBCPressure.Text)
        End If

        If DDLightEngineSpeed.Text <> "Other" Then '010709
            Speedkmph = DDLightEngineSpeed.SelectedValue
        Else
            Speedkmph = Val(txtLightEngineSpeed.Text)
        End If

        If DDLightEngineGrade.Text <> "Other" Then '010709
            DownGrade = DDLightEngineGrade.SelectedValue
        Else
            DownGrade = Val(txtLightEngineGrade.Text)
        End If




        '' ''LocoBCPressure = Val(DDLightEngineBCPressure.Text)
        '' ''Speedkmph = Val(DDLightEngineSpeed.Text)
        '' ''DownGrade = Val(DDLightEngineGrade.Text)


        Dim EffectiveTrainWeight As Double = 1.05 * (Locoweight * LocoNumber)
        Dim LocoBrakeDevTime As Double = 5
        Dim TimeLag1 As Integer = 1
        Dim Velocity As Double = Speedkmph / 3.6
        Dim table_name As String = "temp_LightEngine"
        cmd1.Connection = con1
        cmd2.Connection = con1
        cmd1.CommandText = "SELECT name FROM MSysObjects WHERE (MSysObjects.Name='" + table_name + "') AND (MSysObjects.Type=1)"
        con1.Open()
        rd1 = cmd1.ExecuteReader()
        If rd1.Read = True Then
            cmd2.CommandText = "drop table temp_LightEngine"
            cmd2.ExecuteNonQuery()

            cmd2.CommandText = " Create TABLE [temp_LightEngine] (fieldSpeedkmph double,fieldTime long,fieldDistance double)"

            cmd2.ExecuteNonQuery()

        Else
            cmd2.CommandText = " Create TABLE [temp_LightEngine] (fieldSpeedkmph double,fieldTime long,fieldDistance double)"

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
            If DDLightEngineLocoBrakeBlock.SelectedItem.Text = "Cast Iron" Then GoTo 150
            If DDLightEngineLocoBrakeBlock.SelectedItem.Text = "L Type Composition" Then LocoFriction = 0.17
            If DDLightEngineLocoBrakeBlock.SelectedItem.Text = "High Friction" Then LocoFriction = 0.25
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
            If Time <= LocoBrakeDevTime Then GoTo 30
            GoTo 40
30:         BrakeEffortLoco = TotalBPloco * AKL
40:         RollingResistanceLoco = ((LocoRRL1 + LocoRRL2 * Speedkmph + LocoRRL3 * Speedkmph * _
        Speedkmph) * Locoweight * LocoNumber) / 1000
            GradePull = EffectiveTrainWeight / DownGrade * 1.05
            If DownGrade >= 500 Then GradePull = 0
            TotalBrakeEffort = BrakeEffortLoco + RollingResistanceLoco + GradePull
            Retardation = TotalBrakeEffort * 9.81 / EffectiveTrainWeight
            Distance = Velocity - 0.5 * Retardation
            TotalDistance = TotalDistance + Distance
            Velocity = Velocity - Retardation
            Time = Time + 1
            Speedkmph = Velocity * 3.6
            If Speedkmph < 0 Then
                Speedkmph = 0
            End If

            cmd1.Connection = con1
            cmd1.CommandText = "Insert Into temp_LightEngine (fieldSpeedkmph,fieldTime,fieldDistance) values ('" & Speedkmph & "','" & Time & "','" & TotalDistance & "')" 'dhs
            con1.Open()
            cmd1.ExecuteNonQuery()
            con1.Close()

        Loop
         Response.Redirect("LightEngineChart.aspx?RptQry_distance=" + txtTotalDistance.Text + "&RptQry_time=" + txtTime.Text)

    End Sub

    Protected Sub DDLightEngineLocoType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLightEngineLocoType.SelectedIndexChanged
        If DDLightEngineLocoType.SelectedItem.Text = "WDG4" Or DDLightEngineLocoType.SelectedItem.Text = "WDP4" Or DDLightEngineLocoType.SelectedItem.Text = "WAP5" _
        Or DDLightEngineLocoType.SelectedItem.Text = "WDP4B" Or DDLightEngineLocoType.SelectedItem.Text = "WDG5" Or DDLightEngineLocoType.SelectedItem.Text = "WDP4D" Then
            DDLightEngineLocoBrakeBlock.Items.Clear()
            DDLightEngineLocoBrakeBlock.Items.Add("Select")
            DDLightEngineLocoBrakeBlock.Items.Add(New ListItem("High Friction", "3"))
        ElseIf DDLightEngineLocoType.SelectedItem.Text = "WAG9" Or DDLightEngineLocoType.SelectedItem.Text = "WAG9H" Or DDLightEngineLocoType.SelectedItem.Text = "WAP7CONV" Or DDLightEngineLocoType.SelectedItem.Text = "WAP7" Then
            DDLightEngineLocoBrakeBlock.Items.Clear()
            DDLightEngineLocoBrakeBlock.Items.Add("Select")
            DDLightEngineLocoBrakeBlock.Items.Add(New ListItem("Cast Iron", "1"))
            DDLightEngineLocoBrakeBlock.Items.Remove("Cast Iron")
        Else
            DDLightEngineLocoBrakeBlock.Items.Clear()
            DDLightEngineLocoBrakeBlock.Items.Add("Select")
            DDLightEngineLocoBrakeBlock.Items.Add(New ListItem("Cast Iron", "1"))
            DDLightEngineLocoBrakeBlock.Items.Add(New ListItem("L Type Composition", "2"))
        End If
    End Sub
    Protected Sub DDLightEngineBCPressure_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLightEngineBCPressure.SelectedIndexChanged
        If DDLightEngineBCPressure.Text = "Other" Then
            txtLightEngineBCPressure.Visible = True
        Else
            txtLightEngineBCPressure.Visible = False
        End If
    End Sub
    Protected Sub DDLightEngineSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLightEngineSpeed.SelectedIndexChanged
        If DDLightEngineSpeed.Text = "Other" Then
            txtLightEngineSpeed.Visible = True
        Else
            txtLightEngineSpeed.Visible = False
        End If
    End Sub
    Protected Sub DDLightEngineGrade_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLightEngineGrade.SelectedIndexChanged
        If DDLightEngineGrade.Text = "Other" Then
            txtLightEngineGrade.Visible = True
        Else
            txtLightEngineGrade.Visible = False
        End If
    End Sub
End Class
