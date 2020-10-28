using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Unit
{
    public class UnitXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> symbol;

        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;

        public UnitXAWE(IArclitePage page)
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteUOM()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteUOM()']/parent::div/a/i[@class='fas fa-times-circle arc-fa-2x']");
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Unit Search", new ArcliteSearch("Unit Search", "//div[@id='tbl_UOMUnitlist_filter']/label/input", null));
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Unit Data Table", new ArcliteDataTable("Unit Data Table", search.Value, "//td[text()='", "']/parent::tr", "/td/button", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Unit Add", new ArcliteButton("Unit Add", "//a[@onclick='AddEditUOM(0)']"));
            name = new KeyValuePair<string, IArcliteWebElement>("Unit Name", new ArcliteTextBox("Unit Name", "//input[@id='txtNameUOM']"));
            symbol = new KeyValuePair<string, IArcliteWebElement>("Unit Symbol", new ArcliteTextBox("Unit Symbol", "//input[@id='txtSymbolUOM']"));

            save = new KeyValuePair<string, IArcliteWebElement>("Unit Save", new ArcliteButton("Unit Save", "//button[@id='btnSave'][@onclick='SaveUpdateUOM(0)']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Unit Cancel", new ArcliteButton("Unit Cancel", "//button[@id='btnclose']"));

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
            this.elementXpaths.Add(symbol.Key, symbol.Value);

            this.elementXpaths.Add(save.Key, save.Value);
            this.elementXpaths.Add(cancel.Key, cancel.Value);
        }
    }
}

