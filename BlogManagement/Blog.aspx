<%@ Page Title="Blog" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="BlogManagement.Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdn.ckeditor.com/4.14.0/standard/ckeditor.js"></script>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <div class="form-group" style="margin-top:50px">
           <div class="col-md-2"> <asp:Label runat="server" AssociatedControlID="txtHeader" Text="Header" CssClass="control-label"></asp:Label></div>
            <div class="col-md-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtHeader"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtHeader"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group" style="margin-top:50px">
           <div class="col-md-2"> <asp:Label runat="server" AssociatedControlID="fileUpload" Text="File" CssClass="control-label"></asp:Label></div>
            <div class="col-md-3">
                <asp:FileUpload runat="server" CssClass="form-control" ID="fileUpload" ></asp:FileUpload>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="fileUpload"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
            <div class="col-md-3">
                <img id="imgFile" runat="server" width="100" height="150" />
            </div>
        </div>
        <div class="form-group" style="margin-top:50px">
            <asp:HiddenField runat="server" ID="hfId" />
            <textarea id="editor1" runat="server" name="editor1"></textarea>
        </div>

        <div class="form-group">
            <div class="col-md-10">
                <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Submit" CssClass="btn btn-primary" />
            </div>
        </div>
        <a href="BlogList.aspx" class="btn btn-info" style="margin-top:10px">Go to List</a>
    </div>
    <script>
        CKEDITOR.replace("<%=editor1.ClientID%>");
    </script>
</asp:Content>
