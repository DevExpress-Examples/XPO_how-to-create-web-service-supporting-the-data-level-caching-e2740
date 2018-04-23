using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DXSample.PersistentClasses;

namespace DatabaseUpdater {
    class Program {
        static void Main(string[] args) {
            IDataLayer dal = 
                XpoDefault.GetDataLayer(MSSqlConnectionProvider.GetConnectionString(@".",
                "CachingService"), AutoCreateOption.DatabaseAndSchema);
            UnitOfWork uow = new UnitOfWork(dal);
            uow.UpdateSchema(typeof(Person).Assembly);
            uow.CreateObjectTypeRecords(typeof(Person).Assembly);
            uow.Delete(new XPCollection<Person>(uow));
            uow.CommitChanges();
            new Person(uow) { Name = "John", Age = 26 };
            new Person(uow) { Name = "Bob", Age = 31 };
            uow.CommitChanges();
        }
    }
}
