using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scal.IT.Log
{
    public class Tools
    {
        /// <summary>
        /// 组织日志内容
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string OrganiseContent(LogEntity arg)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("标识:" + arg.ID);
            builder.Append(" 外部关联ID:" + arg.AssociateID);
            builder.Append(" 模块名称:" + arg.ModuleName);
            builder.Append(" 日志内容:" + arg.LogContent);
            builder.Append(" 操作类型:" + arg.OperateType);
            builder.Append(" 记录时间:" + arg.CreateTime);
            builder.Append(" 记录人:" + arg.Name);
            builder.Append(" 附件字段1:" + arg.F1);
            builder.Append(" 附件字段2:" + arg.F2);
            return builder.ToString();
        }

        /// <summary>
        /// 根据日志类型转化为System.Diagnostics.EventLogEntryType类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static System.Diagnostics.EventLogEntryType EventLogType(int type)
        {
            System.Diagnostics.EventLogEntryType eventType;
            switch (type)
            {
                case 0:
                    {
                        eventType = System.Diagnostics.EventLogEntryType.Information;
                        break;
                    }
                case 1:
                    {
                        eventType = System.Diagnostics.EventLogEntryType.Error;
                        break;
                    }
                case 2:
                    {
                        eventType = System.Diagnostics.EventLogEntryType.Warning;
                        break;
                    }
                default:
                    {
                        eventType = System.Diagnostics.EventLogEntryType.Information;
                        break;
                    }
            }
            return eventType;
        }



        /// <summary>
        /// 根据日志类型转化为string类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string FileLogType(int type)
        {
            string eventType;
            switch (type)
            {
                case 0:
                    {
                        eventType = "普通信息";
                        break;
                    }
                case 1:
                    {
                        eventType = "错误信息";
                        break;
                    }
                case 2:
                    {
                        eventType = "警告信息";
                        break;
                    }
                default:
                    {
                        eventType = "普通信息";
                        break;
                    }
            }
            return eventType;
        }
    }
}
