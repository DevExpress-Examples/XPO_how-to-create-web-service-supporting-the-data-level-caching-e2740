Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DXSample.PersistentClasses

Namespace DatabaseUpdater

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            Dim dal As IDataLayer = XpoDefault.GetDataLayer(MSSqlConnectionProvider.GetConnectionString(".", "CachingService"), AutoCreateOption.DatabaseAndSchema)
            Dim uow As UnitOfWork = New UnitOfWork(dal)
            uow.UpdateSchema(GetType(Person).Assembly)
            uow.CreateObjectTypeRecords(GetType(Person).Assembly)
            uow.Delete(New XPCollection(Of Person)(uow))
            uow.CommitChanges()
            Dim tmp_Person = New Person(uow) With {.Name = "John", .Age = 26}
            Dim tmp_Person = New Person(uow) With {.Name = "Bob", .Age = 31}
            uow.CommitChanges()
        End Sub
    End Class
End Namespace
