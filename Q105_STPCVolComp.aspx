<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AkzoCLM.Master" CodeFile="Q105_STPCVolComp.aspx.cs" Inherits="Q105_STPCVolComp" %>

<asp:Content ID="CPH3" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <%--<h2>Hare Rama Hare Krishna</h2>--%>

    
    <script type="text/javascript">

        function validate() {
            var summ = "";
            summ += ItemName();
            summ += ItemCode();


            if (summ == "") {
                var result = confirm('Do you want to save?');
                if (result) {
                    document.getElementById('<%=CnfResult.ClientID%>').value = "true";
                     return true;
                 }
                 else {
                     document.getElementById('<%=CnfResult.ClientID%>').value = "true";
                    return false;
                }

            }
            else {
                alert(summ);
                return false;
            }
        }
    </script>

    <style type="text/css">
        .ddl {
            border: 1px solid #7d6754;
            border-radius: 5px;
            padding: 2px;
            -webkit-appearance:scrollbartrack-vertical;
            /*background-image: url('Images/Arrowhead-Down-01.png');*/
            background-position: 88px;
            background-repeat: no-repeat;
            text-indent: 0.01px; /*In Firefox*/
            text-overflow: ''; /*In Firefox*/
            width:180px;
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
   height:35px;
 }
    </style>


     





    <asp:Panel ID="pnlMenuItem" runat="server" style="text-align: left; height: 630px; width: 1100px; background-color: #f7e98e">
        <table>
            <tr>
                 <td style="width:30px"></td>
                <td>
                    <asp:Label ID="Label2" runat="Server"   Text="Q105 - Product Cluster Volume Comparison" ForeColor=" Black " Font-Names="Calibri" Font-Size="Larger" Font-Bold="true" ></asp:Label>
                </td>
                
            </tr>
            <tr style="height:25px"></tr>
        </table>
        <table>     
            <tr>
                <td style="width:30px"></td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:HiddenField ID="CnfResult" runat="server" />
                                <asp:Label ID="Label9" runat="Server" Width="130px" Text="From Year" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium" ></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFromYear" ToolTip="Which year's data you wish to check?" CssClass="ddl"   runat="server"
                                    Font-Names="Calibri"  >
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
                            <td>
                                <asp:Label ID="Label10" runat="Server" Text="From Month" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFromMonth" ToolTip="FY=Full Year,else select the month" CssClass="ddl"   runat="server"
                                    Font-Names="Calibri" >
                                    <asp:ListItem Text="FY" Value="FY"></asp:ListItem>
                                    <asp:ListItem Text="JAN" Value="JAN"></asp:ListItem>
                                    <asp:ListItem Text="FEB" Value="FEB"></asp:ListItem>
                                    <asp:ListItem Text="MAR" Value="MAR"></asp:ListItem>
                                    <asp:ListItem Text="APR" Value="APR"></asp:ListItem>
                                    <asp:ListItem Text="MAY" Value="MAY"></asp:ListItem>
                                    <asp:ListItem Text="JUN" Value="JUN"></asp:ListItem>
                                    <asp:ListItem Text="JUL" Value="JUL"></asp:ListItem>
                                    <asp:ListItem Text="AUG" Value="AUG"></asp:ListItem>
                                    <asp:ListItem Text="SEP" Value="SEP"></asp:ListItem>
                                    <asp:ListItem Text="OCT" Value="OCT"></asp:ListItem>
                                    <asp:ListItem Text="NOV" Value="NOV"></asp:ListItem>
                                    <asp:ListItem Text="DEC" Value="DEC"></asp:ListItem>
                                </asp:DropDownList>                                
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label36" runat="Server" Text="Product Cluster1" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPC1" ToolTip="Select the product cluster" CssClass="ddl" runat="server"  Width="270px" Font-Names="Calibri"  >
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label90" runat="Server" Text="Formula1" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFormula1" ToolTip="Select the formula" CssClass="ddl"  runat="server"
                                    Font-Names="Calibri"  >
                                    <asp:ListItem Text=">" Value=" GT"></asp:ListItem>
                                    <asp:ListItem Text="<" Value="LT"></asp:ListItem>
                                    <asp:ListItem Text=">=" Value="GE"></asp:ListItem>
                                    <asp:ListItem Text="<=" Value=" LE"></asp:ListItem>
                                    <asp:ListItem Text="=" Value="EQ"></asp:ListItem>
                                    <asp:ListItem Text="<>" Value="NE"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label91" runat="Server" Text="PC1 Volume" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPC1Volume" runat="Server" Text="0" MaxLength="12" CssClass="ddl"  ToolTip="Enter product cluster volume" Width="170px" ForeColor="Black" Font-Names="Verdana"  ></asp:TextBox>
                            </td>
                        </tr>
                         

                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="Server" Text="To Year" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlToYear" ToolTip="Which year's data you wish to compare?"  CssClass="ddl"  runat="server" Font-Names="Calibri">
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
                            <td>
                                <asp:Label ID="Label12" runat="Server" Text="To Month" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlToMonth" ToolTip="FY=Full Year,else select the month" CssClass="ddl"  runat="server"
                                    Font-Names="Calibri" >
                                    <asp:ListItem Text="FY" Value="FY"></asp:ListItem>
                                    <asp:ListItem Text="JAN" Value="JAN"></asp:ListItem>
                                    <asp:ListItem Text="FEB" Value="FEB"></asp:ListItem>
                                    <asp:ListItem Text="MAR" Value="MAR"></asp:ListItem>
                                    <asp:ListItem Text="APR" Value="APR"></asp:ListItem>
                                    <asp:ListItem Text="MAY" Value="MAY"></asp:ListItem>
                                    <asp:ListItem Text="JUN" Value="JUN"></asp:ListItem>
                                    <asp:ListItem Text="JUL" Value="JUL"></asp:ListItem>
                                    <asp:ListItem Text="AUG" Value="AUG"></asp:ListItem>
                                    <asp:ListItem Text="SEP" Value="SEP"></asp:ListItem>
                                    <asp:ListItem Text="OCT" Value="OCT"></asp:ListItem>
                                    <asp:ListItem Text="NOV" Value="NOV"></asp:ListItem>
                                    <asp:ListItem Text="DEC" Value="DEC"></asp:ListItem>

                                </asp:DropDownList>

                            </td>
                        </tr>      
                        <tr>
                            <td>
                                <asp:Label ID="Label41" runat="Server" Text="Product Cluster2" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPC2" ToolTip="Select the product cluster" CssClass="ddl"  runat="server"  Width="270px" Font-Names="Calibri"  >
                                </asp:DropDownList>
                            </td>
                        </tr>    
                        <tr>
                            <td>
                                <asp:Label ID="Label51" runat="Server" Text="Formula2" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFormula2" ToolTip="Select the formula" CssClass="ddl"  runat="server"
                                    Font-Names="Calibri" >
                                    <asp:ListItem Text=">" Value=" GT"></asp:ListItem>
                                    <asp:ListItem Text="<" Value="LT"></asp:ListItem>
                                    <asp:ListItem Text=">=" Value="GE"></asp:ListItem>
                                    <asp:ListItem Text="<=" Value=" LE"></asp:ListItem>
                                    <asp:ListItem Text="=" Value="EQ"></asp:ListItem>
                                    <asp:ListItem Text="<>" Value="NE"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label42" runat="Server" Text="PC2 Volume" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPC2Volume" runat="Server" Text="0" MaxLength="12" CssClass="ddl"  ToolTip="Enter product cluster volume" Width="170px"   ForeColor="Black" Font-Names="Verdana"  ></asp:TextBox>
                            </td>
                        </tr>
                         
                        <tr>
                            <td>
                                <asp:Label ID="Label33" runat="Server" Text="Status" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStatus" ToolTip="Default Status=Submitted" CssClass="ddl"   runat="server" Font-Names="Calibri" Enabled="false" >
                                    <asp:ListItem Text="Submitted" Value="00"></asp:ListItem>                                   
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="Server" Text="Send To" ForeColor=" Black " Font-Names="Calibri" Font-Size="Medium "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSendTo" ToolTip="Email will be sent to the selected id" CssClass="ddl"    runat="server" Font-Names="Calibri"  Width="270px">                                    
                                  <%--  <asp:ListItem Text="ajay.pandita@akzonobel.com" Value="ajay.pandita@akzonobel.com"></asp:ListItem>
                                    <asp:ListItem Text="sridhar@innovatussystems.com" Value="sridhar@innovatussystems.com"></asp:ListItem>--%>
                                    <asp:ListItem Text="rangan@innovatussystems.com" Value="rangan@innovatussystems.com"></asp:ListItem>
                                    <asp:ListItem Text="logesh@innovatussystems.com" Value="logesh@innovatussystems.com"></asp:ListItem>
                                </asp:DropDownList>
                            </td>

                        </tr>

                        <tr>
                            <td></td>
                            <td > 

                                <asp:Button ID="btnSave" runat="Server" Text="Save" ToolTip="Click here to save the details" CssClass="Button111" OnClick="btnSave_Click"  />
                                <asp:Button ID="btnClearItm" runat="Server" Text="Clear" ToolTip=" Click here to clear entered details" CssClass="Button111" OnClick="btnClear_Click" />
                                <%--<asp:Button ID="btnUpteItm" runat="Server" CssClass="btn btn-success" Text="Update" ToolTip="Click here to Update the details" ForeColor="White" BackColor="DarkGreen" Font-Size="Medium" OnClick="btnUpteItm_Click" OnClientClick="javascript:return TaskConfirmMsgET()" />
                                
                                <asp:Button ID="btnCloseItm" runat="Server" CssClass="btn" Text="Close" ToolTip="Click here to close" ForeColor="White" BackColor=" DarkBlue " Font-Size="Medium" OnClick="btnCloseItm_Click" />--%>

                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
    </asp:Panel>






</asp:Content>
