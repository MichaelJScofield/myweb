using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// BookManage 的摘要说明
/// </summary>
public class BookManage
{
    public BookManage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    DataBase data = new DataBase();

    #region 定义图书信息--数据结构
    private string bookcode = "";
    private string bookname = "";
    private string type = "";
    private string author = "";
    private string translator = "";
    private string pubname = "";
    private decimal price = 0;
    private int page = 0;
    private string bcase = "";
    private int storage = 0;
    private DateTime intime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private string oper = "";
    private int borrownum = 0;

    /// <summary>
    /// 条形码
    /// </summary>
    public string BookCode
    {
        get { return bookcode; }
        set { bookcode = value; }
    }
    /// <summary>
    /// 书名
    /// </summary>
    public string BookName
    {
        get { return bookname; }
        set { bookname = value; }
    }
    /// <summary>
    /// 类型编号
    /// </summary>
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    /// <summary>
    /// 作者
    /// </summary>
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    /// <summary>
    /// 译者
    /// </summary>
    public string Translator
    {
        get { return translator; }
        set { translator = value; }
    }
    /// <summary>
    /// 出版社
    /// </summary>
    public string PubName
    {
        get { return pubname; }
        set { pubname = value; }
    }
    /// <summary>
    /// 价格
    /// </summary>
    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }
    /// <summary>
    /// 页码
    /// </summary>
    public int Page
    {
        get { return page; }
        set { page = value; }
    }
    /// <summary>
    /// 书架
    /// </summary>
    public string Bcase
    {
        get { return bcase; }
        set { bcase = value; }
    }
    /// <summary>
    /// 库存量
    /// </summary>
    public int Storage
    {
        get { return storage; }
        set { storage = value; }
    }
    /// <summary>
    /// 录入时间
    /// </summary>
    public DateTime InTime
    {
        get { return intime; }
        set { intime = value; }
    }
    /// <summary>
    /// 操作员
    /// </summary>
    public string Oper
    {
        get { return oper; }
        set { oper = value; }
    }
    /// <summary>
    /// 借阅次数
    /// </summary>
    public int BorrowNum
    {
        get { return borrownum; }
        set { borrownum = value; }
    }
    #endregion

    #region 添加--图书信息
    /// <summary>
    /// 添加--图书信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
    public int AddBook(BookManage bookmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@bookcode",  SqlDbType.VarChar, 30, bookmanage.BookCode),
            data.MakeInParam("@bookname",  SqlDbType.VarChar, 50,bookmanage.BookName ),
            data.MakeInParam("@type",  SqlDbType.VarChar, 50, bookmanage.Type ),
            data.MakeInParam("@author",  SqlDbType.VarChar, 50, bookmanage.Author ),
            data.MakeInParam("@translator",  SqlDbType.VarChar, 50, bookmanage.Translator ),
            data.MakeInParam("@pubname",  SqlDbType.VarChar, 100, bookmanage.PubName ),
            data.MakeInParam("@price",  SqlDbType.Money, 8, bookmanage.Price ),
            data.MakeInParam("@page",  SqlDbType.Int, 4,bookmanage.Page ),
            data.MakeInParam("@bcase",  SqlDbType.VarChar, 50, bookmanage.Bcase ),
            data.MakeInParam("@storage",  SqlDbType.BigInt, 8, bookmanage.Storage ),
            data.MakeInParam("@inTime",  SqlDbType.DateTime, 8, bookmanage.InTime ),
            data.MakeInParam("@oper",  SqlDbType.VarChar, 30, bookmanage.Oper ),
			};
        return (data.RunProc("INSERT INTO tb_bookinfo (bookcode,bookname,type,author,translator,pubname,price,page,bcase,storage,inTime,oper) "
            + "VALUES (@bookcode,@bookname,@type,@author,@translator,@pubname,@price,@page,@bcase,@storage,@inTime,@oper)", prams));
    }
    #endregion

    #region 修改--图书信息
    /// <summary>
    /// 修改--图书信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
    public int UpdateBook(BookManage bookmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@bookcode",  SqlDbType.VarChar, 30, bookmanage.BookCode),
            data.MakeInParam("@bookname",  SqlDbType.VarChar, 50,bookmanage.BookName ),
            data.MakeInParam("@type",  SqlDbType.VarChar, 50, bookmanage.Type ),
            data.MakeInParam("@author",  SqlDbType.VarChar, 50, bookmanage.Author ),
            data.MakeInParam("@translator",  SqlDbType.VarChar, 50, bookmanage.Translator ),
            data.MakeInParam("@pubname",  SqlDbType.VarChar, 100, bookmanage.PubName),
            data.MakeInParam("@price",  SqlDbType.Money, 8, bookmanage.Price ),
            data.MakeInParam("@page",  SqlDbType.Int, 4,bookmanage.Page ),
            data.MakeInParam("@bcase",  SqlDbType.VarChar, 50, bookmanage.Bcase ),
            data.MakeInParam("@storage",  SqlDbType.BigInt, 8, bookmanage.Storage ),
            data.MakeInParam("@inTime",  SqlDbType.DateTime, 8, bookmanage.InTime ),
            data.MakeInParam("@oper",  SqlDbType.VarChar, 30, bookmanage.Oper),
			};
        return (data.RunProc("update tb_bookinfo set bookname=@bookname,type=@type,author=@author,translator=@translator,pubname=@pubname,price=@price,"
            + "page=@page,bcase=@bcase,storage=@storage,inTime=@inTime,oper=@oper where bookcode=@bookcode", prams));
    }
    /// <summary>
    /// 每借一次图书就将图书的所借次数加一
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
    public int UpdateBorrowNum(BookManage bookmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@bookcode",  SqlDbType.VarChar, 30, bookmanage.BookCode),
            data.MakeInParam("@borrownum",  SqlDbType.Int, 4, bookmanage.BorrowNum),
			};
        return (data.RunProc("update tb_bookinfo set borrownum=@borrownum where bookcode=@bookcode", prams));
    }
    #endregion

    #region 删除--图书信息
    /// <summary>
    /// 删除--图书信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
    public int DeleteBook(BookManage bookmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@bookcode",  SqlDbType.VarChar, 30, bookmanage.BookCode),
			};
        return (data.RunProc("delete from tb_bookinfo where bookcode=@bookcode", prams));
    }
    #endregion

    #region 查询--图书信息
    /// <summary>
    /// 根据--图书编号--得到图书信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByCode(BookManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@bookcode",  SqlDbType.VarChar, 30, bookmanage.BookCode+"%"),
			};
        return (data.RunProcReturn("select * from tb_bookinfo where bookcode like @bookcode", prams, tbName));
    }
    /// <summary>
    /// 根据--图书名称--得到图书信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByName(BookManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@bookname",  SqlDbType.VarChar, 50,"%"+bookmanage.BookName+"%"),
			};
        return (data.RunProcReturn("select * from tb_bookinfo where bookname like @bookname", prams, tbName));
    }
    /// <summary>
    /// 根据--图书类型--得到图书信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByType(BookManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@type",  SqlDbType.VarChar, 50, "%"+bookmanage.Type+"%"),
			};
        return (data.RunProcReturn("select * from tb_bookinfo where type like @type", prams, tbName));
    }
    /// <summary>
    /// 根据--图书作者--得到图书信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByAuthor(BookManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@author",  SqlDbType.VarChar, 50, "%"+bookmanage.Author +"%"),
			};
        return (data.RunProcReturn("select * from tb_bookinfo where author like @author", prams, tbName));
    }
    /// <summary>
    /// 根据--出版社--得到图书信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByPub(BookManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@pubname",  SqlDbType.VarChar, 100, "%"+bookmanage.PubName +"%"),
			};
        return (data.RunProcReturn("select * from tb_bookinfo where pubname like @pubname", prams, tbName));
    }
    /// <summary>
    /// 根据--书架--得到图书信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByBCase(BookManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@bcase",  SqlDbType.VarChar, 50, "%"+bookmanage.Bcase +"%"),
			};
        return (data.RunProcReturn("select * from tb_bookinfo where bcase like @bcase", prams, tbName));
    }
    /// <summary>
    /// 得到所有--图书信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllBook(string tbName)
    {
        return (data.RunProcReturn("select * from tb_bookinfo ORDER BY bookcode", tbName));
    }
    /// <summary>
    /// 得到图书借阅排行的前5名
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetBookSort(string tbName)
    {
        return (data.RunProcReturn("select top 5* from tb_bookinfo where borrownum<>0 ORDER BY borrownum desc", tbName));
    }
    /// <summary>
    /// 得到所有图书借阅排行
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllBookSort(string tbName)
    {
        return (data.RunProcReturn("select * from tb_bookinfo where borrownum<>0 ORDER BY borrownum desc", tbName));
    }
    #endregion
}
