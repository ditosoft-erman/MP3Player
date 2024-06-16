<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Dim ListViewItem1 As ListViewItem = New ListViewItem("")
        btnBrowse = New Button()
        music = New TextBox()
        fileName = New Label()
        btnUpload = New Button()
        btnPlay = New Button()
        AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        ListViewMusic = New ListView()
        Title = New ColumnHeader()
        CType(AxWindowsMediaPlayer1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnBrowse
        ' 
        btnBrowse.Location = New Point(321, 420)
        btnBrowse.Name = "btnBrowse"
        btnBrowse.Size = New Size(94, 29)
        btnBrowse.TabIndex = 0
        btnBrowse.Text = "Browse"
        btnBrowse.UseVisualStyleBackColor = True
        ' 
        ' music
        ' 
        music.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        music.Location = New Point(321, 350)
        music.Name = "music"
        music.ReadOnly = True
        music.Size = New Size(336, 51)
        music.TabIndex = 1
        ' 
        ' fileName
        ' 
        fileName.AutoSize = True
        fileName.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        fileName.Location = New Point(321, 319)
        fileName.Name = "fileName"
        fileName.Size = New Size(99, 28)
        fileName.TabIndex = 2
        fileName.Text = "File Name"
        ' 
        ' btnUpload
        ' 
        btnUpload.Location = New Point(421, 420)
        btnUpload.Name = "btnUpload"
        btnUpload.Size = New Size(94, 29)
        btnUpload.TabIndex = 3
        btnUpload.Text = "Upload"
        btnUpload.UseVisualStyleBackColor = True
        ' 
        ' btnPlay
        ' 
        btnPlay.Location = New Point(521, 420)
        btnPlay.Name = "btnPlay"
        btnPlay.Size = New Size(94, 29)
        btnPlay.TabIndex = 4
        btnPlay.Text = "Play"
        btnPlay.UseVisualStyleBackColor = True
        ' 
        ' AxWindowsMediaPlayer1
        ' 
        AxWindowsMediaPlayer1.Enabled = True
        AxWindowsMediaPlayer1.Location = New Point(321, 47)
        AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), AxHost.State)
        AxWindowsMediaPlayer1.Size = New Size(407, 238)
        AxWindowsMediaPlayer1.TabIndex = 6
        ' 
        ' ListViewMusic
        ' 
        ListViewMusic.AllowColumnReorder = True
        ListViewMusic.Columns.AddRange(New ColumnHeader() {Title})
        ListViewMusic.FullRowSelect = True
        ListViewMusic.Items.AddRange(New ListViewItem() {ListViewItem1})
        ListViewMusic.Location = New Point(27, 47)
        ListViewMusic.Name = "ListViewMusic"
        ListViewMusic.Size = New Size(246, 443)
        ListViewMusic.TabIndex = 7
        ListViewMusic.UseCompatibleStateImageBehavior = False
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(899, 548)
        Controls.Add(ListViewMusic)
        Controls.Add(AxWindowsMediaPlayer1)
        Controls.Add(btnPlay)
        Controls.Add(btnUpload)
        Controls.Add(fileName)
        Controls.Add(music)
        Controls.Add(btnBrowse)
        Name = "Dashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "dashboard"
        CType(AxWindowsMediaPlayer1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnBrowse As Button
    Friend WithEvents music As TextBox
    Friend WithEvents fileName As Label
    Friend WithEvents btnUpload As Button
    Friend WithEvents btnPlay As Button
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents LoadMusicList As ListView
    Public WithEvents ListViewMusic As ListView
    Friend WithEvents Title As ColumnHeader
End Class
