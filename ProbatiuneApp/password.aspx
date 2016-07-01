
<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="password.aspx.cs" Inherits="ProbatiuneApp.password" %>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <section class="featured">

        <div class="login-page">
            <div class="form">
                <input type="password" id="newpass" name="newpass" placeholder="Parola noua" runat="server" />
                <input type="password" id="newpass1" name="newpass1" placeholder="Confirmati parola noua" runat="server" />
                <button id="Button1" onserverclick=" btnsubmit_Click" runat="server">Change Password</button>
            </div>
        </div>
    </section>

</asp:Content>
