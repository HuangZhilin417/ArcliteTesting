using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.DefaultPage
{
    class ArcliteWebPageXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> home;
        public KeyValuePair<string, IArcliteWebElement> orderTracking;
        public KeyValuePair<string, IArcliteWebElement> scheduler;
        public KeyValuePair<string, IArcliteWebElement> workstation;
        public KeyValuePair<string, IArcliteWebElement> dashboard;

        public KeyValuePair<string, IArcliteWebElement> workflowBuilder;
        public KeyValuePair<string, IArcliteWebElement> settings;
        public KeyValuePair<string, IArcliteWebElement> user;

        public ArcliteWebPageXAWE(IArclitePage page)
        {

            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            home = new KeyValuePair<string, IArcliteWebElement>("Home", new ArcliteButton("Home", "//a/i[@class='fa fa-home arc-fa-2x']"));
            orderTracking = new KeyValuePair<string, IArcliteWebElement>("Order Tracking & Manangement", new ArcliteButton("Order Tracking & Manangement", "//a[@id='arc-scheduler-sales']"));
            scheduler = new KeyValuePair<string, IArcliteWebElement>("Scheduler", new ArcliteButton("Scheduler", "//a[@id='arc-scheduler-jobs']"));
            workstation = new KeyValuePair<string, IArcliteWebElement>("Workstation", new ArcliteButton("Workstation", "//a[@id='arc-workstation']"));
            dashboard = new KeyValuePair<string, IArcliteWebElement>("Dashboard", new ArcliteButton("Dashboard", "//a[@id='arc-dashboard']"));

            workflowBuilder = new KeyValuePair<string, IArcliteWebElement>("Workflow Builder", new ArcliteButton("Workflow Builder", "//a[@id='arc-workflow-builder']"));
            settings = new KeyValuePair<string, IArcliteWebElement>("Configuration", new ArcliteButton("Configuration", "//a[@id='arc-config']"));
            user = new KeyValuePair<string, IArcliteWebElement>("User Information", new ArcliteButton("User Information", "//li[@class='nav-item dropdown']/a"));

            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        public ArcliteWebPageXAWE()
        {
            home = new KeyValuePair<string, IArcliteWebElement>("Home", new ArcliteButton("Home", "//a/i[@class='fa fa-home arc-fa-2x']"));
            orderTracking = new KeyValuePair<string, IArcliteWebElement>("Order Tracking & Manangement", new ArcliteButton("Order Tracking & Manangement", "//a[@id='arc-scheduler-sales']"));
            scheduler = new KeyValuePair<string, IArcliteWebElement>("Scheduler", new ArcliteButton("Scheduler", "//a[@id='arc-scheduler-jobs']"));
            workstation = new KeyValuePair<string, IArcliteWebElement>("Workstation", new ArcliteButton("Workstation", "//a[@id='arc-workstation']"));
            dashboard = new KeyValuePair<string, IArcliteWebElement>("Dashboard", new ArcliteButton("Dashboard", "//a[@id='arc-dashboard']"));

            workflowBuilder = new KeyValuePair<string, IArcliteWebElement>("Workflow Builder", new ArcliteButton("Workflow Builder", "//a[@id='arc-workflow-builder']"));
            settings = new KeyValuePair<string, IArcliteWebElement>("Configuration", new ArcliteButton("Configuration", "//a[@id='arc-config']"));
            user = new KeyValuePair<string, IArcliteWebElement>("User Information", new ArcliteButton("User Information", "//li[@class='nav-item dropdown']/a"));
        }
        //Dictionary<element name, XPath>


        public void setElementXpaths()
        {
            this.elementXpaths.Add(home.Key, home.Value);
            this.elementXpaths.Add(orderTracking.Key, orderTracking.Value);
            this.elementXpaths.Add(scheduler.Key, scheduler.Value);
            this.elementXpaths.Add(workstation.Key, workstation.Value);
            this.elementXpaths.Add(dashboard.Key, dashboard.Value);

            this.elementXpaths.Add(workflowBuilder.Key, workflowBuilder.Value);
            this.elementXpaths.Add(settings.Key, settings.Value);
            this.elementXpaths.Add(user.Key, user.Value);

        }
    }
}
