Imports System.Text
Imports Document
Imports Newtonsoft.Json
Imports RabbitMQ.Client
Imports RabbitMQ.Client.Events

Module Module1

    Dim connection As IConnection
    Private _channel As IModel
    Private isConnectionOpen As Boolean
    Private ReadOnly createDocument = "document_create_queue"
    Private ReadOnly documentCreated = "document_created_queue"
    Private ReadOnly documentCreateExchange = "document_create_exchange"

    Private ReadOnly Property channel As IModel
        Get
            Return If(_channel, (__Assign(_channel, getChannel())))
        End Get
    End Property
    <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
    Function __Assign(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

    Sub Main()
        connection = getConnection()

        channel.ExchangeDeclare(documentCreateExchange, "direct")
        channel.QueueDeclare(createDocument, False, False, False)
        channel.QueueBind(createDocument, documentCreateExchange, createDocument)

        'channel.QueueDeclare(documentCreated, False, False, False)
        'channel.QueueBind(documentCreated, documentCreateExchange, documentCreated)

        Dim consumer As New EventingBasicConsumer(channel)
        Dim modelJson
        AddHandler consumer.Received, Sub(consumer2 As IBasicConsumer, ea As BasicDeliverEventArgs)
                                          modelJson = Encoding.UTF8.GetString(ea.Body.ToArray())
                                          'model = JsonConvert.DeserializeObject(Of CreateDocumentModel)(modelJson)
                                          Console.WriteLine($"Recieved Data:{modelJson}")
                                          Task.Delay(5000).Wait()

                                      End Sub
        channel.BasicConsume(createDocument, True, consumer)
        Console.WriteLine($"{createDocument} listening")
        Console.ReadLine()
    End Sub


    Private Function getChannel() As IModel
        Return connection.CreateModel()
    End Function
    Private Function getConnection() As IConnection
        Dim factory As ConnectionFactory = New ConnectionFactory()
        factory.HostName = "localhost"
        Return factory.CreateConnection()
    End Function

    Private Sub WriteToQueue(ByVal queueName As String, model As CreateDocumentModel)
        Dim msgArr = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model))
        channel.BasicPublish(documentCreateExchange, queueName, Nothing, msgArr)

        Console.WriteLine("Message published")
    End Sub

End Module
