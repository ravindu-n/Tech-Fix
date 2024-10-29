<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="ManagerPage.aspx.cs" Inherits="TechFix1.ManagerPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    html, body {
        height: 100%; /* Ensure the background covers the full viewport */
        margin: 0; /* Remove default margins */
        padding: 0;
    }

    html {
        background-image: url('<%= ResolveUrl("~/Images/BGI.jpg") %>'); /* Corrected image path */
        background-size: cover;
        background-repeat: no-repeat;
        background-position: center center;
        background-attachment: fixed; /* Ensure background stays fixed */
    }

    body, div, .container {
        background-color: transparent !important; /* Remove any white background from container elements */
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
