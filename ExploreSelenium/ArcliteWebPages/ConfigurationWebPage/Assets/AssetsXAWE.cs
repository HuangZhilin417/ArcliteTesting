using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Assets
{
    public class AssetsXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> dataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> assetType;

        public KeyValuePair<string, IArcliteWebElement> serial;
        public KeyValuePair<string, IArcliteWebElement> description;
        public KeyValuePair<string, IArcliteWebElement> installedTime;
        public KeyValuePair<string, IArcliteWebElement> installedBy;
        public KeyValuePair<string, IArcliteWebElement> qualifications;

        public KeyValuePair<string, IArcliteWebElement> trackOEE;
        public KeyValuePair<string, IArcliteWebElement> save;
        public KeyValuePair<string, IArcliteWebElement> cancel;

        public AssetsXAWE(IArclitePage page)
        {
            this.initPage();
            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        public AssetsXAWE()
        {
            this.initPage();
        }

        //Dictionary<element name, XPath>
        private void initPage()
        {
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            search = new KeyValuePair<string, IArcliteWebElement>("Assets Search", new ArcliteSearch("Assets Search", "//div[@id='tblAssetManagement_filter']/label/input", null));
            IArcliteWebElement confirmDelete = new ArcliteButton("Assets Confirm Delete", "//a[@title='Yes, delete it!']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Assets Cancel Delete", "//div[@id='confirmation']/div/div/div/a[@title='Cancel']");
            dataTable = new KeyValuePair<string, IArcliteWebElement>("Assets Data Table", new ArcliteDataTable("Assets Data Table", search.Value, "//td[text()='", "']/parent::tr", "/td/button", confirmDelete, cancelDelete));
            add = new KeyValuePair<string, IArcliteWebElement>("Assets Add", new ArcliteButton("Assets Add", "//a[@onclick='AddEditAsset(0)']"));
            name = new KeyValuePair<string, IArcliteWebElement>("Assets Name", new ArcliteTextBox("Assets Name", "//*[@id='txtNameAsset']"));
            assetType = new KeyValuePair<string, IArcliteWebElement>("Assets Type", new ArcliteSelect("Assets Type", "//div[@id='partialDdlAssetType']/div/div[@class='fs-label-wrap']", "//select[@id='ParentAssetID']", "//div[@id='partialDdlAssetType']/div/div/div/div[@data-value = '", "']"));

            serial = new KeyValuePair<string, IArcliteWebElement>("Assets Serial", new ArcliteTextBox("Assets Serial", "//*[@id='MachineDetails_MachineSerial']"));
            description = new KeyValuePair<string, IArcliteWebElement>("Assets Description", new ArcliteTextBox("Assets Description", "//*[@id='MachineDetails_Description']"));
            installedTime = new KeyValuePair<string, IArcliteWebElement>("Assets Installed Time", new ArcliteCalender("Assets Installed Time", "//input[@id='installedtime']", "//input[@id='installedtime']/parent::div/div/ul/li/div[@class='datepicker']/div[@class='datepicker-days']/table/thead/tr/th[@class='next']", "//tr/td[text()='1']"));
            installedBy = new KeyValuePair<string, IArcliteWebElement>("Assets Installed By", new ArcliteSelect("Assets Installed By", "//label[text()='Installed By']/parent::div/div", "//select[@id='PersonnelID']", "//label[text()='Installed By']/parent::div/div/div/div/div[@data-value='", "']"));
            qualifications = new KeyValuePair<string, IArcliteWebElement>("Assets Qualifications", new ArcliteSelect("Assets Qualifications", "//div[@id='partialDdlQualification']/div", "//select[@id='select_qua']", "//div[@id='partialDdlQualification']/div/div/div/div[@data-value = '", "']"));

            trackOEE = new KeyValuePair<string, IArcliteWebElement>("Assets Track OEE", new ArcliteButton("Assets Track OEE", "//label[@for='trackOEE']"));
            save = new KeyValuePair<string, IArcliteWebElement>("Assets Save", new ArcliteButton("Assets Save", "//button[@id='btnSave']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Assets Cancel", new ArcliteTextBox("Assets Cancel", "//button[@id='btnclose']"));
        }

        public void setElementXpaths()
        {
            this.elementXpaths.Add(search.Key, search.Value);
            this.elementXpaths.Add(dataTable.Key, dataTable.Value);
            this.elementXpaths.Add(add.Key, add.Value);
            this.elementXpaths.Add(name.Key, name.Value);
            this.elementXpaths.Add(assetType.Key, assetType.Value);

            this.elementXpaths.Add(serial.Key, serial.Value);
            this.elementXpaths.Add(description.Key, description.Value);
            this.elementXpaths.Add(installedTime.Key, installedTime.Value);
            this.elementXpaths.Add(installedBy.Key, installedBy.Value);
            this.elementXpaths.Add(qualifications.Key, qualifications.Value);

            this.elementXpaths.Add(trackOEE.Key, trackOEE.Value);
            this.elementXpaths.Add(save.Key, save.Value);
            this.elementXpaths.Add(cancel.Key, cancel.Value);

        }
    }
}
