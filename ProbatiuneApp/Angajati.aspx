﻿<%@ Page Title="Angajati" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="Angajati.aspx.cs" Inherits="ProbatiuneApp.Angajati" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="form-wrapper cf">
            <input runat="server" id="SearchTextBox" type="text" placeholder="Cauta angajat..." required>
            <button id="Button1" type="submit" runat="server" onserverclick="SearchButton_Click">Search</button>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent1" ContentPlaceHolderID="MainContent">


    <div class="searchDiv">
        <asp:Panel ID="panel" runat="server" HorizontalAlign="Center" Style="margin-bottom: 10px">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Nume Angajat" Width="13%"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Prenume Angajat" Width="13%"></asp:TextBox>
            <asp:ImageButton ID="BTN_aDD" ImageUrl="~/Images/add.png" Height="50px" runat="server" OnClick="AddButon_Click" />

        </asp:Panel>
    </div>

               
    <script type="text/javascript">
        function myfcn() {
            $("#dialog").dialog({
                title: "Credentiale angajat",
                buttons: {
                    AmInteles: function () {
                        $(this).dialog('close');
                    }
                }
            });

        
        };
       
    </script>
    <div id="dialog" style="display: none">
        <p>Utilizatorul creat va folosi urmatoarele credentiale:<br></p>
        Username:
        <asp:Label ID="UsernameLabel" Text="Username:" runat="server" > </asp:Label><br>
        Parola:
         <asp:Label ID="PassLabel" Text="Password:" runat="server"> </asp:Label><br>
    </div>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />


        <asp:GridView runat="server" ID="GridView1" ContentPlaceHolderID="Grid_Angajati" CellPadding="4" OnRowDeleted="GridView1_Delete" OnRowDeleting="GridView1_Deleting"
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
        style=" text-align:left; margin:0 auto; width: 80%; font-size: 14px;"
        AutoGenerateColumns="False" AllowPaging="True" PageSize="15" OnPageIndexChanging="OnPageIndexChanging" ForeColor="#333333" GridLines="None" >
      
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns> 
                <asp:TemplateField HeaderText=" Nr.crt ">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="   Nume   ">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Nume" runat="server" Text='<%#Eval("Nume") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Nume" Width="90%" runat="server" Text='<%#Eval("Nume") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                 <asp:TemplateField HeaderText="   Prenume   ">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Prenume" runat="server" Text='<%#Eval("Prenume") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Prenume" Width="90%" runat="server" Text='<%#Eval("Prenume") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="   Nr. Active   ">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_totalActiv" runat="server" Text='<%#Eval("activ") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 

                 <asp:TemplateField HeaderText="   Nr. Inactive   ">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_totalInactiv" runat="server" Text='<%#Eval("inactiv") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 
                
                <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:ImageButton  ID="btn_Edit" ImageUrl="~/Images/edit.png" Height="20px" runat="server" CommandName="Edit" />  

                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate> 
                     
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/delete.png" CommandName="Delete"  >
                    <ControlStyle Height="20px"></ControlStyle>
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
</asp:Content>