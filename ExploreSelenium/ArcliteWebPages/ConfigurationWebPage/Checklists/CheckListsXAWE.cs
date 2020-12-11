using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System.Collections.Generic;
using System.Linq;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Checklists
{
    public class CheckListsXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> search;
        public KeyValuePair<string, IArcliteWebElement> checklistDataTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> manageCategories;
        public KeyValuePair<string, IArcliteWebElement> all;

        public KeyValuePair<string, IArcliteWebElement> approve;
        public KeyValuePair<string, IArcliteWebElement> approveDataTable;
        public KeyValuePair<string, IArcliteWebElement> name;
        public KeyValuePair<string, IArcliteWebElement> categoryName;
        public KeyValuePair<string, IArcliteWebElement> formNumber;

        public KeyValuePair<string, IArcliteWebElement> addCategory;
        public KeyValuePair<string, IArcliteWebElement> addCategoryName;
        public KeyValuePair<string, IArcliteWebElement> categorySave;
        public KeyValuePair<string, IArcliteWebElement> categoryCancel;
        public KeyValuePair<string, IArcliteWebElement> categoryTable;

        public KeyValuePair<string, IArcliteWebElement> revisionNumber;
        public KeyValuePair<string, IArcliteWebElement> header;
        public KeyValuePair<string, IArcliteWebElement> footer;
        public KeyValuePair<string, IArcliteWebElement> description;
        public KeyValuePair<string, IArcliteWebElement> save;

        public KeyValuePair<string, IArcliteWebElement> approvePassword;
        public KeyValuePair<string, IArcliteWebElement> approveStatus;
        public KeyValuePair<string, IArcliteWebElement> approveConfirm;
        public KeyValuePair<string, IArcliteWebElement> approveCancel;
        public KeyValuePair<string, IArcliteWebElement> categorySearch;

        public KeyValuePair<string, IArcliteWebElement> cancel;
        public KeyValuePair<string, IArcliteWebElement> approveSearch;

        public CheckListsXAWE(IArclitePage page)
        {
            this.initPage();
            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        public CheckListsXAWE()
        {
            this.initPage();
        }

        //Dictionary<element name, XPath>
        private void initPage()
        {
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            IArcliteWebElement approveRequestConfirm = new ArcliteButton("Checklist Category Approve Request Submit", "//a[@onclick='SaveApprovalRequest()']");
            IArcliteWebElement approveRequestCancel = new ArcliteButton("Checklist Category Approve Request Cancel", "//a[@onclick='SaveApprovalRequest()']/parent::div/a[@title='Close']");
            search = new KeyValuePair<string, IArcliteWebElement>("Checklist Search", new ArcliteSearch("Checklist Search", "//div[@id='gvChecklist_filter']/label/input", null));
            checklistDataTable = new KeyValuePair<string, IArcliteWebElement>("Checklist Data Table", new ArcliteDataTable("Checklist Data Table", search.Value, "//td[text()='", "']/parent::tr", "/td[@class='details-control']", "//td[text()='", "']/parent::tr/td/a[text()='Submit Approval']", approveRequestConfirm, approveRequestCancel));
            add = new KeyValuePair<string, IArcliteWebElement>("Checklist Add", new ArcliteButton("Checklist Add", "//a[@title='Add Checklist']/i"));
            manageCategories = new KeyValuePair<string, IArcliteWebElement>("Checklist Manage Categories", new ArcliteButton("Checklist Manage Categories", "//a[text()='Manage Categories']"));
            all = new KeyValuePair<string, IArcliteWebElement>("Checklist All", new ArcliteButton("Checklist All", "//a[@id='dvAllChklst-tab']"));

            approve = new KeyValuePair<string, IArcliteWebElement>("Checklist Approve", new ArcliteButton("Checklist Approve", "//a[@id='dvAllChklst-approval-tab']"));
            approveSearch = new KeyValuePair<string, IArcliteWebElement>("Checklist Approve Search", new ArcliteSearch("Checklist Approve Search", "//div[@id='tblCreationApprovals_filter']/label/input", null));

            approveDataTable = new KeyValuePair<string, IArcliteWebElement>("Checklist Approve Data Table", new ArcliteDataTable("Checklist Approve Data Table", approveSearch.Value, "//td[normalize-space(text()) = '", "']/parent::tr", "/td/a", null, null));
            name = new KeyValuePair<string, IArcliteWebElement>("Checklist Name", new ArcliteTextBox("Checklist Name", "//*[@id='txtTemplateName']"));
            categoryName = new KeyValuePair<string, IArcliteWebElement>("Checklist Category Name", new ArcliteSelect("Checklist Category Name", "//select[@id='ddlCategoryList']", "//select[@id='ddlCategoryList']"));

            addCategory = new KeyValuePair<string, IArcliteWebElement>("Checklist Add Category", new ArcliteButton("Checklist Add Category", "//a[@onclick='ShowAddChecklistCategoryPopup()']"));
            addCategoryName = new KeyValuePair<string, IArcliteWebElement>("Checklist Add Category Name", new ArcliteTextBox("Checklist Add Category Name", "//input[@id='txtCategoryName']"));
            categorySave = new KeyValuePair<string, IArcliteWebElement>("Checklist Category Save", new ArcliteButton("Checklist Category Save", "//button[@id='btnSaveCategory']"));
            categoryCancel = new KeyValuePair<string, IArcliteWebElement>("Checklist Category Cancel", new ArcliteButton("Checklist Category Cancel", "//button[@onclick='closeAddChecklistCategoryPopup();']"));
            categorySearch = new KeyValuePair<string, IArcliteWebElement>("Checklist Category Search", new ArcliteSearch("Checklist Category Search", "//div[@id='tblChecklistCategory_filter']/label/input']", null));

            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteChecklistCategory();']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteCategoryCancel();']");

            categoryTable = new KeyValuePair<string, IArcliteWebElement>("Checklist Category Table", new ArcliteDataTable("Checklist Category Table", categorySearch.Value, "//td[normalize-space(text()) = '", "']/parent::tr", "/td/a[@title='Click to Delete']", confirmDelete, cancelDelete));
            revisionNumber = new KeyValuePair<string, IArcliteWebElement>("Checklist Revision Number", new ArcliteTextBox("Checklist Revision Number", "//*[@id='txtRevisionNo']"));
            header = new KeyValuePair<string, IArcliteWebElement>("Checklist Header", new ArcliteTextBox("Checklist Header", "//*[@id='txtHeader']"));
            footer = new KeyValuePair<string, IArcliteWebElement>("Checklist Footer", new ArcliteTextBox("Checklist Footer", "//*[@id='txtFooter']"));
            description = new KeyValuePair<string, IArcliteWebElement>("Checklist Description", new ArcliteTextBox("Checklist Description", "//*[@id='txtDescription']"));

            approvePassword = new KeyValuePair<string, IArcliteWebElement>("Checklist Approve Password", new ArcliteTextBox("Checklist Approve Password", "//input[@id='txtPassword']"));
            approveStatus = new KeyValuePair<string, IArcliteWebElement>("Checklist Approve Status", new ArcliteSelect("Checklist Approve Status", "//select[@id='ddlApprovalStatus']", "//select[@id='ddlApprovalStatus']"));
            approveConfirm = new KeyValuePair<string, IArcliteWebElement>("Checklist Approve Confirm", new ArcliteButton("Checklist Approve Confirm", "//button[@id='btnApproveStep']"));
            approveCancel = new KeyValuePair<string, IArcliteWebElement>("Checklist Approve Cancel", new ArcliteButton("Checklist Approve Cancel", "//button[@class='btn arc-btn-icon-red ml-1']"));
            save = new KeyValuePair<string, IArcliteWebElement>("Checklist Save", new ArcliteButton("Checklist Save", "//*[@id='btnSaveChecklist']"));

            formNumber = new KeyValuePair<string, IArcliteWebElement>("Checklist Form Number", new ArcliteTextBox("Checklist Form Number", "//input[@id='txtFileNo']"));
            cancel = new KeyValuePair<string, IArcliteWebElement>("Checklist Cancel", new ArcliteTextBox("Checklist Cancel", "//*[@id='btnCancelChecklist']"));
        }

        public void setElementXpaths()
        {
            this.elementXpaths.Add(search.Key, search.Value);
            this.elementXpaths.Add(checklistDataTable.Key, checklistDataTable.Value);
            this.elementXpaths.Add(add.Key, add.Value);
            this.elementXpaths.Add(manageCategories.Key, manageCategories.Value);
            this.elementXpaths.Add(all.Key, all.Value);

            this.elementXpaths.Add(approve.Key, approve.Value);
            this.elementXpaths.Add(approveDataTable.Key, approveDataTable.Value);
            this.elementXpaths.Add(name.Key, name.Value);
            this.elementXpaths.Add(categoryName.Key, categoryName.Value);
            this.elementXpaths.Add(formNumber.Key, formNumber.Value);

            this.elementXpaths.Add(addCategory.Key, addCategory.Value);
            this.elementXpaths.Add(addCategoryName.Key, addCategoryName.Value);
            this.elementXpaths.Add(categorySave.Key, categorySave.Value);
            this.elementXpaths.Add(categoryCancel.Key, categoryCancel.Value);
            this.elementXpaths.Add(categoryTable.Key, categoryTable.Value);

            this.elementXpaths.Add(revisionNumber.Key, revisionNumber.Value);
            this.elementXpaths.Add(header.Key, header.Value);
            this.elementXpaths.Add(footer.Key, footer.Value);
            this.elementXpaths.Add(description.Key, description.Value);
            this.elementXpaths.Add(save.Key, save.Value);

            this.elementXpaths.Add(approvePassword.Key, approvePassword.Value);
            this.elementXpaths.Add(approveStatus.Key, approveStatus.Value);
            this.elementXpaths.Add(categorySearch.Key, categorySearch.Value);
            this.elementXpaths.Add(approveSearch.Key, approveSearch.Value);
            this.elementXpaths.Add(cancel.Key, cancel.Value);

            this.elementXpaths.Add(approveConfirm.Key, approveConfirm.Value);
            this.elementXpaths.Add(approveCancel.Key, approveCancel.Value);
        }
    }
}