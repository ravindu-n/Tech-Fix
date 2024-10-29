<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="TechFix1.UserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link rel="stylesheet" href="CSS/StyleSheet.css" />

    <script type="text/javascript">
    function confirmDelete() {
        return confirm('Are you sure you want to delete this user?');
    }
    </script>

    <div class="user-management-container">
        <h2>Manage Users</h2>
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" CssClass="user-table"
            DataKeyNames="ID" OnRowEditing="gvUsers_RowEditing" OnRowCancelingEdit="gvUsers_RowCancelingEdit"
            OnRowUpdating="gvUsers_RowUpdating" OnRowCommand="gvUsers_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" />

                <asp:TemplateField HeaderText="Full Name">
                    <ItemTemplate>
                        <asp:Label ID="lblfName" runat="server" Text='<%# Eval("fName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtfName" runat="server" Text='<%# Eval("fName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Username">
                    <ItemTemplate>
                        <asp:Label ID="lbluName" runat="server" Text='<%# Eval("uName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtuName" runat="server" Text='<%# Eval("uName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Role">
                    <ItemTemplate>
                        <asp:Label ID="lbluRole" runat="server" Text='<%# Eval("uRole") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlRole" runat="server">
                            <asp:ListItem Text="manager" Value="manager"></asp:ListItem>
                            <asp:ListItem Text="accountant" Value="accountant"></asp:ListItem>
                            <asp:ListItem Text="supplier" Value="supplier"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" 
                        CommandName="DeleteUser" 
                        CommandArgument='<%# Eval("ID") %>' 
                        OnClientClick="return confirmDelete();"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:CommandField ShowEditButton="true" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnAddUser" runat="server" Text="Add New User" CssClass="btn btn-primary" OnClick="btnAddUser_Click" />
        <br />
        <br />
        <asp:TextBox ID="txtSearch" runat="server" CssClass="search-box" Placeholder="Search users..."></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click" />

        <!-- Edit User Section -->
        <div id="editUserSection" runat="server" visible="false">
            <h3>Edit User</h3>
            <asp:Label ID="lblUserName" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblRole" runat="server" Text="Role"></asp:Label>
            <asp:DropDownList ID="ddlRole" runat="server" CssClass="role-dropdown">
                <asp:ListItem Text="manager" Value="manager"></asp:ListItem>
                <asp:ListItem Text="accountant" Value="accountant"></asp:ListItem>
                <asp:ListItem Text="supplier" Value="supplier"></asp:ListItem>
            </asp:DropDownList>

            <br />

        </div>
    </div>
</asp:Content>
