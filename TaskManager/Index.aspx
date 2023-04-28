<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TaskManager.WebForm2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: 3em;
        }
       .auto-style2 {
            text-align: left;
            font-size: 2em;
            padding-right: 100px;
        }
        .auto-style3 {
            text-align: left;
            width: 100%;
        }
        #GridView1 tr th {
            padding: 10px;
        }
        #GridView1 tr td {
            padding: 10px;
        }
        .Background  
        {  
            background-color: Black;  
            filter: opacity(90%);
            opacity: 0.8;  
        }  
        .Popup  
        {  
            background-color: #FFFFFF;  
            border-width: 3px;  
            border-style: solid;  
            border-color: black;  
            padding-top: 10px;  
            padding-left: 10px;  
            width: 700px;  
            height: 800px;  
        }  
        .lbl  
        {  
            font-size:16px;  
            font-style:italic;  
            font-weight:bold;  
        } 
    </style>
</head>
<body style="width: 100%; height: 100%">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">  </asp:ScriptManager>  
        <div class="auto-style3">
            <h1 class="auto-style1">Task Manager</h1>
            <h1 class="auto-style2">Current Tasks</h1>
            <asp:SqlDataSource 
                ID="SqlDataSource1" 
                runat="server" 
                ConnectionString="<%$ ConnectionStrings:TaskManagerDBConnectionString %>" 
                SelectCommand="SELECT * FROM [Tasks]"
                DeleteCommand="DELETE FROM Tasks WHERE Id = @Id">
            </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnRowDeleting="grid_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="DueDate" HeaderText="DueDate" SortExpression="DueDate" />
                    <asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                    <asp:BoundField DataField="Assignee" HeaderText="Assignee" SortExpression="Assignee" />
                    <asp:BoundField DataField="Project" HeaderText="Project" SortExpression="Project" />

                    <asp:CommandField ButtonType="Image" deleteimageurl="~\Images\delete.png" ShowDeleteButton="true" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="new_task" runat="server" Text="Create New Task" />
            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="new_task"  
                CancelControlID="cancel" BackgroundCssClass="Background">  
            </cc1:ModalPopupExtender>  
            <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">  
                <iframe style=" width: 600px; height: 750px;" id="irm1" src="NewTask.aspx" runat="server"></iframe>  
               <br/>
                <asp:Button ID="cancel" runat="server" Text="Close" OnClick="refresh_Click" />
            </asp:Panel>
            <asp:Button ID="refresh" runat="server" Text="Refresh" OnClick="refresh_Click" />
        </div>
    </form>
</body>
</html>
