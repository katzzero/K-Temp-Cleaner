Imports System.IO

Module Module1

    Sub Main()
        Console.WriteLine("..== For testing purpose only, made by T.O.Neves. thanks to Sergio Pastore ==..")
        Console.WriteLine(" Software made for specific needs, maybe not useful for everyone. Use with care.")
        Console.WriteLine(" Lisenced under GPL 3.0 - search on GitHub for the source code.")
        Console.WriteLine()
        Dim _args() As String = Environment.GetCommandLineArgs
        Dim _yes4all As Boolean = CBool(VariantType.Boolean)
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
        Dim _dir2 As Boolean = CBool(VariantType.Boolean)
        filelist = GetFilesRecursive(tempath)


        If _args.Count() > 0 Then
            If _args(_count) = "-y" Then
                _yes4all = True
            End If
            If _args(_count) = " -d" Then
                _dir2 = True
            End If
        Else

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
