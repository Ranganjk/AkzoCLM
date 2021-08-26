<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AkzoCLM.Master" CodeFile="Q106_STCGCSBNP.aspx.cs" Inherits="Q106_STCGCSBNP" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="CPH3" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">

        function TaskConfirmMsg() {
            var result = confirm('Do you want to save?');
            if (result) {
                document.getElementById('<%=CnfResult.ClientID%>').value = "true";
                return true;
            } else {
                document.getElementById('<%=CnfResult.ClientID%>').value = "false";
                return false;
            }
        }
    </script>

    <style type="text/css">
        .ddl {
            border: 1px solid #7d6754;
            border-radius: 5px;
            padding: 2px;
            -webkit-appearance: scrollbartrack-vertical;
            /*background-image: url('Images/Arrowhead-Down-01.png');*/
            background-position: 88px;
            background-repeat: no-repeat;
            text-indent: 0.01px; /*In Firefox*/
            text-overflow: ''; /*In Firefox*/
            width: 180px;
        }

        .Button111 {
            background-color: #008dde;
            border: none;
            border-radius: 3px;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            color: #f4f4f4;
            cursor: pointer;
            font-family: 'Open Sans', Verdana, Helvetica, sans-serif;
            height: 20px;
            text-transform: uppercase;
            width: 100px;
            -webkit-appearance: none;
        }

        tr {
            height: 35px;
        }
    </style>



    <asp:Panel ID="pnlMenuItem" runat="server" Style="text-align: left; height: 540px; width: 1100px; background-color: #f7e98e">

        <table>
            <tr style="vertical-align: top">
                <td style="width: 5px"></td>
                <td>
                    <asp:Label ID="Label2" runat="Server" Text="Q106 –  CG codes with positive months" ForeColor=" Black " Font-Names="Calibri" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr style="height: 25px"></tr>
        </table>

        <table>
            <tr>
                <td style="width: 30px"></td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:HiddenField ID="CnfResult" runat="server" />
                                <asp:Label ID="Label9" runat="Server" Width="130px" Text="For Year" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium"></asp:Label><br />

                                <asp:DropDownList ID="ddlForYear" ToolTip="Which year's data you wish to check?" CssClass="ddl" runat="server"
                                    Font-Names="Calibri">
                                    <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                    <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                    <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                    <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                    <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 300px">
                                <asp:Label ID="Label36" runat="Server" Text="Sub Brand" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label><br />

                                <telerik:RadComboBox RenderMode="Lightweight" ID="rdgCombo" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="true"
                                    Width="270px" Height="310px">
                                </telerik:RadComboBox>

                                <%--<asp:DropDownList ID="ddlSubBrand" ToolTip="Select the SubBrand" CssClass="ddl" runat="server" Width="270px" Font-Names="Calibri">
                                </asp:DropDownList>--%>
                            </td>
                            

                            <td style="width: 200px">
                                <asp:Label ID="Label90" runat="Server" Text="Formula" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label><br />

                                <asp:DropDownList ID="ddlFormula" ToolTip="Select the formula to compare with the +ve months" CssClass="ddl" runat="server"
                                    Font-Names="Calibri">
                                    <asp:ListItem Text="<=" Value="LE"></asp:ListItem>
                                    <asp:ListItem Text="=" Value="EQ"></asp:ListItem>
                                    <asp:ListItem Text=">=" Value="GE"></asp:ListItem>
                                </asp:DropDownList>
                            </td>

                            <td style="width: 250px">
                                <asp:Label ID="Label12" runat="Server" Text="+ve Months" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label><br />

                                <asp:DropDownList ID="ddlPtvMonth" ToolTip="Select the positive months" CssClass="ddl" runat="server" Font-Names="Calibri">
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                            </td>



                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMsg" runat="server" Text="Ordered by Product Category, Sub brand" Font-Names="calibri" Font-Size="Small" ForeColor="Blue"></asp:Label><br />
                                <asp:Label ID="Label3" runat="server" Text="(Scheme=Yes alone shown)" Font-Names="calibri" Font-Size="Small" ForeColor="Blue"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="Server" Text="Send To" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label><br />

                                <asp:DropDownList ID="ddlSendTo" ToolTip="Email will be sent to the selected id" CssClass="ddl" runat="server" Font-Names="Calibri" Width="270px">
                                    <asp:ListItem Text="sridhar@innovatussystems.com" Value="sridhar@innovatussystems.com"></asp:ListItem>
                                    <asp:ListItem Text="rangan@innovatussystems.com" Value="rangan@innovatussystems.com"></asp:ListItem>
                                    <asp:ListItem Text="logesh@innovatussystems.com" Value="logesh@innovatussystems.com"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 50px">

                            <td>
                                <asp:Button ID="btnSave" runat="Server" Text="Save" ToolTip="Click here to save the details" CssClass="Button111" OnClick="btnSave_Click" OnClientClick="javascript:return TaskConfirmMsg()" />
                                <asp:Button ID="btnClear" runat="Server" Text="Clear" ToolTip=" Click here to clear entered details" CssClass="Button111" OnClick="btnClear_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

    </asp:Panel>
    .
</asp:Content>
