Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Namespace DXSample.PersistentClasses
	Public Class Person
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private fName As String
		Public Property Name() As String
			Get
				Return fName
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", fName, value)
			End Set
		End Property

		Private fAge As Integer
		Public Property Age() As Integer
			Get
				Return fAge
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Age", fAge, value)
			End Set
		End Property
	End Class
End Namespace