using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AnalysisServices.AdomdClient;
using System.Data;

namespace WebApplication1
{
    public class Test
    {
        public DataTable Adomd()
        {
            //连接的字符串
            string conStr = "provider=msolap ;Integrated Security =SSPI ;Data Source= localhost ;Catalog =Scal B2CReport Mdx ;";
            //创建个连接对象
            AdomdConnection con = new AdomdConnection();
            con.ConnectionString = conStr;
            con.Open();
            // 创建个命令
            AdomdCommand cmm = con.CreateCommand();
            cmm.CommandText = @"select 
	{[Measures].[订票数量],
	[Measures].[Add Fare],[Measures].[Par Price]} on columns,
	{[Sale Sta View Time].[Create Day].[2011-12-01]:[Sale Sta View Time].[Create Day].[2011-12-31]} on rows
from [SCAL3 Test]
where 
	{
	{[Sale Sta View Generic].[Is Member].&[1]}
	}";
            //执行命令返回单元集合
            CellSet result = cmm.ExecuteCellSet();
            DataTable table = CellSetToTable(result);
            con.Close();
            return table;

        }

        private DataTable CellSetToTable(CellSet cellset)
        {

            DataTable table = new DataTable("cellset");


            Axis columns = cellset.Axes[0];//获取列轴
            Axis rows = cellset.Axes[1]; //获取行轴
            CellCollection valuesCell = cellset.Cells;//获取度量值单元集合
            //行轴的级别标题为表的第一列
            table.Columns.Add(rows.Set.Hierarchies[0].Caption);
            //行轴的成各个成员的标题变成表的列
            for (int i = 0; i < columns.Set.Tuples.Count; i++)
            {
                table.Columns.Add(new DataColumn(columns.Set.Tuples[i].Members[0].Caption));
            }
            int valuesIndex = 0;
            DataRow row = null;
            //向表中填充数据
            for (int i = 0; i < rows.Set.Tuples.Count; i++)
            {
                row = table.NewRow();
                //表所有行的第一列值为相应行轴的成标题
                row[0] = rows.Set.Tuples[i].Members[0].Caption;
                for (int k = 1; k <= columns.Set.Tuples.Count; k++)
                {   //按顺序把度量值单元集合的值填充到表中
                    row[k] = valuesCell[valuesIndex].Value;
                    valuesIndex++;
                }
                table.Rows.Add(row);
            }

            return table;


        }
    }
}