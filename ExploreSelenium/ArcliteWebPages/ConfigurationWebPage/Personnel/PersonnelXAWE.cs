using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Personnel
{
    public class PersonnelXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> userName;
        public KeyValuePair<string, IArcliteWebElement> firstName;

        public KeyValuePair<string, IArcliteWebElement> lastName;
        public KeyValuePair<string, IArcliteWebElement> primaryPassword;
        public KeyValuePair<string, IArcliteWebElement> confirmPassword;
        public KeyValuePair<string, IArcliteWebElement> email;
        public KeyValuePair<string, IArcliteWebElement> department;
        


        public KeyValuePair<string, IArcliteWebElement> title;
        public KeyValuePair<string, IArcliteWebElement> qualification;
        public KeyValuePair<string, IArcliteWebElement> role;
        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;


        public PersonnelXAWE(IArclitePage page)
        {

            this.initPage();
            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }


        public PersonnelXAWE()
        {

            this.initPage();
        }

        private void initPage()
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeletePersonnel()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@title='Cancel']");

            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Personnel Search", new ArcliteSearch("Personnel Search", "//div[@id='item_table_filter']/label/input", null));
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Personnel Data Table", new ArcliteDataTable("Personnel Data Table", search.Value, "//table[@id='item_table']/tbody/tr/td[text()='", "']", "/parent::tr/td/button", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Personnel Add", new ArcliteButton("Personnel Add", "//a[@onclick='AddEditPersonnel(0)']"));
            userName = new KeyValuePair<string, IArcliteWebElement>("Personnel User Name", new ArcliteTextBox("Personnel User Name", "//*[@id='txtusername']"));
            firstName = new KeyValuePair<string, IArcliteWebElement>("Personnel First Name", new ArcliteTextBox("Personnel First Name", "//*[@id='txtfirstname']"));

            lastName = new KeyValuePair<string, IArcliteWebElement>("Personnel Last Name", new ArcliteTextBox("Personnel Last Name", "//*[@id='txtlastname']"));
            primaryPassword = new KeyValuePair<string, IArcliteWebElement>("Personnel Primary Password", new ArcliteTextBox("Personnel Primary Password", "//*[@id='txtPrimaryPassword']"));
            confirmPassword = new KeyValuePair<string, IArcliteWebElement>("Personnel Confirm Password", new ArcliteTextBox("Personnel Confirm Password", "//*[@id='txtConfirmPrimaryPassword']"));
            email = new KeyValuePair<string, IArcliteWebElement>("Personnel Email", new ArcliteTextBox("Personnel Email", "//*[@id='txtPrimaryEmail']"));
            department = new KeyValuePair<string, IArcliteWebElement>("Personnel Department", new ArcliteTextBox("Personnel Department", "//*[@id='select_departement']"));

            title = new KeyValuePair<string, IArcliteWebElement>("Personnel Title", new ArcliteTextBox("Personnel Title", "//*[@id='txtposition']"));
            qualification = new KeyValuePair<string, IArcliteWebElement>("Personnel Qualification", new ArcliteSelect("Personnel Qualification", "//div[@id='partialDdlQualification']/div/div[@class='fs-label-wrap']", "//select[@id='select_qua']", "//div[@id='partialDdlQualification']/div/div/div/div[@data-value = '", "']"));
            role = new KeyValuePair<string, IArcliteWebElement>("Personnel Role", new ArcliteSelect("Personnel Role", "//form[@id='add-update-personnel']/div/div/div/div/div[@class='fs-label-wrap']", "//select[@id='select_role']", "//*[@id='add-update-personnel']/div/div/div/div/div/div/div[@data-value = '", "']"));
            save = new KeyValuePair<string, IArcliteWebElement>("Personnel Save", new ArcliteButton("Personnel Save", "//*[@id='btnSave'][@onclick='SaveUpdatePersonnel(0)']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Personnel Cancel", new ArcliteTextBox("Personnel Cancel", "//button[@id='btnclose']"));
        }
        //Dictionary<element name, XPath>


        public void setElementXpaths()
        {
            this.elementXpaths.Add(search.Key, search.Value);
            this.elementXpaths.Add(dataTable.Key, dataTable.Value);
            this.elementXpaths.Add(add.Key, add.Value);
            this.elementXpaths.Add(userName.Key, userName.Value);
            this.elementXpaths.Add(firstName.Key, firstName.Value);

            this.elementXpaths.Add(lastName.Key, lastName.Value);
            this.elementXpaths.Add(primaryPassword.Key, primaryPassword.Value);
            this.elementXpaths.Add(confirmPassword.Key, confirmPassword.Value);
            this.elementXpaths.Add(email.Key, email.Value);
            this.elementXpaths.Add(department.Key, department.Value);

            this.elementXpaths.Add(title.Key, title.Value);
            this.elementXpaths.Add(qualification.Key, qualification.Value);
            this.elementXpaths.Add(role.Key, role.Value);
            this.elementXpaths.Add(save.Key, save.Value);
            this.elementXpaths.Add(cancel.Key, cancel.Value);

        }
    }
}

