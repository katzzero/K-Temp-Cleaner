Module Module1

    Sub Main()
        Console.WriteLine("..== For testing purpose only, made by T.O.Neves and Sergio Pastore ==..")
        Dim tempath As String = System.IO.Path.GetTempPath
        Console.Read()
        Console.WriteLine(tempath)
        Dim filelist = System.IO.Directory.EnumerateFiles(tempath)
        Try
            For Each temps In filelist
                Console.WriteLine(temps)
            Next
            Console.Read()
        Catch ex As Exception
            Console.WriteLine("error acessing temp files")
        End Try
        Try
            For Each temps In filelist
                Try
                    System.IO.File.Delete(temps)
                Catch ex As Exception
                    Console.WriteLine("error deleting file" & 
                End Try
                Console.Read()
            Next
        Catch ex As Exception
            Console.WriteLine("error acessing temp files")
        End Try

    End Sub

End Module
