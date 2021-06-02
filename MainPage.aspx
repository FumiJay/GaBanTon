<%@ Page Title="" Language="C#" MasterPageFile="~/TopSide.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="GaBanTon.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #GroupImg {
            height: 200px;
            width: 200px;
        }

        #BuyGroup {
            margin: 22px 22px 22px 22px;
        }

        #img {
            padding: 10px 10px 10px 10px;
        }

        #GroupInfo {
            padding: 10px 10px 10px 10px;
        }

        #GroupTital {
            font-size: 35px;
        }

        #GroupLider {
            font-size: 12px;
        }

        #Search_bar {
            padding: 5px 5px 5px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="Search_bar" class="row offset-1 justify-content-end align-content-end">
            <asp:DropDownList ID="GroupStaus1" runat="server">
                <asp:ListItem>未結團</asp:ListItem>
                <asp:ListItem>結團</asp:ListItem>
                <asp:ListItem>已結束</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="KeyWord" runat="server"></asp:TextBox>&nbsp;
            <asp:Button CssClass="btn btn-primary" ID="Search" runat="server" Text="搜尋" OnClick="Searchbtn_Click" />&nbsp;
        </div>

        <div>
            <asp:Repeater ID="Group" runat="server">
                <ItemTemplate>
                    <div id="BuyGroup" class="col-12 border border-primary row">
                        <div id="img">
                            <asp:ImageButton id="GroupImg" CommandArgument='<%#Eval("Sid") %>' runat="server" src='<%#Eval("GroupImg") %>' OnClick="Detail_Click" />
                        </div>
                        <div id="GroupInfo">
                            <asp:Label ID="GroupTital" runat="server">團　名: <%#Eval("GroupTital") %></asp:Label><br />
                            <asp:Label ID="MemberID" runat="server">發起人: <%#Eval("MemberName") %></asp:Label><br />
                            <asp:Label ID="Shop" runat="server">店　名: <%#Eval("ShopName") %></asp:Label><br />
                            <asp:Label ID="Status" runat="server">狀　態: <%#Eval("Status") %></asp:Label><br />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <%--<div id="BuyGroup" class="col-12 border border-primary row">
            <div id="img">
                <a href="GroupDetail.aspx">
                    <img id="GroupImg" src="img/三色豆.jpg" alt="Alternate Text" /></a>
            </div>
            <div id="GroupInfo">
                <asp:Label ID="GroupTital" runat="server" Text="團　名: 麵非麵"></asp:Label><br />
                <asp:Label ID="GroupLider" runat="server" Text="發起人: XXX"></asp:Label><br />
                <asp:Label ID="Shop" runat="server" Text="店　名: XXX"></asp:Label><br />
                <asp:Label ID="Status" runat="server" Text="狀　態: XXX"></asp:Label><br />
            </div>
        </div>--%>

    <div class="text-center">
        <asp:Repeater runat="server" ID="repPaging">
            <ItemTemplate>
                <a style="color: <%# Eval("Color") %>" href="<%# Eval("Link") %>" title="<%# Eval("Title") %>">第<%# Eval("Name") %>頁</a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
