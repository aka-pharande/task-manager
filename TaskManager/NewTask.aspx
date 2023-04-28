<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewTask.aspx.cs" Inherits="TaskManager.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: justify;
            width: 100%;
        }
        .auto-style2 {
            width: 100%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server" aria-orientation="horizontal">
        <div>
            <h1 class="auto-style2">New Task</h1>
        </div>
        <div class="auto-style1">

            <div> 
                <asp:Label ID="label_type" width="100px" runat="server" Text="Type"></asp:Label>
                <asp:DropDownList ID="task_type" runat="server" Height="16px" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="type_changed">
                    <asp:ListItem>Generic</asp:ListItem>
                    <asp:ListItem>Personal</asp:ListItem>
                    <asp:ListItem>Work</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <br />

            <div> 
                <asp:Label ID="label_name" width="100px" runat="server" Text="Name*"></asp:Label>
                <asp:TextBox ID="task_name" runat="server" style="min-width:300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="task_name" ErrorMessage="Name can not be empty!" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <br />

            <div> 
                <asp:Label ID="label_description" width="100px" runat="server" Text="Description"></asp:Label>
                <asp:TextBox ID="task_description" runat="server" TextMode="MultiLine" Rows="10" style="min-width:300px"></asp:TextBox>
            </div>

            <br />

            <div> 
                <asp:Label ID="label_due_date" width="100px" runat="server" Text="Due Date"></asp:Label>
                <asp:TextBox ID="task_due_date" textmode="Date" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="task_due_date" ErrorMessage="Due date can not be in the past!" ForeColor="Red" Operator="GreaterThanEqual"></asp:CompareValidator>
            </div>

            <br />

            <div> 
                <asp:Label ID="label_priority" width="100px" runat="server" Text="Priority"></asp:Label>
                <asp:DropDownList ID="task_priority" runat="server" Height="16px" Width="100px">
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                </asp:DropDownList>
            </div>

            <br />

            <div> 
                <asp:Label ID="label_status" width="100px" runat="server" Text="Status"></asp:Label>
                <asp:DropDownList ID="task_status" runat="server" Height="16px" Width="100px">
                    <asp:ListItem Value="NotStarted">Not Started</asp:ListItem>
                    <asp:ListItem Value="InProgress">In Progress</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                    <asp:ListItem>Postponed</asp:ListItem>
                </asp:DropDownList>
            </div>

            <br />

            <div> 
                <asp:Label ID="label1" width="100px" runat="server" Text="Location"></asp:Label>
                <asp:TextBox ID="task_location" runat="server" Enabled="false"></asp:TextBox>
            </div>

            <br />

            <div> 
                <asp:Label ID="label2" width="100px" runat="server" Text="Assignee"></asp:Label>
                <asp:TextBox ID="task_assignee" runat="server" Enabled="false"></asp:TextBox>
            </div>

            <br />

            <div> 
                <asp:Label ID="label3" width="100px" runat="server" Text="Project"></asp:Label>
                <asp:TextBox ID="task_project" runat="server" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <br />

        </div>
        <asp:Button ID="create" runat="server" OnClick="create_Click" Text="Create" />
        <asp:Label ID="result" runat="server"></asp:Label>
    </form>
</body>
</html>
