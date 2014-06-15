Imports System.IO

Module Module1

    Sub Main()
        Console.WriteLine("..== For testing purpose only, made by T.O.Neves. thanks to Sergio Pastore ==..")
        Console.WriteLine("Software made for specific needs, maybe not useful for everyone. Use with care.")
        Console.WriteLine("Lisenced under GPL 3.0 - search on GitHub for the source code.")
        Console.WriteLine("send any bugs or opinions to thiagoneves@live.com")
        Console.WriteLine()

        'Variables 
        Dim _args() As String = Environment.GetCommandLineArgs
        Dim _yes4all As Boolean = CBool(VariantType.Boolean)
        Dim _dir2 As Boolean = CBool(VariantType.Boolean)
        Dim _info As Boolean = CBool(VariantType.Boolean)
        Dim _help As Boolean = CBool(VariantType.Boolean)
        Dim _pro_only As Boolean = CBool(VariantType.Boolean)
        Dim _pro_plus As Boolean = CBool(VariantType.Boolean)
        Dim tempath As String = System.IO.Path.GetTempPath
        Dim filelist = System.IO.Directory.EnumerateFiles(tempath)
        Dim filecount As Integer = 0
        Dim filesize As FileInfo
        Dim totalsize As Integer = 0
        Dim totalsize_ok As String = "Error Getting files size."
        Dim dirlist = System.IO.Directory.EnumerateDirectories(tempath)
        Dim dircount As Integer = 0
        Dim FO As FileStream
        Dim _continue As String = CStr(VariantType.String)
        Dim _count As Integer

        filelist = GetFilesRecursive(tempath)


        If _args.Count() > 0 Then
            If _args(_count) = "-y" Then
                _yes4all = True
                Console.WriteLine(" Argument -y used for Yes on all questions.")
            End If
            If _args(_count) = "-d" Then
                _dir2 = True
                Console.WriteLine(" Argument -d used for Folder deletion too.")
            End If
            If _args(_count) = "-i" Then
                _info = True
                Console.WriteLine(" Argument -i used for information only.")
            End If
            If _args(_count) = "-h" Then
                _help = True
                Console.WriteLine(" Argument -h used for Help.")
            End If
            If _args(_count) = "-p" Then
                _pro_only = True
                Console.WriteLine(" Argument -p used for Pro-Tools temporary deletion only.")
            End If
            If _args(_count) = "-p" Then
                _pro_only = True
                Console.WriteLine(" Argument -p used for Pro-Tools temporary deletion only.")
            End If
        End If

        If _help = True Then
            Console.WriteLine()
            Console.WriteLine(" Usage: <k-temp-cleaner.exe> -<arg1> -<arg2> -<arg3>")
            Console.WriteLine()
            Console.WriteLine(" -y = Yes for all questions.")
            Console.WriteLine()
            Console.WriteLine(" -d = Delete folders too.")
            Console.WriteLine()
            Console.WriteLine(" -i = Information only.")
            Console.WriteLine()
            Console.WriteLine(" Press any key to Exit.")
            Console.Read()
            Environment.[Exit](0)
        End If



        Console.WriteLine(" The default Temporary folder will be cleaned right now.")
        Console.WriteLine(tempath)

        If _yes4all = False Then
            Console.WriteLine(" You want to continue? yes/no")

            Do Until _continue = "yes"
                _continue = Console.ReadLine()
                If _continue = "yes" Then
                    Console.WriteLine(" Starting the cleanup.")
                ElseIf _continue = "no" Then
                    Console.WriteLine(" Stoping right now.")
                    Environment.Exit(0)
                Else
                    Console.WriteLine(" you need to type yes or no")
                End If
            Loop
        Else
            Console.WriteLine(" Starting the cleanup.")
        End If

        If _dir2 = True Then
            Try
                For Each _dirs In dirlist
                    Directory.Delete(_dirs)

                Next
            Catch ex As Exception

            End Try
        End If

        Try
            For Each _dir In dirlist
                dircount = dircount + 1
            Next
            Console.WriteLine(" " & dircount & " Directories in temporary folder")
        Catch ex As Exception
            Console.WriteLine(" Error gathering the list of directories.")
        End Try


        Try
            For Each temps In filelist
                filesize = My.Computer.FileSystem.GetFileInfo(temps)
                filecount = filecount + 1
                totalsize = CInt(totalsize + filesize.Length)
                Dim finalsize = CDec((totalsize / 1024) / 1024)
                totalsize_ok = finalsize.ToString("###,###,###") & " MBs"
            Next
            Console.WriteLine(" " & filecount & " files.")
            Console.WriteLine(" " & totalsize_ok)
            Console.Read()
        Catch ex As Exception
            Console.WriteLine(" error acessing temp files.")
        End Try

        Try
            For Each temps In filelist
                Try
                    FO = System.IO.File.Open(temps, FileMode.Open, FileAccess.Read, FileShare.None)
                    FO.Close()
                    File.Delete(temps)
                    Console.WriteLine(temps & " Deleted.")
                Catch ex As Exception
                    Console.WriteLine(" error deleting file - Probably in use. " & vbCrLf & temps)
                    Console.Read()
                End Try

            Next
        Catch ex As Exception
            Console.WriteLine(" error acessing temp files.")
            Console.Read()
        End Try

    End Sub

    Public Function GetFilesRecursive(ByVal initial As String) As List(Of String)
        ' This list stores the results.
        Dim result As New List(Of String)

        ' This stack stores the directories to process.
        Dim stack As New Stack(Of String)

        ' Add the initial directory
        stack.Push(initial)

        ' Continue processing for each stacked directory
        Do While (stack.Count > 0)
            ' Get top directory string
            Dim dir As String = stack.Pop
            Try
                ' Add all immediate file paths
                result.AddRange(Directory.GetFiles(dir, "*.*"))

                ' Loop through all subdirectories and add them to the stack.
                Dim directoryName As String
                For Each directoryName In Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

            Catch ex As Exception
                Console.WriteLine(" Error scanning file system.")
            End Try
        Loop

        ' Return the list
        Return result
    End Function

