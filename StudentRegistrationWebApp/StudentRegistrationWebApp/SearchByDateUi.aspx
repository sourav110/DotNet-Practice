<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByDateUi.aspx.cs" Inherits="StudentRegistrationWebApp.SearchByDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Search Student Information by Date</h2>
    <hr />

    <div class="form-group">
        <label for="fromDateTextBox">From Date</label>
        <input type="date" class="form-control" runat="server" id="fromDateTextBox">
    </div>

    <div class="form-group">
        <label for="toDateTextBox">To Date</label>
        <input type="date" class="form-control" runat="server" id="toDateTextBox">
    </div>

    <asp:Button ID="searchButton" class="btn btn-primary" runat="server" Text="Search" OnClick="searchButton_Click"/>
    <br />
    <asp:Label ID="messageLabel" runat="server"></asp:Label>
    <br />

    <asp:GridView ID="searchByDateGridView" runat="server" AutoGenerateColumns ="false">
        <Columns>
            <asp:TemplateField HeaderText ="SLNo.">
                <ItemTemplate>
                    <%#Container.DataItemIndex +1 %>
                </ItemTemplate>
            </asp:TemplateField>
                
            <asp:TemplateField HeaderText ="Student Name">
                <ItemTemplate>
                    <%#Eval("StudentName") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText ="Reg No.">
                <ItemTemplate>
                    <%#Eval("RegNo") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText ="Department">
                <ItemTemplate>
                    <%#Eval("Department") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText ="No Of Course">
                <ItemTemplate>
                    <%#Eval("NoOfCourse") %>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

</asp:Content>
