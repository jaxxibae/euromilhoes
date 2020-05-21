Public Class Form1
    Dim Rnd As New Random

    Dim NumerosAposta As New ArrayList
    Dim EstrelasAposta As New ArrayList

    Dim NumerosSorteio As New ArrayList
    Dim EstrelasSorteio As New ArrayList

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Caso haja algum dado nas ArrayLists (por exemplo, para gerar uma nova aposta), vamos apagá-los
        NumerosAposta.Clear()
        EstrelasAposta.Clear()

        ' Também vamos limpar o sorteio gerado, para não haverem múltiplas tentativas de ganhar ao sistema >:)
        NumerosSorteio.Clear()
        EstrelasSorteio.Clear()
        TextBox2.Clear()
        Label3.Text = ""
        Label4.Text = ""

        ' Gerar números
        For i = 0 To 4
            GerarNumero(NumerosAposta)
        Next

        ' Gerar estrelas
        For i = 0 To 1
            GerarEstrela(EstrelasAposta)
        Next

        ' Ordenar cada ArrayList em ordem ascendente
        NumerosAposta.Sort()
        EstrelasAposta.Sort()

        ' Caso houverem dados já na TextBox1, vamos removê-los
        TextBox1.Clear()

        ' Mostrar o resultado da aposta gerada na TextBox1
        TextBox1.Text &= "Números:" & vbNewLine
        For i = 0 To 4
            TextBox1.Text &= NumerosAposta(i) & vbNewLine
        Next

        TextBox1.Text &= vbNewLine & "Estrelas:" & vbNewLine
        For i = 0 To 1
            TextBox1.Text &= EstrelasAposta(i) & vbNewLine
        Next
    End Sub

    Sub GerarNumero(AL As ArrayList)
        Dim NumeroAleatorio As Integer = Rnd.Next(1, 51)
        ' Vamos verificar por números duplicados, caso existam
        If AL.Contains(NumeroAleatorio) Then
            GerarNumero(AL)
        Else
            AL.Add(NumeroAleatorio)
        End If
    End Sub

    Sub GerarEstrela(AL As ArrayList)
        Dim EstrelaAleatoria As Integer = Rnd.Next(1, 13)
        ' Vamos verificar por estrelas duplicadas, caso existam
        If AL.Contains(EstrelaAleatoria) Then
            GerarEstrela(AL)
        Else
            AL.Add(EstrelaAleatoria)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Caso haja algum dado nas ArrayLists (por exemplo, para gerar uma nova aposta), vamos apagá-los
        NumerosSorteio.Clear()
        EstrelasSorteio.Clear()

        ' Gerar números
        For i = 0 To 4
            GerarNumero(NumerosSorteio)
        Next

        ' Gerar estrelas
        For i = 0 To 1
            GerarEstrela(EstrelasSorteio)
        Next

        ' Ordenar cada ArrayList em ordem ascendente
        NumerosSorteio.Sort()
        EstrelasSorteio.Sort()

        ' Caso houverem dados já na TextBox1, vamos removê-los
        TextBox2.Clear()

        ' Mostrar o resultado da aposta gerada na TextBox1
        TextBox2.Text &= "Números:" & vbNewLine
        For i = 0 To 4
            TextBox2.Text &= NumerosSorteio(i) & vbNewLine
        Next

        TextBox2.Text &= vbNewLine & "Estrelas:" & vbNewLine
        For i = 0 To 1
            TextBox2.Text &= EstrelasSorteio(i) & vbNewLine
        Next

        ' Vamos verificar a aposta com o sub VerificarAposta()
        VerificarAposta()
    End Sub

    Sub VerificarAposta()
        Dim NumerosAcertados As Integer = 0
        Dim EstrelasAcertadas As Integer = 0

        For i = 0 To 4
            If NumerosSorteio.Contains(NumerosAposta(i)) Then
                NumerosAcertados += 1
            End If
        Next

        For i = 0 To 1
            If EstrelasSorteio.Contains(EstrelasAposta(i)) Then
                EstrelasAcertadas += 1
            End If
        Next

        Label3.Text = "Números: " & NumerosAcertados
        Label4.Text = "Estrelas: " & EstrelasAcertadas
    End Sub
End Class
