using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Text;

namespace Scal.IT.Log
{
    /// <summary>
    /// 本数据访问层(Data Access Layer)组件提供了访问数据库表 dbo.t_Scal_IT_Log 中数据的功能。
	/// liu  2012年4月24日 星期二
    /// </summary>
    public class CLogDAL
    {
		#region 字段定义
		private string _connectionString = ""; //数据库连接字符串
		private SqlConnection _sqlConnection = null; //数据库连接对象
		private int _returnCode = 0; //错误代码 0为成功，非 0 表示有错误，详见 _returnMessage
		private string _returnMessage = ""; //详细错误信息
		#endregion
		
		#region 构造函数
        /// <summary>
        /// 构造一个新的 CLogDAL 对象。
        /// </summary>
        public CLogDAL()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["Scal.IT.Log.DB"].ToString();
        }
		
		/// <summary>
        /// 用指定的数据库连接字符串构造一个新的 CLogDAL 对象。
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
		public CLogDAL(string connectionString)
        {
			this.ConnectionString = connectionString.Trim();
        }
		#endregion
		
		#region 属性定义
		/// <summary>
        /// 数据库连接字符串
        /// </summary>
		public string ConnectionString
		{
			set { _connectionString = value.Trim(); }
			get { return _connectionString.Trim(); }
		}
		
		/// <summary>
		/// 错误代码 0为成功，非 0 表示有错误，详见 ReturnMessage
		/// </summary>
		public int ReturnCode
		{
			get { return _returnCode; }
		}

		/// <summary>
		/// 详细错误信息
		/// </summary>
		public string ReturnMessage
		{
			get { return _returnMessage; }
		}
		#endregion
		
		#region 方法定义




