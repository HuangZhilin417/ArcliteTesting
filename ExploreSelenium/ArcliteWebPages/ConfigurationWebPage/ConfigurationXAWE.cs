using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationPage
{
    public class ConfigurationXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> inventory;
        public KeyValuePair<string, IArcliteWebElement> personnel;
        public KeyValuePair<string, IArcliteWebElement> assets;
        public KeyValuePair<string, IArcliteWebElement> customers;
        public KeyValuePair<string, IArcliteWebElement> suppliers;

        public KeyValuePair<string, IArcliteWebElement> checklists;
        public KeyValuePair<string, IArcliteWebElement> settings;

        public ConfigurationXAWE(IArclitePage page) 
        {

            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            inventory = new KeyValuePair<string, IArcliteWebElement>("Inventory Page", new ArcliteButton("Inventory Page", "//a[@id='inventory']"));
            personnel = new KeyValuePair<string, IArcliteWebElement>("Personnel Page", new ArcliteButton("Personnel Page", "//a[@id='personnel']"));
            assets = new KeyValuePair<string, IArcliteWebElement>("Assets Page", new ArcliteButton("Assets Page", "//a[@id='assets']"));
            customers = new KeyValuePair<string, IArcliteWebElement>("Customers Page", new ArcliteButton("Customers Page", "//a[@id='customer']"));
            suppliers = new KeyValuePair<string, IArcliteWebElement>("Suppliers Page", new ArcliteButton("Suppliers Page", "//a[@id='supplier']"));

            checklists = new KeyValuePair<string, IArcliteWebElement>("Checklists Page", new ArcliteButton("Checklists Page", "//a[@id='checklist']"));
            settings = new KeyValuePair<string, IArcliteWebElement>("Settings Page", new ArcliteButton("Settings Page", "//a[@id='settings']"));

            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }
        //Dictionary<element name, XPath>


        public void setElementXpaths()
        {
            this.elementXpaths.Add(inventory.Key, inventory.Value);
            this.elementXpaths.Add(personnel.Key, personnel.Value);
            this.elementXpaths.Add(assets.Key, assets.Value);
            this.elementXpaths.Add(customers.Key, customers.Value);
            this.elementXpaths.Add(suppliers.Key, suppliers.Value);

            this.elementXpaths.Add(checklists.Key, checklists.Value);
            this.elementXpaths.Add(settings.Key, settings.Value);
       

        }
    }
}
