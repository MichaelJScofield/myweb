<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="BorrowBook.aspx.cs" Inherits="BookBRManage_BorrowBook" Title="Untitled Page"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr><form name="form1" method="post" action="">
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="15" colspan="3" align="right">&nbsp;</td>
            </tr>
            <tr>
              <td height="45" colspan="3" background="../images/tushujieyue.gif"></td>
            </tr>
                  <tr>
              <td height="100" colspan="3" background="../images/tu shu pai hang2.gif"><table width="740" height="100" border="0" align="center" cellspacing="0">
                <tr>
                  <td class="waikuang"><table width="718" border="0" align="center" cellspacing="0">
                    <tr>
                      <td height="27" colspan="2" width="205"><img src="../images/zuzheyanzheng.gif" width="133" height="18"></td>
                      <td width="1" rowspan="3"><img src="../images/shuxian.jpg" width="1" height="76"></td>
                      <td width="111" align="center" class="daohang1">姓名：</td>
                      <td width="162"><label>
                        <asp:TextBox ID="txtReader" runat="server" ReadOnly="True"></asp:TextBox>
                      </label></td>
                      <td width="73" class="daohang1">性别：</td>
                      <td width="166"><asp:TextBox ID="txtSex" runat="server" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td height="28" colspan="2" class="daohang1">读者编号：</td>
                      <td align="center" class="daohang1">证件类型：</td>
                      <td><asp:TextBox ID="txtPaperType" runat="server" ReadOnly="True"></asp:TextBox></td>
                      <td width="73" class="daohang1">证件号码：</td>
                      <td width="166"><asp:TextBox ID="txtPaperNum" runat="server" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td width="149"><label>
                        <asp:TextBox ID="txtReaderID" runat="server" Width="98px"></asp:TextBox>
                      </label></td>
                      <td width="56" align="center"><label>
                        <asp:Button ID="btnSure" runat="server" Text="确定" OnClick="btnSure_Click" />
                      </label></td>
                      <td align="center" class="daohang1">读者类型：</td>
                      <td><asp:TextBox ID="txtRType" runat="server" ReadOnly="True"></asp:TextBox></td>
                      <td width="73" class="daohang1">可借数量：</td>
                      <td width="166"><asp:TextBox ID="txtBNum" runat="server" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                  </table></td>
                  </tr>
              </table></td>
            </tr>
                  <tr>
                    <td colspan="3" valign="top" background="../images/tu shu pai hang2.gif"><table width="745" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                          <td align="center"></td>
                        </tr>
                        <tr>
                          <td height="5" colspan="2"><table width="722" height="30" border="1" align="center" cellpadding="0" cellspacing="0" bordercolorlight="#C2D7E4" bordercolordark="#FFFFFF">
                              <tr>
                                <td height="28"><table width="735" height="23" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                      <td bgcolor="#ACF2F1">&nbsp;&nbsp;图书借阅</td>
                                    </tr>
                                </table></td>
                              </tr>
                          </table></td>
                        </tr>
                      </table>
                        <asp:GridView ID="gvBookInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" Font-Size="9pt" HorizontalAlign="Center"
                    OnPageIndexChanging="gvBookInfo_PageIndexChanging"
                    PageSize="5" Width="678px" OnRowUpdating="gvBookInfo_RowUpdating" OnSelectedIndexChanged="gvBookInfo_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="bookcode" HeaderText="条形码" ReadOnly="True" />
                        <asp:BoundField DataField="bookname" HeaderText="图书名称" />
                        <asp:BoundField DataField="type" HeaderText="图书类型" />
                        <asp:BoundField DataField="pubname" HeaderText="出版社" />
                        <asp:BoundField DataField="bcase" HeaderText="书架" />
                        <asp:BoundField DataField="storage" HeaderText="库存总数" />
                        <asp:TemplateField HeaderText="借阅">
                            <ItemTemplate>
                                <asp:Button ID="btnBorrow" runat="server" CommandName="Update" Text="借阅" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DFF5F5" />
                </asp:GridView></td>
                  </tr>
            <tr>
              <td colspan="3" valign="top" background="images/tu shu pai hang2.gif"><table width="745" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="center" style="height: 19px"></td>
                  </tr>
                <tr>
                  <td height="5" colspan="2"><table width="722" height="30" border="1" align="center" cellpadding="0" cellspacing="0" bordercolorlight="#C2D7E4" bordercolordark="#FFFFFF">
                    <tr>
                      <td height="28"><table width="735" height="23" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                          <td bgcolor="#ACF2F1">&nbsp;&nbsp;读者所借图书</td>
                          </tr>
                      </table></td>
                      </tr>

                  </table>                    </td>
                </tr>
                
                
              </table>
                <asp:GridView ID="gvBorrowBook" runat="server" AllowPaging="True" AutoGenerateColumns="False" Font-Size="9pt" HorizontalAlign="Center"
                    OnPageIndexChanging="gvBorrowBook_PageIndexChanging"
                    PageSize="5" Width="678px">
                    <Columns>
                        <asp:BoundField DataField="bookname" HeaderText="图书名称" />
                        <asp:BoundField DataField="borrowTime" HeaderText="借阅时间" />
                        <asp:BoundField DataField="ygbackTime" HeaderText="应还时间" />
                        <asp:BoundField DataField="pubname" HeaderText="出版社" />
                        <asp:BoundField DataField="bcase" HeaderText="书架" />
                        <asp:BoundField DataField="price" HeaderText="价格" />
                    </Columns>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DFF5F5" />
                </asp:GridView><br>
</td>
              </tr>
            <tr>
              <td height="4" colspan="3" valign="top" background="../images/tu shu pai hang3.gif"></td>
            </tr>
            
          </table>
            </td></form>
        </tr>
      </table>
</asp:Content>

