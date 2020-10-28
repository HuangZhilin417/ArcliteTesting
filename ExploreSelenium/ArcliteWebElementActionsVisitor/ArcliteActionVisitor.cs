using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;
namespace ExploreSelenium.ArcliteWebElementActionsVisitor
{
    //Repersents a visiting class for dealing with different button types
    public class ArcliteActionVisitor : IActionsVisitor
    {
        public WebDriverWait wait;
        public IWebDriver driver;
        //takes in a current page, driver wait, and current element
        public ArcliteActionVisitor(WebDriverWait wait, IWebDriver driver)
        {
            this.wait = wait;
            this.driver = driver;
        }

        public void switchFrame()
        {
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));
        }

        public void visitButton(ArcliteButton element)
        {
            IWebElement e;
            try
            {
                e = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(element._elementXPath)));
            }
            catch (ElementNotVisibleException eve)
            {
                throw eve;
            }
            try
            {
                e.Click();
            }
            catch (ElementClickInterceptedException)
            {
                driver.ExecuteJavaScript("arguments[0].click();", e);
            }
            catch (StaleElementReferenceException)
            {
                driver.ExecuteJavaScript("arguments[0].click();", e);
            }
        }

        public void visitCalender(ArcliteCalender element, InputVal wanted)
        {
            //clicks the calender
            IArcliteWebElement calender = new ArcliteButton(element.elementName, element.elementXPath);
            calender.accept(this, new InputVal());
            IArcliteWebElement nextMonth = new ArcliteButton(element.elementName, element._nextMonthXpath);
            nextMonth.accept(this, new InputVal());
            IArcliteWebElement date = new ArcliteButton(element.elementName, element._firstDateXpath);
            date.accept(this, new InputVal());
        }

        public void visitDataTable(ArcliteDataTable element, InputVal wanted)
        {

            IArcliteWebElement search = element._searchElement;
            search.accept(this, wanted);

            if (element._expand == null && wanted.valTwo == "")
            {
                
                IArcliteWebElement delete = new ArcliteButton("", element._tableEntryFirst + wanted.valOne + element._tableEntrySecond + element._deleteXpathWithEntry);
                delete.accept(this, new InputVal());
                element._confirmDelete.accept(this, new InputVal());
            }
            else if(element._expand != null && wanted.valTwo != "")
            {
       
                IArcliteWebElement expand = new ArcliteButton("", element._tableEntryFirst + wanted.valTwo + element._tableEntrySecond + element._expand);
                expand.accept(this, new InputVal());
                IArcliteWebElement delete = new ArcliteButton("", element._deleteFirst + wanted.valOne + element._deleteSecond);
                delete.accept(this, new InputVal());
                element._confirmDelete.accept(this, new InputVal());
            }
            else if (element._confirmDelete == null && element._cancelDelete == null)
            {
     
                IArcliteWebElement check = new ArcliteButton("", element._tableEntryFirst + wanted.valOne + element._tableEntrySecond + element._deleteXpathWithEntry);
                check.accept(this, new InputVal());
            }
            else
            {
                throw new ArgumentException("something is or is not null");
            }
        }
     

        public void visitSearch(ArcliteSearch arcliteSearch, InputVal wanted)
        {

            if(arcliteSearch._searchButtonXpath == null)
            {
                IArcliteWebElement search = new ArcliteTextBox("", arcliteSearch._searchInputXPath);
                search.accept(this, wanted);
            }
            else
            {
                IArcliteWebElement search = new ArcliteTextBox("", arcliteSearch._searchInputXPath);
                search.accept(this, wanted);
                IArcliteWebElement confirm = new ArcliteButton("", arcliteSearch._searchButtonXpath);
                confirm.accept(this, new InputVal());
            }

        }

        public void visitSelect(ArcliteSelect element, InputVal wanted)
        {
            
            IArcliteWebElement dropdown = new ArcliteButton(element.elementName, element._dropDownXpath);
            dropdown.accept(this, new InputVal());
            SelectElement selectElement = new SelectElement(driver.FindElement(By.XPath(element._selectXPath)));
            if (element._optionFirst == null)
            {
             
                //get the options as a select element 
                selectElement.SelectByText(wanted.valOne);
            }
            else
            {
                string dataVal = Util.getDataValue(wanted.valOne, selectElement);
                IArcliteWebElement selectOption = new ArcliteButton("", element._optionFirst + dataVal + element._optionSecond);
                selectOption.accept(this, new InputVal());
            }
            
        }

        public void visitTextBox(ArcliteTextBox element, InputVal wanted)
        {
            IWebElement input = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(element.elementXPath)));
            try
            {
                input.SendKeys(wanted.valOne);
            }
            catch (ElementClickInterceptedException ex)
            {
                driver.ExecuteJavaScript("arguments[0].value = '"+ wanted.valOne + "';", input);
            }
        }



    }
}
