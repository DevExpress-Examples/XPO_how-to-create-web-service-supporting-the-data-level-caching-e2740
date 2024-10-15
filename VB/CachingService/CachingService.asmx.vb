Imports DevExpress.Xpo.DB
Imports System.Web.Services
Imports System.ComponentModel
Imports DevExpress.Xpo.DB.Helpers

Namespace DXSample.Service

    <WebService([Namespace]:="http://devexpress.example/")>
    <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
    <ToolboxItem(False)>
    Public Class CachingService
        Inherits WebService

        <WebMethod>
        Public Function ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements As ModificationStatement()) As DataCacheModificationResult
            Return CType(Application("DataStore"), DataCacheRoot).ModifyData(cookie, dmlStatements)
        End Function

        <WebMethod>
        Public Function NotifyDirtyTables(ByVal cookie As DataCacheCookie, ParamArray dirtyTablesNames As String()) As DataCacheResult
            Return CType(Application("DataStore"), DataCacheRoot).NotifyDirtyTables(cookie, dirtyTablesNames)
        End Function

        <WebMethod>
        Public Function ProcessCookie(ByVal cookie As DataCacheCookie) As DataCacheResult
            Return CType(Application("DataStore"), DataCacheRoot).ProcessCookie(cookie)
        End Function

        <WebMethod>
        Public Function SelectData(ByVal cookie As DataCacheCookie, ByVal selects As SelectStatement()) As DataCacheSelectDataResult
            Return CType(Application("DataStore"), DataCacheRoot).SelectData(cookie, selects)
        End Function
    End Class
End Namespace
