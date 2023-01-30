Public Class CreateDocumentModel
    Public Property userId As Integer

    Public Property url As String

    Public Property documentType As DocumentType


End Class

Public Enum DocumentType
    Pdf
    Html
    Png
End Enum

