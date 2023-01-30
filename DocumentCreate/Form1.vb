Imports RabbitMQ.Client
Imports System.IO
Imports Document
Imports System.Text.Json
Imports Newtonsoft.Json
Imports RabbitMQ.Client.Events
Imports System.Text

Public Class Form1

    Dim connection As IConnection
    Private _channel As IModel
    Private ReadOnly createDocument = "create_document_queue"
    Private ReadOnly documentCreated = "document_created_queue"
    Private ReadOnly documentCreateExchange = "document_create_exchange"

    <Obsolete>
    Private ReadOnly Property channel As IModel
        Get
            Return If(_channel, Assign(_channel, getChannel()))
        End Get
    End Property
    <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
    Shared Function Assign(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnCreateDocument.Enabled = False
    End Sub

    <Obsolete>
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If connection Is Nothing Then
            connection = getConnection()
        End If
        btnCreateDocument.Enabled = True

        channel.ExchangeDeclare(documentCreateExchange, "direct")

        channel.QueueDeclare(createDocument, False, False, False)
        channel.QueueBind(createDocument, documentCreateExchange, createDocument)

        channel.QueueDeclare(documentCreated, False, False, False)
        channel.QueueBind(documentCreated, documentCreateExchange, documentCreated)

        AddLog("Connection is open now")

    End Sub
    Private Function getChannel() As IModel
        Return connection.CreateModel()
    End Function
    Private Function getConnection() As IConnection
        Dim factory As ConnectionFactory = New ConnectionFactory()
        factory.HostName = "localhost"
        Return factory.CreateConnection()
    End Function

    <Obsolete>
    Private Sub WriteToQueue(ByVal queueName As String, model As CreateDocumentModel)
        Dim msgArr = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model))
        channel.BasicPublish(documentCreateExchange, queueName, Nothing, msgArr)

        AddLog("Message published")
    End Sub
    Private Sub AddLog(ByVal log As String)
        'If txtLog.InvokeRequired Then
        '    txtLog.Invoke(New Action(AddressOf AddLog(log)))
        '    Return
        'End If

        log = $"[{DateTime.Now:dd.M.yyyy HH:mm:ss}] - {log}"
        txtLog.AppendText($"{log}" & vbCrLf)

        txtLog.SelectionStart = txtLog.Text.Length
        txtLog.ScrollToCaret()
    End Sub

    <Obsolete>
    Private Sub btnCreateDocument_Click(sender As Object, e As EventArgs) Handles btnCreateDocument.Click
        Dim model As CreateDocumentModel = New CreateDocumentModel()
        model.userId = 1
        model.documentType = DocumentType.Pdf
        WriteToQueue(createDocument, model)

        Dim consumer As EventingBasicConsumer = New EventingBasicConsumer(channel)
        AddHandler consumer.Received, Sub(consumerBasic As IBasicConsumer, ea As BasicDeliverEventArgs)
                                          Dim body = JsonConvert.DeserializeObject(Of CreateDocumentModel)(Encoding.UTF8.GetString(ea.Body.ToArray()))
                                          AddLog($"Recieved Data Url:{body.url}")
                                          'channel.BasicAck(ea.DeliveryTag, False, False)
                                      End Sub
        channel.BasicConsume(documentCreated, True, consumer)



    End Sub
End Class
