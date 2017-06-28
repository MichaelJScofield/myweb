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
/// BookcaseManage 的摘要说明
/// </summary>
public class BookcaseManage
{
	public BookcaseManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义书架信息--数据结构
    private string id = "";
    private string name = "";
    /// <summary>
    /// 书架编号
    /// </summary>
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    /// <summary>
    /// 书架名称
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    #endregion

    #region 自动生成书架编号
    /// <summary>
    /// 自动生成书架编号
    /// </summary>
    /// <returns></returns>
    public string GetBcaseID()
    {
        DataSet ds = GetAllBCase("tb_bookcase");
        string strBcaseID = "";
        if (ds.Tables[0].Rows.Count == 0)
            strBcaseID = "SJ1001";
        else
            strBcaseID = "SJ" + (Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0].ToString().Substring(2, 4)) + 1);
        return strBcaseID;
    }
    #endregion

    #region 添加--书架信息
    /// <summary>
    /// 添加--书架信息
    /// </summary>
    /// <param name="bookcasemanage"></param>
    /// <returns></returns>
    public int AddBookcase(BookcaseManage bookcasemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, bookcasemanage.ID),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,bookcasemanage.Name),
			};
        return (data.RunProc("INSERT INTO tb_bookcase (id,name) VALUES(@id,@name)", prams));
    }
    #endregion

    #region 修改--书架信息
    /// <summary>
    /// 修改--书架信息
    /// </summary>
    /// <param name="bookcasemanage"></param>
    /// <returns></returns>
    public int UpdateBookcase(BookcaseManage bookcasemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, bookcasemanage.ID),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,bookcasemanage.Name),
			};
        return (data.RunProc("update tb_bookcase set name=@name where id=@id", prams));
    }
    #endregion

    #region 删除--书架信息
    /// <summary>
    /// 删除--书架信息
    /// </summary>
    /// <param name="bookcasemanage"></param>
    /// <returns></returns>
    public int DeleteBookcase(BookcaseManage bookcasemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, bookcasemanage.ID),
			};
        return (data.RunProc("delete from tb_bookcase where id=@id", prams));
    }
    #endregion

    #region 查询--书架信息
    /// <summary>
    /// 根据--书架编号--得到书架信息
    /// </summary>
    /// <param name="bookcasemanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBCaseByID(BookcaseManage bookcasemanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, bookcasemanage.ID+"%"),
			};
        return (data.RunProcReturn("select * from tb_bookcase where id like @id", prams, tbName));
    }
    /// <summary>
    /// 根据--书架名称--得到书架信息
    /// </summary>
    /// <param name="bookcasemanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBCaseByName(BookcaseManage bookcasemanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@name",  SqlDbType.VarChar, 50,bookcasemanage.Name+"%"),
			};
        return (data.RunProcReturn("select * from tb_bookcase where name like @name", prams, tbName));
    }
    /// <summary>
    /// 得到所有--书架信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllBCase(string tbName)
    {
        return (data.RunProcReturn("select * from tb_bookcase ORDER BY id", tbName));
    }
    #endregion
}
