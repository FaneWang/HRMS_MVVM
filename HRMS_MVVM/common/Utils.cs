using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace HRMS_MVVM.common
{
    class Utils
    {
        public static string ImgToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imgByteArray = ms.GetBuffer();
            //不能关闭ms
            //ms.Close();
            string imgString = String.Join(",", Array.ConvertAll(imgByteArray, (Converter<byte, string>)Convert.ToString));
            return imgString;
        }

        public static Image ByteArrayToImg(string imgString)
        {
            string[] imgStringArr = imgString.Split(new char[] { ',' });
            byte[] byteArr = Array.ConvertAll<string, byte>(imgStringArr, delegate (string s) { return byte.Parse(s); });
            if (byteArr == null) return null;
            MemoryStream ms = new MemoryStream(byteArr);
            Image img = Image.FromStream(ms);
            return img;
        }
    }
}
