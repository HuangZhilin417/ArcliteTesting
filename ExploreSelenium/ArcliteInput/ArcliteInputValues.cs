using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebPages;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Assets;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Checklists;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Customers;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Personnel;
using ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Suppliers;
using ExploreSelenium.ArcliteWebPages.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteInputs
{   public struct InputVal
    {
        public string valOne;
        public string valTwo;

        public InputVal(string val1, string val2)
        {
            this.valOne = val1;
            this.valTwo = val2;
        }

        public InputVal(string val1)
        {
            this.valOne = val1;
            this.valTwo = "";
        }
    }


    public class ArcliteInputValues : IArcliteInputs
    {
        Dictionary<string, InputVal> inputs = new Dictionary<string, InputVal>();
        InventoryXAWE inventoryInfo;
        PersonnelXAWE personnelInfo;
        LoginPageXAWE loginInfo;
        AssetsXAWE assetsInfo;
        CustomersXAWE customersInfo;
        SuppliersXAWE suppliersInfo;
        CheckListsXAWE checkListsInfo;
        public ArcliteInputValues()
        {
            inventoryInfo = new InventoryXAWE();
            personnelInfo = new PersonnelXAWE();
            loginInfo = new LoginPageXAWE();
            assetsInfo = new AssetsXAWE();
            customersInfo = new CustomersXAWE();
            suppliersInfo = new SuppliersXAWE();
            checkListsInfo = new CheckListsXAWE();
            this.initInputs();
        }

        private void initInputs()
        {
            inputs.Add(loginInfo.username.Key, new InputVal("admin"));
            inputs.Add(loginInfo.password.Key, new InputVal("admin"));

            inputs.Add(inventoryInfo.barcode.Key, new InputVal("945207352"));
            inputs.Add(inventoryInfo.inventoryItemType.Key, new InputVal("Iphone 12 Pro Max Super"));
            inputs.Add(inventoryInfo.name.Key, new InputVal("A lot of work to do"));
            inputs.Add(inventoryInfo.supplier.Key, new InputVal("Josh Huang"));
            inputs.Add(inventoryInfo.unitCost.Key, new InputVal("100"));
            inputs.Add(inventoryInfo.heldQuantity.Key, new InputVal("1499"));
            inputs.Add(inventoryInfo.currency.Key, new InputVal("Chinese Yuan"));
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

            inputs.Add(checkListsInfo.name.Key, new InputVal("daily to do list "));
            inputs.Add(checkListsInfo.categoryName.Key, new InputVal("new daily list"));
            inputs.Add(checkListsInfo.formNumber.Key, new InputVal("7925"));
            inputs.Add(checkListsInfo.revisionNumber.Key, new InputVal("94520"));
            inputs.Add(checkListsInfo.header.Key, new InputVal("head"));
            inputs.Add(checkListsInfo.footer.Key, new InputVal("foot"));
            inputs.Add(checkListsInfo.description.Key, new InputVal("daily checklist"));

        }


        public InputVal getInput(string key)
        {
            return inputs[key];
        }

        public void setInput(string key, InputVal value)
        {
            inputs[key] = value;
        }
    }
}
