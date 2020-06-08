<%@ Page Title="BlogList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BlogList.aspx.cs" Inherits="BlogManagement.BlogList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row form-group text-center" style="margin-top:30px"><a href="Blog.aspx" class="btn btn-primary">Create New</a></div>
        <div class="row form-group">
            <div class="col-md-10">
            <asp:GridView AutoGenerateColumns="false" runat="server" ID="gv1" CssClass="table table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="Header" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblHeader" Text='<%#Eval("Header") %>'></asp:Label>
                            <asp:HiddenField runat="server" ID="hfId" Value='<%#Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Content" ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="lblContent" Text='<%#Eval("Content") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="60px">
                        <ItemTemplate>
                            <%--<asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#  
                                         Eval("Id")%>'
                                OnClick="lnkRemove_Click"
                                Text="Delete"></asp:LinkButton>|--%>
                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#  
                                         Eval("Id")%>'
                        OnClick="lnkEdit_Click"
                        Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        </div>
    </div>


</asp:Content>
