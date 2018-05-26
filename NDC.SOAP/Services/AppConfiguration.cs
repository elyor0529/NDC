using System;
using System.Configuration;
using System.IO;
using NDC.Common;

namespace NDC.SOAP.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class AppConfiguration : IConfiguration
    {
        public AppConfiguration()
        {
            FromEmail = ConfigurationManager.AppSettings["AdminEmail"];
            EmailProviderKey = ConfigurationManager.AppSettings["SendGridKey"];
            TemplatePath = Path.Combine(MainSettings.CurrentDirectory, ConfigurationManager.AppSettings["RazorViewPath"]);
            AttachmentSize = Convert.ToInt32(ConfigurationManager.AppSettings["AttachmentSize"]);
        }

        public string FromEmail { get; set; }
        public string EmailProviderKey { get; set; }
        public string TemplatePath { get; set; }
        public int AttachmentSize { get; set; }
    }
}