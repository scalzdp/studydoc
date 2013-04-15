using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Configuration;
namespace Scal.IT.Log
{
    public class FileLog:ILog
    {
        private string direcPath;
        private string filePath;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FileLog()
        {
            direcPath = ConfigurationManager.AppSettings["Scal.IT.Log.FilePath"].ToString();
            filePath = direcPath + "\\log.txt";
        }

        /// <summary>
        /// 写文件日志函数
        /// </summary>
        /// <param name="arg">LogFileEntity文件日志Entity</param>
        /// <returns></returns>
        public bool WriteLog(LogEntity arg)
        {
            try
            {

                WriteLogFile(arg);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }


        /// <summary>
        /// 检查文件夹是否存在
        /// </summary>
        private void CheckDirectoryExist()
        {
            if (!Directory.Exists(direcPath))
            {
                Directory.CreateDirectory(direcPath);
            }
        }


        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        private  FileInfo CheckFileExist()
        {
            FileInfo finfo = new FileInfo(filePath);
            if (!File.Exists(filePath))
            {
                FileStream fs = finfo.Create();
                fs.Flush();
                fs.Close();
               
            }
            return finfo;
        }

        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="arg">文件日志Entity</param>
        private void WriteLogFile(LogEntity arg)
        {

            //检查文件夹是否存在
            CheckDirectoryExist();
            // 检查文件是否存在
            FileInfo fileInfo = CheckFileExist();
            if (fileInfo.IsReadOnly == true)
            {
                fileInfo.IsReadOnly = false;
            }
            //创建只写文件流
            using (FileStream fileStream = fileInfo.OpenWrite())
            {
                //根据上面创建的文件流创建写数据流
                StreamWriter writer = new StreamWriter(fileStream);
                //设置写数据流的起始位置为文件流的末尾
                writer.BaseStream.Seek(0, SeekOrigin.End);
                //写入“Log Entry : ”
                writer.Write("Log Entry: \r\n");
                //写入当前系统时间并换行
                writer.Write("CreateTime:{0} \r\n", DateTime.Now);
                //写入日志类型并换行
                writer.Write("LogType:{0} \r\n", Tools.FileLogType(arg.LogType));
                //写入日志内容并换行
                writer.Write("Content:{0} \r\n", Tools.OrganiseContent(arg));
                //写入------------------------------------“并换行
                writer.Write("------------------------------------\r\n");
                //清空缓冲区内容，并把缓冲区内容写入基础流
                writer.Flush();
                //关闭写数据流
                writer.Close();
            }
        }





    }
}
