<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrationUi.aspx.cs" Inherits="StudentRegistrationWebApp.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Registration Form</h2>
    <hr />

    <div class="form-group">
        <label for="inputStudentName">Student Name</label>
        <input type="text" class="form-control" id="inputStudentName" runat="server" placeholder="Enter Student Name" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="inputStudentName" ForeColor="red" ErrorMessage="Name Can't be empty"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <label for="inputRegNo">Reg No.</label>
        <input type="text" class="form-control" id="inputRegNo" runat="server" visible="True" placeholder="Enter Reg No"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="inputRegNo" ForeColor="red" ErrorMessage="RegNo Can't be empty"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <label for="inputDept">Department</label>
        <asp:DropDownList ID="departmentDropDownList" class="form-control" runat="server"></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="inputNoOfCourses">No of Courses</label>
        <input type="text" class="form-control" id="inputNoOfCourses" runat="server" visible="True" placeholder="Enter No of Course taken" value="0"/>
    </div>
    
    <asp:Button ID="saveButton" class="btn btn-primary" runat="server" Text="Save" OnClick="saveButton_Click"/>
    <asp:Label ID="messageLabel" runat="server"></asp:Label>
    <br />
    
    <hr />
    <asp:GridView ID="registrationGridView" runat="server" AutoGenerateColumns ="false">
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
