<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AkzoCLM.Master" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="CPH2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

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
    </style>


    <table style="width: 100%; border-style: none; background-color: #f7e98e">

        <tr>
            <td>
                <asp:Label ID="Label1" runat="Server" Text="Q103 - Sub Brand VPC View" ForeColor=" Black " Font-Names="Calibri" Font-Size="Larger" Font-Bold="true"></asp:Label>
            </td>
        </tr>

        <tr style="height: 20px"></tr>

        <tr>
            <td>
                <asp:Label ID="Label4" runat="Server" Text="Select" ForeColor=" Black " Font-Names="Verdana" Font-Size="Small"></asp:Label>
                <asp:DropDownList ID="ddlSelect" runat="server" Style="height: 20px; width: 150px" Font-Names="Verdana" Font-Size="Small" AutoPostBack="true" OnSelectedIndexChanged="ddlSelect_Change">
                    <asp:ListItem Text="Quarterly" Value="01"></asp:ListItem>
                    <asp:ListItem Text="Yearly" Value="02"></asp:ListItem>
                    <asp:ListItem Text="Monthly" Value="03"></asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="lblYear" runat="Server" Text="Year" ForeColor=" Black " Font-Names="Verdana" Font-Size="Small"></asp:Label>
                <asp:DropDownList ID="ddlYear" runat="server" Style="height: 20px; width: 100px" Font-Names="Verdana" Font-Size="Small" AutoPostBack="true">
                    <asp:ListItem Text="2021" Value="21"></asp:ListItem>
                    <asp:ListItem Text="2020" Value="20"></asp:ListItem>
                    <asp:ListItem Text="2019" Value="19"></asp:ListItem>
                    <asp:ListItem Text="2018" Value="18"></asp:ListItem>
                    <asp:ListItem Text="2017" Value="17"></asp:ListItem>
                    <asp:ListItem Text="2016" Value="16"></asp:ListItem>
                    <asp:ListItem Text="2015" Value="15"></asp:ListItem>
                    <asp:ListItem Text="2014" Value="14"></asp:ListItem>
                    <asp:ListItem Text="2013" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2012" Value="12"></asp:ListItem>
                    <asp:ListItem Text="2011" Value="11"></asp:ListItem>
                    <asp:ListItem Text="2010" Value="10"></asp:ListItem>
                </asp:DropDownList>
                &nbsp&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Label ID="Label2" runat="Server" Text="Sub Brand" ForeColor=" Black " Font-Names="Verdana" Font-Size="Small"></asp:Label>
                <asp:DropDownList ID="ddlSubBrand" runat="server" Style="height: 25px; width: 315px" Font-Names="Verdana" Font-Size="Small" Enabled="true" ToolTip="Choose the preview centre where you wish to reassign the image.">
                    <asp:ListItem Text="ALL" Value="00"></asp:ListItem>
                </asp:DropDownList>

                


                &nbsp&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnShow" runat="server" CssClass="Button111" Font-Bold="false" ToolTip="Click to view the details" AutoPostBack="true" Text="Show" OnClick="BtnShow_Click"></asp:Button>
                <asp:Button ID="BtnnExcelExport" runat="server" CssClass="Button111" Font-Bold="false" Text="Export to Excel" ToolTip="Click here to export grid details in excel." OnClick="BtnnExcelExport_Click" Width="150px" />

            </td>
        </tr>

        <tr style="height: 10px"></tr>


        <tr>
            <td style="width: 100%;">

                <table>
                    <tr>
                        <asp:Panel ID="Panel2" runat="server" Visible="true">
                            <td>
                                <telerik:RadGrid ID="rdgQ103" runat="server" AllowPaging="false" PageSize="20" AutoGenerateColumns="False" Skin="Sunset" AllowSorting="true" Height="450px"
                                    CellSpacing="0" Width="98%" AllowFilteringByColumn="true" MasterTableView-HierarchyDefaultExpanded="true" OnItemCommand="rdgQ103_ItemCommand"
                                    OnPageIndexChanged="rdgQ103_PageIndexChanged" OnItemDataBound="rdgQ103_ItemDataBound" Font-Names="calibri">

                                    <ClientSettings>
                                        <Scrolling AllowScroll="True" UseStaticHeaders="true" />
                                    </ClientSettings>
                                    <GroupingSettings CaseSensitive="false" />
                                    <HeaderContextMenu CssClass="table table-bordered table-hover">
                                    </HeaderContextMenu>
                                    <PagerStyle AlwaysVisible="true" Mode="NextPrevAndNumeric" />
                                    <MasterTableView AllowCustomPaging="false" ShowFooter="true">
                                        <NoRecordsTemplate>
                                            No Records Found.
                                        </NoRecordsTemplate>
                                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                        <RowIndicatorColumn>
                                            <HeaderStyle Width="10px"></HeaderStyle>
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn>
                                            <HeaderStyle Width="10px"></HeaderStyle>
                                        </ExpandCollapseColumn>
                                        <Columns>




                                            <telerik:GridBoundColumn HeaderText="Sub Brand" DataField="SubBrand" ItemStyle-Width="150px" HeaderStyle-Width="150px" HeaderStyle-Wrap="false"
                                                ItemStyle-Wrap="false" AllowFiltering="true" Visible="true" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" AllowSorting="true"
                                                ItemStyle-CssClass="Row1" FilterControlWidth="100px">
                                                <HeaderStyle Wrap="False"></HeaderStyle>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Product Cluster" DataField="ProductCluster" ItemStyle-Width="100px" HeaderStyle-Width="100px" HeaderStyle-Wrap="false"
                                                ItemStyle-Wrap="false" AllowFiltering="true" Visible="true" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" AllowSorting="true"
                                                ItemStyle-CssClass="Row1" FilterControlWidth="80px">
                                                <HeaderStyle Wrap="False"></HeaderStyle>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="YYMM" DataField="YYMM" ItemStyle-Width="80px" HeaderStyle-Width="80px" HeaderStyle-Wrap="false"
                                                ItemStyle-Wrap="false" AllowFiltering="true" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" AllowSorting="true"
                                                ItemStyle-CssClass="Row1" FilterControlWidth="50px">
                                                <HeaderStyle Wrap="False"></HeaderStyle>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn HeaderText="Quantity in KL" DataField="QuantityKL" ItemStyle-Width="100px" HeaderStyle-Width="100px" HeaderStyle-Wrap="false"
                                                ItemStyle-Wrap="false" AllowFiltering="true" Visible="true" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" AllowSorting="true"
                                                ItemStyle-CssClass="Row1" FilterControlWidth="80px">
                                                <HeaderStyle Wrap="False"></HeaderStyle>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="CG Codes" DataField="CGCodes" ItemStyle-Width="120px" HeaderStyle-Width="120px" HeaderStyle-Wrap="false"
                                                ItemStyle-Wrap="false" AllowFiltering="true" Visible="true" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" AllowSorting="true"
                                                ItemStyle-CssClass="Row1" FilterControlWidth="80px">
                                                <HeaderStyle Wrap="False"></HeaderStyle>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="VPC" DataField="VPC" ItemStyle-Width="100px" HeaderStyle-Width="100px" HeaderStyle-Wrap="false"
                                                ItemStyle-Wrap="false" AllowFiltering="true" Visible="true" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" AllowSorting="true"
                                                ItemStyle-CssClass="Row1" FilterControlWidth="80px">
                                                <HeaderStyle Wrap="False"></HeaderStyle>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Rank" DataField="Rank" ItemStyle-Width="80px" HeaderStyle-Width="80px" HeaderStyle-Wrap="false"
                                                ItemStyle-Wrap="false" AllowFiltering="true" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" AllowSorting="true"
                                                ItemStyle-CssClass="Row1" FilterControlWidth="50px">
                                                <HeaderStyle Wrap="False"></HeaderStyle>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Percent Share" DataField="PercentShare" ItemStyle-Width="100px" HeaderStyle-Width="100px" HeaderStyle-Wrap="false"
                                                ItemStyle-Wrap="false" AllowFiltering="true" Visible="true" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" AllowSorting="true"
                                                ItemStyle-CssClass="Row1" FilterControlWidth="80px">
                                                <HeaderStyle Wrap="False"></HeaderStyle>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Rate of Increase" DataField="RateofIncrease" ItemStyle-Width="100px" HeaderStyle-Width="100px" HeaderStyle-Wrap="false"
                                                ItemStyle-Wrap="false" AllowFiltering="true" Visible="true" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" AllowSorting="true"
                                                ItemStyle-CssClass="Row1" FilterControlWidth="50px">
                                                <HeaderStyle Wrap="False"></HeaderStyle>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </telerik:GridBoundColumn>





                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <PagerStyle AlwaysVisible="True"></PagerStyle>
                                    </MasterTableView>
                                    <ClientSettings>
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <FilterMenu Skin="Simple" EnableTheming="True">
                                        <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
                                    </FilterMenu>
                                </telerik:RadGrid>
                            </td>

                        </asp:Panel>




                    </tr>

                </table>
            </td>

        </tr>
    </table>

</asp:Content>