Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Module Module1

    Sub Main()



        Console.WriteLine("..== For testing purpose only, by T.O.Neves. thanks to Sergio Pastore ==..")
        Console.WriteLine("Software made for specific needs, maybe not useful for everyone. Use with care.")
        Console.WriteLine("Lisenced under GPL 3.0 - search on GitHub for the source code." & " V.0.2.423")
        Console.WriteLine("Please, send any bugs or opinions to thiagoneves@live.com")
        'Console.WriteLine("Logfile created on program folder if no other path is given.")
        Console.WriteLine("Working as user """ & Environment.UserName.ToString & """ profile.")
        Console.WriteLine()

        'Console.Read()
        'Environment.Exit(0)

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
        Dim _user_sw As Boolean = False
        Dim _user As String = "current"
        Dim tempath As String = System.IO.Path.GetTempPath
        Dim _cleanpath As String = CStr(VariantType.String)
        Dim _continue As String = CStr(VariantType.String)
        Dim _count As Integer = 0
        Dim _size_tmp As Integer
        Dim _dir_tmp As Integer
        Dim _file_tmp As Integer
        Dim _size_pt As Integer
        Dim _dir_pt As Integer
        Dim _file_pt As Integer
        Dim _size_cln As Integer
        Dim _dir_cln As Integer
        Dim _file_cln As Integer

        Console.WriteLine("Parsing Arguments:")
        For Each y In _args
            If y.Contains("-y") Then
                _yes4all = True
            End If
        Next
        For Each arg In _args
            If arg.Contains("-q") Then
                _quiet = True
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
                Console.WriteLine("Pro Tools config folders.")
                'Console.WriteLine(_ptpath(0))
                'Console.WriteLine(_ptpath(1))
                'Console.WriteLine(_ptpath(2))
            End If
            If arg = "-tmp" Then
                _temp = True
                Console.WriteLine("System Temporary folder.")
                'Console.WriteLine(tempath)
            End If
            If arg = "-c" Then
                _clean = True
                Console.WriteLine("User selected folder.")
                If _count = _args.Count - 1 Then
                    _cleanpath = _args(_count)
                Else
                    _cleanpath = _args(_count + 1)
                End If

                If _cleanpath.Contains("-") = True Then
                    If _yes4all = False Then
                        Console.WriteLine("Enter the path to clean:")
                        If _yes4all = False Then
                            Do Until System.IO.Directory.Exists(_cleanpath) = True Or _cleanpath = "none"
                                _cleanpath = Console.ReadLine()
                                If _cleanpath = "" Then
                                    Console.WriteLine("type ""none"" to cancel")
                                    'Environment.Exit(22)

                                End If
                            Loop
                        Else
                            If System.IO.Directory.Exists(_cleanpath) = False Then

                            End If
                        End If
                        If System.IO.Directory.Exists(_cleanpath) = True Then
                            Console.WriteLine()
                            Console.WriteLine("## Careful ##")
                            Console.WriteLine("Any file on " & _cleanpath & " will be Deleted !!!")
                            Console.WriteLine("This action can cause severe damage to the system !!")
                            Console.WriteLine()
                            Console.WriteLine("Do you REALLY want to continue? yes/no")
                            If _yes4all = False Then
                                Do Until _continue = "yes"
                                    _continue = Console.ReadLine()
                                    If _continue = "yes" Then
                                        Console.WriteLine("Ok then.")
                                    ElseIf _continue = "no" Then
                                        Console.WriteLine("Stoping right now.")
                                        Environment.Exit(10)
                                    Else
                                        Console.WriteLine("You need to type ""yes"" or ""no""")
                                    End If
                                Loop
                                Console.WriteLine("Feature not suported at the momment.")
                                'Console.WriteLine("User selected folder.")
                                Console.WriteLine(_cleanpath)
                            End If
                        Else
                            Console.WriteLine("Specified folder not found!")
                            _cleanpath = ""
                            _clean = False
                        End If
                    End If
                End If
                End If



            If arg = "-u" Then
                _user_sw = True
                If _count = _args.Count - 1 Then
                    _user = _args(_count)
                Else
                    _user = _args(_count + 1)
                End If
                If _user.Contains("-") = True Then
                    Dim _y As String = Nothing
                    If _yes4all = False Then
                        Do Until _y = "y"
                            If _user = "none" Then
                                Environment.Exit(22)
                            End If
                            Console.WriteLine("Enter the user name you want to clean:")
                            _user = Console.ReadLine()
                            Console.WriteLine()
                            If System.IO.Directory.Exists("C:\Users\" & _user & "\AppData\Roaming") = True Then
                                Try
                                    'Console.WriteLine(System.IO.Directory.GetAccessControl("C:\Users\" & _user & "\AppData\Roaming"))
                                    Console.WriteLine(Security.AccessControl.FileSystemRights.TakeOwnership.ToString("C:\Users\" & _user & "\AppData\Roaming"))
                                    Console.WriteLine(Security.AccessControl.FileSystemRights.ReadPermissions.ToString("C:\Users\" & _user & "\AppData\Roaming"))

                                Catch ex As Exception
                                    Console.WriteLine("Could not get control of user folder.")
                                    Console.WriteLine("C:\Users\" & _user & "\AppData\Roaming")
                                End Try

                                Console.WriteLine("User found! Want to proceed ? y/n")
                                _y = Console.ReadLine()
                            Else
                                Console.WriteLine("User not found! write ""none"" to exit")
                            End If
                            If System.IO.Directory.Exists("C:\Users\" & _user & "\AppData\Roaming") = True Then
                                Console.WriteLine("## Careful ##")
                                Console.WriteLine("Preference files for user " & _user & " will be cleaned!")
                                Console.WriteLine("C:\Users\" & _user & "\AppData\Roaming")
                                Console.WriteLine()
                                Console.WriteLine("Do you REALLY want to continue? y/n")
                                If _yes4all = False Then
                                    Do Until _continue = "y"
                                        _continue = Console.ReadLine()
                                        If _continue = "y" Then
                                            Console.WriteLine("Continuing...")
                                        ElseIf _continue = "n" Then
                                            Console.WriteLine("Stoping right now.")
                                            Environment.Exit(0)
                                        Else
                                            Console.WriteLine("You need to type ""y"" or ""n""")
                                        End If
                                    Loop
                                    Console.WriteLine("The user selected folder will be cleaned.")
                                    Console.WriteLine("C:\Users\" & _user & "\AppData\Roaming")
                                End If
                            Else
                                Console.WriteLine("Specified folder not found!")
                                _user = "current"
                                _user_sw = False
                            End If
                        Loop
                    Else
                        Console.WriteLine("-y argument used, bypassing all questions without a possible yes answer")
                    End If

                End If

            End If
            _count = _count + 1
        Next
        'Console.Read()
        'Environment.Exit(0)



        Console.WriteLine()
        Console.WriteLine("Finished parsing arguments.")
        Console.WriteLine("Starting processes...")
        Console.WriteLine()

        'Console.Read()
        'Environment.Exit(0)

        If _help = True Then
            Console.WriteLine()
            Console.WriteLine("Usage: <k-cleaner.exe> -<arg1> -<arg2> -<c> <""absolute path""> -<u> <""username"">... -<argN>")
            Console.WriteLine()
            Console.WriteLine(" -y = Presume yes for all questions.")
            Console.WriteLine()
            Console.WriteLine(" -q = Quiet mode. -- on future versions.")
            Console.WriteLine()
            Console.WriteLine(" -f = Include folders. Deprecated, default now.")
            Console.WriteLine()
            Console.WriteLine(" -i = Information only.")
            Console.WriteLine()
            Console.WriteLine(" -h = This help.")
            Console.WriteLine()
            Console.WriteLine(" -u = Specify a user, use the argument ""-u"" before the user name if used in conjunction with ""-y"" or just ""-u"" without it. ")
            Console.WriteLine()
            Console.WriteLine(" -pt = Clean the following Pro Tools files/folders:")
            Console.WriteLine()
            Console.WriteLine("       ""C:\Program File (x86)\Avid\Pro Tools\DAE\DAE Prefs""")
            Console.WriteLine("       ""C:\Program File (x86)\Avid\Pro Tools\Database"" [keeping this folder]")
            Console.WriteLine("       ""C:\Users\-=current user=-\AppData\Roaming\...\Pro Tools pref.ptp""")
            Console.WriteLine()
            Console.WriteLine(" -tmp = Clean user Temporary folder.")
            Console.WriteLine()
            Console.WriteLine(" -c = Clean user specified folder.")
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("Press any key to Exit.")
            Console.Read()
            Environment.[Exit](10)
        End If

        If _yes4all = False Then
            Console.WriteLine("You want to continue? y/n")

            Do Until _continue = "y"
                _continue = Console.ReadLine()
                If _continue = "y" Then
                    Console.WriteLine("Starting the cleanup.")
                ElseIf _continue = "n" Then
                    Console.WriteLine("Stoping right now.")
                    Environment.Exit(0)
                ElseIf _continue = "" Then
                Else
                    Console.WriteLine("You need to type ""y"" or ""n""")
                End If
            Loop
        Else
            If _quiet = False Then
                Console.WriteLine()
                Console.WriteLine("Starting the cleanup.")
                Console.WriteLine()
            End If
        End If

        'handle -tmp argument
        If _temp = True Then
            clean_tmp(_user, _file_tmp, _dir_tmp, _size_tmp)
            'Console.WriteLine(_size_tmp)
            'Console.WriteLine(_file_tmp)
            'Console.WriteLine(_dir_tmp)
            'Console.Read()
        End If

        If _clean = True Then
            clean_folder(_user, _file_cln, _dir_cln, _size_cln)
            'Console.WriteLine(_size_cln)
            'Console.WriteLine(_file_cln)
            'Console.WriteLine(_dir_cln)
            'Console.Read()
        End If


        'handle -pt argument
        If _pt = True Then
            clean_PT(_user, _file_pt, _dir_pt, _size_pt)
            'Console.WriteLine(_size_pt)
            'Console.WriteLine(_file_pt)
            'Console.WriteLine(_dir_pt)
            'Console.Read()
        End If

        If _yes4all = False Then
            Console.Read()
        End If


    End Sub

    Private Sub clean_folder(ByVal _cleanpath As String, ByRef _files As Integer, ByRef _dir As Integer, ByRef _size As Integer)

        Dim _tmplist = GetFilesRecursive(_cleanpath)
        Dim _fileinfo As FileInfo
        Dim _filesize As Integer
        Dim _totalsize As Integer = 0
        Dim _dirlist = GetfoldersRecursive(_cleanpath)
        _dir = _dirlist.Count
        _files = _tmplist.Count
        Dim _delFcount As Integer
        Dim _delFcounterr As Integer
        Dim _delDcount As Integer
        Dim _delDcounterr As Integer

        For Each File In _tmplist
            _fileinfo = My.Computer.FileSystem.GetFileInfo(File)
            _filesize = _fileinfo.Length
            _totalsize = _totalsize + _filesize
        Next
        _size = (_totalsize / 1024)
        Console.WriteLine()
        Console.WriteLine("System Temporary Folder.")
        Console.WriteLine(_cleanpath)
        Console.WriteLine()
        Console.WriteLine("Trying to delete the following files:")
        For Each File In _tmplist
            Try
                Console.Write(File)
                FileOpen(0, File, OpenMode.Random, OpenAccess.ReadWrite, OpenShare.LockReadWrite)
                FileClose(0)
                'System.IO.File.Open(File, FileMode.Open, FileAccess.ReadWrite, FileShare.None).Close()
                System.IO.File.Delete(File)
                Console.Write(" ...ok." & vbCrLf)
                _delFcount = _delFcount + 1
            Catch ex As Exception
                Console.Write(" ...error." & vbCrLf)
                _delFcounterr = _delFcounterr + 1
            End Try
        Next
        Console.WriteLine()
        Console.WriteLine("Trying to delete the following folders:")
        For Each Dirs In _dirlist
            Try
                Console.Write(Dirs)
                My.Computer.FileSystem.DeleteDirectory(Dirs, DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
                Console.Write(" ...ok." & vbCrLf)
                _delDcount = _delDcount + 1
            Catch ex As Exception
                Console.Write(" ...error." & vbCrLf)
                _delDcounterr = _delDcounterr + 1
            End Try

        Next
        Console.WriteLine("User selected folder cleaned.")
        Console.WriteLine()
        Console.WriteLine(_delFcount & " Files deleted and " & _delFcounterr & " in use.")
        Console.WriteLine(_delDcount & " Folders deleted and " & _delDcounterr & " still in use.")
        'Console.Read()

    End Sub


    Private Sub clean_tmp(ByVal _user As String, ByRef _files As Integer, ByRef _dir As Integer, ByRef _size As Integer)

        ' C:\Users\Thiago\AppData\Local\Temp
        Dim tempath As String
        If _user = "current" Then
            tempath = System.IO.Path.GetTempPath
        Else
            tempath = "C:\Users\" & _user & "\AppData\Local\Temp"
            Try
                System.IO.Directory.GetAccessControl("C:\Users\" & _user & "\AppData\Local\Temp")
            Catch ex As Exception
                Console.WriteLine("Could not get control of user temporary folder.")
            End Try
        End If

        Dim _tmplist = GetFilesRecursive(tempath)
        Dim _fileinfo As FileInfo
        Dim _filesize As Integer
        Dim _totalsize As Integer = 0
        Dim _dirlist = GetfoldersRecursive(tempath)
        _dir = _dirlist.Count
        _files = _tmplist.Count
        Dim _delFcount As Integer
        Dim _delFcounterr As Integer
        Dim _delDcount As Integer
        Dim _delDcounterr As Integer

        For Each File In _tmplist
            _fileinfo = My.Computer.FileSystem.GetFileInfo(File)
            _filesize = _fileinfo.Length
            _totalsize = _totalsize + _filesize
        Next
        _size = (_totalsize / 1024)
        Console.WriteLine()
        Console.WriteLine("System Temporary Folder.")
        Console.WriteLine(tempath)
        Console.WriteLine()
        Console.WriteLine("Trying to delete the following files:")
        For Each File In _tmplist
            Try
                Console.Write(File)
                FileOpen(0, File, OpenMode.Random, OpenAccess.ReadWrite, OpenShare.LockReadWrite)
                FileClose(0)
                'System.IO.File.Open(File, FileMode.Open, FileAccess.ReadWrite, FileShare.None).Close()
                System.IO.File.Delete(File)
                Console.Write(" ...ok." & vbCrLf)
                _delFcount = _delFcount + 1
            Catch ex As Exception
                Console.Write(" ...error." & vbCrLf)
                _delFcounterr = _delFcounterr + 1
            End Try
        Next
        Console.WriteLine()
        Console.WriteLine("Trying to delete the following folders:")
        For Each Dirs In _dirlist
            Try
                Console.Write(Dirs)
                My.Computer.FileSystem.DeleteDirectory(Dirs, DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
                Console.Write(" ...ok." & vbCrLf)
                _delDcount = _delDcount + 1
            Catch ex As Exception
                Console.Write(" ...error." & vbCrLf)
                _delDcounterr = _delDcounterr + 1
            End Try

        Next
        Console.WriteLine("Temporary folder cleaned.")
        Console.WriteLine()
        Console.WriteLine(_delFcount & " Files deleted and " & _delFcounterr & " in use.")
        Console.WriteLine(_delDcount & " Folders deleted and " & _delDcounterr & " still in use.")
        'Console.Read()



    End Sub


    Private Sub clean_PT(ByVal _user As String, ByRef _files As Integer, ByRef _dir As Integer, ByRef _size As Integer)
        '_size = 0
        Dim _ptpath(2) As String
        _ptpath(0) = "C:\Program Files (x86)\Avid\Pro Tools\DAE\DAE Prefs"
        _ptpath(1) = "C:\Program Files (x86)\Avid\Pro Tools\Databases"
        If _user = "current" Then
            _ptpath(2) = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Else

        End If

        Dim _daelist = GetFilesRecursive(_ptpath(0))
        Dim _databaselist = GetFilesRecursive(_ptpath(1))
        Dim _prefsearch = GetFilesRecursive(_ptpath(2))
        Dim _flag As Boolean
        Dim _info As FileInfo
        Dim _Fsize As Integer
        Dim _01list As List(Of String) = _databaselist
        _01list.AddRange(_daelist)
        Try
            _files = _01list.Count
            For Each File In _01list
                _info = My.Computer.FileSystem.GetFileInfo(File)
                _Fsize = _info.Length
                _size = _size + _Fsize
            Next
        Catch ex As Exception
            Console.WriteLine("Error getting information about files and folders.")
        End Try


        'path 1
        Console.WriteLine("Finding first Pro Tools Folder...")
        Console.WriteLine("C:\Program Files (x86)\Avid\Pro Tools\DAE\DAE Prefs")
        If System.IO.Directory.Exists(_ptpath(0)) = True Then
            Console.WriteLine(_ptpath(0) & " exists")

            Console.WriteLine("Trying to delete folder...")
            Try
                FileSystem.DeleteDirectory(_ptpath(0).ToString, DeleteDirectoryOption.DeleteAllContents)
                _flag = True
            Catch ex As Exception
                Console.WriteLine("## Error ## Try delete it manually.")
                _flag = False
            End Try
            If _flag = True Then
                Console.WriteLine("Deletion completed ok.")
                Console.WriteLine()
            End If
        Else
            Console.WriteLine("No folder found, probably already deleted.")
        End If

        'path 2 - database - need to keep folder ... delete all within
        Console.WriteLine()
        Console.WriteLine("Finding Second Pro Tools Folder...")
        If System.IO.Directory.Exists(_ptpath(1)) = True Then
            Console.WriteLine(_ptpath(1) & " exists")
            Console.WriteLine("Trying to delete the following files:")
            If _databaselist.Count > 0 Then
                For Each _File In _databaselist
                    Try
                        Console.Write(_File)
                        FileSystem.DeleteFile(_File)
                        Console.Write(" ... ok." & vbCrLf)
                    Catch ex As Exception
                        Console.Write("## Error ## file " & _File & " in use.")
                    End Try
                Next
            Else
                Console.WriteLine("Could not find any file in Database folder. Probably already cleaned.")
            End If

        Else
            Console.WriteLine("No folder found! Please check it.")
        End If

        'path 3 - just a file inside the folder - need to find it first.
        Console.WriteLine()
        Console.WriteLine("Searching for the last File...")
        Dim _found As Integer = 0
        For Each _prefs In _prefsearch
            If _prefs.Contains("Pro Tools Prefs") = True Then
                _found = _found + 1
                Console.WriteLine()
                Console.WriteLine("Trying to delete the following files:")
                Try
                    Console.Write(_prefs)
                    FileSystem.DeleteFile(_prefs)
                    Console.Write(" ... ok.")
                    Console.WriteLine()
                    _files = _files + 1
                Catch ex As Exception
                    Console.Write("## Error ## file " & _prefs & " in use.")
                End Try
            Else
                _found = _found
            End If
        Next
        If _found = 0 Then
            Console.WriteLine("Could not find ""Pro Tools Pref.ptp""  file, probably already deleted.")
        End If
        'Console.Read()
        'Environment.Exit(0)
    End Sub

    Public Function GetfoldersRecursive(ByVal initial As String, Optional ByVal _quiet As Boolean = False) As List(Of String)
        ' This list stores the results.
        Dim stack As New Stack(Of String)
        Dim result As New List(Of String)
        stack.Push(initial)
        Do While stack.Count > 0
            Dim dir As String = stack.Pop
            Try
                result.AddRange(Directory.GetDirectories(dir))
                Dim dirname As String
                For Each dirname In Directory.GetDirectories(dir)
                    stack.Push(dirname)
                Next
            Catch ex As Exception
                Console.WriteLine("Error scanning system folders.")
            End Try
        Loop

        ' Return the list
        Return result.ToList
    End Function

    Public Function GetFilesRecursive(ByVal initial As String, Optional ByVal _quiet As Boolean = False) As List(Of String)
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
                If _quiet = False Then
                    Console.WriteLine("Error scanning system files.")
                End If
            End Try
        Loop

        ' Return the list
        Return result
    End Function
End Module