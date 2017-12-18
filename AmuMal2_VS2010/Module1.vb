'�Ϳ�..�Ϳ��Ϳ��Ϳ�..�Ϳ��Ϳ�..
'�� ���۹��� ���۱ǹ��� ��ȣ�� �޴� ��, �� �������� �㰡 ���� ���� �� ������ ���մϴ�.

Imports System
Imports System.IO
Imports System.Collections

Module Module1


    Dim FileNum As Integer = FreeFile()
    Dim FileName As String = System.IO.Directory.GetCurrentDirectory & "\amumal.txt"

    Sub Main()
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.White
        Console.Clear()

        Console.WriteLine("�ƹ��� v2.22")
        Console.WriteLine(" ")
        Console.WriteLine("Build by �糪��, at 20170915. Twitter @ItsLunaNyan")
        Console.WriteLine("Repo : https://github.com/NewMoneL/AmuMal2_VS2010")
        Console.WriteLine(" ")
        Console.Title = "�ƹ���"

        If System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory & "\amumal.txt") = False Then
            Console.WriteLine("�� ���α׷��� Ÿ�Ӷ��� ������� �޸� ����ϴ� ���α׷��Դϴ�.")
            Console.WriteLine("������ �޸��� ������ �Է��ϰ� Enter�� ���� ����մϴ�.")
            Console.WriteLine(" ")
            Console.WriteLine("�޸��� ���� ��� ���ϴ� ��ɾ �Է��ϸ� ������ ����˴ϴ�.")
            Console.WriteLine("��ɾ ���� �ڼ��� ������ �ʿ��ϸ� help�� �Է��ϼ���.")
            Console.WriteLine(" ")
        End If

        Do
            Dim txtxt As String
            Console.Write("�Է�:")
            txtxt = Console.ReadLine()
            Select Case txtxt
                Case "help"
                    Help()

                Case "lf"
                    lf()

                Case "cls"
                    Console.Clear()

                Case "open"
                    If System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory & "\amumal.txt") = True Then
                        Process.Start(System.IO.Directory.GetCurrentDirectory & "\amumal.txt")
                    Else
                        Console.WriteLine("�����ͺ��̽��� ���ų� �ƹ� ���뵵 �����ϴ�. ���� �޸� �߰��ϼ���.")
                    End If

                Case "copy"
                    Copy()

                Case "type"
                    type()

                Case "del"
                    del()

                Case "exit"
                    End

                Case Else
                    Write(txtxt)
            End Select
        Loop

    End Sub

    Sub Write(ByVal txt As String)

        FileOpen(FileNum, FileName, OpenMode.Append)
        Print(FileNum, vbCrLf & txt)
        Print(FileNum, vbCrLf & Format(Now, "yyyy-MM-dd hh:mm:ss"))
        Print(FileNum, vbCrLf & "----------")
        FileClose(FileNum)

        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo(FileName)

        Console.WriteLine(" ")
        Console.WriteLine("��ϵǾ����ϴ�.")
        Console.WriteLine(Format(Now, "yyyy-MM-dd hh:mm:ss") & ", ���� �뷮 : " & infoReader.Length & " Bytes")
        Console.WriteLine(" ")

    End Sub

    Sub Help()
        Console.WriteLine("�� ���α׷��� Ÿ�Ӷ��� ������� �޸� ����ϴ� ���α׷��Դϴ�.")
        Console.WriteLine("������ �޸��� ������ �Է��ϰ� Enter�� ���� ����մϴ�.")
        Console.WriteLine(" ")
        Console.WriteLine("�޸��� ���� ��� ���ϴ� ��ɾ �Է��ϸ� ������ ����˴ϴ�.")
        Console.WriteLine("����Ϸ��� �ƹ� Ű�� �����ʽÿ�.")
        Console.ReadKey()
        Console.WriteLine("��ɾ�� ������ ������ �����ϴ�.")
        Console.WriteLine(" ")
        Console.WriteLine("lf       ���� �ٷ� �޸� �ۼ��մϴ�.")
        Console.WriteLine("cls      ȭ���� û�ҵ˴ϴ�.")
        Console.WriteLine("open     �����ͺ��̽� ������ ���ϴ�.")
        Console.WriteLine("type     �����ͺ��̽� ������ �ش� �ֿܼ��� ��� ����մϴ�.")
        Console.WriteLine("copy     �����ͺ��̽��� �ڵ� ����մϴ�.")
        Console.WriteLine("del      �����ͺ��̽��� ����ϰ� ��� û���մϴ�.")
        Console.WriteLine("exit     ���α׷��� ����˴ϴ�.")
        Console.WriteLine(" ")
        Console.WriteLine("�ڼ��� ������ �ش� ���α׷��� ���� GitHub �������丮")
        Console.WriteLine("(https://github.com/NewMoneL/AmuMal2)�� �������ּ���.")
        Console.WriteLine(" ")
    End Sub

    Sub lf()
        Dim txt2 As String
        Dim ExitMe As Boolean = False

        Console.WriteLine("���� �ٷ� �޸� �ۼ��մϴ�. �������� end�� �Է��ϼ���.")

        Do While ExitMe = False
            txt2 = Console.ReadLine()
            If txt2 = "end" Then
                ExitMe = True
            Else
                FileOpen(FileNum, FileName, OpenMode.Append)
                Print(FileNum, vbCrLf & txt2)
                FileClose(FileNum)
            End If
        Loop

        FileOpen(FileNum, FileName, OpenMode.Append)
        Print(FileNum, vbCrLf & Format(Now, "yyyy-MM-dd hh:mm:ss"))
        Print(FileNum, vbCrLf & "----------")
        FileClose(FileNum)

        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo(FileName)

        Console.WriteLine(" ")
        Console.WriteLine("��ϵǾ����ϴ�.")
        Console.WriteLine(Format(Now, "yyyy-MM-dd hh:mm:ss") & ", ���� �뷮 : " & infoReader.Length & " Bytes")
        Console.WriteLine(" ")

    End Sub

    Sub Copy()
        Dim FileToCopy As String = System.IO.Directory.GetCurrentDirectory & "\amumal.txt"
        Dim NewCopy As String = System.IO.Directory.GetCurrentDirectory & "\amumal_" & System.Guid.NewGuid.ToString & ".txt"

        If System.IO.File.Exists(FileToCopy) = True Then
            System.IO.File.Copy(FileToCopy, NewCopy)
            Console.WriteLine("����Ǿ����ϴ�.")
            Console.WriteLine("���� �̸��� " & NewCopy & " �Դϴ�.")
        Else
            Console.WriteLine("�����ͺ��̽��� ���ų� �ƹ� ���뵵 �����ϴ�. ���� �޸� �߰��ϼ���.")
        End If
    End Sub

    Sub type()
        Dim txtLine2 As String

        If System.IO.File.Exists(FileName) = True Then
            FileOpen(FileNum, FileName, OpenMode.Input)
            Do While Not EOF(FileNum)
                Input(FileNum, txtLine2)
                Console.WriteLine(txtLine2)
            Loop
            FileClose(FileNum)
        Else
            Console.WriteLine("�����ͺ��̽��� ���ų� �ƹ� ���뵵 �����ϴ�. ���� �޸� �߰��ϼ���.")
        End If

    End Sub

    Sub del()
        Copy()

        FileOpen(FileNum, FileName, OpenMode.Output)
        Print(FileNum, "")
        FileClose(FileNum)

        Console.WriteLine("û�ҵǾ����ϴ�.")
    End Sub

End Module