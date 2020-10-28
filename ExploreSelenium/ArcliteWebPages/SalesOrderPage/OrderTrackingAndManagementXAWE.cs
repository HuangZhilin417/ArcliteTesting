using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.SalesOrderPage
{
    class OrderTrackingAndManagementXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> addSalesOrder;
        public KeyValuePair<string, IArcliteWebElement> quotation;
        public KeyValuePair<string, IArcliteWebElement> customer;
        public KeyValuePair<string, IArcliteWebElement> order;
        public KeyValuePair<string, IArcliteWebElement> priority;

        public KeyValuePair<string, IArcliteWebElement> details;
        public KeyValuePair<string, IArcliteWebElement> requestedEndDate;
        public KeyValuePair<string, IArcliteWebElement> addJobs;
        public KeyValuePair<string, IArcliteWebElement> addChecklist;
        public KeyValuePair<string, IArcliteWebElement> search;

        public KeyValuePair<string, IArcliteWebElement> jobNotes;
        public KeyValuePair<string, IArcliteWebElement> jobAddCheckList;
        public KeyValuePair<string, IArcliteWebElement> jobAddWorkflow;
        public KeyValuePair<string, IArcliteWebElement> jobSelectWorkflow;
        public KeyValuePair<string, IArcliteWebElement> jobFinishedGoodItemType;

        public KeyValuePair<string, IArcliteWebElement> jobDone;
        public KeyValuePair<string, IArcliteWebElement> jobCancel;
        public KeyValuePair<string, IArcliteWebElement> checkListTable;
        public KeyValuePair<string, IArcliteWebElement> checkListDone;

        public KeyValuePair<string, IArcliteWebElement> checkListCancel;
        public KeyValuePair<string, IArcliteWebElement> submit;
        public KeyValuePair<string, IArcliteWebElement> saveDraft;
        public KeyValuePair<string, IArcliteWebElement> checklistSearch;

        public OrderTrackingAndManagementXAWE(IArclitePage page)
        {
            IArcliteWebElement confirmDelete = new ArcliteButton("Checklist Category Confirm Delete", "//a[@onclick='DeleteSupplier()']");
            IArcliteWebElement cancelDelete = new ArcliteButton("Checklist Category Cancel Delete", "//a[@onclick='DeleteSupplier()']/parent::div/a/i[@class='fas fa-times-circle arc-fa-2x']");
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            addSalesOrder = new KeyValuePair<string, IArcliteWebElement>("New Sales Order", new ArcliteButton("New Sales Order", "//a[@id='add_sales_order']"));
            quotation = new KeyValuePair<string, IArcliteWebElement>("Quotation #", new ArcliteTextBox("Quotation #", "//input[@id='quo-no']"));
            customer = new KeyValuePair<string, IArcliteWebElement>("customer", new ArcliteSelect("Customer", "//span[@id='select2-customer-container']", "//select[@id='customer']"));
            order = new KeyValuePair<string, IArcliteWebElement>("Order", new ArcliteTextBox("Order", "//input[@id='po-no']"));
            priority = new KeyValuePair<string, IArcliteWebElement>("Priority", new ArcliteSelect("New Sales Order", null, "//select[@id='priority']"));

            requestedEndDate = new KeyValuePair<string, IArcliteWebElement>("Requested End Date", new ArcliteCalender("Requested End Date", "//div[@id='requested-end-date-dtp']/span", 
                "//div/ul/li/div[@class='datepicker']/div[@class='datepicker-days']/table/thead/tr/th[@class='next']", "//tr/td[text()='1']"));
            details = new KeyValuePair<string, IArcliteWebElement>("Details", new ArcliteTextBox("Details", "//textarea[@id='detail']"));
            addJobs = new KeyValuePair<string, IArcliteWebElement>("Add Job", new ArcliteButton("Add Job", "//div/button[text()='Columns']/parent::div/a/i"));
            jobNotes = new KeyValuePair<string, IArcliteWebElement>("Job Notes", new ArcliteTextBox("Job Notes", "//textarea[@id='txt_NOTES']"));
            jobAddCheckList = new KeyValuePair<string, IArcliteWebElement>("Job Add CheckList", new ArcliteButton("Job Add CheckList", "//a[@onclick='GetChecklists(true)']"));

            jobAddWorkflow = new KeyValuePair<string, IArcliteWebElement>("Job Add WorkFlow", new ArcliteButton("Job Add WorkFlow", "//a[@id='add_sales_order']"));
            jobSelectWorkflow = new KeyValuePair<string, IArcliteWebElement>("Job Select Checklist", new ArcliteSelect("Job Select Checklist", "//span[@id='select2-workflows-container']", "//select[@id='workflows']"));
            jobFinishedGoodItemType = new KeyValuePair<string, IArcliteWebElement>("Job Finished Good Item Type", new ArcliteButton("Job Finished Good Item Type", "//div[@id='selected-items']"));
            jobDone = new KeyValuePair<string, IArcliteWebElement>("Job Done", new ArcliteButton("Job Done", "//a[@id='add-wo']"));
            jobCancel = new KeyValuePair<string, IArcliteWebElement>("Job Cancel", new ArcliteButton("Job Cancel", "//a[@onclick='closeNav()']"));

            addChecklist = new KeyValuePair<string, IArcliteWebElement>("Add Checklist", new ArcliteButton("Add Checklist", "//a[@onclick='GetChecklists(false)']"));
            checklistSearch = new KeyValuePair<string, IArcliteWebElement>("CheckList Search", new ArcliteSearch("CheckList Search", "//div[@id='tblChecklists_filter']/label/input", null));
            checkListTable = new KeyValuePair<string, IArcliteWebElement>("Checklist Table", new ArcliteDataTable("Checklist Table", new ArcliteSearch("CheckList Search", "//div[@id='tblChecklists_filter']/label/input", null), 
                "//table[@id='tblChecklists']/tbody/tr/td/span[text()='", "']", "/parent::td/parent::tr/td/div/label", null, null));
            checkListDone = new KeyValuePair<string, IArcliteWebElement>("Checklist Done", new ArcliteButton("Checklist Done", "//a[@id='btnAddChecklists']"));
            checkListCancel = new KeyValuePair<string, IArcliteWebElement>("Checklist Cancel", new ArcliteButton("Checklist Cancel", "//div[@id='checklistMdl']/div/div/div/a[@id='close_sch_job_display_setting_close']"));

            submit = new KeyValuePair<string, IArcliteWebElement>("Submit", new ArcliteButton("Submit", "//button[@id='complete-so']"));
            saveDraft = new KeyValuePair<string, IArcliteWebElement>("Save Draft", new ArcliteButton("Save Draft", "//button[@id='save-draft']"));
            search = new KeyValuePair<string, IArcliteWebElement>("Search", new ArcliteSearch("Search", "//input[@id='search_text']", "//a[@id='search']"));


            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }
        public void setElementXpaths()
        {
            elementXpaths.Add(addSalesOrder.Key, addSalesOrder.Value);
            elementXpaths.Add(quotation.Key, quotation.Value);
            elementXpaths.Add(customer.Key, customer.Value);
            elementXpaths.Add(order.Key, order.Value);
            elementXpaths.Add(priority.Key, priority.Value);

            elementXpaths.Add(requestedEndDate.Key, requestedEndDate.Value);
            elementXpaths.Add(details.Key, details.Value);
            elementXpaths.Add(addJobs.Key, addJobs.Value);
            elementXpaths.Add(jobNotes.Key, jobNotes.Value);
            elementXpaths.Add(jobAddCheckList.Key, jobAddCheckList.Value);

            elementXpaths.Add(jobAddWorkflow.Key, jobAddWorkflow.Value);
            elementXpaths.Add(jobSelectWorkflow.Key, jobSelectWorkflow.Value);
            elementXpaths.Add(jobFinishedGoodItemType.Key, jobFinishedGoodItemType.Value);
            elementXpaths.Add(jobDone.Key, jobDone.Value);
            elementXpaths.Add(jobCancel.Key, jobCancel.Value);

            elementXpaths.Add(addChecklist.Key, addChecklist.Value);
            elementXpaths.Add(checkListTable.Key, checkListTable.Value);
            elementXpaths.Add(checkListDone.Key, checkListDone.Value);
            elementXpaths.Add(checkListCancel.Key, checkListCancel.Value);

            elementXpaths.Add(submit.Key, submit.Value);
            elementXpaths.Add(saveDraft.Key, saveDraft.Value);
            elementXpaths.Add(search.Key, search.Value);
            elementXpaths.Add(checklistSearch.Key, checklistSearch.Value);

        }
    }
}
