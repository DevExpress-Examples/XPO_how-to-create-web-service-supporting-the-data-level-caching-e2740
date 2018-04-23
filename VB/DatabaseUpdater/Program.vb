Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DXSample.PersistentClasses

Namespace DatabaseUpdater
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			Dim dal As IDataLayer = XpoDefault.GetDataLayer(MSSqlConnectionProvider.GetConnectionString(".", "CachingService"), AutoCreateOption.DatabaseAndSchema)
			Dim uow As New UnitOfWork(dal)
			uow.UpdateSchema(GetType(Person).Assembly)
			uow.CreateObjectTypeRecords(GetType(Person).Assembly)
			uow.Delete(New XPCollection(Of Person)(uow))
			uow.CommitChanges()
            Dim john As Person = New Person(uow) With { _
             .Name = "John", _
             .Age = 26 _
                     }
            Dim bob As Person = New Person(uow) With { _
             .Name = "Bob", _
             .Age = 31 _
                         }
			uow.CommitChanges()
		End Sub
	End Class
End Namespace
