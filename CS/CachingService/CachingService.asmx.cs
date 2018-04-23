using System;
using DevExpress.Xpo.DB;
using System.Web.Services;
using System.ComponentModel;
using DevExpress.Xpo.DB.Helpers;

namespace DXSample.Service {
    [WebService(Namespace = "http://devexpress.example/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class CachingService : WebService {
        [WebMethod]
        public DataCacheModificationResult ModifyData(DataCacheCookie cookie,
            ModificationStatement[] dmlStatements) {
            return ((DataCacheRoot)Application["DataStore"]).ModifyData(cookie, dmlStatements);
        }

        [WebMethod]
        public DataCacheResult NotifyDirtyTables(DataCacheCookie cookie,
            params string[] dirtyTablesNames) {
            return ((DataCacheRoot)Application["DataStore"]).NotifyDirtyTables(cookie, dirtyTablesNames);
        }

        [WebMethod]
        public DataCacheResult ProcessCookie(DataCacheCookie cookie) {
            return ((DataCacheRoot)Application["DataStore"]).ProcessCookie(cookie);
        }

        [WebMethod]
        public DataCacheSelectDataResult SelectData(DataCacheCookie cookie, SelectStatement[] selects) {
            return ((DataCacheRoot)Application["DataStore"]).SelectData(cookie, selects);
        }
    }
}
