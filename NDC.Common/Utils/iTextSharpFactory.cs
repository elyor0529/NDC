using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace NDC.Common.Utils
{
    /// <summary>
    /// HTML content to Pdf bytes - http://developers.itextpdf.com/itextsharp-net
    /// </summary>
    public static class iTextSharpFactory
    {
        /// <summary>
        ///     iTextSharp - HTML code to Pdf data
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] Convert(string content)
        {
            //check if has html code
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException(nameof(content));

            //buffer
            using (var ms = new MemoryStream())
            {
                //doc
                using (var doc = new Document())
                {
                    //writer
                    using (PdfWriter.GetInstance(doc, ms))
                    {
                        //open
                        doc.Open();

                        //html parser
                        using (var htmlWorker = new HTMLWorker(doc))
                        {
                            //read content
                            using (var sr = new StringReader(content))
                            {
                                // to parse
                                htmlWorker.Parse(sr);
                            }
                        }

                        //close
                        doc.Close();
                    }
                }

                return ms.ToArray();
            }
        }
    }
}