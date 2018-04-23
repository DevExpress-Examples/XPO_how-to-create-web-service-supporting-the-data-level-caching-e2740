using DXSample.Proxy;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using DXSample.PersistentClasses;

namespace DXSample {
    public static class XpoHelper {
        public static Session GetNewSesion() {
            return new Session(DataLayer);
        }

        public static UnitOfWork GetNewUnitOfWork() {
            return new UnitOfWork(DataLayer);
        }

        static readonly object lockObject = new object();

        static volatile IDataLayer fDataLayer;
        static IDataLayer DataLayer {
            get {
                if (fDataLayer == null)
                    lock (lockObject) {
                        if (fDataLayer == null) fDataLayer = GetDataLayer();
                    }
                return fDataLayer;
            }
        }

        static IDataLayer GetDataLayer() {
            XpoDefault.Session = null;
            XPDictionary dict = new ReflectionDictionary();
            dict.GetDataStoreSchema(typeof(Person).Assembly);
            return new ThreadSafeDataLayer(dict, new DataCacheNode(new CachingDataStore("http://localhost:1556/CachingService.asmx")));
        }
    }
}