using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using HRMS_MVVM.commands;
using HRMS_MVVM.common;
using HRMS_MVVM.models;
using System.Drawing;
using MongoDB.Driver;
using MongoDB.Bson;

namespace HRMS_MVVM.viewModels
{
    class InformationEditViewModel : NotificationParent
    {
        private MongoClient client = DBUtils.GetMongoClient();

        #region 数据属性，处理窗口关闭事件
        private int canClose = 1;
        public int CanClose
        {
            get
            {
                return canClose;
            }
            set
            {
                canClose = value;
                this.raisePropertyChanged("CanClose");
            }
        }
        #endregion

        #region 数据模型
        private Information information;
        public Information Information
        {
            get { return information; }
            set
            {
                information = value;
                this.raisePropertyChanged("Information");
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                this.raisePropertyChanged("City");
            }
        }

        private string photo;
        public string Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                this.raisePropertyChanged("Photo");
            }
        }
        #endregion

        #region 数据属性，表示窗口当前状态
        private int currentState = 1;
        public int CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value;
                this.raisePropertyChanged("CurrentState");
            }
        }
        #endregion

        #region 复选框
        public ObservableCollection<string> Nations { get; set; }
        public ObservableCollection<string> Genders { get; set; }
        public ObservableCollection<string> Marriages { get; set; }
        public ObservableCollection<string> Educations { get; set; }
        public ObservableCollection<string> Politics { get; set; }
        public ObservableCollection<string> Provinces { get; set; }
        private ObservableCollection<string> cities;
        public ObservableCollection<string> Cities
        {
            get { return cities; }
            set
            {
                cities = value;
                this.raisePropertyChanged("Cities");
            }
        }
        #endregion

        #region 定义命令属性
        public DelegateCommand closeCommand { get; set; }
        public DelegateCommand getCityCommand { get; set; }
        public DelegateCommand photoChooseCommand { get; set; }
        public DelegateCommand photoDeleteCommand { get; set; }
        public DelegateCommand editCommand { get; set; }
        #endregion

        public InformationEditViewModel()
        {
            this.closeCommand = new DelegateCommand(new Action<object>(closeExecute), new Func<Object, bool>(closeCanExecute));
            this.getCityCommand = new DelegateCommand(new Action<object>(getCityExecute));
            this.photoChooseCommand = new DelegateCommand(new Action<object>(photoChooseExecute));
            this.photoDeleteCommand = new DelegateCommand(new Action<object>(photoDeleteExecute));
            this.editCommand = new DelegateCommand(new Action<object>(editExecute));
            #region 初始化INformation属性
            var database = client.GetDatabase("hrms");
            var collection = database.GetCollection<BsonDocument>("informations");
            var filter = Builders<BsonDocument>.Filter.Eq("Id", "5436");
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var doc = collection.Find(filter).Project(projection).First();
            string jsonStr = doc.ToJson();
            this.Information = JsonUtils.DeserializeJsonToObject<Information>(jsonStr);
            #endregion

            #region 初始化照片
            ServiceProxy.ServiceTestClient serviceTestClient = new ServiceProxy.ServiceTestClient("WSHttpBinding_IServiceTest");
            string imgStr = serviceTestClient.PicDownload(Information.Photo);
            Image img = Utils.ByteArrayToImg(imgStr);
            string path = "C:/Users/victo/Desktop/Csharp/HRMS_MVVM/HRMS_MVVM/images/" + Information.Photo + ".jpg";
            img.Save(path);
            Photo = path;
            #endregion

            #region 初始化民族
            Nations = new ObservableCollection<string>();
            Nations.Add("请选择");
            Nations.Add("土家族");
            Nations.Add("汉族");
            Nations.Add("苗族");
            #endregion
            #region 性别
            Genders = new ObservableCollection<string>();
            Genders.Add("请选择");
            Genders.Add("男");
            Genders.Add("女");
            #endregion
            #region 婚姻
            Marriages = new ObservableCollection<string>();
            Marriages.Add("请选择");
            Marriages.Add("已婚");
            Marriages.Add("未婚");
            #endregion
            #region 学历
            Educations = new ObservableCollection<string>();
            Educations.Add("请选择");
            Educations.Add("初中及以下");
            Educations.Add("高中");
            Educations.Add("本科");
            Educations.Add("硕士");
            Educations.Add("博士");
            #endregion
            #region 政治面貌
            Politics = new ObservableCollection<string>();
            Politics.Add("请选择");
            Politics.Add("群众");
            Politics.Add("共青团员");
            Politics.Add("中共党员");
            Politics.Add("其他");
            #endregion
            #region 籍贯
            Provinces = new ObservableCollection<string>();
            Provinces.Add("请选择");
            Provinces.Add("湖北");
            Provinces.Add("四川");

            Cities = new ObservableCollection<string>();
            if (Information.Province == "湖北")
            {
                Cities.Add("武汉");
                Cities.Add("恩施");
                Cities.Add("宜昌");
                City = Information.City;
            }
            else if (Information.Province == "四川")
            {
                Cities.Add("成都");
                Cities.Add("德阳");
                Cities.Add("绵阳");
                City = Information.City;
            }
            #endregion
        }

        #region close命令改变CanClose属性
        public bool closeCanExecute(Object parameter)
        {
            return true;
        }

        public void closeExecute(Object parameter)
        {
            this.CanClose = 0;
        }
        #endregion

        #region getCityExecute
        public void getCityExecute(Object parameter)
        {
            if (Information.Province == "湖北")
            {
                Cities.Clear();
                Cities.Add("武汉");
                Cities.Add("恩施");
                Cities.Add("宜昌");
                City = "武汉";
            }
            else if (Information.Province == "四川")
            {
                Cities.Clear();
                Cities.Add("成都");
                Cities.Add("德阳");
                Cities.Add("绵阳");
                City = "成都";
            }
            else
            {
                Cities.Clear();
                Cities.Add("请选择");
                City = "请选择";
            }
        }
        #endregion

        #region photoChooseExecute
        public void photoChooseExecute(Object parameter)
        {
            Microsoft.Win32.OpenFileDialog dialog =
                new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "图像文件|*.jpg;*.png;*.jpeg";
            if (dialog.ShowDialog() == true)
            {
                // 根据文件名在本地读取文件，存为字节文件，调用上传服务上传文件转换为图片并返回
                // 在服务器端的存储位置（http链接），存储到数据库中；获取数据库中路径，赋给Photo预览
                Photo = dialog.FileName;
                Image image = Image.FromFile(dialog.FileName);
                try
                {
                    string imgString = Utils.ImgToByteArray(image);
                    ServiceProxy.ServiceTestClient client = new ServiceProxy.ServiceTestClient("WSHttpBinding_IServiceTest");
                    string imgName = client.PicUpload(imgString);
                    this.Information.Photo = imgName;
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show("上传错误，请联系管理员！");
                }
            }
        }
        #endregion

        #region photoDeleteExecute
        public void photoDeleteExecute(Object parameter)
        {
            Photo = "";
            try
            {
                ServiceProxy.ServiceTestClient client = new ServiceProxy.ServiceTestClient("WSHttpBinding_IServiceTest");
                client.PicDelete(this.Information.Photo);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("清除错误，请联系管理员！");
            }
        }
        #endregion

        #region editExecute
        public void editExecute(Object parameter)
        {
            this.Information.City = City;
            if (string.IsNullOrWhiteSpace(Information.Id))
            {
                System.Windows.MessageBox.Show("职工编号为必填项！");
                return;
            }
            if (string.IsNullOrWhiteSpace(Information.Name))
            {
                System.Windows.MessageBox.Show("职工姓名为必填项！");
                return;
            }
            if (string.IsNullOrWhiteSpace(Information.Gender) | Information.Gender == "请选择")
            {
                System.Windows.MessageBox.Show("性别为必填项！");
                return;
            }
            try
            {
                string infoJsonStr = JsonUtils.SerializeObject(Information);
                var doc = BsonDocument.Parse(infoJsonStr);
                MongoClient client = DBUtils.GetMongoClient();
                var database = client.GetDatabase("hrms");
                var collection = database.GetCollection<BsonDocument>("informations");
                var filter = Builders<BsonDocument>.Filter.Eq("Id", "5436");
                var update = Builders<BsonDocument>.Update.Set("Id", Information.Id).Set("Name", Information.Name).Set("Province", Information.Province).Set("City", Information.City);
                collection.UpdateOne(filter, update);
                this.CanClose = 0;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("编辑失败，请联系管理员！");
                return;
            }
        }
        #endregion

        #region getPros
        private string getProperties<T>(T t)
        {
            string tStr = string.Empty;
            if (t == null)
            {
                return tStr;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return tStr;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    tStr += string.Format("{0}:{1},", name, value);
                }
                else
                {
                    getProperties(value);
                }
            }
            return tStr;
        }
        #endregion
    }
}
