using ExploreSelenium.ArcliteWebElementActionsVisitor;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebElements
{
    public class ArcliteButton : ArcliteWebElement, IArcliteWebElement
    {
        public string _elementName;
        public string _elementXPath;
        public IWebElement _element;
        public ArcliteWebElementType _elementType;
        WebDriverWait _wait;
        public ArcliteButton(string name, string xPath, ArcliteWebElementType type, WebDriverWait wait) : base(name, xPath, type, wait)
        {
            _elementName = base.elementName;
            _elementXPath = base.elementXPath;
            _elementType = base.elementType;
            _wait = wait;
            _element = base.webElement;
        }
        public ArcliteButton(string name, string xPath) : base(name, xPath, type)
        {
            _elementType = ArcliteWebElementType.Button;
        }

        new public void accept(IActionsVisitor visitor, string wanted)
        {
            visitor.visitButton(this);
        }
    }
}
