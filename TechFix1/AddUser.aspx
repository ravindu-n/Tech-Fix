<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="TechFix1.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="CSS/StyleSheet.css" />

<div class="add-user-container">
    <h2>Add New User</h2>

    <!-- Error Message Label -->
    <asp:Label ID="lblError" runat="server" CssClass="error-label" Visible="false"></asp:Label><br />

    <asp:TextBox ID="txtfName" runat="server" placeholder="Full Name" CssClass="input-text"></asp:TextBox><br />
    <asp:TextBox ID="txtuName" runat="server" placeholder="Username" CssClass="input-text"></asp:TextBox><br />

    <!-- Replace TextBox with DropDownList for Role -->
    <asp:DropDownList ID="ddlRole" runat="server" CssClass="input-text">
        <asp:ListItem Text="Select Role" Value="" Selected="True" />
        <asp:ListItem Text="manager" Value="manager" />
        <asp:ListItem Text="accountant" Value="accountant" />
        <asp:ListItem Text="supplier" Value="supplier" />
    </asp:DropDownList><br />

    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="input-text"></asp:TextBox><br />

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click" />
</div>
</asp:Content>
