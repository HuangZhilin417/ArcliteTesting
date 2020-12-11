using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace ExploreSelenium.ArcliteWebElementActionsVisitor
{
    /*
     * Repersents a visiting class for dealing with different Arclite elements
     */

    public class ArcliteActionVisitor : IActionsVisitor
    {
        public WebDriverWait wait;
        public IWebDriver driver;
        public int longSleepTime = 4000;
        public int shortSleepTime = 2000;

        /*
         * takes in a web driver wait, and a driver to perfrom either wait or don't wait operations
         */

        public ArcliteActionVisitor(WebDriverWait wait, IWebDriver driver)
        {
            this.wait = wait;
            this.driver = driver;
        }

        /*
         * Switches to the main frame of Arclite, usually need to call this after clicking on a navigation tab button and want to access the content inside the tab
         */

        void IActionsVisitor.switchFrame()
        {
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("mainFrame"));
        }

        /*
         * Performs a click on a button
         */

        void IActionsVisitor.visitButton(ArcliteButton element)
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

        /*
         * select the next month's first day for a calender
         */

        void IActionsVisitor.visitCalender(ArcliteCalender element, InputVal wanted)
        {
            IArcliteWebElement calender = new ArcliteButton(element.elementName, element.elementXPath);
            calender.accept(this, new InputVal());
            IArcliteWebElement nextMonth;
            try
            {
                nextMonth = new ArcliteButton(element.elementName, element._nextMonthXpath);
                nextMonth.accept(this, new InputVal());
            }
            catch (WebDriverTimeoutException)
            {
                ((IActionsVisitor)this).visitCalender(element, wanted);
                return;
            }

            IArcliteWebElement date = new ArcliteButton(element.elementName, element._firstDateXpath);
            date.accept(this, new InputVal());
        }

        /*
         * Delete a entry from a table if no action is specified
         */

        void IActionsVisitor.visitDataTable(ArcliteDataTable element, InputVal wanted, ArcliteTestAction action = ArcliteTestAction.delete)
        {
            switch (action)
            {
                case ArcliteTestAction.delete:
                    deleteFromTable(element, wanted);
                    break;

                case ArcliteTestAction.check:
                    checkEntryFromTable(element, wanted);
                    break;

                default:
                    break;
            }
        }

        private void deleteFromTable(ArcliteDataTable element, InputVal wanted)
        {
            string text = wanted.getSelectedVal();

            IArcliteWebElement search = element._searchElement;
            search.accept(this, wanted);

            if (element._confirmDelete == null && element._cancelDelete == null)
            {
                IArcliteWebElement check = new ArcliteButton("", element._tableEntryFirst + text + element._tableEntrySecond + element._deleteXpathWithEntry);
                check.accept(this, new InputVal());
            }
            else if (element._expand == null)
            {
                IArcliteWebElement delete = new ArcliteButton("", element._tableEntryFirst + text + element._tableEntrySecond + element._deleteXpathWithEntry);
                delete.accept(this, new InputVal());
                element._confirmDelete.accept(this, new InputVal());
            }
            else if (element._expand != null)
            {
                IArcliteWebElement expand = new ArcliteButton("", element._tableEntryFirst + wanted.valTwo + element._tableEntrySecond + element._expand);
                expand.accept(this, new InputVal());
                IArcliteWebElement delete = new ArcliteButton("", element._deleteFirst + wanted.valOne + element._deleteSecond);
                delete.accept(this, new InputVal());
                element._confirmDelete.accept(this, new InputVal());
            }
            else
            {
                throw new ArgumentException("something is or is not null");
            }
        }

        private void checkEntryFromTable(ArcliteDataTable element, InputVal wanted)
        {
            string text = wanted.getSelectedVal();

            IArcliteWebElement search = element._searchElement;
            search.accept(this, wanted);

            if (element._confirmDelete == null && element._cancelDelete == null)
            {
                IArcliteWebElement check = new ArcliteButton("", element._tableEntryFirst + text + element._tableEntrySecond);
                check.accept(this, new InputVal());
            }
            else if (element._expand == null)
            {
                IArcliteWebElement delete = new ArcliteButton("", element._tableEntryFirst + text + element._tableEntrySecond);
                delete.accept(this, new InputVal());
            }
            else if (element._expand != null)
            {
                IArcliteWebElement expand = new ArcliteButton("", element._tableEntryFirst + wanted.valTwo + element._tableEntrySecond + element._expand);
                expand.accept(this, new InputVal());
            }
            else
            {
                throw new ArgumentException("something is or is not null");
            }
        }

        /*
         * Enter text in a search box and clicks on search button if there is one
         */

        void IActionsVisitor.visitSearch(ArcliteSearch arcliteSearch, InputVal wanted)
        {
            if (arcliteSearch._searchButtonXpath == null)
            {
                IArcliteWebElement search = new ArcliteTextBox("", arcliteSearch._searchInputXPath);
                search.accept(this, wanted);
                IWebElement webElement;
                webElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(search.elementXPath)));
                webElement.SendKeys(Keys.Enter);
            }
            else
            {
                IArcliteWebElement search = new ArcliteTextBox("", arcliteSearch._searchInputXPath);
                search.accept(this, wanted);
                IArcliteWebElement confirm = new ArcliteButton("", arcliteSearch._searchButtonXpath);
                confirm.accept(this, new InputVal());
            }
        }

        /*
         * selects from a dropdown with wanted option
         */

        void IActionsVisitor.visitSelect(ArcliteSelect element, InputVal wanted)
        {
            string text = wanted.getSelectedVal();
            IArcliteWebElement dropdown = new ArcliteButton(element.elementName, element._dropDownXpath);
            dropdown.accept(this, new InputVal());
            Thread.Sleep(shortSleepTime);
            SelectElement selectElement = new SelectElement(driver.FindElement(By.XPath(element._selectXPath)));
            if (element._optionFirst == null)
            {
                //get the options as a select element
                selectElement.SelectByText(text);
            }
            else
            {
                string dataVal = Util.getDataValue(text, selectElement);
                IArcliteWebElement selectOption = new ArcliteButton("", element._optionFirst + dataVal + element._optionSecond);
                selectOption.accept(this, new InputVal());
            }
        }

        /*
         * visit canvas in workflow builder and createds one step, and opens it
         */

        void IActionsVisitor.visitCanvas(ArcliteCanvas element, InputVal wanted)
        {
            int baseX = 170;
            int baseY = 130;

            int destX = int.Parse(wanted.valOne);
            int destY = int.Parse(wanted.valTwo);

            IWebElement canvas = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(element.elementXPath)));
            Actions click = new Actions(driver);

            element.addStep.accept(this, new InputVal());

            click.MoveToElement(canvas, baseX, baseY).ClickAndHold().Build().Perform();

            click.MoveByOffset(destX, destY).Build().Perform();

            click.Release().Build().Perform();

            click.MoveToElement(canvas, destX + baseX, destY + baseY).DoubleClick().Build().Perform();
        }

        /*
         * Enter text in the textbox
         */

        void IActionsVisitor.visitTextBox(ArcliteTextBox element, InputVal wanted)
        {
            string text = wanted.getSelectedVal();
            IWebElement input;
            long number = 0;
            bool canConvert = long.TryParse(text, out number);
            if (element._secondXPath == null)
            {
                try
                {
                    input = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(element.elementXPath)));
                    new ArcliteButton("", element.elementXPath).accept(this, new InputVal());
                }
                catch (WebDriverTimeoutException)
                {
                    input = driver.FindElement(By.XPath(element.elementXPath));
                }
            }
            else
            {
                input = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(element.elementXPath + wanted.valTwo + element._secondXPath)));
                new ArcliteButton("", element.elementXPath + wanted.valTwo + element._secondXPath).accept(this, new InputVal());
            }
            if (canConvert)
            {
                input.Clear();
                input.SendKeys(text);
            }
            else
            {
                driver.ExecuteJavaScript("arguments[0].value = '" + text + "';", input);
            }
        }

        /*
         * Switch to the parent frame
         */

        void IActionsVisitor.switchToParentFrame()
        {
            driver.SwitchTo().ParentFrame();
        }

        /*
         * gets the value from a textbox
         */

        string IActionsVisitor.getValue(ArcliteTextBox textbox)
        {
            IWebElement input;
            try
            {
                input = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(textbox.elementXPath)));
            }
            catch (WebDriverTimeoutException)
            {
                input = driver.FindElement(By.XPath(textbox.elementXPath));
            }
            string res = input.GetAttribute("value");
            return res;
        }

        /*
         * selects a attatchement in the attachement box, need to have a exact file location
         */

        public void visitAttachment(ArcliteAttachment element, InputVal input)
        {
            IWebElement fileUp = driver.FindElement(By.XPath(element.elementXPath));
            fileUp.SendKeys(input.valOne);
        }
    }
}