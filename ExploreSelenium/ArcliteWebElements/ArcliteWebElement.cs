using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace ExploreSelenium.ArcliteWebElements
{
    class ArcliteWebElement : IArcliteWebElement
    {
        string _elementName;
        string _elementXPath;
        IWebElement _element;
        ArcliteWebElementType _elementType;
        WebDriverWait wait;
        public ArcliteWebElement(string name, string xPath, ArcliteWebElementType type, WebDriverWait wait)
        {
            this.wait = wait;
            _elementName = name;
            _elementXPath = xPath;
            _elementType = type;
            this.setWebElement();
        }

        public string elementName { get => _elementName; set => _elementName = value; }
        public string elementXPath { get => _elementXPath; set => _elementXPath = value; }
        public ArcliteWebElementType elementType { get => _elementType; set => _elementType = value; }
        IWebElement IArcliteWebElement.webElement { get => _element; set => _element = value; }

        private void setWebElement()
        {
           this._element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(this._elementXPath)));
        }
    }
}
