<%@ Page Title="" Language="C#" MasterPageFile="~/Supplier.Master" AutoEventWireup="true" CodeBehind="ViewQuotationRequests.aspx.cs" Inherits="TechFix1.ViewQuotationRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/SupplierStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Approved Quotation Requests</h2>
        <asp:GridView ID="GridViewApprovedRequests" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Request ID" />
                <asp:BoundField DataField="RequestDate" HeaderText="Request Date" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="InventoryID" HeaderText="Inventory ID" />
                <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                <asp:BoundField DataField="BrandNO" HeaderText="Brand" />
                <asp:BoundField DataField="SerialNO" HeaderText="Serial No" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblQuotationId" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CommandName="Submit" CommandArgument='<%# Eval("ID") %>' OnClick="SubmitQuotation" CssClass="action-btn" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>