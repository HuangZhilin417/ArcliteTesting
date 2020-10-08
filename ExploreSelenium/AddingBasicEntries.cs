using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ExploreSelenium.BaseCkass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;
using System.CodeDom.Compiler;
using NUnit.Framework.Internal.Commands;
using Microsoft.Win32;
using ExploreSelenium.BaseClass;

namespace ExploreSelenium
{
    [TestFixture]
    public class AddingBasicEntries : BaseTest, IArcliteVariable
    {
        [Test, Category("addSecond"), OrderAttribute(2)]
        public void addingInventory()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on inventory
            IWebElement inventory = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='inventory']")));
            inventory.Click();
            
            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks add inventory
            IWebElement addInventory = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-plus arc-fa-2x']")));
            addInventory.Click();

            //input value into barcode
            IWebElement barcode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='txtNewItemCustomBarcode']")));
            barcode.SendKeys("945207352");

            //clicks Inventory item type dropdown
            
            IWebElement unitDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='partialDdlItemType']/div/div/div[@class='fs-label']")));
            unitDropDown.Click();

            //get the options as a select element 
            SelectElement selectUnitElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='ddlItemTypeId']")));

            //select the wanted option
            IWebElement selectedUnitOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='fs-option g0'] [@data-value = '" + Util.getDataValue("Iphone 12 Pro Max Super", selectUnitElement) + "']")));
            selectedUnitOption.Click();

            //enter name for inventory
            IWebElement inventoryItemName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='txtSpecificItemName']")));
            inventoryItemName.SendKeys("A lot of work to do");


            //enter value for held quantity
            IWebElement heldQuantity = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtQuantity']")));
            heldQuantity.Clear();
            heldQuantity.SendKeys("100");

            //enter value for unit cost
            IWebElement unitCost = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtUnitCost']")));
            unitCost.Clear();
            unitCost.SendKeys("1499");

            //clicks Inventory item type dropdown
            IWebElement supplierDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='partialDdlSupplier']")));
            supplierDropDown.Click();

            //get the options as a select element 
            SelectElement selectSupplierElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='ddlSupplierId']")));
            
            //select the wanted option
            IWebElement selectedSupplierOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='partialDdlSupplier']/div/div[@class='fs-dropdown']/div/div[@data-value = '" + Util.getDataValue("Josh Huang", selectSupplierElement) + "']")));
            selectedSupplierOption.Click();

            //clicks save inventory item button
            IWebElement saveInventory = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSave'][@onclick='SaveUpdateItem(0)']")));
            saveInventory.Click();
        }

        [Test, Category("deleteFirst"), OrderAttribute(4)]
        public void deletingInventory ()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on inventory
            IWebElement inventory = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='inventory']")));
            inventory.Click();
            
            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tbInventoryItemType_filter']/label")));
            search.SendKeys("Iphone 12 Pro Max Super");

            //expand the inventory
            IWebElement expandInventory = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@role='row']/td[text()='Iphone 12 Pro Max Super']/parent::tr/td[@class=' details-control']")));
            expandInventory.Click();

            //click delete button
            IWebElement deleteButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='arc-btn-outline btn btn-sm pull-right button'][@title='Delete']")));
            deleteButton.Click();

            //click confirm delete button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteInventoryItem()']")));
            confirmButton.Click();
        }

        [Test, Category("addSecond"), OrderAttribute(2)]
        public void addingPersonnelManager()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on inventory
            IWebElement personnel = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='personnel']")));
            personnel.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //click add personnel
            IWebElement addPersonnel = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='AddEditPersonnel(0)']")));
            addPersonnel.Click();

            //enter value for user name
            IWebElement userName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtusername']")));
            userName.Clear();
            userName.SendKeys("BCisaFB");

            //enter value for first name
            IWebElement firstName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtfirstname']")));
            firstName.Clear();
            firstName.SendKeys("Josh");

            //enter value for last name
            IWebElement lastName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtlastname']")));
            lastName.Clear();
            lastName.SendKeys("Huang");

            //enter value for primary password
            IWebElement primaryPassword = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtPrimaryPassword']")));
            primaryPassword.Clear();
            primaryPassword.SendKeys("Itsme1234!");


            //enter value for confirm password
            IWebElement confirmPassword = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtConfirmPrimaryPassword']")));
            confirmPassword.Clear();
            confirmPassword.SendKeys("Itsme1234!");


            //enter value for email
            IWebElement email = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtPrimaryEmail']")));
            email.Clear();
            email.SendKeys("master@gmail.com");

            //enter value for department
            IWebElement department = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='select_departement']")));
            department.Clear();
            department.SendKeys("chrome");


            //enter value for title
            IWebElement title = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtposition']")));
            title.Clear();
            title.SendKeys("master");

            //clicks qualification dropdown
            IWebElement qualificationDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='partialDdlQualification']/div/div[@class='fs-label-wrap']")));
            qualificationDropDown.Click();

            //get the options as a select element 
            SelectElement selectQualificationElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='select_qua']")));

            //select the wanted option
            IWebElement selectedQualificationOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='partialDdlQualification']/div/div/div/div[@data-value = '" + Util.getDataValue("Best Nunchaku User", selectQualificationElement) + "']")));
            selectedQualificationOption.Click();

            //clicks role dropdown
            IWebElement roleDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='add-update-personnel']/div/div/div/label[text()='Role']/parent::div/div/div[@class='fs-label-wrap']")));
            roleDropDown.Click();

            //get the options as a select element 
            SelectElement selectRoleElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='select_role']")));

            //select the wanted option
            IWebElement selectedRoleOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='add-update-personnel']/div/div/div/div/div/div/div[@data-value = '" + Util.getDataValue("Admin", selectRoleElement) + "']")));
            selectedRoleOption.Click();

            //clicks save personnel button
            IWebElement savePersonnel = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSave'][@onclick='SaveUpdatePersonnel(0)']")));
            savePersonnel.Click();
        }
        [Test, Category("deleteFirst"), OrderAttribute(4)]
        public void disablePersonnel()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on inventory
            IWebElement personnel = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='personnel']")));
            personnel.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //click disable button
            IWebElement deleteButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='BCisaFB']/parent::tr/td/button[@value='Delete']")));
            deleteButton.Click();

            //click confirm delete button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeletePersonnel()']")));
            confirmButton.Click();
        }


        [Test, Category("addSecond"), OrderAttribute(2)]
        public void addingAssets()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on asset
            IWebElement asset = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='assets']")));
            asset.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

         
            
            //click add asset
            IWebElement addAsset = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='AddEditAsset(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", addAsset);

            //enter value for asset name
            IWebElement assetName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtNameAsset']")));
            assetName.Clear();
            assetName.SendKeys("A Chip");

            //clicks asset dropdown
            IWebElement assetTypeDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='partialDdlAssetType']/div/div[@class='fs-label-wrap']")));
            assetTypeDropDown.Click();

            //get the options as a select element 
            SelectElement selectAssetTypeElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='ParentAssetID']")));

            //select the wanted option
            IWebElement selectedAssetTypeOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='partialDdlAssetType']/div/div/div/div[@data-value = '" + Util.getDataValue("Support", selectAssetTypeElement) + "']")));
            selectedAssetTypeOption.Click();

            //enter value for serial
            IWebElement serial = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='MachineDetails_MachineSerial']")));
            serial.Clear();
            serial.SendKeys("94520735279253217");

            //enter value for description
            IWebElement description = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='MachineDetails_Description']")));
            description.Clear();
            description.SendKeys("big chip is the best ever");



            //clicks installed by dropdown
            IWebElement installedByDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='form-group']/label[text()='Installed By']/parent::div/div")));
            installedByDropDown.Click();

            //get the options as a select element 
            SelectElement selectInstalledByElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='PersonnelID']")));

            //select the wanted option
            IWebElement selectedInstalledByOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-group']/label[text()='Installed By']/parent::div/div/div/div/div[@data-value = '" + Util.getDataValue("Josh Huang", selectInstalledByElement) + "']")));
            selectedInstalledByOption.Click();

            //clicks qualification dropdown
            IWebElement qualificationDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='partialDdlQualification']/div/div[@class='fs-label-wrap']")));
            qualificationDropDown.Click();

            //get the options as a select element 
            SelectElement selectQualificationElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='select_qua']")));

            //select the wanted option
            IWebElement selectedQualificationOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='partialDdlQualification']/div/div/div/div[@data-value = '" + Util.getDataValue("Best Nunchaku Machine", selectQualificationElement) + "']")));
            selectedQualificationOption.Click();

            //select the track OEE
            IWebElement trackOEE = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='addEditAsset']/div/div/div/div/label[@class='arc-checkbox-label']")));
            trackOEE.Click();

            //clicks save personnel button
            IWebElement saveAsset = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSave'][@onclick='SaveUpdateAsset(0)']")));
            saveAsset.Click();

        }

        [Test, Category("deleteFirst"), OrderAttribute(4)]
        public void deletingAsset()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on asset
            IWebElement asset = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='assets']")));
            asset.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblAssetManagement_filter']/label")));
            search.SendKeys("A Chip");

            //click delete button
            IWebElement deleteButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@title='A Chip']/parent::tr/td/button[@title='Delete']")));
            deleteButton.Click();

            //click confirm delete button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteAsset()']")));
            confirmButton.Click();
        }


        [Test, Category("addSecond"), OrderAttribute(2)]
        public void addingCustomer()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on Customer
            IWebElement customer = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='customer']")));
            customer.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //click add Customer
            IWebElement addCustomer = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='AddEditCustomer(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", addCustomer);

            //enter value for name
            IWebElement name = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtNameCustomer']")));
            name.Clear();
            name.SendKeys("BCisaFB");

            //enter value for customer code
            IWebElement customerCode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='CustomerCode']")));
            customerCode.Clear();
            customerCode.SendKeys("9452");

            //enter value for contact name
            IWebElement contactName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ContactName']")));
            contactName.Clear();
            contactName.SendKeys("Bailey Clark");

            //enter value for contact number
            IWebElement contactNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ContactNumber']")));
            contactNumber.Clear();
            contactNumber.SendKeys("+1520520");


            //enter value for secondary number
            IWebElement secondaryNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='SecondaryNumber']")));
            secondaryNumber.Clear();
            secondaryNumber.SendKeys("+114141414");


            //enter value for email
            IWebElement email = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ContactEmail']")));
            email.Clear();
            email.SendKeys("baileyclark@gmail.com");

            //enter value for delivery address
            IWebElement deliveryAddress = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='DeliveryAddress']")));
            deliveryAddress.Clear();
            deliveryAddress.SendKeys("chrome");


            //enter value for notes
            IWebElement notes = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtCustomerNotes']")));
            notes.Clear();
            notes.SendKeys("never regret");

            //clicks person in charge dropdown
            IWebElement personInChargeDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@class='control-label'][text()='Person In Charge']/parent::div/div")));
            personInChargeDropDown.Click();

            //get the options as a select element 
            SelectElement selectPersonInChargeElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='ddlPersonInCharge']")));

            //select the wanted option
            IWebElement selectedPersonInChargeOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@class='control-label'][text()='Person In Charge']/parent::div/div/div/div/div/div[@data-value = '" + Util.getDataValue("Josh Huang", selectPersonInChargeElement) + "']")));
            selectedPersonInChargeOption.Click();

            //clicks save personnel button
            IWebElement saveCustomer = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSave'][@onclick='SaveUpdateCustomer(0)']")));
            saveCustomer.Click();
        }

        [Test, Category("deleteFirst"), OrderAttribute(4)]
        public void deletingCustomer()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on Customer
            IWebElement customer = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='customer']")));
            customer.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tbCustomer_filter']/label")));
            search.SendKeys("BCisaFB");

            //click delete button
            IWebElement deleteButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[@role='row']/td[text()='BCisaFB']/parent::tr/td/button[@title='Delete']")));
            driver.ExecuteJavaScript("arguments[0].click();", deleteButton);
            // this.retryClick(deleteButton);

            //click confirm delete button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteCustomer()']")));
            confirmButton.Click();
        }

        private void retryClick(IWebElement button)
        {
            int attempt = 0;
            bool result = false;
            while(attempt < 2)
            {
                try
                {
                    button.Click();
                    result = true;
                    break;
                }
                catch (OpenQA.Selenium.StaleElementReferenceException e)
                {
                    result = false;
                }
                attempt++;
            }
            if (result)
            {
                throw new StaleElementReferenceException();
            }
        }

        [Test, Category("addSecond"), OrderAttribute(2)]
        public void addingSupplier()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on Customer
            IWebElement supplier = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='supplier']")));
            supplier.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //click add Customer
            IWebElement addCustomer = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='AddEditSupplier(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", addCustomer);

            //enter value for name
            IWebElement name = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtNameSupplier']")));
            name.Clear();
            name.SendKeys("Caleb Furnas");

            //enter value for supplier code
            IWebElement supplierCode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='SupplierCode']")));
            supplierCode.Clear();
            supplierCode.SendKeys("9452");

            //enter value for contact name
            IWebElement contactName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ContactName']")));
            contactName.Clear();
            contactName.SendKeys("Caleb");

            //enter value for contact number
            IWebElement contactNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ContactNumberPrimary']")));
            contactNumber.Clear();
            contactNumber.SendKeys("+1520520");


            //enter value for secondary number
            IWebElement secondaryNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ContactNumberSecondary']")));
            secondaryNumber.Clear();
            secondaryNumber.SendKeys("+114141414");


            //enter value for email
            IWebElement email = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ContactEmail']")));
            email.Clear();
            email.SendKeys("calebFurnas@gmail.com");

            //enter value for address
            IWebElement address = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='Address']")));
            address.Clear();
            address.SendKeys("chrome");


            //enter value for notes
            IWebElement notes = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='Notes']")));
            notes.Clear();
            notes.SendKeys("never regret");

            //clicks person in charge dropdown
            IWebElement personInChargeDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@class='control-label'][text()='Person In Charge']/parent::div/div")));
            personInChargeDropDown.Click();

            //get the options as a select element 
            SelectElement selectPersonInChargeElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='ddlPersonInCharge']")));

            //select the wanted option
            IWebElement selectedPersonInChargeOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@class='control-label'][text()='Person In Charge']/parent::div/div/div/div/div/div[@data-value = '" + Util.getDataValue("Josh Huang", selectPersonInChargeElement) + "']")));
            selectedPersonInChargeOption.Click();

            //enter value for notes
            IWebElement description = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='Description']")));
            description.Clear();
            description.SendKeys("my best friend");

            //clicks save personnel button
            IWebElement saveCustomer = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSave'][@onclick='SaveUpdateSupplier(0)']")));
            saveCustomer.Click();
        }

        [Test, Category("deleteFirst"), OrderAttribute(4)]
        public void deletingSupplier()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on supplier
            IWebElement supplier = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='supplier']")));
            supplier.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tbSupplier_filter']/label")));
            search.SendKeys("Caleb Furnas");

            //click delete button
            IWebElement deleteButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[@role='row']/td[text()='Caleb Furnas']/parent::tr/td/a/i")));
            deleteButton.Click();

            //click confirm delete button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteSupplier()']")));
            confirmButton.Click();
        }



            [Test, Category("addSecond"), OrderAttribute(2)]
        public void addingChecklist()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click(); 


            //clicks on checklist
            IWebElement checklist = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='checklist']")));
            checklist.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //click add checklist
            IWebElement addChecklist = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@title='Add Checklist']/i")));
            driver.ExecuteJavaScript("arguments[0].click();", addChecklist);

            //enter value for name
            IWebElement name = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtTemplateName']")));
            name.Clear();
            name.SendKeys("daily to do list");

            //click add category
            IWebElement addCategory = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='ShowAddChecklistCategoryPopup()']")));
            addCategory.Click();

            //enter value for name
            IWebElement categoryName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtCategoryName']")));
            driver.ExecuteJavaScript("arguments[0].value = 'new daily list';", categoryName);

            //clicks save category button
            IWebElement saveCategory = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSaveCategory']")));
            saveCategory.Click();
          

            //enter value for form number
            IWebElement formNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtFileNo']")));
            driver.ExecuteJavaScript("arguments[0].value = '7925';", formNumber);

            //enter value for revision number
            IWebElement revisionNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtRevisionNo']")));
            driver.ExecuteJavaScript("arguments[0].value = '94520';", revisionNumber);
     

            //enter value for header
            IWebElement header = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtHeader']")));
            driver.ExecuteJavaScript("arguments[0].value = 'head';", header);


            //enter value for footer
            IWebElement footer = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtFooter']")));
            driver.ExecuteJavaScript("arguments[0].value = 'foot';", footer);


            //enter value for description
            IWebElement description = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='txtDescription']")));
            driver.ExecuteJavaScript("arguments[0].value = 'daily checklist';", description);

            Thread.Sleep(2000);
  
            //clicks save button
            IWebElement save = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSaveChecklist']")));
            driver.ExecuteJavaScript("arguments[0].click();", save);
        }
     /*   [Test, Category("deleteFirst"), OrderAttribute(1)]
        public void deleteChecklist()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on checklist
            IWebElement checklist = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='checklist']")));
            checklist.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='pnlChecklistGrid']/div/div/label")));
            search.SendKeys("new daily list");


            IWebElement expand = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@class='sorting_1'][text()='new daily list']/parent::tr/td")));
            expand.Click();

            IWebElement deleteList = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@width='150px'][text()='daily to do list']/parent::tr/td/a[@title='Click to Delete']/i")));
            deleteList.Click();

            //click confirm delete button
            IWebElement confirm = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteChecklist();']/i")));
            confirm.Click();

            IWebElement manageCategories = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='checklist-action']/a")));
            driver.ExecuteJavaScript("arguments[0].click();", manageCategories);

            IWebElement delete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[@role='row']/td[text()='new daily list ']/parent::tr/td/a[@title='Click to Delete']")));
            delete.Click();


            //click confirm delete button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteChecklistCategory();']")));
            confirmButton.Click();
            
        }*/


        [Test, Category("addFirst"), OrderAttribute(1)]
        public void addCustomFieldInputControlInventoryItem()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));
           
            //clicks on custom field
            IWebElement customField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='customfield']")));
            customField.Click();

            //clicks on add input control
            IWebElement addInputControl = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-targetmodal='modalNewField']")));
            addInputControl.Click();

           
            //enter value for field name
            IWebElement fieldName = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtColumnKey']")));
            fieldName.SendKeys("big o");

            //enter value for field name
            IWebElement dataType = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='fieldType']")));
            SelectElement dataSelect = new SelectElement(dataType);
            dataSelect.SelectByIndex(1);

            //enter value for help text
            IWebElement helpText = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtHelpText']")));
            helpText.SendKeys("help the big o");

            //enter value for min value
            IWebElement minVlaue = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtMinValue']")));
            minVlaue.SendKeys("0");

            //enter value for max value
            IWebElement maxVlaue = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtMaxValue'][@name='MaxValue']")));
            maxVlaue.SendKeys("100");

            //clicks on is required check box
            IWebElement isRequired = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@class='arc-checkbox-label']")));
            isRequired.Click();

            //clicks on save
            IWebElement save = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-save arc-fa-2x']")));
            save.Click();

            /* //enter value for field name
             IWebElement dataType = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='fieldType']")));
             SelectElement dataSelect = new SelectElement(dataType);
             dataSelect.SelectByIndex(1);*/
        }

        [Test, Category("deleteSecond"), OrderAttribute(5)]
        public void deleteCustomFieldInputControlInventoryItem()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on custom field
            IWebElement customField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='customfield']")));
            customField.Click();

            //clicks on delete
            IWebElement delete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr/td[text()='big_o']/parent::tr/td/a[@title='Click to Delete']")));
            delete.Click();

            //confirm button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='removeColumn()']/i")));
            confirmButton.Click();
        }

            [Test, Category("addFirst"), OrderAttribute(1)]
        public void addInventoryItemType()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on Inventory Item Type
            IWebElement inventoryItemType = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='itemtype']/div")));
            inventoryItemType.Click();

            
            //clicks on add
            IWebElement add = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-plus arc-fa-2x']")));
            driver.ExecuteJavaScript("arguments[0].click();", add);


            //enter value for name
            IWebElement name = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtItemTypeName']")));
            driver.ExecuteJavaScript("arguments[0].value = 'Iphone 12 Pro Max Super';", name);

            //enter value for description
            IWebElement description = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@id='txtItemTypeDescription']")));
            driver.ExecuteJavaScript("arguments[0].value = 'the brand new Iphone, cost 1499$';", description);

            //enter value for min quantity
            IWebElement minQuantity = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtItemTypeMinQuantity']")));
            minQuantity.Clear();
            driver.ExecuteJavaScript("arguments[0].value = '100';", minQuantity);

            //enter value for max quantity
            IWebElement maxQuantity = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtItemTypeMaxQuantity']")));
            maxQuantity.Clear();
            driver.ExecuteJavaScript("arguments[0].value = '100000';", maxQuantity);

            //enter value for reorder quantity
            IWebElement reorderQuantity = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtItemTypeReorderQuantity']")));
            reorderQuantity.Clear();
            driver.ExecuteJavaScript("arguments[0].value = '100';", reorderQuantity);

            Thread.Sleep(3000);

            //clicks unit dropdown
            IWebElement unitDropDown = driver.FindElement(By.XPath("//div[@id='partialddlUOM']/div"));
            unitDropDown.Click();
            driver.ExecuteJavaScript("arguments[0].click();", unitDropDown);

            //get the options as a select element 
            SelectElement selectUnit = new SelectElement(driver.FindElement(By.XPath("//select[@id='ddlUnitOfMeasurementId']")));

            //select the wanted option
            IWebElement selectedUnitOption = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='partialddlUOM']/div/div/div/div[@data-value = '" + Util.getDataValue("count", selectUnit) + "']")));
            driver.ExecuteJavaScript("arguments[0].click();", selectedUnitOption);

            //click save
            IWebElement save = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='btnSave'][@onclick='SaveUpdateItemType(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", save);


        }


        [Test, Category("deleteSecond"), OrderAttribute(5)]
        public void deleteInventoryItemType()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on Inventory Item Type
            IWebElement inventoryItemType = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='itemtype']/div")));
            inventoryItemType.Click();

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tbInventoryItemType_filter']/label")));
            search.SendKeys("Iphone 12 Pro Max Super");

            //clicks on delete
            IWebElement delete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[@role='row']/td[text()='Iphone 12 Pro Max Super']/parent::tr/td/button")));
            delete.Click();

            //confirm button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteInventoryItemType()']/i")));
            confirmButton.Click();
        }

        [Test, Category("addFirst"), OrderAttribute(1)]
        public void addUnit()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on Unit
            IWebElement unit = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='unit']/div")));
            unit.Click();

            //clicks on add
            IWebElement add = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='AddEditUOM(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", add);

            //enter value for name
            IWebElement name = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtNameUOM']")));
            name.SendKeys("count");
            //driver.ExecuteJavaScript("arguments[0].value = '100';", name);


            //enter value for symbol
            IWebElement symbol = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtSymbolUOM']")));
            symbol.SendKeys("p");

            //click save
            IWebElement save = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='btnSave'][@onclick='SaveUpdateUOM(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", save);


        }


        [Test, Category("deleteSecond"), OrderAttribute(5)]
        public void deleteUnit()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on Unit
            IWebElement unit = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='unit']/div")));
            unit.Click();

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tbl_UOMUnitlist_filter']/label")));
            search.SendKeys("count");

            //clicks on delete
            IWebElement delete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='count']/parent::tr/td/button")));
            delete.Click();

            //confirm button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteUOM()']/i")));
            confirmButton.Click();

        }

        [Test, Category("addFirst"), OrderAttribute(1)]
        public void addCurrency()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on currency
            IWebElement currency = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='currency']/div")));
            currency.Click();

            //clicks on add
            IWebElement add = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='AddEditUOM(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", add);

            //enter value for name
            IWebElement name = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtNameUOM']")));
            name.SendKeys("Chinese Yuan");
            //driver.ExecuteJavaScript("arguments[0].value = '100';", name);


            //enter value for symbol
            IWebElement symbol = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtSymbolUOM']")));
            symbol.SendKeys("Y");

            //click save
            IWebElement save = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='btnSave'][@onclick='SaveUpdateUOM(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", save);


        }


        [Test, Category("deleteSecond"), OrderAttribute(5)]
        public void deleteCurrency()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on currency
            IWebElement currency = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='currency']/div")));
            currency.Click();

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tbl_UOMCurrencylist_filter']/label")));
            search.SendKeys("Chinese Yuan");

            //clicks on delete
            IWebElement delete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='Chinese Yuan']/parent::tr/td/button")));
            delete.Click();

            //confirm button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteUOM()']/i")));
            confirmButton.Click();

        }



        [Test, Category("addFirst"), OrderAttribute(1)]
        public void addLocationManager()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on location manager
            IWebElement locationManager = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='warehouse']/div")));
            locationManager.Click();

            //clicks on add
            IWebElement add = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='btn-add-warehouse']")));
            driver.ExecuteJavaScript("arguments[0].click();", add);

            //enter value for name
            IWebElement name = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='warehouseLocation']")));
            name.SendKeys("California");
            //driver.ExecuteJavaScript("arguments[0].value = '100';", name);

            //enter value for code
            IWebElement code = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='warehouseNumber']")));
            code.SendKeys("1234");

            //enter value for description
            IWebElement description = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@id='warehouseDescription']")));
            description.SendKeys("The first warehouse in California");

            //click save
            IWebElement save = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn arc-btn-icon']")));
            driver.ExecuteJavaScript("arguments[0].click();", save);


        }


        [Test, Category("deleteSecond"), OrderAttribute(5)]
        public void deleteLocationManager()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on location manager
            IWebElement locationManager = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='warehouse']/div")));
            locationManager.Click();

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='type-list_filter']/label")));
            search.SendKeys("California");

            //clicks on delete
            IWebElement delete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@title='California']/parent::tr/td/a")));
            delete.Click();

            //confirm button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteWatehouseById()']/i")));
            confirmButton.Click();

        }


        [Test, Category("addFirst"), OrderAttribute(1)]
        public void addPersonnelQualification()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on qualification
            IWebElement qualification = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='qualification']/div")));
            qualification.Click();

            //clicks on add
            IWebElement add = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@onclick='AddEditQualification(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", add);

            //enter value for name
            IWebElement name = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtNameQ']")));
            name.SendKeys("Best Nunchaku User");
            //driver.ExecuteJavaScript("arguments[0].value = '100';", name);


            Thread.Sleep(2000);

            //clicks type dropdown
            IWebElement typeDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divQualificationType']/div")));
            typeDropDown.Click();

            //get the options as a select element 
            SelectElement selectTypeElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='ddlQualificationType']")));

            //select the wanted option
            IWebElement selectedTypeOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='divQualificationType']/div/div/div/div[@data-value = '" + Util.getDataValue("Personnel", selectTypeElement) + "']")));
            selectedTypeOption.Click();


            //enter value for description
            IWebElement description = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@id='txtDescQ']")));
            description.SendKeys("name says it all");

            //click save
            IWebElement save = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@onclick='SaveUpdateQualification(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", save);


        }


        [Test, Category("deleteSecond"), OrderAttribute(5)]
        public void deletePersonnelQualification()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on qualification
            IWebElement qualification = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='qualification']/div")));
            qualification.Click();

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='qa_table_filter']/label")));
            search.SendKeys("Best Nunchaku User");

            //clicks on delete
            IWebElement delete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='Best Nunchaku User ']/parent::tr/td/button")));
            delete.Click();

            //confirm button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteQualification()']/i")));
            confirmButton.Click();

        }



        [Test, Category("addFirst"), OrderAttribute(1)]
        public void addMachineQualification()
        {
            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on qualification
            IWebElement qualification = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='qualification']/div")));
            qualification.Click();

            //clicks on add
            IWebElement add = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@onclick='AddEditQualification(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", add);

            //enter value for name
            IWebElement name = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtNameQ']")));
            name.SendKeys("Best Nunchaku Machine");
            //driver.ExecuteJavaScript("arguments[0].value = '100';", name);
            Thread.Sleep(2000);

            //clicks type dropdown
            IWebElement typeDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divQualificationType']/div")));
            typeDropDown.Click();

            //get the options as a select element 
            SelectElement selectTypeElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='ddlQualificationType']")));

            //select the wanted option
            IWebElement selectedTypeOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='divQualificationType']/div/div/div/div[@data-value = '" + Util.getDataValue("Machine", selectTypeElement) + "']")));
            selectedTypeOption.Click();


            //enter value for description
            IWebElement description = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@id='txtDescQ']")));
            description.SendKeys("name says it all");

            //click save
            IWebElement save = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@onclick='SaveUpdateQualification(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", save);


        }


        [Test, Category("deleteSecond"), OrderAttribute(5)]
        public void deleteMachineQualification()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on qualification
            IWebElement qualification = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='qualification']/div")));
            qualification.Click();

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='qa_table_filter']/label")));
            search.SendKeys("Best Nunchaku Machine");

            //clicks on delete
            IWebElement delete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='Best Nunchaku Machine ']/parent::tr/td/button")));
            delete.Click();

            //confirm button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteQualification()']/i")));
            confirmButton.Click();

        }

        //adds the Asset Type
        [Test, Category("addFirst"), OrderAttribute(1)]
        public void addAssetType()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks on asset type
            IWebElement assetType = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='assetType']/div")));
            assetType.Click();

            //clicks on add
            IWebElement add = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='AddEditAssetType(0,0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", add);

            //enter value for name
            IWebElement name = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='AssetTypeName']")));
            name.SendKeys("Support");
            Thread.Sleep(1000);

            //enter value for description
            IWebElement description = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@id='AssetTypeDescription']")));
            description.SendKeys("Support the  chip");

            //click save
            IWebElement save = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@onclick='SaveUpdateAssetType(0)']")));
            driver.ExecuteJavaScript("arguments[0].click();", save);


        }

        //delete the created asset type
        [Test, Category("deleteSecond"), OrderAttribute(5)]
        public void deleteAssetType()
        {

            //clicks the gear button
            IWebElement gear = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='fa fa-cog arc-fa-2x']")));
            gear.Click();

            //clicks on settings
            IWebElement settings = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='settings']")));
            settings.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));


            //clicks on asset type
            IWebElement assetType = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-settings='assetType']/div")));
            assetType.Click();

            //search for item
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblAssetTypeManagement_filter']/label")));
            search.SendKeys("Support");

            //clicks on delete
            IWebElement delete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='Support']/parent::tr/td/button")));
            delete.Click();

            //confirm button
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='DeleteAssetType()']/i")));
            confirmButton.Click();

        }


    }


   

}