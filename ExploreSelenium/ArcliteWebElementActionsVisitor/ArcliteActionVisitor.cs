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
        WebDriverWait wait;
        IWebDriver driver;
        //takes in a current page, driver wait, and current element
        public ArcliteActionVisitor(WebDriverWait wait, IWebDriver driver)
        {
            this.wait = wait;
            this.driver = driver;
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
            catch (ElementClickInterceptedException ex)
            {
                driver.ExecuteJavaScript("arguments[0].click();", e);
            }
        }

        public void visitCalender(ArcliteCalender element, string wanted)
        {
            
            throw new NotImplementedException();
        }

        public void visitSelect(ArcliteSelect element, string wanted)
        {
     
            //clicks customer dropdown
            IWebElement customerDropDown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='select2-customer-container']")));


            //get the options as a select element 
            SelectElement selectCustomerElement = new SelectElement(driver.FindElement(By.XPath("//select[@id='customer']")));

            selectCustomerElement.SelectByText("BCisaFB");
        }


        public void visitTextBox(ArcliteTextBox element, string wanted)
        {
            try
            { 
                element.webElement.SendKeys(wanted);
            }
            catch (ElementClickInterceptedException ex)
            {
                driver.ExecuteJavaScript("arguments[0].value = '"+ wanted +"';", element.webElement);
            }
        }

    }
}
