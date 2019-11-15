<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByDepartmentUi.aspx.cs" Inherits="StudentRegistrationWebApp.SearchByDepartmentUi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Search Student Information by Department</h2>
    <hr />

    <div class="form-group">
        <label for="inputDept">Department</label>
        <asp:DropDownList ID="departmentDropDownList" class="form-control" runat="server"></asp:DropDownList>
    </div>

    <asp:Button ID="searchButton" class="btn btn-primary" runat="server" Text="Search" OnClick="searchButton_Click"/>
    <asp:Label ID="messageLabel" runat="server"></asp:Label>

    <br />
    <hr />

    <asp:GridView ID="searchByDeptGridView" runat="server" AutoGenerateColumns ="false">
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

            <asp:TemplateField HeaderText ="No Of Course">
                <ItemTemplate>
                    <%#Eval("NoOfCourse") %>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>

