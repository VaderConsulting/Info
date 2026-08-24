<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.lblDesired = New System.Windows.Forms.Label
        Me.nudDesiredValue = New System.Windows.Forms.NumericUpDown
        Me.Plotter1 = New Slepov.WinForms.Plotter
        Me.btnStartStop = New System.Windows.Forms.Button
        Me.lblLoad = New System.Windows.Forms.Label
        CType(Me.nudDesiredValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrMain
        '
        Me.tmrMain.Interval = 500
        '
        'lblDesired
        '
        Me.lblDesired.AutoSize = True
        Me.lblDesired.Location = New System.Drawing.Point(12, 9)
        Me.lblDesired.Name = "lblDesired"
        Me.lblDesired.Size = New System.Drawing.Size(70, 13)
        Me.lblDesired.TabIndex = 0
        Me.lblDesired.Text = "Desired Load"
        '
        'nudDesiredValue
        '
        Me.nudDesiredValue.Location = New System.Drawing.Point(88, 7)
        Me.nudDesiredValue.Name = "nudDesiredValue"
        Me.nudDesiredValue.Size = New System.Drawing.Size(45, 20)
        Me.nudDesiredValue.TabIndex = 1
        Me.nudDesiredValue.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Plotter1
        '
        Me.Plotter1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Plotter1.BackColor = System.Drawing.Color.DarkGreen
        Me.Plotter1.Location = New System.Drawing.Point(15, 33)
        Me.Plotter1.Max = 100.0!
        Me.Plotter1.Min = 0.0!
        Me.Plotter1.Name = "Plotter1"
        Me.Plotter1.Size = New System.Drawing.Size(277, 157)
        Me.Plotter1.TabIndex = 4
        '
        'btnStartStop
        '
        Me.btnStartStop.Location = New System.Drawing.Point(139, 5)
        Me.btnStartStop.Name = "btnStartStop"
        Me.btnStartStop.Size = New System.Drawing.Size(74, 22)
        Me.btnStartStop.TabIndex = 2
        Me.btnStartStop.Text = "Start"
        Me.btnStartStop.UseVisualStyleBackColor = True
        '
        'lblLoad
        '
        Me.lblLoad.AutoSize = True
        Me.lblLoad.Location = New System.Drawing.Point(219, 9)
        Me.lblLoad.Name = "lblLoad"
        Me.lblLoad.Size = New System.Drawing.Size(0, 13)
        Me.lblLoad.TabIndex = 3
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 202)
        Me.Controls.Add(Me.lblLoad)
        Me.Controls.Add(Me.btnStartStop)
        Me.Controls.Add(Me.Plotter1)
        Me.Controls.Add(Me.nudDesiredValue)
        Me.Controls.Add(Me.lblDesired)
        Me.MinimumSize = New System.Drawing.Size(320, 240)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CPU Load simulator"
        CType(Me.nudDesiredValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrMain As System.Windows.Forms.Timer
    Friend WithEvents lblDesired As System.Windows.Forms.Label
    Friend WithEvents nudDesiredValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Plotter1 As Slepov.WinForms.Plotter
    Friend WithEvents btnStartStop As System.Windows.Forms.Button
    Friend WithEvents lblLoad As System.Windows.Forms.Label

End Class
