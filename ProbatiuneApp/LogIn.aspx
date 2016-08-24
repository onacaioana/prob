
<%@ Page Title="LOG IN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="LogIn.aspx.cs" Inherits="ProbatiuneApp.LogIn" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    
    <section class="featured">

        <div class="login-page">
            <div class="form">

                <input type="text" id="txtusername" name="txtusername" placeholder="Username" runat="server" />
                <input type="password" id="txtpassword" placeholder="Password" runat="server" />
                <button onserverclick=" btnsubmit_Click" runat="server">Sign In</button>
            </div>
        </div>
    </section>

</asp:Content>
