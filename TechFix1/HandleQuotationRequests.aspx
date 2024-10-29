<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant.Master" AutoEventWireup="true" CodeBehind="HandleQuotationRequests.aspx.cs" Inherits="TechFix1.HandleQuotationRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/AccountantSheet.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2>Quotation Request</h2>
    
        <div class="form-group">
            <asp:Label ID="lblUserID" runat="server" Text="User ID:" CssClass="form-label"></asp:Label>
            <asp:Label ID="txtUserID" runat="server" CssClass="form-value"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblInventoryID" runat="server" Text="Inventory ID:" CssClass="form-label"></asp:Label>
            <asp:Label ID="txtInventoryID" runat="server" CssClass="form-value"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblItemName" runat="server" Text="Item Name:" CssClass="form-label"></asp:Label>
            <asp:Label ID="txtItemName" runat="server" CssClass="form-value"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblBrandNO" runat="server" Text="Brand NO:" CssClass="form-label"></asp:Label>
            <asp:Label ID="txtBrandNO" runat="server" CssClass="form-value"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblSerialNO" runat="server" Text="Serial NO:" CssClass="form-label"></asp:Label>
            <asp:Label ID="txtSerialNO" runat="server" CssClass="form-value"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblQuantity" runat="server" Text="Quantity:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-input"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblItemPrice" runat="server" Text="Item Price: Pending" CssClass="form-label"></asp:Label>
        </div>

        <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red"></asp:Label>

        <div class="form-actions">
            <asp:Button ID="btnSendRequest" runat="server" Text="Send Request" CssClass="btn btn-primary" OnClick="btnSendRequest_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
        </div>
    </div>

    <!-- Table for Quotation Requests -->
<h3>Sent Quotation Requests</h3>
<asp:GridView ID="gvQuotationRequests" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        <asp:BoundField DataField="RequestDate" HeaderText="Request Date" />
        <asp:BoundField DataField="qStatus" HeaderText="Status" />
    </Columns>
</asp:GridView>
</asp:Content>