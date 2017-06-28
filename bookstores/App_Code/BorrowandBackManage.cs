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
/// BorrowandBackManage 的摘要说明
/// </summary>
public class BorrowandBackManage
{
	public BorrowandBackManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义图书借还信息--数据结构
    private string id = "";
    private string readid = "";
    private string bookcode = "";
    private DateTime borrowtime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private DateTime ygbacktime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private DateTime sjbacktime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private string borrowoper = "";
    private string backoper = "";
    private bool isback = false;

    private string bookname = "";
    private string name = "";
    private DateTime fromtime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private DateTime totime = Convert.ToDateTime(DateTime.Now.ToShortDateString());

    /// <summary>
    /// 借书编号
    /// </summary>
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    /// <summary>
    /// 读者编号
    /// </summary>
    public string ReadID
    {
        get { return readid; }
        set { readid = value; }
    }
    /// <summary>
    /// 图书条形码
    /// </summary>
    public string BookCode
    {
        get { return bookcode; }
        set { bookcode = value; }
    }
    /// <summary>
    /// 借书时间
    /// </summary>
    public DateTime BorrowTime
    {
        get { return borrowtime; }
        set { borrowtime = value; }
    }
    /// <summary>
    /// 应该还书时间
    /// </summary>
    public DateTime YGBackTime
    {
        get { return ygbacktime; }
        set { ygbacktime = value; }
    }
    /// <summary>
    /// 实际还书时间
    /// </summary>
    public DateTime SJBackTime
    {
        get { return sjbacktime; }
        set { sjbacktime = value; }
    }
    /// <summary>
    /// 借书操作员
    /// </summary>
    public string BorrowOper
    {
        get { return borrowoper; }
        set { borrowoper = value; }
    }
    /// <summary>
    /// 还书操作员
    /// </summary>
    public string BackOper
    {
        get { return backoper; }
        set { backoper = value; }
    }
    /// <summary>
    /// 是否归还
    /// </summary>
    public bool IsBack
    {
        get { return isback; }
        set { isback = value; }
    }
    /// <summary>
    /// 图书名称
    /// </summary>
    public string BookName
    {
        get { return bookname; }
        set { bookname = value; }
    }
    /// <summary>
    /// 读者名称
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime FromTime
    {
        get { return fromtime; }
        set { fromtime = value; }
    }
    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime ToTime
    {
        get { return totime; }
        set { totime = value; }
    }
    #endregion

