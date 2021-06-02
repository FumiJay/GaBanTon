<%@ Page Title="" Language="C#" MasterPageFile="~/TopSide.Master" AutoEventWireup="true" CodeBehind="CreateGroup.aspx.cs" Inherits="GaBanTon.CreateGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        #area {
            border-radius: 10px;
            padding: 20px 20px 20px 20px;
        }

        #Taital {
            text-align: center;
        }

        #img {
            padding: 10px 10px 10px 10px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div id="area" class="col-12 border border-primary">
            <asp:Label ForeColor="Red" ID="Mess" runat="server" Text=""></asp:Label>
            <div class="align-items-center">
                <h4 id="Taital">開團瞜!</h4>
                <br />
                <br />
            </div>
            <div>
                團　名:<asp:TextBox ID="GroupName" runat="server"></asp:TextBox><br />
                店　名:<asp:DropDownList ID="Shop" runat="server">
                    <asp:ListItem Value="1" Text="麥當勞" />
                    <asp:ListItem Value="2" Text="肯德基" />
                    <asp:ListItem Value="3" Text="丹丹漢堡" />
                </asp:DropDownList>
            </div>
            <div>
                群組圖片:
                <asp:DropDownList ID="GroupImg" AutoPostBack="true" runat="server" OnSelectedIndexChanged="GroupImg_SelectedIndexChanged">
                    <asp:ListItem Value="img/三色豆.jpg" Text="三色豆" />
                    <asp:ListItem Value="img/毛豆炒豆乾.jpg" Text="毛豆炒豆乾" />
                    <asp:ListItem Value="img/豆枝、豆棗.jpg" Text="豆枝、豆棗" />
                    <asp:ListItem Value="img/油菜.jpg" Text="油菜" />
                    <asp:ListItem Value="img/洋蔥炒蛋.jpg" Text="洋蔥炒蛋" />
                    <asp:ListItem Value="img/紅燒茄子.jpg" Text="紅燒茄子" />
                    <asp:ListItem Value="img/紅蘿蔔炒蛋.jpg" Text="紅蘿蔔炒蛋" />
                    <asp:ListItem Value="img/電話線.jpg" Text="電話線" />
                    <asp:ListItem Value="img/滷海帶蘿蔔.jpg" Text="滷海帶蘿蔔" />
                    <asp:ListItem Value="img/辣筍.jpg" Text="辣筍" />
                    <asp:ListItem Value="img/辣菜補.jpg" Text="辣菜補" />
                    <asp:ListItem Value="img/螢光咖哩.jpg" Text="螢光咖哩" />
                </asp:DropDownList>
            </div>
            <div id="img">
                <img id="ImgView" runat="server" src="img/三色豆.jpg" alt="Alternate Text" />
            </div>
        </div>
        <div class="row justify-content-center align-items-center offset-10">
            <asp:Button ID="btnOK" Style="padding-top: 5px" class="btn btn-success" runat="server" Text="確定" OnClick="btnOK_Click" />&nbsp;
            <asp:Button ID="btnReset" Style="padding-top: 5px" class="btn btn-info" runat="server" Text="重置" OnClick="btnReset_Click" />
        </div>
    </div>
</asp:Content>
