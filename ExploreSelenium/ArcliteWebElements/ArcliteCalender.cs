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
        IWebElement _element;
        ArcliteWebElementType _elementType;
        public ArcliteCalender(string name, string xPath, ArcliteWebElementType type, WebDriverWait wait) : base(name, xPath, type, wait)
        {
            
        }

        public ArcliteCalender(string name, string xPath, string nextMonthXpath, string firstDateXpath) : base()
        {
            _elementType = ArcliteWebElementType.Calender;
            _elementName = base.elementName;
            _elementXPath = base.elementXPath;
        }

        new public void accept(IActionsVisitor visitor, string wanted)
        {
            visitor.visitCalender(this, wanted);
        }
    }
}
