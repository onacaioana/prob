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
    <h3>TABEL CAZURI</h3>
    <div class="searchDiv">
          <asp:Label ID="lblMessage" runat="Server" ForeColor="red" EnableViewState="False"></asp:Label>
    </div>
        <asp:GridView runat="server" ID="GridView1" ContentPlaceHolderID="Grid_Angajati"  BackColor="#DEBA84" BorderColor="#DEBA84" HorizontalAlign="Left" VerticalAlign =" 50px"  BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" AutoGenerateColumns="False" >
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
                <asp:BoundField DataField="IDCazz" HeaderText="ID"   />
                <asp:BoundField DataField="Nume" HeaderText="Nume "   />
                <asp:BoundField DataField="Prenume" HeaderText="Prenume"  />
                <asp:BoundField DataField="NrDosar" HeaderText="Nr.Dosar " />
                <asp:BoundField DataField="Start" HeaderText="StartDate"  />
                <asp:BoundField DataField="TheEnd" HeaderText="StopDate" />
                <asp:BoundField DataField="Observatii" HeaderText="Observatii"  />
                <asp:BoundField DataField="Nume" HeaderText="Nume Angajat"  />
                <asp:BoundField DataField="Prenume" HeaderText="Prenume Angajat"  />
                <asp:HyperLinkField DataNavigateUrlFields="Nume" DataNavigateUrlFormatString="edit.aspx?Nume={0}" Text="Edit" />
                <asp:ButtonField   ButtonType="Link"  Text="Delete" />
            </Columns>
        </asp:GridView>

  

</asp:Content>