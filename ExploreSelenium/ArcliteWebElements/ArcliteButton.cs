using ExploreSelenium.ArcliteInputs;
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
        public ArcliteWebElementType _elementType;

        public ArcliteButton(string name, string xPath) : base(name, xPath)
        {
            _elementName = base.elementName;
            _elementXPath = base.elementXPath;
            _elementType = ArcliteWebElementType.Button;
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitButton(this);
        }
    }
}
