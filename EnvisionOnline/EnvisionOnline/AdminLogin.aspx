<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="AdminLogin" %>

<!DOCTYPE html>
<!--[if lt IE 7 ]> <html lang="en" class="ie6 ielt8"> <![endif]-->
<!--[if IE 7 ]>    <html lang="en" class="ie7 ielt8"> <![endif]-->
<!--[if IE 8 ]>   <html lang="en" class="ie8"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!-->  
<html lang="en"> <!--<![endif]-->
<head id="Head1" runat="server">
	<title>Login</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        .btnLogin
        {
	        float:right;
	        height:30px;
	        border:solid 1px #808080;
        }
        .txtBox
        {
	        background:#fff;
	        padding:5px;
	        width:250px;
	        border:solid 1px #808080;
        }
        .textWhite
        {
            color: White;
            }
        .failureNotification
        {
            font-size: 1.2em;
            color: Red;
        }
        div.accountInfo
        {
            width: 40%;
        }
        fieldset.login label, fieldset.register label, fieldset.changePassword label
        {
            display: block;
        }

        input.textEntry 
        {
            width: 80%;
            border: 1px solid #ccc;
        }
        input.passwordEntry 
        {
            width: 80%;
            border: 1px solid #ccc;
        }
        fieldset label.inline 
        {
            display: inline;
        }
        .submitButton
        {
            text-align: right;
            padding-right: 10px;
        }

        .main
        {
            padding: 0px 12px;
            margin: 12px 8px 8px 8px;
            min-height: 420px;
        }
    </style>
</head>
<body style="background-image:url(Resources/background.jpg);">
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-TelerikCdn="Disabled">
		<Scripts>
			<%--Needed for JavaScript IntelliSense in VS2010--%>
			<%--For VS2008 replace RadScriptManager with ScriptManager--%>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<script type="text/javascript">
	    //Put your JavaScript code here.
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="LoginButton">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="LoginButton" />
                    <telerik:AjaxUpdatedControl ControlID="lblAlert" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <div class="main">
            <div class="container">
        <h2 class="textWhite">
            Login
        </h2>
        <p class="textWhite">
            Please enter your username and password.
        </p>
        <span class="failureNotification">
            <asp:Literal ID="FailureText" runat="server"></asp:Literal>
        </span>
        <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                ValidationGroup="LoginUserValidationGroup"/>
        <div class="accountInfo">
            <fieldset class="login">
                <legend class="textWhite">Account Information</legend>
                <p>
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="textWhite">Username:</asp:Label>
                    <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                            CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="textWhite">Password:</asp:Label>
                    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"/>
                </p>
            </fieldset>
        </div>
        <p>
            <asp:Label ID="lblAlert" runat="server" ForeColor="Red" Visible="false">***Username or Pasword don't match!!!***</asp:Label>
        </p>
        </div><!-- container -->
	
        </div>
   </form>
</body>
</html>
