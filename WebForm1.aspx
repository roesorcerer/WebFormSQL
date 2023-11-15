<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="COP2664CWinter2021.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div>
            <asp:HiddenField ID="hftweet_id" runat="server" />
            <table align="left" class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="airline_sentiment" CssClass="auto-style2"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtairline_sentiment" runat="server" Height="23px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Airline Sentiment Confidence" CssClass="auto-style2"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtairline_sentiment_confidence" runat="server" Height="23px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Negative Reason" CssClass="auto-style2"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtnegativereason" runat="server" Height="23px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Negative Reason Confidence" CssClass="auto-style2"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtnegativereason_confidence" runat="server" Height="23px"></asp:TextBox>
                    </td>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Airline" CssClass="auto-style2"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtairline" runat="server" Height="23px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" />
                    </td>

                    <td>
                            <asp:Button ID="ButtonClear" runat="server" Text="Clear" OnClick="ButtonClear_Click" />
                    </td>
                    </tr>
                <tr>
                    <td colspan="2">
<%--            Create success and error messages--%>

                    <asp:Label ID="SuccessMessage" runat="server" Text="" ForeColor="Green" style="font-style: normal; font-weight: 700; font-family: Arial, Helvetica, sans-serif;"></asp:Label>
                    <asp:Label ID="ErrorMessage" runat="server" Text="" ForeColor="Red" style="font-style: normal; font-weight: 700; font-family: Arial, Helvetica, sans-serif;"></asp:Label>
                </td>
                    </tr>
            </table>
            <br />
<%--            Create a grid to display all rows--%>
            <asp:GridView ID="gvtweets" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="airline_sentiment" HeaderText="Airline Sentiment" />
                    <asp:BoundField DataField="airline_sentiment_confidence" HeaderText="Airline Sentiment Confidence" />
                    <asp:BoundField DataField="negativereason" HeaderText="Negative Reason" />
                    <asp:BoundField DataField="negativereason_confidence" HeaderText="Negative Reason Confidence" />
                    <asp:BoundField DataField="airline" HeaderText="Airline" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("tweet_id") %>' OnClick="lnk_OnClick" >View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
