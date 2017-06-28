<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="ReaderBorrowSort.aspx.cs" Inherits="SortManage_ReaderBorrowSort" Title="Untitled Page"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1"
        class="waikuang">
        <tr>
            <td valign="top">
                <table align="center" style="width: 628px; height: 91px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="777" height="472" valign="top">
                            <table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="24">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="756" height="45" background="../images/zu zhe pai hang.gif">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="200" background="../images/tu shu pai hang2.gif">
                                        <asp:GridView ID="gvReaderSort" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            Font-Size="9pt" ForeColor="#333333" HorizontalAlign="Center" Width="678px" OnRowDataBound="gvReaderSort_RowDataBound"
                                            AllowPaging="True" OnPageIndexChanging="gvReaderSort_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField HeaderText="排名" />
                                                <asp:BoundField DataField="id" HeaderText="读者编号" />
                                                <asp:BoundField DataField="name" HeaderText="读者姓名" />
                                                <asp:BoundField DataField="type" HeaderText="读者类型" />
                                                <asp:BoundField DataField="paperType" HeaderText="证件类型" />
                                                <asp:BoundField DataField="paperNum" HeaderText="证件号码" />
                                                <asp:BoundField DataField="tel" HeaderText="电话" />
                                                <asp:BoundField DataField="sex" HeaderText="性别" />
                                            </Columns>
                                            <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="4" background="../images/tu shu pai hang3.gif">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
