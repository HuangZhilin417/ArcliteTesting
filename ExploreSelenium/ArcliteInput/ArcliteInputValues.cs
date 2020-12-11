using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebPages;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Assets;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Checklists;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Customers;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Personnel;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.AssetTypeManager;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Currency;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.InventoryItemType;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.LocationManager;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Qualification;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Unit;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Suppliers;
using ExploreSelenium.ArcliteWebPages.Inventory;
using ExploreSelenium.ArcliteWebPages.SalesOrderPage;
using ExploreSelenium.ArcliteWebPages.Workflow_Builder;
using ExploreSelenium.ArcliteWebPages.WorkstationPage;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteInputs
{
    public struct InputVal
    {
        /*
         * The auto return value
         */
        public string valOne;

        /*
         * The alternate return value
         */
        public string valTwo;

        /*
         * Selects the return val, one or two
         */
        public bool isFirst;

        /*
         * Creates a InputVal with two possible return options
         *
         */

        public InputVal(string val1, string val2)
        {
            this.valOne = val1;
            this.valTwo = val2;
            this.isFirst = true;
        }

        /*
         * Creates a InputVal with two possible return options and with the selected return option
         */

        public InputVal(string val1, string val2, bool isFirst)
        {
            this.valOne = val1;
            this.valTwo = val2;
            this.isFirst = isFirst;
        }

        /*
         * Creates a InputVal with only one return value
         */

        public InputVal(string val1)
        {
            this.valOne = val1;
            this.valTwo = "";
            this.isFirst = true;
        }

        /*
         * Switch selected option between first and second
         */

        public InputVal switchVal()
        {
            this.isFirst = !isFirst;
            return this;
        }

        /*
         * Returns the selected value
         */

        public string getSelectedVal()
        {
            if (this.isFirst)
            {
                return this.valOne;
            }
            else
            {
                return this.valTwo;
            }
        }
    }

    /*
     * A Input class that is responsible for all inputs in testing
     */

    public class ArcliteInputValues : IArcliteInputs
    {
        private Dictionary<string, InputVal> inputs = new Dictionary<string, InputVal>();
        private InventoryXAWE inventoryInfo;
        private PersonnelXAWE personnelInfo;
        private LoginPageXAWE loginInfo;
        private AssetsXAWE assetsInfo;
        private CustomersXAWE customersInfo;
        private SuppliersXAWE suppliersInfo;
        private CheckListsXAWE checkListsInfo;
        private InventoryItemTypeXAWE inventoryItemTypeInfo;
        private UnitXAWE unitInfo;
        private CurrencyXAWE currencyInfo;
        private LocationManagerXAWE locationManagerInfo;
        private QualificationXAWE qualificationInfo;
        private AssetTypeManagerXAWE assetTypeManagerInfo;
        private OrderTrackingAndManagementXAWE orderTrackingAndManagementInfo;
        private WorkflowBuilderXAWE workflowInfo;
        private WorkstationXAWE workstationInfo;

        /*
         * Needs to contain every single page's info class, and then call initInputs
         */

        public ArcliteInputValues()
        {
            inventoryInfo = new InventoryXAWE();
            personnelInfo = new PersonnelXAWE();
            loginInfo = new LoginPageXAWE();
            assetsInfo = new AssetsXAWE();
            customersInfo = new CustomersXAWE();
            suppliersInfo = new SuppliersXAWE();
            checkListsInfo = new CheckListsXAWE();
            inventoryItemTypeInfo = new InventoryItemTypeXAWE();
            unitInfo = new UnitXAWE();
            currencyInfo = new CurrencyXAWE();
            locationManagerInfo = new LocationManagerXAWE();
            qualificationInfo = new QualificationXAWE();
            assetTypeManagerInfo = new AssetTypeManagerXAWE();
            orderTrackingAndManagementInfo = new OrderTrackingAndManagementXAWE();
            workflowInfo = new WorkflowBuilderXAWE();
            workstationInfo = new WorkstationXAWE();

            this.initInputs();
        }

        /*
         * Needs to Initialize all of the entries for the inputs dictionary
         */

        private void initInputs()
        {
            inputs.Add(loginInfo.username.Key, new InputVal("admin"));
            inputs.Add(loginInfo.password.Key, new InputVal("admin"));

            inputs.Add(assetTypeManagerInfo.name.Key, new InputVal("Support"));
            inputs.Add(assetTypeManagerInfo.description.Key, new InputVal("Support the  chip"));

            inputs.Add(qualificationInfo.name.Key, new InputVal("Best Nunchaku User", "Best Nunchaku Machine"));
            inputs.Add(qualificationInfo.type.Key, new InputVal("Personnel", "Machine"));
            inputs.Add(qualificationInfo.description.Key, new InputVal("name says it all"));

            inputs.Add(locationManagerInfo.name.Key, new InputVal("California"));
            inputs.Add(locationManagerInfo.code.Key, new InputVal("1234"));
            inputs.Add(locationManagerInfo.description.Key, new InputVal("The first warehouse in California"));

            inputs.Add(currencyInfo.name.Key, new InputVal("Chinese Yuan"));
            inputs.Add(currencyInfo.symbol.Key, new InputVal("Y"));

            inputs.Add(unitInfo.name.Key, new InputVal("count"));
            inputs.Add(unitInfo.symbol.Key, new InputVal("p"));

            inputs.Add(inventoryItemTypeInfo.name.Key, new InputVal("Iphone 12 Pro Max Super"));
            inputs.Add(inventoryItemTypeInfo.description.Key, new InputVal("the brand new Iphone, cost 1499$"));
            inputs.Add(inventoryItemTypeInfo.minimumQuantity.Key, new InputVal("100"));
            inputs.Add(inventoryItemTypeInfo.maximumQuantity.Key, new InputVal("100000"));
            inputs.Add(inventoryItemTypeInfo.reorderQuantity.Key, new InputVal("100"));
            inputs.Add(inventoryItemTypeInfo.unit.Key, new InputVal(unitInfo.name.Key));

            inputs.Add(inventoryInfo.barcode.Key, new InputVal("945207352"));
            inputs.Add(inventoryInfo.inventoryItemType.Key, new InputVal(inventoryItemTypeInfo.name.Key));
            inputs.Add(inventoryInfo.name.Key, new InputVal("A lot of work to do"));
            inputs.Add(inventoryInfo.supplier.Key, new InputVal("Caleb Furnas"));
            inputs.Add(inventoryInfo.unitCost.Key, new InputVal("100"));
            inputs.Add(inventoryInfo.heldQuantity.Key, new InputVal("1499"));
            inputs.Add(inventoryInfo.currency.Key, new InputVal(currencyInfo.name.Key));
            inputs.Add(inventoryInfo.notes.Key, new InputVal("Hi this is testing with the new wrapper"));
            inputs.Add(inventoryInfo.purchaseReceivedDate.Key, new InputVal(""));

            inputs.Add(personnelInfo.userName.Key, new InputVal("BCisaFB"));
            inputs.Add(personnelInfo.firstName.Key, new InputVal("Josh"));
            inputs.Add(personnelInfo.lastName.Key, new InputVal("Huang"));
            inputs.Add(personnelInfo.primaryPassword.Key, new InputVal("Itsme1234!"));
            inputs.Add(personnelInfo.confirmPassword.Key, new InputVal("Itsme1234!"));
            inputs.Add(personnelInfo.email.Key, new InputVal("master@gmail.com"));
            inputs.Add(personnelInfo.department.Key, new InputVal("chrome"));
            inputs.Add(personnelInfo.title.Key, new InputVal("master"));
            inputs.Add(personnelInfo.qualification.Key, new InputVal("Best Nunchaku User"));
            inputs.Add(personnelInfo.role.Key, new InputVal("Admin"));

            inputs.Add(assetsInfo.name.Key, new InputVal("A Chip"));
            inputs.Add(assetsInfo.assetType.Key, new InputVal("Support"));
            inputs.Add(assetsInfo.serial.Key, new InputVal("94520735279253217"));
            inputs.Add(assetsInfo.description.Key, new InputVal("big chip is the best ever"));
            inputs.Add(assetsInfo.installedBy.Key, new InputVal("Josh Huang"));
            inputs.Add(assetsInfo.qualifications.Key, new InputVal("Best Nunchaku Machine"));

            inputs.Add(customersInfo.name.Key, new InputVal("BCisaFB"));
            inputs.Add(customersInfo.customerCode.Key, new InputVal("9452"));
            inputs.Add(customersInfo.contactName.Key, new InputVal("Bailey Clark"));
            inputs.Add(customersInfo.contactNumber.Key, new InputVal("+1520520"));
            inputs.Add(customersInfo.secondaryNumber.Key, new InputVal("+114141414"));
            inputs.Add(customersInfo.email.Key, new InputVal("baileyclark@gmail.com"));
            inputs.Add(customersInfo.deliveryAddress.Key, new InputVal("chrome"));
            inputs.Add(customersInfo.notes.Key, new InputVal("never regret"));
            inputs.Add(customersInfo.personInCharge.Key, new InputVal("Josh Huang"));

            inputs.Add(suppliersInfo.name.Key, new InputVal("Caleb Furnas"));
            inputs.Add(suppliersInfo.suppliersCode.Key, new InputVal("9452"));
            inputs.Add(suppliersInfo.contactName.Key, new InputVal("Caleb"));
            inputs.Add(suppliersInfo.contactNumber.Key, new InputVal("+1520520"));
            inputs.Add(suppliersInfo.secondaryNumber.Key, new InputVal("+114141414"));
            inputs.Add(suppliersInfo.email.Key, new InputVal("calebFurnas@gmail.com"));
            inputs.Add(suppliersInfo.address.Key, new InputVal("chrome"));
            inputs.Add(suppliersInfo.notes.Key, new InputVal("never regret"));
            inputs.Add(suppliersInfo.personInCharge.Key, new InputVal("Josh Huang"));
            inputs.Add(suppliersInfo.description.Key, new InputVal("My best friend"));

            inputs.Add(checkListsInfo.approvePassword.Key, new InputVal(loginInfo.password.Key));
            inputs.Add(checkListsInfo.approveStatus.Key, new InputVal("Approved"));
            inputs.Add(checkListsInfo.name.Key, new InputVal("daily to do list "));
            inputs.Add(checkListsInfo.addCategoryName.Key, new InputVal("new daily list"));
            inputs.Add(checkListsInfo.formNumber.Key, new InputVal("7925"));
            inputs.Add(checkListsInfo.revisionNumber.Key, new InputVal("94520"));
            inputs.Add(checkListsInfo.header.Key, new InputVal("head"));
            inputs.Add(checkListsInfo.footer.Key, new InputVal("foot"));
            inputs.Add(checkListsInfo.description.Key, new InputVal("daily checklist"));

            inputs.Add(workflowInfo.workflowName.Key, new InputVal("new work flow josh"));
            inputs.Add(workflowInfo.instructionName.Key, new InputVal("before the model"));
            inputs.Add(workflowInfo.description.Key, new InputVal("creating a new workflow testing canvas"));
            inputs.Add(workflowInfo.stepName.Key, new InputVal("Starting Step Created In Selenium", "Ending Step Created In Selenium"));
            inputs.Add(workflowInfo.runTime.Key, new InputVal("00:00:05"));
            inputs.Add(workflowInfo.cycleTime.Key, new InputVal("1"));
            inputs.Add(workflowInfo.workflowTable.Key, new InputVal(workflowInfo.workflowName.Key));
            inputs.Add(workflowInfo.personnelQualificationTable.Key, new InputVal(personnelInfo.qualification.Key));
            inputs.Add(workflowInfo.personnelTable.Key, new InputVal(personnelInfo.userName.Key));
            inputs.Add(workflowInfo.machineQualificationTable.Key, new InputVal(assetsInfo.qualifications.Key));
            inputs.Add(workflowInfo.assetTable.Key, new InputVal(assetsInfo.name.Key));
            inputs.Add(workflowInfo.itemsTable.Key, new InputVal(inventoryItemTypeInfo.name.Key));
            inputs.Add(workflowInfo.attachment.Key, new InputVal(@Util.getCurrentFileLocation("Arctest.png")));
            inputs.Add(workflowInfo.name.Key, new InputVal("new checklist"));
            inputs.Add(workflowInfo.notes.Key, new InputVal("new checklist created in Selenium"));
            inputs.Add(workflowInfo.expectedValue.Key, new InputVal("50"));

            inputs.Add(orderTrackingAndManagementInfo.quotation.Key, new InputVal("94527925"));
            inputs.Add(orderTrackingAndManagementInfo.customer.Key, new InputVal(customersInfo.name.Key));
            inputs.Add(orderTrackingAndManagementInfo.order.Key, new InputVal(inventoryItemTypeInfo.name.Key));
            inputs.Add(orderTrackingAndManagementInfo.details.Key, new InputVal("adding sales order from selenium test method"));
            inputs.Add(orderTrackingAndManagementInfo.jobNotes.Key, new InputVal("this is adding job for selenium testing"));
            inputs.Add(orderTrackingAndManagementInfo.jobFinishedGoodItemTable.Key, new InputVal(inventoryItemTypeInfo.name.Key));
            inputs.Add(orderTrackingAndManagementInfo.jobFinishedGoodItemQuantity.Key, new InputVal("100", inventoryItemTypeInfo.name.Key));
            inputs.Add(orderTrackingAndManagementInfo.jobSelectWorkflow.Key, new InputVal(workflowInfo.workflowName.Key));

            inputs.Add(orderTrackingAndManagementInfo.checkListTable.Key, new InputVal(checkListsInfo.name.Key));

            inputs.Add(orderTrackingAndManagementInfo.dataTable.Key, new InputVal(workflowInfo.workflowName.Key));

            inputs.Add(workstationInfo.ongoingWorkstationTable.Key, new InputVal(workflowInfo.workflowName.Key));
            inputs.Add(workstationInfo.stepsTable.Key, new InputVal(workflowInfo.stepName.Key, workflowInfo.stepName.Key));
            inputs.Add(workstationInfo.completedWorkstationTable.Key, new InputVal(customersInfo.name.Key));
        }

        /*
         * Returns a Input based on the given Key
         */

        public InputVal getInput(string key)
        {
            InputVal current = inputs[key];
            int isRef = isReference(key);
            switch (isRef)
            {
                case 1:
                    return new InputVal(inputs[current.valOne].valOne, current.valTwo);

                case 2:
                    return new InputVal(current.valOne, inputs[current.valTwo].valOne);

                case 3:
                    return new InputVal(inputs[current.valOne].valOne, inputs[current.valTwo].valTwo);

                default:
                    break;
            }

            return inputs[key];
        }

        /*
         * Is current string a reference to another key's value in inputs dictionary.
         */

        private int isReference(string key)
        {
            InputVal current = inputs[key];

            if (inputs.ContainsKey(current.valOne) && inputs.ContainsKey(current.valTwo))
            {
                return 3;
            }
            else if (inputs.ContainsKey(current.valOne))
            {
                return 1;
            }
            else if (inputs.ContainsKey(current.valTwo))
            {
                return 2;
            }

            return 0;
        }

        /*
         * sets key's value in a dictionary
         */

        public void setInput(string key, InputVal value)
        {
            inputs[key] = value;
        }

        /*
         * switch the selected option to the other
         */

        public void switchInput(string key)
        {
            inputs[key] = inputs[key].switchVal();
        }
    }
}