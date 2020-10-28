using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.LocationManager
{
    public class LocationManagerXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> code;

        public KeyValuePair<string, IArcliteWebElement> description;
        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;

        public LocationManagerXAWE(IArclitePage page)
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteWatehouseById()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteWatehouseById()']/parent::div/a/i[@class='fas fa-times-circle arc-fa-2x']");
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Location Manager Search", new ArcliteSearch("Location Manager Search", "//div[@id='type-list_filter']/label/input", null));
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Location Manager Data Table", new ArcliteDataTable("Location Manager Data Table", search.Value, "//td[@title='", "']/parent::tr", "/td/a", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Location Manager Add", new ArcliteButton("Location Manager Add", "//a[@id='btn-add-warehouse']"));
            name = new KeyValuePair<string, IArcliteWebElement>("Location Manager Name", new ArcliteTextBox("Location Manager Name", "//input[@id='warehouseLocation']"));
            code = new KeyValuePair<string, IArcliteWebElement>("Location Manager Code", new ArcliteTextBox("Location Manager Code", "//input[@id='warehouseNumber']"));

            description = new KeyValuePair<string, IArcliteWebElement>("Location Manager Description", new ArcliteTextBox("Location Manager Description", "//textarea[@id='warehouseDescription']"));
            save = new KeyValuePair<string, IArcliteWebElement>("Location Manager Save", new ArcliteButton("Location Manager Save", "//button[@class='btn arc-btn-icon']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Location Manager Cancel", new ArcliteButton("Location Manager Cancel", "//form[@id='addWarehouseForm']/div/a"));

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
            this.elementXpaths.Add(code.Key, code.Value);

            this.elementXpaths.Add(description.Key, description.Value);
            this.elementXpaths.Add(save.Key, save.Value);
            this.elementXpaths.Add(cancel.Key, cancel.Value);
        }
    }
}
