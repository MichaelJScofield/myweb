<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Global_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table align="center" style="width: 628px; height: 91px">
        <tr>
      <td height="9" background="../images/index_08.gif"></td>
    </tr>
    <tr>
      <td width="777" height="472"><table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td height="24">&nbsp;</td>
            </tr>
            <tr>
              <td width="756" height="45" background="../images/tu shu pai hang.gif">&nbsp;</td>
            </tr>
            <tr>
              <td height="200" background="../images/tu shu pai hang2.gif">
              <asp:GridView ID="gvBookSort" runat="server" AutoGenerateColumns="False" Font-Size="9pt" HorizontalAlign="Center"
                    PageSize="5" Width="678px" OnRowDataBound="gvBookSort_RowDataBound">
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
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView></td>
            </tr>
            <tr>
              <td height="4" background="../images/tu shu pai hang3.gif"></td>
            </tr>
            <tr>
        <td colspan="6" style="text-align: right">
            <asp:HyperLink ID="hpLinkBookSort" runat="server" NavigateUrl="~/SortManage/BookBorrowSort.aspx" ImageUrl="~/images/more.gif"></asp:HyperLink></td>
    </tr>
          </table>
            <table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td height="4"></td>
              </tr>
              <tr>
                <td width="756" height="45" background="../images/zu zhe pai hang.gif">&nbsp;</td>
              </tr>
              <tr>
                <td height="200" background="../images/tu shu pai hang2.gif"><asp:GridView ID="gvReaderSort" runat="server" AutoGenerateColumns="False" Font-Size="9pt" HorizontalAlign="Center"
                    PageSize="5" Width="678px" OnRowDataBound="gvReaderSort_RowDataBound">
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
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView></td>
              </tr>
              <tr>
                <td height="4" background="../images/tu shu pai hang3.gif"></td>
              </tr>
              <tr>
        <td colspan="6" style="text-align: right">
            <asp:HyperLink ID="hpLinkReaderSort" runat="server" NavigateUrl="~/SortManage/ReaderBorrowSort.aspx" ImageUrl="~/images/more.gif"></asp:HyperLink></td>
    </tr>
            </table></td>
        </tr>
      </table></td>
    </table>
</asp:Content>

