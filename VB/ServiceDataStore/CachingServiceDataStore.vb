Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo.DB
Imports System.Web.Services
Imports DevExpress.Xpo.DB.Helpers
Imports System.Web.Services.Protocols

Namespace DXSample.Proxy
	<WebServiceBinding(Namespace := "http://devexpress.example/")> _
	Public Class CachingDataStore
		Inherits SoapHttpClientProtocol
		Implements ICachedDataStore
		Public Sub New(ByVal url As String)
			MyBase.New()
			Me.Url = url
		End Sub

		<SoapDocumentMethod("http://devexpress.example/ModifyData", RequestNamespace := "http://devexpress.example/", ResponseNamespace := "http://devexpress.example/")> _
		Public Overridable Function ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements() As ModificationStatement) As DataCacheModificationResult
			Return CType(Invoke("ModifyData", New Object() { cookie, dmlStatements })(0), DataCacheModificationResult)
		End Function

		<SoapDocumentMethod("http://devexpress.example/NotifyDirtyTables", RequestNamespace := "http://devexpress.example/", ResponseNamespace := "http://devexpress.example/")> _
		Public Overridable Function NotifyDirtyTables(ByVal cookie As DataCacheCookie, ParamArray ByVal dirtyTablesNames() As String) As DataCacheResult
			Return CType(Invoke("NotifyDirtyTables", New Object() { cookie, dirtyTablesNames })(0), DataCacheResult)
		End Function

		<SoapDocumentMethod("http://devexpress.example/ProcessCookie", RequestNamespace := "http://devexpress.example/", ResponseNamespace := "http://devexpress.example/")> _
		Public Overridable Function ProcessCookie(ByVal cookie As DataCacheCookie) As DataCacheResult
			Return CType(Invoke("ProcessCookie", New Object() { cookie })(0), DataCacheResult)
		End Function

		<SoapDocumentMethod("http://devexpress.example/SelectData", RequestNamespace := "http://devexpress.example/", ResponseNamespace := "http://devexpress.example/")> _
		Public Overridable Function SelectData(ByVal cookie As DataCacheCookie, ByVal selects() As SelectStatement) As DataCacheSelectDataResult
			Return CType(Invoke("SelectData", New Object() { cookie, selects })(0), DataCacheSelectDataResult)
		End Function

		Protected Overridable Function UpdateSchema(ByVal cookie As DataCacheCookie, ByVal tables() As DBTable, ByVal dontCreateIfFirstTableNotExits As Boolean) As DataCacheUpdateSchemaResult
			Throw New InvalidOperationException("Schema modification is not allowed")
		End Function

		#Region "ICacheToCacheCommunicationCore Members"

		Private Function ICacheToCacheCommunicationCore_ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements() As ModificationStatement) As DataCacheModificationResult Implements ICacheToCacheCommunicationCore.ModifyData
			Return ModifyData(cookie, dmlStatements)
		End Function

		Private Function ICacheToCacheCommunicationCore_NotifyDirtyTables(ByVal cookie As DataCacheCookie, ParamArray ByVal dirtyTablesNames() As String) As DataCacheResult Implements ICacheToCacheCommunicationCore.NotifyDirtyTables
			Return NotifyDirtyTables(cookie, dirtyTablesNames)
		End Function

		Private Function ICacheToCacheCommunicationCore_ProcessCookie(ByVal cookie As DataCacheCookie) As DataCacheResult Implements ICacheToCacheCommunicationCore.ProcessCookie
			Return ProcessCookie(cookie)
		End Function

		Private Function ICacheToCacheCommunicationCore_SelectData(ByVal cookie As DataCacheCookie, ByVal selects() As SelectStatement) As DataCacheSelectDataResult Implements ICacheToCacheCommunicationCore.SelectData
			Return SelectData(cookie, selects)
		End Function

		Private Function ICacheToCacheCommunicationCore_UpdateSchema(ByVal cookie As DataCacheCookie, ByVal tables() As DBTable, ByVal dontCreateIfFirstTableNotExist As Boolean) As DataCacheUpdateSchemaResult Implements ICacheToCacheCommunicationCore.UpdateSchema
			Return UpdateSchema(cookie, tables, dontCreateIfFirstTableNotExist)
		End Function

		#End Region

		#Region "IDataStore Members"

		Private ReadOnly Property IDataStore_AutoCreateOption() As AutoCreateOption Implements IDataStore.AutoCreateOption
			Get
				Return AutoCreateOption.SchemaAlreadyExists
			End Get
		End Property

		Private Function ModifyData(ParamArray ByVal dmlStatements() As ModificationStatement) As ModificationResult Implements IDataStore.ModifyData
			Return ModifyData(DataCacheCookie.Empty, dmlStatements).ModificationResult
		End Function

		Private Function SelectData(ParamArray ByVal selects() As SelectStatement) As SelectedData Implements IDataStore.SelectData
			Return SelectData(DataCacheCookie.Empty, selects).SelectedData
		End Function

		Private Function IDataStore_UpdateSchema(ByVal dontCreateIfFirstTableNotExist As Boolean, ParamArray ByVal tables() As DBTable) As UpdateSchemaResult Implements IDataStore.UpdateSchema
			Return UpdateSchema(DataCacheCookie.Empty, tables, dontCreateIfFirstTableNotExist).UpdateSchemaResult
		End Function

		#End Region
	End Class
End Namespace