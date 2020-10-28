using ExploreSelenium.BaseCkass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Interactions;
using ExploreSelenium.ArcliteWebPages;

namespace ExploreSelenium
{
    [TestFixture]
    public class AddSalesOrderAndPush : BaseTest
    {

        [Test, OrderAttribute(3), Category("addThird")]
        public void addSalesOrder()
        {
         
            //clicks the add sales order button
            IWebElement trackingOrderAndManagement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='arc-scheduler-sales']")));
            driver.ExecuteJavaScript("arguments[0].click();", trackingOrderAndManagement);

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks the add sales order
            IWebElement addSalesOrder = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='add_sales_order']")));
            driver.ExecuteJavaScript("arguments[0].click();", addSalesOrder);

            //enter value for name
            IWebElement quotationNum = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='quo-no']")));
            driver.ExecuteJavaScript("arguments[0].value = '94527925';", quotationNum);
            Thread.Sleep(1000);

            //clicks customer dropdown
            IWebElement customerDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='select2-customer-container']")));
            customerDropDown.Click();


            //get the options as a select element 
            SelectElement selectCustomerElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='customer']")));
            selectCustomerElement.SelectByText("BCisaFB");
           

            //enter value for order
            IWebElement order = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='po-no']")));
            driver.ExecuteJavaScript("arguments[0].value = 'Iphone 12 Pro Max';", order);









            //enter value for details
            IWebElement details = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@id='detail']")));
            driver.ExecuteJavaScript("arguments[0].value = 'adding sales order from selenium test method';", details);

            //clicks the calender
            IWebElement calender = driver.FindElement(By.XPath("//div[@id='requested-end-date-dtp']/span"));
            driver.ExecuteJavaScript("arguments[0].click();", calender);

            //clicks next month on the calender
            IWebElement nextMonth = driver.FindElement(By.XPath("//div/ul/li/div[@class='datepicker']/div[@class='datepicker-days']/table/thead/tr/th[@class='next']"));
            nextMonth.Click();

            //clicks next month's first day
            IWebElement clickDate = driver.FindElement(By.XPath("//tr/td[text()='1']"));
            clickDate.Click();

            //adds a job
            addJobSubTestInAddSalesOder();

            addCheckListInJob("false");

            //clicks next month's first day
            IWebElement submit = driver.FindElement(By.XPath("//button[@id='complete-so']"));
            driver.ExecuteJavaScript("arguments[0].click();", submit);


            /*//select the wanted option
            IWebElement selectedCustomerOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='fs-option g0'] [@data-value = '" + Util.getDataValue("BCisaFB", selectCustomerElement) + "']")));
            selectedCustomerOption.Click();*/

        }


        [Test, OrderAttribute(4), Category("addThird")]
        public void pushJobToSchedule()
        {
            //clicks the sales order
            IWebElement salesOrder = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='arc-scheduler-jobs']")));
            salesOrder.Click();

            //clicks the jobs to schedule
            IWebElement jobsToSchedule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='jobs-to-schedule']")));
            jobsToSchedule.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            

            //search for customer
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblJobsGrid_length']/input")));
            searchInput.SendKeys("BCisaFB");

            //div[@id='tblJobsGrid_length']/button[@id='btnSearch']
            //clicks the search button
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblJobsGrid_length']/button[@id='btnSearch']")));
            search.Click();

            //clicks the check button
            IWebElement checkJobBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='BCisaFB']/parent::tr/td/div/label")));
            checkJobBox.Click();

            //clicks the gear button
            IWebElement schedule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblJobsGrid_filter']/button[@id='btnSchedule']")));
            schedule.Click();

        }


        [Test, OrderAttribute(5), Category("deleteSecond")]
        public void deleteSalesOrder()
        {
            //clicks the sales button
            IWebElement salesOrder = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='arc-scheduler-sales']")));
            salesOrder.Click();

            //switch frame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));

            //clicks the delete button
            IWebElement delete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='BCisaFB']/parent::tr/td/a[@title='Delete']/i")));
            delete.Click();

            //clicks the delete button
            IWebElement confirm = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='confirm_sch_so_delete']")));
            confirm.Click();


        }

            public void addJobSubTestInAddSalesOder()
        {
            string workflowName = "notebook manu.";

            //clicks add job
            IWebElement addJob = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div/button[text()='Columns']/parent::div/a/i")));
            addJob.Click();

            //enter value for order
            IWebElement notes = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@id='txt_NOTES']")));
            driver.ExecuteJavaScript("arguments[0].value = 'this is adding job for selenium testing';", notes);

            addCheckListInJob("true");            

            


            //clicks add finished good item type
            IWebElement goodItemType = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='selected-items']")));
            goodItemType.Click();

            //clicks other finished good item type
            IWebElement other = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='otherParts()']")));
            other.Click();

            //search for created list
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='table-parts-list_filter']/label/input")));
            search.SendKeys("Iphone 12 Pro Max Super" + Keys.Enter);

            //clicks other finished good item type
            IWebElement selectGood = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[@data-name='Iphone 12 Pro Max Super']/td/div/label")));
            selectGood.Click();

            //quantity
            IWebElement quantity = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[@data-name='Iphone 12 Pro Max Super']/td/input")));
            quantity.Clear();
            quantity.SendKeys("100");

            //clicks other finished good item type
            IWebElement save = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='confirmSelectItems()']")));
            save.Click();

            //clicks other finished good item type
            IWebElement workflow = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='select2-workflows-container']")));
            workflow.Click();
            Thread.Sleep(2000);
            //get the options as a select element 
            SelectElement select = new SelectElement(driver.FindElement(By.XPath("//select[@id='workflows']")));

            select.SelectByText(workflowName);

            //clicks other finished good item type
            IWebElement confirm = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='add-wo']")));
            driver.ExecuteJavaScript("arguments[0].click();", confirm);

        }

        //select the workflow based on name
        public void selectWorkflow(string name, SelectElement select) {
            if (name.Equals("") || name.Equals(null))
            {
                select.SelectByValue("1");
            }
            else
            {
                try
                {
                    select.SelectByText(name);
                }
                catch(Exception e)
                {
                    select.SelectByValue("1");
                }
            }
            }

        //adding a check list in job, if true then it adds in the add sales order -> add job -> add checklist, if false it adds in the add sales order -> add checklist
        public void addCheckListInJob(String trueOrFalse)
        {
            //clicks add checklist
            IWebElement addChecklist = driver.FindElement(By.XPath("//a[@onclick='GetChecklists(" + trueOrFalse + ")']"));
            driver.ExecuteJavaScript("arguments[0].click();", addChecklist);

            //search for created list
            IWebElement search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblChecklists_filter']/label/input")));
            search.SendKeys("daily to do list" + Keys.Enter);
            //driver.ExecuteJavaScript("arguments[0].value = 'daily to do list';", search);

            //clicks select checklist
            IWebElement selectChecklist = driver.FindElement(By.XPath("//td[text()='94520']/parent::tr/td/div/label"));
            driver.ExecuteJavaScript("arguments[0].click();", selectChecklist);

            //clicks add checklist
            IWebElement add = driver.FindElement(By.XPath("//a[@id='btnAddChecklists']"));
            driver.ExecuteJavaScript("arguments[0].click();", add);


        }

      

    }
}
