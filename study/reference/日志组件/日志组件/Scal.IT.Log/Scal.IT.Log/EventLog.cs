using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Scal.IT.Log
{
    public class EventLog:ILog
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EventLog()
        {

        }

        /// <summary>
        /// 写系统日志函数
        /// </summary>
        /// <param name="arg">LogEventEntity系统日志Entity</param>
        /// <returns></returns>
        public bool WriteLog(LogEntity arg)
        {
            try
            {
                string source = ConfigurationManager.AppSettings["Scal.IT.Log.EventSouce"].ToString();

                System.Diagnostics.EventLog.WriteEntry(source, Tools.OrganiseContent(arg), Tools.EventLogType(arg.LogType));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






    }
}
