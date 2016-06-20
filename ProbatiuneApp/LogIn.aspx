
<%@ Page Title="LOG IN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="LogIn.aspx.cs" Inherits="ProbatiuneApp.LogIn" %>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <section class="featured">
        <div class="logIn">

   
        <asp:TextBox ID="txtusername" placeholder="Username" runat="server" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtpassword" placeholder="Password" runat="server" Width="180px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <!--Remember me:
        <asp:CheckBox ID="chkRememberMe" runat="server" /><br />
        --><asp:Button ID="btnsubmit" runat="server" Text="LogIn" Width="81px" onclick="btnsubmit_Click" />
            <br />
         </div>
    </section>
</asp:Content>