End Module


Imports System.Collections.Generic
Imports System.IO
Imports System.Linq

Namespace K_Temp_Cleaner
    <StandardModule> _
    Friend NotInheritable Class Module1
        <STAThread> _
        Public Shared Sub Main()
            Console.WriteLine("..== For testing purpose only, made by T.O.Neves. thanks to Sergio Pastore ==..")
            Console.WriteLine("Software made for specific needs, maybe not useful for everyone. Use with care.")
            Console.WriteLine("Lisenced under GPL 3.0 - search on GitHub for the source code.")
            Console.WriteLine("send any bugs or opinions to thiagoneves@live.com")
            Dim commandLineArgs As String() = Environment.GetCommandLineArgs()
            Dim flag1 As Boolean = False
            Dim flag2 As Boolean = False
            Dim flag3 As Boolean = False
            Dim flag4 As Boolean = False
            Dim tempPath As String = Path.GetTempPath()
            Directory.EnumerateFiles(tempPath)
            Dim enumerable1 As IEnumerable(Of String) = Directory.EnumerateDirectories(tempPath)
            Dim num1 As Integer = 0
            Dim num2 As Integer = 0
            Dim str As String = "Error Getting files size."
            Dim num3 As Integer = 0
            Dim Left1 As String = Conversions.ToString(8)
            Dim enumerable2 As IEnumerable(Of String) = DirectCast(Module1.GetFilesRecursive(tempPath), IEnumerable(Of String))
            If Enumerable.Count(Of String)(DirectCast(commandLineArgs, IEnumerable(Of String))) > 0 Then
                Dim strArray As String() = commandLineArgs
                Dim index As Integer = 0
                While index < strArray.Length
                    Dim Left2 As String = strArray(index)
                    If Operators.CompareString(Left2, "-y", False) = 0 Then
                        flag1 = True
                    End If
                    If Operators.CompareString(Left2, "-d", False) = 0 Then
                        flag3 = True
                    End If
                    If Operators.CompareString(Left2, "-l", False) = 0 Then
                        flag2 = True
                    End If
                    If Operators.CompareString(Left2, "-h", False) = 0 Then
                        flag4 = True
                    End If
                    index += 1

                End While
            End If
            If flag4 Then
                Console.WriteLine()
                Console.WriteLine(" usage: <k-temp-cleaner.exe> -<arg1> -<arg2> -<arg3>")
                Console.WriteLine()
                Console.WriteLine(" -y = Yes for all questions.")
                Console.WriteLine()
                Console.WriteLine(" -d = Delete folders too.")
                Console.WriteLine()
                Console.WriteLine(" -l = list only - non deletion mode.")
                Console.WriteLine()
                Console.WriteLine(" Press any key to Exit.")
                Console.Read()
                Environment.[Exit](0)
            End If
            Console.WriteLine()
            Console.WriteLine(" The default Temporary folder will be cleaned right now.")
            Console.WriteLine()
            Console.WriteLine(tempPath)
            Console.WriteLine()
            Try
                Dim enumerator As IEnumerator(Of String)
                Try
                    enumerator = enumerable1.GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As String = enumerator.Current
                        num3 += 1

                    End While
                Finally
                    If enumerator IsNot Nothing Then
                        enumerator.Dispose()
                    End If
                End Try
                Console.WriteLine(" " & Conversions.ToString(num3) & " folders.")
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Console.WriteLine(" Error gathering the list of directories.")
                ProjectData.ClearProjectError()
            End Try
            Try
                Dim enumerator As IEnumerator(Of String)
                Try
                    enumerator = enumerable2.GetEnumerator()
                    While enumerator.MoveNext()
                        Dim fileInfo As FileInfo = MyProject.Computer.FileSystem.GetFileInfo(enumerator.Current)
                        num1 += 1

                        num2 = CInt(CLng(num2) + fileInfo.Length)
                        str = New [Decimal](CDbl(num2) / 1024.0).ToString("###,###,###") & " KB`s."
                    End While
                Finally
                    If enumerator IsNot Nothing Then
                        enumerator.Dispose()
                    End If
                End Try
                Console.WriteLine(" " & Conversions.ToString(num1) & " files.")
                Console.WriteLine(" " & str)
                If Not flag1 Then
                    Console.WriteLine(" Press any key to continue.")
                    Console.Read()
                End If
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Console.WriteLine(" error acessing temp files.")
                ProjectData.ClearProjectError()
            End Try
            If Not flag1 Then
                If flag2 Then
                    Console.WriteLine(" No files will be deleted on list mode.")
                ElseIf Not flag2 Then
                    Console.WriteLine(" Temporary folder will be Wiped out.")
                    Console.WriteLine("    You want to continue? yes/no")
                    While Operators.CompareString(Left1, "yes", False) <> 0
                        Left1 = Console.ReadLine()
                        If Operators.CompareString(Left1, "yes", False) = 0 Then
                            Console.WriteLine(" Starting the cleanup.")
                        ElseIf Operators.CompareString(Left1, "no", False) = 0 Then
                            Console.WriteLine(" Stoping right now.")
                            Environment.[Exit](0)
                        ElseIf Operators.CompareString(Left1, "", False) <> 0 Then
                            Console.WriteLine(" You need to type yes or no !")
                        End If
                    End While
                End If
            ElseIf flag1 Then
                Console.WriteLine(" !Yes for all mode!")
            End If
            Try
                If Not flag2 Then
                    Dim enumerator As IEnumerator(Of String)
                    Try
                        enumerator = enumerable2.GetEnumerator()
                        While enumerator.MoveNext()
                            Dim current As String = enumerator.Current
                            Try
                                File.Open(current, FileMode.Open, FileAccess.Read, FileShare.None).Close()
                                File.Delete(current)
                                Console.WriteLine(current & " Deleted.")
                            Catch ex As Exception
                                ProjectData.SetProjectError(ex)
                                Console.WriteLine(" error deleting file - Probably in use. " & vbCr & vbLf & current)
                                ProjectData.ClearProjectError()
                            End Try
                        End While
                    Finally
                        If enumerator IsNot Nothing Then
                            enumerator.Dispose()
                        End If
                    End Try
                    If Not flag1 Then
                        Console.WriteLine(" Press any key to continue.")
                        Console.Read()
                    End If
                Else
                    Dim num4 As Integer = If(flag2, 1, 0)
                End If
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Console.WriteLine(" error acessing temp files.")
                If Not flag1 Then
                    Console.WriteLine(" Press any key to continue.")
                    Console.Read()
                End If
                ProjectData.ClearProjectError()
            End Try
            Dim enumerator1 As IEnumerator(Of String)
            If flag3 Then
                Try
                    enumerator1 = enumerable1.GetEnumerator()
                    While enumerator1.MoveNext()
                        Dim current As String = enumerator1.Current
                        Try
                            Console.WriteLine(current & " folder deleted.")
                            Directory.Delete(current)
                        Catch ex As Exception
                            ProjectData.SetProjectError(ex)
                            Console.WriteLine(current & " in use or not empty.")
                            ProjectData.ClearProjectError()
                        End Try
                    End While
                Finally
                    If enumerator1 IsNot Nothing Then
                        enumerator1.Dispose()
                    End If
                End Try
            ElseIf Not flag3 Then
                Console.WriteLine(" Directories will not be deleted, use -d argument for that.")
            End If
            If flag1 Then
                Return
            End If
            Console.WriteLine(" Press any key to continue.")
            Console.Read()
        End Sub

        Public Shared Function GetFilesRecursive(initial As String) As List(Of String)
            Dim list As New List(Of String)()
            Dim stack As New Stack(Of String)()
            stack.Push(initial)
            While stack.Count > 0
                Dim path As String = stack.Pop()
                Try
                    list.AddRange(DirectCast(Directory.GetFiles(path, "*.*"), IEnumerable(Of String)))
                    Dim directories As String() = Directory.GetDirectories(path)
                    Dim index As Integer = 0
                    While index < directories.Length
                        Dim str As String = directories(index)
                        stack.Push(str)
                        index += 1

                    End While
                Catch ex As Exception
                    ProjectData.SetProjectError(ex)
                    Console.WriteLine(" Error scanning file system.")
                    ProjectData.ClearProjectError()
                End Try
            End While
            Return list
        End Function
    End Class
End Namespace