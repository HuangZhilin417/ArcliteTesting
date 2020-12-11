using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System.Collections.Generic;
using System.Linq;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Qualification
{
    public class QualificationXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> type;

        public KeyValuePair<string, IArcliteWebElement> description;
        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;

        public QualificationXAWE(IArclitePage page)
        {
            this.initPage();
            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        //Dictionary<element name, XPath>
        public QualificationXAWE()
        {
            this.initPage();
        }

        //Dictionary<element name, XPath>
        private void initPage()
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteQualification()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteQualification()']/parent::div/a/i[@class='fas fa-times-circle arc-fa-2x']");
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Qualification Search", new ArcliteSearch("Qualification Search", "//div[@id='qa_table_filter']/label/input", null));
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Qualification Data Table", new ArcliteDataTable("Qualification Data Table", search.Value, "//td[normalize-space(text())='", "']/parent::tr", "/td/button", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Qualification Add", new ArcliteButton("Qualification Add", "//button[@onclick='AddEditQualification(0)']"));
            name = new KeyValuePair<string, IArcliteWebElement>("Qualification Name", new ArcliteTextBox("Qualification Name", "//input[@id='txtNameQ']"));
            type = new KeyValuePair<string, IArcliteWebElement>("Qualification Type", new ArcliteSelect("Qualification Type", "//div[@id='divQualificationType']/div", "//select[@id='ddlQualificationType']", "//div[@id='divQualificationType']/div/div/div/div[@data-value = '", "']"));

            description = new KeyValuePair<string, IArcliteWebElement>("Qualification Description", new ArcliteTextBox("Qualification Description", "//textarea[@id='txtDescQ']"));
            save = new KeyValuePair<string, IArcliteWebElement>("Qualification Save", new ArcliteButton("Qualification Save", "//button[@onclick='SaveUpdateQualification(0)']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Qualification Cancel", new ArcliteButton("Qualification Cancel", "//button[@id='btnclose']"));
        }

        public void setElementXpaths()
        {
            this.elementXpaths.Add(search.Key, search.Value);
            this.elementXpaths.Add(dataTable.Key, dataTable.Value);
            this.elementXpaths.Add(add.Key, add.Value);
            this.elementXpaths.Add(name.Key, name.Value);
            this.elementXpaths.Add(type.Key, type.Value);

            this.elementXpaths.Add(description.Key, description.Value);
            this.elementXpaths.Add(save.Key, save.Value);
            this.elementXpaths.Add(cancel.Key, cancel.Value);
        }
    }
}