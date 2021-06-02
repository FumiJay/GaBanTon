<%@ Page Title="" Language="C#" MasterPageFile="~/TopSide.Master" AutoEventWireup="true" CodeBehind="GroupDetail.aspx.cs" Inherits="GaBanTon.GroupDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #img {
            border-radius: 10px;
            padding: 10px 10px 10px 10px;
        }

        #FoodImg {
            height: 50px;
            width: 50px;
        }

        #food {
            padding: 10px 10px 10px 10px;
        }

        .Member {
            padding: 10px 10px 10px 10px;
        }

        #MemberImg {
            height: 50px;
            width: 50px;
        }

        #Car_1 {
            padding: 10px 10px 10px 10px;
            border-radius: 5px;
        }

        #Car_2 {
            padding: 10px 10px 10px 10px;
            border-radius: 5px;
        }

        #CarImg {
            height: 50px;
            width: 50px;
        }

        #Buy {
            border-radius: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container border border-primary">
        團　名:
        <asp:Label ID="GroupTital" runat="server" Text=""></asp:Label><br />
        <div id="BuyGroup" class="col-12 row">
            <div id="img">
                <img id="GroupImg" runat="server" src="" alt="Alternate Text" />
            </div>
            <br />
            <div id="GroupInfo">
                狀態:<asp:DropDownList ID="GroupStaus1" runat="server">
                    <asp:ListItem>未結團</asp:ListItem>
                    <asp:ListItem>結團</asp:ListItem>
                    <asp:ListItem>已結束</asp:ListItem>
                </asp:DropDownList><br />
                店　名:
                <asp:Label ID="Shop" runat="server" Text=""></asp:Label><br />
                發起人:
                <asp:Label ID="GroupLider" runat="server" Text=""></asp:Label><br />
            </div>
            &nbsp;
            <div class="justify-content-center align-items-center">
                <asp:Button ID="btnResult" class="btn btn-success" runat="server" Text="結單!" />
            </div>
        </div>
        <br />
        <hr />
        <asp:Label ForeColor="Red" ID="ErrMess" runat="server" Text=""></asp:Label><br />
        <asp:Repeater ID="Rep_MenuList" runat="server">
            <ItemTemplate>
                <div id="food" class="btn btn-outline-secondary col-md-3 col-sm-6">
                    <img id="FoodImg" src="img/電話線.jpg" />
                    <asp:Label ID="Food" runat="server"><%#Eval("MenuName") %></asp:Label><br />
                    單價: $<asp:Label ID="Price" runat="server"><%#Eval("Price") %></asp:Label>元<br />
                    數量: 
                <asp:DropDownList ID="MenuBar" runat="server" AutoPostBack="true" ToolTip='<%#Eval("MenuName")+","+Eval("Price")+","+Eval("MenuID") %>' OnSelectedIndexChanged="MenuBar_SelectedIndexChanged">
                    <asp:ListItem>請選擇數量</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <hr />
        <div class="row Member">
            <asp:Repeater ID="WhoBuy" runat="server" OnItemDataBound="WhoBuy_ItemDataBound">
                <ItemTemplate>
                    <div class="btn btn-outline-secondary col-md-3 col-sm-6 Member">
                        <img id="MemberImg" src="img/Member.png" />
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name")%>'></asp:Label><br />
                        <asp:Repeater ID="Food" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Food_Qty" runat="server" Text='<%#Eval("MenuName")+","+Eval("Qty") %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <br />
        <hr />
        <div id="Car_1" class="row">
            <div id="Car_2" class="border border-primary col-md-3 col-sm-6">
                <img id="CarImg" src="img/card.png" />
                <asp:Label ID="BuyCar" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="Menu_Total" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="Price_Total" runat="server" Text=""></asp:Label><br />
                <asp:Button ID="Buy" class="btn btn-success" runat="server" Text="下訂!" OnClick="Buy_Click" />
            </div>
        </div>
    </div>
</asp:Content>
