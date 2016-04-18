<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProbatiuneApp._Default" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <asp:ImageButton ID="SearchButton" runat="server" Height="24px" ImageUrl="~/Images/images.jpg" Width="24px" OnClick="SearchButton_Click" />
            <asp:TextBox ID="SearchTextBox" runat="server" Height="18px" Width="157px" OnTextChanged="SearchTextBox_TextChanged"></asp:TextBox>
         </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="searchDiv">
          <asp:Label ID="lblMessage" runat="Server" ForeColor="red" EnableViewState="False"></asp:Label>
        <asp:Panel ID="panel" runat="server" OnLoad="Panel_Load">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Nume Caz" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Prenume Caz" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Nr. Dosar" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" placeholder="Data inceperii" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" placeholder="Data final" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox6" runat="server" placeholder="Observatii" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox7" runat="server" placeholder="Nume Angajat" Width="10%" ></asp:TextBox>
            <asp:TextBox ID="TextBox8" runat="server" placeholder="Prenume Angajat" Width="10%" ></asp:TextBox>
            <asp:Button ID="AddButon" runat="server" Height="41px" Text="Adauga" Width="85px" OnClick="AddButon_Click" />

        </asp:Panel>
    </div>
    <asp:GridView runat="server" ID="GridView1" ContentPlaceHolderID="Grid_Cazuri"  BackColor="#DEBA84" BorderColor="#DEBA84" HorizontalAlign="Left" 
        VerticalAlign =" 50px"  BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
         OnRowDeleted="GridView1_Delete" OnRowDeleting="GridView1_Deleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
         OnRowUpdating="GridView1_RowUpdating"  AutoGenerateColumns="False" AllowPaging="true" PageSize="8" OnPageIndexChanging="OnPageIndexChanging" >

            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
            <Columns> 
                <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDCazz") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Nume">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Nume" runat="server" Text='<%#Eval("Nume") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Nume" Width="90%" runat="server" Text='<%#Eval("Nume") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                 <asp:TemplateField HeaderText="Prenume">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Prenume" runat="server" Text='<%#Eval("Prenume") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Prenume" Width="90%" runat="server" Text='<%#Eval("Prenume") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField> 
               
                <asp:TemplateField HeaderText="NrDosar">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_NrDosar" runat="server" Text='<%#Eval("NrDosar") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_NrDosar" Width="90%" runat="server" Text='<%#Eval("NrDosar") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="StartDate">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Start" runat="server" Text='<%#Eval("Start") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Start" Width="90%" runat="server" Text='<%#Eval("Start") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField> 
                  <asp:TemplateField HeaderText="StopDate">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_TheEnd" runat="server" Text='<%#Eval("TheEnd") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_TheEnd" Width="90%" runat="server" Text='<%#Eval("TheEnd") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  

                  <asp:TemplateField HeaderText="Observatii">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Observatii" runat="server" Text='<%#Eval("Observatii") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Observatii" Width="90%" runat="server" Text='<%#Eval("Observatii") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField> 

                
                  <asp:TemplateField HeaderText="Nume Angajat">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_angNume" runat="server" Text='<%#Eval("NumeAng") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_angNume" Width="90%" runat="server" Text='<%#Eval("NumeAng") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>

                  <asp:TemplateField HeaderText="Prenume Angajat">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_angPrenume" runat="server" Text='<%#Eval("PrenumeAng") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_angPrenume" Width="90%" runat="server" Text='<%#Eval("PrenumeAng") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                       
                </asp:TemplateField>
                <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate> 
                     
                </asp:TemplateField>
                <asp:ButtonField CommandName="Delete" HeaderText="Delete" Text="Sterge" />
            </Columns>
        </asp:GridView>
     

</asp:Content>