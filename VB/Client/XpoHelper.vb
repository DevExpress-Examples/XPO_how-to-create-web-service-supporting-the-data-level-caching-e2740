Imports Microsoft.VisualBasic
Imports System
Imports DXSample.Proxy
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports DXSample.PersistentClasses

Namespace DXSample
	Public NotInheritable Class XpoHelper
		Private Sub New()
		End Sub
		Public Shared Function GetNewSesion() As Session
			Return New Session(DataLayer)
		End Function

		Public Shared Function GetNewUnitOfWork() As UnitOfWork
			Return New UnitOfWork(DataLayer)
		End Function

		Private Shared ReadOnly lockObject As Object = New Object()

'INSTANT VB TODO TASK: There is no VB.NET equivalent to 'volatile':
'ORIGINAL LINE: static volatile IDataLayer fDataLayer;
		Private Shared fDataLayer As IDataLayer
		Private Shared ReadOnly Property DataLayer() As IDataLayer
			Get
				If fDataLayer Is Nothing Then
					SyncLock lockObject
						If fDataLayer Is Nothing Then
							fDataLayer = GetDataLayer()
						End If
					End SyncLock
				End If
				Return fDataLayer
			End Get
		End Property

		Private Shared Function GetDataLayer() As IDataLayer
			XpoDefault.Session = Nothing
			Dim dict As XPDictionary = New ReflectionDictionary()
			dict.GetDataStoreSchema(GetType(Person).Assembly)
			Return New ThreadSafeDataLayer(dict, New DataCacheNode(New CachingDataStore("http://localhost:1556/CachingService.asmx")))
		End Function
	End Class
End Namespace