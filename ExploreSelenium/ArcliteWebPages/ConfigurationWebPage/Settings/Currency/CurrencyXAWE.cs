using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System.Collections.Generic;
using System.Linq;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Currency
{
    public class CurrencyXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> symbol;

        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;

        public CurrencyXAWE(IArclitePage page)
        {
            this.initPage();
            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        //Dictionary<element name, XPath>
        public CurrencyXAWE()
        {
            this.initPage();
        }

        //Dictionary<element name, XPath>
        private void initPage()
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteUOM()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteUOM()']/parent::div/a/i[@class='fas fa-times-circle arc-fa-2x']");
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Currency Search", new ArcliteSearch("Currency Search", "//div[@id='tbl_UOMCurrencylist_filter']/label/input", null));
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Currency Data Table", new ArcliteDataTable("Currency Data Table", search.Value, "//td[text()='", "']/parent::tr", "/td/button", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Currency Add", new ArcliteButton("Currency Add", "//a[@onclick='AddEditUOM(0)']"));
            name = new KeyValuePair<string, IArcliteWebElement>("Currency Name", new ArcliteTextBox("Currency Name", "//input[@id='txtNameUOM']"));
            symbol = new KeyValuePair<string, IArcliteWebElement>("Currency Symbol", new ArcliteTextBox("Currency Symbol", "//input[@id='txtSymbolUOM']"));

            save = new KeyValuePair<string, IArcliteWebElement>("Currency Save", new ArcliteButton("Currency Save", "//button[@id='btnSave']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Currency Cancel", new ArcliteButton("Currency Cancel", "//button[@id='btnclose']"));
        }

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