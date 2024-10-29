<%@ Page Title="" Language="C#" MasterPageFile="~/Supplier.Master" AutoEventWireup="true" CodeBehind="EnterQuotationDetails.aspx.cs" Inherits="TechFix1.EnterQuotationDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/SupplierStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Enter Quotation Details</h2>
    <div class="quotation-details">
        <asp:Label ID="lblRequestQuotationId" runat="server" Text="Request Quotation ID: " CssClass="label"></asp:Label>
        <asp:Label ID="lblRequestQuotationIdValue" runat="server" CssClass="value"></asp:Label>

        <asp:Label ID="lblInventoryID" runat="server" Text="Inventory ID: " CssClass="label"></asp:Label>
        <asp:Label ID="lblInventoryIDValue" runat="server" CssClass="value"></asp:Label>

        <asp:Label ID="lblUserID" runat="server" Text="User ID: " CssClass="label"></asp:Label>
        <asp:Label ID="lblUserIDValue" runat="server" CssClass="value"></asp:Label>

        <asp:Label ID="lblItemName" runat="server" Text="Item Name: " CssClass="label"></asp:Label>
        <asp:Label ID="lblItemNameValue" runat="server" CssClass="value"></asp:Label>

        <asp:Label ID="lblBrandNO" runat="server" Text="Brand NO: " CssClass="label"></asp:Label>
        <asp:Label ID="lblBrandNOValue" runat="server" CssClass="value"></asp:Label>

        <asp:Label ID="lblSerialNO" runat="server" Text="Serial NO: " CssClass="label"></asp:Label>
        <asp:Label ID="lblSerialNOValue" runat="server" CssClass="value"></asp:Label>

        <asp:Label ID="lblQuantity" runat="server" Text="Quantity: " CssClass="label"></asp:Label>
        <asp:Label ID="lblQuantityValue" runat="server" CssClass="value"></asp:Label>

        <asp:Label ID="lblItemPrice" runat="server" Text="Item Price: " CssClass="label"></asp:Label>
        <asp:TextBox ID="txtItemPrice" runat="server" CssClass="text-box"></asp:TextBox>

        <asp:Label ID="lblDiscount" runat="server" Text="Discount: " CssClass="label"></asp:Label>
        <asp:TextBox ID="txtDiscount" runat="server" CssClass="text-box"></asp:TextBox>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="submit-btn" />
        <asp:Label ID="lblMessage" runat="server" CssClass="message" Text=""></asp:Label>
    </div>
</asp:Content>