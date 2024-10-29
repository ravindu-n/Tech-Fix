<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TechFix1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - TechFix</title>
    <!-- Link to the external CSS file -->
    <link rel="stylesheet" href="CSS/StyleSheet.css" />
    <script>
        function togglePasswordVisibility() {
            var passwordField = document.getElementById('<%= txtPassword.ClientID %>');
            if (passwordField.type === "password") {
                passwordField.type = "text";
            } else {
                passwordField.type = "password";
            }
        }
    </script>
</head>
<body>
    <!-- Header Section -->
    <header class="header">
        <div class="header-content">
        <img src="Images/Logo.png" alt="TechFix Logo" class="logo" />
        <h1>TechFix</h1>
            </div>
    </header>

    <!-- Main Content -->
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control"></asp:TextBox>

            <!-- Checkbox to show/hide password -->
            <div class="checkbox-container">
                <asp:CheckBox ID="chkShowPassword" runat="server" Text="Show Password" OnClick="togglePasswordVisibility()" CssClass="checkbox-label" />
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
        </div>
    </form>

    <!-- Footer Section -->
    <footer class="footer">
        <p>&copy; 2024 TechFix. All rights reserved.</p>
    </footer>
</body>
</html>
