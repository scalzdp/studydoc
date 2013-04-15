using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scal.IT.Log
{
    /// <summary>
    /// 主体接口
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 写文件日志函数
        /// </summary>
        /// <param name="arg">日志Entity</param>
        /// <returns></returns>
        bool WriteLog(LogEntity arg);
    }


    /// <summary>
    /// 查询接口
    /// </summary>
    public interface IlogSearch
    {
        /// <summary>
        /// 按ID查询单条日志
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        LogEntity SearchLogSingle(int ID);
        /// <summary>
        /// 按条件查询全部日志
        /// </summary>
        /// <param name="whereClause">查询条件</param>
        /// <param name="OrderBy">排序条件</param>
        /// <returns></returns>
        List<LogEntity> SearchLogCollection(string whereClause, string OrderBy);

        /// <summary>
        /// 按条件查询日志并分页
        /// </summary>
        /// <param name="whereClause">查询条件</param>
        /// <param name="OrderBy">排序条件</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="totalSize">总条数</param>
        /// <param name="totalPage">总页数</param>
        /// <returns></returns>
        List<LogEntity> SearchLogCollection(string whereClause, string OrderBy, int pageSize, int pageNumber, out int totalSize, out int totalPage);
    }
}
