<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportServerOrgData.aspx.cs" Inherits="LJ.Reports.Web.Reports.ReportServerOrgData" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Content/EasyUI/jquery.js"></script>
    <script src="../Content/EasyUI/jquery.easyui.js"></script>
    <script src="../Content/EasyUI/locale/easyui-lang-zh_CN.js"></script>
    <link href="../Content/EasyUI/themes/icon.css" rel="stylesheet" />
    <link href="../Content/EasyUI/themes/default/easyui.css" rel="stylesheet" />
    <script src="../Scripts/jquery.Extend.js"></script>
    <script type="text/javascript">
        //页面加载
        $(document).ready(function () {
            initCombo();
        });
        function initCombo() {
            var url = "../DataService/GeOrgListBy?OrgSign=" + $('#HiddenOrgSign').val();;
            $('#OrgID').combobox({
                //prompt: '--请选择--',
                url: url,//ajax后台取数据路径，返回的是json格式的数据 
                valueField: 'id',
                textField: 'name',
                method: 'Post',
                editable: false,
                required: true,
                onLoadSuccess: function () { //数据加载完毕事件
                    $("#OrgID").combobox('select', "-1");
                },
                onSelect: function (org) {
                    $('#HiddenSelectedOrgIDs').val(org.id);  //给隐藏字段赋值
                }
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <table>
            <asp:HiddenField ID="HiddenOrgSign" runat="server" />
            <asp:HiddenField ID="HiddenSelectedOrgIDs" runat="server" />
            <tr>
                <td>查询时间：</td>
                <td>
                    <asp:TextBox ID="StartDate" class="easyui-datetimebox" Style="width: 150px" runat="server"></asp:TextBox>
                </td>
                <td>至</td>
                <td>
                    <asp:TextBox ID="EndDate" class="easyui-datetimebox" Style="width: 150px" runat="server"></asp:TextBox>
                </td>
                <td>机构：</td>
                <td>
                    <asp:TextBox ID="OrgID" class="easyui-combobox" Style="width: 200px" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;
                   <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                    &nbsp;
                </td>
            </tr>
        </table>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server"  width="100%" height="100%"  ZoomMode="PageWidth" ShowBackButton="true" SizeToReportContent="True" > </rsweb:ReportViewer>

    </form>
</body>
</html>
