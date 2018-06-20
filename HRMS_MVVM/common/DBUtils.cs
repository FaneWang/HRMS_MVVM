using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_MVVM.common
{
    class DBUtils
    {
        //从配置文件获取连接字符串
        private static string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        //获取mongodb客户端对象，应为单例模式
        private static MongoClient client;

        public DBUtils()
        {
        }

        public static MongoClient GetMongoClient()
        {
            if (client == null)
            {
                client = new MongoClient(connectionString);
            }
            return client;
        }
    }
}
