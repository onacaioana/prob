<%@ Page Title="OPIS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="OPIS.aspx.cs" Inherits="ProbatiuneApp.OPIS" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="form-wrapper cf">
            <input runat="server" id="SearchTextBox" type="text" placeholder="Cauta angajat..." required>
            <button id="Button3" type="submit" runat="server" onserverclick="SearchButton_Click">Search</button>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent1" ContentPlaceHolderID="MainContent">
    <div class="searchDiv">
          <asp:Panel ID="panel1" runat="server" HorizontalAlign="Center" style="margin-bottom:10px">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Nume" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="CNP" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Caz referat" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" placeholder="Caz supraveghere" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" placeholder="Caz asistenta" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox6" runat="server" placeholder="Consilier" Width="10%" ></asp:TextBox>
            <asp:ImageButton  ID="ImageButton1" ImageUrl="~/Images/add.png" Height="50px" runat="server" OnClick="AddButon_Click"   /> 

        </asp:Panel>
    </div>
        <asp:GridView runat="server" ID="GridView1" ContentPlaceHolderID="Grid_Angajati" CellPadding="4" OnRowDeleted="GridView1_Delete" OnRowDeleting="GridView1_Deleting"
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
        AutoGenerateColumns="False" AllowPaging="True" PageSize="8" OnPageIndexChanging="OnPageIndexChanging" ForeColor="#333333" GridLines="None" style="margin:0 auto" >
      
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
                        <asp:Label ID="lbl_cazReferat" runat="server" Text='<%#Eval("[Caz referat]") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_cazReferat" Width="90%" runat="server" Text='<%#Eval("[Caz referat]") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="Caz supraveghere">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_cazSuprav" runat="server" Text='<%#Eval("[Caz supraveghere]") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_cazSuprav" Width="90%" runat="server" Text='<%#Eval("[Caz supraveghere]") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField> 
                  <asp:TemplateField HeaderText="Caz Asistenta">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_cazAsis" runat="server" Text='<%#Eval("CazAsistenta") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_cazAsis" Width="90%" runat="server" Text='<%#Eval("CazAsistenta") %>'></asp:TextBox>  
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
</asp:Content>