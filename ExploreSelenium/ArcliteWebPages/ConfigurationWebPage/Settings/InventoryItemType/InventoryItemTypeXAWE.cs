using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.InventoryItemType
{
    public class InventoryItemTypeXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> description;

        public KeyValuePair<string, IArcliteWebElement> unit;
        public KeyValuePair<string, IArcliteWebElement> minimumQuantity;
        public KeyValuePair<string, IArcliteWebElement> maximumQuantity;
        public KeyValuePair<string, IArcliteWebElement> reorderQuantity;


        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;

        public InventoryItemTypeXAWE(IArclitePage page)
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteInventoryItemType()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteInventoryItemType()']/parent::div/a/i[@class='fas fa-times-circle arc-fa-2x']");
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type Search", new ArcliteSearch("Inventory Item Type Search", "//div[@id='tbInventoryItemType_filter']/label/input", null));
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type Data Table", new ArcliteDataTable("Inventory Item Type Data Table", search.Value, "//td[normalize-space(text())='", "']/parent::tr", "/td/button", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type Add", new ArcliteButton("Inventory Item Type Add", "//i[@class='fa fa-plus arc-fa-2x']"));
            name = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type Name", new ArcliteTextBox("Inventory Item Type Name", "//input[@id='txtItemTypeName'"));
            description = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Description", new ArcliteTextBox("Inventory Item Description", "//textarea[@id='txtItemTypeDescription']"));

            unit = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type Unit", new ArcliteSelect("Inventory Item Type Unit", "//div[@id='partialddlUOM']/div", "//select[@id='ddlUnitOfMeasurementId']", "//div[@id='partialddlUOM']/div/div/div/div[@data-value = '", "']"));
            minimumQuantity = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type Minimum Quantity", new ArcliteTextBox("Inventory Item Type Minimum Quantity", "//input[@id='txtItemTypeMinQuantity']"));
            maximumQuantity = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type Maximum Quantity", new ArcliteTextBox("Inventory Item Type Maximum Quantity", "//input[@id='txtItemTypeMaxQuantity']"));
            reorderQuantity = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type Reorder Quantity", new ArcliteTextBox("Inventory Item Type Reorder Quantity", "//input[@id='txtItemTypeReorderQuantity']"));
            save = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type Save", new ArcliteButton("Inventory Item Type Save", "//button[@id='btnSave'][@onclick='SaveUpdateItemType(0)']"));
            
            cancel = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type Cancel", new ArcliteButton("Inventory Item Type Cancel", "//button[@id='btnclose']"));

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

            this.elementXpaths.Add(unit.Key, unit.Value);
            this.elementXpaths.Add(minimumQuantity.Key, minimumQuantity.Value);
            this.elementXpaths.Add(reorderQuantity.Key, reorderQuantity.Value);
            this.elementXpaths.Add(maximumQuantity.Key, maximumQuantity.Value);
            this.elementXpaths.Add(save.Key, save.Value);

            this.elementXpaths.Add(cancel.Key, cancel.Value);
        }
    }
}

