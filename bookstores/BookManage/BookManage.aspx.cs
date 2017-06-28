using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class BookManage_BookManage : System.Web.UI.Page
{
    BookManage bookmanage = new BookManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "查看图书信息页面";
        if (!IsPostBack)
            gvBind();
    }
    protected void gvBookInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBookInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvBookInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bookmanage.BookCode = gvBookInfo.DataKeys[e.RowIndex].Value.ToString();
        bookmanage.DeleteBook(bookmanage);
        Response.Write("<script>alert('图书信息删除成功')</script>");
        gvBind();
    }
    private void gvBind()
    {
        DataSet ds = bookmanage.GetAllBook("tb_bookinfo");
        gvBookInfo.DataSource = ds;
        gvBookInfo.DataKeyNames = new string[] { "bookcode" };
        gvBookInfo.DataBind();
    }
}
