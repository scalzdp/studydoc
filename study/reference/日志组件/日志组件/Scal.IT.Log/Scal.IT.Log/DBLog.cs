using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scal.IT.Log
{
    public class DBLog:ILog,IlogSearch
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DBLog()
        {
        }

        /// <summary>
        /// 写文件日志函数
        /// </summary>
        /// <param name="arg">LogDBEntity数据库日志Entity</param>
        /// <returns></returns>
        public bool WriteLog(LogEntity arg)
        {
            LogEntity dbEntity = new LogEntity();
            dbEntity = (LogEntity)arg;
            try
            {
                CLogBLL.Insert(ref dbEntity);
                return true;
            }
            catch (Exception ex)
            {
                if (!CLogBLL.AddTableAndProc())
                {
                    throw ex;
                }
                else
                {
                    CLogBLL.Insert(ref dbEntity);
                    return true;
                }
            }
        }

        /// <summary>
        /// 按ID查询单条日志
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>LogDBEntity按ID查询单条日志</returns>
        public LogEntity SearchLogSingle(int ID)
        {
            try
            {
                return CLogBLL.Load(ID);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        /// <summary>
        /// 按条件查询全部日志
        /// </summary>
        /// <param name="whereClause">查询条件</param>
        /// <param name="OrderBy">排序条件</param>
        /// <returns>List<LogDBEntity>按条件查询全部日志</returns>
        public List<LogEntity> SearchLogCollection(string whereClause, string OrderBy)
        {
            try
            {
                return CLogBLL.LoadCollection(whereClause, OrderBy);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 按条件查询日志并分页
        /// </summary>
        /// <param name="whereClause">查询条件</param>
        /// <param name="OrderBy">排序条件</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="totalSize">总条数</param>
        /// <param name="totalPage">总页数</param>
        /// <returns>List<LogDBEntity>按条件查询日志并分页</returns>
        public List<LogEntity> SearchLogCollection(string whereClause, string OrderBy, int pageSize, int pageNumber, out int totalSize, out int totalPage)
        {
            try
            {
                return CLogBLL.LoadCollection(whereClause, OrderBy, pageSize, pageNumber, out totalSize, out totalPage);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
