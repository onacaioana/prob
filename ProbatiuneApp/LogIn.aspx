
<%@ Page Title="LOG IN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="LogIn.aspx.cs" Inherits="ProbatiuneApp.LogIn" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    
    <section class="featured">

        <div class="login-page">
            <div class="form">

                <input type="text" id="txtusername" name="txtusername" placeholder="Username" runat="server" />
                <input type="password" id="txtpassword" placeholder="Password" runat="server" />
                <button onserverclick=" btnsubmit_Click" runat="server">Sign In</button>
            </div>

        <script type="text/javascript">
            function myfcn() {
                $("#dialog").dialog({
                    title: "Atentie!",
                    buttons: {
                        AmInteles: function () {
                            $(this).dialog('close');
                        }
                    }
                });
            };
    </script>
    <div id="dialog" style="display: none">
         <asp:Label ID="LabelText" Text="" runat="server" > </asp:Label><br>
    </div>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />


        </div>
    </section>

</asp:Content>
