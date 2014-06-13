﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenRoomForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpenRoomForm))
        Me.MeetingInformationGrpBox = New System.Windows.Forms.GroupBox()
        Me.MeetingLengthTxtBox = New System.Windows.Forms.Label()
        Me.StartTimeTxtBox = New System.Windows.Forms.Label()
        Me.MeetingLengthComboBox = New System.Windows.Forms.ComboBox()
        Me.StartTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.StartDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.FindRoomBtn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RDCheckBox = New System.Windows.Forms.CheckBox()
        Me.OpsCheckBox = New System.Windows.Forms.CheckBox()
        Me.Floor2CheckBox = New System.Windows.Forms.CheckBox()
        Me.CarmelCommandButton = New System.Windows.Forms.Button()
        Me.MendocinoCommandButton = New System.Windows.Forms.Button()
        Me.NapaCommandButton = New System.Windows.Forms.Button()
        Me.PinnaclesCommandButton = New System.Windows.Forms.Button()
        Me.TahoeCommandButton = New System.Windows.Forms.Button()
        Me.BigSurCommandButton = New System.Windows.Forms.Button()
        Me.SantaCruzCommandButton = New System.Windows.Forms.Button()
        Me.ShastaCommandButton = New System.Windows.Forms.Button()
        Me.SquawValleyCommandButton = New System.Windows.Forms.Button()
        Me.JoshuaTreeCommandButton = New System.Windows.Forms.Button()
        Me.MontereyCommandButton = New System.Windows.Forms.Button()
        Me.PismoBeachCommandButton = New System.Windows.Forms.Button()
        Me.CarmelTxtBox = New System.Windows.Forms.Label()
        Me.MendocinoTxtBox = New System.Windows.Forms.Label()
        Me.NapaTxtBox = New System.Windows.Forms.Label()
        Me.PinnaclesTxtBox = New System.Windows.Forms.Label()
        Me.TahoeTxtBox = New System.Windows.Forms.Label()
        Me.BigSurTxtBox = New System.Windows.Forms.Label()
        Me.SantaCruzTxtBox = New System.Windows.Forms.Label()
        Me.ShastaTxtBox = New System.Windows.Forms.Label()
        Me.SquawValleyTxtBox = New System.Windows.Forms.Label()
        Me.JoshuaTreeTxtBox = New System.Windows.Forms.Label()
        Me.MontereyTxtBox = New System.Windows.Forms.Label()
        Me.PismoBeachTxtBox = New System.Windows.Forms.Label()
        Me.DRRoomCommandButton = New System.Windows.Forms.Button()
        Me.DRRoomTxtBox = New System.Windows.Forms.Label()
        Me.MeetingInformationGrpBox.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MeetingInformationGrpBox
        '
        Me.MeetingInformationGrpBox.Controls.Add(Me.MeetingLengthTxtBox)
        Me.MeetingInformationGrpBox.Controls.Add(Me.StartTimeTxtBox)
        Me.MeetingInformationGrpBox.Controls.Add(Me.MeetingLengthComboBox)
        Me.MeetingInformationGrpBox.Controls.Add(Me.StartTimePicker)
        Me.MeetingInformationGrpBox.Controls.Add(Me.StartDatePicker)
        Me.MeetingInformationGrpBox.Location = New System.Drawing.Point(12, 12)
        Me.MeetingInformationGrpBox.Name = "MeetingInformationGrpBox"
        Me.MeetingInformationGrpBox.Size = New System.Drawing.Size(290, 89)
        Me.MeetingInformationGrpBox.TabIndex = 0
        Me.MeetingInformationGrpBox.TabStop = False
        Me.MeetingInformationGrpBox.Text = "Meeting Information"
        '
        'MeetingLengthTxtBox
        '
        Me.MeetingLengthTxtBox.AutoSize = True
        Me.MeetingLengthTxtBox.Location = New System.Drawing.Point(6, 51)
        Me.MeetingLengthTxtBox.Name = "MeetingLengthTxtBox"
        Me.MeetingLengthTxtBox.Size = New System.Drawing.Size(81, 13)
        Me.MeetingLengthTxtBox.TabIndex = 2
        Me.MeetingLengthTxtBox.Text = "Meeting Length"
        '
        'StartTimeTxtBox
        '
        Me.StartTimeTxtBox.AutoSize = True
        Me.StartTimeTxtBox.Location = New System.Drawing.Point(6, 19)
        Me.StartTimeTxtBox.Name = "StartTimeTxtBox"
        Me.StartTimeTxtBox.Size = New System.Drawing.Size(55, 13)
        Me.StartTimeTxtBox.TabIndex = 2
        Me.StartTimeTxtBox.Text = "Start Time"
        '
        'MeetingLengthComboBox
        '
        Me.MeetingLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MeetingLengthComboBox.FormattingEnabled = True
        Me.MeetingLengthComboBox.Location = New System.Drawing.Point(93, 51)
        Me.MeetingLengthComboBox.Name = "MeetingLengthComboBox"
        Me.MeetingLengthComboBox.Size = New System.Drawing.Size(180, 21)
        Me.MeetingLengthComboBox.TabIndex = 1
        '
        'StartTimePicker
        '
        Me.StartTimePicker.CustomFormat = "h:mm tt"
        Me.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.StartTimePicker.Location = New System.Drawing.Point(186, 19)
        Me.StartTimePicker.Name = "StartTimePicker"
        Me.StartTimePicker.ShowUpDown = True
        Me.StartTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.StartTimePicker.TabIndex = 0
        '
        'StartDatePicker
        '
        Me.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.StartDatePicker.Location = New System.Drawing.Point(93, 19)
        Me.StartDatePicker.Name = "StartDatePicker"
        Me.StartDatePicker.Size = New System.Drawing.Size(87, 20)
        Me.StartDatePicker.TabIndex = 0
        '
        'FindRoomBtn
        '
        Me.FindRoomBtn.Location = New System.Drawing.Point(330, 67)
        Me.FindRoomBtn.Name = "FindRoomBtn"
        Me.FindRoomBtn.Size = New System.Drawing.Size(153, 34)
        Me.FindRoomBtn.TabIndex = 1
        Me.FindRoomBtn.Text = "Find a Room!"
        Me.FindRoomBtn.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(330, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(153, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'RDCheckBox
        '
        Me.RDCheckBox.AutoSize = True
        Me.RDCheckBox.Checked = True
        Me.RDCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RDCheckBox.Location = New System.Drawing.Point(12, 107)
        Me.RDCheckBox.Name = "RDCheckBox"
        Me.RDCheckBox.Size = New System.Drawing.Size(89, 17)
        Me.RDCheckBox.TabIndex = 3
        Me.RDCheckBox.Text = "Floor 1 - R&&D"
        Me.RDCheckBox.UseVisualStyleBackColor = True
        '
        'OpsCheckBox
        '
        Me.OpsCheckBox.AutoSize = True
        Me.OpsCheckBox.Checked = True
        Me.OpsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OpsCheckBox.Location = New System.Drawing.Point(176, 107)
        Me.OpsCheckBox.Name = "OpsCheckBox"
        Me.OpsCheckBox.Size = New System.Drawing.Size(86, 17)
        Me.OpsCheckBox.TabIndex = 3
        Me.OpsCheckBox.Text = "Floor 1 - Ops"
        Me.OpsCheckBox.UseVisualStyleBackColor = True
        '
        'Floor2CheckBox
        '
        Me.Floor2CheckBox.AutoSize = True
        Me.Floor2CheckBox.Checked = True
        Me.Floor2CheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Floor2CheckBox.Location = New System.Drawing.Point(362, 107)
        Me.Floor2CheckBox.Name = "Floor2CheckBox"
        Me.Floor2CheckBox.Size = New System.Drawing.Size(58, 17)
        Me.Floor2CheckBox.TabIndex = 3
        Me.Floor2CheckBox.Text = "Floor 2"
        Me.Floor2CheckBox.UseVisualStyleBackColor = True
        '
        'CarmelCommandButton
        '
        Me.CarmelCommandButton.Location = New System.Drawing.Point(12, 130)
        Me.CarmelCommandButton.Name = "CarmelCommandButton"
        Me.CarmelCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.CarmelCommandButton.TabIndex = 4
        Me.CarmelCommandButton.UseVisualStyleBackColor = True
        '
        'MendocinoCommandButton
        '
        Me.MendocinoCommandButton.Location = New System.Drawing.Point(12, 168)
        Me.MendocinoCommandButton.Name = "MendocinoCommandButton"
        Me.MendocinoCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.MendocinoCommandButton.TabIndex = 4
        Me.MendocinoCommandButton.UseVisualStyleBackColor = True
        '
        'NapaCommandButton
        '
        Me.NapaCommandButton.Location = New System.Drawing.Point(12, 206)
        Me.NapaCommandButton.Name = "NapaCommandButton"
        Me.NapaCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.NapaCommandButton.TabIndex = 4
        Me.NapaCommandButton.UseVisualStyleBackColor = True
        '
        'PinnaclesCommandButton
        '
        Me.PinnaclesCommandButton.Location = New System.Drawing.Point(12, 244)
        Me.PinnaclesCommandButton.Name = "PinnaclesCommandButton"
        Me.PinnaclesCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.PinnaclesCommandButton.TabIndex = 4
        Me.PinnaclesCommandButton.UseVisualStyleBackColor = True
        '
        'TahoeCommandButton
        '
        Me.TahoeCommandButton.Location = New System.Drawing.Point(12, 282)
        Me.TahoeCommandButton.Name = "TahoeCommandButton"
        Me.TahoeCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.TahoeCommandButton.TabIndex = 4
        Me.TahoeCommandButton.UseVisualStyleBackColor = True
        '
        'BigSurCommandButton
        '
        Me.BigSurCommandButton.Location = New System.Drawing.Point(176, 130)
        Me.BigSurCommandButton.Name = "BigSurCommandButton"
        Me.BigSurCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.BigSurCommandButton.TabIndex = 4
        Me.BigSurCommandButton.UseVisualStyleBackColor = True
        '
        'SantaCruzCommandButton
        '
        Me.SantaCruzCommandButton.Location = New System.Drawing.Point(176, 168)
        Me.SantaCruzCommandButton.Name = "SantaCruzCommandButton"
        Me.SantaCruzCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.SantaCruzCommandButton.TabIndex = 4
        Me.SantaCruzCommandButton.UseVisualStyleBackColor = True
        '
        'ShastaCommandButton
        '
        Me.ShastaCommandButton.Location = New System.Drawing.Point(361, 128)
        Me.ShastaCommandButton.Name = "ShastaCommandButton"
        Me.ShastaCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.ShastaCommandButton.TabIndex = 4
        Me.ShastaCommandButton.UseVisualStyleBackColor = True
        '
        'SquawValleyCommandButton
        '
        Me.SquawValleyCommandButton.Location = New System.Drawing.Point(361, 166)
        Me.SquawValleyCommandButton.Name = "SquawValleyCommandButton"
        Me.SquawValleyCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.SquawValleyCommandButton.TabIndex = 4
        Me.SquawValleyCommandButton.UseVisualStyleBackColor = True
        '
        'JoshuaTreeCommandButton
        '
        Me.JoshuaTreeCommandButton.Location = New System.Drawing.Point(361, 204)
        Me.JoshuaTreeCommandButton.Name = "JoshuaTreeCommandButton"
        Me.JoshuaTreeCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.JoshuaTreeCommandButton.TabIndex = 4
        Me.JoshuaTreeCommandButton.UseVisualStyleBackColor = True
        '
        'MontereyCommandButton
        '
        Me.MontereyCommandButton.Location = New System.Drawing.Point(361, 242)
        Me.MontereyCommandButton.Name = "MontereyCommandButton"
        Me.MontereyCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.MontereyCommandButton.TabIndex = 4
        Me.MontereyCommandButton.UseVisualStyleBackColor = True
        '
        'PismoBeachCommandButton
        '
        Me.PismoBeachCommandButton.Location = New System.Drawing.Point(361, 280)
        Me.PismoBeachCommandButton.Name = "PismoBeachCommandButton"
        Me.PismoBeachCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.PismoBeachCommandButton.TabIndex = 4
        Me.PismoBeachCommandButton.UseVisualStyleBackColor = True
        '
        'CarmelTxtBox
        '
        Me.CarmelTxtBox.AutoSize = True
        Me.CarmelTxtBox.Location = New System.Drawing.Point(43, 135)
        Me.CarmelTxtBox.Name = "CarmelTxtBox"
        Me.CarmelTxtBox.Size = New System.Drawing.Size(39, 13)
        Me.CarmelTxtBox.TabIndex = 5
        Me.CarmelTxtBox.Text = "Carmel"
        '
        'MendocinoTxtBox
        '
        Me.MendocinoTxtBox.AutoSize = True
        Me.MendocinoTxtBox.Location = New System.Drawing.Point(43, 175)
        Me.MendocinoTxtBox.Name = "MendocinoTxtBox"
        Me.MendocinoTxtBox.Size = New System.Drawing.Size(60, 13)
        Me.MendocinoTxtBox.TabIndex = 5
        Me.MendocinoTxtBox.Text = "Mendocino"
        '
        'NapaTxtBox
        '
        Me.NapaTxtBox.AutoSize = True
        Me.NapaTxtBox.Location = New System.Drawing.Point(43, 213)
        Me.NapaTxtBox.Name = "NapaTxtBox"
        Me.NapaTxtBox.Size = New System.Drawing.Size(33, 13)
        Me.NapaTxtBox.TabIndex = 5
        Me.NapaTxtBox.Text = "Napa"
        '
        'PinnaclesTxtBox
        '
        Me.PinnaclesTxtBox.AutoSize = True
        Me.PinnaclesTxtBox.Location = New System.Drawing.Point(43, 251)
        Me.PinnaclesTxtBox.Name = "PinnaclesTxtBox"
        Me.PinnaclesTxtBox.Size = New System.Drawing.Size(53, 13)
        Me.PinnaclesTxtBox.TabIndex = 5
        Me.PinnaclesTxtBox.Text = "Pinnacles"
        '
        'TahoeTxtBox
        '
        Me.TahoeTxtBox.AutoSize = True
        Me.TahoeTxtBox.Location = New System.Drawing.Point(43, 289)
        Me.TahoeTxtBox.Name = "TahoeTxtBox"
        Me.TahoeTxtBox.Size = New System.Drawing.Size(38, 13)
        Me.TahoeTxtBox.TabIndex = 5
        Me.TahoeTxtBox.Text = "Tahoe"
        '
        'BigSurTxtBox
        '
        Me.BigSurTxtBox.AutoSize = True
        Me.BigSurTxtBox.Location = New System.Drawing.Point(207, 136)
        Me.BigSurTxtBox.Name = "BigSurTxtBox"
        Me.BigSurTxtBox.Size = New System.Drawing.Size(41, 13)
        Me.BigSurTxtBox.TabIndex = 5
        Me.BigSurTxtBox.Text = "Big Sur"
        '
        'SantaCruzTxtBox
        '
        Me.SantaCruzTxtBox.AutoSize = True
        Me.SantaCruzTxtBox.Location = New System.Drawing.Point(207, 174)
        Me.SantaCruzTxtBox.Name = "SantaCruzTxtBox"
        Me.SantaCruzTxtBox.Size = New System.Drawing.Size(59, 13)
        Me.SantaCruzTxtBox.TabIndex = 5
        Me.SantaCruzTxtBox.Text = "Santa Cruz"
        '
        'ShastaTxtBox
        '
        Me.ShastaTxtBox.AutoSize = True
        Me.ShastaTxtBox.Location = New System.Drawing.Point(392, 134)
        Me.ShastaTxtBox.Name = "ShastaTxtBox"
        Me.ShastaTxtBox.Size = New System.Drawing.Size(40, 13)
        Me.ShastaTxtBox.TabIndex = 5
        Me.ShastaTxtBox.Text = "Shasta"
        '
        'SquawValleyTxtBox
        '
        Me.SquawValleyTxtBox.AutoSize = True
        Me.SquawValleyTxtBox.Location = New System.Drawing.Point(392, 172)
        Me.SquawValleyTxtBox.Name = "SquawValleyTxtBox"
        Me.SquawValleyTxtBox.Size = New System.Drawing.Size(71, 13)
        Me.SquawValleyTxtBox.TabIndex = 5
        Me.SquawValleyTxtBox.Text = "Squaw Valley"
        '
        'JoshuaTreeTxtBox
        '
        Me.JoshuaTreeTxtBox.AutoSize = True
        Me.JoshuaTreeTxtBox.Location = New System.Drawing.Point(392, 212)
        Me.JoshuaTreeTxtBox.Name = "JoshuaTreeTxtBox"
        Me.JoshuaTreeTxtBox.Size = New System.Drawing.Size(66, 13)
        Me.JoshuaTreeTxtBox.TabIndex = 5
        Me.JoshuaTreeTxtBox.Text = "Joshua Tree"
        '
        'MontereyTxtBox
        '
        Me.MontereyTxtBox.AutoSize = True
        Me.MontereyTxtBox.Location = New System.Drawing.Point(392, 248)
        Me.MontereyTxtBox.Name = "MontereyTxtBox"
        Me.MontereyTxtBox.Size = New System.Drawing.Size(51, 13)
        Me.MontereyTxtBox.TabIndex = 5
        Me.MontereyTxtBox.Text = "Monterey"
        '
        'PismoBeachTxtBox
        '
        Me.PismoBeachTxtBox.AutoSize = True
        Me.PismoBeachTxtBox.Location = New System.Drawing.Point(392, 288)
        Me.PismoBeachTxtBox.Name = "PismoBeachTxtBox"
        Me.PismoBeachTxtBox.Size = New System.Drawing.Size(69, 13)
        Me.PismoBeachTxtBox.TabIndex = 5
        Me.PismoBeachTxtBox.Text = "Pismo Beach"
        '
        'DRRoomCommandButton
        '
        Me.DRRoomCommandButton.Location = New System.Drawing.Point(12, 318)
        Me.DRRoomCommandButton.Name = "DRRoomCommandButton"
        Me.DRRoomCommandButton.Size = New System.Drawing.Size(25, 25)
        Me.DRRoomCommandButton.TabIndex = 4
        Me.DRRoomCommandButton.UseVisualStyleBackColor = True
        '
        'DRRoomTxtBox
        '
        Me.DRRoomTxtBox.AutoSize = True
        Me.DRRoomTxtBox.Location = New System.Drawing.Point(43, 325)
        Me.DRRoomTxtBox.Name = "DRRoomTxtBox"
        Me.DRRoomTxtBox.Size = New System.Drawing.Size(110, 13)
        Me.DRRoomTxtBox.TabIndex = 5
        Me.DRRoomTxtBox.Text = "Design Review Room"
        '
        'OpenRoomForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 363)
        Me.Controls.Add(Me.PismoBeachTxtBox)
        Me.Controls.Add(Me.MontereyTxtBox)
        Me.Controls.Add(Me.JoshuaTreeTxtBox)
        Me.Controls.Add(Me.SquawValleyTxtBox)
        Me.Controls.Add(Me.ShastaTxtBox)
        Me.Controls.Add(Me.SantaCruzTxtBox)
        Me.Controls.Add(Me.BigSurTxtBox)
        Me.Controls.Add(Me.DRRoomTxtBox)
        Me.Controls.Add(Me.TahoeTxtBox)
        Me.Controls.Add(Me.PinnaclesTxtBox)
        Me.Controls.Add(Me.NapaTxtBox)
        Me.Controls.Add(Me.MendocinoTxtBox)
        Me.Controls.Add(Me.CarmelTxtBox)
        Me.Controls.Add(Me.DRRoomCommandButton)
        Me.Controls.Add(Me.PismoBeachCommandButton)
        Me.Controls.Add(Me.TahoeCommandButton)
        Me.Controls.Add(Me.MontereyCommandButton)
        Me.Controls.Add(Me.JoshuaTreeCommandButton)
        Me.Controls.Add(Me.PinnaclesCommandButton)
        Me.Controls.Add(Me.NapaCommandButton)
        Me.Controls.Add(Me.SquawValleyCommandButton)
        Me.Controls.Add(Me.SantaCruzCommandButton)
        Me.Controls.Add(Me.MendocinoCommandButton)
        Me.Controls.Add(Me.ShastaCommandButton)
        Me.Controls.Add(Me.BigSurCommandButton)
        Me.Controls.Add(Me.CarmelCommandButton)
        Me.Controls.Add(Me.Floor2CheckBox)
        Me.Controls.Add(Me.OpsCheckBox)
        Me.Controls.Add(Me.RDCheckBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.FindRoomBtn)
        Me.Controls.Add(Me.MeetingInformationGrpBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OpenRoomForm"
        Me.Text = "OpenRoom by Geoff Russell"
        Me.MeetingInformationGrpBox.ResumeLayout(False)
        Me.MeetingInformationGrpBox.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MeetingInformationGrpBox As System.Windows.Forms.GroupBox
    Friend WithEvents StartDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents StartTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents MeetingLengthTxtBox As System.Windows.Forms.Label
    Friend WithEvents StartTimeTxtBox As System.Windows.Forms.Label
    Friend WithEvents FindRoomBtn As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RDCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents OpsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Floor2CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CarmelCommandButton As System.Windows.Forms.Button
    Friend WithEvents MendocinoCommandButton As System.Windows.Forms.Button
    Friend WithEvents NapaCommandButton As System.Windows.Forms.Button
    Friend WithEvents PinnaclesCommandButton As System.Windows.Forms.Button
    Friend WithEvents TahoeCommandButton As System.Windows.Forms.Button
    Friend WithEvents BigSurCommandButton As System.Windows.Forms.Button
    Friend WithEvents SantaCruzCommandButton As System.Windows.Forms.Button
    Friend WithEvents ShastaCommandButton As System.Windows.Forms.Button
    Friend WithEvents SquawValleyCommandButton As System.Windows.Forms.Button
    Friend WithEvents JoshuaTreeCommandButton As System.Windows.Forms.Button
    Friend WithEvents MontereyCommandButton As System.Windows.Forms.Button
    Friend WithEvents PismoBeachCommandButton As System.Windows.Forms.Button
    Friend WithEvents CarmelTxtBox As System.Windows.Forms.Label
    Friend WithEvents MendocinoTxtBox As System.Windows.Forms.Label
    Friend WithEvents NapaTxtBox As System.Windows.Forms.Label
    Friend WithEvents PinnaclesTxtBox As System.Windows.Forms.Label
    Friend WithEvents TahoeTxtBox As System.Windows.Forms.Label
    Friend WithEvents BigSurTxtBox As System.Windows.Forms.Label
    Friend WithEvents SantaCruzTxtBox As System.Windows.Forms.Label
    Friend WithEvents ShastaTxtBox As System.Windows.Forms.Label
    Friend WithEvents SquawValleyTxtBox As System.Windows.Forms.Label
    Friend WithEvents JoshuaTreeTxtBox As System.Windows.Forms.Label
    Friend WithEvents MontereyTxtBox As System.Windows.Forms.Label
    Friend WithEvents PismoBeachTxtBox As System.Windows.Forms.Label
    Friend WithEvents DRRoomCommandButton As System.Windows.Forms.Button
    Friend WithEvents DRRoomTxtBox As System.Windows.Forms.Label
    Friend WithEvents MeetingLengthComboBox As System.Windows.Forms.ComboBox
End Class
