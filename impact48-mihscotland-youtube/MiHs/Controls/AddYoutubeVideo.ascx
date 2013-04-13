<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddYoutubeVideo.ascx.cs" Inherits="MiHs.Controls.AddYoutubeVideo" %>

<p>
    <asp:Label ID="UrlLabel" runat="server" AssociatedControlID="Url" Text="Url"/><br/>
    <asp:TextBox ID="Url" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="UrlRequiredValidator" runat="server" ControlToValidate="Url" 
        ErrorMessage="Url required" ForeColor="Red" Display="Dynamic"/>
    <asp:CustomValidator ID="UrlValidator" runat="server" ControlToValidate="Url" ForeColor="Red" 
        OnServerValidate="ValidateUrl" ErrorMessage="Invalid Url" Display="Dynamic"/>
</p>

<p>
    <asp:Label runat="server" AssociatedControlID="Comment" Text="Comment"/><br/>   
    <asp:TextBox ID="Comment" runat="server"></asp:TextBox>
</p>

<p>
    <asp:Button ID="Add" runat="server" CausesValidation="True" Text="Add" OnClick="Add_Click"/>
</p>