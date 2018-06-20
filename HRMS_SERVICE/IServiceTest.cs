using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HRMS_SERVICE
{
    [ServiceContract]
    public interface IServiceTest
    {
        [OperationContract]
        string SayingHello(string name);
        [OperationContract]
        string PicUpload(string picString);
        [OperationContract]
        string PicDownload(string picName);
        [OperationContract]
        bool PicDelete(string picName);
    }
}
