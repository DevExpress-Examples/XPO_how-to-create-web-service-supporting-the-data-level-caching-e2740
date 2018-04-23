using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.Configuration;

namespace CachingService {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {
            string connectionString = ConfigurationManager.ConnectionStrings["DXConnectionString"].ConnectionString;
            IDataStore provider = XpoDefault.GetConnectionProvider(connectionString, 
                AutoCreateOption.None);
            DataCacheRoot root = new DataCacheRoot(provider);
            Application.Add("DataStore", root);
        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {

        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}