<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="ViewQuotations.aspx.cs" Inherits="TechFix1.ViewQuotations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/StyleSheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Quotations</h2>

    <!-- Request Quotations from Accountant -->
    <h3>Request Quotations</h3>
    <asp:GridView ID="GridViewRequestQuotations" runat="server" AutoGenerateColumns="False" CssClass="quotation-table"
            OnRowCommand="GridViewRequestQuotations_RowCommand" DataKeyNames="ID"> 
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Request ID" />
                <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                <asp:BoundField DataField="BrandNO" HeaderText="Brand No" />
                <asp:BoundField DataField="SerialNO" HeaderText="Serial No" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="RequestDate" HeaderText="Request Date" />
                <asp:BoundField DataField="qStatus" HeaderText="Status" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnApproveRequest" runat="server" Text="Approve" CommandName="ApproveRequest" CommandArgument='<%# Eval("ID") %>' CssClass="action-btn btn-approve" />
                        <asp:Button ID="btnRejectRequest" runat="server" Text="Reject" CommandName="RejectRequest" CommandArgument='<%# Eval("ID") %>' CssClass="action-btn btn-reject" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    <!-- Quotations from Suppliers -->
    <h3>Quotations</h3>
    <asp:GridView ID="GridViewQuotations" runat="server" AutoGenerateColumns="False" CssClass="quotation-table"
        OnRowCommand="GridViewQuotations_RowCommand" DataKeyNames="ID" > 
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Quotation ID" />
            <asp:BoundField DataField="InventoryID" HeaderText="Inventory ID" />
            <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
            <asp:BoundField DataField="BrandNO" HeaderText="Brand NO" />
            <asp:BoundField DataField="SerialNO" HeaderText="Serial NO" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="ItemPrice" HeaderText="Item Price" />
            <asp:BoundField DataField="Discount" HeaderText="Discount" />
            <asp:BoundField DataField="qStatus" HeaderText="Status" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnApproveQuotation" runat="server" Text="Approve" CommandName="ApproveQuotation" CommandArgument='<%# Eval("ID") %>' CssClass="action-btn btn-approve" />
                    <asp:Button ID="btnRejectQuotation" runat="server" Text="Reject" CommandName="RejectQuotation" CommandArgument='<%# Eval("ID") %>' CssClass="action-btn btn-reject" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
</asp:Content>