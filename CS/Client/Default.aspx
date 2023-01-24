<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Client._Default" %>

<%@ Register 
    Assembly="DevExpress.Xpo.v13.1, Version=13.1.14.0, PublicKeyToken=b88d1754d700e49a, Culture=neutral" 
    Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, PublicKeyToken=b88d1754d700e49a, Culture=neutral" 
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:XpoDataSource ID="personSource" runat="server" TypeName="DXSample.PersistentClasses.Person" />
        <dx:ASPxGridView runat="server" DataSourceID="personSource" KeyFieldName="Oid">
            <Columns>
                <dx:GridViewCommandColumn>
                    <NewButton Visible="true" />
                    <EditButton Visible="true" />
                    <CancelButton Visible="true" />
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="Name" />
                <dx:GridViewDataTextColumn FieldName="Age" />
            </Columns>
        </dx:ASPxGridView>
    </div>
    </form>
</body>
</html>
