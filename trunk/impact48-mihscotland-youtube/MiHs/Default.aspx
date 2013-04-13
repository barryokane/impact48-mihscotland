<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="MiHs.Default" %>
<%@ Register TagPrefix="mih" tagName="AddYoutubeVideo" src="Controls/AddYoutubeVideo.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    
    <mih:AddYoutubeVideo ID="AddYoutubeVideoControl" runat="server" OnAddingYoutubeVideo="AddYoutubeVideoControl_AddingYoutubeVideo"/>
    
    <asp:Repeater ID="YoutubeVideos" runat="server" OnDataBinding="YoutubeVideos_DataBinding">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li><%# Eval("Url")%> (<%# Eval("Comment")%>)</li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
</asp:Content>
