Public Class frmMain

    Private m_CPU As New Info.CPU

    Private Sub tmrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMain.Tick
        Dim CurrentUtilisation As Integer = m_CPU.CurrentUtilisation

        Me.Plotter1.Add(CurrentUtilisation)
        lblLoad.Text = CurrentUtilisation & "%"

        Me.Refresh()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Plotter1.Min = 0
        Me.Plotter1.Max = 100
        Me.Plotter1.ForeColor = Color.AntiqueWhite

    End Sub

    Private Sub btnStartStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartStop.Click
        tmrMain.Enabled = Not tmrMain.Enabled

        If tmrMain.Enabled = True Then
            btnStartStop.Text = "Stop"
            m_CPU.SpinEnabled = True
            m_CPU.DesiredCPUUtilisation = CInt(nudDesiredValue.Value)
            m_CPU.StartCPUSpin()
        Else
            btnStartStop.Text = "Start"
            m_CPU.SpinEnabled = False
        End If
    End Sub

    Private Sub nudDesiredValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDesiredValue.ValueChanged
        m_CPU.DesiredCPUUtilisation = CInt(nudDesiredValue.Value)
    End Sub

End Class
