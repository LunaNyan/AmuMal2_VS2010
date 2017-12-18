'와웅..와웅와웅와웅..와웅와웅..
'본 저작물은 저작권법의 보호를 받는 바, 원 저작자의 허가 없이 복제 및 전제를 금합니다.

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

        Console.WriteLine("아무말 v2.22")
        Console.WriteLine(" ")
        Console.WriteLine("Build by 루나냥, at 20170915. Twitter @ItsLunaNyan")
        Console.WriteLine("Repo : https://github.com/NewMoneL/AmuMal2_VS2010")
        Console.WriteLine(" ")
        Console.Title = "아무말"

        If System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory & "\amumal.txt") = False Then
            Console.WriteLine("이 프로그램은 타임라인 방식으로 메모를 기록하는 프로그램입니다.")
            Console.WriteLine("간단히 메모할 내용을 입력하고 Enter을 눌러 등록합니다.")
            Console.WriteLine(" ")
            Console.WriteLine("메모할 내용 대신 원하는 명령어를 입력하면 동작이 수행됩니다.")
            Console.WriteLine("명령어에 대한 자세한 내용이 필요하면 help를 입력하세요.")
            Console.WriteLine(" ")
        End If

        Do
            Dim txtxt As String
            Console.Write("입력:")
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
                        Console.WriteLine("데이터베이스가 없거나 아무 내용도 없습니다. 먼저 메모를 추가하세요.")
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
        Console.WriteLine("기록되었습니다.")
        Console.WriteLine(Format(Now, "yyyy-MM-dd hh:mm:ss") & ", 파일 용량 : " & infoReader.Length & " Bytes")
        Console.WriteLine(" ")

    End Sub

    Sub Help()
        Console.WriteLine("이 프로그램은 타임라인 방식으로 메모를 기록하는 프로그램입니다.")
        Console.WriteLine("간단히 메모할 내용을 입력하고 Enter을 눌러 등록합니다.")
        Console.WriteLine(" ")
        Console.WriteLine("메모할 내용 대신 원하는 명령어를 입력하면 동작이 수행됩니다.")
        Console.WriteLine("계속하려면 아무 키나 누르십시오.")
        Console.ReadKey()
        Console.WriteLine("명령어와 동작은 다음과 같습니다.")
        Console.WriteLine(" ")
        Console.WriteLine("lf       여러 줄로 메모를 작성합니다.")
        Console.WriteLine("cls      화면이 청소됩니다.")
        Console.WriteLine("open     데이터베이스 파일을 엽니다.")
        Console.WriteLine("type     데이터베이스 파일을 해당 콘솔에서 모두 출력합니다.")
        Console.WriteLine("copy     데이터베이스를 자동 백업합니다.")
        Console.WriteLine("del      데이터베이스를 백업하고 모두 청소합니다.")
        Console.WriteLine("exit     프로그램이 종료됩니다.")
        Console.WriteLine(" ")
        Console.WriteLine("자세한 정보는 해당 프로그램에 대한 GitHub 레포지토리")
        Console.WriteLine("(https://github.com/NewMoneL/AmuMal2)를 참조해주세요.")
        Console.WriteLine(" ")
    End Sub

    Sub lf()
        Dim txt2 As String
        Dim ExitMe As Boolean = False

        Console.WriteLine("여러 줄로 메모를 작성합니다. 끝내려면 end를 입력하세요.")

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
        Console.WriteLine("기록되었습니다.")
        Console.WriteLine(Format(Now, "yyyy-MM-dd hh:mm:ss") & ", 파일 용량 : " & infoReader.Length & " Bytes")
        Console.WriteLine(" ")

    End Sub

    Sub Copy()
        Dim FileToCopy As String = System.IO.Directory.GetCurrentDirectory & "\amumal.txt"
        Dim NewCopy As String = System.IO.Directory.GetCurrentDirectory & "\amumal_" & System.Guid.NewGuid.ToString & ".txt"

        If System.IO.File.Exists(FileToCopy) = True Then
            System.IO.File.Copy(FileToCopy, NewCopy)
            Console.WriteLine("백업되었습니다.")
            Console.WriteLine("파일 이름은 " & NewCopy & " 입니다.")
        Else
            Console.WriteLine("데이터베이스가 없거나 아무 내용도 없습니다. 먼저 메모를 추가하세요.")
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
            Console.WriteLine("데이터베이스가 없거나 아무 내용도 없습니다. 먼저 메모를 추가하세요.")
        End If

    End Sub

    Sub del()
        Copy()

        FileOpen(FileNum, FileName, OpenMode.Output)
        Print(FileNum, "")
        FileClose(FileNum)

        Console.WriteLine("청소되었습니다.")
    End Sub

End Module