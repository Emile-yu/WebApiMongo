using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.common
{
    public class AppsettingsHelper
    {
        private static IConfiguration _configuration;

        public AppsettingsHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string app(params string[] sections)
        {
            string result = "";
            if (sections.Length > 0)
            {
                string section = string.Join(":", sections);
                result = _configuration[section];
            }
            return result;
        }
    }
}
