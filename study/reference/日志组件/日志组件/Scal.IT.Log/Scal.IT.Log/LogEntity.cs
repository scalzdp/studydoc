using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scal.IT.Log
{
    


    /// <summary>
    /// 数据库日志Entity类
    /// 柳忠松
    /// </summary>
    public class LogEntity
    {
        #region 字段定义
        private long _ID = 0; //标识
        private int _associateID = 0; //外部关联ID
        private string _moduleName = String.Empty; //模块名称
        private string _logContent = String.Empty; //日志内容
        private int _logType = 0; //日志类型，0：普通信息，1：错误信息，2：警告信息
        private string _operateType = String.Empty;//操作类型
        private DateTime _createTime = DateTime.Now; //记录时间
        private string _name = String.Empty; //记录人
        private int _f1 = 0; //附件字段1
        private string _f2 = String.Empty; //附件字段2



        #endregion

        #region 构造函数
        /// <summary>
        /// Initialize an new empty LogDBEntity object.
        /// </summary>
        public LogEntity()
        {
        }


        /// <summary>
        /// Initialize a new LogDBEntity object with the given parameters.
        /// </summary>
        public LogEntity(long ID, int associateID, string moduleName, string logContent, int logType, string operateType, DateTime createTime, string name, int f1, string f2)
        {
            this._ID = ID; //标识
            this._associateID = associateID; //外部关联ID
            this._moduleName = moduleName; //模块名称
            this._logContent = logContent;//日志内容
            this._createTime = createTime; //记录时间
            this._name = name;//记录人
            this._f1 = f1; //附件字段1
            this._f2 = f2; //附件字段2
            this._operateType = operateType;//操作类型
            this._logType = logType;// 日志类型，0：普通信息，1：错误信息，2：警告信息
        }



        #endregion

        #region 属性定义
        /// <summary>
        /// 标识
        /// </summary>
        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        /// <summary>
        /// 外部关联ID
        /// </summary>
        public int AssociateID
        {
            get { return _associateID; }
            set { _associateID = value; }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName
        {
            get { return _moduleName.Trim(); }
            set { _moduleName = value.Trim(); }
        }

        /// <summary>
        /// 日志类型，0：普通信息，1：错误信息，2：警告信息
        /// </summary>
        public int LogType
        {
            get { return _logType; }
            set { _logType = value; }
        }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogContent
        {
            get { return _logContent.Trim(); }
            set { _logContent = value.Trim(); }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperateType
        {
            get { return _operateType; }
            set { _operateType = value; }
        }


        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        /// <summary>
        /// 记录人
        /// </summary>
        public string Name
        {
            get { return _name.Trim(); }
            set { _name = value.Trim(); }
        }

        /// <summary>
        /// 附件字段1
        /// </summary>
        public int F1
        {
            get { return _f1; }
            set { _f1 = value; }
        }

        /// <summary>
        /// 附件字段2
        /// </summary>
        public string F2
        {
            get { return _f2.Trim(); }
            set { _f2 = value.Trim(); }
        }

        #endregion

    } // end of LogDBEntity class





}
