using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System.Collections.Generic;
using System.Linq;

namespace ExploreSelenium.ArcliteWebPages
{
    public class HomePageXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> homeOrderTracking;
        public KeyValuePair<string, IArcliteWebElement> homeScheduler;
        public KeyValuePair<string, IArcliteWebElement> homeWorkStation;
        public KeyValuePair<string, IArcliteWebElement> homeDashboards;
        public KeyValuePair<string, IArcliteWebElement> homeWorkflows;

        public KeyValuePair<string, IArcliteWebElement> homeConfiguration;

        public HomePageXAWE(IArclitePage page)
        {
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            homeOrderTracking = new KeyValuePair<string, IArcliteWebElement>("Home Tracking", new ArcliteTextBox("Home Tracking", "//a[@onclick=\"selectHeader('#arc-scheduler-sales')\"]"));
            homeScheduler = new KeyValuePair<string, IArcliteWebElement>("Home Scheduler", new ArcliteTextBox("Home Scheduler", "//a[@onclick=\"selectHeader('#arc-scheduler-jobs')\"]"));
            homeWorkStation = new KeyValuePair<string, IArcliteWebElement>("Home Workstation", new ArcliteButton("Home Workstation", "//a[@onclick=\"selectHeader('#arc-workstation')\"]"));
            homeDashboards = new KeyValuePair<string, IArcliteWebElement>("Home Dashboards", new ArcliteTextBox("Home Dashboards", "//a[@onclick=\"selectHeader('#arc-dashboard')\"]"));
            homeWorkflows = new KeyValuePair<string, IArcliteWebElement>("Home Workflows", new ArcliteTextBox("Home Workflows", "//a[@onclick=\"selectHeader('#arc-workflow-builder')\"]"));

            homeConfiguration = new KeyValuePair<string, IArcliteWebElement>("Home Configuration", new ArcliteButton("Home Configuration", "//a[@onclick=\"selectHeader('#arc-config')\"]"));

            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        //Dictionary<element name, XPath>

        public void setElementXpaths()
        {
            this.elementXpaths.Add(homeOrderTracking.Key, homeOrderTracking.Value);
            this.elementXpaths.Add(homeScheduler.Key, homeScheduler.Value);
            this.elementXpaths.Add(homeWorkStation.Key, homeWorkStation.Value);
            this.elementXpaths.Add(homeDashboards.Key, homeDashboards.Value);
            this.elementXpaths.Add(homeWorkflows.Key, homeWorkflows.Value);

            this.elementXpaths.Add(homeConfiguration.Key, homeConfiguration.Value);
        }
    }
}