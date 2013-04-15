<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <style>
        .show
        {
            color:Red;
            text-decoration:line-through;
        }
    </style>
    <script type="text/javascript">
    
        $(document).ready(function () {
            $("input[id^='DataList1_txtName']").click(function () {
                var id = $(this).attr("id");
                id = id.substring(id.indexOf("DataList1_txtName") + 17);
                var type = $("select[id^='DataList1_dltest'][id$=" + id + "]");
                var age = $("input[id^='DataList1_txtType'][id$=" + id + "]");
                if (type.val() == "0") {
                    if (getAge($(this).val()) != "false") {
                        age.val(getAge($(this).val()));

                    }
                    else {
                        alert("身份证格式错误");
                    }
                }
            });
        });

        var aCity = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外" }
        function cidInfo(sId) {
            var iSum = 0
            var info = ""
            if (!/^\d{17}(\d|x)$/i.test(sId)) return "false";
            sId = sId.replace(/x$/i, "a");
            if (aCity[parseInt(sId.substr(0, 2))] == null) return "false";
            sBirthday = sId.substr(6, 4) + "/" + Number(sId.substr(10, 2)) + "/" + Number(sId.substr(12, 2));
            var d = new Date(sBirthday.replace(/-/g, "/"));
            if (sBirthday != (d.getFullYear() + "/" + (d.getMonth() + 1) + "/" + d.getDate())) return "false";
            for (var i = 17; i >= 0; i--) iSum += (Math.pow(2, i) % 11) * parseInt(sId.charAt(17 - i), 11)
            if (iSum % 11 != 1) return false;
            return sBirthday;
        }
        function getAge(sId) {
            if (cidInfo(sId) != "false") {
                try {
                    var birthday = new Date(cidInfo(sId).replace(/-/g, "/"));
                    var now = new Date();
                    var year = now.getFullYear() - birthday.getFullYear();
                    var month = now.getMonth() - birthday.getMonth();
                    var day = now.getDate() - birthday.getDate();
                    var age = year;
                    if (month < 0) {
                        age--;
                    }
                    else if (month == 0) {
                        if (day < 0) {
                            age--;
                        }
                    }
                    return age;
                }
                catch (e) {
                    return "false";
                }

            }
            else {
                return "false";
            }


        }

    </script>
</head>
<body>

    <form id="form1" runat="server">
        <table><tr style="text-decoration:line-through"><td>11223123</td><td>fsadf</td></tr></table>
        <div class="show"  style="text-decoration:line-through">11223123</div>
        <div>
            <asp:DropDownList ID="dltest" runat="server">
                <asp:ListItem Value="1">t1</asp:ListItem>
                <asp:ListItem Value="2" Selected="True">t2</asp:ListItem>
                <asp:ListItem Value="3">t3</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtName"  runat="server"></asp:TextBox>
            <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
        </div>
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <asp:DropDownList ID="dltest" runat="server">
                    <asp:ListItem Value="0">t0</asp:ListItem>
                    <asp:ListItem Value="1">t1</asp:ListItem>
                    <asp:ListItem Value="2" Selected="True">t2</asp:ListItem>
                    <asp:ListItem Value="3">t3</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtName" Text="370681198802270039" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtType"  runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:DataList>


        <asp:DataGrid ID="dgDataList" runat="server"  
            OnItemDataBound="dgDataList_ItemDataBound" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundColumn DataField="IDs" HeaderText="航班号" />
                <asp:TemplateColumn HeaderText="航班号" Visible="false">
                    <ItemTemplate>
                        <asp:TextBox ID="txtFlightNo" Width="80" runat="server" Text='<%# Eval("IDs").ToString()%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="IDs" HeaderText="舱位" />
                <asp:TemplateColumn HeaderText="出发城市">
                    <ItemTemplate>
                        <asp:Label ID="lblTakeoffTime" runat="server" Text='<%# Eval("IDs").ToString() %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
    </form>
    
</body>
</html>