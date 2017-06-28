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

public partial class BookManage_AddBook : System.Web.UI.Page
{
    ValidateClass validate=new ValidateClass();
    BookcaseManage bookcasemanage = new BookcaseManage();
    BTypeManage btypemanage = new BTypeManage();
    BookManage bookmanage = new BookManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "添加/修改图书信息页面";
        if (!IsPostBack)
        {
            DataSet bcaseds = bookcasemanage.GetAllBCase("tb_bookcase");
            ddlBCase.DataSource = bcaseds;
            ddlBCase.DataTextField = "name";
            ddlBCase.DataBind();

            DataSet btypeds = btypemanage.GetAllBType("tb_booktype");
            ddlBType.DataSource = btypeds;
            ddlBType.DataTextField = "typename";
            ddlBType.DataBind();

            if (Request["bookcode"] == null)
            {
                btnAdd.Enabled = true;
                txtInTime.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                btnSave.Enabled = true;
                txtBCode.ReadOnly = txtBName.ReadOnly = true;
                txtBCode.Text = Request["bookcode"].ToString();
                bookmanage.BookCode = txtBCode.Text;
                DataSet bookds = bookmanage.FindBookByCode(bookmanage,"tb_bookinfo");
                txtBName.Text = bookds.Tables[0].Rows[0][1].ToString();
                ddlBType.SelectedValue = bookds.Tables[0].Rows[0][2].ToString();
                txtAuthor.Text = bookds.Tables[0].Rows[0][3].ToString();
                txtTranslator.Text = bookds.Tables[0].Rows[0][4].ToString();
                txtPub.Text = bookds.Tables[0].Rows[0][5].ToString();
                txtPrice.Text = bookds.Tables[0].Rows[0][6].ToString();
                txtPage.Text = bookds.Tables[0].Rows[0][7].ToString();
                ddlBCase.SelectedValue = bookds.Tables[0].Rows[0][8].ToString();
                txtStorage.Text = bookds.Tables[0].Rows[0][9].ToString();
                txtInTime.Text = bookds.Tables[0].Rows[0][10].ToString();
                txtOper.Text = bookds.Tables[0].Rows[0][11].ToString();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ValidateFun();
        bookmanage.BookCode = txtBCode.Text;
        if (bookmanage.FindBookByCode(bookmanage, "tb_bookinfo").Tables[0].Rows.Count > 0)
        {
            bookmanage.BookName = txtBName.Text;
            bookmanage.Type = ddlBType.SelectedValue;
            bookmanage.Author = txtAuthor.Text;
            bookmanage.Translator = txtTranslator.Text;
            bookmanage.PubName = txtPub.Text;
            bookmanage.Price = Convert.ToDecimal(txtPrice.Text);
            bookmanage.Page = Convert.ToInt32(txtPage.Text);
            bookmanage.Bcase = ddlBCase.SelectedValue;
            bookmanage.Storage = Convert.ToInt32(txtStorage.Text) + Convert.ToInt32(bookmanage.FindBookByCode(bookmanage, "tb_bookinfo").Tables[0].Rows[0][9].ToString());
            bookmanage.InTime = Convert.ToDateTime(txtInTime.Text);
            bookmanage.Oper = txtOper.Text;
            bookmanage.UpdateBook(bookmanage);
        }
        else
        {
            bookmanage.BookName = txtBName.Text;
            bookmanage.Type = ddlBType.SelectedValue;
            bookmanage.Author = txtAuthor.Text;
            bookmanage.Translator = txtTranslator.Text;
            bookmanage.PubName = txtPub.Text;
            bookmanage.Price = Convert.ToDecimal(txtPrice.Text);
            bookmanage.Page = Convert.ToInt32(txtPage.Text);
            bookmanage.Bcase = ddlBCase.SelectedValue;
            bookmanage.Storage = Convert.ToInt32(txtStorage.Text);
            bookmanage.InTime = Convert.ToDateTime(txtInTime.Text);
            bookmanage.Oper = txtOper.Text;
            bookmanage.AddBook(bookmanage);
        }
        Response.Redirect("BookManage.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValidateFun();
        bookmanage.BookCode = txtBCode.Text;
        bookmanage.BookName = txtBName.Text;
        bookmanage.Type = ddlBType.SelectedValue;
        bookmanage.Author = txtAuthor.Text;
        bookmanage.Translator = txtTranslator.Text;
        bookmanage.PubName = txtPub.Text;
        bookmanage.Price = Convert.ToDecimal(txtPrice.Text);
        bookmanage.Page = Convert.ToInt32(txtPage.Text);
        bookmanage.Bcase = ddlBCase.SelectedValue;
        bookmanage.Storage = Convert.ToInt32(txtStorage.Text);
        bookmanage.InTime = Convert.ToDateTime(txtInTime.Text);
        bookmanage.Oper = txtOper.Text;
        bookmanage.UpdateBook(bookmanage);
        Response.Redirect("BookManage.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtInTime.Text = DateTime.Now.ToShortDateString();
        txtBName.Text = txtAuthor.Text = txtTranslator.Text = txtPub.Text = txtPrice.Text = txtPage.Text = txtStorage.Text = txtOper.Text = string.Empty;
    }
    protected void ValidateFun()
    {
        if (txtBCode.Text == "")
        {
            Response.Write("<script>alert('图书条形码不能为空！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (txtBName.Text == "")
        {
            Response.Write("<script>alert('图书名称不能为空！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateNum(txtPrice.Text))
        {
            Response.Write("<script>alert('图书价格输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateNum(txtPage.Text))
        {
            Response.Write("<script>alert('图书页码输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateNum(txtStorage.Text))
        {
            Response.Write("<script>alert('图书库存量输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
    }
}

