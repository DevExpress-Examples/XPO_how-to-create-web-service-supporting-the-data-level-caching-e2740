Imports Microsoft.VisualBasic
Imports System
Imports DXSample

Namespace Client
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			personSource.Session = XpoHelper.GetNewSesion()
		End Sub
	End Class
End Namespace
