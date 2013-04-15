

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;


namespace Scal.IT.Log
{
    /// <summary>
    /// 本业务逻辑层(Business Logic Layer)组件提供了操作 LogEntity 对象的功能。
	/// liu  2012年4月24日 星期二
    /// </summary>
    public class CLogBLL
    {
		#region 字段定义
		#endregion
		
		#region 构造函数
        /// <summary>
        /// 构造一个新的 CLogBLL 对象。
        /// </summary>
        public CLogBLL()
        {
        }
		#endregion
		
		#region 属性定义
		#endregion
		


		#region 方法定义

        /// <summary>
        /// 添加日志表与存储过程整套流程
        /// </summary>
        /// <returns></returns>
        public static bool AddTableAndProc()
        {
            if (IsExistLogTable())
            {
                return true;
            }
            else
            {
                if (AddLogTable() && AddLogListProc() && AddLogInsertProc() && AddLogSingleProc())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 判断日志表是否存在
        /// </summary>
        /// <returns></returns>
        public static bool IsExistLogTable()
        {
            try
            {
                CLogDAL d = new CLogDAL();
                if (d.IsExistLogTable() == "yes")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        /// <summary>
        /// 添加日志表
        /// </summary>
        /// <returns></returns>
        public static bool AddLogTable()
        {
            try
            {
                CLogDAL d = new CLogDAL();
                return d.AddLogTable();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 添加日志表查询存储过程
        /// </summary>
        /// <returns></returns>
        public static bool AddLogListProc()
        {
            try
            {
                CLogDAL d = new CLogDAL();
                return d.AddLogListProc();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 添加日志表查询存储过程
        /// </summary>
        /// <returns></returns>
        public static bool AddLogInsertProc()
        {
            try
            {
                CLogDAL d = new CLogDAL();
                return d.AddLogInsertProc();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 添加日志表单条查询存储过程
        /// </summary>
        /// <returns></returns>
        public static bool AddLogSingleProc()
        {
            try
            {
                CLogDAL d = new CLogDAL();
                return d.AddLogSingleProc();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

		/// <summary>
		/// 用指定的ID，取得 LogEntity 对象。
        /// </summary>
        /// <param name="ID">主键值</param>
        /// <returns>成功返回 LogEntity 对象；失败返回null。</returns>
        public static LogEntity Load(long ID)
        {
			try
			{
            	CLogDAL d = new CLogDAL();
				return d.Load(ID);
			}
			catch(Exception ex)
			{
				throw ex;	
			}
        }
		
		/// <summary>
		/// 用给定的条件，取得 LogEntity 对象集合。
		/// </summary>
		/// <param name="whereClause">sql条件语句</param>
		/// <param name="OrderBy">sql排序语句</param>
		/// <returns>LogEntity 对象集合</returns>
		public static List<LogEntity> LoadCollection(string whereClause, string OrderBy)
		{
			try
			{
				int pageSize = 0;
				int pageNumber = 1;
				int totalSize = 0;
				int totalPage = 0;
				return LoadCollection(whereClause, OrderBy, pageSize, pageNumber, out totalSize, out totalPage);
			}
			catch(Exception ex)
			{
				throw ex;	
			}
		}
		
		/// <summary>
		/// 用给定的条件，取得 LogEntity 对象集合。本方法支持分页。
		/// </summary>
		/// <param name="whereClause">sql条件语句</param>
		/// <param name="OrderBy">sql排序语句</param>
		/// <param name="pageSize">返回结果分页的每页数量，为0表示不分页。</param>
		/// <param name="pageNumber">当前页号</param>
		/// <param name="totalSize">总数量</param>
		/// <param name="totalPage">总页数</param>
		/// <returns>LogEntity 对象集合</returns>
		public static List<LogEntity> LoadCollection(string whereClause, string OrderBy, int pageSize, int pageNumber, out int totalSize, out int totalPage)
		{
			try
			{
				totalSize = 0;
				totalPage = 0;
				List<LogEntity> result;
				
				CLogDAL d = new CLogDAL();
				result = d.LoadCollection(whereClause, OrderBy, pageSize, pageNumber, out totalSize, out totalPage);
				
				return result;
			}
			catch(Exception ex)
			{
				throw ex;	
			}
		}
		
		/// <summary>
        /// 添加一个 LogEntity 对象
        /// </summary>
        /// <param name="obj">将要添加的 LogEntity 对象</param>
		public static void Insert(ref LogEntity obj)
        {
			//DbTransaction trans = null; //使用事务方式：声明事务对象
			try
			{
            	CLogDAL d = new CLogDAL();
				d.Insert(ref obj);
				//trans = d.CreateTransaction(); //使用事务方式：创建事务
                //d.Insert(ref obj, trans); //使用事务方式：操作数据
				
				//如果DAL组件返回代码不为0，说明操作错误。
                if (d.ReturnCode != 0)
                {
                    throw new Exception(d.ReturnMessage);
                }
				
				//trans.Commit(); //使用事务方式：提交事务
			}
			catch(Exception ex)
			{
				//trans.Rollback(); //使用事务方式：回滚事务
				throw ex;	
			}
        }

		
		#endregion

    } // end of CLogBLL class
    
} // end of Scal.CMS2011.Components.BLL namespace 

