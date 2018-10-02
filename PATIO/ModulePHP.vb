Imports System.Web

Public Module ModulePHP
    Public Site As String = "https://www.dainville-ac.fr/appli/"
    Public SitePhP As String = "https://www.dainville-ac.fr/appli/php/"

    Function ContenuTable(ByVal NomTable As String) As DataSet
        Dim Sn As New DataSet
        Dim Url As String = SitePhP & "contenu_table.php?table=" & NomTable

        'Lecture du fichier
        Sn.ReadXml(Url, XmlReadMode.Auto)

        Return Sn
    End Function

    Public Function ContenuRequete(ByVal SQL As String) As DataSet
        Dim Sn As New DataSet
        Dim mSQL As String = SQL.Replace("'", "@@@")
        Dim Url As String = SitePhP & "contenu_req.php?requete=" & mSQL
        Dim url1 As New Uri(Url)

        My.Computer.Clipboard.SetText(Url)
        'Lecture du fichier
        Try
            Sn.ReadXml(Url, XmlReadMode.Auto)
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & mSQL, 0, "Erreur")
        End Try
        'Le nom des tables : stat, dataset
        Return Sn
    End Function

    Public Function ContenuRequeteLourd(ByVal SQL As String) As DataSet
        Dim SnF As New DataSet
        Dim mSQL As String = SQL.Replace("'", "@@@")
        Dim tSQL As String

        Try
            Dim OK As Boolean = True
            Dim N As Integer = 10
            Dim K As Integer = 0

            Do While OK
                Dim Sn As New DataSet
                tSQL = mSQL & " LIMIT " & K * N & "," & N

                Dim Url As String = SitePhP & "contenu_req.php?requete=" & tSQL
                Dim url1 As New Uri(Url)
                'MsgBox(tSQL)
                'Lecture du fichier
                Sn.ReadXml(Url, XmlReadMode.Auto)

                'Transfert des lignes
                If SnF.Tables.Count = 0 Then
                    SnF = Sn
                Else
                    Dim N1 As Integer = Val(Sn.Tables("stat").Rows(0).Item(0).ToString)
                    If N1 = 0 Then Exit Do

                    For I As Integer = 0 To Sn.Tables("dataset").Rows.Count - 1
                        Dim mRow As DataRow = SnF.Tables("dataset").NewRow
                        For J As Integer = 0 To Sn.Tables("dataset").Columns.Count - 1
                            mRow(J) = Sn.Tables("dataset").Rows(I).Item(J).ToString
                        Next
                        SnF.Tables("dataset").Rows.Add(mRow)
                    Next

                    Dim N2 As Integer = Val(SnF.Tables("stat").Rows(0).Item(0).ToString)
                    SnF.Tables("stat").Rows(0).Item(0) = N1 + N2

                End If
                K += 1
            Loop
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & tSQL, 0, "Erreur")
        End Try
        'Le nom des tables : stat, dataset
        Return SnF
    End Function

    Public Function ExecuteSQL(ByVal SQL As String) As Boolean
        Dim wb As New System.Net.WebClient
        Dim url As String = SitePhP & "execute_req.php?requete=" & SQL
        Dim OK As Boolean = False

        Dim result As String = wb.DownloadString(url)

        If result = "1" Then
            OK = True
        Else
            MsgBox(result, 0, "Erreur")
        End If

        Return OK
    End Function

    Function GetId(ByVal iduser As String, ByVal item As String) As String
        Dim SQL As String
        Dim Valeur As String = ""
        Dim Sn As DataSet

        'Recherche de la valeur
        SQL = "select valeur from das_inc WHERE iduser='" & iduser & "'"
        SQL &= " AND item='" & item & "'"
        Sn = ContenuRequete(SQL)

        If Val(Sn.Tables("stat").Rows(0).Item("nb").ToString) > 0 Then
            Valeur = Sn.Tables("dataset").Rows(0).Item(0).ToString
        Else
            Valeur = 0
        End If

        Valeur = (Val(Valeur) + 1).ToString

        'Suppression de la valeur
        SQL = "delete from das_inc WHERE iduser='" & iduser & "'"
        SQL &= " AND item='" & item & "'"
        If Not ExecuteSQL(SQL) Then MsgBox("erreur 1")

        'Ajout de la valeur
        SQL = "INSERT INTO das_inc VALUES ('" & iduser & "','"
        SQL &= item & "','" & Valeur & "')"
        If Not ExecuteSQL(SQL) Then MsgBox("erreur 2")

        Return Valeur
    End Function

    Function GetFile(Fichier As String) As String
        Dim Texte As String = ""
        Dim wb As New Net.WebClient
        Texte = wb.DownloadString(Fichier)
        Return Texte
    End Function
End Module
