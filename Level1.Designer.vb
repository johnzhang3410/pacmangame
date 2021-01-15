<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Level1
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
        Me.components = New System.ComponentModel.Container()
        Me.MyPac = New System.Windows.Forms.PictureBox()
        Me.PbxGhost1 = New System.Windows.Forms.PictureBox()
        Me.PacClock = New System.Windows.Forms.Timer(Me.components)
        Me.Ghost1MoveClock = New System.Windows.Forms.Timer(Me.components)
        Me.Ghost2MoveClock = New System.Windows.Forms.Timer(Me.components)
        Me.Ghost3MoveClock = New System.Windows.Forms.Timer(Me.components)
        Me.Ghost4MoveClock = New System.Windows.Forms.Timer(Me.components)
        Me.PowerPelletClock = New System.Windows.Forms.Timer(Me.components)
        Me.PowerFruitClock = New System.Windows.Forms.Timer(Me.components)
        Me.lblScores = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.pbxGhost2 = New System.Windows.Forms.PictureBox()
        Me.pbxGhost3 = New System.Windows.Forms.PictureBox()
        Me.pbxGhost4 = New System.Windows.Forms.PictureBox()
        Me.Heart1 = New System.Windows.Forms.PictureBox()
        Me.Heart4 = New System.Windows.Forms.PictureBox()
        Me.Heart3 = New System.Windows.Forms.PictureBox()
        Me.Heart2 = New System.Windows.Forms.PictureBox()
        Me.StartClock = New System.Windows.Forms.Timer(Me.components)
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnShow = New System.Windows.Forms.Button()
        CType(Me.MyPac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbxGhost1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGhost2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGhost3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGhost4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Heart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Heart4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Heart3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Heart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MyPac
        '
        Me.MyPac.Location = New System.Drawing.Point(50, 50)
        Me.MyPac.Name = "MyPac"
        Me.MyPac.Size = New System.Drawing.Size(50, 50)
        Me.MyPac.TabIndex = 2
        Me.MyPac.TabStop = False
        '
        'PbxGhost1
        '
        Me.PbxGhost1.Location = New System.Drawing.Point(250, 50)
        Me.PbxGhost1.Name = "PbxGhost1"
        Me.PbxGhost1.Size = New System.Drawing.Size(50, 50)
        Me.PbxGhost1.TabIndex = 3
        Me.PbxGhost1.TabStop = False
        '
        'PacClock
        '
        Me.PacClock.Enabled = True
        Me.PacClock.Interval = 50
        '
        'Ghost1MoveClock
        '
        Me.Ghost1MoveClock.Enabled = True
        Me.Ghost1MoveClock.Interval = 50
        '
        'Ghost2MoveClock
        '
        Me.Ghost2MoveClock.Enabled = True
        Me.Ghost2MoveClock.Interval = 50
        '
        'Ghost3MoveClock
        '
        Me.Ghost3MoveClock.Enabled = True
        Me.Ghost3MoveClock.Interval = 50
        '
        'Ghost4MoveClock
        '
        Me.Ghost4MoveClock.Enabled = True
        Me.Ghost4MoveClock.Interval = 50
        '
        'PowerPelletClock
        '
        '
        'lblScores
        '
        Me.lblScores.AutoSize = True
        Me.lblScores.ForeColor = System.Drawing.SystemColors.Control
        Me.lblScores.Location = New System.Drawing.Point(12, 9)
        Me.lblScores.Name = "lblScores"
        Me.lblScores.Size = New System.Drawing.Size(41, 13)
        Me.lblScores.TabIndex = 4
        Me.lblScores.Text = "Score: "
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Font = New System.Drawing.Font("SimSun", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblStart.ForeColor = System.Drawing.SystemColors.Control
        Me.lblStart.Location = New System.Drawing.Point(381, 9)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(0, 19)
        Me.lblStart.TabIndex = 5
        '
        'pbxGhost2
        '
        Me.pbxGhost2.Location = New System.Drawing.Point(700, 125)
        Me.pbxGhost2.Name = "pbxGhost2"
        Me.pbxGhost2.Size = New System.Drawing.Size(50, 50)
        Me.pbxGhost2.TabIndex = 6
        Me.pbxGhost2.TabStop = False
        '
        'pbxGhost3
        '
        Me.pbxGhost3.Location = New System.Drawing.Point(700, 257)
        Me.pbxGhost3.Name = "pbxGhost3"
        Me.pbxGhost3.Size = New System.Drawing.Size(50, 50)
        Me.pbxGhost3.TabIndex = 7
        Me.pbxGhost3.TabStop = False
        '
        'pbxGhost4
        '
        Me.pbxGhost4.Location = New System.Drawing.Point(538, 257)
        Me.pbxGhost4.Name = "pbxGhost4"
        Me.pbxGhost4.Size = New System.Drawing.Size(50, 50)
        Me.pbxGhost4.TabIndex = 8
        Me.pbxGhost4.TabStop = False
        '
        'Heart1
        '
        Me.Heart1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Heart1.Location = New System.Drawing.Point(732, 772)
        Me.Heart1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Heart1.Name = "Heart1"
        Me.Heart1.Size = New System.Drawing.Size(50, 50)
        Me.Heart1.TabIndex = 9
        Me.Heart1.TabStop = False
        Me.Heart1.Visible = False
        '
        'Heart4
        '
        Me.Heart4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Heart4.Location = New System.Drawing.Point(580, 772)
        Me.Heart4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Heart4.Name = "Heart4"
        Me.Heart4.Size = New System.Drawing.Size(50, 50)
        Me.Heart4.TabIndex = 10
        Me.Heart4.TabStop = False
        '
        'Heart3
        '
        Me.Heart3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Heart3.Location = New System.Drawing.Point(628, 772)
        Me.Heart3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Heart3.Name = "Heart3"
        Me.Heart3.Size = New System.Drawing.Size(50, 50)
        Me.Heart3.TabIndex = 11
        Me.Heart3.TabStop = False
        '
        'Heart2
        '
        Me.Heart2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Heart2.Location = New System.Drawing.Point(682, 772)
        Me.Heart2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Heart2.Name = "Heart2"
        Me.Heart2.Size = New System.Drawing.Size(50, 50)
        Me.Heart2.TabIndex = 12
        Me.Heart2.TabStop = False
        '
        'StartClock
        '
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(524, 23)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 13
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        Me.btnNext.Visible = False
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(605, 23)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 23)
        Me.btnShow.TabIndex = 14
        Me.btnShow.Text = "Show"
        Me.btnShow.UseVisualStyleBackColor = True
        Me.btnShow.Visible = False
        '
        'Level1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(888, 764)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.Heart2)
        Me.Controls.Add(Me.Heart3)
        Me.Controls.Add(Me.Heart4)
        Me.Controls.Add(Me.Heart1)
        Me.Controls.Add(Me.pbxGhost4)
        Me.Controls.Add(Me.pbxGhost3)
        Me.Controls.Add(Me.pbxGhost2)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.lblScores)
        Me.Controls.Add(Me.PbxGhost1)
        Me.Controls.Add(Me.MyPac)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "Level1"
        Me.Text = "Form1"
        CType(Me.MyPac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbxGhost1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGhost2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGhost3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGhost4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Heart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Heart4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Heart3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Heart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MyPac As System.Windows.Forms.PictureBox
    Friend WithEvents PbxGhost1 As System.Windows.Forms.PictureBox
    Friend WithEvents PacClock As System.Windows.Forms.Timer
    Friend WithEvents Ghost1MoveClock As System.Windows.Forms.Timer
    Friend WithEvents Ghost2MoveClock As System.Windows.Forms.Timer
    Friend WithEvents Ghost3MoveClock As System.Windows.Forms.Timer
    Friend WithEvents Ghost4MoveClock As System.Windows.Forms.Timer
    Friend WithEvents PowerPelletClock As System.Windows.Forms.Timer
    Friend WithEvents PowerFruitClock As System.Windows.Forms.Timer
    Friend WithEvents lblScores As System.Windows.Forms.Label
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents pbxGhost2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbxGhost3 As System.Windows.Forms.PictureBox
    Friend WithEvents pbxGhost4 As System.Windows.Forms.PictureBox
    Friend WithEvents Heart1 As System.Windows.Forms.PictureBox
    Friend WithEvents Heart4 As System.Windows.Forms.PictureBox
    Friend WithEvents Heart3 As System.Windows.Forms.PictureBox
    Friend WithEvents Heart2 As System.Windows.Forms.PictureBox
    Friend WithEvents StartClock As System.Windows.Forms.Timer
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnShow As System.Windows.Forms.Button

End Class
