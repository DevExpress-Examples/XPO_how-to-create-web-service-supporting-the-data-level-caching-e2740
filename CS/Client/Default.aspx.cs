using System;
using DXSample;

namespace Client {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            personSource.Session = XpoHelper.GetNewSesion();
        }
    }
}
