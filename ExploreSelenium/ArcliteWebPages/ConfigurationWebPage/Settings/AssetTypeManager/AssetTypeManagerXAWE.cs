using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.AssetTypeManager
{
    public class AssetTypeManagerXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> description;

        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;

        public AssetTypeManagerXAWE(IArclitePage page)
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteAssetType()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteAssetType()']/parent::div/a/i[@class='fas fa-times-circle arc-fa-2x']");
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Asset Type Manager Search", new ArcliteSearch("Asset Type Manager Search", "//div[@id='tblAssetTypeManagement_filter']/label/input", null));
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Asset Type Manager Data Table", new ArcliteDataTable("Asset Type Manager Data Table", search.Value, "//td[text()='", "']/parent::tr", "/td/button", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Asset Type Manager Add", new ArcliteButton("Asset Type Manager Add", "//a[@onclick='AddEditAssetType(0,0)']"));
            name = new KeyValuePair<string, IArcliteWebElement>("Asset Type Manager Name", new ArcliteTextBox("Asset Type Manager Name", "//input[@id='AssetTypeName']"));
            description = new KeyValuePair<string, IArcliteWebElement>("Asset Type Manager Description", new ArcliteTextBox("Asset Type Manager Description", "//textarea[@id='AssetTypeDescription']"));
            
            save = new KeyValuePair<string, IArcliteWebElement>("Asset Type Manager Save", new ArcliteButton("Asset Type Manager Save", "//button[@onclick='SaveUpdateAssetType(0)']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Asset Type Manager Cancel", new ArcliteButton("Asset Type Manager Cancel", "//button[@id='btnclose']"));

            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }
        //Dictionary<element name, XPath>


        public void setElementXpaths()
        {
            this.elementXpaths.Add(search.Key, search.Value);
            this.elementXpaths.Add(dataTable.Key, dataTable.Value);
            this.elementXpaths.Add(add.Key, add.Value);
            this.elementXpaths.Add(name.Key, name.Value);
            this.elementXpaths.Add(description.Key, description.Value);

            this.elementXpaths.Add(save.Key, save.Value);
            this.elementXpaths.Add(cancel.Key, cancel.Value);
        }
    }
}
