<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="BookBorrowSort.aspx.cs" Inherits="SortManage_BookBorrowSort" Title="Untitled Page"
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
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="756" height="45" background="../images/tu shu pai hang.gif">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="200" background="../images/tu shu pai hang2.gif">
                                        <asp:GridView ID="gvBookSort" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            Font-Size="9pt" ForeColor="#333333" HorizontalAlign="Center" Width="678px" OnRowDataBound="gvBookSort_RowDataBound"
                                            AllowPaging="True" OnPageIndexChanging="gvBookSort_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField HeaderText="排名" />
                                                <asp:BoundField DataField="bookcode" HeaderText="图书条形码" ReadOnly="True" />
                                                <asp:BoundField DataField="bookname" HeaderText="图书名称" />
                                                <asp:BoundField DataField="type" HeaderText="图书类型" />
                                                <asp:BoundField DataField="bcase" HeaderText="书架" />
                                                <asp:BoundField DataField="pubname" HeaderText="出版社" />
                                                <asp:BoundField DataField="author" HeaderText="作者" />
                                                <asp:BoundField DataField="price" HeaderText="定价" />
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
