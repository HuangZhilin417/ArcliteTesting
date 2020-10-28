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
    public class ArcliteTextBox : ArcliteWebElement, IArcliteWebElement
    {
        string _elementName;
        string _elementXPath;
        ArcliteWebElementType _elementType;
        public ArcliteTextBox(string name, string xPath) : base(name, xPath)
        {
            _elementName = base.elementName;
            _elementXPath = base.elementXPath;
            _elementType = ArcliteWebElementType.Textbox;
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitTextBox(this, input);
        }
    }
}
