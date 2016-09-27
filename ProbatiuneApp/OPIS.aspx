<%@ Page Title="OPIS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="OPIS.aspx.cs" Inherits="ProbatiuneApp.OPIS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="form-wrapper cf">
            <input runat="server" id="SearchTextBox" type="text" placeholder="Cauta nume..." required>
            <button id="Button3" type="submit" runat="server" onserverclick="SearchButton_Click">Search</button>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent1" ContentPlaceHolderID="MainContent">
    <div class="searchDiv">

          <asp:Panel ID="panel1" runat="server" HorizontalAlign="Center" style="margin-bottom:10px">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Nume Prenume " Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="CNP" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" placeholder="CazReferat" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" placeholder="CazSupraveghere" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBoxInceput" runat="server" TextMode="date" placeholder="Data Inceperii" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBoxAN" runat="server" placeholder="ANI" Width="3%" ></asp:TextBox>
            <asp:TextBox ID="TextBoxLUNA" runat="server" placeholder="LUNI" Width="3%" ></asp:TextBox>
            <asp:TextBox ID="TextBoxZILE" runat="server" placeholder="ZILE" Width="3%" ></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <asp:ImageButton  ID="ImageButton1" ImageUrl="~/Images/add.png" Height="50px" runat="server" OnClick="AddButon_Click"   /> 
        </asp:Panel>
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

   
    <script type="text/javascript">
        function addfuntion() {
            $("#Contain").dialog({
                title: "Adaugare Opis",
                buttons: {
                    Adauga: function () {
                        $(this).dialog('close');
                    }
                }
            });
        };
    </script>
    <div id="Contain" style="display: none">
    <table>
        <tr>
        <td>
        <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="First Name"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="TextBox5" runat="server" Font-Size="14px" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Middle Name"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="TextBox6" runat="server" Font-Size="14px" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Last Name"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="TextBox7" runat="server" Font-Size="14px" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Gender"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="TextBox8" runat="server" Font-Size="14px" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Age"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="TextBox9" runat="server" Font-Size="14px" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="City"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="TextBox10" runat="server" Font-Size="14px" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="Label10" runat="server" CssClass="lbl" Text="State"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="TextBox11" runat="server" Font-Size="14px" ></asp:TextBox>
        </td>
        </tr>
    </table>
    </div>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />

    </div>
        <asp:GridView runat="server" ID="GridView1" Content="Value" IsHitTestVisible="False" ContentPlaceHolderID="Grid_Angajati" 
            CellPadding="2" OnRowDeleted="GridView1_Delete" OnRowDeleting="GridView1_Deleting" HorizontalAlign="Center" style=" text-align:left; margin:0 auto; width: 80%; font-size: 14px;"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
            AutoGenerateColumns="False" AllowPaging="True" PageSize="15" OnPageIndexChanging="OnPageIndexChanging" ForeColor="#333333" GridLines="None"   >
      
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
            <Columns > 
                <asp:TemplateField HeaderText="Nr.Crt">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IdOpis") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Nume Prenume">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Nume" runat="server" Text='<%#Eval("Nume") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Nume" Width="90%" runat="server" Text='<%#Eval("Nume") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                 <asp:TemplateField HeaderText="CNP">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_CNP" runat="server" Text='<%#Eval("CNP") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_CNP" Width="90%" runat="server" Text='<%#Eval("CNP") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField> 
               
                <asp:TemplateField HeaderText="Caz referat">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_cazReferat" runat="server" Text='<%#Eval("CazReferat") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_cazReferat" Width="90%" runat="server" Text='<%#Eval("CazReferat") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="Caz supraveghere">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_cazSuprav" runat="server" Text='<%#Eval("CazSupraveghere") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_cazSuprav" Width="90%" runat="server" Text='<%#Eval("CazSupraveghere") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  

                  <asp:TemplateField HeaderText="Consilier">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Consilier" runat="server" Text='<%#Eval("Consilier") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Consilier" Width="90%" runat="server" Text='<%#Eval("Consilier") %>'></asp:TextBox>  
                    </EditItemTemplate>  
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
    <style>
     .GridView1:hover
        {
            background-color: #FFEB9C;
            border-top: solid;
            color:#9C6500;
        }
 </style>
</asp:Content>