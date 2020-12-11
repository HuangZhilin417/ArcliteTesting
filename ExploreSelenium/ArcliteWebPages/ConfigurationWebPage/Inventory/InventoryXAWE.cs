using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System.Collections.Generic;
using System.Linq;

namespace ExploreSelenium.ArcliteWebPages.Inventory
{
    public class InventoryXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> barcode;
        public KeyValuePair<string, IArcliteWebElement> inventoryItemType;

        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> heldQuantity;
        public KeyValuePair<string, IArcliteWebElement> unitCost;
        public KeyValuePair<string, IArcliteWebElement> currency;
        public KeyValuePair<string, IArcliteWebElement> supplier;

        public KeyValuePair<string, IArcliteWebElement> purchaseReceivedDate;
        public KeyValuePair<string, IArcliteWebElement> location;
        public KeyValuePair<string, IArcliteWebElement> notes;
        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;

        public InventoryXAWE(IArclitePage page)
        {
            this.init();

            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        private void init()
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteInventoryItem()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteInventoryItem()']/parent::div/a/i[@class='fas fa-times-circle arc-fa-2x']");

            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Inventory Search", new ArcliteSearch("Inventory Search", "//div[@id='tbInventoryItemType_filter']/label/input", null));
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Inventory Data Table", new ArcliteDataTable("Inventory Data Table", search.Value, "//td[text()='", "']/parent::tr", "/td[@class=' details-control']", "//td[text()='", "']/parent::tr/td/button[@title='Delete']", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Inventory Add", new ArcliteButton("Inventory Add", "//i[@class='fa fa-plus arc-fa-2x']"));
            barcode = new KeyValuePair<string, IArcliteWebElement>("Inventory Barcode", new ArcliteTextBox("Inventory Barcode", "//input[@id='txtNewItemCustomBarcode']"));
            inventoryItemType = new KeyValuePair<string, IArcliteWebElement>("Inventory Item Type", new ArcliteSelect("Inventory Item Type", "//div[@id='partialDdlItemType']/div/div/div[@class='fs-label']", "//select[@id='ddlItemTypeId']", "//div[@class='fs-option g0'] [@data-value = '", "']"));

            name = new KeyValuePair<string, IArcliteWebElement>("Inventory Name", new ArcliteTextBox("Inventory Name", "//input[@id='txtSpecificItemName']"));
            heldQuantity = new KeyValuePair<string, IArcliteWebElement>("Inventory Held Quantity", new ArcliteTextBox("Inventory Held Quantity", "//*[@id='txtQuantity']"));
            unitCost = new KeyValuePair<string, IArcliteWebElement>("Inventory Unit Cost", new ArcliteTextBox("Inventory Unit Cost", "//*[@id='txtUnitCost']"));
            currency = new KeyValuePair<string, IArcliteWebElement>("Inventory Currency", new ArcliteSelect("Inventory Currency", "//label[text()='Currency']/parent::div/div/div/div", "//select[@id='ddlUnitTypes']", "//label[text()='Currency']/parent::div/div/div/div/div/div/div[@data-value='", "']"));
            supplier = new KeyValuePair<string, IArcliteWebElement>("Inventory Supplier", new ArcliteSelect("Inventory Supplier", "//div[@id='partialDdlSupplier']", "//select[@id='ddlSupplierId']", "//div[@id='partialDdlSupplier']/div/div[@class='fs-dropdown']/div/div[@data-value = '", "']"));

            purchaseReceivedDate = new KeyValuePair<string, IArcliteWebElement>("Inventory Purchase Reveived Date", new ArcliteCalender("Inventory Purchase Reveived Date", "//div[@id='purchased-date-dtp']", "//input[@id='txtPurchasedDate']/parent::div/div/ul/li/div[@class='datepicker']/div[@class='datepicker-days']/table/thead/tr/th[@class='next']", "//tr/td[text()='1']"));
            location = new KeyValuePair<string, IArcliteWebElement>("Inventory Location", new ArcliteSelect("Inventory Location", "//div[@id='partialDdlItemWarehouseadd']", "//select[@id='ddlWarehouse']", "//div[@id='partialDdlItemWarehouseadd']/div/div/div/div[@class='fs-option g0'][@data-value='", "']"));
            notes = new KeyValuePair<string, IArcliteWebElement>("Inventory Notes", new ArcliteTextBox("Inventory Notes", "//textarea[@id='txtNotes']"));
            save = new KeyValuePair<string, IArcliteWebElement>("Inventory Save", new ArcliteButton("Inventory Save", "//button[@id='btnSave']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Inventory Cancel", new ArcliteTextBox("Inventory Cancel", "//button[@id='btnclose']"));
        }

        //Dictionary<element name, XPath>

        public InventoryXAWE()
        {
            this.init();
        }

        public void setElementXpaths()
        {
            this.elementXpaths.Add(search.Key, search.Value);
            this.elementXpaths.Add(dataTable.Key, dataTable.Value);
            this.elementXpaths.Add(add.Key, add.Value);
            this.elementXpaths.Add(barcode.Key, barcode.Value);
            this.elementXpaths.Add(inventoryItemType.Key, inventoryItemType.Value);

            this.elementXpaths.Add(name.Key, name.Value);
            this.elementXpaths.Add(heldQuantity.Key, heldQuantity.Value);
            this.elementXpaths.Add(unitCost.Key, unitCost.Value);
            this.elementXpaths.Add(currency.Key, currency.Value);
            this.elementXpaths.Add(supplier.Key, supplier.Value);

            this.elementXpaths.Add(purchaseReceivedDate.Key, purchaseReceivedDate.Value);
            this.elementXpaths.Add(location.Key, location.Value);
            this.elementXpaths.Add(notes.Key, notes.Value);
            this.elementXpaths.Add(save.Key, save.Value);
            this.elementXpaths.Add(cancel.Key, cancel.Value);
        }
    }
}