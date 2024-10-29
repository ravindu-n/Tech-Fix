<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant.Master" AutoEventWireup="true" CodeBehind="EditInventory.aspx.cs" Inherits="TechFix1.EditInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/AccountantSheet.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <<div class="form-container">
        <h2>Edit Inventory</h2>
    
        <asp:HiddenField ID="hfID" runat="server" />

        <div class="form-group">
            <asp:Label ID="lblUserID" runat="server" Text="User ID:" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlUserID" runat="server" CssClass="form-input"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblItemName" runat="server" Text="Item Name:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtItemName" runat="server" CssClass="form-input"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblBrandNO" runat="server" Text="Brand NO:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtBrandNO" runat="server" CssClass="form-input"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblSerialNO" runat="server" Text="Serial NO:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtSerialNO" runat="server" CssClass="form-input"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblQuantity" runat="server" Text="Quantity:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-input"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblItemPrice" runat="server" Text="Item Price:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtItemPrice" runat="server" CssClass="form-input"></asp:TextBox>
        </div>

        <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red"></asp:Label>

        <div class="form-actions">
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>