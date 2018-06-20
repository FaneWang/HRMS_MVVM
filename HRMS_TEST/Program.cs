using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Drawing;

namespace HRMS_TEST
{
    class Program
    {
        //从配置文件获取连接字符串
        //public static string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        //获取mongodb客户端对象，应为单例模式
        //public static MongoClient client = new MongoClient(connectionString);


        static void Main(string[] args)
        {
            #region service1
            //try
            //{
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //    //这里构造函数里面的东西是配置文件中endpoint的name
            //    ServiceProxy1.ServiceTestClient serviceProxy = new ServiceProxy1.ServiceTestClient("WSHttpBinding_IServiceTest");

            //    string name = "onepig";
            //    string result = string.Empty;

            //    result = serviceProxy.SayingHello(name);

            //    Console.WriteLine("Returned value is {0}...", result);


            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Exception:{0}", e.Message);
            //}

            //Console.WriteLine("Press any key to exit.");
            //Console.Read();
            #endregion

            #region service2
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                //这里构造函数里面的东西是配置文件中endpoint的name
                ServiceReference1.ServiceTestClient serviceProxy = new ServiceReference1.ServiceTestClient("WSHttpBinding_IServiceTest");

                Image img = Image.FromFile("C:/Users/victo/Desktop/Csharp/HRMS_MVVM/HRMS_TEST/images/4646.jpg");
                string imgString = Utils.ImgToByteArray(img);

                string result = serviceProxy.PicUpload(imgString);

                //string imgString = serviceProxy.PicDownload("4646");
                //Image img = Utils.ByteArrayToImg(imgString);
                //string path = "C:/Users/victo/Desktop/Csharp/HRMS_MVVM/HRMS_MVVM/images/hthtjyjkj.jpg";
                //img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

                Console.WriteLine("Returned value is {0}...", result);


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
            }

            Console.WriteLine("Press any key to exit.");
            Console.Read();
            #endregion

            //Console.WriteLine(connectionString);
            //获取数据库对象，指定数据库不存在就创建一个
            //var database = client.GetDatabase("hrms");
            //获取集合对象，指定集合对象不存在就创建一个
            //var collection = database.GetCollection<BsonDocument>("test2");

            #region 插入单个文档
            //var doc = new BsonDocument {
            //    {"id",0003 },
            //    {"name","fegrgrh" },
            //    {"age",34 },
            //    {"info",new BsonDocument
            //        {
            //            {"photo","353454.jpg" },
            //            {"phone","6576768.jpg" }
            //        }
            //    }
            //};

            //collection.InsertOne(doc1);
            #endregion

            #region 插入多个文档
            //var doc1 = new BsonDocument {
            //    {"id",0005 },
            //    {"name","grrh" },
            //    {"age",37 },
            //    {"info",new BsonDocument
            //        {
            //            {"photo","3534765878.jpg" },
            //            {"phone","657664568.jpg" }
            //        }
            //    }
            //};

            //var doc2 = new BsonDocument {
            //    {"id",0008 },
            //    {"name","frh" },
            //    {"age",23 },
            //    {"info",new BsonDocument
            //        {
            //            {"photo","3900054.jpg" },
            //            {"phone","6500068.jpg" }
            //        }
            //    }
            //};

            //var docs = new List<BsonDocument>();
            //docs.Add(doc1);
            //docs.Add(doc2);
            //collection.InsertMany(docs);
            #endregion

            #region 计数
            //var count = collection.Count(new BsonDocument());
            //Console.WriteLine(count);
            #endregion

            #region 查询第一个文档
            //var document = collection.Find(new BsonDocument()).FirstOrDefault();
            //Console.WriteLine(document.ToString());
            #endregion

            #region 查询所有文档
            //var docs = collection.Find(new BsonDocument()).ToList();

            //foreach (var doc in docs)
            //{
            //    Console.WriteLine(doc.ToString());
            //}
            #endregion

            #region 条件查询
            //Eq,Gt,Lte等操作符
            //var filter = Builders<BsonDocument>.Filter.Eq("counter",71);
            //var doc = collection.Find(filter).First();
            //Console.WriteLine(doc.ToString());
            #endregion

            #region 结果排序
            //var filter = Builders<BsonDocument>.Filter.Exists("counter");
            //var sort = Builders<BsonDocument>.Sort.Descending("counter");
            //var doc = collection.Find(filter).Sort(sort).First();
            //Console.WriteLine(doc.ToString());
            #endregion

            #region 结果筛选
            //var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            //var doc = collection.Find(new BsonDocument()).Project(projection).First();
            //Console.WriteLine(doc.ToString());
            #endregion

            #region 更新一个，多个（结合条件）
            //var filter = Builders<BsonDocument>.Filter.Eq("id", 8);
            //var update = Builders<BsonDocument>.Update.Set("name", "王五");
            //var result = collection.UpdateOne(filter, update);
            //if (result.IsModifiedCountAvailable)
            //{
            //    Console.WriteLine(result.ModifiedCount);
            //}
            #endregion

            #region 删除一个多个（结合条件）
            //var filter = Builders<BsonDocument>.Filter.Eq("counter", 56);
            //var result = collection.DeleteOne(filter);
            //Console.WriteLine(result.DeletedCount);
            #endregion
        }


    }
}

