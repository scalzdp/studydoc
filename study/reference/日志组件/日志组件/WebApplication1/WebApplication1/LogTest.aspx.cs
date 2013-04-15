using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Scal.IT.Log;
namespace WebApplication1
{
    public partial class LogTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            LogEntity arg = new LogEntity();
            arg.ID = 0;//日志ID
            arg.AssociateID = 12;////外部关联ID
            arg.ModuleName = "测试模块"; //模块名称
            arg.LogContent = "测试添加日志"; //日志内容
            arg.LogType = 0; //日志类型，0：普通信息，1：错误信息，2：警告信息
            arg.OperateType = "添加";//操作类型表征含义自定义
            arg.CreateTime = DateTime.Now; //记录时间
            arg.Name = "测试记录人"; //记录人
            arg.F1 = 0; //附件字段1
            arg.F2 = String.Empty; //附件字段2

            //ILog logFile = new FileLog();
            //logFile.WriteLog(arg);



            //ILog logEvent = new EventLog();
            //logEvent.WriteLog(arg);

            ILog logDB = new DBLog();
            logDB.WriteLog(arg);



            IlogSearch log = new DBLog();
            int totalSize = 0;
            int totalPage = 0;
            List<LogEntity> result = log.SearchLogCollection(" LogType = 0", " CreateTime DESC",
                20, 2, out totalSize, out totalPage);
            //第一个参数为查询条件，第二个参数为排序条件，第三个参数为页面大小，第四个参数为当前页，第五个参数返回日志总条数，第六个参数返回日志总页数


            GridView1.DataSource = log.SearchLogCollection("", "");
            GridView1.DataBind();


        }
    }
}