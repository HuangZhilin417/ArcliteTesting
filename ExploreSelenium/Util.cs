using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebPages;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ExploreSelenium
{
    /*
     * Tool class
     */

    public static class Util
    {
        /*
         * gets the fs-option data value based on the given string and select element
         */

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
            throw new Exception("can't find the wanted string: " + s);
        }

        /*
         * Get file location of the current file location
         */

        public static string getCurrentFileLocation(String fileName)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            dir = dir + @"\" + fileName;

            return dir;
        }

        /*
         * Get to that page given
         */

        public static void navigateToWeb(IArclitePage page, IActionsVisitor visitor, bool isFinal, IArcliteInputs inputs)
        {
            IArclitePage defaultPage = new ArcliteWebPage(visitor, inputs);

            IArclitePage configurationPage = new ConfigurationsPage(visitor, inputs);
            IArclitePage settingPage = new SettingsPage(visitor, inputs);
            List<IArclitePage> webPageList = new List<IArclitePage>();
            webPageList.Add(defaultPage);
            webPageList.Add(configurationPage);
            webPageList.Add(settingPage);

            int count = 0;
            foreach (IArclitePage p in webPageList)
            {
                if (count > 0)
                {
                    Util.navigateToWeb(p, visitor, false, inputs);
                }
                if (count == 2)
                {
                    visitor.switchFrame();
                }
                if (p.pageElements.ContainsKey(page.pageTitle))
                {
                    p.pageElements[page.pageTitle].accept(visitor, new InputVal());
                    if (isFinal && count != 2)
                    {
                        visitor.switchFrame();
                    }
                    return;
                }
                count++;
            }
            throw new ArgumentException("page does not exist");
        }

        /*
         * Returns a random string
         */

        public static string randomString()
        {
            string result = "";
            Random rand = new Random();
            result = rand.Next(0, 16782312).ToString();
            return result;
        }
    }
}