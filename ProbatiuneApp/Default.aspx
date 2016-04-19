<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProbatiuneApp._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <nav>
            <ul id="menu">
                <li><a id="A1" runat="server" href="~/">Vizualizare</a></li>
                <li><a id="A2" runat="server" href="~/Adaugare.aspx">Adaugare</a></li>
                <li><button id="exportButton" onclick="Export_OnClick">Export</button></li>
            </ul>
        </nav>
        <div class="content-wrapper" style="padding-left:30px" >
            <asp:TextBox ID="SearchTextBox" runat="server" placeholder="Cautare Nume/Prenume" Height="23px" Width="409px" BorderColor="Maroon" style="margin:auto 15px 15px 300px;position:static;" BackColor="#ffcccc" OnTextChanged="SearchTextBox_TextChanged"></asp:TextBox>
            <asp:ImageButton ID="SearchButton" runat="server" Height="26px" ImageUrl="~/Images/images.jpg" OnClick="SearchButton_Click" Width="32px" />
            <asp:TextBox ID="TextBox9" runat="server" placeholder="Cautare Numar dosar" Height="23px" Width="409px" BorderColor="Maroon" style="margin:auto 15px auto 300px;position:static;" BackColor="#ffcccc" OnTextChanged="SearchTextBox_TextChanged"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/Images/images.jpg" OnClick="SearchButton_Click" Width="32px" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
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
            <asp:ImageButton  ID="BTN_aDD" ImageUrl="~/Images/add.png" Height="50px" runat="server" OnClick="AddButon_Click" /> 

        </asp:Panel>
    </div>

        <asp:GridView runat="server" ID="GridView1" ContentPlaceHolderID="Grid_Cazuri" HorizontalAlign="Left" 
        VerticalAlign =" 50px" CellPadding="4"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
         OnRowDeleted="GridView1_Delete" OnRowDeleting="GridView1_Deleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
         OnRowUpdating="GridView1_RowUpdating"  AutoGenerateColumns="False" AllowPaging="True" PageSize="8" OnPageIndexChanging="OnPageIndexChanging" ForeColor="#333333" GridLines="None" >

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