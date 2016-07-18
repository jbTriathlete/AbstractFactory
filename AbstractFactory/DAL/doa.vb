Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class doa
    Implements IDisposable

    Dim conn As SqlConnection

    Dim cmd As SqlCommand

    Dim sqlDr As SqlDataAdapter

    Dim parm As New spParm

    Dim ds As DataSet

    Dim disposed As Boolean = False

    ' Public connstring As String = "server=ibm-jbaker;database=master;Trusted_connection=yes"

    Public connstring As String = "server=prosql05;database=CPSData;user id=sa;password=sqlsql;"


    Public Structure spParm
        Public parmName As String
        Public value As String
        Public type As String
        Public direction As Boolean
    End Structure

    Public Function executeUpdate(ByVal inSql As String) As Boolean

        conn = New SqlConnection(connstring)

        conn.Open()

        cmd = New SqlCommand(inSql, conn)

        cmd.ExecuteNonQuery()

        Return True

    End Function

    Public Function executeUpdateb(ByVal inSql As String) As Boolean

        conn = New SqlConnection(connstring)

        conn.Open()

        cmd = New SqlCommand(inSql, conn)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.ExecuteNonQuery()

        Return True

    End Function

    Public Function executeSpGet(ByVal inSp As String, ByVal inParm As IList(Of spParm)) As DataSet

        conn = New SqlConnection(connstring)

        conn.Open()

        sqlDr = New SqlDataAdapter(inSp, conn)

        sqlDr.SelectCommand.CommandType = CommandType.StoredProcedure

        sqlDr.SelectCommand.CommandTimeout = 900

        For xcnt = 1 To inParm.Count

            parm = inParm.Item(xcnt)

            If parm.type = "int" Then

                sqlDr.SelectCommand.Parameters.Add(parm.parmName, SqlDbType.Int)

                sqlDr.SelectCommand.Parameters(parm.parmName).Value = CInt(parm.value)

            ElseIf parm.type = "datetime" Then

                sqlDr.SelectCommand.Parameters.Add(parm.parmName, SqlDbType.DateTime)

                sqlDr.SelectCommand.Parameters(parm.parmName).Value = CDate(parm.value)

            ElseIf parm.type = "varchar" Then

                sqlDr.SelectCommand.Parameters.Add(parm.parmName, SqlDbType.VarChar)

                sqlDr.SelectCommand.Parameters(parm.parmName).Value = parm.value

            ElseIf parm.type = "Boolean" Then

                sqlDr.SelectCommand.Parameters.Add(parm.parmName, SqlDbType.Bit)

                sqlDr.SelectCommand.Parameters(parm.parmName).Value = parm.value

            Else

                sqlDr.SelectCommand.Parameters.Add(parm.parmName, SqlDbType.VarChar)

                sqlDr.SelectCommand.Parameters(parm.parmName).Value = parm.value

            End If

        Next



        ds = New DataSet



        sqlDr.Fill(ds, inSp)

        sqlDr.Dispose()

        conn.Close()

        Return ds

    End Function

    Public Function executeSpInsert(ByVal inSp As String, ByVal inParm As IList(Of spParm)) As Integer

        Dim cnt As Integer

        Dim isOut As Boolean = False

        Dim outName As String = ""

        conn = New SqlConnection(connstring)

        sqlDr = New SqlDataAdapter()

        sqlDr.InsertCommand = New SqlCommand(inSp, conn)

        sqlDr.InsertCommand.CommandType = CommandType.StoredProcedure

        sqlDr.InsertCommand.UpdatedRowSource = UpdateRowSource.Both

        For xcnt = 1 To inParm.Count

            parm = inParm.Item(xcnt)

            If parm.type = "int" Then

                sqlDr.InsertCommand.Parameters.Add(parm.parmName, SqlDbType.Int)

                sqlDr.InsertCommand.Parameters(parm.parmName).Value = CInt(parm.value)

            ElseIf parm.type = "long" Then

                sqlDr.InsertCommand.Parameters.Add(parm.parmName, SqlDbType.BigInt)

                sqlDr.InsertCommand.Parameters(parm.parmName).Value = CDate(parm.value)

            ElseIf parm.type = "datetime" Then

                sqlDr.InsertCommand.Parameters.Add(parm.parmName, SqlDbType.DateTime)

                sqlDr.InsertCommand.Parameters(parm.parmName).Value = CDate(parm.value)

            ElseIf parm.type = "varchar" Then

                sqlDr.InsertCommand.Parameters.Add(parm.parmName, SqlDbType.VarChar)

                sqlDr.InsertCommand.Parameters(parm.parmName).Value = parm.value

            ElseIf parm.type = "numeric" Then

                sqlDr.InsertCommand.Parameters.Add(parm.parmName, SqlDbType.Decimal)

                sqlDr.InsertCommand.Parameters(parm.parmName).Value = CDec(parm.value)

            Else

                sqlDr.InsertCommand.Parameters.Add(parm.parmName, SqlDbType.VarChar)

                sqlDr.InsertCommand.Parameters(parm.parmName).Value = parm.value

            End If

            If parm.direction = True Then

                outName = parm.parmName

                sqlDr.InsertCommand.Parameters(parm.parmName).Direction = ParameterDirection.Output

                isOut = 1

            End If

        Next



        conn.Open()

        cnt = sqlDr.InsertCommand.ExecuteNonQuery

        If isOut = True Then

            cnt = sqlDr.InsertCommand.Parameters(outName).Value

        End If



        sqlDr.Dispose()

        conn.Close()

        Return cnt

    End Function



    Public Function executeQuery(ByVal inSp As String) As DataSet

        conn = New SqlConnection(connstring)

        conn.Open()

        sqlDr = New SqlDataAdapter(inSp, conn)

        sqlDr.SelectCommand.CommandType = CommandType.Text



        ds = New DataSet

        sqlDr.Fill(ds, inSp)

        sqlDr.Dispose()

        conn.Close()

        Return ds

    End Function



    ' Public implementation of Dispose pattern callable by consumers.

    Public Sub Dispose() Implements IDisposable.Dispose

        Dispose(True)

        GC.SuppressFinalize(Me)

    End Sub



    Protected Overridable Sub Dispose(disposing As Boolean)

        If disposed Then Return

        If disposing Then

            ' Free any other managed objects here.

            '

            conn.Dispose()

            cmd.Dispose()

            sqlDr.Dispose()

            ds.Dispose()

        End If

        ' Free any unmanaged objects here.

        '

        disposed = True

    End Sub

End Class