        /// <summary>
        /// 判断日志表是否存在
        /// </summary>
        /// <returns></returns>
        public string IsExistLogTable()
        {
            string cmd = "declare @p varchar(10) IF objectProperty(object_id('t_Scal_IT_Log'),'IsUserTable')=1 begin set @p = 'yes' end ELSE begin set @p = 'no' end select @p";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.Text, cmd))
            {
                if (reader.Read())
                {
                    string result = reader[0].ToString();
                    return result;
                }
                else
                {
                    reader.Close();
                    return "no";
                }
            }
        }


        /// <summary>
        /// 添加日志表
        /// </summary>
        /// <returns></returns>
        public bool AddLogTable()
        {

            StringBuilder cmdBuild = new StringBuilder();
            cmdBuild.Append(@"SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[t_Scal_IT_Log](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AssociateID] [int] NULL,
	[ModuleName] [nvarchar](20) NOT NULL,
	[LogContent] [nvarchar](100) NOT NULL,
	[LogType] [int] NOT NULL,
	[OperateType] [nvarchar](20) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[F1] [int] NULL,
	[F2] [nvarchar](50) NULL,
 CONSTRAINT [PK_t_Scal_IT_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Scal_IT_Log', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部关联ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Scal_IT_Log', @level2type=N'COLUMN',@level2name=N'AssociateID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Scal_IT_Log', @level2type=N'COLUMN',@level2name=N'ModuleName'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Scal_IT_Log', @level2type=N'COLUMN',@level2name=N'LogContent'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志类型 0：正常信息，1：错误信息，2：警告信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Scal_IT_Log', @level2type=N'COLUMN',@level2name=N'LogType'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Scal_IT_Log', @level2type=N'COLUMN',@level2name=N'OperateType'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Scal_IT_Log', @level2type=N'COLUMN',@level2name=N'CreateTime'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Scal_IT_Log', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附件字段1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Scal_IT_Log', @level2type=N'COLUMN',@level2name=N'F1'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附件字段2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Scal_IT_Log', @level2type=N'COLUMN',@level2name=N'F2'
");
            string cmd = cmdBuild.ToString();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.Text, cmd))
            {
                return true;
            }
        }


        /// <summary>
        /// 添加日志表查询存储过程
        /// </summary>
        /// <returns></returns>
        public bool AddLogListProc()
        {

            StringBuilder cmdBuild = new StringBuilder();
            cmdBuild.Append(@"
------------------------------------------------------------------------------------------------------------------------
-- Date Created: 2012-04-26 17:35:59
-- Author: liu
-- Summary: 查询表 [t_Scal_IT_Log]() 中的数据
-- EXEC [dbo].[p_Scal_IT_Log_List]
------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[p_Scal_IT_Log_List]
	@FieldsClause VARCHAR(2000) = NULL, --查询列子句
	@WhereClause VARCHAR(2000) = NULL, --查询条件子句
	@OrderBy VARCHAR(2000) = NULL, --查询排序子句
	@PageSize INT = 0, -- 分页查询的每页数量，为0表示查询全部，不分页。
	@PageNumber INT = 1, -- 分页查询的当前页号
	@TotalSize INT OUTPUT, -- 返回值，查询结果记录条数
	@TotalPage INT OUTPUT -- 返回值，查询结果总页数
AS
BEGIN
	SET NOCOUNT ON
	-- 声明变量
	DECLARE @Sql NVARCHAR(4000) -- 用于保存动态组织的sql语句
	DECLARE @ParmDefinition NVARCHAR(500) -- 用于保存临时参数
	DECLARE @MinRowIndex INT -- 分页查询的最小行号
	DECLARE @MaxRowIndex INT -- 分页查询的最大行号

	-- 检查参数合法性，并设置为可用值
	SET @FieldsClause = LTRIM(RTRIM(ISNULL(@FieldsClause,'*'))) -- 缺省查询所有字段
	SET @WhereClause = LTRIM(RTRIM(ISNULL(@WhereClause,'')))
	SET @OrderBy = LTRIM(RTRIM(ISNULL(@OrderBy,'')))
	IF(@OrderBy = '') SET @OrderBy = '[ID]'
	IF(@PageSize < 0) SET @PageSize = 0
	IF(@PageNumber < 1) SET @PageNumber = 1

	IF(@PageSize = 0) -- 为0表示不分页
	BEGIN
		-- 如果不分页
		-- 组织查询语句
		SET @Sql = N'
		SELECT ' + @FieldsClause + ' FROM [dbo].[t_Scal_IT_Log]'
		
		-- 附加WHERE子句
		IF(@WhereClause <> '')
		BEGIN
		SET @Sql = @Sql + N'
		WHERE ' + @WhereClause
		END
		
		-- 附加ORDER子句
		IF(@OrderBy <> '')
		BEGIN
		SET @Sql = @Sql + N'
		ORDER BY ' + @OrderBy
		END
		
		-- 执行语句
		--PRINT @Sql
		EXEC(@Sql)
	
		-- 设置返回值
		SET @TotalSize = @@ROWCOUNT
		SET @TotalPage = 1
	END
	ELSE
	BEGIN
		-- 如果分页
		
		-- 检查：排序语句不能为空，建议至少使用主键做排序
		IF(@OrderBy = '')
		BEGIN
			RAISERROR(N'请务必给参数@OrderBy输入有效的排序语句',15,1)
			RETURN
		END

		-- 计算总条数
		SET @Sql = N'
		SELECT @RowCountOut=COUNT(1) FROM [dbo].[t_Scal_IT_Log]'
		
		IF(@WhereClause <> '')
		BEGIN
		SET @Sql = @Sql + N'
		WHERE ' + @WhereClause
		END
		
		SET @ParmDefinition = N'
		@RowCountOut INT OUTPUT';
		
		EXECUTE sp_executesql @Sql,@ParmDefinition,@RowCountOut = @TotalSize OUTPUT
		-- PRINT @TotalSize
		
		-- 根据总记录条数，计算总页数
		SET @TotalPage = CEILING(CAST(@TotalSize AS NUMERIC(10,2)) / @PageSize)
		
		-- 根据计算总页数，更正查询页数
		IF(@PageNumber > @TotalPage) SET @PageNumber = @TotalPage

		-- 计算最小、最大行号
		SET @MinRowIndex = (@PageNumber - 1) * @PageSize + 1
		SET @MaxRowIndex = @MinRowIndex + @PageSize - 1
		

		-- 组织查询语句
		SET @Sql = N'
		SELECT ' + @FieldsClause + ' FROM (
			SELECT TOP ' + CAST(@MaxRowIndex AS NVARCHAR(10)) + ' ' + @FieldsClause + ','
		SET @Sql = @Sql + N'
			ROW_NUMBER() OVER(ORDER BY ' + @OrderBy + ') AS ''RowNo'''
		SET @Sql = @Sql + N'
			FROM [dbo].[t_Scal_IT_Log]'
		
		-- 附加WHERE子句
		IF(@WhereClause <> '')
		BEGIN
		SET @Sql = @Sql + N'
			WHERE ' + @WhereClause
		END
		
		-- 附加行号范围子句
		SET @Sql = @Sql + '
		) tmp WHERE RowNo BETWEEN ' + CAST(@MinRowIndex AS nvarchar(10)) + ' AND ' + CAST(@MaxRowIndex AS nvarchar(10))
		
		-- 执行语句
		--PRINT @Sql
		EXEC(@Sql)
	END
END
");
            
            string cmd = cmdBuild.ToString();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.Text, cmd))
            {
                return true;
            }
        }


        /// <summary>
        /// 添加日志表查询存储过程
        /// </summary>
        /// <returns></returns>
        public bool AddLogInsertProc()
        {

            StringBuilder cmdBuild = new StringBuilder();
            cmdBuild.Append(@"
------------------------------------------------------------------------------------------------------------------------
-- Date Created: 2012-04-26 17:35:59
-- Author: liu
-- Summary: 添加数据到表 [t_Scal_IT_Log]()
-- EXEC [dbo].[p_Scal_IT_Log_Insert]
------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[p_Scal_IT_Log_Insert]
	@ID bigint OUTPUT , -- 标识
	@AssociateID int, -- 外部关联ID
	@ModuleName nvarchar(20), -- 模块名称
	@LogContent nvarchar(100), -- 日志内容
	@LogType int, -- 日志类型 0：正常信息，1：错误信息，2：警告信息
	@OperateType nvarchar(20), -- 操作类型
	@CreateTime datetime, -- 记录时间
	@Name nvarchar(20), -- 记录人
	@F1 int, -- 附件字段1
	@F2 nvarchar(50) -- 附件字段2
AS
BEGIN
	SET NOCOUNT ON
	
	-- 以下声明的两个变量，可以用于检查逻辑错误，并作为返回值。
	DECLARE @ReturnCode INT
	DECLARE @ReturnMessage VARCHAR(200)
	SET @ReturnCode=0 -- 表示没有逻辑错误
	SET @ReturnMessage=''
	
	-- 在这里可以依据逻辑，检查数据有效性。
	-- IF(...)
	-- BEGIN
	-- 	SET @ReturnCode=-1
	-- 	SET @ReturnMessage='...逻辑错误'
	-- END
	
	IF(@ReturnCode=0) -- 如果没有逻辑错误，那么继续...
	BEGIN
			
		INSERT INTO [dbo].[t_Scal_IT_Log] (
			[AssociateID],
			[ModuleName],
			[LogContent],
			[LogType],
			[OperateType],
			[CreateTime],
			[Name],
			[F1],
			[F2]
		) VALUES (
			@AssociateID,
			@ModuleName,
			@LogContent,
			@LogType,
			@OperateType,
			@CreateTime,
			@Name,
			@F1,
			@F2
		)	
		
		SET @ID = @@IDENTITY
			
	END
	
	SELECT @ReturnCode AS ReturnCode,@ReturnMessage AS ReturnMessage
END
");
            string cmd = cmdBuild.ToString();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.Text, cmd))
            {
                return true;

            }

        }

        /// <summary>
        /// 添加日志表单条查询存储过程
        /// </summary>
        /// <returns></returns>
        public bool AddLogSingleProc()
        {

            StringBuilder cmdBuild = new StringBuilder();
            cmdBuild.Append(@"
------------------------------------------------------------------------------------------------------------------------
-- Date Created: 2012-04-26 17:35:59
-- Author: liu
-- Summary: 根据主键取得表 [t_Scal_IT_Log]() 中的数据
-- EXEC [dbo].[p_Scal_IT_Log_Get]
------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[p_Scal_IT_Log_Get]
	@ID bigint -- 标识
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
		[ID],
		[AssociateID],
		[ModuleName],
		[LogContent],
		[LogType],
		[OperateType],
		[CreateTime],
		[Name],
		[F1],
		[F2]
	FROM
		[dbo].[t_Scal_IT_Log]
	WHERE
		[ID] = @ID
END
");
            string cmd = cmdBuild.ToString();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.Text, cmd))
            {
                return true;

            }
        }



        /// <summary>
        /// 用指定的ID，从数据库中提取数据，并返回一个 LogEntity 对象。
        /// </summary>
        /// <param name="ID">主键值</param>
        /// <returns>成功返回 LogEntity 对象；失败返回null。</returns>
        public LogEntity Load(long ID)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@ID", ID) };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "p_Scal_IT_Log_Get", parameterValues))
            {
                if (reader.Read())
                {
                    LogEntity result;
                    result = LoadFromReader(reader);
                    reader.Close();
                    return result;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }


		/// <summary>
		/// 用给定的条件，从数据库中返回 LogEntity 对象集合。
		/// </summary>
		/// <param name="whereClause">sql条件语句</param>
		/// <param name="OrderBy">sql排序语句</param>
		/// <returns>LogEntity 对象集合</returns>
		public List<LogEntity> LoadCollection(string whereClause, string OrderBy)
		{
			int pageSize = 0;
			int pageNumber = 1;
			int totalSize = 0;
			int totalPage = 0;
			return LoadCollection(whereClause, OrderBy, pageSize, pageNumber, out totalSize, out totalPage);
		}
		
		/// <summary>
		/// 用给定的条件，从数据库中返回 LogEntity 对象集合。本方法支持分页。
		/// </summary>
		/// <param name="whereClause">sql条件语句</param>
		/// <param name="OrderBy">sql排序语句</param>
		/// <param name="pageSize">返回结果分页的每页数量，为0表示不分页。</param>
		/// <param name="pageNumber">当前页号</param>
		/// <param name="totalSize">总数量</param>
		/// <param name="totalPage">总页数</param>
		/// <returns>LogEntity 对象集合</returns>
		public List<LogEntity> LoadCollection(string whereClause, string OrderBy, int pageSize, int pageNumber, out int totalSize, out int totalPage)
		{
			totalSize = 0;
			totalPage = 0;
			List<LogEntity> result = new List<LogEntity>();
			
			//组织sql参数
			SqlParameter parmTotalSize = new SqlParameter("@TotalSize", totalSize);
			parmTotalSize.Direction = ParameterDirection.Output;
			SqlParameter parmTotalPage = new SqlParameter("@TotalPage", totalPage);
			parmTotalPage.Direction = ParameterDirection.Output;

			SqlParameter[] parms = new SqlParameter[] { 
				new SqlParameter("@WhereClause", whereClause), 
				new SqlParameter("@OrderBy", OrderBy),
				new SqlParameter("@PageSize", pageSize),
				new SqlParameter("@PageNumber", pageNumber),
				parmTotalSize,
				parmTotalPage
			};
			
			//读取数据
			using (SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "p_Scal_IT_Log_List", parms))
			{
				while (reader.Read())
				{
					LogEntity tmp = LoadFromReader(reader);
					result.Add(tmp);
				}
				
				reader.Close();
				totalSize= (int) parms[4].Value;
				totalPage= (int) parms[5].Value;
			}
			
			return result;
		}
		
		/// <summary>
        /// 在数据库中添加一个 LogEntity 对象
        /// </summary>
        /// <param name="obj">将要添加的 LogEntity 对象</param>
		public void Insert(ref LogEntity obj)
        {
            SqlParameter[] parameterValues = GetInsertParameterValues(obj);
            using(SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "p_Scal_IT_Log_Insert", parameterValues))
			{
				while (reader.Read())
				{
					LoadReturnFromReader(reader);
				}
				reader.Close();
			}
			
			if (_returnCode == 0) //返回代码为0，表示成功添加。
            {
                obj.ID = (long) parameterValues[0].Value; //设置新添加对象的主键值
            }
        }

		
		/// <summary>
        /// 创建一个数据库事务
        /// </summary>
        /// <returns>新的事务</returns>
        public SqlTransaction CreateTransaction()
        {
            if (_sqlConnection == null)
            {
                _sqlConnection = new SqlConnection(_connectionString);
            }
            if(_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();

            return _sqlConnection.BeginTransaction();
        }
		
		/// <summary>
        /// 用事务处理方式，在数据库中添加一个 LogEntity 对象
        /// </summary>
        /// <param name="obj">将要添加的 LogEntity 对象</param>
		/// <param name="myTransaction">要关联的事务</param>
		public void Insert(ref LogEntity obj, DbTransaction myTransaction)
        {
            SqlParameter[] parameterValues = GetInsertParameterValues(obj);
            using (SqlDataReader reader = SqlHelper.ExecuteReader((SqlTransaction)myTransaction, CommandType.StoredProcedure, "p_Scal_IT_Log_Insert", parameterValues))
			{
				while (reader.Read())
				{
					LoadReturnFromReader(reader);
				}
				reader.Close();
			}
			
			if (_returnCode == 0) //返回代码为0，表示成功添加。
            {
                obj.ID = (long) parameterValues[0].Value; //设置新添加对象的主键值
            }
        }
		

		
		private LogEntity LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
				LogEntity c = new LogEntity();
                if (!Convert.IsDBNull(reader["ID"])) c.ID = Convert.ToInt64(reader["ID"]);  //标识
                if (!Convert.IsDBNull(reader["AssociateID"])) c.AssociateID = Convert.ToInt32(reader["AssociateID"]);  //外部关联ID
                if (!Convert.IsDBNull(reader["ModuleName"])) c.ModuleName = Convert.ToString(reader["ModuleName"]);  //模块名称
                if (!Convert.IsDBNull(reader["LogContent"])) c.LogContent = Convert.ToString(reader["LogContent"]);  //日志内容
                if (!Convert.IsDBNull(reader["LogType"])) c.LogType = Convert.ToInt32(reader["LogType"]);  //日志类型 0：正常信息，1：错误信息，2：警告信息
                if (!Convert.IsDBNull(reader["OperateType"])) c.OperateType = Convert.ToString(reader["OperateType"]);  //操作类型
                if (!Convert.IsDBNull(reader["CreateTime"])) c.CreateTime = Convert.ToDateTime(reader["CreateTime"]);  //记录时间
                if (!Convert.IsDBNull(reader["Name"])) c.Name = Convert.ToString(reader["Name"]);  //记录人
                if (!Convert.IsDBNull(reader["F1"])) c.F1 = Convert.ToInt32(reader["F1"]);  //附件字段1
                if (!Convert.IsDBNull(reader["F2"])) c.F2 = Convert.ToString(reader["F2"]);  //附件字段2
				return c;
            }
			return null;
        }
		
		private void LoadReturnFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				if (!reader.IsDBNull(0)) _returnCode = reader.GetInt32(0);  //错误代码
				if (!reader.IsDBNull(1)) _returnMessage = reader.GetString(1);  //详细错误信息
			}
		}

        private SqlParameter GetSqlParameter(string name, ParameterDirection direction, object value)
        {
            SqlParameter p = new SqlParameter(name, value);
            p.Direction = direction;
            return p;
        }

        private SqlParameter[] GetInsertParameterValues(LogEntity obj)
        {
            return new SqlParameter[] {
            	GetSqlParameter("@ID", ParameterDirection.Output, obj.ID),   //标识
            	GetSqlParameter("@AssociateID", ParameterDirection.Input, obj.AssociateID),   //外部关联ID
            	GetSqlParameter("@ModuleName", ParameterDirection.Input, obj.ModuleName),   //模块名称
            	GetSqlParameter("@LogContent", ParameterDirection.Input, obj.LogContent),   //日志内容
            	GetSqlParameter("@LogType", ParameterDirection.Input, obj.LogType),   //日志类型 0：正常信息，1：错误信息，2：警告信息
            	GetSqlParameter("@OperateType", ParameterDirection.Input, obj.OperateType),   //操作类型
            	GetSqlParameter("@CreateTime", ParameterDirection.Input, obj.CreateTime),   //记录时间
            	GetSqlParameter("@Name", ParameterDirection.Input, obj.Name),   //记录人
            	GetSqlParameter("@F1", ParameterDirection.Input, obj.F1),   //附件字段1
            	GetSqlParameter("@F2", ParameterDirection.Input, obj.F2),   //附件字段2
            };
        }

        private SqlParameter[] GetUpdateParameterValues(LogEntity obj)
        {
            return new SqlParameter[] {
            	new SqlParameter("@ID", obj.ID),   //标识
            	new SqlParameter("@AssociateID", obj.AssociateID),   //外部关联ID
            	new SqlParameter("@ModuleName", obj.ModuleName),   //模块名称
            	new SqlParameter("@LogContent", obj.LogContent),   //日志内容
            	new SqlParameter("@LogType", obj.LogType),   //日志类型 0：正常信息，1：错误信息，2：警告信息
            	new SqlParameter("@OperateType", obj.OperateType),   //操作类型
            	new SqlParameter("@CreateTime", obj.CreateTime),   //记录时间
            	new SqlParameter("@Name", obj.Name),   //记录人
            	new SqlParameter("@F1", obj.F1),   //附件字段1
            	new SqlParameter("@F2", obj.F2)   //附件字段2
			};
        }
		#endregion

    } // end of CLogDAL class
    
} // end of Scal.CMS2011.Components.DAL namespace 

