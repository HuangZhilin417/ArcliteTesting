using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings
{
    class SettingsXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> customFields;
        public KeyValuePair<string, IArcliteWebElement> otherSettings;
        public KeyValuePair<string, IArcliteWebElement> inventoryItemType;
        public KeyValuePair<string, IArcliteWebElement> unit;
        public KeyValuePair<string, IArcliteWebElement> currency;

        public KeyValuePair<string, IArcliteWebElement> locationManager;
        public KeyValuePair<string, IArcliteWebElement> stockAdjustment;
        public KeyValuePair<string, IArcliteWebElement> qualifications;
        public KeyValuePair<string, IArcliteWebElement> qualificationsMatrix;
        public KeyValuePair<string, IArcliteWebElement> assetType;

        public SettingsXAWE(IArclitePage page)
        {

            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            customFields = new KeyValuePair<string, IArcliteWebElement>("Setting Custom Fields", new ArcliteButton("Setting Custom Fields", "//a[@data-settings='customfield']"));
            otherSettings = new KeyValuePair<string, IArcliteWebElement>("Setting Other Settings", new ArcliteButton("Setting Other Settings", "//a[@data-settings='timeout']"));
            inventoryItemType = new KeyValuePair<string, IArcliteWebElement>("Setting Inventory Item Type", new ArcliteButton("Setting Inventory Item Type", "//a[@data-settings='itemtype']"));
            unit = new KeyValuePair<string, IArcliteWebElement>("Setting Unit", new ArcliteButton("Setting Unit", "//a[@data-settings='unit']"));
            currency = new KeyValuePair<string, IArcliteWebElement>("Setting Currency", new ArcliteButton("Setting Currency", "//a[@data-settings='currency']"));

            locationManager = new KeyValuePair<string, IArcliteWebElement>("Setting Location Manager", new ArcliteButton("Setting Location Manager", "//a[@data-settings='warehouse']"));
            stockAdjustment = new KeyValuePair<string, IArcliteWebElement>("Setting Stock Adjustment", new ArcliteButton("Setting Stock Adjustment", "//a[@data-settings='stock']"));
            qualifications = new KeyValuePair<string, IArcliteWebElement>("Setting Qualifications", new ArcliteButton("Setting Qualifications", "//a[@data-settings='qualification']"));
            qualificationsMatrix = new KeyValuePair<string, IArcliteWebElement>("Setting Qualifications Matrix", new ArcliteButton("Setting Qualifications Matrix", "//a[@data-settings='qualificationMatrix']"));
            assetType = new KeyValuePair<string, IArcliteWebElement>("Setting Asset Type", new ArcliteButton("Setting Asset Type", "//a[@data-settings='assetType']"));

            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }
        //Dictionary<element name, XPath>


        public void setElementXpaths()
        {
            this.elementXpaths.Add(customFields.Key, customFields.Value);
            this.elementXpaths.Add(otherSettings.Key, otherSettings.Value);
            this.elementXpaths.Add(inventoryItemType.Key, inventoryItemType.Value);
            this.elementXpaths.Add(unit.Key, unit.Value);
            this.elementXpaths.Add(currency.Key, currency.Value);

            this.elementXpaths.Add(locationManager.Key, locationManager.Value);
            this.elementXpaths.Add(stockAdjustment.Key, stockAdjustment.Value);
            this.elementXpaths.Add(qualifications.Key, qualifications.Value);
            this.elementXpaths.Add(qualificationsMatrix.Key, qualificationsMatrix.Value);
            this.elementXpaths.Add(assetType.Key, assetType.Value);
        }
    }
}
