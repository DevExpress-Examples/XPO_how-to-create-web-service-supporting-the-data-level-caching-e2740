using System;
using DevExpress.Xpo.DB;
using System.Web.Services;
using DevExpress.Xpo.DB.Helpers;
using System.Web.Services.Protocols;

namespace DXSample.Proxy {
    [WebServiceBinding(Namespace = "http://devexpress.example/")]
    public class CachingDataStore : SoapHttpClientProtocol, ICachedDataStore {
        public CachingDataStore(string url)
            : base() {
            Url = url;
        }

        [SoapDocumentMethod("http://devexpress.example/ModifyData",
            RequestNamespace = "http://devexpress.example/",
            ResponseNamespace = "http://devexpress.example/")]
        public virtual DataCacheModificationResult ModifyData(DataCacheCookie cookie,
            ModificationStatement[] dmlStatements) {
            return (DataCacheModificationResult)Invoke("ModifyData",
                new object[] { cookie, dmlStatements })[0];
        }

        [SoapDocumentMethod("http://devexpress.example/NotifyDirtyTables",
            RequestNamespace = "http://devexpress.example/",
            ResponseNamespace = "http://devexpress.example/")]
        public virtual DataCacheResult NotifyDirtyTables(DataCacheCookie cookie,
            params string[] dirtyTablesNames) {
            return (DataCacheResult)Invoke("NotifyDirtyTables",
                new object[] { cookie, dirtyTablesNames })[0];
        }

        [SoapDocumentMethod("http://devexpress.example/ProcessCookie",
            RequestNamespace = "http://devexpress.example/",
            ResponseNamespace = "http://devexpress.example/")]
        public virtual DataCacheResult ProcessCookie(DataCacheCookie cookie) {
            return (DataCacheResult)Invoke("ProcessCookie", new object[] { cookie })[0];
        }

        [SoapDocumentMethod("http://devexpress.example/SelectData",
            RequestNamespace = "http://devexpress.example/",
            ResponseNamespace = "http://devexpress.example/")]
        public virtual DataCacheSelectDataResult SelectData(DataCacheCookie cookie,
            SelectStatement[] selects) {
            return (DataCacheSelectDataResult)Invoke("SelectData", new object[] { cookie, selects })[0];
        }

        protected virtual DataCacheUpdateSchemaResult UpdateSchema(DataCacheCookie cookie,
            DBTable[] tables, bool dontCreateIfFirstTableNotExits) {
            throw new InvalidOperationException("Schema modification is not allowed");
        }

        #region ICacheToCacheCommunicationCore Members

        DataCacheModificationResult ICacheToCacheCommunicationCore.ModifyData(DataCacheCookie cookie,
            ModificationStatement[] dmlStatements) {
            return ModifyData(cookie, dmlStatements);
        }

        DataCacheResult ICacheToCacheCommunicationCore.NotifyDirtyTables(DataCacheCookie cookie, 
            params string[] dirtyTablesNames) {
            return NotifyDirtyTables(cookie, dirtyTablesNames);
        }

        DataCacheResult ICacheToCacheCommunicationCore.ProcessCookie(DataCacheCookie cookie) {
            return ProcessCookie(cookie);
        }

        DataCacheSelectDataResult ICacheToCacheCommunicationCore.SelectData(DataCacheCookie cookie,
            SelectStatement[] selects) {
            return SelectData(cookie, selects);
        }

        DataCacheUpdateSchemaResult ICacheToCacheCommunicationCore.UpdateSchema(DataCacheCookie cookie,
            DBTable[] tables, bool dontCreateIfFirstTableNotExist) {
            return UpdateSchema(cookie, tables, dontCreateIfFirstTableNotExist);
        }

        #endregion

        #region IDataStore Members

        AutoCreateOption IDataStore.AutoCreateOption {
            get { return AutoCreateOption.SchemaAlreadyExists; }
        }

        ModificationResult IDataStore.ModifyData(params ModificationStatement[] dmlStatements) {
            return ModifyData(DataCacheCookie.Empty, dmlStatements).ModificationResult;
        }

        SelectedData IDataStore.SelectData(params SelectStatement[] selects) {
            return SelectData(DataCacheCookie.Empty, selects).SelectedData;
        }

        UpdateSchemaResult IDataStore.UpdateSchema(bool dontCreateIfFirstTableNotExist, 
            params DBTable[] tables) {
            return UpdateSchema(DataCacheCookie.Empty, tables, 
                dontCreateIfFirstTableNotExist).UpdateSchemaResult;
        }

        #endregion
    }
}