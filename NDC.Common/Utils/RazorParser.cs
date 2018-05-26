using System;
using System.IO;
using RazorEngine.Templating;

namespace NDC.Common.Utils
{
    public static class RazorParser
    {
        /// <summary>
        ///     Razor engine compile to HTML code - https://github.com/Antaris/RazorEngine
        /// </summary>
        /// <param name="path"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string Compile(string path, object model)
        {
            //path
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            //model
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var templateService = new TemplateService();
            var template = File.ReadAllText(path);
            var cache = model.GetHashCode().ToString();

            return templateService.Parse(template, model, null, cache);
        }
    }
}