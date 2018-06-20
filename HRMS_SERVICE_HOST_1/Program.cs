using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_SERVICE_HOST_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HRMS_SERVICE.PictureHandle)))
            {
                //判断是否打开连接，没打开就打开
                if (host.State != CommunicationState.Opening)
                {
                    host.Open();
                }

                //显示运行状态
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Host is running,and current state is {0}.", host.State);

                //打印终结点信息
                foreach (ServiceEndpoint se in host.Description.Endpoints)
                {
                    Console.WriteLine("Host is listening at {0}...", se.Address.Uri.ToString());
                }

                Console.Read();
            }
        }
    }
}
