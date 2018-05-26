using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NDC.Common.Utils;
using NDC.SOAP.Models;

namespace NDC.SOAP.Services
{
    public class EmailService : IService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _configuration = configuration;
        }

        /// <summary>
        ///     Send async email
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="peoples"></param>
        /// <returns></returns>
        public void BatchSend(string destination, IEnumerable<Person> peoples)
        {
            //destination
            if (string.IsNullOrWhiteSpace(destination))
                throw new ArgumentNullException("destination");

            //check peoples
            if (peoples == null || !peoples.Any())
                throw new ArgumentNullException("peoples");

            // Partition the entire source array.
            //https://msdn.microsoft.com/en-us/library/dd997411(v=vs.110).aspx
            var rangePartitioner = Partitioner.Create(0, peoples.Count(), _configuration.AttachmentSize);

            // Loop over the partitions
            var rangePartitions = rangePartitioner.GetDynamicPartitions();

            foreach (var rangePartition in rangePartitions)
            {
                var attachments = new string[rangePartition.Item2 - rangePartition.Item1];
                var attachmentIndex = 0;

                // Loop over each range element without a delegate invocation.
                for (var counter = rangePartition.Item1; counter < rangePartition.Item2; counter++)
                {
                    var person = peoples.ElementAt(counter);
                    var html = RazorParser.Compile(_configuration.TemplatePath, person);
                    var pdf = iTextSharpFactory.Convert(html);
                    var tmpPath = Path.Combine(Path.GetTempPath(), string.Format("{0}_{1}.pdf", person.FullName, Path.GetFileNameWithoutExtension(Path.GetRandomFileName())));

                    File.WriteAllBytes(tmpPath, pdf);

                    attachments[attachmentIndex] = tmpPath;
                    attachmentIndex++;
                }

                var subject = string.Format("Criminal Profiles - Part {0}/{1}", rangePartition.Item1 + 1, rangePartition.Item2);
                var body = @"Hi, we are sending you the results of your search. Please open the attached files.";

                SendGridTool.Send(_configuration.EmailProviderKey, _configuration.FromEmail, destination, subject, body, attachments);
            }
        }
    }
}