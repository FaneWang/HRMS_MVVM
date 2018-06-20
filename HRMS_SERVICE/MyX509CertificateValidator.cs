using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace HRMS_SERVICE
{
    class MyX509CertificateValidator : X509CertificateValidator
    {
        public override void Validate(X509Certificate2 certificate)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Certificate Subject is {0}", certificate.Subject);
            Console.WriteLine("Certificate Thumbprint is {0}", certificate.Thumbprint);

            //这里的指纹是客户端证书的值
            //如果在生产环境中，可以使用CA证书
            //可以在服务端创建一个证书库，将证书的指纹或其他信息存储于数据库，验证时从数据库获取数据进行验证，后期可以通过数据库新增证书信息
            if(certificate.Thumbprint.ToLower() != "6f5dcf580d32cfc9c6c6e5486c505ca002e47829")
            {
                Console.WriteLine("Certificate Validation is failed,{0}", certificate.Subject);
                throw new SecurityTokenException("Unknown certificate");
            }
            else
            {
                Console.WriteLine("Certificate Validation is success,{0}", certificate.Subject);
            }
        }
    }
}
