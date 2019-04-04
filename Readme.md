<!-- default file list -->
*Files to look at*:

* [CachingService.asmx.cs](./CS/CachingService/CachingService.asmx.cs) (VB: [CachingService.asmx.vb](./VB/CachingService/CachingService.asmx.vb))
* [Global.asax.cs](./CS/CachingService/Global.asax.cs) (VB: [Global.asax.vb](./VB/CachingService/Global.asax.vb))
* [Web.config](./CS/CachingService/Web.config) (VB: [Web.config](./VB/CachingService/Web.config))
* [Default.aspx](./CS/Client/Default.aspx) (VB: [Default.aspx](./VB/Client/Default.aspx))
* [Default.aspx.cs](./CS/Client/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Client/Default.aspx.vb))
* [XpoHelper.cs](./CS/Client/XpoHelper.cs) (VB: [XpoHelper.vb](./VB/Client/XpoHelper.vb))
* [CachingServiceDataStore.cs](./CS/ServiceDataStore/CachingServiceDataStore.cs) (VB: [CachingServiceDataStore.vb](./VB/ServiceDataStore/CachingServiceDataStore.vb))
<!-- default file list end -->
# How to create Web Service supporting the data-level caching?


<p>This example demonstrates how to create Web Service exposing methods necessary to implement the ICacheToCacheCommunicationCore interface. This interface is part of the Data Layer Caching mechanism. Please read the <a href="http://community.devexpress.com/blogs/xpo/archive/2006/03/27/session-management-and-caching.aspx"><u>Session Management and Caching</u></a> blog for details.<br />
Before run this example, modify the connection settings in the Global.asax file of the CachingService project. Also, modify the connection settings in the Program.cs file of the DatabaseUpdater project, and run it before running the service.<br />
<strong>See also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/AK3911">How to use XPO with a Web Service</a></p>


<h3>Description</h3>

<p><br />
</p>

<br/>


