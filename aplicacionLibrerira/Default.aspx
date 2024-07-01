<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="aplicacionLibrerira._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
    <div class="row">
        <section class="col-md-4" aria-labelledby="gettingStartedTitle">
            <form id="searchForm">
                <label id="lblSeleccionar" for="seleccionar">Seleccionar:</label>
             <select id="slcAutor" value="Autor" runat="server">
               <option id="opAutor" value="Autor">Autor</option>
               <option id="opTitulo" value="Titulo">Titulo</option>
               <option id="opAño" value="Año">Año</option>
             </select><br><br>
                <input type="text" id="txtData" runat="server" name="searchData" placeholder="Ingresar dato a buscar">
                 <asp:Button ID="txtButton" runat="server" Text="Buscar" OnClick="button1_Click" Width="84px" />
            </form>  
            <asp:Button ID="deleteButton" runat="server" OnClick="buttonEliminar_Click" Text="Borrar" Width="84px" />
        </section>
        
    <div class="row">
        <div class="col-12">
            <h3>Lista de libros</h3>
            <asp:GridView ID="gvLibros" runat="server" Width="80%" BorderWidth="2px" CellSpacing="15"
                AutoGenerateColumns="true">         
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                        <asp:CheckBox ID="Checkbox" runat="server" AutoPostback="true"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
             
</main>
</div>
</asp:Content>
