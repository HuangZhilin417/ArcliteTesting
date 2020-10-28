using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Customers
{
    public class CustomersXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> customerCode;

        public KeyValuePair<string, IArcliteWebElement> contactName;
        public KeyValuePair<string, IArcliteWebElement> contactNumber;
        public KeyValuePair<string, IArcliteWebElement> secondaryNumber;
        public KeyValuePair<string, IArcliteWebElement> email;
        public KeyValuePair<string, IArcliteWebElement> deliveryAddress;

        public KeyValuePair<string, IArcliteWebElement> notes;
        public KeyValuePair<string, IArcliteWebElement> personInCharge;
        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;

        public CustomersXAWE(IArclitePage page)
        {
            this.initPage();

            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        public CustomersXAWE()
        {
            this.initPage();
        }
        //Dictionary<element name, XPath>
        //Dictionary<element name, XPath>
        private void initPage()
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteCustomer()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteCustomer()']/parent::div/a/i[@class='fas fa-times-circle arc-fa-2x']");
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Customers Search", new ArcliteSearch("Customers Search", "//div[@id='tbCustomer_filter']/label", null));
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Customers Data Table", new ArcliteDataTable("Customers Data Table", search.Value, "//td[text()='", "']/parent::tr", "/td/button", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Customers Add", new ArcliteButton("Customers Add", "//a[@onclick='AddEditCustomer(0)']"));
            name = new KeyValuePair<string, IArcliteWebElement>("Customers Name", new ArcliteTextBox("Customers Name", "//*[@id='txtNameCustomer']"));
            customerCode = new KeyValuePair<string, IArcliteWebElement>("Customers Item Type", new ArcliteTextBox("Customers Item Type", "//*[@id='CustomerCode']"));

            contactName = new KeyValuePair<string, IArcliteWebElement>("Customers Contact Name", new ArcliteTextBox("Customers Contact Name", "//*[@id='ContactName']"));
            contactNumber = new KeyValuePair<string, IArcliteWebElement>("Customers Contact Number", new ArcliteTextBox("Customers Contact Number", "//*[@id='ContactNumber']"));
            secondaryNumber = new KeyValuePair<string, IArcliteWebElement>("Customers Secondary Number", new ArcliteTextBox("Customers Secondary Number", "//*[@id='SecondaryNumber']"));
            email = new KeyValuePair<string, IArcliteWebElement>("Customers Email", new ArcliteTextBox("Customers Email", "//*[@id='ContactEmail']"));
            deliveryAddress = new KeyValuePair<string, IArcliteWebElement>("Customers Delivery Address", new ArcliteTextBox("Customers Delivery Address", "//*[@id='DeliveryAddress']"));

            notes = new KeyValuePair<string, IArcliteWebElement>("Customers Notes", new ArcliteTextBox("Customers Notes", "//*[@id='txtCustomerNotes']"));
            personInCharge = new KeyValuePair<string, IArcliteWebElement>("Customers Person In Charge", new ArcliteSelect("Customers Person In Charge", "//label[@class='control-label'][text()='Person In Charge']/parent::div/div", "//select[@id='ddlPersonInCharge']", "//label[@class='control-label'][text()='Person In Charge']/parent::div/div/div/div/div/div[@data-value = '", "']"));
            save = new KeyValuePair<string, IArcliteWebElement>("Customers Save", new ArcliteButton("Customers Save", "//button[@id='btnSave']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Customers Cancel", new ArcliteTextBox("Customers Cancel", "//button[@id='btnclose']"));
        }

        public void setElementXpaths()
        {
            this.elementXpaths.Add(search.Key, search.Value);
            this.elementXpaths.Add(dataTable.Key, dataTable.Value);
            this.elementXpaths.Add(add.Key, add.Value);
            this.elementXpaths.Add(name.Key, name.Value);
            this.elementXpaths.Add(customerCode.Key, customerCode.Value);

            this.elementXpaths.Add(contactName.Key, contactName.Value);
            this.elementXpaths.Add(contactNumber.Key, contactNumber.Value);
            this.elementXpaths.Add(secondaryNumber.Key, secondaryNumber.Value);
            this.elementXpaths.Add(email.Key, email.Value);
            this.elementXpaths.Add(deliveryAddress.Key, deliveryAddress.Value);

            this.elementXpaths.Add(notes.Key, notes.Value);
            this.elementXpaths.Add(personInCharge.Key, personInCharge.Value);
            this.elementXpaths.Add(save.Key, save.Value);
            this.elementXpaths.Add(cancel.Key, cancel.Value);

        }
    }
}
