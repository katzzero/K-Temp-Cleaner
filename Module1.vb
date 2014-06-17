Imports System.IO

Module Module1

    Sub Main()
        Console.WriteLine("..== For testing purpose only, by T.O.Neves. thanks to Sergio Pastore ==..")
        Console.WriteLine("Software made for specific needs, maybe not useful for everyone. Use with care.")
        Console.WriteLine("Lisenced under GPL 3.0 - search on GitHub for the source code.")
        Console.WriteLine("Please, send any bugs or opinions to thiagoneves@live.com")
        Console.WriteLine()

        'Variables 
        Dim _args() As String = Environment.GetCommandLineArgs
        Dim _yes4all As Boolean = False
        Dim _dir2 As Boolean = False
        Dim _info As Boolean = False
        Dim _help As Boolean = False
        Dim _pt As Boolean = False
        Dim _temp As Boolean = False
        Dim _quiet As Boolean = False
        Dim _clean As Boolean = False
        Dim tempath As String = System.IO.Path.GetTempPath
        Dim _ptpath(2) As String
        _ptpath(0) = "C:\Program File(x86)\Avid\Pro Tools\DAE\DAE Prefs"
        _ptpath(1) = "C:\Program File(x86)\Avid\Pro Tools\Database"
        _ptpath(2) = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        'Console.WriteLine(_ptpath(2))
        Dim _cleanpath As String = CStr(VariantType.String)
        Dim filelisttemp As List(Of String)
        Dim filecount As Integer = 0
        Dim filesize As FileInfo
        Dim totalsize As Integer = 0
        Dim totalsize_ok As String = "Error Getting files size."
        Dim dirlist = System.IO.Directory.EnumerateDirectories(tempath)
        Dim dircount As Integer = 0
        Dim _continue As String = CStr(VariantType.String)
        Dim _count As Integer = 0
        'filelist = GetFilesRecursive(tempath)

        Console.WriteLine(" Parsing Arguments:")
        For Each arg In _args
            If arg.Contains("-q") Then
                _quiet = True
            End If
            If arg.Contains("-y") Then
                _yes4all = True
            End If
            If arg.Contains("-f") Then
                _dir2 = True
            End If
            If arg.Contains("-i") Then
                _info = True
            End If
            If arg.Contains("-h") Then
                _help = True
            End If
            If arg.Contains("-pt") Then
                _pt = True
                Console.WriteLine(" Pro Tools config folders will be cleaned.")
                Console.WriteLine(_ptpath(0))
                Console.WriteLine(_ptpath(1))
                Console.WriteLine(_ptpath(2))
            End If
            If arg = "-tmp" Then
                _temp = True
                Console.WriteLine(" User's default Temporary folder will be cleaned.")
                Console.WriteLine(tempath)
            End If
            If arg = "-c" Then
                _clean = True
                _cleanpath = _args(_count + 1)
                If System.IO.Directory.Exists(_cleanpath) = True Then
                    Console.WriteLine(" ## Careful ##")
                    Console.WriteLine(" Any file on " & _cleanpath & " will be Deleted !!!")
                    Console.WriteLine()
                    Console.WriteLine(" Do you REALLY want to continue? Yes/No")

                    Do Until _continue = "Yes"
                        _continue = Console.ReadLine()
                        If _continue = "Yes" Then
                            Console.WriteLine(" Starting the cleanup.")
                        ElseIf _continue = "No" Then
                            Console.WriteLine(" Stoping right now.")
                            Environment.Exit(0)
                        Else
                            Console.WriteLine(" You need to type Yes or No")
                        End If
                    Loop
                    Console.WriteLine(" The user selected folder will be cleaned.")
                    Console.WriteLine(_cleanpath)
                Else
                    Console.WriteLine(" Specified folder not found!")
                    _cleanpath = ""
                    _clean = False
                End If

            End If
            _count = _count + 1
        Next
        Console.Read()
        Environment.Exit(0)

        
       
        Console.WriteLine()
        Console.WriteLine(" Finished parsing arguments.")
        Console.WriteLine(" Starting processes...")
        'Console.Read()
        'Environment.Exit(0)

        If _help = True Then
            Console.WriteLine()
            Console.WriteLine(" Usage: <k-cleaner.exe> -<arg1> -<arg2> -<c> <""absolute path""> ... -<argN>")
            Console.WriteLine()
            Console.WriteLine(" -y = Presume yes for all questions.")
            Console.WriteLine()
            Console.WriteLine(" -q = Quiet mode.")
            Console.WriteLine()
            Console.WriteLine(" -f = Include folders.")
            Console.WriteLine()
            Console.WriteLine(" -i = Information only.")
            Console.WriteLine()
            Console.WriteLine(" -h = This help.")
            Console.WriteLine()
            Console.WriteLine(" -pt = Clean the following Pro Tools files:")
            Console.WriteLine()
            Console.WriteLine("       C:\Program File(x86)\Avid\Pro Tools\DAE\DAE Prefs")
            Console.WriteLine("       C:\Program File(x86)\Avid\Pro Tools\Database [keeping this folder]")
            Console.WriteLine("       C:\Users\-=current user=-\AppData\Roaming\...\Pro Tools.pref")
            Console.WriteLine()
            Console.WriteLine(" -tmp = Clean user Temporary folder.")
            Console.WriteLine()
            Console.WriteLine(" -c = Clean user specified folder.")
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine(" Press any key to Exit.")
            Console.Read()
            Environment.[Exit](0)
        End If

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
            If _quiet = False Then
                Console.WriteLine(" Starting the cleanup.")
            End If

        End If

    End Sub

    Public Function get_count(ByVal path As String,ByVal Optional _dir As Boolean, ByVal _ ) As List(Of String)

        Try
            For Each _dir In dirlist
                dircount = dircount + 1
            Next
            Console.WriteLine(" " & dircount & " Directories in temporary folder")
        Catch ex As Exception
            Console.WriteLine(" Error gathering the list of directories.")
        End Try
        filelisttemp = GetFilesRecursive(tempath)
        For Each path In _ptpath
            filelistpt.add = GetFilesRecursive(path)
        Next


        Try
            For Each temps In filelist
                filesize = My.Computer.FileSystem.GetFileInfo(temps)
                filecount = filecount + 1
                totalsize = CInt(totalsize + filesize.Length)
                Dim finalsize = CDec(totalsize / 1024)
                totalsize_ok = finalsize.ToString("###,###,###") & " KB's"
            Next
            Console.WriteLine(" " & filecount & " files.")
            Console.WriteLine(" " & totalsize_ok)
            Console.Read()
        Catch ex As Exception
            Console.WriteLine(" error acessing temp files.")
        End Try
        If _info = True Then
            Environment.Exit(0)
        End If
        If _dir = True Then

        End If

    End Function

    Public Function del_folder(ByVal _path As String, ByVal _quiet As Boolean) As Boolean
        Try

            For Each _dirs In _path
                Try
                    Directory.Delete(_dirs)
                Catch ex As Exception
                    If _quiet = False Then
                        Console.WriteLine(" error deleting temporary folders.")
                    End If
                End Try

            Next

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function clean_folder(ByVal _folder As IEnumerable(Of String), ByVal _quiet As Boolean) As Boolean

        Dim FO As FileStream
        Try
            For Each temps In _folder
                Try
                    FO = System.IO.File.Open(temps, FileMode.Open, FileAccess.Read, FileShare.None)
                    FO.Close()
                    File.Delete(temps)
                    If _quiet = False Then
                        Console.WriteLine(temps & " Deleted.")
                    End If
                Catch ex As Exception
                    If _quiet = False Then
                        Console.WriteLine(" error deleting file - Probably in use. " & vbCrLf & temps)
                        'Console.Read()
                    End If
                End Try

            Next
            Return True
        Catch ex As Exception
            If _quiet = False Then
                Console.WriteLine(" error acessing temp files.")
                'Console.Read()
            End If
            Return False
        End Try

    End Function


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