    #region 自动生成借书编号
    /// <summary>
    /// 自动生成借书编号
    /// </summary>
    /// <returns></returns>
    public string GetBorrowBookID()
    {
        DataSet ds = GetAllBoBaBook("tb_borrowandback");
        string strBorrowBookID = "";
        if (ds.Tables[0].Rows.Count == 0)
            strBorrowBookID = "JS10001";
        else
            strBorrowBookID = "JS" + (Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0].ToString().Substring(2, 5)) + 1);
        return strBorrowBookID;
    }
    #endregion

    #region 添加--借书信息
    /// <summary>
    /// 添加--借书信息
    /// </summary>
    /// <param name="borrowandbackmanage"></param>
    /// <returns></returns>
    public int AddBorrow(BorrowandBackManage borrowandbackmanage)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@id",  SqlDbType.VarChar, 30, borrowandbackmanage.ID ),
                data.MakeInParam("@readerid",  SqlDbType.VarChar, 20,borrowandbackmanage.ReadID ),
                data.MakeInParam("@bookcode",  SqlDbType.VarChar, 30, borrowandbackmanage.BookCode ),
                data.MakeInParam("@borrowTime",  SqlDbType.DateTime, 8, borrowandbackmanage.BorrowTime ),
                data.MakeInParam("@ygbackTime",  SqlDbType.DateTime, 8, borrowandbackmanage.YGBackTime ),
                data.MakeInParam("@borrowoper",  SqlDbType.VarChar, 30, borrowandbackmanage.BorrowOper ),
			};
        return (data.RunProc("INSERT INTO tb_borrowandback (id,readerid,bookcode,borrowTime,ygbackTime,borrowoper) "
            + "VALUES (@id,@readerid,@bookcode,@borrowTime,@ygbackTime,@borrowoper)", prams));
    }
    #endregion

    #region 修改--借书还书信息
    /// <summary>
    /// 修改--借书还书信息
    /// </summary>
    /// <param name="borrowandbackmanage"></param>
    /// <returns></returns>
    public int UpdateBackBook(BorrowandBackManage borrowandbackmanage)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@id",  SqlDbType.VarChar, 30, borrowandbackmanage.ID ),
                data.MakeInParam("@sjbackTime",  SqlDbType.DateTime, 8,borrowandbackmanage.SJBackTime ),
                data.MakeInParam("@backoper",  SqlDbType.VarChar, 30, borrowandbackmanage.BackOper ),
                data.MakeInParam("@isback",  SqlDbType.Bit, 1, borrowandbackmanage.IsBack ),
			};
        return (data.RunProc("update tb_borrowandback set sjbackTime=@sjbackTime,backoper=@backoper,isback=@isback where id=@id", prams));
    }
    #endregion

    #region 图书续借
    /// <summary>
    /// 图书续借
    /// </summary>
    /// <param name="borrowandbackmanage"></param>
    /// <returns></returns>
    public int RenewBook(BorrowandBackManage borrowandbackmanage)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@id",  SqlDbType.VarChar, 30, borrowandbackmanage.ID ),
                data.MakeInParam("@ygbackTime",  SqlDbType.DateTime, 8,borrowandbackmanage.YGBackTime ),
                data.MakeInParam("@borrowTime",  SqlDbType.DateTime, 8,borrowandbackmanage.BorrowTime )
			};
        return (data.RunProc("update tb_borrowandback set ygbackTime=@ygbackTime,borrowTime=@borrowTime where id=@id", prams));
    }
    #endregion

    #region 删除--借书还书信息
    /// <summary>
    /// 删除--借书还书信息
    /// </summary>
    /// <param name="borrowandbackmanage"></param>
    /// <returns></returns>
    public int DeleteBoBaBook(BorrowandBackManage borrowandbackmanage)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@id",  SqlDbType.VarChar, 30, borrowandbackmanage.ID ),
			};
        return (data.RunProc("delete from tb_borrowandback where id=@id", prams));
    }
    #endregion

    #region 查询--借书还书信息
    /// <summary>
    /// 根据--借书编号--得到借书还书信息
    /// </summary>
    /// <param name="borrowandbackmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBoBaBookByID(BorrowandBackManage borrowandbackmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@id",  SqlDbType.VarChar, 30, borrowandbackmanage.ID+"%"),
			};
        return (data.RunProcReturn("select * from view_BookBRInfo where id like @id", prams, tbName));
    }
    /// <summary>
    /// 根据--读者编号--得到借书还书信息
    /// </summary>
    /// <param name="borrowandbackmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBoBaBookByReaderID(BorrowandBackManage borrowandbackmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@readerid",  SqlDbType.VarChar, 20,borrowandbackmanage.ReadID+"%"),
			};
        return (data.RunProcReturn("select * from view_BookBRInfo where readerid like @readerid", prams, tbName));
    }
    /// <summary>
    /// 根据--读者名称--得到借书还书信息
    /// </summary>
    /// <param name="borrowandbackmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBoBaBookByReader(BorrowandBackManage borrowandbackmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@name",  SqlDbType.VarChar, 50,"%"+borrowandbackmanage.Name+"%"),
			};
        return (data.RunProcReturn("select * from view_BookBRInfo where name like @name", prams, tbName));
    }
    /// <summary>
    /// 根据--图书条形码--得到借书还书信息
    /// </summary>
    /// <param name="borrowandbackmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBoBaBookByBCode(BorrowandBackManage borrowandbackmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@bookcode",  SqlDbType.VarChar, 30, borrowandbackmanage.BookCode+"%"),
			};
        return (data.RunProcReturn("select * from view_BookBRInfo where bookcode like @bookcode", prams, tbName));
    }
    /// <summary>
    /// 根据--图书名称--得到借书还书信息
    /// </summary>
    /// <param name="borrowandbackmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBoBaBookByBName(BorrowandBackManage borrowandbackmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@bookname",  SqlDbType.VarChar, 50, "%"+borrowandbackmanage.BookCode+"%"),
			};
        return (data.RunProcReturn("select * from view_BookBRInfo where bookname like @bookname", prams, tbName));
    }
    /// <summary>
    /// 根据--借阅时间--得到借书还书信息
    /// </summary>
    /// <param name="borrowandbackmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBoBaBookByBoTime(BorrowandBackManage borrowandbackmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@fromtime",  SqlDbType.DateTime, 8, borrowandbackmanage.FromTime),
                data.MakeInParam("@totime",  SqlDbType.DateTime, 8, borrowandbackmanage.ToTime),
			};
        return (data.RunProcReturn("select * from view_BookBRInfo where borrowTime between @fromtime and @totime", prams, tbName));
    }
    /// <summary>
    /// 得到所有--借书还书信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllBoBaBook(string tbName)
    {
        return (data.RunProcReturn("select * from view_BookBRInfo ORDER BY id", tbName));
    }
    /// <summary>
    /// 得到所有--借书还书详细信息
    /// </summary>
    /// <param name="borrowandbackmanages"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBoBaBookByRID(BorrowandBackManage borrowandbackmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@readerid",  SqlDbType.VarChar, 20,borrowandbackmanage.ReadID +"%"),
			};
        return (data.RunProcReturn("select * from view_BookBRInfo where readerid like @readerid and isback=0", prams, tbName));
    }
    #endregion
}
