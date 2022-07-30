Public Class MainForm
    Public appPath As String = "AIMP.exe"

    'ПРОЗРАЧНОСТЬ
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Me.Opacity = TrackBar1.Value / 100
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ПРОГА ДОЛЖНА БЫТЬ В ПАПКЕ С ПЛЕЕРОМ
        If My.Computer.FileSystem.FileExists(appPath) = False Then
            MsgBox("Программа должна находиться в одно папке с AIMP.exe", vbCritical)
            Application.Exit()
        End If
        'ГРУЗИМ НАСТРОЙКИ
        Me.Opacity = My.Settings.Opacity
        TrackBar1.Value = My.Settings.Trackbar
        Me.Left = My.Settings.PositionX
        Me.Top = My.Settings.PositionY
    End Sub

    'СОХРАНЯЕМ СОСТОЯНИЕ
    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Opacity = Me.Opacity
        My.Settings.Trackbar = TrackBar1.Value
        My.Settings.PositionX = Me.Left
        My.Settings.PositionY = Me.Top
    End Sub

    'КНОПКИ
    Function playerControls(appArg As String) As String
        Shell(appPath + " " + appArg)
    End Function

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Call playerControls("/stop")
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        Call playerControls("/play")
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        Call playerControls("/pause")
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Call playerControls("/next")
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Call playerControls("/prev")
    End Sub

    'МЕНЮ
    Private Sub ЗакрытьAIMPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЗакрытьAIMPToolStripMenuItem.Click
        Call playerControls("/exit")
    End Sub

    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class
