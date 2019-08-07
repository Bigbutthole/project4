Imports System.Reflection
Imports 反色模块
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim www As Graphics = Graphics.FromHdc(ApiClass.GetWindowDC(ApiClass.GetDesktopWindow))
        Dim scr As Screen = My.Computer.Screen
        Dim temp1 As New Bitmap(scr.WorkingArea.Width, scr.WorkingArea.Height)
        Dim ww As Graphics = Graphics.FromImage(temp1)
        ww.CopyFromScreen(New Point, New Point, scr.WorkingArea.Size)
        Dim handle As IntPtr = Class1.PContray(temp1).GetHicon
        www.DrawIcon(Icon.FromHandle(handle), scr.WorkingArea)
    End Sub
End Class
Public Module Module1
    Function Func1(sender As Object, args As ResolveEventArgs) As Assembly
        If New AssemblyName(args.Name).Name = "反色模块" Then
            Return Assembly.Load(My.Resources.反色模块)
        End If
    End Function
    Sub Main()
        Application.Run(New Form1)
    End Sub
    Sub New()
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf Func1
    End Sub
End Module