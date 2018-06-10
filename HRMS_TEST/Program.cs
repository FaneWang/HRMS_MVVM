using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

namespace HRMS_TEST
{
    class Program
    {
        //从配置文件获取连接字符串
        public static string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        //获取mongodb客户端对象，应为单例模式
        public static MongoClient client = new MongoClient(connectionString);
        

        static void Main(string[] args)
        {
            //Console.WriteLine(connectionString);
            //获取数据库对象，指定数据库不存在就创建一个
            var database = client.GetDatabase("hrms");
            //获取集合对象，指定集合对象不存在就创建一个
            var collection = database.GetCollection<BsonDocument>("test");

            //插入单个文档
            var doc1 = new BsonDocument {
                {"id",0003 },
                {"name","fegrgrh" },
                {"age",34 },
                {"info",new BsonDocument
                    {
                        {"photo","353454.jpg" },
                        {"photo","6576768.jpg" }
                    }
                }
            };

            collection.InsertOne(doc1);

            //查询
            var document = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(document.ToString());
        }

        
    }
}

