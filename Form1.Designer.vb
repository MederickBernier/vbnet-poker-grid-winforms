<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Panel1 = New Panel()
        btnCheckHand = New Button()
        btnContinue = New Button()
        chkHand5 = New CheckBox()
        chkHand4 = New CheckBox()
        chkHand3 = New CheckBox()
        chkHand2 = New CheckBox()
        chkHand1 = New CheckBox()
        pbHand5 = New PictureBox()
        pbHand4 = New PictureBox()
        pbHand3 = New PictureBox()
        pbHand2 = New PictureBox()
        pbHand1 = New PictureBox()
        pnlControls = New Panel()
        lblWinnings = New Label()
        Label3 = New Label()
        btnExit = New Button()
        btnPlay = New Button()
        numBid = New NumericUpDown()
        numCredits = New NumericUpDown()
        Label2 = New Label()
        Label1 = New Label()
        resultTimer = New Timer(components)
        Panel1.SuspendLayout()
        CType(pbHand5, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbHand4, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbHand3, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbHand2, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbHand1, ComponentModel.ISupportInitialize).BeginInit()
        pnlControls.SuspendLayout()
        CType(numBid, ComponentModel.ISupportInitialize).BeginInit()
        CType(numCredits, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(btnCheckHand)
        Panel1.Controls.Add(btnContinue)
        Panel1.Controls.Add(chkHand5)
        Panel1.Controls.Add(chkHand4)
        Panel1.Controls.Add(chkHand3)
        Panel1.Controls.Add(chkHand2)
        Panel1.Controls.Add(chkHand1)
        Panel1.Controls.Add(pbHand5)
        Panel1.Controls.Add(pbHand4)
        Panel1.Controls.Add(pbHand3)
        Panel1.Controls.Add(pbHand2)
        Panel1.Controls.Add(pbHand1)
        Panel1.Location = New Point(12, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1024, 415)
        Panel1.TabIndex = 0
        ' 
        ' btnCheckHand
        ' 
        btnCheckHand.Enabled = False
        btnCheckHand.Location = New Point(413, 300)
        btnCheckHand.Name = "btnCheckHand"
        btnCheckHand.Size = New Size(190, 99)
        btnCheckHand.TabIndex = 11
        btnCheckHand.Text = "Finaliser la partie"
        btnCheckHand.UseVisualStyleBackColor = True
        btnCheckHand.Visible = False
        ' 
        ' btnContinue
        ' 
        btnContinue.Location = New Point(413, 300)
        btnContinue.Name = "btnContinue"
        btnContinue.Size = New Size(190, 99)
        btnContinue.TabIndex = 10
        btnContinue.Text = "Continuer"
        btnContinue.UseVisualStyleBackColor = True
        ' 
        ' chkHand5
        ' 
        chkHand5.AutoSize = True
        chkHand5.Location = New Point(852, 252)
        chkHand5.Name = "chkHand5"
        chkHand5.Size = New Size(76, 24)
        chkHand5.TabIndex = 9
        chkHand5.Text = "Garder"
        chkHand5.UseVisualStyleBackColor = True
        ' 
        ' chkHand4
        ' 
        chkHand4.AutoSize = True
        chkHand4.Location = New Point(650, 252)
        chkHand4.Name = "chkHand4"
        chkHand4.Size = New Size(76, 24)
        chkHand4.TabIndex = 8
        chkHand4.Text = "Garder"
        chkHand4.UseVisualStyleBackColor = True
        ' 
        ' chkHand3
        ' 
        chkHand3.AutoSize = True
        chkHand3.Location = New Point(454, 252)
        chkHand3.Name = "chkHand3"
        chkHand3.Size = New Size(76, 24)
        chkHand3.TabIndex = 7
        chkHand3.Text = "Garder"
        chkHand3.UseVisualStyleBackColor = True
        ' 
        ' chkHand2
        ' 
        chkHand2.AutoSize = True
        chkHand2.Location = New Point(244, 252)
        chkHand2.Name = "chkHand2"
        chkHand2.Size = New Size(76, 24)
        chkHand2.TabIndex = 6
        chkHand2.Text = "Garder"
        chkHand2.UseVisualStyleBackColor = True
        ' 
        ' chkHand1
        ' 
        chkHand1.AutoSize = True
        chkHand1.Location = New Point(32, 252)
        chkHand1.Name = "chkHand1"
        chkHand1.Size = New Size(76, 24)
        chkHand1.TabIndex = 5
        chkHand1.Text = "Garder"
        chkHand1.UseVisualStyleBackColor = True
        ' 
        ' pbHand5
        ' 
        pbHand5.BackgroundImageLayout = ImageLayout.None
        pbHand5.Location = New Point(815, 3)
        pbHand5.Name = "pbHand5"
        pbHand5.Size = New Size(190, 243)
        pbHand5.SizeMode = PictureBoxSizeMode.Zoom
        pbHand5.TabIndex = 4
        pbHand5.TabStop = False
        ' 
        ' pbHand4
        ' 
        pbHand4.BackgroundImageLayout = ImageLayout.None
        pbHand4.Location = New Point(609, 3)
        pbHand4.Name = "pbHand4"
        pbHand4.Size = New Size(190, 243)
        pbHand4.SizeMode = PictureBoxSizeMode.Zoom
        pbHand4.TabIndex = 3
        pbHand4.TabStop = False
        ' 
        ' pbHand3
        ' 
        pbHand3.BackgroundImageLayout = ImageLayout.None
        pbHand3.Location = New Point(413, 3)
        pbHand3.Name = "pbHand3"
        pbHand3.Size = New Size(190, 243)
        pbHand3.SizeMode = PictureBoxSizeMode.Zoom
        pbHand3.TabIndex = 2
        pbHand3.TabStop = False
        ' 
        ' pbHand2
        ' 
        pbHand2.BackgroundImageLayout = ImageLayout.None
        pbHand2.Location = New Point(217, 3)
        pbHand2.Name = "pbHand2"
        pbHand2.Size = New Size(190, 243)
        pbHand2.SizeMode = PictureBoxSizeMode.Zoom
        pbHand2.TabIndex = 1
        pbHand2.TabStop = False
        ' 
        ' pbHand1
        ' 
        pbHand1.BackgroundImageLayout = ImageLayout.None
        pbHand1.Location = New Point(3, 3)
        pbHand1.Name = "pbHand1"
        pbHand1.Size = New Size(190, 243)
        pbHand1.SizeMode = PictureBoxSizeMode.Zoom
        pbHand1.TabIndex = 0
        pbHand1.TabStop = False
        ' 
        ' pnlControls
        ' 
        pnlControls.Controls.Add(lblWinnings)
        pnlControls.Controls.Add(Label3)
        pnlControls.Controls.Add(btnExit)
        pnlControls.Controls.Add(btnPlay)
        pnlControls.Controls.Add(numBid)
        pnlControls.Controls.Add(numCredits)
        pnlControls.Controls.Add(Label2)
        pnlControls.Controls.Add(Label1)
        pnlControls.Location = New Point(1042, 12)
        pnlControls.Name = "pnlControls"
        pnlControls.Size = New Size(263, 415)
        pnlControls.TabIndex = 1
        ' 
        ' lblWinnings
        ' 
        lblWinnings.AutoSize = True
        lblWinnings.Location = New Point(73, 226)
        lblWinnings.Name = "lblWinnings"
        lblWinnings.Size = New Size(68, 20)
        lblWinnings.TabIndex = 14
        lblWinnings.Text = "PH Gains"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(15, 226)
        Label3.Name = "Label3"
        Label3.Size = New Size(52, 20)
        Label3.TabIndex = 13
        Label3.Text = "Gains: "
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(139, 130)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(118, 66)
        btnExit.TabIndex = 12
        btnExit.Text = "Quitter"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' btnPlay
        ' 
        btnPlay.Location = New Point(15, 130)
        btnPlay.Name = "btnPlay"
        btnPlay.Size = New Size(118, 66)
        btnPlay.TabIndex = 11
        btnPlay.Text = "Jouer"
        btnPlay.UseVisualStyleBackColor = True
        ' 
        ' numBid
        ' 
        numBid.Location = New Point(83, 64)
        numBid.Name = "numBid"
        numBid.Size = New Size(174, 27)
        numBid.TabIndex = 4
        numBid.TextAlign = HorizontalAlignment.Center
        ' 
        ' numCredits
        ' 
        numCredits.Location = New Point(83, 10)
        numCredits.Name = "numCredits"
        numCredits.Size = New Size(174, 27)
        numCredits.TabIndex = 3
        numCredits.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(15, 71)
        Label2.Name = "Label2"
        Label2.Size = New Size(47, 20)
        Label2.TabIndex = 2
        Label2.Text = "Mise: "
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(15, 17)
        Label1.Name = "Label1"
        Label1.Size = New Size(62, 20)
        Label1.TabIndex = 1
        Label1.Text = "Crédits: "
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1312, 438)
        Controls.Add(pnlControls)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Poker"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(pbHand5, ComponentModel.ISupportInitialize).EndInit()
        CType(pbHand4, ComponentModel.ISupportInitialize).EndInit()
        CType(pbHand3, ComponentModel.ISupportInitialize).EndInit()
        CType(pbHand2, ComponentModel.ISupportInitialize).EndInit()
        CType(pbHand1, ComponentModel.ISupportInitialize).EndInit()
        pnlControls.ResumeLayout(False)
        pnlControls.PerformLayout()
        CType(numBid, ComponentModel.ISupportInitialize).EndInit()
        CType(numCredits, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pbHand5 As PictureBox
    Friend WithEvents pbHand4 As PictureBox
    Friend WithEvents pbHand3 As PictureBox
    Friend WithEvents pbHand2 As PictureBox
    Friend WithEvents pbHand1 As PictureBox
    Friend WithEvents chkHand1 As CheckBox
    Friend WithEvents chkHand2 As CheckBox
    Friend WithEvents chkHand4 As CheckBox
    Friend WithEvents chkHand3 As CheckBox
    Friend WithEvents chkHand5 As CheckBox
    Friend WithEvents btnContinue As Button
    Friend WithEvents pnlControls As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents numCredits As NumericUpDown
    Friend WithEvents numBid As NumericUpDown
    Friend WithEvents btnPlay As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lblWinnings As Label
    Friend WithEvents btnCheckHand As Button
    Friend WithEvents resultTimer As Timer

End Class
