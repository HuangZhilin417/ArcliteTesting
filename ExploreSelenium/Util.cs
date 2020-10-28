using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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

        public static void navigateToWeb(IArclitePage page, IActionsVisitor visitor, bool isFinal)
        {
            IArclitePage defaultPage = new ArcliteWebPage(visitor);

            IArclitePage configurationPage = new ConfigurationsPage(visitor);
            IArclitePage settingPage = new SettingsPage(visitor);
            List<IArclitePage> webPageList = new List<IArclitePage>();
            webPageList.Add(defaultPage);
            webPageList.Add(configurationPage);
            webPageList.Add(settingPage);

            int count = 0;
            foreach (IArclitePage p in webPageList) {
                if (count > 0)
                {
                    navigateToWeb(p, visitor, false);
                }
                if (p.pageElements.ContainsKey(page.pageTitle))
                {
                    p.pageElements[page.pageTitle].accept(visitor, new InputVal());
                    if (isFinal)
                    {
                        visitor.switchFrame();
                    }
                    return;
                }
                count++;
            }
            throw new ArgumentException("page does not exist");
        }

        public static string randomString(){
            string result = "";
            Random rand = new Random();
            result = rand.Next(0, 16782312).ToString();
            return result;

        }

    }
}
