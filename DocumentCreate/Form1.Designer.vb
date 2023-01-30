<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConnectionString = New System.Windows.Forms.TextBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnCreateDocument = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Connection String:"
        '
        'txtConnectionString
        '
        Me.txtConnectionString.Location = New System.Drawing.Point(191, 40)
        Me.txtConnectionString.Name = "txtConnectionString"
        Me.txtConnectionString.Size = New System.Drawing.Size(325, 26)
        Me.txtConnectionString.TabIndex = 1
        Me.txtConnectionString.Text = "amqp://guest:guest@localhost:5672"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(553, 30)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(91, 35)
        Me.btnConnect.TabIndex = 2
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnCreateDocument
        '
        Me.btnCreateDocument.Location = New System.Drawing.Point(261, 210)
        Me.btnCreateDocument.Name = "btnCreateDocument"
        Me.btnCreateDocument.Size = New System.Drawing.Size(304, 121)
        Me.btnCreateDocument.TabIndex = 3
        Me.btnCreateDocument.Text = "Create Document"
        Me.btnCreateDocument.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.SystemColors.InfoText
        Me.txtLog.ForeColor = System.Drawing.Color.Lime
        Me.txtLog.Location = New System.Drawing.Point(-1, 365)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(877, 193)
        Me.txtLog.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 563)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.btnCreateDocument)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtConnectionString)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtConnectionString As TextBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnCreateDocument As Button
    Friend WithEvents txtLog As TextBox
End Class
