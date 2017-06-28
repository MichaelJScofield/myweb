<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="BookManage.aspx.cs" Inherits="BookManage_BookManage" Title="Untitled Page" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" align="right" class="daohang1">&nbsp;</td>
            </tr>
            <tr>
              <td height="22" background="../images/tu shu pai hang2.gif"><table width="756" height="77" border="0" align="right" cellpadding="0" cellspacing="0">
                <tr>
                  <td height="45" colspan="3" align="right" background="../images/danganguanli.gif">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="622" height="32" align="right"><img src="../images/tianjia tubiao.gif" width="19" height="18"></td>
                  <td width="89" align="right" class="daohang1"><asp:HyperLink ID="hpLinkAddBook" runat="server" NavigateUrl="~/BookManage/AddBook.aspx" ForeColor="Black">添加图书信息</asp:HyperLink></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/tu shu pai hang2.gif"><asp:GridView ID="gvBookInfo" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvBookInfo_PageIndexChanging" OnRowDeleting="gvBookInfo_RowDeleting"  Width="678px" HorizontalAlign="Center">
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DFF5F5" />
                    <Columns>
                        <asp:BoundField DataField="bookcode" HeaderText="条形码" ReadOnly="True" />
                        <asp:BoundField DataField="bookname" HeaderText="图书名称" />
                        <asp:BoundField DataField="type" HeaderText="图书类型" />
                        <asp:BoundField DataField="pubname" HeaderText="出版社" />
                        <asp:BoundField DataField="bcase" HeaderText="书架" />
                        <asp:BoundField DataField="storage" HeaderText="库存总数" />
                        <asp:HyperLinkField DataNavigateUrlFormatString="AddBook.aspx?bookcode={0}" HeaderText="详情"
                            Text="详情" DataNavigateUrlFields="bookcode" >
                            <ControlStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            <HeaderStyle ForeColor="Black" />
                        </asp:HyperLinkField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
                            <HeaderStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            <ControlStyle ForeColor="Black" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
                <p>&nbsp;</p></td>
            </tr>
            <tr>
              <td height="4" valign="top" background="../images/tu shu pai hang3.gif"></td>
            </tr>
            
          </table>
            </td>
        </tr>
      </table>
</asp:Content>

