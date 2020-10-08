using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium
{
    public static class Util
    {
        static Dictionary<String, int> ord = new Dictionary<string, int>();

        public static string getDataValue(string s, SelectElement element)
        {
            IList<IWebElement> options = element.Options;
            foreach (IWebElement item in options)
            {
                if (item.GetAttribute("label").Equals(s))
                {
                    return item.GetAttribute("value");
                }
            }
            throw new Exception("can't find the wanted string");
        }

        public static int getOrder()
        {
            return 0;
        }
    }
}
