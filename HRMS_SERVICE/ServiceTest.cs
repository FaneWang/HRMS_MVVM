using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HRMS_SERVICE
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class ServiceTest : IServiceTest
    {
        public string SayingHello(string name)
        {
            Console.WriteLine("Hello,{0},Calling at {1}", name, DateTime.Now.ToLongTimeString());
            return "Hello," + name;
        }

        public bool PicDelete(string picName)
        {
            try
            {
                string path = "C:/Users/victo/Desktop/Csharp/HRMS_MVVM/HRMS_SERVICE/images/" + picName + ".jpg";
                File.Delete(path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
                return false;
            }
        }

        public string PicDownload(string picName)
        {
            try
            {
                string path = "C:/Users/victo/Desktop/Csharp/HRMS_MVVM/HRMS_SERVICE/images/" + picName + ".jpg";
                Image img = Image.FromFile(path);
                string imgString = ImgToByteArray(img);
                return imgString;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
                return null;
            }
        }

        public string PicUpload(string picString)
        {
            //string imgString = ImgToByteArray(pic);
            //string picName = GuidTo16String();
            //string path = "C:/Users/victo/Desktop/Csharp/HRMS_MVVM/HRMS_SERVICE/images/" + picName + ".jpg";
            //pic.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            //return picName;
            try
            {
                string picName = GuidTo16String();
                string path = "C:/Users/victo/Desktop/Csharp/HRMS_MVVM/HRMS_SERVICE/images/" + picName + ".jpg";
                Image img = ByteArrayToImg(picString);
                Image imgCopy = img;
                imgCopy.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                return picName;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
                return null;
            }
        }

        private string ImgToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imgByteArray = ms.GetBuffer();
            string imgString = String.Join(",", Array.ConvertAll(imgByteArray, (Converter<byte, string>)Convert.ToString));
            return imgString;
        }

        private Image ByteArrayToImg(string imgString)
        {
            string[] imgStringArr = imgString.Split(new char[] { ',' });
            byte[] byteArr = Array.ConvertAll<string, byte>(imgStringArr, delegate (string s) { return byte.Parse(s); });
            if (byteArr == null) return null;
            MemoryStream ms = new MemoryStream(byteArr);
            Image img = Image.FromStream(ms);
            return img;
        }

        private string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}
