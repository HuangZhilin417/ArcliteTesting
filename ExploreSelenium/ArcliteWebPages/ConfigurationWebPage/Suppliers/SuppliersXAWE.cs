using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System.Collections.Generic;
using System.Linq;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Suppliers
{
    public class SuppliersXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> suppliersCode;

        public KeyValuePair<string, IArcliteWebElement> contactName;
        public KeyValuePair<string, IArcliteWebElement> contactNumber;
        public KeyValuePair<string, IArcliteWebElement> secondaryNumber;
        public KeyValuePair<string, IArcliteWebElement> email;
        public KeyValuePair<string, IArcliteWebElement> address;

        public KeyValuePair<string, IArcliteWebElement> notes;
        public KeyValuePair<string, IArcliteWebElement> personInCharge;
        public KeyValuePair<string, IArcliteWebElement> description;
        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;

        public SuppliersXAWE(IArclitePage page)
        {
            this.initPage();
            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        public SuppliersXAWE()
        {
            this.initPage();
        }

        //Dictionary<element name, XPath>

        private void initPage()
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteSupplier()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteSupplier()']/parent::div/a/i[@class='fas fa-times-circle arc-fa-2x']");
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Suppliers Search", new ArcliteSearch("Suppliers Search", "//div[@id='tbSupplier_filter']/label/input", null));
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Suppliers Data Table", new ArcliteDataTable("Suppliers Data Table", search.Value, "//td[text()='", "']/parent::tr", "/td/a", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Suppliers Add", new ArcliteButton("Suppliers Add", "//a[@onclick='AddEditSupplier(0)']"));
            name = new KeyValuePair<string, IArcliteWebElement>("Suppliers Name", new ArcliteTextBox("Suppliers Name", "//*[@id='txtNameSupplier']"));
            suppliersCode = new KeyValuePair<string, IArcliteWebElement>("Suppliers Item Type", new ArcliteTextBox("Suppliers Item Type", "//*[@id='SupplierCode']"));

            contactName = new KeyValuePair<string, IArcliteWebElement>("Suppliers Contact Name", new ArcliteTextBox("Suppliers Contact Name", "//*[@id='ContactName']"));
            contactNumber = new KeyValuePair<string, IArcliteWebElement>("Suppliers Contact Number", new ArcliteTextBox("Suppliers Contact Number", "//*[@id='ContactNumberPrimary']"));
            secondaryNumber = new KeyValuePair<string, IArcliteWebElement>("Suppliers Secondary Number", new ArcliteTextBox("Suppliers Secondary Number", "//*[@id='ContactNumberSecondary']"));
            email = new KeyValuePair<string, IArcliteWebElement>("Suppliers Email", new ArcliteTextBox("Suppliers Email", "//*[@id='ContactEmail']"));
            address = new KeyValuePair<string, IArcliteWebElement>("Suppliers Address", new ArcliteTextBox("Suppliers Address", "//*[@id='Address']"));

            notes = new KeyValuePair<string, IArcliteWebElement>("Suppliers Notes", new ArcliteTextBox("Suppliers Notes", "//*[@id='Notes']"));
            personInCharge = new KeyValuePair<string, IArcliteWebElement>("Suppliers Person In Charge", new ArcliteSelect("Suppliers Person In Charge", "//label[@class='control-label'][text()='Person In Charge']/parent::div/div", "//select[@id='ddlPersonInCharge']", "//label[@class='control-label'][text()='Person In Charge']/parent::div/div/div/div/div/div[@data-value = '", "']"));
            description = new KeyValuePair<string, IArcliteWebElement>("Suppliers Description", new ArcliteTextBox("Suppliers Description", "//*[@id='Description']"));
            save = new KeyValuePair<string, IArcliteWebElement>("Suppliers Save", new ArcliteButton("Suppliers Save", "//button[@id='btnSave']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Suppliers Cancel", new ArcliteTextBox("Suppliers Cancel", "//button[@id='btnclose']"));
        }

        public void setElementXpaths()
        {
            this.elementXpaths.Add(search.Key, search.Value);
            this.elementXpaths.Add(dataTable.Key, dataTable.Value);
            this.elementXpaths.Add(add.Key, add.Value);
            this.elementXpaths.Add(name.Key, name.Value);
            this.elementXpaths.Add(suppliersCode.Key, suppliersCode.Value);

            this.elementXpaths.Add(contactName.Key, contactName.Value);
            this.elementXpaths.Add(contactNumber.Key, contactNumber.Value);
            this.elementXpaths.Add(secondaryNumber.Key, secondaryNumber.Value);
            this.elementXpaths.Add(email.Key, email.Value);
            this.elementXpaths.Add(address.Key, address.Value);

            this.elementXpaths.Add(notes.Key, notes.Value);
            this.elementXpaths.Add(personInCharge.Key, personInCharge.Value);
            this.elementXpaths.Add(description.Key, description.Value);
            this.elementXpaths.Add(save.Key, save.Value);
            this.elementXpaths.Add(cancel.Key, cancel.Value);
        }
    }
}