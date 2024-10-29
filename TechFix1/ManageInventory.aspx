<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant.Master" AutoEventWireup="true" CodeBehind="ManageInventory.aspx.cs" Inherits="TechFix1.ManageInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="CSS/AccountantSheet.css" />
        <script type="text/javascript">
    function confirmDelete() {
        return confirm("Are you sure you want to delete this item?");
    }
        </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Inventory</h2>

    <!-- Inventory Form for Adding and Editing -->
    <div class="form-section">
        <asp:Label ID="lblID" runat="server" Text="ID" Visible="false"></asp:Label>
        <asp:HiddenField ID="hfID" runat="server" />

        <asp:Label ID="lblUserID" runat="server" Text="User ID:"></asp:Label>
        <asp:DropDownList ID="ddlUserID" runat="server"></asp:DropDownList>
        <br />

        <asp:Label ID="lblItemName" runat="server" Text="Item Name:"></asp:Label>
        <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblBrandNO" runat="server" Text="Brand NO:"></asp:Label>
        <asp:TextBox ID="txtBrandNO" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblSerialNO" runat="server" Text="Serial NO:"></asp:Label>
        <asp:TextBox ID="txtSerialNO" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblItemPrice" runat="server" Text="Item Price:"></asp:Label>
        <asp:TextBox ID="txtItemPrice" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red"></asp:Label> <!-- Validation message label -->
        <br />

        <asp:Button ID="btnAddOrUpdate" runat="server" Text="Add" OnClick="btnAddOrUpdate_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
    </div>

    <!-- Inventory GridView -->
    <asp:GridView ID="gvInventory" CssClass="gridview" runat="server" AutoGenerateColumns="False" OnRowEditing="gvInventory_RowEditing" OnRowDeleting="gvInventory_RowDeleting" OnRowCommand="gvInventory_RowCommand" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
            <asp:BoundField DataField="BrandNO" HeaderText="Brand NO" />
            <asp:BoundField DataField="SerialNO" HeaderText="Serial NO" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="ItemPrice" HeaderText="Item Price" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />

            <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnRequest" runat="server" CommandName="Request" CommandArgument='<%# Eval("ID") %>' Text="Request" />
            </ItemTemplate>
        </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>