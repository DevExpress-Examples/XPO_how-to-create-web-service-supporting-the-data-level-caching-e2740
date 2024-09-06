Imports System
Imports DXSample

Namespace Client

    Public Partial Class _Default
        Inherits Web.UI.Page

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
            personSource.Session = GetNewSesion()
        End Sub
    End Class
End Namespace
