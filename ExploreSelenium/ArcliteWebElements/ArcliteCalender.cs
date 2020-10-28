using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebElements
{
    public class ArcliteCalender : ArcliteWebElement, IArcliteWebElement
    {
        string _elementName;
        string _elementXPath;
        public string _nextMonthXpath;
        public string _firstDateXpath;
        IWebElement _element;
        ArcliteWebElementType _elementType;

        public ArcliteCalender(string name, string xPath, string nextMonthXpath, string firstDateXpath) : base(name, xPath)
        {
            _elementType = ArcliteWebElementType.Calender;
            _elementName = base.elementName;
            _elementXPath = base.elementXPath;
            _nextMonthXpath = nextMonthXpath;
            _firstDateXpath = firstDateXpath;
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitCalender(this, input);
        }
    }
}
