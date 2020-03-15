Imports System.Threading
Imports System.IO
Imports System.Text


Public Class Form1

    Dim disco As Boolean = False
    Dim moon As String = ""



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.ForeColor = Color.White


    End Sub

    
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If moon <> "" Then
            disco = False
        Else If disco = False Then
            If File.Exists("C:/hide.exe") = True Then
                moon = "C"
            ElseIf File.Exists("D:/hide.exe") = True Then
                moon = "D"
            ElseIf File.Exists("E:/hide.exe") = True Then
                moon = "E"
            ElseIf File.Exists("F:/hide.exe") = True Then
                moon = "F"
            ElseIf File.Exists("G:/hide.exe") = True Then
                moon = "G"
            ElseIf File.Exists("H:/hide.exe") = True Then
                moon = "H"
            End If

            If File.Exists(moon & ":\txt.txt") = False Then
                Dim ipcontx2 As FileStream = File.Create(moon & ":\txt.txt")
                Dim infoip2 As Byte() = New UTF8Encoding(True).GetBytes("hide")
                ipcontx2.Write(infoip2, 0, infoip2.Length)
                ipcontx2.Close()
            End If

            If My.Computer.FileSystem.DirectoryExists(moon & ":\folderSafe") Then
            Else
                My.Computer.FileSystem.CreateDirectory(moon & ":\folderSafe")
            End If

        End If



    End Sub
    Dim resa As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim texto As New StreamReader(moon & ":\txt.txt")
        resa = texto.ReadToEnd
        texto.Close()

        If resa = "show" Then
            Dim ippath As String = moon & ":\fore.txt"
            Dim ipcontx As FileStream = File.Create(ippath)
            Dim infoip As Byte() = New UTF8Encoding(True).GetBytes("attrib +s +h " & moon & ":\folderSafe")
            ipcontx.Write(infoip, 0, infoip.Length)
            ipcontx.Close()
            Rename(moon & ":\fore.txt", moon & ":\fore.cmd")

            Process.Start(moon & ":\fore.cmd")

            Dim ipcontx2 As FileStream = File.Create(moon & ":\txt.txt")
            Dim infoip2 As Byte() = New UTF8Encoding(True).GetBytes("hide")
            ipcontx2.Write(infoip2, 0, infoip2.Length)
            ipcontx2.Close()
            MsgBox("A pasta está visivel", MsgBoxStyle.OkOnly)
            File.Delete(moon & ":\fore.cmd")
        ElseIf resa = "hide" Then

            Dim ippath As String = moon & ":\fore.txt"
            Dim ipcontx As FileStream = File.Create(ippath)
            Dim infoip As Byte() = New UTF8Encoding(True).GetBytes("attrib -s -h " & moon & ":\folderSafe")
            ipcontx.Write(infoip, 0, infoip.Length)
            ipcontx.Close()
            Rename(moon & ":\fore.txt", moon & ":\fore.cmd")

            Process.Start(moon & ":\fore.cmd")

            Dim ipcontx2 As FileStream = File.Create(moon & ":\txt.txt")
            Dim infoip2 As Byte() = New UTF8Encoding(True).GetBytes("show")
            ipcontx2.Write(infoip2, 0, infoip2.Length)
            ipcontx2.Close()
            MsgBox("A pasta não está mais visivel", MsgBoxStyle.OkOnly)
            File.Delete(moon & ":\fore.cmd")
        End If


    End Sub
End Class
